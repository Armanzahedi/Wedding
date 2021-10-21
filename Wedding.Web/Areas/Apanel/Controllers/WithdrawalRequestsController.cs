using System.Linq;
using System.Threading.Tasks;
using DataTablesParser;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Wedding.Infrastructure.DTOs;
using Wedding.Infrastructure.ExtensionMethods;
using Wedding.Infrastructure.Repositories;
using Wedding.Web.Areas.Apanel.ViewModels;

namespace Wedding.Web.Areas.Apanel.Controllers
{
    [Area("Apanel")]
    public class WithdrawalRequestsController : Controller
    {
        private readonly IWithdrawalRequestRepository _withdrawalRequestRepo;

        public WithdrawalRequestsController(IWithdrawalRequestRepository withdrawalRequestRepo)
        {
            _withdrawalRequestRepo = withdrawalRequestRepo;
        }

        [Authorize("Permission")]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [Authorize("Index")]
        public string LoadGrid()
        {
            var query =  _withdrawalRequestRepo.GetDefaultQuery()
                .AsQueryable()
                .Include(w => w.PaymentAccount)
                .Include(w => w.WalletTransaction.Wallet.Customer.User)
                .Select(item => new WithdrawalRequestGridDto()
                {
                    Id = item.Id,
                    Customer = $"{item.WalletTransaction.Wallet.Customer.User.FirstName} {item.WalletTransaction.Wallet.Customer.User.LastName} - {item.WalletTransaction.Wallet.Customer.User.PhoneNumber}",
                    PaymentAccount = item.PaymentAccount.CardNumber,
                    Amount = $"{item.WalletTransaction.Amount.ToString("##,###")} تومان",
                    PersianDate = item.RequestDate.ToPersianDate()
                })
                .ToList();
            var parser = new Parser<WithdrawalRequestGridDto>(Request.Form, query.AsQueryable());
            return JsonConvert.SerializeObject(parser.Parse());
        }
    }
}
