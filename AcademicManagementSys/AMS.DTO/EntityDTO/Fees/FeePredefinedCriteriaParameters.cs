using AMS.Base.DTO;
using System;
namespace AMS.DTO
{
	public class FeePredefinedCriteriaParameters : BaseDTO
	{
		public int ID
		{
			get;
			set;
		}
        public string FeeCriteriaParametersDescription
		{
			get;
			set;
		}
        public string FeeCriteriaParametersCode
		{
			get;
			set;
		}
        public string TableEntityName
        {
            get;
            set;
        }
        public string PrimaryKeyFieldName
        {
            get;
            set;
        }
        public string DisplayKeyFieldName
        {
            get;
            set;
        }
        public string TableName { get; set; }
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


        //Extra Property
        public int BalanceSheetID { get; set; }
	}
}
