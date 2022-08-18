using AMS.Base.DTO;
using System;
namespace AMS.DTO
{
    public class CRMReportSearchRequest : Request
    {
        public int EmployeeID
        {
            get;
            set;
        }
        public int AdminRoleID
        {
            get;
            set;
        }
        public DateTime FromDate { get; set; }
        public DateTime UptoDate { get; set; }

        public DateTime TodaysDate { get; set; }
        
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
    }
}
