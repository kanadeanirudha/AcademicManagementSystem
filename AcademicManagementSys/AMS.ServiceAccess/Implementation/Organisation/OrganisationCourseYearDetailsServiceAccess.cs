using AMS.Base.DTO;
using AMS.Business.BusinessAction;
using AMS.DTO;
namespace AMS.ServiceAccess
{
    public class OrganisationCourseYearDetailsServiceAccess : IOrganisationCourseYearDetailsServiceAccess
    {
        IOrganisationCourseYearDetailsBA _organisationCourseYearDetailsBA = null;
        public OrganisationCourseYearDetailsServiceAccess()
        {
            _organisationCourseYearDetailsBA = new OrganisationCourseYearDetailsBA();
        }
        public IBaseEntityResponse<OrganisationCourseYearDetails> InsertOrganisationCourseYearDetails(OrganisationCourseYearDetails item)
        {
            return _organisationCourseYearDetailsBA.InsertOrganisationCourseYearDetails(item);
        }
        public IBaseEntityResponse<OrganisationCourseYearDetails> UpdateOrganisationCourseYearDetails(OrganisationCourseYearDetails item)
        {
            return _organisationCourseYearDetailsBA.UpdateOrganisationCourseYearDetails(item);
        }
        public IBaseEntityResponse<OrganisationCourseYearDetails> DeleteOrganisationCourseYearDetails(OrganisationCourseYearDetails item)
        {
            return _organisationCourseYearDetailsBA.DeleteOrganisationCourseYearDetails(item);
        }
        public IBaseEntityCollectionResponse<OrganisationCourseYearDetails> GetBySearch(OrganisationCourseYearDetailsSearchRequest searchRequest)
        {
            return _organisationCourseYearDetailsBA.GetBySearch(searchRequest);
        }
        public IBaseEntityResponse<OrganisationCourseYearDetails> SelectByID(OrganisationCourseYearDetails item)
        {
            return _organisationCourseYearDetailsBA.SelectByID(item);
        }
        public IBaseEntityResponse<OrganisationCourseYearDetails> SelectByID_For_CourseDescription(OrganisationCourseYearDetails item)
        {
            return _organisationCourseYearDetailsBA.SelectByID_For_CourseDescription(item);
        }
        public IBaseEntityCollectionResponse<OrganisationCourseYearDetails> GetByApplicableSemester(OrganisationCourseYearDetailsSearchRequest searchRequest)
        {
            return _organisationCourseYearDetailsBA.GetByApplicableSemester(searchRequest);
        }
        public IBaseEntityResponse<OrganisationCourseYearDetails> SelectByBranchDetIDAndStandardNumber(OrganisationCourseYearDetails item)
        {
            return _organisationCourseYearDetailsBA.SelectByBranchDetIDAndStandardNumber(item);
        }
        public IBaseEntityCollectionResponse<OrganisationCourseYearDetails> GetCourseYearListRoleWise(OrganisationCourseYearDetailsSearchRequest searchRequest)
        {
            return _organisationCourseYearDetailsBA.GetCourseYearListRoleWise(searchRequest);
        }
        public IBaseEntityCollectionResponse<OrganisationCourseYearDetails> GetNextCourseYearForPromotion(OrganisationCourseYearDetailsSearchRequest searchRequest)
        {
            return _organisationCourseYearDetailsBA.GetNextCourseYearForPromotion(searchRequest);
        }

        public IBaseEntityCollectionResponse<OrganisationCourseYearDetails> GetCourseYearListRole_CentreCode_UniversityWise(OrganisationCourseYearDetailsSearchRequest searchRequest)
        {
            return _organisationCourseYearDetailsBA.GetCourseYearListRole_CentreCode_UniversityWise(searchRequest);
        }
        public IBaseEntityCollectionResponse<OrganisationCourseYearDetails> GetCourseYearDetailsByCentreCode(OrganisationCourseYearDetailsSearchRequest searchRequest)
        {
            return _organisationCourseYearDetailsBA.GetCourseYearDetailsByCentreCode(searchRequest);
        }
        
        public IBaseEntityCollectionResponse<OrganisationCourseYearDetails> GetCourseYearDetailSearchList(OrganisationCourseYearDetailsSearchRequest searchRequest)
        {
            return _organisationCourseYearDetailsBA.GetCourseYearDetailSearchList(searchRequest);
        }
        public IBaseEntityCollectionResponse<OrganisationCourseYearDetails> GetCourseYearDetailDescription(OrganisationCourseYearDetailsSearchRequest searchRequest)
        {
            return _organisationCourseYearDetailsBA.GetCourseYearDetailDescription(searchRequest);
        }
    }
}
