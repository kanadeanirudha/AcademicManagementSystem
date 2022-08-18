using AMS.Base.DTO;
using System;
namespace AMS.DTO
{
	public class ScholarShipAllocationSearchRequest : Request
	{
		public int ID
		{
			get;
			set;
		}
		public int StudentID
		{
			get;
			set;
		}
		public int ScholarShipMasterID
		{
			get;
			set;
		}
        public string TransDate
		{
			get;
			set;
		}
		public string ScholarSheepDocumentNumber
		{
			get;
			set;
		}
        public bool IsApproved
		{
			get;
			set;
		}
		public int ApporvedBy
		{
			get;
			set;
		}
		public bool ApproveStatus
		{
			get;
			set;
		}
		public int LastSectionDetailID
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
        public string SearchBy
        {
            get;
            set;
        }
        public string SortDirection
        {
            get;
            set;
        }
        public string SearchWord
        {
            get;
            set;
        }
        public int BranchID
        {
            get;
            set;
        }
        public string ScopeIdentity
        {
            get;
            set;
        }
        public string CentreCode
        {
            get;
            set;
        }
        public int PersonID
		{
			get;
			set;
		}
        public int TaskNotificationMasterID
		{
			get;
			set;
		}
        public int AccBalanceSheetID
		{
			get;
			set;
		}  
	}
}
