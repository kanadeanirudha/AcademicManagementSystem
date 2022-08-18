using AMS.Base.DTO;
using System;
namespace AMS.DTO
{
	public class FeeLateFeesMaster : BaseDTO
	{
        //-----------------------Properties of FeeLateFeesMaster  table----------------------------------
		public int ID
		{
			get;
			set;
		}
		public string LateFeeDescription
		{
			get;
			set;
		}
        public string LateFeeType
		{
			get;
			set;
		}
        public string SlabFixedFlag
		{
			get;
			set;
		}
		public decimal LateFeeAmount
		{
			get;
			set;
		}
        public decimal LateFeeAmountForSlab
		{
			get;
			set;
		}
		public int PeriodTypeID
		{
			get;
			set;
		}
        public string PeriodType
        {
            get;
            set;
        }
        public string PeriodTypeForSlab
        {
            get;
            set;
        }
		public int FeeSubTypeID
		{
			get;
			set;
		}
        public string FeeSubType
        {
            get;
            set;
        }
        public bool IsIncremental
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

        //-------------------------Properties of FeeLateFeeSlabDetails  table---------------------------
        public int LateFeesMasterID
        {
            get;
            set;
        }
        public string LateFeeSlabFrom
        {
            get;
            set;
        }
        public string LateFeeSlabTo
        {
            get;
            set;
        }
        public decimal LateFeeValue
        {
            get;
            set;
        }
        public string errorMessage { get; set; }
        public string SelectedXml { get; set; }
        
	}
}
