using AMS.Base.DTO;
using AMS.Business.BusinessAction;
using AMS.DTO;
namespace AMS.ServiceAccess
{
    public class ToolQualifyingExamApplicableServiceAccess : IToolQualifyingExamApplicableServiceAccess
    {
        IToolQualifyingExamApplicableBA _toolQualifyingExamApplicableBA = null;
        public ToolQualifyingExamApplicableServiceAccess()
        {
            _toolQualifyingExamApplicableBA = new ToolQualifyingExamApplicableBA();
        }
        public IBaseEntityResponse<ToolQualifyingExamApplicable> InsertToolQualifyingExamApplicable(ToolQualifyingExamApplicable item)
        {
            return _toolQualifyingExamApplicableBA.InsertToolQualifyingExamApplicable(item);
        }
        public IBaseEntityResponse<ToolQualifyingExamApplicable> UpdateToolQualifyingExamApplicable(ToolQualifyingExamApplicable item)
        {
            return _toolQualifyingExamApplicableBA.UpdateToolQualifyingExamApplicable(item);
        }
        public IBaseEntityResponse<ToolQualifyingExamApplicable> DeleteToolQualifyingExamApplicable(ToolQualifyingExamApplicable item)
        {
            return _toolQualifyingExamApplicableBA.DeleteToolQualifyingExamApplicable(item);
        }
        public IBaseEntityCollectionResponse<ToolQualifyingExamApplicable> GetBySearch(ToolQualifyingExamApplicableSearchRequest searchRequest)
        {
            return _toolQualifyingExamApplicableBA.GetBySearch(searchRequest);
        }
        public IBaseEntityResponse<ToolQualifyingExamApplicable> SelectByID(ToolQualifyingExamApplicable item)
        {
            return _toolQualifyingExamApplicableBA.SelectByID(item);
        }
        public IBaseEntityCollectionResponse<ToolQualifyingExamApplicable> GetBySearchListBranchDetails(ToolQualifyingExamApplicableSearchRequest searchRequest)
        {
            return _toolQualifyingExamApplicableBA.GetBySearchListBranchDetails(searchRequest);
        }
    }
}
