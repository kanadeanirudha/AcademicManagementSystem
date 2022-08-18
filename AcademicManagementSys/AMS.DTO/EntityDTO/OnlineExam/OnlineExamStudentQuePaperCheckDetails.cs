using System;
using System.Collections.Generic;
using AMS.Base.DTO;
namespace AMS.DTO
{
    public class OnlineExamStudentQuePaperCheckDetails : BaseDTO
    {
        public byte ID
        {
            get;
            set;
        }
        public int OnlineExamQuestionPaperCheckerID
        {
            get;
            set;
        }
        public int OnlineExamSubjectGroupScheduleID
        {
            get;
            set;
        }
        public int OnlineExamExaminationCourseApplicableID
        {
            get;
            set;
        }
        public int MarksForQuestion
        {
            get;
            set;
        }
        public decimal MarkObtained
        {
            get;
            set;
        }
        public string ExaminationName
        {
            get;
            set;
        }
        public int SubjectGroupID
        {
            get;
            set;
        }
        public int SubjectID
        {
            get;
            set;
        }
        public string SubjectDescription
        {
            get;
            set;
        }
        public int OnlineExamQuestionBankMasterID
        {
            get;
            set;
        }
      
        public int OnlineExamQuestionBankDetailsID
        {
            get;
            set;
        }
        public int OnlineExamIndQuestionPaperID
        {
            get;
            set;
        }
        public string QuestionLableText
        {
            get;
            set;
        }
        public string DescriptiveAnswer
        {
            get;
            set;
        }
        public int IsAttachmentCompalsary
        {
            get;
            set;
        }
        public string AttachedDocument
        {
            get;
            set;
        }
        public string ImageType
        {
            get;
            set;
        }
        public string OptionImage
        {
            get;
            set;
        }
        public string OptionText
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
        public string OptionIDsList
        {
            get;
            set;
        }
        public int OnlineExamStudentQuePaperCheckDetailsID
        {
            get;
            set;
        }
        public int OnlineExamStudentApplicableID
        {
            get;
            set;
        }
        public bool IsChecked
        {
            get;
            set;
        }
        public bool IsAllChecked
        {
            get;
            set;
        }
        public string StudentName
        {
            get;
            set;
        }
        public string FirstName
        {
            get;
            set;
        }
        public string MiddleName
        {
            get;
            set;
        }
        public string LastName
        {
            get;
            set;
        }
        public int OnlineExamIndStudentExamInfoID
        {
            get;
            set;
        }
        public int StudentID
        {
            get;
            set;
        }
        public bool IsExaminationOver
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
        public string errorMessage { get; set; }
    }
}
