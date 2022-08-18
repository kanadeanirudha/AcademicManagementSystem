using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Business.BusinessRules
{
    public interface IFishLicenseRuleMasterBR
    {
        IValidateBusinessRuleResponse InsertFishLicenseRuleMasterValidate(FishLicenseRuleMaster item);
        IValidateBusinessRuleResponse UpdateFishLicenseRuleMasterValidate(FishLicenseRuleMaster item);
        IValidateBusinessRuleResponse DeleteFishLicenseRuleMasterValidate(FishLicenseRuleMaster item);
    }
}
