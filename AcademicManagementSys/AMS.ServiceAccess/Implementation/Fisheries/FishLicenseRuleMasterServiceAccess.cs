using AMS.Base.DTO;
using AMS.Business.BusinessAction;
using AMS.DTO;

namespace AMS.ServiceAccess
{
    public class FishLicenseRuleMasterServiceAccess : IFishLicenseRuleMasterServiceAccess
    {
        IFishLicenseRuleMasterBA _fishLicenseRuleMasterBA = null;
        public FishLicenseRuleMasterServiceAccess()
        {
            _fishLicenseRuleMasterBA = new FishLicenseRuleMasterBA();
        }
        public IBaseEntityResponse<FishLicenseRuleMaster> InsertFishLicenseRuleMaster(FishLicenseRuleMaster item)
        {
            return _fishLicenseRuleMasterBA.InsertFishLicenseRuleMaster(item);
        }
        public IBaseEntityResponse<FishLicenseRuleMaster> UpdateFishLicenseRuleMaster(FishLicenseRuleMaster item)
        {
            return _fishLicenseRuleMasterBA.UpdateFishLicenseRuleMaster(item);
        }
        public IBaseEntityResponse<FishLicenseRuleMaster> DeleteFishLicenseRuleMaster(FishLicenseRuleMaster item)
        {
            return _fishLicenseRuleMasterBA.DeleteFishLicenseRuleMaster(item);
        }
        public IBaseEntityCollectionResponse<FishLicenseRuleMaster> GetBySearch(FishLicenseRuleMasterSearchRequest searchRequest)
        {
            return _fishLicenseRuleMasterBA.GetBySearch(searchRequest);
        }
        public IBaseEntityResponse<FishLicenseRuleMaster> SelectByID(FishLicenseRuleMaster item)
        {
            return _fishLicenseRuleMasterBA.SelectByID(item);
        }
    }
}
