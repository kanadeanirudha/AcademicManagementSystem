using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AMS.ServiceAccess
{
    public interface IFishFishermenMasterServiceAccess
    {
        IBaseEntityResponse<FishFishermenMaster> InsertFishFishermenMaster(FishFishermenMaster item);
        IBaseEntityResponse<FishFishermenMaster> UpdateFishFishermenMaster(FishFishermenMaster item);
        IBaseEntityResponse<FishFishermenMaster> DeleteFishFishermenMaster(FishFishermenMaster item);
        IBaseEntityCollectionResponse<FishFishermenMaster> GetBySearch(FishFishermenMasterSearchRequest searchRequest);
        IBaseEntityResponse<FishFishermenMaster> SelectByID(FishFishermenMaster item);
    }
}
