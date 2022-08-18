using AMS.Base.DTO;
using AMS.Business.BusinessAction;
using AMS.DTO;
namespace AMS.ServiceAccess
{
    public class OrganisationSubjectGrpCombinationServiceAccess : IOrganisationSubjectGrpCombinationServiceAccess
    {
        IOrganisationSubjectGrpCombinationBA _organisationSubjectGrpCombinationBA = null;
        public OrganisationSubjectGrpCombinationServiceAccess()
        {
            _organisationSubjectGrpCombinationBA = new OrganisationSubjectGrpCombinationBA();
        }
        public IBaseEntityResponse<OrganisationSubjectGrpCombination> InsertOrganisationSubjectGrpCombination(OrganisationSubjectGrpCombination item)
        {
            return _organisationSubjectGrpCombinationBA.InsertOrganisationSubjectGrpCombination(item);
        }
        public IBaseEntityResponse<OrganisationSubjectGrpCombination> UpdateOrganisationSubjectGrpCombination(OrganisationSubjectGrpCombination item)
        {
            return _organisationSubjectGrpCombinationBA.UpdateOrganisationSubjectGrpCombination(item);
        }
        public IBaseEntityResponse<OrganisationSubjectGrpCombination> DeleteOrganisationSubjectGrpCombination(OrganisationSubjectGrpCombination item)
        {
            return _organisationSubjectGrpCombinationBA.DeleteOrganisationSubjectGrpCombination(item);
        }
        public IBaseEntityCollectionResponse<OrganisationSubjectGrpCombination> GetBySearch(OrganisationSubjectGrpCombinationSearchRequest searchRequest)
        {
            return _organisationSubjectGrpCombinationBA.GetBySearch(searchRequest);
        }
        public IBaseEntityResponse<OrganisationSubjectGrpCombination> SelectByID(OrganisationSubjectGrpCombination item)
        {
            return _organisationSubjectGrpCombinationBA.SelectByID(item);
        }
    }
}
