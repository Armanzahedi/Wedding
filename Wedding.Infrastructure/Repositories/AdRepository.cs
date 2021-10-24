using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
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
        Task<AdStatusDto> GetStatus(int adId);
        Task<AdPurchaseHistory> GetLastPurchase(int adId);
        Task<AdPurchaseHistory> GetCurrentActivePurchase(int adId);
        Task<AdInfoDto> GetAdInfo(int adId);
        Task<AdInfoDto> UpdateAdInfo(AdInfoDto model);
        Task<List<AdGallery>> GetAdGallery(int adId);
        IQueryable<Ad> GetwithPurchaseHistory();
        Task<Ad> UpdateCoordinates(int adId, double lng, double lat);
        Task<int> GetGalleryLimit(int adId);
        Task<List<AdPurchaseHistory>> GetActivePurchaseList(int adId);
        Task<AdPurchaseHistory> UpgradeAd(UpgradeAdDto model, DateTime from, DateTime to);
        Task<User> GetAdUser(int adId);
    }
    public class AdRepository : BaseRepository<Ad>, IAdRepository
    {
        private readonly MyDbContext _context;
        private readonly ILogRepository _logger;
        private readonly ICustomerRepository _customerRepo;
        private readonly IAdContactRepository _adContactRepo;
        private readonly IAdPurchaseHistoryRepository _adPurchaseRepo;
        private readonly IAdGalleryRepository _adGalleryRepo;
        private readonly IInvoiceRepository _invoiceRepo;

        public AdRepository(MyDbContext context, ILogRepository logger,
            ICustomerRepository customerRepo, IAdContactRepository adContactRepo,
            IAdPurchaseHistoryRepository adPurchaseRepo, IAdGalleryRepository adGalleryRepo,
            IInvoiceRepository invoiceRepo) : base(context, logger)
        {
            _context = context;
            _logger = logger;
            _customerRepo = customerRepo;
            _adContactRepo = adContactRepo;
            _adPurchaseRepo = adPurchaseRepo;
            _adGalleryRepo = adGalleryRepo;
            _invoiceRepo = invoiceRepo;
        }

        public async Task<AdCreateDto> GetAdCreate(int? customerId)
        {
            if (customerId == null)
                return new AdCreateDto();
            else
            {
                var customer = await _customerRepo.GetDefaultQuery().AsQueryable()
                    .Include(c => c.User)
                    .FirstOrDefaultAsync(c => c.Id == customerId.Value);
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
        public async Task<AdPurchaseHistory> GetLastPurchase(int adId)
        {
            return await _adPurchaseRepo.GetDefaultQuery().AsQueryable().OrderByDescending(p => p.PurchasedFrom)
                .FirstOrDefaultAsync(p => p.AdId == adId);
        }

        public async Task<AdPurchaseHistory> GetCurrentActivePurchase(int adId)
        {
            return await _adPurchaseRepo.GetDefaultQuery().AsQueryable()
                .FirstOrDefaultAsync(p => p.PurchasedFrom <= DateTime.Now && p.PurchasedTo >= DateTime.Now);
        }

        public async Task<AdInfoDto> GetAdInfo(int adId)
        {
            var model = await GetwithPurchaseHistory()
                .Select(a => new AdInfoDto
                {
                    Id = a.Id,
                    IsFree = (a.GetAdType() == AdType.Free),
                    Title = a.Title,
                    GeoDivisionId = a.GeoDivisionId,
                    JobTypeId = a.JobTypeId,
                    Address = a.Address,
                    Slug = a.Slug,
                    Description = a.Description,
                    WhatsApp = a.WhatsApp,
                    Instagram = a.Instagram,
                    Telegram = a.Telegram,
                    Website = a.Website,
                    Discount = a.Discount,
                    LastModifiedDate = a.LastModifiedDate
                }).FirstOrDefaultAsync(a=> a.Id == adId);

            var adContacts = await _adContactRepo.GetDefaultQuery().AsQueryable().Where(ac => ac.AdId == adId).OrderBy(ac => ac.InsertDate).ToListAsync();

            model.PhoneNumber1 = adContacts.ElementAtOrDefault(0)?.PhoneNumber;

            model.PhoneNumber2 = adContacts.ElementAtOrDefault(1)?.PhoneNumber;

            model.PhoneNumber3 = adContacts.ElementAtOrDefault(2)?.PhoneNumber;

            return model;
        }

        public async Task<AdInfoDto> UpdateAdInfo(AdInfoDto model)
        {
            var ad = await base.GetDefaultQuery().AsQueryable().Include(a=>a.AdPurchaseHistory)
                .FirstOrDefaultAsync(a=>a.Id == model.Id);
            ad.Title = model.Title;
            ad.JobTypeId = model.JobTypeId.Value;
            ad.GeoDivisionId = model.GeoDivisionId.Value;
            ad.Address = model.Address;
            var adContacts = await _adContactRepo.GetDefaultQuery().AsQueryable()
                .Where(ac => ac.AdId == model.Id).ToListAsync();

            await _adContactRepo
                .UpdateAdContact(model.Id,model.PhoneNumber1,adContacts.ElementAtOrDefault(0));

            if (ad.GetAdType() == AdType.Premium)
            {
                if (string.IsNullOrEmpty(model.PhoneNumber2) == false)
                    await _adContactRepo
                        .UpdateAdContact(model.Id, model.PhoneNumber2, adContacts.ElementAtOrDefault(1));

                if (string.IsNullOrEmpty(model.PhoneNumber3) == false)
                    await _adContactRepo
                        .UpdateAdContact(model.Id, model.PhoneNumber3, adContacts.ElementAtOrDefault(2));
                ad.Slug = model.Slug;
                ad.WhatsApp = model.WhatsApp;
                ad.Instagram = model.Instagram;
                ad.Telegram = model.Telegram;
                ad.Website = model.Website;
                ad.Discount = model.Discount;
                ad.Description = model.Description;
            }
            ad.LastModifiedDate = DateTime.Now;
            await base.Update(ad);
            return model;
        }

        public Task<List<AdGallery>> GetAdGallery(int adId)
        {
            return _adGalleryRepo.GetDefaultQuery().AsQueryable().Where(ag => ag.AdId == adId).ToListAsync();
        }

        public IQueryable<Ad> GetwithPurchaseHistory()
        {
            return base.GetDefaultQuery().AsQueryable()
                .Include(a => a.AdPurchaseHistory)
                .ThenInclude(ph=>ph.Invoice);
        }

        public async Task<Ad> UpdateCoordinates(int adId, double lng, double lat)
        {
            var ad = await base.GetById(adId);
            ad.Longitude = lng;
            ad.Latitude = lat;
            await base.Update(ad);
            return ad;
        }

        public async Task<int> GetGalleryLimit(int adId)
        {
            var galleryLimit = await base.GetDefaultQuery().AsQueryable()
                .Select(a => new AdGalleryLimitDto() { Id = a.Id, Limit = a.GalleryLimit })
                .FirstOrDefaultAsync(a => a.Id == adId);
            return galleryLimit.Limit;
        }

        public async Task<List<AdPurchaseHistory>> GetActivePurchaseList(int adId)
        {
            return await _adPurchaseRepo.GetDefaultQuery().AsQueryable()
                .Where(h => h.Invoice.IsPayed == true && h.AdId == adId).ToListAsync();
        }

        public async Task<AdPurchaseHistory> UpgradeAd(UpgradeAdDto model,DateTime from,DateTime to)
        {
            var ad = await base.GetById(model.AdId);
            var adPurchase = new AdPurchaseHistory
            {
                AdId = model.AdId,
                PurchasedFrom = from,
                PurchasedTo = to,
                CreateDate = DateTime.Now,
                Price = model.Price,
            };
            var invoice = new Invoice()
            {
                CustomerId = ad.CustomerId,
                InvoiceType = InvoiceType.AdPurchase,
                CreateDate = DateTime.Now,
                Amount = model.Price
            };
            await _invoiceRepo.Add(invoice);

            adPurchase.InvoiceId = invoice.Id;

            await _adPurchaseRepo.Add(adPurchase);
            return adPurchase;
        }

        public async Task<User> GetAdUser(int adId)
        {
            var model = await base.GetDefaultQuery().AsQueryable()
                .Select(r => new { AdId = r.Id, user = r.Customer.User })
                .FirstOrDefaultAsync(r => r.AdId == adId);
            return model.user;
        }

        public async Task<AdStatusDto> GetStatus(int adId)
        {
            var model = await GetwithPurchaseHistory().Select(a => new AdStatusDto
            {
                Id = a.Id,
                Status = a.Status,
                RegisterDate = a.RegisterDate,
                AdType = a.GetAdType(),
            }).FirstOrDefaultAsync(a=>a.Id == adId);
            if (model != null && model.AdType == AdType.Premium)
            {
                var lastPurchase = await GetCurrentActivePurchase(model.Id);
                if (lastPurchase != null)
                {
                    model.PremiumFrom = lastPurchase.PurchasedFrom;
                    model.PremiumTo = lastPurchase.PurchasedTo;
                }
            }

            return model;
        }

    }
}
