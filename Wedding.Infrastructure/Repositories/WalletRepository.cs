using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Wedding.Core.Models;
using Wedding.Infrastructure.Context;

namespace Wedding.Infrastructure.Repositories
{
    public interface IWalletRepository : IBaseRepository<Wallet>
    {
        Task<Wallet> GetByCustomerId(int customerId);
        Task<List<WalletTransaction>> GetTransactionHistory(int walletId);
    }
    public class WalletRepository : BaseRepository<Wallet>, IWalletRepository
    {
        private readonly MyDbContext _context;
        private readonly ILogRepository _logger;
        private readonly IWalletTransactionRepository _transactionRepo;

        public WalletRepository(MyDbContext context, ILogRepository logger, IWalletTransactionRepository transactionRepo) : base(context, logger)
        {
            _context = context;
            _logger = logger;
            _transactionRepo = transactionRepo;
        }

        public async Task<Wallet> GetByCustomerId(int customerId)
        {
            return await base.GetDefaultQuery().AsQueryable().FirstOrDefaultAsync(w => w.CustomerId == customerId);
        }

        public async Task<List<WalletTransaction>> GetTransactionHistory(int walletId)
        {
            return await _transactionRepo.GetDefaultQuery().AsQueryable().Where(w=>w.WalletId == walletId).ToListAsync();
        }

    }
}
