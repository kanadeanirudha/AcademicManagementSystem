using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.Business.BusinessRules
{
    public interface IInventoryPurchaseMasterAndTransactionBR
	{
        IValidateBusinessRuleResponse InsertInventoryPurchaseMasterAndTransactionValidate(InventoryPurchaseMasterAndTransaction item);
        IValidateBusinessRuleResponse UpdateInventoryPurchaseMasterAndTransactionValidate(InventoryPurchaseMasterAndTransaction item);
        IValidateBusinessRuleResponse DeleteInventoryPurchaseMasterAndTransactionValidate(InventoryPurchaseMasterAndTransaction item);
	}
}

