using AMS.Base.DTO;
using AMS.Business.BusinessActions;
using AMS.DTO;

namespace AMS.ServiceAccess
{
    public class HMIPDTypeServiceAccess : IHMIPDTypeServiceAccess
    {
        IHMIPDTypeBA _HMIPDTypeBA = null;
        public HMIPDTypeServiceAccess()
        {
            _HMIPDTypeBA = new HMIPDTypeBA();
        }
        public IBaseEntityResponse<HMIPDType> InsertHMIPDType(HMIPDType item)
        {
            return _HMIPDTypeBA.InsertHMIPDType(item);
        }
        public IBaseEntityResponse<HMIPDType> UpdateHMIPDType(HMIPDType item)
        {
            return _HMIPDTypeBA.UpdateHMIPDType(item);
        }
        public IBaseEntityResponse<HMIPDType> DeleteHMIPDType(HMIPDType item)
        {
            return _HMIPDTypeBA.DeleteHMIPDType(item);
        }
        public IBaseEntityCollectionResponse<HMIPDType> GetBySearch(HMIPDTypeSearchRequest searchRequest)
        {
            return _HMIPDTypeBA.GetBySearch(searchRequest);
        }
        public IBaseEntityCollectionResponse<HMIPDType> GetHMIPDTypeSearchList(HMIPDTypeSearchRequest searchRequest)
        {
            return _HMIPDTypeBA.GetHMIPDTypeSearchList(searchRequest);
        }
        public IBaseEntityResponse<HMIPDType> SelectByID(HMIPDType item)
        {
            return _HMIPDTypeBA.SelectByID(item);
        }
        public IBaseEntityCollectionResponse<HMIPDType> GetIPDTypeList(HMIPDTypeSearchRequest searchRequest)
        {
            return _HMIPDTypeBA.GetIPDTypeList(searchRequest);
        }
    }
}
