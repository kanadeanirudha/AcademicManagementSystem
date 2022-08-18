
using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.ServiceAccess
{
    public interface IGeneralQuestionLevelMasterServiceAccess
    {
        IBaseEntityResponse<GeneralQuestionLevelMaster> InsertGeneralQuestionLevelMaster(GeneralQuestionLevelMaster item);
        IBaseEntityResponse<GeneralQuestionLevelMaster> UpdateGeneralQuestionLevelMaster(GeneralQuestionLevelMaster item);
        IBaseEntityResponse<GeneralQuestionLevelMaster> DeleteGeneralQuestionLevelMaster(GeneralQuestionLevelMaster item);
        IBaseEntityCollectionResponse<GeneralQuestionLevelMaster> GetBySearch(GeneralQuestionLevelMasterSearchRequest searchRequest);
        IBaseEntityResponse<GeneralQuestionLevelMaster> SelectByID(GeneralQuestionLevelMaster item);
        IBaseEntityCollectionResponse<GeneralQuestionLevelMaster> GetGeneralQuestionLevelMasterSearchList(GeneralQuestionLevelMasterSearchRequest searchRequest);
    }
}
