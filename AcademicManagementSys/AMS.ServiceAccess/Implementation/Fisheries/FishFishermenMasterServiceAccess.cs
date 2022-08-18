using AMS.Base.DTO;
using AMS.Business.BusinessAction;
using AMS.DTO;

namespace AMS.ServiceAccess
{
    public class FishFishermenMasterServiceAccess : IFishFishermenMasterServiceAccess
    {
        IFishFishermenMasterBA _fishFishermenMasterBA = null;
        public FishFishermenMasterServiceAccess()
        {
            _fishFishermenMasterBA = new FishFishermenMasterBA();
        }
        public IBaseEntityResponse<FishFishermenMaster> InsertFishFishermenMaster(FishFishermenMaster item)
        {
            return _fishFishermenMasterBA.InsertFishFishermenMaster(item);
        }
        public IBaseEntityResponse<FishFishermenMaster> UpdateFishFishermenMaster(FishFishermenMaster item)
        {
            return _fishFishermenMasterBA.UpdateFishFishermenMaster(item);
        }
        public IBaseEntityResponse<FishFishermenMaster> DeleteFishFishermenMaster(FishFishermenMaster item)
        {
            return _fishFishermenMasterBA.DeleteFishFishermenMaster(item);
        }
        public IBaseEntityCollectionResponse<FishFishermenMaster> GetBySearch(FishFishermenMasterSearchRequest searchRequest)
        {
            return _fishFishermenMasterBA.GetBySearch(searchRequest);
        }
        public IBaseEntityResponse<FishFishermenMaster> SelectByID(FishFishermenMaster item)
        {
            return _fishFishermenMasterBA.SelectByID(item);
        }
    }
}
