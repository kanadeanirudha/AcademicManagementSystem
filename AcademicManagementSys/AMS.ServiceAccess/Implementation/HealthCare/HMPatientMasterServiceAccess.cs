using AMS.Base.DTO;
using AMS.Business.BusinessActions;
using AMS.DTO;

namespace AMS.ServiceAccess
{
    public class HMPatientMasterServiceAccess : IHMPatientMasterServiceAccess
    {
        IHMPatientMasterBA _HMPatientMasterBA = null;
        public HMPatientMasterServiceAccess()
        {
            _HMPatientMasterBA = new HMPatientMasterBA();
        }
        public IBaseEntityResponse<HMPatientMaster> InsertHMPatientMaster(HMPatientMaster item)
        {
            return _HMPatientMasterBA.InsertHMPatientMaster(item);
        }
        public IBaseEntityResponse<HMPatientMaster> UpdateHMPatientMaster(HMPatientMaster item)
        {
            return _HMPatientMasterBA.UpdateHMPatientMaster(item);
        }
        public IBaseEntityResponse<HMPatientMaster> DeleteHMPatientMaster(HMPatientMaster item)
        {
            return _HMPatientMasterBA.DeleteHMPatientMaster(item);
        }
        public IBaseEntityCollectionResponse<HMPatientMaster> GetBySearch(HMPatientMasterSearchRequest searchRequest)
        {
            return _HMPatientMasterBA.GetBySearch(searchRequest);
        }
        public IBaseEntityCollectionResponse<HMPatientMaster> GetHMPatientMasterSearchList(HMPatientMasterSearchRequest searchRequest)
        {
            return _HMPatientMasterBA.GetHMPatientMasterSearchList(searchRequest);
        }
        public IBaseEntityResponse<HMPatientMaster> SelectByID(HMPatientMaster item)
        {
            return _HMPatientMasterBA.SelectByID(item);
        }
        public IBaseEntityCollectionResponse<HMPatientMaster> GetListOfPatient(HMPatientMasterSearchRequest searchRequest)
        {
            return _HMPatientMasterBA.GetListOfPatient(searchRequest);
        }
    }
}
