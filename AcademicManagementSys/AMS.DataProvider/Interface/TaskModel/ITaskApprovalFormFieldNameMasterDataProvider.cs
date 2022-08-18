using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.DataProvider
{
    public interface ITaskApprovalFormFieldNameMasterDataProvider
    {
        IBaseEntityResponse<TaskApprovalFormFieldNameMaster> InsertTaskApprovalFormFieldNameMaster(TaskApprovalFormFieldNameMaster item);
        IBaseEntityResponse<TaskApprovalFormFieldNameMaster> UpdateTaskApprovalFormFieldNameMaster(TaskApprovalFormFieldNameMaster item);
        IBaseEntityResponse<TaskApprovalFormFieldNameMaster> DeleteTaskApprovalFormFieldNameMaster(TaskApprovalFormFieldNameMaster item);
        IBaseEntityCollectionResponse<TaskApprovalFormFieldNameMaster> GetTaskApprovalFormFieldNameMasterBySearch(TaskApprovalFormFieldNameMasterSearchRequest searchRequest);
        IBaseEntityCollectionResponse<TaskApprovalFormFieldNameMaster> GetTaskApprovalFormFieldNameMasterSearchList(TaskApprovalFormFieldNameMasterSearchRequest searchRequest);
        IBaseEntityResponse<TaskApprovalFormFieldNameMaster> GetTaskApprovalFormFieldNameMasterByID(TaskApprovalFormFieldNameMaster item);
    }
}
