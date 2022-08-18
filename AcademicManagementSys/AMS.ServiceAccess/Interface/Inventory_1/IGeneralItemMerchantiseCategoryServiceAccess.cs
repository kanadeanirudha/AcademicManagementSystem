using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.ServiceAccess
{
    public interface IGeneralItemMerchantiseCategoryServiceAccess
    {
        IBaseEntityResponse<GeneralItemMerchantiseCategory> InsertGeneralItemMerchantiseCategory(GeneralItemMerchantiseCategory item);
        IBaseEntityResponse<GeneralItemMerchantiseCategory> UpdateGeneralItemMerchantiseCategory(GeneralItemMerchantiseCategory item);
        IBaseEntityResponse<GeneralItemMerchantiseCategory> DeleteGeneralItemMerchantiseCategory(GeneralItemMerchantiseCategory item);
        IBaseEntityCollectionResponse<GeneralItemMerchantiseCategory> GetBySearch(GeneralItemMerchantiseCategorySearchRequest searchRequest);
        IBaseEntityResponse<GeneralItemMerchantiseCategory> SelectByID(GeneralItemMerchantiseCategory item);
        IBaseEntityCollectionResponse<GeneralItemMerchantiseCategory> GetGeneralItemMerchantiseCategorySearchList(GeneralItemMerchantiseCategorySearchRequest searchRequest);
        IBaseEntityCollectionResponse<GeneralItemMerchantiseCategory> GetGeneralItemMerchantiseCategoryCodeByDepartmentCode(GeneralItemMerchantiseCategorySearchRequest searchRequest);
    }
}
