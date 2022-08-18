using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.Business.BusinessAction
{
    public interface IToolQualifyingExamMasterBA
    {
        IBaseEntityResponse<ToolQualifyingExamMaster> InsertToolQualifyingExamMaster(ToolQualifyingExamMaster item);
        IBaseEntityResponse<ToolQualifyingExamMaster> UpdateToolQualifyingExamMaster(ToolQualifyingExamMaster item);
        IBaseEntityResponse<ToolQualifyingExamMaster> DeleteToolQualifyingExamMaster(ToolQualifyingExamMaster item);
        IBaseEntityCollectionResponse<ToolQualifyingExamMaster> GetBySearch(ToolQualifyingExamMasterSearchRequest searchRequest);
        IBaseEntityResponse<ToolQualifyingExamMaster> SelectByID(ToolQualifyingExamMaster item);
    }
}
