using AMS.Common;
using AMS.DTO;
using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Web.Mvc;
namespace AMS.ViewModel
{
    public class OnlineExaminationMasterViewModel : IOnlineExaminationMasterViewModel
    {
        public OnlineExaminationMasterViewModel()
        {
            OnlineExaminationMasterDTO = new OnlineExaminationMaster();
            AcademicSessionList = new List<GeneralSessionMaster>();
            QuestionTypeList = new List<GeneralQuestionTypeMaster>();
        }
        public List<GeneralSessionMaster> AcademicSessionList { get; set; }
        public List<GeneralQuestionTypeMaster> QuestionTypeList { get; set; }
        public List<OrganisationSubjectMaster> SubjectList { get; set; }

        public IEnumerable<SelectListItem> AcademicSessionListMasterItem { get { return new SelectList(AcademicSessionList, "ID", "SessionName"); } }
        public IEnumerable<SelectListItem> QuestionTypeListMasterItem { get { return new SelectList(QuestionTypeList, "RelatedWith", "QuestionType"); } }

        public OnlineExaminationMaster OnlineExaminationMasterDTO
        {
            get;
            set;
        }
        //----------------------------------Properties of OnlineExamExaminationMaster table--------------------------------
        public int ID
        {
            get
            {
                return (OnlineExaminationMasterDTO != null && OnlineExaminationMasterDTO.ID > 0) ? OnlineExaminationMasterDTO.ID : new int();
            }
            set
            {
                OnlineExaminationMasterDTO.ID = value;
            }
        }
        [Display(Name = "DisplayName_ExaminationName", ResourceType = typeof(AMS.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_ExaminationNameRequired")]
        public string ExaminationName
        {
            get
            {
                return (OnlineExaminationMasterDTO != null) ? OnlineExaminationMasterDTO.ExaminationName : string.Empty;
            }
            set
            {
                OnlineExaminationMasterDTO.ExaminationName = value;
            }
        }

        //[Display(Name = "DisplayName_Purpose", ResourceType = typeof(AMS.Common.Resources))]
        //[Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_PurposeRequired")]
        public string Purpose
        {
            get
            {
                return (OnlineExaminationMasterDTO != null) ? OnlineExaminationMasterDTO.Purpose : string.Empty;
            }
            set
            {
                OnlineExaminationMasterDTO.Purpose = value;
            }
        }
        public int AcadSessionId
        {
            get
            {
                return (OnlineExaminationMasterDTO != null && OnlineExaminationMasterDTO.AcadSessionId > 0) ? OnlineExaminationMasterDTO.AcadSessionId : new int();
            }
            set
            {
                OnlineExaminationMasterDTO.AcadSessionId = value;
            }
        }
        [Range(1, 240, ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_TotalTimeRangeRequired")]
        [Display(Name = "DisplayName_TotalTime", ResourceType = typeof(AMS.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_TotalTimeRequired")]
        public Int16 TotalTime
        {
            get
            {
                return (OnlineExaminationMasterDTO != null) ? OnlineExaminationMasterDTO.TotalTime : new Int16();
            }
            set
            {
                OnlineExaminationMasterDTO.TotalTime = value;
            }
        }

        [Display(Name = "DisplayName_TotalQuestion", ResourceType = typeof(AMS.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_TotalQuestionRequired")]
        public Int16 TotalQuestion
        {
            get
            {
                return (OnlineExaminationMasterDTO != null && OnlineExaminationMasterDTO.TotalQuestion > 0) ? OnlineExaminationMasterDTO.TotalQuestion : new Int16();
            }
            set
            {
                OnlineExaminationMasterDTO.TotalQuestion = value;
            }
        }

        [Display(Name = "DisplayName_TotalMarks", ResourceType = typeof(AMS.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_TotalMarksRequired")]
        public decimal TotalMarks
        {
            get
            {
                return (OnlineExaminationMasterDTO != null && OnlineExaminationMasterDTO.TotalMarks > 0) ? OnlineExaminationMasterDTO.TotalMarks : new decimal();
            }
            set
            {
                OnlineExaminationMasterDTO.TotalMarks = value;
            }
        }

        [Display(Name = "DisplayName_MarksInEachQuestion", ResourceType = typeof(AMS.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_MarksInEachQuestionRequired")]
        public decimal MarksInEachQuestion
        {
            get
            {
                return (OnlineExaminationMasterDTO != null && OnlineExaminationMasterDTO.MarksInEachQuestion > 0) ? OnlineExaminationMasterDTO.MarksInEachQuestion : new decimal();
            }
            set
            {
                OnlineExaminationMasterDTO.MarksInEachQuestion = value;
            }
        }

        [Display(Name = "DisplayName_IsNegativeMarkingApplicable", ResourceType = typeof(AMS.Common.Resources))]
        public Boolean IsNegativeMarkingApplicable
        {
            get
            {
                return (OnlineExaminationMasterDTO != null) ? OnlineExaminationMasterDTO.IsNegativeMarkingApplicable : false;
            }
            set
            {
                OnlineExaminationMasterDTO.IsNegativeMarkingApplicable = value;
            }
        }

        [Display(Name = "DisplayName_NegativeMarksInEachQuestion", ResourceType = typeof(AMS.Common.Resources))]
        public decimal NegativeMarksInEachQuestion
        {
            get
            {
                return (OnlineExaminationMasterDTO != null && OnlineExaminationMasterDTO.NegativeMarksInEachQuestion > 0) ? OnlineExaminationMasterDTO.NegativeMarksInEachQuestion : new decimal();
            }
            set
            {
                OnlineExaminationMasterDTO.NegativeMarksInEachQuestion = value;
            }
        }

        //[Display(Name = "DisplayName_TotalPaperSet", ResourceType = typeof(AMS.Common.Resources))]
        //[Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_TotalPaperSetRequired")]
        public Int16 TotalPaperSet
        {
            get
            {
                return (OnlineExaminationMasterDTO != null && OnlineExaminationMasterDTO.TotalPaperSet > 0) ? OnlineExaminationMasterDTO.TotalPaperSet : new Int16();
            }
            set
            {
                OnlineExaminationMasterDTO.TotalPaperSet = value;
            }
        }

        //----------------------------------Properties of OnlineExamExaminationSubjectApplicable  table--------------------------------
        public int OnlineExaminationSubjectApplicableID
        {
            get
            {
                return (OnlineExaminationMasterDTO != null && OnlineExaminationMasterDTO.OnlineExaminationSubjectApplicableID > 0) ? OnlineExaminationMasterDTO.OnlineExaminationSubjectApplicableID : new int();
            }
            set
            {
                OnlineExaminationMasterDTO.OnlineExaminationSubjectApplicableID = value;
            }
        }

        [Display(Name = "DisplayName_TotalQuestionQueTypeWise", ResourceType = typeof(AMS.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_TotalQuestionQueTypeWiseRequired")]
        public Int16 TotalQuestionQueTypeWise
        {
            get
            {
                return (OnlineExaminationMasterDTO != null && OnlineExaminationMasterDTO.TotalQuestionQueTypeWise > 0) ? OnlineExaminationMasterDTO.TotalQuestionQueTypeWise : new Int16();
            }
            set
            {
                OnlineExaminationMasterDTO.TotalQuestionQueTypeWise = value;
            }
        }

        public int SubjectID
        {
            get
            {
                return (OnlineExaminationMasterDTO != null && OnlineExaminationMasterDTO.SubjectID > 0) ? OnlineExaminationMasterDTO.SubjectID : new int();
            }
            set
            {
                OnlineExaminationMasterDTO.SubjectID = value;
            }
        }
        public string SubjectName
        {
            get
            {
                return (OnlineExaminationMasterDTO != null) ? OnlineExaminationMasterDTO.SubjectName : string.Empty;
            }
            set
            {
                OnlineExaminationMasterDTO.SubjectName = value;
            }
        }
        [Display(Name = "DisplayName_QuestionType", ResourceType = typeof(AMS.Common.Resources))]
        public string QuestionType
        {
            get
            {
                return (OnlineExaminationMasterDTO != null) ? OnlineExaminationMasterDTO.QuestionType : string.Empty;
            }
            set
            {
                OnlineExaminationMasterDTO.QuestionType = value;
            }
        }
        public int QuestionTypeID
        {
            get
            {
                return (OnlineExaminationMasterDTO != null && OnlineExaminationMasterDTO.QuestionTypeID > 0) ? OnlineExaminationMasterDTO.QuestionTypeID : new int();
            }
            set
            {
                OnlineExaminationMasterDTO.QuestionTypeID = value;
            }
        }
        public string errorMessage
        {
            get;
            set;
        }
        public string XMLString
        {
            get
            {
                return (OnlineExaminationMasterDTO != null) ? OnlineExaminationMasterDTO.XMLString : string.Empty;
            }
            set
            {
                OnlineExaminationMasterDTO.XMLString = value;
            }
        }        
    }
}
