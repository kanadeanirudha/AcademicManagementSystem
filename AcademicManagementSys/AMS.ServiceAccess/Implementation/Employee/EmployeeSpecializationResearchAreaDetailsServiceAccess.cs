using AMS.Base.DTO;
using AMS.Business.BusinessAction;
using AMS.DTO;
namespace AMS.ServiceAccess
{
    public class EmployeeSpecializationResearchAreaDetailsServiceAccess : IEmployeeSpecializationResearchAreaDetailsServiceAccess
    {
        IEmployeeSpecializationResearchAreaDetailsBA _employeeSpecializationResearchAreaDetailsBA = null;
        public EmployeeSpecializationResearchAreaDetailsServiceAccess()
        {
            _employeeSpecializationResearchAreaDetailsBA = new EmployeeSpecializationResearchAreaDetailsBA();
        }
        public IBaseEntityResponse<EmployeeSpecializationResearchAreaDetails> InsertEmployeeSpecializationResearchAreaDetails(EmployeeSpecializationResearchAreaDetails item)
        {
            return _employeeSpecializationResearchAreaDetailsBA.InsertEmployeeSpecializationResearchAreaDetails(item);
        }
        public IBaseEntityResponse<EmployeeSpecializationResearchAreaDetails> UpdateEmployeeSpecializationResearchAreaDetails(EmployeeSpecializationResearchAreaDetails item)
        {
            return _employeeSpecializationResearchAreaDetailsBA.UpdateEmployeeSpecializationResearchAreaDetails(item);
        }
        public IBaseEntityResponse<EmployeeSpecializationResearchAreaDetails> DeleteEmployeeSpecializationResearchAreaDetails(EmployeeSpecializationResearchAreaDetails item)
        {
            return _employeeSpecializationResearchAreaDetailsBA.DeleteEmployeeSpecializationResearchAreaDetails(item);
        }
        public IBaseEntityCollectionResponse<EmployeeSpecializationResearchAreaDetails> GetBySearch(EmployeeSpecializationResearchAreaDetailsSearchRequest searchRequest)
        {
            return _employeeSpecializationResearchAreaDetailsBA.GetBySearch(searchRequest);
        }
        public IBaseEntityResponse<EmployeeSpecializationResearchAreaDetails> SelectByID(EmployeeSpecializationResearchAreaDetails item)
        {
            return _employeeSpecializationResearchAreaDetailsBA.SelectByID(item);
        }
    }
}
