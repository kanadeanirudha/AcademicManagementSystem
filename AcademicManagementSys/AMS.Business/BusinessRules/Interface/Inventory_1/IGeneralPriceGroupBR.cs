using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Business.BusinessRules
{
    public interface IGeneralPriceGroupBR
    {
        IValidateBusinessRuleResponse InsertGeneralPriceGroupValidate(GeneralPriceGroup item);
        IValidateBusinessRuleResponse UpdateGeneralPriceGroupValidate(GeneralPriceGroup item);
        IValidateBusinessRuleResponse DeleteGeneralPriceGroupValidate(GeneralPriceGroup item);
    }
}
