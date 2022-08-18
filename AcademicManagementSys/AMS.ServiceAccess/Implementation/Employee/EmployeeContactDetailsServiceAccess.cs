using AMS.Base.DTO;
using AMS.Business.BusinessAction;
using AMS.DTO;
namespace AMS.ServiceAccess
{
    public class EmployeeContactDetailsServiceAccess : IEmployeeContactDetailsServiceAccess
    {
        IEmployeeContactDetailsBA _employeeContactDetailsBA = null;
        public EmployeeContactDetailsServiceAccess()
        {
            _employeeContactDetailsBA = new EmployeeContactDetailsBA();
        }
        public IBaseEntityResponse<EmployeeContactDetails> InsertEmployeeContactDetails(EmployeeContactDetails item)
        {
            return _employeeContactDetailsBA.InsertEmployeeContactDetails(item);
        }
        public IBaseEntityResponse<EmployeeContactDetails> UpdateEmployeeContactDetails(EmployeeContactDetails item)
        {
            return _employeeContactDetailsBA.UpdateEmployeeContactDetails(item);
        }
        public IBaseEntityResponse<EmployeeContactDetails> DeleteEmployeeContactDetails(EmployeeContactDetails item)
        {
            return _employeeContactDetailsBA.DeleteEmployeeContactDetails(item);
        }
        public IBaseEntityCollectionResponse<EmployeeContactDetails> GetBySearch(EmployeeContactDetailsSearchRequest searchRequest)
        {
            return _employeeContactDetailsBA.GetBySearch(searchRequest);
        }
        public IBaseEntityResponse<EmployeeContactDetails> SelectByID(EmployeeContactDetails item)
        {
            return _employeeContactDetailsBA.SelectByID(item);
        }
    }
}
