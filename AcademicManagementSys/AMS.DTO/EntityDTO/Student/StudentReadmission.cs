using AMS.Base.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.DTO
{
	public class StudentReadmission : BaseDTO         ///StuAdmissionDetails Table///
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
		public string AdmissionCancelStatus
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
        public string CentreName { get; set; }
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
        public string StudentName { get; set; }
        public string BranchDescription { get; set; }
        public string CourseYearDesc { get; set; }
        public string SectionDesc { get; set; }
        public string SessionName { get; set; }
        public int SessionID { get; set; }
        public string errorMessage { get; set; }

        public int CourseYearId
        {
            get;
            set;
        }
        public string StudentCode { get; set; }
        public string searchType { get; set; }
        public int StuAdmissionDetailID { get; set; }
        public int OldSectionDetailID { get; set; }
        public int CourseYearOldId { get; set; }
        public string IsCurrentYearStudent { get; set; }
        public string ActiveSessionFlag { get; set; }
	}
}
