using AMS.Base.DTO;
using System;
namespace AMS.DTO
{
	public class InventoryDailySaleReport : BaseDTO
	{
		public Int64 ID
		{
			get;
			set;
		}
		public string TransactionDate
		{
			get;
			set;
		}
		public string BillNumber
		{
			get;
			set;
		}
		public decimal BillAmount
		{
			get;
			set;
		}
        public decimal RoundUpAmount
		{
			get;
			set;
		}
		public string CustomerName
		{
			get;
			set;
		}
		public string CustomerType
		{
			get;
			set;
		}
		public int BalanceSheetID
		{
			get;
			set;
		}
		public int CounterLogId
		{
			get;
			set;
		}
		public int LocationID
		{
			get;
			set;
		}
		public bool IsActive
		{
			get;
			set;
		}
        public string   LocationName
		{
			get;
			set;
		}
        public string  AccBalsheetHeadDesc
		{
			get;
			set;
		}
        public string AccBalsheetCode
       {
           get;
           set;
       }
        public string FromDate { get; set; }
        public string UptoDate { get; set; }
        public decimal TotalDailySaleAmount { get; set; }
        public bool IsPosted
		{
			get;
			set;
		}
	}
}
