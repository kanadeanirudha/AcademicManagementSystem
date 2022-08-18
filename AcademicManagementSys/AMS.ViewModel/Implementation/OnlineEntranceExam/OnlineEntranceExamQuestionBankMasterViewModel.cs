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
    public class OnlineEntranceExamQuestionBankMasterViewModel : IOnlineEntranceExamQuestionBankMasterViewModel
    {
        public OnlineEntranceExamQuestionBankMasterViewModel()
        {
            OnlineEntranceExamQuestionBankMasterDTO = new OnlineEntranceExamQuestionBankMaster();
            ListGetAdminRoleApplicableCentre = new List<AdminRoleApplicableDetails>();
            ListOrganisationUniversityMaster = new List<OrganisationUniversityMaster>();
            ListOrganisationDepartmentMaster = new List<OrganisationDepartmentMaster>();
            ListOnlineExamCourse = new List<OnlineEntranceExamQuestionBankMaster>();
            ListOrganisationCourseYear = new List<OnlineEntranceExamQuestionBankMaster>();
            ListOrganisationSubjectMaster = new List<OrganisationSubjectMaster>();
            ListQuestionLevelMaster = new List<GeneralQuestionLevelMaster>();
            QuestionTypeList = new List<GeneralQuestionTypeMaster>();
            ListSyllabusGroupUnit = new List<OrganisationSyllabusGroupMaster>();
            ListSyllabusGroupTopic = new List<OrganisationSyllabusGroupMaster>();
            GetQuestionBankAndDetailList = new List<OnlineEntranceExamQuestionBankMaster>();
        }

        public OnlineEntranceExamQuestionBankMaster OnlineEntranceExamQuestionBankMasterDTO { get; set; }
        public List<AdminRoleApplicableDetails> ListGetAdminRoleApplicableCentre { get; set; }
        public List<OrganisationUniversityMaster> ListOrganisationUniversityMaster { get; set; }
        public List<OrganisationDepartmentMaster> ListOrganisationDepartmentMaster { get; set; }
        public List<OnlineEntranceExamQuestionBankMaster> ListOnlineExamCourse { get; set; }
        public List<OnlineEntranceExamQuestionBankMaster> ListOrganisationCourseYear { get; set; }
        public List<OrganisationSubjectMaster> ListOrganisationSubjectMaster { get; set; }
        public List<GeneralQuestionLevelMaster> ListQuestionLevelMaster { get; set; }
        public List<GeneralQuestionTypeMaster> QuestionTypeList { get; set; }
        public List<OrganisationSyllabusGroupMaster> ListSyllabusGroupUnit { get; set; }
        public List<OrganisationSyllabusGroupMaster> ListSyllabusGroupTopic { get; set; }
        public List<OnlineEntranceExamQuestionBankMaster> GetQuestionBankAndDetailList { get; set; }

        public IEnumerable<SelectListItem> ListGetAdminRoleApplicableCentreItems
        {
            get
            {
                return new SelectList(ListGetAdminRoleApplicableCentre, "CentreCode", "CentreName");
            }
        }

        public IEnumerable<SelectListItem> ListOrganisationUnivesitytMasterItems
        {
            get
            {

                return new SelectList(ListOrganisationUniversityMaster, "ID", "UniversityName");
            }

        }

        public IEnumerable<SelectListItem> ListOrganisationDepartmentMasterItems
        {
            get
            {
                return new SelectList(ListOrganisationDepartmentMaster, "ID", "DepartmentName");
            }
        }

        public IEnumerable<SelectListItem> ListOnlineExamCourseItems
        {
            get
            {

                return new SelectList(ListOnlineExamCourse, "OrgBranchMasterID", "BranchDescription");
            }

        }

        public IEnumerable<SelectListItem> ListOrganisationCourseYearItems
        {
            get
            {

                return new SelectList(ListOrganisationCourseYear, "SelectedCourseYearID", "CourseYearDetailsDescription");
            }

        }

        public IEnumerable<SelectListItem> ListOrganisationSubjectMasterItems
        {
            get
            {
                return new SelectList(ListOrganisationSubjectMaster, "SubjectID", "Descriptions");
            }
        }

        public IEnumerable<SelectListItem> ListQuestionLevelMasterItems
        {
            get
            {
                return new SelectList(ListQuestionLevelMaster, "GeneralQuestionLevelMasterID", "LevelDescription");
            }
        }

        public IEnumerable<SelectListItem> QuestionTypeListMasterItem
        {
            get
            {
                return new SelectList(QuestionTypeList, "ID", "QuestionType");
            }
        }


        public IEnumerable<SelectListItem> ListSyllabusGroupUnitItem
        {
            get
            {
                return new SelectList(ListSyllabusGroupUnit, "SyllabusGrpAndDetailID", "UnitDescription");
            }
        }

        public IEnumerable<SelectListItem> ListSyllabusGroupTopicItems
        {
            get
            {
                return new SelectList(ListSyllabusGroupTopic, "SyllabusGrpTopicsID", "TopicName");
            }
        }
        

        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~OnlineExamQuestionBankMaster ~~~~~~~~~~~~~~~~~~~~~~~~~~
        public int OnlineExamQuestionBankMasterID
        {
            get
            {
                return (OnlineEntranceExamQuestionBankMasterDTO.OnlineExamQuestionBankMasterID > 0) ? OnlineEntranceExamQuestionBankMasterDTO.OnlineExamQuestionBankMasterID : new int();
            }
            set
            {
                OnlineEntranceExamQuestionBankMasterDTO.OnlineExamQuestionBankMasterID = value;
            }
        }
        public int SubjectID
        {
            get
            {
                return (OnlineEntranceExamQuestionBankMasterDTO.SubjectID > 0) ? OnlineEntranceExamQuestionBankMasterDTO.SubjectID : new int();
            }
            set
            {
                OnlineEntranceExamQuestionBankMasterDTO.SubjectID = value;
            }
        }
        public int SubjectGroupID
        {
            get
            {
                return (OnlineEntranceExamQuestionBankMasterDTO.SubjectGroupID > 0) ? OnlineEntranceExamQuestionBankMasterDTO.SubjectGroupID : new int();
            }
            set
            {
                OnlineEntranceExamQuestionBankMasterDTO.SubjectGroupID = value;
            }
        }

        public int CourseYearDetailID
        {
            get
            {
                return (OnlineEntranceExamQuestionBankMasterDTO.CourseYearDetailID > 0) ? OnlineEntranceExamQuestionBankMasterDTO.CourseYearDetailID : new int();
            }
            set
            {
                OnlineEntranceExamQuestionBankMasterDTO.CourseYearDetailID = value;
            }
        }

        [Display(Name = "Department ")]
        public int DepartmentID
        {
            get
            {
                return (OnlineEntranceExamQuestionBankMasterDTO.DepartmentID > 0) ? OnlineEntranceExamQuestionBankMasterDTO.DepartmentID : new int();
            }
            set
            {
                OnlineEntranceExamQuestionBankMasterDTO.DepartmentID = value;
            }
        }
        public int OldOnlineExamQuestionBankMasterID
        {
            get
            {
                return (OnlineEntranceExamQuestionBankMasterDTO.OldOnlineExamQuestionBankMasterID > 0) ? OnlineEntranceExamQuestionBankMasterDTO.OldOnlineExamQuestionBankMasterID : new int();
            }
            set
            {
                OnlineEntranceExamQuestionBankMasterDTO.OldOnlineExamQuestionBankMasterID = value;
            }
        }
        public Int16 IsAcademic
        {
            get
            {
                return (OnlineEntranceExamQuestionBankMasterDTO.IsAcademic > 0) ? OnlineEntranceExamQuestionBankMasterDTO.IsAcademic : new Int16();
            }
            set
            {
                OnlineEntranceExamQuestionBankMasterDTO.IsAcademic = value;
            }
        }

        [Display(Name = "Subject")]
        public string SubjectName
        {
            get
            {
                return (OnlineEntranceExamQuestionBankMasterDTO.SubjectName != null && OnlineEntranceExamQuestionBankMasterDTO.SubjectName != "") ? OnlineEntranceExamQuestionBankMasterDTO.SubjectName : string.Empty;
            }
            set
            {
                OnlineEntranceExamQuestionBankMasterDTO.SubjectName = value;
            }
        }

        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ OnlineQuestionBankDetails ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        public int OnlineQuestionBankDetailsID
        {
            get
            {
                return (OnlineEntranceExamQuestionBankMasterDTO.OnlineQuestionBankDetailsID > 0) ? OnlineEntranceExamQuestionBankMasterDTO.OnlineQuestionBankDetailsID : new int();
            }
            set
            {
                OnlineEntranceExamQuestionBankMasterDTO.OnlineQuestionBankDetailsID = value;
            }
        }

        [Display(Name = "Question Label")]
        public string QuestionLableText
        {
            get
            {
                return (OnlineEntranceExamQuestionBankMasterDTO.QuestionLableText != null && OnlineEntranceExamQuestionBankMasterDTO.QuestionLableText != "") ? OnlineEntranceExamQuestionBankMasterDTO.QuestionLableText : string.Empty;
            }
            set
            {
                OnlineEntranceExamQuestionBankMasterDTO.QuestionLableText = value;
            }
        }
        public string ImageType
        {
            get
            {
                return (OnlineEntranceExamQuestionBankMasterDTO.ImageType != null && OnlineEntranceExamQuestionBankMasterDTO.ImageType != "") ? OnlineEntranceExamQuestionBankMasterDTO.ImageType : string.Empty;
            }
            set
            {
                OnlineEntranceExamQuestionBankMasterDTO.ImageType = value;
            }
        }

        [Display(Name = "Image Name")]
        public string ImageName
        {
            get
            {
                return (OnlineEntranceExamQuestionBankMasterDTO.ImageName != null && OnlineEntranceExamQuestionBankMasterDTO.ImageName != "") ? OnlineEntranceExamQuestionBankMasterDTO.ImageName : string.Empty;
            }
            set
            {
                OnlineEntranceExamQuestionBankMasterDTO.ImageName = value;
            }
        }
        [Display(Name = "Is Question In Image")]
        public bool IsQuestionInImage
        {
            get
            {
                return (OnlineEntranceExamQuestionBankMasterDTO.IsQuestionInImage != false) ? OnlineEntranceExamQuestionBankMasterDTO.IsQuestionInImage : new bool();
            }
            set
            {
                OnlineEntranceExamQuestionBankMasterDTO.IsQuestionInImage = value;
            }
        }
        public int LastAppearedInExamID
        {
            get
            {
                return (OnlineEntranceExamQuestionBankMasterDTO.LastAppearedInExamID > 0) ? OnlineEntranceExamQuestionBankMasterDTO.LastAppearedInExamID : new int();
            }
            set
            {
                OnlineEntranceExamQuestionBankMasterDTO.LastAppearedInExamID = value;
            }
        }
        public string AppearDate
        {
            get
            {
                return (OnlineEntranceExamQuestionBankMasterDTO.AppearDate != null && OnlineEntranceExamQuestionBankMasterDTO.AppearDate != "") ? OnlineEntranceExamQuestionBankMasterDTO.AppearDate : string.Empty;
            }
            set
            {
                OnlineEntranceExamQuestionBankMasterDTO.AppearDate = value;
            }
        }
        public int GeneralQuestionLevelMasterID
        {
            get
            {
                return (OnlineEntranceExamQuestionBankMasterDTO.GeneralQuestionLevelMasterID > 0) ? OnlineEntranceExamQuestionBankMasterDTO.GeneralQuestionLevelMasterID : new int();
            }
            set
            {
                OnlineEntranceExamQuestionBankMasterDTO.GeneralQuestionLevelMasterID = value;
            }
        }
        public int SyllabusGroupID
        {
            get
            {
                return (OnlineEntranceExamQuestionBankMasterDTO.SyllabusGroupID > 0) ? OnlineEntranceExamQuestionBankMasterDTO.SyllabusGroupID : new int();
            }
            set
            {
                OnlineEntranceExamQuestionBankMasterDTO.SyllabusGroupID = value;
            }
        }

        [Display(Name="Topic")]
        public int SyllabusTopicGroupID
        {
            get
            {
                return (OnlineEntranceExamQuestionBankMasterDTO.SyllabusTopicGroupID > 0) ? OnlineEntranceExamQuestionBankMasterDTO.SyllabusTopicGroupID : new int();
            }
            set
            {
                OnlineEntranceExamQuestionBankMasterDTO.SyllabusTopicGroupID = value;
            }
        }
        public int SyllabusGroupDetID
        {
            get
            {
                return (OnlineEntranceExamQuestionBankMasterDTO.SyllabusGroupDetID > 0) ? OnlineEntranceExamQuestionBankMasterDTO.SyllabusGroupDetID : new int();
            }
            set
            {
                OnlineEntranceExamQuestionBankMasterDTO.SyllabusGroupDetID = value;
            }
        }
        public int GenQuestionTypeID
        {
            get
            {
                return (OnlineEntranceExamQuestionBankMasterDTO.GenQuestionTypeID > 0) ? OnlineEntranceExamQuestionBankMasterDTO.GenQuestionTypeID : new int();
            }
            set
            {
                OnlineEntranceExamQuestionBankMasterDTO.GenQuestionTypeID = value;
            }
        }

        [Display(Name="Unit")]
        public string SyllabusGroupDetail
        {
            get
            {
                return (OnlineEntranceExamQuestionBankMasterDTO.SyllabusGroupDetail != null && OnlineEntranceExamQuestionBankMasterDTO.SyllabusGroupDetail != "") ? OnlineEntranceExamQuestionBankMasterDTO.SyllabusGroupDetail : string.Empty;
            }
            set
            {
                OnlineEntranceExamQuestionBankMasterDTO.SyllabusGroupDetail = value;
            }
        }

        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~OnlineExamQuestionBankAnsDetails ~~~~~~~~~~~~~~~~~~~
        public int OnlineExamQuestionBankAnsDetailsID
        {
            get
            {
                return (OnlineEntranceExamQuestionBankMasterDTO.OnlineExamQuestionBankAnsDetailsID > 0) ? OnlineEntranceExamQuestionBankMasterDTO.OnlineExamQuestionBankAnsDetailsID : new int();
            }
            set
            {
                OnlineEntranceExamQuestionBankMasterDTO.OnlineExamQuestionBankAnsDetailsID = value;
            }
        }
        [Display(Name="Option")]
        public string OptionText
        {
            get
            {
                return (OnlineEntranceExamQuestionBankMasterDTO.OptionText != null && OnlineEntranceExamQuestionBankMasterDTO.OptionText != "") ? OnlineEntranceExamQuestionBankMasterDTO.OptionText : string.Empty;
            }
            set
            {
                OnlineEntranceExamQuestionBankMasterDTO.OptionText = value;
            }
        }
        public string OptionImage
        {
            get
            {
                return (OnlineEntranceExamQuestionBankMasterDTO.OptionImage != null && OnlineEntranceExamQuestionBankMasterDTO.OptionImage != "") ? OnlineEntranceExamQuestionBankMasterDTO.OptionImage : string.Empty;
            }
            set
            {
                OnlineEntranceExamQuestionBankMasterDTO.OptionImage = value;
            }
        }
        public bool IsAnswer
        {
            get
            {
                return (OnlineEntranceExamQuestionBankMasterDTO.IsAnswer != false) ? OnlineEntranceExamQuestionBankMasterDTO.IsAnswer : new bool();
            }
            set
            {
                OnlineEntranceExamQuestionBankMasterDTO.IsAnswer = value;
            }
        }

        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~Comman Feilds~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        [Display(Name = "CreatedBy")]
        public int CreatedBy
        {
            get
            {
                return (OnlineEntranceExamQuestionBankMasterDTO.CreatedBy > 0) ? OnlineEntranceExamQuestionBankMasterDTO.CreatedBy : new int();
            }
            set
            {
                OnlineEntranceExamQuestionBankMasterDTO.CreatedBy = value;
            }
        }

        [Display(Name = "CreatedDate")]
        public DateTime CreatedDate
        {
            get
            {
                return (OnlineEntranceExamQuestionBankMasterDTO != null) ? OnlineEntranceExamQuestionBankMasterDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                OnlineEntranceExamQuestionBankMasterDTO.CreatedDate = value;
            }
        }

        [Display(Name = "ModifiedBy")]
        public int ModifiedBy
        {
            get
            {
                return (OnlineEntranceExamQuestionBankMasterDTO != null && OnlineEntranceExamQuestionBankMasterDTO.ModifiedBy > 0) ? OnlineEntranceExamQuestionBankMasterDTO.ModifiedBy : new int();
            }
            set
            {
                OnlineEntranceExamQuestionBankMasterDTO.ModifiedBy = value;
            }
        }

        [Display(Name = "ModifiedDate")]
        public DateTime ModifiedDate
        {
            get
            {
                return (OnlineEntranceExamQuestionBankMasterDTO != null) ? OnlineEntranceExamQuestionBankMasterDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                OnlineEntranceExamQuestionBankMasterDTO.ModifiedDate = value;
            }
        }

        [Display(Name = "DeletedBy")]
        public int DeletedBy
        {
            get
            {
                return (OnlineEntranceExamQuestionBankMasterDTO != null) ? OnlineEntranceExamQuestionBankMasterDTO.DeletedBy : new int();
            }
            set
            {
                OnlineEntranceExamQuestionBankMasterDTO.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime DeletedDate
        {
            get
            {
                return (OnlineEntranceExamQuestionBankMasterDTO != null) ? OnlineEntranceExamQuestionBankMasterDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                OnlineEntranceExamQuestionBankMasterDTO.DeletedDate = value;
            }
        }
        public bool IsDeleted
        {
            get
            {
                return (OnlineEntranceExamQuestionBankMasterDTO.IsDeleted != false) ? OnlineEntranceExamQuestionBankMasterDTO.IsDeleted : new bool();
            }
            set
            {
                OnlineEntranceExamQuestionBankMasterDTO.IsDeleted = value;
            }
        }
        public string errorMessage
        {
            get
            {
                return (OnlineEntranceExamQuestionBankMasterDTO.OptionImage != null && OnlineEntranceExamQuestionBankMasterDTO.OptionImage != "") ? OnlineEntranceExamQuestionBankMasterDTO.OptionImage : string.Empty;
            }
            set
            {
                OnlineEntranceExamQuestionBankMasterDTO.OptionImage = value;
            }
        }


        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~Extra Feilds~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        [Display(Name = "Centre Code ")]
        public string SelectedCentreCode
        {
            get
            {
                return (OnlineEntranceExamQuestionBankMasterDTO.SelectedCentreCode != null && OnlineEntranceExamQuestionBankMasterDTO.SelectedCentreCode != "") ? OnlineEntranceExamQuestionBankMasterDTO.SelectedCentreCode : string.Empty;
            }
            set
            {
                OnlineEntranceExamQuestionBankMasterDTO.SelectedCentreCode = value;
            }
        }

        [Display(Name = "University ")]
        public string SelectedUniversityID
        {
            get
            {
                return (OnlineEntranceExamQuestionBankMasterDTO.SelectedUniversityID != null && OnlineEntranceExamQuestionBankMasterDTO.SelectedUniversityID != "") ? OnlineEntranceExamQuestionBankMasterDTO.SelectedUniversityID : string.Empty;
            }
            set
            {
                OnlineEntranceExamQuestionBankMasterDTO.SelectedUniversityID = value;
            }
        }

        [Display(Name = "Course ")]
        public string SelectedCourseID
        {
            get
            {
                return (OnlineEntranceExamQuestionBankMasterDTO.SelectedCourseID != null && OnlineEntranceExamQuestionBankMasterDTO.SelectedCourseID != "") ? OnlineEntranceExamQuestionBankMasterDTO.SelectedCourseID : string.Empty;
            }
            set
            {
                OnlineEntranceExamQuestionBankMasterDTO.SelectedCourseID = value;
            }
        }

        [Display(Name = "Course")]
        public string SelectedCourseYearID
        {
            get
            {
                return (OnlineEntranceExamQuestionBankMasterDTO.SelectedCourseYearID != null && OnlineEntranceExamQuestionBankMasterDTO.SelectedCourseYearID != "") ? OnlineEntranceExamQuestionBankMasterDTO.SelectedCourseYearID : string.Empty;
            }
            set
            {
                OnlineEntranceExamQuestionBankMasterDTO.SelectedCourseYearID = value;
            }
        }


        public string CourseYearDetailsDescription
        {
            get
            {
                return (OnlineEntranceExamQuestionBankMasterDTO.CourseYearDetailsDescription != null && OnlineEntranceExamQuestionBankMasterDTO.CourseYearDetailsDescription != "") ? OnlineEntranceExamQuestionBankMasterDTO.CourseYearDetailsDescription : string.Empty;
            }
            set
            {
                OnlineEntranceExamQuestionBankMasterDTO.CourseYearDetailsDescription = value;
            }
        }
        public string CourseYearCode
        {
            get
            {
                return (OnlineEntranceExamQuestionBankMasterDTO.CourseYearCode != null && OnlineEntranceExamQuestionBankMasterDTO.CourseYearCode != "") ? OnlineEntranceExamQuestionBankMasterDTO.CourseYearCode : string.Empty;
            }
            set
            {
                OnlineEntranceExamQuestionBankMasterDTO.CourseYearCode = value;
            }
        }

        [Display(Name = "Course Year")]
        public string CourseYearID
        {
            get
            {
                return (OnlineEntranceExamQuestionBankMasterDTO.CourseYearID != null && OnlineEntranceExamQuestionBankMasterDTO.CourseYearID != "") ? OnlineEntranceExamQuestionBankMasterDTO.CourseYearID : string.Empty;
            }
            set
            {
                OnlineEntranceExamQuestionBankMasterDTO.CourseYearID = value;
            }
        }

        //To Create Subject
        [Display(Name = "Centre Code ")]
        public string CentreCode
        {
            get
            {
                return (OnlineEntranceExamQuestionBankMasterDTO.CentreCode != null && OnlineEntranceExamQuestionBankMasterDTO.CentreCode != "") ? OnlineEntranceExamQuestionBankMasterDTO.CentreCode : string.Empty;
            }
            set
            {
                OnlineEntranceExamQuestionBankMasterDTO.CentreCode = value;
            }
        }

        [Display(Name = "University ")]
        public string University
        {
            get
            {
                return (OnlineEntranceExamQuestionBankMasterDTO.University != null && OnlineEntranceExamQuestionBankMasterDTO.University != "") ? OnlineEntranceExamQuestionBankMasterDTO.University : string.Empty;
            }
            set
            {
                OnlineEntranceExamQuestionBankMasterDTO.University = value;
            }
        }

        [Display(Name = "Department ")]
        public int Department
        {
            get
            {
                return (OnlineEntranceExamQuestionBankMasterDTO.Department > 0) ? OnlineEntranceExamQuestionBankMasterDTO.Department : new int();
            }
            set
            {
                OnlineEntranceExamQuestionBankMasterDTO.Department = value;
            }
        }

        [Display(Name = "Course ")]
        public string Course
        {
            get
            {
                return (OnlineEntranceExamQuestionBankMasterDTO.Course != null && OnlineEntranceExamQuestionBankMasterDTO.Course != "") ? OnlineEntranceExamQuestionBankMasterDTO.Course : string.Empty;
            }
            set
            {
                OnlineEntranceExamQuestionBankMasterDTO.Course = value;
            }
        }

        //public int SubjectgroupID
        //{
        //    get
        //    {
        //        return (OnlineEntranceExamQuestionBankMasterDTO.SubjectgroupID > 0) ? OnlineEntranceExamQuestionBankMasterDTO.SubjectgroupID : new int();
        //    }
        //    set
        //    {
        //        OnlineEntranceExamQuestionBankMasterDTO.SubjectgroupID = value;
        //    }
        //}

        [Display(Name = "Subject")]
        public string Subject
        {
            get
            {
                return (OnlineEntranceExamQuestionBankMasterDTO.Subject != null && OnlineEntranceExamQuestionBankMasterDTO.Subject != "") ? OnlineEntranceExamQuestionBankMasterDTO.Subject : string.Empty;
            }
            set
            {
                OnlineEntranceExamQuestionBankMasterDTO.Subject = value;
            }
        }

        public string SubjectGroupDesc
        {
            get
            {
                return (OnlineEntranceExamQuestionBankMasterDTO.SubjectGroupDesc != null && OnlineEntranceExamQuestionBankMasterDTO.SubjectGroupDesc != "") ? OnlineEntranceExamQuestionBankMasterDTO.SubjectGroupDesc : string.Empty;
            }
            set
            {
                OnlineEntranceExamQuestionBankMasterDTO.SubjectGroupDesc = value;
            }
        }

        public string LevelCode
        {
            get
            {
                return (OnlineEntranceExamQuestionBankMasterDTO.LevelCode != null && OnlineEntranceExamQuestionBankMasterDTO.LevelCode != "") ? OnlineEntranceExamQuestionBankMasterDTO.LevelCode : string.Empty;
            }
            set
            {
                OnlineEntranceExamQuestionBankMasterDTO.LevelCode = value;
            }
        }

        public string LevelDescription
        {
            get
            {
                return (OnlineEntranceExamQuestionBankMasterDTO.LevelDescription != null && OnlineEntranceExamQuestionBankMasterDTO.LevelDescription != "") ? OnlineEntranceExamQuestionBankMasterDTO.LevelDescription : string.Empty;
            }
            set
            {
                OnlineEntranceExamQuestionBankMasterDTO.LevelDescription = value;
            }
        }

        [Display(Name = "Question Level")]
        public int GeneralQuestionLevelID
        {
            get
            {
                return (OnlineEntranceExamQuestionBankMasterDTO.GeneralQuestionLevelID > 0) ? OnlineEntranceExamQuestionBankMasterDTO.GeneralQuestionLevelID : new int();
            }
            set
            {
                OnlineEntranceExamQuestionBankMasterDTO.GeneralQuestionLevelID = value;
            }
        }

        [Display(Name = "Question Type")]
        public int GeneralQuestionTypeID
        {
            get
            {
                return (OnlineEntranceExamQuestionBankMasterDTO.GeneralQuestionTypeID > 0) ? OnlineEntranceExamQuestionBankMasterDTO.GeneralQuestionTypeID : new int();
            }
            set
            {
                OnlineEntranceExamQuestionBankMasterDTO.GeneralQuestionTypeID = value;
            }
        }

        [Display(Name = "Is Option In Image")]
        public bool IsOptionInImage
        {
            get
            {
                return (OnlineEntranceExamQuestionBankMasterDTO != null) ? OnlineEntranceExamQuestionBankMasterDTO.IsQuestionInImage : false;
            }
            set
            {
                OnlineEntranceExamQuestionBankMasterDTO.IsQuestionInImage = value;
            }
        }

        public string SelectedXml
        {
            get
            {
                return (OnlineEntranceExamQuestionBankMasterDTO.SelectedXml != null && OnlineEntranceExamQuestionBankMasterDTO.SelectedXml != "") ? OnlineEntranceExamQuestionBankMasterDTO.SelectedXml : string.Empty;
            }
            set
            {
                OnlineEntranceExamQuestionBankMasterDTO.SelectedXml = value;
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
