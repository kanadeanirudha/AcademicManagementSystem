
using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Business.BusinessRules
{
    public interface IInventoryCounterLogAndLockDetailsBR
    {
        IValidateBusinessRuleResponse InsertInventoryCounterLogAndLockDetailsValidate(InventoryCounterLogAndLockDetails item);
        IValidateBusinessRuleResponse UpdateInventoryCounterLogAndLockDetailsValidate(InventoryCounterLogAndLockDetails item);
        IValidateBusinessRuleResponse DeleteInventoryCounterLogAndLockDetailsValidate(InventoryCounterLogAndLockDetails item);
    }
}
