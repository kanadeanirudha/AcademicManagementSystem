using AMS.Base.DTO;
using AMS.Business.BusinessAction;
using AMS.DTO;

namespace AMS.ServiceAccess
{
    public class AdminRoleDetailsServiceAccess : IAdminRoleDetailsServiceAccess
    {
        IAdminRoleDetailsBA _adminRoleDetailsBA = null;

        public AdminRoleDetailsServiceAccess()
        {
            _adminRoleDetailsBA = new AdminRoleDetailsBA();
        }

        public IBaseEntityResponse<AdminRoleDetails> InsertAdminRoleDetails(AdminRoleDetails item)
        {
            return _adminRoleDetailsBA.InsertAdminRoleDetails(item);
        }

        public IBaseEntityResponse<AdminRoleDetails> UpdateAdminRoleDetails(AdminRoleDetails item)
        {
            return _adminRoleDetailsBA.UpdateAdminRoleDetails(item);
        }

        public IBaseEntityResponse<AdminRoleDetails> DeleteAdminRoleDetails(AdminRoleDetails item)
        {
            return _adminRoleDetailsBA.DeleteAdminRoleDetails(item);
        }

        public IBaseEntityCollectionResponse<AdminRoleDetails> GetBySearch(AdminRoleDetailsSearchRequest searchRequest)
        {
            return _adminRoleDetailsBA.GetBySearch(searchRequest);
        }


        public IBaseEntityResponse<AdminRoleDetails> SelectByID(AdminRoleDetails item)
        {
            return _adminRoleDetailsBA.SelectByID(item);
        }
    }
}
