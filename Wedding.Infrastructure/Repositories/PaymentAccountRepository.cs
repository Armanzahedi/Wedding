using System;
using System.Collections.Generic;
using System.Text;
using Wedding.Core.Models;
using Wedding.Infrastructure.Context;

namespace Wedding.Infrastructure.Repositories
{
    public interface IPaymentAccountRepository : IBaseRepository<PaymentAccount>
    {
    }
    public class PaymentAccountRepository : BaseRepository<PaymentAccount>, IPaymentAccountRepository
    {
        private readonly MyDbContext _context;
        private readonly ILogRepository _logger;

        public PaymentAccountRepository(MyDbContext context, ILogRepository logger) : base(context, logger)
        {
            _context = context;
            _logger = logger;
        }
    }
}
