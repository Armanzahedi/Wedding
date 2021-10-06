using System;
using System.Collections.Generic;
using System.Text;
using Wedding.Core.Utility;

namespace Wedding.Core.Models
{
    public class AdFaq : BaseEntity
    {
        public int AdId { get; set; }
        public Ad Ad { get; set; }
        public ApprovalStatus Status { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }
    }
}
