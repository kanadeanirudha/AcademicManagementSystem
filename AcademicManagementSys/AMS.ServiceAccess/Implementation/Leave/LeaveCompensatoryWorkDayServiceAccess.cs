using AMS.Base.DTO;
using AMS.Business.BusinessAction;
using AMS.DTO;
namespace AMS.ServiceAccess
{
    public class LeaveCompensatoryWorkDayServiceAccess : ILeaveCompensatoryWorkDayServiceAccess
    {
        ILeaveCompensatoryWorkDayBA _leaveCompensatoryWorkDayBA = null;
        public LeaveCompensatoryWorkDayServiceAccess()
        {
            _leaveCompensatoryWorkDayBA = new LeaveCompensatoryWorkDayBA();
        }
        public IBaseEntityResponse<LeaveCompensatoryWorkDay> InsertLeaveCompensatoryWorkDay(LeaveCompensatoryWorkDay item)
        {
            return _leaveCompensatoryWorkDayBA.InsertLeaveCompensatoryWorkDay(item);
        }
        public IBaseEntityResponse<LeaveCompensatoryWorkDay> UpdateLeaveCompensatoryWorkDay(LeaveCompensatoryWorkDay item)
        {
            return _leaveCompensatoryWorkDayBA.UpdateLeaveCompensatoryWorkDay(item);
        }
        public IBaseEntityResponse<LeaveCompensatoryWorkDay> DeleteLeaveCompensatoryWorkDay(LeaveCompensatoryWorkDay item)
        {
            return _leaveCompensatoryWorkDayBA.DeleteLeaveCompensatoryWorkDay(item);
        }
        public IBaseEntityCollectionResponse<LeaveCompensatoryWorkDay> GetBySearch(LeaveCompensatoryWorkDaySearchRequest searchRequest)
        {
            return _leaveCompensatoryWorkDayBA.GetBySearch(searchRequest);
        }
        public IBaseEntityResponse<LeaveCompensatoryWorkDay> SelectByID(LeaveCompensatoryWorkDay item)
        {
            return _leaveCompensatoryWorkDayBA.SelectByID(item);
        }      
        public IBaseEntityResponse<LeaveCompensatoryWorkDay> GetCompensatoryOffDayApplicationDetailsByID(LeaveCompensatoryWorkDay item)
        {
            return _leaveCompensatoryWorkDayBA.GetCompensatoryOffDayApplicationDetailsByID(item);
        }
        public IBaseEntityResponse<LeaveCompensatoryWorkDay> InsertApprovedCompensatoryWorkDayRecord(LeaveCompensatoryWorkDay item)
        {
            return _leaveCompensatoryWorkDayBA.InsertApprovedCompensatoryWorkDayRecord(item);
        }
        public IBaseEntityCollectionResponse<LeaveCompensatoryWorkDay> GetCompensatoryWorkDayDataByEmployeeAndLeaveSessionID(LeaveCompensatoryWorkDaySearchRequest searchRequest)
        {
            return _leaveCompensatoryWorkDayBA.GetCompensatoryWorkDayDataByEmployeeAndLeaveSessionID(searchRequest);
        }
        
    }
}
