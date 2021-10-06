using Wedding.Core.Models;
using Wedding.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace Wedding.Infrastructure.Repositories
{
    public interface IContactUsFormRepository : IBaseRepository<ContactUsForm>
    {
    }
    public class ContactUsFormRepository : BaseRepository<ContactUsForm>, IContactUsFormRepository
    {
        private readonly MyDbContext _context;
        private readonly ILogRepository _logger;

        public ContactUsFormRepository(MyDbContext context, ILogRepository logger) : base(context, logger)
        {
            _context = context;
            _logger = logger;
        }
    }
}
