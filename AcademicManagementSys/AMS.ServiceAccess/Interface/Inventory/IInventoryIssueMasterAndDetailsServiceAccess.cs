using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.ServiceAccess
{
    public interface IInventoryIssueMasterAndDetailsServiceAccess
    {
        IBaseEntityResponse<InventoryIssueMasterAndDetails> InsertInventoryIssueMasterAndDetails(InventoryIssueMasterAndDetails item);
        IBaseEntityResponse<InventoryIssueMasterAndDetails> UpdateInventoryIssueMasterAndDetails(InventoryIssueMasterAndDetails item);
        IBaseEntityResponse<InventoryIssueMasterAndDetails> DeleteInventoryIssueMasterAndDetails(InventoryIssueMasterAndDetails item);
        IBaseEntityCollectionResponse<InventoryIssueMasterAndDetails> GetBySearch(InventoryIssueMasterAndDetailsSearchRequest searchRequest);
        IBaseEntityResponse<InventoryIssueMasterAndDetails> SelectByID(InventoryIssueMasterAndDetails item);
    }
}
