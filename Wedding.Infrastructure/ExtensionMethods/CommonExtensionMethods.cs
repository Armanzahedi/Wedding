using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Wedding.Infrastructure.ExtensionMethods
{
    public static class CommonExtensionMethods
    {
        public static IEnumerable<TSource> DistinctBy<TSource, TKey> (this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
        {
            HashSet<TKey> seenKeys = new HashSet<TKey>();
            foreach (TSource element in source)
            {
                if (seenKeys.Add(keySelector(element)))
                {
                    yield return element;
                }
            }
        }

        public static JsonResult JsonError(this ModelStateDictionary modelState)
        {
            var allErrors = modelState.Values.SelectMany(v => v.Errors).ToList();

            var message = "";
            foreach (var error in allErrors)
            {
                message += $"{error.ErrorMessage}  <br/>";
            }
            return new JsonResult(new { Status = "Invalid", Message = message });
        }

        public static string AddPaymentResultToUrl(this string url,bool result)
        {
            if (url.Contains("?"))
                return url + $"&paymentResult={result}";
            else
                return url + $"?paymentResult={result}";
        }
    }
}
