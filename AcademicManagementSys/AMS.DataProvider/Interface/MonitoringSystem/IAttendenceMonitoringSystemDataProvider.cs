using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.DataProvider
{
    public interface IAttendenceMonitoringSystemDataProvider
    {
        IBaseEntityCollectionResponse<AttendenceMonitoringSystem> GetAttendenceMonitoringSystemBySearch(AttendenceMonitoringSystemSearchRequest searchRequest);
        IBaseEntityResponse<AttendenceMonitoringSystem> GetAttendenceMonitoringSystemByCentreCode(AttendenceMonitoringSystem item);
        IBaseEntityCollectionResponse<AttendenceMonitoringSystem> GetEmployeeList(AttendenceMonitoringSystemSearchRequest searchRequest);
        IBaseEntityCollectionResponse<AttendenceMonitoringSystem> GetAttendenceDetailsByEmployeeID(AttendenceMonitoringSystemSearchRequest searchRequest);

    }
}
