using AMS.Base.DTO;

namespace AMS.DTO
{
    public class CRMSaleGroupMasterAndAllocateEmployeeInGroupSearchRequest : Request
    {
        public int CRMSaleGroupMasterID
        {
            get;
            set;
        }
        public int EmployeeID
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
    }
}
