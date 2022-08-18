using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Business.BusinessRules
{
    public interface IInventoryCustomerMasterBR
    {
        IValidateBusinessRuleResponse InsertInventoryCustomerMasterValidate(InventoryCustomerMaster item);
        IValidateBusinessRuleResponse UpdateInventoryCustomerMasterValidate(InventoryCustomerMaster item);
        IValidateBusinessRuleResponse DeleteInventoryCustomerMasterValidate(InventoryCustomerMaster item);
    }
}
