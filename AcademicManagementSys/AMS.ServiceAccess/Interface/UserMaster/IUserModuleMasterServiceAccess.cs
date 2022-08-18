using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.ServiceAccess
{
    public interface IUserModuleMasterServiceAccess
    {
        IBaseEntityResponse<UserModuleMaster> InsertUserModuleMaster(UserModuleMaster item);
        IBaseEntityResponse<UserModuleMaster> UpdateUserModuleMaster(UserModuleMaster item);
        IBaseEntityResponse<UserModuleMaster> DeleteUserModuleMaster(UserModuleMaster item);
        IBaseEntityCollectionResponse<UserModuleMaster> GetBySearch(UserModuleMasterSearchRequest searchRequest);
        IBaseEntityResponse<UserModuleMaster> SelectByID(UserModuleMaster item);
        IBaseEntityCollectionResponse<UserModuleMaster> GetModuleListForLoginUserIDByRoleID(UserModuleMasterSearchRequest searchRequest);
        IBaseEntityCollectionResponse<UserModuleMaster> GetModuleListForAdmin(UserModuleMasterSearchRequest searchRequest);
        IBaseEntityCollectionResponse<UserModuleMaster> GetUserModuleList(UserModuleMasterSearchRequest searchRequest);
    } 
}
