using AMS.Base.DTO;
using AMS.Business.BusinessActions;
using AMS.DTO;
namespace AMS.ServiceAccess
{
    public class EmployeeEnterpriseReportServiceAccess : IEmployeeEnterpriseReportServiceAccess
    {
        IEmployeeEnterpriseReportBA _EmployeeEnterpriseReportBA = null;
        public EmployeeEnterpriseReportServiceAccess()
        {
            _EmployeeEnterpriseReportBA = new EmployeeEnterpriseReportBA();
        }
        public IBaseEntityCollectionResponse<EmployeeEnterpriseReport> GetEmployeePerformanceMonitoringReportBySearch(EmployeeEnterpriseReportSearchRequest searchRequest)
        {
            return _EmployeeEnterpriseReportBA.GetEmployeePerformanceMonitoringReportBySearch(searchRequest);
        }
        public IBaseEntityResponse<EmployeeEnterpriseReport> GetEmployeeEnterpriseReportByCentreCode(EmployeeEnterpriseReport item)
        {
            return _EmployeeEnterpriseReportBA.GetEmployeeEnterpriseReportByCentreCode(item);
        }
        public IBaseEntityCollectionResponse<EmployeeEnterpriseReport> GetEmployeeList(EmployeeEnterpriseReportSearchRequest searchRequest)
        {
            return _EmployeeEnterpriseReportBA.GetEmployeeList(searchRequest);
        }
        public IBaseEntityCollectionResponse<EmployeeEnterpriseReport> GetByCentreCodeAndDeptID(EmployeeEnterpriseReportSearchRequest searchRequest)
        {
            return _EmployeeEnterpriseReportBA.GetByCentreCodeAndDeptID(searchRequest);
        }


    }
}
