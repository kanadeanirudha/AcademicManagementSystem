using AMS.Base.DTO;
using AMS.Business.BusinessActions;
using AMS.DTO;

namespace AMS.ServiceAccess
{
    public class FeeAccountTypeMasterServiceAccess : IFeeAccountTypeMasterServiceAccess
    {
        IFeeAccountTypeMasterBA _FeeAccountTypeMasterBA = null;
        public FeeAccountTypeMasterServiceAccess()
        {
            _FeeAccountTypeMasterBA = new FeeAccountTypeMasterBA();
        }
        public IBaseEntityResponse<FeeAccountTypeMaster> InsertFeeAccountTypeMaster(FeeAccountTypeMaster item)
        {
            return _FeeAccountTypeMasterBA.InsertFeeAccountTypeMaster(item);
        }
        public IBaseEntityResponse<FeeAccountTypeMaster> UpdateFeeAccountTypeMaster(FeeAccountTypeMaster item)
        {
            return _FeeAccountTypeMasterBA.UpdateFeeAccountTypeMaster(item);
        }
        public IBaseEntityResponse<FeeAccountTypeMaster> DeleteFeeAccountTypeMaster(FeeAccountTypeMaster item)
        {
            return _FeeAccountTypeMasterBA.DeleteFeeAccountTypeMaster(item);
        }
        public IBaseEntityCollectionResponse<FeeAccountTypeMaster> GetBySearch(FeeAccountTypeMasterSearchRequest searchRequest)
        {
            return _FeeAccountTypeMasterBA.GetBySearch(searchRequest);
        }
        public IBaseEntityResponse<FeeAccountTypeMaster> SelectByID(FeeAccountTypeMaster item)
        {
            return _FeeAccountTypeMasterBA.SelectByID(item);
        }
        public IBaseEntityCollectionResponse<FeeAccountTypeMaster> GetFeeAccountTypeMasterSearchList(FeeAccountTypeMasterSearchRequest searchRequest)
        {
            return _FeeAccountTypeMasterBA.GetFeeAccountTypeMasterSearchList(searchRequest);
        }
    }
}
