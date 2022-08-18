using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.Business.BusinessActions
{
    public interface IFeeReceiptMasterBA
    {
        IBaseEntityResponse<FeeReceiptMaster> InsertFeeReceiptMaster(FeeReceiptMaster item);
        IBaseEntityResponse<FeeReceiptMaster> UpdateFeeReceiptMaster(FeeReceiptMaster item);
        IBaseEntityCollectionResponse<FeeReceiptMaster> GetBySearch(FeeReceiptMasterSearchRequest searchRequest);
        IBaseEntityCollectionResponse<FeeReceiptMaster> GetAccountListForFeeReceipt(FeeReceiptMasterSearchRequest searchRequest);
        IBaseEntityResponse<FeeReceiptMaster> SelectByID(FeeReceiptMaster item);
        IBaseEntityCollectionResponse<FeeReceiptMaster> GetStudentPaymentDetails(FeeReceiptMasterSearchRequest searchRequest);
        IBaseEntityCollectionResponse<FeeReceiptMaster> GetStudentDetailsForFeeReceipt(FeeReceiptMasterSearchRequest searchRequest);
    }
}
