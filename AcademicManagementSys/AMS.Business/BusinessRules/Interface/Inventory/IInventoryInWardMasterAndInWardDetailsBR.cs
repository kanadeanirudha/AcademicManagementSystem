using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Business.BusinessRules
{
    public interface IInventoryInWardMasterAndInWardDetailsBR
    {
        // InventoryInWardMaster Method
        IValidateBusinessRuleResponse InsertInventoryInWardMasterValidate(InventoryInWardMasterAndInWardDetails item);
        IValidateBusinessRuleResponse UpdateInventoryInWardMasterValidate(InventoryInWardMasterAndInWardDetails item);
        IValidateBusinessRuleResponse DeleteInventoryInWardMasterValidate(InventoryInWardMasterAndInWardDetails item);

        //InventoryInWardDetails Method
        IValidateBusinessRuleResponse InsertInventoryInWardDetailsValidate(InventoryInWardMasterAndInWardDetails item);
        IValidateBusinessRuleResponse UpdateInventoryInWardDetailsValidate(InventoryInWardMasterAndInWardDetails item);
        IValidateBusinessRuleResponse DeleteInventoryInWardDetailsValidate(InventoryInWardMasterAndInWardDetails item);
    }
}
