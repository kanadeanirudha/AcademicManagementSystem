using AMS.Base.DTO;
namespace AMS.DTO
{
    public class OnlineExamExaminationCourseApplicableSearchRequest : Request
    {
        public int OnlineExamExaminationCourseApplicableID
        {
            get;
            set;
        }
        public  int CourseYearID { get; set; }
       
        public int DepartmentID { get; set; }

       
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

        public int EndRow
        {
            get;
            set;
        }

        public int RowLength
        {
            get;
            set;
        }
        public string SearchBy
        {
            get;
            set;
        }
        public string SortDirection
        {
            get;
            set;
        }
    }
}
