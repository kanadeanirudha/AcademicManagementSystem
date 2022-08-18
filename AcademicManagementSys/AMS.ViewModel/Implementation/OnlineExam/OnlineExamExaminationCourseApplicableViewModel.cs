using AMS.Common;
using AMS.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AMS.ViewModel
{
    public class OnlineExamExaminationCourseApplicableViewModel : IOnlineExamExaminationCourseApplicableViewModel
    {

        public OnlineExamExaminationCourseApplicableViewModel()
        {
            OnlineExamExaminationCourseApplicableDTO = new OnlineExamExaminationCourseApplicable();
            DescriptionList = new List<OrganisationCourseYearDetails>();
            SemesterList = new List<OrganisationSemesterMaster>();
            DepartmentList = new List<OrganisationDepartmentMaster>();

        }
        public List<OrganisationCourseYearDetails> DescriptionList { get; set; }
        public IEnumerable<SelectListItem> DescriptionListItems { get { return new SelectList(DescriptionList, "DescriptionName", "DescriptionName"); } }

        public List<OrganisationSemesterMaster> SemesterList { get; set; }
        public IEnumerable<SelectListItem> SemesterListItems { get { return new SelectList(SemesterList, "SemesterID", "SemesterName"); } }

        public List<OrganisationDepartmentMaster> DepartmentList { get; set; }
        public IEnumerable<SelectListItem> DepartmentListItem { get { return new SelectList(DepartmentList, DepartmentName, DepartmentName); } }

        public OnlineExamExaminationCourseApplicable OnlineExamExaminationCourseApplicableDTO
        {
            get;
            set;
        }

        public Int32 ID
        {
            get
            {
                return (OnlineExamExaminationCourseApplicableDTO != null && OnlineExamExaminationCourseApplicableDTO.ID > 0) ? OnlineExamExaminationCourseApplicableDTO.ID : new Int32();
            }
            set
            {
                OnlineExamExaminationCourseApplicableDTO.ID= value;
            }
        }

        public Int32 OnlineExamExaminationMasterId
        {
            get
            {
                return (OnlineExamExaminationCourseApplicableDTO != null && OnlineExamExaminationCourseApplicableDTO.OnlineExamExaminationMasterId > 0) ? OnlineExamExaminationCourseApplicableDTO.OnlineExamExaminationMasterId : new Int32();
            }
            set
            {
                OnlineExamExaminationCourseApplicableDTO.OnlineExamExaminationMasterId = value;
            }
        }
        public String ExaminationName
        {
            get
            {
                return (OnlineExamExaminationCourseApplicableDTO != null) ? OnlineExamExaminationCourseApplicableDTO.ExaminationName : string.Empty;
            }
            set
            {
                OnlineExamExaminationCourseApplicableDTO.ExaminationName = value;
            }
        }

        [Required(ErrorMessage = "CourseYear should not be blank.")]
        [Display(Name = "Course Year ")]
        public Int32 CourseYearID
        {
            get
            {
                return (OnlineExamExaminationCourseApplicableDTO != null) ? OnlineExamExaminationCourseApplicableDTO.CourseYearID : new Int32();
            }
            set
            {
                OnlineExamExaminationCourseApplicableDTO.CourseYearID = value;
            }
        }


        public Int32 SemesterMstID
        {
            get
            {
                return (OnlineExamExaminationCourseApplicableDTO != null) ? OnlineExamExaminationCourseApplicableDTO.SemesterMstID : new Int32();
            }
            set
            {
                OnlineExamExaminationCourseApplicableDTO.SemesterMstID = value;
            }
        }
        
        [Required(ErrorMessage = "Semester should not be blank.")]
        [Display(Name = "Semester")]
        public String Semester
        {
            get
            {
                return (OnlineExamExaminationCourseApplicableDTO != null) ? OnlineExamExaminationCourseApplicableDTO.Semester : string.Empty;
            }
            set
            {
                OnlineExamExaminationCourseApplicableDTO.Semester= value;
            }
        }
        [Required(ErrorMessage = "Department should not be blank.")]
        [Display(Name = "Department ")]
        public Int32 DepartmentID
        {
            get
            {
                return (OnlineExamExaminationCourseApplicableDTO != null) ? OnlineExamExaminationCourseApplicableDTO.DepartmentID : new Int32();
            }
            set
            {
                OnlineExamExaminationCourseApplicableDTO.DepartmentID = value;
            }
        }
        [Required(ErrorMessage = "Examination Status should not be blank.")]
        [Display(Name = "Examination Status")]
        public byte ExaminationStatus
        {
            get
            {
                return (OnlineExamExaminationCourseApplicableDTO != null) ? OnlineExamExaminationCourseApplicableDTO.ExaminationStatus : new byte();
            }
            set
            {
                OnlineExamExaminationCourseApplicableDTO.ExaminationStatus = value;
            }
        }
        [Required(ErrorMessage = "Examination Start Date should not be blank.")]
        [Display(Name = "Examination Start Date")]
        public String ExaminationStartDate
        {
            get
            {
                return (OnlineExamExaminationCourseApplicableDTO != null) ? OnlineExamExaminationCourseApplicableDTO.ExaminationStartDate : string.Empty;
            }
            set
            {
                OnlineExamExaminationCourseApplicableDTO.ExaminationStartDate= value;
            }
        }
        [Required(ErrorMessage = "Examination End Date should not be blank.")]
        [Display(Name = "Examination End Date ")]
        public String ExaminationEndDate
        {
            get
            {
                return (OnlineExamExaminationCourseApplicableDTO != null) ? OnlineExamExaminationCourseApplicableDTO.ExaminationEndDate : string.Empty;
            }
            set
            {
                OnlineExamExaminationCourseApplicableDTO.ExaminationEndDate = value;
            }
        }
        [Required(ErrorMessage = "Result Announce Date should not be blank.")]
        [Display(Name = "Result Announce Date")]
        public string ResultAnnounceDate
        {
            get
            {
                return (OnlineExamExaminationCourseApplicableDTO != null) ? OnlineExamExaminationCourseApplicableDTO.ResultAnnounceDate : string.Empty;
            }
            set
            {
                OnlineExamExaminationCourseApplicableDTO.ResultAnnounceDate = value;
            }
        }
        [Required(ErrorMessage = "Description should not be blank.")]
        [Display(Name = "Description")]
        public String Description
        {
            get
            {
                return (OnlineExamExaminationCourseApplicableDTO != null) ? OnlineExamExaminationCourseApplicableDTO.Description : string.Empty;
            }
            set
            {
                OnlineExamExaminationCourseApplicableDTO.Description = value;
            }
        }
        [Required(ErrorMessage = "Department Name should not be blank.")]
        [Display(Name = "DepartmentName")]
        public String DepartmentName
        {
            get
            {
                return (OnlineExamExaminationCourseApplicableDTO != null) ? OnlineExamExaminationCourseApplicableDTO.DepartmentName : string.Empty;
            }
            set
            {
                OnlineExamExaminationCourseApplicableDTO.DepartmentName = value;
            }
        }
        [Display(Name = "IsResultAnnounce")]
        public bool IsResultAnnounce
        {
            get
            {
                return (OnlineExamExaminationCourseApplicableDTO != null) ? OnlineExamExaminationCourseApplicableDTO.IsResultAnnounce : new bool();
            }
            set
            {
                OnlineExamExaminationCourseApplicableDTO.IsResultAnnounce= value;
            }
        }
        public bool IsAllChecked
        {
            get
            {
                return (OnlineExamExaminationCourseApplicableDTO != null) ? OnlineExamExaminationCourseApplicableDTO.IsAllChecked : new bool();
            }
            set
            {
                OnlineExamExaminationCourseApplicableDTO.IsAllChecked = value;
            }
        }
        [Display(Name = "IsDeleted")]
        public bool IsDeleted
        {
            get
            {
                return (OnlineExamExaminationCourseApplicableDTO != null) ? OnlineExamExaminationCourseApplicableDTO.IsDeleted : false;
            }
            set
            {
                OnlineExamExaminationCourseApplicableDTO.IsDeleted = value;
            }
        }

        [Display(Name = "CreatedBy")]
        public int CreatedBy
        {
            get
            {
                return (OnlineExamExaminationCourseApplicableDTO != null && OnlineExamExaminationCourseApplicableDTO.CreatedBy > 0) ? OnlineExamExaminationCourseApplicableDTO.CreatedBy : new int();
            }
            set
            {
                OnlineExamExaminationCourseApplicableDTO.CreatedBy = value;
            }
        }

        [Display(Name = "CreatedDate")]
        public DateTime CreatedDate
        {
            get
            {
                return (OnlineExamExaminationCourseApplicableDTO != null) ? OnlineExamExaminationCourseApplicableDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                OnlineExamExaminationCourseApplicableDTO.CreatedDate = value;
            }
        }

        [Display(Name = "ModifiedBy")]
        public int ModifiedBy
        {
            get
            {
                return (OnlineExamExaminationCourseApplicableDTO != null) ? OnlineExamExaminationCourseApplicableDTO.ModifiedBy : new int();
            }
            set
            {
                OnlineExamExaminationCourseApplicableDTO.ModifiedBy = value;
            }
        }

        [Display(Name = "ModifiedDate")]
        public DateTime ModifiedDate
        {
            get
            {
                return (OnlineExamExaminationCourseApplicableDTO != null) ? OnlineExamExaminationCourseApplicableDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                OnlineExamExaminationCourseApplicableDTO.ModifiedDate = value;
            }
        }

        [Display(Name = "DeletedBy")]
        public int DeletedBy
        {
            get
            {
                return (OnlineExamExaminationCourseApplicableDTO != null) ? OnlineExamExaminationCourseApplicableDTO.DeletedBy : new int();
            }
            set
            {
                OnlineExamExaminationCourseApplicableDTO.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime DeletedDate
        {
            get
            {
                return (OnlineExamExaminationCourseApplicableDTO != null) ? OnlineExamExaminationCourseApplicableDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                OnlineExamExaminationCourseApplicableDTO.DeletedDate = value;
            }
        }


        public string errorMessage { get; set; }






    }
}

