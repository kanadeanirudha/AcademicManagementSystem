using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.DataProvider
{
    public interface IAdminRoleMasterDataProvider
    {
        IBaseEntityCollectionResponse<AdminRoleMaster> GetAdminRoleMasterBySearch(AdminRoleMasterSearchRequest searchRequest);

        IBaseEntityResponse<AdminRoleMaster> GetAdminRoleMasterByID(AdminRoleMaster item);

        IBaseEntityResponse<AdminRoleMaster> InsertAdminRoleMaster(AdminRoleMaster item);

        IBaseEntityResponse<AdminRoleMaster> UpdateAdminRoleMaster(AdminRoleMaster item);

        IBaseEntityResponse<AdminRoleMaster> DeleteAdminRoleMaster(AdminRoleMaster item);

        IBaseEntityCollectionResponse<AdminRoleMaster> GetAdminRoleMasterBySearchForAdminRoleDetailsBySPD(AdminRoleMasterSearchRequest searchRequest);

        IBaseEntityCollectionResponse<AdminRoleMaster> GetAdminCentreRightsByRole(AdminRoleMasterSearchRequest searchRequest);
    }
}
