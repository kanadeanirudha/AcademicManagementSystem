using AMS.Base.DTO;
using System;
namespace AMS.DTO
{
    public class FeeCriteriaParametersAndValuesSearchRequest : Request
    {
        //FeeCriteriaParameters
        public int FeeCriteriaParametersID
        {
            get;
            set;
        }
        public string FeeCriteriaParametersDescription
        {
            get;
            set;
        }
        public string FeeCriteriaParametersCode
        {
            get;
            set;
        }
        public bool IsActive
        {
            get;
            set;
        }
        public string CentreCode
        {
            get;
            set;
        }
        public string RelatedWith
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
        public int AccBalanceSheetID
        {
            get;
            set;
        }
        //FeeCriteriaParametersValues

        public int FeeCriteriaParametersValuesID
        {
            get;
            set;
        }
        public string FeeCriteriaParameterValue
        {
            get;
            set;
        }
       
    }
}
