﻿using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Business.BusinessActions
{
    public interface IInventoryItemMasterBA
    {
        IBaseEntityResponse<InventoryItemMaster> InsertInventoryItemMaster(InventoryItemMaster item);
        IBaseEntityResponse<InventoryItemMaster> UpdateInventoryItemMaster(InventoryItemMaster item);
        IBaseEntityResponse<InventoryItemMaster> DeleteInventoryItemMaster(InventoryItemMaster item);
        IBaseEntityCollectionResponse<InventoryItemMaster> GetBySearch(InventoryItemMasterSearchRequest searchRequest);
        IBaseEntityCollectionResponse<InventoryItemMaster> GetInventoryItemSearchList(InventoryItemMasterSearchRequest searchRequest);
        IBaseEntityResponse<InventoryItemMaster> SelectByID(InventoryItemMaster item);
        IBaseEntityCollectionResponse<InventoryItemMaster> GetInventoryItemSearchListForSale(InventoryItemMasterSearchRequest searchRequest);
        IBaseEntityResponse<InventoryItemMaster> GetItemCode(InventoryItemMaster item);
        IBaseEntityCollectionResponse<InventoryItemMaster> GetBatchList(InventoryItemMasterSearchRequest searchRequest);
        IBaseEntityCollectionResponse<InventoryItemMaster> GetInventoryItemMasterList(InventoryItemMasterSearchRequest searchRequest);
        IBaseEntityCollectionResponse<InventoryItemMaster> GetInventoryItemSearchListForEstimation(InventoryItemMasterSearchRequest searchRequest);

        IBaseEntityCollectionResponse<InventoryItemMaster> GetItemFamilySearchList(InventoryItemMasterSearchRequest searchRequest);
        IBaseEntityCollectionResponse<InventoryItemMaster> GetItemPackingUnitSearchList(InventoryItemMasterSearchRequest searchRequest);
        IBaseEntityCollectionResponse<InventoryItemMaster> GetItemPackingTypeSearchList(InventoryItemMasterSearchRequest searchRequest);
        IBaseEntityResponse<InventoryItemMaster> CheckFocusOnAction(InventoryItemMaster item);
    }
}
