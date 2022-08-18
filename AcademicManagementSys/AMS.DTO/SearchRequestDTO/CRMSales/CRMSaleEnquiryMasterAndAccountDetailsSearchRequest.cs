using AMS.Base.DTO;
using System;
namespace AMS.DTO
{
    public class CRMSaleEnquiryMasterAndAccountDetailsSearchRequest : Request
    {
        public int CRMSaleEnquiryMasterID
        {
            get;
            set;
        }
        public Int16 EnquiryAccountType
        {
            get;
            set;
        }
        public string TransactionDate
        {
            get;
            set;
        }
        public string AccountName
        {
            get;
            set;
        }
        public Int16 AccountProgressTypeID
        {
            get;
            set;
        }
        public Int32 CRMSaleEnquiryAccountMasterID
        {
            get;
            set;
        }
        public Int32 EmployeeID
        {
            get;
            set;
        }
        public Int32 CRMSaleEnquiryAccountContactPersonNameID
        {
            get;
            set;
        }
        public string ContactPersonName
        {
            get;
            set;
        }
        public string SortOrder
        {
            get;
            set;
        }
        public string SortBy
        {
            get;
            set;
        }
        public int StartRow
        {
            get;
            set;
        }
        public int RowLength
        {
            get;
            set;
        }
        public int EndRow
        {
            get;
            set;
        }
        public string SearchBy { get; set; }
        public string SortDirection { get; set; }

        public Int32 EnquiryHandledById { get; set; }
    }
}
