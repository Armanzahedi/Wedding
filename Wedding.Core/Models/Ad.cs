using System;
using System.Collections.Generic;
using System.Text;
using Wedding.Core.Utility;

namespace Wedding.Core.Models
{
    public class Ad : BaseEntity
    {
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public int JobTypeId { get; set; }
        public JobType JobType { get; set; }
        public int GeoDivisionId { get; set; }
        public GeoDivision GeoDivision { get; set; }
        public string Slug { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public string WhatsApp { get; set; }
        public string Instagram { get; set; }
        public string Telegram { get; set; }
        public string Website { get; set; }
        public string Address { get; set; }
        public string Discount { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public DateTime RegisterDate { get; set; }
        public ApprovalStatus Status { get; set; } = ApprovalStatus.Pending;
        public bool IsActive { get; set; } = true;
        public bool IsPermenantPremium { get; set; } = false;
        public ICollection<AdContact> AdContacts { get; set; }
        public ICollection<AdFaq> AdFaqs { get; set; }
        public ICollection<AdGallery> AdGallery { get; set; }
        public ICollection<AdPurchaseHistory> AdPurchaseHistory { get; set; }
        public ICollection<AdRating> AdRatings { get; set; }
        public ICollection<AdReview> AdReviews { get; set; }
        public ICollection<AdTag> AdTags { get; set; }
        public int GalleryLimit { get; set; } = 17;
        public DateTime? LastModifiedDate { get; set; }
    }
}
