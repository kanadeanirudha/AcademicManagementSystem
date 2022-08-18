using System;
using System.Collections.Generic;
using AMS.Base.DTO;
using AMS.Business.BusinessActions;
using AMS.DTO;
namespace AMS.ServiceAccess
{
    public class InventoryReportServiceAccess : IInventoryReportServiceAccess
    {
        IInventoryReportBA _InventoryReportBA = null;
        public InventoryReportServiceAccess()
        {
            _InventoryReportBA = new InventoryReportBA();
        }

        public IBaseEntityCollectionResponse<InventoryReport> GetInventoryReportBySearch_PriceList(InventoryReportSearchRequest searchRequest)
         {
             return _InventoryReportBA.GetInventoryReportBySearch_PriceList(searchRequest);
         }

        public IBaseEntityCollectionResponse<InventoryReport> GetInventoryReportBySearch_ItemList(InventoryReportSearchRequest searchRequest)
        {
            return _InventoryReportBA.GetInventoryReportBySearch_ItemList(searchRequest);
        }
        public IBaseEntityCollectionResponse<InventoryReport> GetInventoryReportBySearch_ArticleList(InventoryReportSearchRequest searchRequest)
        {
            return _InventoryReportBA.GetInventoryReportBySearch_ArticleList(searchRequest);
        }
    }
}
