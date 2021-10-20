using System;
using System.Collections.Generic;
using System.Text;
using Wedding.Core.Models;
using Wedding.Infrastructure.Context;

namespace Wedding.Infrastructure.Repositories
{
    public interface IPaymentRepository : IBaseRepository<Payment>
    {
    }
    public class PaymentRepository : BaseRepository<Payment>, IPaymentRepository
    {
        private readonly MyDbContext _context;
        private readonly ILogRepository _logger;

        public PaymentRepository(MyDbContext context, ILogRepository logger) : base(context, logger)
        {
            _context = context;
            _logger = logger;
        }
    }
}
