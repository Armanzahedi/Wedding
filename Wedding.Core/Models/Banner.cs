using System;
using System.Collections.Generic;
using System.Text;
using Wedding.Core.Utility;

namespace Wedding.Core.Models
{
    public class Banner : BaseEntity
    {
        public string CreateDate { get; set; }
        public int AdId { get; set; }
        public Ad Ad { get; set; }  
        public int JobTypeId { get; set; }
        public JobType JobType { get; set; }
        public int GeoDivisionId { get; set; }
        public GeoDivision GeoDivision { get; set; }
        public BannerTypes BannerType { get; set; }
        public string Image { get; set; }
        public string Image2 { get; set; }
        public DateTime ActiveFrom { get; set; }
        public DateTime ActiveTo { get; set; }
        public long Price { get; set; }
        public int? InvoiceId { get; set; }
        public Invoice Invoice { get; set; }
        public bool IsPermenantActive { get; set; } = false;
        public bool IsBanned { get; set; } = false;
    }
}
