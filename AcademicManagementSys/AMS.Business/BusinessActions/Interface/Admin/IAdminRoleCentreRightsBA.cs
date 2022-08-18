using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Business.BusinessAction
{
    public interface IAdminRoleCentreRightsBA
    {
        IBaseEntityResponse<AdminRoleCentreRights> InsertAdminRoleCentreRights(AdminRoleCentreRights item);

        IBaseEntityResponse<AdminRoleCentreRights> UpdateAdminRoleCentreRights(AdminRoleCentreRights item);

        IBaseEntityResponse<AdminRoleCentreRights> DeleteAdminRoleCentreRights(AdminRoleCentreRights item);

        IBaseEntityCollectionResponse<AdminRoleCentreRights> GetBySearch(AdminRoleCentreRightsSearchRequest searchRequest);

        IBaseEntityResponse<AdminRoleCentreRights> SelectByID(AdminRoleCentreRights item);

        IBaseEntityResponse<AdminRoleCentreRights> GetCentreLevelManagerRights(AdminRoleCentreRights item);         
    }
}
