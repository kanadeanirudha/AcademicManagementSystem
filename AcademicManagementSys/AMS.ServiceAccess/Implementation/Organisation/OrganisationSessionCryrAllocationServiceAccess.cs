using AMS.Base.DTO;
using AMS.Business.BusinessAction;
using AMS.DTO;
namespace AMS.ServiceAccess
{
    public class OrganisationSessionCryrAllocationServiceAccess : IOrganisationSessionCryrAllocationServiceAccess
    {
        IOrganisationSessionCryrAllocationBA _organisationSessionCryrAllocationBA = null;
        public OrganisationSessionCryrAllocationServiceAccess()
        {
            _organisationSessionCryrAllocationBA = new OrganisationSessionCryrAllocationBA();
        }
        public IBaseEntityResponse<OrganisationSessionCryrAllocation> InsertOrganisationSessionCryrAllocation(OrganisationSessionCryrAllocation item)
        {
            return _organisationSessionCryrAllocationBA.InsertOrganisationSessionCryrAllocation(item);
        }
        public IBaseEntityResponse<OrganisationSessionCryrAllocation> UpdateOrganisationSessionCryrAllocation(OrganisationSessionCryrAllocation item)
        {
            return _organisationSessionCryrAllocationBA.UpdateOrganisationSessionCryrAllocation(item);
        }
        public IBaseEntityResponse<OrganisationSessionCryrAllocation> DeleteOrganisationSessionCryrAllocation(OrganisationSessionCryrAllocation item)
        {
            return _organisationSessionCryrAllocationBA.DeleteOrganisationSessionCryrAllocation(item);
        }
        public IBaseEntityCollectionResponse<OrganisationSessionCryrAllocation> GetBySearch(OrganisationSessionCryrAllocationSearchRequest searchRequest)
        {
            return _organisationSessionCryrAllocationBA.GetBySearch(searchRequest);
        }
        public IBaseEntityResponse<OrganisationSessionCryrAllocation> SelectByID(OrganisationSessionCryrAllocation item)
        {
            return _organisationSessionCryrAllocationBA.SelectByID(item);
        }
        public IBaseEntityResponse<OrganisationSessionCryrAllocation> GetCurrentSession(OrganisationSessionCryrAllocation item)
        {
            return _organisationSessionCryrAllocationBA.GetCurrentSession(item);
        }
    }
}
