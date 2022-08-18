using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.ServiceAccess
{
    public interface IPurchaseReportMasterServiceAccess
    {
        IBaseEntityResponse<PurchaseReportMaster> InsertPurchaseReportMaster(PurchaseReportMaster item);
        IBaseEntityResponse<PurchaseReportMaster> UpdatePurchaseReportMaster(PurchaseReportMaster item);
        IBaseEntityResponse<PurchaseReportMaster> DeletePurchaseReportMaster(PurchaseReportMaster item);        
        IBaseEntityResponse<PurchaseReportMaster> SelectPurchaseReportMasterByID(PurchaseReportMaster item);
                
        //Search List.
        IBaseEntityCollectionResponse<PurchaseReportMaster> GetPurchaseReportMasterSearchList(PurchaseReportMasterSearchRequest searchRequest);

        //For ArticalMovement Report
        IBaseEntityCollectionResponse<PurchaseReportMaster> GetArticalMovementReport(PurchaseReportMasterSearchRequest searchRequest);

        //For Crurrent Stock Report
        IBaseEntityCollectionResponse<PurchaseReportMaster> GetLocationWiseCurrentStockReport(PurchaseReportMasterSearchRequest searchRequest);

        //For DumpAndShrinkReport
        IBaseEntityCollectionResponse<PurchaseReportMaster> GetStockConsumptionReport(PurchaseReportMasterSearchRequest searchRequest);

        //For DailyItemRateChange Report
        IBaseEntityCollectionResponse<PurchaseReportMaster> GetDailyItemRateChangeReportBySearch(PurchaseReportMasterSearchRequest searchRequest);

        //For Below Indend Level Report
        IBaseEntityCollectionResponse<PurchaseReportMaster> GetBelowIndendLevelReportBySearch(PurchaseReportMasterSearchRequest searchRequest);

        //For Item Order Status Report
        //For Below Indend Level Report
        IBaseEntityCollectionResponse<PurchaseReportMaster> GetItemOrderStatusList(PurchaseReportMasterSearchRequest searchRequest);
    }
}
