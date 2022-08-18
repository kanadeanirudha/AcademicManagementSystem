using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.Business.BusinessActions
{
    public interface IEmpEmployeeMasterBA
    {
        IBaseEntityResponse<EmpEmployeeMaster> InsertEmpEmployeeMaster(EmpEmployeeMaster item);
        IBaseEntityResponse<EmpEmployeeMaster> UpdateEmpEmployeeMaster(EmpEmployeeMaster item);
        IBaseEntityResponse<EmpEmployeeMaster> UpdateEmpEmployeeMasterPersonalInformation(EmpEmployeeMaster item);
        IBaseEntityResponse<EmpEmployeeMaster> UpdateEmpEmployeeMasterOfficeDetails(EmpEmployeeMaster item);
        IBaseEntityResponse<EmpEmployeeMaster> DeleteEmpEmployeeMaster(EmpEmployeeMaster item);
        IBaseEntityCollectionResponse<EmpEmployeeMaster> GetBySearch(EmpEmployeeMasterSearchRequest searchRequest);
        IBaseEntityResponse<EmpEmployeeMaster> SelectByID(EmpEmployeeMaster item);
        IBaseEntityCollectionResponse<EmpEmployeeMaster> GetEmployeeList(EmpEmployeeMasterSearchRequest searchRequest);
        IBaseEntityCollectionResponse<EmpEmployeeMaster> GetEmployeeCentrewiseSearchList(EmpEmployeeMasterSearchRequest searchRequest);
        IBaseEntityCollectionResponse<EmpEmployeeMaster> GetEmployeeRoleCentrewiseSearchList(EmpEmployeeMasterSearchRequest searchRequest);
        IBaseEntityCollectionResponse<EmpEmployeeMaster> GetByCentreCodeAndDeptID(EmpEmployeeMasterSearchRequest searchRequest);
        IBaseEntityResponse<EmpEmployeeMaster> GetCurrentPassword(EmpEmployeeMaster item);
        IBaseEntityResponse<EmpEmployeeMaster> InsertNewPassword(EmpEmployeeMaster item);
        IBaseEntityCollectionResponse<EmpEmployeeMaster> GetCallerEmployeeList(EmpEmployeeMasterSearchRequest searchRequest);
        IBaseEntityCollectionResponse<EmpEmployeeMaster> GetByEmployeeInCRMSales(EmpEmployeeMasterSearchRequest searchRequest);
        IBaseEntityCollectionResponse<EmpEmployeeMaster> GetListEmpEmployeeMasterForCRMSalesGroup(EmpEmployeeMasterSearchRequest searchRequest);
        IBaseEntityCollectionResponse<EmpEmployeeMaster> GetListEmpEmployeeMasterForTargetException(EmpEmployeeMasterSearchRequest searchRequest);
        //Staff Allocation
        IBaseEntityCollectionResponse<EmpEmployeeMaster> GetEmployeeNameList(EmpEmployeeMasterSearchRequest searchRequest);
    }
}
