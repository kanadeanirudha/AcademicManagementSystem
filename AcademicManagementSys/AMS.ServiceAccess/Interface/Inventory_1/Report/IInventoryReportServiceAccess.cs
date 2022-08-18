using System;
using System.Collections.Generic;
using System.Linq;
using AMS.Base.DTO;
using AMS.DTO;
using System.Text;
using System.Threading.Tasks;
namespace AMS.Business.BusinessActions
{
    public interface IInventoryReportServiceAccess
    {
      IBaseEntityCollectionResponse<InventoryReport> GetInventoryReportBySearch_PriceList(InventoryReportSearchRequest searchRequest);
      IBaseEntityCollectionResponse<InventoryReport> GetInventoryReportBySearch_ItemList(InventoryReportSearchRequest searchRequest);
      IBaseEntityCollectionResponse<InventoryReport> GetInventoryReportBySearch_ArticleList(InventoryReportSearchRequest searchRequest);

    }
}
