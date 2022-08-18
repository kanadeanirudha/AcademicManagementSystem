using AMS.Base.DTO;
using AMS.Business.BusinessAction;
using AMS.DTO;
namespace AMS.ServiceAccess
{
    public class EmployeePersonalDetailsServiceAccess : IEmployeePersonalDetailsServiceAccess
    {
        IEmployeePersonalDetailsBA _employeePersonalDetailsBA = null;
        public EmployeePersonalDetailsServiceAccess()
        {
            _employeePersonalDetailsBA = new EmployeePersonalDetailsBA();
        }
        public IBaseEntityResponse<EmployeePersonalDetails> InsertEmployeePersonalDetails(EmployeePersonalDetails item)
        {
            return _employeePersonalDetailsBA.InsertEmployeePersonalDetails(item);
        }
        public IBaseEntityResponse<EmployeePersonalDetails> UpdateEmployeePersonalDetails(EmployeePersonalDetails item)
        {
            return _employeePersonalDetailsBA.UpdateEmployeePersonalDetails(item);
        }
        public IBaseEntityResponse<EmployeePersonalDetails> DeleteEmployeePersonalDetails(EmployeePersonalDetails item)
        {
            return _employeePersonalDetailsBA.DeleteEmployeePersonalDetails(item);
        }
        public IBaseEntityCollectionResponse<EmployeePersonalDetails> GetBySearch(EmployeePersonalDetailsSearchRequest searchRequest)
        {
            return _employeePersonalDetailsBA.GetBySearch(searchRequest);
        }
        public IBaseEntityResponse<EmployeePersonalDetails> SelectByID(EmployeePersonalDetails item)
        {
            return _employeePersonalDetailsBA.SelectByID(item);
        }
    }
}
