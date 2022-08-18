using AMS.Base.DTO;
using AMS.Business.BusinessAction;
using AMS.DTO;
namespace AMS.ServiceAccess
{
    public class ToolQualificationApplicableServiceAccess : IToolQualificationApplicableServiceAccess
    {
        IToolQualificationApplicableBA _ToolQualificationApplicableBA = null;
        public ToolQualificationApplicableServiceAccess()
        {
            _ToolQualificationApplicableBA = new ToolQualificationApplicableBA();
        }
        public IBaseEntityResponse<ToolQualificationApplicable> InsertToolQualificationApplicable(ToolQualificationApplicable item)
        {
            return _ToolQualificationApplicableBA.InsertToolQualificationApplicable(item);
        }
        public IBaseEntityResponse<ToolQualificationApplicable> UpdateToolQualificationApplicable(ToolQualificationApplicable item)
        {
            return _ToolQualificationApplicableBA.UpdateToolQualificationApplicable(item);
        }
        public IBaseEntityResponse<ToolQualificationApplicable> DeleteToolQualificationApplicable(ToolQualificationApplicable item)
        {
            return _ToolQualificationApplicableBA.DeleteToolQualificationApplicable(item);
        }
        public IBaseEntityCollectionResponse<ToolQualificationApplicable> GetBySearch(ToolQualificationApplicableSearchRequest searchRequest)
        {
            return _ToolQualificationApplicableBA.GetBySearch(searchRequest);
        }
        public IBaseEntityResponse<ToolQualificationApplicable> SelectByID(ToolQualificationApplicable item)
        {
            return _ToolQualificationApplicableBA.SelectByID(item);
        }
        public IBaseEntityCollectionResponse<ToolQualificationApplicable> GetBySearchListBranchDetails(ToolQualificationApplicableSearchRequest searchRequest)
        {
            return _ToolQualificationApplicableBA.GetBySearchListBranchDetails(searchRequest);
        }
    }
}
