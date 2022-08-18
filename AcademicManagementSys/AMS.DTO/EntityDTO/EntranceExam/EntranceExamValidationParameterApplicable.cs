using AMS.Base.DTO;
using System;
namespace AMS.DTO
{
    public class EntranceExamValidationParameterApplicable : BaseDTO
    {
        public int ID
        {
            get;
            set;
        }
        //from table EntranceExamValidationParameterApplicable
        public int EntranceExamValidationParameterID	
        {
            get;
            set;
        }

        public string FromDate  
        {
            get;
            set;
        }
        public string UpToDate
        {
            get;
            set;
        }
        public string CentreCode
        {
            get;
            set;
        }
        public bool IsLastRecord
        {
            get;
            set;
        }

        //from Table EntranceExamValidationParameter
        public string FeeCriteriaValueCombinationDescription
        {
            get;
            set;
        }
        public decimal PreQualificationCutOff
        {
            get;
            set;
        }

        public decimal EntranceExamFeeAmount
        {
            get;
            set;
        }
        public decimal EntranceExamCutOff
        {
            get;
            set;
        }
        public string SessionName { get; set; }
        public string CentreName
        {
            get;
            set;
        }
        public int SessionID
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
        public int ModifiedBy
        {
            get;
            set;
        }
        public DateTime ModifiedDate
        {
            get;
            set;
        }
        public int DeletedBy
        {
            get;
            set;
        }
        public DateTime DeletedDate
        {
            get;
            set;
        }
        public string errorMessage { get; set; }
    }
}
