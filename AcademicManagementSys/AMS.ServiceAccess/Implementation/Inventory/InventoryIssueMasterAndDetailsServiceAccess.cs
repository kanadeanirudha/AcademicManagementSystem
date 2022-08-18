using AMS.Base.DTO;
using AMS.Business.BusinessActions;
using AMS.DTO;

namespace AMS.ServiceAccess
{
    public class InventoryIssueMasterAndDetailsServiceAccess : IInventoryIssueMasterAndDetailsServiceAccess
    {
		IInventoryIssueMasterAndDetailsBA _InventoryIssueMasterAndDetailsBA = null;
		public InventoryIssueMasterAndDetailsServiceAccess()
		{
			_InventoryIssueMasterAndDetailsBA = new InventoryIssueMasterAndDetailsBA();
		}
		public IBaseEntityResponse<InventoryIssueMasterAndDetails> InsertInventoryIssueMasterAndDetails(InventoryIssueMasterAndDetails item)
		{
			return _InventoryIssueMasterAndDetailsBA.InsertInventoryIssueMasterAndDetails(item);
		}
		public IBaseEntityResponse<InventoryIssueMasterAndDetails> UpdateInventoryIssueMasterAndDetails(InventoryIssueMasterAndDetails item)
		{
			return _InventoryIssueMasterAndDetailsBA.UpdateInventoryIssueMasterAndDetails(item);
		}
		public IBaseEntityResponse<InventoryIssueMasterAndDetails> DeleteInventoryIssueMasterAndDetails(InventoryIssueMasterAndDetails item)
		{
			return _InventoryIssueMasterAndDetailsBA.DeleteInventoryIssueMasterAndDetails(item);
		}
		public IBaseEntityCollectionResponse<InventoryIssueMasterAndDetails> GetBySearch(InventoryIssueMasterAndDetailsSearchRequest searchRequest)
		{
			return _InventoryIssueMasterAndDetailsBA.GetBySearch(searchRequest);
		}
		public IBaseEntityResponse<InventoryIssueMasterAndDetails> SelectByID(InventoryIssueMasterAndDetails item)
		{
			return _InventoryIssueMasterAndDetailsBA.SelectByID(item);
		}
    }
}
