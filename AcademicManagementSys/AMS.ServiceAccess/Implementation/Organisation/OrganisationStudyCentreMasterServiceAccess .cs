using AMS.Base.DTO;
using AMS.Business.BusinessAction;
using AMS.DTO;
namespace AMS.ServiceAccess
{
    public class OrganisationStudyCentreMasterServiceAccess : IOrganisationStudyCentreMasterServiceAccess
    {
        IOrganisationStudyCentreMasterBA _organisationStudyCentreMasterBA = null;
        public OrganisationStudyCentreMasterServiceAccess()
        {
            _organisationStudyCentreMasterBA = new OrganisationStudyCentreMasterBA();
        }
        public IBaseEntityResponse<OrganisationStudyCentreMaster> InsertOrganisationStudyCentreMaster(OrganisationStudyCentreMaster item)
        {
            return _organisationStudyCentreMasterBA.InsertOrganisationStudyCentreMaster(item);
        }
        public IBaseEntityResponse<OrganisationStudyCentreMaster> UpdateOrganisationStudyCentreMaster(OrganisationStudyCentreMaster item)
        {
            return _organisationStudyCentreMasterBA.UpdateOrganisationStudyCentreMaster(item);
        }
        public IBaseEntityResponse<OrganisationStudyCentreMaster> DeleteOrganisationStudyCentreMaster(OrganisationStudyCentreMaster item)
        {
            return _organisationStudyCentreMasterBA.DeleteOrganisationStudyCentreMaster(item);
        }
        public IBaseEntityCollectionResponse<OrganisationStudyCentreMaster> GetBySearch(OrganisationStudyCentreMasterSearchRequest searchRequest)
        {
            return _organisationStudyCentreMasterBA.GetBySearch(searchRequest);
        }
        public IBaseEntityCollectionResponse<OrganisationStudyCentreMaster> GetListHORO(OrganisationStudyCentreMasterSearchRequest searchRequest)
        {
            return _organisationStudyCentreMasterBA.GetListHORO(searchRequest);
        }
        public IBaseEntityCollectionResponse<OrganisationStudyCentreMaster> GetStudyCentreList(OrganisationStudyCentreMasterSearchRequest searchRequest)
        {
            return _organisationStudyCentreMasterBA.GetOrganisationStudyCentreList(searchRequest);
        }
        public IBaseEntityCollectionResponse<OrganisationStudyCentreMaster> GetStudyCentreListRoleWise(OrganisationStudyCentreMasterSearchRequest searchRequest)
        {
            return _organisationStudyCentreMasterBA.GetStudyCentreListRoleWise(searchRequest);
        }
        public IBaseEntityCollectionResponse<OrganisationStudyCentreMaster> GetStudyCentreDetailsForReports(OrganisationStudyCentreMasterSearchRequest searchRequest)
        {
            return _organisationStudyCentreMasterBA.GetStudyCentreDetailsForReports(searchRequest);
        }        
        public IBaseEntityResponse<OrganisationStudyCentreMaster> SelectByID(OrganisationStudyCentreMaster item)
        {
            return _organisationStudyCentreMasterBA.SelectByID(item);
        }
        public IBaseEntityResponse<OrganisationStudyCentreMaster> SelectHOROCount(OrganisationStudyCentreMaster item)
        {
            return _organisationStudyCentreMasterBA.SelectHOROCount(item);
        }
    }
}
