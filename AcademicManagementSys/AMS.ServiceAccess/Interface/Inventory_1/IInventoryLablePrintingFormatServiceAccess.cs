using System;
using System.Collections.Generic;
using System.Linq;
using AMS.Base.DTO;
using AMS.DTO;
using System.Text;
using System.Threading.Tasks;
namespace AMS.Business.BusinessActions
{
    public interface IInventoryLablePrintingFormatServiceAccess
    {
      IBaseEntityCollectionResponse<InventoryLablePrintingFormat> GetInventoryLablePrintingFormatByGeneralUnitsID(InventoryLablePrintingFormatSearchRequest searchRequest);
      IBaseEntityCollectionResponse<InventoryLablePrintingFormat> GetInventoryLablePrintingFormatBySearch_ItemList(InventoryLablePrintingFormatSearchRequest searchRequest);
      IBaseEntityCollectionResponse<InventoryLablePrintingFormat> GetItemNumberList(InventoryLablePrintingFormatSearchRequest searchRequest);
    }
}
