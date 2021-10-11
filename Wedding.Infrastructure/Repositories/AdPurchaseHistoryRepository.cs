using System;
using System.Collections.Generic;
using System.Text;
using Wedding.Core.Models;
using Wedding.Infrastructure.Context;

namespace Wedding.Infrastructure.Repositories
{
    public interface IAdPurchaseHistoryRepository : IBaseRepository<AdPurchaseHistory>
    {
    }
    public class AdPurchaseHistoryRepository : BaseRepository<AdPurchaseHistory>, IAdPurchaseHistoryRepository
    {
        private readonly MyDbContext _context;
        private readonly ILogRepository _logger;

        public AdPurchaseHistoryRepository(MyDbContext context, ILogRepository logger) : base(context, logger)
        {
            _context = context;
            _logger = logger;
        }
    }
}
