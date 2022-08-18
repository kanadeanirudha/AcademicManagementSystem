using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.ServiceAccess
{
    public interface IOrganisationSectionMasterServiceAccess
    {
        IBaseEntityResponse<OrganisationSectionMaster> InsertOrganisationSectionMaster(OrganisationSectionMaster item);
        IBaseEntityResponse<OrganisationSectionMaster> UpdateOrganisationSectionMaster(OrganisationSectionMaster item);
        IBaseEntityResponse<OrganisationSectionMaster> DeleteOrganisationSectionMaster(OrganisationSectionMaster item);
        IBaseEntityCollectionResponse<OrganisationSectionMaster> GetBySearch(OrganisationSectionMasterSearchRequest searchRequest);
        IBaseEntityResponse<OrganisationSectionMaster> SelectByID(OrganisationSectionMaster item);
        IBaseEntityCollectionResponse<OrganisationSectionMaster> GetBySearchList(OrganisationSectionMasterSearchRequest searchRequest);
    }
}
