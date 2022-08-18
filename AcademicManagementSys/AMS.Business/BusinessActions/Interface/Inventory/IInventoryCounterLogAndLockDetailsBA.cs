
using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Business.BusinessActions
{
    public interface IInventoryCounterLogAndLockDetailsBA
    {
        IBaseEntityResponse<InventoryCounterLogAndLockDetails> InsertInventoryCounterLogAndLockDetails(InventoryCounterLogAndLockDetails item);
        IBaseEntityResponse<InventoryCounterLogAndLockDetails> UpdateInventoryCounterLogAndLockDetails(InventoryCounterLogAndLockDetails item);
        IBaseEntityResponse<InventoryCounterLogAndLockDetails> DeleteInventoryCounterLogAndLockDetails(InventoryCounterLogAndLockDetails item);
        IBaseEntityCollectionResponse<InventoryCounterLogAndLockDetails> GetBySearch(InventoryCounterLogAndLockDetailsSearchRequest searchRequest);
        IBaseEntityCollectionResponse<InventoryCounterLogAndLockDetails> GetInventoryCounterLogAndLockDetailsList(InventoryCounterLogAndLockDetailsSearchRequest searchRequest);
        IBaseEntityResponse<InventoryCounterLogAndLockDetails> SelectByID(InventoryCounterLogAndLockDetails item);
        IBaseEntityCollectionResponse<InventoryCounterLogAndLockDetails> GetInventoryCounterLockStatus(InventoryCounterLogAndLockDetailsSearchRequest searchRequest);
        IBaseEntityCollectionResponse<InventoryCounterLogAndLockDetails> GetInventoryCounterLog_OpeningCashAndTotalSaleAmount(InventoryCounterLogAndLockDetailsSearchRequest searchRequest);
      
    }
}
