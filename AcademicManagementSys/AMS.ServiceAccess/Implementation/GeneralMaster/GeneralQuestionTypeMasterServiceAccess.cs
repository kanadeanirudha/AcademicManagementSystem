
using AMS.Base.DTO;
using AMS.Business.BusinessActions;
using AMS.DTO;

namespace AMS.ServiceAccess
{
    public class GeneralQuestionTypeMasterServiceAccess : IGeneralQuestionTypeMasterServiceAccess
    {
        IGeneralQuestionTypeMasterBA _GeneralQuestionTypeMasterBA = null;
        public GeneralQuestionTypeMasterServiceAccess()
        {
            _GeneralQuestionTypeMasterBA = new GeneralQuestionTypeMasterBA();
        }
        public IBaseEntityResponse<GeneralQuestionTypeMaster> InsertGeneralQuestionTypeMaster(GeneralQuestionTypeMaster item)
        {
            return _GeneralQuestionTypeMasterBA.InsertGeneralQuestionTypeMaster(item);
        }
        public IBaseEntityResponse<GeneralQuestionTypeMaster> UpdateGeneralQuestionTypeMaster(GeneralQuestionTypeMaster item)
        {
            return _GeneralQuestionTypeMasterBA.UpdateGeneralQuestionTypeMaster(item);
        }
        public IBaseEntityResponse<GeneralQuestionTypeMaster> DeleteGeneralQuestionTypeMaster(GeneralQuestionTypeMaster item)
        {
            return _GeneralQuestionTypeMasterBA.DeleteGeneralQuestionTypeMaster(item);
        }
        public IBaseEntityCollectionResponse<GeneralQuestionTypeMaster> GetBySearch(GeneralQuestionTypeMasterSearchRequest searchRequest)
        {
            return _GeneralQuestionTypeMasterBA.GetBySearch(searchRequest);
        }
        public IBaseEntityCollectionResponse<GeneralQuestionTypeMaster> GetBySearchList(GeneralQuestionTypeMasterSearchRequest searchRequest)
        {
            return _GeneralQuestionTypeMasterBA.GetGeneralQuestionTypeMasterSearchList(searchRequest);
        }
        public IBaseEntityResponse<GeneralQuestionTypeMaster> SelectByID(GeneralQuestionTypeMaster item)
        {
            return _GeneralQuestionTypeMasterBA.SelectByID(item);
        }
    }
}
