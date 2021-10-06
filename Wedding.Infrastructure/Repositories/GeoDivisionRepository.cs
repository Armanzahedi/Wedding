using System;
using System.Collections.Generic;
using System.Text;
using Wedding.Core.Models;
using Wedding.Infrastructure.Context;

namespace Wedding.Infrastructure.Repositories
{
    public interface IGeoDivisionRepository : IBaseRepository<GeoDivision>
    {
    }
    public class GeoDivisionRepository : BaseRepository<GeoDivision>, IGeoDivisionRepository
    {
        private readonly MyDbContext _context;
        private readonly ILogRepository _logger;

        public GeoDivisionRepository(MyDbContext context, ILogRepository logger) : base(context, logger)
        {
            _context = context;
            _logger = logger;
        }
    }
}
