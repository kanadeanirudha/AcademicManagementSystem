using AMS.Base.DTO;
using AMS.Business.BusinessAction;
using AMS.DTO;
namespace AMS.ServiceAccess
{
    public class GeneralTaskReportingDetailsServiceAccess : IGeneralTaskReportingDetailsServiceAccess
    {
        IGeneralTaskReportingDetailsBA _generalTaskReportingDetailsBA = null;
        public GeneralTaskReportingDetailsServiceAccess()
        {
            _generalTaskReportingDetailsBA = new GeneralTaskReportingDetailsBA();
        }
        public IBaseEntityResponse<GeneralTaskReportingDetails> InsertGeneralTaskReportingMaster(GeneralTaskReportingDetails item)
        {
            return _generalTaskReportingDetailsBA.InsertGeneralTaskReportingMaster(item);
        }
        public IBaseEntityResponse<GeneralTaskReportingDetails> InsertGeneralTaskApprovalStageDetails(GeneralTaskReportingDetails item)
        {
            return _generalTaskReportingDetailsBA.InsertGeneralTaskApprovalStageDetails(item);
        }
        public IBaseEntityResponse<GeneralTaskReportingDetails> InsertGeneralTaskReportingDetails(GeneralTaskReportingDetails item)
        {
            return _generalTaskReportingDetailsBA.InsertGeneralTaskReportingDetails(item);
        }
        public IBaseEntityResponse<GeneralTaskReportingDetails> UpdateGeneralTaskReportingDetails(GeneralTaskReportingDetails item)
        {
            return _generalTaskReportingDetailsBA.UpdateGeneralTaskReportingDetails(item);
        }
        public IBaseEntityResponse<GeneralTaskReportingDetails> DeleteGeneralTaskReportingDetails(GeneralTaskReportingDetails item)
        {
            return _generalTaskReportingDetailsBA.DeleteGeneralTaskReportingDetails(item);
        }
        public IBaseEntityCollectionResponse<GeneralTaskReportingDetails> GetBySearch(GeneralTaskReportingDetailsSearchRequest searchRequest)
        {
            return _generalTaskReportingDetailsBA.GetBySearch(searchRequest);
        }
        public IBaseEntityCollectionResponse<GeneralTaskReportingDetails> GetTaskReportingDetailsApprovalStages(GeneralTaskReportingDetailsSearchRequest searchRequest)
        {
            return _generalTaskReportingDetailsBA.GetTaskReportingDetailsApprovalStages(searchRequest);
        }
        public IBaseEntityCollectionResponse<GeneralTaskReportingDetails> GetTaskReportingDetailsApprovalStageDetails(GeneralTaskReportingDetailsSearchRequest searchRequest)
        {
            return _generalTaskReportingDetailsBA.GetTaskReportingDetailsApprovalStageDetails(searchRequest);
        }
        public IBaseEntityCollectionResponse<GeneralTaskReportingDetails> ReportingRoleIDsSearchList(GeneralTaskReportingDetailsSearchRequest searchRequest)
        {
            return _generalTaskReportingDetailsBA.ReportingRoleIDsSearchList(searchRequest);
        }
        public IBaseEntityCollectionResponse<GeneralTaskReportingDetails> DepartmentList(GeneralTaskReportingDetailsSearchRequest searchRequest)
        {
            return _generalTaskReportingDetailsBA.DepartmentList(searchRequest);
        }
        public IBaseEntityCollectionResponse<GeneralTaskReportingDetails> GetTaskApprovalBasedTableList(GeneralTaskReportingDetailsSearchRequest searchRequest)
        {
            return _generalTaskReportingDetailsBA.GetTaskApprovalBasedTableList(searchRequest);
        }
        public IBaseEntityCollectionResponse<GeneralTaskReportingDetails> GetTaskApprovalParamPrimaryKeyList(GeneralTaskReportingDetailsSearchRequest searchRequest)
        {
            return _generalTaskReportingDetailsBA.GetTaskApprovalParamPrimaryKeyList(searchRequest);
        }
        public IBaseEntityCollectionResponse<GeneralTaskReportingDetails> GetTaskApprovalKeyValueList(GeneralTaskReportingDetailsSearchRequest searchRequest)
        {
            return _generalTaskReportingDetailsBA.GetTaskApprovalKeyValueList(searchRequest);
        }
        public IBaseEntityCollectionResponse<GeneralTaskReportingDetails> GetGeneralTaskModelList(GeneralTaskReportingDetailsSearchRequest searchRequest)
        {
            return _generalTaskReportingDetailsBA.GetGeneralTaskModelList(searchRequest);
        }
        public IBaseEntityCollectionResponse<GeneralTaskReportingDetails> GetTaskApprovalBaseTableDisplayFieldList(GeneralTaskReportingDetailsSearchRequest searchRequest)
        {
            return _generalTaskReportingDetailsBA.GetTaskApprovalBaseTableDisplayFieldList(searchRequest);
        }
        public IBaseEntityResponse<GeneralTaskReportingDetails> SelectByID(GeneralTaskReportingDetails item)
        {
            return _generalTaskReportingDetailsBA.SelectByID(item);
        }
        public IBaseEntityResponse<GeneralTaskReportingDetails> UpdateEnagedByUserID(GeneralTaskReportingDetails item)
        {
            return _generalTaskReportingDetailsBA.UpdateEnagedByUserID(item);
        }

        public IBaseEntityResponse<GeneralTaskReportingDetails> GetTotalPendingCountTaskEmployeewise(GeneralTaskReportingDetails item)
        {
            return _generalTaskReportingDetailsBA.GetTotalPendingCountTaskEmployeewise(item);
        }
    }
}
