using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Wedding.Core.Models;
using Wedding.Core.Utility;
using Wedding.Infrastructure.Context;
using Wedding.Infrastructure.DTOs;

namespace Wedding.Infrastructure.Repositories
{
    public interface IWalletRepository : IBaseRepository<Wallet>
    {
        Task<Wallet> GetByCustomerId(int customerId);
        Task<long> GetBalance(int walletId);
        Task<List<WalletTransaction>> GetTransactionHistory(int walletId);
        //Task<Invoice> SubmitDeposit(DepositDto model);
        //Task<WalletTransaction> ProccessDeposit(int invoiceId);
    }
    public class WalletRepository : BaseRepository<Wallet>, IWalletRepository
    {
        private readonly MyDbContext _context;
        private readonly ILogRepository _logger;
        private readonly IWalletTransactionRepository _transactionRepo;
        private readonly IInvoiceRepository _invoiceRepo;

        public WalletRepository(MyDbContext context, ILogRepository logger, IWalletTransactionRepository transactionRepo)
            : base(context, logger)
        {
            _context = context;
            _logger = logger;
            _transactionRepo = transactionRepo;
        }

        public async Task<Wallet> GetByCustomerId(int customerId)
        {
            return await base.GetDefaultQuery().AsQueryable().FirstOrDefaultAsync(w => w.CustomerId == customerId);
        }

        public async Task<long> GetBalance(int walletId)
        {
            var model = await base.GetDefaultQuery().AsQueryable()
                .Select(w => new { w.Id, w.Balance })
                .FirstOrDefaultAsync(w => w.Id == walletId);
            return model.Balance;
        }

        public async Task<List<WalletTransaction>> GetTransactionHistory(int walletId)
        {
            return await _transactionRepo.GetDefaultQuery().AsQueryable().Where(w=>w.WalletId == walletId).OrderByDescending(t=>t.CreateDate).ToListAsync();
        }

        //public async Task<Invoice> SubmitDeposit(DepositDto model)
        //{
        //    var wallet = await base.GetById(model.WalletId);
        //    var invoice = new Invoice()
        //    {
        //        CustomerId = wallet.CustomerId,
        //        Amount = model.Amount,
        //        InvoiceType = InvoiceType.WalletDeposit,
        //        CreateDate = DateTime.Now
        //    };
        //    await _invoiceRepo.Add(invoice);
        //    var transaction = new WalletTransaction
        //    {
        //        WalletId = model.WalletId,
        //        TransactionType = WalletTransactionType.Deposit,
        //        TransactionStatus = WalletTransctionStatus.Pending,
        //        Amount = model.Amount,
        //        CreateDate = DateTime.Now,
        //        InvoiceId = invoice.Id
        //    };
        //    await _transactionRepo.Add(transaction);
        //    return invoice;
        //}

        //public async Task<WalletTransaction> ProccessDeposit(int invoiceId)
        //{
        //    var invoice = await _invoiceRepo.GetById(invoiceId);
        //    var transaction = await _transactionRepo.GetByInvoiceId(invoiceId);

        //    if (invoice.IsPayed)
        //    {
        //        transaction.TransactionStatus = WalletTransctionStatus.Processed;
        //        await _transactionRepo.Update(transaction);

        //        var wallet = await base.GetById(transaction.WalletId);
        //        wallet.Balance += transaction.Amount;
        //        await base.Update(wallet);
        //    }
        //    else
        //    {
        //        transaction.TransactionStatus = WalletTransctionStatus.Failed;
        //        transaction.IsDeleted = true;
        //        await _transactionRepo.Update(transaction);
        //    }

        //    return transaction;
        //}
    }
}
