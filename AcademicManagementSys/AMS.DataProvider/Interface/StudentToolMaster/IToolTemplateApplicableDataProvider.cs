using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.DataProvider
{
    public interface IToolTemplateApplicableDataProvider
    {
        IBaseEntityResponse<ToolTemplateApplicable> InsertToolTemplateApplicable(ToolTemplateApplicable item);
        IBaseEntityResponse<ToolTemplateApplicable> UpdateToolTemplateApplicable(ToolTemplateApplicable item);
        IBaseEntityResponse<ToolTemplateApplicable> DeleteToolTemplateApplicable(ToolTemplateApplicable item);
        IBaseEntityCollectionResponse<ToolTemplateApplicable> GetToolTemplateApplicableBySearch(ToolTemplateApplicableSearchRequest searchRequest);
        IBaseEntityResponse<ToolTemplateApplicable> GetToolTemplateApplicableByID(ToolTemplateApplicable item);
        IBaseEntityCollectionResponse<ToolTemplateApplicable> GetToolTemplateApplicableBySearchBranchDetails(ToolTemplateApplicableSearchRequest searchRequest);
    }
}
