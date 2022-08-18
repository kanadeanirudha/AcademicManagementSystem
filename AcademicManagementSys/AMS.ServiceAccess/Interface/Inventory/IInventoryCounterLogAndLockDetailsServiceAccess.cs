
using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.ServiceAccess
{
    public interface IInventoryCounterLogAndLockDetailsServiceAccess
    {
        IBaseEntityResponse<InventoryCounterLogAndLockDetails> InsertInventoryCounterLogAndLockDetails(InventoryCounterLogAndLockDetails item);
        IBaseEntityResponse<InventoryCounterLogAndLockDetails> UpdateInventoryCounterLogAndLockDetails(InventoryCounterLogAndLockDetails item);
        IBaseEntityResponse<InventoryCounterLogAndLockDetails> DeleteInventoryCounterLogAndLockDetails(InventoryCounterLogAndLockDetails item);
        IBaseEntityCollectionResponse<InventoryCounterLogAndLockDetails> GetBySearch(InventoryCounterLogAndLockDetailsSearchRequest searchRequest);
        IBaseEntityResponse<InventoryCounterLogAndLockDetails> SelectByID(InventoryCounterLogAndLockDetails item);
        IBaseEntityCollectionResponse<InventoryCounterLogAndLockDetails> GetInventoryCounterLogAndLockDetailsList(InventoryCounterLogAndLockDetailsSearchRequest searchRequest);
        IBaseEntityCollectionResponse<InventoryCounterLogAndLockDetails> GetInventoryCounterLockStatus(InventoryCounterLogAndLockDetailsSearchRequest searchRequest);
        IBaseEntityCollectionResponse<InventoryCounterLogAndLockDetails> GetInventoryCounterLog_OpeningCashAndTotalSaleAmount(InventoryCounterLogAndLockDetailsSearchRequest searchRequest);
    }
}
