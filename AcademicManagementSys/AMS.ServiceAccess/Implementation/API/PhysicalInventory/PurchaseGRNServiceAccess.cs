using AMS.Base.DTO;
using AMS.Business.BusinessAction;
using AMS.DTO;

namespace AMS.ServiceAccess
{
    public class PurchaseGRNServiceAccess : IPurchaseGRNServiceAccess
    {
        IPurchaseGRNBA _PurchaseGRNBA = null;

        public PurchaseGRNServiceAccess()
        {
            _PurchaseGRNBA = new PurchaseGRNBA();
        }

        public IBaseEntityResponse<PurchaseGRN> PostPurchaseGRN(PurchaseGRN item)
        {
            return _PurchaseGRNBA.PostPurchaseGRN(item);
        }
        public IBaseEntityCollectionResponse<PurchaseGRN> GetPurchaseGRNVendorList(PurchaseGRNSearchRequest searchRequest)
        {
            return _PurchaseGRNBA.GetPurchaseGRNVendorList(searchRequest);
        }
        public IBaseEntityCollectionResponse<PurchaseGRN> GetPurchaseGRNPOList(PurchaseGRNSearchRequest searchRequest)
        {
            return _PurchaseGRNBA.GetPurchaseGRNPOList(searchRequest);
        }
        public IBaseEntityCollectionResponse<PurchaseGRN> GetPurchaseGRNBatchList(PurchaseGRNSearchRequest searchRequest)
        {
            return _PurchaseGRNBA.GetPurchaseGRNBatchList(searchRequest);
        }
        public IBaseEntityCollectionResponse<PurchaseGRN> GetPurchaseOrderItemList(PurchaseGRNSearchRequest searchRequest)
        {
            return _PurchaseGRNBA.GetPurchaseOrderItemList(searchRequest);
        }
        public IBaseEntityCollectionResponse<PurchaseGRN> GetPOList(PurchaseGRNSearchRequest searchRequest)
        {
            return _PurchaseGRNBA.GetPOList(searchRequest);
        }
        public IBaseEntityCollectionResponse<PurchaseGRN> GetGRNList(PurchaseGRNSearchRequest searchRequest)
        {
            return _PurchaseGRNBA.GetGRNList(searchRequest);
        }
        public IBaseEntityCollectionResponse<PurchaseGRN> GetPurchaseGRNView(PurchaseGRNSearchRequest searchRequest)
        {
            return _PurchaseGRNBA.GetPurchaseGRNView(searchRequest);
        }
    }
}
