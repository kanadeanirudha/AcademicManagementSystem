using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.DataProvider
{
    public interface IToolQualificationApplicableDataProvider
    {
        IBaseEntityResponse<ToolQualificationApplicable> InsertToolQualificationApplicable(ToolQualificationApplicable item);
        IBaseEntityResponse<ToolQualificationApplicable> UpdateToolQualificationApplicable(ToolQualificationApplicable item);
        IBaseEntityResponse<ToolQualificationApplicable> DeleteToolQualificationApplicable(ToolQualificationApplicable item);
        IBaseEntityCollectionResponse<ToolQualificationApplicable> GetToolQualificationApplicableBySearch(ToolQualificationApplicableSearchRequest searchRequest);
        IBaseEntityResponse<ToolQualificationApplicable> GetToolQualificationApplicableByID(ToolQualificationApplicable item);
        IBaseEntityCollectionResponse<ToolQualificationApplicable> GetToolQualificationApplicableBySearchListBranchDetails(ToolQualificationApplicableSearchRequest searchRequest);
    }
}
