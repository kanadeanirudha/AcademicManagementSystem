using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Business.BusinessRules
{
    public interface IFeeTypeAndSubTypeBR
    {
        IValidateBusinessRuleResponse InsertFeeTypeAndSubTypeValidate(FeeTypeAndSubType item);
        IValidateBusinessRuleResponse UpdateFeeTypeAndSubTypeValidate(FeeTypeAndSubType item);
        IValidateBusinessRuleResponse DeleteFeeTypeAndSubTypeValidate(FeeTypeAndSubType item);
    }
}
