using AMS.Common;
using AMS.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AMS.ViewModel
{
     public class FishLicenseRuleMasterViewModel : IFishLicenseRuleMasterViewModel
    {
         public FishLicenseRuleMasterViewModel()
         {
             FishLicenseRuleMasterDTO = new FishLicenseRuleMaster();
             ListGetFishLicenseType = new List<FishLicenseType>();

             ListOrgStudyApplicableCentre = new List<AdminRoleApplicableDetails>();            
         }

         public FishLicenseRuleMaster FishLicenseRuleMasterDTO { get; set; }

         public List<FishLicenseType> ListGetFishLicenseType
         {
             get;
             set;
         }
         
         public IEnumerable<SelectListItem> ListGetAdminFishLicenseTypeItems
         {
             get
             {
                 return new SelectList(ListGetFishLicenseType, "ID", "LicenseType");
             }
         }

         public List<AdminRoleApplicableDetails> ListOrgStudyApplicableCentre
         {
             get;
             set;
         }

         //public IEnumerable<SelectListItem> ListOrgStudyApplicableCentreItems
         //{
         //    get
         //    {
         //        return new SelectList(ListOrgStudyApplicableCentre, "CentreCode", "CentreName");
         //    }
         //}

         //------------------------------------------------Model Properties-----------------------------------------------------------------------------------------------//

         public int ID
         {
             get
             {
                 return (FishLicenseRuleMasterDTO != null && FishLicenseRuleMasterDTO.ID > 0) ? FishLicenseRuleMasterDTO.ID : new int();
             }
             set
             {
                 FishLicenseRuleMasterDTO.ID = value;
             }
         }

         public int LicenseTypeID
         {
             get
             {
                 return (FishLicenseRuleMasterDTO != null && FishLicenseRuleMasterDTO.LicenseTypeID > 0) ? FishLicenseRuleMasterDTO.LicenseTypeID : new int();
             }
             set
             {
                 FishLicenseRuleMasterDTO.LicenseTypeID = value;
             }
         }

         
         [Display(Name = "DisplayName_RuleName", ResourceType = typeof(Resources))]
         [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "DisplayErrorMessage_RuleNameShouldNotBeBlank")]
         public string RuleName
         {
             get
             {
                 return (FishLicenseRuleMasterDTO != null && FishLicenseRuleMasterDTO.RuleName != "") ? FishLicenseRuleMasterDTO.RuleName : string.Empty;
             }
             set
             {
                 FishLicenseRuleMasterDTO.RuleName = value;
             }
         }

         [Display(Name = "DisplayName_RuleCode", ResourceType = typeof(Resources))]
         [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "DisplayErrorMessage_RuleCodeShouldNotBlank")]
         public string RuleCode
         {
             get
             {
                 return (FishLicenseRuleMasterDTO != null && FishLicenseRuleMasterDTO.RuleCode != "") ? FishLicenseRuleMasterDTO.RuleCode : string.Empty;
             }
             set
             {
                 FishLicenseRuleMasterDTO.RuleCode = value;
             }
         }

         
         [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "DisplayErrorMessage_PercentageShouldNotBeBlank")]
         public decimal Percentage
         {
             get
             {
                 return FishLicenseRuleMasterDTO != null ? FishLicenseRuleMasterDTO.Percentage : new decimal();
             }
             set
             {
                 FishLicenseRuleMasterDTO.Percentage = value;
             }
         }

         
         [Display(Name = "DisplayName_Increase_Decrease", ResourceType = typeof(Resources))]
         [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "DisplayErrorMessage_IncreaseDecreaseFlagShouldNotBeBlank")]
         public string IncreaseDecreaseFlag
         {
             get
             {
                 return (FishLicenseRuleMasterDTO != null && FishLicenseRuleMasterDTO.IncreaseDecreaseFlag != "") ? FishLicenseRuleMasterDTO.IncreaseDecreaseFlag : string.Empty;
             }
             set
             {
                 FishLicenseRuleMasterDTO.IncreaseDecreaseFlag = value;
             }
         }
                  
         public bool IsDeleted
         {
             get
             {
                 return FishLicenseRuleMasterDTO.IsDeleted != false ? FishLicenseRuleMasterDTO.IsDeleted : false;
             }
             set
             {
                 FishLicenseRuleMasterDTO.IsDeleted = value;
             }
         }

         public int CreatedBy
         {
             get
             {
                 return (FishLicenseRuleMasterDTO != null && FishLicenseRuleMasterDTO.CreatedBy > 0) ? FishLicenseRuleMasterDTO.CreatedBy : new int();
             }
             set
             {
                 FishLicenseRuleMasterDTO.CreatedBy = value;
             }
         }

         public DateTime CreatedDate
         {
             get
             {
                 return (FishLicenseRuleMasterDTO.CreatedDate != null) ? FishLicenseRuleMasterDTO.CreatedDate : DateTime.Now;
             }
             set
             {
                 FishLicenseRuleMasterDTO.CreatedDate = value;
             }
         }

         public Nullable<int> ModifiedBy
         {
             get
             {
                 return (FishLicenseRuleMasterDTO != null && FishLicenseRuleMasterDTO.ModifiedBy > 0) ? FishLicenseRuleMasterDTO.ModifiedBy : new int();
             }
             set
             {
                 FishLicenseRuleMasterDTO.ModifiedBy = value;
             }
         }

         public DateTime? ModifiedDate
         {
             get
             {
                 return (FishLicenseRuleMasterDTO.ModifiedDate != null) ? FishLicenseRuleMasterDTO.ModifiedDate : DateTime.Now;
             }
             set
             {
                 FishLicenseRuleMasterDTO.ModifiedDate = value;
             }
         }

         public int? DeletedBy
         {
             get
             {
                 return (FishLicenseRuleMasterDTO != null && FishLicenseRuleMasterDTO.DeletedBy > 0) ? FishLicenseRuleMasterDTO.DeletedBy : new int();
             }
             set
             {
                 FishLicenseRuleMasterDTO.DeletedBy = value;
             }
         }

         public DateTime? DeletedDate
         {
             get
             {
                 return (FishLicenseRuleMasterDTO.DeletedDate != null) ? FishLicenseRuleMasterDTO.DeletedDate : DateTime.Now;
             }
             set
             {
                 FishLicenseRuleMasterDTO.DeletedDate = value;
             }
         }

        //FishLicenseApplicable Property

         public int FishLicenseApplicableTblID
         {
             get
             {
                 return (FishLicenseRuleMasterDTO != null && FishLicenseRuleMasterDTO.FishLicenseApplicableTblID > 0) ? FishLicenseRuleMasterDTO.FishLicenseApplicableTblID : new int();
             }
             set
             {
                 FishLicenseRuleMasterDTO.FishLicenseApplicableTblID = value;
             }
         }

         public int FishLicenseRuleMasterID
         {
             get
             {
                 return (FishLicenseRuleMasterDTO != null && FishLicenseRuleMasterDTO.FishLicenseRuleMasterID > 0) ? FishLicenseRuleMasterDTO.FishLicenseRuleMasterID : new int();
             }
             set
             {
                 FishLicenseRuleMasterDTO.FishLicenseRuleMasterID = value;
             }
         }

         [Display(Name = "DisplayName_ApplicableFromData", ResourceType = typeof(Resources))]
         [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "DisplayErrorMessage_ApplicableFromDateShouldNotBlank")]
         public string ApplicableFromDate
         {
             get
             {
                 return (FishLicenseRuleMasterDTO.ApplicableFromDate != null) ? FishLicenseRuleMasterDTO.ApplicableFromDate : string.Empty;
             }
             set
             {
                 FishLicenseRuleMasterDTO.ApplicableFromDate = value;
             }
         }
                  
         [Display(Name = "DisplayName_ApplicableUptoDate", ResourceType = typeof(Resources))]
         [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "DisplayErrorMessage_ApplicableUptoDateShouldNotBlank")]
         public string ApplicableUptoDate
         {
             get
             {
                 return (FishLicenseRuleMasterDTO.ApplicableUptoDate != null) ? FishLicenseRuleMasterDTO.ApplicableUptoDate : string.Empty;
             }
             set
             {
                 FishLicenseRuleMasterDTO.ApplicableUptoDate = value;
             }
         }

         
         [Display(Name = "DisplayName_ApplicableToAll", ResourceType = typeof(Resources))]
         [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "DisplayErrorMessage_ApplicableToAllShouldNotBlank")]
         public bool IsAplicableToAllCentre
         {
             get
             {
                 return FishLicenseRuleMasterDTO.IsAplicableToAllCentre != false ? FishLicenseRuleMasterDTO.IsAplicableToAllCentre : false;
             }
             set
             {
                 FishLicenseRuleMasterDTO.IsAplicableToAllCentre = value;
             }
         }

        //FishLicenseApplicableDetails Property

         public int FishLicenseApplicableDetailsID
         {
             get
             {
                 return (FishLicenseRuleMasterDTO != null && FishLicenseRuleMasterDTO.FishLicenseApplicableDetailsID > 0) ? FishLicenseRuleMasterDTO.FishLicenseApplicableDetailsID : new int();
             }
             set
             {
                 FishLicenseRuleMasterDTO.FishLicenseApplicableDetailsID = value;
             }
         }

         [Display(Name = "Applicable Center")]
         public int FishLicenseApplicableID
         {
             get
             {
                 return (FishLicenseRuleMasterDTO != null && FishLicenseRuleMasterDTO.FishLicenseApplicableID > 0) ? FishLicenseRuleMasterDTO.FishLicenseApplicableID : new int();
             }
             set
             {
                 FishLicenseRuleMasterDTO.FishLicenseApplicableID = value;
             }
         }

         public string CentreCode
         {
             get
             {
                 return (FishLicenseRuleMasterDTO != null && FishLicenseRuleMasterDTO.CentreCode != "") ? FishLicenseRuleMasterDTO.CentreCode : string.Empty;
             }
             set
             {
                 FishLicenseRuleMasterDTO.CentreCode = value;
             }
         }

         public string SelectedCentreCodes
         {
             get
             {
                 return (FishLicenseRuleMasterDTO != null && FishLicenseRuleMasterDTO.SelectedCentreCodes != "") ? FishLicenseRuleMasterDTO.SelectedCentreCodes : string.Empty;
             }
             set
             {
                 FishLicenseRuleMasterDTO.SelectedCentreCodes = value;
             }
         }

         [Display(Name = "DisplayName_LicenseFeeAmount", ResourceType = typeof(Resources))]
         [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "ValidationMessage_LicenseFeeAmountShouldNotBlank")]
         public decimal LicenseFeeAmount
         {
             get
             {
                 return FishLicenseRuleMasterDTO != null  ? FishLicenseRuleMasterDTO.LicenseFeeAmount : new decimal();
             }
             set
             {
                 FishLicenseRuleMasterDTO.LicenseFeeAmount = value;
             }
         }

    }
}
