using AMS.Base.DTO;
using AMS.Business.BusinessAction;
using AMS.DTO;
namespace AMS.ServiceAccess
{
	public class BranchPromotionServiceAccess : IBranchPromotionServiceAccess
	{
		IBranchPromotionBA _BranchPromotionBA = null;
		public BranchPromotionServiceAccess()
		{
			_BranchPromotionBA = new BranchPromotionBA();
		}
		public IBaseEntityResponse<BranchPromotion> InsertBranchPromotion(BranchPromotion item)
		{
			return _BranchPromotionBA.InsertBranchPromotion(item);
		}
		public IBaseEntityResponse<BranchPromotion> UpdateBranchPromotion(BranchPromotion item)
		{
			return _BranchPromotionBA.UpdateBranchPromotion(item);
		}
		public IBaseEntityResponse<BranchPromotion> DeleteBranchPromotion(BranchPromotion item)
		{
			return _BranchPromotionBA.DeleteBranchPromotion(item);
		}
		public IBaseEntityCollectionResponse<BranchPromotion> GetBySearch(BranchPromotionSearchRequest searchRequest)
		{
			return _BranchPromotionBA.GetBySearch(searchRequest);
		}
        public IBaseEntityCollectionResponse<BranchPromotion> GetBranchPromotionStudentListBySearch(BranchPromotionSearchRequest searchRequest)
        {
            return _BranchPromotionBA.GetBranchPromotionStudentListBySearch(searchRequest);
        }
		public IBaseEntityResponse<BranchPromotion> SelectByID(BranchPromotion item)
		{
			return _BranchPromotionBA.SelectByID(item);
		}
	}
}
