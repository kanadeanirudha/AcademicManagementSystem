using AMS.Base.DTO;
using System;
namespace AMS.DTO
{
    public class CRMSaleBillingTransactionSearchRequest : Request
    {
        public int ID { get; set; }
        public string InvoiceNumber { get; set; }
        public string InvoiceDate { get; set; }
        public int CRMSaleEnquiryAccountMasterID { get; set; }
        public int CallEnquiryMasterIDP { get; set; }
        public decimal InvoiceAmount { get; set; }
        public string CurrencyCode { get; set; }

        public string SortOrder { get; set; }
        public string SortBy { get; set; }
        public int StartRow { get; set; }
        public int RowLength { get; set; }
        public int EndRow { get; set; }
        public string SearchBy { get; set; }
        public string SortDirection { get; set; }

        public string EnquiryDesription { get; set; }
        public string AccountName { get; set; }
    }
}
