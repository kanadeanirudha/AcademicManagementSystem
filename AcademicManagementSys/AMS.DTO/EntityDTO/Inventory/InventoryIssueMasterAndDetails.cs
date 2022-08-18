using AMS.Base.DTO;
using System;
namespace AMS.DTO
{
	public class InventoryIssueMasterAndDetails : BaseDTO
	{
        //---------------------------------------IssueMaster-----------------------------
		public int IssueMasterID
		{
			get;
			set;
		}
        public int IssueFromLocationID
        {
            get;
            set;
        }
        public int IssueToLocationID
        {
            get;
            set;
        }
        public int AccountSessionID
        {
            get;
            set;
        }
      
		public string TransactionDate
		{
			get;
			set;
		}
		public string IssueNumber
		{
			get;
			set;
		}
        public string CentreCode
        {
            get;
            set;
        }
        public string IssueFromLocationName
        {
            get;
            set;
        }
        public string IssueToLocationName
        {
            get;
            set;
        }
        public string ParameterXml
        {
            get;
            set;
        }
        public string UnitCode
        {
            get;
            set;
        }
        public int UnitID
        {
            get;
            set;
        }
        public string ItemName
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

        //--------------------------------------IssueDetails------------------------------
        public int SalesTransactionID
        {
            get;
            set;
        }
      
        public int ItemID
        {
            get;
            set;
        }

        public decimal Quantity
        {
            get;
            set;
        }
        public decimal CurrentStockQuantity
        {
            get;
            set;
        }
        public string errorMessage { get; set; }
        public string SelectedBalanceSheet { get; set; }
	}
}
