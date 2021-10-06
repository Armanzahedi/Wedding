using DataTablesParser;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wedding.Core.Models;
using Wedding.Infrastructure.Repositories;

namespace Wedding.Web.Areas.Apanel.Controllers
{
    [Area("Apanel")]
    [Authorize("Permission")]
    public class ContactUsFormController : Controller
    {
        private readonly IContactUsFormRepository _contactUsFormRepo;
        public ContactUsFormController(IContactUsFormRepository contactUsFormRepo)
        {
            _contactUsFormRepo = contactUsFormRepo;
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
            var parser = new Parser<ContactUsForm>(Request.Form, _contactUsFormRepo.GetDefaultQuery().AsQueryable());
            return JsonConvert.SerializeObject(parser.Parse());
        }

        public async Task<IActionResult> Details(int id)
        {
            var form = await _contactUsFormRepo.GetById(id);
            form.IsSeen = true;
            await _contactUsFormRepo.Update(form);
            return PartialView(form);
        }
        //public IActionResult Create()
        //{
        //    return PartialView();
        //}
        //[HttpPost]
        //public async Task<IActionResult> Create(ContactUsForm model)
        //{
        //    if (!ModelState.IsValid)
        //        return PartialView(model);

        //    await _contactUsFormRepo.AddOrUpdate(model);
        //    return RedirectToAction(nameof(Index));
        //}

        //public async Task<IActionResult> Edit(int id)
        //{
        //    return PartialView(await _contactUsFormRepo.GetById(id));
        //}
        //[HttpPost]
        //public async Task<IActionResult> Edit(ContactUsForm model)
        //{
        //    if (!ModelState.IsValid)
        //        return PartialView(model);

        //    await _contactUsFormRepo.AddOrUpdate(model);
        //    return RedirectToAction(nameof(Index));
        //}

        //public async Task<IActionResult> Delete(int id)
        //{
        //    return PartialView(await _contactUsFormRepo.GetById(id));
        //}
        //[HttpPost, ActionName("Delete")]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    await _contactUsFormRepo.Delete(id);
        //    return RedirectToAction(nameof(Index));
        //}
    }
}
