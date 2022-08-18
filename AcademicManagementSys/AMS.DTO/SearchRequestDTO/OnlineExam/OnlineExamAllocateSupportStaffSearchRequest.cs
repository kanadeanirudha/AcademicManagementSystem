using AMS.Base.DTO;

namespace AMS.DTO
{
    public class OnlineExamAllocateSupportStaffSearchRequest : Request
    {
        public int OnlineExamExaminationMasterID
        {
            get;
            set;
        }
        public int EmployeeId { get; set; }
        public int RoleDetailID { get; set; }
        public int SessionId{get;set;}
	    public int ExaminationID {get;set;}
        //******Fields From Job Support Staff
        public string AllotedJobName { get; set; }
        public string AllotedJobCode { get; set; }
       

       
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
