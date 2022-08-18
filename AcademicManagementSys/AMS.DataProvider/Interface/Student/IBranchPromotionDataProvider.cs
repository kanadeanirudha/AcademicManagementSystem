using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.DataProvider
{
	public interface IBranchPromotionDataProvider
	{
		IBaseEntityResponse<BranchPromotion> InsertBranchPromotion(BranchPromotion item);
		IBaseEntityResponse<BranchPromotion> UpdateBranchPromotion(BranchPromotion item);
		IBaseEntityResponse<BranchPromotion> DeleteBranchPromotion(BranchPromotion item);
		IBaseEntityCollectionResponse<BranchPromotion> GetBranchPromotionBySearch(BranchPromotionSearchRequest searchRequest);
        IBaseEntityCollectionResponse<BranchPromotion> GetBranchPromotionStudentListBySearch(BranchPromotionSearchRequest searchRequest);
		IBaseEntityResponse<BranchPromotion> GetBranchPromotionByID(BranchPromotion item);
	}
}
