using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.ServiceAccess
{
    public interface IOrganisationStreamMasterServiceAccess
    {
        IBaseEntityResponse<OrganisationStreamMaster> InsertOrganisationStreamMaster(OrganisationStreamMaster item);

        IBaseEntityResponse<OrganisationStreamMaster> UpdateOrganisationStreamMaster(OrganisationStreamMaster item);

        IBaseEntityResponse<OrganisationStreamMaster> DeleteOrganisationStreamMaster(OrganisationStreamMaster item);

        IBaseEntityCollectionResponse<OrganisationStreamMaster> GetBySearch(OrganisationStreamMasterSearchRequest searchRequest);
        IBaseEntityCollectionResponse<OrganisationStreamMaster> GetBySearchList(OrganisationStreamMasterSearchRequest searchRequest);
        IBaseEntityResponse<OrganisationStreamMaster> SelectByID(OrganisationStreamMaster item);
    }
}
