using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.DataProvider
{
    public interface IInventoryReportDataProvider
    {
         IBaseEntityCollectionResponse<InventoryReport> GetInventoryReportBySearch_PriceList(InventoryReportSearchRequest searchRequest);
         IBaseEntityCollectionResponse<InventoryReport> GetInventoryReportBySearch_ItemList(InventoryReportSearchRequest searchRequest);
         IBaseEntityCollectionResponse<InventoryReport> GetInventoryReportBySearch_ArticleList(InventoryReportSearchRequest searchRequest);
    }
}
