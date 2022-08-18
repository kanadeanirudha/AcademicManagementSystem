using AMS.Base.DTO;
using AMS.Business.BusinessAction;
using AMS.DTO;
namespace AMS.ServiceAccess
{
    public class ToolTemplateApplicableServiceAccess : IToolTemplateApplicableServiceAccess
    {
        IToolTemplateApplicableBA _toolTemplateApplicableBA = null;
        public ToolTemplateApplicableServiceAccess()
        {
            _toolTemplateApplicableBA = new ToolTemplateApplicableBA();
        }
        public IBaseEntityResponse<ToolTemplateApplicable> InsertToolTemplateApplicable(ToolTemplateApplicable item)
        {
            return _toolTemplateApplicableBA.InsertToolTemplateApplicable(item);
        }
        public IBaseEntityResponse<ToolTemplateApplicable> UpdateToolTemplateApplicable(ToolTemplateApplicable item)
        {
            return _toolTemplateApplicableBA.UpdateToolTemplateApplicable(item);
        }
        public IBaseEntityResponse<ToolTemplateApplicable> DeleteToolTemplateApplicable(ToolTemplateApplicable item)
        {
            return _toolTemplateApplicableBA.DeleteToolTemplateApplicable(item);
        }
        public IBaseEntityCollectionResponse<ToolTemplateApplicable> GetBySearch(ToolTemplateApplicableSearchRequest searchRequest)
        {
            return _toolTemplateApplicableBA.GetBySearch(searchRequest);
        }
        public IBaseEntityResponse<ToolTemplateApplicable> SelectByID(ToolTemplateApplicable item)
        {
            return _toolTemplateApplicableBA.SelectByID(item);
        }
        public IBaseEntityCollectionResponse<ToolTemplateApplicable> GetBySearchListBranchDetails(ToolTemplateApplicableSearchRequest searchRequest)
        {
            return _toolTemplateApplicableBA.GetBySearchListBranchDetails(searchRequest);
        }
    }
}
