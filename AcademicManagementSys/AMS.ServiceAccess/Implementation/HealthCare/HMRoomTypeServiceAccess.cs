using AMS.Base.DTO;
using AMS.Business.BusinessActions;
using AMS.DTO;

namespace AMS.ServiceAccess
{
    public class HMRoomTypeServiceAccess : IHMRoomTypeServiceAccess
    {
        IHMRoomTypeBA _HMRoomTypeBA = null;
        public HMRoomTypeServiceAccess()
        {
            _HMRoomTypeBA = new HMRoomTypeBA();
        }
        public IBaseEntityResponse<HMRoomType> InsertHMRoomType(HMRoomType item)
        {
            return _HMRoomTypeBA.InsertHMRoomType(item);
        }
        public IBaseEntityResponse<HMRoomType> UpdateHMRoomType(HMRoomType item)
        {
            return _HMRoomTypeBA.UpdateHMRoomType(item);
        }
        public IBaseEntityResponse<HMRoomType> DeleteHMRoomType(HMRoomType item)
        {
            return _HMRoomTypeBA.DeleteHMRoomType(item);
        }
        public IBaseEntityCollectionResponse<HMRoomType> GetBySearch(HMRoomTypeSearchRequest searchRequest)
        {
            return _HMRoomTypeBA.GetBySearch(searchRequest);
        }
        public IBaseEntityCollectionResponse<HMRoomType> GetHMRoomTypeSearchList(HMRoomTypeSearchRequest searchRequest)
        {
            return _HMRoomTypeBA.GetHMRoomTypeSearchList(searchRequest);
        }
        public IBaseEntityResponse<HMRoomType> SelectByID(HMRoomType item)
        {
            return _HMRoomTypeBA.SelectByID(item);
        }
    }
}
