using AMS.Common;
using AMS.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AMS.ViewModel
{
    public class StudentMasterViewModel : IStudentMasterViewModel
    {
        public StudentMasterViewModel()
        {
            StudentMasterDTO = new StudentMaster();
            ListGetAdminRoleApplicableCentre = new List<AdminRoleApplicableDetails>();
            ListOrganisationCourseYearDetails = new List<OrganisationCourseYearDetails>();
        }
        public StudentMaster StudentMasterDTO { get; set; }
        public List<AdminRoleApplicableDetails> ListGetAdminRoleApplicableCentre
        {
            get;
            set;
        }
        public IEnumerable<SelectListItem> ListGetAdminRoleApplicableCentreItems
        {
            get
            {
                return new SelectList(ListGetAdminRoleApplicableCentre, "CentreCode", "CentreName");
            }
        }
        public List<OrganisationCourseYearDetails> ListOrganisationCourseYearDetails
        {
            get;
            set;
        }
        public IEnumerable<SelectListItem> ListOrganisationCourseYearDetailsItems
        {
            get
            {
                return new SelectList(ListOrganisationCourseYearDetails, "ID", "CourseYearCode");
            }
        }
        public int ID
        {
            get
            {
                return (StudentMasterDTO != null && StudentMasterDTO.ID > 0) ? StudentMasterDTO.ID : new int();
            }
            set
            {
                StudentMasterDTO.ID = value;
            }
        }

        public string StudentFullName
        {
            get
            {
                return (StudentMasterDTO != null) ? StudentMasterDTO.StudentFullName : string.Empty;
            }
            set
            {
                StudentMasterDTO.StudentFullName = value;
            }
        }
        public string StudentCode
        {
            get
            {
                return (StudentMasterDTO != null) ? StudentMasterDTO.StudentCode : string.Empty;
            }
            set
            {
                StudentMasterDTO.StudentCode = value;
            }
        }
        public string Title
        {
            get
            {
                return (StudentMasterDTO != null) ? StudentMasterDTO.Title : string.Empty;
            }
            set
            {
                StudentMasterDTO.Title = value;
            }
        }
        public string NickName
        {
            get
            {
                return (StudentMasterDTO != null) ? StudentMasterDTO.NickName : string.Empty;
            }
            set
            {
                StudentMasterDTO.NickName = value;
            }
        }
        public string FirstName
        {
            get
            {
                return (StudentMasterDTO != null) ? StudentMasterDTO.FirstName : string.Empty;
            }
            set
            {
                StudentMasterDTO.FirstName = value;
            }
        }
        public string MiddleName
        {
            get
            {
                return (StudentMasterDTO != null) ? StudentMasterDTO.MiddleName : string.Empty;
            }
            set
            {
                StudentMasterDTO.MiddleName = value;
            }
        }
        public string LastName
        {
            get
            {
                return (StudentMasterDTO != null) ? StudentMasterDTO.LastName : string.Empty;
            }
            set
            {
                StudentMasterDTO.LastName = value;
            }
        }
        public string StudentGender
        {
            get
            {
                return (StudentMasterDTO != null) ? StudentMasterDTO.StudentGender : string.Empty;
            }
            set
            {
                StudentMasterDTO.StudentGender = value;
            }
        }
        public string MotherName
        {
            get
            {
                return (StudentMasterDTO != null) ? StudentMasterDTO.MotherName : string.Empty;
            }
            set
            {
                StudentMasterDTO.MotherName = value;
            }
        }
        public string StudentOccupation
        {
            get
            {
                return (StudentMasterDTO != null) ? StudentMasterDTO.StudentOccupation : string.Empty;
            }
            set
            {
                StudentMasterDTO.StudentOccupation = value;
            }
        }
        public int StudentMobileNumber
        {
            get
            {
                return (StudentMasterDTO != null && StudentMasterDTO.StudentMobileNumber > 0) ? StudentMasterDTO.StudentMobileNumber : new int();
            }
            set
            {
                StudentMasterDTO.StudentMobileNumber = value;
            }
        }
        public int ParentMobileNumber
        {
            get
            {
                return (StudentMasterDTO != null && StudentMasterDTO.ParentMobileNumber > 0) ? StudentMasterDTO.ParentMobileNumber : new int();
            }
            set
            {
                StudentMasterDTO.ParentMobileNumber = value;
            }
        }
        public int GuardianMobileNumber
        {
            get
            {
                return (StudentMasterDTO != null && StudentMasterDTO.GuardianMobileNumber > 0) ? StudentMasterDTO.GuardianMobileNumber : new int();
            }
            set
            {
                StudentMasterDTO.GuardianMobileNumber = value;
            }
        }
        public int ParentLandlineNumber
        {
            get
            {
                return (StudentMasterDTO != null && StudentMasterDTO.ParentLandlineNumber > 0) ? StudentMasterDTO.ParentLandlineNumber : new int();
            }
            set
            {
                StudentMasterDTO.ParentLandlineNumber = value;
            }
        }
        public string ParentEmailID
        {
            get
            {
                return (StudentMasterDTO != null) ? StudentMasterDTO.ParentEmailID : string.Empty;
            }
            set
            {
                StudentMasterDTO.ParentEmailID = value;
            }
        }
        public string GuardianEmailID
        {
            get
            {
                return (StudentMasterDTO != null) ? StudentMasterDTO.GuardianEmailID : string.Empty;
            }
            set
            {
                StudentMasterDTO.GuardianEmailID = value;
            }
        }
        public string FatherEmailID
        {
            get
            {
                return (StudentMasterDTO != null) ? StudentMasterDTO.FatherEmailID : string.Empty;
            }
            set
            {
                StudentMasterDTO.FatherEmailID = value;
            }
        }
        public string MotherEmailID
        {
            get
            {
                return (StudentMasterDTO != null) ? StudentMasterDTO.MotherEmailID : string.Empty;
            }
            set
            {
                StudentMasterDTO.MotherEmailID = value;
            }
        }
        public string StudentEmailID
        {
            get
            {
                return (StudentMasterDTO != null) ? StudentMasterDTO.StudentEmailID : string.Empty;
            }
            set
            {
                StudentMasterDTO.StudentEmailID = value;
            }
        }
        public string NameAsPerLeaving
        {
            get
            {
                return (StudentMasterDTO != null) ? StudentMasterDTO.NameAsPerLeaving : string.Empty;
            }
            set
            {
                StudentMasterDTO.NameAsPerLeaving = value;
            }
        }
        public string LastSchoolCollegeAttend
        {
            get
            {
                return (StudentMasterDTO != null) ? StudentMasterDTO.LastSchoolCollegeAttend : string.Empty;
            }
            set
            {
                StudentMasterDTO.LastSchoolCollegeAttend = value;
            }
        }
        public int PreviousLeavingNumber
        {
            get
            {
                return (StudentMasterDTO != null && StudentMasterDTO.PreviousLeavingNumber > 0) ? StudentMasterDTO.PreviousLeavingNumber : new int();
            }
            set
            {
                StudentMasterDTO.PreviousLeavingNumber = value;
            }
        }
        public string CastAsPerLeaving
        {
            get
            {
                return (StudentMasterDTO != null) ? StudentMasterDTO.CastAsPerLeaving : string.Empty;
            }
            set
            {
                StudentMasterDTO.CastAsPerLeaving = value;
            }
        }
        public string LeavingDatetime
        {
            get
            {
                return (StudentMasterDTO != null) ? StudentMasterDTO.LeavingDatetime : string.Empty;
            }
            set
            {
                StudentMasterDTO.LeavingDatetime = value;
            }
        }
        public int EnrollmentNumber
        {
            get
            {
                return (StudentMasterDTO != null && StudentMasterDTO.EnrollmentNumber > 0) ? StudentMasterDTO.EnrollmentNumber : new int();
            }
            set
            {
                StudentMasterDTO.EnrollmentNumber = value;
            }
        }
        public Int16 DomicileStateID
        {
            get
            {
                return (StudentMasterDTO != null && StudentMasterDTO.DomicileStateID > 0) ? StudentMasterDTO.DomicileStateID : new Int16();
            }
            set
            {
                StudentMasterDTO.DomicileStateID = value;
            }
        }
        public Int16 DomicileCountryID
        {
            get
            {
                return (StudentMasterDTO != null && StudentMasterDTO.DomicileCountryID > 0) ? StudentMasterDTO.DomicileCountryID : new Int16();
            }
            set
            {
                StudentMasterDTO.DomicileCountryID = value;
            }
        }
        public int MigrationNumber
        {
            get
            {
                return (StudentMasterDTO != null && StudentMasterDTO.MigrationNumber > 0) ? StudentMasterDTO.MigrationNumber : new int();
            }
            set
            {
                StudentMasterDTO.MigrationNumber = value;
            }
        }
        public string MigrationDatetime
        {
            get
            {
                return (StudentMasterDTO != null) ? StudentMasterDTO.MigrationDatetime : string.Empty;
            }
            set
            {
                StudentMasterDTO.MigrationDatetime = value;
            }
        }
        public string AdmissionNumber
        {
            get
            {
                return (StudentMasterDTO != null) ? StudentMasterDTO.AdmissionNumber : string.Empty;
            }
            set
            {
                StudentMasterDTO.AdmissionNumber = value;
            }
        }
        public int AdmissionCategoryID
        {
            get
            {
                return (StudentMasterDTO != null && StudentMasterDTO.AdmissionCategoryID > 0) ? StudentMasterDTO.AdmissionCategoryID : new int();
            }
            set
            {
                StudentMasterDTO.AdmissionCategoryID = value;
            }
        }
        public int AdmissionTypeID
        {
            get
            {
                return (StudentMasterDTO != null && StudentMasterDTO.AdmissionTypeID > 0) ? StudentMasterDTO.AdmissionTypeID : new int();
            }
            set
            {
                StudentMasterDTO.AdmissionTypeID = value;
            }
        }
        public int QuotaMstID
        {
            get
            {
                return (StudentMasterDTO != null && StudentMasterDTO.QuotaMstID > 0) ? StudentMasterDTO.QuotaMstID : new int();
            }
            set
            {
                StudentMasterDTO.QuotaMstID = value;
            }
        }
        public int SeatMstID
        {
            get
            {
                return (StudentMasterDTO != null && StudentMasterDTO.SeatMstID > 0) ? StudentMasterDTO.SeatMstID : new int();
            }
            set
            {
                StudentMasterDTO.SeatMstID = value;
            }
        }
        public bool IsHostelResidency
        {
            get
            {
                return (StudentMasterDTO != null) ? StudentMasterDTO.IsHostelResidency : false;
            }
            set
            {
                StudentMasterDTO.IsHostelResidency = value;
            }
        }
        public int RfidTagIDNo
        {
            get
            {
                return (StudentMasterDTO != null && StudentMasterDTO.RfidTagIDNo > 0) ? StudentMasterDTO.RfidTagIDNo : new int();
            }
            set
            {
                StudentMasterDTO.RfidTagIDNo = value;
            }
        }
        public int BranchID
        {
            get
            {
                return (StudentMasterDTO != null && StudentMasterDTO.BranchID > 0) ? StudentMasterDTO.BranchID : new int();
            }
            set
            {
                StudentMasterDTO.BranchID = value;
            }
        }
        public int FeeStructureID
        {
            get
            {
                return (StudentMasterDTO != null && StudentMasterDTO.FeeStructureID > 0) ? StudentMasterDTO.FeeStructureID : new int();
            }
            set
            {
                StudentMasterDTO.FeeStructureID = value;
            }
        }
        public int SectionDetailID
        {
            get
            {
                return (StudentMasterDTO != null && StudentMasterDTO.SectionDetailID > 0) ? StudentMasterDTO.SectionDetailID : new int();
            }
            set
            {
                StudentMasterDTO.SectionDetailID = value;
            }
        }
        public int OldSectionDetailID
        {
            get
            {
                return (StudentMasterDTO != null && StudentMasterDTO.OldSectionDetailID > 0) ? StudentMasterDTO.OldSectionDetailID : new int();
            }
            set
            {
                StudentMasterDTO.OldSectionDetailID = value;
            }
        }
        public int CourseYearId
        {
            get
            {
                return (StudentMasterDTO != null && StudentMasterDTO.CourseYearId > 0) ? StudentMasterDTO.CourseYearId : new int();
            }
            set
            {
                StudentMasterDTO.CourseYearId = value;
            }
        }

        public string CourseYearDescription
        {
            get
            {
                return (StudentMasterDTO != null) ? StudentMasterDTO.CourseYearDescription : string.Empty;
            }
            set
            {
                StudentMasterDTO.CourseYearDescription = value;
            }
        }
        public int CourseYearOldId
        {
            get
            {
                return (StudentMasterDTO != null && StudentMasterDTO.CourseYearOldId > 0) ? StudentMasterDTO.CourseYearOldId : new int();
            }
            set
            {
                StudentMasterDTO.CourseYearOldId = value;
            }
        }
        public bool StudentActiveFlag
        {
            get
            {
                return (StudentMasterDTO != null) ? StudentMasterDTO.StudentActiveFlag : false;
            }
            set
            {
                StudentMasterDTO.StudentActiveFlag = value;
            }
        }
        public string StudentStatus
        {
            get
            {
                return (StudentMasterDTO != null) ? StudentMasterDTO.StudentStatus : string.Empty;
            }
            set
            {
                StudentMasterDTO.StudentStatus = value;
            }
        }
        public string StatusCode
        {
            get
            {
                return (StudentMasterDTO != null) ? StudentMasterDTO.StatusCode : string.Empty;
            }
            set
            {
                StudentMasterDTO.StatusCode = value;
            }
        }
        public string StuAdmissionCode
        {
            get
            {
                return (StudentMasterDTO != null) ? StudentMasterDTO.StuAdmissionCode : string.Empty;
            }
            set
            {
                StudentMasterDTO.StuAdmissionCode = value;
            }
        }
        public string AcademicYear
        {
            get
            {
                return (StudentMasterDTO != null) ? StudentMasterDTO.AcademicYear : string.Empty;
            }
            set
            {
                StudentMasterDTO.AcademicYear = value;
            }
        }
        public string AdmitAcademicYear
        {
            get
            {
                return (StudentMasterDTO != null) ? StudentMasterDTO.AdmitAcademicYear : string.Empty;
            }
            set
            {
                StudentMasterDTO.AdmitAcademicYear = value;
            }
        }
        public string StuAdmissionType
        {
            get
            {
                return (StudentMasterDTO != null) ? StudentMasterDTO.StuAdmissionType : string.Empty;
            }
            set
            {
                StudentMasterDTO.StuAdmissionType = value;
            }
        }
        public string QulifyingExamType
        {
            get
            {
                return (StudentMasterDTO != null) ? StudentMasterDTO.QulifyingExamType : string.Empty;
            }
            set
            {
                StudentMasterDTO.QulifyingExamType = value;
            }
        }
        public string FirstAdmissionDatetime
        {
            get
            {
                return (StudentMasterDTO != null) ? StudentMasterDTO.FirstAdmissionDatetime : string.Empty;
            }
            set
            {
                StudentMasterDTO.FirstAdmissionDatetime = value;
            }
        }
        public string CentreCode
        {
            get
            {
                return (StudentMasterDTO != null) ? StudentMasterDTO.CentreCode : string.Empty;
            }
            set
            {
                StudentMasterDTO.CentreCode = value;
            }
        }
        public string CentreName
        {
            get
            {
                return (StudentMasterDTO != null) ? StudentMasterDTO.CentreName : string.Empty;
            }
            set
            {
                StudentMasterDTO.CentreName = value;
            }
        }
        public string AdmissionPattern
        {
            get
            {
                return (StudentMasterDTO != null) ? StudentMasterDTO.AdmissionPattern : string.Empty;
            }
            set
            {
                StudentMasterDTO.AdmissionPattern = value;
            }
        }
        public int TransferSectionID
        {
            get
            {
                return (StudentMasterDTO != null && StudentMasterDTO.TransferSectionID > 0) ? StudentMasterDTO.TransferSectionID : new int();
            }
            set
            {
                StudentMasterDTO.TransferSectionID = value;
            }
        }
        public int RegistrationID
        {
            get
            {
                return (StudentMasterDTO != null && StudentMasterDTO.RegistrationID > 0) ? StudentMasterDTO.RegistrationID : new int();
            }
            set
            {
                StudentMasterDTO.RegistrationID = value;
            }
        }
        public bool IsDomicleFromLast3Year
        {
            get
            {
                return (StudentMasterDTO != null) ? StudentMasterDTO.IsDomicleFromLast3Year : false;
            }
            set
            {
                StudentMasterDTO.IsDomicleFromLast3Year = value;
            }
        }
        public bool IsNriPoi
        {
            get
            {
                return (StudentMasterDTO != null) ? StudentMasterDTO.IsNriPoi : false;
            }
            set
            {
                StudentMasterDTO.IsNriPoi = value;
            }
        }
        public int TransferCoursesYearId
        {
            get
            {
                return (StudentMasterDTO != null && StudentMasterDTO.TransferCoursesYearId > 0) ? StudentMasterDTO.TransferCoursesYearId : new int();
            }
            set
            {
                StudentMasterDTO.TransferCoursesYearId = value;
            }
        }
        public string DirectSecYrAdmissionMode
        {
            get
            {
                return (StudentMasterDTO != null) ? StudentMasterDTO.DirectSecYrAdmissionMode : string.Empty;
            }
            set
            {
                StudentMasterDTO.DirectSecYrAdmissionMode = value;
            }
        }
        public string AdmittedInShift
        {
            get
            {
                return (StudentMasterDTO != null) ? StudentMasterDTO.AdmittedInShift : string.Empty;
            }
            set
            {
                StudentMasterDTO.AdmittedInShift = value;
            }
        }
        public string AllotAdmThrough
        {
            get
            {
                return (StudentMasterDTO != null) ? StudentMasterDTO.AllotAdmThrough : string.Empty;
            }
            set
            {
                StudentMasterDTO.AllotAdmThrough = value;
            }
        }
        public int BankAccountNumber
        {
            get
            {
                return (StudentMasterDTO != null && StudentMasterDTO.BankAccountNumber > 0) ? StudentMasterDTO.BankAccountNumber : new int();
            }
            set
            {
                StudentMasterDTO.BankAccountNumber = value;
            }
        }
        public string BankBranchName
        {
            get
            {
                return (StudentMasterDTO != null) ? StudentMasterDTO.BankBranchName : string.Empty;
            }
            set
            {
                StudentMasterDTO.BankBranchName = value;
            }
        }
        public string BankBranchCity
        {
            get
            {
                return (StudentMasterDTO != null) ? StudentMasterDTO.BankBranchCity : string.Empty;
            }
            set
            {
                StudentMasterDTO.BankBranchCity = value;
            }
        }
        public int UniqueIdentificatinNumber
        {
            get
            {
                return (StudentMasterDTO != null && StudentMasterDTO.UniqueIdentificatinNumber > 0) ? StudentMasterDTO.UniqueIdentificatinNumber : new int();
            }
            set
            {
                StudentMasterDTO.UniqueIdentificatinNumber = value;
            }
        }
        public string IdentificationType
        {
            get
            {
                return (StudentMasterDTO != null) ? StudentMasterDTO.IdentificationType : string.Empty;
            }
            set
            {
                StudentMasterDTO.IdentificationType = value;
            }
        }
        public bool IsActive
        {
            get
            {
                return (StudentMasterDTO != null) ? StudentMasterDTO.IsActive : false;
            }
            set
            {
                StudentMasterDTO.IsActive = value;
            }
        }
        public bool IsDeleted
        {
            get
            {
                return (StudentMasterDTO != null) ? StudentMasterDTO.IsDeleted : false;
            }
            set
            {
                StudentMasterDTO.IsDeleted = value;
            }
        }
        public int CreatedBy
        {
            get
            {
                return (StudentMasterDTO != null && StudentMasterDTO.CreatedBy > 0) ? StudentMasterDTO.CreatedBy : new int();
            }
            set
            {
                StudentMasterDTO.CreatedBy = value;
            }
        }
        public DateTime CreatedDate
        {
            get
            {
                return (StudentMasterDTO != null) ? StudentMasterDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                StudentMasterDTO.CreatedDate = value;
            }
        }
        public int? ModifiedBy
        {
            get
            {
                return (StudentMasterDTO != null && StudentMasterDTO.ModifiedBy > 0) ? StudentMasterDTO.ModifiedBy : new int();
            }
            set
            {
                StudentMasterDTO.ModifiedBy = value;
            }
        }
        public DateTime? ModifiedDate
        {
            get
            {
                return (StudentMasterDTO != null) ? StudentMasterDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                StudentMasterDTO.ModifiedDate = value;
            }
        }
        public int? DeletedBy
        {
            get
            {
                return (StudentMasterDTO != null && StudentMasterDTO.DeletedBy > 0) ? StudentMasterDTO.DeletedBy : new int();
            }
            set
            {
                StudentMasterDTO.DeletedBy = value;
            }
        }
        public DateTime? DeletedDate
        {
            get
            {
                return (StudentMasterDTO != null) ? StudentMasterDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                StudentMasterDTO.DeletedDate = value;
            }
        }
        public string StudentName
        {
            get
            {
                return (StudentMasterDTO != null) ? StudentMasterDTO.StudentName : string.Empty;
            }
            set
            {
                StudentMasterDTO.StudentName = value;
            }
        }
        public string searchType { get; set; }
        public string SelectedCentreCode
        {
            get;
            set;
        }
        public string SelectedCourseYearDetailsID
        {
            get;
            set;
        }
    }
}
