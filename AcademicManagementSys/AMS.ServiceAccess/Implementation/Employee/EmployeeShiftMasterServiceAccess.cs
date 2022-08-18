using AMS.Base.DTO;
using AMS.Business.BusinessAction;
using AMS.DTO;
namespace AMS.ServiceAccess
{
    public class EmployeeShiftMasterServiceAccess : IEmployeeShiftMasterServiceAccess
    {
        IEmployeeShiftMasterBA _employeeShiftMasterBA = null;
        public EmployeeShiftMasterServiceAccess()
        {
            _employeeShiftMasterBA = new EmployeeShiftMasterBA();
        }
        public IBaseEntityResponse<EmployeeShiftMaster> InsertEmployeeShiftMaster(EmployeeShiftMaster item)
        {
            return _employeeShiftMasterBA.InsertEmployeeShiftMaster(item);
        }
        public IBaseEntityResponse<EmployeeShiftMaster> UpdateEmployeeShiftMaster(EmployeeShiftMaster item)
        {
            return _employeeShiftMasterBA.UpdateEmployeeShiftMaster(item);
        }
        public IBaseEntityResponse<EmployeeShiftMaster> DeleteEmployeeShiftMaster(EmployeeShiftMaster item)
        {
            return _employeeShiftMasterBA.DeleteEmployeeShiftMaster(item);
        }
        public IBaseEntityCollectionResponse<EmployeeShiftMaster> GetBySearch(EmployeeShiftMasterSearchRequest searchRequest)
        {
            return _employeeShiftMasterBA.GetBySearch(searchRequest);
        }
        public IBaseEntityCollectionResponse<EmployeeShiftMaster> GetBySearchList(EmployeeShiftMasterSearchRequest searchRequest)
        {
            return _employeeShiftMasterBA.GetBySearchList(searchRequest);
        }
        public IBaseEntityResponse<EmployeeShiftMaster> SelectByEmployeeShiftMasterID(EmployeeShiftMaster item)
        {
            return _employeeShiftMasterBA.SelectByEmployeeShiftMasterID(item);
        }
        public IBaseEntityCollectionResponse<EmployeeShiftMaster> GetEmployeeShiftMasterDetailsBySearch(EmployeeShiftMasterSearchRequest searchRequest)
        {
            return _employeeShiftMasterBA.GetEmployeeShiftMasterDetailsBySearch(searchRequest);
        }
        public IBaseEntityResponse<EmployeeShiftMaster> InsertEmployeeShiftMasterDetails(EmployeeShiftMaster item)
        {
            return _employeeShiftMasterBA.InsertEmployeeShiftMasterDetails(item);
        }
        public IBaseEntityResponse<EmployeeShiftMaster> SelectByEmployeeShiftMasterDetailsID(EmployeeShiftMaster item)
        {
            return _employeeShiftMasterBA.SelectByEmployeeShiftMasterDetailsID(item);
        }
        public IBaseEntityResponse<EmployeeShiftMaster> UpdateEmployeeShiftMasterDetails(EmployeeShiftMaster item)
        {
            return _employeeShiftMasterBA.UpdateEmployeeShiftMasterDetails(item);
        }       
    }
}
