using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Business.BusinessRules
{
    public interface IInventoryItemSaleReturnMasterBR
    {
        IValidateBusinessRuleResponse InsertInventoryItemSaleReturnMasterValidate(InventoryItemSaleReturnMaster item);
        IValidateBusinessRuleResponse UpdateInventoryItemSaleReturnMasterValidate(InventoryItemSaleReturnMaster item);
        IValidateBusinessRuleResponse DeleteInventoryItemSaleReturnMasterValidate(InventoryItemSaleReturnMaster item);
    }
}
