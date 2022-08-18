using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.DataProvider
{
    public interface IInventoryDatewiseItemTransactionDataProvider
    {
        IBaseEntityResponse<InventoryDatewiseItemTransaction> InsertInventoryDatewiseItemTransaction(InventoryDatewiseItemTransaction item);
        IBaseEntityResponse<InventoryDatewiseItemTransaction> UpdateInventoryDatewiseItemTransaction(InventoryDatewiseItemTransaction item);
        IBaseEntityResponse<InventoryDatewiseItemTransaction> DeleteInventoryDatewiseItemTransaction(InventoryDatewiseItemTransaction item);
        IBaseEntityCollectionResponse<InventoryDatewiseItemTransaction> GetInventoryDatewiseItemTransactionBySearch(InventoryDatewiseItemTransactionSearchRequest searchRequest);
        IBaseEntityCollectionResponse<InventoryDatewiseItemTransaction> GetInventoryItemSearchList(InventoryDatewiseItemTransactionSearchRequest searchRequest);
        IBaseEntityResponse<InventoryDatewiseItemTransaction> GetInventoryDatewiseItemTransactionByID(InventoryDatewiseItemTransaction item);
    }
}
