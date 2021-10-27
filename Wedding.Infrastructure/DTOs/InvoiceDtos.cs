using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using FluentValidation;
using Wedding.Core.Utility;

namespace Wedding.Infrastructure.DTOs
{
    public class PayInvoiceDto
    {
        [Display(Name = "شماره فاکتور")]
        public int Id { get; set; }

        [Display(Name = "مشتری")]
        public string Customer { get; set; }
        [Display(Name = "نوع فاکتور")]
        public InvoiceType InvoiceType { get; set; }

        [Display(Name = "تاریخ ثبت")]
        public DateTime CreateDate { get; set; }

        [Display(Name = "مبلغ فاکتور")]
        public long Amount { get; set; }

        [Display(Name = "موجودی کیف پول")]
        public long WalletBalance { get; set; }

        [Display(Name = "استفاده از اعتبار کیف پول")]
        public bool UseWallet { get; set; }

        [Display(Name = "رسید خرید")]
        public string Receipt { get; set; }

        [Display(Name = "پرداخت آنلاین")]
        public bool OnlinePayment { get; set; }

        [Display(Name = "مبلغ پرداختی")]
        public long PayableAmount { get; set; }

        public string Referer { get; set; }
    }
    public class PayInvoiceDtoValidator : AbstractValidator<PayInvoiceDto>
    {

        public PayInvoiceDtoValidator()
        {
            RuleFor(w => w.Receipt)
                .Must((model, receipt) => model.OnlinePayment || string.IsNullOrEmpty(receipt) == false)
                .WithMessage("لطفا تصویر رسید پرداخت را آپلود کنید");
            RuleFor(w => w.PayableAmount)
                .Must(payableAmount => payableAmount == 0 || payableAmount >= 1000)
                .WithMessage("حداقل مبلغ پرداختی 1,000 تومان باشد");
        }
    }
}
