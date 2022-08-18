using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.Business.BusinessRules
{
    public interface IGeneralUnitTypeBR
    {
        /// <summary>
        /// business rule interface of insert new record of GeneralUnitType.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IValidateBusinessRuleResponse InsertGeneralUnitTypeValidate(GeneralUnitType item);

        /// <summary>
        /// business rule interface of update record of GeneralUnitType.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IValidateBusinessRuleResponse UpdateGeneralUnitTypeValidate(GeneralUnitType item);

        /// <summary>
        /// business rule interface of dalete record of GeneralUnitType.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IValidateBusinessRuleResponse DeleteGeneralUnitTypeValidate(GeneralUnitType item);
    }
}

