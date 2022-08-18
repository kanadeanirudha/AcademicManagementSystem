using AMS.Base.DTO;
using AMS.Business.BusinessAction;
using AMS.DTO;
namespace AMS.ServiceAccess
{
    public class OrganisationCourseYearSemesterServiceAccess : IOrganisationCourseYearSemesterServiceAccess
    {
        IOrganisationCourseYearSemesterBA _organisationCourseYearSemesterBA = null;
        public OrganisationCourseYearSemesterServiceAccess()
        {
            _organisationCourseYearSemesterBA = new OrganisationCourseYearSemesterBA();
        }
        public IBaseEntityResponse<OrganisationCourseYearSemester> InsertOrganisationCourseYearSemester(OrganisationCourseYearSemester item)
        {
            return _organisationCourseYearSemesterBA.InsertOrganisationCourseYearSemester(item);
        }
        public IBaseEntityResponse<OrganisationCourseYearSemester> UpdateOrganisationCourseYearSemester(OrganisationCourseYearSemester item)
        {
            return _organisationCourseYearSemesterBA.UpdateOrganisationCourseYearSemester(item);
        }
        public IBaseEntityResponse<OrganisationCourseYearSemester> DeleteOrganisationCourseYearSemester(OrganisationCourseYearSemester item)
        {
            return _organisationCourseYearSemesterBA.DeleteOrganisationCourseYearSemester(item);
        }
        public IBaseEntityCollectionResponse<OrganisationCourseYearSemester> GetBySearch(OrganisationCourseYearSemesterSearchRequest searchRequest)
        {
            return _organisationCourseYearSemesterBA.GetBySearch(searchRequest);
        }
        public IBaseEntityResponse<OrganisationCourseYearSemester> SelectByID(OrganisationCourseYearSemester item)
        {
            return _organisationCourseYearSemesterBA.SelectByID(item);
        }
    }
}
