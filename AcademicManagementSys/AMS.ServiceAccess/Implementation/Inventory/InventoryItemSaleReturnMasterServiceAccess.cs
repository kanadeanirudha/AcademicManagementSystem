using AMS.Base.DTO;
using AMS.Business.BusinessActions;
using AMS.DTO;

namespace AMS.ServiceAccess
{
    public class InventoryItemSaleReturnMasterServiceAccess : IInventoryItemSaleReturnMasterServiceAccess
    {
        IInventoryItemSaleReturnMasterBA _inventoryItemSaleReturnMasterBA = null;
        public InventoryItemSaleReturnMasterServiceAccess()
		{
            _inventoryItemSaleReturnMasterBA = new InventoryItemSaleReturnMasterBA();
		}

        public IBaseEntityResponse<InventoryItemSaleReturnMaster> InsertInventoryItemSaleReturnMaster(InventoryItemSaleReturnMaster item)
        {
            return _inventoryItemSaleReturnMasterBA.InsertInventoryItemSaleReturnMaster(item);
        }
        public IBaseEntityResponse<InventoryItemSaleReturnMaster> UpdateInventoryItemSaleReturnMaster(InventoryItemSaleReturnMaster item)
        {
            return _inventoryItemSaleReturnMasterBA.UpdateInventoryItemSaleReturnMaster(item);
        }
        public IBaseEntityResponse<InventoryItemSaleReturnMaster> DeleteInventoryItemSaleReturnMaster(InventoryItemSaleReturnMaster item)
        {
            return _inventoryItemSaleReturnMasterBA.DeleteInventoryItemSaleReturnMaster(item);
        }
        public IBaseEntityCollectionResponse<InventoryItemSaleReturnMaster> GetInventoryItemSaleReturnMasterBySearch(InventoryItemSaleReturnMasterSearchRequest searchRequest)
        {
            return _inventoryItemSaleReturnMasterBA.GetInventoryItemSaleReturnMasterBySearch(searchRequest);
        }
        public IBaseEntityCollectionResponse<InventoryItemSaleReturnMaster> GetInventoryItemSaleReturnMasterByID(InventoryItemSaleReturnMasterSearchRequest searchRequest)
        {
            return _inventoryItemSaleReturnMasterBA.GetInventoryItemSaleReturnMasterByID(searchRequest);
        }

        //Search List.
        public IBaseEntityCollectionResponse<InventoryItemSaleReturnMaster> GetInventoryItemSaleReturnMasterSearchList(InventoryItemSaleReturnMasterSearchRequest searchRequest)
        {
            return _inventoryItemSaleReturnMasterBA.GetInventoryItemSaleReturnMasterSearchList(searchRequest);
        }
    



        public IBaseEntityCollectionResponse<InventoryItemSaleReturnMaster> GetBillDetailsByID(InventoryItemSaleReturnMasterSearchRequest searchRequest)
        {
            return _inventoryItemSaleReturnMasterBA.GetBillDetailsByID(searchRequest);
        }        
        public IBaseEntityResponse<InventoryItemSaleReturnMaster> GetInventoryItemQuantity(InventoryItemSaleReturnMaster item)
        {
            return _inventoryItemSaleReturnMasterBA.GetInventoryItemQuantity(item);
        }
        public IBaseEntityCollectionResponse<InventoryItemSaleReturnMaster> GetInventoryItemSaleReturnMasterBillPrintList(InventoryItemSaleReturnMasterSearchRequest searchRequest)
        {
            return _inventoryItemSaleReturnMasterBA.GetInventoryItemSaleReturnMasterBillPrintList(searchRequest);
        }
        //For Inventory Sale Report To operator
        public IBaseEntityCollectionResponse<InventoryItemSaleReturnMaster> GetInventorySalesReportToOperator(InventoryItemSaleReturnMasterSearchRequest searchRequest)
        {
            return _inventoryItemSaleReturnMasterBA.GetInventorySalesReportToOperator(searchRequest);
        }

        }
}
