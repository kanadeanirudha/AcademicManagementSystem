using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.ServiceAccess
{
    public interface IOrganisationMasterServiceAccess
    {
        IBaseEntityResponse<OrganisationMaster> InsertOrganisationMaster(OrganisationMaster item);
        IBaseEntityResponse<OrganisationMaster> UpdateOrganisationMaster(OrganisationMaster item);
        IBaseEntityResponse<OrganisationMaster> DeleteOrganisationMaster(OrganisationMaster item);
        IBaseEntityCollectionResponse<OrganisationMaster> GetBySearch(OrganisationMasterSearchRequest searchRequest);
        IBaseEntityCollectionResponse<OrganisationMaster> GetBySearchList(OrganisationMasterSearchRequest searchRequest);
        IBaseEntityResponse<OrganisationMaster> SelectByID(OrganisationMaster item);
    }
}
