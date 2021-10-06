using System;
using System.Collections.Generic;
using System.Text;

namespace Wedding.Core.Models
{
    public class AdRating : BaseEntity
    {
        public int AdId { get; set; }
        public Ad Ad { get; set; }
        public decimal Score { get; set; }
        public string IpAddress { get; set; }
        public DateTime ActionDate { get; set; }
    }
}
