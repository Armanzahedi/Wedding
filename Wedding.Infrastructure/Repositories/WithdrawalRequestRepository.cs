using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Wedding.Core.Models;
using Wedding.Core.Utility;
using Wedding.Infrastructure.Context;

namespace Wedding.Infrastructure.Repositories
{
    public interface IWithdrawalRequestRepository : IBaseRepository<WithdrawalRequest>
    {
        Task<int> GetRequestCount();
    }
    public class WithdrawalRequestRepository : BaseRepository<WithdrawalRequest>, IWithdrawalRequestRepository
    {
        private readonly MyDbContext _context;
        private readonly ILogRepository _logger;

        public WithdrawalRequestRepository(MyDbContext context, ILogRepository logger) : base(context, logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<int> GetRequestCount()
        {
            return await base.GetDefaultQuery().AsQueryable()
                .CountAsync(w => w.Status == WithdrawalRequestStatus.Requested);
        }
    }
}
