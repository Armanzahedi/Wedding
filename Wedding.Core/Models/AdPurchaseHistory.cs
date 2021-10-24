using System;
using System.Collections.Generic;
using System.Text;
using Wedding.Core.Utility;

namespace Wedding.Core.Models
{
    public class AdPurchaseHistory : BaseEntity
    {
        public int AdId { get; set; }
        public Ad Ad { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime PurchasedFrom { get; set; }
        public DateTime PurchasedTo { get; set; }
        public long Price { get; set; }
        public int InvoiceId { get; set; }
        public Invoice Invoice { get; set; }
    }
}
