using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.DataProvider
{
    public interface IInventoryItemSaleReturnMasterDataProvider
    {
        IBaseEntityResponse<InventoryItemSaleReturnMaster> InsertInventoryItemSaleReturnMaster(InventoryItemSaleReturnMaster item);
        IBaseEntityResponse<InventoryItemSaleReturnMaster> UpdateInventoryItemSaleReturnMaster(InventoryItemSaleReturnMaster item);
        IBaseEntityResponse<InventoryItemSaleReturnMaster> DeleteInventoryItemSaleReturnMaster(InventoryItemSaleReturnMaster item);
        IBaseEntityCollectionResponse<InventoryItemSaleReturnMaster> GetInventoryItemSaleReturnMasterBySearch(InventoryItemSaleReturnMasterSearchRequest searchRequest);
        IBaseEntityCollectionResponse<InventoryItemSaleReturnMaster> GetBillDetailsByID(InventoryItemSaleReturnMasterSearchRequest searchRequest);
        IBaseEntityCollectionResponse<InventoryItemSaleReturnMaster> GetInventoryItemSaleReturnMasterByID(InventoryItemSaleReturnMasterSearchRequest searchRequest);

        IBaseEntityResponse<InventoryItemSaleReturnMaster> GetInventoryItemQuantity(InventoryItemSaleReturnMaster item);
        IBaseEntityCollectionResponse<InventoryItemSaleReturnMaster> GetInventoryItemSaleReturnMasterBillPrintList(InventoryItemSaleReturnMasterSearchRequest searchRequest);

        //For Inventory Sale Report To operator
        IBaseEntityCollectionResponse<InventoryItemSaleReturnMaster> GetInventorySalesReportToOperator(InventoryItemSaleReturnMasterSearchRequest searchRequest);
        //Search List.
        IBaseEntityCollectionResponse<InventoryItemSaleReturnMaster> GetInventoryItemSaleReturnMasterSearchList(InventoryItemSaleReturnMasterSearchRequest searchRequest);
    }
}
