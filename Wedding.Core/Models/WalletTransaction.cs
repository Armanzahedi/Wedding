using System;
using System.Collections.Generic;
using System.Text;
using Wedding.Core.Utility;

namespace Wedding.Core.Models
{
    public class WalletTransaction : BaseEntity
    {
        public int WalletId { get; set; }
        public Wallet Wallet { get; set; }
        public long Amount { get; set; }
        public DateTime CreateDate { get; set; }
        public WalletTransactionType TransactionType { get; set; }
        public WalletTransctionStatus TransactionStatus { get; set; }
    }
}
