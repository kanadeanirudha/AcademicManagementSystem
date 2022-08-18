using AMS.Base.DTO;
using System;
namespace AMS.DTO
{
    public class OnlineExamQuestionBankMasterAndDetails : BaseDTO
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
        public string GenQuestionType
        {
            get;
            set;
        }

        public string CourseType
        {
            get;
            set;
        }

        public string SubjectGroupType
        {
            get;
            set;
        }
        public string Center
        {
            get;
            set;
        }

        public int SubjectID
        {
            get;
            set;
        }
        public string SubjectName
        {
            get;
            set;
        }
        public int SubjectGroupID
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
        public string OptionImageList
        {
            get;
            set;
        }
        public string OptionTextList
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
        public bool IsActive
        {
            get;
            set;
        }
        public int CourseYearDetailID
        {
            get;
            set;
        }
        public string CourseYearDescription
        {
            get;
            set;
        }
        public int OrgSemesterMstID
        {
            get;
            set;
        }
        public Int16 IsAttachmentCompalsary
        {
            get;
            set;
        }
        public bool IsQuestionDescriptive
        {
            get;
            set;
        }
        public bool IsDeleted
        {
            get;
            set;
        }
        public int CreatedBy
        {
            get;
            set;
        }
        public DateTime CreatedDate
        {
            get;
            set;
        }
        public int ModifiedBy
        {
            get;
            set;
        }
        public DateTime ModifiedDate
        {
            get;
            set;
        }
        public int DeletedBy
        {
            get;
            set;
        }
        public DateTime DeletedDate
        {
            get;
            set;
        }

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
        public int GeneralQuestionLevelMasterID
        {
            get;
            set;
        }
        public string QuestionBankMasterDescription
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
        public string SelectedXml
        {
            get;
            set;
        }
        public string errorMessage
        {
            get;
            set;
        }
    }
}
