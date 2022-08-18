using AMS.Base.DTO;
using AMS.Business.BusinessAction;
using AMS.DTO;

namespace AMS.ServiceAccess
{
    public class SalePromotionOnFixAmountPlanServiceAccess : ISalePromotionOnFixAmountPlanServiceAccess
    {
        ISalePromotionOnFixAmountPlanBA _SalePromotionOnFixAmountPlanBA = null;

        public SalePromotionOnFixAmountPlanServiceAccess()
        {
            _SalePromotionOnFixAmountPlanBA = new SalePromotionOnFixAmountPlanBA();
        }

        public IBaseEntityCollectionResponse<SalePromotionOnFixAmountPlan> SalePromotionPriceDiscountOnFixAmountPlan(SalePromotionOnFixAmountPlanSearchRequest searchRequest)
        {
            return _SalePromotionOnFixAmountPlanBA.SalePromotionPriceDiscountOnFixAmountPlan(searchRequest);
        }

    }
}
