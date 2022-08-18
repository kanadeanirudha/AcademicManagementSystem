using AMS.Base.DTO;
using AMS.Business.BusinessAction;
using AMS.DTO;
namespace AMS.ServiceAccess
{
    public class LeaveEmployeeApplicationStatusReportServiceAccess : ILeaveEmployeeApplicationStatusReportServiceAccess
    {
        ILeaveEmployeeApplicationStatusReportBA _leaveLateMarkRulesDetailsBA = null;
        public LeaveEmployeeApplicationStatusReportServiceAccess()
        {
            _leaveLateMarkRulesDetailsBA = new LeaveEmployeeApplicationStatusReportBA();
        }

        public IBaseEntityCollectionResponse<LeaveEmployeeApplicationStatusReport> GetBySearch(LeaveEmployeeApplicationStatusReportSearchRequest searchRequest)
        {
            return _leaveLateMarkRulesDetailsBA.GetBySearch(searchRequest);
        }

    }
}
