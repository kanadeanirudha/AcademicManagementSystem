using AMS.Base.DTO;
using System;
namespace AMS.DTO
{
    public class EntranceExam : BaseDTO
    {
        //----------------------------------Properties of EntranceExamIndStudentExamInfo  table--------------------------------
        public int ID
        {
            get;
            set;
        }
        public int StudentRegistrationID
        {
            get;
            set;
        }
        public int EntranceExamApplicableExamToCourseID
        {
            get;
            set;
        }
        public string CourseYearCode
        {
            get;
            set;
        }
        public Int16 AttendanceFlag
        {
            get;
            set;
        }
        public string AttendLogInTime
        {
            get;
            set;
        }
        public string ExaminationDate
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
        public Boolean IsExaminationOver
        {
            get;
            set;
        }
        public string SessionName
        {
            get;
            set;
        }
        public Boolean LoginStatus
        {
            get;
            set;
        }
        public Boolean IsLock
        {
            get;
            set;
        }
        public int OnlineExaminationPaperID
        {
            get;
            set;
        }
        public string IPAddress
        {
            get;
            set;
        }
        public bool IsActive
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
        public int? ModifiedBy
        {
            get;
            set;
        }
        public DateTime? ModifiedDate
        {
            get;
            set;
        }
        public int? DeletedBy
        {
            get;
            set;
        }
        public DateTime? DeletedDate
        {
            get;
            set;
        }

        //----------------------------------Properties of EntranceExamIndQuestionPaper  table--------------------------------   
        public int EntranceExamIndQuestionPaperID
        {
            get;
            set;
        }
        public int OnlineExaminationMasterID
        {
            get;
            set;
        }
        public int SubjectID
        {
            get;
            set;
        }
        public Int16 GenQuestionTypeID
        {
            get;
            set;
        }
        public int OnlineExamQuestionBankMasterID
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
        public Boolean IsQuestionInImage
        {
            get;
            set;
        }
        public int AnswerOptionID
        {
            get;
            set;
        }
        public int CorrectOptionID
        {
            get;
            set;
        }
        public Boolean IsAnswerCorrect
        {
            get;
            set;
        }
        public decimal MarkObtained
        {
            get;
            set;
        }
        public Int16 CurrentStatus
        {
            get;
            set;
        }

        //----------------------------------Properties of EntranceExamIndQuestionPaperDetails  table--------------------------------        
        public int EntranceExamIndQuestionPaperDetailsID
        {
            get;
            set;
        }
        public int OnlineExamQuestionBankDetailsID
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
        public Boolean IsAnswer
        {
            get;
            set;
        }
        public string errorMessage { get; set; }
    }
}
