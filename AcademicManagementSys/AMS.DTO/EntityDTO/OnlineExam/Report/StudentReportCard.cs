using AMS.Base.DTO;
using System;
namespace AMS.DTO
{
    public class StudentReportCard : BaseDTO
    {
        public Int16 ID
        {
            get;
            set;
        }
        public string ExaminationName
        {
            get;
            set;
        }
        public string SubjectName
        {
            get;
            set;
        }
        public Int16 TotalMarks
        {
            get;
            set;
        }
        public string ExaminationDate
        {
            get;
            set;
        }
        public decimal MarkObtained
        {
            get;
            set;
        }
        public Int16 OverAllTotalMarks
        {
            get;
            set;
        }
        public decimal TotalMarkObtained
        {
            get;
            set;
        }
    }
}
