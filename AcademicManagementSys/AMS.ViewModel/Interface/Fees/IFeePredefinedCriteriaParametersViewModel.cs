using AMS.DTO;
using System;
using System.Collections.Generic;

namespace AMS.ViewModel
{
    public interface IFeePredefinedCriteriaParametersViewModel
    {
        FeePredefinedCriteriaParameters FeePredefinedCriteriaParametersDTO
        {
            get;
            set;
        }

        int ID
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
        string TableEntityName
        {
            get;
            set;
        }
        string PrimaryKeyFieldName
        {
            get;
            set;
        }
        string DisplayKeyFieldName
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
        int ModifiedBy
        {
            get;
            set;
        }
        DateTime ModifiedDate
        {
            get;
            set;
        }
        int DeletedBy
        {
            get;
            set;
        }
        DateTime DeletedDate
        {
            get;
            set;
        }
        string errorMessage { get; set; }
    }
}
