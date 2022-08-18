using AMS.Base.DTO;
using AMS.DTO;
using AMS.Business.BusinessAction;

namespace AMS.ServiceAccess
{
    public class EmployeeAttendanceReportServiceAccess :IEmployeeAttendanceReportServiceAccess
    {
        IEmployeeAttendanceReportBA _employeeAttendanceReportBA = null;

        public EmployeeAttendanceReportServiceAccess()
        {
            _employeeAttendanceReportBA = new EmployeeAttendanceReportBA();
        }

        public IBaseEntityCollectionResponse<EmployeeAttendanceReport> GetEmployeeAttendanceReportSelectAll(EmployeeAttendanceReportSearchRequest searchRequest)
        {
            return _employeeAttendanceReportBA.GetEmployeeAttendanceReportSelectAll(searchRequest);
        }

        public IBaseEntityCollectionResponse<EmployeeAttendanceReport>GetEmployeeCentreAndDepartmentWise(EmployeeAttendanceReportSearchRequest searchRequest)
        {
            return _employeeAttendanceReportBA.GetEmployeeCentreAndDepartmentWise(searchRequest);
        }

        public IBaseEntityCollectionResponse<EmployeeAttendanceReport> GetEmployeeAttendanceReportData(EmployeeAttendanceReportSearchRequest searchRequest)
        {
            return _employeeAttendanceReportBA.GetEmployeeAttendanceReportData(searchRequest);
        }
    }
}
