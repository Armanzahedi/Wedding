using System;
using System.Collections.Generic;
using System.Text;
using Wedding.Core.Utility;

namespace Wedding.Core.Models
{
    public class AdGallery : BaseEntity
    {
        public int AdId { get; set; }
        public Ad Ad { get; set; }
        public string Image { get; set; }
        public string Title { get; set; }
        public ApprovalStatus Status { get; set; }
        public int DisplayOrder { get; set; }
    }
}
