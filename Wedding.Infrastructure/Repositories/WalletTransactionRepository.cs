using System;
using System.Collections.Generic;
using System.Text;
using Wedding.Core.Models;
using Wedding.Infrastructure.Context;

namespace Wedding.Infrastructure.Repositories
{
    public interface IWalletTransactionRepository : IBaseRepository<WalletTransaction>
    {
    }
    public class WalletTransactionRepository : BaseRepository<WalletTransaction>, IWalletTransactionRepository
    {
        private readonly MyDbContext _context;
        private readonly ILogRepository _logger;

        public WalletTransactionRepository(MyDbContext context, ILogRepository logger) : base(context, logger)
        {
            _context = context;
            _logger = logger;
        }
    }
}
