using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.ServiceAccess
{
    public interface IGeneralItemMarchandiseSubCategoryServiceAccess
    {
        IBaseEntityResponse<GeneralItemMarchandiseSubCategory> InsertGeneralItemMarchandiseSubCategory(GeneralItemMarchandiseSubCategory item);
        IBaseEntityResponse<GeneralItemMarchandiseSubCategory> UpdateGeneralItemMarchandiseSubCategory(GeneralItemMarchandiseSubCategory item);
        IBaseEntityResponse<GeneralItemMarchandiseSubCategory> DeleteGeneralItemMarchandiseSubCategory(GeneralItemMarchandiseSubCategory item);
        IBaseEntityCollectionResponse<GeneralItemMarchandiseSubCategory> GetBySearch(GeneralItemMarchandiseSubCategorySearchRequest searchRequest);
        IBaseEntityResponse<GeneralItemMarchandiseSubCategory> SelectByID(GeneralItemMarchandiseSubCategory item);
        IBaseEntityCollectionResponse<GeneralItemMarchandiseSubCategory> GetGeneralItemMarchandiseSubCategorySearchList(GeneralItemMarchandiseSubCategorySearchRequest searchRequest);
        IBaseEntityCollectionResponse<GeneralItemMarchandiseSubCategory> GetGeneralItemMerchantiseSubCategoryCodeByDepartmentCode(GeneralItemMarchandiseSubCategorySearchRequest searchRequest);
    }
}
