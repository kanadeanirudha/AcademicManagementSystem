using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.Business.BusinessRules
{
    public interface IGeneralRunningNumbersForAccountBR
    {
        /// <summary>
        /// business rule interface of insert new record of GeneralRunningNumbersForAccount.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IValidateBusinessRuleResponse InsertGeneralRunningNumbersForAccountValidate(GeneralRunningNumbersForAccount item);

        /// <summary>
        /// business rule interface of update record of GeneralRunningNumbersForAccount.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IValidateBusinessRuleResponse UpdateGeneralRunningNumbersForAccountValidate(GeneralRunningNumbersForAccount item);

        /// <summary>
        /// business rule interface of dalete record of GeneralRunningNumbersForAccount.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IValidateBusinessRuleResponse DeleteGeneralRunningNumbersForAccountValidate(GeneralRunningNumbersForAccount item);
    }
}

