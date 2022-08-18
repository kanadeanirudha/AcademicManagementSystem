using AMS.DTO;
using System;
using System.Collections.Generic;

namespace AMS.ViewModel
{
    public interface IFeeCriteriaCombinationParameterValueViewModel
    {
        FeeCriteriaCombinationParameterValue FeeCriteriaCombinationParameterValueDTO
        {
            get;
            set;
        }
        int FeeCriteriaValueCombinationMasterID
        {
            get;
            set;
        }
        int FeeCriteriaMasterID
        {
            get;
            set;
        }
        string FeeCriteriaValueCombinationDescription
        {
            get;
            set;
        }

        string FeeCriteriaParameterValueCombinationIDs
        {
            get;
            set;
        }
        bool ValueCombinationStatus
        {
            get;
            set;
        }

        bool IsDeleted
        {
            get;
            set;
        }
        int CreatedBy
        {
            get;
            set;
        }
        DateTime CreatedDate
        {
            get;
            set;
        }
        int? ModifiedBy
        {
            get;
            set;
        }
        DateTime? ModifiedDate
        {
            get;
            set;
        }
        int? DeletedBy
        {
            get;
            set;
        }
        DateTime? DeletedDate
        {
            get;
            set;
        }
        string errorMessage { get; set; }
        //FeeCriteriaValueCombinationDetails

        int FeeCriteriaParameterValuesID
        {
            get;
            set;
        }
    }
}

