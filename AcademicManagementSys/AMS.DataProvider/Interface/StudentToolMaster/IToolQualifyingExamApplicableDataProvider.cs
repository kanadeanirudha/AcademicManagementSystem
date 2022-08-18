using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.DataProvider
{
    public interface IToolQualifyingExamApplicableDataProvider
    {
        IBaseEntityResponse<ToolQualifyingExamApplicable> InsertToolQualifyingExamApplicable(ToolQualifyingExamApplicable item);
        IBaseEntityResponse<ToolQualifyingExamApplicable> UpdateToolQualifyingExamApplicable(ToolQualifyingExamApplicable item);
        IBaseEntityResponse<ToolQualifyingExamApplicable> DeleteToolQualifyingExamApplicable(ToolQualifyingExamApplicable item);
        IBaseEntityCollectionResponse<ToolQualifyingExamApplicable> GetToolQualifyingExamApplicableBySearch(ToolQualifyingExamApplicableSearchRequest searchRequest);
        IBaseEntityResponse<ToolQualifyingExamApplicable> GetToolQualifyingExamApplicableByID(ToolQualifyingExamApplicable item);
        IBaseEntityCollectionResponse<ToolQualifyingExamApplicable> GetToolQualifyingExamApplicableBySearchListBranchDetails(ToolQualifyingExamApplicableSearchRequest searchRequest);
    }
}
