using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Wedding.Infrastructure.Repositories;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Wedding.Core.Utility;
using Wedding.Infrastructure.DTOs;
using Wedding.Infrastructure.ExtensionMethods;

namespace Wedding.Web.Areas.Apanel.Controllers
{
    [Area("Apanel")]
    public class InvoicesController : Controller
    {
        private readonly IInvoiceRepository _invoiceRepo;
        private readonly IWalletRepository _walletRepo;
        private readonly ICustomerRepository _customerRepo;

        public InvoicesController(IInvoiceRepository invoiceRepo, IWalletRepository walletRepo, ICustomerRepository customerRepo)
        {
            _invoiceRepo = invoiceRepo;
            _walletRepo = walletRepo;
            _customerRepo = customerRepo;
        }

        public IActionResult Index()
        {
            return View();
        }
        [Route("Apanel/Invoices/CustomerInvoices/{customerId}")]
        public async Task<IActionResult> CustomerInvoices(int customerId,string referer = null, bool? paymentResult = null)
        {
            ViewBag.CustoemerId = customerId;

            ViewBag.Referer = referer;
            ViewBag.PaymentResult = paymentResult;

            var model = await _invoiceRepo.GetByCustomerId(customerId);
            ViewBag.PendingInvoiceCount = model.Count(i => i.IsPayed == false);
            return View(model);
        }
        public async Task<IActionResult> PayInvoice(int id)
        {
            var invoice = await _invoiceRepo.GetById(id);

            var wallet = await _walletRepo.GetDefaultQuery()
                .AsQueryable().Select(w=>new {w.CustomerId,w.Balance}).FirstOrDefaultAsync(w=>w.CustomerId == invoice.CustomerId);

            var customer = await _customerRepo.GetDefaultQuery()
                .AsQueryable().Select(c => new { c.Id, CustomerName = $"{c.User.FirstName} {c.User.LastName} - {c.User.PhoneNumber}" })
                .FirstOrDefaultAsync(c => c.Id == invoice.CustomerId);
            var model = new PayInvoiceDto
            {
                Id = invoice.Id,
                Customer = customer.CustomerName,
                InvoiceType = invoice.InvoiceType,
                CreateDate = invoice.CreateDate,
                Amount = invoice.Amount,
                WalletBalance = wallet.Balance,
                OnlinePayment = true,
                UseWallet = false,
                Referer = Request.Headers["Referer"].ToString()
            };
            return PartialView(model);
        }
        [HttpPost]
        public async Task<JsonResult> PayInvoice(PayInvoiceDto model)
        {
            if (!ModelState.IsValid)
                return ModelState.JsonError();

            var redirectUrl = await _invoiceRepo.PayInvoice(model);

            return Json(new {Status = "Success", RedirectUrl = redirectUrl });
        }
    }
}
