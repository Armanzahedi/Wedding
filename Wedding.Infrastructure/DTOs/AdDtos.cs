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

    public class AdStatusDto
    {
        public int Id { get; set; }
        public ApprovalStatus Status { get; set; }
        public DateTime RegisterDate { get; set; }
        public AdType AdType { get; set; }
        public DateTime? PremiumFrom { get; set; }
        public DateTime? PremiumTo { get; set; }
    }
    public class AdInfoDto
    {
        public int Id { get; set; }
        public bool IsFree { get; set; }
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
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string Address { get; set; }
        [Display(Name = "شماره تلفن 1")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [RegularExpression("^0[0-9]{2,}[0-9]{7,}$", ErrorMessage = "شماره تلفن وارد شده معتبر نیست")]
        public string PhoneNumber1 { get; set; }
        [Display(Name = "شماره تلفن 2")]
        [RegularExpression("^0[0-9]{2,}[0-9]{7,}$", ErrorMessage = "شماره تلفن وارد شده معتبر نیست")]
        public string PhoneNumber2 { get; set; }
        [Display(Name = "شماره تلفن 3")]
        [RegularExpression("^0[0-9]{2,}[0-9]{7,}$", ErrorMessage = "شماره تلفن وارد شده معتبر نیست")]
        public string PhoneNumber3 { get; set; }
        [Display(Name = "لینک آگهی")]
        public string Slug { get; set; }
        [Display(Name = "توضیحات")]
        public string Description { get; set; }
        [Display(Name = "واتساپ")]
        [RegularExpression("^0[0-9]{2,}[0-9]{7,}$", ErrorMessage = "شماره تلفن وارد شده معتبر نیست")]
        public string WhatsApp { get; set; }
        [Display(Name = "اینستاگرام")]
        public string Instagram { get; set; }
        [Display(Name = "تلگرام")]
        public string Telegram { get; set; }
        [Display(Name = "وبسایت")]
        public string Website { get; set; }
        [Display(Name = "متن تخفیف")]
        public string Discount { get; set; }

        public DateTime? LastModifiedDate { get; set; }
    }
    public class AdImageDto
    {
        public int Id { get; set; }
        public string Image { get; set; }
    }
    public class AdLocationDto
    {
        public int Id { get; set; }
        public double? lng { get; set; }
        public double? lat { get; set; }
    }

    public class AdGalleryLimitDto
    {
        public int Id { get; set; }
        public int Limit { get; set; }
    }

    public class UpgradeAdDto
    {
        public int Id { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public long Price { get; set; }
    }
}
