using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.ServiceAccess
{
    public interface IEmployeeEnterpriseReportServiceAccess
    {
        IBaseEntityCollectionResponse<EmployeeEnterpriseReport> GetEmployeePerformanceMonitoringReportBySearch(EmployeeEnterpriseReportSearchRequest searchRequest);
        IBaseEntityResponse<EmployeeEnterpriseReport> GetEmployeeEnterpriseReportByCentreCode(EmployeeEnterpriseReport item);
        IBaseEntityCollectionResponse<EmployeeEnterpriseReport> GetEmployeeList(EmployeeEnterpriseReportSearchRequest searchRequest);
        IBaseEntityCollectionResponse<EmployeeEnterpriseReport> GetByCentreCodeAndDeptID(EmployeeEnterpriseReportSearchRequest searchRequest);

    }
}
