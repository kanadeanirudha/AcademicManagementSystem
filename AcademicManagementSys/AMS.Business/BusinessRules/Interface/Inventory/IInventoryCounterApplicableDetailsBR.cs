using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Business.BusinessRules
{
    public interface IInventoryCounterApplicableDetailsBR
    {
        IValidateBusinessRuleResponse InsertInventoryCounterApplicableDetailsValidate(InventoryCounterApplicableDetails item);
        IValidateBusinessRuleResponse UpdateInventoryCounterApplicableDetailsValidate(InventoryCounterApplicableDetails item);
        IValidateBusinessRuleResponse DeleteInventoryCounterApplicableDetailsValidate(InventoryCounterApplicableDetails item);
    }
}
