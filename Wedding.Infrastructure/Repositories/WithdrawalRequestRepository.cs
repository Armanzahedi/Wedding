using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Wedding.Core.Models;
using Wedding.Core.Utility;
using Wedding.Infrastructure.Context;

namespace Wedding.Infrastructure.Repositories
{
    public interface IWithdrawalRequestRepository : IBaseRepository<WithdrawalRequest>
    {
        Task<int> GetRequestCount();
        Task<WithdrawalRequest> ProcessRequest(int requestId);
        Task<WithdrawalRequest> RejectRequest(int requestId);
        Task<User> GetRequstUser(int requestId);
        Task<long> GetRequstAmount(int requestId);
    }
    public class WithdrawalRequestRepository : BaseRepository<WithdrawalRequest>, IWithdrawalRequestRepository
    {
        private readonly MyDbContext _context;
        private readonly ILogRepository _logger;
        private readonly IWalletTransactionRepository _walletTransactionRepo;
        private readonly IWalletRepository _walletRepo;


        public WithdrawalRequestRepository(MyDbContext context, ILogRepository logger, IWalletTransactionRepository walletTransactionRepo, IWalletRepository walletRepo) : base(context, logger)
        {
            _context = context;
            _logger = logger;
            _walletTransactionRepo = walletTransactionRepo;
            _walletRepo = walletRepo;
        }

        public async Task<int> GetRequestCount()
        {
            return await base.GetDefaultQuery().AsQueryable()
                .CountAsync(w => w.Status == WithdrawalRequestStatus.Requested);
        }

        public async Task<WithdrawalRequest> ProcessRequest(int requestId)
        {
            var request = await base.GetById(requestId);
            request.ProcessDate = DateTime.Now;
            request.Status = WithdrawalRequestStatus.Processed;
            await base.Update(request);
            var transaction = await _walletTransactionRepo.GetById(request.WalletTransactionId);
            transaction.TransactionStatus = WalletTransctionStatus.Processed;
            await _walletTransactionRepo.Update(transaction);

            var wallet = await _walletRepo.GetById(transaction.WalletId);
            wallet.Balance -= transaction.Amount;
            await _walletRepo.Update(wallet);
            return request;
        }

        public async Task<WithdrawalRequest> RejectRequest(int requestId)
        {
            var request = await base.GetById(requestId);
            request.ProcessDate = DateTime.Now;
            request.Status = WithdrawalRequestStatus.Rejected;
            await base.Update(request);
            var transaction = await _walletTransactionRepo.GetById(request.WalletTransactionId);
            transaction.TransactionStatus = WalletTransctionStatus.Failed;
            await _walletTransactionRepo.Update(transaction);
            return request;
        }

        public async Task<User> GetRequstUser(int requestId)
        {
            var model = await base.GetDefaultQuery().AsQueryable()
                .Select(r=>new {requestId, user = r.PaymentAccount.Customer.User})
                .FirstOrDefaultAsync(r => r.requestId == requestId);
            return model.user;
        }

        public async Task<long> GetRequstAmount(int requestId)
        {
            var model = await base.GetDefaultQuery().AsQueryable()
                .Select(r => new { requestId, r.WalletTransaction.Amount })
                .FirstOrDefaultAsync(r => r.requestId == requestId);
            return model.Amount;
        }
    }
}
