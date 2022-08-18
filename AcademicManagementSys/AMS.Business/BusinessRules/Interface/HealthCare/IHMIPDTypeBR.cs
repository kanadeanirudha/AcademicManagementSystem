using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Business.BusinessRules
{
    public interface IHMIPDTypeBR
    {
        IValidateBusinessRuleResponse InsertHMIPDTypeValidate(HMIPDType item);
        IValidateBusinessRuleResponse UpdateHMIPDTypeValidate(HMIPDType item);
        IValidateBusinessRuleResponse DeleteHMIPDTypeValidate(HMIPDType item);
    }
}
