using AMS.Base.DTO;
using System;

namespace AMS.DTO
{
    public class FishLicenseRuleMasterSearchRequest : Request
    {
        public int ID
        {
            get;
            set;
        }
        public int LicenseTypeID
        {
            get;
            set;
        }
        public string RuleName
        {
            get;
            set;
        }
        public string RuleCode
        {
            get;
            set;
        }
        public decimal Percentage
        {
            get;
            set;
        }
        public string IncreaseDecreaseFlag
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

        //FishLicenseApplicable Property
        public int FishLicenseApplicableTblID { get; set; }
        public int FishLicenseRuleMasterID { get; set; }
        public string ApplicableFromDate { get; set; }
        public string ApplicableUptoDate { get; set; }
        public bool IsAplicableToAllCentre { get; set; }
        public decimal LicenseFeeAmount { get; set; }

        //FishLicenseApplicableDetails Property

        public int FishLicenseApplicableDetailsID { get; set; }
        public int FishLicenseApplicableID { get; set; }
        public string CentreCode { get; set; }


        //Extra Property

        public string SearchBy { get; set; }
        public string SortDirection { get; set; }
        public string LicenseType { get; set; }
    }
}
