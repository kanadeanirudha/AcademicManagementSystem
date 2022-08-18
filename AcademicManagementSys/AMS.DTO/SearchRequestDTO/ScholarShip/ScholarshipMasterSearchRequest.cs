using AMS.Base.DTO;
using System;
namespace AMS.DTO
{
    public class ScholarShipMasterSearchRequest : Request
    {
        public int ID
        {
            get;
            set;
        }
        public string ScholarShipDescription
        {
            get;
            set;
        }
        public Int16 ScholarShipType
        {
            get;
            set;
        }
        public Int16 ScholarShipImplementType
        {
            get;
            set;
        }
        public bool  IsCalulatedAmountFix
        {
            get;
            set;
        }
        public decimal FixAmount
        {
            get;
            set;
        }
        public decimal Percentage
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
        public string SearchWord
        {
            get;
            set;
        }
        public string ScopeIdentity
        {
            get;
            set;
        }
    }
}
