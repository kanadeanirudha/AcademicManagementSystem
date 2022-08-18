using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.Business.BusinessAction
{
    public interface IToolQualifyingExamSubjectBA
    {
        IBaseEntityResponse<ToolQualifyingExamSubject> InsertToolQualifyingExamSubject(ToolQualifyingExamSubject item);
        IBaseEntityResponse<ToolQualifyingExamSubject> UpdateToolQualifyingExamSubject(ToolQualifyingExamSubject item);
        IBaseEntityResponse<ToolQualifyingExamSubject> DeleteToolQualifyingExamSubject(ToolQualifyingExamSubject item);
        IBaseEntityCollectionResponse<ToolQualifyingExamSubject> GetBySearch(ToolQualifyingExamSubjectSearchRequest searchRequest);
        IBaseEntityResponse<ToolQualifyingExamSubject> SelectByID(ToolQualifyingExamSubject item);
        IBaseEntityCollectionResponse<ToolQualifyingExamSubject> GetByQualifyingExamSubjectList(ToolQualifyingExamSubjectSearchRequest searchRequest);
    }
}
