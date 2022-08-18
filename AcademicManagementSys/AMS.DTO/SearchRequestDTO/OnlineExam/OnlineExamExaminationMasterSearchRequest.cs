

using AMS.Base.DTO;

namespace AMS.DTO
{
    public class OnlineExamExaminationMasterSearchRequest : Request
    {
        public int OnlineExamExaminationMasterID
        {
            get;
            set;
        }
        public string ExaminationName { get; set; }
        public string Purpose { get; set; }
        public int AcadSessionId  { get; set; }
        public int EmployeeID { get; set; }
        public int RoleMasterID { get; set; }
        public int SessionMaster { get; set; }
        public string CentreCode { get; set; }
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
