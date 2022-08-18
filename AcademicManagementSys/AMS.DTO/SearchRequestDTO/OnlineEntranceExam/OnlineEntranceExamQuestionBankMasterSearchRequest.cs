using AMS.Base.DTO;
using System;
namespace AMS.DTO
{
    public class OnlineEntranceExamQuestionBankMasterSearchRequest : Request
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

        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~OnlineExamQuestionBankAnsDetails ~~~~~~~~~~~~~~~~~~~
        public int OnlineExamQuestionBankAnsDetailsID { get; set; }
        public string OptionText { get; set; }
        public string OptionImage { get; set; }
        public bool IsAnswer { get; set; }

        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~Comman Property ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        public bool IsDeleted { get; set; }
        public string SortOrder { get; set; }
        public string SortBy { get; set; }
        public int StartRow { get; set; }
        public int EndRow { get; set; }
        public int RowLength { get; set; }
        public string SearchBy { get; set; }
        public string SortDirection { get; set; }

        public string SearchWord { get; set; }

        //~~~~~~~~~~~~~~~~~~~~~~~~Extra Feilds~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        public string SelectedCentreCode { get; set; }
        public string SelectedUniversityID { get; set; }
        public string SelectedCourseID { get; set; }

        public int CourseYearID { get; set; }
    }
}
