using AMS.Base.DTO;
using AMS.DTO;
using AMS.Business;
using AMS.Business.BusinessActions;
namespace AMS.ServiceAccess
{
    public class CRMSaleBillingTransactionServiceAccess : ICRMSaleBillingTransactionServiceAccess
    {
        ICRMSaleBillingTransactionBA cRMSaleBillingTransactionBA = null;

        public CRMSaleBillingTransactionServiceAccess()
        {
            cRMSaleBillingTransactionBA = new CRMSaleBillingTransactionBA();
        }

        //CRMSaleBillingTransaction
        public IBaseEntityResponse<CRMSaleBillingTransaction> InsertCRMSaleBillingTransaction(CRMSaleBillingTransaction item)
        {
            return cRMSaleBillingTransactionBA.InsertCRMSaleBillingTransaction(item);
        }

        public IBaseEntityResponse<CRMSaleBillingTransaction> UpdateCRMSaleBillingTransaction(CRMSaleBillingTransaction item)
        {
            return cRMSaleBillingTransactionBA.UpdateCRMSaleBillingTransaction(item);
        }

        public IBaseEntityResponse<CRMSaleBillingTransaction> DeleteCRMSaleBillingTransaction(CRMSaleBillingTransaction item)
        {
            return cRMSaleBillingTransactionBA.DeleteCRMSaleBillingTransaction(item);
        }

        public IBaseEntityCollectionResponse<CRMSaleBillingTransaction> GetCRMSaleBillingTransactionSelectAll(CRMSaleBillingTransactionSearchRequest searchRequest)
        {
            return cRMSaleBillingTransactionBA.GetCRMSaleBillingTransactionSelectAll(searchRequest);
        }

        public IBaseEntityResponse<CRMSaleBillingTransaction> SelectByCRMSaleBillingTransactionID(CRMSaleBillingTransaction item)
        {
            return cRMSaleBillingTransactionBA.SelectByCRMSaleBillingTransactionID(item);
        }
    }
}
