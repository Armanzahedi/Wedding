using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Kavenegar.Core.Models;
using SmsIrRestfulNetCore;

namespace Wedding.Infrastructure.Helpers
{
    public static class SmsHelper
    {
        private static string KavenegarApiKey = "";
        private static string SmsIrSecretKey = "";
        private static string SmsIrApiKey = "";

        public static async Task<SendResult> SendSms(string receptor,string message, string sender = null)
        {
            var api = new Kavenegar.KavenegarApi(KavenegarApiKey);
            var result = await api.Send(sender, receptor, message);
            return result;
        }
        public static RestVerificationCodeRespone SendVerificationCode(string phoneNumber,string code)
        {
            var token = new Token().GetToken(SmsIrApiKey, SmsIrSecretKey);

            var restVerificationCode = new RestVerificationCode()
            {
                Code = code,
                MobileNumber = phoneNumber
            };

            var restVerificationCodeRespone = new VerificationCode().Send(token, restVerificationCode);

            return restVerificationCodeRespone;
        }
    }
}
