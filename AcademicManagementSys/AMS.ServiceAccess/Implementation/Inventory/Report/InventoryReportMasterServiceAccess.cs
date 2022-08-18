using AMS.Base.DTO;
using AMS.Business.BusinessAction;
using AMS.DTO;

namespace AMS.ServiceAccess
{
    public class InventoryReportMasterServiceAccess : IInventoryReportMasterServiceAccess
    {
        IInventoryReportMasterBA _inventoryReportMasterBA = null;        
        public InventoryReportMasterServiceAccess()
		{
            _inventoryReportMasterBA = new InventoryReportMasterBA();
		}

        //EntranceExamSchedule Table Method.
        public IBaseEntityResponse<InventoryReportMaster> InsertInventoryReportMaster(InventoryReportMaster item)
		{
            return _inventoryReportMasterBA.InsertInventoryReportMaster(item);
		}
        public IBaseEntityResponse<InventoryReportMaster> UpdateInventoryReportMaster(InventoryReportMaster item)
		{
            return _inventoryReportMasterBA.UpdateInventoryReportMaster(item);
		}
        public IBaseEntityResponse<InventoryReportMaster> DeleteInventoryReportMaster(InventoryReportMaster item)
		{
            return _inventoryReportMasterBA.DeleteInventoryReportMaster(item);
		}        
        public IBaseEntityResponse<InventoryReportMaster> SelectInventoryReportMasterByID(InventoryReportMaster item)
		{
            return _inventoryReportMasterBA.SelectInventoryReportMasterByID(item);
		}

        //For ItemWiseCinsumption
        public IBaseEntityCollectionResponse<InventoryReportMaster> GetItemWiseConsumptionBySearch(InventoryReportMasterSearchRequest searchRequest)
        {
            return _inventoryReportMasterBA.GetItemWiseConsumptionBySearch(searchRequest);
        }

        //For DailyRateChange
        public IBaseEntityCollectionResponse<InventoryReportMaster> GetDailyRateChangeBySearch(InventoryReportMasterSearchRequest searchRequest)
        {
            return _inventoryReportMasterBA.GetDailyRateChangeBySearch(searchRequest);
        }

        //For DumpAndShrinkReport
        public IBaseEntityCollectionResponse<InventoryReportMaster> GetDumpAndShrinkReportBySearch(InventoryReportMasterSearchRequest searchRequest)
        {
            return _inventoryReportMasterBA.GetDumpAndShrinkReportBySearch(searchRequest);
        }

        //Search List
        public IBaseEntityCollectionResponse<InventoryReportMaster> GetInventoryReportMasterSearchList(InventoryReportMasterSearchRequest searchRequest)
        {
            return _inventoryReportMasterBA.GetInventoryReportMasterSearchList(searchRequest);
        }

        //For DailyItemRateChange Report
        public IBaseEntityCollectionResponse<InventoryReportMaster> GetDailyItemRateChangeReportBySearch(InventoryReportMasterSearchRequest searchRequest)
        {
            return _inventoryReportMasterBA.GetDailyItemRateChangeReportBySearch(searchRequest);
        }

        // For Below Indend Level Report       
        public IBaseEntityCollectionResponse<InventoryReportMaster> GetBelowIndendLevelReportBySearch(InventoryReportMasterSearchRequest searchRequest)
        {
            return _inventoryReportMasterBA.GetBelowIndendLevelReportBySearch(searchRequest);
        }
    }
}
