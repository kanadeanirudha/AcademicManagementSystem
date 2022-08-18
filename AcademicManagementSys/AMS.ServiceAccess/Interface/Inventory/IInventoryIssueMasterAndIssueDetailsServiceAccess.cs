using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.ServiceAccess
{
    public interface IInventoryIssueMasterAndIssueDetailsServiceAccess
    {
        // InventoryIssueMaster Table Property.
        IBaseEntityResponse<InventoryIssueMasterAndIssueDetails> InsertInventoryIssueMaster(InventoryIssueMasterAndIssueDetails item);
        IBaseEntityResponse<InventoryIssueMasterAndIssueDetails> UpdateInventoryIssueMaster(InventoryIssueMasterAndIssueDetails item);
        IBaseEntityResponse<InventoryIssueMasterAndIssueDetails> DeleteInventoryIssueMaster(InventoryIssueMasterAndIssueDetails item);
        IBaseEntityCollectionResponse<InventoryIssueMasterAndIssueDetails> GetInventoryIssueMasterBySearch(InventoryIssueMasterAndIssueDetailsSearchRequest searchRequest);
        IBaseEntityCollectionResponse<InventoryIssueMasterAndIssueDetails> GetInventoryIssueMasterByID(InventoryIssueMasterAndIssueDetailsSearchRequest searchRequest);

        //InventoryIssueMaster Search List.
        IBaseEntityCollectionResponse<InventoryIssueMasterAndIssueDetails> GetInventoryIssueMasterSearchList(InventoryIssueMasterAndIssueDetailsSearchRequest searchRequest);

        // InventoryIssueDetails Table Property.
        IBaseEntityResponse<InventoryIssueMasterAndIssueDetails> InsertInventoryIssueDetails(InventoryIssueMasterAndIssueDetails item);
        IBaseEntityResponse<InventoryIssueMasterAndIssueDetails> UpdateInventoryIssueDetails(InventoryIssueMasterAndIssueDetails item);
        IBaseEntityResponse<InventoryIssueMasterAndIssueDetails> DeleteInventoryIssueDetails(InventoryIssueMasterAndIssueDetails item);
        IBaseEntityCollectionResponse<InventoryIssueMasterAndIssueDetails> GetInventoryIssueDetailsBySearch(InventoryIssueMasterAndIssueDetailsSearchRequest searchRequest);
        IBaseEntityResponse<InventoryIssueMasterAndIssueDetails> GetInventoryIssueDetailsByID(InventoryIssueMasterAndIssueDetails item);

        //InventoryIssueDetails Search List.
        IBaseEntityCollectionResponse<InventoryIssueMasterAndIssueDetails> GetInventoryIssueDetailsSearchList(InventoryIssueMasterAndIssueDetailsSearchRequest searchRequest);

        //Inventory Issue for Location search.
        IBaseEntityCollectionResponse<InventoryLocationMaster> GetInventoryIssueLocationMasterList(InventoryLocationMasterSearchRequest searchRequest);
    }
}
