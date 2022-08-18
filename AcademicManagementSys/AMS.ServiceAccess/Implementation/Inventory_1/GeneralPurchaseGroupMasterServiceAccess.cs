using AMS.Base.DTO;
using AMS.Business.BusinessActions;
using AMS.DTO;

namespace AMS.ServiceAccess
{
    public class GeneralPurchaseGroupMasterServiceAccess : IGeneralPurchaseGroupMasterServiceAccess
    {
        IGeneralPurchaseGroupMasterBA _GeneralPurchaseGroupMasterBA = null;
        public GeneralPurchaseGroupMasterServiceAccess()
        {
            _GeneralPurchaseGroupMasterBA = new GeneralPurchaseGroupMasterBA();
        }
        public IBaseEntityResponse<GeneralPurchaseGroupMaster> InsertGeneralPurchaseGroupMaster(GeneralPurchaseGroupMaster item)
        {
            return _GeneralPurchaseGroupMasterBA.InsertGeneralPurchaseGroupMaster(item);
        }
        public IBaseEntityResponse<GeneralPurchaseGroupMaster> UpdateGeneralPurchaseGroupMaster(GeneralPurchaseGroupMaster item)
        {
            return _GeneralPurchaseGroupMasterBA.UpdateGeneralPurchaseGroupMaster(item);
        }
        public IBaseEntityResponse<GeneralPurchaseGroupMaster> DeleteGeneralPurchaseGroupMaster(GeneralPurchaseGroupMaster item)
        {
            return _GeneralPurchaseGroupMasterBA.DeleteGeneralPurchaseGroupMaster(item);
        }
        public IBaseEntityCollectionResponse<GeneralPurchaseGroupMaster> GetBySearch(GeneralPurchaseGroupMasterSearchRequest searchRequest)
        {
            return _GeneralPurchaseGroupMasterBA.GetBySearch(searchRequest);
        }
        public IBaseEntityResponse<GeneralPurchaseGroupMaster> SelectByID(GeneralPurchaseGroupMaster item)
        {
            return _GeneralPurchaseGroupMasterBA.SelectByID(item);
        }
        public IBaseEntityCollectionResponse<GeneralPurchaseGroupMaster> GetGeneralPurchaseGroupMasterSearchList(GeneralPurchaseGroupMasterSearchRequest searchRequest)
        {
            return _GeneralPurchaseGroupMasterBA.GetGeneralPurchaseGroupMasterSearchList(searchRequest);
        }
    }
}
