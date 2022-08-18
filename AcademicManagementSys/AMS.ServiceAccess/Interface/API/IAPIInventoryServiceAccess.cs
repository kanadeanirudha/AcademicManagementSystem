using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.ServiceAccess
{
    public interface IAPIInventoryServiceAccess
    {
        IBaseEntityResponse<APIInventory> InventoryCounterLogin(APIInventory item);
        IBaseEntityResponse<APIInventory> PostOnline(APIInventory item);
        IBaseEntityResponse<APIInventory> SingleBillPostOnline(APIInventory item);
        IBaseEntityResponse<APIInventory> GetLocalInvoiceNo(APIInventory item);
        IBaseEntityCollectionResponse<APIInventory> InventoryGetOnline(APIInventorySearchRequest searchRequest);
        IBaseEntityResponse<APIInventory> PostSaleReturnOnline(APIInventory item);
    }
}
