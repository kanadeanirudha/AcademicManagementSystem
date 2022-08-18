using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.Business.BusinessRules
{
    public interface ICRMCallMasterAndDetailsBR
    {
        /// <summary>
        /// business rule interface of insert new record of CRMCallMasterAndDetails.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IValidateBusinessRuleResponse InsertCRMCallMasterAndDetailsValidate(CRMCallMasterAndDetails item);

        /// <summary>
        /// business rule interface of update record of CRMCallMasterAndDetails.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IValidateBusinessRuleResponse UpdateCRMCallMasterAndDetailsValidate(CRMCallMasterAndDetails item);

        /// <summary>
        /// business rule interface of dalete record of CRMCallMasterAndDetails.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IValidateBusinessRuleResponse DeleteCRMCallMasterAndDetailsValidate(CRMCallMasterAndDetails item);
    }
}

