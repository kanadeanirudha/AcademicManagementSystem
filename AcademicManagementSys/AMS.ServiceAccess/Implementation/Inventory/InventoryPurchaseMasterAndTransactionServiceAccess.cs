using AMS.Base.DTO;
using AMS.Business.BusinessAction;
using AMS.DTO;
namespace AMS.ServiceAccess
{
    public class InventoryPurchaseMasterAndTransactionServiceAccess : IInventoryPurchaseMasterAndTransactionServiceAccess
	{
		IInventoryPurchaseMasterAndTransactionBA _InventoryPurchaseMasterAndTransactionBA = null;
		public InventoryPurchaseMasterAndTransactionServiceAccess()
		{
			_InventoryPurchaseMasterAndTransactionBA = new InventoryPurchaseMasterAndTransactionBA();
		}
		public IBaseEntityResponse<InventoryPurchaseMasterAndTransaction> InsertInventoryPurchaseMasterAndTransaction(InventoryPurchaseMasterAndTransaction item)
		{
			return _InventoryPurchaseMasterAndTransactionBA.InsertInventoryPurchaseMasterAndTransaction(item);
		}
		public IBaseEntityResponse<InventoryPurchaseMasterAndTransaction> UpdateInventoryPurchaseMasterAndTransaction(InventoryPurchaseMasterAndTransaction item)
		{
			return _InventoryPurchaseMasterAndTransactionBA.UpdateInventoryPurchaseMasterAndTransaction(item);
		}
		public IBaseEntityResponse<InventoryPurchaseMasterAndTransaction> DeleteInventoryPurchaseMasterAndTransaction(InventoryPurchaseMasterAndTransaction item)
		{
			return _InventoryPurchaseMasterAndTransactionBA.DeleteInventoryPurchaseMasterAndTransaction(item);
		}
		public IBaseEntityCollectionResponse<InventoryPurchaseMasterAndTransaction> GetBySearch(InventoryPurchaseMasterAndTransactionSearchRequest searchRequest)
		{
			return _InventoryPurchaseMasterAndTransactionBA.GetBySearch(searchRequest);
		}
		public IBaseEntityResponse<InventoryPurchaseMasterAndTransaction> SelectByID(InventoryPurchaseMasterAndTransaction item)
		{
			return _InventoryPurchaseMasterAndTransactionBA.SelectByID(item);
		}
        public IBaseEntityCollectionResponse<InventoryPurchaseMasterAndTransaction> GetPurchaseMasterAndTransaction(InventoryPurchaseMasterAndTransactionSearchRequest searchRequest)
        {
            return _InventoryPurchaseMasterAndTransactionBA.GetPurchaseMasterAndTransaction(searchRequest);
        }
        public IBaseEntityResponse<InventoryPurchaseMasterAndTransaction> CheckFocusOnAction(InventoryPurchaseMasterAndTransaction item)
        {
            return _InventoryPurchaseMasterAndTransactionBA.CheckFocusOnAction(item);
        }
	}
}



 