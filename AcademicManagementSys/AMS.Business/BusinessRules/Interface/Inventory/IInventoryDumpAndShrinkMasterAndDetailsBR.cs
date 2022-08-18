using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Business.BusinessRules
{
    public interface IInventoryDumpAndShrinkMasterAndDetailsBR
    {
        IValidateBusinessRuleResponse InsertInventoryDumpAndShrinkMasterAndDetailsValidate(InventoryDumpAndShrinkMasterAndDetails item);
        IValidateBusinessRuleResponse UpdateInventoryDumpAndShrinkMasterAndDetailsValidate(InventoryDumpAndShrinkMasterAndDetails item);
        IValidateBusinessRuleResponse DeleteInventoryDumpAndShrinkMasterAndDetailsValidate(InventoryDumpAndShrinkMasterAndDetails item);
    }
}
