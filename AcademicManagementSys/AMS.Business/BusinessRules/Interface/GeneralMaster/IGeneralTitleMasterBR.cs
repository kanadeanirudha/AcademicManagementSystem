using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.Business.BusinessRules
{
    public interface IGeneralTitleMasterBR
    {
        /// <summary>
        /// business rule interface of insert new record of GeneralTitleMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IValidateBusinessRuleResponse InsertGeneralTitleMasterValidate(GeneralTitleMaster item);

        /// <summary>
        /// business rule interface of update record of GeneralTitleMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IValidateBusinessRuleResponse UpdateGeneralTitleMasterValidate(GeneralTitleMaster item);

        /// <summary>
        /// business rule interface of dalete record of GeneralTitleMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IValidateBusinessRuleResponse DeleteGeneralTitleMasterValidate(GeneralTitleMaster item);
    }
}
