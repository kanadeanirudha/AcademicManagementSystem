using AMS.Base.DTO;
using AMS.Business.BusinessAction;
using AMS.DTO;
namespace AMS.ServiceAccess
{
    public class EmployeeServiceDetailsServiceAccess : IEmployeeServiceDetailsServiceAccess
    {
        IEmployeeServiceDetailsBA _employeeServiceDetailsBA = null;
        public EmployeeServiceDetailsServiceAccess()
        {
            _employeeServiceDetailsBA = new EmployeeServiceDetailsBA();
        }
        public IBaseEntityResponse<EmployeeServiceDetails> InsertEmployeeServiceDetails(EmployeeServiceDetails item)
        {
            return _employeeServiceDetailsBA.InsertEmployeeServiceDetails(item);
        }
        public IBaseEntityResponse<EmployeeServiceDetails> UpdateEmployeeServiceDetails(EmployeeServiceDetails item)
        {
            return _employeeServiceDetailsBA.UpdateEmployeeServiceDetails(item);
        }
        public IBaseEntityResponse<EmployeeServiceDetails> DeleteEmployeeServiceDetails(EmployeeServiceDetails item)
        {
            return _employeeServiceDetailsBA.DeleteEmployeeServiceDetails(item);
        }
        public IBaseEntityCollectionResponse<EmployeeServiceDetails> GetBySearch(EmployeeServiceDetailsSearchRequest searchRequest)
        {
            return _employeeServiceDetailsBA.GetBySearch(searchRequest);
        }
        public IBaseEntityCollectionResponse<EmployeeServiceDetails> GetBySearchList(EmployeeServiceDetailsSearchRequest searchRequest)
        {
            return _employeeServiceDetailsBA.GetBySearchList(searchRequest);
        }
        public IBaseEntityResponse<EmployeeServiceDetails> SelectByID(EmployeeServiceDetails item)
        {
            return _employeeServiceDetailsBA.SelectByID(item);
        }
        public IBaseEntityResponse<EmployeeServiceDetails> SelectByEmployeeID(EmployeeServiceDetails item)
        {
            return _employeeServiceDetailsBA.SelectByEmployeeID(item);
        }
      
    }
}
