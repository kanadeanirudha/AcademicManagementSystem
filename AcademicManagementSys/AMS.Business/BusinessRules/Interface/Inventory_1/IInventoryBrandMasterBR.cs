using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Business.BusinessRules
{
    public interface IInventoryBrandMasterBR
    {
        IValidateBusinessRuleResponse InsertInventoryBrandMasterValidate(InventoryBrandMaster item);
        IValidateBusinessRuleResponse UpdateInventoryBrandMasterValidate(InventoryBrandMaster item);
        IValidateBusinessRuleResponse DeleteInventoryBrandMasterValidate(InventoryBrandMaster item);
    }
}
