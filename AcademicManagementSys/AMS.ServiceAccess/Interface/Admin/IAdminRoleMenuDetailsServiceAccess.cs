using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.ServiceAccess
{
    public interface IAdminRoleMenuDetailsServiceAccess
    {
        IBaseEntityResponse<AdminRoleMenuDetails> InsertAdminRoleMenuDetails(AdminRoleMenuDetails item);
        IBaseEntityResponse<AdminRoleMenuDetails> UpdateAdminRoleMenuDetails(AdminRoleMenuDetails item);
        IBaseEntityResponse<AdminRoleMenuDetails> DeleteAdminRoleMenuDetails(AdminRoleMenuDetails item);
        IBaseEntityCollectionResponse<AdminRoleMenuDetails> GetBySearch(AdminRoleMenuDetailsSearchRequest searchRequest);
        IBaseEntityResponse<AdminRoleMenuDetails> SelectByID(AdminRoleMenuDetails item);
        IBaseEntityCollectionResponse<AdminRoleMenuDetails> GetBySearchModuleList(AdminRoleMenuDetailsSearchRequest searchRequest);
        IBaseEntityCollectionResponse<AdminRoleMenuDetails> GetBySearchAdminMenuList(AdminRoleMenuDetailsSearchRequest searchRequest);
    }
}
