using AMS.Base.DTO;
using AMS.Business.BusinessAction;
using AMS.DTO;

namespace AMS.ServiceAccess
{
    public class AdminRoleMasterServiceAccess : IAdminRoleMasterServiceAccess
    {
        IAdminRoleMasterBA _adminRoleMasterBA = null;

        public AdminRoleMasterServiceAccess()
        {
            _adminRoleMasterBA = new AdminRoleMasterBA();
        }

        public IBaseEntityResponse<AdminRoleMaster> InsertAdminRoleMaster(AdminRoleMaster item)
        {
            return _adminRoleMasterBA.InsertAdminRoleMaster(item);
        }

        public IBaseEntityResponse<AdminRoleMaster> UpdateAdminRoleMaster(AdminRoleMaster item)
        {
            return _adminRoleMasterBA.UpdateAdminRoleMaster(item);
        }

        public IBaseEntityResponse<AdminRoleMaster> DeleteAdminRoleMaster(AdminRoleMaster item)
        {
            return _adminRoleMasterBA.DeleteAdminRoleMaster(item);
        }

        public IBaseEntityCollectionResponse<AdminRoleMaster> GetBySearch(AdminRoleMasterSearchRequest searchRequest)
        {
            return _adminRoleMasterBA.GetBySearch(searchRequest);
        }


        public IBaseEntityResponse<AdminRoleMaster> SelectByID(AdminRoleMaster item)
        {
            return _adminRoleMasterBA.SelectByID(item);
        }

        public IBaseEntityCollectionResponse<AdminRoleMaster> GetBySearchForAdminRoleDetailsBySPD(AdminRoleMasterSearchRequest searchRequest)
        {
            return _adminRoleMasterBA.GetBySearchForAdminRoleDetailsBySPD(searchRequest);
        }

        public IBaseEntityCollectionResponse<AdminRoleMaster> GetCentreRightsByRole(AdminRoleMasterSearchRequest searchRequest)
        {
            return _adminRoleMasterBA.GetCentreRightsByRole(searchRequest);
        }
    }
}
