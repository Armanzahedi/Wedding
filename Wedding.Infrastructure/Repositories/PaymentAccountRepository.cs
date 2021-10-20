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
    public interface IPaymentAccountRepository : IBaseRepository<PaymentAccount>
    {
        Task<List<PaymentAccount>> GetByCustomerId(int customerId);
        Task<bool> CardNumberExist(string cardNumber, int customerId);
        Task<PaymentAccount> ChangeStatus(int id, PaymentAccountStatus status);
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

        public async Task<List<PaymentAccount>> GetByCustomerId(int customerId)
        {
            return await base.GetDefaultQuery().AsQueryable().Where(p => p.CustomerId == customerId).ToListAsync();
        }

        public async Task<bool> CardNumberExist(string cardNumber, int customerId)
        {
            return await base.GetDefaultQuery().AsQueryable()
                .AnyAsync(p => p.CardNumber == cardNumber && p.CustomerId == customerId);
        }

        public async Task<PaymentAccount> ChangeStatus(int id, PaymentAccountStatus status)
        {
            var model = await base.GetById(id);
            model.Status = status;
            await base.Update(model);
            return model;
        }
    }
}
