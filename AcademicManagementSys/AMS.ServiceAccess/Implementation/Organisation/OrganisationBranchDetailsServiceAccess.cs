using AMS.Base.DTO;
using AMS.Business.BusinessAction;
using AMS.DTO;
namespace AMS.ServiceAccess
{
    public class OrganisationBranchDetailsServiceAccess : IOrganisationBranchDetailsServiceAccess
    {
        IOrganisationBranchDetailsBA _organisationBranchDetailsBA = null;
        public OrganisationBranchDetailsServiceAccess()
        {
            _organisationBranchDetailsBA = new OrganisationBranchDetailsBA();
        }
        public IBaseEntityResponse<OrganisationBranchDetails> InsertOrganisationBranchDetails(OrganisationBranchDetails item)
        {
            return _organisationBranchDetailsBA.InsertOrganisationBranchDetails(item);
        }
        public IBaseEntityResponse<OrganisationBranchDetails> UpdateOrganisationBranchDetails(OrganisationBranchDetails item)
        {
            return _organisationBranchDetailsBA.UpdateOrganisationBranchDetails(item);
        }
        public IBaseEntityResponse<OrganisationBranchDetails> DeleteOrganisationBranchDetails(OrganisationBranchDetails item)
        {
            return _organisationBranchDetailsBA.DeleteOrganisationBranchDetails(item);
        }
        public IBaseEntityCollectionResponse<OrganisationBranchDetails> GetBySearch(OrganisationBranchDetailsSearchRequest searchRequest)
        {
            return _organisationBranchDetailsBA.GetBySearch(searchRequest);
        }
        public IBaseEntityResponse<OrganisationBranchDetails> SelectByID(OrganisationBranchDetails item)
        {
            return _organisationBranchDetailsBA.SelectByID(item);
        }
        public IBaseEntityResponse<OrganisationBranchDetails> SelectByID_For_CourseDescription(OrganisationBranchDetails item)
        {
            return _organisationBranchDetailsBA.SelectByID_For_CourseDescription(item);
        }
    }
}
