using AMS.Base.DTO;
using AMS.Business.BusinessActions;
using AMS.DTO;

namespace AMS.ServiceAccess
{
    public class HMConsultantTypeMasterServiceAccess : IHMConsultantTypeMasterServiceAccess
    {
        IHMConsultantTypeMasterBA _HMConsultantTypeMasterBA = null;
        public HMConsultantTypeMasterServiceAccess()
        {
            _HMConsultantTypeMasterBA = new HMConsultantTypeMasterBA();
        }
        public IBaseEntityResponse<HMConsultantTypeMaster> InsertHMConsultantTypeMaster(HMConsultantTypeMaster item)
        {
            return _HMConsultantTypeMasterBA.InsertHMConsultantTypeMaster(item);
        }
        public IBaseEntityResponse<HMConsultantTypeMaster> UpdateHMConsultantTypeMaster(HMConsultantTypeMaster item)
        {
            return _HMConsultantTypeMasterBA.UpdateHMConsultantTypeMaster(item);
        }
        public IBaseEntityResponse<HMConsultantTypeMaster> DeleteHMConsultantTypeMaster(HMConsultantTypeMaster item)
        {
            return _HMConsultantTypeMasterBA.DeleteHMConsultantTypeMaster(item);
        }
        public IBaseEntityCollectionResponse<HMConsultantTypeMaster> GetBySearch(HMConsultantTypeMasterSearchRequest searchRequest)
        {
            return _HMConsultantTypeMasterBA.GetBySearch(searchRequest);
        }
        public IBaseEntityCollectionResponse<HMConsultantTypeMaster> GetHMConsultantTypeMasterSearchList(HMConsultantTypeMasterSearchRequest searchRequest)
        {
            return _HMConsultantTypeMasterBA.GetHMConsultantTypeMasterSearchList(searchRequest);
        }
        public IBaseEntityResponse<HMConsultantTypeMaster> SelectByID(HMConsultantTypeMaster item)
        {
            return _HMConsultantTypeMasterBA.SelectByID(item);
        }
        public IBaseEntityCollectionResponse<HMConsultantTypeMaster> GetConsultantTypeList(HMConsultantTypeMasterSearchRequest searchRequest)
        {
            return _HMConsultantTypeMasterBA.GetConsultantTypeList(searchRequest);
        }
    }
}
