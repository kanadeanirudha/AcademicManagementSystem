using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.ServiceAccess
{
    public interface ITaskApprovalFormFieldNameMasterServiceAccess
    {
        IBaseEntityResponse<TaskApprovalFormFieldNameMaster> InsertTaskApprovalFormFieldNameMaster(TaskApprovalFormFieldNameMaster item);
        IBaseEntityResponse<TaskApprovalFormFieldNameMaster> UpdateTaskApprovalFormFieldNameMaster(TaskApprovalFormFieldNameMaster item);
        IBaseEntityResponse<TaskApprovalFormFieldNameMaster> DeleteTaskApprovalFormFieldNameMaster(TaskApprovalFormFieldNameMaster item);
        IBaseEntityCollectionResponse<TaskApprovalFormFieldNameMaster> GetBySearch(TaskApprovalFormFieldNameMasterSearchRequest searchRequest);
        IBaseEntityResponse<TaskApprovalFormFieldNameMaster> SelectByID(TaskApprovalFormFieldNameMaster item);
        IBaseEntityCollectionResponse<TaskApprovalFormFieldNameMaster> GetTaskApprovalFormFieldNameMasterSearchList(TaskApprovalFormFieldNameMasterSearchRequest searchRequest);
    }
}
