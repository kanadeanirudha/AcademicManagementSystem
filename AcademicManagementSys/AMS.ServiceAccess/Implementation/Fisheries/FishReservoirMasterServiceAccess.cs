using AMS.Base.DTO;
using AMS.Business.BusinessAction;
using AMS.DTO;

namespace AMS.ServiceAccess
{
    public class FishReservoirMasterServiceAccess : IFishReservoirMasterServiceAccess
    {
        IFishReservoirMasterBA _fishReservoirMasterBA = null;
        public FishReservoirMasterServiceAccess()
        {
            _fishReservoirMasterBA = new FishReservoirMasterBA();
        }
        public IBaseEntityResponse<FishReservoirMaster> InsertFishReservoirMaster(FishReservoirMaster item)
        {
            return _fishReservoirMasterBA.InsertFishReservoirMaster(item);
        }
        public IBaseEntityResponse<FishReservoirMaster> UpdateFishReservoirMaster(FishReservoirMaster item)
        {
            return _fishReservoirMasterBA.UpdateFishReservoirMaster(item);
        }
        public IBaseEntityResponse<FishReservoirMaster> DeleteFishReservoirMaster(FishReservoirMaster item)
        {
            return _fishReservoirMasterBA.DeleteFishReservoirMaster(item);
        }
        public IBaseEntityCollectionResponse<FishReservoirMaster> GetBySearch(FishReservoirMasterSearchRequest searchRequest)
        {
            return _fishReservoirMasterBA.GetBySearch(searchRequest);
        }
        public IBaseEntityResponse<FishReservoirMaster> SelectByID(FishReservoirMaster item)
        {
            return _fishReservoirMasterBA.SelectByID(item);
        }
    }
}
