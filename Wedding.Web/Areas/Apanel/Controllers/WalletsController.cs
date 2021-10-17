using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Wedding.Core.Models;
using Wedding.Infrastructure.Repositories;

namespace Wedding.Web.Areas.Apanel.Controllers
{
    [Area("Apanel")]
    public class WalletsController : Controller
    {
        private readonly IWalletRepository _walletRepo;

        public WalletsController(IWalletRepository walletRepo)
        {
            _walletRepo = walletRepo;
        }

        public async Task<IActionResult> Customer(int id,string referrer = null)
        {
            var model = await _walletRepo.GetByCustomerId(id);
            if (string.IsNullOrEmpty(referrer) == false)
            {
                ViewBag.Referrer = referrer;
            }
            return View(model);
        }

        public async Task<IActionResult> TransactionHistory(int id)
        {
            var model = await _walletRepo.GetTransactionHistory(id);
            return PartialView(model);
        }
        public IActionResult CreatePaymentAccount()
        {
            return PartialView();
        }
    }
}
