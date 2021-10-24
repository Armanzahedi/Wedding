using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore.Internal;
using Wedding.Core.Models;
using Wedding.Core.Utility;

namespace Wedding.Infrastructure.ExtensionMethods
{
    public static class AdExtentionMethods
    {
        public static AdType GetAdType(this Ad ad)
        {
            if (ad.IsPermenantPremium ||
                (ad.AdPurchaseHistory != null && ad.AdPurchaseHistory
                    .Any(a => a.PurchasedFrom <= DateTime.Now && a.PurchasedTo >= DateTime.Now && 
                              a.Invoice is { IsDeleted: false, IsPayed: true })))
                return AdType.Premium;
            else
                return AdType.Free;
        }

    }
}
