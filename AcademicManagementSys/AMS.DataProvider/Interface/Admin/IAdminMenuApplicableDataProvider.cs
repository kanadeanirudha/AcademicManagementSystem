using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.DataProvider
{
    public interface IAdminMenuApplicableDataProvider
    {
        IBaseEntityCollectionResponse<AdminMenuApplicable> GetAdminMenuApplicableBySearch(AdminMenuApplicableSearchRequest searchRequest);

        IBaseEntityResponse<AdminMenuApplicable> GetAdminMenuApplicableByID(int id);

        IBaseEntityResponse<AdminMenuApplicable> InsertAdminMenuApplicable(AdminMenuApplicable item);

        IBaseEntityResponse<AdminMenuApplicable> UpdateAdminMenuApplicable(AdminMenuApplicable item);

        IBaseEntityResponse<AdminMenuApplicable> DeleteAdminMenuApplicable(AdminMenuApplicable item);
    }
}
