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
    public class StudentIdentityCardViewModel : IStudentIdentityCardViewModel
    {

        public StudentIdentityCardViewModel()
        {
            StudentIdentityCardDTO = new StudentIdentityCard();
            ListOrganisationStudyCentreMaster = new List<OrganisationStudyCentreMaster>();
            ListOrganisationUniversityMaster = new List<OrganisationUniversityMaster>();
            ListOrganisationBranchMaster = new List<OrganisationBranchMaster>();
            ListOrganisationSectionDetails = new List<OrganisationSectionDetails>();
            ListOrganisationCentrewiseSessionDetails = new List<OrganisationCentrewiseSession>();
         
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
        public List<OrganisationUniversityMaster> ListOrganisationUniversityMaster
        {
            get;
            set;
        }
        public IEnumerable<SelectListItem> UniversityListMasterItems
        {
            get
            {
                return new SelectList(ListOrganisationUniversityMaster, "ID", "UniversityName");
            }
        }
        public List<OrganisationBranchMaster> ListOrganisationBranchMaster
        {
            get;
            set;
        }
        public IEnumerable<SelectListItem> BranchListMasterItems
        {
            get
            {
                return new SelectList(ListOrganisationBranchMaster, "ID", "BranchDescription");
            }
        }
        public List<OrganisationSectionDetails> ListOrganisationSectionDetails
        {
            get;
            set;
        }
        public IEnumerable<SelectListItem> SectionDetailsListMasterItems
        {
            get
            {
                return new SelectList(ListOrganisationSectionDetails, "ID", "Descriptions");
            }
        }
        public List<OrganisationCentrewiseSession> ListOrganisationCentrewiseSessionDetails
        {
            get;
            set;
        }
        public IEnumerable<SelectListItem> SessionDetailsListMasterItems
        {
            get
            { 
                return new SelectList(ListOrganisationCentrewiseSessionDetails, "SessionID", "SessionName");
            }
        }
        public string SelectedCentreCode
        {
            get;
            set;
        }
        public string SelectedUniversityID
        {
            get;
            set;
        }
        public string SelectedBranchID
        {
            get;
            set;
        }
        public string SelectedSectionDetailID
        {
            get;
            set;
        }
        public string SelectedAcademicYear
        {
            get;
            set;
        }
        public StudentIdentityCard StudentIdentityCardDTO
        {
            get;
            set;
        }
      
    
        public int ID
        {
            get
            {
                return (StudentIdentityCardDTO != null && StudentIdentityCardDTO.ID > 0) ? StudentIdentityCardDTO.ID : new int();
            }
            set
            {
                StudentIdentityCardDTO.ID = value;
            }
        }
        public int StudentId
        {
            get
            {
                return (StudentIdentityCardDTO != null) ? StudentIdentityCardDTO.StudentId : new int();
            }
            set
            {
                StudentIdentityCardDTO.StudentId = value;
            }
        }
        public string StudentTitle
        {
            get
            {
                return (StudentIdentityCardDTO != null) ? StudentIdentityCardDTO.StudentTitle : string.Empty;
            }
            set
            {
                StudentIdentityCardDTO.StudentTitle = value;
            }
        }

        [Display(Name = "FirstName")]
        public string StudentFirstName
        {
            get
            {
                return (StudentIdentityCardDTO != null) ? StudentIdentityCardDTO.StudentFirstName : string.Empty;
            }
            set
            {
                StudentIdentityCardDTO.StudentFirstName = value;
            }
        }

        [Display(Name = "MiddleName")]
        public string StudentMiddleName
        {
            get
            {
                return (StudentIdentityCardDTO != null) ? StudentIdentityCardDTO.StudentMiddleName : string.Empty;
            }
            set
            {
                StudentIdentityCardDTO.StudentMiddleName = value;
            }
        }

        public string StudentLastName
        {
            get
            {
                return (StudentIdentityCardDTO != null) ? StudentIdentityCardDTO.StudentLastName : string.Empty;
            }
            set
            {
                StudentIdentityCardDTO.StudentLastName = value;
            }
        }


        [Display(Name = "DisplayName_StudentCode", ResourceType = typeof(Resources))]
        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "ValidationMessage_StudentCodeRequired")]
        public string StudentCode
        {
            get
            {
                return (StudentIdentityCardDTO != null) ? StudentIdentityCardDTO.StudentCode : string.Empty;
            }
            set
            {
                StudentIdentityCardDTO.StudentCode = value;
            }
        }

        public string StudentFullName
        {
            get
            {
                return (StudentIdentityCardDTO != null) ? StudentIdentityCardDTO.StudentFullName : string.Empty;
            }
            set
            {
                StudentIdentityCardDTO.StudentFullName = value;
            }
        }

        [Display(Name = "DisplayName_StudentMobileNumber", ResourceType = typeof(Resources))]
        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "ValidationMessage_StudentMobileNumberRequired")]
        public string StudentMobileNumber
        {
            get
            {
                return (StudentIdentityCardDTO != null) ? StudentIdentityCardDTO.StudentMobileNumber : string.Empty;
            }
            set
            {
                StudentIdentityCardDTO.StudentMobileNumber = value;
            }
        }

        [Display(Name = "DisplayName_ParentMobileNumber", ResourceType = typeof(Resources))]
        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "ValidationMessage_ParentMobileNumberRequired")]
        public string ParentMobileNumber
        {
            get
            {
                return (StudentIdentityCardDTO != null) ? StudentIdentityCardDTO.ParentMobileNumber : string.Empty;
            }
            set
            {
                StudentIdentityCardDTO.ParentMobileNumber = value;
            }
        }
        [Display(Name = "Identification Mark")]
       // [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "ValidationMessage_ParentMobileNumberRequired")]
        public string StudentIdentificationMark
        {
            get
            {
                return (StudentIdentityCardDTO != null) ? StudentIdentityCardDTO.StudentIdentificationMark : string.Empty;
            }
            set
            {
                StudentIdentityCardDTO.StudentIdentificationMark = value;
            }
        }
        
        public string RollNumber
        {
            get
            {
                return (StudentIdentityCardDTO != null) ? StudentIdentityCardDTO.RollNumber : string.Empty;
            }
            set
            {
                StudentIdentityCardDTO.RollNumber = value;
            }
        }

        [Required(ErrorMessage = "Branch must be setected")]
        [Display(Name = "Course Name")]
        public int BranchID
        {
            get
            {
                return (StudentIdentityCardDTO != null) ? StudentIdentityCardDTO.BranchID : new int();
            }
            set
            {
                StudentIdentityCardDTO.BranchID = value;
            }
        }

        [Required(ErrorMessage = "University must be setected")]
        [Display(Name = "University Name")]
        public int UniversityID
        {
            get
            {
                return (StudentIdentityCardDTO != null) ? StudentIdentityCardDTO.UniversityID : new int();
            }
            set
            {
                StudentIdentityCardDTO.UniversityID = value;
            }
        }
        [Required(ErrorMessage = "Section must be setected")]
        [Display(Name = "Admitted Section Details")]
        public int SectionDetailID
        {
            get
            {
                return (StudentIdentityCardDTO != null) ? StudentIdentityCardDTO.SectionDetailID : new int();
            }
            set
            {
                StudentIdentityCardDTO.SectionDetailID = value;
            }
        }
        public string AcademicYear
        {
            get
            {
                return (StudentIdentityCardDTO != null) ? StudentIdentityCardDTO.AcademicYear : string.Empty;
            }
            set
            {
                StudentIdentityCardDTO.AcademicYear = value;
            }
        }
        [Required(ErrorMessage = "Centre Name must be setected")]
        [Display(Name = "Centre Name")]
        public string CentreCode
        {
            get
            {
                return (StudentIdentityCardDTO != null) ? StudentIdentityCardDTO.CentreCode : string.Empty;
            }
            set
            {
                StudentIdentityCardDTO.CentreCode = value;
            }
        }

        [Display(Name = "DisplayName_UniqueIdentificatinNumber", ResourceType = typeof(Resources))]
        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "ValidationMessage_UniqueIdentificatinNumberRequired")]
        public string UniqueIdentificatinNumber
        {
            get
            {
                return (StudentIdentityCardDTO != null) ? StudentIdentityCardDTO.UniqueIdentificatinNumber : string.Empty;
            }
            set
            {
                StudentIdentityCardDTO.UniqueIdentificatinNumber = value;
            }
        }
        public string AddressType
        {
            get
            {
                return (StudentIdentityCardDTO != null) ? StudentIdentityCardDTO.AddressType : string.Empty;
            }
            set
            {
                StudentIdentityCardDTO.AddressType = value;
            }
        }

        [Display(Name = "DisplayName_PermanentAddressLine1", ResourceType = typeof(Resources))]
        //[Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "ValidationMessage_PermanentAddressLine1Required")]
        public string PermanentAddressLine1
        {
            get
            {
                return (StudentIdentityCardDTO != null) ? StudentIdentityCardDTO.PermanentAddressLine1 : string.Empty;
            }
            set
            {
                StudentIdentityCardDTO.PermanentAddressLine1 = value;
            }
        }

        [Display(Name = "DisplayName_PermanentAddressLine2", ResourceType = typeof(Resources))]
        //[Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "ValidationMessage_PermanentAddressLine2Required")]
        public string PermanentAddressLine2
        {
            get
            {
                return (StudentIdentityCardDTO != null) ? StudentIdentityCardDTO.PermanentAddressLine2 : string.Empty;
            }
            set
            {
                StudentIdentityCardDTO.PermanentAddressLine2 = value;
            }
        }


        [Display(Name = "DisplayName_CorrespondenceAddressLine1", ResourceType = typeof(Resources))]
        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "ValidationMessage_CorrespondenceAddressLine1Required")]
        public string CorrespondenceAddressLine1
        {
            get
            {
                return (StudentIdentityCardDTO != null) ? StudentIdentityCardDTO.CorrespondenceAddressLine1 : string.Empty;
            }
            set
            {
                StudentIdentityCardDTO.CorrespondenceAddressLine1 = value;
            }
        }

        [Display(Name = "DisplayName_CorrespondenceAddressLine2", ResourceType = typeof(Resources))]
        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "ValidationMessage_CorrespondenceAddressLine2Required")]
        public string CorrespondenceAddressLine2
        {
            get
            {
                return (StudentIdentityCardDTO != null) ? StudentIdentityCardDTO.CorrespondenceAddressLine2 : string.Empty;
            }
            set
            {
                StudentIdentityCardDTO.CorrespondenceAddressLine2 = value;
            }
        }
        public string PlotNumber
        {
            get
            {
                return (StudentIdentityCardDTO != null) ? StudentIdentityCardDTO.PlotNumber : string.Empty;
            }
            set
            {
                StudentIdentityCardDTO.PlotNumber = value;
            }
        }
        public string Street
        {
            get
            {
                return (StudentIdentityCardDTO != null) ? StudentIdentityCardDTO.Street : string.Empty;
            }
            set
            {
                StudentIdentityCardDTO.Street = value;
            }
        }
        //[Required(ErrorMessage = "Date of Birth should not be blank")]
        [Display(Name = "DisplayName_DateofBirth", ResourceType = typeof(Resources))]
        //[Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "ValidationMessage_DateOfBirthRequired")]
        public string DateOfBirth
        {
            get
            {
                return (StudentIdentityCardDTO != null) ? StudentIdentityCardDTO.DateOfBirth : string.Empty;
            }
            set
            {
                StudentIdentityCardDTO.DateOfBirth = value;
            }
        }
        public string Bloodgroup
        {
            get
            {
                return (StudentIdentityCardDTO != null) ? StudentIdentityCardDTO.Bloodgroup : string.Empty;
            }
            set
            {
                StudentIdentityCardDTO.Bloodgroup = value;
            }
        }
        

        [Display(Name = "IsDeleted")]
        public bool IsDeleted
        {
            get
            {
                return (StudentIdentityCardDTO != null) ? StudentIdentityCardDTO.IsDeleted : false;
            }
            set
            {
                StudentIdentityCardDTO.IsDeleted = value;
            }
        }

        [Display(Name = "CreatedBy")]
        public int CreatedBy
        {
            get
            {
                return (StudentIdentityCardDTO != null && StudentIdentityCardDTO.CreatedBy > 0) ? StudentIdentityCardDTO.CreatedBy : new int();
            }
            set
            {
                StudentIdentityCardDTO.CreatedBy = value;
            }
        }

        [Display(Name = "CreatedDate")]
        public DateTime CreatedDate
        {
            get
            {
                return (StudentIdentityCardDTO != null) ? StudentIdentityCardDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                StudentIdentityCardDTO.CreatedDate = value;
            }
        }

        [Display(Name = "ModifiedBy")]
        public int? ModifiedBy
        {
            get
            {
                return (StudentIdentityCardDTO != null && StudentIdentityCardDTO.ModifiedBy.HasValue) ? StudentIdentityCardDTO.ModifiedBy : new int();
            }
            set
            {
                StudentIdentityCardDTO.ModifiedBy = value;
            }
        }

        [Display(Name = "ModifiedDate")]
        public DateTime? ModifiedDate
        {
            get
            {
                return (StudentIdentityCardDTO != null && StudentIdentityCardDTO.ModifiedDate.HasValue) ? StudentIdentityCardDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                StudentIdentityCardDTO.ModifiedDate = value;
            }
        }

        [Display(Name = "DeletedBy")]
        public int? DeletedBy
        {
            get
            {
                return (StudentIdentityCardDTO != null && StudentIdentityCardDTO.DeletedBy.HasValue) ? StudentIdentityCardDTO.DeletedBy : new int();
            }
            set
            {
                StudentIdentityCardDTO.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime? DeletedDate
        {
            get
            {
                return (StudentIdentityCardDTO != null && StudentIdentityCardDTO.DeletedDate.HasValue) ? StudentIdentityCardDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                StudentIdentityCardDTO.DeletedDate = value;
            }
        }

        public string errorMessage { get; set; }


        #region File Upload

        [Display(Name = "Internet URL")]
        public string Url { get; set; }

        public bool IsUrl { get; set; }

        [Display(Name = "Flickr image")]
        public string Flickr { get; set; }

        public bool IsFlickr { get; set; }

        //[Display(Name = "Local file")]
        //[Required(ErrorMessage = "Please select the photo")]
        public HttpPostedFileBase StudentPhotoFile { get; set; }
        public HttpPostedFileBase StudentSignatureFile { get; set; }
        //  public HttpPostedFileBase StudentThumbFile { get; set; }


        public bool IsFile { get; set; }

        [Range(0, int.MaxValue)]
        public int X { get; set; }

        [Range(0, int.MaxValue)]
        public int Y { get; set; }

        [Range(1, int.MaxValue)]
        public int Width { get; set; }

        [Range(1, int.MaxValue)]
        public int Height { get; set; }

        public byte[] StudentPhoto
        {
            get
            {
                return (StudentIdentityCardDTO != null) ? StudentIdentityCardDTO.StudentPhoto : new byte[1];         //review this       
            }
            set
            {
                StudentIdentityCardDTO.StudentPhoto = value;
            }
        }


        public string StudentPhotoType
        {
            get
            {
                return (StudentIdentityCardDTO != null) ? StudentIdentityCardDTO.StudentPhotoType : string.Empty;
            }
            set
            {
                StudentIdentityCardDTO.StudentPhotoType = value;
            }
        }


        public string StudentPhotoFilename
        {
            get
            {
                return (StudentIdentityCardDTO != null) ? StudentIdentityCardDTO.StudentPhotoFilename : string.Empty;
            }
            set
            {
                StudentIdentityCardDTO.StudentPhotoFilename = value;
            }
        }

        public string StudentPhotoFileWidth
        {
            get
            {
                return (StudentIdentityCardDTO != null) ? StudentIdentityCardDTO.StudentPhotoFileWidth : string.Empty;
            }
            set
            {
                StudentIdentityCardDTO.StudentPhotoFileWidth = value;
            }
        }


        public string StudentPhotoFileHeight
        {
            get
            {
                return (StudentIdentityCardDTO != null) ? StudentIdentityCardDTO.StudentPhotoFileHeight : string.Empty;
            }
            set
            {
                StudentIdentityCardDTO.StudentPhotoFileHeight = value;
            }
        }


        public string StudentPhotoFileSize
        {
            get
            {
                return (StudentIdentityCardDTO != null) ? StudentIdentityCardDTO.StudentPhotoFileSize : string.Empty;
            }
            set
            {
                StudentIdentityCardDTO.StudentPhotoFileSize = value;
            }
        }

        // for Signature
        public byte[] StudentSignature
        {
            get
            {
                return (StudentIdentityCardDTO != null) ? StudentIdentityCardDTO.StudentSignature : new byte[1];         //review this       
            }
            set
            {
                StudentIdentityCardDTO.StudentSignature = value;
            }
        }


        public string StudentSignatureType
        {
            get
            {
                return (StudentIdentityCardDTO != null) ? StudentIdentityCardDTO.StudentSignatureType : string.Empty;
            }
            set
            {
                StudentIdentityCardDTO.StudentSignatureType = value;
            }
        }


        public string StudentSignatureFilename
        {
            get
            {
                return (StudentIdentityCardDTO != null) ? StudentIdentityCardDTO.StudentSignatureFilename : string.Empty;
            }
            set
            {
                StudentIdentityCardDTO.StudentSignatureFilename = value;
            }
        }

        public string StudentSignatureFileWidth
        {
            get
            {
                return (StudentIdentityCardDTO != null) ? StudentIdentityCardDTO.StudentSignatureFileWidth : string.Empty;
            }
            set
            {
                StudentIdentityCardDTO.StudentSignatureFileWidth = value;
            }
        }


        public string StudentSignatureFileHeight
        {
            get
            {
                return (StudentIdentityCardDTO != null) ? StudentIdentityCardDTO.StudentSignatureFileHeight : string.Empty;
            }
            set
            {
                StudentIdentityCardDTO.StudentSignatureFileHeight = value;
            }
        }


        public string StudentSignatureFileSize
        {
            get
            {
                return (StudentIdentityCardDTO != null) ? StudentIdentityCardDTO.StudentSignatureFileSize : string.Empty;
            }
            set
            {
                StudentIdentityCardDTO.StudentSignatureFileSize = value;
            }
        }



        #endregion File Upload


        #region Address
     
        # endregion Address
    }
}

