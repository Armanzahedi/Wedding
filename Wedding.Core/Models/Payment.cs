using System;
using System.Collections.Generic;
using System.Text;
using Wedding.Core.Utility;

namespace Wedding.Core.Models
{
    public class Payment : BaseEntity
    {
        public int InvoiceId { get; set; }
        public Invoice Invoice { get; set; }
        public PaymentStatus PaymentStatus { get; set; }
        public DateTime CreateDate { get; set; }
        public long Amount { get; set; }
    }
}
