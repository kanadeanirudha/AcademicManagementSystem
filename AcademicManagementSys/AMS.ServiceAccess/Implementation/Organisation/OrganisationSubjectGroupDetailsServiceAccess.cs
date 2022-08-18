using AMS.Base.DTO;
using AMS.Business.BusinessAction;
using AMS.DTO;
namespace AMS.ServiceAccess
{
    public class OrganisationSubjectGroupDetailsServiceAccess : IOrganisationSubjectGroupDetailsServiceAccess
    {
        IOrganisationSubjectGroupDetailsBA _organisationSubjectGroupDetailsBA = null;
        public OrganisationSubjectGroupDetailsServiceAccess()
        {
            _organisationSubjectGroupDetailsBA = new OrganisationSubjectGroupDetailsBA();
        }
        public IBaseEntityResponse<OrganisationSubjectGroupDetails> InsertOrganisationSubjectGroupDetails(OrganisationSubjectGroupDetails item)
        {
            return _organisationSubjectGroupDetailsBA.InsertOrganisationSubjectGroupDetails(item);
        }
        public IBaseEntityResponse<OrganisationSubjectGroupDetails> UpdateOrganisationSubjectGroupDetails(OrganisationSubjectGroupDetails item)
        {
            return _organisationSubjectGroupDetailsBA.UpdateOrganisationSubjectGroupDetails(item);
        }
        public IBaseEntityResponse<OrganisationSubjectGroupDetails> DeleteOrganisationSubjectGroupDetails(OrganisationSubjectGroupDetails item)
        {
            return _organisationSubjectGroupDetailsBA.DeleteOrganisationSubjectGroupDetails(item);
        }
        public IBaseEntityCollectionResponse<OrganisationSubjectGroupDetails> GetBySearch(OrganisationSubjectGroupDetailsSearchRequest searchRequest)
        {
            return _organisationSubjectGroupDetailsBA.GetBySearch(searchRequest);
        }
        public IBaseEntityCollectionResponse<OrganisationSubjectGroupDetails> GetBySubjectTypeMaterList(OrganisationSubjectGroupDetailsSearchRequest searchRequest)
        {
            return _organisationSubjectGroupDetailsBA.GetBySubjectTypeMaterList(searchRequest);
        }

        public IBaseEntityCollectionResponse<OrganisationSubjectGroupDetails> GetByElectiveGroupSearchList(OrganisationSubjectGroupDetailsSearchRequest searchRequest)
        {
            return _organisationSubjectGroupDetailsBA.GetByElectiveGroupSearchList(searchRequest);
        }
        public IBaseEntityCollectionResponse<OrganisationSubjectGroupDetails> GetBySubElectiveGroupSearchList(OrganisationSubjectGroupDetailsSearchRequest searchRequest)
        {
            return _organisationSubjectGroupDetailsBA.GetBySubElectiveGroupSearchList(searchRequest);
        }
        public IBaseEntityResponse<OrganisationSubjectGroupDetails> SelectByID(OrganisationSubjectGroupDetails item)
        {
            return _organisationSubjectGroupDetailsBA.SelectByID(item);
        }
        public IBaseEntityCollectionResponse<OrganisationSubjectGroupDetails> GetByDescriptionList(OrganisationSubjectGroupDetailsSearchRequest searchRequest)
        {
            return _organisationSubjectGroupDetailsBA.GetByDescriptionList(searchRequest);
        }
    }
}
