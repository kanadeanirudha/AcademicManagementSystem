using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Business.BusinessRules
{
    public interface IGeneralItemMerchantiseDepartmentBR
    {
        IValidateBusinessRuleResponse InsertGeneralItemMerchantiseDepartmentValidate(GeneralItemMerchantiseDepartment item);
        IValidateBusinessRuleResponse UpdateGeneralItemMerchantiseDepartmentValidate(GeneralItemMerchantiseDepartment item);
        IValidateBusinessRuleResponse DeleteGeneralItemMerchantiseDepartmentValidate(GeneralItemMerchantiseDepartment item);
    }
}
