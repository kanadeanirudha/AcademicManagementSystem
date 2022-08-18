using AMS.Base.DTO;
using AMS.Business.BusinessAction;
using AMS.DTO;
namespace AMS.ServiceAccess
{
    public class OrganisationDepartmentBranchServiceAccess : IOrganisationDepartmentBranchServiceAccess
    {
        IOrganisationDepartmentBranchBA _organisationDepartmentBranchBA = null;
        public OrganisationDepartmentBranchServiceAccess()
        {
            _organisationDepartmentBranchBA = new OrganisationDepartmentBranchBA();
        }
        public IBaseEntityResponse<OrganisationDepartmentBranch> InsertOrganisationDepartmentBranch(OrganisationDepartmentBranch item)
        {
            return _organisationDepartmentBranchBA.InsertOrganisationDepartmentBranch(item);
        }
        public IBaseEntityResponse<OrganisationDepartmentBranch> UpdateOrganisationDepartmentBranch(OrganisationDepartmentBranch item)
        {
            return _organisationDepartmentBranchBA.UpdateOrganisationDepartmentBranch(item);
        }
        public IBaseEntityResponse<OrganisationDepartmentBranch> DeleteOrganisationDepartmentBranch(OrganisationDepartmentBranch item)
        {
            return _organisationDepartmentBranchBA.DeleteOrganisationDepartmentBranch(item);
        }
        public IBaseEntityCollectionResponse<OrganisationDepartmentBranch> GetBySearch(OrganisationDepartmentBranchSearchRequest searchRequest)
        {
            return _organisationDepartmentBranchBA.GetBySearch(searchRequest);
        }
        public IBaseEntityResponse<OrganisationDepartmentBranch> SelectByID(OrganisationDepartmentBranch item)
        {
            return _organisationDepartmentBranchBA.SelectByID(item);
        }
    }
}
