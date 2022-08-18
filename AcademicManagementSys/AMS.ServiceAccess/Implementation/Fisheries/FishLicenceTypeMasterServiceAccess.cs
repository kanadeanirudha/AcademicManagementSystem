using AMS.Base.DTO;
using AMS.Business.BusinessAction;
using AMS.DTO;

namespace AMS.ServiceAccess
{
    public class FishLicenseTypeServiceAccess : IFishLicenseTypeServiceAccess
    {
        IFishLicenseTypeBA _fishLicenseTypeBA = null;
        public FishLicenseTypeServiceAccess()
        {
            _fishLicenseTypeBA = new FishLicenseTypeBA();
        }
        public IBaseEntityResponse<FishLicenseType> InsertFishLicenseType(FishLicenseType item)
        {
            return _fishLicenseTypeBA.InsertFishLicenseType(item);
        }
        public IBaseEntityResponse<FishLicenseType> UpdateFishLicenseType(FishLicenseType item)
        {
            return _fishLicenseTypeBA.UpdateFishLicenseType(item);
        }
        public IBaseEntityResponse<FishLicenseType> DeleteFishLicenseType(FishLicenseType item)
        {
            return _fishLicenseTypeBA.DeleteFishLicenseType(item);
        }
        public IBaseEntityCollectionResponse<FishLicenseType> GetBySearch(FishLicenseTypeSearchRequest searchRequest)
        {
            return _fishLicenseTypeBA.GetBySearch(searchRequest);
        }
        public IBaseEntityResponse<FishLicenseType> SelectByID(FishLicenseType item)
        {
            return _fishLicenseTypeBA.SelectByID(item);
        }


        public IBaseEntityCollectionResponse<FishLicenseType> GetBySearchList(FishLicenseTypeSearchRequest searchRequest)
        {
            return _fishLicenseTypeBA.GetBySearchList(searchRequest);
        }
    }
}
