using AMS.DTO;
using System;
using System.Collections.Generic;

namespace AMS.ViewModel
{
    public interface IEntranceExamValidationParameterViewModel
    {
        EntranceExamValidationParameter EntranceExamValidationParameterDTO
        {
            get;
            set;
        }

        int ID
        {
            get;
            set;
        }
        int FeeCriteriaValueCombinationMasterID
        {
            get;
            set;
        }
        string FeeCriteriaValueCombinationDescription
        {
            get;
            set;
        }
        decimal PreQualificationCutOff
        {
            get;
            set;
        }

        decimal EntranceExamFeeAmount
        {
            get;
            set;
        }
        decimal EntranceExamCutOff
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
