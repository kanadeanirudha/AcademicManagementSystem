using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.ServiceAccess
{
    public interface IToolQualificationExamMasterServiceAccess
    {
        IBaseEntityResponse<ToolQualificationExamMaster> InsertToolQualificationExamMaster(ToolQualificationExamMaster item);
        IBaseEntityResponse<ToolQualificationExamMaster> UpdateToolQualificationExamMaster(ToolQualificationExamMaster item);
        IBaseEntityResponse<ToolQualificationExamMaster> DeleteToolQualificationExamMaster(ToolQualificationExamMaster item);
        IBaseEntityCollectionResponse<ToolQualificationExamMaster> GetBySearch(ToolQualificationExamMasterSearchRequest searchRequest);
        IBaseEntityResponse<ToolQualificationExamMaster> SelectByID(ToolQualificationExamMaster item);
    }
}
