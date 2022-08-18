using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.Business.BusinessRules
{
    public interface ICRMCallerRoleAllocationBR
    {
        /// <summary>
        /// business rule interface of insert new record of CRMCallerRoleAllocation.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IValidateBusinessRuleResponse InsertCRMCallerRoleAllocationValidate(CRMCallerRoleAllocation item);

        /// <summary>
        /// business rule interface of update record of CRMCallerRoleAllocation.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IValidateBusinessRuleResponse UpdateCRMCallerRoleAllocationValidate(CRMCallerRoleAllocation item);

        /// <summary>
        /// business rule interface of dalete record of CRMCallerRoleAllocation.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IValidateBusinessRuleResponse DeleteCRMCallerRoleAllocationValidate(CRMCallerRoleAllocation item);
    }
}
