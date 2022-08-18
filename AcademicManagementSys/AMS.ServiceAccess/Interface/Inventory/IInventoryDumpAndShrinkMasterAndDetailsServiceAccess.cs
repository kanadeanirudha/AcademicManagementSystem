using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.ServiceAccess
{
    public interface IInventoryDumpAndShrinkMasterAndDetailsServiceAccess
    {
        IBaseEntityResponse<InventoryDumpAndShrinkMasterAndDetails> InsertInventoryDumpAndShrinkMasterAndDetails(InventoryDumpAndShrinkMasterAndDetails item);
        IBaseEntityResponse<InventoryDumpAndShrinkMasterAndDetails> InsertApprovedDumpAndShrinkRecord(InventoryDumpAndShrinkMasterAndDetails item);
        IBaseEntityResponse<InventoryDumpAndShrinkMasterAndDetails> UpdateInventoryDumpAndShrinkMasterAndDetails(InventoryDumpAndShrinkMasterAndDetails item);
        IBaseEntityResponse<InventoryDumpAndShrinkMasterAndDetails> DeleteInventoryDumpAndShrinkMasterAndDetails(InventoryDumpAndShrinkMasterAndDetails item);
        IBaseEntityCollectionResponse<InventoryDumpAndShrinkMasterAndDetails> GetBySearch(InventoryDumpAndShrinkMasterAndDetailsSearchRequest searchRequest);
        IBaseEntityCollectionResponse<InventoryDumpAndShrinkMasterAndDetails> GetDumpAndShrinkDetails(InventoryDumpAndShrinkMasterAndDetailsSearchRequest searchRequest);
        IBaseEntityCollectionResponse<InventoryDumpAndShrinkMasterAndDetails> GetDumpAndShrinkRequestForApproval(InventoryDumpAndShrinkMasterAndDetailsSearchRequest searchRequest);
        IBaseEntityResponse<InventoryDumpAndShrinkMasterAndDetails> SelectByID(InventoryDumpAndShrinkMasterAndDetails item);
    }
}
