using AMS.Base.DTO;
using AMS.Business.BusinessAction;
using AMS.DTO;
namespace AMS.ServiceAccess
{
    public class OrganisationMasterServiceAccess : IOrganisationMasterServiceAccess
    {
        IOrganisationMasterBA _OrganisationMasterBA = null;
        public OrganisationMasterServiceAccess()
        {
            _OrganisationMasterBA = new OrganisationMasterBA();
        }
        public IBaseEntityResponse<OrganisationMaster> InsertOrganisationMaster(OrganisationMaster item)
        {
            return _OrganisationMasterBA.InsertOrganisationMaster(item);
        }
        public IBaseEntityResponse<OrganisationMaster> UpdateOrganisationMaster(OrganisationMaster item)
        {
            return _OrganisationMasterBA.UpdateOrganisationMaster(item);
        }
        public IBaseEntityResponse<OrganisationMaster> DeleteOrganisationMaster(OrganisationMaster item)
        {
            return _OrganisationMasterBA.DeleteOrganisationMaster(item);
        }
        public IBaseEntityCollectionResponse<OrganisationMaster> GetBySearch(OrganisationMasterSearchRequest searchRequest)
        {
            return _OrganisationMasterBA.GetBySearch(searchRequest);
        }
        public IBaseEntityCollectionResponse<OrganisationMaster> GetBySearchList(OrganisationMasterSearchRequest searchRequest)
        {
            return _OrganisationMasterBA.GetBySearchList(searchRequest);
        }
        public IBaseEntityResponse<OrganisationMaster> SelectByID(OrganisationMaster item)
        {
            return _OrganisationMasterBA.SelectByID(item);
        }
    }
}
