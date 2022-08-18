using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.DataProvider
{
	public interface IFeeRefundMasterDataProvider
	{
		IBaseEntityResponse<FeeRefundMaster> InsertFeeRefundMaster(FeeRefundMaster item);
		IBaseEntityResponse<FeeRefundMaster> UpdateFeeRefundMaster(FeeRefundMaster item);
		IBaseEntityCollectionResponse<FeeRefundMaster> GetFeeRefundMasterBySearch(FeeRefundMasterSearchRequest searchRequest);
        IBaseEntityCollectionResponse<FeeRefundMaster> GetAccountListForFeeRefund(FeeRefundMasterSearchRequest searchRequest);
		IBaseEntityResponse<FeeRefundMaster> GetFeeRefundMasterByID(FeeRefundMaster item);
        IBaseEntityCollectionResponse<FeeRefundMaster> GetStudentPaymentDetails(FeeRefundMasterSearchRequest searchRequest);
        IBaseEntityCollectionResponse<FeeRefundMaster> GetStudentDetailsForFeeReceipt(FeeRefundMasterSearchRequest searchRequest);
	}
}
