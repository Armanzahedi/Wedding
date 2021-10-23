using System;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Wedding.Core.Models;
using Wedding.Core.Utility;
using Wedding.Infrastructure.DTOs;
using Wedding.Infrastructure.Repositories;

namespace Wedding.Web.Areas.Apanel.Controllers
{
    [Area("Apanel")]
    public class WalletsController : Controller
    {
        private readonly IWalletRepository _walletRepo;
        private readonly IWalletTransactionRepository _walletTransactionRepo;
        private readonly IPaymentRepository _paymentRepo;
        private readonly IPaymentAccountRepository _paymentAccountRepo;
        private readonly IWithdrawalRequestRepository _withdrawalRequestRepo;

        public WalletsController(IWalletRepository walletRepo, IPaymentAccountRepository paymentAccountRepo, IWalletTransactionRepository walletTransactionRepo, IPaymentRepository paymentRepo, IWithdrawalRequestRepository withdrawalRequestRepo)
        {
            _walletRepo = walletRepo;
            _paymentAccountRepo = paymentAccountRepo;
            _walletTransactionRepo = walletTransactionRepo;
            _paymentRepo = paymentRepo;
            _withdrawalRequestRepo = withdrawalRequestRepo;
        }

        public async Task<IActionResult> Customer(int id, string referer = null, bool? paymentResult = null)
        {
            var model = await _walletRepo.GetByCustomerId(id);
            if (string.IsNullOrEmpty(referer) == false)
                ViewBag.Referer = referer;

            if (paymentResult != null)
                ViewBag.PaymentResult = paymentResult;

            return View(model);
        }

        public async Task<IActionResult> TransactionHistory(int id)
        {
            var model = await _walletRepo.GetTransactionHistory(id);
            return PartialView(model);
        }
        [Route("Apanel/Wallets/PaymentAccounts/{customerId}")]
        public async Task<IActionResult> PaymentAccounts(int customerId)
        {
            ViewBag.CustomerId = customerId;
            var model = await _paymentAccountRepo.GetByCustomerId(customerId);
            return PartialView(model);
        }
        public IActionResult CreatePaymentAccount(int customerId)
        {
            var model = new PaymentAccount { CustomerId = customerId };
            return PartialView(model);
        }
        [HttpPost]
        public async Task<JsonResult> CreatePaymentAccount(PaymentAccount model)
        {
            if (!ModelState.IsValid)
            {
                return Json(new { Status = "invalid", Message = "اطلاعات وارد شده صحیح نیست" });
            }

            if (await _paymentAccountRepo.CardNumberExist(model.CardNumber, model.CustomerId))
            {
                return Json(new { Status = "invalid", Message = "شماره کارت وارد شده قبلا در سیستم ثبت شده" });
            }
            await _paymentAccountRepo.Add(model);
            return Json(new { Status = "Success", Message = "شماره حساب با موفقیت ذخیره شد" });
        }
        public async Task<IActionResult> EditPaymentAccount(int id)
        {
            var model = await _paymentAccountRepo.GetById(id);
            return PartialView(model);
        }
        [HttpPost]
        public async Task<JsonResult> EditPaymentAccount(PaymentAccount model)
        {
            await _paymentAccountRepo.ChangeStatus(model.Id, model.Status);
            return Json(new { Status = "Success", Message = "تغییرات با موفقیت ذخیره شد" });
        }
        public async Task<IActionResult> DeletePaymentAccount(int id)
        {
            return PartialView(await _paymentAccountRepo.GetById(id));
        }
        [HttpPost, ActionName("DeletePaymentAccount")]
        public async Task<IActionResult> DeleteConfirmedPaymentAccount(int id)
        {
            await _paymentAccountRepo.Delete(id);
            return Json(new { Status = "Success", Message = "تغییرات با موفقیت ذخیره شد" });
        }

        //public IActionResult Deposit(int walletId)
        //{
        //    string referer = Request.Headers["Referer"].ToString();
        //    var model = new DepositDto { WalletId = walletId, Referer = Request.Headers["Referer"].ToString() };
        //    return PartialView(model);
        //}
        //[HttpPost]
        //public async Task<IActionResult> Deposit(DepositDto model)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return PartialView();
        //    }

        //    var payment = await _walletRepo.SubmitDeposit(model);
        //    return RedirectToAction("PaymentRequest", "Payment", new
        //    {
        //        area = "",
        //        id = payment.Id,
        //        referer = model.Referer
        //    });
        //}
        public async Task<IActionResult> Withdrawal(int walletId)
        {
            var wallet = await _walletRepo.GetById(walletId);
            var paymentAccounts = await _paymentAccountRepo.GetByCustomerId(wallet.CustomerId);
            ViewData["PaymentAccounts"] = paymentAccounts.Select(a =>
                new SelectListItem()
                {
                    Text = a.CardNumber,
                    Value = a.Id.ToString(),
                }).ToList();
            ViewBag.PaymentAccountIsEmpty = paymentAccounts.Any() == false;
            var model = new WithdrawalDto() { WalletId = walletId, WalletBalance = wallet.Balance };
            return PartialView(model);
        }
        [HttpPost]
        public async Task<JsonResult> Withdrawal(WithdrawalDto model)
        {
            if (!ModelState.IsValid)
            {
                return Json(new { Status = "Invalid", Message = "اطلاعات وارد شده صحیح نیست" });
            }

            var pendingRequests = await _withdrawalRequestRepo.GetDefaultQuery()
                .AsQueryable()
                .Include(r=>r.WalletTransaction)
                .Where(r => r.WalletTransaction.WalletId == model.WalletId && r.Status == WithdrawalRequestStatus.Requested)
                .ToListAsync();
            if (pendingRequests.Any())
            {
                long totalRequestAmount = pendingRequests.Sum(item => item.WalletTransaction.Amount);
                var walletBalance = await _walletRepo.GetBalance(model.WalletId);
                long allowedReqAmount = walletBalance - totalRequestAmount;

                if (allowedReqAmount < model.Amount)
                {
                    return Json(new { Status = "Invalid", Message = $"مجموع برداشت های پردازش نشده ی شما {totalRequestAmount:##,###} تومان بوده و سقف مجاز برداشت شما {allowedReqAmount:##,###} تومان میباشد" });
                }
            }
            var transaction = new WalletTransaction
            {
                Amount = model.Amount,
                WalletId =model.WalletId, 
                CreateDate = DateTime.Now,
                TransactionType = WalletTransactionType.Withdraw,
                TransactionStatus = WalletTransctionStatus.Pending
            };
            await _walletTransactionRepo.Add(transaction);

            var withdrawalRequest = new WithdrawalRequest
            {
                WalletTransactionId = transaction.Id,
                PaymentAccountId = model.PaymentAcountId,
                Status = WithdrawalRequestStatus.Requested,
                RequestDate = DateTime.Now
            };
            await _withdrawalRequestRepo.Add(withdrawalRequest);

            return Json(new { Status = "Success", Message = "درخواست برداشت با موفقیت ثبت شد" });
        }
    }
}
