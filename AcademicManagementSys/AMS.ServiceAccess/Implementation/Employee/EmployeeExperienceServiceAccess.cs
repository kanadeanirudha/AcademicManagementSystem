using AMS.Base.DTO;
using AMS.Business.BusinessAction;
using AMS.DTO;
namespace AMS.ServiceAccess
{
    public class EmployeeExperienceServiceAccess : IEmployeeExperienceServiceAccess
    {
        IEmployeeExperienceBA _employeeExperienceBA = null;
        public EmployeeExperienceServiceAccess()
        {
            _employeeExperienceBA = new EmployeeExperienceBA();
        }
        public IBaseEntityResponse<EmployeeExperience> InsertEmployeeExperience(EmployeeExperience item)
        {
            return _employeeExperienceBA.InsertEmployeeExperience(item);
        }
        public IBaseEntityResponse<EmployeeExperience> UpdateEmployeeExperience(EmployeeExperience item)
        {
            return _employeeExperienceBA.UpdateEmployeeExperience(item);
        }
        public IBaseEntityResponse<EmployeeExperience> DeleteEmployeeExperience(EmployeeExperience item)
        {
            return _employeeExperienceBA.DeleteEmployeeExperience(item);
        }
        public IBaseEntityCollectionResponse<EmployeeExperience> GetBySearch(EmployeeExperienceSearchRequest searchRequest)
        {
            return _employeeExperienceBA.GetBySearch(searchRequest);
        }
        public IBaseEntityResponse<EmployeeExperience> SelectByID(EmployeeExperience item)
        {
            return _employeeExperienceBA.SelectByID(item);
        }
    }
}
