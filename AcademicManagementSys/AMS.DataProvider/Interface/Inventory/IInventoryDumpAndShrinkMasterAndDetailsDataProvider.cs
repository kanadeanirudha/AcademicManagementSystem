using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.DataProvider
{
    public interface IInventoryDumpAndShrinkMasterAndDetailsDataProvider
    {
        IBaseEntityResponse<InventoryDumpAndShrinkMasterAndDetails> InsertInventoryDumpAndShrinkMasterAndDetails(InventoryDumpAndShrinkMasterAndDetails item);
        IBaseEntityResponse<InventoryDumpAndShrinkMasterAndDetails> InsertApprovedDumpAndShrinkRecord(InventoryDumpAndShrinkMasterAndDetails item);
        IBaseEntityResponse<InventoryDumpAndShrinkMasterAndDetails> UpdateInventoryDumpAndShrinkMasterAndDetails(InventoryDumpAndShrinkMasterAndDetails item);
        IBaseEntityResponse<InventoryDumpAndShrinkMasterAndDetails> DeleteInventoryDumpAndShrinkMasterAndDetails(InventoryDumpAndShrinkMasterAndDetails item);
        IBaseEntityCollectionResponse<InventoryDumpAndShrinkMasterAndDetails> GetInventoryDumpAndShrinkMasterAndDetailsBySearch(InventoryDumpAndShrinkMasterAndDetailsSearchRequest searchRequest);
        IBaseEntityCollectionResponse<InventoryDumpAndShrinkMasterAndDetails> GetDumpAndShrinkDetails(InventoryDumpAndShrinkMasterAndDetailsSearchRequest searchRequest);
        IBaseEntityCollectionResponse<InventoryDumpAndShrinkMasterAndDetails> GetDumpAndShrinkRequestForApproval(InventoryDumpAndShrinkMasterAndDetailsSearchRequest searchRequest);
        IBaseEntityResponse<InventoryDumpAndShrinkMasterAndDetails> GetInventoryDumpAndShrinkMasterAndDetailsByID(InventoryDumpAndShrinkMasterAndDetails item);
    }
}
