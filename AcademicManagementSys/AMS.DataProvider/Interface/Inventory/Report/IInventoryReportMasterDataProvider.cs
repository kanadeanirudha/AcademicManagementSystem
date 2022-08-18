using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.DataProvider
{
    public interface IInventoryReportMasterDataProvider
    {
        // InventoryReportMaster Method
        IBaseEntityResponse<InventoryReportMaster> InsertInventoryReportMaster(InventoryReportMaster item);
        IBaseEntityResponse<InventoryReportMaster> UpdateInventoryReportMaster(InventoryReportMaster item);
        IBaseEntityResponse<InventoryReportMaster> DeleteInventoryReportMaster(InventoryReportMaster item);        
        IBaseEntityResponse<InventoryReportMaster> GetInventoryReportMasterByID(InventoryReportMaster item);

        //Search InventoryReportMaster List
        IBaseEntityCollectionResponse<InventoryReportMaster> GetInventoryReportMasterSearchList(InventoryReportMasterSearchRequest searchRequest);

        IBaseEntityCollectionResponse<InventoryReportMaster> GetItemWiseConsumptionBySearch(InventoryReportMasterSearchRequest searchRequest);

        IBaseEntityCollectionResponse<InventoryReportMaster> GetDailyRateChangeBySearch(InventoryReportMasterSearchRequest searchRequest);

        IBaseEntityCollectionResponse<InventoryReportMaster> GetDumpAndShrinkReportBySearch(InventoryReportMasterSearchRequest searchRequest);

        //For DailyItemRateChange Report
        IBaseEntityCollectionResponse<InventoryReportMaster> GetDailyItemRateChangeReportBySearch(InventoryReportMasterSearchRequest searchRequest);

        //For Below Indend Level Report.
        IBaseEntityCollectionResponse<InventoryReportMaster> GetBelowIndendLevelReportBySearch(InventoryReportMasterSearchRequest searchRequest);
    }
}
