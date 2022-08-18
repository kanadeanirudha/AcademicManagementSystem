using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.DataProvider
{
    public interface IInventoryInWardMasterAndInWardDetailsDataProvider
    {
        // InventoryInWardMaster Method
        IBaseEntityResponse<InventoryInWardMasterAndInWardDetails> InsertInventoryInWardMaster(InventoryInWardMasterAndInWardDetails item);
        IBaseEntityResponse<InventoryInWardMasterAndInWardDetails> UpdateInventoryInWardMaster(InventoryInWardMasterAndInWardDetails item);
        IBaseEntityResponse<InventoryInWardMasterAndInWardDetails> DeleteInventoryInWardMaster(InventoryInWardMasterAndInWardDetails item);
        IBaseEntityCollectionResponse<InventoryInWardMasterAndInWardDetails> GetInventoryInWardMasterBySearch(InventoryInWardMasterAndInWardDetailsSearchRequest searchRequest);
        IBaseEntityResponse<InventoryInWardMasterAndInWardDetails> GetInventoryInWardMasterByID(InventoryInWardMasterAndInWardDetails item);
        IBaseEntityCollectionResponse<InventoryInWardMasterAndInWardDetails> GetInWardRequestForApproval(InventoryInWardMasterAndInWardDetailsSearchRequest searchRequest);

        //Search InventoryInWardMaster List
        IBaseEntityCollectionResponse<InventoryInWardMasterAndInWardDetails> GetInventoryInWardMasterSearchList(InventoryInWardMasterAndInWardDetailsSearchRequest searchRequest);

        // InventoryInWardDetails Method
        IBaseEntityResponse<InventoryInWardMasterAndInWardDetails> InsertInventoryInWardDetails(InventoryInWardMasterAndInWardDetails item);
        IBaseEntityResponse<InventoryInWardMasterAndInWardDetails> UpdateInventoryInWardDetails(InventoryInWardMasterAndInWardDetails item);
        IBaseEntityResponse<InventoryInWardMasterAndInWardDetails> DeleteInventoryInWardDetails(InventoryInWardMasterAndInWardDetails item);
        IBaseEntityCollectionResponse<InventoryInWardMasterAndInWardDetails> GetInventoryInWardDetailsBySearch(InventoryInWardMasterAndInWardDetailsSearchRequest searchRequest);
        IBaseEntityResponse<InventoryInWardMasterAndInWardDetails> GetInventoryInWardDetailsByID(InventoryInWardMasterAndInWardDetails item);

        //Search InventoryInWardDetails List
        IBaseEntityCollectionResponse<InventoryInWardMasterAndInWardDetails> GetInventoryInWardDetailsSearchList(InventoryInWardMasterAndInWardDetailsSearchRequest searchRequest);

        //Laayer For InvSystemSettingMaster list
        IBaseEntityCollectionResponse<InventoryInWardMasterAndInWardDetails> GetInvSystemSetting(InventoryInWardMasterAndInWardDetailsSearchRequest searchRequest);

        //Laayer For InvSystemSettingMaster list
        IBaseEntityResponse<InventoryInWardMasterAndInWardDetails> GetInvSyncHistoryCount(InventoryInWardMasterAndInWardDetails item);

    }
}
