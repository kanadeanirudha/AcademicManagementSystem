using AMS.Base.DTO;
using AMS.Business.BusinessActions;
using AMS.DTO;

namespace AMS.ServiceAccess
{
    public class SalePromotionActivityMasterAndDetailsServiceAccess : ISalePromotionActivityMasterAndDetailsServiceAccess
    {
        ISalePromotionActivityMasterAndDetailsBA _SalePromotionActivityMasterAndDetailsBA = null;
        public SalePromotionActivityMasterAndDetailsServiceAccess()
        {
            _SalePromotionActivityMasterAndDetailsBA = new SalePromotionActivityMasterAndDetailsBA();
        }
        public IBaseEntityResponse<SalePromotionActivityMasterAndDetails> InsertSalePromotionActivityMasterAndDetails(SalePromotionActivityMasterAndDetails item)
        {
            return _SalePromotionActivityMasterAndDetailsBA.InsertSalePromotionActivityMasterAndDetails(item);
        }
        public IBaseEntityResponse<SalePromotionActivityMasterAndDetails> UpdateSalePromotionActivityMasterAndDetails(SalePromotionActivityMasterAndDetails item)
        {
            return _SalePromotionActivityMasterAndDetailsBA.UpdateSalePromotionActivityMasterAndDetails(item);
        }
        public IBaseEntityResponse<SalePromotionActivityMasterAndDetails> DeleteSalePromotionActivityMasterAndDetails(SalePromotionActivityMasterAndDetails item)
        {
            return _SalePromotionActivityMasterAndDetailsBA.DeleteSalePromotionActivityMasterAndDetails(item);
        }
        public IBaseEntityResponse<SalePromotionActivityMasterAndDetails> DeletePromotionActivityDiscounteItemList(SalePromotionActivityMasterAndDetails item)
        {
            return _SalePromotionActivityMasterAndDetailsBA.DeletePromotionActivityDiscounteItemList(item);
        }
        public IBaseEntityCollectionResponse<SalePromotionActivityMasterAndDetails> GetBySearch(SalePromotionActivityMasterAndDetailsSearchRequest searchRequest)
        {
            return _SalePromotionActivityMasterAndDetailsBA.GetBySearch(searchRequest);
        }
        public IBaseEntityCollectionResponse<SalePromotionActivityMasterAndDetails> GetSalePromotionActivityMasterAndDetailsSearchList(SalePromotionActivityMasterAndDetailsSearchRequest searchRequest)
        {
            return _SalePromotionActivityMasterAndDetailsBA.GetSalePromotionActivityMasterAndDetailsSearchList(searchRequest);
        }
        public IBaseEntityResponse<SalePromotionActivityMasterAndDetails> SelectByID(SalePromotionActivityMasterAndDetails item)
        {
            return _SalePromotionActivityMasterAndDetailsBA.SelectByID(item);
        }
        public IBaseEntityResponse<SalePromotionActivityMasterAndDetails> InsertSalePromotionActivityMasterAndDetailsRules(SalePromotionActivityMasterAndDetails item)
        {
            return _SalePromotionActivityMasterAndDetailsBA.InsertSalePromotionActivityMasterAndDetailsRules(item);
        }
        public IBaseEntityCollectionResponse<SalePromotionActivityMasterAndDetails> GetPlanForFixedAmount(SalePromotionActivityMasterAndDetailsSearchRequest searchRequest)
        {
            return _SalePromotionActivityMasterAndDetailsBA.GetPlanForFixedAmount(searchRequest);
        }
        public IBaseEntityCollectionResponse<SalePromotionActivityMasterAndDetails> GetItemList(SalePromotionActivityMasterAndDetailsSearchRequest searchRequest)
        {
            return _SalePromotionActivityMasterAndDetailsBA.GetItemList(searchRequest);
        }
        public IBaseEntityCollectionResponse<SalePromotionActivityMasterAndDetails> GetFixAmountDetails(SalePromotionActivityMasterAndDetailsSearchRequest searchRequest)
        {
            return _SalePromotionActivityMasterAndDetailsBA.GetFixAmountDetails(searchRequest);
        }
        public IBaseEntityResponse<SalePromotionActivityMasterAndDetails> InsertItemDetails(SalePromotionActivityMasterAndDetails item)
        {
            return _SalePromotionActivityMasterAndDetailsBA.InsertItemDetails(item);
        }
        public IBaseEntityCollectionResponse<SalePromotionActivityMasterAndDetails> GetConcessionfreeItemsSearchList(SalePromotionActivityMasterAndDetailsSearchRequest searchRequest)
        {
            return _SalePromotionActivityMasterAndDetailsBA.GetConcessionfreeItemsSearchList(searchRequest);
        }

        public IBaseEntityCollectionResponse<SalePromotionActivityMasterAndDetails> GetSelectedItemFreeConcessionTypeList(SalePromotionActivityMasterAndDetailsSearchRequest searchRequest)
        {
            return _SalePromotionActivityMasterAndDetailsBA.GetSelectedItemFreeConcessionTypeList(searchRequest);
        }

        public IBaseEntityCollectionResponse<SalePromotionActivityMasterAndDetails> GetSelectedItemOfConcessionType(SalePromotionActivityMasterAndDetailsSearchRequest searchRequest)
        {
            return _SalePromotionActivityMasterAndDetailsBA.GetSelectedItemOfConcessionType(searchRequest);
        }
        public IBaseEntityResponse<SalePromotionActivityMasterAndDetails> UpdateSelectedItemOfConcessionType(SalePromotionActivityMasterAndDetails item)
        {
            return _SalePromotionActivityMasterAndDetailsBA.UpdateSelectedItemOfConcessionType(item);
        }
        public IBaseEntityResponse<SalePromotionActivityMasterAndDetails> InsertSalePromotionGiftVocherDetails(SalePromotionActivityMasterAndDetails item)
        {
            return _SalePromotionActivityMasterAndDetailsBA.InsertSalePromotionGiftVocherDetails(item);
        }
        public IBaseEntityCollectionResponse<SalePromotionActivityMasterAndDetails> GetSalePromotionGiftVocherDetails(SalePromotionActivityMasterAndDetailsSearchRequest searchRequest)
        {
            return _SalePromotionActivityMasterAndDetailsBA.GetSalePromotionGiftVocherDetails(searchRequest);
        }
    }
}
