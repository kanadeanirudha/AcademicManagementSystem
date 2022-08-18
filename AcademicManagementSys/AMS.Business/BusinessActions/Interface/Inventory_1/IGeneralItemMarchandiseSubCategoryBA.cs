using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Business.BusinessActions
{
    public interface IGeneralItemMarchandiseSubCategoryBA
    {
        IBaseEntityResponse<GeneralItemMarchandiseSubCategory> InsertGeneralItemMarchandiseSubCategory(GeneralItemMarchandiseSubCategory item);
        IBaseEntityResponse<GeneralItemMarchandiseSubCategory> UpdateGeneralItemMarchandiseSubCategory(GeneralItemMarchandiseSubCategory item);
        IBaseEntityResponse<GeneralItemMarchandiseSubCategory> DeleteGeneralItemMarchandiseSubCategory(GeneralItemMarchandiseSubCategory item);
        IBaseEntityCollectionResponse<GeneralItemMarchandiseSubCategory> GetBySearch(GeneralItemMarchandiseSubCategorySearchRequest searchRequest);
        IBaseEntityCollectionResponse<GeneralItemMarchandiseSubCategory> GetGeneralItemMarchandiseSubCategorySearchList(GeneralItemMarchandiseSubCategorySearchRequest searchRequest);
        IBaseEntityResponse<GeneralItemMarchandiseSubCategory> SelectByID(GeneralItemMarchandiseSubCategory item);
        IBaseEntityCollectionResponse<GeneralItemMarchandiseSubCategory> GetGeneralItemMerchantiseSubCategoryCodeByDepartmentCode(GeneralItemMarchandiseSubCategorySearchRequest searchRequest);
    }
}

