using AMS.Base.DTO;
using AMS.Business.BusinessAction;
using AMS.DTO;
namespace AMS.ServiceAccess
{
    public class EmployeeShiftApplicableMasterServiceAccess : IEmployeeShiftApplicableMasterServiceAccess
    {
        IEmployeeShiftApplicableMasterBA _employeeShiftApplicableMasterBA = null;
        public EmployeeShiftApplicableMasterServiceAccess()
        {
            _employeeShiftApplicableMasterBA = new EmployeeShiftApplicableMasterBA();
        }
        public IBaseEntityResponse<EmployeeShiftApplicableMaster> InsertEmployeeShiftApplicableMaster(EmployeeShiftApplicableMaster item)
        {
            return _employeeShiftApplicableMasterBA.InsertEmployeeShiftApplicableMaster(item);
        }
        public IBaseEntityResponse<EmployeeShiftApplicableMaster> UpdateEmployeeShiftApplicableMaster(EmployeeShiftApplicableMaster item)
        {
            return _employeeShiftApplicableMasterBA.UpdateEmployeeShiftApplicableMaster(item);
        }
        public IBaseEntityResponse<EmployeeShiftApplicableMaster> DeleteEmployeeShiftApplicableMaster(EmployeeShiftApplicableMaster item)
        {
            return _employeeShiftApplicableMasterBA.DeleteEmployeeShiftApplicableMaster(item);
        }
        public IBaseEntityCollectionResponse<EmployeeShiftApplicableMaster> GetBySearch(EmployeeShiftApplicableMasterSearchRequest searchRequest)
        {
            return _employeeShiftApplicableMasterBA.GetBySearch(searchRequest);
        }
        public IBaseEntityResponse<EmployeeShiftApplicableMaster> SelectByID(EmployeeShiftApplicableMaster item)
        {
            return _employeeShiftApplicableMasterBA.SelectByID(item);
        }
    }
}
