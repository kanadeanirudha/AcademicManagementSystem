using AMS.Base.DTO;
using AMS.Business.BusinessAction;
using AMS.DTO;
namespace AMS.ServiceAccess
{
    public class EmployeeDocumentRequiredServiceAccess : IEmployeeDocumentRequiredServiceAccess
    {
        IEmployeeDocumentRequiredBA _employeeDocumentRequiredBA = null;
        public EmployeeDocumentRequiredServiceAccess()
        {
            _employeeDocumentRequiredBA = new EmployeeDocumentRequiredBA();
        }
        public IBaseEntityResponse<EmployeeDocumentRequired> InsertEmployeeDocumentRequired(EmployeeDocumentRequired item)
        {
            return _employeeDocumentRequiredBA.InsertEmployeeDocumentRequired(item);
        }
        public IBaseEntityResponse<EmployeeDocumentRequired> UpdateEmployeeDocumentRequired(EmployeeDocumentRequired item)
        {
            return _employeeDocumentRequiredBA.UpdateEmployeeDocumentRequired(item);
        }
        public IBaseEntityResponse<EmployeeDocumentRequired> DeleteEmployeeDocumentRequired(EmployeeDocumentRequired item)
        {
            return _employeeDocumentRequiredBA.DeleteEmployeeDocumentRequired(item);
        }
        public IBaseEntityCollectionResponse<EmployeeDocumentRequired> GetBySearch(EmployeeDocumentRequiredSearchRequest searchRequest)
        {
            return _employeeDocumentRequiredBA.GetBySearch(searchRequest);
        }
        public IBaseEntityResponse<EmployeeDocumentRequired> SelectByID(EmployeeDocumentRequired item)
        {
            return _employeeDocumentRequiredBA.SelectByID(item);
        }
        public IBaseEntityCollectionResponse<EmployeeDocumentRequired> SelectByLeaveRuleMasterID(EmployeeDocumentRequiredSearchRequest searchRequest)
        {
            return _employeeDocumentRequiredBA.SelectByLeaveRuleMasterID(searchRequest);
        }
        
    }
}
