using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Business.BusinessRules
{
    public interface IInventoryLocationMaster_1BR
    {
        IValidateBusinessRuleResponse InsertInventoryLocationMaster_1Validate(InventoryLocationMaster_1 item);
        IValidateBusinessRuleResponse UpdateInventoryLocationMaster_1Validate(InventoryLocationMaster_1 item);
        IValidateBusinessRuleResponse DeleteInventoryLocationMaster_1Validate(InventoryLocationMaster_1 item);
    }
}
