
using AMS.Base.DTO;
using AMS.Business.BusinessActions;
using AMS.DTO;

namespace AMS.ServiceAccess
{
    public class GeneralQuestionLevelMasterServiceAccess : IGeneralQuestionLevelMasterServiceAccess
    {
        IGeneralQuestionLevelMasterBA _GeneralQuestionLevelMasterBA = null;
        public GeneralQuestionLevelMasterServiceAccess()
        {
            _GeneralQuestionLevelMasterBA = new GeneralQuestionLevelMasterBA();
        }
        public IBaseEntityResponse<GeneralQuestionLevelMaster> InsertGeneralQuestionLevelMaster(GeneralQuestionLevelMaster item)
        {
            return _GeneralQuestionLevelMasterBA.InsertGeneralQuestionLevelMaster(item);
        }
        public IBaseEntityResponse<GeneralQuestionLevelMaster> UpdateGeneralQuestionLevelMaster(GeneralQuestionLevelMaster item)
        {
            return _GeneralQuestionLevelMasterBA.UpdateGeneralQuestionLevelMaster(item);
        }
        public IBaseEntityResponse<GeneralQuestionLevelMaster> DeleteGeneralQuestionLevelMaster(GeneralQuestionLevelMaster item)
        {
            return _GeneralQuestionLevelMasterBA.DeleteGeneralQuestionLevelMaster(item);
        }
        public IBaseEntityCollectionResponse<GeneralQuestionLevelMaster> GetBySearch(GeneralQuestionLevelMasterSearchRequest searchRequest)
        {
            return _GeneralQuestionLevelMasterBA.GetBySearch(searchRequest);
        }
        public IBaseEntityCollectionResponse<GeneralQuestionLevelMaster> GetGeneralQuestionLevelMasterSearchList(GeneralQuestionLevelMasterSearchRequest searchRequest)
        {
            return _GeneralQuestionLevelMasterBA.GetGeneralQuestionLevelMasterSearchList(searchRequest);
        }
        public IBaseEntityResponse<GeneralQuestionLevelMaster> SelectByID(GeneralQuestionLevelMaster item)
        {
            return _GeneralQuestionLevelMasterBA.SelectByID(item);
        }
    }
}
