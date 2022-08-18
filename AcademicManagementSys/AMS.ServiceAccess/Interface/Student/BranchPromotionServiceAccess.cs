using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.ServiceAccess
{
	public interface IBranchPromotionServiceAccess
	{
		IBaseEntityResponse<BranchPromotion> InsertBranchPromotion(BranchPromotion item);
		IBaseEntityResponse<BranchPromotion> UpdateBranchPromotion(BranchPromotion item);
		IBaseEntityResponse<BranchPromotion> DeleteBranchPromotion(BranchPromotion item);
		IBaseEntityCollectionResponse<BranchPromotion> GetBySearch(BranchPromotionSearchRequest searchRequest);
        IBaseEntityCollectionResponse<BranchPromotion> GetBranchPromotionStudentListBySearch(BranchPromotionSearchRequest searchRequest);
		IBaseEntityResponse<BranchPromotion> SelectByID(BranchPromotion item);
	}
}
