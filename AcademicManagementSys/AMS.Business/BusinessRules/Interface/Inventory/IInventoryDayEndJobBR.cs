using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Business.BusinessRules
{
    public interface IInventoryDayEndJobBR
    {
        IValidateBusinessRuleResponse InsertInventoryDayEndJobValidate(InventoryDayEndJob item);
        IValidateBusinessRuleResponse UpdateInventoryDayEndJobValidate(InventoryDayEndJob item);
        IValidateBusinessRuleResponse DeleteInventoryDayEndJobValidate(InventoryDayEndJob item);
        IValidateBusinessRuleResponse GetDayEndJob(InventoryDayEndJob item);
    }
}
