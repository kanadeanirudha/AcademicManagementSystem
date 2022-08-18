using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Business.BusinessRules
{
    public interface IInventoryItemCategoryMasterBR
    {
        IValidateBusinessRuleResponse InsertInventoryItemCategoryMasterValidate(InventoryItemCategoryMaster item);
        IValidateBusinessRuleResponse UpdateInventoryItemCategoryMasterValidate(InventoryItemCategoryMaster item);
        IValidateBusinessRuleResponse DeleteInventoryItemCategoryMasterValidate(InventoryItemCategoryMaster item);
    }
}
