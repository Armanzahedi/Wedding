using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Wedding.Core.Utility;

namespace Wedding.Infrastructure.DTOs
{
    public class CustomerCreateDto
    {
        [Display(Name = "نام")]
        public string FirstName { get; set; }
        [Display(Name = "نام خانوادگی")]
        public string LastName { get; set; }
        [Display(Name = "شماره همراه")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [RegularExpression("^0[0-9]{2,}[0-9]{7,}$", ErrorMessage = "{0} وارد شده معتبر نیست")]
        public string PhoneNumber { get; set; }

        [Display(Name = "شغل")]
        public int? JobTypeId { get; set; }

        [Display(Name = "منطقه")]
        public int? GeoDivisionId { get; set; }
        [Display(Name = "نام مجموعه")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string JobTitle { get; set; }
    }
    public class CustomerDetailsDto
    {
        public int Id { get; set; }
        public string Image { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string JobType { get; set; }
        public string JobTitle { get; set; }
        public string Region { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
    }
    public class CustomerEditDto
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string Image { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Display(Name = "شماره همراه")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [RegularExpression("^0[0-9]{2,}[0-9]{7,}$", ErrorMessage = "{0} وارد شده معتبر نیست")]
        public string PhoneNumber { get; set; }
        public int? JobTypeId { get; set; }
        public int? GeoDivisionId { get; set; }
        public string Address { get; set; }
        [Display(Name = "ایمیل")]
        [EmailAddress(ErrorMessage = "{0} وارد شده نامعطبر است")]
        public string Email { get; set; }
        [Display(Name = "نام کاربری")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string UserName { get; set; }
        [Display(Name = "نام مجموعه")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string JobTitle { get; set; }
    }

    public class CustomerAdsGridDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public AdType AdType { get; set; }
        public ApprovalStatus AdStatus { get; set; }
        public string RegisterDate { get; set; }
    }
}
