using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.Business.BusinessRules
{
    public interface ILeaveLateMarkRulesDetailsBR
    {
        IValidateBusinessRuleResponse InsertLeaveLateMarkRulesDetailsValidate(LeaveLateMarkRulesDetails item);
        IValidateBusinessRuleResponse UpdateLeaveLateMarkRulesDetailsValidate(LeaveLateMarkRulesDetails item);
        IValidateBusinessRuleResponse DeleteLeaveLateMarkRulesDetailsValidate(LeaveLateMarkRulesDetails item);
    }
}
