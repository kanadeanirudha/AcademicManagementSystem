using AMS.Base.DTO;
using AMS.Business.BusinessActions;
using AMS.DTO;

namespace AMS.ServiceAccess
{
    public class SalePromotionPlanAndDetailsServiceAccess : ISalePromotionPlanAndDetailsServiceAccess
    {
        ISalePromotionPlanAndDetailsBA _SalePromotionPlanAndDetailsBA = null;
        public SalePromotionPlanAndDetailsServiceAccess()
        {
            _SalePromotionPlanAndDetailsBA = new SalePromotionPlanAndDetailsBA();
        }
        public IBaseEntityResponse<SalePromotionPlanAndDetails> InsertSalePromotionPlanAndDetails(SalePromotionPlanAndDetails item)
        {
            return _SalePromotionPlanAndDetailsBA.InsertSalePromotionPlanAndDetails(item);
        }
        public IBaseEntityResponse<SalePromotionPlanAndDetails> UpdateSalePromotionPlanAndDetails(SalePromotionPlanAndDetails item)
        {
            return _SalePromotionPlanAndDetailsBA.UpdateSalePromotionPlanAndDetails(item);
        }
        public IBaseEntityResponse<SalePromotionPlanAndDetails> DeleteSalePromotionPlanAndDetails(SalePromotionPlanAndDetails item)
        {
            return _SalePromotionPlanAndDetailsBA.DeleteSalePromotionPlanAndDetails(item);
        }
        public IBaseEntityCollectionResponse<SalePromotionPlanAndDetails> GetBySearch(SalePromotionPlanAndDetailsSearchRequest searchRequest)
        {
            return _SalePromotionPlanAndDetailsBA.GetBySearch(searchRequest);
        }
        public IBaseEntityCollectionResponse<SalePromotionPlanAndDetails> GetSalePromotionPlanAndDetailsSearchList(SalePromotionPlanAndDetailsSearchRequest searchRequest)
        {
            return _SalePromotionPlanAndDetailsBA.GetSalePromotionPlanAndDetailsSearchList(searchRequest);
        }
        public IBaseEntityResponse<SalePromotionPlanAndDetails> SelectByID(SalePromotionPlanAndDetails item)
        {
            return _SalePromotionPlanAndDetailsBA.SelectByID(item);
        }
        public IBaseEntityResponse<SalePromotionPlanAndDetails> InsertSalePromotionPlan(SalePromotionPlanAndDetails item)
        {
            return _SalePromotionPlanAndDetailsBA.InsertSalePromotionPlan(item);
        }
        public IBaseEntityCollectionResponse<SalePromotionPlanAndDetails> GetPlanDescriptionByPlanCode(SalePromotionPlanAndDetailsSearchRequest searchRequest)
        {
            return _SalePromotionPlanAndDetailsBA.GetPlanDescriptionByPlanCode(searchRequest);
        }
        public IBaseEntityCollectionResponse<SalePromotionPlanAndDetails> GetDiscountInPercentLIst(SalePromotionPlanAndDetailsSearchRequest searchRequest)
        {
            return _SalePromotionPlanAndDetailsBA.GetDiscountInPercentLIst(searchRequest);
        }
        public IBaseEntityCollectionResponse<SalePromotionPlanAndDetails> GetBillAmountrangeForGiftVoucher(SalePromotionPlanAndDetailsSearchRequest searchRequest)
        {
            return _SalePromotionPlanAndDetailsBA.GetBillAmountrangeForGiftVoucher(searchRequest);
        }
    }
}
