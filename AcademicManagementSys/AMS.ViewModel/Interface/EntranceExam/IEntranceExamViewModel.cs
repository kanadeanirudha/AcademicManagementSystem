using AMS.DTO;
using System;
namespace AMS.ViewModel
{
    public interface IEntranceExamViewModel
    {
        EntranceExam EntranceExamDTO { get; set; }
        //----------------------------------Properties of EntranceExamIndStudentExamInfo  table--------------------------------
        int ID
        {
            get;
            set;
        }
        int StudentRegistrationID
        {
            get;
            set;
        }
        int EntranceExamApplicableExamToCourseID
        {
            get;
            set;
        }
        string CourseYearCode
        {
            get;
            set;
        }
        Int16 AttendanceFlag
        {
            get;
            set;
        }
        string AttendLogInTime
        {
            get;
            set;
        }
        string ExaminationDate
        {
            get;
            set;
        }
        string ExaminationStartTime
        {
            get;
            set;
        }
        string ExaminationEndTime
        {
            get;
            set;
        }
        Boolean IsExaminationOver
        {
            get;
            set;
        }
        string SessionName
        {
            get;
            set;
        }
        Boolean LoginStatus
        {
            get;
            set;
        }
        Boolean IsLock
        {
            get;
            set;
        }
        int OnlineExaminationPaperID
        {
            get;
            set;
        }
        string IPAddress
        {
            get;
            set;
        }

        //----------------------------------Properties of EntranceExamIndQuestionPaper  table--------------------------------   
        int EntranceExamIndQuestionPaperID
        {
            get;
            set;
        }
        int OnlineExaminationMasterID
        {
            get;
            set;
        }
        int SubjectID
        {
            get;
            set;
        }
        Int16 GenQuestionTypeID
        {
            get;
            set;
        }
        int OnlineExamQuestionBankMasterID
        {
            get;
            set;
        }
        string QuestionLableText
        {
            get;
            set;
        }
        string ImageType
        {
            get;
            set;
        }
        string ImageName
        {
            get;
            set;
        }
        Boolean IsQuestionInImage
        {
            get;
            set;
        }
        int AnswerOptionID
        {
            get;
            set;
        }
        int CorrectOptionID
        {
            get;
            set;
        }
        Boolean IsAnswerCorrect
        {
            get;
            set;
        }
        decimal MarkObtained
        {
            get;
            set;
        }
        Int16 CurrentStatus
        {
            get;
            set;
        }

        //----------------------------------Properties of EntranceExamIndQuestionPaperDetails  table--------------------------------        
       int EntranceExamIndQuestionPaperDetailsID
        {
            get;
            set;
        }
       int OnlineExamQuestionBankDetailsID
        {
            get;
            set;
        }
       string OptionText
        {
            get;
            set;
        }
       string OptionImage
        {
            get;
            set;
        }
       Boolean IsAnswer
        {
            get;
            set;
        }
    }
}
