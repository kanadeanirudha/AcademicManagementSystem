using AMS.DTO;
using System;
using System.Collections.Generic;

namespace AMS.ViewModel
{
    public interface ICRMJobCreationMasterAndAllocationViewModel
    {
        CRMJobCreationMasterAndAllocation CRMJobCreationMasterAndAllocationDTO
        {
            get;
            set;
        }

        #region --------------CRMJobCreationMaster Fields--------------
        int JobCreationMasterID
        {
            get;
            set;
        }
        string JobName
        {
            get;
            set;
        }
        string JobCode
        {
            get;
            set;
        }
        string JobStartDate
        {
            get;
            set;
        }
        string JobEndDate
        {
            get;
            set;
        }
        Int16 CallTypeID
        {
            get;
            set;
        }
        string CallTypeDescription
        {
            get;
            set;
        }

        bool IsNeededCaptureData
        {
            get;
            set;
        }
        bool IsActive
        {
            get;
            set;
        }
        bool IsDeleted
        {
            get;
            set;
        }
        int CreatedBy
        {
            get;
            set;
        }
        DateTime CreatedDate
        {
            get;
            set;
        }
        int? ModifiedBy
        {
            get;
            set;
        }
        DateTime? ModifiedDate
        {
            get;
            set;
        }
        int? DeletedBy
        {
            get;
            set;
        }
        DateTime? DeletedDate
        {
            get;
            set;
        }
        string errorMessage { get; set; }
        #endregion

        #region ----------------CRMJobAllocation Fields----------------

        Int64 JobAllocationID
        {
            get;
            set;
        }
        int CallEnquiryDetailID
        {
            get;
            set;
        }
        int AdminRoleMasterID
        {
            get;
            set;
        }
        int EmployeeID
        {
            get;
            set;
        }
        string TransactionaDate
        {
            get;
            set;
        }
        Int16 CallerJobStatus
        {
            get;
            set;
        }
        Int16 PerDayCallTarget
        {
            get;
            set;
        }
        string EmployeeName
        {
            get;
            set;
        }
        #endregion


        List<CRMCallType> ListCallType
        {
            get;
            set;
        }

        int PendingCalls
        {
            get;
            set;
        }

        List<CRMJobCreationMasterAndAllocation> CRMJobAllocationList
        {
            get;
            set;
        }
    }

   
}
