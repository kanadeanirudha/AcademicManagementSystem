using AMS.Base.DTO;
using AMS.Business.BusinessActions;
using AMS.DTO;

namespace AMS.ServiceAccess
{
    public class GeneralRequestMasterServiceAccess : IGeneralRequestMasterServiceAccess
    {
        IGeneralRequestMasterBA _GeneralRequestMasterBA = null;
        public GeneralRequestMasterServiceAccess()
        {
            _GeneralRequestMasterBA = new GeneralRequestMasterBA();
        }
        public IBaseEntityResponse<GeneralRequestMaster> InsertGeneralRequestMaster(GeneralRequestMaster item)
        {
            return _GeneralRequestMasterBA.InsertGeneralRequestMaster(item);
        }
        public IBaseEntityResponse<GeneralRequestMaster> UpdateGeneralRequestMaster(GeneralRequestMaster item)
        {
            return _GeneralRequestMasterBA.UpdateGeneralRequestMaster(item);
        }
        public IBaseEntityResponse<GeneralRequestMaster> DeleteGeneralRequestMaster(GeneralRequestMaster item)
        {
            return _GeneralRequestMasterBA.DeleteGeneralRequestMaster(item);
        }
        public IBaseEntityCollectionResponse<GeneralRequestMaster> GetBySearch(GeneralRequestMasterSearchRequest searchRequest)
        {
            return _GeneralRequestMasterBA.GetBySearch(searchRequest);
        }

        public IBaseEntityCollectionResponse<GeneralRequestMaster> GetRequestCode(GeneralRequestMasterSearchRequest searchRequest)
        {
            return _GeneralRequestMasterBA.GetRequestCode(searchRequest);
        }

        public IBaseEntityCollectionResponse<GeneralRequestMaster> GetGeneralRequestMasterSearchList(GeneralRequestMasterSearchRequest searchRequest)
        {
            return _GeneralRequestMasterBA.GetGeneralRequestMasterSearchList(searchRequest);
        }
        public IBaseEntityResponse<GeneralRequestMaster> SelectByID(GeneralRequestMaster item)
        {
            return _GeneralRequestMasterBA.SelectByID(item);
        }
    }
}
