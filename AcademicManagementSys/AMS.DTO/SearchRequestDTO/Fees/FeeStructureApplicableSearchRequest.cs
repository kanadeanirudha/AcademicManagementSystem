using AMS.Base.DTO;
using System;
namespace AMS.DTO
{
	public class FeeStructureApplicableSearchRequest : Request
	{
		public int ID
		{
			get;
			set;
		}
		public int FeeStructureMasterID
		{
			get;
			set;
		}
        public string ApplicableFromDate
		{
			get;
			set;
		}
        public string ApplicableToDate
		{
			get;
			set;
		}
		public string CentreCode
		{
			get;
			set;
		}
		public string SortOrder
		{
			get;
			set;
		}
		public string SortBy
		{
			get;
			set;
		}
		public int StartRow
		{
			get;
			set;
		}
		public int RowLength
		{
			get;
			set;
		}
		public int EndRow
		{
			get;
			set;
		}
        public string SearchBy { get; set; }
        public string SortDirection { get; set; }
        public int AccBalanceSheetID { get; set; }
        public int FeeCriteriaMasterID { get; set; }

        //Extra Property
        public string Address { get; set; }
        public string AddmissionYear { get; set; }
        public string AdmissionType { get; set; }

        public int PersonID { get; set; }
        public int TaskNotificationDetailsID { get; set; }
        public int TaskNotificationMasterID { get; set; }
        public int GeneralTaskReportingDetailsID { get; set; }
        public string TaskCode { get; set; }
        public int StageSequenceNumber { get; set; }
        public bool IsLastRecord { get; set; }


        public int AccountID { get; set; }
        public int FeeReceivableVoucherStructureID { get; set; }
        public string AccountType { get; set; }
        public decimal Amount { get; set; }
        public bool CrDrStatus { get; set; }
        public string FeeSubShortDesc { get; set; }
        public Int16 Source { get; set; }
	}
}
