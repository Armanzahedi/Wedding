using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Wedding.Core.Models;
using Wedding.Infrastructure.Context;

namespace Wedding.Infrastructure.Repositories
{
    public interface IAdContactRepository : IBaseRepository<AdContact>
    {
        Task<AdContact> UpdateAdContact(int adId,string phoneNumber, AdContact model = null);
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

        public async Task<AdContact> UpdateAdContact(int adId, string phoneNumber, AdContact model = null)
        {
            var contact = model ?? new AdContact();
            contact.AdId = adId;
            contact.PhoneNumber = phoneNumber;
            await base.AddOrUpdate(contact);
            return contact;
        }
    }
}
