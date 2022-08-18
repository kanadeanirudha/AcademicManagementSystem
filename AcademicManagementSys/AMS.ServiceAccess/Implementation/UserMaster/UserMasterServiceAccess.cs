using AMS.Base.DTO;
using AMS.Business.BusinessAction;
using AMS.DTO;

namespace AMS.ServiceAccess
{
    public class UserMasterServiceAccess : IUserMasterServiceAccess
    {
        IUserMasterBA _userMasterBA = null;

        public UserMasterServiceAccess()
        {
            _userMasterBA = new UserMasterBA();
        }

        public IBaseEntityResponse<UserMaster> InsertUserMaster(UserMaster item)
        {
            return _userMasterBA.InsertUserMaster(item);
        }

        public IBaseEntityResponse<UserMaster> UpdateUserMaster(UserMaster item)
        {
            return _userMasterBA.UpdateUserMaster(item);
        }

        public IBaseEntityResponse<UserMaster> DeleteUserMaster(UserMaster item)
        {
            return _userMasterBA.DeleteUserMaster(item);
        }

        public IBaseEntityCollectionResponse<UserMaster> GetBySearch(UserMasterSearchRequest searchRequest)
        {
            return _userMasterBA.GetBySearch(searchRequest);
        }


        public IBaseEntityResponse<UserMaster> SelectByID(UserMaster item)
        {
            return _userMasterBA.SelectByID(item);
        }


        public IBaseEntityResponse<UserMaster> SelectByEmailID(UserMaster item)
        {
            return _userMasterBA.SelectByEmailID(item);
        }

        public IBaseEntityResponse<UserMaster> UserLoginApi(UserMaster item)
        {
            return _userMasterBA.UserLoginApi(item);
        }

        public IBaseEntityResponse<UserMaster> UserLogoutApi(UserMaster item)
        {
            return _userMasterBA.UserLogoutApi(item);
        }

        public IBaseEntityCollectionResponse<UserMaster> GetUserType(UserMasterSearchRequest searchRequest)
        {
            return _userMasterBA.GetUserType(searchRequest);
           
        }

        public IBaseEntityResponse<UserMaster> SelectByEmailIDPassword(UserMaster item)
        {
            return _userMasterBA.SelectByEmailIDPassword(item);
        }

        public IBaseEntityCollectionResponse<UserMaster> GetRoleByID(UserMasterSearchRequest searchRequest)
        {
            return _userMasterBA.GetRoleByID(searchRequest);
        }

        public IBaseEntityResponse<UserMaster> LogOffByUserID(UserMaster item)
        {
            return _userMasterBA.LogOffByUserID(item);
        }


        public IBaseEntityCollectionResponse<UserMaster> GetActiveUserBySearch(UserMasterSearchRequest searchRequest)
        {
            return _userMasterBA.GetActiveUserBySearch(searchRequest);
        }
        public IBaseEntityResponse<UserMaster> UserLoginReset(UserMaster item)
        {
            return _userMasterBA.UserLoginReset(item);
        }
    }
}
