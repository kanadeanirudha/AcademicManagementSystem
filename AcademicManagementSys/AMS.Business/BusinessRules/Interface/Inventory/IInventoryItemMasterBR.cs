using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Business.BusinessRules
{
    public interface IInventoryItemMasterBR
    {
        IValidateBusinessRuleResponse InsertInventoryItemMasterValidate(InventoryItemMaster item);
        IValidateBusinessRuleResponse UpdateInventoryItemMasterValidate(InventoryItemMaster item);
        IValidateBusinessRuleResponse DeleteInventoryItemMasterValidate(InventoryItemMaster item);
    }
}
