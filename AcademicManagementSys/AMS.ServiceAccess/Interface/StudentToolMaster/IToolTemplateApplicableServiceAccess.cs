using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.ServiceAccess
{
    public interface IToolTemplateApplicableServiceAccess
    {
        IBaseEntityResponse<ToolTemplateApplicable> InsertToolTemplateApplicable(ToolTemplateApplicable item);
        IBaseEntityResponse<ToolTemplateApplicable> UpdateToolTemplateApplicable(ToolTemplateApplicable item);
        IBaseEntityResponse<ToolTemplateApplicable> DeleteToolTemplateApplicable(ToolTemplateApplicable item);
        IBaseEntityCollectionResponse<ToolTemplateApplicable> GetBySearch(ToolTemplateApplicableSearchRequest searchRequest);
        IBaseEntityResponse<ToolTemplateApplicable> SelectByID(ToolTemplateApplicable item);
        IBaseEntityCollectionResponse<ToolTemplateApplicable> GetBySearchListBranchDetails(ToolTemplateApplicableSearchRequest searchRequest);
    }
}
