using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Business.BusinessRules
{
    public interface IInventoryReportMasterBR
    {
        // InventoryReportMaster Method
        IValidateBusinessRuleResponse InsertInventoryReportMasterValidate(InventoryReportMaster item);
        IValidateBusinessRuleResponse UpdateInventoryReportMasterValidate(InventoryReportMaster item);
        IValidateBusinessRuleResponse DeleteInventoryReportMasterValidate(InventoryReportMaster item);
    }
}
