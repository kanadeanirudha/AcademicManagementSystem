using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Business.BusinessRules
{
    public interface IInventoryIssueMasterAndDetailsBR
    {
        IValidateBusinessRuleResponse InsertInventoryIssueMasterAndDetailsValidate(InventoryIssueMasterAndDetails item);
        IValidateBusinessRuleResponse UpdateInventoryIssueMasterAndDetailsValidate(InventoryIssueMasterAndDetails item);
        IValidateBusinessRuleResponse DeleteInventoryIssueMasterAndDetailsValidate(InventoryIssueMasterAndDetails item);
    }
}
