using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.ServiceAccess
{
    public interface IPurchaseInvoiceServiceAccess
    {
        IBaseEntityResponse<PurchaseInvoice> InsertPurchaseInvoice(PurchaseInvoice item);
        IBaseEntityResponse<PurchaseInvoice> UpdatePurchaseInvoice(PurchaseInvoice item);
        IBaseEntityResponse<PurchaseInvoice> DeletePurchaseInvoice(PurchaseInvoice item);
        IBaseEntityCollectionResponse<PurchaseInvoice> GetBySearch(PurchaseInvoiceSearchRequest searchRequest);
        IBaseEntityResponse<PurchaseInvoice> SelectByID(PurchaseInvoice item);
        IBaseEntityCollectionResponse<PurchaseInvoice> SelectByPurchaseGRNMasterID(PurchaseInvoiceSearchRequest searchRequest);
        IBaseEntityCollectionResponse<PurchaseInvoice> GetRecordForPurchaseOrderPDF(PurchaseInvoiceSearchRequest searchRequest);
    }
}
