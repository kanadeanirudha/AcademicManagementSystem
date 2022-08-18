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
    public class StudentReportViewModel : IStudentReportViewModel
    {

        public StudentReportViewModel()
        {
            StudentReportDTO = new StudentReport();
            ListOrganisationStudyCentreMaster = new List<OrganisationStudyCentreMaster>();
            ListOrganisationUniversityMaster = new List<OrganisationUniversityMaster>();
            ListOrganisationCourseYearDetails = new List<OrganisationCourseYearDetails>();
            ListOrganisationSectionDetails = new List<OrganisationSectionDetails>();
            ListOrganisationCentrewiseSessionDetails = new List<OrganisationCentrewiseSession>();
            ListGeneralCategoryMaster = new List<GeneralCategoryMaster>();

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
        public List<OrganisationCourseYearDetails> ListOrganisationCourseYearDetails
        {
            get;
            set;
        }
        public IEnumerable<SelectListItem> CourseYearListMasterItems
        {
            get
            {
                return new SelectList(ListOrganisationCourseYearDetails, "ID", "Description");
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

        public List<GeneralCategoryMaster> ListGeneralCategoryMaster
        {
            get;
            set;
        }
        public IEnumerable<SelectListItem> GeneralCategoryMasterItems
        {
            get
            {
                return new SelectList(ListGeneralCategoryMaster, "ID", "CategoryName");
            }
        }
        [Required(ErrorMessage = "Centre must be setected")]
        public string SelectedCentreCode
        {
            get;
            set;
        }
        [Required(ErrorMessage = "University must be setected")]
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
        [Required(ErrorMessage = "Course Year must be setected")]
        public string SelectedCourseYearId
        {
            get;
            set;
        }
        [Required(ErrorMessage = "Section must be setected")]
        public string SelectedSectionDetailID
        {
            get;
            set;
        }
        [Required(ErrorMessage = "Academic Year must be setected")]
        public string SelectedAcademicYear
        {
            get;
            set;
        }
        [Display(Name = "Category Name")]
        [Required(ErrorMessage = "Category must be setected")]
        public string SelectedCategoryId
        {
            get;
            set;
        }
        [Display(Name = "I-Card View")]
        public string SelectedICardView
        {
            get;
            set;
        }

        public StudentReport StudentReportDTO
        {
            get;
            set;
        }


        public int ID
        {
            get
            {
                return (StudentReportDTO != null && StudentReportDTO.ID > 0) ? StudentReportDTO.ID : new int();
            }
            set
            {
                StudentReportDTO.ID = value;
            }
        }
        public int StudentId
        {
            get
            {
                return (StudentReportDTO != null) ? StudentReportDTO.StudentId : new int();
            }
            set
            {
                StudentReportDTO.StudentId = value;
            }
        }


        [Display(Name = "Student Name")]
        public string StudentFullName
        {
            get
            {
                return (StudentReportDTO != null) ? StudentReportDTO.StudentFullName : string.Empty;
            }
            set
            {
                StudentReportDTO.StudentFullName = value;
            }
        }

        [Display(Name = "FirstName")]
        public string StudentFirstName
        {
            get
            {
                return (StudentReportDTO != null) ? StudentReportDTO.StudentFirstName : string.Empty;
            }
            set
            {
                StudentReportDTO.StudentFirstName = value;
            }
        }

        [Display(Name = "MiddleName")]
        public string StudentMiddleName
        {
            get
            {
                return (StudentReportDTO != null) ? StudentReportDTO.StudentMiddleName : string.Empty;
            }
            set
            {
                StudentReportDTO.StudentMiddleName = value;
            }
        }

        public string StudentLastName
        {
            get
            {
                return (StudentReportDTO != null) ? StudentReportDTO.StudentLastName : string.Empty;
            }
            set
            {
                StudentReportDTO.StudentLastName = value;
            }
        }
        [Required(ErrorMessage = "Student Code should not be blank")]
        [Display(Name = "Student Code")]
        public string StudentCode
        {
            get
            {
                return (StudentReportDTO != null) ? StudentReportDTO.StudentCode : string.Empty;
            }
            set
            {
                StudentReportDTO.StudentCode = value;
            }
        }





        public string RollNumber
        {
            get
            {
                return (StudentReportDTO != null) ? StudentReportDTO.RollNumber : string.Empty;
            }
            set
            {
                StudentReportDTO.RollNumber = value;
            }
        }

        [Required(ErrorMessage = "Branch must be setected")]
        [Display(Name = "Course Name")]
        public int BranchID
        {
            get
            {
                return (StudentReportDTO != null) ? StudentReportDTO.BranchID : new int();
            }
            set
            {
                StudentReportDTO.BranchID = value;
            }
        }
        [Required(ErrorMessage = "Course Year must be setected")]
        [Display(Name = "Course Year")]
        public int CourseYearId
        {
            get
            {
                return (StudentReportDTO != null) ? StudentReportDTO.CourseYearId : new int();
            }
            set
            {
                StudentReportDTO.CourseYearId = value;
            }
        }
        [Required(ErrorMessage = "University must be setected")]
        [Display(Name = "University Name")]
        public int UniversityID
        {
            get
            {
                return (StudentReportDTO != null) ? StudentReportDTO.UniversityID : new int();
            }
            set
            {
                StudentReportDTO.UniversityID = value;
            }
        }
        [Required(ErrorMessage = "Section must be setected")]
        [Display(Name = "Section Details")]
        public int SectionDetailID
        {
            get
            {
                return (StudentReportDTO != null) ? StudentReportDTO.SectionDetailID : new int();
            }
            set
            {
                StudentReportDTO.SectionDetailID = value;
            }
        }
        [Required(ErrorMessage = "Academic Year must be setected")]
        [Display(Name = "Academic Year")]
        public string AcademicYear
        {
            get
            {
                return (StudentReportDTO != null) ? StudentReportDTO.AcademicYear : string.Empty;
            }
            set
            {
                StudentReportDTO.AcademicYear = value;
            }
        }
        [Display(Name = "Admission Status")]
        public string AdmissionStatus
        {
            get
            {
                return (StudentReportDTO != null) ? StudentReportDTO.AdmissionStatus : string.Empty;
            }
            set
            {
                StudentReportDTO.AdmissionStatus = value;
            }
        }
        [Display(Name = "Sort Order")]
        public string SortOrder
        {
            get
            {
                return (StudentReportDTO != null) ? StudentReportDTO.SortOrder : string.Empty;
            }
            set
            {
                StudentReportDTO.SortOrder = value;
            }
        }
        [Required(ErrorMessage = "Centre Name must be setected")]
        [Display(Name = "Centre Name")]
        public string CentreCode
        {
            get
            {
                return (StudentReportDTO != null) ? StudentReportDTO.CentreCode : string.Empty;
            }
            set
            {
                StudentReportDTO.CentreCode = value;
            }
        }

        [Display(Name = "Report Type")]
        public bool ReportType
        {
            get
            {
                return (StudentReportDTO != null) ? StudentReportDTO.ReportType : false;
            }
            set
            {
                StudentReportDTO.ReportType = value;
            }
        }

        public bool IsShowDiv
        {
            get
            {
                return (StudentReportDTO != null) ? StudentReportDTO.IsShowDiv : false;
            }
            set
            {
                StudentReportDTO.IsShowDiv = value;
            }
        }
        [Display(Name = "All Course")]
        public bool IsAllCourse
        {
            get
            {
                return (StudentReportDTO != null) ? StudentReportDTO.IsAllCourse : false;
            }
            set
            {
                StudentReportDTO.IsAllCourse = value;
            }
        }
        [Display(Name = "Course Year/Section")]
        public string Course_Section
        {
            get
            {
                return (StudentReportDTO != null) ? StudentReportDTO.Course_Section : string.Empty;
            }
            set
            {
                StudentReportDTO.Course_Section = value;
            }
        }
        [Display(Name = "IsDeleted")]
        public bool IsDeleted
        {
            get
            {
                return (StudentReportDTO != null) ? StudentReportDTO.IsDeleted : false;
            }
            set
            {
                StudentReportDTO.IsDeleted = value;
            }
        }

        [Display(Name = "CreatedBy")]
        public int CreatedBy
        {
            get
            {
                return (StudentReportDTO != null && StudentReportDTO.CreatedBy > 0) ? StudentReportDTO.CreatedBy : new int();
            }
            set
            {
                StudentReportDTO.CreatedBy = value;
            }
        }

        [Display(Name = "CreatedDate")]
        public DateTime CreatedDate
        {
            get
            {
                return (StudentReportDTO != null) ? StudentReportDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                StudentReportDTO.CreatedDate = value;
            }
        }

        [Display(Name = "ModifiedBy")]
        public int? ModifiedBy
        {
            get
            {
                return (StudentReportDTO != null && StudentReportDTO.ModifiedBy.HasValue) ? StudentReportDTO.ModifiedBy : new int();
            }
            set
            {
                StudentReportDTO.ModifiedBy = value;
            }
        }

        [Display(Name = "ModifiedDate")]
        public DateTime? ModifiedDate
        {
            get
            {
                return (StudentReportDTO != null && StudentReportDTO.ModifiedDate.HasValue) ? StudentReportDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                StudentReportDTO.ModifiedDate = value;
            }
        }

        [Display(Name = "DeletedBy")]
        public int? DeletedBy
        {
            get
            {
                return (StudentReportDTO != null && StudentReportDTO.DeletedBy.HasValue) ? StudentReportDTO.DeletedBy : new int();
            }
            set
            {
                StudentReportDTO.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime? DeletedDate
        {
            get
            {
                return (StudentReportDTO != null && StudentReportDTO.DeletedDate.HasValue) ? StudentReportDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                StudentReportDTO.DeletedDate = value;
            }
        }

        public string errorMessage { get; set; }
        public bool IsPosted { get; set; }
        



    }
}

