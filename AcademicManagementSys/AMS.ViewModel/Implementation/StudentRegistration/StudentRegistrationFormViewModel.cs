using AMS.Common;
using AMS.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using System.Web;
using AMS.Base.DTO;


namespace AMS.ViewModel
{
    public class StudentRegistrationFormBaseViewModel : IStudentRegistrationFormBaseViewModel
    {
        public StudentRegistrationFormBaseViewModel()
        {

        }

        public StudentRegistrationForm StudentRegistrationFormDTO
        {
            get;
            set;
        }
        public List<OrganisationStudyCentreMaster> ListOrgStudyCentreMaster
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

    }
    public class StudentRegistrationFormViewModel : IStudentRegistrationFormViewModel
    {

        public StudentRegistrationFormViewModel()
        {
            StudentRegistrationFormDTO = new StudentRegistrationForm();
            //  StudentRegistrationFormQualifingExamSubjectList = new List<StudentRegistrationForm>(); 
            ToolQualifyingExamSubjectList = new List<ToolQualifyingExamSubject>();
            ToolQualificationMasterSubjectListForGeneral = new List<ToolQualificationMasterSubject>();
            ToolQualificationMasterSubjectListForSSC = new List<ToolQualificationMasterSubject>();
            ToolQualificationMasterSubjectListForHSC = new List<ToolQualificationMasterSubject>();
            PreviousWorkExperienceDTO = new PreviousWorkExperience();
            PreviousWorkExperienceList = new List<PreviousWorkExperience>();
        }

        public StudentRegistrationForm StudentRegistrationFormDTO { get; set; }
        public List<PreviousWorkExperience>  PreviousWorkExperienceList { get; set; }
        public PreviousWorkExperience PreviousWorkExperienceDTO { get; set; }
        #region Oficial Info

        public int Student_AcademicYearId
        {

            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.Student_AcademicYearId : new int();
            }
            set
            {
                StudentRegistrationFormDTO.Student_AcademicYearId = value;
            }
        }
        public string Student_AcademicYear
        {

            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.Student_AcademicYear : string.Empty;
            }

            set
            {
                StudentRegistrationFormDTO.Student_AcademicYear = value;
            }
        }
        [Display(Name = "Template Name")]
        public string TemplateName
        {

            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.TemplateName : string.Empty;
            }

            set
            {
                StudentRegistrationFormDTO.TemplateName = value;
            }
        }
        //[Required(ErrorMessage = "Field should not be blank")]
        [Display(Name = "CenterCode")]
        public string Student_StudentCode
        {

            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.Student_StudentCode : string.Empty;
            }
            set
            {
                StudentRegistrationFormDTO.Student_StudentCode = value;
            }
        }
        //[Required(ErrorMessage = "Field must be selected")]
        [Display(Name = "Student_CourseYearId")]
        public int Student_CourseYearId
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.Student_CourseYearId : new int();
            }
            set
            {
                StudentRegistrationFormDTO.Student_CourseYearId = value;
            }
        }
        public string Student_CourseYearName
        {

            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.Student_CourseYearName : string.Empty;
            }
            set
            {
                StudentRegistrationFormDTO.Student_CourseYearName = value;
            }
        }
        //[Required(ErrorMessage = "Field should not be blank")]
        [Display(Name = "Student_SelfRegistrationCode")]
        public string Student_SelfRegistrationCode
        {

            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.Student_SelfRegistrationCode : string.Empty;
            }
            set
            {
                StudentRegistrationFormDTO.Student_SelfRegistrationCode = value;
            }
        }

        public string Student_CourseName
        {

            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.Student_CourseName : string.Empty;
            }
            set
            {
                StudentRegistrationFormDTO.Student_CourseName = value;
            }
        }
        //[Required(ErrorMessage = "Field should not be blank")]
        [Display(Name = "Student_DateofRegistration")]
        public string Student_DateofRegistration
        {

            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.Student_DateofRegistration : string.Empty;
            }
            set
            {
                StudentRegistrationFormDTO.Student_DateofRegistration = value;
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
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.StudentPhoto : new byte[1];         //review this       
            }
            set
            {
                StudentRegistrationFormDTO.StudentPhoto = value;
            }
        }


        public string StudentPhotoType
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.StudentPhotoType : string.Empty;
            }
            set
            {
                StudentRegistrationFormDTO.StudentPhotoType = value;
            }
        }


        public string StudentPhotoFilename
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.StudentPhotoFilename : string.Empty;
            }
            set
            {
                StudentRegistrationFormDTO.StudentPhotoFilename = value;
            }
        }

        public string StudentPhotoFileWidth
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.StudentPhotoFileWidth : string.Empty;
            }
            set
            {
                StudentRegistrationFormDTO.StudentPhotoFileWidth = value;
            }
        }


        public string StudentPhotoFileHeight
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.StudentPhotoFileHeight : string.Empty;
            }
            set
            {
                StudentRegistrationFormDTO.StudentPhotoFileHeight = value;
            }
        }


        public string StudentPhotoFileSize
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.StudentPhotoFileSize : string.Empty;
            }
            set
            {
                StudentRegistrationFormDTO.StudentPhotoFileSize = value;
            }
        }

        // for Signature
        public byte[] StudentSignature
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.StudentSignature : new byte[1];         //review this       
            }
            set
            {
                StudentRegistrationFormDTO.StudentSignature = value;
            }
        }


        public string StudentSignatureType
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.StudentSignatureType : string.Empty;
            }
            set
            {
                StudentRegistrationFormDTO.StudentSignatureType = value;
            }
        }


        public string StudentSignatureFilename
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.StudentSignatureFilename : string.Empty;
            }
            set
            {
                StudentRegistrationFormDTO.StudentSignatureFilename = value;
            }
        }

        public string StudentSignatureFileWidth
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.StudentSignatureFileWidth : string.Empty;
            }
            set
            {
                StudentRegistrationFormDTO.StudentSignatureFileWidth = value;
            }
        }


        public string StudentSignatureFileHeight
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.StudentSignatureFileHeight : string.Empty;
            }
            set
            {
                StudentRegistrationFormDTO.StudentSignatureFileHeight = value;
            }
        }


        public string StudentSignatureFileSize
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.StudentSignatureFileSize : string.Empty;
            }
            set
            {
                StudentRegistrationFormDTO.StudentSignatureFileSize = value;
            }
        }
        //For Thumb
        // for Signature
        public byte[] StudentThumb
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.StudentThumb : new byte[1];         //review this       
            }
            set
            {
                StudentRegistrationFormDTO.StudentThumb = value;
            }
        }


        public string StudentThumbType
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.StudentThumbType : string.Empty;
            }
            set
            {
                StudentRegistrationFormDTO.StudentThumbType = value;
            }
        }


        public string StudentThumbFilename
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.StudentThumbFilename : string.Empty;
            }
            set
            {
                StudentRegistrationFormDTO.StudentThumbFilename = value;
            }
        }

        public string StudentThumbFileWidth
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.StudentThumbFileWidth : string.Empty;
            }
            set
            {
                StudentRegistrationFormDTO.StudentThumbFileWidth = value;
            }
        }


        public string StudentThumbFileHeight
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.StudentThumbFileHeight : string.Empty;
            }
            set
            {
                StudentRegistrationFormDTO.StudentThumbFileHeight = value;
            }
        }


        public string StudentThumbFileSize
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.StudentThumbFileSize : string.Empty;
            }
            set
            {
                StudentRegistrationFormDTO.StudentThumbFileSize = value;
            }
        }



        #endregion File Upload

        #region  Student General Info

        public int ID
        {
            get
            {
                return (StudentRegistrationFormDTO != null && StudentRegistrationFormDTO.ID > 0) ? StudentRegistrationFormDTO.ID : new int();
            }
            set
            {
                StudentRegistrationFormDTO.ID = value;
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
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.StudentEmailID : string.Empty;
            }
            set
            {
                StudentRegistrationFormDTO.StudentEmailID = value;
            }
        }
        //[Required(ErrorMessage = "Field should not be blank")]
        [Display(Name = "Password")]
        public string Password
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.Password : string.Empty;
            }
            set
            {
                StudentRegistrationFormDTO.Password = value;
            }
        }
        //[Required(ErrorMessage = "Field should not be blank")]
        [Display(Name = "Title")]
        public string StudentTitle
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.StudentTitle : string.Empty;
            }
            set
            {
                StudentRegistrationFormDTO.StudentTitle = value;
            }
        }
        //[Required(ErrorMessage = "Field Name should not be blank")]
        [Display(Name = "FirstName")]
        public string StudentFirstName
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.StudentFirstName : string.Empty;
            }
            set
            {
                StudentRegistrationFormDTO.StudentFirstName = value;
            }
        }
        //[Required(ErrorMessage = "Field Name should not be blank")]
        [Display(Name = "MiddleName")]
        public string StudentMiddleName
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.StudentMiddleName : string.Empty;
            }
            set
            {
                StudentRegistrationFormDTO.StudentMiddleName = value;
            }
        }

        public string StudentLastName
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.StudentLastName : string.Empty;
            }
            set
            {
                StudentRegistrationFormDTO.StudentLastName = value;
            }
        }
        //[Required(ErrorMessage = "Field should not be blank")]
        [Display(Name = "ContactNumber")]
        public string StudentMobileNumber
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.StudentMobileNumber : string.Empty;
            }
            set
            {
                StudentRegistrationFormDTO.StudentMobileNumber = value;
            }
        }
        //[Required(ErrorMessage = "Field should not be blank")]
        [Display(Name = "ContactNumber")]
        public string StudentLandLineNumber
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.StudentLandLineNumber : string.Empty;
            }
            set
            {
                StudentRegistrationFormDTO.StudentLandLineNumber = value;
            }
        }


        public string StudentGender
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.StudentGender : string.Empty;
            }
            set
            {
                StudentRegistrationFormDTO.StudentGender = value;
            }
        }

        //[Required(ErrorMessage = "Field should not be blank")]
        [Display(Name = "CenterCode")]
        public string CenterCode
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.CenterCode : string.Empty;
            }
            set
            {
                StudentRegistrationFormDTO.CenterCode = value;
            }
        }
        //[Required(ErrorMessage = "Field should not be blank")]
        [Display(Name = "ContactNumber")]
        public string StudentEmploymentSector
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.StudentEmploymentSector : string.Empty;
            }
            set
            {
                StudentRegistrationFormDTO.StudentEmploymentSector = value;
            }
        }
        //[Required(ErrorMessage = "Field should not be blank")]
        [Display(Name = "ContactNumber")]
        public string StudentOccupation
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.StudentOccupation : string.Empty;
            }
            set
            {
                StudentRegistrationFormDTO.StudentOccupation = value;
            }
        }

        //[Required(ErrorMessage = "Field should not be blank")]
        [Display(Name = "ContactNumber")]
        public string StudentDesignation
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.StudentDesignation : string.Empty;
            }
            set
            {
                StudentRegistrationFormDTO.StudentDesignation = value;
            }
        }
        //[Required(ErrorMessage = "Field should not be blank")]
        [Display(Name = "StudentOrganizationName")]
        public string StudentOrganizationName
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.StudentOrganizationName : string.Empty;
            }
            set
            {
                StudentRegistrationFormDTO.StudentOrganizationName = value;
            }
        }
        //[Required(ErrorMessage = "Field should not be blank")]
        [Display(Name = "StudentOfficeContactNo")]
        public string StudentOfficeContactNo
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.StudentOfficeContactNo : string.Empty;
            }
            set
            {
                StudentRegistrationFormDTO.StudentOfficeContactNo = value;
            }
        }
        //[Required(ErrorMessage = "Field should not be blank")]
        [Display(Name = "StudentAnnualIncome")]
        public double StudentAnnualIncome
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.StudentAnnualIncome : new double();
            }
            set
            {
                StudentRegistrationFormDTO.StudentAnnualIncome = value;
            }
        }
        public bool IsActive
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.IsActive : false;
            }
            set
            {
                StudentRegistrationFormDTO.IsActive = value;
            }
        }

        public string WebRegistrationStatus
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.WebRegistrationStatus : string.Empty;
            }
            set
            {
                StudentRegistrationFormDTO.WebRegistrationStatus = value;
            }
        }

        public string WebAdminComments
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.WebAdminComments : string.Empty;
            }
            set
            {
                StudentRegistrationFormDTO.WebAdminComments = value;
            }
        }

        public string ApprovalDate
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.ApprovalDate : string.Empty;
            }
            set
            {
                StudentRegistrationFormDTO.ApprovalDate = value;
            }
        }
        public int AdminApprovedBy
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.AdminApprovedBy : new int();
            }
            set
            {
                StudentRegistrationFormDTO.AdminApprovedBy = value;
            }
        }

        public int StudentID
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.StudentID : new int();
            }
            set
            {
                StudentRegistrationFormDTO.StudentID = value;
            }
        }
        //[Required(ErrorMessage = "University should not be blank")]
        [Display(Name = "UniversityID")]
        public int UniversityID
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.UniversityID : new int();
            }
            set
            {
                StudentRegistrationFormDTO.UniversityID = value;
            }
        }
        public string StudentCode
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.StudentCode : string.Empty;
            }
            set
            {
                StudentRegistrationFormDTO.StudentCode = value;
            }
        }
        public int ApprovStudSecEmployeeID
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.ApprovStudSecEmployeeID : new int();
            }
            set
            {
                StudentRegistrationFormDTO.ApprovStudSecEmployeeID = value;
            }
        }
        public int ApprovAcctSecEmployeeID
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.ApprovAcctSecEmployeeID : new int();
            }
            set
            {
                StudentRegistrationFormDTO.ApprovAcctSecEmployeeID = value;
            }
        }
        //[Required(ErrorMessage = "Branch should not be blank")]
        [Display(Name = "Branch")]
        public int BranchDetailID
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.BranchDetailID : new int();
            }
            set
            {
                StudentRegistrationFormDTO.BranchDetailID = value;
            }
        }
        //[Required(ErrorMessage = "Standard Number should not be blank")]
        [Display(Name = "Standard Number")]
        public int StandardNumber
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.StandardNumber : new int();
            }
            set
            {
                StudentRegistrationFormDTO.StandardNumber = value;
            }
        }
        public int AdmissionPattern
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.AdmissionPattern : new int();
            }
            set
            {
                StudentRegistrationFormDTO.AdmissionPattern = value;
            }
        }
        public int ToolRegistrationTemplateMstID
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.ToolRegistrationTemplateMstID : new int();
            }
            set
            {
                StudentRegistrationFormDTO.ToolRegistrationTemplateMstID = value;
            }
        }

        #endregion Student General Info

        #region Father InFormation
        public string FatherHusbondType
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.FatherHusbondType : string.Empty;
            }
            set
            {
                StudentRegistrationFormDTO.FatherHusbondType = value;
            }
        }
        //[Required(ErrorMessage = "Title should not be blank")]
        [Display(Name = "Title")]
        public string FatherTitle
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.FatherTitle : string.Empty;
            }
            set
            {
                StudentRegistrationFormDTO.FatherTitle = value;
            }
        }
        //[Required(ErrorMessage = "First Name should not be blank")]
        [Display(Name = "FirstName")]
        public string FatherFirstName
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.FatherFirstName : string.Empty;
            }
            set
            {
                StudentRegistrationFormDTO.FatherFirstName = value;
            }
        }
        //[Required(ErrorMessage = "Middle Name should not be blank")]
        [Display(Name = "MiddleName")]
        public string FatherMiddleName
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.FatherMiddleName : string.Empty;
            }
            set
            {
                StudentRegistrationFormDTO.FatherMiddleName = value;
            }
        }
        //[Required(ErrorMessage = "LastName should not be blank")]
        [Display(Name = "MiddleName")]
        public string FatherLastName
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.FatherLastName : string.Empty;
            }
            set
            {
                StudentRegistrationFormDTO.FatherLastName = value;
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
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.FatherEmailId : string.Empty;
            }
            set
            {
                StudentRegistrationFormDTO.FatherEmailId = value;
            }
        }

        //[Required(ErrorMessage = "Mobile Number should not be blank")]
        [Display(Name = "ContactNumber")]
        public string FatherMobileNumber
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.FatherMobileNumber : string.Empty;
            }
            set
            {
                StudentRegistrationFormDTO.FatherMobileNumber = value;
            }
        }
        //[Required(ErrorMessage = "LandLine Number should not be blank")]
        [Display(Name = "ContactNumber")]
        public string FatherLandLineNumber
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.FatherLandLineNumber : string.Empty;
            }
            set
            {
                StudentRegistrationFormDTO.FatherLandLineNumber = value;
            }
        }

        //[Required(ErrorMessage = "Employment Sector should not be blank")]
        [Display(Name = "ContactNumber")]
        public string FatherEmploymentSector
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.FatherEmploymentSector : string.Empty;
            }
            set
            {
                StudentRegistrationFormDTO.FatherEmploymentSector = value;
            }
        }
        //[Required(ErrorMessage = "Occupation should not be blank")]
        [Display(Name = "ContactNumber")]
        public string FatherOccupation
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.FatherOccupation : string.Empty;
            }
            set
            {
                StudentRegistrationFormDTO.FatherOccupation = value;
            }
        }

        //[Required(ErrorMessage = "Designation should not be blank")]
        [Display(Name = "ContactNumber")]
        public string FatherDesignation
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.FatherDesignation : string.Empty;
            }
            set
            {
                StudentRegistrationFormDTO.FatherDesignation = value;
            }
        }
        //[Required(ErrorMessage = "Organization Name should not be blank")]
        [Display(Name = "FatherOrganizationName")]
        public string FatherOrganizationName
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.FatherOrganizationName : string.Empty;
            }
            set
            {
                StudentRegistrationFormDTO.FatherOrganizationName = value;
            }
        }
        //[Required(ErrorMessage = "Office ContactNo should not be blank")]
        [Display(Name = "FatherOfficeContactNo")]
        public string FatherOfficeContactNo
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.FatherOfficeContactNo : string.Empty;
            }
            set
            {
                StudentRegistrationFormDTO.FatherOfficeContactNo = value;
            }
        }
        //[Required(ErrorMessage = "Annual Income should not be blank")]
        [Display(Name = "FatherAnnualIncome")]
        public double FatherAnnualIncome
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.FatherAnnualIncome : new double();
            }
            set
            {
                StudentRegistrationFormDTO.FatherAnnualIncome = value;
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
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.MotherTitle : string.Empty;
            }
            set
            {
                StudentRegistrationFormDTO.MotherTitle = value;
            }
        }
        //[Required(ErrorMessage = "First Name should not be blank")]
        [Display(Name = "FirstName")]
        public string MotherFirstName
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.MotherFirstName : string.Empty;
            }
            set
            {
                StudentRegistrationFormDTO.MotherFirstName = value;
            }
        }
        //[Required(ErrorMessage = "Middle Name should not be blank")]
        [Display(Name = "MiddleName")]
        public string MotherMiddleName
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.MotherMiddleName : string.Empty;
            }
            set
            {
                StudentRegistrationFormDTO.MotherMiddleName = value;
            }
        }
        //[Required(ErrorMessage = "LastName should not be blank")]
        [Display(Name = "MiddleName")]
        public string MotherLastName
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.MotherLastName : string.Empty;
            }
            set
            {
                StudentRegistrationFormDTO.MotherLastName = value;
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
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.MotherEmailId : string.Empty;
            }
            set
            {
                StudentRegistrationFormDTO.MotherEmailId = value;
            }
        }

        //[Required(ErrorMessage = "Mobile Number should not be blank")]
        [Display(Name = "ContactNumber")]
        public string MotherMobileNumber
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.MotherMobileNumber : string.Empty;
            }
            set
            {
                StudentRegistrationFormDTO.MotherMobileNumber = value;
            }
        }
        //[Required(ErrorMessage = "LandLine Number should not be blank")]
        [Display(Name = "ContactNumber")]
        public string MotherLandLineNumber
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.MotherLandLineNumber : string.Empty;
            }
            set
            {
                StudentRegistrationFormDTO.MotherLandLineNumber = value;
            }
        }

        //[Required(ErrorMessage = "Employment Sector should not be blank")]
        [Display(Name = "ContactNumber")]
        public string MotherEmploymentSector
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.MotherEmploymentSector : string.Empty;
            }
            set
            {
                StudentRegistrationFormDTO.MotherEmploymentSector = value;
            }
        }
        //[Required(ErrorMessage = "Occupation should not be blank")]
        [Display(Name = "ContactNumber")]
        public string MotherOccupation
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.MotherOccupation : string.Empty;
            }
            set
            {
                StudentRegistrationFormDTO.MotherOccupation = value;
            }
        }

        //[Required(ErrorMessage = "Designation should not be blank")]
        [Display(Name = "ContactNumber")]
        public string MotherDesignation
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.MotherDesignation : string.Empty;
            }
            set
            {
                StudentRegistrationFormDTO.MotherDesignation = value;
            }
        }
        //[Required(ErrorMessage = "Organization Name should not be blank")]
        [Display(Name = "MotherOrganizationName")]
        public string MotherOrganizationName
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.MotherOrganizationName : string.Empty;
            }
            set
            {
                StudentRegistrationFormDTO.MotherOrganizationName = value;
            }
        }
        //[Required(ErrorMessage = "Office ContactNo should not be blank")]
        [Display(Name = "MotherOfficeContactNo")]
        public string MotherOfficeContactNo
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.MotherOfficeContactNo : string.Empty;
            }
            set
            {
                StudentRegistrationFormDTO.MotherOfficeContactNo = value;
            }
        }
        //[Required(ErrorMessage = "Annual Income should not be blank")]
        [Display(Name = "MotherAnnualIncome")]
        public double MotherAnnualIncome
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.MotherAnnualIncome : new double();
            }
            set
            {
                StudentRegistrationFormDTO.MotherAnnualIncome = value;
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
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.GuardianTitle : string.Empty;
            }
            set
            {
                StudentRegistrationFormDTO.GuardianTitle = value;
            }
        }
        //[Required(ErrorMessage = "First Name should not be blank")]
        [Display(Name = "FirstName")]
        public string GuardianFirstName
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.GuardianFirstName : string.Empty;
            }
            set
            {
                StudentRegistrationFormDTO.GuardianFirstName = value;
            }
        }
        //[Required(ErrorMessage = "Middle Name should not be blank")]
        [Display(Name = "MiddleName")]
        public string GuardianMiddleName
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.GuardianMiddleName : string.Empty;
            }
            set
            {
                StudentRegistrationFormDTO.GuardianMiddleName = value;
            }
        }
        //[Required(ErrorMessage = "LastName should not be blank")]
        [Display(Name = "MiddleName")]
        public string GuardianLastName
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.GuardianLastName : string.Empty;
            }
            set
            {
                StudentRegistrationFormDTO.GuardianLastName = value;
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
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.GuardianEmailId : string.Empty;
            }
            set
            {
                StudentRegistrationFormDTO.GuardianEmailId = value;
            }
        }

        //[Required(ErrorMessage = "Mobile Number should not be blank")]
        [Display(Name = "ContactNumber")]
        public string GuardianMobileNumber
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.GuardianMobileNumber : string.Empty;
            }
            set
            {
                StudentRegistrationFormDTO.GuardianMobileNumber = value;
            }
        }
        //[Required(ErrorMessage = "LandLine Number should not be blank")]
        [Display(Name = "ContactNumber")]
        public string GuardianLandLineNumber
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.GuardianLandLineNumber : string.Empty;
            }
            set
            {
                StudentRegistrationFormDTO.GuardianLandLineNumber = value;
            }
        }

        //[Required(ErrorMessage = "Employment Sector should not be blank")]
        [Display(Name = "ContactNumber")]
        public string GuardianEmploymentSector
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.GuardianEmploymentSector : string.Empty;
            }
            set
            {
                StudentRegistrationFormDTO.GuardianEmploymentSector = value;
            }
        }
        //[Required(ErrorMessage = "Occupation should not be blank")]
        [Display(Name = "ContactNumber")]
        public string GuardianOccupation
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.GuardianOccupation : string.Empty;
            }
            set
            {
                StudentRegistrationFormDTO.GuardianOccupation = value;
            }
        }

        //[Required(ErrorMessage = "Designation should not be blank")]
        [Display(Name = "ContactNumber")]
        public string GuardianDesignation
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.GuardianDesignation : string.Empty;
            }
            set
            {
                StudentRegistrationFormDTO.GuardianDesignation = value;
            }
        }
        //[Required(ErrorMessage = "Organization Name should not be blank")]
        [Display(Name = "GuardianOrganizationName")]
        public string GuardianOrganizationName
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.GuardianOrganizationName : string.Empty;
            }
            set
            {
                StudentRegistrationFormDTO.GuardianOrganizationName = value;
            }
        }
        //[Required(ErrorMessage = "Office ContactNo should not be blank")]
        [Display(Name = "GuardianOfficeContactNo")]
        public string GuardianOfficeContactNo
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.GuardianOfficeContactNo : string.Empty;
            }
            set
            {
                StudentRegistrationFormDTO.GuardianOfficeContactNo = value;
            }
        }
        //[Required(ErrorMessage = "Annual Income should not be blank")]
        [Display(Name = "GuardianAnnualIncome")]
        public double GuardianAnnualIncome
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.GuardianAnnualIncome : new double();
            }
            set
            {
                StudentRegistrationFormDTO.GuardianAnnualIncome = value;
            }
        }
        #endregion

        #region General


        public bool IsDeleted
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.IsDeleted : false;
            }
            set
            {
                StudentRegistrationFormDTO.IsDeleted = value;
            }
        }

        //[Display(Name = "CreatedBy")]
        public int CreatedBy
        {
            get
            {
                return (StudentRegistrationFormDTO != null && StudentRegistrationFormDTO.CreatedBy > 0) ? StudentRegistrationFormDTO.CreatedBy : new int();
            }
            set
            {
                StudentRegistrationFormDTO.CreatedBy = value;
            }
        }

        //[Display(Name = "CreatedDate")]
        public DateTime CreatedDate
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                StudentRegistrationFormDTO.CreatedDate = value;
            }
        }

        //[Display(Name = "ModifiedBy")]
        public int? ModifiedBy
        {
            get
            {
                return (StudentRegistrationFormDTO != null && StudentRegistrationFormDTO.ModifiedBy.HasValue) ? StudentRegistrationFormDTO.ModifiedBy : new int();
            }
            set
            {
                StudentRegistrationFormDTO.ModifiedBy = value;
            }
        }

        //[Display(Name = "ModifiedDate")]
        public DateTime? ModifiedDate
        {
            get
            {
                return (StudentRegistrationFormDTO != null && StudentRegistrationFormDTO.ModifiedDate.HasValue) ? StudentRegistrationFormDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                StudentRegistrationFormDTO.ModifiedDate = value;
            }
        }

        //[Display(Name = "DeletedBy")]
        public int? DeletedBy
        {
            get
            {
                return (StudentRegistrationFormDTO != null && StudentRegistrationFormDTO.DeletedBy.HasValue) ? StudentRegistrationFormDTO.DeletedBy : new int();
            }
            set
            {
                StudentRegistrationFormDTO.DeletedBy = value;
            }
        }

        //[Display(Name = "DeletedDate")]
        public DateTime? DeletedDate
        {
            get
            {
                return (StudentRegistrationFormDTO != null && StudentRegistrationFormDTO.DeletedDate.HasValue) ? StudentRegistrationFormDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                StudentRegistrationFormDTO.DeletedDate = value;
            }
        }
        #endregion General


        #region Student Specific  Info
        //[Required(ErrorMessage = "Enrollment number should not be blank")]
        [Display(Name = "StudentEnrollmentNo")]
        public string StudentEnrollmentNo
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.StudentEnrollmentNo : string.Empty;
            }
            set
            {
                StudentRegistrationFormDTO.StudentEnrollmentNo = value;
            }
        }
        //[Required(ErrorMessage = "NRI/POI must be selected")]
        [Display(Name = "StudentNRI_POI")]
        public string StudentNRI_POI
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.StudentNRI_POI : string.Empty;
            }
            set
            {
                StudentRegistrationFormDTO.StudentNRI_POI = value;
            }
        }
        //[Required(ErrorMessage = "Migration Number should not be blank")]
        [Display(Name = "StudentMigrationNumber")]
        public string StudentMigrationNumber
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.StudentMigrationNumber : string.Empty;
            }
            set
            {
                StudentRegistrationFormDTO.StudentMigrationNumber = value;
            }
        }
        //[Required(ErrorMessage = "Nationality must be selected")]
        [Display(Name = "StudentNationalityID")]
        public int StudentNationalityID
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.StudentNationalityID : new int();
            }
            set
            {
                StudentRegistrationFormDTO.StudentNationalityID = value;
            }
        }
        //[Required(ErrorMessage = "Migration Date should not be blank")]
        [Display(Name = "StudentMigrationDate")]
        public string StudentMigrationDate
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.StudentMigrationDate : string.Empty;
            }
            set
            {
                StudentRegistrationFormDTO.StudentMigrationDate = value;
            }
        }
        //[Required(ErrorMessage = "Marital Status must be selected")]
        [Display(Name = "StudentMaritalStatus")]
        public string StudentMaritalStatus
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.StudentMaritalStatus : string.Empty;
            }
            set
            {
                StudentRegistrationFormDTO.StudentMaritalStatus = value;
            }
        }
        //[Required(ErrorMessage = "Domicile State of Father should not be blank")]
        [Display(Name = "StudentDomicileStateofFather")]
        public string StudentDomicileStateofFather
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.StudentDomicileStateofFather : string.Empty;
            }
            set
            {
                StudentRegistrationFormDTO.StudentDomicileStateofFather = value;
            }
        }
        //[Required(ErrorMessage = "Blood Group must be selected")]
        [Display(Name = "StudentBloodGroup")]
        public string StudentBloodGroup
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.StudentBloodGroup : string.Empty;
            }
            set
            {
                StudentRegistrationFormDTO.StudentBloodGroup = value;
            }
        }
        //[Required(ErrorMessage = "Domicile State of Mother should not be blank")]
        [Display(Name = "StudentDomicileStateofMother")]
        public string StudentDomicileStateofMother
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.StudentDomicileStateofMother : string.Empty;
            }
            set
            {
                StudentRegistrationFormDTO.StudentDomicileStateofMother = value;
            }
        }
        //[Required(ErrorMessage = "Physically Handicapped must be selected")]
        [Display(Name = "PhysicallyHandicapped")]
        public string PhysicallyHandicapped
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.PhysicallyHandicapped : string.Empty;
            }
            set
            {
                StudentRegistrationFormDTO.PhysicallyHandicapped = value;
            }
        }
        //[Required(ErrorMessage = "Employment Status should not be blank")]
        [Display(Name = "StudentEmploymentStatus")]
        public string StudentEmploymentStatus
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.StudentEmploymentStatus : string.Empty;
            }
            set
            {
                StudentRegistrationFormDTO.StudentEmploymentStatus = value;
            }

        }
        //[Required(ErrorMessage = "Identification Mark should not be blank")]
        [Display(Name = "StudentIdentificationMark")]
        public string StudentIdentificationMark
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.StudentIdentificationMark : string.Empty;
            }
            set
            {
                StudentRegistrationFormDTO.StudentIdentificationMark = value;
            }

        }
        //[Required(ErrorMessage = "Previous name of student should not be blank")]
        [Display(Name = "StudentPrevNameofStudent")]
        public string StudentPrevNameofStudent
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.StudentPrevNameofStudent : string.Empty;
            }
            set
            {
                StudentRegistrationFormDTO.StudentPrevNameofStudent = value;
            }

        }
        //[Required(ErrorMessage = "Organ donor must be selected")]
        [Display(Name = "StudentOrgandonor")]
        public string StudentOrgandonor
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.StudentOrgandonor : string.Empty;
            }
            set
            {
                StudentRegistrationFormDTO.StudentOrgandonor = value;
            }
        }
        //[Required(ErrorMessage = "Reason for name change must be selected")]
        [Display(Name = "StudentReasonforNamechange")]
        public string StudentReasonforNamechange
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.StudentReasonforNamechange : string.Empty;
            }
            set
            {
                StudentRegistrationFormDTO.StudentReasonforNamechange = value;
            }
        }

        //[Required(ErrorMessage = "Region Name must be selected")]
        [Display(Name = "StudentRegionID")]
        public int StudentRegionID
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.StudentRegionID : new int();
            }
            set
            {
                StudentRegistrationFormDTO.StudentRegionID = value;
            }
        }
        //[Required(ErrorMessage = "Region Name should not be blank")]
        [Display(Name = "StudentRegionOther")]
        public string StudentRegionOther
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.StudentRegionOther : string.Empty;
            }
            set
            {
                StudentRegistrationFormDTO.StudentRegionOther = value;
            }
        }


        public int Student_Domesile_CountryId
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.Student_Domesile_CountryId : new int();
            }
            set
            {
                StudentRegistrationFormDTO.Student_Domesile_CountryId = value;
            }
        }
        public int StudentSelfRegistrationID
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.StudentSelfRegistrationID : new int();
            }
            set
            {
                StudentRegistrationFormDTO.StudentSelfRegistrationID = value;
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
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.Student_PermanentAddress_PloteNo : string.Empty;
            }
            set
            {
                StudentRegistrationFormDTO.Student_PermanentAddress_PloteNo = value;
            }
        }
        //[Required(ErrorMessage = "Field should not be blank")]
        [Display(Name = "Student_PermanentAddress_StreeNo")]
        public string Student_PermanentAddress_StreeNo
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.Student_PermanentAddress_StreeNo : string.Empty;
            }
            set
            {
                StudentRegistrationFormDTO.Student_PermanentAddress_StreeNo = value;
            }
        }
        //[Required(ErrorMessage = "Field should not be blank")]
        [Display(Name = "Student_PermanentAddress_Address1")]
        public string Student_PermanentAddress_Address1
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.Student_PermanentAddress_Address1 : string.Empty;
            }
            set
            {
                StudentRegistrationFormDTO.Student_PermanentAddress_Address1 = value;
            }
        }

        //[Required(ErrorMessage = "Field should not be blank")]
        [Display(Name = "Student_PermanentAddress_Address2")]
        public string Student_PermanentAddress_Address2
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.Student_PermanentAddress_Address2 : string.Empty;
            }
            set
            {
                StudentRegistrationFormDTO.Student_PermanentAddress_Address2 = value;
            }
        }
        //[Required(ErrorMessage = "Field should not be blank")]
        [Display(Name = "Student_PermanentAddress_City_Tahsil")]
        public int Student_PermanentAddress_City_TahsilID
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.Student_PermanentAddress_City_TahsilID : new int();
            }
            set
            {
                StudentRegistrationFormDTO.Student_PermanentAddress_City_TahsilID = value;
            }
        }
        [Display(Name = "Student_PermanentAddress_City_TahsilName")]
        public string Student_PermanentAddress_City_TahsilName
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.Student_PermanentAddress_City_TahsilName : string.Empty;
            }
            set
            {
                StudentRegistrationFormDTO.Student_PermanentAddress_City_TahsilName = value;
            }
        }
        public string Student_PermanentAddress_City_TahsilOther
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.Student_PermanentAddress_City_TahsilOther : string.Empty;
            }
            set
            {
                StudentRegistrationFormDTO.Student_PermanentAddress_City_TahsilOther = value;
            }
        }
        //[Required(ErrorMessage = "Field should not be blank")]
        [Display(Name = "Student_PermanentAddress_CountryId")]
        public int Student_PermanentAddress_CountryId
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.Student_PermanentAddress_CountryId : new int();
            }
            set
            {
                StudentRegistrationFormDTO.Student_PermanentAddress_CountryId = value;
            }
        }
        //[Required(ErrorMessage = "Field should not be blank")]
        [Display(Name = "Student_PermanentAddress_State")]
        public int Student_PermanentAddress_State
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.Student_PermanentAddress_State : new int();
            }
            set
            {
                StudentRegistrationFormDTO.Student_PermanentAddress_State = value;
            }
        }
        //[Required(ErrorMessage = "Field should not be blank")]
        [Display(Name = "Student_PermanentAddress_StateOther")]
        public string Student_PermanentAddress_StateOther
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.Student_PermanentAddress_StateOther : string.Empty;
            }
            set
            {
                StudentRegistrationFormDTO.Student_PermanentAddress_StateOther = value;
            }
        }
        //[Required(ErrorMessage = "Field should not be blank")]
        [Display(Name = "Student_PermanentAddress_District")]
        public int Student_PermanentAddress_DistrictID
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.Student_PermanentAddress_DistrictID : new int();
            }
            set
            {
                StudentRegistrationFormDTO.Student_PermanentAddress_DistrictID = value;
            }
        }
        public string Student_PermanentAddress_DistrictOther
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.Student_PermanentAddress_DistrictOther : string.Empty;
            }
            set
            {
                StudentRegistrationFormDTO.Student_PermanentAddress_DistrictOther = value;
            }
        }
        //[Required(ErrorMessage = "Field should not be blank")]
        [Display(Name = "Student_PermanentAddress_Tahsil")]
        public string Student_PermanentAddress_Tahsil
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.Student_PermanentAddress_Tahsil : string.Empty;
            }
            set
            {
                StudentRegistrationFormDTO.Student_PermanentAddress_Tahsil = value;
            }
        }
        //[Required(ErrorMessage = "Field should not be blank")]
        [Display(Name = "Student_PermanentAddress_NearPoliceStation")]
        public string Student_PermanentAddress_NearPoliceStation
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.Student_PermanentAddress_NearPoliceStation : string.Empty;
            }
            set
            {
                StudentRegistrationFormDTO.Student_PermanentAddress_NearPoliceStation = value;
            }
        }
        //[Required(ErrorMessage = "Field should not be blank")]
        [Display(Name = "Student_PermanentAddress_ZipCode")]
        public string Student_PermanentAddress_ZipCode
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.Student_PermanentAddress_ZipCode : string.Empty;
            }
            set
            {
                StudentRegistrationFormDTO.Student_PermanentAddress_ZipCode = value;
            }
        }
        //[Required(ErrorMessage = "Field should not be blank")]
        [Display(Name = "Student_PermanentAddress_City_Tahsil_Pattern")]
        public string Student_PermanentAddress_City_Tahsil_Pattern
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.Student_PermanentAddress_City_Tahsil_Pattern : string.Empty;
            }
            set
            {
                StudentRegistrationFormDTO.Student_PermanentAddress_City_Tahsil_Pattern = value;
            }
        }
        #endregion  Permanent Address

        #region  Correspondence Address
        public bool SameAsPerPermanentAddress
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.SameAsPerPermanentAddress : false;
            }
            set
            {
                StudentRegistrationFormDTO.SameAsPerPermanentAddress = value;
            }
        }

        //[Required(ErrorMessage = "Field should not be blank")]
        [Display(Name = "Student_CorrespondenceAddress_PloteNo")]
        public string Student_CorrespondenceAddress_PloteNo
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.Student_CorrespondenceAddress_PloteNo : string.Empty;
            }
            set
            {
                StudentRegistrationFormDTO.Student_CorrespondenceAddress_PloteNo = value;
            }
        }
        //[Required(ErrorMessage = "Field should not be blank")]
        [Display(Name = "Student_CorrespondenceAddress_StreeNo")]
        public string Student_CorrespondenceAddress_StreeNo
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.Student_CorrespondenceAddress_StreeNo : string.Empty;
            }
            set
            {
                StudentRegistrationFormDTO.Student_CorrespondenceAddress_StreeNo = value;
            }
        }
        //[Required(ErrorMessage = "Field should not be blank")]
        [Display(Name = "Student_CorrespondenceAddress_Address1")]
        public string Student_CorrespondenceAddress_Address1
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.Student_CorrespondenceAddress_Address1 : string.Empty;
            }
            set
            {
                StudentRegistrationFormDTO.Student_CorrespondenceAddress_Address1 = value;
            }
        }
        //[Required(ErrorMessage = "Field should not be blank")]
        [Display(Name = "Student_CorrespondenceAddress_Address2")]
        public string Student_CorrespondenceAddress_Address2
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.Student_CorrespondenceAddress_Address2 : string.Empty;
            }
            set
            {
                StudentRegistrationFormDTO.Student_CorrespondenceAddress_Address2 = value;
            }
        }
        //[Required(ErrorMessage = "Field should not be blank")]
        [Display(Name = "Student_CorrespondenceAddress_City_Tahsil")]
        public string Student_CorrespondenceAddress_City_TahsilOther
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.Student_CorrespondenceAddress_City_TahsilOther : string.Empty;
            }
            set
            {
                StudentRegistrationFormDTO.Student_CorrespondenceAddress_City_TahsilOther = value;
            }
        }

        public int Student_CorrespondenceAddress_City_TahsilID
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.Student_CorrespondenceAddress_City_TahsilID : new int();
            }
            set
            {
                StudentRegistrationFormDTO.Student_CorrespondenceAddress_City_TahsilID = value;
            }
        }

        [Display(Name = "Student_CorrespondenceAddress_City_Tahsil")]
        public string Student_CorrespondenceAddress_City_TahsilName
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.Student_CorrespondenceAddress_City_TahsilName : string.Empty;
            }
            set
            {
                StudentRegistrationFormDTO.Student_CorrespondenceAddress_City_TahsilName = value;
            }
        }
        //[Required(ErrorMessage = "Field should not be blank")]
        [Display(Name = "Student_CorrespondenceAddress_CountryId")]
        public int Student_CorrespondenceAddress_CountryId
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.Student_CorrespondenceAddress_CountryId : new int();
            }
            set
            {
                StudentRegistrationFormDTO.Student_CorrespondenceAddress_CountryId = value;
            }
        }
        //[Required(ErrorMessage = "Field should not be blank")]
        [Display(Name = "Student_CorrespondenceAddress_State")]
        public int Student_CorrespondenceAddress_State
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.Student_CorrespondenceAddress_State : new int();
            }
            set
            {
                StudentRegistrationFormDTO.Student_CorrespondenceAddress_State = value;
            }
        }
        //[Required(ErrorMessage = "Field should not be blank")]
        [Display(Name = "Student_CorrespondenceAddress_StateOther")]
        public string Student_CorrespondenceAddress_StateOther
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.Student_CorrespondenceAddress_StateOther : string.Empty;
            }
            set
            {
                StudentRegistrationFormDTO.Student_CorrespondenceAddress_StateOther = value;
            }
        }
        //[Required(ErrorMessage = "Field should not be blank")]
        [Display(Name = "Student_CorrespondenceAddress_District")]
        public string Student_CorrespondenceAddress_DistrictOther
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.Student_CorrespondenceAddress_DistrictOther : string.Empty;
            }
            set
            {
                StudentRegistrationFormDTO.Student_CorrespondenceAddress_DistrictOther = value;
            }
        }

        public int Student_CorrespondenceAddress_DistrictID
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.Student_CorrespondenceAddress_DistrictID : new int();
            }
            set
            {
                StudentRegistrationFormDTO.Student_CorrespondenceAddress_DistrictID = value;
            }
        }
        //[Required(ErrorMessage = "Field should not be blank")]
        [Display(Name = "Student_CorrespondenceAddress_Tahsil")]
        public string Student_CorrespondenceAddress_Tahsil
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.Student_CorrespondenceAddress_Tahsil : string.Empty;
            }
            set
            {
                StudentRegistrationFormDTO.Student_CorrespondenceAddress_Tahsil = value;
            }
        }
        //[Required(ErrorMessage = "Field should not be blank")]
        [Display(Name = "Student_CorrespondenceAddress_NearPoliceStation")]
        public string Student_CorrespondenceAddress_NearPoliceStation
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.Student_CorrespondenceAddress_NearPoliceStation : string.Empty;
            }
            set
            {
                StudentRegistrationFormDTO.Student_CorrespondenceAddress_NearPoliceStation = value;
            }
        }
        //[Required(ErrorMessage = "Field should not be blank")]
        [Display(Name = "Student_CorrespondenceAddress_ZipCode")]
        public string Student_CorrespondenceAddress_ZipCode
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.Student_CorrespondenceAddress_ZipCode : string.Empty;
            }
            set
            {
                StudentRegistrationFormDTO.Student_CorrespondenceAddress_ZipCode = value;
            }
        }
        //[Required(ErrorMessage = "Field should not be blank")]
        [Display(Name = "Student_CorrespondenceAddress_City_Tahsil_Pattern")]
        public string Student_CorrespondenceAddress_City_Tahsil_Pattern
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.Student_CorrespondenceAddress_City_Tahsil_Pattern : string.Empty;
            }
            set
            {
                StudentRegistrationFormDTO.Student_CorrespondenceAddress_City_Tahsil_Pattern = value;
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
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.StudentDateofBirth : string.Empty;
            }
            set
            {
                StudentRegistrationFormDTO.StudentDateofBirth = value;
            }
        }
        //[Required(ErrorMessage = "BirthPlace must be selected")]
        [Display(Name = "StudentBirthPlace")]
        public string StudentBirthPlace
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.StudentBirthPlace : string.Empty;
            }
            set
            {
                StudentRegistrationFormDTO.StudentBirthPlace = value;
            }
        }
        //[Required(ErrorMessage = "Religion Name must be selected")]
        //[Display(Name = "StudentReligionID")]
        public int StudentReligionID
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.StudentReligionID : new int();
            }
            set
            {
                StudentRegistrationFormDTO.StudentReligionID = value;
            }
        }
        //[Required(ErrorMessage = "Caste must be selected")]
        //[Display(Name = "StudentCasteID")]
        public int StudentCasteID
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.StudentCasteID : new int();
            }
            set
            {
                StudentRegistrationFormDTO.StudentCasteID = value;
            }
        }
        //[Required(ErrorMessage = "Category must be selected")]
        [Display(Name = "StudentCategoryID")]
        public int StudentCategoryID
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.StudentCategoryID : new int();
            }
            set
            {
                StudentRegistrationFormDTO.StudentCategoryID = value;
            }
        }
        //[Required(ErrorMessage = "Caste as per TC/LC must be selected")]
        [Display(Name = "StudentCasteAsPerTC/LC")]
        public string StudentCasteAsPerTC_LC
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.StudentCasteAsPerTC_LC : string.Empty;
            }
            set
            {
                StudentRegistrationFormDTO.StudentCasteAsPerTC_LC = value;
            }
        }
        //[Required(ErrorMessage = "Mother tonque must be selected")]
        [Display(Name = "StudentMotherTongueID")]
        public int StudentMotherTongueID
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.StudentMotherTongueID : new int();
            }
            set
            {
                StudentRegistrationFormDTO.StudentMotherTongueID = value;
            }
        }
        //[Required(ErrorMessage = "Name as per mark sheet must be selected")]
        [Display(Name = "StudentNameAsPerMarkSheet")]
        public string StudentNameAsPerMarkSheet
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.StudentNameAsPerMarkSheet : string.Empty;
            }
            set
            {
                StudentRegistrationFormDTO.StudentNameAsPerMarkSheet = value;
            }
        }
        //[Required(ErrorMessage = "Last School/College must be selected")]
        [Display(Name = "StudentLastSchool_College")]
        public string StudentLastSchool_College
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.StudentLastSchool_College : string.Empty;
            }
            set
            {
                StudentRegistrationFormDTO.StudentLastSchool_College = value;
            }
        }
        //[Required(ErrorMessage = "Previous LC/TC number must be selected")]
        [Display(Name = "StudentNameAsPerMarkSheet")]
        public string StudentPreviousLC_TCNo
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.StudentPreviousLC_TCNo : string.Empty;
            }
            set
            {
                StudentRegistrationFormDTO.StudentPreviousLC_TCNo = value;
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
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.Student_Ex_Serviceman_Ward_of_Ex_Serviceman : false;
            }
            set
            {
                StudentRegistrationFormDTO.Student_Ex_Serviceman_Ward_of_Ex_Serviceman = value;
            }
        }
        //[Required(ErrorMessage = "Field must be selected")]
        [Display(Name = "Student_Ex_Serviceman_Ward_of_Ex_Serviceman")]
        public bool Student_Active_Serviceman_Ward_of_Active_Serviceman
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.Student_Active_Serviceman_Ward_of_Active_Serviceman : false;
            }
            set
            {
                StudentRegistrationFormDTO.Student_Active_Serviceman_Ward_of_Active_Serviceman = value;
            }
        }
        //[Required(ErrorMessage = "Field must be selected")]
        [Display(Name = "Student_FreedomFighterWardOfFreedomFighter")]
        public bool Student_FreedomFighterWardOfFreedomFighter
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.Student_FreedomFighterWardOfFreedomFighter : false;
            }
            set
            {
                StudentRegistrationFormDTO.Student_FreedomFighterWardOfFreedomFighter = value;
            }
        }
        //[Required(ErrorMessage = "Field must be selected")]
        [Display(Name = "Student_WardofPrimaryTeacher")]
        public bool Student_WardofPrimaryTeacher
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.Student_WardofPrimaryTeacher : false;
            }
            set
            {
                StudentRegistrationFormDTO.Student_WardofPrimaryTeacher = value;
            }
        }
        //[Required(ErrorMessage = "Field must be selected")]
        [Display(Name = "Student_WardofSecondaryTeacher")]
        public bool Student_WardofSecondaryTeacher
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.Student_WardofSecondaryTeacher : false;
            }
            set
            {
                StudentRegistrationFormDTO.Student_WardofSecondaryTeacher = value;
            }
        }
        //[Required(ErrorMessage = "Field must be selected")]
        [Display(Name = "Student_Deserted_Divorced_Widowed_Women")]
        public bool Student_Deserted_Divorced_Widowed_Women
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.Student_Deserted_Divorced_Widowed_Women : false;
            }
            set
            {
                StudentRegistrationFormDTO.Student_Deserted_Divorced_Widowed_Women = value;
            }
        }
        //[Required(ErrorMessage = "Field must be selected")]
        [Display(Name = "Student_MemberofProjectAffectedFamily")]
        public bool Student_MemberofProjectAffectedFamily
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.Student_MemberofProjectAffectedFamily : false;
            }
            set
            {
                StudentRegistrationFormDTO.Student_MemberofProjectAffectedFamily = value;
            }
        }
        //[Required(ErrorMessage = "Field must be selected")]
        [Display(Name = "Student_KashmirMigrant")]
        public bool Student_KashmirMigrant
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.Student_KashmirMigrant : false;
            }
            set
            {
                StudentRegistrationFormDTO.Student_KashmirMigrant = value;
            }
        }
        //[Required(ErrorMessage = "Field must be selected")]
        [Display(Name = "Student_MemberofEarthquakeAffectedFamily")]
        public bool Student_MemberofEarthquakeAffectedFamily
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.Student_MemberofEarthquakeAffectedFamily : false;
            }
            set
            {
                StudentRegistrationFormDTO.Student_MemberofEarthquakeAffectedFamily = value;
            }
        }
        //[Required(ErrorMessage = "Field must be selected")]
        [Display(Name = "Student_MemberofFloodFamineAffectedFamily")]
        public bool Student_MemberofFloodFamineAffectedFamily
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.Student_MemberofFloodFamineAffectedFamily : false;
            }
            set
            {
                StudentRegistrationFormDTO.Student_MemberofFloodFamineAffectedFamily = value;
            }
        }
        //[Required(ErrorMessage = "Field must be selected")]
        [Display(Name = "Student_ResidentofTribalArea")]
        public bool Student_ResidentofTribalArea
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.Student_ResidentofTribalArea : false;
            }
            set
            {
                StudentRegistrationFormDTO.Student_ResidentofTribalArea = value;
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
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.StudentIndicatetypeofCandidature : string.Empty;
            }
            set
            {
                StudentRegistrationFormDTO.StudentIndicatetypeofCandidature = value;
            }
        }
        //[Required(ErrorMessage = "Field should not be blank")]
        [Display(Name = "StudentSchoolFromHSCExaminationpassed")]
        public string StudentSchoolFromHSCExaminationpassed
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.StudentSchoolFromHSCExaminationpassed : string.Empty;
            }
            set
            {
                StudentRegistrationFormDTO.StudentSchoolFromHSCExaminationpassed = value;
            }
        }
        //[Required(ErrorMessage = "Field should not be blank")]
        [Display(Name = "StudentEconomicallyBackwardClass")]
        public string StudentEconomicallyBackwardClass
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.StudentEconomicallyBackwardClass : string.Empty;
            }
            set
            {
                StudentRegistrationFormDTO.StudentEconomicallyBackwardClass = value;
            }
        }
        //[Required(ErrorMessage = "Field should not be blank")]
        [Display(Name = "StudentsNameOfDistrictWhereParentDomiciled")]
        public string StudentsNameOfDistrictWhereParentDomiciled
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.StudentsNameOfDistrictWhereParentDomiciled : string.Empty;
            }
            set
            {
                StudentRegistrationFormDTO.StudentsNameOfDistrictWhereParentDomiciled = value;
            }
        }
        //[Required(ErrorMessage = "Field should not be blank")]
        [Display(Name = "StudentsMKBCandidate")]
        public string StudentsMKBCandidate
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.StudentsMKBCandidate : string.Empty;
            }
            set
            {
                StudentRegistrationFormDTO.StudentsMKBCandidate = value;
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
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.Student_QualifyingExamId : new int();
            }
            set
            {
                StudentRegistrationFormDTO.Student_QualifyingExamId = value;
            }
        }
        //[Required(ErrorMessage = "Field should not be blank")]
        [Display(Name = "Student_QualifyingExamName")]
        public string Student_QualifyingExamName
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.Student_QualifyingExamName : string.Empty;
            }
            set
            {
                StudentRegistrationFormDTO.Student_QualifyingExamName = value;
            }
        }
        //[Required(ErrorMessage = "Field should not be blank")]
        [Display(Name = "Student_QualifyingRollNo")]
        public string Student_QualifyingRollNo
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.Student_QualifyingRollNo : string.Empty;
            }
            set
            {
                StudentRegistrationFormDTO.Student_QualifyingRollNo = value;
            }
        }
        //[Required(ErrorMessage = "Field should not be blank")]
        [Display(Name = "Student_QualifyingExamTotalMarksPointsObtained")]
        public int Student_QualifyingExamTotalMarksPointsObtained
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.Student_QualifyingExamTotalMarksPointsObtained : new int();
            }
            set
            {
                StudentRegistrationFormDTO.Student_QualifyingExamTotalMarksPointsObtained = value;
            }
        }
        //[Required(ErrorMessage = "Field should not be blank")]
        [Display(Name = "Student_QualifyingExamOutOffMark")]
        public int Student_QualifyingExamOutOffMark
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.Student_QualifyingExamOutOffMark : new int();
            }
            set
            {
                StudentRegistrationFormDTO.Student_QualifyingExamOutOffMark = value;
            }
        }
        //[Required(ErrorMessage = "Field should not be blank")]
        [Display(Name = "Student_QualifyingExamRank")]
        public string Student_QualifyingExamRank
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.Student_QualifyingExamRank : string.Empty;
            }
            set
            {
                StudentRegistrationFormDTO.Student_QualifyingExamRank = value;
            }
        }
        //[Required(ErrorMessage = "Field should not be blank")]
        [Display(Name = "Student_QualifyingExamRank")]
        public int Student_QualifyingExamTotalMarksPointsObtainedInSubject
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.Student_QualifyingExamTotalMarksPointsObtainedInSubject : new int();
            }
            set
            {
                StudentRegistrationFormDTO.Student_QualifyingExamTotalMarksPointsObtainedInSubject = value;
            }
        }

        public int Student_QualifyingTransactionID
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.Student_QualifyingTransactionID : new int();
            }
            set
            {
                StudentRegistrationFormDTO.Student_QualifyingTransactionID = value;
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
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.Student_Qualification_General_MediumOfInstitution : new int();
            }
            set
            {
                StudentRegistrationFormDTO.Student_Qualification_General_MediumOfInstitution = value;
            }
        }
        //[Required(ErrorMessage = "Field must be selected")]
        [Display(Name = "Student_Qualification_General_MonthOfPassing")]

        public int Student_Qualification_General_MonthOfPassing
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.Student_Qualification_General_MonthOfPassing : new int();
            }
            set
            {
                StudentRegistrationFormDTO.Student_Qualification_General_MonthOfPassing = value;
            }

        }
        //[Required(ErrorMessage = "Field must be selected")]
        [Display(Name = "Student_Qualification_General_YearOfPassing")]
        public int Student_Qualification_General_YearOfPassing
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.Student_Qualification_General_YearOfPassing : new int();
            }
            set
            {
                StudentRegistrationFormDTO.Student_Qualification_General_YearOfPassing = value;
            }

        }
        //[Required(ErrorMessage = "Field should not be blank")]
        [Display(Name = "Student_Qualification_General_SingleAttempt")]
        public string Student_Qualification_General_SingleAttempt
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.Student_Qualification_General_SingleAttempt : string.Empty;
            }
            set
            {
                StudentRegistrationFormDTO.Student_Qualification_General_SingleAttempt = value;
            }
        }
        //[Required(ErrorMessage = "Field must be selected")]
        [Display(Name = "Student_Qualification_General_Percent")]
        public int Student_Qualification_General_Percent
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.Student_Qualification_General_Percent : new int();
            }
            set
            {
                StudentRegistrationFormDTO.Student_Qualification_General_Percent = value;
            }

        }
        //[Required(ErrorMessage = "Field must be selected")]
        [Display(Name = "Student_Qualification_General_ObtainedMark")]
        public int Student_Qualification_General_ObtainedMark
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.Student_Qualification_General_ObtainedMark : new int();
            }
            set
            {
                StudentRegistrationFormDTO.Student_Qualification_General_ObtainedMark = value;
            }

        }
        //[Required(ErrorMessage = "Field must be selected")]
        [Display(Name = "Student_Qualification_General_OutOfMark")]
        public int Student_Qualification_General_OutOfMark
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.Student_Qualification_General_OutOfMark : new int();
            }
            set
            {
                StudentRegistrationFormDTO.Student_Qualification_General_OutOfMark = value;
            }
        }
        //[Required(ErrorMessage = "Field should not be blank")]
        [Display(Name = "Student_Qualification_General_Region_Division_Board")]
        public string Student_Qualification_General_Region_Division_Board
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.Student_Qualification_General_Region_Division_Board : string.Empty;
            }
            set
            {
                StudentRegistrationFormDTO.Student_Qualification_General_Region_Division_Board = value;
            }
        }
        //[Required(ErrorMessage = "Field should not be blank")]
        [Display(Name = "Student_Qualification_General_NameofInstitution")]
        public string Student_Qualification_General_NameofInstitution
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.Student_Qualification_General_NameofInstitution : string.Empty;
            }
            set
            {
                StudentRegistrationFormDTO.Student_Qualification_General_NameofInstitution = value;
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
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.Student_Qualification_SSC_MediumOfInstitution : new int();
            }
            set
            {
                StudentRegistrationFormDTO.Student_Qualification_SSC_MediumOfInstitution = value;
            }
        }
        //[Required(ErrorMessage = "Field must be selected")]
        [Display(Name = "Student_Qualification_SSC_MonthOfPassing")]

        public int Student_Qualification_SSC_MonthOfPassing
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.Student_Qualification_SSC_MonthOfPassing : new int();
            }
            set
            {
                StudentRegistrationFormDTO.Student_Qualification_SSC_MonthOfPassing = value;
            }

        }
        //[Required(ErrorMessage = "Field must be selected")]
        [Display(Name = "Student_Qualification_SSC_YearOfPassing")]
        public int Student_Qualification_SSC_YearOfPassing
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.Student_Qualification_SSC_YearOfPassing : new int();
            }
            set
            {
                StudentRegistrationFormDTO.Student_Qualification_SSC_YearOfPassing = value;
            }

        }
        //[Required(ErrorMessage = "Field should not be blank")]
        [Display(Name = "Student_Qualification_SSC_SingleAttempt")]
        public string Student_Qualification_SSC_SingleAttempt
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.Student_Qualification_SSC_SingleAttempt : string.Empty;
            }
            set
            {
                StudentRegistrationFormDTO.Student_Qualification_SSC_SingleAttempt = value;
            }
        }
        //[Required(ErrorMessage = "Field must be selected")]
        [Display(Name = "Student_Qualification_SSC_Percent")]
        public int Student_Qualification_SSC_Percent
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.Student_Qualification_SSC_Percent : new int();
            }
            set
            {
                StudentRegistrationFormDTO.Student_Qualification_SSC_Percent = value;
            }

        }
        //[Required(ErrorMessage = "Field must be selected")]
        [Display(Name = "Student_Qualification_SSC_ObtainedMark")]
        public int Student_Qualification_SSC_ObtainedMark
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.Student_Qualification_SSC_ObtainedMark : new int();
            }
            set
            {
                StudentRegistrationFormDTO.Student_Qualification_SSC_ObtainedMark = value;
            }

        }
        //[Required(ErrorMessage = "Field must be selected")]
        [Display(Name = "Student_Qualification_SSC_OutOfMark")]
        public int Student_Qualification_SSC_OutOfMark
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.Student_Qualification_SSC_OutOfMark : new int();
            }
            set
            {
                StudentRegistrationFormDTO.Student_Qualification_SSC_OutOfMark = value;
            }
        }
        //[Required(ErrorMessage = "Field should not be blank")]
        [Display(Name = "Student_Qualification_SSC_Region_Division_Board")]
        public string Student_Qualification_SSC_Region_Division_Board
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.Student_Qualification_SSC_Region_Division_Board : string.Empty;
            }
            set
            {
                StudentRegistrationFormDTO.Student_Qualification_SSC_Region_Division_Board = value;
            }
        }
        //[Required(ErrorMessage = "Field should not be blank")]
        [Display(Name = "Student_Qualification_SSC_NameofInstitution")]
        public string Student_Qualification_SSC_NameofInstitution
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.Student_Qualification_SSC_NameofInstitution : string.Empty;
            }
            set
            {
                StudentRegistrationFormDTO.Student_Qualification_SSC_NameofInstitution = value;
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
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.Student_Qualification_HSC_MediumOfInstitution : new int();
            }
            set
            {
                StudentRegistrationFormDTO.Student_Qualification_HSC_MediumOfInstitution = value;
            }
        }
        //[Required(ErrorMessage = "Field must be selected")]
        [Display(Name = "Student_Qualification_HSC_MonthOfPassing")]

        public int Student_Qualification_HSC_MonthOfPassing
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.Student_Qualification_HSC_MonthOfPassing : new int();
            }
            set
            {
                StudentRegistrationFormDTO.Student_Qualification_HSC_MonthOfPassing = value;
            }

        }
        //[Required(ErrorMessage = "Field must be selected")]
        [Display(Name = "Student_Qualification_HSC_YearOfPassing")]
        public int Student_Qualification_HSC_YearOfPassing
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.Student_Qualification_HSC_YearOfPassing : new int();
            }
            set
            {
                StudentRegistrationFormDTO.Student_Qualification_HSC_YearOfPassing = value;
            }

        }
        //[Required(ErrorMessage = "Field must be selected")]
        [Display(Name = "Student_Qualification_HSC_StreamID")]
        public int Student_Qualification_HSC_StreamID
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.Student_Qualification_HSC_StreamID : new int();
            }
            set
            {
                StudentRegistrationFormDTO.Student_Qualification_HSC_StreamID = value;
            }

        }
        //[Required(ErrorMessage = "Field should not be blank")]
        [Display(Name = "Student_Qualification_HSC_StreamOther")]
        public string Student_Qualification_HSC_StreamOther
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.Student_Qualification_HSC_StreamOther : string.Empty;
            }
            set
            {
                StudentRegistrationFormDTO.Student_Qualification_HSC_StreamOther = value;
            }

        }
        //[Required(ErrorMessage = "Field should not be blank")]
        [Display(Name = "Student_Qualification_HSC_SingleAttempt")]
        public string Student_Qualification_HSC_SingleAttempt
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.Student_Qualification_HSC_SingleAttempt : string.Empty;
            }
            set
            {
                StudentRegistrationFormDTO.Student_Qualification_HSC_SingleAttempt = value;
            }
        }
        //[Required(ErrorMessage = "Field should not be blank")]
        [Display(Name = "Student_Qualification_HSC_Class")]
        public string Student_Qualification_HSC_Class
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.Student_Qualification_HSC_Class : string.Empty;
            }
            set
            {
                StudentRegistrationFormDTO.Student_Qualification_HSC_Class = value;
            }

        }

        //[Required(ErrorMessage = "Field must be selected")]
        [Display(Name = "Student_Qualification_HSC_ObtainedMark")]
        public int Student_Qualification_HSC_ObtainedMark
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.Student_Qualification_HSC_ObtainedMark : new int();
            }
            set
            {
                StudentRegistrationFormDTO.Student_Qualification_HSC_ObtainedMark = value;
            }

        }
        //[Required(ErrorMessage = "Field must be selected")]
        [Display(Name = "Student_Qualification_HSC_OutOfMark")]
        public int Student_Qualification_HSC_OutOfMark
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.Student_Qualification_HSC_OutOfMark : new int();
            }
            set
            {
                StudentRegistrationFormDTO.Student_Qualification_HSC_OutOfMark = value;
            }
        }
        //[Required(ErrorMessage = "Field must be selected")]
        [Display(Name = "Student_Qualification_HSC_Percent")]
        public int Student_Qualification_HSC_Percent
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.Student_Qualification_HSC_Percent : new int();
            }
            set
            {
                StudentRegistrationFormDTO.Student_Qualification_HSC_Percent = value;
            }

        }
        //[Required(ErrorMessage = "Field must be selected")]
        [Display(Name = "Student_Qualification_HSC_PCM_PVM_ObtainedMark")]
        public int Student_Qualification_HSC_PCM_PVM_ObtainedMark
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.Student_Qualification_HSC_PCM_PVM_ObtainedMark : new int();
            }
            set
            {
                StudentRegistrationFormDTO.Student_Qualification_HSC_PCM_PVM_ObtainedMark = value;
            }

        }
        //[Required(ErrorMessage = "Field must be selected")]
        [Display(Name = "Student_Qualification_HSC_PCM_PVM_OutOfMark")]
        public int Student_Qualification_HSC_PCM_PVM_OutOfMark
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.Student_Qualification_HSC_PCM_PVM_OutOfMark : new int();
            }
            set
            {
                StudentRegistrationFormDTO.Student_Qualification_HSC_PCM_PVM_OutOfMark = value;
            }
        }
        //[Required(ErrorMessage = "Field must be selected")]
        [Display(Name = "Student_Qualification_HSC_PCB_ObtainedMark")]
        public int Student_Qualification_HSC_PCB_ObtainedMark
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.Student_Qualification_HSC_PCB_ObtainedMark : new int();
            }
            set
            {
                StudentRegistrationFormDTO.Student_Qualification_HSC_PCB_ObtainedMark = value;
            }
        }
        //[Required(ErrorMessage = "Field must be selected")]
        [Display(Name = "Student_Qualification_HSC_PCB_OutOfMark")]
        public int Student_Qualification_HSC_PCB_OutOfMark
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.Student_Qualification_HSC_PCB_OutOfMark : new int();
            }
            set
            {
                StudentRegistrationFormDTO.Student_Qualification_HSC_PCB_OutOfMark = value;
            }
        }
        //[Required(ErrorMessage = "Field should not be blank")]
        [Display(Name = "Student_Qualification_HSC_Region_Division_Board")]
        public string Student_Qualification_HSC_Region_Division_Board
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.Student_Qualification_HSC_Region_Division_Board : string.Empty;
            }
            set
            {
                StudentRegistrationFormDTO.Student_Qualification_HSC_Region_Division_Board = value;
            }
        }
        //[Required(ErrorMessage = "Field should not be blank")]
        [Display(Name = "Student_Qualification_HSC_NameofInstitution")]
        public string Student_Qualification_HSC_NameofInstitution
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.Student_Qualification_HSC_NameofInstitution : string.Empty;
            }
            set
            {
                StudentRegistrationFormDTO.Student_Qualification_HSC_NameofInstitution = value;
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
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.Student_Qualification_Diploma_ITI_Details_MediumOfInstitution : new int();
            }
            set
            {
                StudentRegistrationFormDTO.Student_Qualification_Diploma_ITI_Details_MediumOfInstitution = value;
            }

        }
        //[Required(ErrorMessage = "Field must be selected")]
        [Display(Name = "Student_Qualification_Diploma_ITI_Details_BranchId")]
        public int Student_Qualification_Diploma_ITI_Details_BranchId
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.Student_Qualification_Diploma_ITI_Details_BranchId : new int();
            }
            set
            {
                StudentRegistrationFormDTO.Student_Qualification_Diploma_ITI_Details_BranchId = value;
            }

        }
        //[Required(ErrorMessage = "Field must be selected")]
        [Display(Name = "Student_Qualification_Diploma_ITI_Details_BranchName")]
        public string Student_Qualification_Diploma_ITI_Details_BranchName
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.Student_Qualification_Diploma_ITI_Details_BranchName : string.Empty;
            }
            set
            {
                StudentRegistrationFormDTO.Student_Qualification_Diploma_ITI_Details_BranchName = value;
            }
        }
        //[Required(ErrorMessage = "Field should not be blank")]
        [Display(Name = "Student_Qualification_Diploma_ITI_Details_ExamPattern")]
        public string Student_Qualification_Diploma_ITI_Details_ExamPattern
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.Student_Qualification_Diploma_ITI_Details_ExamPattern : string.Empty;
            }
            set
            {
                StudentRegistrationFormDTO.Student_Qualification_Diploma_ITI_Details_ExamPattern = value;
            }

        }
        //[Required(ErrorMessage = "Field must be selected")]
        [Display(Name = "Student_Qualification_Diploma_ITI_Details_MonthOfPassing")]
        public int Student_Qualification_Diploma_ITI_Details_MonthOfPassing
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.Student_Qualification_Diploma_ITI_Details_MonthOfPassing : new int();
            }
            set
            {
                StudentRegistrationFormDTO.Student_Qualification_Diploma_ITI_Details_MonthOfPassing = value;
            }
        }
        //[Required(ErrorMessage = "Field must be selected")]
        [Display(Name = "Student_Qualification_Diploma_ITI_Details_YearOfPassing")]
        public int Student_Qualification_Diploma_ITI_Details_YearOfPassing
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.Student_Qualification_Diploma_ITI_Details_YearOfPassing : new int();
            }
            set
            {
                StudentRegistrationFormDTO.Student_Qualification_Diploma_ITI_Details_YearOfPassing = value;
            }

        }
        //[Required(ErrorMessage = "Field should not be blank")]
        [Display(Name = "Student_Qualification_Diploma_ITI_Details_Class")]
        public string Student_Qualification_Diploma_ITI_Details_Class
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.Student_Qualification_Diploma_ITI_Details_Class : string.Empty;
            }
            set
            {
                StudentRegistrationFormDTO.Student_Qualification_Diploma_ITI_Details_Class = value;
            }
        }
        //[Required(ErrorMessage = "Field must be selected")]
        [Display(Name = "Student_Qualification_Diploma_ITI_Details_ObtainedMark")]
        public int Student_Qualification_Diploma_ITI_Details_ObtainedMark
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.Student_Qualification_Diploma_ITI_Details_ObtainedMark : new int();
            }
            set
            {
                StudentRegistrationFormDTO.Student_Qualification_Diploma_ITI_Details_ObtainedMark = value;
            }
        }
        //[Required(ErrorMessage = "Field must be selected")]
        [Display(Name = "Student_Qualification_Diploma_ITI_Details_OutOfMark")]
        public int Student_Qualification_Diploma_ITI_Details_OutOfMark
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.Student_Qualification_Diploma_ITI_Details_OutOfMark : new int();
            }
            set
            {
                StudentRegistrationFormDTO.Student_Qualification_Diploma_ITI_Details_OutOfMark = value;
            }
        }
        //[Required(ErrorMessage = "Field must be selected")]
        [Display(Name = "Student_Qualification_Diploma_ITI_Details_Percent")]
        public int Student_Qualification_Diploma_ITI_Details_Percent
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.Student_Qualification_Diploma_ITI_Details_Percent : new int();
            }
            set
            {
                StudentRegistrationFormDTO.Student_Qualification_Diploma_ITI_Details_Percent = value;
            }
        }
        //[Required(ErrorMessage = "Field should not be blank")]
        [Display(Name = "Student_Qualification_Diploma_ITI_Details_SingleAttempt")]
        public string Student_Qualification_Diploma_ITI_Details_SingleAttempt
        {

            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.Student_Qualification_Diploma_ITI_Details_SingleAttempt : string.Empty;
            }
            set
            {
                StudentRegistrationFormDTO.Student_Qualification_Diploma_ITI_Details_SingleAttempt = value;
            }
        }
        //[Required(ErrorMessage = "Field should not be blank")]
        [Display(Name = "Student_Qualification_Diploma_ITI_Details_BoardEnrollmentNumber")]
        public string Student_Qualification_Diploma_ITI_Details_BoardEnrollmentNumber
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.Student_Qualification_Diploma_ITI_Details_BoardEnrollmentNumber : string.Empty;
            }
            set
            {
                StudentRegistrationFormDTO.Student_Qualification_Diploma_ITI_Details_BoardEnrollmentNumber = value;
            }

        }
        //[Required(ErrorMessage = "Field should not be blank")]
        [Display(Name = "Student_Qualification_Diploma_ITI_Details_NameofInstitution")]
        public string Student_Qualification_Diploma_ITI_Details_NameofInstitution
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.Student_Qualification_Diploma_ITI_Details_NameofInstitution : string.Empty;
            }
            set
            {
                StudentRegistrationFormDTO.Student_Qualification_Diploma_ITI_Details_NameofInstitution = value;
            }
        }
        //[Required(ErrorMessage = "Field should not be blank")]
        [Display(Name = "Student_Qualification_Diploma_ITI_Details_Board")]
        public string Student_Qualification_Diploma_ITI_Details_Board
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.Student_Qualification_Diploma_ITI_Details_Board : string.Empty;
            }
            set
            {
                StudentRegistrationFormDTO.Student_Qualification_Diploma_ITI_Details_Board = value;
            }
        }
        //[Required(ErrorMessage = "Field should not be blank")]
        [Display(Name = "Student_Qualification_Diploma_ITI_Details_State")]
        public int Student_Qualification_Diploma_ITI_Details_State
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.Student_Qualification_Diploma_ITI_Details_State : new int();
            }
            set
            {
                StudentRegistrationFormDTO.Student_Qualification_Diploma_ITI_Details_State = value;
            }
        }

        //[Required(ErrorMessage = "Field should not be blank")]
        [Display(Name = "Student_Qualification_Diploma_ITI_Details_StateOther")]
        public string Student_Qualification_Diploma_ITI_Details_StateOther
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.Student_Qualification_Diploma_ITI_Details_StateOther : string.Empty;
            }
            set
            {
                StudentRegistrationFormDTO.Student_Qualification_Diploma_ITI_Details_StateOther = value;
            }
        }
        public int Student_Qualification_Diploma_ITI_Details_CountryId
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.Student_Qualification_Diploma_ITI_Details_CountryId : new int();
            }
            set
            {
                StudentRegistrationFormDTO.Student_Qualification_Diploma_ITI_Details_CountryId = value;
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
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.Student_Qualification_DegreeDetails_MediumOfInstitution : new int();
            }
            set
            {
                StudentRegistrationFormDTO.Student_Qualification_DegreeDetails_MediumOfInstitution = value;
            }

        }
        //[Required(ErrorMessage = "Field must be selected")]
        [Display(Name = "Student_Qualification_DegreeDetails_BranchId")]
        public int Student_Qualification_DegreeDetails_BranchId
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.Student_Qualification_DegreeDetails_BranchId : new int();
            }
            set
            {
                StudentRegistrationFormDTO.Student_Qualification_DegreeDetails_BranchId = value;
            }

        }
        //[Required(ErrorMessage = "Field must be selected")]
        [Display(Name = "Student_Qualification_DegreeDetails_BranchName")]
        public string Student_Qualification_DegreeDetails_BranchName
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.Student_Qualification_DegreeDetails_BranchName : string.Empty;
            }
            set
            {
                StudentRegistrationFormDTO.Student_Qualification_DegreeDetails_BranchName = value;
            }
        }
        //[Required(ErrorMessage = "Field should not be blank")]
        [Display(Name = "Student_Qualification_DegreeDetails_ExamPattern")]
        public string Student_Qualification_DegreeDetails_ExamPattern
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.Student_Qualification_DegreeDetails_ExamPattern : string.Empty;
            }
            set
            {
                StudentRegistrationFormDTO.Student_Qualification_DegreeDetails_ExamPattern = value;
            }

        }
        //[Required(ErrorMessage = "Field must be selected")]
        [Display(Name = "Student_Qualification_DegreeDetails_MonthOfPassing")]
        public int Student_Qualification_DegreeDetails_MonthOfPassing
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.Student_Qualification_DegreeDetails_MonthOfPassing : new int();
            }
            set
            {
                StudentRegistrationFormDTO.Student_Qualification_DegreeDetails_MonthOfPassing = value;
            }
        }
        //[Required(ErrorMessage = "Field must be selected")]
        [Display(Name = "Student_Qualification_DegreeDetails_YearOfPassing")]
        public int Student_Qualification_DegreeDetails_YearOfPassing
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.Student_Qualification_DegreeDetails_YearOfPassing : new int();
            }
            set
            {
                StudentRegistrationFormDTO.Student_Qualification_DegreeDetails_YearOfPassing = value;
            }

        }
        //[Required(ErrorMessage = "Field should not be blank")]
        [Display(Name = "Student_Qualification_DegreeDetails_Class")]
        public string Student_Qualification_DegreeDetails_Class
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.Student_Qualification_DegreeDetails_Class : string.Empty;
            }
            set
            {
                StudentRegistrationFormDTO.Student_Qualification_DegreeDetails_Class = value;
            }
        }
        //[Required(ErrorMessage = "Field must be selected")]
        [Display(Name = "Student_Qualification_DegreeDetails_ObtainedMark")]
        public int Student_Qualification_DegreeDetails_ObtainedMark
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.Student_Qualification_DegreeDetails_ObtainedMark : new int();
            }
            set
            {
                StudentRegistrationFormDTO.Student_Qualification_DegreeDetails_ObtainedMark = value;
            }
        }
        //[Required(ErrorMessage = "Field must be selected")]
        [Display(Name = "Student_Qualification_DegreeDetails_OutOfMark")]
        public int Student_Qualification_DegreeDetails_OutOfMark
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.Student_Qualification_DegreeDetails_OutOfMark : new int();
            }
            set
            {
                StudentRegistrationFormDTO.Student_Qualification_DegreeDetails_OutOfMark = value;
            }
        }
        //[Required(ErrorMessage = "Field must be selected")]
        [Display(Name = "Student_Qualification_DegreeDetails_Percent")]
        public int Student_Qualification_DegreeDetails_Percent
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.Student_Qualification_DegreeDetails_Percent : new int();
            }
            set
            {
                StudentRegistrationFormDTO.Student_Qualification_DegreeDetails_Percent = value;
            }
        }
        //[Required(ErrorMessage = "Field should not be blank")]
        [Display(Name = "Student_Qualification_DegreeDetails_SingleAttempt")]
        public string Student_Qualification_DegreeDetails_SingleAttempt
        {

            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.Student_Qualification_DegreeDetails_SingleAttempt : string.Empty;
            }
            set
            {
                StudentRegistrationFormDTO.Student_Qualification_DegreeDetails_SingleAttempt = value;
            }
        }
        //[Required(ErrorMessage = "Field should not be blank")]
        [Display(Name = "Student_Qualification_DegreeDetails_BoardEnrollmentNumber")]
        public string Student_Qualification_DegreeDetails_BoardEnrollmentNumber
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.Student_Qualification_DegreeDetails_BoardEnrollmentNumber : string.Empty;
            }
            set
            {
                StudentRegistrationFormDTO.Student_Qualification_DegreeDetails_BoardEnrollmentNumber = value;
            }

        }
        //[Required(ErrorMessage = "Field should not be blank")]
        [Display(Name = "Student_Qualification_DegreeDetails_NameofInstitution")]
        public string Student_Qualification_DegreeDetails_NameofInstitution
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.Student_Qualification_DegreeDetails_NameofInstitution : string.Empty;
            }
            set
            {
                StudentRegistrationFormDTO.Student_Qualification_DegreeDetails_NameofInstitution = value;
            }
        }
        //[Required(ErrorMessage = "Field must be selected")]
        [Display(Name = "Student_Qualification_DegreeDetails_UniversityId")]
        public int Student_Qualification_DegreeDetails_UniversityId
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.Student_Qualification_DegreeDetails_UniversityId : new int();
            }
            set
            {
                StudentRegistrationFormDTO.Student_Qualification_DegreeDetails_UniversityId = value;
            }
        }
        //[Required(ErrorMessage = "Field should not be blank")]
        [Display(Name = "Student_Qualification_DegreeDetails_UniversityNameOther")]
        public string Student_Qualification_DegreeDetails_UniversityName
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.Student_Qualification_DegreeDetails_UniversityName : string.Empty;
            }
            set
            {
                StudentRegistrationFormDTO.Student_Qualification_DegreeDetails_UniversityName = value;
            }
        }
        //[Required(ErrorMessage = "Field should not be blank")]
        [Display(Name = "Student_Qualification_DegreeDetails_State")]
        public int Student_Qualification_DegreeDetails_State
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.Student_Qualification_DegreeDetails_State : new int();
            }
            set
            {
                StudentRegistrationFormDTO.Student_Qualification_DegreeDetails_State = value;
            }
        }
        //[Required(ErrorMessage = "Field should not be blank")]
        [Display(Name = "Student_Qualification_DegreeDetails_StateOther")]
        public string Student_Qualification_DegreeDetails_StateOther
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.Student_Qualification_DegreeDetails_StateOther : string.Empty;
            }
            set
            {
                StudentRegistrationFormDTO.Student_Qualification_DegreeDetails_StateOther = value;
            }
        }
        //[Required(ErrorMessage = "Field should not be blank")]
        [Display(Name = "Student_Qualification_DegreeDetails_Degree")]
        public string Student_Qualification_DegreeDetails_Degree
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.Student_Qualification_DegreeDetails_Degree : string.Empty;
            }
            set
            {
                StudentRegistrationFormDTO.Student_Qualification_DegreeDetails_Degree = value;
            }
        }

        public int Student_Qualification_DegreeDetails_CountryId
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.Student_Qualification_DegreeDetails_CountryId : new int();
            }
            set
            {
                StudentRegistrationFormDTO.Student_Qualification_DegreeDetails_CountryId = value;
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
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.Student_Qualification_PostGraduationDetails_MediumOfInstitution : new int();
            }
            set
            {
                StudentRegistrationFormDTO.Student_Qualification_PostGraduationDetails_MediumOfInstitution = value;
            }

        }
        //[Required(ErrorMessage = "Field must be selected")]
        [Display(Name = "Student_Qualification_PostGraduationDetails_BranchId")]
        public int Student_Qualification_PostGraduationDetails_BranchId
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.Student_Qualification_PostGraduationDetails_BranchId : new int();
            }
            set
            {
                StudentRegistrationFormDTO.Student_Qualification_PostGraduationDetails_BranchId = value;
            }

        }
        //[Required(ErrorMessage = "Field must be selected")]
        [Display(Name = "Student_Qualification_PostGraduationDetails_BranchName")]
        public string Student_Qualification_PostGraduationDetails_BranchName
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.Student_Qualification_PostGraduationDetails_BranchName : string.Empty;
            }
            set
            {
                StudentRegistrationFormDTO.Student_Qualification_PostGraduationDetails_BranchName = value;
            }
        }
        //[Required(ErrorMessage = "Field should not be blank")]
        [Display(Name = "Student_Qualification_PostGraduationDetails_ExamPattern")]
        public string Student_Qualification_PostGraduationDetails_ExamPattern
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.Student_Qualification_PostGraduationDetails_ExamPattern : string.Empty;
            }
            set
            {
                StudentRegistrationFormDTO.Student_Qualification_PostGraduationDetails_ExamPattern = value;
            }

        }
        //[Required(ErrorMessage = "Field must be selected")]
        [Display(Name = "Student_Qualification_PostGraduationDetails_MonthOfPassing")]
        public int Student_Qualification_PostGraduationDetails_MonthOfPassing
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.Student_Qualification_PostGraduationDetails_MonthOfPassing : new int();
            }
            set
            {
                StudentRegistrationFormDTO.Student_Qualification_PostGraduationDetails_MonthOfPassing = value;
            }
        }
        //[Required(ErrorMessage = "Field must be selected")]
        [Display(Name = "Student_Qualification_PostGraduationDetails_YearOfPassing")]
        public int Student_Qualification_PostGraduationDetails_YearOfPassing
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.Student_Qualification_PostGraduationDetails_YearOfPassing : new int();
            }
            set
            {
                StudentRegistrationFormDTO.Student_Qualification_PostGraduationDetails_YearOfPassing = value;
            }

        }
        //[Required(ErrorMessage = "Field should not be blank")]
        [Display(Name = "Student_Qualification_PostGraduationDetails_Class")]
        public string Student_Qualification_PostGraduationDetails_Class
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.Student_Qualification_PostGraduationDetails_Class : string.Empty;
            }
            set
            {
                StudentRegistrationFormDTO.Student_Qualification_PostGraduationDetails_Class = value;
            }
        }
        //[Required(ErrorMessage = "Field must be selected")]
        [Display(Name = "Student_Qualification_PostGraduationDetails_ObtainedMark")]
        public int Student_Qualification_PostGraduationDetails_ObtainedMark
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.Student_Qualification_PostGraduationDetails_ObtainedMark : new int();
            }
            set
            {
                StudentRegistrationFormDTO.Student_Qualification_PostGraduationDetails_ObtainedMark = value;
            }
        }
        //[Required(ErrorMessage = "Field must be selected")]
        [Display(Name = "Student_Qualification_PostGraduationDetails_OutOfMark")]
        public int Student_Qualification_PostGraduationDetails_OutOfMark
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.Student_Qualification_PostGraduationDetails_OutOfMark : new int();
            }
            set
            {
                StudentRegistrationFormDTO.Student_Qualification_PostGraduationDetails_OutOfMark = value;
            }
        }
        //[Required(ErrorMessage = "Field must be selected")]
        [Display(Name = "Student_Qualification_PostGraduationDetails_Percent")]
        public int Student_Qualification_PostGraduationDetails_Percent
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.Student_Qualification_PostGraduationDetails_Percent : new int();
            }
            set
            {
                StudentRegistrationFormDTO.Student_Qualification_PostGraduationDetails_Percent = value;
            }
        }
        //[Required(ErrorMessage = "Field should not be blank")]
        [Display(Name = "Student_Qualification_PostGraduationDetails_SingleAttempt")]
        public string Student_Qualification_PostGraduationDetails_SingleAttempt
        {

            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.Student_Qualification_PostGraduationDetails_SingleAttempt : string.Empty;
            }
            set
            {
                StudentRegistrationFormDTO.Student_Qualification_PostGraduationDetails_SingleAttempt = value;
            }
        }
        //[Required(ErrorMessage = "Field should not be blank")]
        [Display(Name = "Student_Qualification_PostGraduationDetails_BoardEnrollmentNumber")]
        public string Student_Qualification_PostGraduationDetails_BoardEnrollmentNumber
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.Student_Qualification_PostGraduationDetails_BoardEnrollmentNumber : string.Empty;
            }
            set
            {
                StudentRegistrationFormDTO.Student_Qualification_PostGraduationDetails_BoardEnrollmentNumber = value;
            }

        }
        //[Required(ErrorMessage = "Field should not be blank")]
        [Display(Name = "Student_Qualification_PostGraduationDetails_NameofInstitution")]
        public string Student_Qualification_PostGraduationDetails_NameofInstitution
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.Student_Qualification_PostGraduationDetails_NameofInstitution : string.Empty;
            }
            set
            {
                StudentRegistrationFormDTO.Student_Qualification_PostGraduationDetails_NameofInstitution = value;
            }
        }
        //[Required(ErrorMessage = "Field must be selected")]
        [Display(Name = "Student_Qualification_PostGraduationDetails_UniversityId")]
        public int Student_Qualification_PostGraduationDetails_UniversityId
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.Student_Qualification_PostGraduationDetails_UniversityId : new int();
            }
            set
            {
                StudentRegistrationFormDTO.Student_Qualification_PostGraduationDetails_UniversityId = value;
            }
        }
        //[Required(ErrorMessage = "Field should not be blank")]
        [Display(Name = "Student_Qualification_PostGraduationDetails_UniversityName")]
        public string Student_Qualification_PostGraduationDetails_UniversityName
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.Student_Qualification_PostGraduationDetails_UniversityName : string.Empty;
            }
            set
            {
                StudentRegistrationFormDTO.Student_Qualification_PostGraduationDetails_UniversityName = value;
            }
        }

        //[Required(ErrorMessage = "Field should not be blank")]
        [Display(Name = "Student_Qualification_PostGraduationDetails_State")]
        public int Student_Qualification_PostGraduationDetails_State
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.Student_Qualification_PostGraduationDetails_State : new int();
            }
            set
            {
                StudentRegistrationFormDTO.Student_Qualification_PostGraduationDetails_State = value;
            }
        }
        //[Required(ErrorMessage = "Field should not be blank")]
        [Display(Name = "Student_Qualification_PostGraduationDetails_StateOther")]
        public string Student_Qualification_PostGraduationDetails_StateOther
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.Student_Qualification_PostGraduationDetails_StateOther : string.Empty;
            }
            set
            {
                StudentRegistrationFormDTO.Student_Qualification_PostGraduationDetails_StateOther = value;
            }
        }
        //[Required(ErrorMessage = "Field should not be blank")]
        [Display(Name = "Student_Qualification_PostGraduationDetails_PostGraduation")]
        public string Student_Qualification_PostGraduationDetails_PostGraduation
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.Student_Qualification_PostGraduationDetails_PostGraduation : string.Empty;
            }
            set
            {
                StudentRegistrationFormDTO.Student_Qualification_PostGraduationDetails_PostGraduation = value;
            }
        }

        public int Student_Qualification_PostGraduationDetails_CountryId
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.Student_Qualification_PostGraduationDetails_CountryId : new int();
            }
            set
            {
                StudentRegistrationFormDTO.Student_Qualification_PostGraduationDetails_CountryId = value;
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
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.Student_DTE_DTEUserID : string.Empty;
            }
            set
            {
                StudentRegistrationFormDTO.Student_DTE_DTEUserID = value;
            }
        }
        //[Required(ErrorMessage = "Field should not be blank")]
        [Display(Name = "Student_DTE_DTEPassword")]
        public string Student_DTE_DTEPassword
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.Student_DTE_DTEPassword : string.Empty;
            }
            set
            {
                StudentRegistrationFormDTO.Student_DTE_DTEPassword = value;
            }
        }
        //[Required(ErrorMessage = "Field should not be blank")]
        [Display(Name = "Student_DTE_DTESrNo")]
        public string Student_DTE_DTESrNo
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.Student_DTE_DTESrNo : string.Empty;
            }
            set
            {
                StudentRegistrationFormDTO.Student_DTE_DTESrNo = value;
            }
        }
        //[Required(ErrorMessage = "Field should not be blank")]
        [Display(Name = "Student_DTE_DTEMeritNo")]
        public string Student_DTE_DTEMeritNo
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.Student_DTE_DTEMeritNo : string.Empty;
            }
            set
            {
                StudentRegistrationFormDTO.Student_DTE_DTEMeritNo = value;
            }
        }
        //[Required(ErrorMessage = "Field must be selected")]
        [Display(Name = "Student_DTE_AdmissionTypeId")]
        public int Student_DTE_AdmissionTypeId
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.Student_DTE_AdmissionTypeId : new int();
            }
            set
            {
                StudentRegistrationFormDTO.Student_DTE_AdmissionTypeId = value;
            }
        }
        //[Required(ErrorMessage = "Field must be selected")]
        [Display(Name = "Student_DTE_AdmissionRound")]

        public int Student_DTE_AdmissionRound
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.Student_DTE_AdmissionRound : new int();
            }
            set
            {
                StudentRegistrationFormDTO.Student_DTE_AdmissionRound = value;
            }
        }
        //[Required(ErrorMessage = "Field must be selected")]
        [Display(Name = "Student_DTE_AdmissionCategoryId")]
        public int Student_DTE_AdmissionCategoryId
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.Student_DTE_AdmissionCategoryId : new int();
            }
            set
            {
                StudentRegistrationFormDTO.Student_DTE_AdmissionCategoryId = value;
            }
        }
        //[Required(ErrorMessage = "Field should not be blank")]
        [Display(Name = "Student_DTE_DTESeatNo")]
        public string Student_DTE_DTESeatNo
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.Student_DTE_DTESeatNo : string.Empty;
            }
            set
            {
                StudentRegistrationFormDTO.Student_DTE_DTESeatNo = value;
            }
        }
        //[Required(ErrorMessage = "Field must be selected")]
        [Display(Name = "Student_DTE_QualifyingExamId")]
        public int Student_DTE_QualifyingExamId
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.Student_DTE_QualifyingExamId : new int();
            }
            set
            {
                StudentRegistrationFormDTO.Student_DTE_QualifyingExamId = value;
            }
        }

        //[Required(ErrorMessage = "Field should not be blank")]
        [Display(Name = "Student_DTE_QualifyingExamName")]
        public string Student_DTE_QualifyingExamName
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.Student_DTE_QualifyingExamName : string.Empty;
            }
            set
            {
                StudentRegistrationFormDTO.Student_DTE_QualifyingExamName = value;
            }
        }
        //[Required(ErrorMessage = "Field must be selected")]
        [Display(Name = "Student_DTE_QualifyingExamMarks")]
        public int Student_DTE_QualifyingExamMarks
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.Student_DTE_QualifyingExamMarks : new int();
            }
            set
            {
                StudentRegistrationFormDTO.Student_DTE_QualifyingExamMarks = value;
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
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.Student_Scholarship_ScholarshipId : string.Empty;
            }
            set
            {
                StudentRegistrationFormDTO.Student_Scholarship_ScholarshipId = value;
            }
        }
        //[Required(ErrorMessage = "Field should not be blank")]
        [Display(Name = "Student_Scholarship_ScholarshipType")]
        public string Student_Scholarship_ScholarshipType
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.Student_Scholarship_ScholarshipType : string.Empty;
            }
            set
            {
                StudentRegistrationFormDTO.Student_Scholarship_ScholarshipType = value;
            }
        }
        //[Required(ErrorMessage = "Field must be selected")]
        [Display(Name = "Student_Scholarship_CastCategoryId")]
        public int Student_Scholarship_CastCategoryId
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.Student_Scholarship_CastCategoryId : new int();
            }
            set
            {
                StudentRegistrationFormDTO.Student_Scholarship_CastCategoryId = value;
            }
        }
        //[Required(ErrorMessage = "Field should not be blank")]
        [Display(Name = "Student_Scholarship_CastCategoryOther")]
        public string Student_Scholarship_CastCategoryOther
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.Student_Scholarship_CastCategoryOther : string.Empty;
            }
            set
            {
                StudentRegistrationFormDTO.Student_Scholarship_CastCategoryOther = value;
            }
        }
        //[Required(ErrorMessage = "Field should not be blank")]
        [Display(Name = "Student_Scholarship_AadhaarCardNo")]
        public string Student_Scholarship_AadhaarCardNo
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.Student_Scholarship_AadhaarCardNo : string.Empty;
            }
            set
            {
                StudentRegistrationFormDTO.Student_Scholarship_AadhaarCardNo = value;
            }
        }
        public double Student_Scholarship_AnnualIncome
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.Student_Scholarship_AnnualIncome : new double();
            }
            set
            {
                StudentRegistrationFormDTO.Student_Scholarship_AnnualIncome = value;
            }
        }
        //[Required(ErrorMessage = "Field must be selected")]
        [Display(Name = "Student_QualifyingExamId")]
        public int Student_Scholarship_NoofSibling
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.Student_Scholarship_NoofSibling : new int();
            }
            set
            {
                StudentRegistrationFormDTO.Student_Scholarship_NoofSibling = value;
            }
        }
        //[Required(ErrorMessage = "Field must be selected")]
        [Display(Name = "Student_QualifyingExamId")]
        public int Student_Scholarship_ChildNoOutofSibling
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.Student_Scholarship_ChildNoOutofSibling : new int();
            }
            set
            {
                StudentRegistrationFormDTO.Student_Scholarship_ChildNoOutofSibling = value;
            }
        }
        //[Required(ErrorMessage = "Field should not be blank")]
        [Display(Name = "Student_Scholarship_HostelDayScholar")]
        public string Student_Scholarship_HostelDayScholar
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.Student_Scholarship_HostelDayScholar : string.Empty;
            }
            set
            {
                StudentRegistrationFormDTO.Student_Scholarship_HostelDayScholar = value;
            }
        }

        //[Required(ErrorMessage = "Field should not be blank")]
        [Display(Name = "Student_Scholarship_Bank_BranchName")]
        public string Student_Scholarship_Bank_BranchName
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.Student_Scholarship_Bank_BranchName : string.Empty;
            }
            set
            {
                StudentRegistrationFormDTO.Student_Scholarship_Bank_BranchName = value;
            }
        }
        //[Required(ErrorMessage = "Field should not be blank")]
        [Display(Name = "Student_Scholarship_Bank_AC_No")]
        public string Student_Scholarship_Bank_AC_No
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.Student_Scholarship_Bank_AC_No : string.Empty;
            }
            set
            {
                StudentRegistrationFormDTO.Student_Scholarship_Bank_AC_No = value;
            }
        }
        //[Required(ErrorMessage = "Field should not be blank")]
        [Display(Name = "Student_Scholarship_Bank_IFSCCode")]
        public string Student_Scholarship_Bank_IFSCCode
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.Student_Scholarship_Bank_IFSCCode : string.Empty;
            }
            set
            {
                StudentRegistrationFormDTO.Student_Scholarship_Bank_IFSCCode = value;
            }
        }
        //[Required(ErrorMessage = "Field should not be blank")]
        [Display(Name = "Student_Scholarship_Bank_MICRCode")]
        public string Student_Scholarship_Bank_MICRCode
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.Student_Scholarship_Bank_MICRCode : string.Empty;
            }
            set
            {
                StudentRegistrationFormDTO.Student_Scholarship_Bank_MICRCode = value;
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
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.Student_AdmissionDocuments_JETMarkSheet : false;
            }
            set
            {
                StudentRegistrationFormDTO.Student_AdmissionDocuments_JETMarkSheet = value;
            }
        }
        //[Required(ErrorMessage = "Field must be selected")]
        [Display(Name = "Student_AdmissionDocuments_AllotmentLetter")]
        public bool Student_AdmissionDocuments_AllotmentLetter
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.Student_AdmissionDocuments_AllotmentLetter : false;
            }
            set
            {
                StudentRegistrationFormDTO.Student_AdmissionDocuments_AllotmentLetter = value;
            }
        }
        //[Required(ErrorMessage = "Field must be selected")]
        [Display(Name = "Student_AdmissionDocuments_TenthMarkSheet")]
        public bool Student_AdmissionDocuments_TenthMarkSheet
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.Student_AdmissionDocuments_TenthMarkSheet : false;
            }
            set
            {
                StudentRegistrationFormDTO.Student_AdmissionDocuments_TenthMarkSheet = value;
            }
        }
        //[Required(ErrorMessage = "Field must be selected")]
        [Display(Name = "Student_AdmissionDocuments_TwelvethMarkSheet")]
        public bool Student_AdmissionDocuments_TwelvethMarkSheet
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.Student_AdmissionDocuments_TwelvethMarkSheet : false;
            }
            set
            {
                StudentRegistrationFormDTO.Student_AdmissionDocuments_TwelvethMarkSheet = value;
            }
        }
        //[Required(ErrorMessage = "Field must be selected")]
        [Display(Name = "Student_AdmissionDocuments_AllDiplomaMarksheet")]
        public bool Student_AdmissionDocuments_AllDiplomaMarksheet
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.Student_AdmissionDocuments_AllDiplomaMarksheet : false;
            }
            set
            {
                StudentRegistrationFormDTO.Student_AdmissionDocuments_AllDiplomaMarksheet = value;
            }
        }
        //[Required(ErrorMessage = "Field must be selected")]
        [Display(Name = "Student_AdmissionDocuments_LeavingCertificate")]
        public bool Student_AdmissionDocuments_LeavingCertificate
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.Student_AdmissionDocuments_LeavingCertificate : false;
            }
            set
            {
                StudentRegistrationFormDTO.Student_AdmissionDocuments_LeavingCertificate = value;
            }
        }
        //[Required(ErrorMessage = "Field must be selected")]
        [Display(Name = "Student_AdmissionDocuments_Domicile_BirthCertificate")]

        public bool Student_AdmissionDocuments_Domicile_BirthCertificate
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.Student_AdmissionDocuments_Domicile_BirthCertificate : false;
            }
            set
            {
                StudentRegistrationFormDTO.Student_AdmissionDocuments_Domicile_BirthCertificate = value;
            }
        }
        //[Required(ErrorMessage = "Field must be selected")]
        [Display(Name = "Student_AdmissionDocuments_NationalityCertificate")]
        public bool Student_AdmissionDocuments_NationalityCertificate
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.Student_AdmissionDocuments_NationalityCertificate : false;
            }
            set
            {
                StudentRegistrationFormDTO.Student_AdmissionDocuments_NationalityCertificate = value;
            }
        }
        //[Required(ErrorMessage = "Field must be selected")]
        [Display(Name = "Student_AdmissionDocuments_CasteCertificate")]
        public bool Student_AdmissionDocuments_CasteCertificate
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.Student_AdmissionDocuments_CasteCertificate : false;
            }
            set
            {
                StudentRegistrationFormDTO.Student_AdmissionDocuments_CasteCertificate = value;
            }
        }
        //[Required(ErrorMessage = "Field must be selected")]
        [Display(Name = "Student_AdmissionDocuments_CasteValidityCertificate")]
        public bool Student_AdmissionDocuments_CasteValidityCertificate
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.Student_AdmissionDocuments_CasteValidityCertificate : false;
            }
            set
            {
                StudentRegistrationFormDTO.Student_AdmissionDocuments_CasteValidityCertificate = value;
            }
        }
        //[Required(ErrorMessage = "Field must be selected")]
        [Display(Name = "Student_AdmissionDocuments_NonCreamylayerCertificate")]
        public bool Student_AdmissionDocuments_NonCreamylayerCertificate
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.Student_AdmissionDocuments_NonCreamylayerCertificate : false;
            }
            set
            {
                StudentRegistrationFormDTO.Student_AdmissionDocuments_NonCreamylayerCertificate = value;
            }
        }
        //[Required(ErrorMessage = "Field must be selected")]
        [Display(Name = "Student_AdmissionDocuments_EquivalenceCertificate")]

        public bool Student_AdmissionDocuments_EquivalenceCertificate
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.Student_AdmissionDocuments_EquivalenceCertificate : false;
            }
            set
            {
                StudentRegistrationFormDTO.Student_AdmissionDocuments_EquivalenceCertificate = value;
            }
        }
        //[Required(ErrorMessage = "Field must be selected")]
        [Display(Name = "Student_AdmissionDocuments_MigrationCertificate")]
        public bool Student_AdmissionDocuments_MigrationCertificate
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.Student_AdmissionDocuments_MigrationCertificate : false;
            }
            set
            {
                StudentRegistrationFormDTO.Student_AdmissionDocuments_MigrationCertificate = value;
            }
        }
        //[Required(ErrorMessage = "Field must be selected")]
        [Display(Name = "Student_AdmissionDocuments_GapCertificate")]
        public bool Student_AdmissionDocuments_GapCertificate
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.Student_AdmissionDocuments_GapCertificate : false;
            }
            set
            {
                StudentRegistrationFormDTO.Student_AdmissionDocuments_GapCertificate = value;
            }
        }
        //[Required(ErrorMessage = "Field must be selected")]
        [Display(Name = "Student_AdmissionDocuments_AntiRaggingAffidavit")]
        public bool Student_AdmissionDocuments_AntiRaggingAffidavit
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.Student_AdmissionDocuments_AntiRaggingAffidavit : false;
            }
            set
            {
                StudentRegistrationFormDTO.Student_AdmissionDocuments_AntiRaggingAffidavit = value;
            }
        }
        //[Required(ErrorMessage = "Field must be selected")]
        [Display(Name = "Student_AdmissionDocuments_Proforma_Fand_F1_On_DoctorsLetter_Head")]
        public bool Student_AdmissionDocuments_Proforma_Fand_F1_On_DoctorsLetter_Head
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.Student_AdmissionDocuments_Proforma_Fand_F1_On_DoctorsLetter_Head : false;
            }
            set
            {
                StudentRegistrationFormDTO.Student_AdmissionDocuments_Proforma_Fand_F1_On_DoctorsLetter_Head = value;
            }
        }
        //[Required(ErrorMessage = "Field must be selected")]
        [Display(Name = "Student_AdmissionDocuments_Proforma_I")]
        public bool Student_AdmissionDocuments_Proforma_I
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.Student_AdmissionDocuments_Proforma_I : false;
            }
            set
            {
                StudentRegistrationFormDTO.Student_AdmissionDocuments_Proforma_I = value;
            }
        }
        //[Required(ErrorMessage = "Field must be selected")]
        [Display(Name = "Student_AdmissionDocuments_ProformaG1")]
        public bool Student_AdmissionDocuments_ProformaG1
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.Student_AdmissionDocuments_ProformaG1 : false;
            }
            set
            {
                StudentRegistrationFormDTO.Student_AdmissionDocuments_ProformaG1 = value;
            }
        }
        //[Required(ErrorMessage = "Field must be selected")]
        [Display(Name = "Student_AdmissionDocuments_ProformaG2")]
        public bool Student_AdmissionDocuments_ProformaG2
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.Student_AdmissionDocuments_ProformaG2 : false;
            }
            set
            {
                StudentRegistrationFormDTO.Student_AdmissionDocuments_ProformaG2 = value;
            }
        }
        //[Required(ErrorMessage = "Field must be selected")]
        [Display(Name = "Student_AdmissionDocuments_Proforma_C_D_E")]
        public bool Student_AdmissionDocuments_Proforma_C_D_E
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.Student_AdmissionDocuments_Proforma_C_D_E : false;
            }
            set
            {
                StudentRegistrationFormDTO.Student_AdmissionDocuments_Proforma_C_D_E = value;
            }
        }
        //[Required(ErrorMessage = "Field must be selected")]
        [Display(Name = "Student_AdmissionDocuments_FathersIncomeCertificate")]
        public bool Student_AdmissionDocuments_FathersIncomeCertificate
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.Student_AdmissionDocuments_FathersIncomeCertificate : false;
            }
            set
            {
                StudentRegistrationFormDTO.Student_AdmissionDocuments_FathersIncomeCertificate = value;
            }
        }
        //[Required(ErrorMessage = "Field must be selected")]
        [Display(Name = "Student_AdmissionDocuments_AadharCardXerox")]
        public bool Student_AdmissionDocuments_AadharCardXerox
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.Student_AdmissionDocuments_AadharCardXerox : false;
            }
            set
            {
                StudentRegistrationFormDTO.Student_AdmissionDocuments_AadharCardXerox = value;
            }
        }
        //[Required(ErrorMessage = "Field must be selected")]
        [Display(Name = "Student_AdmissionDocuments_B_WPhoto_I_card_size")]
        public bool Student_AdmissionDocuments_B_WPhoto_I_card_size
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.Student_AdmissionDocuments_B_WPhoto_I_card_size : false;
            }
            set
            {
                StudentRegistrationFormDTO.Student_AdmissionDocuments_B_WPhoto_I_card_size = value;
            }
        }
        //[Required(ErrorMessage = "Field must be selected")]
        [Display(Name = "Student_AdmissionDocuments_Colour_photo")]
        public bool Student_AdmissionDocuments_Colour_photo
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.Student_AdmissionDocuments_Colour_photo : false;
            }
            set
            {
                StudentRegistrationFormDTO.Student_AdmissionDocuments_Colour_photo = value;
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
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.Student_AdmissionDocuments_PGStudents_DegreeMarksheet : false;
            }
            set
            {
                StudentRegistrationFormDTO.Student_AdmissionDocuments_PGStudents_DegreeMarksheet = value;
            }
        }
        //[Required(ErrorMessage = "Field must be selected")]
        [Display(Name = "Student_AdmissionDocuments_PGStudents_DegreeCertificate")]
        public bool Student_AdmissionDocuments_PGStudents_DegreeCertificate
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.Student_AdmissionDocuments_PGStudents_DegreeCertificate : false;
            }
            set
            {
                StudentRegistrationFormDTO.Student_AdmissionDocuments_PGStudents_DegreeCertificate = value;
            }
        }
        //[Required(ErrorMessage = "Field must be selected")]
        [Display(Name = "Student_AdmissionDocuments_PGStudents_GateScoreCard")]
        public bool Student_AdmissionDocuments_PGStudents_GateScoreCard
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.Student_AdmissionDocuments_PGStudents_GateScoreCard : false;
            }
            set
            {
                StudentRegistrationFormDTO.Student_AdmissionDocuments_PGStudents_GateScoreCard = value;
            }
        }
        //[Required(ErrorMessage = "Field must be selected")]
        [Display(Name = "Student_AdmissionDocuments_PGStudents_SponsorshipLetterforSponsoredCandidate")]
        public bool Student_AdmissionDocuments_PGStudents_SponsorshipLetterforSponsoredCandidate
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.Student_AdmissionDocuments_PGStudents_SponsorshipLetterforSponsoredCandidate : false;
            }
            set
            {
                StudentRegistrationFormDTO.Student_AdmissionDocuments_PGStudents_SponsorshipLetterforSponsoredCandidate = value;
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
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.Student_AdmissionDocuments_Comments : string.Empty;
            }
            set
            {
                StudentRegistrationFormDTO.Student_AdmissionDocuments_Comments = value;
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
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.Student_ScholarshipDocuments_IncomeCertificateOriginal : false;
            }
            set
            {
                StudentRegistrationFormDTO.Student_ScholarshipDocuments_IncomeCertificateOriginal = value;
            }
        }
        //[Required(ErrorMessage = "Field must be selected")]
        [Display(Name = "Student_ScholarshipDocuments_TenthMarkSheet")]
        public bool Student_ScholarshipDocuments_TenthMarkSheet
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.Student_ScholarshipDocuments_TenthMarkSheet : false;
            }
            set
            {
                StudentRegistrationFormDTO.Student_ScholarshipDocuments_TenthMarkSheet = value;
            }
        }
        //[Required(ErrorMessage = "Field must be selected")]
        [Display(Name = "Student_ScholarshipDocuments_TwelvethMarkSheet")]
        public bool Student_ScholarshipDocuments_TwelvethMarkSheet
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.Student_ScholarshipDocuments_TwelvethMarkSheet : false;
            }
            set
            {
                StudentRegistrationFormDTO.Student_ScholarshipDocuments_TwelvethMarkSheet = value;
            }
        }
        //[Required(ErrorMessage = "Field must be selected")]
        [Display(Name = "Student_ScholarshipDocuments_AdharCard")]
        public bool Student_ScholarshipDocuments_AdharCard
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.Student_ScholarshipDocuments_AdharCard : false;
            }
            set
            {
                StudentRegistrationFormDTO.Student_ScholarshipDocuments_AdharCard = value;
            }
        }
        //[Required(ErrorMessage = "Field must be selected")]
        [Display(Name = "Student_ScholarshipDocuments_AdmissionConfirmationLetter")]
        public bool Student_ScholarshipDocuments_AdmissionConfirmationLetter
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.Student_ScholarshipDocuments_AdmissionConfirmationLetter : false;
            }
            set
            {
                StudentRegistrationFormDTO.Student_ScholarshipDocuments_AdmissionConfirmationLetter = value;
            }
        }
        //[Required(ErrorMessage = "Field must be selected")]
        [Display(Name = "Student_ScholarshipDocuments_AllotmentLetter")]
        public bool Student_ScholarshipDocuments_AllotmentLetter
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.Student_ScholarshipDocuments_AllotmentLetter : false;
            }
            set
            {
                StudentRegistrationFormDTO.Student_ScholarshipDocuments_AllotmentLetter = value;
            }
        }
        //[Required(ErrorMessage = "Field must be selected")]
        [Display(Name = "Student_ScholarshipDocuments_BankPassBookXerox")]
        public bool Student_ScholarshipDocuments_BankPassBookXerox
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.Student_ScholarshipDocuments_BankPassBookXerox : false;
            }
            set
            {
                StudentRegistrationFormDTO.Student_ScholarshipDocuments_BankPassBookXerox = value;
            }
        }
        //[Required(ErrorMessage = "Field must be selected")]
        [Display(Name = "Student_ScholarshipDocuments_CastCertificate")]
        public bool Student_ScholarshipDocuments_CastCertificate
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.Student_ScholarshipDocuments_CastCertificate : false;
            }
            set
            {
                StudentRegistrationFormDTO.Student_ScholarshipDocuments_CastCertificate = value;
            }
        }
        //[Required(ErrorMessage = "Field must be selected")]
        [Display(Name = "Student_ScholarshipDocuments_CastValidity")]
        public bool Student_ScholarshipDocuments_CastValidity
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.Student_ScholarshipDocuments_CastValidity : false;
            }
            set
            {
                StudentRegistrationFormDTO.Student_ScholarshipDocuments_CastValidity = value;
            }
        }
        //[Required(ErrorMessage = "Field must be selected")]
        [Display(Name = "Student_ScholarshipDocuments_Domicile")]
        public bool Student_ScholarshipDocuments_Domicile
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.Student_ScholarshipDocuments_Domicile : false;
            }
            set
            {
                StudentRegistrationFormDTO.Student_ScholarshipDocuments_Domicile = value;
            }
        }
        //[Required(ErrorMessage = "Field must be selected")]
        [Display(Name = "Student_ScholarshipDocuments_Receipt")]
        public bool Student_ScholarshipDocuments_Receipt
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.Student_ScholarshipDocuments_Receipt : false;
            }
            set
            {
                StudentRegistrationFormDTO.Student_ScholarshipDocuments_Receipt = value;
            }
        }
        //[Required(ErrorMessage = "Field must be selected")]
        [Display(Name = "Student_ScholarshipDocuments_GateScoreCard")]
        public bool Student_ScholarshipDocuments_GateScoreCard
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.Student_ScholarshipDocuments_GateScoreCard : false;
            }
            set
            {
                StudentRegistrationFormDTO.Student_ScholarshipDocuments_GateScoreCard = value;
            }
        }
        //[Required(ErrorMessage = "Field must be selected")]
        [Display(Name = "Student_ScholarshipDocuments_HandicapCertificate")]
        public bool Student_ScholarshipDocuments_HandicapCertificate
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.Student_ScholarshipDocuments_HandicapCertificate : false;
            }
            set
            {
                StudentRegistrationFormDTO.Student_ScholarshipDocuments_HandicapCertificate = value;
            }
        }
        //[Required(ErrorMessage = "Field must be selected")]
        [Display(Name = "Student_ScholarshipDocuments_Icardsizephoto")]
        public bool Student_ScholarshipDocuments_Icardsizephoto
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.Student_ScholarshipDocuments_Icardsizephoto : false;
            }
            set
            {
                StudentRegistrationFormDTO.Student_ScholarshipDocuments_Icardsizephoto = value;
            }
        }
        //[Required(ErrorMessage = "Field must be selected")]
        [Display(Name = "Student_ScholarshipDocuments_IDProof")]
        public bool Student_ScholarshipDocuments_IDProof
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.Student_ScholarshipDocuments_IDProof : false;
            }
            set
            {
                StudentRegistrationFormDTO.Student_ScholarshipDocuments_IDProof = value;
            }
        }
        //[Required(ErrorMessage = "Field must be selected")]
        [Display(Name = "Student_ScholarshipDocuments_IncomeAffidavitOriginal")]
        public bool Student_ScholarshipDocuments_IncomeAffidavitOriginal
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.Student_ScholarshipDocuments_IncomeAffidavitOriginal : false;
            }
            set
            {
                StudentRegistrationFormDTO.Student_ScholarshipDocuments_IncomeAffidavitOriginal = value;
            }
        }
        //[Required(ErrorMessage = "Field must be selected")]
        [Display(Name = "Student_ScholarshipDocuments_JEEMainScoreCard")]
        public bool Student_ScholarshipDocuments_JEEMainScoreCard
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.Student_ScholarshipDocuments_JEEMainScoreCard : false;
            }
            set
            {
                StudentRegistrationFormDTO.Student_ScholarshipDocuments_JEEMainScoreCard = value;
            }
        }
        //[Required(ErrorMessage = "Field must be selected")]
        [Display(Name = "Student_ScholarshipDocuments_Leavingcertificate")]
        public bool Student_ScholarshipDocuments_Leavingcertificate
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.Student_ScholarshipDocuments_Leavingcertificate : false;
            }
            set
            {
                StudentRegistrationFormDTO.Student_ScholarshipDocuments_Leavingcertificate = value;
            }
        }
        //[Required(ErrorMessage = "Field must be selected")]
        [Display(Name = "Student_ScholarshipDocuments_ParentsFromNo16")]
        public bool Student_ScholarshipDocuments_ParentsFromNo16
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.Student_ScholarshipDocuments_ParentsFromNo16 : false;
            }
            set
            {
                StudentRegistrationFormDTO.Student_ScholarshipDocuments_ParentsFromNo16 = value;
            }
        }
        //[Required(ErrorMessage = "Field must be selected")]
        [Display(Name = "Student_ScholarshipDocuments_LastYearMarksheet")]
        public bool Student_ScholarshipDocuments_LastYearMarksheet
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.Student_ScholarshipDocuments_LastYearMarksheet : false;
            }
            set
            {
                StudentRegistrationFormDTO.Student_ScholarshipDocuments_LastYearMarksheet = value;
            }
        }
        //[Required(ErrorMessage = "Field must be selected")]
        [Display(Name = "Student_ScholarshipDocuments_RationCard")]
        public bool Student_ScholarshipDocuments_RationCard
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.Student_ScholarshipDocuments_RationCard : false;
            }
            set
            {
                StudentRegistrationFormDTO.Student_ScholarshipDocuments_RationCard = value;
            }
        }
        //[Required(ErrorMessage = "Field must be selected")]
        [Display(Name = "Student_ScholarshipDocuments_MHCETScoreCard")]
        public bool Student_ScholarshipDocuments_MHCETScoreCard
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.Student_ScholarshipDocuments_MHCETScoreCard : false;
            }
            set
            {
                StudentRegistrationFormDTO.Student_ScholarshipDocuments_MHCETScoreCard = value;
            }
        }
        //[Required(ErrorMessage = "Field must be selected")]
        [Display(Name = "Student_ScholarshipDocuments_LastCollegeletterAboutScholarshipOriginal")]
        public bool Student_ScholarshipDocuments_LastCollegeletterAboutScholarshipOriginal
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.Student_ScholarshipDocuments_LastCollegeletterAboutScholarshipOriginal : false;
            }
            set
            {
                StudentRegistrationFormDTO.Student_ScholarshipDocuments_LastCollegeletterAboutScholarshipOriginal = value;
            }
        }
        //[Required(ErrorMessage = "Field must be selected")]
        [Display(Name = "Student_ScholarshipDocuments_Colourphoto")]
        public bool Student_ScholarshipDocuments_Colourphoto
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.Student_ScholarshipDocuments_Colourphoto : false;
            }
            set
            {
                StudentRegistrationFormDTO.Student_ScholarshipDocuments_Colourphoto = value;
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
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.Student_ScholarshipDocuments_IfApplicable_NonCreamylayer : false;
            }
            set
            {
                StudentRegistrationFormDTO.Student_ScholarshipDocuments_IfApplicable_NonCreamylayer = value;
            }
        }
        //[Required(ErrorMessage = "Field must be selected")]
        [Display(Name = "Student_ScholarshipDocuments_IfApplicable_DeathcertificateFatherMother")]
        public bool Student_ScholarshipDocuments_IfApplicable_DeathcertificateFatherMother
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.Student_ScholarshipDocuments_IfApplicable_DeathcertificateFatherMother : false;
            }
            set
            {
                StudentRegistrationFormDTO.Student_ScholarshipDocuments_IfApplicable_DeathcertificateFatherMother = value;
            }
        }
        //[Required(ErrorMessage = "Field must be selected")]
        [Display(Name = "Student_ScholarshipDocuments_IfApplicable_DisabilityAbilityCertificate")]
        public bool Student_ScholarshipDocuments_IfApplicable_DisabilityAbilityCertificate
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.Student_ScholarshipDocuments_IfApplicable_DisabilityAbilityCertificate : false;
            }
            set
            {
                StudentRegistrationFormDTO.Student_ScholarshipDocuments_IfApplicable_DisabilityAbilityCertificate = value;
            }
        }
        //[Required(ErrorMessage = "Field must be selected")]
        [Display(Name = "Student_ScholarshipDocuments_IfApplicable_GapCertificate")]
        public bool Student_ScholarshipDocuments_IfApplicable_GapCertificate
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.Student_ScholarshipDocuments_IfApplicable_GapCertificate : false;
            }
            set
            {
                StudentRegistrationFormDTO.Student_ScholarshipDocuments_IfApplicable_GapCertificate = value;
            }
        }

        public string StudentSubmitedDocumentFlagIDs
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.StudentSubmitedDocumentFlagIDs : string.Empty;
            }
            set
            {
                StudentRegistrationFormDTO.StudentSubmitedDocumentFlagIDs = value;
            }
        }
        public string StudentSubmitedDocumentIDs
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.StudentSubmitedDocumentIDs : string.Empty;
            }
            set
            {
                StudentRegistrationFormDTO.StudentSubmitedDocumentIDs = value;
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
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.Student_ScholarshipDocuments_Comments : string.Empty;
            }
            set
            {
                StudentRegistrationFormDTO.Student_ScholarshipDocuments_Comments = value;
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
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.QualifyingExamSubjectDetailsIDs : string.Empty;
            }
            set
            {
                StudentRegistrationFormDTO.QualifyingExamSubjectDetailsIDs = value;
            }
        }
        public string QualificationExamSubjectGeneralDetailsIDs
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.QualificationExamSubjectGeneralDetailsIDs : string.Empty;
            }
            set
            {
                StudentRegistrationFormDTO.QualificationExamSubjectGeneralDetailsIDs = value;
            }
        }
        public string QualificationExamSubjectSSCDetailsIDs
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.QualificationExamSubjectSSCDetailsIDs : string.Empty;
            }
            set
            {
                StudentRegistrationFormDTO.QualificationExamSubjectSSCDetailsIDs = value;
            }
        }
        public string QualificationExamSubjectHSCDetailsIDs
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.QualificationExamSubjectHSCDetailsIDs : string.Empty;
            }
            set
            {
                StudentRegistrationFormDTO.QualificationExamSubjectHSCDetailsIDs = value;
            }
        }
        #endregion Subject IDs

        public bool StudentActiveFlag
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.StudentActiveFlag : false;
            }
            set
            {
                StudentRegistrationFormDTO.StudentActiveFlag = value;
            }
        }


        //public IEnumerable<SelectListItem> StudentRegistrationFormListItems
        //{
        //    get
        //    {
        //        return new SelectList(StudentRegistrationFormList, "ID", "SubstitudeTitleName");
        //    }
        //}

        public List<StudentRegistrationForm> StudentRegistrationFormList
        {
            get;
            set;
        }
        public List<OrganisationUniversityMaster> ListOrganisationUniversityMaster
        {
            get;
            set;
        }
        public IEnumerable<SelectListItem> ListOrganisationUnivesitytMasterItems
        {
            get
            {

                return new SelectList(ListOrganisationUniversityMaster, "UniversityID", "UniversityName");
            }

        }
        //public List<StudentRegistrationForm> StudentRegistrationFormQualifingExamSubjectList
        //{
        //    get;
        //    set;
        //}

        public List<ToolQualifyingExamSubject> ToolQualifyingExamSubjectList
        {
            get;
            set;
        }
        public List<ToolQualificationMasterSubject> ToolQualificationMasterSubjectListForGeneral
        {
            get;
            set;
        }
        public List<ToolQualificationMasterSubject> ToolQualificationMasterSubjectListForSSC
        {
            get;
            set;
        }
        public List<ToolQualificationMasterSubject> ToolQualificationMasterSubjectListForHSC
        {
            get;
            set;
        }
        public OrganisationCourseYearDetails OrganisationCourseYearDetailsDTO { get; set; }
        public OrganisationBranchDetails OrganisationBranchDetailsDTO { get; set; }

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

        public bool IsTaskGeneratedForApproval
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.IsTaskGeneratedForApproval : false;
            }
            set
            {
                StudentRegistrationFormDTO.IsTaskGeneratedForApproval = value;
            }
        }
        public string ReasonIfRejected
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.ReasonIfRejected : string.Empty;
            }
            set
            {
                StudentRegistrationFormDTO.ReasonIfRejected = value;
            }
        }
        public string NameOfApplicant
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.NameOfApplicant : string.Empty;
            }
            set
            {
                StudentRegistrationFormDTO.NameOfApplicant = value;
            }
        }
        public string TitleOfProject
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.TitleOfProject : string.Empty;
            }
            set
            {
                StudentRegistrationFormDTO.TitleOfProject = value;
            }
        }
        public string ProjectSummary
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.ProjectSummary : string.Empty;
            }
            set
            {
                StudentRegistrationFormDTO.ProjectSummary = value;
            }
        }
        public short FeesPaidBy
        {
            get
            {
                return (StudentRegistrationFormDTO != null && StudentRegistrationFormDTO.FeesPaidBy > 0) ? StudentRegistrationFormDTO.FeesPaidBy : new short();
            }
            set
            {
                StudentRegistrationFormDTO.FeesPaidBy = value;
            }
        }
        public string WorkExperienceXML
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.WorkExperienceXML : string.Empty;
            }
            set
            {
                StudentRegistrationFormDTO.WorkExperienceXML = value;
            }
        }
        public string DeletedPreviousExperienceIDs
        {
            get
            {
                return (StudentRegistrationFormDTO != null) ? StudentRegistrationFormDTO.DeletedPreviousExperienceIDs : string.Empty;
            }
            set
            {
                StudentRegistrationFormDTO.DeletedPreviousExperienceIDs = value;
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
    //public class PreviousWorkExperience 
    //{
    //    public PreviousWorkExperience() {
    //        PreviousWorkExperienceDTO = new PreviousWorkExperience();
    //        PreviousWorkExperienceList = new List<PreviousWorkExperience>();
    //}
    //    public PreviousWorkExperience PreviousWorkExperienceDTO { get; set; }
       
    //    public string NameOfOrganization
    //    {
    //        get
    //        {
    //            return (PreviousWorkExperienceDTO != null) ? PreviousWorkExperienceDTO.NameOfOrganization : string.Empty;
    //        }
    //        set
    //        {
    //            PreviousWorkExperienceDTO.NameOfOrganization = value;
    //        }
    //    }
    //    public string Position
    //    {
    //        get
    //        {
    //            return (PreviousWorkExperienceDTO != null) ? PreviousWorkExperienceDTO.Position : string.Empty;
    //        }
    //        set
    //        {
    //            PreviousWorkExperienceDTO.Position = value;
    //        }
    //    }
    //    public string FullPartTimeFlag
    //    {
    //        get
    //        {
    //            return (PreviousWorkExperienceDTO != null) ? PreviousWorkExperienceDTO.FullPartTimeFlag : string.Empty;
    //        }
    //        set
    //        {
    //            PreviousWorkExperienceDTO.FullPartTimeFlag = value;
    //        }
    //    }
    //    public string FromDate
    //    {
    //        get
    //        {
    //            return (PreviousWorkExperienceDTO != null) ? PreviousWorkExperienceDTO.FromDate : string.Empty;
    //        }
    //        set
    //        {
    //            PreviousWorkExperienceDTO.FromDate = value;
    //        }
    //    }
    //    public string UptoDate
    //    {
    //        get
    //        {
    //            return (PreviousWorkExperienceDTO != null) ? PreviousWorkExperienceDTO.UptoDate : string.Empty;
    //        }
    //        set
    //        {
    //            PreviousWorkExperienceDTO.UptoDate = value;
    //        }
    //    }
    //}
}
