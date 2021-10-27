using System;
using System.Collections.Generic;
using System.Text;
using Wedding.Core.Utility;

namespace Wedding.Core.Models
{
    public class Invoice : BaseEntity
    {
        public string Title { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public InvoiceType InvoiceType { get; set; }
        public InvoicePaymentMethod? InvoicePaymentMethod { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? ProcessedDate { get; set; }
        public bool IsPayed { get; set; } = false;
        public long Amount { get; set; }
        public long WalletAmount { get; set; } 
        public long PaymentAmount { get; set; } 
        public string Receipt { get; set; }
        public bool IsReviewed { get; set; } = false;
    }
}
