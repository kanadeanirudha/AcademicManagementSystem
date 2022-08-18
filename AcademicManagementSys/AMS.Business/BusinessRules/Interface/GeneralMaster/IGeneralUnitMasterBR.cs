using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.Business.BusinessRules
{
    public interface IGeneralUnitMasterBR
    {
        IValidateBusinessRuleResponse InsertGeneralUnitMasterValidate(GeneralUnitMaster item);
        IValidateBusinessRuleResponse UpdateGeneralUnitMasterValidate(GeneralUnitMaster item);
        IValidateBusinessRuleResponse DeleteGeneralUnitMasterValidate(GeneralUnitMaster item);
    }
}
