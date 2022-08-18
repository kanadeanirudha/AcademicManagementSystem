using AMS.Base.DTO;
using System;
namespace AMS.DTO
{
	public class InventoryDayEndJob : BaseDTO
	{
		public int ID
		{
			get;
			set;
		}
        public Int16 AccBalsheetMstID
        {
            get;
            set;
        }
        
        public string Timezone
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

        public int Status
        {
            get;
            set;
        }
	}
}
