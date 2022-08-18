using AMS.Base.DTO;
using AMS.Business.BusinessAction;
using AMS.DTO;
namespace AMS.ServiceAccess
{
    public class AdminRoleMenuDetailsServiceAccess : IAdminRoleMenuDetailsServiceAccess
    {
        IAdminRoleMenuDetailsBA _adminRoleMenuDetailsBA = null;
        public AdminRoleMenuDetailsServiceAccess()
        {
            _adminRoleMenuDetailsBA = new AdminRoleMenuDetailsBA();
        }
        public IBaseEntityResponse<AdminRoleMenuDetails> InsertAdminRoleMenuDetails(AdminRoleMenuDetails item)
        {
            return _adminRoleMenuDetailsBA.InsertAdminRoleMenuDetails(item);
        }
        public IBaseEntityResponse<AdminRoleMenuDetails> UpdateAdminRoleMenuDetails(AdminRoleMenuDetails item)
        {
            return _adminRoleMenuDetailsBA.UpdateAdminRoleMenuDetails(item);
        }
        public IBaseEntityResponse<AdminRoleMenuDetails> DeleteAdminRoleMenuDetails(AdminRoleMenuDetails item)
        {
            return _adminRoleMenuDetailsBA.DeleteAdminRoleMenuDetails(item);
        }
        public IBaseEntityCollectionResponse<AdminRoleMenuDetails> GetBySearch(AdminRoleMenuDetailsSearchRequest searchRequest)
        {
            return _adminRoleMenuDetailsBA.GetBySearch(searchRequest);
        }
        public IBaseEntityResponse<AdminRoleMenuDetails> SelectByID(AdminRoleMenuDetails item)
        {
            return _adminRoleMenuDetailsBA.SelectByID(item);
        }
        public IBaseEntityCollectionResponse<AdminRoleMenuDetails> GetBySearchModuleList(AdminRoleMenuDetailsSearchRequest searchRequest)
        {
            return _adminRoleMenuDetailsBA.GetBySearchModuleList(searchRequest);
        }
        public IBaseEntityCollectionResponse<AdminRoleMenuDetails> GetBySearchAdminMenuList(AdminRoleMenuDetailsSearchRequest searchRequest)
        {
            return _adminRoleMenuDetailsBA.GetBySearchAdminMenuList(searchRequest);
        }
    }
}
