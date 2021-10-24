using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

    public enum AdType
    {
        [Display(Name = "رایگان")]
        Free = 1,
        [Display(Name = "ویژه")]
        Premium = 2
    }

    public enum OrderStatus
    {
        Pending = 1,
        Approved = 2,
        Rejected = 3
    }
    public enum OrderType
    {
        AdPurchase = 1,
        BannerPurchase = 2,
        Reservation = 3,
        WalletCharge = 4
    }

    public enum WalletTransactionType
    {
        Deposit = 1,
        Withdraw = 2,
        Reservation = 3,
        Payment = 4
    }

    public enum WalletTransctionStatus
    {
        Pending = 1,
        Processed = 2,
        Failed = 3
    }
    public enum PaymentAccountStatus {
        Pending = 1,
        Approved = 2,
        Rejected = 3
    }

    public enum InvoiceType
    {
        WalletDeposit = 1,
        AdPurchase = 2,
        BannerPurchase = 3,
        Reservation = 4
    }  
    public enum InvoicePaymentMethod
    {
        Online = 1,
        Wallet = 2,
        OnlineAndWallet = 3,
        Wire = 4 // Kart be Kart
    }
    public enum PaymentStatus
    {
        Pending = 1,
        Payed = 2,
        Failed = 3,
    }

    public enum WithdrawalRequestStatus
    {
        Requested = 1,
        Processed = 2,
        Rejected = 3
    }

    public enum AdPurchaseStatus
    {
        Pending = 1,
        Approved = 2,
        Rejected = 3
    }
}
