using AMS.Base.DTO;
using AMS.Business.BusinessAction;
using AMS.DTO;
namespace AMS.ServiceAccess
{
    public class ToolQualificationExamMasterServiceAccess : IToolQualificationExamMasterServiceAccess
    {
        IToolQualificationExamMasterBA _toolQualificationExamMasterBA = null;
        public ToolQualificationExamMasterServiceAccess()
        {
            _toolQualificationExamMasterBA = new ToolQualificationExamMasterBA();
        }
        public IBaseEntityResponse<ToolQualificationExamMaster> InsertToolQualificationExamMaster(ToolQualificationExamMaster item)
        {
            return _toolQualificationExamMasterBA.InsertToolQualificationExamMaster(item);
        }
        public IBaseEntityResponse<ToolQualificationExamMaster> UpdateToolQualificationExamMaster(ToolQualificationExamMaster item)
        {
            return _toolQualificationExamMasterBA.UpdateToolQualificationExamMaster(item);
        }
        public IBaseEntityResponse<ToolQualificationExamMaster> DeleteToolQualificationExamMaster(ToolQualificationExamMaster item)
        {
            return _toolQualificationExamMasterBA.DeleteToolQualificationExamMaster(item);
        }
        public IBaseEntityCollectionResponse<ToolQualificationExamMaster> GetBySearch(ToolQualificationExamMasterSearchRequest searchRequest)
        {
            return _toolQualificationExamMasterBA.GetBySearch(searchRequest);
        }
        public IBaseEntityResponse<ToolQualificationExamMaster> SelectByID(ToolQualificationExamMaster item)
        {
            return _toolQualificationExamMasterBA.SelectByID(item);
        }
    }
}
