using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Business.BusinessRules
{
    public interface IInventoryDatewiseItemTransactionBR
    {
        IValidateBusinessRuleResponse InsertInventoryDatewiseItemTransactionValidate(InventoryDatewiseItemTransaction item);
        IValidateBusinessRuleResponse UpdateInventoryDatewiseItemTransactionValidate(InventoryDatewiseItemTransaction item);
        IValidateBusinessRuleResponse DeleteInventoryDatewiseItemTransactionValidate(InventoryDatewiseItemTransaction item);
    }
}
