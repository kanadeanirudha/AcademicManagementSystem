using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.ServiceAccess
{
    public interface IEmployeeAttendanceReportServiceAccess
    {
        IBaseEntityCollectionResponse<EmployeeAttendanceReport> GetEmployeeAttendanceReportSelectAll(EmployeeAttendanceReportSearchRequest searchRequest);
        IBaseEntityCollectionResponse<EmployeeAttendanceReport> GetEmployeeCentreAndDepartmentWise(EmployeeAttendanceReportSearchRequest searchRequest);
        IBaseEntityCollectionResponse<EmployeeAttendanceReport> GetEmployeeAttendanceReportData(EmployeeAttendanceReportSearchRequest searchRequest);
    }
}
