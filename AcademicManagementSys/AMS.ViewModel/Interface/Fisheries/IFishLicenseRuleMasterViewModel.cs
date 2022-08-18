using AMS.DTO;
using System;
using System.Collections.Generic;

namespace AMS.ViewModel
{
    public interface IFishLicenseRuleMasterViewModel
    {
        FishLicenseRuleMaster FishLicenseRuleMasterDTO { get; set; }


        // FishLicenseRuleMaster Property
        int ID { get; set; }
        int LicenseTypeID { get; set; }
        string RuleName { get; set; }
        string RuleCode { get; set; }
        decimal Percentage { get; set; }
        string IncreaseDecreaseFlag { get; set; }
        bool IsDeleted { get; set; }
        int CreatedBy { get; set; }
        DateTime CreatedDate { get; set; }
        int? ModifiedBy { get; set; }
        DateTime? ModifiedDate { get; set; }
        int? DeletedBy { get; set; }
        DateTime? DeletedDate { get; set; }


        //FishLicenseApplicable Property

        int FishLicenseApplicableTblID { get; set; }
        int FishLicenseRuleMasterID { get; set; }
        string ApplicableFromDate { get; set; }
        string ApplicableUptoDate { get; set; }
        bool IsAplicableToAllCentre { get; set; }
        decimal LicenseFeeAmount { get; set; }

        //FishLicenseApplicableDetails Property

        int FishLicenseApplicableDetailsID { get; set; }
        int FishLicenseApplicableID { get; set; }
        string CentreCode { get; set; }


    }
}
