using AMS.Base.DTO;
using AMS.Business.BusinessAction;
using AMS.DTO;

namespace AMS.ServiceAccess
{
    public class SalePromotionGetOfflineServiceAccess : ISalePromotionGetOfflineServiceAccess
    {
        ISalePromotionGetOfflineBA _SalePromotionGetOfflineBA = null;

        public SalePromotionGetOfflineServiceAccess()
        {
            _SalePromotionGetOfflineBA = new SalePromotionGetOfflineBA();
        }

        public IBaseEntityCollectionResponse<SalePromotionGetOffline> GetSalePromotionActivityMaster(SalePromotionGetOfflineSearchRequest searchRequest)
        {
            return _SalePromotionGetOfflineBA.GetSalePromotionActivityMaster(searchRequest);
        }

        public IBaseEntityCollectionResponse<SalePromotionGetOffline> GetSalePromotionActivityDetails(SalePromotionGetOfflineSearchRequest searchRequest)
        {
            return _SalePromotionGetOfflineBA.GetSalePromotionActivityDetails(searchRequest);
        }

        public IBaseEntityCollectionResponse<SalePromotionGetOffline> GetPromotionActivityDiscounteItemList(SalePromotionGetOfflineSearchRequest searchRequest)
        {
            return _SalePromotionGetOfflineBA.GetPromotionActivityDiscounteItemList(searchRequest);
        }

        public IBaseEntityCollectionResponse<SalePromotionGetOffline> GetSalePromotionPlan(SalePromotionGetOfflineSearchRequest searchRequest)
        {
            return _SalePromotionGetOfflineBA.GetSalePromotionPlan(searchRequest);
        }

        public IBaseEntityCollectionResponse<SalePromotionGetOffline> GetSalePromotionPlanDetails(SalePromotionGetOfflineSearchRequest searchRequest)
        {
            return _SalePromotionGetOfflineBA.GetSalePromotionPlanDetails(searchRequest);
        }
    }
}
