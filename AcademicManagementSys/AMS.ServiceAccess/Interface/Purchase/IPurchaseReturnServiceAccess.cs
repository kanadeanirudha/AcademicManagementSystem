using AMS.Base.DTO;
using AMS.DTO;
namespace AMS.ServiceAccess
{
    public interface IPurchaseReturnServiceAccess
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
