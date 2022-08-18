using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.ServiceAccess
{
    public interface IBOMAndRecipeDetailsServiceAccess
    {
        IBaseEntityResponse<BOMAndRecipeDetails> InsertBOMAndRecipeDetails(BOMAndRecipeDetails item);
        IBaseEntityResponse<BOMAndRecipeDetails> UpdateBOMAndRecipeDetails(BOMAndRecipeDetails item);
        IBaseEntityResponse<BOMAndRecipeDetails> DeleteBOMAndRecipeDetails(BOMAndRecipeDetails item);
        IBaseEntityCollectionResponse<BOMAndRecipeDetails> GetBySearch(BOMAndRecipeDetailsSearchRequest searchRequest);
        IBaseEntityResponse<BOMAndRecipeDetails> SelectByID(BOMAndRecipeDetails item);
        IBaseEntityCollectionResponse<BOMAndRecipeDetails> GetBOMAndRecipeDetailsSearchList(BOMAndRecipeDetailsSearchRequest searchRequest);
        IBaseEntityCollectionResponse<BOMAndRecipeDetails> SelectIngridentsByVarients(BOMAndRecipeDetailsSearchRequest searchRequest);
        IBaseEntityCollectionResponse<BOMAndRecipeDetails> GetConsumptionUnitList(BOMAndRecipeDetailsSearchRequest searchRequest);
        IBaseEntityCollectionResponse<BOMAndRecipeDetails> GetItemsList(BOMAndRecipeDetailsSearchRequest searchRequest);
        IBaseEntityCollectionResponse<BOMAndRecipeDetails> GetUoMCodeWisePurchasePriceList(BOMAndRecipeDetailsSearchRequest searchRequest);
    }
}
