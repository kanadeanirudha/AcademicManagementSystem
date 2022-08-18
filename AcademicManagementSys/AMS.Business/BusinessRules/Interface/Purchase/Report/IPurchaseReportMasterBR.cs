
using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Business.BusinessRules
{
    public interface IPurchaseReportMasterBR
    {
        // PurchaseReportMaster Method
        IValidateBusinessRuleResponse InsertPurchaseReportMasterValidate(PurchaseReportMaster item);
        IValidateBusinessRuleResponse UpdatePurchaseReportMasterValidate(PurchaseReportMaster item);
        IValidateBusinessRuleResponse DeletePurchaseReportMasterValidate(PurchaseReportMaster item);
    }
}
