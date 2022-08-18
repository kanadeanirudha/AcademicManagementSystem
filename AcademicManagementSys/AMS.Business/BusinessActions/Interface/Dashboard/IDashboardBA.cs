using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.Business.BusinessAction
{
    public interface IDashboardBA
    {
        IBaseEntityResponse<Dashboard> InsertDashboard(Dashboard item);
        IBaseEntityResponse<Dashboard> GeneralRequestApprovalInsert(Dashboard item);
        IBaseEntityResponse<Dashboard> InformativeNotificationsReadInsert(Dashboard item);
        IBaseEntityResponse<Dashboard> UpdateDashboard(Dashboard item);
        IBaseEntityResponse<Dashboard> DeleteDashboard(Dashboard item);
        IBaseEntityCollectionResponse<Dashboard> GetBySearch(DashboardSearchRequest searchRequest);
        IBaseEntityCollectionResponse<Dashboard> GetGeneralRequestBySearch(DashboardSearchRequest searchRequest);
        IBaseEntityCollectionResponse<Dashboard> GetInformativeNotificationListBySearch(DashboardSearchRequest searchRequest);
        IBaseEntityResponse<Dashboard> SelectByID(Dashboard item);
        IBaseEntityCollectionResponse<Dashboard> GetByRequestApprovalField(DashboardSearchRequest searchRequest);
        IBaseEntityCollectionResponse<Dashboard> GetByGeneralRequestApprovalField(DashboardSearchRequest searchRequest);
        IBaseEntityCollectionResponse<Dashboard> GetGeneralTaskModelListByPersonID(DashboardSearchRequest searchRequest);
        IBaseEntityResponse<Dashboard> ApproveAllLeaveApplication(Dashboard item);
        IBaseEntityResponse<Dashboard> ApproveAllCompensatoryLeaveApplication(Dashboard item);
        IBaseEntityResponse<Dashboard> ApproveAllManualAttendanceApplication(Dashboard item);
        IBaseEntityResponse<Dashboard> ApproveAllAttendanceSpecialRequestApplication(Dashboard item);
        IBaseEntityCollectionResponse<Dashboard> GetDashboardContentListByAdminRoleID(DashboardSearchRequest searchRequest);

        IBaseEntityCollectionResponse<Dashboard> GetDeshboardAllocationBySearch(DashboardSearchRequest searchRequest);
        IBaseEntityResponse<Dashboard> DeleteContaintAllocateStatus(Dashboard item);
        IBaseEntityResponse<Dashboard> InsertContaintAllocateStatus(Dashboard item);
    }
}
