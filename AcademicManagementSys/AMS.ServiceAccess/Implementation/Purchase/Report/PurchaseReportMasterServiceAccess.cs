using AMS.Base.DTO;
using AMS.Business.BusinessAction;
using AMS.DTO;

namespace AMS.ServiceAccess
{
    public class PurchaseReportMasterServiceAccess : IPurchaseReportMasterServiceAccess
    {
        IPurchaseReportMasterBA _PurchaseReportMasterBA = null;        
        public PurchaseReportMasterServiceAccess()
		{
            _PurchaseReportMasterBA = new PurchaseReportMasterBA();
		}

        //EntranceExamSchedule Table Method.
        public IBaseEntityResponse<PurchaseReportMaster> InsertPurchaseReportMaster(PurchaseReportMaster item)
		{
            return _PurchaseReportMasterBA.InsertPurchaseReportMaster(item);
		}
        public IBaseEntityResponse<PurchaseReportMaster> UpdatePurchaseReportMaster(PurchaseReportMaster item)
		{
            return _PurchaseReportMasterBA.UpdatePurchaseReportMaster(item);
		}
        public IBaseEntityResponse<PurchaseReportMaster> DeletePurchaseReportMaster(PurchaseReportMaster item)
		{
            return _PurchaseReportMasterBA.DeletePurchaseReportMaster(item);
		}        
        public IBaseEntityResponse<PurchaseReportMaster> SelectPurchaseReportMasterByID(PurchaseReportMaster item)
		{
            return _PurchaseReportMasterBA.SelectPurchaseReportMasterByID(item);
		}

        //For ItemWiseCinsumption
        public IBaseEntityCollectionResponse<PurchaseReportMaster> GetArticalMovementReport(PurchaseReportMasterSearchRequest searchRequest)
        {
            return _PurchaseReportMasterBA.GetArticalMovementReport(searchRequest);
        }

        //For DailyRateChange
        public IBaseEntityCollectionResponse<PurchaseReportMaster> GetLocationWiseCurrentStockReport(PurchaseReportMasterSearchRequest searchRequest)
        {
            return _PurchaseReportMasterBA.GetLocationWiseCurrentStockReport(searchRequest);
        }

        //For DumpAndShrinkReport
        public IBaseEntityCollectionResponse<PurchaseReportMaster> GetStockConsumptionReport(PurchaseReportMasterSearchRequest searchRequest)
        {
            return _PurchaseReportMasterBA.GetStockConsumptionReport(searchRequest);
        }

        //Search List
        public IBaseEntityCollectionResponse<PurchaseReportMaster> GetPurchaseReportMasterSearchList(PurchaseReportMasterSearchRequest searchRequest)
        {
            return _PurchaseReportMasterBA.GetPurchaseReportMasterSearchList(searchRequest);
        }

        //For DailyItemRateChange Report
        public IBaseEntityCollectionResponse<PurchaseReportMaster> GetDailyItemRateChangeReportBySearch(PurchaseReportMasterSearchRequest searchRequest)
        {
            return _PurchaseReportMasterBA.GetDailyItemRateChangeReportBySearch(searchRequest);
        }

        // For Below Indend Level Report       
        public IBaseEntityCollectionResponse<PurchaseReportMaster> GetBelowIndendLevelReportBySearch(PurchaseReportMasterSearchRequest searchRequest)
        {
            return _PurchaseReportMasterBA.GetBelowIndendLevelReportBySearch(searchRequest);
        }

        //For Item Order Status Report
        // For Below Indend Level Report       
        public IBaseEntityCollectionResponse<PurchaseReportMaster> GetItemOrderStatusList(PurchaseReportMasterSearchRequest searchRequest)
        {
            return _PurchaseReportMasterBA.GetItemOrderStatusList(searchRequest);
        }
    }
}
