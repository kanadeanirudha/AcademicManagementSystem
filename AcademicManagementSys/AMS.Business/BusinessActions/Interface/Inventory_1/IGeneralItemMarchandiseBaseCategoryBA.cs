using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Business.BusinessActions
{
    public interface IGeneralItemMarchandiseBaseCategoryBA
    {
        IBaseEntityResponse<GeneralItemMarchandiseBaseCategory> InsertGeneralItemMarchandiseBaseCategory(GeneralItemMarchandiseBaseCategory item);
        IBaseEntityResponse<GeneralItemMarchandiseBaseCategory> UpdateGeneralItemMarchandiseBaseCategory(GeneralItemMarchandiseBaseCategory item);
        IBaseEntityResponse<GeneralItemMarchandiseBaseCategory> DeleteGeneralItemMarchandiseBaseCategory(GeneralItemMarchandiseBaseCategory item);
        IBaseEntityCollectionResponse<GeneralItemMarchandiseBaseCategory> GetBySearch(GeneralItemMarchandiseBaseCategorySearchRequest searchRequest);
        IBaseEntityCollectionResponse<GeneralItemMarchandiseBaseCategory> GetGeneralItemMarchandiseBaseCategorySearchList(GeneralItemMarchandiseBaseCategorySearchRequest searchRequest);
        IBaseEntityResponse<GeneralItemMarchandiseBaseCategory> SelectByID(GeneralItemMarchandiseBaseCategory item);
        IBaseEntityCollectionResponse<GeneralItemMarchandiseBaseCategory> GetGeneralItemMerchantiseBaseCategoryCodeByCategoryCode(GeneralItemMarchandiseBaseCategorySearchRequest searchRequest);

    }
}

