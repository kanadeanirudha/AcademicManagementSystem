using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Business.BusinessRules
{
    public interface IInventoryCounterMasterBR
    {
        IValidateBusinessRuleResponse InsertInventoryCounterMasterValidate(InventoryCounterMaster item);
        IValidateBusinessRuleResponse UpdateInventoryCounterMasterValidate(InventoryCounterMaster item);
        IValidateBusinessRuleResponse DeleteInventoryCounterMasterValidate(InventoryCounterMaster item);
    }
}
