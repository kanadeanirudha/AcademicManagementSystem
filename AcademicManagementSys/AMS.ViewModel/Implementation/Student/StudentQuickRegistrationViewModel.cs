using AMS.Common;
using AMS.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using System.Web;
namespace AMS.ViewModel
{
    public class StudentQuickRegistrationViewModel : IStudentQuickRegistrationViewModel
    {

        public StudentQuickRegistrationViewModel()
        {
            StudentQuickRegistrationDTO = new StudentQuickRegistration();
            ListBranchRoleWise = new List<OrganisationBranchMaster>();
            ListOrganisationStudyCentreMaster = new List<OrganisationStudyCentreMaster>();
            ListOrganisationCentrewiseSession = new List<OrganisationCentrewiseSession>();
            ListOrganisationCentrewiseSessionForNewAdmission = new List<OrganisationCentrewiseSession>();
        }

        public StudentQuickRegistration StudentQuickRegistrationDTO
        {
            get;
            set;
        }
        public List<OrganisationStudyCentreMaster> ListOrganisationStudyCentreMaster
        {
            get;
            set;
        }
        public IEnumerable<SelectListItem> StudyCentreListMasterItems
        {
            get
            {
                return new SelectList(ListOrganisationStudyCentreMaster, "CentreCode", "CentreName");
            }
        }
        public List<OrganisationBranchMaster> ListBranchRoleWise
        {
            get;
            set;
        }
        public IEnumerable<SelectListItem> BranchListRoleWiseMasterItems
        {
            get
            {
                return new SelectList(ListBranchRoleWise, "ID", "BranchDescription");
            }
        }

        public List<OrganisationCentrewiseSession> ListOrganisationCentrewiseSession
        {
            get;
            set;
        }
        public List<OrganisationCentrewiseSession> ListOrganisationCentrewiseSessionForNewAdmission
        {
            get;
            set;
        }
        public IEnumerable<SelectListItem> SessionListMasterItems
        {
            get
            {
                return new SelectList(ListOrganisationCentrewiseSession, "ID", "SessionName");
            }
        }

        public IEnumerable<SelectListItem> SessionListMasterItemsForNewAdmission
        {
            get
            {
                return new SelectList(ListOrganisationCentrewiseSessionForNewAdmission, "ID", "SessionName");
            }
        }
        public int ID
        {
            get
            {
                return (StudentQuickRegistrationDTO != null && StudentQuickRegistrationDTO.ID > 0) ? StudentQuickRegistrationDTO.ID : new int();
            }
            set
            {
                StudentQuickRegistrationDTO.ID = value;
            }
        }

        [Display(Name = "DisplayName_StudentCode", ResourceType = typeof(AMS.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_StudentCodeRequired")]
        public string StudentCode
        {
            get
            {
                return (StudentQuickRegistrationDTO != null) ? StudentQuickRegistrationDTO.StudentCode : string.Empty;
            }
            set
            {
                StudentQuickRegistrationDTO.StudentCode = value;
            }
        }
        [Display(Name = "DisplayName_Title", ResourceType = typeof(AMS.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_TitleRequired")]
        public string Title
        {
            get
            {
                return (StudentQuickRegistrationDTO != null) ? StudentQuickRegistrationDTO.Title : string.Empty;
            }
            set
            {
                StudentQuickRegistrationDTO.Title = value;
            }
        }

        [Display(Name = "DisplayName_FirstName", ResourceType = typeof(AMS.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_FirstNameRequired")]
        public string FirstName
        {
            get
            {
                return (StudentQuickRegistrationDTO != null) ? StudentQuickRegistrationDTO.FirstName : string.Empty;
            }
            set
            {
                StudentQuickRegistrationDTO.FirstName = value;
            }
        }
         [Display(Name = "DisplayName_FullName", ResourceType = typeof(AMS.Common.Resources))]
        public string FullName
        {
            get
            {
                return (StudentQuickRegistrationDTO != null) ? StudentQuickRegistrationDTO.FullName : string.Empty;
            }
            set
            {
                StudentQuickRegistrationDTO.FullName = value;
            }
        }
         [Display(Name = "DisplayName_StudentQuickInformation", ResourceType = typeof(AMS.Common.Resources))]
        public string StudentQuickInformation
        {
            get
            {
                return (StudentQuickRegistrationDTO != null) ? StudentQuickRegistrationDTO.StudentQuickInformation : string.Empty;
            }
            set
            {
                StudentQuickRegistrationDTO.StudentQuickInformation = value;
            }
        }

        [Display(Name = "DisplayName_MiddleName", ResourceType = typeof(AMS.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_MiddleNameRequired")]
        public string MiddleName
        {
            get
            {
                return (StudentQuickRegistrationDTO != null) ? StudentQuickRegistrationDTO.MiddleName : string.Empty;
            }
            set
            {
                StudentQuickRegistrationDTO.MiddleName = value;
            }
        }

     //   [Required(ErrorMessage = "Last Name should not be blank")]
      [Display(Name = "DisplayName_LastName", ResourceType = typeof(AMS.Common.Resources))]
      [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_LastNameRequired")]
        public string LastName
        {
            get
            {
                return (StudentQuickRegistrationDTO != null) ? StudentQuickRegistrationDTO.LastName : string.Empty;
            }
            set
            {
                StudentQuickRegistrationDTO.LastName = value;
            }
        }
        [Display(Name = "DisplayName_MotherName", ResourceType = typeof(AMS.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_MotherNameRequired")]
        public string MotherName
        {
            get
            {
                return (StudentQuickRegistrationDTO != null) ? StudentQuickRegistrationDTO.MotherName : string.Empty;
            }
            set
            {
                StudentQuickRegistrationDTO.MotherName = value;
            }
        }

        [Required(ErrorMessage = "Gender should not be blank.")]
        [Display(Name = "Gender")]
        public string StudentGender
        {
            get
            {
                return (StudentQuickRegistrationDTO != null) ? StudentQuickRegistrationDTO.StudentGender : string.Empty;
            }
            set
            {
                StudentQuickRegistrationDTO.StudentGender = value;
            }
        }
        [Display(Name = "Address")]
        public string studentAddress
        {
            get
            {
                return (StudentQuickRegistrationDTO != null) ? StudentQuickRegistrationDTO.studentAddress : string.Empty;
            }
            set
            {
                StudentQuickRegistrationDTO.studentAddress = value;
            }
        }


        [Display(Name = "DisplayName_MobileNumber", ResourceType = typeof(AMS.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_MobileNumberRequired")]
        public string StudentMobileNumber
        {
            get
            {
                return (StudentQuickRegistrationDTO != null) ? StudentQuickRegistrationDTO.StudentMobileNumber : string.Empty;
            }
            set
            {
                StudentQuickRegistrationDTO.StudentMobileNumber = value;
            }
        }

        [Display(Name = "DisplayName_CourseName", ResourceType = typeof(AMS.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_CourseNameRequired")]
        public int BranchID
        {
            get
            {
                return (StudentQuickRegistrationDTO != null) ? StudentQuickRegistrationDTO.BranchID : new int();
            }
            set
            {
                StudentQuickRegistrationDTO.BranchID = value;
            }
        }

        [Display(Name = "DisplayName_University", ResourceType = typeof(AMS.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_UniversityNameRequired")]
        public int UniversityID
        {
            get
            {
                return (StudentQuickRegistrationDTO != null) ? StudentQuickRegistrationDTO.UniversityID : new int();
            }
            set
            {
                StudentQuickRegistrationDTO.UniversityID = value;
            }
        }
        [Display(Name = "DisplayName_AdmittedSectionDetails", ResourceType = typeof(AMS.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_AdmittedSectionDetailsRequired")]

        public int SectionDetailID
        {
            get
            {
                return (StudentQuickRegistrationDTO != null) ? StudentQuickRegistrationDTO.SectionDetailID : new int();
            }
            set
            {
                StudentQuickRegistrationDTO.SectionDetailID = value;
            }
        }
        public int CourseYearId
        {
            get
            {
                return (StudentQuickRegistrationDTO != null) ? StudentQuickRegistrationDTO.CourseYearId : new int();
            }
            set
            {
                StudentQuickRegistrationDTO.CourseYearId = value;
            }
        }
        public bool StudentActiveFlag
        {
            get
            {
                return (StudentQuickRegistrationDTO != null) ? StudentQuickRegistrationDTO.StudentActiveFlag : false;
            }
            set
            {
                StudentQuickRegistrationDTO.StudentActiveFlag = value;
            }
        }
        public bool StudentStatus
        {
            get
            {
                return (StudentQuickRegistrationDTO != null) ? StudentQuickRegistrationDTO.StudentStatus : false;
            }
            set
            {
                StudentQuickRegistrationDTO.StudentStatus = value;
            }
        }
        public string StatusCode
        {
            get
            {
                return (StudentQuickRegistrationDTO != null) ? StudentQuickRegistrationDTO.StatusCode : string.Empty;
            }
            set
            {
                StudentQuickRegistrationDTO.StatusCode = value;
            }
        }
        public string StuAdmissionCode
        {
            get
            {
                return (StudentQuickRegistrationDTO != null) ? StudentQuickRegistrationDTO.StuAdmissionCode : string.Empty;
            }
            set
            {
                StudentQuickRegistrationDTO.StuAdmissionCode = value;
            }
        }
        public string AcademicYear
        {
            get
            {
                return (StudentQuickRegistrationDTO != null) ? StudentQuickRegistrationDTO.AcademicYear : string.Empty;
            }
            set
            {
                StudentQuickRegistrationDTO.AcademicYear = value;
            }
        }

        public string AdmitAcademicYear
        {
            get
            {
                return (StudentQuickRegistrationDTO != null) ? StudentQuickRegistrationDTO.AdmitAcademicYear : string.Empty;
            }
            set
            {
                StudentQuickRegistrationDTO.AdmitAcademicYear = value;
            }
        }


        [Display(Name = "DisplayName_DateofBirth", ResourceType = typeof(AMS.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_DateofBirthRequired")]

       
        public string DateofBirth
        {
            get
            {
                return (StudentQuickRegistrationDTO != null) ? StudentQuickRegistrationDTO.DateofBirth : string.Empty;
            }
            set
            {
                StudentQuickRegistrationDTO.DateofBirth = value;
            }
        }
        [Display(Name = "DisplayName_FirstAdmittedSession", ResourceType = typeof(AMS.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_FirstAdmittedSessionRequired")]
        public string AdmittedSessionID
        {
            get
            {
                return (StudentQuickRegistrationDTO != null) ? StudentQuickRegistrationDTO.AdmittedSessionID : string.Empty;
            }
            set
            {
                StudentQuickRegistrationDTO.AdmittedSessionID = value;
            }
        }

        [Display(Name = "DisplayName_Session", ResourceType = typeof(AMS.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_SessionRequired")]
        public string AcademicSessionID
        {
            get
            {
                return (StudentQuickRegistrationDTO != null) ? StudentQuickRegistrationDTO.AcademicSessionID : string.Empty;
            }
            set
            {
                StudentQuickRegistrationDTO.AcademicSessionID = value;
            }
        }
        public DateTime FirstAdmissionDatetime
        {
            get
            {
                return (StudentQuickRegistrationDTO != null) ? StudentQuickRegistrationDTO.FirstAdmissionDatetime : DateTime.Now;
            }
            set
            {
                StudentQuickRegistrationDTO.FirstAdmissionDatetime = value;
            }
        }

        [Display(Name = "DisplayName_CentreCode", ResourceType = typeof(AMS.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_CentreCodeRequired")]
        public string CentreCode
        {
            get
            {
                return (StudentQuickRegistrationDTO != null) ? StudentQuickRegistrationDTO.CentreCode : string.Empty;
            }
            set
            {
                StudentQuickRegistrationDTO.CentreCode = value;
            }
        }
        [Display(Name = "DisplayName_AdmissionPattern", ResourceType = typeof(AMS.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_AdmissionPatternRequired")]
        public string AdmissionPattern
        {
            get
            {
                return (StudentQuickRegistrationDTO != null) ? StudentQuickRegistrationDTO.AdmissionPattern : string.Empty;
            }
            set
            {
                StudentQuickRegistrationDTO.AdmissionPattern = value;
            }
        }
        public int TransferSectionID
        {
            get
            {
                return (StudentQuickRegistrationDTO != null) ? StudentQuickRegistrationDTO.TransferSectionID : new int();
            }
            set
            {
                StudentQuickRegistrationDTO.TransferSectionID = value;
            }
        }
        public string DirectSecYrAdmissionMode
        {
            get
            {
                return (StudentQuickRegistrationDTO != null) ? StudentQuickRegistrationDTO.DirectSecYrAdmissionMode : string.Empty;
            }
            set
            {
                StudentQuickRegistrationDTO.DirectSecYrAdmissionMode = value;
            }
        }

        [Display(Name = "DisplayName_EmailId", ResourceType = typeof(AMS.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_StudentEmailIDRequired")]
        [RegularExpression("^([a-zA-Z0-9_\\-\\.]+)@[a-z0-9-]+(\\.[a-z0-9-]+)*(\\.[a-z]{2,3})$", ErrorMessage = "Please enter your email address in the format someone@example.com.")]
        public string StudentEmailID
        {
            get
            {
                return (StudentQuickRegistrationDTO != null) ? StudentQuickRegistrationDTO.StudentEmailID : string.Empty;
            }
            set
            {
                StudentQuickRegistrationDTO.StudentEmailID = value;
            }
        }
        public bool IsActive
        {
            get
            {
                return (StudentQuickRegistrationDTO != null) ? StudentQuickRegistrationDTO.IsDeleted : false;
            }
            set
            {
                StudentQuickRegistrationDTO.IsDeleted = value;
            }
        }
        [Display(Name = "Is Back Student")]
        public bool IsBackStudent
        {
            get
            {
                return (StudentQuickRegistrationDTO != null) ? StudentQuickRegistrationDTO.IsBackStudent : false;
            }
            set
            {
                StudentQuickRegistrationDTO.IsBackStudent = value;
            }
        }
        [Display(Name = "IsDeleted")]
        public bool IsDeleted
        {
            get
            {
                return (StudentQuickRegistrationDTO != null) ? StudentQuickRegistrationDTO.IsDeleted : false;
            }
            set
            {
                StudentQuickRegistrationDTO.IsDeleted = value;
            }
        }

        [Display(Name = "CreatedBy")]
        public int CreatedBy
        {
            get
            {
                return (StudentQuickRegistrationDTO != null && StudentQuickRegistrationDTO.CreatedBy > 0) ? StudentQuickRegistrationDTO.CreatedBy : new int();
            }
            set
            {
                StudentQuickRegistrationDTO.CreatedBy = value;
            }
        }

        [Display(Name = "CreatedDate")]
        public DateTime CreatedDate
        {
            get
            {
                return (StudentQuickRegistrationDTO != null) ? StudentQuickRegistrationDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                StudentQuickRegistrationDTO.CreatedDate = value;
            }
        }

        [Display(Name = "ModifiedBy")]
        public int? ModifiedBy
        {
            get
            {
                return (StudentQuickRegistrationDTO != null && StudentQuickRegistrationDTO.ModifiedBy.HasValue) ? StudentQuickRegistrationDTO.ModifiedBy : new int();
            }
            set
            {
                StudentQuickRegistrationDTO.ModifiedBy = value;
            }
        }

        [Display(Name = "ModifiedDate")]
        public DateTime? ModifiedDate
        {
            get
            {
                return (StudentQuickRegistrationDTO != null && StudentQuickRegistrationDTO.ModifiedDate.HasValue) ? StudentQuickRegistrationDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                StudentQuickRegistrationDTO.ModifiedDate = value;
            }
        }

        [Display(Name = "DeletedBy")]
        public int? DeletedBy
        {
            get
            {
                return (StudentQuickRegistrationDTO != null && StudentQuickRegistrationDTO.DeletedBy.HasValue) ? StudentQuickRegistrationDTO.DeletedBy : new int();
            }
            set
            {
                StudentQuickRegistrationDTO.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime? DeletedDate
        {
            get
            {
                return (StudentQuickRegistrationDTO != null && StudentQuickRegistrationDTO.DeletedDate.HasValue) ? StudentQuickRegistrationDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                StudentQuickRegistrationDTO.DeletedDate = value;
            }
        }

        public string errorMessage { get; set; }



    }
}

