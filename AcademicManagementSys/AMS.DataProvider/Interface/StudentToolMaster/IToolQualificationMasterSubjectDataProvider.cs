using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.DataProvider
{
    public interface IToolQualificationMasterSubjectDataProvider
    {
        IBaseEntityResponse<ToolQualificationMasterSubject> InsertToolQualificationMasterSubject(ToolQualificationMasterSubject item);
        IBaseEntityResponse<ToolQualificationMasterSubject> UpdateToolQualificationMasterSubject(ToolQualificationMasterSubject item);
        IBaseEntityResponse<ToolQualificationMasterSubject> DeleteToolQualificationMasterSubject(ToolQualificationMasterSubject item);
        IBaseEntityCollectionResponse<ToolQualificationMasterSubject> GetToolQualificationMasterSubjectBySearch(ToolQualificationMasterSubjectSearchRequest searchRequest);
        IBaseEntityResponse<ToolQualificationMasterSubject> GetToolQualificationMasterSubjectByID(ToolQualificationMasterSubject item);
        IBaseEntityCollectionResponse<ToolQualificationMasterSubject> GetByQualificationMasterSubjectList(ToolQualificationMasterSubjectSearchRequest searchRequest);
        IBaseEntityCollectionResponse<ToolQualificationMasterSubject> GetByQualificationMasterSubjectListByBranchDetailID_StandardNumber_EducationType(ToolQualificationMasterSubjectSearchRequest searchRequest);
    }
}
