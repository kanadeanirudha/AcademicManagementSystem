using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.Business.BusinessRules
{
    public interface ICRMSaleAccountProgressTypeMasterAndRuleBR
    {
        //CRMSaleAccountProgressTypeRule
        IValidateBusinessRuleResponse InsertCRMSaleAccountProgressTypeRuleValidate(CRMSaleAccountProgressTypeMasterAndRule item);

        IValidateBusinessRuleResponse UpdateCRMSaleAccountProgressTypeRuleValidate(CRMSaleAccountProgressTypeMasterAndRule item);

        IValidateBusinessRuleResponse DeleteCRMSaleAccountProgressTypeRuleValidate(CRMSaleAccountProgressTypeMasterAndRule item);

      
    }
}
