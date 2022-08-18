using AMS.Base.DTO;
using AMS.Business.BusinessActions;
using AMS.DTO;

namespace AMS.ServiceAccess
{
    public class InventoryPhysicalStockMasterAndTransactionServiceAccess : IInventoryPhysicalStockMasterAndTransactionServiceAccess
    {
        IInventoryPhysicalStockMasterAndTransactionBA _InventoryPhysicalStockMasterAndTransactionBA = null;
        public InventoryPhysicalStockMasterAndTransactionServiceAccess()
        {
            _InventoryPhysicalStockMasterAndTransactionBA = new InventoryPhysicalStockMasterAndTransactionBA();
        }
        public IBaseEntityResponse<InventoryPhysicalStockMasterAndTransaction> InsertInventoryPhysicalStockMasterAndTransaction(InventoryPhysicalStockMasterAndTransaction item)
        {
            return _InventoryPhysicalStockMasterAndTransactionBA.InsertInventoryPhysicalStockMasterAndTransaction(item);
        }
        public IBaseEntityResponse<InventoryPhysicalStockMasterAndTransaction> UpdateInventoryPhysicalStockMasterAndTransaction(InventoryPhysicalStockMasterAndTransaction item)
        {
            return _InventoryPhysicalStockMasterAndTransactionBA.UpdateInventoryPhysicalStockMasterAndTransaction(item);
        }
        public IBaseEntityResponse<InventoryPhysicalStockMasterAndTransaction> DeleteInventoryPhysicalStockMasterAndTransaction(InventoryPhysicalStockMasterAndTransaction item)
        {
            return _InventoryPhysicalStockMasterAndTransactionBA.DeleteInventoryPhysicalStockMasterAndTransaction(item);
        }
        public IBaseEntityCollectionResponse<InventoryPhysicalStockMasterAndTransaction> GetBySearch(InventoryPhysicalStockMasterAndTransactionSearchRequest searchRequest)
        {
            return _InventoryPhysicalStockMasterAndTransactionBA.GetBySearch(searchRequest);
        }
        public IBaseEntityCollectionResponse<InventoryPhysicalStockMasterAndTransaction> GetInventoryPhysicalStockMasterAndTransactionSearchList(InventoryPhysicalStockMasterAndTransactionSearchRequest searchRequest)
        {
            return _InventoryPhysicalStockMasterAndTransactionBA.GetInventoryPhysicalStockMasterAndTransactionSearchList(searchRequest);
        }
        public IBaseEntityResponse<InventoryPhysicalStockMasterAndTransaction> SelectByID(InventoryPhysicalStockMasterAndTransaction item)
        {
            return _InventoryPhysicalStockMasterAndTransactionBA.SelectByID(item);
        }

        public IBaseEntityCollectionResponse<InventoryPhysicalStockMasterAndTransaction> GetInventoryStockDetails(InventoryPhysicalStockMasterAndTransactionSearchRequest searchRequest)
        {
            return _InventoryPhysicalStockMasterAndTransactionBA.GetInventoryStockDetails(searchRequest);
        }
    
    }
}
