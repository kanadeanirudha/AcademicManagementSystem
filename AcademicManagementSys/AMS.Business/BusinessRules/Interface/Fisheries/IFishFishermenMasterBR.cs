using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Business.BusinessRules
{
    public interface IFishFishermenMasterBR
    {
        IValidateBusinessRuleResponse InsertFishFishermenMasterValidate(FishFishermenMaster item);
        IValidateBusinessRuleResponse UpdateFishFishermenMasterValidate(FishFishermenMaster item);
        IValidateBusinessRuleResponse DeleteFishFishermenMasterValidate(FishFishermenMaster item);
    }
}
