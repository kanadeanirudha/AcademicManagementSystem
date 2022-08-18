using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.ServiceAccess
{
    public interface ILeavePostServiceAccess
    {
        IBaseEntityResponse<LeavePost> InsertLeavePostAtOpening(LeavePost item);
        IBaseEntityResponse<LeavePost> UpdateLeavePost(LeavePost item);
        IBaseEntityResponse<LeavePost> DeleteLeavePost(LeavePost item);
        IBaseEntityCollectionResponse<LeavePost> GetBySearch(LeavePostSearchRequest searchRequest);
        IBaseEntityResponse<LeavePost> SelectByID(LeavePost item);
        IBaseEntityResponse<LeavePost> InsertLeavePostAtYearEnd(LeavePost item);
        IBaseEntityCollectionResponse<LeavePost> GetLeaveSummaryAtTheYearEndBySearch(LeavePostSearchRequest searchRequest);
        
    }
}
