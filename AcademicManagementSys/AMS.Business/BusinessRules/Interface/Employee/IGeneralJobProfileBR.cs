using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.Business.BusinessRules
{
    public interface IGeneralJobProfileBR
    {

        /// <summary>
        /// business rule interface of insert new record of GeneralJobProfile.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IValidateBusinessRuleResponse InsertGeneralJobProfileValidate(GeneralJobProfile item);

        /// <summary>
        /// business rule interface of update record of GeneralJobProfile.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IValidateBusinessRuleResponse UpdateGeneralJobProfileValidate(GeneralJobProfile item);

        /// <summary>
        /// business rule interface of dalete record of GeneralJobProfile.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IValidateBusinessRuleResponse DeleteGeneralJobProfileValidate(GeneralJobProfile item);
    }
}
