using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.Business.BusinessAction
{
    public interface IToolQualificationApplicableBA
    {
        IBaseEntityResponse<ToolQualificationApplicable> InsertToolQualificationApplicable(ToolQualificationApplicable item);
        IBaseEntityResponse<ToolQualificationApplicable> UpdateToolQualificationApplicable(ToolQualificationApplicable item);
        IBaseEntityResponse<ToolQualificationApplicable> DeleteToolQualificationApplicable(ToolQualificationApplicable item);
        IBaseEntityCollectionResponse<ToolQualificationApplicable> GetBySearch(ToolQualificationApplicableSearchRequest searchRequest);
        IBaseEntityResponse<ToolQualificationApplicable> SelectByID(ToolQualificationApplicable item);
        IBaseEntityCollectionResponse<ToolQualificationApplicable> GetBySearchListBranchDetails(ToolQualificationApplicableSearchRequest searchRequest);
    }
}
