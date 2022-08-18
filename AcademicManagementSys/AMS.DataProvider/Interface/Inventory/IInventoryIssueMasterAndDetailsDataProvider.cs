using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.DataProvider
{
    public interface IInventoryIssueMasterAndDetailsDataProvider
    {
        IBaseEntityResponse<InventoryIssueMasterAndDetails> InsertInventoryIssueMasterAndDetails(InventoryIssueMasterAndDetails item);
        IBaseEntityResponse<InventoryIssueMasterAndDetails> UpdateInventoryIssueMasterAndDetails(InventoryIssueMasterAndDetails item);
        IBaseEntityResponse<InventoryIssueMasterAndDetails> DeleteInventoryIssueMasterAndDetails(InventoryIssueMasterAndDetails item);
        IBaseEntityCollectionResponse<InventoryIssueMasterAndDetails> GetInventoryIssueMasterAndDetailsBySearch(InventoryIssueMasterAndDetailsSearchRequest searchRequest);
        IBaseEntityResponse<InventoryIssueMasterAndDetails> GetInventoryIssueMasterAndDetailsByID(InventoryIssueMasterAndDetails item);
    }
}
