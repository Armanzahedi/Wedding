using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Wedding.Core.Models
{
    public class Menu : BaseEntity
    {
        [MaxLength(500,ErrorMessage = "{0} باید از 500 کاراکتر کمتر باشد")]
        [Display(Name = "عنوان")]
        public string Title { get; set; }

        [Display(Name = "آدرس")]
        public string Url { get; set; }

        public int? ParentId { get; set; }
        public virtual Menu Parent { get; set; }
        public virtual ICollection<Menu> Children { get; set; }

    }
}
