using AMS.Common;
using AMS.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web;
using System.Web.Mvc;

namespace AMS.ViewModel
{
    public class OnlineExamQuestionBankMasterAndDetailsViewModel : IOnlineExamQuestionBankMasterAndDetailsViewModel
    {

        public OnlineExamQuestionBankMasterAndDetailsViewModel()
        {
            OnlineExamQuestionBankMasterAndDetailsDTO = new OnlineExamQuestionBankMasterAndDetails();
            QuestionTypeList = new List<GeneralQuestionTypeMaster>();
            CorseListList = new List<OrganisationCourseYearDetails>();
            SubjectGroup = new List<OrganisationSubjectGroupDetails>();
            AdminRoleApplicableCenter = new List<AdminRoleApplicableDetails>();
        }
        public List<GeneralQuestionTypeMaster> QuestionTypeList { get; set; }
        public List<OrganisationCourseYearDetails> CorseListList { get; set; }
        public List<OrganisationSubjectGroupDetails> SubjectGroup { get; set; }
        public List<AdminRoleApplicableDetails> AdminRoleApplicableCenter { get; set; }

        public IEnumerable<SelectListItem> QuestionTypeListMasterItem { get { return new SelectList(QuestionTypeList, "RelatedWith", "QuestionType"); } }

        public IEnumerable<SelectListItem> CourseTypeListMasterItem { get { return new SelectList(CorseListList, "ID", "CourseDescription"); } }

        public IEnumerable<SelectListItem> SubjectGroupListItem { get { return new SelectList(SubjectGroup, "ID", "Description"); } }

        public IEnumerable<SelectListItem> ApplicableCenters { get { return new SelectList(AdminRoleApplicableCenter, "CentreCode", "CentreName"); } }

        public OnlineExamQuestionBankMasterAndDetails OnlineExamQuestionBankMasterAndDetailsDTO
        {
            get;
            set;
        }

        public int ID
        {
            get
            {
                return (OnlineExamQuestionBankMasterAndDetailsDTO != null && OnlineExamQuestionBankMasterAndDetailsDTO.ID > 0) ? OnlineExamQuestionBankMasterAndDetailsDTO.ID : new int();
            }
            set
            {
                OnlineExamQuestionBankMasterAndDetailsDTO.ID = value;
            }
        }

        [Display(Name = "Question Type")]        
        public Int16 GenQuestionTypeID
        {
            get
            {
                return (OnlineExamQuestionBankMasterAndDetailsDTO != null && OnlineExamQuestionBankMasterAndDetailsDTO.GenQuestionTypeID > 0) ? OnlineExamQuestionBankMasterAndDetailsDTO.GenQuestionTypeID : new Int16();
            }
            set
            {
                OnlineExamQuestionBankMasterAndDetailsDTO.GenQuestionTypeID = value;
            }
        }

        [Display(Name = "DisplayName_QuestionType", ResourceType = typeof(AMS.Common.Resources))]
        [Required(ErrorMessage = "Question type should not be blank.")]
        public string GenQuestionType
        {
            get
            {
                return (OnlineExamQuestionBankMasterAndDetailsDTO != null) ? OnlineExamQuestionBankMasterAndDetailsDTO.GenQuestionType : string.Empty;
            }
            set
            {
                OnlineExamQuestionBankMasterAndDetailsDTO.GenQuestionType = value;
            }
        }

        //
        [Display(Name = "Course Year")]
        [Required(ErrorMessage = "Course year should not be blank")]
        public string CourseType
        {
            get
            {
                return (OnlineExamQuestionBankMasterAndDetailsDTO != null) ? OnlineExamQuestionBankMasterAndDetailsDTO.CourseType : string.Empty;
            }
            set
            {
                OnlineExamQuestionBankMasterAndDetailsDTO.CourseType = value;
            }
        }

        [Display(Name = "Subject group")]
        [Required(ErrorMessage = "Subject group should not be blank")]
        public string SubjectGroupType
        {
            get
            {
                return (OnlineExamQuestionBankMasterAndDetailsDTO != null) ? OnlineExamQuestionBankMasterAndDetailsDTO.SubjectGroupType : string.Empty;
            }
            set
            {
                OnlineExamQuestionBankMasterAndDetailsDTO.SubjectGroupType = value;
            }
        }

        [Display(Name = "Center")]
        [Required(ErrorMessage = "Center should not be blank")]
        public string Center
        {
            get
            {
                return (OnlineExamQuestionBankMasterAndDetailsDTO != null) ? OnlineExamQuestionBankMasterAndDetailsDTO.Center : string.Empty;
            }
            set
            {
                OnlineExamQuestionBankMasterAndDetailsDTO.Center = value;
            }
        }
        //
        public int SubjectID
        {
            get
            {
                return (OnlineExamQuestionBankMasterAndDetailsDTO != null && OnlineExamQuestionBankMasterAndDetailsDTO.SubjectID > 0) ? OnlineExamQuestionBankMasterAndDetailsDTO.SubjectID : new int();
            }
            set
            {
                OnlineExamQuestionBankMasterAndDetailsDTO.SubjectID = value;
            }
        }
        public int CourseYearDetailID
        {
            get
            {
                return (OnlineExamQuestionBankMasterAndDetailsDTO != null && OnlineExamQuestionBankMasterAndDetailsDTO.CourseYearDetailID > 0) ? OnlineExamQuestionBankMasterAndDetailsDTO.CourseYearDetailID : new int();
            }
            set
            {
                OnlineExamQuestionBankMasterAndDetailsDTO.CourseYearDetailID = value;
            }
        }
        public int OrgSemesterMstID
        {
            get
            {
                return (OnlineExamQuestionBankMasterAndDetailsDTO != null && OnlineExamQuestionBankMasterAndDetailsDTO.OrgSemesterMstID > 0) ? OnlineExamQuestionBankMasterAndDetailsDTO.OrgSemesterMstID : new int();
            }
            set
            {
                OnlineExamQuestionBankMasterAndDetailsDTO.OrgSemesterMstID = value;
            }
        }
        public int SubjectGroupID
        {
            get
            {
                return (OnlineExamQuestionBankMasterAndDetailsDTO != null && OnlineExamQuestionBankMasterAndDetailsDTO.SubjectGroupID > 0) ? OnlineExamQuestionBankMasterAndDetailsDTO.SubjectGroupID : new int();
            }
            set
            {
                OnlineExamQuestionBankMasterAndDetailsDTO.SubjectGroupID = value;
            }
        }
        public int OnlineExamExaminationQuestionPaperID
        {
            get
            {
                return (OnlineExamQuestionBankMasterAndDetailsDTO != null && OnlineExamQuestionBankMasterAndDetailsDTO.OnlineExamExaminationQuestionPaperID > 0) ? OnlineExamQuestionBankMasterAndDetailsDTO.OnlineExamExaminationQuestionPaperID : new int();
            }
            set
            {
                OnlineExamQuestionBankMasterAndDetailsDTO.OnlineExamExaminationQuestionPaperID = value;
            }
        }
        public int OnlineExamSubjectGroupScheduleID
        {
            get
            {
                return (OnlineExamQuestionBankMasterAndDetailsDTO != null && OnlineExamQuestionBankMasterAndDetailsDTO.OnlineExamSubjectGroupScheduleID > 0) ? OnlineExamQuestionBankMasterAndDetailsDTO.OnlineExamSubjectGroupScheduleID : new int();
            }
            set
            {
                OnlineExamQuestionBankMasterAndDetailsDTO.OnlineExamSubjectGroupScheduleID = value;
            }
        }
        public string OptionImageList
        {
            get
            {
                return (OnlineExamQuestionBankMasterAndDetailsDTO != null) ? OnlineExamQuestionBankMasterAndDetailsDTO.OptionImageList : String.Empty;
            }
            set
            {
                OnlineExamQuestionBankMasterAndDetailsDTO.OptionImageList = value;
            }
        }
        public string OptionTextList
        {
            get
            {
                return (OnlineExamQuestionBankMasterAndDetailsDTO != null) ? OnlineExamQuestionBankMasterAndDetailsDTO.OptionTextList : String.Empty;
            }
            set
            {
                OnlineExamQuestionBankMasterAndDetailsDTO.OptionTextList = value;
            }
        }
       
        [Display(Name = "Subject Name")]
        public string SubjectName
        {
            get
            {
                return (OnlineExamQuestionBankMasterAndDetailsDTO != null) ? OnlineExamQuestionBankMasterAndDetailsDTO.SubjectName : string.Empty;
            }
            set
            {
                OnlineExamQuestionBankMasterAndDetailsDTO.SubjectName = value;
            }
        }
        [Display(Name = "Question Text")]
        [Required(ErrorMessage = "Question text should not be blank")]
        public string QuestionLableText
        {
            get
            {
                return (OnlineExamQuestionBankMasterAndDetailsDTO != null) ? OnlineExamQuestionBankMasterAndDetailsDTO.QuestionLableText : string.Empty;
            }
            set
            {
                OnlineExamQuestionBankMasterAndDetailsDTO.QuestionLableText = value;
            }
        }


        [Display(Name = "Image Type")]
        public string ImageType
        {
            get
            {
                return (OnlineExamQuestionBankMasterAndDetailsDTO != null) ? OnlineExamQuestionBankMasterAndDetailsDTO.ImageType : string.Empty;
            }
            set
            {
                OnlineExamQuestionBankMasterAndDetailsDTO.ImageType = value;
            }
        }

        [Display(Name = "Question Image")]
        public string ImageName
        {
            get
            {
                return (OnlineExamQuestionBankMasterAndDetailsDTO != null) ? OnlineExamQuestionBankMasterAndDetailsDTO.ImageName : string.Empty;
            }
            set
            {
                OnlineExamQuestionBankMasterAndDetailsDTO.ImageName = value;
            }
        }

        [Display(Name = "Is Question In Image")]
        public bool IsQuestionInImage
        {
            get
            {
                return (OnlineExamQuestionBankMasterAndDetailsDTO != null) ? OnlineExamQuestionBankMasterAndDetailsDTO.IsQuestionInImage : false;
            }
            set
            {
                OnlineExamQuestionBankMasterAndDetailsDTO.IsQuestionInImage = value;
            }
        }
        [Display(Name = "Is Option In Image")]
        public bool IsOptionInImage
        {
            get
            {
                return (OnlineExamQuestionBankMasterAndDetailsDTO != null) ? OnlineExamQuestionBankMasterAndDetailsDTO.IsQuestionInImage : false;
            }
            set
            {
                OnlineExamQuestionBankMasterAndDetailsDTO.IsQuestionInImage = value;
            }
        }

        public int LastAppearedInExamID
        {
            get
            {
                return (OnlineExamQuestionBankMasterAndDetailsDTO != null && OnlineExamQuestionBankMasterAndDetailsDTO.LastAppearedInExamID > 0) ? OnlineExamQuestionBankMasterAndDetailsDTO.LastAppearedInExamID : new int();
            }
            set
            {
                OnlineExamQuestionBankMasterAndDetailsDTO.LastAppearedInExamID = value;
            }
        }

        [Display(Name = "Appear Date")]
        public string AppearDate
        {
            get
            {
                return (OnlineExamQuestionBankMasterAndDetailsDTO != null) ? OnlineExamQuestionBankMasterAndDetailsDTO.AppearDate : string.Empty;
            }
            set
            {
                OnlineExamQuestionBankMasterAndDetailsDTO.AppearDate = value;
            }
        }
        [Display(Name = "Option Text")]
        public string OptionText
        {
            get
            {
                return (OnlineExamQuestionBankMasterAndDetailsDTO != null) ? OnlineExamQuestionBankMasterAndDetailsDTO.OptionText : string.Empty;
            }
            set
            {
                OnlineExamQuestionBankMasterAndDetailsDTO.OptionText = value;
            }
        }
        [Display(Name = "Option Image")]
        public string OptionImage
        {
            get
            {
                return (OnlineExamQuestionBankMasterAndDetailsDTO != null) ? OnlineExamQuestionBankMasterAndDetailsDTO.OptionImage : string.Empty;
            }
            set
            {
                OnlineExamQuestionBankMasterAndDetailsDTO.OptionImage = value;
            }
        }

        [Display(Name = "Attachement")]
        public Int16 IsAttachmentCompalsary
        {
            get
            {
                return (OnlineExamQuestionBankMasterAndDetailsDTO != null) ? OnlineExamQuestionBankMasterAndDetailsDTO.IsAttachmentCompalsary : new Int16();
            }
            set
            {
                OnlineExamQuestionBankMasterAndDetailsDTO.IsAttachmentCompalsary = value;
            }
        }

        [Display(Name = "Descriptive Answer")]
        public bool IsQuestionDescriptive
        {
            get
            {
                return (OnlineExamQuestionBankMasterAndDetailsDTO != null) ? OnlineExamQuestionBankMasterAndDetailsDTO.IsQuestionDescriptive : false;
            }
            set
            {
                OnlineExamQuestionBankMasterAndDetailsDTO.IsQuestionDescriptive = value;
            }
        }

        [Display(Name = "IsActive")]
        public bool IsActive
        {
            get
            {
                return (OnlineExamQuestionBankMasterAndDetailsDTO != null) ? OnlineExamQuestionBankMasterAndDetailsDTO.IsActive : false;
            }
            set
            {
                OnlineExamQuestionBankMasterAndDetailsDTO.IsActive = value;
            }
        }

        [Display(Name = "IsDeleted")]
        public bool IsDeleted
        {
            get
            {
                return (OnlineExamQuestionBankMasterAndDetailsDTO != null) ? OnlineExamQuestionBankMasterAndDetailsDTO.IsDeleted : false;
            }
            set
            {
                OnlineExamQuestionBankMasterAndDetailsDTO.IsDeleted = value;
            }
        }

        [Display(Name = "CreatedBy")]
        public int CreatedBy
        {
            get
            {
                return (OnlineExamQuestionBankMasterAndDetailsDTO != null && OnlineExamQuestionBankMasterAndDetailsDTO.CreatedBy > 0) ? OnlineExamQuestionBankMasterAndDetailsDTO.CreatedBy : new int();
            }
            set
            {
                OnlineExamQuestionBankMasterAndDetailsDTO.CreatedBy = value;
            }
        }

        [Display(Name = "CreatedDate")]
        public DateTime CreatedDate
        {
            get
            {
                return (OnlineExamQuestionBankMasterAndDetailsDTO != null) ? OnlineExamQuestionBankMasterAndDetailsDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                OnlineExamQuestionBankMasterAndDetailsDTO.CreatedDate = value;
            }
        }

        [Display(Name = "ModifiedBy")]
        public int ModifiedBy
        {
            get
            {
                return (OnlineExamQuestionBankMasterAndDetailsDTO != null && OnlineExamQuestionBankMasterAndDetailsDTO.ModifiedBy > 0) ? OnlineExamQuestionBankMasterAndDetailsDTO.ModifiedBy : new int();
            }
            set
            {
                OnlineExamQuestionBankMasterAndDetailsDTO.ModifiedBy = value;
            }
        }

        [Display(Name = "ModifiedDate")]
        public DateTime ModifiedDate
        {
            get
            {
                return (OnlineExamQuestionBankMasterAndDetailsDTO != null) ? OnlineExamQuestionBankMasterAndDetailsDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                OnlineExamQuestionBankMasterAndDetailsDTO.ModifiedDate = value;
            }
        }

        [Display(Name = "DeletedBy")]
        public int DeletedBy
        {
            get
            {
                return (OnlineExamQuestionBankMasterAndDetailsDTO != null) ? OnlineExamQuestionBankMasterAndDetailsDTO.DeletedBy : new int();
            }
            set
            {
                OnlineExamQuestionBankMasterAndDetailsDTO.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime DeletedDate
        {
            get
            {
                return (OnlineExamQuestionBankMasterAndDetailsDTO != null) ? OnlineExamQuestionBankMasterAndDetailsDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                OnlineExamQuestionBankMasterAndDetailsDTO.DeletedDate = value;
            }
        }


        public string errorMessage { get; set; }
        public string SelectedXml
        {
            get
            {
                return (OnlineExamQuestionBankMasterAndDetailsDTO != null) ? OnlineExamQuestionBankMasterAndDetailsDTO.SelectedXml : string.Empty;
            }
            set
            {
                OnlineExamQuestionBankMasterAndDetailsDTO.SelectedXml = value;
            }
        }


        [Display(Name = "OnlineExamQuestionBankDetailsID")]
        public int OnlineExamQuestionBankDetailsID
        {
            get
            {
                return (OnlineExamQuestionBankMasterAndDetailsDTO != null) ? OnlineExamQuestionBankMasterAndDetailsDTO.OnlineExamQuestionBankDetailsID : new int();
            }
            set
            {
                OnlineExamQuestionBankMasterAndDetailsDTO.OnlineExamQuestionBankDetailsID = value;
            }
        }

        [Display(Name = "OnlineExamQuestionBankMasterID")]
        public int OnlineExamQuestionBankMasterID
        {
            get
            {
                return (OnlineExamQuestionBankMasterAndDetailsDTO != null) ? OnlineExamQuestionBankMasterAndDetailsDTO.OnlineExamQuestionBankMasterID : new int();
            }
            set
            {
                OnlineExamQuestionBankMasterAndDetailsDTO.OnlineExamQuestionBankMasterID = value;
            }
        }
       [Display(Name = "Question Level Type")]
       [Required(ErrorMessage = "Question Level Type should not be blank.")]
        public int GeneralQuestionLevelMasterID
        {
            get
            {
                return (OnlineExamQuestionBankMasterAndDetailsDTO != null) ? OnlineExamQuestionBankMasterAndDetailsDTO.GeneralQuestionLevelMasterID : new int();
            }
            set
            {
                OnlineExamQuestionBankMasterAndDetailsDTO.GeneralQuestionLevelMasterID = value;
            }
        }
        [Display(Name = "Is Answer?")]
        public bool IsAnswer
        {
            get
            {
                return (OnlineExamQuestionBankMasterAndDetailsDTO != null) ? OnlineExamQuestionBankMasterAndDetailsDTO.IsAnswer : false;
            }
            set
            {
                OnlineExamQuestionBankMasterAndDetailsDTO.IsAnswer = value;
            }
        }

        [Display(Name = "Internet URL")]
        public string Url { get; set; }

        public bool IsUrl { get; set; }

        [Display(Name = "Flickr image")]
        public string Flickr { get; set; }

        public bool IsFlickr { get; set; }

        public bool IsFile { get; set; }

        [Range(0, int.MaxValue)]
        public int X { get; set; }

        [Range(0, int.MaxValue)]
        public int Y { get; set; }

        [Range(1, int.MaxValue)]
        public int Width { get; set; }

        [Range(1, int.MaxValue)]
        public int Height { get; set; }
       
        public HttpPostedFileBase QuestionImageFile { get; set; }
        public HttpPostedFileBase OptionImageFile { get; set; }

    }
}

