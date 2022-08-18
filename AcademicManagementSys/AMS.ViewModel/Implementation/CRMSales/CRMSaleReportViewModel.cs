using AMS.Common;
using AMS.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using System.Web;

namespace AMS.ViewModel
{
    public class CRMSaleReportViewModel 
    {

        public CRMSaleReportViewModel()
        {
            CRMSaleReportDTO = new CRMSaleReport();
        }
        //CRMSaleTargetGroupWise
        public CRMSaleReport CRMSaleReportDTO
        {
            get;
            set;

        }
        public string TodaysMeetingCount
        {
            get
            {
                return (CRMSaleReportDTO != null) ? CRMSaleReportDTO.TodaysMeetingCount : string.Empty;
            }
            set
            {
                CRMSaleReportDTO.TodaysMeetingCount = value;
            }
        }
        public string AccountTarget
        {
            get
            {
                return (CRMSaleReportDTO != null) ? CRMSaleReportDTO.AccountTarget : string.Empty;
            }
            set
            {
                CRMSaleReportDTO.AccountTarget = value;
            }
        }
        public string BillingTarget
        {
            get
            {
                return (CRMSaleReportDTO != null) ? CRMSaleReportDTO.BillingTarget : string.Empty;
            }
            set
            {
                CRMSaleReportDTO.BillingTarget = value;
            }
        }
        public string PeriodType
        {
            get
            {
                return (CRMSaleReportDTO != null) ? CRMSaleReportDTO.PeriodType : string.Empty;
            }
            set
            {
                CRMSaleReportDTO.PeriodType = value;
            }
        }
        public string TotalInvoiceAmount
        {
            get
            {
                return (CRMSaleReportDTO != null) ? CRMSaleReportDTO.TotalInvoiceAmount : string.Empty;
            }
            set
            {
                CRMSaleReportDTO.TotalInvoiceAmount = value;
            }
        }
        public string TotalHotAccount
        {
            get
            {
                return (CRMSaleReportDTO != null) ? CRMSaleReportDTO.TotalHotAccount : string.Empty;
            }
            set
            {
                CRMSaleReportDTO.TotalHotAccount = value;
            }
        }
        public string TotalColdAccount
        {
            get
            {
                return (CRMSaleReportDTO != null) ? CRMSaleReportDTO.TotalColdAccount : string.Empty;
            }
            set
            {
                CRMSaleReportDTO.TotalColdAccount = value;
            }
        }
        public string TotalExistingAccount
        {
            get
            {
                return (CRMSaleReportDTO != null) ? CRMSaleReportDTO.TotalExistingAccount : string.Empty;
            }
            set
            {
                CRMSaleReportDTO.TotalExistingAccount = value;
            }
        }
        public string TotalEnquiries
        {
            get
            {
                return (CRMSaleReportDTO != null) ? CRMSaleReportDTO.TotalEnquiries : string.Empty;
            }
            set
            {
                CRMSaleReportDTO.TotalEnquiries = value;
            }
        }
        public string ConversionRate
        {
            get
            {
                return (CRMSaleReportDTO != null) ? CRMSaleReportDTO.ConversionRate : string.Empty;
            }
            set
            {
                CRMSaleReportDTO.ConversionRate = value;
            }
        }

        public string EnquiryDesription
        {
            get
            {
                return (CRMSaleReportDTO != null) ? CRMSaleReportDTO.EnquiryDesription : string.Empty;
            }
            set
            {
                CRMSaleReportDTO.EnquiryDesription = value;
            }
        }


        public Int16 EnquiryProgressStatus
        {
            get
            {
                return CRMSaleReportDTO != null ? CRMSaleReportDTO.EnquiryProgressStatus : new Int16();
            }
            set
            {
                CRMSaleReportDTO.EnquiryProgressStatus = value;
            }
        }

        public string FromTime
        {
            get
            {
                return (CRMSaleReportDTO != null) ? CRMSaleReportDTO.FromTime : string.Empty;
            }
            set
            {
                CRMSaleReportDTO.FromTime = value;
            }
        }
        public string UptoTime
        {
            get
            {
                return (CRMSaleReportDTO != null) ? CRMSaleReportDTO.UptoTime : string.Empty;
            }
            set
            {
                CRMSaleReportDTO.UptoTime = value;
            }
        }

        [Display(Name = "Caller Job Status")]
        public Int16 CallerJobStatus
        {
            get
            {
                return CRMSaleReportDTO != null ? CRMSaleReportDTO.CallerJobStatus : new Int16();
            }
            set
            {
                CRMSaleReportDTO.CallerJobStatus = value;
            }
        }
        [Display(Name="Name")]
        public string FromUserName
        {
            get
            {
                return (CRMSaleReportDTO != null) ? CRMSaleReportDTO.FromUserName : string.Empty;
            }
            set
            {
                CRMSaleReportDTO.FromUserName = value;
            }
        }
        public string BodyDescription
        {
            get
            {
                return (CRMSaleReportDTO != null) ? CRMSaleReportDTO.BodyDescription : string.Empty;
            }
            set
            {
                CRMSaleReportDTO.BodyDescription = value;
            }
        }
        public string ReportList
        {
            get
            {
                return (CRMSaleReportDTO != null) ? CRMSaleReportDTO.ReportList : string.Empty;
            }
            set
            {
                CRMSaleReportDTO.ReportList = value;
            }
        }
        public Int32 ReportCount
        {
            get
            {
                return (CRMSaleReportDTO != null) ? CRMSaleReportDTO.ReportCount : new Int32();
            }
            set
            {
                CRMSaleReportDTO.ReportCount = value;
            }
        }
    }
}

