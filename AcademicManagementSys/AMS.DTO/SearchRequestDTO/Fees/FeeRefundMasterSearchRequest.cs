using AMS.Base.DTO;
using System;
namespace AMS.DTO
{
	public class FeeRefundMasterSearchRequest : Request
	{
		public int ID
		{
			get;
			set;
		}
		public Int16 AccSessionID
		{
			get;
			set;
		}
        public Int16 IsChashOrBankFlag { get; set; }
        public int AccBalanceSheetID
		{
			get;
			set;
		}
		public string CentreCode
		{
			get;
			set;
		}
		public int AcademicYearID
		{
			get;
			set;
		}
		public string PersonType
		{
			get;
			set;
		}
		public int PersonID
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
	}
}
