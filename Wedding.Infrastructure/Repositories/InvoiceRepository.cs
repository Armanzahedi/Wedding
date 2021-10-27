using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Wedding.Core.Models;
using Wedding.Core.Utility;
using Wedding.Infrastructure.Context;
using Wedding.Infrastructure.DTOs;
using Wedding.Infrastructure.ExtensionMethods;
using Exception = System.Exception;

namespace Wedding.Infrastructure.Repositories
{
    public interface IInvoiceRepository : IBaseRepository<Invoice>
    {
        Task<List<Invoice>> GetByCustomerId(int customerId);
        Task<string> PayInvoice(PayInvoiceDto model);
        Task<bool> ProccessInvoice(int invoiceId, PaymentStatus paymentStatus);
    }
    public class InvoiceRepository : BaseRepository<Invoice>, IInvoiceRepository
    {
        private readonly MyDbContext _context;
        private readonly ILogRepository _logger;
        private readonly IWalletRepository _walletRepo;
        private readonly IWalletTransactionRepository _transactionRepo;

        public InvoiceRepository(MyDbContext context, ILogRepository logger, IWalletRepository walletRepo, IWalletTransactionRepository transactionRepo) : base(context, logger)
        {
            _context = context;
            _logger = logger;
            _walletRepo = walletRepo;
            _transactionRepo = transactionRepo;
        }

        public async Task<List<Invoice>> GetByCustomerId(int customerId)
        {
            return await base.GetDefaultQuery().AsQueryable().Where(i => i.CustomerId == customerId)
                .OrderByDescending(i=>i.CreateDate)
                .ToListAsync();
        }

        public async Task<string> PayInvoice(PayInvoiceDto model)
        {
            var invoice = await base.GetById(model.Id);
            var redirectUrl = model.Referer.AddPaymentResultToUrl(result: true);

            if (model.OnlinePayment)
            {
                redirectUrl = $"/Payment/PaymentRequest/{invoice.Id}?referer={model.Referer}";

                invoice.InvoicePaymentMethod = InvoicePaymentMethod.Online;
                invoice.PaymentAmount = invoice.Amount;

                var wallet = await _walletRepo.GetByCustomerId(invoice.CustomerId);
                if (model.UseWallet && wallet.Balance > 0)
                {

                    // wallet balance is enough no need for payment gateway
                    if (wallet.Balance > invoice.PaymentAmount)
                    {
                        invoice.PaymentAmount = 0;
                        invoice.WalletAmount = invoice.Amount;
                        invoice.InvoicePaymentMethod = InvoicePaymentMethod.Wallet;
                        invoice.IsPayed = true;
                        wallet.Balance -= invoice.Amount;

                        var transaction = new WalletTransaction
                        {
                            WalletId = wallet.Id,
                            TransactionType = WalletTransactionType.Payment,
                            TransactionStatus = WalletTransctionStatus.Processed,
                            Amount = invoice.Amount,
                            CreateDate = DateTime.Now,
                            InvoiceId = invoice.Id
                        };
                        await _transactionRepo.Add(transaction);
                        await _walletRepo.Update(wallet);
                        redirectUrl = model.Referer.AddPaymentResultToUrl(result: true);
                    }
                    else
                    {
                        invoice.PaymentAmount = invoice.Amount - wallet.Balance;
                        invoice.WalletAmount = invoice.Amount - invoice.PaymentAmount;
                        invoice.InvoicePaymentMethod = InvoicePaymentMethod.OnlineAndWallet;
                    }
                }
            }
            else
            {
                invoice.PaymentAmount = 0;
                invoice.InvoicePaymentMethod = InvoicePaymentMethod.Wire;
                invoice.Receipt = model.Receipt;
                invoice.IsPayed = true;
            }

            await base.Update(invoice);
            return redirectUrl;
        }

        public async Task<bool> ProccessInvoice(int invoiceId,PaymentStatus paymentStatus)
        {
            try
            {
                var invoice = await base.GetById(invoiceId);
                invoice.ProcessedDate = DateTime.Now;
                invoice.IsPayed = paymentStatus == PaymentStatus.Payed;
                await base.Update(invoice);
                if (invoice.IsPayed)
                {
                    if (invoice.InvoicePaymentMethod == InvoicePaymentMethod.OnlineAndWallet)
                    {
                        var wallet = await _walletRepo.GetByCustomerId(invoice.CustomerId);
                        wallet.Balance -= invoice.WalletAmount;

                        await _walletRepo.Update(wallet);

                        var transction = new WalletTransaction
                        {
                            WalletId = wallet.Id,
                            CreateDate = DateTime.Now,
                            TransactionType = WalletTransactionType.Payment,
                            Amount = invoice.WalletAmount,
                            TransactionStatus = WalletTransctionStatus.Processed,
                            InvoiceId = invoice.Id
                        };

                        await _transactionRepo.Add(transction);
                    }
                }
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
