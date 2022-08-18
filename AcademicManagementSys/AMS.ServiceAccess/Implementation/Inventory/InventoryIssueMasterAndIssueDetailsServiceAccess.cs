using AMS.Base.DTO;
using AMS.Business.BusinessAction;
using AMS.DTO;

namespace AMS.ServiceAccess
{
    public class InventoryIssueMasterAndIssueDetailsServiceAccess : IInventoryIssueMasterAndIssueDetailsServiceAccess
    {
        IInventoryIssueMasterAndIssueDetailsBA _inventoryIssueMasterAndIssueDetailsBA = null;

        public InventoryIssueMasterAndIssueDetailsServiceAccess()
        {
            _inventoryIssueMasterAndIssueDetailsBA = new InventoryIssueMasterAndIssueDetailsBA();
        }

        // InventoryIssueMaster Table Property.
        public IBaseEntityResponse<InventoryIssueMasterAndIssueDetails> InsertInventoryIssueMaster(InventoryIssueMasterAndIssueDetails item)
        {
            return _inventoryIssueMasterAndIssueDetailsBA.InsertInventoryIssueMaster(item);
        }
        public IBaseEntityResponse<InventoryIssueMasterAndIssueDetails> UpdateInventoryIssueMaster(InventoryIssueMasterAndIssueDetails item)
        {
            return _inventoryIssueMasterAndIssueDetailsBA.UpdateInventoryIssueMaster(item);
        }
        public IBaseEntityResponse<InventoryIssueMasterAndIssueDetails> DeleteInventoryIssueMaster(InventoryIssueMasterAndIssueDetails item)
        {
            return _inventoryIssueMasterAndIssueDetailsBA.DeleteInventoryIssueMaster(item);
        }
        public IBaseEntityCollectionResponse<InventoryIssueMasterAndIssueDetails> GetInventoryIssueMasterBySearch(InventoryIssueMasterAndIssueDetailsSearchRequest searchRequest)
        {
            return _inventoryIssueMasterAndIssueDetailsBA.GetInventoryIssueMasterBySearch(searchRequest);
        }
        public IBaseEntityCollectionResponse<InventoryIssueMasterAndIssueDetails> GetInventoryIssueMasterByID(InventoryIssueMasterAndIssueDetailsSearchRequest searchRequest)
        {
            return _inventoryIssueMasterAndIssueDetailsBA.GetInventoryIssueMasterByID(searchRequest);
        }


        //InventoryIssueMaster Search List
        public IBaseEntityCollectionResponse<InventoryIssueMasterAndIssueDetails> GetInventoryIssueMasterSearchList(InventoryIssueMasterAndIssueDetailsSearchRequest searchRequest)
        {
            return _inventoryIssueMasterAndIssueDetailsBA.GetInventoryIssueMasterSearchList(searchRequest);
        }


        // InventoryIssueDetails Table Property.
        public IBaseEntityResponse<InventoryIssueMasterAndIssueDetails> InsertInventoryIssueDetails(InventoryIssueMasterAndIssueDetails item)
        {
            return _inventoryIssueMasterAndIssueDetailsBA.InsertInventoryIssueDetails(item);
        }
        public IBaseEntityResponse<InventoryIssueMasterAndIssueDetails> UpdateInventoryIssueDetails(InventoryIssueMasterAndIssueDetails item)
        {
            return _inventoryIssueMasterAndIssueDetailsBA.UpdateInventoryIssueDetails(item);
        }
        public IBaseEntityResponse<InventoryIssueMasterAndIssueDetails> DeleteInventoryIssueDetails(InventoryIssueMasterAndIssueDetails item)
        {
            return _inventoryIssueMasterAndIssueDetailsBA.DeleteInventoryIssueDetails(item);
        }
        public IBaseEntityCollectionResponse<InventoryIssueMasterAndIssueDetails> GetInventoryIssueDetailsBySearch(InventoryIssueMasterAndIssueDetailsSearchRequest searchRequest)
        {
            return _inventoryIssueMasterAndIssueDetailsBA.GetInventoryIssueDetailsBySearch(searchRequest);
        }
        public IBaseEntityResponse<InventoryIssueMasterAndIssueDetails> GetInventoryIssueDetailsByID(InventoryIssueMasterAndIssueDetails item)
        {
            return _inventoryIssueMasterAndIssueDetailsBA.GetInventoryIssueDetailsByID(item);
        }


        //InventoryIssueDetails Search List
        public IBaseEntityCollectionResponse<InventoryIssueMasterAndIssueDetails> GetInventoryIssueDetailsSearchList(InventoryIssueMasterAndIssueDetailsSearchRequest searchRequest)
        {
            return _inventoryIssueMasterAndIssueDetailsBA.GetInventoryIssueDetailsSearchList(searchRequest);
        }

        //Inventory Issue for Location search.
        public IBaseEntityCollectionResponse<InventoryLocationMaster> GetInventoryIssueLocationMasterList(InventoryLocationMasterSearchRequest searchRequest)
        {
            return _inventoryIssueMasterAndIssueDetailsBA.GetInventoryIssueLocationMasterList(searchRequest);
        }
    }
}
