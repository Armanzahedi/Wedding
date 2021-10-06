using System;
using System.Collections.Generic;
using System.Text;

namespace Wedding.Core.Models
{
    public class AdContact : BaseEntity
    {
        public int AdId { get; set; }
        public Ad Ad { get; set; }
        public string PhoneNumber { get; set; }
    }
}
