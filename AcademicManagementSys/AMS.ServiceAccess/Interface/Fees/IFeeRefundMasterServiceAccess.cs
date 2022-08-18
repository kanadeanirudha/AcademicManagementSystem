using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.ServiceAccess
{
    public interface IFeeRefundMasterServiceAccess
    {
        IBaseEntityResponse<FeeRefundMaster> InsertFeeRefundMaster(FeeRefundMaster item);
        IBaseEntityResponse<FeeRefundMaster> UpdateFeeRefundMaster(FeeRefundMaster item);
        IBaseEntityCollectionResponse<FeeRefundMaster> GetBySearch(FeeRefundMasterSearchRequest searchRequest);
        IBaseEntityCollectionResponse<FeeRefundMaster> GetAccountListForFeeRefund(FeeRefundMasterSearchRequest searchRequest);
        IBaseEntityResponse<FeeRefundMaster> SelectByID(FeeRefundMaster item);
        IBaseEntityCollectionResponse<FeeRefundMaster> GetStudentPaymentDetails(FeeRefundMasterSearchRequest searchRequest);
        IBaseEntityCollectionResponse<FeeRefundMaster> GetStudentDetailsForFeeReceipt(FeeRefundMasterSearchRequest searchRequest);
    }
}
