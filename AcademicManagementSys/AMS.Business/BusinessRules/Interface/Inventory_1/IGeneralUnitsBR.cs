using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Business.BusinessRules
{
    public interface IGeneralUnitsBR
    {
        IValidateBusinessRuleResponse InsertGeneralUnitsValidate(GeneralUnits item);
        IValidateBusinessRuleResponse UpdateGeneralUnitsValidate(GeneralUnits item);
        IValidateBusinessRuleResponse DeleteGeneralUnitsValidate(GeneralUnits item);
    }
}
