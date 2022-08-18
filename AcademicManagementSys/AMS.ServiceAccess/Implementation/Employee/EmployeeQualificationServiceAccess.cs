using AMS.Base.DTO;
using AMS.Business.BusinessAction;
using AMS.DTO;
namespace AMS.ServiceAccess
{
    public class EmployeeQualificationServiceAccess : IEmployeeQualificationServiceAccess
    {
        IEmployeeQualificationBA _employeeQualificationBA = null;
        public EmployeeQualificationServiceAccess()
        {
            _employeeQualificationBA = new EmployeeQualificationBA();
        }
        public IBaseEntityResponse<EmployeeQualification> InsertEmployeeQualification(EmployeeQualification item)
        {
            return _employeeQualificationBA.InsertEmployeeQualification(item);
        }
        public IBaseEntityResponse<EmployeeQualification> UpdateEmployeeQualification(EmployeeQualification item)
        {
            return _employeeQualificationBA.UpdateEmployeeQualification(item);
        }
        public IBaseEntityResponse<EmployeeQualification> DeleteEmployeeQualification(EmployeeQualification item)
        {
            return _employeeQualificationBA.DeleteEmployeeQualification(item);
        }
        public IBaseEntityCollectionResponse<EmployeeQualification> GetBySearch(EmployeeQualificationSearchRequest searchRequest)
        {
            return _employeeQualificationBA.GetBySearch(searchRequest);
        }
        public IBaseEntityResponse<EmployeeQualification> SelectByID(EmployeeQualification item)
        {
            return _employeeQualificationBA.SelectByID(item);
        }
    }
}
