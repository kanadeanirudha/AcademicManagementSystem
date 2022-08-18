using AMS.Base.DTO;
using AMS.Business.BusinessAction;
using AMS.DTO;
namespace AMS.ServiceAccess
{
    public class UserMainMenuMasterServiceAccess : IUserMainMenuMasterServiceAccess
    {
        IUserMainMenuMasterBA _userMainMenuMasterBA = null;
        public UserMainMenuMasterServiceAccess()
        {
            _userMainMenuMasterBA = new UserMainMenuMasterBA();
        }
        public IBaseEntityResponse<UserMainMenuMaster> InsertUserMainMenuMaster(UserMainMenuMaster item)
        {
            return _userMainMenuMasterBA.InsertUserMainMenuMaster(item);
        }
        public IBaseEntityResponse<UserMainMenuMaster> UpdateUserMainMenuMaster(UserMainMenuMaster item)
        {
            return _userMainMenuMasterBA.UpdateUserMainMenuMaster(item);
        }
        public IBaseEntityResponse<UserMainMenuMaster> DeleteUserMainMenuMaster(UserMainMenuMaster item)
        {
            return _userMainMenuMasterBA.DeleteUserMainMenuMaster(item);
        }
        public IBaseEntityCollectionResponse<UserMainMenuMaster> GetBySearch(UserMainMenuMasterSearchRequest searchRequest)
        {
            return _userMainMenuMasterBA.GetBySearch(searchRequest);
        }
        public IBaseEntityResponse<UserMainMenuMaster> SelectByID(UserMainMenuMaster item)
        {
            return _userMainMenuMasterBA.SelectByID(item);
        }
        public IBaseEntityCollectionResponse<UserMainMenuMaster> GetByModuleID(UserMainMenuMasterSearchRequest searchRequest)
        {
            return _userMainMenuMasterBA.GetByModuleID(searchRequest);
        }
        public IBaseEntityCollectionResponse<UserMainMenuMaster> GetByModuleCode(UserMainMenuMasterSearchRequest searchRequest)
        {
            return _userMainMenuMasterBA.GetByModuleCode(searchRequest);
        }
        public IBaseEntityCollectionResponse<UserMainMenuMaster> GetParentMenuByModuleID(UserMainMenuMasterSearchRequest searchRequest)
        {
            return _userMainMenuMasterBA.GetParentMenuByModuleID(searchRequest);
        }
        public IBaseEntityCollectionResponse<UserMainMenuMaster> GetCentrewiseMenuListForStudent(UserMainMenuMasterSearchRequest searchRequest)
        {
            return _userMainMenuMasterBA.GetCentrewiseMenuListForStudent(searchRequest);
        }
        
    }
}
