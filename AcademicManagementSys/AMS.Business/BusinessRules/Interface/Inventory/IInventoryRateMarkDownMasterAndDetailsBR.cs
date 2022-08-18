using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Business.BusinessRules
{
    public interface IInventoryRateMarkDownMasterAndDetailsBR
    {
        IValidateBusinessRuleResponse InsertInventoryRateMarkDownMasterAndDetailsValidate(InventoryRateMarkDownMasterAndDetails item);
        IValidateBusinessRuleResponse UpdateInventoryRateMarkDownMasterAndDetailsValidate(InventoryRateMarkDownMasterAndDetails item);
        IValidateBusinessRuleResponse DeleteInventoryRateMarkDownMasterAndDetailsValidate(InventoryRateMarkDownMasterAndDetails item);
    }
}
