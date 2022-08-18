using AMS.Base.DTO;
using System;
namespace AMS.DTO
{
    public class CRMJobCreationMasterAndAllocationSearchRequest : Request
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
        public bool IsNeededCaptureData
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
        public bool IsActive
        {
            get;
            set;
        }
      #endregion
    }
}
