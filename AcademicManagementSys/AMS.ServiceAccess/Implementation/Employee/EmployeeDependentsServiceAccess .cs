using AMS.Base.DTO;
using AMS.Business.BusinessAction;
using AMS.DTO;
namespace AMS.ServiceAccess
{
    public class EmployeeDependentsServiceAccess : IEmployeeDependentsServiceAccess
    {
        IEmployeeDependentsBA _employeeDependentsBA = null;
        public EmployeeDependentsServiceAccess()
        {
            _employeeDependentsBA = new EmployeeDependentsBA();
        }
        public IBaseEntityResponse<EmployeeDependents> InsertEmployeeDependents(EmployeeDependents item)
        {
            return _employeeDependentsBA.InsertEmployeeDependents(item);
        }
        public IBaseEntityResponse<EmployeeDependents> UpdateEmployeeDependents(EmployeeDependents item)
        {
            return _employeeDependentsBA.UpdateEmployeeDependents(item);
        }
        public IBaseEntityResponse<EmployeeDependents> DeleteEmployeeDependents(EmployeeDependents item)
        {
            return _employeeDependentsBA.DeleteEmployeeDependents(item);
        }
        public IBaseEntityCollectionResponse<EmployeeDependents> GetBySearch(EmployeeDependentsSearchRequest searchRequest)
        {
            return _employeeDependentsBA.GetBySearch(searchRequest);
        }
        public IBaseEntityResponse<EmployeeDependents> SelectByID(EmployeeDependents item)
        {
            return _employeeDependentsBA.SelectByID(item);
        }
    }
}
