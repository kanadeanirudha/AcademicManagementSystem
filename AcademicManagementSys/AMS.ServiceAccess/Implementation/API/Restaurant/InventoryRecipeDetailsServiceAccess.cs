using AMS.Base.DTO;
using AMS.Business.BusinessAction;
using AMS.DTO;

namespace AMS.ServiceAccess
{
    public class InventoryRecipeDetailsServiceAccess : IInventoryRecipeDetailsServiceAccess
    {
        IInventoryRecipeDetailsBA _InventoryRecipeDetailsBA = null;

        public InventoryRecipeDetailsServiceAccess()
        {
            _InventoryRecipeDetailsBA = new InventoryRecipeDetailsBA();
        }

        public IBaseEntityCollectionResponse<InventoryRecipeDetails> GetInventoryRecipeMaster(InventoryRecipeDetailsSearchRequest searchRequest)
        {
            return _InventoryRecipeDetailsBA.GetInventoryRecipeMaster(searchRequest);
        }
        public IBaseEntityCollectionResponse<InventoryRecipeDetails> GetInventoryVariationMaster(InventoryRecipeDetailsSearchRequest searchRequest)
        {
            return _InventoryRecipeDetailsBA.GetInventoryVariationMaster(searchRequest);
        }
        public IBaseEntityCollectionResponse<InventoryRecipeDetails> GetInventoryRecipeFormulaDetails(InventoryRecipeDetailsSearchRequest searchRequest)
        {
            return _InventoryRecipeDetailsBA.GetInventoryRecipeFormulaDetails(searchRequest);
        }
    }

}

