using AMS.Base.DTO;
using System;
namespace AMS.DTO
{
    public class FeeCriteriaCombinationParameterValue : BaseDTO
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

        public string FeeCriteriaParameterValueCombinationIDs
        {
            get;
            set;
        }
        public string FeeCriteriaParameterValueCombinationIDsXml
        {
            get;
            set;
        }
        public bool ValueCombinationStatus
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
        //FeeCriteriaValueCombinationDetails

        public int FeeCriteriaParameterValuesID
        {
            get;
            set;
        }
    

    }
}
