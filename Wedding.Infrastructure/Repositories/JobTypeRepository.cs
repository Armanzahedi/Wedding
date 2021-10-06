using System;
using System.Collections.Generic;
using System.Text;
using Wedding.Core.Models;
using Wedding.Infrastructure.Context;

namespace Wedding.Infrastructure.Repositories
{
    public interface IJobTypeRepository : IBaseRepository<JobType>
    {
    }
    public class JobTypeRepository : BaseRepository<JobType>, IJobTypeRepository
    {
        private readonly MyDbContext _context;
        private readonly ILogRepository _logger;

        public JobTypeRepository(MyDbContext context, ILogRepository logger) : base(context, logger)
        {
            _context = context;
            _logger = logger;
        }
    }
}
