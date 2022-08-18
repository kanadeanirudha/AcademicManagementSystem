using AMS.Base.DTO;
using AMS.Business.BusinessActions;
using AMS.DTO;
namespace AMS.ServiceAccess
{
    public class FeeReceiptMasterServiceAccess : IFeeReceiptMasterServiceAccess
    {
        IFeeReceiptMasterBA _FeeReceiptMasterBA = null;
        public FeeReceiptMasterServiceAccess()
        {
            _FeeReceiptMasterBA = new FeeReceiptMasterBA();
        }
        public IBaseEntityResponse<FeeReceiptMaster> InsertFeeReceiptMaster(FeeReceiptMaster item)
        {
            return _FeeReceiptMasterBA.InsertFeeReceiptMaster(item);
        }
        public IBaseEntityResponse<FeeReceiptMaster> UpdateFeeReceiptMaster(FeeReceiptMaster item)
        {
            return _FeeReceiptMasterBA.UpdateFeeReceiptMaster(item);
        }
        public IBaseEntityCollectionResponse<FeeReceiptMaster> GetBySearch(FeeReceiptMasterSearchRequest searchRequest)
        {
            return _FeeReceiptMasterBA.GetBySearch(searchRequest);
        }
        public IBaseEntityCollectionResponse<FeeReceiptMaster> GetAccountListForFeeReceipt(FeeReceiptMasterSearchRequest searchRequest)
        {
            return _FeeReceiptMasterBA.GetAccountListForFeeReceipt(searchRequest);
        }
        public IBaseEntityResponse<FeeReceiptMaster> SelectByID(FeeReceiptMaster item)
        {
            return _FeeReceiptMasterBA.SelectByID(item);
        }
        public IBaseEntityCollectionResponse<FeeReceiptMaster> GetStudentPaymentDetails(FeeReceiptMasterSearchRequest searchRequest)
        {
            return _FeeReceiptMasterBA.GetStudentPaymentDetails(searchRequest);
        }
        public IBaseEntityCollectionResponse<FeeReceiptMaster> GetStudentDetailsForFeeReceipt(FeeReceiptMasterSearchRequest searchRequest)
        {
            return _FeeReceiptMasterBA.GetStudentDetailsForFeeReceipt(searchRequest);
        }
    }
}
