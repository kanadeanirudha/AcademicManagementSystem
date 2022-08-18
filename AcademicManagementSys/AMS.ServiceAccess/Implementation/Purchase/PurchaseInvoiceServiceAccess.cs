using AMS.Base.DTO;
using AMS.Business.BusinessAction;
using AMS.DTO;
namespace AMS.ServiceAccess
{
    public class PurchaseInvoiceServiceAccess : IPurchaseInvoiceServiceAccess
    {
        IPurchaseInvoiceBA _PurchaseInvoiceBA = null;
        public PurchaseInvoiceServiceAccess()
        {
            _PurchaseInvoiceBA = new PurchaseInvoiceBA();
        }
        public IBaseEntityResponse<PurchaseInvoice> InsertPurchaseInvoice(PurchaseInvoice item)
        {
            return _PurchaseInvoiceBA.InsertPurchaseInvoice(item);
        }
        public IBaseEntityResponse<PurchaseInvoice> UpdatePurchaseInvoice(PurchaseInvoice item)
        {
            return _PurchaseInvoiceBA.UpdatePurchaseInvoice(item);
        }
        public IBaseEntityResponse<PurchaseInvoice> DeletePurchaseInvoice(PurchaseInvoice item)
        {
            return _PurchaseInvoiceBA.DeletePurchaseInvoice(item);
        }
        public IBaseEntityCollectionResponse<PurchaseInvoice> GetBySearch(PurchaseInvoiceSearchRequest searchRequest)
        {
            return _PurchaseInvoiceBA.GetBySearch(searchRequest);
        }
        public IBaseEntityResponse<PurchaseInvoice> SelectByID(PurchaseInvoice item)
        {
            return _PurchaseInvoiceBA.SelectByID(item);
        }
        public IBaseEntityCollectionResponse<PurchaseInvoice> SelectByPurchaseGRNMasterID(PurchaseInvoiceSearchRequest searchRequest)
        {
            return _PurchaseInvoiceBA.SelectByPurchaseGRNMasterID(searchRequest);
        }
        public IBaseEntityCollectionResponse<PurchaseInvoice> GetRecordForPurchaseOrderPDF(PurchaseInvoiceSearchRequest searchRequest)
        {
            return _PurchaseInvoiceBA.GetRecordForPurchaseOrderPDF(searchRequest);
        }
    }
}
