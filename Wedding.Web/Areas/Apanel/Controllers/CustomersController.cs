using DataTablesParser;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wedding.Core.Models;
using Wedding.Core.Utility;
using Wedding.Infrastructure.DTOs;
using Wedding.Infrastructure.ExtensionMethods;
using Wedding.Infrastructure.Repositories;
using Wedding.Web.Areas.Apanel.ViewModels;

namespace Wedding.Web.Areas.Apanel.Controllers
{
    [Area("Apanel")]
    [Authorize("Permission")]
    public class CustomersController : Controller
    {
        private readonly ICustomerRepository _customerRepo;
        private readonly IJobTypeRepository _jobTypeRepo;
        private readonly IGeoDivisionRepository _geoDivisionRepo;
        private readonly IUserRepository _userRepo;
        private readonly IAdRepository _adRepo;
        private readonly UserManager<User> _userManager;

        public CustomersController(ICustomerRepository customerRepo, UserManager<User> userManager, IUserRepository userRepo, IJobTypeRepository jobTypeRepo, IGeoDivisionRepository geoDivisionRepo, IAdRepository adRepo)
        {
            _customerRepo = customerRepo;
            _userManager = userManager;
            _userRepo = userRepo;
            _jobTypeRepo = jobTypeRepo;
            _geoDivisionRepo = geoDivisionRepo;
            _adRepo = adRepo;
        }
        public IActionResult Index(bool root = false)
        {
            ViewBag.Root = root;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public string LoadGrid()
        {
            var query = from item in _customerRepo.GetDefaultQuery().AsQueryable()

                        let FullName = item.User != null ? item.User.FirstName + " " + item.User.LastName : "-"
                        select new CustomerGridViewModel
                        {
                            Id = item.Id,
                            CustomerNumber = item.Id.ToString(),
                            FullName = FullName,
                            PhoneNumber = item.User.PhoneNumber
                        };
            var parser = new Parser<CustomerGridViewModel>(Request.Form, query);
            return JsonConvert.SerializeObject(parser.Parse());
        }

        public IActionResult Create()
        {
            var sategroup = new List<SelectListGroup>();
            foreach (var state in _geoDivisionRepo.GetDefaultQuery().Where(g=>g.GeoDivisionType == GeoType.State).Select(g=>g.Title).ToList())
            {
                sategroup.Add(new SelectListGroup { Name = state });
            }
            ViewData["GeoDivisions"] = _geoDivisionRepo.GetDefaultQuery().Where(a=>a.GeoDivisionType == GeoType.City || a.GeoDivisionType == GeoType.Region).Select(a => 
            new SelectListItem() { 
                Text = a.Title,
                Value = a.Id.ToString(),
                Group = sategroup.FirstOrDefault(s => s.Name == a.Parent.Title) 
            }).ToList();

            ViewData["JobTypes"] = _jobTypeRepo.GetDefaultQuery().Select(a => new SelectListItem() { Text = a.Title, Value = a.Id.ToString() }).ToList();

            return PartialView();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CustomerCreateDto model)
        {
            if (!ModelState.IsValid)
                return View(model);

            if (await _userRepo.UserNameExists(model.PhoneNumber))
            {
                ModelState.AddModelError(string.Empty, "شماره همراه در سیستم ثبت شده");
                return View(model);
            }

            var result = await _customerRepo.CreateCustomer(model);
            if (result == false)
            {
                ModelState.AddModelError(string.Empty, "ثبت مشتری با خطا مواجه شد");
                return View(model);
            }
                
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Details(int id)
        {
            ViewBag.CustomerId = id;
            return View();
        }
        [AllowAnonymous]
        public IActionResult CustomerInfo(int id)
        {
            var model = _customerRepo.GetCustomerDetails(id);
            return PartialView(model);
        }

        [AllowAnonymous]
        public async Task<string> ValidatePhone(string phone,string? id)
        {
            if (await _userRepo.UserNameExists(phone,id))
            {
                return "failed";
            }
            return "success";
        }

        public IActionResult Edit(int id)
        {
            var model = _customerRepo.GetCustomerEdit(id);

            var sategroup = new List<SelectListGroup>();
            foreach (var state in _geoDivisionRepo.GetDefaultQuery().Where(g => g.GeoDivisionType == GeoType.State).Select(g => g.Title).ToList())
            {
                sategroup.Add(new SelectListGroup { Name = state });
            }
            ViewData["GeoDivisions"] = _geoDivisionRepo.GetDefaultQuery().Where(a => a.GeoDivisionType == GeoType.City || a.GeoDivisionType == GeoType.Region).Select(a =>
              new SelectListItem()
              {
                  Text = a.Title,
                  Value = a.Id.ToString(),
                  Selected = (a.Id == model.GeoDivisionId),
                  Group = sategroup.FirstOrDefault(s => s.Name == a.Parent.Title)
              }).ToList();
            ViewData["JobTypes"] = _jobTypeRepo.GetDefaultQuery().Select(a => new SelectListItem() { Text = a.Title, Value = a.Id.ToString(),Selected = (a.Id == model.JobTypeId) }).ToList();
            return PartialView(model);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(CustomerEditDto model)
        {
            if (!ModelState.IsValid)
                return PartialView(model);

            var result = await _customerRepo.EditCustomer(model);

            if (result == false)
            {
                ModelState.AddModelError(string.Empty, "ثبت تغییرات با خطا مواجه شد");
                return View(model);
            }

            return RedirectToAction("Details", new {model.Id});
        }
        [AllowAnonymous]
        public IActionResult AdsGrid(int id)
        {
            ViewBag.CustomerId = id;
            var ads = _adRepo.GetCustomerAds(id)
                .Select(item =>
                new CustomerAdsGridDto
                {
                    Id = item.Id,
                    Title = item.Title,
                    AdType = item.GetAdType(),
                    AdStatus = item.Status,
                    RegisterDate = new PersianDateTime(item.RegisterDate).ToString("dddd d MMMM yyyy")
                }).ToList();
            return PartialView(ads);
        }
        public async Task<IActionResult> Delete(int id)
        {
            var customer = await _customerRepo.GetDefaultQuery().AsQueryable()
                .Include(c => c.User)
                .Include(c => c.Ads)
                .FirstOrDefaultAsync(c => c.Id == id);
            return PartialView(customer);
        }
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _customerRepo.DeleteCustomer(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
