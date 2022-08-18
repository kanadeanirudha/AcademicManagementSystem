using AMS.Common;
using AMS.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;


namespace AMS.ViewModel
{
   
    public class StudentSelfRegistrationViewModel 
    {
        public StudentSelfRegistrationViewModel()
        {
            StudentSelfRegistrationDTO = new StudentSelfRegistration();
        }

        public StudentSelfRegistration StudentSelfRegistrationDTO { get; set; }
        public List<StudentSelfRegistration> ListOrgStudyCentreMaster
        {
            get;
            set;
        }
        public List<OrganisationUniversityMaster> ListOrganisationUniversityMaster
        {
            get;
            set;
        }
        public IEnumerable<SelectListItem> ListOrgStudyCentreMasterItems
        {
            get
            {
                return new SelectList(ListOrgStudyCentreMaster, "CentreCode", "CentreName");
            }
        }

        public IEnumerable<SelectListItem> ListOrganisationUnivesitytMasterItems
        {
            get
            {

                return new SelectList(ListOrganisationUniversityMaster, "UniversityID", "UniversityName");
            }

        }
        public int ID
        {
            get
            {
                return (StudentSelfRegistrationDTO != null && StudentSelfRegistrationDTO.ID > 0) ? StudentSelfRegistrationDTO.ID : new int();
            }
            set
            {
                StudentSelfRegistrationDTO.ID = value;
            }
        }

        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "ValidationMessage_EmailIDRequired")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "DisplayName_EmailId", ResourceType = typeof(Resources))]
        [RegularExpression("^([a-zA-Z0-9_\\-\\.]+)@[a-z0-9-]+(\\.[a-z0-9-]+)*(\\.[a-z]{2,3})$", ErrorMessage = "Please enter your email address in the format someone@example.com.")]
        public string EmailID
        {
            get
            {
                return (StudentSelfRegistrationDTO != null) ? StudentSelfRegistrationDTO.EmailID : string.Empty;
            }
            set
            {
                StudentSelfRegistrationDTO.EmailID = value;
            }
        }

        [Display(Name = "DisplayName_Password", ResourceType = typeof(Resources))]
        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "ValidationMessage_PasswordRequired")]
        public string Password
        {
            get
            {
                return (StudentSelfRegistrationDTO != null) ? StudentSelfRegistrationDTO.Password : string.Empty;
            }
            set
            {
                StudentSelfRegistrationDTO.Password = value;
            }
        }

        //   [Required(ErrorMessage = "OtherRegion is required")]
        [Display(Name = "OtherRegion")]
        public string RegionName
        {
            get
            {
                return (StudentSelfRegistrationDTO != null) ? StudentSelfRegistrationDTO.OtherRegion : string.Empty;
            }
            set
            {
                StudentSelfRegistrationDTO.OtherRegion = value;
            }
        }


        [Display(Name = "DisplayName_Title", ResourceType = typeof(Resources))]
        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "ValidationMessage_TitleRequired")]
        public string Title
        {
            get
            {
                return (StudentSelfRegistrationDTO != null) ? StudentSelfRegistrationDTO.Title : string.Empty;
            }
            set
            {
                StudentSelfRegistrationDTO.Title = value;
            }
        }
        [Display(Name = "Name")]
        public string Name
        {
            get
            {
                return (StudentSelfRegistrationDTO != null) ? StudentSelfRegistrationDTO.Name : string.Empty;
            }
            set
            {
                StudentSelfRegistrationDTO.Name = value;
            }
        }

        [Display(Name = "DisplayName_FirstName", ResourceType = typeof(Resources))]
        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "ValidationMessage_FirstNameRequired")]
        public string FirstName
        {
            get
            {
                return (StudentSelfRegistrationDTO != null) ? StudentSelfRegistrationDTO.FirstName : string.Empty;
            }
            set
            {
                StudentSelfRegistrationDTO.FirstName = value;
            }
        }

        [Display(Name = "DisplayName_MiddleName", ResourceType = typeof(Resources))]
       // [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "ValidationMessage_MiddleNameRequired")]
        public string MiddleName
        {
            get
            {
                return (StudentSelfRegistrationDTO != null) ? StudentSelfRegistrationDTO.MiddleName : string.Empty;
            }
            set
            {
                StudentSelfRegistrationDTO.MiddleName = value;
            }
        }

        [Display(Name = "DisplayName_LastName", ResourceType = typeof(Resources))]
        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "ValidationMessage_LastNameRequired")]
        public string LastName
        {
            get
            {
                return (StudentSelfRegistrationDTO != null) ? StudentSelfRegistrationDTO.LastName : string.Empty;
            }
            set
            {
                StudentSelfRegistrationDTO.LastName = value;
            }
        }

        [Display(Name = "DisplayName_ContactNumber", ResourceType = typeof(Resources))]
        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "ValidationMessage_ContactNumberRequired")]
        public string ContactNumber
        {
            get
            {
                return (StudentSelfRegistrationDTO != null) ? StudentSelfRegistrationDTO.ContactNumber : string.Empty;
            }
            set
            {
                StudentSelfRegistrationDTO.ContactNumber = value;
            }
        }

        [Display(Name = "DisplayName_GenderCode", ResourceType = typeof(Resources))]
        public string Gender
        {
            get
            {
                return (StudentSelfRegistrationDTO != null) ? StudentSelfRegistrationDTO.Gender : string.Empty;
            }
            set
            {
                StudentSelfRegistrationDTO.Gender = value;
            }
        }

        [Display(Name = "DisplayName_DateofBirth", ResourceType = typeof(Resources))]
        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "ValidationMessage_DateofBirthRequired")]
        public string DateOfBirth
        {
            get
            {
                return (StudentSelfRegistrationDTO != null) ? StudentSelfRegistrationDTO.DateOfBirth : string.Empty;
            }
            set
            {
                StudentSelfRegistrationDTO.DateOfBirth = value;
            }
        }

        [Display(Name = "DisplayName_CentreName", ResourceType = typeof(Resources))]
        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "ValidationMessage_CentreCodeRequired")]
        public string CenterCode
        {
            get
            {
                return (StudentSelfRegistrationDTO != null) ? StudentSelfRegistrationDTO.CenterCode : string.Empty;
            }
            set
            {
                StudentSelfRegistrationDTO.CenterCode = value;
            }
        }

        //   [Required(ErrorMessage = "Region Name is required")]
        //[Display(Name = "CenterCode")]
        public string OtherRegion
        {
            get
            {
                return (StudentSelfRegistrationDTO != null) ? StudentSelfRegistrationDTO.OtherRegion : string.Empty;
            }
            set
            {
                StudentSelfRegistrationDTO.OtherRegion = value;
            }
        }
        public bool IsActive
        {
            get
            {
                return (StudentSelfRegistrationDTO != null) ? StudentSelfRegistrationDTO.IsActive : false;
            }
            set
            {
                StudentSelfRegistrationDTO.IsActive = value;
            }
        }

        public string WebRegistrationStatus
        {
            get
            {
                return (StudentSelfRegistrationDTO != null) ? StudentSelfRegistrationDTO.WebRegistrationStatus : string.Empty;
            }
            set
            {
                StudentSelfRegistrationDTO.WebRegistrationStatus = value;
            }
        }

        public string WebAdminComments
        {
            get
            {
                return (StudentSelfRegistrationDTO != null) ? StudentSelfRegistrationDTO.WebAdminComments : string.Empty;
            }
            set
            {
                StudentSelfRegistrationDTO.WebAdminComments = value;
            }
        }

        public DateTime ApprovalDate
        {
            get
            {
                return (StudentSelfRegistrationDTO != null) ? StudentSelfRegistrationDTO.ApprovalDate : new DateTime();
            }
            set
            {
                StudentSelfRegistrationDTO.ApprovalDate = value;
            }
        }
        public int AdminApprovedBy
        {
            get
            {
                return (StudentSelfRegistrationDTO != null) ? StudentSelfRegistrationDTO.AdminApprovedBy : new int();
            }
            set
            {
                StudentSelfRegistrationDTO.AdminApprovedBy = value;
            }
        }

        public int StudentID
        {
            get
            {
                return (StudentSelfRegistrationDTO != null) ? StudentSelfRegistrationDTO.StudentID : new int();
            }
            set
            {
                StudentSelfRegistrationDTO.StudentID = value;
            }
        }

        //   [Required(ErrorMessage = "CountryID is required")]
        public int CountryID
        {
            get
            {
                return (StudentSelfRegistrationDTO != null) ? StudentSelfRegistrationDTO.CountryID : new int();
            }
            set
            {
                StudentSelfRegistrationDTO.CountryID = value;
            }
        }


        // [Required(ErrorMessage = "CasteID is required")]
        public int CasteID
        {
            get
            {
                return (StudentSelfRegistrationDTO != null) ? StudentSelfRegistrationDTO.CasteID : new int();
            }
            set
            {
                StudentSelfRegistrationDTO.CasteID = value;
            }
        }



        //  [Required(ErrorMessage = "CategoryID is required")]
        public int CategoryID
        {
            get
            {
                return (StudentSelfRegistrationDTO != null) ? StudentSelfRegistrationDTO.CategoryID : new int();
            }
            set
            {
                StudentSelfRegistrationDTO.CategoryID = value;
            }
        }


        //   [Required(ErrorMessage = "RegionID is required")]
        public int RegionID
        {
            get
            {
                return (StudentSelfRegistrationDTO != null) ? StudentSelfRegistrationDTO.RegionID : new int();
            }
            set
            {
                StudentSelfRegistrationDTO.RegionID = value;
            }
        }

        [Display(Name = "DisplayName_UniversityID", ResourceType = typeof(Resources))]
        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "ValidationMessage_UniversityIDRequired")]
        public int UniversityID
        {
            get
            {
                return (StudentSelfRegistrationDTO != null) ? StudentSelfRegistrationDTO.UniversityID : new int();
            }
            set
            {
                StudentSelfRegistrationDTO.UniversityID = value;
            }
        }
        public string StudentCode
        {
            get
            {
                return (StudentSelfRegistrationDTO != null) ? StudentSelfRegistrationDTO.StudentCode : string.Empty;
            }
            set
            {
                StudentSelfRegistrationDTO.StudentCode = value;
            }
        }
        public int ApprovStudSecEmployeeID
        {
            get
            {
                return (StudentSelfRegistrationDTO != null) ? StudentSelfRegistrationDTO.ApprovStudSecEmployeeID : new int();
            }
            set
            {
                StudentSelfRegistrationDTO.ApprovStudSecEmployeeID = value;
            }
        }
        public int ApprovAcctSecEmployeeID
        {
            get
            {
                return (StudentSelfRegistrationDTO != null) ? StudentSelfRegistrationDTO.ApprovAcctSecEmployeeID : new int();
            }
            set
            {
                StudentSelfRegistrationDTO.ApprovAcctSecEmployeeID = value;
            }
        }

        [Display(Name = "DisplayName_BranchDetailID", ResourceType = typeof(Resources))]
        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "ValidationMessage_BranchDetailIDRequired")]
        public int BranchDetailID
        {
            get
            {
                return (StudentSelfRegistrationDTO != null) ? StudentSelfRegistrationDTO.BranchDetailID : new int();
            }
            set
            {
                StudentSelfRegistrationDTO.BranchDetailID = value;
            }
        }

        [Display(Name = "Standard")]
        public int StandardNumber
        {
            get
            {
                return (StudentSelfRegistrationDTO != null) ? StudentSelfRegistrationDTO.StandardNumber : new int();
            }
            set
            {
                StudentSelfRegistrationDTO.StandardNumber = value;
            }
        }
        [Display(Name = "DisplayName_AdmissionPattern", ResourceType = typeof(Resources))]
        public int AdmissionPattern
        {
            get
            {
                return (StudentSelfRegistrationDTO != null) ? StudentSelfRegistrationDTO.AdmissionPattern : new int();
            }
            set
            {
                StudentSelfRegistrationDTO.AdmissionPattern = value;
            }
        }

        //[Display(Name = "IsDeleted")]
        public bool IsDeleted
        {
            get
            {
                return (StudentSelfRegistrationDTO != null) ? StudentSelfRegistrationDTO.IsDeleted : false;
            }
            set
            {
                StudentSelfRegistrationDTO.IsDeleted = value;
            }
        }

        //[Display(Name = "CreatedBy")]
        public int CreatedBy
        {
            get
            {
                return (StudentSelfRegistrationDTO != null && StudentSelfRegistrationDTO.CreatedBy > 0) ? StudentSelfRegistrationDTO.CreatedBy : new int();
            }
            set
            {
                StudentSelfRegistrationDTO.CreatedBy = value;
            }
        }

        //[Display(Name = "CreatedDate")]
        public DateTime CreatedDate
        {
            get
            {
                return (StudentSelfRegistrationDTO != null) ? StudentSelfRegistrationDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                StudentSelfRegistrationDTO.CreatedDate = value;
            }
        }

        //[Display(Name = "ModifiedBy")]
        public int? ModifiedBy
        {
            get
            {
                return (StudentSelfRegistrationDTO != null && StudentSelfRegistrationDTO.ModifiedBy.HasValue) ? StudentSelfRegistrationDTO.ModifiedBy : new int();
            }
            set
            {
                StudentSelfRegistrationDTO.ModifiedBy = value;
            }
        }

        //[Display(Name = "ModifiedDate")]
        public DateTime? ModifiedDate
        {
            get
            {
                return (StudentSelfRegistrationDTO != null && StudentSelfRegistrationDTO.ModifiedDate.HasValue) ? StudentSelfRegistrationDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                StudentSelfRegistrationDTO.ModifiedDate = value;
            }
        }

        //[Display(Name = "DeletedBy")]
        public int? DeletedBy
        {
            get
            {
                return (StudentSelfRegistrationDTO != null && StudentSelfRegistrationDTO.DeletedBy.HasValue) ? StudentSelfRegistrationDTO.DeletedBy : new int();
            }
            set
            {
                StudentSelfRegistrationDTO.DeletedBy = value;
            }
        }

        //[Display(Name = "DeletedDate")]
        public DateTime? DeletedDate
        {
            get
            {
                return (StudentSelfRegistrationDTO != null && StudentSelfRegistrationDTO.DeletedDate.HasValue) ? StudentSelfRegistrationDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                StudentSelfRegistrationDTO.DeletedDate = value;
            }
        }
        //public List<OrganisationUniversityMaster> ListOrganisationUniversityMaster
        //{
        //    get;
        //    set;
        //}
        //public IEnumerable<SelectListItem> ListOrganisationUnivesitytMasterItems
        //{
        //    get
        //    {

        //        return new SelectList(ListOrganisationUniversityMaster, "UniversityID", "UniversityName");
        //    }

        //}

    }
}
