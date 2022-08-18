using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Business.BusinessAction
{
    public interface ISalePromotionGetOfflineBA
    {
        IBaseEntityCollectionResponse<SalePromotionGetOffline> GetSalePromotionActivityMaster(SalePromotionGetOfflineSearchRequest searchRequest);
        IBaseEntityCollectionResponse<SalePromotionGetOffline> GetSalePromotionActivityDetails(SalePromotionGetOfflineSearchRequest searchRequest);
        IBaseEntityCollectionResponse<SalePromotionGetOffline> GetPromotionActivityDiscounteItemList(SalePromotionGetOfflineSearchRequest searchRequest);
        IBaseEntityCollectionResponse<SalePromotionGetOffline> GetSalePromotionPlan(SalePromotionGetOfflineSearchRequest searchRequest);
        IBaseEntityCollectionResponse<SalePromotionGetOffline> GetSalePromotionPlanDetails(SalePromotionGetOfflineSearchRequest searchRequest);
    }
}
