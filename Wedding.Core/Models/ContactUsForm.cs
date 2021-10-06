using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Wedding.Core.Models
{
    public class ContactUsForm : BaseEntity
    {
        [Display(Name = "نام")]
        [Required(ErrorMessage = "لطفا {0} خود را وارد کنید")]
        public string Name { get; set; }
        [Display(Name = "ایمیل یا شماره تلفن")]
        [Required(ErrorMessage = "لطفا {0} خود را وارد کنید")]
        //[EmailAddress(ErrorMessage ="ایمیل وارد شده معتبر نیست")]
        public string Email { get; set; }
        [Display(Name = "موضوع")]
        [Required(ErrorMessage = "لطفا {0} خود را وارد کنید")]
        public string Subject { get; set; }
        [Display(Name = "پیام")]
        [Required(ErrorMessage = "لطفا {0} خود را وارد کنید")]
        public string Message { get; set; }
        [Display(Name = "مشاهده شده")]
        public bool IsSeen { get; set; }
    }
}
