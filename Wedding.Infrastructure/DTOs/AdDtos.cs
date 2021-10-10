using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Wedding.Core.Utility;

namespace Wedding.Infrastructure.DTOs
{
    public class AdCreateDto
    {
        [Display(Name = "مشتری")]
        public int? CustomerId { get; set; }
        [Display(Name = "عنوان آگهی")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string Title { get; set; }
        [Display(Name = "شهر یا منطقه")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public int? GeoDivisionId { get; set; }
        [Display(Name = "شغل")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public int? JobTypeId { get; set; }
        [Display(Name = "آدرس")]
        public string Address { get; set; }
        [Display(Name = "شماره تلفن")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string PhoneNumber { get; set; }
        public ApprovalStatus AdStatus { get; set; }
    }
    public class AdEditDto
    {
        public int Id { get; set; }
        [Display(Name = "عنوان آگهی")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string Title { get; set; }
        [Display(Name = "شهر یا منطقه")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public int? GeoDivisionId { get; set; }
        [Display(Name = "شغل")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public int? JobTypeId { get; set; }
        [Display(Name = "آدرس")]
        public string Address { get; set; }
        [Display(Name = "شماره تلفن 1")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string PhoneNumber1 { get; set; }
        [Display(Name = "شماره تلفن 1")]
        public string PhoneNumber2 { get; set; }
        [Display(Name = "شماره تلفن 1")]
        public string PhoneNumber3 { get; set; }
        [Display(Name = "آدرس تبلیغات")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string Slug { get; set; }
        [Display(Name = "توضیحات")]
        public string Description { get; set; }
        [Display(Name = "واتساپ")]
        public string WhatsApp { get; set; }
        [Display(Name = "اینستاگرام")]
        public string Instagram { get; set; }
        [Display(Name = "تلگرام")]
        public string Telegram { get; set; }
        [Display(Name = "وبسایت")]
        public string Website { get; set; }
        [Display(Name = "متن تخفیف")]
        public string Discount { get; set; }

    }
}
