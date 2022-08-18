using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Business.BusinessRules
{
    public interface IGeneralAllocateSaleProcessUnitBR
    {
        IValidateBusinessRuleResponse InsertGeneralAllocateSaleProcessUnitValidate(GeneralAllocateSaleProcessUnit item);
        IValidateBusinessRuleResponse UpdateGeneralAllocateSaleProcessUnitValidate(GeneralAllocateSaleProcessUnit item);
        IValidateBusinessRuleResponse DeleteGeneralAllocateSaleProcessUnitValidate(GeneralAllocateSaleProcessUnit item);
    }
}
