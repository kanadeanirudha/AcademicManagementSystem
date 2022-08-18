using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.ServiceAccess
{
    public interface IInventoryOpeningBalanceServiceAccess
    {
        IBaseEntityResponse<InventoryOpeningBalance> InsertInventoryOpeningBalance(InventoryOpeningBalance item);
        IBaseEntityResponse<InventoryOpeningBalance> UpdateInventoryOpeningBalance(InventoryOpeningBalance item);
        IBaseEntityResponse<InventoryOpeningBalance> DeleteInventoryOpeningBalance(InventoryOpeningBalance item);
        IBaseEntityCollectionResponse<InventoryOpeningBalance> GetBySearch(InventoryOpeningBalanceSearchRequest searchRequest);
        IBaseEntityResponse<InventoryOpeningBalance> SelectByID(InventoryOpeningBalance item);
        IBaseEntityCollectionResponse<InventoryOpeningBalance> GetInventoryOpeningBalanceList(InventoryOpeningBalanceSearchRequest searchRequest);
    }
}
