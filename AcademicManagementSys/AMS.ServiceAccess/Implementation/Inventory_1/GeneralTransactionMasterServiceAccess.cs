using AMS.Base.DTO;
using AMS.Business.BusinessActions;
using AMS.DTO;

namespace AMS.ServiceAccess
{
    public class GeneralTransactionMasterServiceAccess : IGeneralTransactionMasterServiceAccess
    {
        IGeneralTransactionMasterBA _GeneralTransactionMasterBA = null;
        public GeneralTransactionMasterServiceAccess()
        {
            _GeneralTransactionMasterBA = new GeneralTransactionMasterBA();
        }
        public IBaseEntityResponse<GeneralTransactionMaster> InsertGeneralTransactionMaster(GeneralTransactionMaster item)
        {
            return _GeneralTransactionMasterBA.InsertGeneralTransactionMaster(item);
        }
        public IBaseEntityResponse<GeneralTransactionMaster> UpdateGeneralTransactionMaster(GeneralTransactionMaster item)
        {
            return _GeneralTransactionMasterBA.UpdateGeneralTransactionMaster(item);
        }
        public IBaseEntityResponse<GeneralTransactionMaster> DeleteGeneralTransactionMaster(GeneralTransactionMaster item)
        {
            return _GeneralTransactionMasterBA.DeleteGeneralTransactionMaster(item);
        }
        public IBaseEntityCollectionResponse<GeneralTransactionMaster> GetBySearch(GeneralTransactionMasterSearchRequest searchRequest)
        {
            return _GeneralTransactionMasterBA.GetBySearch(searchRequest);
        }
        public IBaseEntityCollectionResponse<GeneralTransactionMaster> GetGeneralTransactionMasterSearchList(GeneralTransactionMasterSearchRequest searchRequest)
        {
            return _GeneralTransactionMasterBA.GetGeneralTransactionMasterSearchList(searchRequest);
        }
        public IBaseEntityResponse<GeneralTransactionMaster> SelectByID(GeneralTransactionMaster item)
        {
            return _GeneralTransactionMasterBA.SelectByID(item);
        }
    }
}
