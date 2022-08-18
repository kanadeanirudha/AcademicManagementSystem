using AMS.Base.DTO;
using System;
namespace AMS.DTO
{
	public class EntranceExamSearchRequest : Request
	{
		public int ID
		{
			get;
			set;
		}
		public int StudentRegistrationID
		{
			get;
			set;
		}
		public int EntranceExamApplicableExamToCourseID
		{
			get;
			set;
		}
		public string CourseYearCode
		{
			get;
			set;
		}
        public Int16 AttendanceFlag
		{
			get;
			set;
		}
		public string AttendLogInTime
		{
			get;
			set;
		}
		public string ExaminationDate
		{
			get;
			set;
		}
		public string ExaminationStartTime
		{
			get;
			set;
		}
		public string ExaminationEndTime
		{
			get;
			set;
		}
        public Boolean IsExaminationOver
		{
			get;
			set;
		}
		public string SessionName
		{
			get;
			set;
		}
        public Boolean LoginStatus
		{
			get;
			set;
		}
        public Boolean IsLock
		{
			get;
			set;
		}
		public int OnlineExaminationPaperID
		{
			get;
			set;
		}
		public string IPAddress
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
	}
}
