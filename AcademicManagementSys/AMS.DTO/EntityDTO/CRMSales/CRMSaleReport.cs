using System;
using AMS.Base.DTO;

namespace AMS.DTO
{
    public class CRMSaleReport : BaseDTO
    {
        //CRMSaleReport
        public string ScheduleDescription
        {
            get;
            set;
        }
        public int EmployeeID
        {
            get;
            set;
        }
        
        public DateTime TransactionDate
        {
            get;
            set;
        }
        public DateTime TransactionFromDateTime
        {
            get;
            set;
        }
        public DateTime TransactionUpToTime
        {
            get;
            set;
        }
        public int ScheduleTimeInMin
        {
            get;
            set;
        }

        public string DataFor
        {
            get;
            set;
        }
        public string TodaysMeetingCount
        {
            get;
            set;
        }
        public string AccountTarget
        {
            get;
            set;
        }
        public string BillingTarget
        {
            get;
            set;
        }
        public string PeriodType
        {
            get;
            set;
        }
        public string TotalInvoiceAmount
        {
            get;
            set;
        }
        public string TotalHotAccount
        {
            get;
            set;
        }
        public string TotalColdAccount
        {
            get;
            set;
        }
        public string TotalExistingAccount
        {
            get;
            set;
        }
        
        public string TotalEnquiries
        {
            get;
            set;
        }
        public string ConversionRate
        {
            get;
            set;
        }
        public string AccountName
        {
            get;
            set;
        }
        public string InvoiceMonth
        {
            get;
            set;
        }
        public string BackgroundColor
        {
            get;
            set;
        }
        public string ReportList
        {
            get;
            set;
        }
        public Int32 ReportCount
        {
            get;
            set;
        }
        
        public Int16 SubScheduleType { get; set; }
        public string EnquiryDesription { get; set; }
        public Int16 EnquiryProgressStatus { get; set; }
        public string FromTime { get; set; }
        public string UptoTime { get; set; }
        public Int16 CallerJobStatus { get; set; }
        public string FromUserName { get; set; }
        public string BodyDescription { get; set; }
        public string TotalInvoiceAmountList { get; set; }
        public int AdminRoleID { get; set; }
        
    }
}
