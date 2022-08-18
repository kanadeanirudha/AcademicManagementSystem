using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.DataProvider
{
    public interface IAdminRoleDetailsDataProvider
    {
        IBaseEntityCollectionResponse<AdminRoleDetails> GetAdminRoleDetailsBySearch(AdminRoleDetailsSearchRequest searchRequest);

        IBaseEntityResponse<AdminRoleDetails> GetAdminRoleDetailsByID(AdminRoleDetails item);

        IBaseEntityResponse<AdminRoleDetails> InsertAdminRoleDetails(AdminRoleDetails item);

        IBaseEntityResponse<AdminRoleDetails> UpdateAdminRoleDetails(AdminRoleDetails item);

        IBaseEntityResponse<AdminRoleDetails> DeleteAdminRoleDetails(AdminRoleDetails item);
    }
}
