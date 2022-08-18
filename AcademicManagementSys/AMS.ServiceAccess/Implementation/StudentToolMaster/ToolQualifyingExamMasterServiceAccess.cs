using AMS.Base.DTO;
using AMS.Business.BusinessAction;
using AMS.DTO;
namespace AMS.ServiceAccess
{
    public class ToolQualifyingExamMasterServiceAccess : IToolQualifyingExamMasterServiceAccess
    {
        IToolQualifyingExamMasterBA _toolQualifyingExamMasterBA = null;
        public ToolQualifyingExamMasterServiceAccess()
        {
            _toolQualifyingExamMasterBA = new ToolQualifyingExamMasterBA();
        }
        public IBaseEntityResponse<ToolQualifyingExamMaster> InsertToolQualifyingExamMaster(ToolQualifyingExamMaster item)
        {
            return _toolQualifyingExamMasterBA.InsertToolQualifyingExamMaster(item);
        }
        public IBaseEntityResponse<ToolQualifyingExamMaster> UpdateToolQualifyingExamMaster(ToolQualifyingExamMaster item)
        {
            return _toolQualifyingExamMasterBA.UpdateToolQualifyingExamMaster(item);
        }
        public IBaseEntityResponse<ToolQualifyingExamMaster> DeleteToolQualifyingExamMaster(ToolQualifyingExamMaster item)
        {
            return _toolQualifyingExamMasterBA.DeleteToolQualifyingExamMaster(item);
        }
        public IBaseEntityCollectionResponse<ToolQualifyingExamMaster> GetBySearch(ToolQualifyingExamMasterSearchRequest searchRequest)
        {
            return _toolQualifyingExamMasterBA.GetBySearch(searchRequest);
        }
        public IBaseEntityResponse<ToolQualifyingExamMaster> SelectByID(ToolQualifyingExamMaster item)
        {
            return _toolQualifyingExamMasterBA.SelectByID(item);
        }
    }
}
