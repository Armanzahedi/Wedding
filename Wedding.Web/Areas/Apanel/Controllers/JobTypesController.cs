using DataTablesParser;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wedding.Core.Models;
using Wedding.Infrastructure.Context;
using Wedding.Infrastructure.Repositories;

namespace Wedding.Web.Areas.Apanel.Controllers
{
    [Area("Apanel")]
    [Authorize("Permission")]
    public class JobTypesController : Controller
    {
        private readonly IJobTypeRepository _JobTypeRepo;
        private readonly MyDbContext _context;
        public JobTypesController(IJobTypeRepository JobTypeRepo, MyDbContext context)
        {
            _JobTypeRepo = JobTypeRepo;
            _context = context;
        }
        public async Task<IActionResult> Index(bool root = false)
        {
            ViewBag.Root = root;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public string LoadGrid()
        {
            var parser = new Parser<JobType>(Request.Form, _JobTypeRepo.GetDefaultQuery().AsQueryable());
            return JsonConvert.SerializeObject(parser.Parse());
        }

        public IActionResult Create()
        {
            return PartialView();
        }
        [HttpPost]
        public async Task<IActionResult> Create(JobType model)
        {
            if (!ModelState.IsValid)
                return PartialView(model);

            await _JobTypeRepo.AddOrUpdate(model);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            return PartialView(await _JobTypeRepo.GetById(id));
        }
        [HttpPost]
        public async Task<IActionResult> Edit(JobType model)
        {
            if (!ModelState.IsValid)
                return PartialView(model);

            await _JobTypeRepo.AddOrUpdate(model);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            return PartialView(await _JobTypeRepo.GetById(id));
        }
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _JobTypeRepo.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
