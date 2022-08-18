using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.DataProvider
{
    public interface IInventoryRateMarkDownMasterAndDetailsDataProvider
    {
        IBaseEntityResponse<InventoryRateMarkDownMasterAndDetails> InsertInventoryRateMarkDownMasterAndDetails(InventoryRateMarkDownMasterAndDetails item);
        IBaseEntityResponse<InventoryRateMarkDownMasterAndDetails> UpdateInventoryRateMarkDownMasterAndDetails(InventoryRateMarkDownMasterAndDetails item);
        IBaseEntityResponse<InventoryRateMarkDownMasterAndDetails> DeleteInventoryRateMarkDownMasterAndDetails(InventoryRateMarkDownMasterAndDetails item);
        IBaseEntityCollectionResponse<InventoryRateMarkDownMasterAndDetails> GetInventoryRateMarkDownMasterAndDetailsBySearch(InventoryRateMarkDownMasterAndDetailsSearchRequest searchRequest);
        IBaseEntityCollectionResponse<InventoryRateMarkDownMasterAndDetails> GetInventoryRateMarkDownMasterAndDetailsList(InventoryRateMarkDownMasterAndDetailsSearchRequest searchRequest);
        IBaseEntityResponse<InventoryRateMarkDownMasterAndDetails> GetInventoryRateMarkDownMasterAndDetailsByID(InventoryRateMarkDownMasterAndDetails item);
    }
}
