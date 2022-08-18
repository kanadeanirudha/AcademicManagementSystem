using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.DataProvider
{
    public interface IInventoryItemCategoryMasterDataProvider
    {
        IBaseEntityResponse<InventoryItemCategoryMaster> InsertInventoryItemCategoryMaster(InventoryItemCategoryMaster item);
        IBaseEntityResponse<InventoryItemCategoryMaster> UpdateInventoryItemCategoryMaster(InventoryItemCategoryMaster item);
        IBaseEntityResponse<InventoryItemCategoryMaster> DeleteInventoryItemCategoryMaster(InventoryItemCategoryMaster item);
        IBaseEntityCollectionResponse<InventoryItemCategoryMaster> GetInventoryItemCategoryMasterBySearch(InventoryItemCategoryMasterSearchRequest searchRequest);
        IBaseEntityCollectionResponse<InventoryItemCategoryMaster> GetInventoryItemCategoryMasterList(InventoryItemCategoryMasterSearchRequest searchRequest);
        IBaseEntityResponse<InventoryItemCategoryMaster> GetInventoryItemCategoryMasterByID(InventoryItemCategoryMaster item);
    }
}
