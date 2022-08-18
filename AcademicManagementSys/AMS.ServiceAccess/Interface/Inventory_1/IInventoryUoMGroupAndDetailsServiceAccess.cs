using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.ServiceAccess
{
    public interface IInventoryUoMGroupAndDetailsServiceAccess
    {
        //For Inventory UoM Group
        IBaseEntityResponse<InventoryUoMGroupAndDetails> InsertInventoryUoMGroup(InventoryUoMGroupAndDetails item);
        IBaseEntityResponse<InventoryUoMGroupAndDetails> UpdateInventoryUoMGroup(InventoryUoMGroupAndDetails item);
        IBaseEntityResponse<InventoryUoMGroupAndDetails> DeleteInventoryUoMGroup(InventoryUoMGroupAndDetails item);
        IBaseEntityCollectionResponse<InventoryUoMGroupAndDetails> SelectByInventoryUoMGroupID(InventoryUoMGroupAndDetailsSearchRequest searchRequest);

        //For Inventory UoM Group Details
        IBaseEntityResponse<InventoryUoMGroupAndDetails> InsertInventoryUoMGroupAndDetails(InventoryUoMGroupAndDetails item);
        IBaseEntityResponse<InventoryUoMGroupAndDetails> UpdateInventoryUoMGroupAndDetails(InventoryUoMGroupAndDetails item);
        IBaseEntityResponse<InventoryUoMGroupAndDetails> DeleteInventoryUoMGroupAndDetails(InventoryUoMGroupAndDetails item);
        IBaseEntityCollectionResponse<InventoryUoMGroupAndDetails> GetBySearch(InventoryUoMGroupAndDetailsSearchRequest searchRequest);
        IBaseEntityResponse<InventoryUoMGroupAndDetails> SelectByID(InventoryUoMGroupAndDetails item);
        IBaseEntityCollectionResponse<InventoryUoMGroupAndDetails> GetInventoryUoMGroupAndDetailsSearchList(InventoryUoMGroupAndDetailsSearchRequest searchRequest);

        IBaseEntityCollectionResponse<InventoryUoMGroupAndDetails> GetInventoryUomCodeByUomGroupCode(InventoryUoMGroupAndDetailsSearchRequest searchRequest);
    }
}
