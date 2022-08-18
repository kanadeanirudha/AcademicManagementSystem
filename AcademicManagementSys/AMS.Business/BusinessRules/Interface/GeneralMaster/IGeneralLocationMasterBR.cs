using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.Business.BusinessRules
{
    public interface IGeneralLocationMasterBR
    {
        /// <summary>
        /// business rule interface of insert new record of General Location Master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IValidateBusinessRuleResponse InsertGeneralLocationMasterValidate(GeneralLocationMaster item);

        /// <summary>
        /// business rule interface of update record of General Location Master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IValidateBusinessRuleResponse UpdateGeneralLocationMasterValidate(GeneralLocationMaster item);

        /// <summary>
        /// business rule interface of dalete record of General Location Master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IValidateBusinessRuleResponse DeleteGeneralLocationMasterValidate(GeneralLocationMaster item);
    }
}

