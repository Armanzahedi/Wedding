using System;
using System.Collections.Generic;
using System.Text;
using Wedding.Core.Utility;

namespace Wedding.Infrastructure.DTOs
{
    public class BannerDtos
    {
        public string Title { get; set; }
        public string Customer { get; set; }
        public string Ad { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public int GeoDivisionId { get; set; }
        public int JobTypeId { get; set; }
        public BannerStatus BannerStatus { get; set; }
        public ApprovalStatus AdStatus { get; set; }
    }
}
