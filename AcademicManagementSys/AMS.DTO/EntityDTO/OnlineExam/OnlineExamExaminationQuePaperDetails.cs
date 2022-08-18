using System;
using System.Collections.Generic;

using System;
using System.Collections.Generic;
using AMS.Base.DTO;
using System;
namespace AMS.DTO
{
    public class OnlineExamExaminationQuePaperDetails : BaseDTO
    {
        public byte ID
        {
            get;
            set;
        }
        public int OnlineExamExaminationQuestionPaperID
        {
            get;
            set;
        }
        public string PaperSet
        {
            get;
            set;
        }
        public int OnlineExamSubjectGroupScheduleID
        {
            get;
            set;
        }
        public int MarksForQuestion
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
        public string QuestionBankMasterDescription
        {
            get;
            set;
        }
        public int OnlineExamQuestionBankDetailsID
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
        public int OnlineExamExaminationQuePaperDetailsID
        {
            get;
            set;
        }
        public int OnlineExamStudentApplicableID
        {
            get;
            set;
        }
        public bool IsFinal
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
