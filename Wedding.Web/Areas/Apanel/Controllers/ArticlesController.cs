using DataTablesParser;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wedding.Core.Models;
using Wedding.Infrastructure.Helpers;
using Wedding.Infrastructure.Repositories;
using Wedding.Web.Areas.Apanel.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace Wedding.Web.Areas.Apanel.Controllers
{
    [Area("Apanel")]
    [Authorize("Permission")]
    public class ArticlesController : Controller
    {
        private readonly IArticleRepository _articleRepo;
        private readonly IArticleCategoryRepository _articleCategoryRepo;
        private readonly ITagRepository _tagRepo;
        private readonly UserManager<User> _userManager;


        public ArticlesController(IArticleRepository articleRepo, IArticleCategoryRepository articleCategoryRepo, ITagRepository tagRepo, UserManager<User> userManager)
        {
            _articleRepo = articleRepo;
            _articleCategoryRepo = articleCategoryRepo;
            _tagRepo = tagRepo;
            _userManager = userManager;
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
            var query = from item in _articleRepo.GetDefaultQuery().AsQueryable()
                        let Author = item.User != null? item.User.FirstName + " " + item.User.LastName:"-"
                        //let PersianDate = new PersianDateTime(item.AddedDate.Value).ToString("dddd d MMMM yyyy ساعت hh:mm tt")
                        select new ArticleGridViewModel
                        {
                            Id = item.Id,
                            Title = item.Title,
                            Category = item.ArticleCategory.Title,
                            Author = Author,
                            //PersianDate = PersianDate
                        };
            var parser = new Parser<ArticleGridViewModel>(Request.Form, query);
            var data = parser.Parse();
            return JsonConvert.SerializeObject(parser.Parse());
        }
        public IActionResult Create()
        {
            ViewData["ArticleCategories"] = _articleCategoryRepo.GetDefaultQuery().Select(a => new SelectListItem() { Text = a.Title, Value = a.Id.ToString() }).ToList();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Article model, string tags)
        {
            if (!ModelState.IsValid)
                return View(model);


            model.AddedDate = DateTime.Now;

            var currentUser = await _userManager.FindByNameAsync(User.Identity.Name);
            if (currentUser != null)
                model.UserId = currentUser.Id;

            await _articleRepo.AddOrUpdate(model);

            if (string.IsNullOrEmpty(tags) == false)
            {
                var tagsArr = tags.Split(',').ToList();
                await _articleRepo.SaveArticleTags(model.Id, tagsArr);
            }

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {

            var article = await _articleRepo.GetById(id);
            ViewData["ArticleCategories"] = _articleCategoryRepo.GetDefaultQuery().Select(a => new SelectListItem() { Text = a.Title, Value = a.Id.ToString(), Selected = (a.Id == article.ArticleCategoryId) }).ToList();
            ViewBag.Tags = string.Join(',', await _articleRepo.GetArticleTags(id));
            return View(article);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Article model, string tags)
        {
            if (!ModelState.IsValid)
                return View(model);

            await _articleRepo.AddOrUpdate(model);

            var tagsArr = new List<string>();
            if (string.IsNullOrEmpty(tags) == false)
                tagsArr = tags.Split(',').ToList();

            await _articleRepo.SaveArticleTags(model.Id, tagsArr);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            return PartialView(await _articleRepo.GetById(id));
        }
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _articleRepo.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        [AllowAnonymous]
        public JsonResult GetTags(string searchStr)
        {
            var suggestion = new List<string>();
            if (string.IsNullOrEmpty(searchStr) == false)
            {
                suggestion = _tagRepo.GetDefaultQuery().Where(
                    p => p.Title.ToLower().Trim().Contains(searchStr.ToLower().Trim())
                ).Select(p => p.Title).ToList();
            }
            return Json(suggestion);
        }
    }
}
