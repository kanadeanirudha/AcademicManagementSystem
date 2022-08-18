using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Business.BusinessRules
{
    public interface IFishItemLicenseAllocationBR
    {
        IValidateBusinessRuleResponse InsertFishItemLicenseAllocationValidate(FishItemLicenseAllocation item);
        IValidateBusinessRuleResponse UpdateFishItemLicenseAllocationValidate(FishItemLicenseAllocation item);
        IValidateBusinessRuleResponse DeleteFishItemLicenseAllocationValidate(FishItemLicenseAllocation item);
    }
}
