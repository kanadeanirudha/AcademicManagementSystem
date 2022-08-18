using AMS.Base.DTO;

namespace AMS.DTO
{
    public class InventoryCounterLogAndLockDetailsSearchRequest : Request
    {
        public int CounterLogID
        {
            get;
            set;
        }
        public int CounterLockID
        {
            get;
            set;
        }
        public int UserID
        {
            get;
            set;
        }
        public int CounterMasterID
        {
            get;
            set;
        }
        public int AccBalsheetMstID
        {
            get;
            set;
        }
        public string TokenCode
        {
            get;
            set;
        }
        public bool IsDeleted
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
    }
}
