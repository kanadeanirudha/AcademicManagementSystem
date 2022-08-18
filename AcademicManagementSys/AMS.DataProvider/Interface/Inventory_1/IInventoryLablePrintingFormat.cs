using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.DataProvider
{
    public interface IInventoryLablePrintingFormatDataProvider
    {
        IBaseEntityCollectionResponse<InventoryLablePrintingFormat> GetInventoryLablePrintingFormatByGeneralUnitsID(InventoryLablePrintingFormatSearchRequest searchRequest);
        IBaseEntityCollectionResponse<InventoryLablePrintingFormat> GetInventoryLablePrintingFormatBySearch_ItemList(InventoryLablePrintingFormatSearchRequest searchRequest);
        IBaseEntityCollectionResponse<InventoryLablePrintingFormat> GetItemNumberList(InventoryLablePrintingFormatSearchRequest searchRequest);
    }
}
