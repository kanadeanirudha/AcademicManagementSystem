using AMS.Base.DTO;
using AMS.DTO;

namespace AMS.ServiceAccess
{
    public interface IPurchaseGRNServiceAccess
    {
        IBaseEntityResponse<PurchaseGRN> PostPurchaseGRN(PurchaseGRN item);
        IBaseEntityCollectionResponse<PurchaseGRN> GetPurchaseGRNVendorList(PurchaseGRNSearchRequest searchRequest);
        IBaseEntityCollectionResponse<PurchaseGRN> GetPurchaseGRNPOList(PurchaseGRNSearchRequest searchRequest);
        IBaseEntityCollectionResponse<PurchaseGRN> GetPurchaseGRNBatchList(PurchaseGRNSearchRequest searchRequest);
        IBaseEntityCollectionResponse<PurchaseGRN> GetPurchaseOrderItemList(PurchaseGRNSearchRequest searchRequest);
        IBaseEntityCollectionResponse<PurchaseGRN> GetPOList(PurchaseGRNSearchRequest searchRequest);
        IBaseEntityCollectionResponse<PurchaseGRN> GetGRNList(PurchaseGRNSearchRequest searchRequest);
        IBaseEntityCollectionResponse<PurchaseGRN> GetPurchaseGRNView(PurchaseGRNSearchRequest searchRequest);
    }
}
