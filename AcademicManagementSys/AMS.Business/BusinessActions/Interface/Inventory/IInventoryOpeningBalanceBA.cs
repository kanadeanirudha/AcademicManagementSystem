using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Business.BusinessActions
{
    public interface IInventoryOpeningBalanceBA
    {
        IBaseEntityResponse<InventoryOpeningBalance> InsertInventoryOpeningBalance(InventoryOpeningBalance item);
        IBaseEntityResponse<InventoryOpeningBalance> UpdateInventoryOpeningBalance(InventoryOpeningBalance item);
        IBaseEntityResponse<InventoryOpeningBalance> DeleteInventoryOpeningBalance(InventoryOpeningBalance item);
        IBaseEntityCollectionResponse<InventoryOpeningBalance> GetBySearch(InventoryOpeningBalanceSearchRequest searchRequest);
        IBaseEntityCollectionResponse<InventoryOpeningBalance> GetInventoryOpeningBalanceList(InventoryOpeningBalanceSearchRequest searchRequest);
        IBaseEntityResponse<InventoryOpeningBalance> SelectByID(InventoryOpeningBalance item);
    }
}
