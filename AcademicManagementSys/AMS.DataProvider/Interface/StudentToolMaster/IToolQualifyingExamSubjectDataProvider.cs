using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.DataProvider
{
    public interface IToolQualifyingExamSubjectDataProvider
    {
        IBaseEntityResponse<ToolQualifyingExamSubject> InsertToolQualifyingExamSubject(ToolQualifyingExamSubject item);
        IBaseEntityResponse<ToolQualifyingExamSubject> UpdateToolQualifyingExamSubject(ToolQualifyingExamSubject item);
        IBaseEntityResponse<ToolQualifyingExamSubject> DeleteToolQualifyingExamSubject(ToolQualifyingExamSubject item);
        IBaseEntityCollectionResponse<ToolQualifyingExamSubject> GetToolQualifyingExamSubjectBySearch(ToolQualifyingExamSubjectSearchRequest searchRequest);
        IBaseEntityResponse<ToolQualifyingExamSubject> GetToolQualifyingExamSubjectByID(ToolQualifyingExamSubject item);
        IBaseEntityCollectionResponse<ToolQualifyingExamSubject> GetByQualifyingExamSubjectList(ToolQualifyingExamSubjectSearchRequest searchRequest);
    }
}
