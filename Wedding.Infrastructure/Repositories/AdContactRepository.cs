using System;
using System.Collections.Generic;
using System.Text;
using Wedding.Core.Models;
using Wedding.Infrastructure.Context;

namespace Wedding.Infrastructure.Repositories
{
    public interface IAdContactRepository : IBaseRepository<AdContact>
    {
    }
    public class AdContactRepository : BaseRepository<AdContact>, IAdContactRepository
    {
        private readonly MyDbContext _context;
        private readonly ILogRepository _logger;

        public AdContactRepository(MyDbContext context, ILogRepository logger) : base(context, logger)
        {
            _context = context;
            _logger = logger;
        }
    }
}
