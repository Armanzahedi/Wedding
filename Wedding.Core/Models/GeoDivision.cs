using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Wedding.Core.Utility;

namespace Wedding.Core.Models
{
    public class GeoDivision : BaseEntity
    {
        [MaxLength(200)]
        [Display(Name = "نام")]
        [Required(ErrorMessage ="لطفا {0} را وارد کنید")]
        public string Title { get; set; }
        [MaxLength(200)]
        [Display(Name = "نام لاتین")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string LatinTitle { get; set; }
        [Display(Name = "نوع منطقه")]
        public GeoType GeoDivisionType { get; set; }
        public int? ParentId { get; set; }
        public virtual GeoDivision Parent { get; set; }
        public virtual ICollection<GeoDivision> Children { get; set; }
        public ICollection<Ad> Ads { get; set; }
    }
}
