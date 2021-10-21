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
        private static string KavenegarApiKey = "4C3162387265436C394B65336143626572424D746A7367354867734D6E776E493268764F65336D496D71553D";
        private static string SmsIrSecretKey = "MySecureSmsCode@2563";
        private static string SmsIrApiKey = "d307040a9ee89909b3830849";

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
