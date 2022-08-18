

using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Business.BusinessRules
{
    public interface IPurchaseReturnBR
    {
        IValidateBusinessRuleResponse InsertPurchaseReturnValidate(PurchaseReturn item);
        IValidateBusinessRuleResponse UpdatePurchaseReturnValidate(PurchaseReturn item);
        IValidateBusinessRuleResponse DeletePurchaseReturnValidate(PurchaseReturn item);
    }
}
