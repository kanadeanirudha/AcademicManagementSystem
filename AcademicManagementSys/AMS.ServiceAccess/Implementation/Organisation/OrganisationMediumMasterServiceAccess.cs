using AMS.Base.DTO;
using AMS.Business.BusinessAction;
using AMS.DTO;
namespace AMS.ServiceAccess
{
    public class OrganisationMediumMasterServiceAccess : IOrganisationMediumMasterServiceAccess
    {
        IOrganisationMediumMasterBA _organisationMediumMasterBA = null;
        public OrganisationMediumMasterServiceAccess()
        {
            _organisationMediumMasterBA = new OrganisationMediumMasterBA();
        }
        public IBaseEntityResponse<OrganisationMediumMaster> InsertOrganisationMediumMaster(OrganisationMediumMaster item)
        {
            return _organisationMediumMasterBA.InsertOrganisationMediumMaster(item);
        }
        public IBaseEntityResponse<OrganisationMediumMaster> UpdateOrganisationMediumMaster(OrganisationMediumMaster item)
        {
            return _organisationMediumMasterBA.UpdateOrganisationMediumMaster(item);
        }
        public IBaseEntityResponse<OrganisationMediumMaster> DeleteOrganisationMediumMaster(OrganisationMediumMaster item)
        {
            return _organisationMediumMasterBA.DeleteOrganisationMediumMaster(item);
        }
        public IBaseEntityCollectionResponse<OrganisationMediumMaster> GetBySearch(OrganisationMediumMasterSearchRequest searchRequest)
        {
            return _organisationMediumMasterBA.GetBySearch(searchRequest);
        }
        public IBaseEntityResponse<OrganisationMediumMaster> SelectByID(OrganisationMediumMaster item)
        {
            return _organisationMediumMasterBA.SelectByID(item);
        }
        public IBaseEntityCollectionResponse<OrganisationMediumMaster> GetBySearchList(OrganisationMediumMasterSearchRequest searchRequest)
        {
            return _organisationMediumMasterBA.GetBySearchList(searchRequest);
        }
    }
}
