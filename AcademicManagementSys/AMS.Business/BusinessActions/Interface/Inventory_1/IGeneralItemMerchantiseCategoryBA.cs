using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Business.BusinessActions
{
    public interface IGeneralItemMerchantiseCategoryBA
    {
        IBaseEntityResponse<GeneralItemMerchantiseCategory> InsertGeneralItemMerchantiseCategory(GeneralItemMerchantiseCategory item);
        IBaseEntityResponse<GeneralItemMerchantiseCategory> UpdateGeneralItemMerchantiseCategory(GeneralItemMerchantiseCategory item);
        IBaseEntityResponse<GeneralItemMerchantiseCategory> DeleteGeneralItemMerchantiseCategory(GeneralItemMerchantiseCategory item);
        IBaseEntityCollectionResponse<GeneralItemMerchantiseCategory> GetBySearch(GeneralItemMerchantiseCategorySearchRequest searchRequest);
        IBaseEntityCollectionResponse<GeneralItemMerchantiseCategory> GetGeneralItemMerchantiseCategorySearchList(GeneralItemMerchantiseCategorySearchRequest searchRequest);
        IBaseEntityResponse<GeneralItemMerchantiseCategory> SelectByID(GeneralItemMerchantiseCategory item);
        IBaseEntityCollectionResponse<GeneralItemMerchantiseCategory> GetGeneralItemMerchantiseCategoryCodeByDepartmentCode(GeneralItemMerchantiseCategorySearchRequest searchRequest);
    }
}

