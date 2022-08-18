using AMS.Base.DTO;
using System;
namespace AMS.DTO
{
	public class StudentMaster : BaseDTO
	{
		public int ID
		{
			get;
			set;
		}
		public string StudentCode
		{
			get;
			set;
		}
        public string StudentFullName
		{
			get;
			set;
		}
        
		public string Title
		{
			get;
			set;
		}
		public string NickName
		{
			get;
			set;
		}
		public string FirstName
		{
			get;
			set;
		}
		public string MiddleName
		{
			get;
			set;
		}
		public string LastName
		{
			get;
			set;
		}
        public string StudentGender
        {
            get;
            set;
        }
		public string MotherName
		{
			get;
			set;
		}
		public string StudentOccupation
		{
			get;
			set;
		}
		public int StudentMobileNumber
		{
			get;
			set;
		}
		public int ParentMobileNumber
		{
			get;
			set;
		}
		public int GuardianMobileNumber
		{
			get;
			set;
		}
		public int ParentLandlineNumber
		{
			get;
			set;
		}
		public string ParentEmailID
		{
			get;
			set;
		}
		public string GuardianEmailID
		{
			get;
			set;
		}
		public string FatherEmailID
		{
			get;
			set;
		}
		public string MotherEmailID
		{
			get;
			set;
		}
		public string StudentEmailID
		{
			get;
			set;
		}
		public string NameAsPerLeaving
		{
			get;
			set;
		}
		public string LastSchoolCollegeAttend
		{
			get;
			set;
		}
		public int PreviousLeavingNumber
		{
			get;
			set;
		}
		public string CastAsPerLeaving
		{
			get;
			set;
		}
        public string LeavingDatetime
		{
			get;
			set;
		}
		public int EnrollmentNumber
		{
			get;
			set;
		}
		public Int16 DomicileStateID
		{
			get;
			set;
		}
		public Int16 DomicileCountryID
		{
			get;
			set;
		}
		public int MigrationNumber
		{
			get;
			set;
		}
        public string MigrationDatetime
		{
			get;
			set;
		}
		public string AdmissionNumber
		{
			get;
			set;
		}
		public int AdmissionCategoryID
		{
			get;
			set;
		}
		public int AdmissionTypeID
		{
			get;
			set;
		}
		public int QuotaMstID
		{
			get;
			set;
		}
		public int SeatMstID
		{
			get;
			set;
		}
        public bool IsHostelResidency
		{
			get;
			set;
		}
		public int RfidTagIDNo
		{
			get;
			set;
		}
		public int BranchID
		{
			get;
			set;
		}
		public int FeeStructureID
		{
			get;
			set;
		}
		public int SectionDetailID
		{
			get;
			set;
		}
		public int OldSectionDetailID
		{
			get;
			set;
		}
		public int CourseYearId
		{
			get;
			set;
		}
        public string CourseYearDescription
        {
            get;
            set;
        }
		public int CourseYearOldId
		{
			get;
			set;
		}
        public bool StudentActiveFlag
		{
			get;
			set;
		}
		public string StudentStatus
		{
			get;
			set;
		}
		public string StatusCode
		{
			get;
			set;
		}
		public string StuAdmissionCode
		{
			get;
			set;
		}
		public string AcademicYear
		{
			get;
			set;
		}
		public string AdmitAcademicYear
		{
			get;
			set;
		}
		public string StuAdmissionType
		{
			get;
			set;
		}
		public string QulifyingExamType
		{
			get;
			set;
		}
        public string FirstAdmissionDatetime
		{
			get;
			set;
		}
		public string CentreCode
		{
			get;
			set;
		}
        public string CentreName
		{
			get;
			set;
		}
        
		public string AdmissionPattern
		{
			get;
			set;
		}
		public int TransferSectionID
		{
			get;
			set;
		}
		public int RegistrationID
		{
			get;
			set;
		}
		public bool IsDomicleFromLast3Year
		{
			get;
			set;
		}
        public bool IsNriPoi
		{
			get;
			set;
		}
		public int TransferCoursesYearId
		{
			get;
			set;
		}
		public string DirectSecYrAdmissionMode
		{
			get;
			set;
		}
		public string AdmittedInShift
		{
			get;
			set;
		}
		public string AllotAdmThrough
		{
			get;
			set;
		}
		public int BankAccountNumber
		{
			get;
			set;
		}
		public string BankBranchName
		{
			get;
			set;
		}
		public string BankBranchCity
		{
			get;
			set;
		}
		public int UniqueIdentificatinNumber
		{
			get;
			set;
		}
		public string IdentificationType
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

        public int StudentId { get; set; }
        public int BranchId { get; set; }
        public string BranchDescription { get; set; }
        public string SectionDesc { get; set; }
        public string CourseYearDesc { get; set; }
        public string searchType { get; set; }
	}
}
