using AMS.Base.DTO;
using AMS.Business.BusinessAction;
using AMS.DTO;
namespace AMS.ServiceAccess
{
    public class LeaveMasterServiceAccess : ILeaveMasterServiceAccess
    {
        ILeaveMasterBA _leaveMasterBA = null;
        public LeaveMasterServiceAccess()
        {
            _leaveMasterBA = new LeaveMasterBA();
        }
        public IBaseEntityResponse<LeaveMaster> InsertLeaveMaster(LeaveMaster item)
        {
            return _leaveMasterBA.InsertLeaveMaster(item);
        }
        public IBaseEntityResponse<LeaveMaster> UpdateLeaveMaster(LeaveMaster item)
        {
            return _leaveMasterBA.UpdateLeaveMaster(item);
        }
        public IBaseEntityResponse<LeaveMaster> DeleteLeaveMaster(LeaveMaster item)
        {
            return _leaveMasterBA.DeleteLeaveMaster(item);
        }
        public IBaseEntityCollectionResponse<LeaveMaster> GetBySearch(LeaveMasterSearchRequest searchRequest)
        {
            return _leaveMasterBA.GetBySearch(searchRequest);
        }
        public IBaseEntityResponse<LeaveMaster> SelectByID(LeaveMaster item)
        {
            return _leaveMasterBA.SelectByID(item);
        }
        public IBaseEntityCollectionResponse<LeaveMaster> GetBySearchList(LeaveMasterSearchRequest searchRequest)
        {
            return _leaveMasterBA.GetBySearchList(searchRequest);
        }
    }
}
