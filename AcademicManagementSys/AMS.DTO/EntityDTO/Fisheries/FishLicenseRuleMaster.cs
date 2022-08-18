using AMS.Base.DTO;
using System;

namespace AMS.DTO
{
    public class FishLicenseRuleMaster : BaseDTO
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
        public bool IsActive
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
        public Nullable<int> ModifiedBy
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

        //Extra Feild.
        public string SelectedCentreCodes { get; set; }
        

    }
}
