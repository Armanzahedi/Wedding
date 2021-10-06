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
        private readonly UserManager<User> _userManager;

        public CustomersController(ICustomerRepository customerRepo, UserManager<User> userManager, IUserRepository userRepo, IJobTypeRepository jobTypeRepo, IGeoDivisionRepository geoDivisionRepo)
        {
            _customerRepo = customerRepo;
            _userManager = userManager;
            _userRepo = userRepo;
            _jobTypeRepo = jobTypeRepo;
            _geoDivisionRepo = geoDivisionRepo;
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
                Group = sategroup.Where(s=>s.Name == a.Parent.Title).FirstOrDefault() 
            }).ToList();
            ViewData["JobTypes"] = _jobTypeRepo.GetDefaultQuery().Select(a => new SelectListItem() { Text = a.Title, Value = a.Id.ToString() }).ToList();

            return PartialView();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateCustomerViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);
            
            if (await _userRepo.UserNameExists(model.PhoneNumber))
            {
                ModelState.AddModelError(string.Empty, "شماره همراه در سیستم ثبت شده");
                return View(model);
            }
            var user = new User 
            { 
                PhoneNumber = model.PhoneNumber,
                FirstName = model.FirstName,
                LastName = model.LastName,
                UserName = model.PhoneNumber
            };
            var result = await _userManager.CreateAsync(user, model.PhoneNumber);
            if(result.Succeeded == false)
                return View(model);

            await _userManager.AddToRoleAsync(user, "Customer");
            var customer = new Customer 
            { UserId = user.Id,
              RegisterDate = DateTime.Now,
              JobTypeId = model.JobTypeId != 0? model.JobTypeId : null,
              GeoDivisionId = model.GeoDivisionId != 0 ? model.GeoDivisionId : null,
              JobTitle = model.JobTitle
            };
            await _customerRepo.AddOrUpdate(customer);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Details(int id)
        {
            ViewBag.CustomerId = id;
            return View();
        }
        [AllowAnonymous]
        public IActionResult CustomerDetails(int id)
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

        [AllowAnonymous]
        public IActionResult CustomerEdit(int id)
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
                  Group = sategroup.Where(s => s.Name == a.Parent.Title).FirstOrDefault()
              }).ToList();
            ViewData["JobTypes"] = _jobTypeRepo.GetDefaultQuery().Select(a => new SelectListItem() { Text = a.Title, Value = a.Id.ToString(),Selected = (a.Id == model.JobTypeId) }).ToList();
            return PartialView(model);
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> CustomerEdit(CustomerEditViewModel model)
        {
            if (!ModelState.IsValid)
                return PartialView(model);

            var customer = await _customerRepo.GetById(model.Id);
            customer.JobTypeId = model.JobTypeId != 0 ? model.JobTypeId : null;
            customer.GeoDivisionId = model.GeoDivisionId != 0 ? model.GeoDivisionId : null;
            customer.Address = model.Address;
            customer.JobTitle = model.JobTitle;
            await _customerRepo.Update(customer);

            var user = await _userRepo.GetById(customer.UserId);
            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            user.PhoneNumber = model.PhoneNumber;
            user.UserName = model.PhoneNumber;
            user.Email = model.Email;
            user.Avatar = model.Image;
            await _userRepo.UpdateUser(user);

            return RedirectToAction("Details", new { Id = model.Id});
        }

        //public async Task<IActionResult> Delete(int id)
        //{
        //    return PartialView(await _customerRepo.GetById(id));
        //}
        //[HttpPost, ActionName("Delete")]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    await _customerRepo.Delete(id);
        //    return RedirectToAction(nameof(Index));
        //}
    }
}
