using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Business.BusinessActions
{
    public interface ITaskApprovalFormFieldNameMasterBA
    {
        IBaseEntityResponse<TaskApprovalFormFieldNameMaster> InsertTaskApprovalFormFieldNameMaster(TaskApprovalFormFieldNameMaster item);
        IBaseEntityResponse<TaskApprovalFormFieldNameMaster> UpdateTaskApprovalFormFieldNameMaster(TaskApprovalFormFieldNameMaster item);
        IBaseEntityResponse<TaskApprovalFormFieldNameMaster> DeleteTaskApprovalFormFieldNameMaster(TaskApprovalFormFieldNameMaster item);
        IBaseEntityCollectionResponse<TaskApprovalFormFieldNameMaster> GetBySearch(TaskApprovalFormFieldNameMasterSearchRequest searchRequest);
        IBaseEntityCollectionResponse<TaskApprovalFormFieldNameMaster> GetTaskApprovalFormFieldNameMasterSearchList(TaskApprovalFormFieldNameMasterSearchRequest searchRequest);
        IBaseEntityResponse<TaskApprovalFormFieldNameMaster> SelectByID(TaskApprovalFormFieldNameMaster item);
    }
}

