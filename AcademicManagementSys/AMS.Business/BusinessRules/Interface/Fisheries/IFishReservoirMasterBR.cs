using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Business.BusinessRules
{
    public interface IFishReservoirMasterBR
    {
        IValidateBusinessRuleResponse InsertFishReservoirMasterValidate(FishReservoirMaster item);
        IValidateBusinessRuleResponse UpdateFishReservoirMasterValidate(FishReservoirMaster item);
        IValidateBusinessRuleResponse DeleteFishReservoirMasterValidate(FishReservoirMaster item);
    }
}
