using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Wedding.Core.Models
{
    public class Customer : BaseEntity
    {
        [ForeignKey("User")]
        public string UserId { get; set; }
        public User User { get; set; }
        public DateTime RegisterDate { get; set; }
        public string JobTitle { get; set; }
        public string Address { get; set; }
        public int? JobTypeId { get; set; }
        public JobType JobType { get; set; }
        public int? GeoDivisionId { get; set; }
        public GeoDivision GeoDivision { get; set; }
        public ICollection<Ad> Ads { get; set; }
        public ICollection<PaymentAccount> PaymentAccounts { get; set; }

    }
}
