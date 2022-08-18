using AMS.Base.DTO;
using AMS.Business.BusinessAction;
using AMS.DTO;
namespace AMS.ServiceAccess
{
    public class PurchaseOrderMasterAndDetailsServiceAccess : IPurchaseOrderMasterAndDetailsServiceAccess
    {
        IPurchaseOrderMasterAndDetailsBA _PurchaseOrderMasterAndDetailsBA = null;
        public PurchaseOrderMasterAndDetailsServiceAccess()
        {
            _PurchaseOrderMasterAndDetailsBA = new PurchaseOrderMasterAndDetailsBA();
        }
        public IBaseEntityResponse<PurchaseOrderMasterAndDetails> InsertPurchaseOrderMasterAndDetails(PurchaseOrderMasterAndDetails item)
        {
            return _PurchaseOrderMasterAndDetailsBA.InsertPurchaseOrderMasterAndDetails(item);
        }
        public IBaseEntityResponse<PurchaseOrderMasterAndDetails> UpdatePurchaseOrderMasterAndDetails(PurchaseOrderMasterAndDetails item)
        {
            return _PurchaseOrderMasterAndDetailsBA.UpdatePurchaseOrderMasterAndDetails(item);
        }
        public IBaseEntityResponse<PurchaseOrderMasterAndDetails> DeletePurchaseOrderMasterAndDetails(PurchaseOrderMasterAndDetails item)
        {
            return _PurchaseOrderMasterAndDetailsBA.DeletePurchaseOrderMasterAndDetails(item);
        }
        public IBaseEntityCollectionResponse<PurchaseOrderMasterAndDetails> GetBySearch(PurchaseOrderMasterAndDetailsSearchRequest searchRequest)
        {
            return _PurchaseOrderMasterAndDetailsBA.GetBySearch(searchRequest);
        }
        public IBaseEntityResponse<PurchaseOrderMasterAndDetails> SelectByID(PurchaseOrderMasterAndDetails item)
        {
            return _PurchaseOrderMasterAndDetailsBA.SelectByID(item);
        }
        public IBaseEntityCollectionResponse<PurchaseOrderMasterAndDetails> SelectByPurchaseRequisitionMasterID(PurchaseOrderMasterAndDetailsSearchRequest searchRequest)
        {
            return _PurchaseOrderMasterAndDetailsBA.SelectByPurchaseRequisitionMasterID(searchRequest);
        }
        public IBaseEntityCollectionResponse<PurchaseOrderMasterAndDetails> GetRecordForPurchaseOrderPDF(PurchaseOrderMasterAndDetailsSearchRequest searchRequest)
        {
            return _PurchaseOrderMasterAndDetailsBA.GetRecordForPurchaseOrderPDF(searchRequest);
        }
        public IBaseEntityCollectionResponse<PurchaseOrderMasterAndDetails> GetPurchaseOrderForApproval(PurchaseOrderMasterAndDetailsSearchRequest searchRequest)
        {
            return _PurchaseOrderMasterAndDetailsBA.GetPurchaseOrderForApproval(searchRequest);
        }
        public IBaseEntityResponse<PurchaseOrderMasterAndDetails> InsertApprovedPurchaseOrderRecord(PurchaseOrderMasterAndDetails item)
        {
            return _PurchaseOrderMasterAndDetailsBA.InsertApprovedPurchaseOrderRecord(item);
        }
            
    }
}
