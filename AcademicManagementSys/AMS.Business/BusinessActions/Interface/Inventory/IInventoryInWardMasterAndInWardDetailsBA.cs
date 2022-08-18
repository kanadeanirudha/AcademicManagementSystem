using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Business.BusinessAction
{
    public interface IInventoryInWardMasterAndInWardDetailsBA
    {
        // InventoryInWardMaster Table Property.
        IBaseEntityResponse<InventoryInWardMasterAndInWardDetails> InsertInventoryInWardMaster(InventoryInWardMasterAndInWardDetails item);
        IBaseEntityResponse<InventoryInWardMasterAndInWardDetails> UpdateInventoryInWardMaster(InventoryInWardMasterAndInWardDetails item);
        IBaseEntityResponse<InventoryInWardMasterAndInWardDetails> DeleteInventoryInWardMaster(InventoryInWardMasterAndInWardDetails item);
        IBaseEntityCollectionResponse<InventoryInWardMasterAndInWardDetails> GetInventoryInWardMasterBySearch(InventoryInWardMasterAndInWardDetailsSearchRequest searchRequest);
        IBaseEntityResponse<InventoryInWardMasterAndInWardDetails> GetInventoryInWardMasterByID(InventoryInWardMasterAndInWardDetails item);
        IBaseEntityCollectionResponse<InventoryInWardMasterAndInWardDetails> GetInWardRequestForApproval(InventoryInWardMasterAndInWardDetailsSearchRequest searchRequest);

        //For Serach List InventoryInWardMaster
        IBaseEntityCollectionResponse<InventoryInWardMasterAndInWardDetails> GetInventoryInWardMasterSearchList(InventoryInWardMasterAndInWardDetailsSearchRequest searchRequest);


        // InventoryInWardDetails Table Property.
        IBaseEntityResponse<InventoryInWardMasterAndInWardDetails> InsertInventoryInWardDetails(InventoryInWardMasterAndInWardDetails item);
        IBaseEntityResponse<InventoryInWardMasterAndInWardDetails> UpdateInventoryInWardDetails(InventoryInWardMasterAndInWardDetails item);
        IBaseEntityResponse<InventoryInWardMasterAndInWardDetails> DeleteInventoryInWardDetails(InventoryInWardMasterAndInWardDetails item);
        IBaseEntityCollectionResponse<InventoryInWardMasterAndInWardDetails> GetInventoryInWardDetailsBySearch(InventoryInWardMasterAndInWardDetailsSearchRequest searchRequest);
        IBaseEntityResponse<InventoryInWardMasterAndInWardDetails> GetInventoryInWardDetailsByID(InventoryInWardMasterAndInWardDetails item);

        //For Serach List InventoryInWardDetails
        IBaseEntityCollectionResponse<InventoryInWardMasterAndInWardDetails> GetInventoryInWardDetailsSearchList(InventoryInWardMasterAndInWardDetailsSearchRequest searchRequest);

        //Laayer For InvSystemSettingMaster list
        IBaseEntityCollectionResponse<InventoryInWardMasterAndInWardDetails> GetInvSystemSetting(InventoryInWardMasterAndInWardDetailsSearchRequest searchRequest);
        //Laayer For Inv Sync History Count
        IBaseEntityResponse<InventoryInWardMasterAndInWardDetails> GetInvSyncHistoryCount(InventoryInWardMasterAndInWardDetails item);
    }
}
