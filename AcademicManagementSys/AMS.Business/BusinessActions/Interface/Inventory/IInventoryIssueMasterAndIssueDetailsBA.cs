using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Business.BusinessAction
{
    public interface IInventoryIssueMasterAndIssueDetailsBA
    {
        // InventoryIssueMaster Table Property.
        IBaseEntityResponse<InventoryIssueMasterAndIssueDetails> InsertInventoryIssueMaster(InventoryIssueMasterAndIssueDetails item);
        IBaseEntityResponse<InventoryIssueMasterAndIssueDetails> UpdateInventoryIssueMaster(InventoryIssueMasterAndIssueDetails item);
        IBaseEntityResponse<InventoryIssueMasterAndIssueDetails> DeleteInventoryIssueMaster(InventoryIssueMasterAndIssueDetails item);
        IBaseEntityCollectionResponse<InventoryIssueMasterAndIssueDetails> GetInventoryIssueMasterBySearch(InventoryIssueMasterAndIssueDetailsSearchRequest searchRequest);
        IBaseEntityCollectionResponse<InventoryIssueMasterAndIssueDetails> GetInventoryIssueMasterByID(InventoryIssueMasterAndIssueDetailsSearchRequest searchRequest);

        //For Serach List Entrance Exam Infrastructure Detail
        IBaseEntityCollectionResponse<InventoryIssueMasterAndIssueDetails> GetInventoryIssueMasterSearchList(InventoryIssueMasterAndIssueDetailsSearchRequest searchRequest);

        // InventoryIssueDetails Table Property.
        IBaseEntityResponse<InventoryIssueMasterAndIssueDetails> InsertInventoryIssueDetails(InventoryIssueMasterAndIssueDetails item);
        IBaseEntityResponse<InventoryIssueMasterAndIssueDetails> UpdateInventoryIssueDetails(InventoryIssueMasterAndIssueDetails item);
        IBaseEntityResponse<InventoryIssueMasterAndIssueDetails> DeleteInventoryIssueDetails(InventoryIssueMasterAndIssueDetails item);
        IBaseEntityCollectionResponse<InventoryIssueMasterAndIssueDetails> GetInventoryIssueDetailsBySearch(InventoryIssueMasterAndIssueDetailsSearchRequest searchRequest);
        IBaseEntityResponse<InventoryIssueMasterAndIssueDetails> GetInventoryIssueDetailsByID(InventoryIssueMasterAndIssueDetails item);

        //InventoryIssueDetails Serach List
        IBaseEntityCollectionResponse<InventoryIssueMasterAndIssueDetails> GetInventoryIssueDetailsSearchList(InventoryIssueMasterAndIssueDetailsSearchRequest searchRequest);

        //Issue location list.
        IBaseEntityCollectionResponse<InventoryLocationMaster> GetInventoryIssueLocationMasterList(InventoryLocationMasterSearchRequest searchRequest);
    }
}
