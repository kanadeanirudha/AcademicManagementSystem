
using AMS.Base.DTO;

namespace AMS.DTO
{
    public class InventoryRateMarkDownMasterAndDetailsSearchRequest : Request
    {
        public int AccBalsheetMstID
        {
            get;
            set;


        }
        public string TransactionDate
        {
            get;
            set;
        }
        public string CentreCode { get; set; }

        public string CategoryDescription 
        { 
            get; 
            set;
        }
        public string CategoryCode { get; set; }
        public int RateMarkDownDetailID
        {
            get;
            set;
        }

        public int RateMarkDownMasterID
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
