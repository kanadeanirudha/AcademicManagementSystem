using AMS.Base.DTO;
using AMS.Business.BusinessActions;
using AMS.DTO;

namespace AMS.ServiceAccess
{
    public class InventorySalesMasterAndTransactionServiceAccess : IInventorySalesMasterAndTransactionServiceAccess
    {
		IInventorySalesMasterAndTransactionBA _InventorySalesMasterAndTransactionBA = null;
		public InventorySalesMasterAndTransactionServiceAccess()
		{
			_InventorySalesMasterAndTransactionBA = new InventorySalesMasterAndTransactionBA();
		}
		public IBaseEntityResponse<InventorySalesMasterAndTransaction> InsertInventorySalesMasterAndTransaction(InventorySalesMasterAndTransaction item)
		{
			return _InventorySalesMasterAndTransactionBA.InsertInventorySalesMasterAndTransaction(item);
		}
        public IBaseEntityResponse<InventorySalesMasterAndTransaction> InsertInventoryHoldBill(InventorySalesMasterAndTransaction item)
		{
            return _InventorySalesMasterAndTransactionBA.InsertInventoryHoldBill(item);
		}
		public IBaseEntityResponse<InventorySalesMasterAndTransaction> UpdateInventorySalesMasterAndTransaction(InventorySalesMasterAndTransaction item)
		{
			return _InventorySalesMasterAndTransactionBA.UpdateInventorySalesMasterAndTransaction(item);
		}
		public IBaseEntityResponse<InventorySalesMasterAndTransaction> DeleteInventorySalesMasterAndTransaction(InventorySalesMasterAndTransaction item)
		{
			return _InventorySalesMasterAndTransactionBA.DeleteInventorySalesMasterAndTransaction(item);
		}
		public IBaseEntityCollectionResponse<InventorySalesMasterAndTransaction> GetBySearch(InventorySalesMasterAndTransactionSearchRequest searchRequest)
		{
			return _InventorySalesMasterAndTransactionBA.GetBySearch(searchRequest);
		}
        public IBaseEntityCollectionResponse<InventorySalesMasterAndTransaction> GetBillDetailsByID(InventorySalesMasterAndTransactionSearchRequest searchRequest)
		{
            return _InventorySalesMasterAndTransactionBA.GetBillDetailsByID(searchRequest);
		}
		public IBaseEntityResponse<InventorySalesMasterAndTransaction> SelectByID(InventorySalesMasterAndTransaction item)
		{
			return _InventorySalesMasterAndTransactionBA.SelectByID(item);
		}
        public IBaseEntityResponse<InventorySalesMasterAndTransaction> SelectHoldBillCount(InventorySalesMasterAndTransaction item)
		{
            return _InventorySalesMasterAndTransactionBA.SelectHoldBillCount(item);
		}
        public IBaseEntityResponse<InventorySalesMasterAndTransaction> GetInventoryItemQuantity(InventorySalesMasterAndTransaction item)
		{
            return _InventorySalesMasterAndTransactionBA.GetInventoryItemQuantity(item);
		}
        public IBaseEntityCollectionResponse<InventorySalesMasterAndTransaction> GetInventorySalesMasterAndTransactionBillPrintList(InventorySalesMasterAndTransactionSearchRequest searchRequest)
        {
            return _InventorySalesMasterAndTransactionBA.GetInventorySalesMasterAndTransactionBillPrintList(searchRequest);
        }

        //For Inventory Sale Report To operator
        public IBaseEntityCollectionResponse<InventorySalesMasterAndTransaction> GetInventorySalesReportToOperator(InventorySalesMasterAndTransactionSearchRequest searchRequest)
        {
            return _InventorySalesMasterAndTransactionBA.GetInventorySalesReportToOperator(searchRequest);
        }

        public IBaseEntityResponse<InventorySalesMasterAndTransaction> CheckFocusOnAction(InventorySalesMasterAndTransaction item)
        {
            return _InventorySalesMasterAndTransactionBA.CheckFocusOnAction(item);
        }
    }
}
