using AMS.DTO;
using System;
using System.Collections.Generic;

namespace AMS.ViewModel
{
    public interface IFeeCriteriaParametersAndValuesViewModel
    {
        FeeCriteriaParametersAndValues FeeCriteriaParametersAndValuesDTO
        {
            get;
            set;
        }
        int FeeCriteriaParametersID
        {
            get;
            set;
        }
        string FeeCriteriaParametersDescription
        {
            get;
            set;
        }
        string FeeCriteriaParametersCode
        {
            get;
            set;
        }
        bool IsActive
        {
            get;
            set;
        }
        string CentreCode
        {
            get;
            set;
        }
        string RelatedWith
        {
            get;
            set;
        }
        int AccBalanceSheetID
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

        //FeeCriteriaParametersValues

        int FeeCriteriaParametersValuesID
        {
            get;
            set;
        }
        string FeeCriteriaParameterValue
        {
            get;
            set;
        }
        string errorMessage { get; set; }
    }
}

