using AMS.Base.DTO;
using AMS.Business.BusinessAction;
using AMS.DTO;
namespace AMS.ServiceAccess
{
    public class OrganisationSectionDetailsServiceAccess : IOrganisationSectionDetailsServiceAccess
    {
        IOrganisationSectionDetailsBA _organisationSectionDetailsBA = null;
        public OrganisationSectionDetailsServiceAccess()
        {
            _organisationSectionDetailsBA = new OrganisationSectionDetailsBA();
        }
        public IBaseEntityResponse<OrganisationSectionDetails> InsertOrganisationSectionDetails(OrganisationSectionDetails item)
        {
            return _organisationSectionDetailsBA.InsertOrganisationSectionDetails(item);
        }
        public IBaseEntityResponse<OrganisationSectionDetails> UpdateOrganisationSectionDetails(OrganisationSectionDetails item)
        {
            return _organisationSectionDetailsBA.UpdateOrganisationSectionDetails(item);
        }
        public IBaseEntityResponse<OrganisationSectionDetails> DeleteOrganisationSectionDetails(OrganisationSectionDetails item)
        {
            return _organisationSectionDetailsBA.DeleteOrganisationSectionDetails(item);
        }
        public IBaseEntityCollectionResponse<OrganisationSectionDetails> GetBySearch(OrganisationSectionDetailsSearchRequest searchRequest)
        {
            return _organisationSectionDetailsBA.GetBySearch(searchRequest);
        }
        public IBaseEntityResponse<OrganisationSectionDetails> SelectByID(OrganisationSectionDetails item)
        {
            return _organisationSectionDetailsBA.SelectByID(item);
        }
        public IBaseEntityCollectionResponse<OrganisationSectionDetails> SelectByBranchDetID(OrganisationSectionDetailsSearchRequest searchRequest)
        {
            return _organisationSectionDetailsBA.SelectByBranchDetID(searchRequest);
        }
        public IBaseEntityCollectionResponse<OrganisationSectionDetails> GetBySearchForSectionDetailsAdd(OrganisationSectionDetailsSearchRequest searchRequest)
        {
            return _organisationSectionDetailsBA.GetBySearchForSectionDetailsAdd(searchRequest);
        }

        public IBaseEntityResponse<OrganisationSectionDetails> SelectByID_OR_CourseYearID(OrganisationSectionDetails item)
        {
            return _organisationSectionDetailsBA.SelectByID_OR_CourseYearID(item);
        }

        public IBaseEntityResponse<OrganisationSectionDetails> UpdateOrganisationSectionDetailsAdd(OrganisationSectionDetails item)
        {
            return _organisationSectionDetailsBA.UpdateOrganisationSectionDetailsAdd(item);
        }

        public IBaseEntityCollectionResponse<OrganisationSectionDetails> GetSectionDetailsRoleWise(OrganisationSectionDetailsSearchRequest searchRequest)
        {
            return _organisationSectionDetailsBA.GetSectionDetailsRoleWise(searchRequest);
        }
        public IBaseEntityCollectionResponse<OrganisationSectionDetails> GetSectionDetailsForPromotion(OrganisationSectionDetailsSearchRequest searchRequest)
        {
            return _organisationSectionDetailsBA.GetSectionDetailsForPromotion(searchRequest);
        }
        public IBaseEntityCollectionResponse<OrganisationSectionDetails> GetSectionDetailsRole_CentreCode_UniversityWise(OrganisationSectionDetailsSearchRequest searchRequest)
        {
            return _organisationSectionDetailsBA.GetSectionDetailsRole_CentreCode_UniversityWise(searchRequest);
        }
    }
}
