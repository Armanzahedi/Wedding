using System;
using System.Linq;
using System.Threading.Tasks;
using DataTablesParser;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Wedding.Core.Utility;
using Wedding.Infrastructure.DTOs;
using Wedding.Infrastructure.ExtensionMethods;
using Wedding.Infrastructure.Helpers;
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
                .Where(r=>r.Status == WithdrawalRequestStatus.Requested)
                .Select(item => new WithdrawalRequestDto()
                {
                    Id = item.Id,
                    Customer = $"{item.WalletTransaction.Wallet.Customer.User.FirstName} {item.WalletTransaction.Wallet.Customer.User.LastName} - {item.WalletTransaction.Wallet.Customer.User.PhoneNumber}",
                    PaymentAccount = item.PaymentAccount.CardNumber,
                    Amount = $"{item.WalletTransaction.Amount.ToString("##,###")} تومان",
                    PersianDate = item.RequestDate.ToPersianDate()
                })
                .ToList();
            var parser = new Parser<WithdrawalRequestDto>(Request.Form, query.AsQueryable());
            return JsonConvert.SerializeObject(parser.Parse());
        }

        [Authorize("ProcessOrReject")]
        public async Task<IActionResult> ProcessRequest(int id)
        {

            var model = await _withdrawalRequestRepo.GetDefaultQuery()
                .AsQueryable()
                .Include(w => w.PaymentAccount)
                .Include(w => w.WalletTransaction.Wallet.Customer.User)
                .Select(item => new WithdrawalRequestDto()
                {
                    Id = item.Id,
                    Customer =
                        $"{item.WalletTransaction.Wallet.Customer.User.FirstName} {item.WalletTransaction.Wallet.Customer.User.LastName} - {item.WalletTransaction.Wallet.Customer.User.PhoneNumber}",
                    PaymentAccount = item.PaymentAccount.CardNumber,
                    Amount = $"{item.WalletTransaction.Amount.ToString("##,###")} تومان",
                    PersianDate = item.RequestDate.ToPersianDate()
                }).FirstOrDefaultAsync(w => w.Id == id);
            return PartialView(model);
        }

        [Authorize("ProcessOrReject")]
        [HttpPost, ActionName("ProcessRequest")]
        public async Task<IActionResult> ProcessRequestConfirmed(int id)
        {
            var request = await _withdrawalRequestRepo.ProcessRequest(id);
            var user = await _withdrawalRequestRepo.GetRequstUser(id);
            var amount = await _withdrawalRequestRepo.GetRequstAmount(id);
            var amountStr = $"{amount.ToString("##,###")} تومان";
            var userFirstName = string.IsNullOrEmpty(user.FirstName) ? "کاربر" : user.FirstName;

            // sms
            var message = $"ازدواج ایرانی \n {userFirstName} عزیز درخواست برداشت شما با موفقیت پردازش شد \n مبلغ: {amountStr} \n تاریخ ثبت : {request.RequestDate.ToPersianDate()}";

            var result = SmsHelper.SendSms(user.PhoneNumber, message);

            return RedirectToAction(nameof(Index));
        }

        [Authorize("ProcessOrReject")]
        public async Task<IActionResult> RejectRequest(int id)
        {

            var model = await _withdrawalRequestRepo.GetDefaultQuery()
                .AsQueryable()
                .Include(w => w.PaymentAccount)
                .Include(w => w.WalletTransaction.Wallet.Customer.User)
                .Select(item => new WithdrawalRequestDto()
                {
                    Id = item.Id,
                    Customer =
                        $"{item.WalletTransaction.Wallet.Customer.User.FirstName} {item.WalletTransaction.Wallet.Customer.User.LastName} - {item.WalletTransaction.Wallet.Customer.User.PhoneNumber}",
                    PaymentAccount = item.PaymentAccount.CardNumber,
                    Amount = $"{item.WalletTransaction.Amount.ToString("##,###")} تومان",
                    PersianDate = item.RequestDate.ToPersianDate()
                }).FirstOrDefaultAsync(w => w.Id == id);
            return PartialView(model);
        }

        [Authorize("ProcessOrReject")]
        [HttpPost, ActionName("RejectRequest")]
        public async Task<IActionResult> RejectRequestConfirmed(int id)
        {
            var request = await _withdrawalRequestRepo.RejectRequest(id);

            return RedirectToAction(nameof(Index));
        }
    }
}
