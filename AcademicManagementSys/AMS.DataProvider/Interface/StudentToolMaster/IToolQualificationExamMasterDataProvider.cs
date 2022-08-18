using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.DataProvider
{
    public interface IToolQualificationExamMasterDataProvider
    {
        IBaseEntityResponse<ToolQualificationExamMaster> InsertToolQualificationExamMaster(ToolQualificationExamMaster item);
        IBaseEntityResponse<ToolQualificationExamMaster> UpdateToolQualificationExamMaster(ToolQualificationExamMaster item);
        IBaseEntityResponse<ToolQualificationExamMaster> DeleteToolQualificationExamMaster(ToolQualificationExamMaster item);
        IBaseEntityCollectionResponse<ToolQualificationExamMaster> GetToolQualificationExamMasterBySearch(ToolQualificationExamMasterSearchRequest searchRequest);
        IBaseEntityResponse<ToolQualificationExamMaster> GetToolQualificationExamMasterByID(ToolQualificationExamMaster item);
    }
}
