using AMS.Base.DTO;
using System;
namespace AMS.DTO
{
    public class FeeCriteriaParametersAndValues : BaseDTO
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
        public string FeeCriteriaParameterOrValue
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
      
        public bool IsDeleted
        {
            get;
            set;
        }
        public int CreatedBy
        {
            get;
            set;
        }
        public int AccBalanceSheetID
        {
            get;
            set;
        }
        public DateTime CreatedDate
        {
            get;
            set;
        }
        public int? ModifiedBy
        {
            get;
            set;
        }
        public DateTime? ModifiedDate
        {
            get;
            set;
        }
        public int? DeletedBy
        {
            get;
            set;
        }
        public DateTime? DeletedDate
        {
            get;
            set;
        }
        public string errorMessage { get; set; }
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
        public bool StatusFlag
        {
            get;
            set;
        }
      
    }
}
