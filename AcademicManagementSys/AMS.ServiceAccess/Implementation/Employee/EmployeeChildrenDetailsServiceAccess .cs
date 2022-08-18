using AMS.Base.DTO;
using AMS.Business.BusinessAction;
using AMS.DTO;
namespace AMS.ServiceAccess
{
    public class EmployeeChildrenDetailsServiceAccess : IEmployeeChildrenDetailsServiceAccess
    {
        IEmployeeChildrenDetailsBA _employeeChildrenDetailsBA = null;
        public EmployeeChildrenDetailsServiceAccess()
        {
            _employeeChildrenDetailsBA = new EmployeeChildrenDetailsBA();
        }
        public IBaseEntityResponse<EmployeeChildrenDetails> InsertEmployeeChildrenDetails(EmployeeChildrenDetails item)
        {
            return _employeeChildrenDetailsBA.InsertEmployeeChildrenDetails(item);
        }
        public IBaseEntityResponse<EmployeeChildrenDetails> UpdateEmployeeChildrenDetails(EmployeeChildrenDetails item)
        {
            return _employeeChildrenDetailsBA.UpdateEmployeeChildrenDetails(item);
        }
        public IBaseEntityResponse<EmployeeChildrenDetails> DeleteEmployeeChildrenDetails(EmployeeChildrenDetails item)
        {
            return _employeeChildrenDetailsBA.DeleteEmployeeChildrenDetails(item);
        }
        public IBaseEntityCollectionResponse<EmployeeChildrenDetails> GetBySearch(EmployeeChildrenDetailsSearchRequest searchRequest)
        {
            return _employeeChildrenDetailsBA.GetBySearch(searchRequest);
        }
        public IBaseEntityResponse<EmployeeChildrenDetails> SelectByID(EmployeeChildrenDetails item)
        {
            return _employeeChildrenDetailsBA.SelectByID(item);
        }
    }
}
