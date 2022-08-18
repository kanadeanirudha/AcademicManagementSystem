using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.Business.BusinessRules
{
    public interface IGeneralCityMasterBR
    {

        /// <summary>
        /// business rule interface of insert new record of General City Master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IValidateBusinessRuleResponse InsertGeneralCityMasterValidate(GeneralCityMaster item);

        /// <summary>
        /// business rule interface of update record of General City Master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IValidateBusinessRuleResponse UpdateGeneralCityMasterValidate(GeneralCityMaster item);

        /// <summary>
        /// business rule interface of dalete record of General City Master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IValidateBusinessRuleResponse DeleteGeneralCityMasterValidate(GeneralCityMaster item);
    }
}
