using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Wedding.Core.Models;
using Wedding.Infrastructure.Context;

namespace Wedding.Infrastructure.Repositories
{
    public interface IWalletTransactionRepository : IBaseRepository<WalletTransaction>
    {
        Task<WalletTransaction> GetByInvoiceId(int invoiceId);
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

        public async Task<WalletTransaction> GetByInvoiceId(int invoiceId)
        {
            return await base.GetDefaultQuery().AsQueryable()
                .FirstOrDefaultAsync(t => t.InvoiceId == invoiceId);
        }
    }
}
