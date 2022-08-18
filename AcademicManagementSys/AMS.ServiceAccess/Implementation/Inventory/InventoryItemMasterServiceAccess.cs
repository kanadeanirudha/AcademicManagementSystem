using System;
using System.Collections.Generic;
using AMS.Base.DTO;
using AMS.Business.BusinessActions;
using AMS.DTO;

namespace AMS.ServiceAccess
{
    public class InventoryItemMasterServiceAccess : IInventoryItemMasterServiceAccess
    {
        IInventoryItemMasterBA _InventoryItemMasterBA = null;
        public InventoryItemMasterServiceAccess()
        {
            _InventoryItemMasterBA = new InventoryItemMasterBA();
        }
        public IBaseEntityResponse<InventoryItemMaster> InsertInventoryItemMaster(InventoryItemMaster item)
        {
            return _InventoryItemMasterBA.InsertInventoryItemMaster(item);
        }
        public IBaseEntityResponse<InventoryItemMaster> UpdateInventoryItemMaster(InventoryItemMaster item)
        {
            return _InventoryItemMasterBA.UpdateInventoryItemMaster(item);
        }
        public IBaseEntityResponse<InventoryItemMaster> DeleteInventoryItemMaster(InventoryItemMaster item)
        {
            return _InventoryItemMasterBA.DeleteInventoryItemMaster(item);
        }
        public IBaseEntityCollectionResponse<InventoryItemMaster> GetBySearch(InventoryItemMasterSearchRequest searchRequest)
        {
            return _InventoryItemMasterBA.GetBySearch(searchRequest);
        }
        public IBaseEntityCollectionResponse<InventoryItemMaster> GetInventoryItemSearchList(InventoryItemMasterSearchRequest searchRequest)
        {
            return _InventoryItemMasterBA.GetInventoryItemSearchList(searchRequest);
        }
        public IBaseEntityResponse<InventoryItemMaster> SelectByID(InventoryItemMaster item)
        {
            return _InventoryItemMasterBA.SelectByID(item);
        }
        public IBaseEntityCollectionResponse<InventoryItemMaster> GetInventoryItemSearchListForSale(InventoryItemMasterSearchRequest searchRequest)
        {
            return _InventoryItemMasterBA.GetInventoryItemSearchListForSale(searchRequest);
        }
        public IBaseEntityResponse<InventoryItemMaster> GetItemCode(InventoryItemMaster item)
        {
            return _InventoryItemMasterBA.GetItemCode(item);
        }
        public IBaseEntityCollectionResponse<InventoryItemMaster> GetBatchList(InventoryItemMasterSearchRequest searchRequest)
        {
            return _InventoryItemMasterBA.GetBatchList(searchRequest);
        }
        public IBaseEntityCollectionResponse<InventoryItemMaster> GetInventoryItemMasterList(InventoryItemMasterSearchRequest searchRequest)
        {
            return _InventoryItemMasterBA.GetInventoryItemMasterList(searchRequest);
        }
        public IBaseEntityCollectionResponse<InventoryItemMaster> GetInventoryItemSearchListForEstimation(InventoryItemMasterSearchRequest searchRequest)
        {
            return _InventoryItemMasterBA.GetInventoryItemSearchListForEstimation(searchRequest);
        }

        public IBaseEntityCollectionResponse<InventoryItemMaster> GetItemFamilySearchList(InventoryItemMasterSearchRequest searchRequest)
        {
            return _InventoryItemMasterBA.GetItemFamilySearchList(searchRequest);
        }
        public IBaseEntityCollectionResponse<InventoryItemMaster> GetItemPackingUnitSearchList(InventoryItemMasterSearchRequest searchRequest)
        {
            return _InventoryItemMasterBA.GetItemPackingUnitSearchList(searchRequest);
        }


        public IBaseEntityCollectionResponse<InventoryItemMaster> GetItemPackingTypeSearchList(InventoryItemMasterSearchRequest searchRequest)
        {
            return _InventoryItemMasterBA.GetItemPackingTypeSearchList(searchRequest);
        }

        public IBaseEntityResponse<InventoryItemMaster> CheckFocusOnAction(InventoryItemMaster item)
        {
            return _InventoryItemMasterBA.CheckFocusOnAction(item);
        }
    }
}
