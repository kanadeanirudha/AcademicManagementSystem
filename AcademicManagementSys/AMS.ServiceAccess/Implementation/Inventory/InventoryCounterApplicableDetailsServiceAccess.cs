
using AMS.Base.DTO;
using AMS.Business.BusinessActions;
using AMS.DTO;

namespace AMS.ServiceAccess
{
    public class InventoryCounterApplicableDetailsServiceAccess : IInventoryCounterApplicableDetailsServiceAccess
    {
        IInventoryCounterApplicableDetailsBA _InventoryCounterApplicableDetailsBA = null;
        public InventoryCounterApplicableDetailsServiceAccess()
        {
            _InventoryCounterApplicableDetailsBA = new InventoryCounterApplicableDetailsBA();
        }
        public IBaseEntityResponse<InventoryCounterApplicableDetails> InsertInventoryCounterApplicableDetails(InventoryCounterApplicableDetails item)
        {
            return _InventoryCounterApplicableDetailsBA.InsertInventoryCounterApplicableDetails(item);
        }
        public IBaseEntityResponse<InventoryCounterApplicableDetails> UpdateInventoryCounterApplicableDetails(InventoryCounterApplicableDetails item)
        {
            return _InventoryCounterApplicableDetailsBA.UpdateInventoryCounterApplicableDetails(item);
        }
        public IBaseEntityResponse<InventoryCounterApplicableDetails> DeleteInventoryCounterApplicableDetails(InventoryCounterApplicableDetails item)
        {
            return _InventoryCounterApplicableDetailsBA.DeleteInventoryCounterApplicableDetails(item);
        }
        public IBaseEntityCollectionResponse<InventoryCounterApplicableDetails> GetBySearch(InventoryCounterApplicableDetailsSearchRequest searchRequest)
        {
            return _InventoryCounterApplicableDetailsBA.GetBySearch(searchRequest);
        }
        public IBaseEntityCollectionResponse<InventoryCounterApplicableDetails> GetInventoryCounterApplicableDetailsList(InventoryCounterApplicableDetailsSearchRequest searchRequest)
        {
            return _InventoryCounterApplicableDetailsBA.GetInventoryCounterApplicableDetailsList(searchRequest);
        }
        public IBaseEntityResponse<InventoryCounterApplicableDetails> SelectByID(InventoryCounterApplicableDetails item)
        {
            return _InventoryCounterApplicableDetailsBA.SelectByID(item);
        }

       // IBaseEntityCollectionResponse<InventoryCounterApplicableDetails> GetInventoryCounterApplicableDetailsMachineList(InventoryCounterApplicableDetailsSearchRequest searchRequest);

    }
}

