using AMS.Base.DTO;
using AMS.DTO;

namespace AMS.Business.BusinessAction
{
    public interface IInventoryRecipeDetailsBA
    {

        IBaseEntityCollectionResponse<InventoryRecipeDetails> GetInventoryRecipeMaster(InventoryRecipeDetailsSearchRequest searchRequest);
        IBaseEntityCollectionResponse<InventoryRecipeDetails> GetInventoryVariationMaster(InventoryRecipeDetailsSearchRequest searchRequest);
        IBaseEntityCollectionResponse<InventoryRecipeDetails> GetInventoryRecipeFormulaDetails(InventoryRecipeDetailsSearchRequest searchRequest);
    }
}
