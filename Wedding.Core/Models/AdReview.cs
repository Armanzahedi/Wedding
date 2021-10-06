using System;
using System.Collections.Generic;
using System.Text;
using Wedding.Core.Utility;

namespace Wedding.Core.Models
{
    public class AdReview : BaseEntity
    {
        public int AdId { get; set; }
        public Ad Ad { get; set; }
        public string IpAddress { get; set; }
        public string Reviewer { get; set; }
        public string Message { get; set; }
        public ApprovalStatus ApprovalStatus { get; set; } = ApprovalStatus.Pending;
    }
}
