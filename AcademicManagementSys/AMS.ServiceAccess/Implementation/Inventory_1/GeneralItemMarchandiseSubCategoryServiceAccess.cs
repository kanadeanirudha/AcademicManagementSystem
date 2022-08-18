using AMS.Base.DTO;
using AMS.Business.BusinessActions;
using AMS.DTO;

namespace AMS.ServiceAccess
{
    public class GeneralItemMarchandiseSubCategoryServiceAccess : IGeneralItemMarchandiseSubCategoryServiceAccess
    {
        IGeneralItemMarchandiseSubCategoryBA _GeneralItemMarchandiseSubCategoryBA = null;
        public GeneralItemMarchandiseSubCategoryServiceAccess()
        {
            _GeneralItemMarchandiseSubCategoryBA = new GeneralItemMarchandiseSubCategoryBA();
        }
        public IBaseEntityResponse<GeneralItemMarchandiseSubCategory> InsertGeneralItemMarchandiseSubCategory(GeneralItemMarchandiseSubCategory item)
        {
            return _GeneralItemMarchandiseSubCategoryBA.InsertGeneralItemMarchandiseSubCategory(item);
        }
        public IBaseEntityResponse<GeneralItemMarchandiseSubCategory> UpdateGeneralItemMarchandiseSubCategory(GeneralItemMarchandiseSubCategory item)
        {
            return _GeneralItemMarchandiseSubCategoryBA.UpdateGeneralItemMarchandiseSubCategory(item);
        }
        public IBaseEntityResponse<GeneralItemMarchandiseSubCategory> DeleteGeneralItemMarchandiseSubCategory(GeneralItemMarchandiseSubCategory item)
        {
            return _GeneralItemMarchandiseSubCategoryBA.DeleteGeneralItemMarchandiseSubCategory(item);
        }
        public IBaseEntityCollectionResponse<GeneralItemMarchandiseSubCategory> GetBySearch(GeneralItemMarchandiseSubCategorySearchRequest searchRequest)
        {
            return _GeneralItemMarchandiseSubCategoryBA.GetBySearch(searchRequest);
        }
        public IBaseEntityCollectionResponse<GeneralItemMarchandiseSubCategory> GetGeneralItemMarchandiseSubCategorySearchList(GeneralItemMarchandiseSubCategorySearchRequest searchRequest)
        {
            return _GeneralItemMarchandiseSubCategoryBA.GetGeneralItemMarchandiseSubCategorySearchList(searchRequest);
        }
        public IBaseEntityResponse<GeneralItemMarchandiseSubCategory> SelectByID(GeneralItemMarchandiseSubCategory item)
        {
            return _GeneralItemMarchandiseSubCategoryBA.SelectByID(item);
        }
        public IBaseEntityCollectionResponse<GeneralItemMarchandiseSubCategory> GetGeneralItemMerchantiseSubCategoryCodeByDepartmentCode(GeneralItemMarchandiseSubCategorySearchRequest searchRequest)
        {
            return _GeneralItemMarchandiseSubCategoryBA.GetGeneralItemMerchantiseSubCategoryCodeByDepartmentCode(searchRequest);
        }
    }
}
