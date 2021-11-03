using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using DataTablesParser;
using Microsoft.AspNetCore.Authorization;
using Newtonsoft.Json;
using Wedding.Web.Areas.Apanel.ViewModels;

namespace Wedding.Web.Areas.Apanel.Controllers
{
    [Area("Apanel")]
    public class BannersController : Controller
    {
        //[Authorize("Permission")]
        //public IActionResult Index(bool root = false)
        //{
        //    ViewBag.Root = root;
        //    var model = new AdFilterViewModel();
        //    return View(model);
        //}
        //[HttpPost]
        //[Authorize("Index")]
        //public string LoadGrid(AdFilterViewModel model)
        //{

        //    IEnumerable<AdGridViewModel> query = _adRepo.GetDefaultQuery().AsQueryable()
        //        .Include(a => a.AdPurchaseHistory)
        //        .Include(a => a.Customer)
        //        .ThenInclude(c => c.User)
        //        .Select(a => new AdGridViewModel
        //        {
        //            Id = a.Id,
        //            Title = a.Title,
        //            Customer = $"{a.Customer.User.FirstName} {a.Customer.User.LastName} - {a.Customer.User.PhoneNumber}",
        //            AdType = a.GetAdType(),
        //            PersianDate = new PersianDateTime(a.RegisterDate).ToPersianDateString(),
        //            RegisterDate = a.RegisterDate,
        //            AdStatus = a.Status
        //        });
        //    if (string.IsNullOrEmpty(model.Title) == false)
        //    {
        //        query = query.Where(a => a.Title.ToLower().Trim().Contains(model.Title.ToLower().Trim()));
        //    }
        //    if (string.IsNullOrEmpty(model.FromDate) == false)
        //    {
        //        var from = DateTime.Parse(model.FromDate, new CultureInfo("fa-IR"));
        //        query = query.Where(a => a.RegisterDate >= from);
        //    }
        //    if (string.IsNullOrEmpty(model.ToDate) == false)
        //    {
        //        var to = DateTime.Parse(model.ToDate, new CultureInfo("fa-IR"));
        //        query = query.Where(a => a.RegisterDate <= to);
        //    }

        //    if (model.AdType != 0)
        //    {
        //        query = query.Where(a => a.AdType == model.AdType);
        //    }
        //    if (model.AdStatus != 0)
        //    {
        //        query = query.Where(a => a.AdStatus == model.AdStatus);
        //    }

        //    if (string.IsNullOrEmpty(model.Customer) == false)
        //    {
        //        query = query.Where(a => a.Customer
        //            .ToLower().Trim().Contains(model.Customer.Trim().ToLower())).ToList();
        //    }

        //    var parser = new Parser<AdGridViewModel>(Request.Form, query.AsQueryable());
        //    return JsonConvert.SerializeObject(parser.Parse());
        //}
    }
}
