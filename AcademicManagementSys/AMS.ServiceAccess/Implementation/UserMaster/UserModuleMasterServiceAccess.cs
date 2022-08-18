using AMS.Base.DTO;
using AMS.Business.BusinessAction;
using AMS.DTO;

namespace AMS.ServiceAccess
{
    public class UserModuleMasterServiceAccess : IUserModuleMasterServiceAccess
    {
        IUserModuleMasterBA _userModuleMasterBA = null;
        public UserModuleMasterServiceAccess()
        {
            _userModuleMasterBA = new UserModuleMasterBA();
        }
        public IBaseEntityResponse<UserModuleMaster> InsertUserModuleMaster(UserModuleMaster item)
        {
            return _userModuleMasterBA.InsertUserModuleMaster(item);
        }
        public IBaseEntityResponse<UserModuleMaster> UpdateUserModuleMaster(UserModuleMaster item)
        {
            return _userModuleMasterBA.UpdateUserModuleMaster(item);
        }
        public IBaseEntityResponse<UserModuleMaster> DeleteUserModuleMaster(UserModuleMaster item)
        {
            return _userModuleMasterBA.DeleteUserModuleMaster(item);
        }
        public IBaseEntityCollectionResponse<UserModuleMaster> GetBySearch(UserModuleMasterSearchRequest searchRequest)
        {
            return _userModuleMasterBA.GetBySearch(searchRequest);
        }
        public IBaseEntityResponse<UserModuleMaster> SelectByID(UserModuleMaster item)
        {
            return _userModuleMasterBA.SelectByID(item);
        }

        public IBaseEntityCollectionResponse<UserModuleMaster> GetModuleListForLoginUserIDByRoleID(UserModuleMasterSearchRequest searchRequest)
        {
            return _userModuleMasterBA.GetModuleListForLoginUserIDByRoleID(searchRequest);
        }

        public IBaseEntityCollectionResponse<UserModuleMaster> GetModuleListForAdmin(UserModuleMasterSearchRequest searchRequest)
        {
            return _userModuleMasterBA.GetModuleListForAdmin(searchRequest);
        }
       
      
          public IBaseEntityCollectionResponse<UserModuleMaster> GetUserModuleList(UserModuleMasterSearchRequest searchRequest)
        {
            return _userModuleMasterBA.GetUserModuleList(searchRequest);
        }
       
    }
}
