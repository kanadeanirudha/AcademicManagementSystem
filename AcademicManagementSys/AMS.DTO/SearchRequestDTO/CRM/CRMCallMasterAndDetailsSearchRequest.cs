using AMS.Base.DTO;
using System;
namespace AMS.DTO
{
    public class CRMCallMasterAndDetailsSearchRequest : Request
    {
        public int ID
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

        public int RowLength
        {
            get;
            set;
        }

        public int EndRow
        {
            get;
            set;
        }
        public string SearchBy { get; set; }
        public string SortDirection { get; set; }

        public int JobCreationMasterID
        {
            get;
            set;
        }

        public Int16 CallerJobStatus
        {
            get;
            set;
        }
        public int EmployeeID
        {
            get;
            set;
        }
        public string FromDate
        {
            get;
            set;
        }
        public string UptoDate
        {
            get;
            set;
        }
        public Int16 CallStatus
        {
            get;
            set;
        }
    }
}


