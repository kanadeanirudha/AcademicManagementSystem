using AMS.Base.DTO;
using AMS.Business.BusinessActions;
using AMS.DTO;

namespace AMS.ServiceAccess
{
    public class InventoryStockAdjustmentServiceAccess : IInventoryStockAdjustmentServiceAccess
    {
        IInventoryStockAdjustmentBA _InventoryStockAdjustmentBA = null;
        public InventoryStockAdjustmentServiceAccess()
        {
            _InventoryStockAdjustmentBA = new InventoryStockAdjustmentBA();
        }
        public IBaseEntityResponse<InventoryStockAdjustment> InsertInventoryStockAdjustment(InventoryStockAdjustment item)
        {
            return _InventoryStockAdjustmentBA.InsertInventoryStockAdjustment(item);
        }
        public IBaseEntityResponse<InventoryStockAdjustment> InsertInventoryStockAdjustmentXML(InventoryStockAdjustment item)
        {
            return _InventoryStockAdjustmentBA.InsertInventoryStockAdjustmentXML(item);
        }
        public IBaseEntityResponse<InventoryStockAdjustment> UpdateInventoryStockAdjustment(InventoryStockAdjustment item)
        {
            return _InventoryStockAdjustmentBA.UpdateInventoryStockAdjustment(item);
        }
        public IBaseEntityResponse<InventoryStockAdjustment> DeleteInventoryStockAdjustment(InventoryStockAdjustment item)
        {
            return _InventoryStockAdjustmentBA.DeleteInventoryStockAdjustment(item);
        }
        public IBaseEntityCollectionResponse<InventoryStockAdjustment> GetBySearch(InventoryStockAdjustmentSearchRequest searchRequest)
        {
            return _InventoryStockAdjustmentBA.GetBySearch(searchRequest);
        }
        public IBaseEntityCollectionResponse<InventoryStockAdjustment> GetInventoryStockAdjustmentSearchList(InventoryStockAdjustmentSearchRequest searchRequest)
        {
            return _InventoryStockAdjustmentBA.GetInventoryStockAdjustmentSearchList(searchRequest);
        }
        public IBaseEntityCollectionResponse<InventoryStockAdjustment> GetItemNameForCurrentStock(InventoryStockAdjustmentSearchRequest searchRequest)
        {
            return _InventoryStockAdjustmentBA.GetItemNameForCurrentStock(searchRequest);
        }
        public IBaseEntityResponse<InventoryStockAdjustment> SelectByID(InventoryStockAdjustment item)
        {
            return _InventoryStockAdjustmentBA.SelectByID(item);
        }
        public IBaseEntityCollectionResponse<InventoryStockAdjustment> GetInventoryStockAdjustmentSearchListForRecipeItem(InventoryStockAdjustmentSearchRequest searchRequest)
        {
            return _InventoryStockAdjustmentBA.GetInventoryStockAdjustmentSearchListForRecipeItem(searchRequest);
        }
        public IBaseEntityCollectionResponse<InventoryStockAdjustment> GetInventoryStockAdjustmentIngridentListForRecipeItem(InventoryStockAdjustmentSearchRequest searchRequest)
        {
            return _InventoryStockAdjustmentBA.GetInventoryStockAdjustmentIngridentListForRecipeItem(searchRequest);
        }
        public IBaseEntityResponse<InventoryStockAdjustment> InsertInventoryStockAdjustmentXMLForRecipe(InventoryStockAdjustment item)
        {
            return _InventoryStockAdjustmentBA.InsertInventoryStockAdjustmentXMLForRecipe(item);
        }
        public IBaseEntityCollectionResponse<InventoryStockAdjustment> GetInventoryItemBatchMasterList(InventoryStockAdjustmentSearchRequest searchRequest)
        {
            return _InventoryStockAdjustmentBA.GetInventoryItemBatchMasterList(searchRequest);
        }
    }
}
