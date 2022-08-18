using AMS.Base.DTO;
using AMS.Business.BusinessActions;
using AMS.DTO;

namespace AMS.ServiceAccess
{
    public class GeneralItemMerchantiseCategoryServiceAccess : IGeneralItemMerchantiseCategoryServiceAccess
    {
        IGeneralItemMerchantiseCategoryBA _GeneralItemMerchantiseCategoryBA = null;
        public GeneralItemMerchantiseCategoryServiceAccess()
        {
            _GeneralItemMerchantiseCategoryBA = new GeneralItemMerchantiseCategoryBA();
        }
        public IBaseEntityResponse<GeneralItemMerchantiseCategory> InsertGeneralItemMerchantiseCategory(GeneralItemMerchantiseCategory item)
        {
            return _GeneralItemMerchantiseCategoryBA.InsertGeneralItemMerchantiseCategory(item);
        }
        public IBaseEntityResponse<GeneralItemMerchantiseCategory> UpdateGeneralItemMerchantiseCategory(GeneralItemMerchantiseCategory item)
        {
            return _GeneralItemMerchantiseCategoryBA.UpdateGeneralItemMerchantiseCategory(item);
        }
        public IBaseEntityResponse<GeneralItemMerchantiseCategory> DeleteGeneralItemMerchantiseCategory(GeneralItemMerchantiseCategory item)
        {
            return _GeneralItemMerchantiseCategoryBA.DeleteGeneralItemMerchantiseCategory(item);
        }
        public IBaseEntityCollectionResponse<GeneralItemMerchantiseCategory> GetBySearch(GeneralItemMerchantiseCategorySearchRequest searchRequest)
        {
            return _GeneralItemMerchantiseCategoryBA.GetBySearch(searchRequest);
        }
        public IBaseEntityCollectionResponse<GeneralItemMerchantiseCategory> GetGeneralItemMerchantiseCategorySearchList(GeneralItemMerchantiseCategorySearchRequest searchRequest)
        {
            return _GeneralItemMerchantiseCategoryBA.GetGeneralItemMerchantiseCategorySearchList(searchRequest);
        }
        public IBaseEntityResponse<GeneralItemMerchantiseCategory> SelectByID(GeneralItemMerchantiseCategory item)
        {
            return _GeneralItemMerchantiseCategoryBA.SelectByID(item);
        }
        public IBaseEntityCollectionResponse<GeneralItemMerchantiseCategory> GetGeneralItemMerchantiseCategoryCodeByDepartmentCode(GeneralItemMerchantiseCategorySearchRequest searchRequest)
        {
            return _GeneralItemMerchantiseCategoryBA.GetGeneralItemMerchantiseCategoryCodeByDepartmentCode(searchRequest);
        }
    }
}
