using AMS.Base.DTO;
using System;
namespace AMS.DTO
{
	public class OnlineExaminationMasterSearchRequest : Request
	{
		public int ID
		{
			get;
			set;
		}
		public string ExaminationName
		{
			get;
			set;
		}
		public string Purpose
		{
			get;
			set;
		}
		public int AcadSessionId
		{
			get;
			set;
		}
		public TimeSpan TotalTime
		{
			get;
			set;
		}
		public Int16 TotalQuestion
		{
			get;
			set;
		}
		public decimal TotalMarks
		{
			get;
			set;
		}
		public decimal MarksInEachQuestion
		{
			get;
			set;
		}
		public bool IsNegativeMarkingApplicable
		{
			get;
			set;
		}
		public decimal NegativeMarksInEachQuestion
		{
			get;
			set;
		}
		public Int16 TotalPaperSet
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
        public string SortDirection
		{
			get;
			set;
		}
        public string SearchBy
		{
			get;
			set;
		}
        public string SearchWord { get; set; }
        public int MaxResults
        {
            get;
            set;
        }
	}
}
