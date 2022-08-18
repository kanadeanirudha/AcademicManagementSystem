using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Business.BusinessAction
{
    public interface IFishReservoirMasterBA
    {
        IBaseEntityResponse<FishReservoirMaster> InsertFishReservoirMaster(FishReservoirMaster item);
        IBaseEntityResponse<FishReservoirMaster> UpdateFishReservoirMaster(FishReservoirMaster item);
        IBaseEntityResponse<FishReservoirMaster> DeleteFishReservoirMaster(FishReservoirMaster item);
        IBaseEntityCollectionResponse<FishReservoirMaster> GetBySearch(FishReservoirMasterSearchRequest searchRequest);
        IBaseEntityResponse<FishReservoirMaster> SelectByID(FishReservoirMaster item);
    }
}
