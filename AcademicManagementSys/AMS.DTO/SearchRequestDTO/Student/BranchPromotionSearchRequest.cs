using AMS.Base.DTO;

namespace AMS.DTO
{
    public class BranchPromotionSearchRequest : Request
	{
		public int ID
		{
			get;
			set;
		}
		public int StudentId
		{
			get;
			set;
		}
		public string FormNumber
		{
			get;
			set;
		}
        public string FormDate
		{
			get;
			set;
		}
		public int SectionDetailID
		{
			get;
			set;
		}
        public string AdmissionDate
		{
			get;
			set;
		}
		public bool AdmissionActiveFlag
		{
			get;
			set;
		}
		public string AcademicYear
		{
			get;
			set;
		}
		public string YearlyRollNumber
		{
			get;
			set;
		}
		public string RollNoSortOrder
		{
			get;
			set;
		}
		public string SortOrderStatus
		{
			get;
			set;
		}
        public string FromSession
		{
			get;
			set;
		}
        public string UptoSession
		{
			get;
			set;
		}
		public string ResultStatus
		{
			get;
			set;
		}
        public bool AdmissionCancelStatus
		{
			get;
			set;
		}
		public string AdmissionStatus
		{
			get;
			set;
		}
        public string AdmissionCancelDate
		{
			get;
			set;
		}
		public int BranchId
		{
			get;
			set;
		}
		public string PromotedToNextBranch
		{
			get;
			set;
		}
		public string StatusCode
		{
			get;
			set;
		}
        public string AdmissionConfirmDate
		{
			get;
			set;
		}
        public string AdmissionPromoteDate
		{
			get;
			set;
		}
		public string CentreCode
		{
			get;
			set;
		}
		public string Remark
		{
			get;
			set;
		}
		public string AdmissionNumber
		{
			get;
			set;
		}
		public string PrevExamSeatNo
		{
			get;
			set;
		}
		public string EligibForCuryrAdmsn
		{
			get;
			set;
		}
		public string ResultCurYear
		{
			get;
			set;
		}
		public string DtndForSemester
		{
			get;
			set;
		}
		public string SemesterSpecificAdmsn
		{
			get;
			set;
		}
		public int StuRevalAppliId
		{
			get;
			set;
		}
		public string ProvisionalType
		{
			get;
			set;
		}
		public string AdmissionFinalStatus
		{
			get;
			set;
		}
		public int SessionID
		{
			get;
			set;
		}
        public bool IsLastRecord
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
        public int CourseYearDetailID { get; set; }
        public int DepartmentID{ get; set; }
        public bool IsFirstYearPromotion { get; set; }
	}
}
