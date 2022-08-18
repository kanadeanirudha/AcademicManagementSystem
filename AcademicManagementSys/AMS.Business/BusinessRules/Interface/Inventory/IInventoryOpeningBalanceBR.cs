using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Business.BusinessRules
{
    public interface IInventoryOpeningBalanceBR
    {
        IValidateBusinessRuleResponse InsertInventoryOpeningBalanceValidate(InventoryOpeningBalance item);
        IValidateBusinessRuleResponse UpdateInventoryOpeningBalanceValidate(InventoryOpeningBalance item);
        IValidateBusinessRuleResponse DeleteInventoryOpeningBalanceValidate(InventoryOpeningBalance item);
    }
}
