using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.DataProvider
{
    public interface IAPIInventoryDataProvider
    {
        IBaseEntityResponse<APIInventory> InventoryCounterLogin(APIInventory item);
        IBaseEntityResponse<APIInventory> PostOnline(APIInventory item);
        IBaseEntityResponse<APIInventory> SingleBillPostOnline(APIInventory item);
        IBaseEntityResponse<APIInventory> GetLocalInvoiceNo(APIInventory item);
        IBaseEntityCollectionResponse<APIInventory> InventoryGetOnline(APIInventorySearchRequest searchRequest);
        IBaseEntityResponse<APIInventory> PostSaleReturnOnline(APIInventory item);
    }
}
