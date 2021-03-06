using Wedding.Core.Models;
using Wedding.Web.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Wedding.Infrastructure.ExtensionMethods;
using Wedding.Infrastructure.Helpers;
using Wedding.Infrastructure.Repositories;

namespace Wedding.Web.Controllers
{
    public class AuthController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly ILogger<AuthController> _logger;
        private readonly IEmailSender _emailSender;
        private readonly IUserRepository _userRepo;
        public AuthController(SignInManager<User> signInManager, UserManager<User> userManager, ILogger<AuthController> logger, IEmailSender emailSender, IUserRepository userRepo)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _logger = logger;
            _emailSender = emailSender;
            _userRepo = userRepo;
        }
        public async Task<IActionResult> Login(string returnUrl = null)
        {
            ViewBag.ReturnUrl = returnUrl ?? Url.Content("~/apanel");
            //await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            var returnUrl = model.ReturnUrl ?? Url.Content("~/apanel");
            if (ModelState.IsValid)
            {
                // This doesn't count login failures towards account lockout
                // To enable password failures to trigger account lockout, set lockoutOnFailure: true
                User user = new User();
                if (IsValidEmail(model.Username))
                {
                    user = await _userManager.FindByEmailAsync(model.Username);
                }
                var result = await _signInManager.PasswordSignInAsync(user.UserName ?? model.Username, model.Password, model.RememberMe, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    _logger.LogInformation("User logged in.");
                    return LocalRedirect(returnUrl);
                }
                if (result.RequiresTwoFactor)
                {
                    return RedirectToPage("./LoginWith2fa", new { ReturnUrl = returnUrl, RememberMe = model.RememberMe });
                }
                if (result.IsLockedOut)
                {
                    _logger.LogWarning("User account locked out.");
                    return RedirectToPage("./Lockout");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "نام کابری یا رمز عبور وارد شده صحیح نیست");
                    return View();
                }
            }

            return View();
        }
        public async Task<IActionResult> SmsLogin(string returnUrl = null)
        {
            ViewBag.ReturnUrl = returnUrl ?? Url.Content("~/apanel");
            //await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

            return View();
        }
        [HttpPost]
        public async Task<JsonResult> GenerateVerificationCode(string phoneNumber)
        {
            if (!ModelState.IsValid)
            {
                return Json(new { Status = "invalid", Message = "اطلاعات وارد شده صحیح نیست" });
            }
            var validatePhone = await _userRepo.GetDefaultQuery().AsQueryable().AnyAsync(u => u.PhoneNumber == phoneNumber);
            if (validatePhone == false)
            {
                return Json(new { Status = "invalid", Message = "کاربری با این شماره تلفن در سیستم ثبت نشده" });

            }

            // can send request every one minute
            if (HttpContext.Session.GetString("VerificationCodeGenerateDate") == null || DateTime.Parse(HttpContext.Session.GetString("VerificationCodeGenerateDate")).AddMinutes(1) <= DateTime.Now)
            {
                try
                {
                    var verificationCode = GenerateRandom6DigitNumber();

                    //sms
                    var message = $"ازدواج ایرانی \n کد تایید: {verificationCode}";
                    var result = SmsHelper.SendSms(phoneNumber, message);

                    HttpContext.Session.SetString("VerificationCodeGenerateDate", DateTime.Now.ToString(CultureInfo.InvariantCulture));
                    HttpContext.Session.SetString("VerificationCode", verificationCode);
                }
                catch (Exception e)
                {
                    return Json(new { Status = "invalid", Message = "ارسال پیام با خطا مواجه شد" });
                }

            }
            return Json(new { Status = "Success" });
        }

        public string GenerateRandom6DigitNumber()
        {
            Random generator = new Random();
            String r = generator.Next(0, 1000000).ToString("D6");
            return r;
        }
        [HttpPost]
        public async Task<JsonResult> SmsLogin(SmsLoginViewModel model)
        {
            var generatedCode = HttpContext.Session.GetString("VerificationCode");
            var validateVerificationCode = generatedCode == model.VerificationCode;
            if (validateVerificationCode)
            {
                var user = await _userRepo.GetDefaultQuery().AsQueryable().FirstOrDefaultAsync(u => u.PhoneNumber == model.PhoneNumber);
                var authProps = new AuthenticationProperties();
                await _signInManager.SignInAsync(user, authProps);

                return Json(new { Status = "Success", ReturnUrl = model.ReturnUrl });
            }
            else
            {
                return Json(new { Status = "invalid", Message = "کد وارد شده معتبر نیست" });
            }

        }
        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(model.Email);
                if (user == null)
                {
                    // Don't reveal that the user does not exist or is not confirmed
                    return View("ForgotPasswordConfirmation");
                }

                var code = await _userManager.GeneratePasswordResetTokenAsync(user);
                code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                var callbackUrl = Url.Page(
                    "/Auth/ResetPassword",
                    pageHandler: null,
                    values: new { code },
                    protocol: Request.Scheme);

                await _emailSender.SendEmailAsync(
                    model.Email,
                    "Reset Password",
                    $"با استفاده از این لینک میتوانید رمز عبور خود را بروز رسانی کنید <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>لینک بروزرسانی</a>");
                return RedirectToPage("ForgotPasswordConfirmation");
            }

            return View(model);
        }

        public IActionResult ForgotPasswordConfirmation()
        {
            return View();
        }

        public ActionResult ResetPassword(string code)
        {
            return code == null ? View("Error") : View();
        }

        [HttpPost]
        public async Task<ActionResult> ResetPassword(ResetPasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                // Don't reveal that the user does not exist
                return RedirectToAction("ResetPasswordConfirmation", "Account");
            }
            var result = await _userManager.ResetPasswordAsync(user, model.Code, model.Password);
            if (result.Succeeded)
            {
                return RedirectToAction("ResetPasswordConfirmation", "Account");
            }
            AddErrors(result);
            return View();
        }
        public IActionResult ResetPasswordConfirmation()
        {
            return View();
        }
        public ActionResult AccessDenied(string returnUrl = null)
        {
            ViewBag.ReturnUrl = Url.Content("~/apanel");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> LogOff()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login", "Auth");
        }
        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
        }
        bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

    }
}
