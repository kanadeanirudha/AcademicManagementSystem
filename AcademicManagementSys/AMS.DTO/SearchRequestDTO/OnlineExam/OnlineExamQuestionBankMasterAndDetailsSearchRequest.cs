using AMS.Base.DTO;
using System;
namespace AMS.DTO
{
    public class OnlineExamQuestionBankMasterAndDetailsSearchRequest : Request
    {
        public int ID
        {
            get;
            set;
        }
        public Int16 GenQuestionTypeID
        {
            get;
            set;
        }
        public int SubjectID
        {
            get;
            set;
        }
        public int GeneralQuestionLevelMasterID
        {
            get;
            set;
        }
        public string QuestionLableText
        {
            get;
            set;
        }
        public string ImageType
        {
            get;
            set;
        }
        public string ImageName
        {
            get;
            set;
        }
        public bool IsQuestionInImage
        {
            get;
            set;
        }
        public int LastAppearedInExamID
        {
            get;
            set;
        }
        public string AppearDate
        {
            get;
            set;
        }
        public string CentreCode
        {
            get;
            set;
        }
        public int CourseYearDetailID
        {
            get;
            set;
        }
        public int OrgSemesterMstID
        {
            get;
            set;
        }
        public string SortOrder
        {
            get;
            set;
        }
        public string SortBy
        {
            get;
            set;
        }
        public int StartRow
        {
            get;
            set;
        }
        public int RowLength
        {
            get;
            set;
        }
        public int EndRow
        {
            get;
            set;
        }
        public string SearchBy { get; set; }
        public string SortDirection { get; set; }
        public int OnlineExamQuestionBankDetailsID
        {
            get;
            set;
        }
        public int OnlineExamQuestionBankMasterID
        {
            get;
            set;
        }
        public int OnlineExamExaminationQuestionPaperID
        {
            get;
            set;
        }
        public int OnlineExamSubjectGroupScheduleID
        {
            get;
            set;
        }
        public string OptionText
        {
            get;
            set;
        }
        public string OptionImage
        {
            get;
            set;
        }
        public bool IsAnswer
        {
            get;
            set;
        }

    }
}
