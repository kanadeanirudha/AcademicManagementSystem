using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.DataProvider
{
    public interface IFishFishermenMasterDataProvider
    {
        IBaseEntityResponse<FishFishermenMaster> InsertFishFishermenMaster(FishFishermenMaster item);
        IBaseEntityResponse<FishFishermenMaster> UpdateFishFishermenMaster(FishFishermenMaster item);
        IBaseEntityResponse<FishFishermenMaster> DeleteFishFishermenMaster(FishFishermenMaster item);
        IBaseEntityCollectionResponse<FishFishermenMaster> GetFishFishermenMasterBySearch(FishFishermenMasterSearchRequest searchRequest);
        IBaseEntityResponse<FishFishermenMaster> GetFishFishermenMasterByID(FishFishermenMaster item);
    }
}

