using System;
using System.Collections.Generic;
using AMS.Base.DTO;
using AMS.Business.BusinessActions;
using AMS.DTO;
namespace AMS.ServiceAccess
{
    public class InventoryCurrentStockPriceDrillReportServiceAccess : IInventoryCurrentStockPriceDrillReportServiceAccess
    {
        IInventoryCurrentStockPriceDrillReportBA _InventoryCurrentStockPriceDrillReportBA = null;
        public InventoryCurrentStockPriceDrillReportServiceAccess()
        {
            _InventoryCurrentStockPriceDrillReportBA = new InventoryCurrentStockPriceDrillReportBA();
        }

        public IBaseEntityCollectionResponse<InventoryCurrentStockPriceDrillReport> GetInventoryCurrentStockPriceDrillReportByOrganisation(InventoryCurrentStockPriceDrillReportSearchRequest searchRequest)
        {
            return _InventoryCurrentStockPriceDrillReportBA.GetInventoryCurrentStockPriceDrillReportByOrganisation(searchRequest);
        }

        public IBaseEntityCollectionResponse<InventoryCurrentStockPriceDrillReport> GetInventoryCurrentStockPriceDrillReportByCentre(InventoryCurrentStockPriceDrillReportSearchRequest searchRequest)
        {
            return _InventoryCurrentStockPriceDrillReportBA.GetInventoryCurrentStockPriceDrillReportByCentre(searchRequest);
        }
        public IBaseEntityCollectionResponse<InventoryCurrentStockPriceDrillReport> GetInventoryCurrentStockPriceDrillReportByStore(InventoryCurrentStockPriceDrillReportSearchRequest searchRequest)
        {
            return _InventoryCurrentStockPriceDrillReportBA.GetInventoryCurrentStockPriceDrillReportByStore(searchRequest);
        }
        public IBaseEntityCollectionResponse<InventoryCurrentStockPriceDrillReport> GetInventoryCurrentStockPriceDrillReportByArticle(InventoryCurrentStockPriceDrillReportSearchRequest searchRequest)
        {
            return _InventoryCurrentStockPriceDrillReportBA.GetInventoryCurrentStockPriceDrillReportByArticle(searchRequest);
        }

    }
}
