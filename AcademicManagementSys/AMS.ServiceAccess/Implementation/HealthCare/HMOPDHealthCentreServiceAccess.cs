using AMS.Base.DTO;
using AMS.Business.BusinessActions;
using AMS.DTO;

namespace AMS.ServiceAccess
{
    public class HMOPDHealthCentreServiceAccess : IHMOPDHealthCentreServiceAccess
    {
        IHMOPDHealthCentreBA _HMOPDHealthCentreBA = null;
        public HMOPDHealthCentreServiceAccess()
        {
            _HMOPDHealthCentreBA = new HMOPDHealthCentreBA();
        }
        public IBaseEntityResponse<HMOPDHealthCentre> InsertHMOPDHealthCentre(HMOPDHealthCentre item)
        {
            return _HMOPDHealthCentreBA.InsertHMOPDHealthCentre(item);
        }
        public IBaseEntityResponse<HMOPDHealthCentre> UpdateHMOPDHealthCentre(HMOPDHealthCentre item)
        {
            return _HMOPDHealthCentreBA.UpdateHMOPDHealthCentre(item);
        }
        public IBaseEntityResponse<HMOPDHealthCentre> DeleteHMOPDHealthCentre(HMOPDHealthCentre item)
        {
            return _HMOPDHealthCentreBA.DeleteHMOPDHealthCentre(item);
        }
        public IBaseEntityCollectionResponse<HMOPDHealthCentre> GetBySearch(HMOPDHealthCentreSearchRequest searchRequest)
        {
            return _HMOPDHealthCentreBA.GetBySearch(searchRequest);
        }
        public IBaseEntityCollectionResponse<HMOPDHealthCentre> GetHMOPDHealthCentreSearchList(HMOPDHealthCentreSearchRequest searchRequest)
        {
            return _HMOPDHealthCentreBA.GetHMOPDHealthCentreSearchList(searchRequest);
        }
        public IBaseEntityResponse<HMOPDHealthCentre> SelectByID(HMOPDHealthCentre item)
        {
            return _HMOPDHealthCentreBA.SelectByID(item);
        }
        public IBaseEntityCollectionResponse<HMOPDHealthCentre> GetListHMOPDHealthCentre(HMOPDHealthCentreSearchRequest searchRequest)
        {
            return _HMOPDHealthCentreBA.GetListHMOPDHealthCentre(searchRequest);
        }
    }
}
