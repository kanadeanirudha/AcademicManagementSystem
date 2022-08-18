using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.ServiceAccess
{
    public interface ILeaveSessionServiceAccess
    {
        IBaseEntityResponse<LeaveSession> InsertLeaveSession(LeaveSession item);
        IBaseEntityResponse<LeaveSession> UpdateLeaveSession(LeaveSession item);
        IBaseEntityResponse<LeaveSession> DeleteLeaveSession(LeaveSession item);
        IBaseEntityCollectionResponse<LeaveSession> GetBySearch(LeaveSessionSearchRequest searchRequest);
        IBaseEntityResponse<LeaveSession> SelectByID(LeaveSession item);
        IBaseEntityResponse<LeaveSession> SelectByEmployeeIDAndCentreCode(LeaveSessionSearchRequest searchRequest);
      

        IBaseEntityResponse<LeaveSession> InsertLeaveSessionDetails(LeaveSession item);
        IBaseEntityResponse<LeaveSession> UpdateLeaveSessionDetails(LeaveSession item);
        IBaseEntityResponse<LeaveSession> DeleteLeaveSessionDetails(LeaveSession item);
        IBaseEntityCollectionResponse<LeaveSession> GetLeaveSessionDetailsBySearch(LeaveSessionSearchRequest searchRequest);
        IBaseEntityResponse<LeaveSession> SelectLeaveSessionDetailsByID(LeaveSession item);

        IBaseEntityCollectionResponse<LeaveSession> GetByFromLeaveSessionID(LeaveSessionSearchRequest searchRequest);
        
    }
}
