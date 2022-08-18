using AMS.Base.DTO;
using System;
namespace AMS.DTO
{
	public class InventoryEstimationMasterAndDetails : BaseDTO
	{
        //--------------------------------Properties of EstimationMaster Table-----------------------------------
		public int ID
		{
			get;
			set;
		}
		public string TransactionDate
		{
			get;
			set;
		}
		public string CustomerName
		{
			get;
			set;
		}
		public string CustomerAddress
		{
			get;
			set;
		}
		public string CustomerMobileNumber
		{
			get;
			set;
		}
		public decimal EstimationAmount
		{
			get;
			set;
		}
		public Boolean EstimationStatus
		{
			get;
			set;
		}
		public Int16 BalanceSheetID
		{
			get;
			set;
		}
		public Boolean IsPendingForBill
		{
			get;
			set;
		}
		public string BillNumber
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
        //--------------------------------Properties of EstimationDetails Table-----------------------------------
        public int EstimationDetailID
        {
            get;
            set;
        }
        public int ItemID
        {
            get;
            set;
        }
        public string ItemName { get; set; }
        public decimal Quantity
        {
            get;
            set;
        }
        public decimal Rate
        {
            get;
            set;
        }
        public int LocationID { get; set; }
        public string errorMessage { get; set; }
        public string SelectedBalanceSheet { get; set; }
        public string XMLstring { get; set; }
        public decimal totalTaxString { get; set; }
        public decimal totalDiscountString { get; set; }
        public string EstimateLocationWiseXMLstring { get; set; }
        public decimal AvailableStock { get; set; }
        public int UnitID { get; set; }
        public string UnitCode { get; set; }
        public decimal Total { get; set; }
        public string PrintingLine1 { get; set; }
        public string PrintingLine2 { get; set; }
        public string PrintingLine3 { get; set; }
        public string PrintingLine4 { get; set; }
        public string CurrencyCode { get; set; }
        public decimal TotalTaxAmount { get; set; }
        public decimal TotalDiscountAmount { get; set; }
        public int GenTaxGroupMasterID { get; set; }
        public decimal taxpercentage { get; set; }
        public decimal RateDecreaseByPercentage { get; set; }
        public decimal GrossAmount
        {
            get;
            set;
        }
        public decimal TotalTaxAmountt { get; set; }
        public int CustomerID { get; set; }
        public decimal DiscountAmountForItem { get; set; }
        public decimal TotalTaxForItem{ get; set; }
	}
}
