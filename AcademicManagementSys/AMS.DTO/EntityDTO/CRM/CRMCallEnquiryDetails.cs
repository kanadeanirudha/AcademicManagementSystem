using AMS.Base.DTO;
using System;
namespace AMS.DTO
{
	public class CRMCallEnquiryDetails : BaseDTO
	{
		public int ID
		{
			get;
			set;
		}
        public int CallEnquiryMasterID
		{
			get;
			set;
		}
       
        public string CalleeFirstName
		{
			get;
			set;
		}
        public string StudentFirstName
        {
            get;
            set;
        }
        public string CalleeMiddelName
		{
			get;
			set;
		}
        public string StudentMiddelName
        {
            get;
            set;
        }
        public string CalleeLastName
        {
            get;
            set;
        }
        public string StudentLastName
        {
            get;
            set;
        }
        public string CallerFullName
        {
            get;
            set;
        }
        public string CalleeMobileNo
        {
            get;
            set;
        }
        public string StudentMobileNo
        {
            get;
            set;
        }
        public string CalleeEmailID
        {
            get;
            set;
        }
        public string StudentEmailID
        {
            get;
            set;
        }
        public int CalleePersonID
		{
			get;
			set;
		}
        public string CalleePersonType
        {
            get;
            set;
        }
        public string CalleeEntityType
        {
            get;
            set;
        }
        
       public Int16 Status
		{
			get;
			set;
		}
       public Int32 UnallocatedCalls
		{
			get;
			set;
		}
       public Int32 AllocatedCalls
		{
			get;
			set;
		}
      
        public string Source
        {
            get;
            set;
        }
        public string UploadDate
        {
            get;
            set;
        }
        public string SourceContactPerson

        {
            get;
            set;
        }
        public Int16 CallTypeID
        {
            get;
            set;
        }
        public int UploadExcelID
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
		public int ModifiedBy
		{
			get;
			set;
		}
		public DateTime ModifiedDate
		{
			get;
			set;
		}
		public int DeletedBy
		{
			get;
			set;
		}
		public DateTime DeletedDate
		{
			get;
			set;
		}
        public string errorMessage { get; set; }
        public string XMLstring { get; set; }
        public string CallForwardTo
        {
            get;
            set;
        }
        public int PendingCallEnquiryCount
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
        public Int16 CallStatus
        {
            get;
            set;
        }
        public Int16 CallerJobStatus
        {
            get;
            set;
        }
        public bool IsButtonShow
        {
            get;
            set;
        }
        public Int64 JobAllocationID
        {
            get;
            set;
        }
        public Int64 CallMasterID
        {
            get;
            set;
        }
        public Int32 JobCreationMasterID
        {
            get;
            set;
        }
        public int CRMCallTypeID
        {
            get;
            set;
        }
        public string StartDate { get; set; }
        public string EndDate { get; set; }

	}
}
