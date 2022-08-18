using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Business.BusinessActions
{
    public interface IInventoryItemCategoryMasterBA
    {
        IBaseEntityResponse<InventoryItemCategoryMaster> InsertInventoryItemCategoryMaster(InventoryItemCategoryMaster item);
        IBaseEntityResponse<InventoryItemCategoryMaster> UpdateInventoryItemCategoryMaster(InventoryItemCategoryMaster item);
        IBaseEntityResponse<InventoryItemCategoryMaster> DeleteInventoryItemCategoryMaster(InventoryItemCategoryMaster item);
        IBaseEntityCollectionResponse<InventoryItemCategoryMaster> GetBySearch(InventoryItemCategoryMasterSearchRequest searchRequest);
        IBaseEntityCollectionResponse<InventoryItemCategoryMaster> GetInventoryItemCategoryMasterList(InventoryItemCategoryMasterSearchRequest searchRequest);
        IBaseEntityResponse<InventoryItemCategoryMaster> SelectByID(InventoryItemCategoryMaster item);
    }
}
