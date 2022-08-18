using AMS.Base.DTO;
using System;
namespace AMS.DTO
{
    public class CRMJobCreationMasterAndAllocation : BaseDTO
    {
        #region --------------CRMJobCreationMaster Fields--------------
        public int JobCreationMasterID
        {
            get;
            set;
        }
        public string JobName
        {
            get;
            set;
        }
        public string JobCode
        {
            get;
            set;
        }
        public string JobStartDate
        {
            get;
            set;
        }
        public string JobEndDate
        {
            get;
            set;
        }
        public Int16 CallTypeID
        {
            get;
            set;
        }
        public string CallTypeDescription
        {
            get;
            set;
        }
        public bool IsNeededCaptureData
        {
            get;
            set;
        }
        public bool IsActive
        {
            get;
            set;
        }
        public bool IsDeleted
        {
            get;
            set;
        }
        public int CreatedBy
        {
            get;
            set;
        }
        public DateTime CreatedDate
        {
            get;
            set;
        }
        public int? ModifiedBy
        {
            get;
            set;
        }
        public DateTime? ModifiedDate
        {
            get;
            set;
        }
        public int? DeletedBy
        {
            get;
            set;
        }
        public DateTime? DeletedDate
        {
            get;
            set;
        }
        public string errorMessage { get; set; }
        public bool IsExists { get; set; }
        #endregion

        #region ----------------CRMJobAllocation Fields----------------

        public Int64 JobAllocationID
        {
            get;
            set;
        }       
        public int CallEnquiryDetailID
        {
            get;
            set;
        }
        public int AdminRoleMasterID
        {
            get;
            set;
        }
        public int EmployeeID
        {
            get;
            set;
        }
        public string TransactionaDate
        {
            get;
            set;
        }
        public Int16 CallerJobStatus
        {
            get;
            set;
        }
        public Int16 PerDayCallTarget
        {
            get;
            set;
        }
        public string EmployeeName
        {
            get;
            set;
        }
        public int PendingCalls
        {
            get;
            set;
        }
        public string JobAllocationDetailsXMLstring
        {
            get;
            set;
        }
        public bool IsExpire
        {
            get;
            set;
        }
        #endregion
    }
}
