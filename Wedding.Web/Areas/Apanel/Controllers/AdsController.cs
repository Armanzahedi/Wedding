using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
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

        public AdsController(ICustomerRepository customerRepo, IJobTypeRepository jobTypeRepo, IGeoDivisionRepository geoDivisionRepo, IAdRepository adRepo)
        {
            _customerRepo = customerRepo;
            _jobTypeRepo = jobTypeRepo;
            _geoDivisionRepo = geoDivisionRepo;
            _adRepo = adRepo;
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
            var ad = await _adRepo.GetById(id);
            return PartialView(ad);
        }
        [AllowAnonymous]
        public async Task<IActionResult> AdInfo(int id)
        {
            var ad = await _adRepo.GetById(id);
            return PartialView(ad);
        }
        [AllowAnonymous]
        public IActionResult AdImage(int id)
        {
            ViewBag.Image = _adRepo.GetDefaultQuery().Where(a => a.Id == id).Select(a => a.Image).FirstOrDefault();
            return PartialView();
        }
        [AllowAnonymous]
        public async Task<IActionResult> EditImage(int id)
        {
            var ad = await _adRepo.GetById(id);
            return PartialView(ad);
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<string> EditImage(int id, string image)
        {
            var ad = await _adRepo.GetById(id);
            ad.Image = image;
            await _adRepo.Update(ad);
            return "success";
        }
    }
}
