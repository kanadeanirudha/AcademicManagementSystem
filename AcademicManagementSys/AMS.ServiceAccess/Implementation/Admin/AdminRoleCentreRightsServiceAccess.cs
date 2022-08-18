using AMS.Base.DTO;
using AMS.Business.BusinessAction;
using AMS.DTO;

namespace AMS.ServiceAccess
{
    public class AdminRoleCentreRightsServiceAccess : IAdminRoleCentreRightsServiceAccess
    {
        IAdminRoleCentreRightsBA _adminRoleCentreRightsBA = null;

        public AdminRoleCentreRightsServiceAccess()
        {
            _adminRoleCentreRightsBA = new AdminRoleCentreRightsBA();
        }

        public IBaseEntityResponse<AdminRoleCentreRights> InsertAdminRoleCentreRights(AdminRoleCentreRights item)
        {
            return _adminRoleCentreRightsBA.InsertAdminRoleCentreRights(item);
        }

        public IBaseEntityResponse<AdminRoleCentreRights> UpdateAdminRoleCentreRights(AdminRoleCentreRights item)
        {
            return _adminRoleCentreRightsBA.UpdateAdminRoleCentreRights(item);
        }

        public IBaseEntityResponse<AdminRoleCentreRights> DeleteAdminRoleCentreRights(AdminRoleCentreRights item)
        {
            return _adminRoleCentreRightsBA.DeleteAdminRoleCentreRights(item);
        }

        public IBaseEntityCollectionResponse<AdminRoleCentreRights> GetBySearch(AdminRoleCentreRightsSearchRequest searchRequest)
        {
            return _adminRoleCentreRightsBA.GetBySearch(searchRequest);
        }


        public IBaseEntityResponse<AdminRoleCentreRights> SelectByID(AdminRoleCentreRights item)
        {
            return _adminRoleCentreRightsBA.SelectByID(item);
        }

        public IBaseEntityResponse<AdminRoleCentreRights> GetCentreLevelManagerRights(AdminRoleCentreRights item)
        {
            return _adminRoleCentreRightsBA.GetCentreLevelManagerRights(item);
        }
        
    }
}
