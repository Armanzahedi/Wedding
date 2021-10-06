using DataTablesParser;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
    public class GeoDivisionsController : Controller
    {
        private readonly IGeoDivisionRepository _GeoDivisionRepo;
        private readonly MyDbContext _context;
        public GeoDivisionsController(IGeoDivisionRepository GeoDivisionRepo, MyDbContext context)
        {
            _GeoDivisionRepo = GeoDivisionRepo;
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
            var query = from item in _GeoDivisionRepo.GetDefaultQuery().AsQueryable()
                        select new GeoDivision
                        {
                            Id = item.Id,
                            Title = item.Title,
                            LatinTitle = item.LatinTitle,
                            GeoDivisionType = item.GeoDivisionType
                        };
            var parser = new Parser<GeoDivision>(Request.Form, query);
            return JsonConvert.SerializeObject(parser.Parse());
        }

        public IActionResult Create()
        {
            ViewData["GeoDivisions"] = _GeoDivisionRepo.GetDefaultQuery().OrderBy(g=>g.GeoDivisionType).ThenBy(g=>g.Title).Select(a => new SelectListItem() { Text = a.Title, Value = a.Id.ToString() }).ToList();
            return PartialView();
        }
        [HttpPost]
        public async Task<IActionResult> Create(GeoDivision model)
        {
            if (!ModelState.IsValid)
                return PartialView(model);

            await _GeoDivisionRepo.AddOrUpdate(model);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var geoDivision = await _GeoDivisionRepo.GetById(id);
            ViewData["GeoDivisions"] = _GeoDivisionRepo.GetDefaultQuery().OrderBy(g => g.GeoDivisionType).ThenBy(g => g.Title).Select(a => new SelectListItem() { Text = a.Title, Value = a.Id.ToString(), Selected = (a.Id == geoDivision.ParentId) }).ToList();

            return PartialView(geoDivision);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(GeoDivision model)
        {
            if (!ModelState.IsValid)
                return PartialView(model);

            await _GeoDivisionRepo.AddOrUpdate(model);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var geoDivision = await _GeoDivisionRepo.GetById(id);
            var children = _GeoDivisionRepo.GetDefaultQuery().Where(g => g.ParentId == geoDivision.Id).Select(g=>g.Title);

            if (children.Any())
                ViewBag.Children = children;

            return PartialView();
        }
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _GeoDivisionRepo.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
