using System;
using Wedding.Core.Utility;

namespace Wedding.Web.Areas.Apanel.ViewModels
{
    public class AdFilterViewModel
    {
        public string Title { get; set; }
        public string Customer { get; set; }

        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public AdType AdType { get; set; }
        public ApprovalStatus AdStatus { get; set; }
        public AdGridOrder Order { get; set; }
    }

    public enum AdGridOrder
    {
        Title = 1,
        Customer = 2,
        AdType = 3,
        RegisterDate = 4,
        AdStatus = 5
    }
    public class AdGridViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Customer { get; set; }
        public AdType AdType { get; set; }
        public string PersianDate { get; set; }
        public DateTime RegisterDate { get; set; }
        public ApprovalStatus AdStatus { get; set; }
    }
}
