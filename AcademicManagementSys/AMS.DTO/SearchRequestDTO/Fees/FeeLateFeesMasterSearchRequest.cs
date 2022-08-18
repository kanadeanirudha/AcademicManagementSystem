using AMS.Base.DTO;
using System;
namespace AMS.DTO
{
    public class FeeLateFeesMasterSearchRequest : Request
    {
        public int ID
        {
            get;
            set;
        }
        public string LateFeeDescription
        {
            get;
            set;
        }
        public Int16 LateFeeType
        {
            get;
            set;
        }
        public Int16 SlabFixedFlag
        {
            get;
            set;
        }
        public decimal LateFeeAmount
        {
            get;
            set;
        }
        public int PeriodTypeID
        {
            get;
            set;
        }
        public int FeeSubTypeID
        {
            get;
            set;
        }
        public bool IsIncremental
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
        public string SearchWord
        {
            get;
            set;
        }
    }
}
