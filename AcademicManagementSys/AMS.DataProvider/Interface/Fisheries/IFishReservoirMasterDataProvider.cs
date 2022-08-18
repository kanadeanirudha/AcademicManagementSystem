using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.DataProvider
{
    public interface IFishReservoirMasterDataProvider
    {
        IBaseEntityResponse<FishReservoirMaster> InsertFishReservoirMaster(FishReservoirMaster item);
        IBaseEntityResponse<FishReservoirMaster> UpdateFishReservoirMaster(FishReservoirMaster item);
        IBaseEntityResponse<FishReservoirMaster> DeleteFishReservoirMaster(FishReservoirMaster item);
        IBaseEntityCollectionResponse<FishReservoirMaster> GetFishReservoirMasterBySearch(FishReservoirMasterSearchRequest searchRequest);
        IBaseEntityResponse<FishReservoirMaster> GetFishReservoirMasterByID(FishReservoirMaster item);
    }
}
