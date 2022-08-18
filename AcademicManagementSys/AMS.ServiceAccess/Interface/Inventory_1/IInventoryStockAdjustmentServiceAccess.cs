using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.ServiceAccess
{
    public interface IInventoryStockAdjustmentServiceAccess
    {
        IBaseEntityResponse<InventoryStockAdjustment> InsertInventoryStockAdjustment(InventoryStockAdjustment item);
        IBaseEntityResponse<InventoryStockAdjustment> InsertInventoryStockAdjustmentXML(InventoryStockAdjustment item);
        IBaseEntityResponse<InventoryStockAdjustment> UpdateInventoryStockAdjustment(InventoryStockAdjustment item);
        IBaseEntityResponse<InventoryStockAdjustment> DeleteInventoryStockAdjustment(InventoryStockAdjustment item);
        IBaseEntityCollectionResponse<InventoryStockAdjustment> GetBySearch(InventoryStockAdjustmentSearchRequest searchRequest);
        IBaseEntityResponse<InventoryStockAdjustment> SelectByID(InventoryStockAdjustment item);
        IBaseEntityCollectionResponse<InventoryStockAdjustment> GetInventoryStockAdjustmentSearchList(InventoryStockAdjustmentSearchRequest searchRequest);
        IBaseEntityCollectionResponse<InventoryStockAdjustment> GetItemNameForCurrentStock(InventoryStockAdjustmentSearchRequest searchRequest);

        IBaseEntityCollectionResponse<InventoryStockAdjustment> GetInventoryStockAdjustmentSearchListForRecipeItem(InventoryStockAdjustmentSearchRequest searchRequest);
        IBaseEntityCollectionResponse<InventoryStockAdjustment> GetInventoryStockAdjustmentIngridentListForRecipeItem(InventoryStockAdjustmentSearchRequest searchRequest);
        IBaseEntityResponse<InventoryStockAdjustment> InsertInventoryStockAdjustmentXMLForRecipe(InventoryStockAdjustment item);

        IBaseEntityCollectionResponse<InventoryStockAdjustment> GetInventoryItemBatchMasterList(InventoryStockAdjustmentSearchRequest searchRequest);
    }
}
