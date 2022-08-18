
using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.DataProvider
{
    public interface IPurchaseReturnDataProvider
    {
        IBaseEntityResponse<PurchaseReturn> InsertPurchaseReturn(PurchaseReturn item);
        IBaseEntityResponse<PurchaseReturn> UpdatePurchaseReturn(PurchaseReturn item);
        IBaseEntityResponse<PurchaseReturn> DeletePurchaseReturn(PurchaseReturn item);
        IBaseEntityCollectionResponse<PurchaseReturn> GetBySearch(PurchaseReturnSearchRequest searchRequest);
        IBaseEntityCollectionResponse<PurchaseReturn> GetVendorSearchList(PurchaseReturnSearchRequest searchRequest);
        IBaseEntityCollectionResponse<PurchaseReturn> GetPurchaseReturnDetailLists(PurchaseReturnSearchRequest searchRequest);
        IBaseEntityResponse<PurchaseReturn> SelectByID(PurchaseReturn item);
        IBaseEntityCollectionResponse<PurchaseReturn> GetUomWisePurchasePrice(PurchaseReturnSearchRequest searchRequest);
        
    }
}
