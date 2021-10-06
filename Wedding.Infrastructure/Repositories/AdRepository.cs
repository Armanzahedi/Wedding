using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Wedding.Core.Models;
using Wedding.Core.Utility;
using Wedding.Infrastructure.Context;
using Wedding.Infrastructure.DTOs;
using Wedding.Infrastructure.ExtensionMethods;

namespace Wedding.Infrastructure.Repositories
{
    public interface IAdRepository : IBaseRepository<Ad>
    {
        Task<AdCreateDto> GetAdCreate(int? customerId);
        Task<Ad> CreateAd(AdCreateDto model);
        IQueryable<Ad> GetCustomerAds(int customerId);
    }
    public class AdRepository : BaseRepository<Ad>, IAdRepository
    {
        private readonly MyDbContext _context;
        private readonly ILogRepository _logger;
        private readonly ICustomerRepository _customerRepo;
        private readonly IAdContactRepository _adContactRepo;

        public AdRepository(MyDbContext context, ILogRepository logger, ICustomerRepository customerRepo, IAdContactRepository adContactRepo) : base(context, logger)
        {
            _context = context;
            _logger = logger;
            _customerRepo = customerRepo;
            _adContactRepo = adContactRepo;
        }

        public async Task<AdCreateDto> GetAdCreate(int? customerId)
        {
            if (customerId == null)
                return new AdCreateDto();
            else
            {
                var customer = await _customerRepo.GetDefaultQuery().AsQueryable()
                    .Include(c=>c.User)
                    .FirstOrDefaultAsync(c=>c.Id == customerId.Value);
                return new AdCreateDto
                {
                    CustomerId = customerId,
                    Title = customer.JobTitle,
                    JobTypeId = customer.JobTypeId,
                    GeoDivisionId = customer.GeoDivisionId,
                    Address = customer.Address,
                    PhoneNumber = customer.User.PhoneNumber,
                    AdStatus = ApprovalStatus.Pending
                };
            }

        }

        public async Task<Ad> CreateAd(AdCreateDto model)
        {
            var ad = new Ad
            {
                CustomerId = model.CustomerId.Value,
                Title = model.Title,
                GeoDivisionId = model.GeoDivisionId.Value,
                JobTypeId = model.JobTypeId.Value,
                Address = model.Address,
                RegisterDate = DateTime.Now,
                Status = model.AdStatus
            };
            await base.Add(ad);
            var adContact = new AdContact
            {
                AdId = ad.Id,
                PhoneNumber = model.PhoneNumber
            };
            await _adContactRepo.Add(adContact);
            return ad;
        }

        public IQueryable<Ad> GetCustomerAds(int customerId)
        {
            return base.GetDefaultQuery().AsQueryable()
                .Include(a => a.AdPurchaseHistory)
                .Where(a => a.CustomerId == customerId);
        }
    }
}
