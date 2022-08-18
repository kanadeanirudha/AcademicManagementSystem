using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Business.BusinessRules
{
    public interface IGeneralSupplierMasterBR
    {
        /// <summary>
        /// business rule interface of insert new record of account balance sheet master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IValidateBusinessRuleResponse InsertGeneralSupplierMasterValidate(GeneralSupplierMaster item);

        /// <summary>
        /// business rule interface of update record of account balance sheet master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IValidateBusinessRuleResponse UpdateGeneralSupplierMasterValidate(GeneralSupplierMaster item);

        /// <summary>
        /// business rule interface of dalete record of account balance sheet master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IValidateBusinessRuleResponse DeleteGeneralSupplierMasterValidate(GeneralSupplierMaster item);
    }
}
