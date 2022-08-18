using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.DataProvider
{
    public interface IInventoryOpeningBalanceDataProvider
    {
        IBaseEntityResponse<InventoryOpeningBalance> InsertInventoryOpeningBalance(InventoryOpeningBalance item);
        IBaseEntityResponse<InventoryOpeningBalance> UpdateInventoryOpeningBalance(InventoryOpeningBalance item);
        IBaseEntityResponse<InventoryOpeningBalance> DeleteInventoryOpeningBalance(InventoryOpeningBalance item);
        IBaseEntityCollectionResponse<InventoryOpeningBalance> GetInventoryOpeningBalanceBySearch(InventoryOpeningBalanceSearchRequest searchRequest);
        IBaseEntityCollectionResponse<InventoryOpeningBalance> GetInventoryOpeningBalanceList(InventoryOpeningBalanceSearchRequest searchRequest);
        IBaseEntityResponse<InventoryOpeningBalance> GetInventoryOpeningBalanceByID(InventoryOpeningBalance item);
    }
}
