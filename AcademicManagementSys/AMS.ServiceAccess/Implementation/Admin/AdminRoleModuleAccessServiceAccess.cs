using AMS.Base.DTO;
using AMS.Business.BusinessAction;
using AMS.DTO;

namespace AMS.ServiceAccess
{
    public class AdminRoleModuleAccessServiceAccess : IAdminRoleModuleAccessServiceAccess
    {
        IAdminRoleModuleAccessBA _adminRoleModuleAccessBA = null;

        public AdminRoleModuleAccessServiceAccess()
        {
            _adminRoleModuleAccessBA = new AdminRoleModuleAccessBA();
        }

        public IBaseEntityResponse<AdminRoleModuleAccess> InsertAdminRoleModuleAccess(AdminRoleModuleAccess item)
        {
            return _adminRoleModuleAccessBA.InsertAdminRoleModuleAccess(item);
        } 

        public IBaseEntityResponse<AdminRoleModuleAccess> UpdateAdminRoleModuleAccess(AdminRoleModuleAccess item)
        {
            return _adminRoleModuleAccessBA.UpdateAdminRoleModuleAccess(item);
        }

        public IBaseEntityResponse<AdminRoleModuleAccess> DeleteAdminRoleModuleAccess(AdminRoleModuleAccess item)
        {
            return _adminRoleModuleAccessBA.DeleteAdminRoleModuleAccess(item);
        }

        public IBaseEntityCollectionResponse<AdminRoleModuleAccess> GetBySearch(AdminRoleModuleAccessSearchRequest searchRequest)
        {
            return _adminRoleModuleAccessBA.GetBySearch(searchRequest);
        }


        public IBaseEntityResponse<AdminRoleModuleAccess> SelectByID(AdminRoleModuleAccess item)
        {
            return _adminRoleModuleAccessBA.SelectByID(item);
        }

        public IBaseEntityResponse<AdminRoleModuleAccess> SelectByAdminRoleMasterID(AdminRoleModuleAccess item)
        {
            return _adminRoleModuleAccessBA.SelectByAdminRoleMasterID(item);
        }

        public IBaseEntityCollectionResponse<AdminRoleModuleAccess> GetAccessibleCentreListByID(AdminRoleModuleAccessSearchRequest searchRequest)
        {
            return _adminRoleModuleAccessBA.GetAccessibleCentreListByID(searchRequest);
        }

        public IBaseEntityCollectionResponse<AdminRoleModuleAccess> GetEntityByID(AdminRoleModuleAccessSearchRequest searchRequest)
        {
            return _adminRoleModuleAccessBA.GetEntityByID(searchRequest);
        }

        public IBaseEntityCollectionResponse<AdminRoleModuleAccess> GetAdminEntityInduvidualListBySearch(AdminRoleModuleAccessSearchRequest searchRequest)
        {
            return _adminRoleModuleAccessBA.GetAdminEntityInduvidualListBySearch(searchRequest);
        }
       
    }
}
