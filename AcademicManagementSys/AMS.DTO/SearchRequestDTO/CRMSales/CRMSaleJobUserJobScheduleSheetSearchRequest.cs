using AMS.Base.DTO;
using System;
namespace AMS.DTO
{
    public class CRMSaleJobUserJobScheduleSheetSearchRequest : Request
    {
        public Int64 ID { get; set; }
        public Int64 JobCreationAllocationID { get; set; }
        public string JobType { get; set; }
        public int EmployeeID { get; set; }
        public string TransactionDate { get; set; }
        public string FromTime { get; set; }
        public string UpToTime { get; set; }
        public Int16 ScheduleType { get; set; }
        public Int16 SubScheduleType { get; set; }
        public bool IsAttendOther { get; set; }
        public string OtherListEmployeId { get; set; }
        public decimal VisitedLat { get; set; }
        public decimal VisitedLang { get; set; }
        public Int16 CallerJobStatus { get; set; }
        public Int16 MeetingStatus { get; set; }

        public int JobCreationMasterID { get; set; }
        public Int16 GeneralOtherJobTypeID { get; set; }
        public string Relatedwith { get; set; }
        public bool IsInvitation { get; set; }
        public Int64 CRMJobUserJobScheduleParentID { get; set; }

        public string SortOrder { get; set; }
        public string SortBy { get; set; }
        public int StartRow { get; set; }
        public int RowLength { get; set; }
        public int EndRow { get; set; }
        public string SearchBy { get; set; }
        public string SortDirection { get; set; }
        public string SelectedDate { get; set; }
        public int EnquiryAccountMasterId { get; set; }
        public int EnquiryAccountContactPersonId { get; set; }
    }
}
