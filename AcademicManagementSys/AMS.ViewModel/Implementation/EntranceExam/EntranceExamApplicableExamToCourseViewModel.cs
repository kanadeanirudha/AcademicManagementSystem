using AMS.Common;
using AMS.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AMS.ViewModel
{
    public class EntranceExamApplicableExamToCourseViewModel : IEntranceExamApplicableExamToCourseViewModel
    {

        public EntranceExamApplicableExamToCourseViewModel()
        {
            EntranceExamApplicableExamToCourseDTO = new EntranceExamApplicableExamToCourse();
            ListOrganisationCentrewiseSession = new List<OrganisationCentrewiseSession>();
            ExaminationNameList = new List<EntranceExamApplicableExamToCourse>();
        }

        public EntranceExamApplicableExamToCourse EntranceExamApplicableExamToCourseDTO
        {
            get;
            set;
        }

        public List<EntranceExamApplicableExamToCourse> ExaminationNameList { get; set; }
        public IEnumerable<SelectListItem> ExaminationNameListItems
        {
            get
            {
                return new SelectList(ExaminationNameList, "ID", "ExaminationName");
            }
        }
        public int ID
        {
            get
            {
                return (EntranceExamApplicableExamToCourseDTO != null && EntranceExamApplicableExamToCourseDTO.ID > 0) ? EntranceExamApplicableExamToCourseDTO.ID : new int();
            }
            set
            {
                EntranceExamApplicableExamToCourseDTO.ID = value;
            }
        }
        public int CourseYearDetailID
        {
            get
            {
                return (EntranceExamApplicableExamToCourseDTO != null && EntranceExamApplicableExamToCourseDTO.CourseYearDetailID > 0) ? EntranceExamApplicableExamToCourseDTO.CourseYearDetailID : new int();
            }
            set
            {
                EntranceExamApplicableExamToCourseDTO.CourseYearDetailID = value;
            }
        }
        public string SessionName { get; set; }
        public int SessionID
        {
            get
            {
                return (EntranceExamApplicableExamToCourseDTO != null && EntranceExamApplicableExamToCourseDTO.SessionID > 0) ? EntranceExamApplicableExamToCourseDTO.SessionID : new int();
            }
            set
            {
                EntranceExamApplicableExamToCourseDTO.SessionID = value;
            }
        }
        public int OnlineExamExaminationMasterID
        {
            get
            {
                return (EntranceExamApplicableExamToCourseDTO != null && EntranceExamApplicableExamToCourseDTO.OnlineExamExaminationMasterID > 0) ? EntranceExamApplicableExamToCourseDTO.OnlineExamExaminationMasterID : new int();
            }
            set
            {
                EntranceExamApplicableExamToCourseDTO.OnlineExamExaminationMasterID = value;
            }
        }

        [Display(Name = "Centre Code :")]
        public string CentreCode
        {
            get
            {
                return (EntranceExamApplicableExamToCourseDTO != null) ? EntranceExamApplicableExamToCourseDTO.CentreCode : string.Empty;
            }
            set
            {
                EntranceExamApplicableExamToCourseDTO.CentreCode = value;
            }
        }

        [Display(Name = "Centre Name :")]
        public string CentreName
        {
            get
            {
                return (EntranceExamApplicableExamToCourseDTO != null) ? EntranceExamApplicableExamToCourseDTO.CentreName : string.Empty;
            }
            set
            {
                EntranceExamApplicableExamToCourseDTO.CentreName = value;
            }
        }
       
        [Display(Name = "DisplayName_CourseName", ResourceType = typeof(AMS.Common.Resources))]
        public string CourseName
        {
            get
            {
                return (EntranceExamApplicableExamToCourseDTO != null) ? EntranceExamApplicableExamToCourseDTO.CourseName : string.Empty;
            }
            set
            {
                EntranceExamApplicableExamToCourseDTO.CourseName = value;
            }
        }

       
        [Display(Name = "DisplayName_ExaminationFromDate", ResourceType = typeof(AMS.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_ExaminationFromDateRequired")]
        public string ExaminationFromDate
        {
            get
            {
                return (EntranceExamApplicableExamToCourseDTO != null) ? EntranceExamApplicableExamToCourseDTO.ExaminationFromDate : string.Empty;
            }
            set
            {
                EntranceExamApplicableExamToCourseDTO.ExaminationFromDate = value;
            }
        }
        
        [Display(Name = "DisplayName_ExaminationUpToDate", ResourceType = typeof(AMS.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_ExaminationUpToDateRequired")]
        public string ExaminationUpToDate
        {
            get
            {
                return (EntranceExamApplicableExamToCourseDTO != null) ? EntranceExamApplicableExamToCourseDTO.ExaminationUpToDate : string.Empty;
            }
            set
            {
                EntranceExamApplicableExamToCourseDTO.ExaminationUpToDate = value;
            }
        }
       
        [Display(Name = "DisplayName_ExamName", ResourceType = typeof(AMS.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_ExamNameRequired")]
        public string ExaminationName
        {
            get
            {
                return (EntranceExamApplicableExamToCourseDTO != null) ? EntranceExamApplicableExamToCourseDTO.ExaminationName : string.Empty;
            }
            set
            {
                EntranceExamApplicableExamToCourseDTO.ExaminationName = value;
            }
        }

        [Display(Name = "IsDeleted")]
        public bool IsDeleted
        {
            get
            {
                return (EntranceExamApplicableExamToCourseDTO != null) ? EntranceExamApplicableExamToCourseDTO.IsDeleted : false;
            }
            set
            {
                EntranceExamApplicableExamToCourseDTO.IsDeleted = value;
            }
        }

        [Display(Name = "CreatedBy")]
        public int CreatedBy
        {
            get
            {
                return (EntranceExamApplicableExamToCourseDTO != null && EntranceExamApplicableExamToCourseDTO.CreatedBy > 0) ? EntranceExamApplicableExamToCourseDTO.CreatedBy : new int();
            }
            set
            {
                EntranceExamApplicableExamToCourseDTO.CreatedBy = value;
            }
        }

        [Display(Name = "CreatedDate")]
        public DateTime CreatedDate
        {
            get
            {
                return (EntranceExamApplicableExamToCourseDTO != null) ? EntranceExamApplicableExamToCourseDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                EntranceExamApplicableExamToCourseDTO.CreatedDate = value;
            }
        }

        [Display(Name = "ModifiedBy")]
        public int ModifiedBy
        {
            get
            {
                return (EntranceExamApplicableExamToCourseDTO != null) ? EntranceExamApplicableExamToCourseDTO.ModifiedBy : new int();
            }
            set
            {
                EntranceExamApplicableExamToCourseDTO.ModifiedBy = value;
            }
        }

        [Display(Name = "ModifiedDate")]
        public DateTime ModifiedDate
        {
            get
            {
                return (EntranceExamApplicableExamToCourseDTO != null) ? EntranceExamApplicableExamToCourseDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                EntranceExamApplicableExamToCourseDTO.ModifiedDate = value;
            }
        }

        [Display(Name = "DeletedBy")]
        public int DeletedBy
        {
            get
            {
                return (EntranceExamApplicableExamToCourseDTO != null) ? EntranceExamApplicableExamToCourseDTO.DeletedBy : new int();
            }
            set
            {
                EntranceExamApplicableExamToCourseDTO.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime DeletedDate
        {
            get
            {
                return (EntranceExamApplicableExamToCourseDTO != null) ? EntranceExamApplicableExamToCourseDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                EntranceExamApplicableExamToCourseDTO.DeletedDate = value;
            }
        }
        public List<OrganisationCentrewiseSession> ListOrganisationCentrewiseSession
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

        public string errorMessage { get; set; }
    }
}

