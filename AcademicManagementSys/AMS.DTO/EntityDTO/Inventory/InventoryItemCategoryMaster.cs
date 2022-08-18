using AMS.Base.DTO;
using System;
namespace AMS.DTO
{
	public class InventoryItemCategoryMaster : BaseDTO
	{
		public int ID
		{
			get;
			set;
		}
        public string CategoryDescription
		{
			get;
			set;
		}
        public string CategoryCode
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
	}
}
