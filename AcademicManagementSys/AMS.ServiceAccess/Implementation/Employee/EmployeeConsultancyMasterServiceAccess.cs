using AMS.Base.DTO;
using AMS.Business.BusinessAction;
using AMS.DTO;
namespace AMS.ServiceAccess
{
    public class EmployeeConsultancyMasterServiceAccess : IEmployeeConsultancyMasterServiceAccess
    {
        IEmployeeConsultancyMasterBA _employeeConsultancyMasterBA = null;
        public EmployeeConsultancyMasterServiceAccess()
        {
            _employeeConsultancyMasterBA = new EmployeeConsultancyMasterBA();
        }
        public IBaseEntityResponse<EmployeeConsultancyMaster> InsertEmployeeConsultancyMaster(EmployeeConsultancyMaster item)
        {
            return _employeeConsultancyMasterBA.InsertEmployeeConsultancyMaster(item);
        }
        public IBaseEntityResponse<EmployeeConsultancyMaster> UpdateEmployeeConsultancyMaster(EmployeeConsultancyMaster item)
        {
            return _employeeConsultancyMasterBA.UpdateEmployeeConsultancyMaster(item);
        }
        public IBaseEntityResponse<EmployeeConsultancyMaster> DeleteEmployeeConsultancyMaster(EmployeeConsultancyMaster item)
        {
            return _employeeConsultancyMasterBA.DeleteEmployeeConsultancyMaster(item);
        }
        public IBaseEntityCollectionResponse<EmployeeConsultancyMaster> GetBySearch(EmployeeConsultancyMasterSearchRequest searchRequest)
        {
            return _employeeConsultancyMasterBA.GetBySearch(searchRequest);
        }
        public IBaseEntityResponse<EmployeeConsultancyMaster> SelectByID(EmployeeConsultancyMaster item)
        {
            return _employeeConsultancyMasterBA.SelectByID(item);
        }
        public IBaseEntityCollectionResponse<EmployeeConsultancyMaster> GetAppliedDetails(EmployeeConsultancyMasterSearchRequest searchRequest)
        {
            return _employeeConsultancyMasterBA.GetAppliedDetails(searchRequest);
        }


        public IBaseEntityResponse<EmployeeConsultancyMaster> InsertEmployeeConsultancyDetails(EmployeeConsultancyMaster item)
        {
            return _employeeConsultancyMasterBA.InsertEmployeeConsultancyDetails(item);
        }
        public IBaseEntityResponse<EmployeeConsultancyMaster> UpdateEmployeeConsultancyDetails(EmployeeConsultancyMaster item)
        {
            return _employeeConsultancyMasterBA.UpdateEmployeeConsultancyDetails(item);
        }
        public IBaseEntityResponse<EmployeeConsultancyMaster> DeleteEmployeeConsultancyDetails(EmployeeConsultancyMaster item)
        {
            return _employeeConsultancyMasterBA.DeleteEmployeeConsultancyDetails(item);
        }
        public IBaseEntityCollectionResponse<EmployeeConsultancyMaster> GetBySearchEmployeeConsultancyDetails(EmployeeConsultancyMasterSearchRequest searchRequest)
        {
            return _employeeConsultancyMasterBA.GetBySearchEmployeeConsultancyDetails(searchRequest);
        }
        public IBaseEntityResponse<EmployeeConsultancyMaster> SelectEmployeeCentreCode(EmployeeConsultancyMaster item)
        {
            return _employeeConsultancyMasterBA.SelectEmployeeCentreCode(item);
        }
    }

}