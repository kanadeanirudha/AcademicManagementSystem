using AMS.Base.DTO;
using System;
namespace AMS.DTO
{
	public class InventoryDumpAndShrinkMasterAndDetails : BaseDTO
	{
        //------------------------------------Properties of Dump & Shrink Master Table------------------------------------
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
		public int BalanceSheetID
		{
			get;
			set;
		}
        public int LocationID
        {
            get;
            set;
        }
		public decimal DumpAndShrinkAmount
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
        public bool Status { get; set; }
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

        //------------------------------------Properties of Dump & Shrink Details Table------------------------------------
		public int DumpAndShrinkDetailID
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
		public decimal DumpQuantity
		{
			get;
			set;
		}
        public decimal ShrinkQuantity
		{
			get;
			set;
		}
        public decimal CurrentQuantity { get; set; }
        public decimal ActualWeight { get; set; }
        public decimal Rate
		{
			get;
			set;
		}
		public bool ApprovedStatus
		{
			get;
			set;
		}

        public decimal ApprovedDumpQty { get; set; }
        public decimal ApprovedShrinkQty { get; set; }
		public string Remark
		{
			get;
			set;
		}
        public int UnitID { get; set; }
        public string UnitCode { get; set; }
        public string BalancesheetName { get; set; }
        public string XMLstring { get; set; }
        public string Location { get; set; }
        public string errorMessage { get; set; }

        #region ------------TaskNotification Properties---------------
        public int TaskNotificationMasterID
        {
            get;
            set;
        }
        public string TaskCode
        {
            get;
            set;
        }
        public int TaskNotificationDetailsID
        {
            get;
            set;
        }
        public int GeneralTaskReportingDetailsID
        {
            get;
            set;
        }
        public int PersonID
        {
            get;
            set;
        }
        public int StageSequenceNumber
        {
            get;
            set;
        }
        public bool IsLastRecord
        {
            get;
            set;
        }
        #endregion
	}
}
