using System;
using System.Collections.Generic;
using AMS.Base.DTO;
using AMS.Business.BusinessActions;
using AMS.DTO;
namespace AMS.ServiceAccess
{
    public class InventoryLablePrintingFormatServiceAccess : IInventoryLablePrintingFormatServiceAccess
    {
        IInventoryLablePrintingFormatBA _InventoryLablePrintingFormatBA = null;
        public InventoryLablePrintingFormatServiceAccess()
        {
            _InventoryLablePrintingFormatBA = new InventoryLablePrintingFormatBA();
        }

        public IBaseEntityCollectionResponse<InventoryLablePrintingFormat> GetInventoryLablePrintingFormatByGeneralUnitsID(InventoryLablePrintingFormatSearchRequest searchRequest)
         {
             return _InventoryLablePrintingFormatBA.GetInventoryLablePrintingFormatByGeneralUnitsID(searchRequest);
         }

        public IBaseEntityCollectionResponse<InventoryLablePrintingFormat> GetInventoryLablePrintingFormatBySearch_ItemList(InventoryLablePrintingFormatSearchRequest searchRequest)
        {
            return _InventoryLablePrintingFormatBA.GetInventoryLablePrintingFormatBySearch_ItemList(searchRequest);
        }

        public IBaseEntityCollectionResponse<InventoryLablePrintingFormat> GetItemNumberList(InventoryLablePrintingFormatSearchRequest searchRequest)
        {
            return _InventoryLablePrintingFormatBA.GetItemNumberList(searchRequest);
        }
    }
}
