using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.Business.BusinessRules
{
    public interface IGeneralMapTypeOfAccountBR
    {
        IValidateBusinessRuleResponse InsertGeneralMapTypeOfAccountValidate(GeneralMapTypeOfAccount item);
        IValidateBusinessRuleResponse UpdateGeneralMapTypeOfAccountValidate(GeneralMapTypeOfAccount item);
        IValidateBusinessRuleResponse DeleteGeneralMapTypeOfAccountValidate(GeneralMapTypeOfAccount item);
    }
}
