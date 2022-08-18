using AMS.Base.DTO;
using AMS.Business.BusinessActions;
using AMS.DTO;

namespace AMS.ServiceAccess
{
    public class GeneralItemMarchandiseBaseCategoryServiceAccess : IGeneralItemMarchandiseBaseCategoryServiceAccess
    {
        IGeneralItemMarchandiseBaseCategoryBA _GeneralItemMarchandiseBaseCategoryBA = null;
        public GeneralItemMarchandiseBaseCategoryServiceAccess()
        {
            _GeneralItemMarchandiseBaseCategoryBA = new GeneralItemMarchandiseBaseCategoryBA();
        }
        public IBaseEntityResponse<GeneralItemMarchandiseBaseCategory> InsertGeneralItemMarchandiseBaseCategory(GeneralItemMarchandiseBaseCategory item)
        {
            return _GeneralItemMarchandiseBaseCategoryBA.InsertGeneralItemMarchandiseBaseCategory(item);
        }
        public IBaseEntityResponse<GeneralItemMarchandiseBaseCategory> UpdateGeneralItemMarchandiseBaseCategory(GeneralItemMarchandiseBaseCategory item)
        {
            return _GeneralItemMarchandiseBaseCategoryBA.UpdateGeneralItemMarchandiseBaseCategory(item);
        }
        public IBaseEntityResponse<GeneralItemMarchandiseBaseCategory> DeleteGeneralItemMarchandiseBaseCategory(GeneralItemMarchandiseBaseCategory item)
        {
            return _GeneralItemMarchandiseBaseCategoryBA.DeleteGeneralItemMarchandiseBaseCategory(item);
        }
        public IBaseEntityCollectionResponse<GeneralItemMarchandiseBaseCategory> GetBySearch(GeneralItemMarchandiseBaseCategorySearchRequest searchRequest)
        {
            return _GeneralItemMarchandiseBaseCategoryBA.GetBySearch(searchRequest);
        }
        public IBaseEntityCollectionResponse<GeneralItemMarchandiseBaseCategory> GetGeneralItemMarchandiseBaseCategorySearchList(GeneralItemMarchandiseBaseCategorySearchRequest searchRequest)
        {
            return _GeneralItemMarchandiseBaseCategoryBA.GetGeneralItemMarchandiseBaseCategorySearchList(searchRequest);
        }
        public IBaseEntityResponse<GeneralItemMarchandiseBaseCategory> SelectByID(GeneralItemMarchandiseBaseCategory item)
        {
            return _GeneralItemMarchandiseBaseCategoryBA.SelectByID(item);
        }
        public IBaseEntityCollectionResponse<GeneralItemMarchandiseBaseCategory> GetGeneralItemMerchantiseBaseCategoryCodeByCategoryCode(GeneralItemMarchandiseBaseCategorySearchRequest searchRequest)
        {
            return _GeneralItemMarchandiseBaseCategoryBA.GetGeneralItemMerchantiseBaseCategoryCodeByCategoryCode(searchRequest);
        }
    }
}
