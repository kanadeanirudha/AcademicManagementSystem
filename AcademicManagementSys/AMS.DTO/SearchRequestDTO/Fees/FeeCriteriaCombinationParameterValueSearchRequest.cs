using AMS.Base.DTO;
using System;
namespace AMS.DTO
{
    public class FeeCriteriaCombinationParameterValueSearchRequest : Request
    {
        //FeeCriteriaValueCombinationMaster
        public int FeeCriteriaValueCombinationMasterID
        {
            get;
            set;
        }
        public int FeeCriteriaMasterID
        {
            get;
            set;
        }
        public string FeeCriteriaValueCombinationDescription
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
        //FeeCriteriaValueCombinationDetails

        public int FeeCriteriaParameterValuesID
        {
            get;
            set;
        }

    }
}
