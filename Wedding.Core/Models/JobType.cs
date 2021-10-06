using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Wedding.Core.Models
{
    public class JobType : BaseEntity
    {
        [Display(Name = "عنوان")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string Title { get; set; }
        [Display(Name = "عنوان جمع")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string PluralTitle { get; set; }
        [Display(Name = "عنوان لاتین")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string LatinTitle { get; set; }
        public string Image { get; set; }

        [Display(Name = "نمایش در صفحه اصلی")]
        public bool ShowInHomePage { get; set; }
        [Display(Name = "فعال است؟")]
        public bool IsActive { get; set; }
        [Display(Name = "ترتیب نمایش")]
        public int? DisplayOrder { get; set; }
        public ICollection<Ad> Ads { get; set; }

    }
}
