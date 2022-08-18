using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Business.BusinessAction
{
    public interface IAdminMenuApplicableBA
    {
        IBaseEntityResponse<AdminMenuApplicable> InsertAdminMenuApplicable(AdminMenuApplicable item);

        IBaseEntityResponse<AdminMenuApplicable> UpdateAdminMenuApplicable(AdminMenuApplicable item);

        IBaseEntityResponse<AdminMenuApplicable> DeleteAdminMenuApplicable(AdminMenuApplicable item);

        IBaseEntityCollectionResponse<AdminMenuApplicable> GetBySearch(AdminMenuApplicableSearchRequest searchRequest);
        
    }
}
