
using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.ServiceAccess
{
    public interface IGeneralQuestionTypeMasterServiceAccess
    {
        IBaseEntityResponse<GeneralQuestionTypeMaster> InsertGeneralQuestionTypeMaster(GeneralQuestionTypeMaster item);
        IBaseEntityResponse<GeneralQuestionTypeMaster> UpdateGeneralQuestionTypeMaster(GeneralQuestionTypeMaster item);
        IBaseEntityResponse<GeneralQuestionTypeMaster> DeleteGeneralQuestionTypeMaster(GeneralQuestionTypeMaster item);
        IBaseEntityCollectionResponse<GeneralQuestionTypeMaster> GetBySearch(GeneralQuestionTypeMasterSearchRequest searchRequest);
        IBaseEntityResponse<GeneralQuestionTypeMaster> SelectByID(GeneralQuestionTypeMaster item);
        IBaseEntityCollectionResponse<GeneralQuestionTypeMaster> GetBySearchList(GeneralQuestionTypeMasterSearchRequest searchRequest);
    }
}
