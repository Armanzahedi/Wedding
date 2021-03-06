using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DataTablesParser;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Wedding.Core.Models;
using Wedding.Core.Utility;
using Wedding.Infrastructure.DTOs;
using Wedding.Infrastructure.ExtensionMethods;
using Wedding.Infrastructure.Helpers;
using Wedding.Infrastructure.Repositories;
using Wedding.Web.Areas.Apanel.ViewModels;

namespace Wedding.Web.Areas.Apanel.Controllers
{
    [Area("Apanel")]
    public class AdsController : Controller
    {
        private readonly ICustomerRepository _customerRepo;
        private readonly IJobTypeRepository _jobTypeRepo;
        private readonly IGeoDivisionRepository _geoDivisionRepo;
        private readonly IAdRepository _adRepo;
        private readonly IAdGalleryRepository _adGalleryRepo;

        public AdsController(ICustomerRepository customerRepo, IJobTypeRepository jobTypeRepo, IGeoDivisionRepository geoDivisionRepo, IAdRepository adRepo, IAdGalleryRepository adGalleryRepo)
        {
            _customerRepo = customerRepo;
            _jobTypeRepo = jobTypeRepo;
            _geoDivisionRepo = geoDivisionRepo;
            _adRepo = adRepo;
            _adGalleryRepo = adGalleryRepo;
        }

        [Authorize("Permission")]
        public IActionResult Index(bool root = false)
        {
            ViewBag.Root = root;
            var model = new AdFilterViewModel();
            return View(model);
        }
        [HttpPost]
        [Authorize("Index")]
        public string LoadGrid(AdFilterViewModel model)
        {

            IEnumerable<AdGridViewModel> query = _adRepo.GetDefaultQuery().AsQueryable()
                .Include(a => a.AdPurchaseHistory)
                .Include(a => a.Customer)
                .ThenInclude(c=>c.User)
                .Select(a => new AdGridViewModel
                {
                    Id = a.Id,
                    Title = a.Title,
                    Customer = $"{a.Customer.User.FirstName} {a.Customer.User.LastName} - {a.Customer.User.PhoneNumber}",
                    AdType = a.GetAdType(),
                    PersianDate = new PersianDateTime(a.RegisterDate).ToPersianDateString(),
                    RegisterDate = a.RegisterDate,
                    AdStatus = a.Status
                });
            if (string.IsNullOrEmpty(model.Title) == false)
            {
                query = query.Where(a => a.Title.ToLower().Trim().Contains(model.Title.ToLower().Trim()));
            }
            if (string.IsNullOrEmpty(model.FromDate) == false)
            {
                var from = DateTime.Parse(model.FromDate, new CultureInfo("fa-IR"));
                query = query.Where(a => a.RegisterDate >= from);
            }
            if (string.IsNullOrEmpty(model.ToDate) == false)
            {
                var to = DateTime.Parse(model.ToDate, new CultureInfo("fa-IR"));
                query = query.Where(a => a.RegisterDate <= to);
            }

            if (model.AdType != 0)
            {
                query = query.Where(a => a.AdType == model.AdType);
            }
            if (model.AdStatus != 0)
            {
                query = query.Where(a => a.AdStatus == model.AdStatus);
            }

            if (string.IsNullOrEmpty(model.Customer) == false)
            {
                query = query.Where(a => a.Customer
                    .ToLower().Trim().Contains(model.Customer.Trim().ToLower())).ToList();
            }

            switch (model.Order)
            {
                default:
                    query = query.OrderBy(a => a.RegisterDate);
                    break;
            }
            var parser = new Parser<AdGridViewModel>(Request.Form, query.AsQueryable());
            return JsonConvert.SerializeObject(parser.Parse());
        }
        [Authorize("Permission")]
        public async Task<IActionResult> Create(int? customerId, string referer)
        {
            var model = await _adRepo.GetAdCreate(customerId);

            var sategroup = new List<SelectListGroup>();
            foreach (var state in _geoDivisionRepo.GetDefaultQuery().Where(g => g.GeoDivisionType == GeoType.State).Select(g => g.Title).ToList())
            {
                sategroup.Add(new SelectListGroup { Name = state });
            }
            ViewData["GeoDivisions"] = _geoDivisionRepo.GetDefaultQuery().Where(a => a.GeoDivisionType == GeoType.City || a.GeoDivisionType == GeoType.Region)
                .Select(a =>
                new SelectListItem()
                {
                    Text = a.Title,
                    Value = a.Id.ToString(),
                    Group = sategroup.FirstOrDefault(s => s.Name == a.Parent.Title),
                    Selected = (a.Id == model.GeoDivisionId)
                }).ToList();

            ViewData["JobTypes"] = _jobTypeRepo.GetDefaultQuery().Select(a => new SelectListItem() { Text = a.Title, Value = a.Id.ToString(), Selected = (a.Id == model.JobTypeId) }).ToList();

            if (customerId == null)
            {
                ViewData["Customers"] = _customerRepo.GetDefaultQuery().AsQueryable().Include(c => c.User)
                    .Select(a => new SelectListItem() { Text = $"{a.User.FirstName} {a.User.LastName} - {a.User.PhoneNumber}", Value = a.Id.ToString() }).ToList();
            }

            ViewBag.Referer = referer;
            return PartialView(model);
        }
        [HttpPost]
        [Authorize("Permission")]
        public async Task<IActionResult> Create(AdCreateDto model, string referer)
        {
            if (!ModelState.IsValid)
                return View(model);

            model.AdStatus = ApprovalStatus.Approved;
            var result = await _adRepo.CreateAd(model);

            if (referer == Referers.CustomerDetails)
                return RedirectToAction("Details", "Customers", new { Id = model.CustomerId });
            else
                return RedirectToAction(nameof(Index));
        }

        [Authorize("Permission")]
        public async Task<IActionResult> Details(int id, string referer)
        {
            if (id != 0)
            {
                var ad = await _adRepo.GetwithPurchaseHistory().FirstOrDefaultAsync(a=>a.Id == id);
                ViewBag.Id = id;
                ViewBag.AdType = ad.GetAdType();
                if (referer != null)
                {
                    ViewBag.Referer = referer;
                    ViewBag.CustomerId = _adRepo.GetDefaultQuery().Where(a => a.Id == id).Select(a => a.CustomerId).FirstOrDefault();
                }
            }
            return View();
        }
        [Authorize("Details")]
        public async Task<IActionResult> AdStatus(int id)
        {
            var ad = await _adRepo.GetStatus(id);
            return PartialView(ad);
        }

        [Authorize("Permission")]
        public async Task<IActionResult> ChangeAdStatus(int id)
        {

            var adStatus = await _adRepo.GetStatus(id);
            return PartialView(adStatus);
        }

        [HttpPost]
        [Authorize("Permission")]
        public async Task<JsonResult> ChangeAdStatus(AdStatusDto model)
        {
            var ad = await _adRepo.GetById(model.Id);
            ad.Status = model.Status;
            await _adRepo.Update(ad);
            return Json(new { Status = "success" });
        }
        [Authorize("Details")]
        public async Task<IActionResult> AdInfo(int id)
        {
            var model = await _adRepo.GetAdInfo(id);

            var sategroup = new List<SelectListGroup>();
            foreach (var state in _geoDivisionRepo.GetDefaultQuery().Where(g => g.GeoDivisionType == GeoType.State).Select(g => g.Title).ToList())
            {
                sategroup.Add(new SelectListGroup { Name = state });
            }
            ViewData["GeoDivisions"] = _geoDivisionRepo.GetDefaultQuery().Where(a => a.GeoDivisionType == GeoType.City || a.GeoDivisionType == GeoType.Region)
                .Select(a =>
                    new SelectListItem()
                    {
                        Text = a.Title,
                        Value = a.Id.ToString(),
                        Group = sategroup.FirstOrDefault(s => s.Name == a.Parent.Title),
                        Selected = (a.Id == model.GeoDivisionId)
                    }).ToList();

            ViewData["JobTypes"] = _jobTypeRepo.GetDefaultQuery().Select(a => new SelectListItem() { Text = a.Title, Value = a.Id.ToString(), Selected = (a.Id == model.JobTypeId) }).ToList();

            return PartialView(model);
        }

        [HttpPost]
        [Authorize("Details")]
        public async Task<JsonResult> AdInfo(AdInfoDto model)
        {
            if (!ModelState.IsValid)
                return Json(new { Status = "invalid",Error = "اطلاعات وارد شده صحیح نیست" });

            if (model.LastModifiedDate != null)
            {
                if (model.LastModifiedDate.Value.AddHours(5)> DateTime.Now)
                {
                    return Json(new { Status = "invalid",Error = "در حال حاضر بروز رسانی آگهی ممکن نیست" });
                }
            }

            var result = await _adRepo.UpdateAdInfo(model);
            return Json(new { Status = "success" });
        }

        [Authorize("Details")]
        public IActionResult AdImage(int id)
        {
            ViewBag.Image = _adRepo.GetDefaultQuery().Where(a => a.Id == id).Select(a => a.Image).FirstOrDefault();
            return PartialView();
        }

        [Authorize("Details")]
        public IActionResult EditImage(int id)
        {
            var adImage = _adRepo.GetDefaultQuery()
                .Where(a => a.Id == id).Select(a => new AdImageDto { Id = a.Id, Image = a.Image })
                .FirstOrDefault();
            return PartialView(adImage);
        }
        [HttpPost]
        [Authorize("Details")]
        public async Task<JsonResult> EditImage(AdImageDto adImage)
        {
            var ad = await _adRepo.GetById(adImage.Id);
            ad.Image = adImage.Image;
            await _adRepo.Update(ad);
            return Json(new { Status = "success" });
        }

        [Authorize("Details")]
        public async Task<IActionResult> AdGallery(int id)
        {

            ViewBag.Id = id;
            var gallery = await _adRepo.GetAdGallery(id);
            ViewBag.GalleryLimit = await _adRepo.GetGalleryLimit(id);
            return PartialView(gallery);
        }

        [Authorize("Details")]
        public IActionResult CreateGallery(int id)
        {
            var model = new AdGallery { AdId = id };
            return PartialView(model);
        }

        [HttpPost]
        [Authorize("Details")]
        public async Task<JsonResult> CreateGallery(AdGallery model)
        {
            if (!ModelState.IsValid)
                return Json(new { Status = "invalid", Error = "اطلاعات وارد شده صحیح نیست" });
            if (model.Image == null)
            {
                return Json(new { Status = "invalid", Error = "لطفا تصویر را وارد کنید" });
            }

            var ad = await _adRepo.GetwithPurchaseHistory().FirstOrDefaultAsync(a=>a.Id == model.AdId);
            if (ad.GetAdType() == AdType.Free)
            {
                return Json(new { Status = "invalid", Error = "امکان افزودن گالری در آگهی رایگان وجود نداری" });
            }
            if (await _adGalleryRepo.GetAdGalleryCount(model.AdId) >= await _adRepo.GetGalleryLimit(model.AdId))
            {
                return Json(new { Status = "invalid", Error = "تعداد تصاویر شما نمیتواند از 20 عدد بیشتر باشد" });
            }
            if (string.IsNullOrEmpty(model.Title))
            {
                var count = await _adGalleryRepo.GetDefaultQuery().AsQueryable()
                    .CountAsync(g => g.AdId == model.AdId && g.IsDeleted == false);
                var number = count + 1;
                var adTitle = await _adRepo.GetDefaultQuery().AsQueryable().Select(a => a.Title).FirstOrDefaultAsync();
                model.Title = $"{adTitle} تصویر {number}";
            }
            var result = await _adGalleryRepo.AddOrUpdate(model);
            return Json(new { Status = "success" });
        }

        [Authorize("Details")]
        public async Task<IActionResult> EditGallery(int id)
        {
            var model = await _adGalleryRepo.GetById(id);
            return PartialView(model);
        }

        [HttpPost]
        [Authorize("Details")]
        public async Task<JsonResult> EditGallery(AdGallery model)
        {
            if (!ModelState.IsValid)
                return Json(new { Status = "invalid", Error = "اطلاعات وارد شده صحیح نیست" });
            if (model.Image == null)
            {
                return Json(new { Status = "invalid", Error = "لطفا تصویر را وارد کنید" });
            }
            if (string.IsNullOrEmpty(model.Title))
            {
                var count = await _adGalleryRepo.GetDefaultQuery().AsQueryable()
                    .CountAsync(g => g.AdId == model.AdId && g.IsDeleted == false);
                var number = count + 1;
                var adTitle = await _adRepo.GetDefaultQuery().AsQueryable().Select(a => a.Title).FirstOrDefaultAsync();
                model.Title = $"{adTitle} تصویر {number}";
            }
            var result = await _adGalleryRepo.AddOrUpdate(model);
            return Json(new { Status = "success" });
        }

        [HttpPost]
        [Authorize("Details")]
        public async Task<JsonResult> DeleteGallery(int id)
        {
            var result = await _adGalleryRepo.Delete(id);
            return Json(new { Status = "success" });
        }

        [Authorize("Details")]
        public async Task<IActionResult> Location(int id)
        {
            var model = await _adRepo.GetDefaultQuery().AsQueryable()
                .Select(a => new AdLocationDto { Id = id, lng = a.Longitude, lat = a.Latitude })
                .FirstOrDefaultAsync(a => a.Id == id);

            return PartialView(model);
        }

        [HttpPost]
        [Authorize("Details")]
        public async Task<JsonResult> UpdateCoordinates(int id, double lng, double lat)
        {
            var ad = await _adRepo.GetwithPurchaseHistory().FirstOrDefaultAsync(a => a.Id == id);
            if (ad.GetAdType() == AdType.Free)
            {
                return Json(new { Status = "invalid",Error = "امکان ثبت موقعیت مکانی در آگهی رایگان وجود نداری" });
            }
            var result = await _adRepo.UpdateCoordinates(id, lng, lat);
            return Json(new { Status = "success" });
        }

        public IActionResult Upgrade(int id)
        {
            ViewBag.AdId = id;
            return PartialView();
        }
        [HttpPost]
        public async Task<JsonResult> Upgrade(UpgradeAdDto model)
        {
            if (!ModelState.IsValid)
                return ModelState.JsonError();

            var from = DateTime.Parse(model.PurchasedFrom, new CultureInfo("fa-IR"));
            var to = DateTime.Parse(model.PurchasedTo, new CultureInfo("fa-IR"));

            if (from >= to)
            {
                return Json(new { Status = "Invalid", Message = "تعارض میان تاریخ های وارد شده" });
            }

            var previousAdPurchases = await _adRepo.GetActivePurchaseList(model.AdId);

            // check if there is a previous purchase that overlaps with current purchase
            if (previousAdPurchases.Any(h=>h.PurchasedFrom < to && from < h.PurchasedTo))
            {
                var prevPr = previousAdPurchases.FirstOrDefault(h => h.PurchasedFrom < to && from < h.PurchasedTo);
                var message = $"این آگهی از تاریخ {prevPr.PurchasedFrom.ToPersianOnlyDate()} تا تاریخ {prevPr.PurchasedTo.ToPersianOnlyDate()} ویژه میباشد <br/> لطفا تاریخ های وارد شده را بررسی کنید";
                return Json(new { Status = "Invalid", Message = message });
            }

            await _adRepo.UpgradeAd(model, from, to);

            var ad = await _adRepo.GetById(model.AdId);
            var user = await _adRepo.GetAdUser(model.AdId);

            var amountStr = $"{model.Price.ToString("##,###")} تومان";
            var userFirstName = string.IsNullOrEmpty(user.FirstName) ? "کاربر" : user.FirstName;
            //sms
            var smsMessage = $"ازدواج ایرانی \n" +
                             $"{userFirstName} عزیز فاکتور ارتقا آگهی {ad.Title} ایجاد شد لطفا نسبت به پرداخت آن اقدام کنید \n" +
                             $"مبلغ: {amountStr} \n" +
                             $"از تاریخ: {from.ToPersianOnlyDate()}" +
                             $"تا تاریخ: {to.ToPersianOnlyDate()}";

            var result = SmsHelper.SendSms(user.PhoneNumber, smsMessage);
            return Json(new { Status = "Success", Message = "درخواست ارتقا با موفقیت ثبت شد" });
        }
    }
}
