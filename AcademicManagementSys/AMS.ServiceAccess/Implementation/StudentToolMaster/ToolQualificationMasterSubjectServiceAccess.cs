using AMS.Base.DTO;
using AMS.Business.BusinessAction;
using AMS.DTO;
namespace AMS.ServiceAccess
{
    public class ToolQualificationMasterSubjectServiceAccess : IToolQualificationMasterSubjectServiceAccess
    {
        IToolQualificationMasterSubjectBA _ToolQualificationMasterSubjectBA = null;
        public ToolQualificationMasterSubjectServiceAccess()
        {
            _ToolQualificationMasterSubjectBA = new ToolQualificationMasterSubjectBA();
        }
        public IBaseEntityResponse<ToolQualificationMasterSubject> InsertToolQualificationMasterSubject(ToolQualificationMasterSubject item)
        {
            return _ToolQualificationMasterSubjectBA.InsertToolQualificationMasterSubject(item);
        }
        public IBaseEntityResponse<ToolQualificationMasterSubject> UpdateToolQualificationMasterSubject(ToolQualificationMasterSubject item)
        {
            return _ToolQualificationMasterSubjectBA.UpdateToolQualificationMasterSubject(item);
        }
        public IBaseEntityResponse<ToolQualificationMasterSubject> DeleteToolQualificationMasterSubject(ToolQualificationMasterSubject item)
        {
            return _ToolQualificationMasterSubjectBA.DeleteToolQualificationMasterSubject(item);
        }
        public IBaseEntityCollectionResponse<ToolQualificationMasterSubject> GetBySearch(ToolQualificationMasterSubjectSearchRequest searchRequest)
        {
            return _ToolQualificationMasterSubjectBA.GetBySearch(searchRequest);
        }
        public IBaseEntityResponse<ToolQualificationMasterSubject> SelectByID(ToolQualificationMasterSubject item)
        {
            return _ToolQualificationMasterSubjectBA.SelectByID(item);
        }
        public IBaseEntityCollectionResponse<ToolQualificationMasterSubject> GetByQualificationMasterSubjectList(ToolQualificationMasterSubjectSearchRequest searchRequest)
        {
            return _ToolQualificationMasterSubjectBA.GetByQualificationMasterSubjectList(searchRequest);
        }
        public IBaseEntityCollectionResponse<ToolQualificationMasterSubject> GetByQualificationMasterSubjectListByBranchDetailID_StandardNumber_EducationType(ToolQualificationMasterSubjectSearchRequest searchRequest)
        {
            return _ToolQualificationMasterSubjectBA.GetByQualificationMasterSubjectListByBranchDetailID_StandardNumber_EducationType(searchRequest);
        }
    }
}
