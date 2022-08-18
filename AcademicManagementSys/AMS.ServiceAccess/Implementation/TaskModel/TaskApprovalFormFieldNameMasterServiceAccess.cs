using AMS.Base.DTO;
using AMS.Business.BusinessActions;
using AMS.DTO;

namespace AMS.ServiceAccess
{
    public class TaskApprovalFormFieldNameMasterServiceAccess : ITaskApprovalFormFieldNameMasterServiceAccess
    {
        ITaskApprovalFormFieldNameMasterBA _TaskApprovalFormFieldNameMasterBA = null;
        public TaskApprovalFormFieldNameMasterServiceAccess()
        {
            _TaskApprovalFormFieldNameMasterBA = new TaskApprovalFormFieldNameMasterBA();
        }
        public IBaseEntityResponse<TaskApprovalFormFieldNameMaster> InsertTaskApprovalFormFieldNameMaster(TaskApprovalFormFieldNameMaster item)
        {
            return _TaskApprovalFormFieldNameMasterBA.InsertTaskApprovalFormFieldNameMaster(item);
        }
        public IBaseEntityResponse<TaskApprovalFormFieldNameMaster> UpdateTaskApprovalFormFieldNameMaster(TaskApprovalFormFieldNameMaster item)
        {
            return _TaskApprovalFormFieldNameMasterBA.UpdateTaskApprovalFormFieldNameMaster(item);
        }
        public IBaseEntityResponse<TaskApprovalFormFieldNameMaster> DeleteTaskApprovalFormFieldNameMaster(TaskApprovalFormFieldNameMaster item)
        {
            return _TaskApprovalFormFieldNameMasterBA.DeleteTaskApprovalFormFieldNameMaster(item);
        }
        public IBaseEntityCollectionResponse<TaskApprovalFormFieldNameMaster> GetBySearch(TaskApprovalFormFieldNameMasterSearchRequest searchRequest)
        {
            return _TaskApprovalFormFieldNameMasterBA.GetBySearch(searchRequest);
        }
        public IBaseEntityCollectionResponse<TaskApprovalFormFieldNameMaster> GetTaskApprovalFormFieldNameMasterSearchList(TaskApprovalFormFieldNameMasterSearchRequest searchRequest)
        {
            return _TaskApprovalFormFieldNameMasterBA.GetTaskApprovalFormFieldNameMasterSearchList(searchRequest);
        }
        public IBaseEntityResponse<TaskApprovalFormFieldNameMaster> SelectByID(TaskApprovalFormFieldNameMaster item)
        {
            return _TaskApprovalFormFieldNameMasterBA.SelectByID(item);
        }
    }
}
