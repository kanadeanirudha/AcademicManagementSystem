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
    public class StudentRegistrationAcademicApprovalViewModel : IStudentRegistrationAcademicApprovalViewModel
    {

        public StudentRegistrationAcademicApprovalViewModel()
        {
            StudentRegistrationAcademicApprovalDTO = new StudentRegistrationAcademicApproval();
            ListOrganisationSectionDetails = new List<OrganisationSectionDetails>();
            PreviousWorkExperienceDTO = new PreviousWorkExperienceAcademicApproval();
            PreviousWorkExperienceList = new List<PreviousWorkExperienceAcademicApproval>();
        }

        public StudentRegistrationAcademicApproval StudentRegistrationAcademicApprovalDTO
        {
            get;
            set;
        }
        public List<PreviousWorkExperienceAcademicApproval> PreviousWorkExperienceList { get; set; }
        public PreviousWorkExperienceAcademicApproval PreviousWorkExperienceDTO { get; set; }
        public string SelectedSectionDetailID
        {
            get;
            set;
        }
    
        public int RegistrationID
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null ) ? StudentRegistrationAcademicApprovalDTO.RegistrationID : new int();
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.RegistrationID = value;
            }
        }
        public int Student_BranchDetailIDOFBranchID
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.Student_BranchDetailIDOFBranchID : new int();
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.Student_BranchDetailIDOFBranchID = value;
            }
        }
        public string AuthorisationType
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.AuthorisationType : string.Empty;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.AuthorisationType = value;
            }
        }
        public int RoleID
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.RoleID : new int();
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.RoleID = value;
            }
        }
        public bool Status
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.Status : false;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.Status = value;
            }
        }
        public string ReasonIfRejected
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.ReasonIfRejected : string.Empty;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.ReasonIfRejected = value;
            }
        }
        public bool IslastStatus
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.IslastStatus : false;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.IslastStatus = value;
            }
        }

        public int ApprovalStatus
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.ApprovalStatus : new int();
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.ApprovalStatus = value;
            }
        }
        public string StudentStatus
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.StudentStatus : string.Empty;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.StudentStatus = value;
            }
        }
        [Display(Name = "IsDeleted")]
        public bool IsDeleted
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.IsDeleted : false;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.IsDeleted = value;
            }
        }

        [Display(Name = "CreatedBy")]
        public int CreatedBy
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null && StudentRegistrationAcademicApprovalDTO.CreatedBy > 0) ? StudentRegistrationAcademicApprovalDTO.CreatedBy : new int();
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.CreatedBy = value;
            }
        }

        [Display(Name = "CreatedDate")]
        public DateTime CreatedDate
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.CreatedDate = value;
            }
        }

        [Display(Name = "ModifiedBy")]
        public int? ModifiedBy
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null && StudentRegistrationAcademicApprovalDTO.ModifiedBy.HasValue) ? StudentRegistrationAcademicApprovalDTO.ModifiedBy : new int();
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.ModifiedBy = value;
            }
        }

        [Display(Name = "ModifiedDate")]
        public DateTime? ModifiedDate
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null && StudentRegistrationAcademicApprovalDTO.ModifiedDate.HasValue) ? StudentRegistrationAcademicApprovalDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.ModifiedDate = value;
            }
        }

        [Display(Name = "DeletedBy")]
        public int? DeletedBy
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null && StudentRegistrationAcademicApprovalDTO.DeletedBy.HasValue) ? StudentRegistrationAcademicApprovalDTO.DeletedBy : new int();
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime? DeletedDate
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null && StudentRegistrationAcademicApprovalDTO.DeletedDate.HasValue) ? StudentRegistrationAcademicApprovalDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.DeletedDate = value;
            }
        }
        public string MenuCodeLink
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.MenuCodeLink : string.Empty;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.MenuCodeLink = value;
            }
        }
        public string errorMessage { get; set; }

        #region Oficial Info

        public int Student_AcademicYearId
        {

            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.Student_AcademicYearId : new int();
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.Student_AcademicYearId = value;
            }
        }
        public string Student_AcademicYear
        {

            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.Student_AcademicYear : string.Empty;
            }

            set
            {
                StudentRegistrationAcademicApprovalDTO.Student_AcademicYear = value;
            }
        }
        //[Required(ErrorMessage = "Field should not be blank")]
        [Display(Name = "CenterCode")]
        public string Student_StudentCode
        {

            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.Student_StudentCode : string.Empty;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.Student_StudentCode = value;
            }
        }
        //[Required(ErrorMessage = "Field must be selected")]
        [Display(Name = "Student_CourseYearId")]
        public int Student_CourseYearId
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.Student_CourseYearId : new int();
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.Student_CourseYearId = value;
            }
        }
        public string Student_CourseYearName
        {

            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.Student_CourseYearName : string.Empty;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.Student_CourseYearName = value;
            }
        }
        //[Required(ErrorMessage = "Field should not be blank")]
        [Display(Name = "Student_SelfRegistrationCode")]
        public string Student_SelfRegistrationCode
        {

            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.Student_SelfRegistrationCode : string.Empty;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.Student_SelfRegistrationCode = value;
            }
        }

        public string Student_CourseName
        {

            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.Student_CourseName : string.Empty;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.Student_CourseName = value;
            }
        }
       
     
        #endregion Oficial Info

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
        public HttpPostedFileBase StudentThumbFile { get; set; }


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
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.StudentPhoto : new byte[1];         //review this       
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.StudentPhoto = value;
            }
        }


        public string StudentPhotoType
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.StudentPhotoType : string.Empty;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.StudentPhotoType = value;
            }
        }


        public string StudentPhotoFilename
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.StudentPhotoFilename : string.Empty;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.StudentPhotoFilename = value;
            }
        }

        public string StudentPhotoFileWidth
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.StudentPhotoFileWidth : string.Empty;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.StudentPhotoFileWidth = value;
            }
        }


        public string StudentPhotoFileHeight
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.StudentPhotoFileHeight : string.Empty;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.StudentPhotoFileHeight = value;
            }
        }


        public string StudentPhotoFileSize
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.StudentPhotoFileSize : string.Empty;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.StudentPhotoFileSize = value;
            }
        }

        // for Signature
        public byte[] StudentSignature
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.StudentSignature : new byte[1];         //review this       
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.StudentSignature = value;
            }
        }


        public string StudentSignatureType
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.StudentSignatureType : string.Empty;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.StudentSignatureType = value;
            }
        }


        public string StudentSignatureFilename
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.StudentSignatureFilename : string.Empty;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.StudentSignatureFilename = value;
            }
        }

        public string StudentSignatureFileWidth
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.StudentSignatureFileWidth : string.Empty;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.StudentSignatureFileWidth = value;
            }
        }


        public string StudentSignatureFileHeight
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.StudentSignatureFileHeight : string.Empty;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.StudentSignatureFileHeight = value;
            }
        }


        public string StudentSignatureFileSize
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.StudentSignatureFileSize : string.Empty;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.StudentSignatureFileSize = value;
            }
        }
        //For Thumb
        // for Signature
        public byte[] StudentThumb
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.StudentThumb : new byte[1];         //review this       
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.StudentThumb = value;
            }
        }


        public string StudentThumbType
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.StudentThumbType : string.Empty;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.StudentThumbType = value;
            }
        }


        public string StudentThumbFilename
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.StudentThumbFilename : string.Empty;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.StudentThumbFilename = value;
            }
        }

        public string StudentThumbFileWidth
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.StudentThumbFileWidth : string.Empty;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.StudentThumbFileWidth = value;
            }
        }


        public string StudentThumbFileHeight
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.StudentThumbFileHeight : string.Empty;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.StudentThumbFileHeight = value;
            }
        }


        public string StudentThumbFileSize
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.StudentThumbFileSize : string.Empty;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.StudentThumbFileSize = value;
            }
        }



        #endregion File Upload

        #region  Student General Info

        public int ID
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null && StudentRegistrationAcademicApprovalDTO.ID > 0) ? StudentRegistrationAcademicApprovalDTO.ID : new int();
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.ID = value;
            }
        }
        //[Required(ErrorMessage = "Field should not be blank")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "StudentEmailID")]
        [RegularExpression("^([a-zA-Z0-9_\\-\\.]+)@[a-z0-9-]+(\\.[a-z0-9-]+)*(\\.[a-z]{2,3})$", ErrorMessage = "Please enter your email address in the format someone@example.com.")]
        public string StudentEmailID
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.StudentEmailID : string.Empty;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.StudentEmailID = value;
            }
        }
        //[Required(ErrorMessage = "Field should not be blank")]
        [Display(Name = "Password")]
        public string Password
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.Password : string.Empty;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.Password = value;
            }
        }
        //[Required(ErrorMessage = "Field should not be blank")]

        public string StudentTitle
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.StudentTitle : string.Empty;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.StudentTitle = value;
            }
        }

        [Display(Name = "FirstName")]
        public string StudentFirstName
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.StudentFirstName : string.Empty;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.StudentFirstName = value;
            }
        }

        [Display(Name = "MiddleName")]
        public string StudentMiddleName
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.StudentMiddleName : string.Empty;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.StudentMiddleName = value;
            }
        }

        public string StudentLastName
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.StudentLastName : string.Empty;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.StudentLastName = value;
            }
        }

        [Display(Name = "StudentDateofRegistration")]
        public string StudentDateofRegistration
        {

            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.StudentDateofRegistration : string.Empty;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.StudentDateofRegistration = value;
            }
        }
        //[Required(ErrorMessage = "Field should not be blank")]
        [Display(Name = "ContactNumber")]
        public string StudentMobileNumber
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.StudentMobileNumber : string.Empty;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.StudentMobileNumber = value;
            }
        }
        //[Required(ErrorMessage = "Field should not be blank")]
        [Display(Name = "ContactNumber")]
        public string StudentLandLineNumber
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.StudentLandLineNumber : string.Empty;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.StudentLandLineNumber = value;
            }
        }


        public string StudentGender
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.StudentGender : string.Empty;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.StudentGender = value;
            }
        }

        //[Required(ErrorMessage = "Field should not be blank")]
        [Display(Name = "CenterCode")]
        public string CenterCode
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.CenterCode : string.Empty;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.CenterCode = value;
            }
        }
        //[Required(ErrorMessage = "Field should not be blank")]
        [Display(Name = "ContactNumber")]
        public string StudentEmploymentSector
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.StudentEmploymentSector : string.Empty;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.StudentEmploymentSector = value;
            }
        }
        //[Required(ErrorMessage = "Field should not be blank")]
        [Display(Name = "ContactNumber")]
        public string StudentOccupation
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.StudentOccupation : string.Empty;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.StudentOccupation = value;
            }
        }

        //[Required(ErrorMessage = "Field should not be blank")]
        [Display(Name = "ContactNumber")]
        public string StudentDesignation
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.StudentDesignation : string.Empty;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.StudentDesignation = value;
            }
        }
        //[Required(ErrorMessage = "Field should not be blank")]
        [Display(Name = "StudentOrganizationName")]
        public string StudentOrganizationName
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.StudentOrganizationName : string.Empty;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.StudentOrganizationName = value;
            }
        }
        //[Required(ErrorMessage = "Field should not be blank")]
        [Display(Name = "StudentOfficeContactNo")]
        public string StudentOfficeContactNo
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.StudentOfficeContactNo : string.Empty;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.StudentOfficeContactNo = value;
            }
        }
        //[Required(ErrorMessage = "Field should not be blank")]
        [Display(Name = "StudentAnnualIncome")]
        public double StudentAnnualIncome
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.StudentAnnualIncome : new double();
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.StudentAnnualIncome = value;
            }
        }
        public bool IsActive
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.IsActive : false;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.IsActive = value;
            }
        }

        public string WebRegistrationStatus
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.WebRegistrationStatus : string.Empty;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.WebRegistrationStatus = value;
            }
        }

        public string WebAdminComments
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.WebAdminComments : string.Empty;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.WebAdminComments = value;
            }
        }

        public DateTime ApprovalDate
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.ApprovalDate : new DateTime();
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.ApprovalDate = value;
            }
        }
        public int AdminApprovedBy
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.AdminApprovedBy : new int();
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.AdminApprovedBy = value;
            }
        }

        public int StudentID
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.StudentID : new int();
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.StudentID = value;
            }
        }
        //[Required(ErrorMessage = "University should not be blank")]
        [Display(Name = "UniversityID")]
        public int UniversityID
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.UniversityID : new int();
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.UniversityID = value;
            }
        }
        public string StudentCode
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.StudentCode : string.Empty;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.StudentCode = value;
            }
        }
        public int ApprovStudSecEmployeeID
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.ApprovStudSecEmployeeID : new int();
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.ApprovStudSecEmployeeID = value;
            }
        }
        public int ApprovAcctSecEmployeeID
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.ApprovAcctSecEmployeeID : new int();
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.ApprovAcctSecEmployeeID = value;
            }
        }
        //[Required(ErrorMessage = "Branch should not be blank")]
        [Display(Name = "Branch")]
        public int BranchDetailID
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.BranchDetailID : new int();
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.BranchDetailID = value;
            }
        }
        //[Required(ErrorMessage = "Standard Number should not be blank")]
        [Display(Name = "Standard Number")]
        public int StandardNumber
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.StandardNumber : new int();
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.StandardNumber = value;
            }
        }
        public int AdmissionPattern
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.AdmissionPattern : new int();
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.AdmissionPattern = value;
            }
        }
        public int ToolRegistrationTemplateMstID
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.ToolRegistrationTemplateMstID : new int();
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.ToolRegistrationTemplateMstID = value;
            }
        }
        public bool IsLastRecordFlag
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.IsLastRecordFlag : false;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.IsLastRecordFlag = value;
            }
        }
        public string ApplicationDate
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.ApplicationDate : string.Empty;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.ApplicationDate = value;
            }
        }
        public bool IsEngaged
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.IsEngaged : false;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.IsEngaged = value;
            }
        }

        public int EngagedByUserID
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null && StudentRegistrationAcademicApprovalDTO.EngagedByUserID > 0) ? StudentRegistrationAcademicApprovalDTO.EngagedByUserID : new int();
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.EngagedByUserID = value;
            }
        }
        #endregion Student General Info

        #region Father InFormation
        public string FatherHusbondType
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.FatherHusbondType : string.Empty;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.FatherHusbondType = value;
            }
        }
        //[Required(ErrorMessage = "Title should not be blank")]
        [Display(Name = "Title")]
        public string FatherTitle
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.FatherTitle : string.Empty;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.FatherTitle = value;
            }
        }
        //[Required(ErrorMessage = "First Name should not be blank")]
        [Display(Name = "FirstName")]
        public string FatherFirstName
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.FatherFirstName : string.Empty;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.FatherFirstName = value;
            }
        }
        //[Required(ErrorMessage = "Middle Name should not be blank")]
        [Display(Name = "MiddleName")]
        public string FatherMiddleName
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.FatherMiddleName : string.Empty;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.FatherMiddleName = value;
            }
        }
        //[Required(ErrorMessage = "LastName should not be blank")]
        [Display(Name = "MiddleName")]
        public string FatherLastName
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.FatherLastName : string.Empty;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.FatherLastName = value;
            }
        }
        //[Required(ErrorMessage = "Email Address should not be blank")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "FatherEmailId")]
        [RegularExpression("^([a-zA-Z0-9_\\-\\.]+)@[a-z0-9-]+(\\.[a-z0-9-]+)*(\\.[a-z]{2,3})$", ErrorMessage = "Please enter your email address in the format someone@example.com.")]

        public string FatherEmailId
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.FatherEmailId : string.Empty;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.FatherEmailId = value;
            }
        }

        //[Required(ErrorMessage = "Mobile Number should not be blank")]
        [Display(Name = "ContactNumber")]
        public string FatherMobileNumber
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.FatherMobileNumber : string.Empty;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.FatherMobileNumber = value;
            }
        }
        //[Required(ErrorMessage = "LandLine Number should not be blank")]
        [Display(Name = "ContactNumber")]
        public string FatherLandLineNumber
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.FatherLandLineNumber : string.Empty;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.FatherLandLineNumber = value;
            }
        }

        //[Required(ErrorMessage = "Employment Sector should not be blank")]
        [Display(Name = "ContactNumber")]
        public string FatherEmploymentSector
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.FatherEmploymentSector : string.Empty;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.FatherEmploymentSector = value;
            }
        }
        //[Required(ErrorMessage = "Occupation should not be blank")]
        [Display(Name = "ContactNumber")]
        public string FatherOccupation
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.FatherOccupation : string.Empty;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.StudentOccupation = value;
            }
        }

        //[Required(ErrorMessage = "Designation should not be blank")]
        [Display(Name = "ContactNumber")]
        public string FatherDesignation
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.FatherDesignation : string.Empty;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.FatherDesignation = value;
            }
        }
        //[Required(ErrorMessage = "Organization Name should not be blank")]
        [Display(Name = "FatherOrganizationName")]
        public string FatherOrganizationName
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.FatherOrganizationName : string.Empty;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.FatherOrganizationName = value;
            }
        }
        //[Required(ErrorMessage = "Office ContactNo should not be blank")]
        [Display(Name = "FatherOfficeContactNo")]
        public string FatherOfficeContactNo
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.FatherOfficeContactNo : string.Empty;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.FatherOfficeContactNo = value;
            }
        }
        //[Required(ErrorMessage = "Annual Income should not be blank")]
        [Display(Name = "FatherAnnualIncome")]
        public double FatherAnnualIncome
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.FatherAnnualIncome : new double();
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.FatherAnnualIncome = value;
            }
        }
        #endregion

        #region Mother InFormation
        //[Required(ErrorMessage = "Title should not be blank")]
        [Display(Name = "Title")]
        public string MotherTitle
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.MotherTitle : string.Empty;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.MotherTitle = value;
            }
        }
        //[Required(ErrorMessage = "First Name should not be blank")]
        [Display(Name = "FirstName")]
        public string MotherFirstName
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.MotherFirstName : string.Empty;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.MotherFirstName = value;
            }
        }
        //[Required(ErrorMessage = "Middle Name should not be blank")]
        [Display(Name = "MiddleName")]
        public string MotherMiddleName
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.MotherMiddleName : string.Empty;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.MotherMiddleName = value;
            }
        }
        //[Required(ErrorMessage = "LastName should not be blank")]
        [Display(Name = "MiddleName")]
        public string MotherLastName
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.MotherLastName : string.Empty;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.MotherLastName = value;
            }
        }
        //[Required(ErrorMessage = "Email Address should not be blank")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "MotherEmailId")]
        [RegularExpression("^([a-zA-Z0-9_\\-\\.]+)@[a-z0-9-]+(\\.[a-z0-9-]+)*(\\.[a-z]{2,3})$", ErrorMessage = "Please enter your email address in the format someone@example.com.")]

        public string MotherEmailId
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.MotherEmailId : string.Empty;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.MotherEmailId = value;
            }
        }

        //[Required(ErrorMessage = "Mobile Number should not be blank")]
        [Display(Name = "ContactNumber")]
        public string MotherMobileNumber
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.MotherMobileNumber : string.Empty;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.MotherMobileNumber = value;
            }
        }
        //[Required(ErrorMessage = "LandLine Number should not be blank")]
        [Display(Name = "ContactNumber")]
        public string MotherLandLineNumber
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.MotherLandLineNumber : string.Empty;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.MotherLandLineNumber = value;
            }
        }

        //[Required(ErrorMessage = "Employment Sector should not be blank")]
        [Display(Name = "ContactNumber")]
        public string MotherEmploymentSector
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.MotherEmploymentSector : string.Empty;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.MotherEmploymentSector = value;
            }
        }
        //[Required(ErrorMessage = "Occupation should not be blank")]
        [Display(Name = "ContactNumber")]
        public string MotherOccupation
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.MotherOccupation : string.Empty;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.StudentOccupation = value;
            }
        }

        //[Required(ErrorMessage = "Designation should not be blank")]
        [Display(Name = "ContactNumber")]
        public string MotherDesignation
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.MotherDesignation : string.Empty;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.MotherDesignation = value;
            }
        }
        //[Required(ErrorMessage = "Organization Name should not be blank")]
        [Display(Name = "MotherOrganizationName")]
        public string MotherOrganizationName
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.MotherOrganizationName : string.Empty;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.MotherOrganizationName = value;
            }
        }
        //[Required(ErrorMessage = "Office ContactNo should not be blank")]
        [Display(Name = "MotherOfficeContactNo")]
        public string MotherOfficeContactNo
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.MotherOfficeContactNo : string.Empty;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.MotherOfficeContactNo = value;
            }
        }
        //[Required(ErrorMessage = "Annual Income should not be blank")]
        [Display(Name = "MotherAnnualIncome")]
        public double MotherAnnualIncome
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.MotherAnnualIncome : new double();
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.MotherAnnualIncome = value;
            }
        }
        #endregion

        #region Guardian InFormation
        //[Required(ErrorMessage = "Title should not be blank")]
        [Display(Name = "Title")]
        public string GuardianTitle
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.GuardianTitle : string.Empty;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.GuardianTitle = value;
            }
        }
        //[Required(ErrorMessage = "First Name should not be blank")]
        [Display(Name = "FirstName")]
        public string GuardianFirstName
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.GuardianFirstName : string.Empty;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.GuardianFirstName = value;
            }
        }
        //[Required(ErrorMessage = "Middle Name should not be blank")]
        [Display(Name = "MiddleName")]
        public string GuardianMiddleName
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.GuardianMiddleName : string.Empty;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.GuardianMiddleName = value;
            }
        }
        //[Required(ErrorMessage = "LastName should not be blank")]
        [Display(Name = "MiddleName")]
        public string GuardianLastName
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.GuardianLastName : string.Empty;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.GuardianLastName = value;
            }
        }
        //[Required(ErrorMessage = "Email Address should not be blank")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "GuardianEmailId")]
        [RegularExpression("^([a-zA-Z0-9_\\-\\.]+)@[a-z0-9-]+(\\.[a-z0-9-]+)*(\\.[a-z]{2,3})$", ErrorMessage = "Please enter your email address in the format someone@example.com.")]

        public string GuardianEmailId
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.GuardianEmailId : string.Empty;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.GuardianEmailId = value;
            }
        }

        //[Required(ErrorMessage = "Mobile Number should not be blank")]
        [Display(Name = "ContactNumber")]
        public string GuardianMobileNumber
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.GuardianMobileNumber : string.Empty;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.GuardianMobileNumber = value;
            }
        }
        //[Required(ErrorMessage = "LandLine Number should not be blank")]
        [Display(Name = "ContactNumber")]
        public string GuardianLandLineNumber
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.GuardianLandLineNumber : string.Empty;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.GuardianLandLineNumber = value;
            }
        }

        //[Required(ErrorMessage = "Employment Sector should not be blank")]
        [Display(Name = "ContactNumber")]
        public string GuardianEmploymentSector
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.GuardianEmploymentSector : string.Empty;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.GuardianEmploymentSector = value;
            }
        }
        //[Required(ErrorMessage = "Occupation should not be blank")]
        [Display(Name = "ContactNumber")]
        public string GuardianOccupation
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.GuardianOccupation : string.Empty;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.StudentOccupation = value;
            }
        }

        //[Required(ErrorMessage = "Designation should not be blank")]
        [Display(Name = "ContactNumber")]
        public string GuardianDesignation
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.GuardianDesignation : string.Empty;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.GuardianDesignation = value;
            }
        }
        //[Required(ErrorMessage = "Organization Name should not be blank")]
        [Display(Name = "GuardianOrganizationName")]
        public string GuardianOrganizationName
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.GuardianOrganizationName : string.Empty;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.GuardianOrganizationName = value;
            }
        }
        //[Required(ErrorMessage = "Office ContactNo should not be blank")]
        [Display(Name = "GuardianOfficeContactNo")]
        public string GuardianOfficeContactNo
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.GuardianOfficeContactNo : string.Empty;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.GuardianOfficeContactNo = value;
            }
        }
        //[Required(ErrorMessage = "Annual Income should not be blank")]
        [Display(Name = "GuardianAnnualIncome")]
        public double GuardianAnnualIncome
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.GuardianAnnualIncome : new double();
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.GuardianAnnualIncome = value;
            }
        }
        #endregion


        #region Student Specific  Info
        //[Required(ErrorMessage = "Enrollment number should not be blank")]
        [Display(Name = "StudentEnrollmentNo")]
        public string StudentEnrollmentNo
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.StudentEnrollmentNo : string.Empty;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.StudentEnrollmentNo = value;
            }
        }
        //[Required(ErrorMessage = "NRI/POI must be selected")]
        [Display(Name = "StudentNRI_POI")]
        public string StudentNRI_POI
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.StudentNRI_POI : string.Empty;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.StudentNRI_POI = value;
            }
        }
        //[Required(ErrorMessage = "Migration Number should not be blank")]
        [Display(Name = "StudentMigrationNumber")]
        public string StudentMigrationNumber
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.StudentMigrationNumber : string.Empty;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.StudentMigrationNumber = value;
            }
        }
        //[Required(ErrorMessage = "Nationality must be selected")]
        [Display(Name = "StudentNationalityID")]
        public int StudentNationalityID
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.StudentNationalityID : new int();
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.StudentNationalityID = value;
            }
        }
        //[Required(ErrorMessage = "Migration Date should not be blank")]
        [Display(Name = "StudentMigrationDate")]
        public string StudentMigrationDate
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.StudentMigrationDate : string.Empty;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.StudentMigrationDate = value;
            }
        }
        //[Required(ErrorMessage = "Marital Status must be selected")]
        [Display(Name = "StudentMaritalStatus")]
        public string StudentMaritalStatus
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.StudentMaritalStatus : string.Empty;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.StudentMaritalStatus = value;
            }
        }
        //[Required(ErrorMessage = "Domicile State of Father should not be blank")]
        [Display(Name = "StudentDomicileStateofFather")]
        public string StudentDomicileStateofFather
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.StudentDomicileStateofFather : string.Empty;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.StudentDomicileStateofFather = value;
            }
        }
        //[Required(ErrorMessage = "Blood Group must be selected")]
        [Display(Name = "StudentBloodGroup")]
        public string StudentBloodGroup
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.StudentBloodGroup : string.Empty;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.StudentBloodGroup = value;
            }
        }
        //[Required(ErrorMessage = "Domicile State of Mother should not be blank")]
        [Display(Name = "StudentDomicileStateofMother")]
        public string StudentDomicileStateofMother
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.StudentDomicileStateofMother : string.Empty;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.StudentDomicileStateofMother = value;
            }
        }
        //[Required(ErrorMessage = "Physically Handicapped must be selected")]
        [Display(Name = "PhysicallyHandicapped")]
        public string PhysicallyHandicapped
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.PhysicallyHandicapped : string.Empty;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.PhysicallyHandicapped = value;
            }
        }
        //[Required(ErrorMessage = "Employment Status should not be blank")]
        [Display(Name = "StudentEmploymentStatus")]
        public string StudentEmploymentStatus
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.StudentEmploymentStatus : string.Empty;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.StudentEmploymentStatus = value;
            }

        }
        //[Required(ErrorMessage = "Identification Mark should not be blank")]
        [Display(Name = "StudentIdentificationMark")]
        public string StudentIdentificationMark
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.StudentIdentificationMark : string.Empty;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.StudentIdentificationMark = value;
            }

        }
        //[Required(ErrorMessage = "Previous name of student should not be blank")]
        [Display(Name = "StudentPrevNameofStudent")]
        public string StudentPrevNameofStudent
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.StudentPrevNameofStudent : string.Empty;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.StudentPrevNameofStudent = value;
            }

        }
        //[Required(ErrorMessage = "Organ donor must be selected")]
        [Display(Name = "StudentOrgandonor")]
        public string StudentOrgandonor
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.StudentOrgandonor : string.Empty;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.StudentOrgandonor = value;
            }
        }
        //[Required(ErrorMessage = "Reason for name change must be selected")]
        [Display(Name = "StudentReasonforNamechange")]
        public string StudentReasonforNamechange
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.StudentReasonforNamechange : string.Empty;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.StudentReasonforNamechange = value;
            }
        }

        //[Required(ErrorMessage = "Region Name must be selected")]
        [Display(Name = "StudentRegionID")]
        public int StudentRegionID
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.StudentRegionID : new int();
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.StudentRegionID = value;
            }
        }
        //[Required(ErrorMessage = "Region Name should not be blank")]
        [Display(Name = "StudentRegionOther")]
        public string StudentRegionOther
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.StudentRegionOther : string.Empty;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.StudentRegionOther = value;
            }
        }


        public int Student_Domesile_CountryId
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.Student_Domesile_CountryId : new int();
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.Student_Domesile_CountryId = value;
            }
        }
        public int StudentSelfRegistrationID
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.StudentSelfRegistrationID : new int();
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.StudentSelfRegistrationID = value;
            }
        }
        #endregion Student Specific  Info

        #region  Address Information

        #region  Permanent Address
        //[Required(ErrorMessage = "Field should not be blank")]
        [Display(Name = "Student_PermanentAddress_PloteNo")]
        public string Student_PermanentAddress_PloteNo
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.Student_PermanentAddress_PloteNo : string.Empty;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.Student_PermanentAddress_PloteNo = value;
            }
        }
        //[Required(ErrorMessage = "Field should not be blank")]
        [Display(Name = "Student_PermanentAddress_StreeNo")]
        public string Student_PermanentAddress_StreeNo
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.Student_PermanentAddress_StreeNo : string.Empty;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.Student_PermanentAddress_StreeNo = value;
            }
        }
        //[Required(ErrorMessage = "Field should not be blank")]
        [Display(Name = "Student_PermanentAddress_Address1")]
        public string Student_PermanentAddress_Address1
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.Student_PermanentAddress_Address1 : string.Empty;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.Student_PermanentAddress_Address1 = value;
            }
        }

        //[Required(ErrorMessage = "Field should not be blank")]
        [Display(Name = "Student_PermanentAddress_Address2")]
        public string Student_PermanentAddress_Address2
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.Student_PermanentAddress_Address2 : string.Empty;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.Student_PermanentAddress_Address2 = value;
            }
        }
        //[Required(ErrorMessage = "Field should not be blank")]
        [Display(Name = "Student_PermanentAddress_City_Tahsil")]
        public int Student_PermanentAddress_City_TahsilID
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.Student_PermanentAddress_City_TahsilID : new int();
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.Student_PermanentAddress_City_TahsilID = value;
            }
        }

        [Display(Name = "Student_PermanentAddress_City_TahsilName")]
        public string Student_PermanentAddress_City_TahsilName
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.Student_PermanentAddress_City_TahsilName : string.Empty;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.Student_PermanentAddress_City_TahsilName = value;
            }
        }


        public string Student_PermanentAddress_City_TahsilOther
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.Student_PermanentAddress_City_TahsilOther : string.Empty;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.Student_PermanentAddress_City_TahsilOther = value;
            }
        }
        //[Required(ErrorMessage = "Field should not be blank")]
        [Display(Name = "Student_PermanentAddress_CountryId")]
        public int Student_PermanentAddress_CountryId
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.Student_PermanentAddress_CountryId : new int();
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.Student_PermanentAddress_CountryId = value;
            }
        }
        //[Required(ErrorMessage = "Field should not be blank")]
        [Display(Name = "Student_PermanentAddress_State")]
        public int Student_PermanentAddress_State
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.Student_PermanentAddress_State : new int();
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.Student_PermanentAddress_State = value;
            }
        }
        //[Required(ErrorMessage = "Field should not be blank")]
        [Display(Name = "Student_PermanentAddress_StateOther")]
        public string Student_PermanentAddress_StateOther
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.Student_PermanentAddress_StateOther : string.Empty;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.Student_PermanentAddress_StateOther = value;
            }
        }
        //[Required(ErrorMessage = "Field should not be blank")]
        [Display(Name = "Student_PermanentAddress_District")]
        public int Student_PermanentAddress_DistrictID
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.Student_PermanentAddress_DistrictID : new int();
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.Student_PermanentAddress_DistrictID = value;
            }
        }
        public string Student_PermanentAddress_DistrictOther
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.Student_PermanentAddress_DistrictOther : string.Empty;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.Student_PermanentAddress_DistrictOther = value;
            }
        }
        //[Required(ErrorMessage = "Field should not be blank")]
        [Display(Name = "Student_PermanentAddress_Tahsil")]
        public string Student_PermanentAddress_Tahsil
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.Student_PermanentAddress_Tahsil : string.Empty;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.Student_PermanentAddress_Tahsil = value;
            }
        }
        //[Required(ErrorMessage = "Field should not be blank")]
        [Display(Name = "Student_PermanentAddress_NearPoliceStation")]
        public string Student_PermanentAddress_NearPoliceStation
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.Student_PermanentAddress_NearPoliceStation : string.Empty;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.Student_PermanentAddress_NearPoliceStation = value;
            }
        }
        //[Required(ErrorMessage = "Field should not be blank")]
        [Display(Name = "Student_PermanentAddress_ZipCode")]
        public string Student_PermanentAddress_ZipCode
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.Student_PermanentAddress_ZipCode : string.Empty;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.Student_PermanentAddress_ZipCode = value;
            }
        }
        //[Required(ErrorMessage = "Field should not be blank")]
        [Display(Name = "Student_PermanentAddress_City_Tahsil_Pattern")]
        public string Student_PermanentAddress_City_Tahsil_Pattern
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.Student_PermanentAddress_City_Tahsil_Pattern : string.Empty;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.Student_PermanentAddress_City_Tahsil_Pattern = value;
            }
        }
        #endregion  Permanent Address

        #region  Correspondence Address
        public bool SameAsPerPermanentAddress
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.SameAsPerPermanentAddress : false;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.SameAsPerPermanentAddress = value;
            }
        }

        //[Required(ErrorMessage = "Field should not be blank")]
        [Display(Name = "Student_CorrespondenceAddress_PloteNo")]
        public string Student_CorrespondenceAddress_PloteNo
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.Student_CorrespondenceAddress_PloteNo : string.Empty;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.Student_CorrespondenceAddress_PloteNo = value;
            }
        }
        //[Required(ErrorMessage = "Field should not be blank")]
        [Display(Name = "Student_CorrespondenceAddress_StreeNo")]
        public string Student_CorrespondenceAddress_StreeNo
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.Student_CorrespondenceAddress_StreeNo : string.Empty;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.Student_CorrespondenceAddress_StreeNo = value;
            }
        }
        //[Required(ErrorMessage = "Field should not be blank")]
        [Display(Name = "Student_CorrespondenceAddress_Address1")]
        public string Student_CorrespondenceAddress_Address1
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.Student_CorrespondenceAddress_Address1 : string.Empty;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.Student_CorrespondenceAddress_Address1 = value;
            }
        }
        //[Required(ErrorMessage = "Field should not be blank")]
        [Display(Name = "Student_CorrespondenceAddress_Address2")]
        public string Student_CorrespondenceAddress_Address2
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.Student_CorrespondenceAddress_Address2 : string.Empty;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.Student_CorrespondenceAddress_Address2 = value;
            }
        }
        //[Required(ErrorMessage = "Field should not be blank")]
        [Display(Name = "Student_CorrespondenceAddress_City_Tahsil")]
        public string Student_CorrespondenceAddress_City_TahsilOther
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.Student_CorrespondenceAddress_City_TahsilOther : string.Empty;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.Student_CorrespondenceAddress_City_TahsilOther = value;
            }
        }

        public int Student_CorrespondenceAddress_City_TahsilID
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.Student_CorrespondenceAddress_City_TahsilID : new int();
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.Student_CorrespondenceAddress_City_TahsilID = value;
            }
        }

        [Display(Name = "Student_CorrespondenceAddress_City_Tahsil")]
        public string Student_CorrespondenceAddress_City_TahsilName
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.Student_CorrespondenceAddress_City_TahsilName : string.Empty;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.Student_CorrespondenceAddress_City_TahsilName = value;
            }
        }
        //[Required(ErrorMessage = "Field should not be blank")]
        [Display(Name = "Student_CorrespondenceAddress_CountryId")]
        public int Student_CorrespondenceAddress_CountryId
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.Student_CorrespondenceAddress_CountryId : new int();
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.Student_CorrespondenceAddress_CountryId = value;
            }
        }
        //[Required(ErrorMessage = "Field should not be blank")]
        [Display(Name = "Student_CorrespondenceAddress_State")]
        public int Student_CorrespondenceAddress_State
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.Student_CorrespondenceAddress_State : new int();
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.Student_CorrespondenceAddress_State = value;
            }
        }
        //[Required(ErrorMessage = "Field should not be blank")]
        [Display(Name = "Student_CorrespondenceAddress_StateOther")]
        public string Student_CorrespondenceAddress_StateOther
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.Student_CorrespondenceAddress_StateOther : string.Empty;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.Student_CorrespondenceAddress_StateOther = value;
            }
        }
        //[Required(ErrorMessage = "Field should not be blank")]
        [Display(Name = "Student_CorrespondenceAddress_District")]
        public string Student_CorrespondenceAddress_DistrictOther
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.Student_CorrespondenceAddress_DistrictOther : string.Empty;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.Student_CorrespondenceAddress_DistrictOther = value;
            }
        }

        public int Student_CorrespondenceAddress_DistrictID
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.Student_CorrespondenceAddress_DistrictID : new int();
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.Student_CorrespondenceAddress_DistrictID = value;
            }
        }
        //[Required(ErrorMessage = "Field should not be blank")]
        [Display(Name = "Student_CorrespondenceAddress_Tahsil")]
        public string Student_CorrespondenceAddress_Tahsil
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.Student_CorrespondenceAddress_Tahsil : string.Empty;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.Student_CorrespondenceAddress_Tahsil = value;
            }
        }
        //[Required(ErrorMessage = "Field should not be blank")]
        [Display(Name = "Student_CorrespondenceAddress_NearPoliceStation")]
        public string Student_CorrespondenceAddress_NearPoliceStation
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.Student_CorrespondenceAddress_NearPoliceStation : string.Empty;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.Student_CorrespondenceAddress_NearPoliceStation = value;
            }
        }
        //[Required(ErrorMessage = "Field should not be blank")]
        [Display(Name = "Student_CorrespondenceAddress_ZipCode")]
        public string Student_CorrespondenceAddress_ZipCode
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.Student_CorrespondenceAddress_ZipCode : string.Empty;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.Student_CorrespondenceAddress_ZipCode = value;
            }
        }
        //[Required(ErrorMessage = "Field should not be blank")]
        [Display(Name = "Student_CorrespondenceAddress_City_Tahsil_Pattern")]
        public string Student_CorrespondenceAddress_City_Tahsil_Pattern
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.Student_CorrespondenceAddress_City_Tahsil_Pattern : string.Empty;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.Student_CorrespondenceAddress_City_Tahsil_Pattern = value;
            }
        }
        #endregion  Correspondence Address

        #endregion  Address Information

        #region Information As Per Leaving Certificate

        //[Required(ErrorMessage = "Date of Birth should not be blank")]
        [Display(Name = "StudentDateofBirth")]
        public string StudentDateofBirth
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.StudentDateofBirth : string.Empty;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.StudentDateofBirth = value;
            }
        }
        //[Required(ErrorMessage = "BirthPlace must be selected")]
        [Display(Name = "StudentBirthPlace")]
        public string StudentBirthPlace
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.StudentBirthPlace : string.Empty;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.StudentBirthPlace = value;
            }
        }
        //[Required(ErrorMessage = "Religion Name must be selected")]
        //[Display(Name = "StudentReligionID")]
        public int StudentReligionID
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.StudentReligionID : new int();
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.StudentReligionID = value;
            }
        }
        //[Required(ErrorMessage = "Caste must be selected")]
        //[Display(Name = "StudentCasteID")]
        public int StudentCasteID
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.StudentCasteID : new int();
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.StudentCasteID = value;
            }
        }
        //[Required(ErrorMessage = "Category must be selected")]
        [Display(Name = "StudentCategoryID")]
        public int StudentCategoryID
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.StudentCategoryID : new int();
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.StudentCategoryID = value;
            }
        }
        //[Required(ErrorMessage = "Caste as per TC/LC must be selected")]
        [Display(Name = "StudentCasteAsPerTC/LC")]
        public string StudentCasteAsPerTC_LC
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.StudentCasteAsPerTC_LC : string.Empty;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.StudentCasteAsPerTC_LC = value;
            }
        }
        //[Required(ErrorMessage = "Mother tonque must be selected")]
        [Display(Name = "StudentMotherTongueID")]
        public int StudentMotherTongueID
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.StudentMotherTongueID : new int();
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.StudentMotherTongueID = value;
            }
        }
        //[Required(ErrorMessage = "Name as per mark sheet must be selected")]
        [Display(Name = "StudentNameAsPerMarkSheet")]
        public string StudentNameAsPerMarkSheet
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.StudentNameAsPerMarkSheet : string.Empty;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.StudentNameAsPerMarkSheet = value;
            }
        }
        //[Required(ErrorMessage = "Last School/College must be selected")]
        [Display(Name = "StudentLastSchool_College")]
        public string StudentLastSchool_College
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.StudentLastSchool_College : string.Empty;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.StudentLastSchool_College = value;
            }
        }
        //[Required(ErrorMessage = "Previous LC/TC number must be selected")]
        [Display(Name = "StudentNameAsPerMarkSheet")]
        public string StudentPreviousLC_TCNo
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.StudentPreviousLC_TCNo : string.Empty;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.StudentPreviousLC_TCNo = value;
            }
        }
        #endregion  Information As Per Leaving Certificate

        #region  Social Reservation Information
        //[Required(ErrorMessage = "Field must be selected")]
        [Display(Name = "Student_Ex_Serviceman_Ward_of_Ex_Serviceman")]
        public bool Student_Ex_Serviceman_Ward_of_Ex_Serviceman
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.Student_Ex_Serviceman_Ward_of_Ex_Serviceman : false;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.Student_Ex_Serviceman_Ward_of_Ex_Serviceman = value;
            }
        }
        //[Required(ErrorMessage = "Field must be selected")]
        [Display(Name = "Student_Ex_Serviceman_Ward_of_Ex_Serviceman")]
        public bool Student_Active_Serviceman_Ward_of_Active_Serviceman
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.Student_Active_Serviceman_Ward_of_Active_Serviceman : false;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.Student_Active_Serviceman_Ward_of_Active_Serviceman = value;
            }
        }
        //[Required(ErrorMessage = "Field must be selected")]
        [Display(Name = "Student_FreedomFighterWardOfFreedomFighter")]
        public bool Student_FreedomFighterWardOfFreedomFighter
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.Student_FreedomFighterWardOfFreedomFighter : false;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.Student_FreedomFighterWardOfFreedomFighter = value;
            }
        }
        //[Required(ErrorMessage = "Field must be selected")]
        [Display(Name = "Student_WardofPrimaryTeacher")]
        public bool Student_WardofPrimaryTeacher
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.Student_WardofPrimaryTeacher : false;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.Student_WardofPrimaryTeacher = value;
            }
        }
        //[Required(ErrorMessage = "Field must be selected")]
        [Display(Name = "Student_WardofSecondaryTeacher")]
        public bool Student_WardofSecondaryTeacher
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.Student_WardofSecondaryTeacher : false;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.Student_WardofSecondaryTeacher = value;
            }
        }
        //[Required(ErrorMessage = "Field must be selected")]
        [Display(Name = "Student_Deserted_Divorced_Widowed_Women")]
        public bool Student_Deserted_Divorced_Widowed_Women
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.Student_Deserted_Divorced_Widowed_Women : false;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.Student_Deserted_Divorced_Widowed_Women = value;
            }
        }
        //[Required(ErrorMessage = "Field must be selected")]
        [Display(Name = "Student_MemberofProjectAffectedFamily")]
        public bool Student_MemberofProjectAffectedFamily
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.Student_MemberofProjectAffectedFamily : false;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.Student_MemberofProjectAffectedFamily = value;
            }
        }
        //[Required(ErrorMessage = "Field must be selected")]
        [Display(Name = "Student_KashmirMigrant")]
        public bool Student_KashmirMigrant
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.Student_KashmirMigrant : false;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.Student_KashmirMigrant = value;
            }
        }
        //[Required(ErrorMessage = "Field must be selected")]
        [Display(Name = "Student_MemberofEarthquakeAffectedFamily")]
        public bool Student_MemberofEarthquakeAffectedFamily
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.Student_MemberofEarthquakeAffectedFamily : false;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.Student_MemberofEarthquakeAffectedFamily = value;
            }
        }
        //[Required(ErrorMessage = "Field must be selected")]
        [Display(Name = "Student_MemberofFloodFamineAffectedFamily")]
        public bool Student_MemberofFloodFamineAffectedFamily
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.Student_MemberofFloodFamineAffectedFamily : false;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.Student_MemberofFloodFamineAffectedFamily = value;
            }
        }
        //[Required(ErrorMessage = "Field must be selected")]
        [Display(Name = "Student_ResidentofTribalArea")]
        public bool Student_ResidentofTribalArea
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.Student_ResidentofTribalArea : false;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.Student_ResidentofTribalArea = value;
            }
        }

        #endregion  Social Reservation Information

        #region  Other Information Of The Student
        //[Required(ErrorMessage = "Field should not be blank")]
        [Display(Name = "StudentIndicatetypeofCandidature")]
        public string StudentIndicatetypeofCandidature
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.StudentIndicatetypeofCandidature : string.Empty;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.StudentIndicatetypeofCandidature = value;
            }
        }
        //[Required(ErrorMessage = "Field should not be blank")]
        [Display(Name = "StudentSchoolFromHSCExaminationpassed")]
        public string StudentSchoolFromHSCExaminationpassed
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.StudentSchoolFromHSCExaminationpassed : string.Empty;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.StudentSchoolFromHSCExaminationpassed = value;
            }
        }
        //[Required(ErrorMessage = "Field should not be blank")]
        [Display(Name = "StudentEconomicallyBackwardClass")]
        public string StudentEconomicallyBackwardClass
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.StudentEconomicallyBackwardClass : string.Empty;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.StudentEconomicallyBackwardClass = value;
            }
        }
        //[Required(ErrorMessage = "Field should not be blank")]
        [Display(Name = "StudentsNameOfDistrictWhereParentDomiciled")]
        public string StudentsNameOfDistrictWhereParentDomiciled
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.StudentsNameOfDistrictWhereParentDomiciled : string.Empty;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.StudentsNameOfDistrictWhereParentDomiciled = value;
            }
        }
        //[Required(ErrorMessage = "Field should not be blank")]
        [Display(Name = "StudentsMKBCandidate")]
        public string StudentsMKBCandidate
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.StudentsMKBCandidate : string.Empty;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.StudentsMKBCandidate = value;
            }
        }

        #endregion  Other Information Of The Student

        #region Qualifying Exam Details
        //[Required(ErrorMessage = "Field must be selected")]
        [Display(Name = "Student_QualifyingExamId")]
        public int Student_QualifyingExamId
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.Student_QualifyingExamId : new int();
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.Student_QualifyingExamId = value;
            }
        }
        //[Required(ErrorMessage = "Field should not be blank")]
        [Display(Name = "Student_QualifyingExamName")]
        public string Student_QualifyingExamName
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.Student_QualifyingExamName : string.Empty;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.Student_QualifyingExamName = value;
            }
        }
        //[Required(ErrorMessage = "Field should not be blank")]
        [Display(Name = "Student_QualifyingRollNo")]
        public string Student_QualifyingRollNo
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.Student_QualifyingRollNo : string.Empty;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.Student_QualifyingRollNo = value;
            }
        }
        //[Required(ErrorMessage = "Field should not be blank")]
        [Display(Name = "Student_QualifyingExamTotalMarksPointsObtained")]
        public int Student_QualifyingExamTotalMarksPointsObtained
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.Student_QualifyingExamTotalMarksPointsObtained : new int();
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.Student_QualifyingExamTotalMarksPointsObtained = value;
            }
        }
        //[Required(ErrorMessage = "Field should not be blank")]
        [Display(Name = "Student_QualifyingExamOutOffMark")]
        public int Student_QualifyingExamOutOffMark
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.Student_QualifyingExamOutOffMark : new int();
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.Student_QualifyingExamOutOffMark = value;
            }
        }
        //[Required(ErrorMessage = "Field should not be blank")]
        [Display(Name = "Student_QualifyingExamRank")]
        public string Student_QualifyingExamRank
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.Student_QualifyingExamRank : string.Empty;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.Student_QualifyingExamRank = value;
            }
        }
        //[Required(ErrorMessage = "Field should not be blank")]
        [Display(Name = "Student_QualifyingExamRank")]
        public int Student_QualifyingExamTotalMarksPointsObtainedInSubject
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.Student_QualifyingExamTotalMarksPointsObtainedInSubject : new int();
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.Student_QualifyingExamTotalMarksPointsObtainedInSubject = value;
            }
        }

        public int Student_QualifyingTransactionID
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.Student_QualifyingTransactionID : new int();
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.Student_QualifyingTransactionID = value;
            }
        }
        #endregion Qualifying Exam Details

        #region Qualification Details
        #region General Details
        //[Required(ErrorMessage = "Field must be selected")]
        [Display(Name = "Student_Qualification_General_MediumOfInstitution")]
        public int Student_Qualification_General_MediumOfInstitution
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.Student_Qualification_General_MediumOfInstitution : new int();
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.Student_Qualification_General_MediumOfInstitution = value;
            }
        }
        //[Required(ErrorMessage = "Field must be selected")]
        [Display(Name = "Student_Qualification_General_MonthOfPassing")]

        public int Student_Qualification_General_MonthOfPassing
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.Student_Qualification_General_MonthOfPassing : new int();
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.Student_Qualification_General_MonthOfPassing = value;
            }

        }
        //[Required(ErrorMessage = "Field must be selected")]
        [Display(Name = "Student_Qualification_General_YearOfPassing")]
        public int Student_Qualification_General_YearOfPassing
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.Student_Qualification_General_YearOfPassing : new int();
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.Student_Qualification_General_YearOfPassing = value;
            }

        }
        //[Required(ErrorMessage = "Field should not be blank")]
        [Display(Name = "Student_Qualification_General_SingleAttempt")]
        public string Student_Qualification_General_SingleAttempt
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.Student_Qualification_General_SingleAttempt : string.Empty;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.Student_Qualification_General_SingleAttempt = value;
            }
        }
        //[Required(ErrorMessage = "Field must be selected")]
        [Display(Name = "Student_Qualification_General_Percent")]
        public int Student_Qualification_General_Percent
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.Student_Qualification_General_Percent : new int();
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.Student_Qualification_General_Percent = value;
            }

        }
        //[Required(ErrorMessage = "Field must be selected")]
        [Display(Name = "Student_Qualification_General_ObtainedMark")]
        public int Student_Qualification_General_ObtainedMark
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.Student_Qualification_General_ObtainedMark : new int();
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.Student_Qualification_General_ObtainedMark = value;
            }

        }
        //[Required(ErrorMessage = "Field must be selected")]
        [Display(Name = "Student_Qualification_General_OutOfMark")]
        public int Student_Qualification_General_OutOfMark
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.Student_Qualification_General_OutOfMark : new int();
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.Student_Qualification_General_OutOfMark = value;
            }
        }
        //[Required(ErrorMessage = "Field should not be blank")]
        [Display(Name = "Student_Qualification_General_Region_Division_Board")]
        public string Student_Qualification_General_Region_Division_Board
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.Student_Qualification_General_Region_Division_Board : string.Empty;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.Student_Qualification_General_Region_Division_Board = value;
            }
        }
        //[Required(ErrorMessage = "Field should not be blank")]
        [Display(Name = "Student_Qualification_General_NameofInstitution")]
        public string Student_Qualification_General_NameofInstitution
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.Student_Qualification_General_NameofInstitution : string.Empty;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.Student_Qualification_General_NameofInstitution = value;
            }
        }

        #endregion General Details
        #region SSC Details
        //[Required(ErrorMessage = "Field must be selected")]
        [Display(Name = "Student_Qualification_SSC_MediumOfInstitution")]
        public int Student_Qualification_SSC_MediumOfInstitution
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.Student_Qualification_SSC_MediumOfInstitution : new int();
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.Student_Qualification_SSC_MediumOfInstitution = value;
            }
        }
        //[Required(ErrorMessage = "Field must be selected")]
        [Display(Name = "Student_Qualification_SSC_MonthOfPassing")]

        public int Student_Qualification_SSC_MonthOfPassing
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.Student_Qualification_SSC_MonthOfPassing : new int();
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.Student_Qualification_SSC_MonthOfPassing = value;
            }

        }
        //[Required(ErrorMessage = "Field must be selected")]
        [Display(Name = "Student_Qualification_SSC_YearOfPassing")]
        public int Student_Qualification_SSC_YearOfPassing
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.Student_Qualification_SSC_YearOfPassing : new int();
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.Student_Qualification_SSC_YearOfPassing = value;
            }

        }
        //[Required(ErrorMessage = "Field should not be blank")]
        [Display(Name = "Student_Qualification_SSC_SingleAttempt")]
        public string Student_Qualification_SSC_SingleAttempt
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.Student_Qualification_SSC_SingleAttempt : string.Empty;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.Student_Qualification_SSC_SingleAttempt = value;
            }
        }
        //[Required(ErrorMessage = "Field must be selected")]
        [Display(Name = "Student_Qualification_SSC_Percent")]
        public int Student_Qualification_SSC_Percent
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.Student_Qualification_SSC_Percent : new int();
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.Student_Qualification_SSC_Percent = value;
            }

        }
        //[Required(ErrorMessage = "Field must be selected")]
        [Display(Name = "Student_Qualification_SSC_ObtainedMark")]
        public int Student_Qualification_SSC_ObtainedMark
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.Student_Qualification_SSC_ObtainedMark : new int();
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.Student_Qualification_SSC_ObtainedMark = value;
            }

        }
        //[Required(ErrorMessage = "Field must be selected")]
        [Display(Name = "Student_Qualification_SSC_OutOfMark")]
        public int Student_Qualification_SSC_OutOfMark
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.Student_Qualification_SSC_OutOfMark : new int();
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.Student_Qualification_SSC_OutOfMark = value;
            }
        }
        //[Required(ErrorMessage = "Field should not be blank")]
        [Display(Name = "Student_Qualification_SSC_Region_Division_Board")]
        public string Student_Qualification_SSC_Region_Division_Board
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.Student_Qualification_SSC_Region_Division_Board : string.Empty;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.Student_Qualification_SSC_Region_Division_Board = value;
            }
        }
        //[Required(ErrorMessage = "Field should not be blank")]
        [Display(Name = "Student_Qualification_SSC_NameofInstitution")]
        public string Student_Qualification_SSC_NameofInstitution
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.Student_Qualification_SSC_NameofInstitution : string.Empty;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.Student_Qualification_SSC_NameofInstitution = value;
            }
        }
        #endregion SSC Details
        #region HSC Details

        //[Required(ErrorMessage = "Field must be selected")]
        [Display(Name = "Student_Qualification_HSC_MediumOfInstitution")]
        public int Student_Qualification_HSC_MediumOfInstitution
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.Student_Qualification_HSC_MediumOfInstitution : new int();
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.Student_Qualification_HSC_MediumOfInstitution = value;
            }
        }
        //[Required(ErrorMessage = "Field must be selected")]
        [Display(Name = "Student_Qualification_HSC_MonthOfPassing")]

        public int Student_Qualification_HSC_MonthOfPassing
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.Student_Qualification_HSC_MonthOfPassing : new int();
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.Student_Qualification_HSC_MonthOfPassing = value;
            }

        }
        //[Required(ErrorMessage = "Field must be selected")]
        [Display(Name = "Student_Qualification_HSC_YearOfPassing")]
        public int Student_Qualification_HSC_YearOfPassing
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.Student_Qualification_HSC_YearOfPassing : new int();
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.Student_Qualification_HSC_YearOfPassing = value;
            }

        }
        //[Required(ErrorMessage = "Field must be selected")]
        [Display(Name = "Student_Qualification_HSC_StreamID")]
        public int Student_Qualification_HSC_StreamID
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.Student_Qualification_HSC_StreamID : new int();
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.Student_Qualification_HSC_StreamID = value;
            }

        }
        //[Required(ErrorMessage = "Field should not be blank")]
        [Display(Name = "Student_Qualification_HSC_StreamOther")]
        public string Student_Qualification_HSC_StreamOther
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.Student_Qualification_HSC_StreamOther : string.Empty;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.Student_Qualification_HSC_StreamOther = value;
            }

        }
        //[Required(ErrorMessage = "Field should not be blank")]
        [Display(Name = "Student_Qualification_HSC_SingleAttempt")]
        public string Student_Qualification_HSC_SingleAttempt
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.Student_Qualification_HSC_SingleAttempt : string.Empty;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.Student_Qualification_HSC_SingleAttempt = value;
            }
        }
        //[Required(ErrorMessage = "Field should not be blank")]
        [Display(Name = "Student_Qualification_HSC_Class")]
        public string Student_Qualification_HSC_Class
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.Student_Qualification_HSC_Class : string.Empty;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.Student_Qualification_HSC_Class = value;
            }

        }

        //[Required(ErrorMessage = "Field must be selected")]
        [Display(Name = "Student_Qualification_HSC_ObtainedMark")]
        public int Student_Qualification_HSC_ObtainedMark
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.Student_Qualification_HSC_ObtainedMark : new int();
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.Student_Qualification_HSC_ObtainedMark = value;
            }

        }
        //[Required(ErrorMessage = "Field must be selected")]
        [Display(Name = "Student_Qualification_HSC_OutOfMark")]
        public int Student_Qualification_HSC_OutOfMark
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.Student_Qualification_HSC_OutOfMark : new int();
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.Student_Qualification_HSC_OutOfMark = value;
            }
        }
        //[Required(ErrorMessage = "Field must be selected")]
        [Display(Name = "Student_Qualification_HSC_Percent")]
        public int Student_Qualification_HSC_Percent
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.Student_Qualification_HSC_Percent : new int();
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.Student_Qualification_HSC_Percent = value;
            }

        }
        //[Required(ErrorMessage = "Field must be selected")]
        [Display(Name = "Student_Qualification_HSC_PCM_PVM_ObtainedMark")]
        public int Student_Qualification_HSC_PCM_PVM_ObtainedMark
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.Student_Qualification_HSC_PCM_PVM_ObtainedMark : new int();
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.Student_Qualification_HSC_PCM_PVM_ObtainedMark = value;
            }

        }
        //[Required(ErrorMessage = "Field must be selected")]
        [Display(Name = "Student_Qualification_HSC_PCM_PVM_OutOfMark")]
        public int Student_Qualification_HSC_PCM_PVM_OutOfMark
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.Student_Qualification_HSC_PCM_PVM_OutOfMark : new int();
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.Student_Qualification_HSC_PCM_PVM_OutOfMark = value;
            }
        }
        //[Required(ErrorMessage = "Field must be selected")]
        [Display(Name = "Student_Qualification_HSC_PCB_ObtainedMark")]
        public int Student_Qualification_HSC_PCB_ObtainedMark
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.Student_Qualification_HSC_PCB_ObtainedMark : new int();
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.Student_Qualification_HSC_PCB_ObtainedMark = value;
            }
        }
        //[Required(ErrorMessage = "Field must be selected")]
        [Display(Name = "Student_Qualification_HSC_PCB_OutOfMark")]
        public int Student_Qualification_HSC_PCB_OutOfMark
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.Student_Qualification_HSC_PCB_OutOfMark : new int();
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.Student_Qualification_HSC_PCB_OutOfMark = value;
            }
        }
        //[Required(ErrorMessage = "Field should not be blank")]
        [Display(Name = "Student_Qualification_HSC_Region_Division_Board")]
        public string Student_Qualification_HSC_Region_Division_Board
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.Student_Qualification_HSC_Region_Division_Board : string.Empty;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.Student_Qualification_HSC_Region_Division_Board = value;
            }
        }
        //[Required(ErrorMessage = "Field should not be blank")]
        [Display(Name = "Student_Qualification_HSC_NameofInstitution")]
        public string Student_Qualification_HSC_NameofInstitution
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.Student_Qualification_HSC_NameofInstitution : string.Empty;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.Student_Qualification_HSC_NameofInstitution = value;
            }
        }
        #endregion HSC Details
        #region Diploma / ITI Details
        //[Required(ErrorMessage = "Field must be selected")]
        [Display(Name = "Student_Qualification_Diploma_ITI_Details_MediumOfInstitution")]
        public int Student_Qualification_Diploma_ITI_Details_MediumOfInstitution
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.Student_Qualification_Diploma_ITI_Details_MediumOfInstitution : new int();
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.Student_Qualification_Diploma_ITI_Details_MediumOfInstitution = value;
            }

        }
        //[Required(ErrorMessage = "Field must be selected")]
        [Display(Name = "Student_Qualification_Diploma_ITI_Details_BranchId")]
        public int Student_Qualification_Diploma_ITI_Details_BranchId
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.Student_Qualification_Diploma_ITI_Details_BranchId : new int();
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.Student_Qualification_Diploma_ITI_Details_BranchId = value;
            }

        }
        //[Required(ErrorMessage = "Field must be selected")]
        [Display(Name = "Student_Qualification_Diploma_ITI_Details_BranchName")]
        public string Student_Qualification_Diploma_ITI_Details_BranchName
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.Student_Qualification_Diploma_ITI_Details_BranchName : string.Empty;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.Student_Qualification_Diploma_ITI_Details_BranchName = value;
            }
        }
        //[Required(ErrorMessage = "Field should not be blank")]
        [Display(Name = "Student_Qualification_Diploma_ITI_Details_ExamPattern")]
        public string Student_Qualification_Diploma_ITI_Details_ExamPattern
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.Student_Qualification_Diploma_ITI_Details_ExamPattern : string.Empty;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.Student_Qualification_Diploma_ITI_Details_ExamPattern = value;
            }

        }
        //[Required(ErrorMessage = "Field must be selected")]
        [Display(Name = "Student_Qualification_Diploma_ITI_Details_MonthOfPassing")]
        public int Student_Qualification_Diploma_ITI_Details_MonthOfPassing
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.Student_Qualification_Diploma_ITI_Details_MonthOfPassing : new int();
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.Student_Qualification_Diploma_ITI_Details_MonthOfPassing = value;
            }
        }
        //[Required(ErrorMessage = "Field must be selected")]
        [Display(Name = "Student_Qualification_Diploma_ITI_Details_YearOfPassing")]
        public int Student_Qualification_Diploma_ITI_Details_YearOfPassing
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.Student_Qualification_Diploma_ITI_Details_YearOfPassing : new int();
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.Student_Qualification_Diploma_ITI_Details_YearOfPassing = value;
            }

        }
        //[Required(ErrorMessage = "Field should not be blank")]
        [Display(Name = "Student_Qualification_Diploma_ITI_Details_Class")]
        public string Student_Qualification_Diploma_ITI_Details_Class
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.Student_Qualification_Diploma_ITI_Details_Class : string.Empty;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.Student_Qualification_Diploma_ITI_Details_Class = value;
            }
        }
        //[Required(ErrorMessage = "Field must be selected")]
        [Display(Name = "Student_Qualification_Diploma_ITI_Details_ObtainedMark")]
        public int Student_Qualification_Diploma_ITI_Details_ObtainedMark
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.Student_Qualification_Diploma_ITI_Details_ObtainedMark : new int();
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.Student_Qualification_Diploma_ITI_Details_ObtainedMark = value;
            }
        }
        //[Required(ErrorMessage = "Field must be selected")]
        [Display(Name = "Student_Qualification_Diploma_ITI_Details_OutOfMark")]
        public int Student_Qualification_Diploma_ITI_Details_OutOfMark
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.Student_Qualification_Diploma_ITI_Details_OutOfMark : new int();
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.Student_Qualification_Diploma_ITI_Details_OutOfMark = value;
            }
        }
        //[Required(ErrorMessage = "Field must be selected")]
        [Display(Name = "Student_Qualification_Diploma_ITI_Details_Percent")]
        public int Student_Qualification_Diploma_ITI_Details_Percent
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.Student_Qualification_Diploma_ITI_Details_Percent : new int();
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.Student_Qualification_Diploma_ITI_Details_Percent = value;
            }
        }
        //[Required(ErrorMessage = "Field should not be blank")]
        [Display(Name = "Student_Qualification_Diploma_ITI_Details_SingleAttempt")]
        public string Student_Qualification_Diploma_ITI_Details_SingleAttempt
        {

            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.Student_Qualification_Diploma_ITI_Details_SingleAttempt : string.Empty;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.Student_Qualification_Diploma_ITI_Details_SingleAttempt = value;
            }
        }
        //[Required(ErrorMessage = "Field should not be blank")]
        [Display(Name = "Student_Qualification_Diploma_ITI_Details_BoardEnrollmentNumber")]
        public string Student_Qualification_Diploma_ITI_Details_BoardEnrollmentNumber
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.Student_Qualification_Diploma_ITI_Details_BoardEnrollmentNumber : string.Empty;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.Student_Qualification_Diploma_ITI_Details_BoardEnrollmentNumber = value;
            }

        }
        //[Required(ErrorMessage = "Field should not be blank")]
        [Display(Name = "Student_Qualification_Diploma_ITI_Details_NameofInstitution")]
        public string Student_Qualification_Diploma_ITI_Details_NameofInstitution
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.Student_Qualification_Diploma_ITI_Details_NameofInstitution : string.Empty;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.Student_Qualification_Diploma_ITI_Details_NameofInstitution = value;
            }
        }
        //[Required(ErrorMessage = "Field should not be blank")]
        [Display(Name = "Student_Qualification_Diploma_ITI_Details_Board")]
        public string Student_Qualification_Diploma_ITI_Details_Board
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.Student_Qualification_Diploma_ITI_Details_Board : string.Empty;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.Student_Qualification_Diploma_ITI_Details_Board = value;
            }
        }
        //[Required(ErrorMessage = "Field should not be blank")]
        [Display(Name = "Student_Qualification_Diploma_ITI_Details_State")]
        public int Student_Qualification_Diploma_ITI_Details_State
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.Student_Qualification_Diploma_ITI_Details_State : new int();
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.Student_Qualification_Diploma_ITI_Details_State = value;
            }
        }

        //[Required(ErrorMessage = "Field should not be blank")]
        [Display(Name = "Student_Qualification_Diploma_ITI_Details_StateOther")]
        public string Student_Qualification_Diploma_ITI_Details_StateOther
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.Student_Qualification_Diploma_ITI_Details_StateOther : string.Empty;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.Student_Qualification_Diploma_ITI_Details_StateOther = value;
            }
        }
        public int Student_Qualification_Diploma_ITI_Details_CountryId
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.Student_Qualification_Diploma_ITI_Details_CountryId : new int();
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.Student_Qualification_Diploma_ITI_Details_CountryId = value;
            }
        }

        #endregion Diploma / ITI Details

        #region Degree Details
        //[Required(ErrorMessage = "Field must be selected")]
        [Display(Name = "Student_Qualification_DegreeDetails_MediumOfInstitution")]
        public int Student_Qualification_DegreeDetails_MediumOfInstitution
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.Student_Qualification_DegreeDetails_MediumOfInstitution : new int();
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.Student_Qualification_DegreeDetails_MediumOfInstitution = value;
            }

        }
        //[Required(ErrorMessage = "Field must be selected")]
        [Display(Name = "Student_Qualification_DegreeDetails_BranchId")]
        public int Student_Qualification_DegreeDetails_BranchId
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.Student_Qualification_DegreeDetails_BranchId : new int();
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.Student_Qualification_DegreeDetails_BranchId = value;
            }

        }
        //[Required(ErrorMessage = "Field must be selected")]
        [Display(Name = "Student_Qualification_DegreeDetails_BranchName")]
        public string Student_Qualification_DegreeDetails_BranchName
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.Student_Qualification_DegreeDetails_BranchName : string.Empty;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.Student_Qualification_DegreeDetails_BranchName = value;
            }
        }
        //[Required(ErrorMessage = "Field should not be blank")]
        [Display(Name = "Student_Qualification_DegreeDetails_ExamPattern")]
        public string Student_Qualification_DegreeDetails_ExamPattern
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.Student_Qualification_DegreeDetails_ExamPattern : string.Empty;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.Student_Qualification_DegreeDetails_ExamPattern = value;
            }

        }
        //[Required(ErrorMessage = "Field must be selected")]
        [Display(Name = "Student_Qualification_DegreeDetails_MonthOfPassing")]
        public int Student_Qualification_DegreeDetails_MonthOfPassing
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.Student_Qualification_DegreeDetails_MonthOfPassing : new int();
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.Student_Qualification_DegreeDetails_MonthOfPassing = value;
            }
        }
        //[Required(ErrorMessage = "Field must be selected")]
        [Display(Name = "Student_Qualification_DegreeDetails_YearOfPassing")]
        public int Student_Qualification_DegreeDetails_YearOfPassing
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.Student_Qualification_DegreeDetails_YearOfPassing : new int();
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.Student_Qualification_DegreeDetails_YearOfPassing = value;
            }

        }
        //[Required(ErrorMessage = "Field should not be blank")]
        [Display(Name = "Student_Qualification_DegreeDetails_Class")]
        public string Student_Qualification_DegreeDetails_Class
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.Student_Qualification_DegreeDetails_Class : string.Empty;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.Student_Qualification_DegreeDetails_Class = value;
            }
        }
        //[Required(ErrorMessage = "Field must be selected")]
        [Display(Name = "Student_Qualification_DegreeDetails_ObtainedMark")]
        public int Student_Qualification_DegreeDetails_ObtainedMark
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.Student_Qualification_DegreeDetails_ObtainedMark : new int();
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.Student_Qualification_DegreeDetails_ObtainedMark = value;
            }
        }
        //[Required(ErrorMessage = "Field must be selected")]
        [Display(Name = "Student_Qualification_DegreeDetails_OutOfMark")]
        public int Student_Qualification_DegreeDetails_OutOfMark
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.Student_Qualification_DegreeDetails_OutOfMark : new int();
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.Student_Qualification_DegreeDetails_OutOfMark = value;
            }
        }
        //[Required(ErrorMessage = "Field must be selected")]
        [Display(Name = "Student_Qualification_DegreeDetails_Percent")]
        public int Student_Qualification_DegreeDetails_Percent
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.Student_Qualification_DegreeDetails_Percent : new int();
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.Student_Qualification_DegreeDetails_Percent = value;
            }
        }
        //[Required(ErrorMessage = "Field should not be blank")]
        [Display(Name = "Student_Qualification_DegreeDetails_SingleAttempt")]
        public string Student_Qualification_DegreeDetails_SingleAttempt
        {

            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.Student_Qualification_DegreeDetails_SingleAttempt : string.Empty;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.Student_Qualification_DegreeDetails_SingleAttempt = value;
            }
        }
        //[Required(ErrorMessage = "Field should not be blank")]
        [Display(Name = "Student_Qualification_DegreeDetails_BoardEnrollmentNumber")]
        public string Student_Qualification_DegreeDetails_BoardEnrollmentNumber
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.Student_Qualification_DegreeDetails_BoardEnrollmentNumber : string.Empty;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.Student_Qualification_DegreeDetails_BoardEnrollmentNumber = value;
            }

        }
        //[Required(ErrorMessage = "Field should not be blank")]
        [Display(Name = "Student_Qualification_DegreeDetails_NameofInstitution")]
        public string Student_Qualification_DegreeDetails_NameofInstitution
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.Student_Qualification_DegreeDetails_NameofInstitution : string.Empty;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.Student_Qualification_DegreeDetails_NameofInstitution = value;
            }
        }
        //[Required(ErrorMessage = "Field must be selected")]
        [Display(Name = "Student_Qualification_DegreeDetails_UniversityId")]
        public int Student_Qualification_DegreeDetails_UniversityId
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.Student_Qualification_DegreeDetails_UniversityId : new int();
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.Student_Qualification_DegreeDetails_UniversityId = value;
            }
        }
        //[Required(ErrorMessage = "Field should not be blank")]
        [Display(Name = "Student_Qualification_DegreeDetails_UniversityNameOther")]
        public string Student_Qualification_DegreeDetails_UniversityName
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.Student_Qualification_DegreeDetails_UniversityName : string.Empty;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.Student_Qualification_DegreeDetails_UniversityName = value;
            }
        }
        //[Required(ErrorMessage = "Field should not be blank")]
        [Display(Name = "Student_Qualification_DegreeDetails_State")]
        public int Student_Qualification_DegreeDetails_State
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.Student_Qualification_DegreeDetails_State : new int();
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.Student_Qualification_DegreeDetails_State = value;
            }
        }
        //[Required(ErrorMessage = "Field should not be blank")]
        [Display(Name = "Student_Qualification_DegreeDetails_StateOther")]
        public string Student_Qualification_DegreeDetails_StateOther
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.Student_Qualification_DegreeDetails_StateOther : string.Empty;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.Student_Qualification_DegreeDetails_StateOther = value;
            }
        }
        //[Required(ErrorMessage = "Field should not be blank")]
        [Display(Name = "Student_Qualification_DegreeDetails_Degree")]
        public string Student_Qualification_DegreeDetails_Degree
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.Student_Qualification_DegreeDetails_Degree : string.Empty;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.Student_Qualification_DegreeDetails_Degree = value;
            }
        }

        public int Student_Qualification_DegreeDetails_CountryId
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.Student_Qualification_DegreeDetails_CountryId : new int();
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.Student_Qualification_DegreeDetails_CountryId = value;
            }
        }

        #endregion DegreeDetails

        #region Post Graduation Details
        //[Required(ErrorMessage = "Field must be selected")]
        [Display(Name = "Student_Qualification_PostGraduationDetails_MediumOfInstitution")]
        public int Student_Qualification_PostGraduationDetails_MediumOfInstitution
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.Student_Qualification_PostGraduationDetails_MediumOfInstitution : new int();
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.Student_Qualification_PostGraduationDetails_MediumOfInstitution = value;
            }

        }
        //[Required(ErrorMessage = "Field must be selected")]
        [Display(Name = "Student_Qualification_PostGraduationDetails_BranchId")]
        public int Student_Qualification_PostGraduationDetails_BranchId
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.Student_Qualification_PostGraduationDetails_BranchId : new int();
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.Student_Qualification_PostGraduationDetails_BranchId = value;
            }

        }
        //[Required(ErrorMessage = "Field must be selected")]
        [Display(Name = "Student_Qualification_PostGraduationDetails_BranchName")]
        public string Student_Qualification_PostGraduationDetails_BranchName
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.Student_Qualification_PostGraduationDetails_BranchName : string.Empty;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.Student_Qualification_PostGraduationDetails_BranchName = value;
            }
        }
        //[Required(ErrorMessage = "Field should not be blank")]
        [Display(Name = "Student_Qualification_PostGraduationDetails_ExamPattern")]
        public string Student_Qualification_PostGraduationDetails_ExamPattern
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.Student_Qualification_PostGraduationDetails_ExamPattern : string.Empty;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.Student_Qualification_PostGraduationDetails_ExamPattern = value;
            }

        }
        //[Required(ErrorMessage = "Field must be selected")]
        [Display(Name = "Student_Qualification_PostGraduationDetails_MonthOfPassing")]
        public int Student_Qualification_PostGraduationDetails_MonthOfPassing
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.Student_Qualification_PostGraduationDetails_MonthOfPassing : new int();
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.Student_Qualification_PostGraduationDetails_MonthOfPassing = value;
            }
        }
        //[Required(ErrorMessage = "Field must be selected")]
        [Display(Name = "Student_Qualification_PostGraduationDetails_YearOfPassing")]
        public int Student_Qualification_PostGraduationDetails_YearOfPassing
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.Student_Qualification_PostGraduationDetails_YearOfPassing : new int();
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.Student_Qualification_PostGraduationDetails_YearOfPassing = value;
            }

        }
        //[Required(ErrorMessage = "Field should not be blank")]
        [Display(Name = "Student_Qualification_PostGraduationDetails_Class")]
        public string Student_Qualification_PostGraduationDetails_Class
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.Student_Qualification_PostGraduationDetails_Class : string.Empty;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.Student_Qualification_PostGraduationDetails_Class = value;
            }
        }
        //[Required(ErrorMessage = "Field must be selected")]
        [Display(Name = "Student_Qualification_PostGraduationDetails_ObtainedMark")]
        public int Student_Qualification_PostGraduationDetails_ObtainedMark
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.Student_Qualification_PostGraduationDetails_ObtainedMark : new int();
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.Student_Qualification_PostGraduationDetails_ObtainedMark = value;
            }
        }
        //[Required(ErrorMessage = "Field must be selected")]
        [Display(Name = "Student_Qualification_PostGraduationDetails_OutOfMark")]
        public int Student_Qualification_PostGraduationDetails_OutOfMark
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.Student_Qualification_PostGraduationDetails_OutOfMark : new int();
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.Student_Qualification_PostGraduationDetails_OutOfMark = value;
            }
        }
        //[Required(ErrorMessage = "Field must be selected")]
        [Display(Name = "Student_Qualification_PostGraduationDetails_Percent")]
        public int Student_Qualification_PostGraduationDetails_Percent
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.Student_Qualification_PostGraduationDetails_Percent : new int();
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.Student_Qualification_PostGraduationDetails_Percent = value;
            }
        }
        //[Required(ErrorMessage = "Field should not be blank")]
        [Display(Name = "Student_Qualification_PostGraduationDetails_SingleAttempt")]
        public string Student_Qualification_PostGraduationDetails_SingleAttempt
        {

            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.Student_Qualification_PostGraduationDetails_SingleAttempt : string.Empty;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.Student_Qualification_PostGraduationDetails_SingleAttempt = value;
            }
        }
        //[Required(ErrorMessage = "Field should not be blank")]
        [Display(Name = "Student_Qualification_PostGraduationDetails_BoardEnrollmentNumber")]
        public string Student_Qualification_PostGraduationDetails_BoardEnrollmentNumber
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.Student_Qualification_PostGraduationDetails_BoardEnrollmentNumber : string.Empty;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.Student_Qualification_PostGraduationDetails_BoardEnrollmentNumber = value;
            }

        }
        //[Required(ErrorMessage = "Field should not be blank")]
        [Display(Name = "Student_Qualification_PostGraduationDetails_NameofInstitution")]
        public string Student_Qualification_PostGraduationDetails_NameofInstitution
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.Student_Qualification_PostGraduationDetails_NameofInstitution : string.Empty;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.Student_Qualification_PostGraduationDetails_NameofInstitution = value;
            }
        }
        //[Required(ErrorMessage = "Field must be selected")]
        [Display(Name = "Student_Qualification_PostGraduationDetails_UniversityId")]
        public int Student_Qualification_PostGraduationDetails_UniversityId
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.Student_Qualification_PostGraduationDetails_UniversityId : new int();
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.Student_Qualification_PostGraduationDetails_UniversityId = value;
            }
        }
        //[Required(ErrorMessage = "Field should not be blank")]
        [Display(Name = "Student_Qualification_PostGraduationDetails_UniversityName")]
        public string Student_Qualification_PostGraduationDetails_UniversityName
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.Student_Qualification_PostGraduationDetails_UniversityName : string.Empty;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.Student_Qualification_PostGraduationDetails_UniversityName = value;
            }
        }

        //[Required(ErrorMessage = "Field should not be blank")]
        [Display(Name = "Student_Qualification_PostGraduationDetails_State")]
        public int Student_Qualification_PostGraduationDetails_State
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.Student_Qualification_PostGraduationDetails_State : new int();
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.Student_Qualification_PostGraduationDetails_State = value;
            }
        }
        //[Required(ErrorMessage = "Field should not be blank")]
        [Display(Name = "Student_Qualification_PostGraduationDetails_StateOther")]
        public string Student_Qualification_PostGraduationDetails_StateOther
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.Student_Qualification_PostGraduationDetails_StateOther : string.Empty;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.Student_Qualification_PostGraduationDetails_StateOther = value;
            }
        }
        //[Required(ErrorMessage = "Field should not be blank")]
        [Display(Name = "Student_Qualification_PostGraduationDetails_PostGraduation")]
        public string Student_Qualification_PostGraduationDetails_PostGraduation
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.Student_Qualification_PostGraduationDetails_PostGraduation : string.Empty;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.Student_Qualification_PostGraduationDetails_PostGraduation = value;
            }
        }

        public int Student_Qualification_PostGraduationDetails_CountryId
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.Student_Qualification_PostGraduationDetails_CountryId : new int();
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.Student_Qualification_PostGraduationDetails_CountryId = value;
            }
        }
        #endregion Post Graduation Details
        #endregion Qualification Details


        # region DTE & Scholarship Information

        # region DTE  Information
        //[Required(ErrorMessage = "Field should not be blank")]
        [Display(Name = "Student_DTE_DTEUserID")]
        public string Student_DTE_DTEUserID
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.Student_DTE_DTEUserID : string.Empty;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.Student_DTE_DTEUserID = value;
            }
        }
        //[Required(ErrorMessage = "Field should not be blank")]
        [Display(Name = "Student_DTE_DTEPassword")]
        public string Student_DTE_DTEPassword
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.Student_DTE_DTEPassword : string.Empty;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.Student_DTE_DTEPassword = value;
            }
        }
        //[Required(ErrorMessage = "Field should not be blank")]
        [Display(Name = "Student_DTE_DTESrNo")]
        public string Student_DTE_DTESrNo
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.Student_DTE_DTESrNo : string.Empty;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.Student_DTE_DTESrNo = value;
            }
        }
        //[Required(ErrorMessage = "Field should not be blank")]
        [Display(Name = "Student_DTE_DTEMeritNo")]
        public string Student_DTE_DTEMeritNo
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.Student_DTE_DTEMeritNo : string.Empty;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.Student_DTE_DTEMeritNo = value;
            }
        }
        //[Required(ErrorMessage = "Field must be selected")]
        [Display(Name = "Student_DTE_AdmissionTypeId")]
        public int Student_DTE_AdmissionTypeId
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.Student_DTE_AdmissionTypeId : new int();
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.Student_DTE_AdmissionTypeId = value;
            }
        }
        //[Required(ErrorMessage = "Field must be selected")]
        [Display(Name = "Student_DTE_AdmissionRound")]

        public int Student_DTE_AdmissionRound
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.Student_DTE_AdmissionRound : new int();
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.Student_DTE_AdmissionRound = value;
            }
        }
        //[Required(ErrorMessage = "Field must be selected")]
        [Display(Name = "Student_DTE_AdmissionCategoryId")]
        public int Student_DTE_AdmissionCategoryId
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.Student_DTE_AdmissionCategoryId : new int();
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.Student_DTE_AdmissionCategoryId = value;
            }
        }
        //[Required(ErrorMessage = "Field should not be blank")]
        [Display(Name = "Student_DTE_DTESeatNo")]
        public string Student_DTE_DTESeatNo
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.Student_DTE_DTESeatNo : string.Empty;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.Student_DTE_DTESeatNo = value;
            }
        }
        //[Required(ErrorMessage = "Field must be selected")]
        [Display(Name = "Student_DTE_QualifyingExamId")]
        public int Student_DTE_QualifyingExamId
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.Student_DTE_QualifyingExamId : new int();
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.Student_DTE_QualifyingExamId = value;
            }
        }

        //[Required(ErrorMessage = "Field should not be blank")]
        [Display(Name = "Student_DTE_QualifyingExamName")]
        public string Student_DTE_QualifyingExamName
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.Student_DTE_QualifyingExamName : string.Empty;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.Student_DTE_QualifyingExamName = value;
            }
        }
        //[Required(ErrorMessage = "Field must be selected")]
        [Display(Name = "Student_DTE_QualifyingExamMarks")]
        public int Student_DTE_QualifyingExamMarks
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.Student_DTE_QualifyingExamMarks : new int();
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.Student_DTE_QualifyingExamMarks = value;
            }
        }
        # endregion DTE  Information

        # region  Scholarship Information
        //[Required(ErrorMessage = "Field should not be blank")]
        [Display(Name = "Student_Scholarship_ScholarshipId")]
        public string Student_Scholarship_ScholarshipId
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.Student_Scholarship_ScholarshipId : string.Empty;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.Student_Scholarship_ScholarshipId = value;
            }
        }
        //[Required(ErrorMessage = "Field should not be blank")]
        [Display(Name = "Student_Scholarship_ScholarshipType")]
        public string Student_Scholarship_ScholarshipType
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.Student_Scholarship_ScholarshipType : string.Empty;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.Student_Scholarship_ScholarshipType = value;
            }
        }
        //[Required(ErrorMessage = "Field must be selected")]
        [Display(Name = "Student_Scholarship_CastCategoryId")]
        public int Student_Scholarship_CastCategoryId
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.Student_Scholarship_CastCategoryId : new int();
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.Student_Scholarship_CastCategoryId = value;
            }
        }
        //[Required(ErrorMessage = "Field should not be blank")]
        [Display(Name = "Student_Scholarship_CastCategoryOther")]
        public string Student_Scholarship_CastCategoryOther
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.Student_Scholarship_CastCategoryOther : string.Empty;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.Student_Scholarship_CastCategoryOther = value;
            }
        }
        //[Required(ErrorMessage = "Field should not be blank")]
        [Display(Name = "Student_Scholarship_AadhaarCardNo")]
        public string Student_Scholarship_AadhaarCardNo
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.Student_Scholarship_AadhaarCardNo : string.Empty;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.Student_Scholarship_AadhaarCardNo = value;
            }
        }
        public double Student_Scholarship_AnnualIncome
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.Student_Scholarship_AnnualIncome : new double();
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.Student_Scholarship_AnnualIncome = value;
            }
        }
        //[Required(ErrorMessage = "Field must be selected")]
        [Display(Name = "Student_QualifyingExamId")]
        public int Student_Scholarship_NoofSibling
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.Student_Scholarship_NoofSibling : new int();
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.Student_Scholarship_NoofSibling = value;
            }
        }
        //[Required(ErrorMessage = "Field must be selected")]
        [Display(Name = "Student_QualifyingExamId")]
        public int Student_Scholarship_ChildNoOutofSibling
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.Student_Scholarship_ChildNoOutofSibling : new int();
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.Student_Scholarship_ChildNoOutofSibling = value;
            }
        }
        //[Required(ErrorMessage = "Field should not be blank")]
        [Display(Name = "Student_Scholarship_HostelDayScholar")]
        public string Student_Scholarship_HostelDayScholar
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.Student_Scholarship_HostelDayScholar : string.Empty;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.Student_Scholarship_HostelDayScholar = value;
            }
        }

        //[Required(ErrorMessage = "Field should not be blank")]
        [Display(Name = "Student_Scholarship_Bank_BranchName")]
        public string Student_Scholarship_Bank_BranchName
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.Student_Scholarship_Bank_BranchName : string.Empty;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.Student_Scholarship_Bank_BranchName = value;
            }
        }
        //[Required(ErrorMessage = "Field should not be blank")]
        [Display(Name = "Student_Scholarship_Bank_AC_No")]
        public string Student_Scholarship_Bank_AC_No
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.Student_Scholarship_Bank_AC_No : string.Empty;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.Student_Scholarship_Bank_AC_No = value;
            }
        }
        //[Required(ErrorMessage = "Field should not be blank")]
        [Display(Name = "Student_Scholarship_Bank_IFSCCode")]
        public string Student_Scholarship_Bank_IFSCCode
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.Student_Scholarship_Bank_IFSCCode : string.Empty;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.Student_Scholarship_Bank_IFSCCode = value;
            }
        }
        //[Required(ErrorMessage = "Field should not be blank")]
        [Display(Name = "Student_Scholarship_Bank_MICRCode")]
        public string Student_Scholarship_Bank_MICRCode
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.Student_Scholarship_Bank_MICRCode : string.Empty;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.Student_Scholarship_Bank_MICRCode = value;
            }
        }
        # endregion Scholarship Information
        # endregion DTE & Scholarship Information


        #region Student Documents Information
        #region Admission Documents Information


        #region Admission Documents Information
        //[Required(ErrorMessage = "Field must be selected")]
        [Display(Name = "Student_AdmissionDocuments_JETMarkSheet")]
        public bool Student_AdmissionDocuments_JETMarkSheet
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.Student_AdmissionDocuments_JETMarkSheet : false;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.Student_AdmissionDocuments_JETMarkSheet = value;
            }
        }
        //[Required(ErrorMessage = "Field must be selected")]
        [Display(Name = "Student_AdmissionDocuments_AllotmentLetter")]
        public bool Student_AdmissionDocuments_AllotmentLetter
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.Student_AdmissionDocuments_AllotmentLetter : false;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.Student_AdmissionDocuments_AllotmentLetter = value;
            }
        }
        //[Required(ErrorMessage = "Field must be selected")]
        [Display(Name = "Student_AdmissionDocuments_TenthMarkSheet")]
        public bool Student_AdmissionDocuments_TenthMarkSheet
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.Student_AdmissionDocuments_TenthMarkSheet : false;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.Student_AdmissionDocuments_TenthMarkSheet = value;
            }
        }
        //[Required(ErrorMessage = "Field must be selected")]
        [Display(Name = "Student_AdmissionDocuments_TwelvethMarkSheet")]
        public bool Student_AdmissionDocuments_TwelvethMarkSheet
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.Student_AdmissionDocuments_TwelvethMarkSheet : false;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.Student_AdmissionDocuments_TwelvethMarkSheet = value;
            }
        }
        //[Required(ErrorMessage = "Field must be selected")]
        [Display(Name = "Student_AdmissionDocuments_AllDiplomaMarksheet")]
        public bool Student_AdmissionDocuments_AllDiplomaMarksheet
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.Student_AdmissionDocuments_AllDiplomaMarksheet : false;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.Student_AdmissionDocuments_AllDiplomaMarksheet = value;
            }
        }
        //[Required(ErrorMessage = "Field must be selected")]
        [Display(Name = "Student_AdmissionDocuments_LeavingCertificate")]
        public bool Student_AdmissionDocuments_LeavingCertificate
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.Student_AdmissionDocuments_LeavingCertificate : false;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.Student_AdmissionDocuments_LeavingCertificate = value;
            }
        }
        //[Required(ErrorMessage = "Field must be selected")]
        [Display(Name = "Student_AdmissionDocuments_Domicile_BirthCertificate")]

        public bool Student_AdmissionDocuments_Domicile_BirthCertificate
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.Student_AdmissionDocuments_Domicile_BirthCertificate : false;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.Student_AdmissionDocuments_Domicile_BirthCertificate = value;
            }
        }
        //[Required(ErrorMessage = "Field must be selected")]
        [Display(Name = "Student_AdmissionDocuments_NationalityCertificate")]
        public bool Student_AdmissionDocuments_NationalityCertificate
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.Student_AdmissionDocuments_NationalityCertificate : false;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.Student_AdmissionDocuments_NationalityCertificate = value;
            }
        }
        //[Required(ErrorMessage = "Field must be selected")]
        [Display(Name = "Student_AdmissionDocuments_CasteCertificate")]
        public bool Student_AdmissionDocuments_CasteCertificate
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.Student_AdmissionDocuments_CasteCertificate : false;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.Student_AdmissionDocuments_CasteCertificate = value;
            }
        }
        //[Required(ErrorMessage = "Field must be selected")]
        [Display(Name = "Student_AdmissionDocuments_CasteValidityCertificate")]
        public bool Student_AdmissionDocuments_CasteValidityCertificate
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.Student_AdmissionDocuments_CasteValidityCertificate : false;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.Student_AdmissionDocuments_CasteValidityCertificate = value;
            }
        }
        //[Required(ErrorMessage = "Field must be selected")]
        [Display(Name = "Student_AdmissionDocuments_NonCreamylayerCertificate")]
        public bool Student_AdmissionDocuments_NonCreamylayerCertificate
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.Student_AdmissionDocuments_NonCreamylayerCertificate : false;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.Student_AdmissionDocuments_NonCreamylayerCertificate = value;
            }
        }
        //[Required(ErrorMessage = "Field must be selected")]
        [Display(Name = "Student_AdmissionDocuments_EquivalenceCertificate")]

        public bool Student_AdmissionDocuments_EquivalenceCertificate
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.Student_AdmissionDocuments_EquivalenceCertificate : false;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.Student_AdmissionDocuments_EquivalenceCertificate = value;
            }
        }
        //[Required(ErrorMessage = "Field must be selected")]
        [Display(Name = "Student_AdmissionDocuments_MigrationCertificate")]
        public bool Student_AdmissionDocuments_MigrationCertificate
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.Student_AdmissionDocuments_MigrationCertificate : false;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.Student_AdmissionDocuments_MigrationCertificate = value;
            }
        }
        //[Required(ErrorMessage = "Field must be selected")]
        [Display(Name = "Student_AdmissionDocuments_GapCertificate")]
        public bool Student_AdmissionDocuments_GapCertificate
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.Student_AdmissionDocuments_GapCertificate : false;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.Student_AdmissionDocuments_GapCertificate = value;
            }
        }
        //[Required(ErrorMessage = "Field must be selected")]
        [Display(Name = "Student_AdmissionDocuments_AntiRaggingAffidavit")]
        public bool Student_AdmissionDocuments_AntiRaggingAffidavit
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.Student_AdmissionDocuments_AntiRaggingAffidavit : false;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.Student_AdmissionDocuments_AntiRaggingAffidavit = value;
            }
        }
        //[Required(ErrorMessage = "Field must be selected")]
        [Display(Name = "Student_AdmissionDocuments_Proforma_Fand_F1_On_DoctorsLetter_Head")]
        public bool Student_AdmissionDocuments_Proforma_Fand_F1_On_DoctorsLetter_Head
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.Student_AdmissionDocuments_Proforma_Fand_F1_On_DoctorsLetter_Head : false;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.Student_AdmissionDocuments_Proforma_Fand_F1_On_DoctorsLetter_Head = value;
            }
        }
        //[Required(ErrorMessage = "Field must be selected")]
        [Display(Name = "Student_AdmissionDocuments_Proforma_I")]
        public bool Student_AdmissionDocuments_Proforma_I
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.Student_AdmissionDocuments_Proforma_I : false;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.Student_AdmissionDocuments_Proforma_I = value;
            }
        }
        //[Required(ErrorMessage = "Field must be selected")]
        [Display(Name = "Student_AdmissionDocuments_ProformaG1")]
        public bool Student_AdmissionDocuments_ProformaG1
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.Student_AdmissionDocuments_ProformaG1 : false;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.Student_AdmissionDocuments_ProformaG1 = value;
            }
        }
        //[Required(ErrorMessage = "Field must be selected")]
        [Display(Name = "Student_AdmissionDocuments_ProformaG2")]
        public bool Student_AdmissionDocuments_ProformaG2
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.Student_AdmissionDocuments_ProformaG2 : false;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.Student_AdmissionDocuments_ProformaG2 = value;
            }
        }
        //[Required(ErrorMessage = "Field must be selected")]
        [Display(Name = "Student_AdmissionDocuments_Proforma_C_D_E")]
        public bool Student_AdmissionDocuments_Proforma_C_D_E
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.Student_AdmissionDocuments_Proforma_C_D_E : false;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.Student_AdmissionDocuments_Proforma_C_D_E = value;
            }
        }
        //[Required(ErrorMessage = "Field must be selected")]
        [Display(Name = "Student_AdmissionDocuments_FathersIncomeCertificate")]
        public bool Student_AdmissionDocuments_FathersIncomeCertificate
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.Student_AdmissionDocuments_FathersIncomeCertificate : false;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.Student_AdmissionDocuments_FathersIncomeCertificate = value;
            }
        }
        //[Required(ErrorMessage = "Field must be selected")]
        [Display(Name = "Student_AdmissionDocuments_AadharCardXerox")]
        public bool Student_AdmissionDocuments_AadharCardXerox
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.Student_AdmissionDocuments_AadharCardXerox : false;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.Student_AdmissionDocuments_AadharCardXerox = value;
            }
        }
        //[Required(ErrorMessage = "Field must be selected")]
        [Display(Name = "Student_AdmissionDocuments_B_WPhoto_I_card_size")]
        public bool Student_AdmissionDocuments_B_WPhoto_I_card_size
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.Student_AdmissionDocuments_B_WPhoto_I_card_size : false;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.Student_AdmissionDocuments_B_WPhoto_I_card_size = value;
            }
        }
        //[Required(ErrorMessage = "Field must be selected")]
        [Display(Name = "Student_AdmissionDocuments_Colour_photo")]
        public bool Student_AdmissionDocuments_Colour_photo
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.Student_AdmissionDocuments_Colour_photo : false;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.Student_AdmissionDocuments_Colour_photo = value;
            }
        }
        #endregion Admission Documents Information
        #region For PG Students
        //[Required(ErrorMessage = "Field must be selected")]
        [Display(Name = "Student_AdmissionDocuments_PGStudents_DegreeMarksheet")]
        public bool Student_AdmissionDocuments_PGStudents_DegreeMarksheet
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.Student_AdmissionDocuments_PGStudents_DegreeMarksheet : false;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.Student_AdmissionDocuments_PGStudents_DegreeMarksheet = value;
            }
        }
        //[Required(ErrorMessage = "Field must be selected")]
        [Display(Name = "Student_AdmissionDocuments_PGStudents_DegreeCertificate")]
        public bool Student_AdmissionDocuments_PGStudents_DegreeCertificate
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.Student_AdmissionDocuments_PGStudents_DegreeCertificate : false;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.Student_AdmissionDocuments_PGStudents_DegreeCertificate = value;
            }
        }
        //[Required(ErrorMessage = "Field must be selected")]
        [Display(Name = "Student_AdmissionDocuments_PGStudents_GateScoreCard")]
        public bool Student_AdmissionDocuments_PGStudents_GateScoreCard
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.Student_AdmissionDocuments_PGStudents_GateScoreCard : false;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.Student_AdmissionDocuments_PGStudents_GateScoreCard = value;
            }
        }
        //[Required(ErrorMessage = "Field must be selected")]
        [Display(Name = "Student_AdmissionDocuments_PGStudents_SponsorshipLetterforSponsoredCandidate")]
        public bool Student_AdmissionDocuments_PGStudents_SponsorshipLetterforSponsoredCandidate
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.Student_AdmissionDocuments_PGStudents_SponsorshipLetterforSponsoredCandidate : false;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.Student_AdmissionDocuments_PGStudents_SponsorshipLetterforSponsoredCandidate = value;
            }
        }
        #endregion For PG Students
        #region Comments
        //[Required(ErrorMessage = "Field should not be blank")]
        [Display(Name = "Student_AdmissionDocuments_Comments")]
        public string Student_AdmissionDocuments_Comments
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.Student_AdmissionDocuments_Comments : string.Empty;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.Student_AdmissionDocuments_Comments = value;
            }
        }
        #endregion Comments
        #endregion Admission Documents Information

        #region Scholarship Documents Information
        #region Scholarship Documents Information
        //[Required(ErrorMessage = "Field must be selected")]
        [Display(Name = "Student_ScholarshipDocuments_IncomeCertificateOriginal")]
        public bool Student_ScholarshipDocuments_IncomeCertificateOriginal
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.Student_ScholarshipDocuments_IncomeCertificateOriginal : false;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.Student_ScholarshipDocuments_IncomeCertificateOriginal = value;
            }
        }
        //[Required(ErrorMessage = "Field must be selected")]
        [Display(Name = "Student_ScholarshipDocuments_TenthMarkSheet")]
        public bool Student_ScholarshipDocuments_TenthMarkSheet
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.Student_ScholarshipDocuments_TenthMarkSheet : false;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.Student_ScholarshipDocuments_TenthMarkSheet = value;
            }
        }
        //[Required(ErrorMessage = "Field must be selected")]
        [Display(Name = "Student_ScholarshipDocuments_TwelvethMarkSheet")]
        public bool Student_ScholarshipDocuments_TwelvethMarkSheet
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.Student_ScholarshipDocuments_TwelvethMarkSheet : false;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.Student_ScholarshipDocuments_TwelvethMarkSheet = value;
            }
        }
        //[Required(ErrorMessage = "Field must be selected")]
        [Display(Name = "Student_ScholarshipDocuments_AdharCard")]
        public bool Student_ScholarshipDocuments_AdharCard
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.Student_ScholarshipDocuments_AdharCard : false;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.Student_ScholarshipDocuments_AdharCard = value;
            }
        }
        //[Required(ErrorMessage = "Field must be selected")]
        [Display(Name = "Student_ScholarshipDocuments_AdmissionConfirmationLetter")]
        public bool Student_ScholarshipDocuments_AdmissionConfirmationLetter
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.Student_ScholarshipDocuments_AdmissionConfirmationLetter : false;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.Student_ScholarshipDocuments_AdmissionConfirmationLetter = value;
            }
        }
        //[Required(ErrorMessage = "Field must be selected")]
        [Display(Name = "Student_ScholarshipDocuments_AllotmentLetter")]
        public bool Student_ScholarshipDocuments_AllotmentLetter
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.Student_ScholarshipDocuments_AllotmentLetter : false;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.Student_ScholarshipDocuments_AllotmentLetter = value;
            }
        }
        //[Required(ErrorMessage = "Field must be selected")]
        [Display(Name = "Student_ScholarshipDocuments_BankPassBookXerox")]
        public bool Student_ScholarshipDocuments_BankPassBookXerox
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.Student_ScholarshipDocuments_BankPassBookXerox : false;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.Student_ScholarshipDocuments_BankPassBookXerox = value;
            }
        }
        //[Required(ErrorMessage = "Field must be selected")]
        [Display(Name = "Student_ScholarshipDocuments_CastCertificate")]
        public bool Student_ScholarshipDocuments_CastCertificate
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.Student_ScholarshipDocuments_CastCertificate : false;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.Student_ScholarshipDocuments_CastCertificate = value;
            }
        }
        //[Required(ErrorMessage = "Field must be selected")]
        [Display(Name = "Student_ScholarshipDocuments_CastValidity")]
        public bool Student_ScholarshipDocuments_CastValidity
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.Student_ScholarshipDocuments_CastValidity : false;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.Student_ScholarshipDocuments_CastValidity = value;
            }
        }
        //[Required(ErrorMessage = "Field must be selected")]
        [Display(Name = "Student_ScholarshipDocuments_Domicile")]
        public bool Student_ScholarshipDocuments_Domicile
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.Student_ScholarshipDocuments_Domicile : false;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.Student_ScholarshipDocuments_Domicile = value;
            }
        }
        //[Required(ErrorMessage = "Field must be selected")]
        [Display(Name = "Student_ScholarshipDocuments_Receipt")]
        public bool Student_ScholarshipDocuments_Receipt
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.Student_ScholarshipDocuments_Receipt : false;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.Student_ScholarshipDocuments_Receipt = value;
            }
        }
        //[Required(ErrorMessage = "Field must be selected")]
        [Display(Name = "Student_ScholarshipDocuments_GateScoreCard")]
        public bool Student_ScholarshipDocuments_GateScoreCard
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.Student_ScholarshipDocuments_GateScoreCard : false;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.Student_ScholarshipDocuments_GateScoreCard = value;
            }
        }
        //[Required(ErrorMessage = "Field must be selected")]
        [Display(Name = "Student_ScholarshipDocuments_HandicapCertificate")]
        public bool Student_ScholarshipDocuments_HandicapCertificate
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.Student_ScholarshipDocuments_HandicapCertificate : false;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.Student_ScholarshipDocuments_HandicapCertificate = value;
            }
        }
        //[Required(ErrorMessage = "Field must be selected")]
        [Display(Name = "Student_ScholarshipDocuments_Icardsizephoto")]
        public bool Student_ScholarshipDocuments_Icardsizephoto
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.Student_ScholarshipDocuments_Icardsizephoto : false;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.Student_ScholarshipDocuments_Icardsizephoto = value;
            }
        }
        //[Required(ErrorMessage = "Field must be selected")]
        [Display(Name = "Student_ScholarshipDocuments_IDProof")]
        public bool Student_ScholarshipDocuments_IDProof
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.Student_ScholarshipDocuments_IDProof : false;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.Student_ScholarshipDocuments_IDProof = value;
            }
        }
        //[Required(ErrorMessage = "Field must be selected")]
        [Display(Name = "Student_ScholarshipDocuments_IncomeAffidavitOriginal")]
        public bool Student_ScholarshipDocuments_IncomeAffidavitOriginal
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.Student_ScholarshipDocuments_IncomeAffidavitOriginal : false;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.Student_ScholarshipDocuments_IncomeAffidavitOriginal = value;
            }
        }
        //[Required(ErrorMessage = "Field must be selected")]
        [Display(Name = "Student_ScholarshipDocuments_JEEMainScoreCard")]
        public bool Student_ScholarshipDocuments_JEEMainScoreCard
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.Student_ScholarshipDocuments_JEEMainScoreCard : false;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.Student_ScholarshipDocuments_JEEMainScoreCard = value;
            }
        }
        //[Required(ErrorMessage = "Field must be selected")]
        [Display(Name = "Student_ScholarshipDocuments_Leavingcertificate")]
        public bool Student_ScholarshipDocuments_Leavingcertificate
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.Student_ScholarshipDocuments_Leavingcertificate : false;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.Student_ScholarshipDocuments_Leavingcertificate = value;
            }
        }
        //[Required(ErrorMessage = "Field must be selected")]
        [Display(Name = "Student_ScholarshipDocuments_ParentsFromNo16")]
        public bool Student_ScholarshipDocuments_ParentsFromNo16
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.Student_ScholarshipDocuments_ParentsFromNo16 : false;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.Student_ScholarshipDocuments_ParentsFromNo16 = value;
            }
        }
        //[Required(ErrorMessage = "Field must be selected")]
        [Display(Name = "Student_ScholarshipDocuments_LastYearMarksheet")]
        public bool Student_ScholarshipDocuments_LastYearMarksheet
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.Student_ScholarshipDocuments_LastYearMarksheet : false;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.Student_ScholarshipDocuments_LastYearMarksheet = value;
            }
        }
        //[Required(ErrorMessage = "Field must be selected")]
        [Display(Name = "Student_ScholarshipDocuments_RationCard")]
        public bool Student_ScholarshipDocuments_RationCard
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.Student_ScholarshipDocuments_RationCard : false;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.Student_ScholarshipDocuments_RationCard = value;
            }
        }
        //[Required(ErrorMessage = "Field must be selected")]
        [Display(Name = "Student_ScholarshipDocuments_MHCETScoreCard")]
        public bool Student_ScholarshipDocuments_MHCETScoreCard
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.Student_ScholarshipDocuments_MHCETScoreCard : false;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.Student_ScholarshipDocuments_MHCETScoreCard = value;
            }
        }
        //[Required(ErrorMessage = "Field must be selected")]
        [Display(Name = "Student_ScholarshipDocuments_LastCollegeletterAboutScholarshipOriginal")]
        public bool Student_ScholarshipDocuments_LastCollegeletterAboutScholarshipOriginal
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.Student_ScholarshipDocuments_LastCollegeletterAboutScholarshipOriginal : false;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.Student_ScholarshipDocuments_LastCollegeletterAboutScholarshipOriginal = value;
            }
        }
        //[Required(ErrorMessage = "Field must be selected")]
        [Display(Name = "Student_ScholarshipDocuments_Colourphoto")]
        public bool Student_ScholarshipDocuments_Colourphoto
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.Student_ScholarshipDocuments_Colourphoto : false;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.Student_ScholarshipDocuments_Colourphoto = value;
            }
        }
        #endregion Scholarship Documents Information
        #region If Applicable
        //[Required(ErrorMessage = "Field must be selected")]
        [Display(Name = "Student_ScholarshipDocuments_IfApplicable_NonCreamylayer")]
        public bool Student_ScholarshipDocuments_IfApplicable_NonCreamylayer
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.Student_ScholarshipDocuments_IfApplicable_NonCreamylayer : false;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.Student_ScholarshipDocuments_IfApplicable_NonCreamylayer = value;
            }
        }
        //[Required(ErrorMessage = "Field must be selected")]
        [Display(Name = "Student_ScholarshipDocuments_IfApplicable_DeathcertificateFatherMother")]
        public bool Student_ScholarshipDocuments_IfApplicable_DeathcertificateFatherMother
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.Student_ScholarshipDocuments_IfApplicable_DeathcertificateFatherMother : false;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.Student_ScholarshipDocuments_IfApplicable_DeathcertificateFatherMother = value;
            }
        }
        //[Required(ErrorMessage = "Field must be selected")]
        [Display(Name = "Student_ScholarshipDocuments_IfApplicable_DisabilityAbilityCertificate")]
        public bool Student_ScholarshipDocuments_IfApplicable_DisabilityAbilityCertificate
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.Student_ScholarshipDocuments_IfApplicable_DisabilityAbilityCertificate : false;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.Student_ScholarshipDocuments_IfApplicable_DisabilityAbilityCertificate = value;
            }
        }
        //[Required(ErrorMessage = "Field must be selected")]
        [Display(Name = "Student_ScholarshipDocuments_IfApplicable_GapCertificate")]
        public bool Student_ScholarshipDocuments_IfApplicable_GapCertificate
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.Student_ScholarshipDocuments_IfApplicable_GapCertificate : false;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.Student_ScholarshipDocuments_IfApplicable_GapCertificate = value;
            }
        }

        public string StudentSubmitedDocumentFlagIDs
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.StudentSubmitedDocumentFlagIDs : string.Empty;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.StudentSubmitedDocumentFlagIDs = value;
            }
        }
        public string StudentSubmitedDocumentIDs
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.StudentSubmitedDocumentIDs : string.Empty;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.StudentSubmitedDocumentIDs = value;
            }
        }

        #endregion If Applicable
        #region Comments
        //[Required(ErrorMessage = "Field should not be blank")]
        [Display(Name = "Student_ScholarshipDocuments_Comments")]
        public string Student_ScholarshipDocuments_Comments
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.Student_ScholarshipDocuments_Comments : string.Empty;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.Student_ScholarshipDocuments_Comments = value;
            }
        }
        #endregion Comments
        #endregion Scholarship Documents Information

        #endregion Student Documents Information


        #region Subject IDs
        public string QualifyingExamSubjectDetailsIDs
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.QualifyingExamSubjectDetailsIDs : string.Empty;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.QualifyingExamSubjectDetailsIDs = value;
            }
        }
        public string QualificationExamSubjectGeneralDetailsIDs
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.QualificationExamSubjectGeneralDetailsIDs : string.Empty;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.QualificationExamSubjectGeneralDetailsIDs = value;
            }
        }
        public string QualificationExamSubjectSSCDetailsIDs
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.QualificationExamSubjectSSCDetailsIDs : string.Empty;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.QualificationExamSubjectSSCDetailsIDs = value;
            }
        }
        public string QualificationExamSubjectHSCDetailsIDs
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.QualificationExamSubjectHSCDetailsIDs : string.Empty;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.QualificationExamSubjectHSCDetailsIDs = value;
            }
        }
        #endregion Subject IDs


        #region Table Name
        public bool StuRegistrationStudentPhotoSignThumb
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.StuRegistrationStudentPhotoSignThumb : false;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.StuRegistrationStudentPhotoSignThumb = value;
            }
        }



        public bool StuRegistrationStudentSocialReservationInformation
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.StuRegistrationStudentSocialReservationInformation : false;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.StuRegistrationStudentSocialReservationInformation = value;
            }
        }
        public bool StuRegistrationOtherInfoOfStudent
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.StuRegistrationOtherInfoOfStudent : false;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.StuRegistrationOtherInfoOfStudent = value;
            }
        }

        public bool stuRegistrationAddressDetails
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.stuRegistrationAddressDetails : false;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.stuRegistrationAddressDetails = value;
            }
        }

        public bool StuRegistrationPreQualificationSchoolTransaction
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.StuRegistrationPreQualificationSchoolTransaction : false;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.StuRegistrationPreQualificationSchoolTransaction = value;
            }
        }

        public bool StuRegistrationPreQualificationSchoolSubjectDetail
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.StuRegistrationPreQualificationSchoolSubjectDetail : false;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.StuRegistrationPreQualificationSchoolSubjectDetail = value;
            }
        }

        public bool StuRegistrationPreEntranceExaminationTransaction
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.StuRegistrationPreEntranceExaminationTransaction : false;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.StuRegistrationPreEntranceExaminationTransaction = value;
            }
        }

        public bool StuRegistrationPreEntranceExaminationSubjectDetail
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.StuRegistrationPreEntranceExaminationSubjectDetail : false;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.StuRegistrationPreEntranceExaminationSubjectDetail = value;
            }
        }

        public bool StuRegistrationPreQualificationCollegeTransaction
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.StuRegistrationPreQualificationCollegeTransaction : false;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.StuRegistrationPreQualificationCollegeTransaction = value;
            }
        }
        public bool StuRegistrationQualifyingSelectionInfo
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.StuRegistrationQualifyingSelectionInfo : false;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.StuRegistrationQualifyingSelectionInfo = value;
            }
        }
        public bool StuRegistrationDocumentSubmitted
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.StuRegistrationDocumentSubmitted : false;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.StuRegistrationDocumentSubmitted = value;
            }
        }
        #endregion Table Name
        public List<StudentRegistrationForm> StudentRegistrationFormList
        {
            get;
            set;
        }
        public List<StudentRegistrationAcademicApproval> QualifyingExamSubjectList
        {
            get;
            set;
        }
        public List<StudentRegistrationAcademicApproval> QualificationMasterSubjectListForGeneral
        {
            get;
            set;
        }
        public List<StudentRegistrationAcademicApproval> QualificationMasterSubjectListForSSC
        {
            get;
            set;
        }
        public List<StudentRegistrationAcademicApproval> QualificationMasterSubjectListForHSC
        {
            get;
            set;
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
        public OrganisationCourseYearDetails OrganisationCourseYearDetailsDTO { get; set; }
        public OrganisationBranchDetails OrganisationBranchDetailsDTO { get; set; }

        #region Task Approval Fields
        public string TaskCode
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.TaskCode : string.Empty;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.TaskCode = value;
            }
        }
        public int TaskNotificationDetailsID
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null && StudentRegistrationAcademicApprovalDTO.TaskNotificationDetailsID > 0) ? StudentRegistrationAcademicApprovalDTO.TaskNotificationDetailsID : new int();
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.TaskNotificationDetailsID = value;
            }
        }
        public int TaskNotificationMasterID
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null && StudentRegistrationAcademicApprovalDTO.TaskNotificationMasterID > 0) ? StudentRegistrationAcademicApprovalDTO.TaskNotificationMasterID : new int();
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.TaskNotificationMasterID = value;
            }
        }
        public int GeneralTaskReportingDetailsID
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null && StudentRegistrationAcademicApprovalDTO.GeneralTaskReportingDetailsID > 0) ? StudentRegistrationAcademicApprovalDTO.GeneralTaskReportingDetailsID : new int();
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.GeneralTaskReportingDetailsID = value;
            }
        }
        public int PersonID
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null && StudentRegistrationAcademicApprovalDTO.PersonID > 0) ? StudentRegistrationAcademicApprovalDTO.PersonID : new int();
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.PersonID = value;
            }
        }
        public int StageSequenceNumber
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null && StudentRegistrationAcademicApprovalDTO.StageSequenceNumber > 0) ? StudentRegistrationAcademicApprovalDTO.StageSequenceNumber : new int();
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.StageSequenceNumber = value;
            }
        }
        public bool IsLastRecord
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.IsLastRecord : false;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.IsLastRecord = value;
            }
        }
        #endregion

        public string NameOfApplicant
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.NameOfApplicant : string.Empty;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.NameOfApplicant = value;
            }
        }
        public string TitleOfProject
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.TitleOfProject : string.Empty;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.TitleOfProject = value;
            }
        }
        public string ProjectSummary
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.ProjectSummary : string.Empty;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.ProjectSummary = value;
            }
        }
        public short FeesPaidBy
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null && StudentRegistrationAcademicApprovalDTO.FeesPaidBy > 0) ? StudentRegistrationAcademicApprovalDTO.FeesPaidBy : new short();
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.FeesPaidBy = value;
            }
        }
        public string WorkExperienceXML
        {
            get
            {
                return (StudentRegistrationAcademicApprovalDTO != null) ? StudentRegistrationAcademicApprovalDTO.WorkExperienceXML : string.Empty;
            }
            set
            {
                StudentRegistrationAcademicApprovalDTO.WorkExperienceXML = value;
            }
        }


        public string NameOfOrganization
        {
            get
            {
                return (PreviousWorkExperienceDTO != null) ? PreviousWorkExperienceDTO.NameOfOrganization : string.Empty;
            }
            set
            {
                PreviousWorkExperienceDTO.NameOfOrganization = value;
            }
        }
        public string Position
        {
            get
            {
                return (PreviousWorkExperienceDTO != null) ? PreviousWorkExperienceDTO.Position : string.Empty;
            }
            set
            {
                PreviousWorkExperienceDTO.Position = value;
            }
        }
        public string FullPartTimeFlag
        {
            get
            {
                return (PreviousWorkExperienceDTO != null) ? PreviousWorkExperienceDTO.FullPartTimeFlag : string.Empty;
            }
            set
            {
                PreviousWorkExperienceDTO.FullPartTimeFlag = value;
            }
        }
        public string FromDate
        {
            get
            {
                return (PreviousWorkExperienceDTO != null) ? PreviousWorkExperienceDTO.FromDate : string.Empty;
            }
            set
            {
                PreviousWorkExperienceDTO.FromDate = value;
            }
        }
        public string UptoDate
        {
            get
            {
                return (PreviousWorkExperienceDTO != null) ? PreviousWorkExperienceDTO.UptoDate : string.Empty;
            }
            set
            {
                PreviousWorkExperienceDTO.UptoDate = value;
            }
        }
    }
}

