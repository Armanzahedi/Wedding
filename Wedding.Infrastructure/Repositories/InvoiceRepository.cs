using System;
using System.Collections.Generic;
using System.Text;
using Wedding.Core.Models;
using Wedding.Infrastructure.Context;

namespace Wedding.Infrastructure.Repositories
{
    public interface IInvoiceRepository : IBaseRepository<Invoice>
    {
    }
    public class InvoiceRepository : BaseRepository<Invoice>, IInvoiceRepository
    {
        private readonly MyDbContext _context;
        private readonly ILogRepository _logger;

        public InvoiceRepository(MyDbContext context, ILogRepository logger) : base(context, logger)
        {
            _context = context;
            _logger = logger;
        }
    }
}
