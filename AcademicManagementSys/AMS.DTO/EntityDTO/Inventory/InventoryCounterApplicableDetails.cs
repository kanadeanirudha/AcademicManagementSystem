using AMS.Base.DTO;
using System;
namespace AMS.DTO
{
	public class InventoryCounterApplicableDetails : BaseDTO
	{
		public int ID
		{
			get;
			set;
		}

        public string CentreCode
        {
            get;
            set;
        }
        public int InvCounterMasterID
		{
			get;
			set;
		}
        public int  InvMachineMasterID 
		{
			get;
			set;
		}
        public Int16 AccBalsheetMstID
        {
            get;
            set;
        }
        public string MachineCode
        {
            get;
            set;
        }
        public string MachineName
        {
            get;
            set;
        }
        public string CounterName
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
        public bool StatusFlag
        {
            get;
            set;
        }
        public string errorMessage { get; set; }
	}
}
