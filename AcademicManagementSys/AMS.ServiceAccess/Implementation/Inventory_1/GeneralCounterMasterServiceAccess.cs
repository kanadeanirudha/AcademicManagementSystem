using AMS.Base.DTO;
using AMS.Business.BusinessActions;
using AMS.DTO;

namespace AMS.ServiceAccess
{
    public class GeneralCounterMasterServiceAccess : IGeneralCounterMasterServiceAccess
    {
        IGeneralCounterMasterBA _GeneralCounterMasterBA = null;
        public GeneralCounterMasterServiceAccess()
        {
            _GeneralCounterMasterBA = new GeneralCounterMasterBA();
        }
        public IBaseEntityResponse<GeneralCounterMaster> InsertGeneralCounterMaster(GeneralCounterMaster item)
        {
            return _GeneralCounterMasterBA.InsertGeneralCounterMaster(item);
        }
        public IBaseEntityResponse<GeneralCounterMaster> UpdateGeneralCounterMaster(GeneralCounterMaster item)
        {
            return _GeneralCounterMasterBA.UpdateGeneralCounterMaster(item);
        }
        public IBaseEntityResponse<GeneralCounterMaster> DeleteGeneralCounterMaster(GeneralCounterMaster item)
        {
            return _GeneralCounterMasterBA.DeleteGeneralCounterMaster(item);
        }
        public IBaseEntityCollectionResponse<GeneralCounterMaster> GetBySearch(GeneralCounterMasterSearchRequest searchRequest)
        {
            return _GeneralCounterMasterBA.GetBySearch(searchRequest);
        }
        public IBaseEntityCollectionResponse<GeneralCounterMaster> GetGeneralCounterMasterSearchList(GeneralCounterMasterSearchRequest searchRequest)
        {
            return _GeneralCounterMasterBA.GetGeneralCounterMasterSearchList(searchRequest);
        }
        public IBaseEntityResponse<GeneralCounterMaster> SelectByID(GeneralCounterMaster item)
        {
            return _GeneralCounterMasterBA.SelectByID(item);
        }
    }
}
