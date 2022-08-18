using AMS.Base.DTO;

namespace AMS.DTO
{
    public class InventoryOpeningBalanceSearchRequest : Request
    {
        public int BalanceSheetID
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
        public int LocationID
        {
            get;
            set;
        }
        public int AccSessionMasterID
        {
            get;
            set;
        }
        public string LocationName { get; set; }
        public string SelectedCentreCode
        {


            get;
            set;

        }
        public int SessionID
        {
            get;
            set;
        }
    }
}
