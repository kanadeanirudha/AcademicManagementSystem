using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.ServiceAccess
{
    public interface IUserMasterServiceAccess
    {
        IBaseEntityResponse<UserMaster> InsertUserMaster(UserMaster item);

        IBaseEntityResponse<UserMaster> UpdateUserMaster(UserMaster item);

        IBaseEntityResponse<UserMaster> DeleteUserMaster(UserMaster item);

        IBaseEntityCollectionResponse<UserMaster> GetBySearch(UserMasterSearchRequest searchRequest);

        IBaseEntityResponse<UserMaster> SelectByID(UserMaster item);

        IBaseEntityResponse<UserMaster> SelectByEmailIDPassword(UserMaster item);
        
        IBaseEntityResponse<UserMaster> UserLoginApi(UserMaster item);

        IBaseEntityResponse<UserMaster> UserLogoutApi(UserMaster item);

        IBaseEntityResponse<UserMaster> SelectByEmailID(UserMaster item);

        IBaseEntityCollectionResponse<UserMaster> GetRoleByID(UserMasterSearchRequest searchRequest);

        IBaseEntityCollectionResponse<UserMaster> GetUserType(UserMasterSearchRequest searchRequest);

         IBaseEntityResponse<UserMaster> LogOffByUserID(UserMaster item);

         IBaseEntityCollectionResponse<UserMaster> GetActiveUserBySearch(UserMasterSearchRequest searchRequest);
         IBaseEntityResponse<UserMaster> UserLoginReset(UserMaster item);
    }
}
