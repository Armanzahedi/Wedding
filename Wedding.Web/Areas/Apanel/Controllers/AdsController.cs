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
using Wedding.Infrastructure.Repositories;

namespace Wedding.Web.Areas.Apanel.Controllers
{
    [Area("Apanel")]
    [Authorize("Permission")]
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

        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> Create(int? customerId,string referer)
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

            ViewData["JobTypes"] = _jobTypeRepo.GetDefaultQuery().Select(a => new SelectListItem() { Text = a.Title, Value = a.Id.ToString(),Selected = (a.Id == model.JobTypeId) }).ToList();

            if (customerId == null)
            {
                ViewData["Customers"] = _customerRepo.GetDefaultQuery().AsQueryable().Include(c=>c.User)
                    .Select(a => new SelectListItem() { Text = $"{a.User.FirstName} {a.User.LastName} - {a.User.PhoneNumber}", Value = a.Id.ToString()}).ToList();
            }

            ViewBag.Referer = referer;
            return PartialView(model);
        }
        [HttpPost]
        public async Task<IActionResult> Create(AdCreateDto model,string referer)
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

        [AllowAnonymous]
        public IActionResult Details(int id, string referer)
        {
            ViewBag.Id = id;
            if (referer != null)
            {
                ViewBag.Referer = referer;
                ViewBag.CustomerId = _adRepo.GetDefaultQuery().Where(a => a.Id == id).Select(a=>a.CustomerId).FirstOrDefault();
            }
            return View();
        }
        [AllowAnonymous]
        public async Task<IActionResult> AdStatus(int id)
        {
            Thread.Sleep(1000);
            var ad = await _adRepo.GetStatus(id);
            return PartialView(ad);
        }

        [AllowAnonymous]
        public async Task<IActionResult> ChangeAdStatus(int id)
        {
            Thread.Sleep(1000);
            var adStatus = await _adRepo.GetStatus(id);
            return PartialView(adStatus);
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<JsonResult> ChangeAdStatus(AdStatusDto model)
        {
            var ad = await _adRepo.GetById(model.Id);
            ad.Status = model.Status;
            await _adRepo.Update(ad);
            return Json(new { Status = "success" });
        }
        [AllowAnonymous]
        public async Task<IActionResult> AdInfo(int id)
        {
            Thread.Sleep(1000);

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

        [AllowAnonymous]
        [HttpPost]
        public async Task<JsonResult> AdInfo(AdInfoDto model)
        {
            if (!ModelState.IsValid)
                return Json(new { Status = "invalid" });

            var result = await _adRepo.UpdateAdInfo(model);
            return Json(new {Status = "success"});
        }
        [AllowAnonymous]
        public IActionResult AdImage(int id)
        {
            Thread.Sleep(1000);

            ViewBag.Image = _adRepo.GetDefaultQuery().Where(a => a.Id == id).Select(a => a.Image).FirstOrDefault();
            return PartialView();
        }
        [AllowAnonymous]
        public IActionResult EditImage(int id)
        {
            Thread.Sleep(1000);

            var adImage = _adRepo.GetDefaultQuery()
                .Where(a => a.Id == id).Select(a => new AdImageDto{Id = a.Id, Image = a.Image})
                .FirstOrDefault();
            return PartialView(adImage);
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<JsonResult> EditImage(AdImageDto adImage)
        {
            var ad = await _adRepo.GetById(adImage.Id);
            ad.Image = adImage.Image;
            await _adRepo.Update(ad);
            return Json(new { Status = "success" });
        }

        [AllowAnonymous]
        public async Task<IActionResult> AdGallery(int id)
        {
            Thread.Sleep(1000);
            ViewBag.Id = id;
            var gallery = await _adRepo.GetAdGallery(id);
            return PartialView(gallery);
        }
        [AllowAnonymous]
        public IActionResult CreateGallery(int id)
        {
            var model = new AdGallery{ AdId = id };
            return PartialView(model);
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<JsonResult> CreateGallery(AdGallery model)
        {
            if (!ModelState.IsValid)
                return Json(new { Status = "invalid",Error= "اطلاعات وارد شده صحیح نیست" });
            if (model.Image == null)
            {
                return Json(new { Status = "invalid",Error= "لطفا تصویر را وارد کنید" });
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
            return Json(new {Status = "success"});
        }
        [AllowAnonymous]
        public async Task<IActionResult> EditGallery(int id)
        {
            var model = await _adGalleryRepo.GetById(id);
            return PartialView(model);
        }
        [AllowAnonymous]
        [HttpPost]
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
        [AllowAnonymous]
        [HttpPost]
        public async Task<JsonResult> DeleteGallery(int id)
        {
            var result = await _adGalleryRepo.Delete(id);
            return Json(new { Status = "success" });
        }
    }
}
