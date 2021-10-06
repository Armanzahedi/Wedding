using System;
using System.Collections.Generic;
using System.Text;

namespace Wedding.Core.Utility
{
    public enum GeoType
    {
        Country = 0,
        State = 1,
        City = 2,
        Region = 3
    }
    public enum ApprovalStatus
    {
        Pending = 1,
        Review = 2,
        Approved = 3,
        Rejected = 4
    }
    public enum PurchaseType { 
        Purchase = 1,
        Extention = 2
    }
}
