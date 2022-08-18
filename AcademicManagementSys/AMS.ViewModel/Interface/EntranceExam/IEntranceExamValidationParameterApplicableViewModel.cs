using AMS.DTO;
using System;
using System.Collections.Generic;

namespace AMS.ViewModel
{
    public interface IEntranceExamValidationParameterApplicableViewModel
    {
        EntranceExamValidationParameterApplicable EntranceExamValidationParameterApplicableDTO
        {
            get;
            set;
        }

        int ID
        {
            get;
            set;
        }
        //from table EntranceExamValidationParameterApplicable
        int EntranceExamValidationParameterID
        {
            get;
            set;
        }

        string FromDate
        {
            get;
            set;
        }
        string UpToDate
        {
            get;
            set;
        }
        string CentreCode
        {
            get;
            set;
        }
        bool IsLastRecord
        {
            get;
            set;
        }

        //from Table EntranceExamValidationParameter
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
