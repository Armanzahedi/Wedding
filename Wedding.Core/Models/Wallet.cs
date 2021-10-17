using System;
using System.Collections.Generic;
using System.Text;
using Wedding.Core.Utility;

namespace Wedding.Core.Models
{
    public class Wallet : BaseEntity
    {
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public long Balance { get; set; } = 0;
        public ICollection<WalletTransaction> WalletTransactions { get; set; }
    }
}
