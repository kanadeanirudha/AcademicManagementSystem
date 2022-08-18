
using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.DataProvider
{
    public interface IGeneralQuestionLevelMasterDataProvider
    {
        IBaseEntityResponse<GeneralQuestionLevelMaster> InsertGeneralQuestionLevelMaster(GeneralQuestionLevelMaster item);
        IBaseEntityResponse<GeneralQuestionLevelMaster> UpdateGeneralQuestionLevelMaster(GeneralQuestionLevelMaster item);
        IBaseEntityResponse<GeneralQuestionLevelMaster> DeleteGeneralQuestionLevelMaster(GeneralQuestionLevelMaster item);
        IBaseEntityCollectionResponse<GeneralQuestionLevelMaster> GetGeneralQuestionLevelMasterBySearch(GeneralQuestionLevelMasterSearchRequest searchRequest);
        IBaseEntityCollectionResponse<GeneralQuestionLevelMaster> GetGeneralQuestionLevelMasterSearchList(GeneralQuestionLevelMasterSearchRequest searchRequest);
        IBaseEntityResponse<GeneralQuestionLevelMaster> GetGeneralQuestionLevelMasterByID(GeneralQuestionLevelMaster item);
    }
}
