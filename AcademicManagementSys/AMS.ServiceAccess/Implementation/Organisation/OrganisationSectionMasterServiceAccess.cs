using AMS.Base.DTO;
using AMS.Business.BusinessAction;
using AMS.DTO;
namespace AMS.ServiceAccess
{
    public class OrganisationSectionMasterServiceAccess : IOrganisationSectionMasterServiceAccess
    {
        IOrganisationSectionMasterBA _organisationSectionMasterBA = null;
        public OrganisationSectionMasterServiceAccess()
        {
            _organisationSectionMasterBA = new OrganisationSectionMasterBA();
        }
        public IBaseEntityResponse<OrganisationSectionMaster> InsertOrganisationSectionMaster(OrganisationSectionMaster item)
        {
            return _organisationSectionMasterBA.InsertOrganisationSectionMaster(item);
        }
        public IBaseEntityResponse<OrganisationSectionMaster> UpdateOrganisationSectionMaster(OrganisationSectionMaster item)
        {
            return _organisationSectionMasterBA.UpdateOrganisationSectionMaster(item);
        }
        public IBaseEntityResponse<OrganisationSectionMaster> DeleteOrganisationSectionMaster(OrganisationSectionMaster item)
        {
            return _organisationSectionMasterBA.DeleteOrganisationSectionMaster(item);
        }
        public IBaseEntityCollectionResponse<OrganisationSectionMaster> GetBySearch(OrganisationSectionMasterSearchRequest searchRequest)
        {
            return _organisationSectionMasterBA.GetBySearch(searchRequest);
        }
        public IBaseEntityResponse<OrganisationSectionMaster> SelectByID(OrganisationSectionMaster item)
        {
            return _organisationSectionMasterBA.SelectByID(item);
        }

        public IBaseEntityCollectionResponse<OrganisationSectionMaster> GetBySearchList(OrganisationSectionMasterSearchRequest searchRequest)
        {
            return _organisationSectionMasterBA.GetBySearchList(searchRequest);
        }
    }
}
