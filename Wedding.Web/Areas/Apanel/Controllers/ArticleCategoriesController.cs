using Wedding.Core.Models;
using Wedding.Infrastructure.Repositories;
using DataTablesParser;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wedding.Infrastructure.Context;

namespace Wedding.Web.Areas.Apanel.Controllers
{
    [Area("Apanel")]
    [Authorize("Permission")]
    public class ArticleCategoriesController : Controller
    {
        private readonly IArticleCategoryRepository _articleCategoryRepo;
        private readonly MyDbContext _context;
        public ArticleCategoriesController(IArticleCategoryRepository articleCategoryRepo, MyDbContext context)
        {
            _articleCategoryRepo = articleCategoryRepo;
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
            var parser = new Parser<ArticleCategory>(Request.Form, _articleCategoryRepo.GetDefaultQuery().AsQueryable());
            return JsonConvert.SerializeObject(parser.Parse());
        }

        public IActionResult Create()
        {
            return PartialView();
        }
        [HttpPost]
        public async Task<IActionResult> Create(ArticleCategory model)
        {
            if (!ModelState.IsValid)
                return PartialView(model);

            await _articleCategoryRepo.AddOrUpdate(model);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            return PartialView(await _articleCategoryRepo.GetById(id));
        }
        [HttpPost]
        public async Task<IActionResult> Edit(ArticleCategory model)
        {
            if (!ModelState.IsValid)
                return PartialView(model);

            await _articleCategoryRepo.AddOrUpdate(model);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            return PartialView(await _articleCategoryRepo.GetById(id));
        }
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _articleCategoryRepo.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
