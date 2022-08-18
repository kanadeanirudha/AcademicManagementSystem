using AMS.Base.DTO;
using System;
using System.Web;
namespace AMS.DTO
{
    public class CRMSaleJobUserJobScheduleSheet : BaseDTO
    {
        public Int64 ID { get; set; }
        public Int64 JobCreationAllocationID { get; set; }
        public string JobName { get; set; }
        public int EmployeeID { get; set; }
        public string TransactionDate { get; set; }
        public string FromTime { get; set; }
        public string UpToTime { get; set; }
        public Int16 ScheduleType { get; set; }
        public Int16 SubScheduleType { get; set; }
        public bool IsAttendOther { get; set; }
        public string OtherListEmployeId { get; set; }
        public string Remark { get; set; }
        public decimal VisitedLat { get; set; }
        public decimal VisitedLang { get; set; }
        public Int16 CallerJobStatus { get; set; }
        public Int16 MeetingStatus { get; set; }
        public string ScheduleDescription { get; set; }
        public Int16 Interestlevel { get; set; }
        public string NextDate { get; set; }
        public string NextFromTime { get; set; }
        public string NextUpToTime { get; set; }
        public Int16 GeneralOtherJobTypeID { get; set; }
        public string Relatedwith { get; set; }
        public bool IsInvitation { get; set; }
        public bool UpdateStatus { get; set; }

        public Int64 CRMJobUserJobScheduleParentID { get; set; }
        
        public bool IsDeleted { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int? DeletedBy { get; set; }
        public DateTime? DeletedDate { get; set; }
        public string errorMessage { get; set; }

        //---------------------------------Extra Property---------------------------------
        public string JobType { get; set; }
        public string Job { get; set; }
        public string JobCode { get; set; }
        public string EmployeeName { get; set; }
        public string ContactPerson { get; set; }
        public string AccountName { get; set; }
        public string SelectedDate { get; set; }

        public string FromAddress { get; set; }
        public string ToAddress { get; set; }
        public string FollowUpType { get; set; }
        public HttpPostedFileBase VisitingCard { get; set; }
        public string VisitingCardName { get; set; }
        public Int64 CRMSaleCallMasterID { get; set; }
        public Int64 CallEnquiryMasterID { get; set; }        
        public Int16 ScheduleStatus { get; set; }
        public Int16 EnquiryStatus { get; set; }

        public Int16 CallStatus { get; set; }        
        public string ToMail { get; set; }
        public string ToSubject { get; set; }
        public string Description { get; set; }
        public string ServeyDate { get; set; }
        public string ServeyTime { get; set; }
        public int JobCreationMasterID { get; set; }
        public string OtherListEmployeIDXml { get; set; }
        public Int16 CRMSaleEnquiryAccountMasterID { get; set; }
        public Int16 CRMSaleEnquiryAccountContactPersonID { get; set; }
    }
}
