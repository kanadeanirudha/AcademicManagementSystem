using AMS.Base.DTO;
using AMS.Business.BusinessAction;
using AMS.DTO;

namespace AMS.ServiceAccess
{
    public class InventoryInWardMasterAndInWardDetailsServiceAccess : IInventoryInWardMasterAndInWardDetailsServiceAccess
    {
        IInventoryInWardMasterAndInWardDetailsBA _inventoryInWardMasterAndInWardDetailsBA = null;

        public InventoryInWardMasterAndInWardDetailsServiceAccess()
        {
            _inventoryInWardMasterAndInWardDetailsBA = new InventoryInWardMasterAndInWardDetailsBA();
        }

        // InventoryInWardMaster Table Property.
        public IBaseEntityResponse<InventoryInWardMasterAndInWardDetails> InsertInventoryInWardMaster(InventoryInWardMasterAndInWardDetails item)
        {
            return _inventoryInWardMasterAndInWardDetailsBA.InsertInventoryInWardMaster(item);
        }
        public IBaseEntityResponse<InventoryInWardMasterAndInWardDetails> UpdateInventoryInWardMaster(InventoryInWardMasterAndInWardDetails item)
        {
            return _inventoryInWardMasterAndInWardDetailsBA.UpdateInventoryInWardMaster(item);
        }
        public IBaseEntityResponse<InventoryInWardMasterAndInWardDetails> DeleteInventoryInWardMaster(InventoryInWardMasterAndInWardDetails item)
        {
            return _inventoryInWardMasterAndInWardDetailsBA.DeleteInventoryInWardMaster(item);
        }
        public IBaseEntityCollectionResponse<InventoryInWardMasterAndInWardDetails> GetInventoryInWardMasterBySearch(InventoryInWardMasterAndInWardDetailsSearchRequest searchRequest)
        {
            return _inventoryInWardMasterAndInWardDetailsBA.GetInventoryInWardMasterBySearch(searchRequest);
        }
        public IBaseEntityResponse<InventoryInWardMasterAndInWardDetails> GetInventoryInWardMasterByID(InventoryInWardMasterAndInWardDetails item)
        {
            return _inventoryInWardMasterAndInWardDetailsBA.GetInventoryInWardMasterByID(item);
        }

        public IBaseEntityCollectionResponse<InventoryInWardMasterAndInWardDetails> GetInWardRequestForApproval(InventoryInWardMasterAndInWardDetailsSearchRequest searchRequest)
        {
            return _inventoryInWardMasterAndInWardDetailsBA.GetInWardRequestForApproval(searchRequest);
        }
        //InventoryIssueMaster Search List
        public IBaseEntityCollectionResponse<InventoryInWardMasterAndInWardDetails> GetInventoryInWardMasterSearchList(InventoryInWardMasterAndInWardDetailsSearchRequest searchRequest)
        {
            return _inventoryInWardMasterAndInWardDetailsBA.GetInventoryInWardMasterSearchList(searchRequest);
        }



        // InventoryInWardDetails Table Property.
        public IBaseEntityResponse<InventoryInWardMasterAndInWardDetails> InsertInventoryInWardDetails(InventoryInWardMasterAndInWardDetails item)
        {
            return _inventoryInWardMasterAndInWardDetailsBA.InsertInventoryInWardDetails(item);
        }
        public IBaseEntityResponse<InventoryInWardMasterAndInWardDetails> UpdateInventoryInWardDetails(InventoryInWardMasterAndInWardDetails item)
        {
            return _inventoryInWardMasterAndInWardDetailsBA.UpdateInventoryInWardDetails(item);
        }
        public IBaseEntityResponse<InventoryInWardMasterAndInWardDetails> DeleteInventoryInWardDetails(InventoryInWardMasterAndInWardDetails item)
        {
            return _inventoryInWardMasterAndInWardDetailsBA.DeleteInventoryInWardDetails(item);
        }
        public IBaseEntityCollectionResponse<InventoryInWardMasterAndInWardDetails> GetInventoryInWardDetailsBySearch(InventoryInWardMasterAndInWardDetailsSearchRequest searchRequest)
        {
            return _inventoryInWardMasterAndInWardDetailsBA.GetInventoryInWardDetailsBySearch(searchRequest);
        }
        public IBaseEntityResponse<InventoryInWardMasterAndInWardDetails> GetInventoryInWardDetailsByID(InventoryInWardMasterAndInWardDetails item)
        {
            return _inventoryInWardMasterAndInWardDetailsBA.GetInventoryInWardDetailsByID(item);
        }
        //InventoryInWardDetails Search List
        public IBaseEntityCollectionResponse<InventoryInWardMasterAndInWardDetails> GetInventoryInWardDetailsSearchList(InventoryInWardMasterAndInWardDetailsSearchRequest searchRequest)
        {
            return _inventoryInWardMasterAndInWardDetailsBA.GetInventoryInWardDetailsSearchList(searchRequest);
        }

        //Laayer For InvSystemSettingMaster list
       
        public IBaseEntityCollectionResponse<InventoryInWardMasterAndInWardDetails> GetInvSystemSetting(InventoryInWardMasterAndInWardDetailsSearchRequest searchRequest)
        {
            return _inventoryInWardMasterAndInWardDetailsBA.GetInvSystemSetting(searchRequest);
        }
        //Laayer For Inv Sync History Count

        public IBaseEntityResponse<InventoryInWardMasterAndInWardDetails> GetInvSyncHistoryCount(InventoryInWardMasterAndInWardDetails item)
        {
            return _inventoryInWardMasterAndInWardDetailsBA.GetInvSyncHistoryCount(item);
        }
        

    }
}
