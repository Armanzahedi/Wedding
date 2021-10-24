using System;
using System.Linq;
using System.Threading.Tasks;
using Dto.Other;
using Dto.Payment;
using Dto.Response.Payment;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Wedding.Core.Models;
using Wedding.Core.Utility;
using Wedding.Infrastructure.Repositories;
using ZarinPal.Class;
using Payment = ZarinPal.Class.Payment;

namespace Wedding.Web.Controllers
{
    public class PaymentController : Controller
    {
        private readonly Payment _payment;
        private readonly Authority _authority;
        private readonly Transactions _transactions;
        private readonly IPaymentRepository _paymentRepo;
        private readonly IInvoiceRepository _invoiceRepo;
        private readonly ICustomerRepository _customerRepo;
        private readonly IWalletTransactionRepository _walletTransactionRepo;
        private readonly IWalletRepository _walletRepo;
        public PaymentController(IPaymentRepository paymentRepo, ICustomerRepository customerRepo, IWalletTransactionRepository walletTransactionRepo, IWalletRepository walletRepo, IInvoiceRepository invoiceRepo)
        {
            _paymentRepo = paymentRepo;
            _customerRepo = customerRepo;
            _walletTransactionRepo = walletTransactionRepo;
            _walletRepo = walletRepo;
            _invoiceRepo = invoiceRepo;
            var expose = new Expose();
            _payment = expose.CreatePayment();
            _authority = expose.CreateAuthority();
            _transactions = expose.CreateTransactions();
        }
        /// <summary>
        /// ﻓﺮﺍﻳﻨﺪ ﺧﺮﻳﺪ
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> PaymentRequest(int id,string referer = null)
        {

            var baseUrl = "https://localhost:44309";
            var invoice = await _invoiceRepo.GetById(id);
            var amount = (int)invoice.PaymentAmount * 10; // Toman to rial
            var customer = await _customerRepo.GeWithUser(invoice.CustomerId);
            var refererStr = referer != null ? $"?referer={referer}" : null;
            string description = $"پرداخت فاکتور شماره {invoice.Id} ";
            switch (invoice.InvoiceType)
            {
                case InvoiceType.WalletDeposit:
                    description += $"(شارژ کیف پول)";
                    break;
                case InvoiceType.AdPurchase:
                    description += $"(خرید آگهی ویژه)";
                    break;
                case InvoiceType.BannerPurchase:
                    description += $"(خرید بنر تبلیغاتی)";
                    break;
                case InvoiceType.Reservation:
                    description += $"(رزرو)";
                    break;
                default:
                    break;
            }
            var result = await _payment.Request(new DtoRequest()
            {
                Mobile = customer.User.PhoneNumber,
                CallbackUrl = $"{baseUrl}/Payment/PaymentResponse/{invoice.Id}{refererStr}",
                //CallbackUrl = $"https://localhost:44310/Payment/PaymentResponse/{payment.Id}",
                Description = description,
                Email = customer.User.Email,
                Amount = amount,
                MerchantId = "XXXXXXXX-XXXX-XXXX-XXXX-XXXXXXXXXXXX"
            }, ZarinPal.Class.Payment.Mode.sandbox);
            return Redirect($"https://sandbox.zarinpal.com/pg/StartPay/{result.Authority}");
        }
        /// <summary>
        /// بازگشت از درگاه
        /// </summary>
        /// <param name="authority"></param>
        /// <param name="status"></param>
        /// <returns></returns>

        public async Task<IActionResult> PaymentResponse(int id,string authority,string status,string referer = null)
        {

            var invoice = await _invoiceRepo.GetById(id);
            var amount = (int)invoice.PaymentAmount * 10;
            var verification = await _payment.Verification(new DtoVerification
            {
                Amount = amount,
                MerchantId = "XXXXXXXX-XXXX-XXXX-XXXX-XXXXXXXXXXXX",
                Authority = authority
            }, Payment.Mode.sandbox);
            
            ViewBag.InvoiceId = invoice.Id;
            var result = await ProccessPayment(invoice, verification);

            if (referer != null)
            {
                // check if referer already has parameters or not
                if (referer.Contains("?"))
                    return Redirect(referer+$"&paymentResult={result}");
                else
                    return Redirect(referer+$"?paymentResult={result}");
            }
            return View(result);
        }

        public async Task<bool> ProccessPayment(Invoice invoice,Verification verification)
        {
            invoice.ProcessedDate = DateTime.Now;

            var payment = new Core.Models.Payment
            {
                InvoiceId = invoice.Id,
                CreateDate = DateTime.Now,
                Amount = invoice.PaymentAmount
            };

            var validation = false;
            // success
            if (verification.Status == 100)
            {
                validation = true;
                invoice.IsPayed = true;
                payment.PaymentStatus = PaymentStatus.Payed;
            }
            else
            {
                payment.PaymentStatus = PaymentStatus.Failed;
            }

            await _paymentRepo.Add(payment);
            await _invoiceRepo.Update(invoice);

            // Proccess payment based on payment type
            switch (invoice.InvoiceType)
            {
                case InvoiceType.WalletDeposit:
                    await _walletRepo.ProccessDeposit(invoice.Id);
                    break;
                default:
                    break;
            }
            return validation;
        }
        /// <summary>
        /// ﻓﺮﺍﻳﻨﺪ ﺧﺮﻳﺪ ﺑﺎ ﺗﺴﻮﻳﻪ ﺍﺷﺘﺮﺍﻛﻲ 
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> RequestWithExtra()
        {
            var result = await _payment.Request(new DtoRequestWithExtra()
            {
                Mobile = "09121112222",
                CallbackUrl = "https://localhost:44310/home/validate",
                Description = "توضیحات",
                Email = "farazmaan@outlook.com",
                Amount = 1000000,
                MerchantId = "XXXXXXXX-XXXX-XXXX-XXXX-XXXXXXXXXXXX",
                AdditionalData = "{\"Wages\":{\"zp.1.1\":{\"Amount\":120,\"Description\":\" ﺗﻘﺴﻴﻢ \"}, \" ﺳﻮﺩ ﺗﺮﺍﻛﻨﺶ zp.2.5\":{\"Amount\":60,\"Description\":\" ﻭﺍﺭﻳﺰ \"}}} "
            }, ZarinPal.Class.Payment.Mode.sandbox);
            return Redirect($"https://sandbox.zarinpal.com/pg/StartPay/{result.Authority}");
        }

        /// <summary>
        /// ﺩﺭ ﺭﻭﺵ ﺍﻳﺠﺎﺩ ﺷﻨﺎﺳﻪ ﭘﺮﺩﺍﺧﺖ ﺑﺎ ﻃﻮﻝ ﻋﻤﺮ ﺑﺎﻻ ﻣﻤﻜﻦ ﺍﺳﺖ ﺣﺎﻟﺘﻲ ﭘﻴﺶ ﺁﻳﺪ ﻛﻪ ﺷﻤﺎ ﺑﻪ ﺗﻤﺪﻳﺪ ﺑﻴﺸﺘﺮ ﻃﻮﻝ ﻋﻤﺮ ﻳﻚ ﺷﻨﺎﺳﻪ ﭘﺮﺩﺍﺧﺖ ﻧﻴﺎﺯ ﺩﺍﺷﺘﻪ ﺑﺎﺷﻴﺪ
        /// ﺩﺭ ﺍﻳﻦ ﺻﻮﺭﺕ ﻣﻲ ﺗﻮﺍﻧﻴﺪ ﺍﺯ ﻣﺘﺪ زیر ﺍﺳﺘﻔﺎﺩﻩ ﻧﻤﺎﻳﻴﺪ 
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> RefreshAuthority()
        {
            var refresh = await _authority.Refresh(new DtoRefreshAuthority
            {
                Authority = "",
                ExpireIn = 1,
                MerchantId = "XXXXXXXX-XXXX-XXXX-XXXX-XXXXXXXXXXXX"
            }, Payment.Mode.sandbox);
            return View();
        }

        /// <summary>
        /// ﻣﻤﻜﻦ ﺍﺳﺖ ﺷﻤﺎ ﻧﻴﺎﺯ ﺩﺍﺷﺘﻪ ﺑﺎﺷﻴﺪ ﻛﻪ ﻣﺘﻮﺟﻪ ﺷﻮﻳﺪ ﭼﻪ ﭘﺮﺩﺍﺧﺖ ﻫﺎﻱ ﺗﻮﺳﻂ ﻭﺏ ﺳﺮﻭﻳﺲ ﺷﻤﺎ ﺑﻪ ﺩﺭﺳﺘﻲ ﺍﻧﺠﺎﻡ ﺷﺪﻩ ﺍﻣﺎ ﻣﺘﺪ  ﺭﻭﻱ ﺁﻧﻬﺎ ﺍﻋﻤﺎﻝ ﻧﺸﺪﻩ
        /// ، ﺑﻪ ﻋﺒﺎﺭﺕ ﺩﻳﮕﺮ ﺍﻳﻦ ﻣﺘﺪ ﻟﻴﺴﺖ ﭘﺮﺩﺍﺧﺖ ﻫﺎﻱ ﻣﻮﻓﻘﻲ ﻛﻪ ﺷﻤﺎ ﺁﻧﻬﺎ ﺭﺍ ﺗﺼﺪﻳﻖ ﻧﻜﺮﺩﻩ ﺍﻳﺪ ﺭﺍ ﺑﻪ PaymentVerification ﺷﻤﺎ ﻧﻤﺎﻳﺶ ﻣﻲ ﺩﻫﺪ.
        /// </summary>
        /// <returns></returns>

        public async Task<IActionResult> Unverified()
        {
            var refresh = await _transactions.GetUnverified(new DtoMerchant
            {
                MerchantId = "XXXXXXXX-XXXX-XXXX-XXXX-XXXXXXXXXXXX"
            }, Payment.Mode.sandbox);
            return View();
        }
    }
}
