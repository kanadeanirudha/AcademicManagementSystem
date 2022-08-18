using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.ServiceAccess
{
    public interface IInventoryReportMasterServiceAccess
    {
        IBaseEntityResponse<InventoryReportMaster> InsertInventoryReportMaster(InventoryReportMaster item);
        IBaseEntityResponse<InventoryReportMaster> UpdateInventoryReportMaster(InventoryReportMaster item);
        IBaseEntityResponse<InventoryReportMaster> DeleteInventoryReportMaster(InventoryReportMaster item);        
        IBaseEntityResponse<InventoryReportMaster> SelectInventoryReportMasterByID(InventoryReportMaster item);
                
        //Search List.
        IBaseEntityCollectionResponse<InventoryReportMaster> GetInventoryReportMasterSearchList(InventoryReportMasterSearchRequest searchRequest);

        //For ItemWiseCinsumption
        IBaseEntityCollectionResponse<InventoryReportMaster> GetItemWiseConsumptionBySearch(InventoryReportMasterSearchRequest searchRequest);

        //For DailyRateChange
        IBaseEntityCollectionResponse<InventoryReportMaster> GetDailyRateChangeBySearch(InventoryReportMasterSearchRequest searchRequest);

        //For DumpAndShrinkReport
        IBaseEntityCollectionResponse<InventoryReportMaster> GetDumpAndShrinkReportBySearch(InventoryReportMasterSearchRequest searchRequest);

        //For DailyItemRateChange Report
        IBaseEntityCollectionResponse<InventoryReportMaster> GetDailyItemRateChangeReportBySearch(InventoryReportMasterSearchRequest searchRequest);

        //For Below Indend Level Report
        IBaseEntityCollectionResponse<InventoryReportMaster> GetBelowIndendLevelReportBySearch(InventoryReportMasterSearchRequest searchRequest);
    }
}
