using AMS.Base.DTO;
using AMS.Business.BusinessActions;
using AMS.DTO;
namespace AMS.ServiceAccess
{
    public class EmpEmployeeMasterServiceAccess : IEmpEmployeeMasterServiceAccess
    {
        IEmpEmployeeMasterBA _empEmployeeMasterBA = null;
        public EmpEmployeeMasterServiceAccess()
        {
            _empEmployeeMasterBA = new EmpEmployeeMasterBA();
        }
        public IBaseEntityResponse<EmpEmployeeMaster> InsertEmpEmployeeMaster(EmpEmployeeMaster item)
        {
            return _empEmployeeMasterBA.InsertEmpEmployeeMaster(item);
        }
        public IBaseEntityResponse<EmpEmployeeMaster> UpdateEmpEmployeeMaster(EmpEmployeeMaster item)
        {
            return _empEmployeeMasterBA.UpdateEmpEmployeeMaster(item);
        }
        public IBaseEntityResponse<EmpEmployeeMaster> UpdateEmpEmployeeMasterPersonalInformation(EmpEmployeeMaster item)
        {
            return _empEmployeeMasterBA.UpdateEmpEmployeeMasterPersonalInformation(item);
        }
        public IBaseEntityResponse<EmpEmployeeMaster> UpdateEmpEmployeeMasterOfficeDetails(EmpEmployeeMaster item)
        {
            return _empEmployeeMasterBA.UpdateEmpEmployeeMasterOfficeDetails(item);
        }
        
        public IBaseEntityResponse<EmpEmployeeMaster> DeleteEmpEmployeeMaster(EmpEmployeeMaster item)
        {
            return _empEmployeeMasterBA.DeleteEmpEmployeeMaster(item);
        }
        public IBaseEntityCollectionResponse<EmpEmployeeMaster> GetBySearch(EmpEmployeeMasterSearchRequest searchRequest)
        {
            return _empEmployeeMasterBA.GetBySearch(searchRequest);
        }
        public IBaseEntityResponse<EmpEmployeeMaster> SelectByID(EmpEmployeeMaster item)
        {
            return _empEmployeeMasterBA.SelectByID(item);
        }
        public IBaseEntityCollectionResponse<EmpEmployeeMaster> GetEmployeeList(EmpEmployeeMasterSearchRequest searchRequest)
        {
            return _empEmployeeMasterBA.GetEmployeeList(searchRequest);
        }
        public IBaseEntityCollectionResponse<EmpEmployeeMaster> GetEmployeeCentrewiseSearchList(EmpEmployeeMasterSearchRequest searchRequest)
        {
            return _empEmployeeMasterBA.GetEmployeeCentrewiseSearchList(searchRequest);
        }
        public IBaseEntityCollectionResponse<EmpEmployeeMaster> GetEmployeeRoleCentrewiseSearchList(EmpEmployeeMasterSearchRequest searchRequest)
        {
            return _empEmployeeMasterBA.GetEmployeeRoleCentrewiseSearchList(searchRequest);
        }
        public IBaseEntityCollectionResponse<EmpEmployeeMaster> GetByCentreCodeAndDeptID(EmpEmployeeMasterSearchRequest searchRequest)
        {
            return _empEmployeeMasterBA.GetByCentreCodeAndDeptID(searchRequest);
        }
        public IBaseEntityResponse<EmpEmployeeMaster> GetCurrentPassword(EmpEmployeeMaster item)
        {
            return _empEmployeeMasterBA.GetCurrentPassword(item);
        }
        public IBaseEntityResponse<EmpEmployeeMaster> InsertNewPassword(EmpEmployeeMaster item)
        {
            return _empEmployeeMasterBA.InsertNewPassword(item);
        }
        public IBaseEntityCollectionResponse<EmpEmployeeMaster> GetCallerEmployeeList(EmpEmployeeMasterSearchRequest searchRequest)
        {
            return _empEmployeeMasterBA.GetCallerEmployeeList(searchRequest);
        }
        public IBaseEntityCollectionResponse<EmpEmployeeMaster> GetByEmployeeInCRMSales(EmpEmployeeMasterSearchRequest searchRequest)
        {
            return _empEmployeeMasterBA.GetByEmployeeInCRMSales(searchRequest);
        }
        public IBaseEntityCollectionResponse<EmpEmployeeMaster> GetListEmpEmployeeMasterForCRMSalesGroup(EmpEmployeeMasterSearchRequest searchRequest)
        {
            return _empEmployeeMasterBA.GetListEmpEmployeeMasterForCRMSalesGroup(searchRequest);
        }
        public IBaseEntityCollectionResponse<EmpEmployeeMaster> GetListEmpEmployeeMasterForTargetException(EmpEmployeeMasterSearchRequest searchRequest)
        {
            return _empEmployeeMasterBA.GetListEmpEmployeeMasterForTargetException(searchRequest);
        }
        //For Staff Allocation

        public IBaseEntityCollectionResponse<EmpEmployeeMaster> GetEmployeeNameList(EmpEmployeeMasterSearchRequest searchRequest)
        {
            return _empEmployeeMasterBA.GetEmployeeNameList(searchRequest);
        }
    }
}
