using AMS.DTO;
using System;
using System.Collections.Generic;

namespace AMS.ViewModel
{
    public interface ICRMSaleJobUserJobScheduleSheetViewModel
    {
        Int64 ID { get; set; }
        Int64 JobCreationAllocationID { get; set; }
        int EmployeeID { get; set; }
        string TransactionDate { get; set; }
        string FromTime { get; set; }
        string UpToTime { get; set; }
        Int16 ScheduleType { get; set; }
        Int16 SubScheduleType { get; set; }
        bool IsAttendOther { get; set; }
        string OtherListEmployeId { get; set; }
        decimal VisitedLat { get; set; }
        decimal VisitedLang { get; set; }
        Int16 CallerJobStatus { get; set; }
        Int16 GeneralOtherJobTypeID { get; set; }
        string Relatedwith { get; set; }
        bool IsInvitation { get; set; }
        Int64 CRMJobUserJobScheduleParentID { get; set; }

        bool IsDeleted { get; set; }
        int CreatedBy { get; set; }
        DateTime CreatedDate { get; set; }
        int? ModifiedBy { get; set; }
        DateTime? ModifiedDate { get; set; }
        int? DeletedBy { get; set; }
        DateTime? DeletedDate { get; set; }
        string errorMessage { get; set; }
        
        int JobCreationMasterID { get; set; }
    }
}
