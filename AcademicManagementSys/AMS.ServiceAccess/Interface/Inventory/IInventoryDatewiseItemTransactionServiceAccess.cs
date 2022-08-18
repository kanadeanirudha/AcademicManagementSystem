using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.ServiceAccess
{
    public interface IInventoryDatewiseItemTransactionServiceAccess
    {
        IBaseEntityResponse<InventoryDatewiseItemTransaction> InsertInventoryDatewiseItemTransaction(InventoryDatewiseItemTransaction item);
        IBaseEntityResponse<InventoryDatewiseItemTransaction> UpdateInventoryDatewiseItemTransaction(InventoryDatewiseItemTransaction item);
        IBaseEntityResponse<InventoryDatewiseItemTransaction> DeleteInventoryDatewiseItemTransaction(InventoryDatewiseItemTransaction item);
        IBaseEntityCollectionResponse<InventoryDatewiseItemTransaction> GetBySearch(InventoryDatewiseItemTransactionSearchRequest searchRequest);
        IBaseEntityCollectionResponse<InventoryDatewiseItemTransaction> GetInventoryItemSearchList(InventoryDatewiseItemTransactionSearchRequest searchRequest);
        IBaseEntityResponse<InventoryDatewiseItemTransaction> SelectByID(InventoryDatewiseItemTransaction item);
    }
}
