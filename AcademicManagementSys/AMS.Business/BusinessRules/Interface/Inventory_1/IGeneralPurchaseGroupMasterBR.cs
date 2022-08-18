using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Business.BusinessRules
{
    public interface IGeneralPurchaseGroupMasterBR
    {
        IValidateBusinessRuleResponse InsertGeneralPurchaseGroupMasterValidate(GeneralPurchaseGroupMaster item);
        IValidateBusinessRuleResponse UpdateGeneralPurchaseGroupMasterValidate(GeneralPurchaseGroupMaster item);
        IValidateBusinessRuleResponse DeleteGeneralPurchaseGroupMasterValidate(GeneralPurchaseGroupMaster item);
    }
}
