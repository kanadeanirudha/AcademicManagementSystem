using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.ServiceAccess
{
    public interface IInventoryPhysicalStockMasterAndTransactionServiceAccess
    {
        IBaseEntityResponse<InventoryPhysicalStockMasterAndTransaction> InsertInventoryPhysicalStockMasterAndTransaction(InventoryPhysicalStockMasterAndTransaction item);
        IBaseEntityResponse<InventoryPhysicalStockMasterAndTransaction> UpdateInventoryPhysicalStockMasterAndTransaction(InventoryPhysicalStockMasterAndTransaction item);
        IBaseEntityResponse<InventoryPhysicalStockMasterAndTransaction> DeleteInventoryPhysicalStockMasterAndTransaction(InventoryPhysicalStockMasterAndTransaction item);
        IBaseEntityCollectionResponse<InventoryPhysicalStockMasterAndTransaction> GetBySearch(InventoryPhysicalStockMasterAndTransactionSearchRequest searchRequest);
        IBaseEntityCollectionResponse<InventoryPhysicalStockMasterAndTransaction> GetInventoryStockDetails(InventoryPhysicalStockMasterAndTransactionSearchRequest searchRequest);
        IBaseEntityResponse<InventoryPhysicalStockMasterAndTransaction> SelectByID(InventoryPhysicalStockMasterAndTransaction item);
        IBaseEntityCollectionResponse<InventoryPhysicalStockMasterAndTransaction> GetInventoryPhysicalStockMasterAndTransactionSearchList(InventoryPhysicalStockMasterAndTransactionSearchRequest searchRequest);
    }
}
