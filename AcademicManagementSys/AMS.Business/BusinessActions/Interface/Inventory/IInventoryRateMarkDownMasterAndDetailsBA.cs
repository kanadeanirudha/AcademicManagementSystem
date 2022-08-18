using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Business.BusinessActions
{
    public interface IInventoryRateMarkDownMasterAndDetailsBA
    {
        IBaseEntityResponse<InventoryRateMarkDownMasterAndDetails> InsertInventoryRateMarkDownMasterAndDetails(InventoryRateMarkDownMasterAndDetails item);
        IBaseEntityResponse<InventoryRateMarkDownMasterAndDetails> UpdateInventoryRateMarkDownMasterAndDetails(InventoryRateMarkDownMasterAndDetails item);
        IBaseEntityResponse<InventoryRateMarkDownMasterAndDetails> DeleteInventoryRateMarkDownMasterAndDetails(InventoryRateMarkDownMasterAndDetails item);
        IBaseEntityCollectionResponse<InventoryRateMarkDownMasterAndDetails> GetBySearch(InventoryRateMarkDownMasterAndDetailsSearchRequest searchRequest);
        IBaseEntityCollectionResponse<InventoryRateMarkDownMasterAndDetails> GetInventoryRateMarkDownMasterAndDetailsList(InventoryRateMarkDownMasterAndDetailsSearchRequest searchRequest);
        IBaseEntityResponse<InventoryRateMarkDownMasterAndDetails> SelectByID(InventoryRateMarkDownMasterAndDetails item);
    }
}
