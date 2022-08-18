using AMS.Base.DTO;
using System;
namespace AMS.DTO
{
    public class InventorySalesMasterAndTransactionSearchRequest : Request
    {
        public int ID
        {
            get;
            set;
        }
        public bool IsOnline
        {
            get;
            set;
        }
        public int LocationID
        {
            get;
            set; 
        }
        public int CreatedBy
        {
            get;
            set;
        }
        public bool IsActive
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
        public Int16 AccBalsheetMstID { get;set; }
        public Int16 keyPressNumber { get; set; }
        public int CounterMstID { get; set; }

        public string PolicyDefaultAnswer
        {
            get;
            set;
        }
    }
}
