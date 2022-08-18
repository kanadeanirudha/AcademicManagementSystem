using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Business.BusinessRules
{
    public interface IInventoryLocationMasterBR
    {
        IValidateBusinessRuleResponse InsertInventoryLocationMasterValidate(InventoryLocationMaster item);
        IValidateBusinessRuleResponse UpdateInventoryLocationMasterValidate(InventoryLocationMaster item);
        IValidateBusinessRuleResponse DeleteInventoryLocationMasterValidate(InventoryLocationMaster item);
    }
}
