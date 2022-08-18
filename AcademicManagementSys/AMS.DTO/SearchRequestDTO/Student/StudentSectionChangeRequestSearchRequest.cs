using AMS.Base.DTO;

namespace AMS.DTO
{
	public class StudentSectionChangeRequestSearchRequest : Request
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
		public int RequestSectionDetailId
		{
			get;
			set;
		}
		public int SessionID
		{
			get;
			set;
		}
		public string CentreCode
		{
			get;
			set;
		}
		public int OldSectionDetailID
		{
			get;
			set;
		}
		public string StatusOfRequest
		{
			get;
			set;
		}
		public int ApprovedEmployeeId
		{
			get;
			set;
		}
		public string ApprovedDate
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
        public int CourseYearID { get; set; }
        public int SectionDetailID { get; set; }
        public string ErrorMessage { get; set; }
	}
}
