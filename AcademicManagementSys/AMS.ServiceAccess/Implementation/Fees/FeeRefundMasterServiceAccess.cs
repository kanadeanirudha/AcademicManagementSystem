using AMS.Base.DTO;
using AMS.Business.BusinessActions;
using AMS.DTO;
namespace AMS.ServiceAccess
{
    public class FeeRefundMasterServiceAccess : IFeeRefundMasterServiceAccess
    {
        IFeeRefundMasterBA _FeeRefundMasterBA = null;
        public FeeRefundMasterServiceAccess()
        {
            _FeeRefundMasterBA = new FeeRefundMasterBA();
        }
        public IBaseEntityResponse<FeeRefundMaster> InsertFeeRefundMaster(FeeRefundMaster item)
        {
            return _FeeRefundMasterBA.InsertFeeRefundMaster(item);
        }
        public IBaseEntityResponse<FeeRefundMaster> UpdateFeeRefundMaster(FeeRefundMaster item)
        {
            return _FeeRefundMasterBA.UpdateFeeRefundMaster(item);
        }
        public IBaseEntityCollectionResponse<FeeRefundMaster> GetBySearch(FeeRefundMasterSearchRequest searchRequest)
        {
            return _FeeRefundMasterBA.GetBySearch(searchRequest);
        }
        public IBaseEntityCollectionResponse<FeeRefundMaster> GetAccountListForFeeRefund(FeeRefundMasterSearchRequest searchRequest)
        {
            return _FeeRefundMasterBA.GetAccountListForFeeRefund(searchRequest);
        }
        public IBaseEntityResponse<FeeRefundMaster> SelectByID(FeeRefundMaster item)
        {
            return _FeeRefundMasterBA.SelectByID(item);
        }
        public IBaseEntityCollectionResponse<FeeRefundMaster> GetStudentPaymentDetails(FeeRefundMasterSearchRequest searchRequest)
        {
            return _FeeRefundMasterBA.GetStudentPaymentDetails(searchRequest);
        }
        public IBaseEntityCollectionResponse<FeeRefundMaster> GetStudentDetailsForFeeReceipt(FeeRefundMasterSearchRequest searchRequest)
        {
            return _FeeRefundMasterBA.GetStudentDetailsForFeeReceipt(searchRequest);
        }
    }
}
