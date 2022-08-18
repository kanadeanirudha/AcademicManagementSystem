using AMS.Base.DTO;
using AMS.Business.BusinessActions;
using AMS.DTO;

namespace AMS.ServiceAccess
{
    public class HMConsultantMasterServiceAccess : IHMConsultantMasterServiceAccess
    {
        IHMConsultantMasterBA _HMConsultantMasterBA = null;
        public HMConsultantMasterServiceAccess()
        {
            _HMConsultantMasterBA = new HMConsultantMasterBA();
        }
        public IBaseEntityResponse<HMConsultantMaster> InsertHMConsultantMaster(HMConsultantMaster item)
        {
            return _HMConsultantMasterBA.InsertHMConsultantMaster(item);
        }
        public IBaseEntityResponse<HMConsultantMaster> UpdateHMConsultantMaster(HMConsultantMaster item)
        {
            return _HMConsultantMasterBA.UpdateHMConsultantMaster(item);
        }
        public IBaseEntityResponse<HMConsultantMaster> DeleteHMConsultantMaster(HMConsultantMaster item)
        {
            return _HMConsultantMasterBA.DeleteHMConsultantMaster(item);
        }
        public IBaseEntityCollectionResponse<HMConsultantMaster> GetBySearch(HMConsultantMasterSearchRequest searchRequest)
        {
            return _HMConsultantMasterBA.GetBySearch(searchRequest);
        }
        public IBaseEntityCollectionResponse<HMConsultantMaster> GetHMConsultantMasterSearchList(HMConsultantMasterSearchRequest searchRequest)
        {
            return _HMConsultantMasterBA.GetHMConsultantMasterSearchList(searchRequest);
        }
        public IBaseEntityResponse<HMConsultantMaster> SelectByID(HMConsultantMaster item)
        {
            return _HMConsultantMasterBA.SelectByID(item);
        }
    }
}
