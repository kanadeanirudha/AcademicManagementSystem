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
    public class CRMReportViewModel
    {

        public CRMReportViewModel()
        {
            CRMReportDTO = new CRMReport();
        }
        //CRMSaleTargetGroupWise
        public CRMReport CRMReportDTO
        {
            get;
            set;

        }
        public string TodaysMeetingCount
        {
            get
            {
                return (CRMReportDTO != null) ? CRMReportDTO.TodaysMeetingCount : string.Empty;
            }
            set
            {
                CRMReportDTO.TodaysMeetingCount = value;
            }
        }
        public string AccountTarget
        {
            get
            {
                return (CRMReportDTO != null) ? CRMReportDTO.AccountTarget : string.Empty;
            }
            set
            {
                CRMReportDTO.AccountTarget = value;
            }
        }
        public string BillingTarget
        {
            get
            {
                return (CRMReportDTO != null) ? CRMReportDTO.BillingTarget : string.Empty;
            }
            set
            {
                CRMReportDTO.BillingTarget = value;
            }
        }
        public string PeriodType
        {
            get
            {
                return (CRMReportDTO != null) ? CRMReportDTO.PeriodType : string.Empty;
            }
            set
            {
                CRMReportDTO.PeriodType = value;
            }
        }
        public string TotalInvoiceAmount
        {
            get
            {
                return (CRMReportDTO != null) ? CRMReportDTO.TotalInvoiceAmount : string.Empty;
            }
            set
            {
                CRMReportDTO.TotalInvoiceAmount = value;
            }
        }
        public string PendingCalls
        {
            get
            {
                return (CRMReportDTO != null) ? CRMReportDTO.PendingCalls : string.Empty;
            }
            set
            {
                CRMReportDTO.PendingCalls = value;
            }
        }
        public string CallbackCalls
        {
            get
            {
                return (CRMReportDTO != null) ? CRMReportDTO.CallbackCalls : string.Empty;
            }
            set
            {
                CRMReportDTO.CallbackCalls = value;
            }
        }
        public string TotalAllocatedCall
        {
            get
            {
                return (CRMReportDTO != null) ? CRMReportDTO.TotalAllocatedCall : string.Empty;
            }
            set
            {
                CRMReportDTO.TotalAllocatedCall = value;
            }
        }
        public string TotalCallbackCall
        {
            get
            {
                return (CRMReportDTO != null) ? CRMReportDTO.TotalCallbackCall : string.Empty;
            }
            set
            {
                CRMReportDTO.TotalCallbackCall = value;
            }
        }
        public string TotalEnquiries
        {
            get
            {
                return (CRMReportDTO != null) ? CRMReportDTO.TotalEnquiries : string.Empty;
            }
            set
            {
                CRMReportDTO.TotalEnquiries = value;
            }
        }
        public string ConversionRate
        {
            get
            {
                return (CRMReportDTO != null) ? CRMReportDTO.ConversionRate : string.Empty;
            }
            set
            {
                CRMReportDTO.ConversionRate = value;
            }
        }

        public string EnquiryDesription
        {
            get
            {
                return (CRMReportDTO != null) ? CRMReportDTO.EnquiryDesription : string.Empty;
            }
            set
            {
                CRMReportDTO.EnquiryDesription = value;
            }
        }


        public Int16 EnquiryProgressStatus
        {
            get
            {
                return CRMReportDTO != null ? CRMReportDTO.EnquiryProgressStatus : new Int16();
            }
            set
            {
                CRMReportDTO.EnquiryProgressStatus = value;
            }
        }

        public string FromTime
        {
            get
            {
                return (CRMReportDTO != null) ? CRMReportDTO.FromTime : string.Empty;
            }
            set
            {
                CRMReportDTO.FromTime = value;
            }
        }
        public string UptoTime
        {
            get
            {
                return (CRMReportDTO != null) ? CRMReportDTO.UptoTime : string.Empty;
            }
            set
            {
                CRMReportDTO.UptoTime = value;
            }
        }

        [Display(Name = "Caller Job Status")]
        public Int16 CallerJobStatus
        {
            get
            {
                return CRMReportDTO != null ? CRMReportDTO.CallerJobStatus : new Int16();
            }
            set
            {
                CRMReportDTO.CallerJobStatus = value;
            }
        }
        [Display(Name = "Name")]
        public string FromUserName
        {
            get
            {
                return (CRMReportDTO != null) ? CRMReportDTO.FromUserName : string.Empty;
            }
            set
            {
                CRMReportDTO.FromUserName = value;
            }
        }
        public string BodyDescription
        {
            get
            {
                return (CRMReportDTO != null) ? CRMReportDTO.BodyDescription : string.Empty;
            }
            set
            {
                CRMReportDTO.BodyDescription = value;
            }
        }
        public string MapArray { get; set; }

    }
}

