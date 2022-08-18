using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.ServiceAccess
{
    public interface IToolQualificationApplicableServiceAccess
    {
        IBaseEntityResponse<ToolQualificationApplicable> InsertToolQualificationApplicable(ToolQualificationApplicable item);
        IBaseEntityResponse<ToolQualificationApplicable> UpdateToolQualificationApplicable(ToolQualificationApplicable item);
        IBaseEntityResponse<ToolQualificationApplicable> DeleteToolQualificationApplicable(ToolQualificationApplicable item);
        IBaseEntityCollectionResponse<ToolQualificationApplicable> GetBySearch(ToolQualificationApplicableSearchRequest searchRequest);
        IBaseEntityCollectionResponse<ToolQualificationApplicable> GetBySearchListBranchDetails(ToolQualificationApplicableSearchRequest searchRequest);
        IBaseEntityResponse<ToolQualificationApplicable> SelectByID(ToolQualificationApplicable item);
    }
}
