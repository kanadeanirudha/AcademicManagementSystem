using AMS.Base.DTO;
using AMS.Business.BusinessAction;
using AMS.DTO;
namespace AMS.ServiceAccess
{
    public class OrganisationBranchMasterServiceAccess : IOrganisationBranchMasterServiceAccess
    {
        IOrganisationBranchMasterBA _organisationBranchMasterBA = null;
        public OrganisationBranchMasterServiceAccess()
        {
            _organisationBranchMasterBA = new OrganisationBranchMasterBA();
        }
        public IBaseEntityResponse<OrganisationBranchMaster> InsertOrganisationBranchMaster(OrganisationBranchMaster item)
        {
            return _organisationBranchMasterBA.InsertOrganisationBranchMaster(item);
        }
        public IBaseEntityResponse<OrganisationBranchMaster> UpdateOrganisationBranchMaster(OrganisationBranchMaster item)
        {
            return _organisationBranchMasterBA.UpdateOrganisationBranchMaster(item);
        }
        public IBaseEntityResponse<OrganisationBranchMaster> DeleteOrganisationBranchMaster(OrganisationBranchMaster item)
        {
            return _organisationBranchMasterBA.DeleteOrganisationBranchMaster(item);
        }
        public IBaseEntityCollectionResponse<OrganisationBranchMaster> GetBySearch(OrganisationBranchMasterSearchRequest searchRequest)
        {
            return _organisationBranchMasterBA.GetBySearch(searchRequest);
        }
        
        public IBaseEntityCollectionResponse<OrganisationBranchMaster> GetBranchListRoleWise(OrganisationBranchMasterSearchRequest searchRequest)
        {
            return _organisationBranchMasterBA.GetBranchListRoleWise(searchRequest);
        }
        public IBaseEntityResponse<OrganisationBranchMaster> SelectByID(OrganisationBranchMaster item)
        {
            return _organisationBranchMasterBA.SelectByID(item);
        }
    }
}
