using AMS.Base.DTO;
using AMS.Business.BusinessActions;
using AMS.DTO;
namespace AMS.ServiceAccess
{
    public class AttendenceMonitoringSystemServiceAccess : IAttendenceMonitoringSystemServiceAccess
    {
        IAttendenceMonitoringSystemBA _AttendenceMonitoringSystemBA = null;
        public AttendenceMonitoringSystemServiceAccess()
        {
            _AttendenceMonitoringSystemBA = new AttendenceMonitoringSystemBA();
        }
        public IBaseEntityCollectionResponse<AttendenceMonitoringSystem> GetAttendenceMonitoringSystemBySearch(AttendenceMonitoringSystemSearchRequest searchRequest)
        {
            return _AttendenceMonitoringSystemBA.GetAttendenceMonitoringSystemBySearch(searchRequest);
        }
        public IBaseEntityResponse<AttendenceMonitoringSystem> GetAttendenceMonitoringSystemByCentreCode(AttendenceMonitoringSystem item)
        {
            return _AttendenceMonitoringSystemBA.GetAttendenceMonitoringSystemByCentreCode(item);
        }
        public IBaseEntityCollectionResponse<AttendenceMonitoringSystem> GetEmployeeList(AttendenceMonitoringSystemSearchRequest searchRequest)
        {
            return _AttendenceMonitoringSystemBA.GetEmployeeList(searchRequest);
        }
        public IBaseEntityCollectionResponse<AttendenceMonitoringSystem> GetAttendenceDetailsByEmployeeID(AttendenceMonitoringSystemSearchRequest searchRequest)
        {
            return _AttendenceMonitoringSystemBA.GetAttendenceDetailsByEmployeeID(searchRequest);
        }


    }
}
