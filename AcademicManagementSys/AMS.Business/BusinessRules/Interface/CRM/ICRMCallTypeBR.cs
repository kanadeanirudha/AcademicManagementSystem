using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.Business.BusinessRules
{
    public interface ICRMCallTypeBR
    {
        /// <summary>
        /// business rule interface of insert new record of CRMCallType.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IValidateBusinessRuleResponse InsertCRMCallTypeValidate(CRMCallType item);

        /// <summary>
        /// business rule interface of update record of CRMCallType.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IValidateBusinessRuleResponse UpdateCRMCallTypeValidate(CRMCallType item);

        /// <summary>
        /// business rule interface of dalete record of CRMCallType.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IValidateBusinessRuleResponse DeleteCRMCallTypeValidate(CRMCallType item);
    }
}
