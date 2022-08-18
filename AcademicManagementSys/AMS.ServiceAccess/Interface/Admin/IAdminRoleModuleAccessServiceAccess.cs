using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.ServiceAccess
{
    public interface IAdminRoleModuleAccessServiceAccess 
    {
        IBaseEntityResponse<AdminRoleModuleAccess> InsertAdminRoleModuleAccess(AdminRoleModuleAccess item);

        IBaseEntityResponse<AdminRoleModuleAccess> UpdateAdminRoleModuleAccess(AdminRoleModuleAccess item);

        IBaseEntityResponse<AdminRoleModuleAccess> DeleteAdminRoleModuleAccess(AdminRoleModuleAccess item);

        IBaseEntityCollectionResponse<AdminRoleModuleAccess> GetBySearch(AdminRoleModuleAccessSearchRequest searchRequest);

        IBaseEntityResponse<AdminRoleModuleAccess> SelectByID(AdminRoleModuleAccess item);

        IBaseEntityResponse<AdminRoleModuleAccess> SelectByAdminRoleMasterID(AdminRoleModuleAccess item);//get info from view.VwAdminSnPostsRoleMaster for SpecialRightsForm

        IBaseEntityCollectionResponse<AdminRoleModuleAccess> GetAccessibleCentreListByID(AdminRoleModuleAccessSearchRequest searchRequest);//get list of accessible centre by adminRolemasterID

        IBaseEntityCollectionResponse<AdminRoleModuleAccess> GetEntityByID(AdminRoleModuleAccessSearchRequest searchRequest);//get list of entites  by cnetrecode,monitoring level and entity type

        IBaseEntityCollectionResponse<AdminRoleModuleAccess> GetAdminEntityInduvidualListBySearch(AdminRoleModuleAccessSearchRequest searchRequest); //get

      
    }
}
