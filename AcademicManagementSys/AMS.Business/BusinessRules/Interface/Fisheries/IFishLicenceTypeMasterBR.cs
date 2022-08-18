using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Business.BusinessRules
{
    public interface IFishLicenseTypeBR
    {
        IValidateBusinessRuleResponse InsertFishLicenseTypeValidate(FishLicenseType item);
        IValidateBusinessRuleResponse UpdateFishLicenseTypeValidate(FishLicenseType item);
        IValidateBusinessRuleResponse DeleteFishLicenseTypeValidate(FishLicenseType item);
    }
}
