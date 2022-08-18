using AMS.Base.DTO;

namespace AMS.DTO
{
    public class CRMCallEnquiryDetailsSearchRequest : Request
    {
        public int ID
        {
            get;
            set;
        }
       
        public bool IsDeleted
        {
            get;
            set;
        }
        public string UploadDate
        {
            get;
            set;
        }
        public int CallTypeID
        {
            get;
            set;
        }
        public int Status
        {
            get;
            set;
        }
        public int CallerJobStatus
        {
            get;
            set;
        }
        public int CallStatus
        {
            get;
            set;
        }
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
        public string StartDate { get; set; }
        public string EndDate { get; set; }
    }
}
