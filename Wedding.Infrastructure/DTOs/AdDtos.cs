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
}
