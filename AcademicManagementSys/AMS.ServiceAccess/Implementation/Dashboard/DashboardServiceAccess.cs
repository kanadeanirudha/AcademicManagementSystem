using AMS.Base.DTO;
using AMS.Business.BusinessAction;
using AMS.DTO;
namespace AMS.ServiceAccess
{
    public class DashboardServiceAccess : IDashboardServiceAccess
    {
        IDashboardBA _DashboardBA = null;
        public DashboardServiceAccess()
        {
            _DashboardBA = new DashboardBA();
        }
        public IBaseEntityResponse<Dashboard> InsertDashboard(Dashboard item)
        {
            return _DashboardBA.InsertDashboard(item);
        }
        public IBaseEntityResponse<Dashboard> GeneralRequestApprovalInsert(Dashboard item)
        {
            return _DashboardBA.GeneralRequestApprovalInsert(item);
        }
        public IBaseEntityResponse<Dashboard> InformativeNotificationsReadInsert(Dashboard item)
        {
            return _DashboardBA.InformativeNotificationsReadInsert(item);
        }
        public IBaseEntityResponse<Dashboard> UpdateDashboard(Dashboard item)
        {
            return _DashboardBA.UpdateDashboard(item);
        }
        public IBaseEntityResponse<Dashboard> DeleteDashboard(Dashboard item)
        {
            return _DashboardBA.DeleteDashboard(item);
        }
        public IBaseEntityCollectionResponse<Dashboard> GetBySearch(DashboardSearchRequest searchRequest)
        {
            return _DashboardBA.GetBySearch(searchRequest);
        }
        public IBaseEntityCollectionResponse<Dashboard> GetGeneralRequestBySearch(DashboardSearchRequest searchRequest)
        {
            return _DashboardBA.GetGeneralRequestBySearch(searchRequest);
        }
        public IBaseEntityCollectionResponse<Dashboard> GetInformativeNotificationListBySearch(DashboardSearchRequest searchRequest)
        {
            return _DashboardBA.GetInformativeNotificationListBySearch(searchRequest);
        }
        public IBaseEntityResponse<Dashboard> SelectByID(Dashboard item)
        {
            return _DashboardBA.SelectByID(item);
        }
        public IBaseEntityCollectionResponse<Dashboard> GetByRequestApprovalField(DashboardSearchRequest searchRequest)
        {
            return _DashboardBA.GetByRequestApprovalField(searchRequest);
        }
        public IBaseEntityCollectionResponse<Dashboard> GetByGeneralRequestApprovalField(DashboardSearchRequest searchRequest)
        {
            return _DashboardBA.GetByGeneralRequestApprovalField(searchRequest);
        }
        public IBaseEntityCollectionResponse<Dashboard> GetGeneralTaskModelListByPersonID(DashboardSearchRequest searchRequest)
        {
            return _DashboardBA.GetGeneralTaskModelListByPersonID(searchRequest);
        }
        public IBaseEntityResponse<Dashboard> ApproveAllLeaveApplication(Dashboard item)
        {
            return _DashboardBA.ApproveAllLeaveApplication(item);
        }
        public IBaseEntityResponse<Dashboard> ApproveAllCompensatoryLeaveApplication(Dashboard item)
        {
            return _DashboardBA.ApproveAllCompensatoryLeaveApplication(item);
        }
        public IBaseEntityResponse<Dashboard> ApproveAllManualAttendanceApplication(Dashboard item)
        {
            return _DashboardBA.ApproveAllManualAttendanceApplication(item);
        }
        public IBaseEntityResponse<Dashboard> ApproveAllAttendanceSpecialRequestApplication(Dashboard item)
        {
            return _DashboardBA.ApproveAllAttendanceSpecialRequestApplication(item);
        }
        public IBaseEntityCollectionResponse<Dashboard> GetDashboardContentListByAdminRoleID(DashboardSearchRequest searchRequest)
        {
            return _DashboardBA.GetDashboardContentListByAdminRoleID(searchRequest);
        }

        public IBaseEntityCollectionResponse<Dashboard> GetDeshboardAllocationBySearch(DashboardSearchRequest searchRequest)
        {
            return _DashboardBA.GetDeshboardAllocationBySearch(searchRequest);
        }

        public IBaseEntityResponse<Dashboard> DeleteContaintAllocateStatus(Dashboard item)
        {
            return _DashboardBA.DeleteContaintAllocateStatus(item);
        }


        public IBaseEntityResponse<Dashboard> InsertContaintAllocateStatus(Dashboard item)
        {
            return _DashboardBA.InsertContaintAllocateStatus(item);
        }

    }
}
