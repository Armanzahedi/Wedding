using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Wedding.Core.Models;
using Wedding.Core.Utility;
using Wedding.Infrastructure.DTOs;
using Wedding.Infrastructure.ExtensionMethods;
using Wedding.Infrastructure.Repositories;

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
        public IActionResult Index()
        {
            return View();
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

            if (referer == "customer")
                return RedirectToAction("Details", "Customers", new { Id = model.CustomerId });
            else
                return RedirectToAction(nameof(Index));
        }

        [Authorize("Permission")]
        public async Task<IActionResult> Details(int id, string referer)
        {
            var ad = await _adRepo.GetwithPurchaseHistory(id);
            ViewBag.Id = id;
            ViewBag.AdType = ad.GetAdType();
            if (referer != null)
            {
                ViewBag.Referer = referer;
                ViewBag.CustomerId = _adRepo.GetDefaultQuery().Where(a => a.Id == id).Select(a => a.CustomerId).FirstOrDefault();
            }
            return View();
        }
        [Authorize("Details")]
        public async Task<IActionResult> AdStatus(int id)
        {
            var ad = await _adRepo.GetStatus(id);
            return PartialView(ad);
        }

        [Authorize("Details")]
        public async Task<IActionResult> ChangeAdStatus(int id)
        {

            var adStatus = await _adRepo.GetStatus(id);
            return PartialView(adStatus);
        }

        [HttpPost]
        [Authorize("Details")]
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

            var ad = await _adRepo.GetwithPurchaseHistory(model.AdId);
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
            var ad = await _adRepo.GetwithPurchaseHistory(id);
            if (ad.GetAdType() == AdType.Free)
            {
                return Json(new { Status = "invalid",Error = "امکان ثبت موقعیت مکانی در آگهی رایگان وجود نداری" });
            }
            var result = await _adRepo.UpdateCoordinates(id, lng, lat);
            return Json(new { Status = "success" });
        }
    }
}
