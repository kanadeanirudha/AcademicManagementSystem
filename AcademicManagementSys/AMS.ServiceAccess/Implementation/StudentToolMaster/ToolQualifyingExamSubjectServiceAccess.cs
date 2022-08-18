using AMS.Base.DTO;
using AMS.Business.BusinessAction;
using AMS.DTO;
namespace AMS.ServiceAccess
{
    public class ToolQualifyingExamSubjectServiceAccess : IToolQualifyingExamSubjectServiceAccess
    {
        IToolQualifyingExamSubjectBA _toolQualifyingExamSubjectBA = null;
        public ToolQualifyingExamSubjectServiceAccess()
        {
            _toolQualifyingExamSubjectBA = new ToolQualifyingExamSubjectBA();
        }
        public IBaseEntityResponse<ToolQualifyingExamSubject> InsertToolQualifyingExamSubject(ToolQualifyingExamSubject item)
        {
            return _toolQualifyingExamSubjectBA.InsertToolQualifyingExamSubject(item);
        }
        public IBaseEntityResponse<ToolQualifyingExamSubject> UpdateToolQualifyingExamSubject(ToolQualifyingExamSubject item)
        {
            return _toolQualifyingExamSubjectBA.UpdateToolQualifyingExamSubject(item);
        }
        public IBaseEntityResponse<ToolQualifyingExamSubject> DeleteToolQualifyingExamSubject(ToolQualifyingExamSubject item)
        {
            return _toolQualifyingExamSubjectBA.DeleteToolQualifyingExamSubject(item);
        }
        public IBaseEntityCollectionResponse<ToolQualifyingExamSubject> GetBySearch(ToolQualifyingExamSubjectSearchRequest searchRequest)
        {
            return _toolQualifyingExamSubjectBA.GetBySearch(searchRequest);
        }
        public IBaseEntityResponse<ToolQualifyingExamSubject> SelectByID(ToolQualifyingExamSubject item)
        {
            return _toolQualifyingExamSubjectBA.SelectByID(item);
        }
        public IBaseEntityCollectionResponse<ToolQualifyingExamSubject> GetByQualifyingExamSubjectList(ToolQualifyingExamSubjectSearchRequest searchRequest)
        {
            return _toolQualifyingExamSubjectBA.GetByQualifyingExamSubjectList(searchRequest);
        }
    }
}
