using AMS.Base.DTO;
using AMS.Business.BusinessActions;
using AMS.DTO;

namespace AMS.ServiceAccess
{
    public class HMComfirtTypeServiceAccess : IHMComfirtTypeServiceAccess
    {
        IHMComfirtTypeBA _HMComfirtTypeBA = null;
        public HMComfirtTypeServiceAccess()
        {
            _HMComfirtTypeBA = new HMComfirtTypeBA();
        }
        public IBaseEntityResponse<HMComfirtType> InsertHMComfirtType(HMComfirtType item)
        {
            return _HMComfirtTypeBA.InsertHMComfirtType(item);
        }
        public IBaseEntityResponse<HMComfirtType> UpdateHMComfirtType(HMComfirtType item)
        {
            return _HMComfirtTypeBA.UpdateHMComfirtType(item);
        }
        public IBaseEntityResponse<HMComfirtType> DeleteHMComfirtType(HMComfirtType item)
        {
            return _HMComfirtTypeBA.DeleteHMComfirtType(item);
        }
        public IBaseEntityCollectionResponse<HMComfirtType> GetBySearch(HMComfirtTypeSearchRequest searchRequest)
        {
            return _HMComfirtTypeBA.GetBySearch(searchRequest);
        }
        public IBaseEntityCollectionResponse<HMComfirtType> GetHMComfirtTypeSearchList(HMComfirtTypeSearchRequest searchRequest)
        {
            return _HMComfirtTypeBA.GetHMComfirtTypeSearchList(searchRequest);
        }
        public IBaseEntityResponse<HMComfirtType> SelectByID(HMComfirtType item)
        {
            return _HMComfirtTypeBA.SelectByID(item);
        }
    }
}
