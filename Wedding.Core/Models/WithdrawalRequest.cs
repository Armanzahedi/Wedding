using System;
using System.Collections.Generic;
using System.Text;
using Wedding.Core.Utility;

namespace Wedding.Core.Models
{
    public class WithdrawalRequest : BaseEntity
    {
        public int WalletTransactionId { get; set; }
        public WalletTransaction WalletTransaction { get; set; }
        public int PaymentAccountId { get; set; }
        public PaymentAccount PaymentAccount { get; set; }
        public WithdrawalRequestStatus Status { get; set; }
        public DateTime RequestDate { get; set; }
        public DateTime? ProcessDate { get; set; }
    }
}
