using Wedding.Core.Models;
using Wedding.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace Wedding.Infrastructure.Repositories
{
    public interface ISystemParameterRepository : IBaseRepository<SystemParameter>
    {
    }
    public class SystemParameterRepository : BaseRepository<SystemParameter>, ISystemParameterRepository
    {
        private readonly MyDbContext _context;
        private readonly ILogRepository _logger;

        public SystemParameterRepository(MyDbContext context, ILogRepository logger) : base(context, logger)
        {
            _context = context;
            _logger = logger;
        }
    }
}
