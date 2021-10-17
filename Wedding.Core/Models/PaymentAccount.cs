using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Wedding.Core.Utility;

namespace Wedding.Core.Models
{
    public class PaymentAccount : BaseEntity
    {
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        [Display(Name = "شماره کارت")]
        public string CardNumber { get; set; }
        [Display(Name = "وضعیت")]
        public PaymentAccountNumberStatus  Status { get; set; }
    }
}
