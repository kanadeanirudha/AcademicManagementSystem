
using AMS.Base.DTO;
using AMS.Business.BusinessActions;
using AMS.DTO;

namespace AMS.ServiceAccess
{
    public class PurchaseReturnServiceAccess : IPurchaseReturnServiceAccess
    {
        IPurchaseReturnBA _PurchaseReturnBA = null;
        public PurchaseReturnServiceAccess()
        {
            _PurchaseReturnBA = new PurchaseReturnBA();
        }
        public IBaseEntityResponse<PurchaseReturn> InsertPurchaseReturn(PurchaseReturn item)
        {
            return _PurchaseReturnBA.InsertPurchaseReturn(item);
        }
        public IBaseEntityResponse<PurchaseReturn> UpdatePurchaseReturn(PurchaseReturn item)
        {
            return _PurchaseReturnBA.UpdatePurchaseReturn(item);
        }
        public IBaseEntityResponse<PurchaseReturn> DeletePurchaseReturn(PurchaseReturn item)
        {
            return _PurchaseReturnBA.DeletePurchaseReturn(item);
        }
        public IBaseEntityCollectionResponse<PurchaseReturn> GetBySearch(PurchaseReturnSearchRequest searchRequest)
        {
            return _PurchaseReturnBA.GetBySearch(searchRequest);
        }
        public IBaseEntityCollectionResponse<PurchaseReturn> GetVendorSearchList(PurchaseReturnSearchRequest searchRequest)
        {
            return _PurchaseReturnBA.GetVendorSearchList(searchRequest);
        }
        public IBaseEntityCollectionResponse<PurchaseReturn> GetPurchaseReturnDetailLists(PurchaseReturnSearchRequest searchRequest)
        {
            return _PurchaseReturnBA.GetPurchaseReturnDetailLists(searchRequest);
        }
        public IBaseEntityResponse<PurchaseReturn> SelectByID(PurchaseReturn item)
        {
            return _PurchaseReturnBA.SelectByID(item);
        }
        public IBaseEntityCollectionResponse<PurchaseReturn> GetUomWisePurchasePrice(PurchaseReturnSearchRequest searchRequest)
        {
            return _PurchaseReturnBA.GetUomWisePurchasePrice(searchRequest);
        }
    }
}
