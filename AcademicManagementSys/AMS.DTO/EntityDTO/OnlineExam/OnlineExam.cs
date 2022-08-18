using System;
using System.Collections.Generic;

using System;
using System.Collections.Generic;
using AMS.Base.DTO;
using System;
namespace AMS.DTO
{
    public class OnlineExam : BaseDTO
    {
        public byte ID
        {
            get;
            set;
        }
        public string ExaminationName
        {
            get;
            set;
        }
        public Int32 OnlineExamIndStudentExamInfoID
        {
            get;
            set;
        }
        public Int32 OnlineExamExaminationCourseApplicableID
        {
            get;
            set;
        }
        public Int32 ExaminationID
        {
            get;
            set;
        }
        public string ExaminationStartTime
        {
            get;
            set;
        }
        public string ExaminationEndTime
        {
            get;
            set;
        }
        public string ExaminationDate
        {
            get;
            set;
        }
        public string ExaminationEndDate
        {
            get;
            set;
        }
        public bool IsExaminationOver
        {
            get;
            set;
        }
        public string SubjectName
        {
            get;
            set;
        }
        public Int16 TotalQuestions
        {
            get;
            set;
        }
        public Int16 ExamDuration
        {
            get;
            set;
        }
        public string OnlineExamTimeDuration
        {
            get;
            set;
        }
        public Int16 QuestionOrder
        {
            get;
            set;
        }
        public Int32 AnswerOptionID
        {
            get;
            set;
        }
        public bool IsQuestionDescriptive
        {
            get;
            set;
        }
        public Int16 IsAttachmentCompalsary
        {
            get;
            set;
        }
        public string QuestionOrderList
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
        public string OptionIDsList
        {
            get;
            set;
        }
        public string CurrentStatusList
        {
            get;
            set;
        }
        public Int16 CurrentStatus
        {
            get;
            set;
        }
        public bool IsDescriptiveQuestionInExam
        {
            get;
            set;
        }
        public bool IsObjectiveQuestionInExam
        {
            get;
            set;
        }
        public Int16 DescriptiveStartQuestionOrder
        {
            get;
            set;
        }
        public Int16 ObjectiveStartQuestionOrder
        {
            get;
            set;
        }
        public string DescriptiveAnswer
        {
            get;
            set;
        }
        public string AttachedDocument
        {
            get;
            set;
        }
        public bool IsExamStart
        {
            get;
            set;
        }
        public string ResultAnnounceDate
        {
            get;
            set;
        }
        public bool IsResultAnnounce
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
