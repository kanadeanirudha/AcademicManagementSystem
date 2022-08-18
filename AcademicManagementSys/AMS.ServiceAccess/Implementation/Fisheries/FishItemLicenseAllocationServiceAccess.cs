using AMS.Base.DTO;
using AMS.Business.BusinessAction;
using AMS.DTO;

namespace AMS.ServiceAccess
{
    public class FishItemLicenseAllocationServiceAccess : IFishItemLicenseAllocationServiceAccess
    {
        IFishItemLicenseAllocationBA _fishItemLicenseAllocationBA = null;
        public FishItemLicenseAllocationServiceAccess()
        {
            _fishItemLicenseAllocationBA = new FishItemLicenseAllocationBA();
        }
        public IBaseEntityResponse<FishItemLicenseAllocation> InsertFishItemLicenseAllocation(FishItemLicenseAllocation item)
        {
            return _fishItemLicenseAllocationBA.InsertFishItemLicenseAllocation(item);
        }
        public IBaseEntityResponse<FishItemLicenseAllocation> UpdateFishItemLicenseAllocation(FishItemLicenseAllocation item)
        {
            return _fishItemLicenseAllocationBA.UpdateFishItemLicenseAllocation(item);
        }
        public IBaseEntityResponse<FishItemLicenseAllocation> DeleteFishItemLicenseAllocation(FishItemLicenseAllocation item)
        {
            return _fishItemLicenseAllocationBA.DeleteFishItemLicenseAllocation(item);
        }
        public IBaseEntityCollectionResponse<FishItemLicenseAllocation> GetBySearch(FishItemLicenseAllocationSearchRequest searchRequest)
        {
            return _fishItemLicenseAllocationBA.GetBySearch(searchRequest);
        }
        public IBaseEntityResponse<FishItemLicenseAllocation> SelectByID(FishItemLicenseAllocation item)
        {
            return _fishItemLicenseAllocationBA.SelectByID(item);
        }
    }
}
