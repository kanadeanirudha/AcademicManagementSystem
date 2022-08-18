using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Business.BusinessRules
{
    public interface IGeneralPackageTypeBR
    {
        IValidateBusinessRuleResponse InsertGeneralPackageTypeValidate(GeneralPackageType item);
        IValidateBusinessRuleResponse UpdateGeneralPackageTypeValidate(GeneralPackageType item);
        IValidateBusinessRuleResponse DeleteGeneralPackageTypeValidate(GeneralPackageType item);
    }
}
