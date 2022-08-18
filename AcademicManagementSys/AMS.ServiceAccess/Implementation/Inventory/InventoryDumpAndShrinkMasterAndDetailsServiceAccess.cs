using AMS.Base.DTO;
using AMS.Business.BusinessActions;
using AMS.DTO;

namespace AMS.ServiceAccess
{
    public class InventoryDumpAndShrinkMasterAndDetailsServiceAccess : IInventoryDumpAndShrinkMasterAndDetailsServiceAccess
    {
		IInventoryDumpAndShrinkMasterAndDetailsBA _InventoryDumpAndShrinkMasterAndDetailsBA = null;
		public InventoryDumpAndShrinkMasterAndDetailsServiceAccess()
		{
			_InventoryDumpAndShrinkMasterAndDetailsBA = new InventoryDumpAndShrinkMasterAndDetailsBA();
		}
		public IBaseEntityResponse<InventoryDumpAndShrinkMasterAndDetails> InsertInventoryDumpAndShrinkMasterAndDetails(InventoryDumpAndShrinkMasterAndDetails item)
		{
			return _InventoryDumpAndShrinkMasterAndDetailsBA.InsertInventoryDumpAndShrinkMasterAndDetails(item);
		}
        public IBaseEntityResponse<InventoryDumpAndShrinkMasterAndDetails> InsertApprovedDumpAndShrinkRecord(InventoryDumpAndShrinkMasterAndDetails item)
		{
            return _InventoryDumpAndShrinkMasterAndDetailsBA.InsertApprovedDumpAndShrinkRecord(item);
		}
		public IBaseEntityResponse<InventoryDumpAndShrinkMasterAndDetails> UpdateInventoryDumpAndShrinkMasterAndDetails(InventoryDumpAndShrinkMasterAndDetails item)
		{
			return _InventoryDumpAndShrinkMasterAndDetailsBA.UpdateInventoryDumpAndShrinkMasterAndDetails(item);
		}
		public IBaseEntityResponse<InventoryDumpAndShrinkMasterAndDetails> DeleteInventoryDumpAndShrinkMasterAndDetails(InventoryDumpAndShrinkMasterAndDetails item)
		{
			return _InventoryDumpAndShrinkMasterAndDetailsBA.DeleteInventoryDumpAndShrinkMasterAndDetails(item);
		}
		public IBaseEntityCollectionResponse<InventoryDumpAndShrinkMasterAndDetails> GetBySearch(InventoryDumpAndShrinkMasterAndDetailsSearchRequest searchRequest)
		{
			return _InventoryDumpAndShrinkMasterAndDetailsBA.GetBySearch(searchRequest);
		}
        public IBaseEntityCollectionResponse<InventoryDumpAndShrinkMasterAndDetails> GetDumpAndShrinkDetails(InventoryDumpAndShrinkMasterAndDetailsSearchRequest searchRequest)
		{
            return _InventoryDumpAndShrinkMasterAndDetailsBA.GetDumpAndShrinkDetails(searchRequest);
		}
        public IBaseEntityCollectionResponse<InventoryDumpAndShrinkMasterAndDetails> GetDumpAndShrinkRequestForApproval(InventoryDumpAndShrinkMasterAndDetailsSearchRequest searchRequest)
		{
            return _InventoryDumpAndShrinkMasterAndDetailsBA.GetDumpAndShrinkRequestForApproval(searchRequest);
		}
		public IBaseEntityResponse<InventoryDumpAndShrinkMasterAndDetails> SelectByID(InventoryDumpAndShrinkMasterAndDetails item)
		{
			return _InventoryDumpAndShrinkMasterAndDetailsBA.SelectByID(item);
		}
    }
}
