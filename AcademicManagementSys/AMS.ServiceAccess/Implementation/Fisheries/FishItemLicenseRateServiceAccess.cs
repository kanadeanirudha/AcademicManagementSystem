using AMS.Base.DTO;
using AMS.Business.BusinessAction;
using AMS.DTO;

namespace AMS.ServiceAccess
{
    public class FishItemLicenseRateServiceAccess : IFishItemLicenseRateServiceAccess
    {
        IFishItemLicenseRateBA _fishItemLicenseRateBA = null;
        public FishItemLicenseRateServiceAccess()
        {
            _fishItemLicenseRateBA = new FishItemLicenseRateBA();
        }
        public IBaseEntityResponse<FishItemLicenseRate> InsertFishItemLicenseRate(FishItemLicenseRate item)
        {
            return _fishItemLicenseRateBA.InsertFishItemLicenseRate(item);
        }
        public IBaseEntityResponse<FishItemLicenseRate> UpdateFishItemLicenseRate(FishItemLicenseRate item)
        {
            return _fishItemLicenseRateBA.UpdateFishItemLicenseRate(item);
        }
        public IBaseEntityResponse<FishItemLicenseRate> DeleteFishItemLicenseRate(FishItemLicenseRate item)
        {
            return _fishItemLicenseRateBA.DeleteFishItemLicenseRate(item);
        }
        public IBaseEntityCollectionResponse<FishItemLicenseRate> GetBySearch(FishItemLicenseRateSearchRequest searchRequest)
        {
            return _fishItemLicenseRateBA.GetBySearch(searchRequest);
        }
        public IBaseEntityResponse<FishItemLicenseRate> SelectByID(FishItemLicenseRate item)
        {
            return _fishItemLicenseRateBA.SelectByID(item);
        }

        //Service Access for Item Name Search List
        public IBaseEntityCollectionResponse<FishItemLicenseRate> GetItemNameCentrewiseSearchList(FishItemLicenseRateSearchRequest searchRequest)
        {
            return _fishItemLicenseRateBA.GetItemNameCentrewiseSearchList(searchRequest);
        }
    }
}
