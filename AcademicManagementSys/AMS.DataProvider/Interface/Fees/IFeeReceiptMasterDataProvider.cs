using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.DataProvider
{
	public interface IFeeReceiptMasterDataProvider
	{
		IBaseEntityResponse<FeeReceiptMaster> InsertFeeReceiptMaster(FeeReceiptMaster item);
		IBaseEntityResponse<FeeReceiptMaster> UpdateFeeReceiptMaster(FeeReceiptMaster item);
		IBaseEntityCollectionResponse<FeeReceiptMaster> GetFeeReceiptMasterBySearch(FeeReceiptMasterSearchRequest searchRequest);
        IBaseEntityCollectionResponse<FeeReceiptMaster> GetAccountListForFeeReceipt(FeeReceiptMasterSearchRequest searchRequest);
		IBaseEntityResponse<FeeReceiptMaster> GetFeeReceiptMasterByID(FeeReceiptMaster item);
        IBaseEntityCollectionResponse<FeeReceiptMaster> GetStudentPaymentDetails(FeeReceiptMasterSearchRequest searchRequest);
        IBaseEntityCollectionResponse<FeeReceiptMaster> GetStudentDetailsForFeeReceipt(FeeReceiptMasterSearchRequest searchRequest);
	}
}
