using AMS.Base.DTO;
using AMS.Business.BusinessActions;
using AMS.DTO;

namespace AMS.ServiceAccess
{
    public class InventoryEstimationMasterAndDetailsServiceAccess : IInventoryEstimationMasterAndDetailsServiceAccess
    {
		IInventoryEstimationMasterAndDetailsBA _InventoryEstimationMasterAndDetailsBA = null;
		public InventoryEstimationMasterAndDetailsServiceAccess()
		{
			_InventoryEstimationMasterAndDetailsBA = new InventoryEstimationMasterAndDetailsBA();
		}
		public IBaseEntityResponse<InventoryEstimationMasterAndDetails> InsertInventoryEstimationMasterAndDetails(InventoryEstimationMasterAndDetails item)
		{
			return _InventoryEstimationMasterAndDetailsBA.InsertInventoryEstimationMasterAndDetails(item);
		}
        public IBaseEntityResponse<InventoryEstimationMasterAndDetails> InsertInventoryEstimationToLocation(InventoryEstimationMasterAndDetails item)
		{
            return _InventoryEstimationMasterAndDetailsBA.InsertInventoryEstimationToLocation(item);
		}
		public IBaseEntityResponse<InventoryEstimationMasterAndDetails> UpdateInventoryEstimationMasterAndDetails(InventoryEstimationMasterAndDetails item)
		{
			return _InventoryEstimationMasterAndDetailsBA.UpdateInventoryEstimationMasterAndDetails(item);
		}
		public IBaseEntityResponse<InventoryEstimationMasterAndDetails> DeleteInventoryEstimationMasterAndDetails(InventoryEstimationMasterAndDetails item)
		{
			return _InventoryEstimationMasterAndDetailsBA.DeleteInventoryEstimationMasterAndDetails(item);
		}
		public IBaseEntityCollectionResponse<InventoryEstimationMasterAndDetails> GetBySearch(InventoryEstimationMasterAndDetailsSearchRequest searchRequest)
		{
			return _InventoryEstimationMasterAndDetailsBA.GetBySearch(searchRequest);
		}
        public IBaseEntityCollectionResponse<InventoryEstimationMasterAndDetails> GetInventoryEstimationMasterAndDetails(InventoryEstimationMasterAndDetailsSearchRequest searchRequest)
		{
            return _InventoryEstimationMasterAndDetailsBA.GetInventoryEstimationMasterAndDetails(searchRequest);
		}
    }
}
