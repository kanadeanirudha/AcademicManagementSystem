using System;
using AMS.Base.DTO;
using System;
namespace AMS.DTO
{
    public class StudentReportCardSearchRequest : BaseDTO
    {

        public int OnlineExamExaminationCourseApplicableID
        {
            get;
            set;
        }
        public int StudentID
        {
            get;
            set;
        }
    }
}





