using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Business.BusinessRules
{
    public interface IGeneralEducationTypeMasterBR
    {
        IValidateBusinessRuleResponse InsertGeneralEducationTypeMasterValidate(GeneralEducationTypeMaster item);

        IValidateBusinessRuleResponse UpdateGeneralEducationTypeMasterValidate(GeneralEducationTypeMaster item);

        IValidateBusinessRuleResponse DeleteGeneralEducationTypeMasterValidate(GeneralEducationTypeMaster item);
    }
}
