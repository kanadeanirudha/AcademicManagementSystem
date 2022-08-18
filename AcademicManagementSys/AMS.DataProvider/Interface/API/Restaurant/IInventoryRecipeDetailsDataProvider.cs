using AMS.Base.DTO;
using AMS.DTO;

namespace AMS.DataProvider
{
    public interface IInventoryRecipeDetailsDataProvider
    {
        IBaseEntityCollectionResponse<InventoryRecipeDetails> GetInventoryRecipeMaster(InventoryRecipeDetailsSearchRequest searchRequest);
        IBaseEntityCollectionResponse<InventoryRecipeDetails> GetInventoryVariationMaster(InventoryRecipeDetailsSearchRequest searchRequest);
        IBaseEntityCollectionResponse<InventoryRecipeDetails> GetInventoryRecipeFormulaDetails(InventoryRecipeDetailsSearchRequest searchRequest);

    }
}
