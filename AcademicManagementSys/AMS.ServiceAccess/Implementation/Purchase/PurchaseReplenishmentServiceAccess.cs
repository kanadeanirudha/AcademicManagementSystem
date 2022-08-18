using AMS.Base.DTO;
using AMS.Business.BusinessAction;
using AMS.DTO;
namespace AMS.ServiceAccess
{
    public class PurchaseReplenishmentServiceAccess : IPurchaseReplenishmentServiceAccess
    {
        IPurchaseReplenishmentBA _PurchaseReplenishmentBA = null;
        public PurchaseReplenishmentServiceAccess()
        {
            _PurchaseReplenishmentBA = new PurchaseReplenishmentBA();
        }
        public IBaseEntityResponse<PurchaseReplenishment> InsertPurchaseReplenishment(PurchaseReplenishment item)
        {
            return _PurchaseReplenishmentBA.InsertPurchaseReplenishment(item);
        }
        public IBaseEntityResponse<PurchaseReplenishment> UpdatePurchaseReplenishment(PurchaseReplenishment item)
        {
            return _PurchaseReplenishmentBA.UpdatePurchaseReplenishment(item);
        }
        public IBaseEntityResponse<PurchaseReplenishment> DeletePurchaseReplenishment(PurchaseReplenishment item)
        {
            return _PurchaseReplenishmentBA.DeletePurchaseReplenishment(item);
        }
        public IBaseEntityCollectionResponse<PurchaseReplenishment> GetBySearch(PurchaseReplenishmentSearchRequest searchRequest)
        {
            return _PurchaseReplenishmentBA.GetBySearch(searchRequest);
        }
        public IBaseEntityResponse<PurchaseReplenishment> SelectByID(PurchaseReplenishment item)
        {
            return _PurchaseReplenishmentBA.SelectByID(item);
        }
        public IBaseEntityCollectionResponse<PurchaseReplenishment> SelectByPurchaseGRNMasterID(PurchaseReplenishmentSearchRequest searchRequest)
        {
            return _PurchaseReplenishmentBA.SelectByPurchaseGRNMasterID(searchRequest);
        }
        public IBaseEntityCollectionResponse<PurchaseReplenishment> GetRecordForPurchaseOrderPDF(PurchaseReplenishmentSearchRequest searchRequest)
        {
            return _PurchaseReplenishmentBA.GetRecordForPurchaseOrderPDF(searchRequest);
        }
    }
}
