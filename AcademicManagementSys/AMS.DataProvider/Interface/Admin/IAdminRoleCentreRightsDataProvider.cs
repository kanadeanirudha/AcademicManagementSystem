using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.DataProvider
{
    public interface IAdminRoleCentreRightsDataProvider
    {
        IBaseEntityCollectionResponse<AdminRoleCentreRights> GetAdminRoleCentreRightsBySearch(AdminRoleCentreRightsSearchRequest searchRequest);

        IBaseEntityResponse<AdminRoleCentreRights> GetAdminRoleCentreRightsByID(AdminRoleCentreRights item);

        IBaseEntityResponse<AdminRoleCentreRights> InsertAdminRoleCentreRights(AdminRoleCentreRights item);

        IBaseEntityResponse<AdminRoleCentreRights> UpdateAdminRoleCentreRights(AdminRoleCentreRights item);

        IBaseEntityResponse<AdminRoleCentreRights> DeleteAdminRoleCentreRights(AdminRoleCentreRights item);

        IBaseEntityResponse<AdminRoleCentreRights> GetCentreLevelManagerRights(AdminRoleCentreRights item);        
    }
}
