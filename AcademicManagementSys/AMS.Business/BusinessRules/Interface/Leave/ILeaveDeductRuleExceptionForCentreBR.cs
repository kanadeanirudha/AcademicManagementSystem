using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.Business.BusinessRules
{
    public interface ILeaveDeductRuleExceptionForCentreBR
    {
        /// <summary>
        /// business rule interface of insert new record of LeaveDeductRuleExceptionForCentre.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IValidateBusinessRuleResponse InsertLeaveDeductRuleExceptionForCentreValidate(LeaveDeductRuleExceptionForCentre item);

        /// <summary>
        /// business rule interface of update record of LeaveDeductRuleExceptionForCentre.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IValidateBusinessRuleResponse UpdateLeaveDeductRuleExceptionForCentreValidate(LeaveDeductRuleExceptionForCentre item);

        /// <summary>
        /// business rule interface of dalete record of LeaveDeductRuleExceptionForCentre.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IValidateBusinessRuleResponse DeleteLeaveDeductRuleExceptionForCentreValidate(LeaveDeductRuleExceptionForCentre item);
    }
}

