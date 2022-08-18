using AMS.DTO;
using System;

namespace AMS.ViewModel
{
    public interface IStudentReadmissionViewModel
    {
        StudentReadmission StudentReadmissionDTO { get; set; }
		 int ID
		{
			get;
			set;
		}
		 int StudentId
		{
			get;
			set;
		}
		 string FormNumber
		{
			get;
			set;
		}
		 string FormDate
		{
			get;
			set;
		}
		 int SectionDetailID
		{
			get;
			set;
		}
		 string AdmissionDate
		{
			get;
			set;
		}
		 bool AdmissionActiveFlag
		{
			get;
			set;
		}
		 string AcademicYear
		{
			get;
			set;
		}
		 string YearlyRollNumber
		{
			get;
			set;
		}
		 string RollNoSortOrder
		{
			get;
			set;
		}
		 string SortOrderStatus
		{
			get;
			set;
		}
         string FromSession
		{
			get;
			set;
		}
         string UptoSession
		{
			get;
			set;
		}
		 string ResultStatus
		{
			get;
			set;
		}
		 string AdmissionCancelStatus
		{
			get;
			set;
		}
		 string AdmissionStatus
		{
			get;
			set;
		}
         string AdmissionCancelDate
		{
			get;
			set;
		}
		 int BranchId
		{
			get;
			set;
		}
		 string PromotedToNextBranch
		{
			get;
			set;
		}
		 string StatusCode
		{
			get;
			set;
		}
         string AdmissionConfirmDate
		{
			get;
			set;
		}
         string AdmissionPromoteDate
		{
			get;
			set;
		}
		 string CentreCode
		{
			get;
			set;
		}
		 string Remark
		{
			get;
			set;
		}
		 string AdmissionNumber
		{
			get;
			set;
		}
		 string PrevExamSeatNo
		{
			get;
			set;
		}
		 string EligibForCuryrAdmsn
		{
			get;
			set;
		}
		 string ResultCurYear
		{
			get;
			set;
		}
		 string DtndForSemester
		{
			get;
			set;
		}
		 string SemesterSpecificAdmsn
		{
			get;
			set;
		}
		 int StuRevalAppliId
		{
			get;
			set;
		}
		 string ProvisionalType
		{
			get;
			set;
		}
		 string AdmissionFinalStatus
		{
			get;
			set;
		}
		 bool IsActive
		{
			get;
			set;
		}
		 bool IsDeleted
		{
			get;
			set;
		}
		 int CreatedBy
		{
			get;
			set;
		}
		 DateTime CreatedDate
		{
			get;
			set;
		}
		 int? ModifiedBy
		{
			get;
			set;
		}
		 DateTime? ModifiedDate
		{
			get;
			set;
		}
		 int? DeletedBy
		{
			get;
			set;
		}
		 DateTime? DeletedDate
		{
			get;
			set;
		}
    }
}
