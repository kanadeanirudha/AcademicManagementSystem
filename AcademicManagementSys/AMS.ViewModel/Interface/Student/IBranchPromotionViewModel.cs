using AMS.DTO;
using System;

namespace AMS.ViewModel
{
    public interface IBranchPromotionViewModel  
    {
        //---------------------------------Properties of StuAdmissionDetails Table------------------------------------------
        BranchPromotion BranchPromotionDTO { get; set; }
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
		// int SectionDetailID
        //{
        //    get;
        //    set;
        //}
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
		 bool AdmissionCancelStatus
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

          string BranchDescription
         {
             get;
             set;
         }


          string CourseYearDesc
         {
             get;
             set;
         }


          string SectionDesc
         {
             get;
             set;
         }


          string SessionName
         {
             get;
             set;
         }
          int SessionID
         {
             get;
             set;
         }


          string CentreName
         {
             get;
             set;
         }

        //---------------------------------Properties of StustudentMaster Table------------------------------------------
         string StudentCode
         {
             get;
             set;
         }
         string Title
         {
             get;
             set;
         }
         string NickName
         {
             get;
             set;
         }
         string FirstName
         {
             get;
             set;
         }
         string MiddleName
         {
             get;
             set;
         }
         string LastName
         {
             get;
             set;
         }
         string MotherName
         {
             get;
             set;
         }
         string StudentOccupation
         {
             get;
             set;
         }
         int StudentMobileNumber
         {
             get;
             set;
         }
         int ParentMobileNumber
         {
             get;
             set;
         }
         int GuardianMobileNumber
         {
             get;
             set;
         }
         int ParentLandlineNumber
         {
             get;
             set;
         }
         string ParentEmailID
         {
             get;
             set;
         }
         string GuardianEmailID
         {
             get;
             set;
         }
         string FatherEmailID
         {
             get;
             set;
         }
         string MotherEmailID
         {
             get;
             set;
         }
         string StudentEmailID
         {
             get;
             set;
         }
         string NameAsPerLeaving
         {
             get;
             set;
         }
         string LastSchoolCollegeAttend
         {
             get;
             set;
         }
         int PreviousLeavingNumber
         {
             get;
             set;
         }
         string CastAsPerLeaving
         {
             get;
             set;
         }
         string LeavingDatetime
         {
             get;
             set;
         }
         int EnrollmentNumber
         {
             get;
             set;
         }
         Int16 DomicileStateID
         {
             get;
             set;
         }
         Int16 DomicileCountryID
         {
             get;
             set;
         }
         int MigrationNumber
         {
             get;
             set;
         }
         string MigrationDatetime
         {
             get;
             set;
         }
         //string AdmissionNumber
         //{
         //    get;
         //    set;
         //}
         int AdmissionCategoryID
         {
             get;
             set;
         }
         int AdmissionTypeID
         {
             get;
             set;
         }
         int QuotaMstID
         {
             get;
             set;
         }
         int SeatMstID
         {
             get;
             set;
         }
         bool IsHostelResidency
         {
             get;
             set;
         }
         int RfidTagIDNo
         {
             get;
             set;
         }
         int BranchID
         {
             get;
             set;
         }
         int FeeStructureID
         {
             get;
             set;
         }
         int SectionDetailID
         {
             get;
             set;
         }
         int OldSectionDetailID
         {
             get;
             set;
         }
         int CourseYearId
         {
             get;
             set;
         }
         int CourseYearOldId
         {
             get;
             set;
         }
         bool StudentActiveFlag
         {
             get;
             set;
         }
         string StudentStatus
         {
             get;
             set;
         }
         //string StatusCode
         //{
         //    get;
         //    set;
         //}
         string StuAdmissionCode
         {
             get;
             set;
         }
         //string AcademicYear
         //{
         //    get;
         //    set;
         //}
         string AdmitAcademicYear
         {
             get;
             set;
         }
         string StuAdmissionType
         {
             get;
             set;
         }
         string QulifyingExamType
         {
             get;
             set;
         }
         string FirstAdmissionDatetime
         {
             get;
             set;
         }
         //string CentreCode
         //{
         //    get;
         //    set;
         //}
         string AdmissionPattern
         {
             get;
             set;
         }
         int TransferSectionID
         {
             get;
             set;
         }
         int RegistrationID
         {
             get;
             set;
         }
         bool IsDomicleFromLast3Year
         {
             get;
             set;
         }
         bool IsNriPoi
         {
             get;
             set;
         }
         int TransferCoursesYearId
         {
             get;
             set;
         }
         string DirectSecYrAdmissionMode
         {
             get;
             set;
         }
         string AdmittedInShift
         {
             get;
             set;
         }
         string AllotAdmThrough
         {
             get;
             set;
         }
         int BankAccountNumber
         {
             get;
             set;
         }
         string BankBranchName
         {
             get;
             set;
         }
         string BankBranchCity
         {
             get;
             set;
         }
         int UniqueIdentificatinNumber
         {
             get;
             set;
         }
         string IdentificationType
         {
             get;
             set;
         }
         string StudentName { get; set; }


    }
}