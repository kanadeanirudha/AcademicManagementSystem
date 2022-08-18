using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.Business.BusinessAction
{
    public interface IToolQualifyingExamApplicableBA
    {
        IBaseEntityResponse<ToolQualifyingExamApplicable> InsertToolQualifyingExamApplicable(ToolQualifyingExamApplicable item);
        IBaseEntityResponse<ToolQualifyingExamApplicable> UpdateToolQualifyingExamApplicable(ToolQualifyingExamApplicable item);
        IBaseEntityResponse<ToolQualifyingExamApplicable> DeleteToolQualifyingExamApplicable(ToolQualifyingExamApplicable item);
        IBaseEntityCollectionResponse<ToolQualifyingExamApplicable> GetBySearch(ToolQualifyingExamApplicableSearchRequest searchRequest);
        IBaseEntityResponse<ToolQualifyingExamApplicable> SelectByID(ToolQualifyingExamApplicable item);
        IBaseEntityCollectionResponse<ToolQualifyingExamApplicable> GetBySearchListBranchDetails(ToolQualifyingExamApplicableSearchRequest searchRequest);
    }
}
