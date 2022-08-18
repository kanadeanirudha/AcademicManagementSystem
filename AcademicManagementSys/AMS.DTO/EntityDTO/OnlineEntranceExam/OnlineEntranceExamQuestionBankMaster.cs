using AMS.Base.DTO;
using System;
namespace AMS.DTO
{
    public class OnlineEntranceExamQuestionBankMaster : BaseDTO
    {
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~OnlineExamQuestionBankMaster ~~~~~~~~~~~~~~~~~~~~~~~~~~
        public int OnlineExamQuestionBankMasterID { get; set; }
        public int SubjectID { get; set; }       
        public int SubjectGroupID { get; set; }
        public int CourseYearDetailID { get; set; }
        public int DepartmentID { get; set; }
        public int OldOnlineExamQuestionBankMasterID { get; set; }
        public Int16 IsAcademic { get; set; }
       
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ OnlineQuestionBankDetails ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        public int OnlineQuestionBankDetailsID { get; set; }
        public string QuestionLableText { get; set; }
        public string ImageType { get; set; }
        public string ImageName { get; set; }
        public bool IsQuestionInImage { get; set; }
        public int LastAppearedInExamID { get; set; }
        public string AppearDate { get; set; }
        public int GeneralQuestionLevelMasterID { get; set; }
        public int SyllabusGroupID { get; set; }
        public int SyllabusTopicGroupID { get; set; }
        public int SyllabusGroupDetID { get; set; }
        public int GenQuestionTypeID { get; set; }

        public string SyllabusGroupDetail { get; set; }
        public string TopicName { get; set; }

        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~OnlineExamQuestionBankAnsDetails ~~~~~~~~~~~~~~~~~~~
        public int OnlineExamQuestionBankAnsDetailsID { get; set; }
        public string OptionText { get; set; }
        public string OptionImage { get; set; }
        public bool IsAnswer { get; set; }

        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~Comman Feilds~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public int DeletedBy { get; set; }
        public DateTime DeletedDate { get; set; }
        public bool IsDeleted { get; set; }
        public string errorMessage { get; set; }

        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~Extra Feilds~~~~~~~~~~~~~~~~~~~~~~~~~
        public string SelectedCentreCode { get; set; }
        public string SelectedUniversityID { get; set; }
        public string SelectedCourseID { get; set; }
        public string SelectedCourseYearID { get; set; }
        public int OrgBranchDetailsID { get; set; }
        public int OrgBranchMasterID { get; set; }
        public string BranchDescription { get; set; }
        public string BranchShortCode { get; set; }
        
        public string CourseYearDetailsDescription { get; set; }
        public string CourseYearCode { get; set; }
        public string SubjectName { get; set; }
        public string CourseYearID { get; set; }

        public string CentreCode { get; set; }
        public string University { get; set; }
        public int Department { get; set; }
        public string Course { get; set; }

        
        public string Subject { get; set; }
        public string SubjectGroupDesc { get; set; }

        public int GeneralQuestionLevelID { get; set; }
        public string LevelCode { get; set; }
        public string LevelDescription { get; set; }
        public int GeneralQuestionTypeID { get; set; }
        public string SelectedXml { get; set; } 
        public bool IsOptionInImage {get;set;}
       
    }
}
