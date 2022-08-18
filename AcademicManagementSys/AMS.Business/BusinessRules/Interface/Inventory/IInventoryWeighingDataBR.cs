using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Business.BusinessRules
{
    public interface IInventoryWeighingDataBR
    {
        IValidateBusinessRuleResponse InsertInventoryWeighingDataValidate(InventoryWeighingData item);
        IValidateBusinessRuleResponse UpdateInventoryWeighingDataValidate(InventoryWeighingData item);
        IValidateBusinessRuleResponse DeleteInventoryWeighingDataValidate(InventoryWeighingData item);
    }
}
