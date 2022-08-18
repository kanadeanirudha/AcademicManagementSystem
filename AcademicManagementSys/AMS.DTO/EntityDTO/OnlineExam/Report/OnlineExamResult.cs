using AMS.Base.DTO;
using System;
namespace AMS.DTO
{
    public class OnlineExamResult : BaseDTO
    {
        public Int16 ID
        {
            get;
            set;
        }
        public int OnlineExamIndStudentExamInfoID
        {
            get;
            set;
        }
        public Int16 CorrectAnswer
        {
            get;
            set;
        }
        public Int16 IncorrectAnswer
        {
            get;
            set;
        }
        public Int16 NotAnswered
        {
            get;
            set;
        }
        public String ExamName
        {
            get;
            set;
        }
        public String ExamDate
        {
            get;
            set;
        }
        public String SubjectName
        {
            get;
            set;
        }
        public byte TotalMarks
        {
            get;
            set;
        }

        public byte TotalQuestions
        {
            get;
            set;
        }
        public byte ExamDuration
        {
            get;
            set;
        }

        public decimal CorrectMarks
        {
            get;
            set;
        }
        public decimal NegativeMarks
        {
            get;
            set;
        }
        public decimal TotalMarksObtained
        {
            get;
            set;
        }
     
       


    }
}
