using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using FluentValidation;

namespace Wedding.Infrastructure.DTOs
{
    public class DepositDto
    {
        public int WalletId { get; set; }
        [Display(Name = "مقدار (تومان)")]
        [Required(ErrorMessage = "لطفا مقدار را وارد کنید")]
        [Range(1000,long.MaxValue,ErrorMessage = "حداقل میزان واریز 1,000 تومان باشد")]
        public long Amount { get; set; }

        public string Referer { get; set; }
    }
    public class WithdrawalDto
    {
        public int WalletId { get; set; }
        [Display(Name = "مقدار (تومان)")]
        [Required(ErrorMessage = "لطفا مقدار را وارد کنید")]
        [Range(15000, long.MaxValue, ErrorMessage = "حداقل میزان برداشت 15,000 تومان باشد")]
        public long Amount { get; set; }

        [Display(Name = "حساب")]
        public int PaymentAcountId { get; set; }
        public long WalletBalance { get; set; }
    }
    public class WithdrawalDtoValidator : AbstractValidator<WithdrawalDto>
    {

        public WithdrawalDtoValidator()
        {
            RuleFor(w => w.Amount).LessThanOrEqualTo(w=>w.WalletBalance).WithMessage("موجدی ناکافی");
        }
    }

    public class WithdrawalRequestGridDto
    {
        public int Id { get; set; }
        public string Customer { get; set; }
        public string PaymentAccount { get; set; }
        public string PersianDate { get; set; }
    }
}
