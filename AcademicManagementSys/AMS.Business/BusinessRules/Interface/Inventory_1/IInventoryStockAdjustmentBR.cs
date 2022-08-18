using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Business.BusinessRules
{
    public interface IInventoryStockAdjustmentBR
    {
        IValidateBusinessRuleResponse InsertInventoryStockAdjustmentValidate(InventoryStockAdjustment item);
        IValidateBusinessRuleResponse UpdateInventoryStockAdjustmentValidate(InventoryStockAdjustment item);
        IValidateBusinessRuleResponse DeleteInventoryStockAdjustmentValidate(InventoryStockAdjustment item);
        IValidateBusinessRuleResponse InsertXMLInventoryStockAdjustmentValidate(InventoryStockAdjustment item);
        IValidateBusinessRuleResponse InsertXMLForRecipeInventoryStockAdjustmentValidate(InventoryStockAdjustment item);
    }
}
