using AMS.Base.DTO;
using AMS.Business.BusinessActions;
using AMS.DTO;

namespace AMS.ServiceAccess
{
    public class BOMAndRecipeDetailsServiceAccess : IBOMAndRecipeDetailsServiceAccess
    {
        IBOMAndRecipeDetailsBA _BOMAndRecipeDetailsBA = null;
        public BOMAndRecipeDetailsServiceAccess()
        {
            _BOMAndRecipeDetailsBA = new BOMAndRecipeDetailsBA();
        }
        public IBaseEntityResponse<BOMAndRecipeDetails> InsertBOMAndRecipeDetails(BOMAndRecipeDetails item)
        {
            return _BOMAndRecipeDetailsBA.InsertBOMAndRecipeDetails(item);
        }
        public IBaseEntityResponse<BOMAndRecipeDetails> UpdateBOMAndRecipeDetails(BOMAndRecipeDetails item)
        {
            return _BOMAndRecipeDetailsBA.UpdateBOMAndRecipeDetails(item);
        }
        public IBaseEntityResponse<BOMAndRecipeDetails> DeleteBOMAndRecipeDetails(BOMAndRecipeDetails item)
        {
            return _BOMAndRecipeDetailsBA.DeleteBOMAndRecipeDetails(item);
        }
        public IBaseEntityCollectionResponse<BOMAndRecipeDetails> GetBySearch(BOMAndRecipeDetailsSearchRequest searchRequest)
        {
            return _BOMAndRecipeDetailsBA.GetBySearch(searchRequest);
        }
        public IBaseEntityCollectionResponse<BOMAndRecipeDetails> GetBOMAndRecipeDetailsSearchList(BOMAndRecipeDetailsSearchRequest searchRequest)
        {
            return _BOMAndRecipeDetailsBA.GetBOMAndRecipeDetailsSearchList(searchRequest);
        }
        public IBaseEntityResponse<BOMAndRecipeDetails> SelectByID(BOMAndRecipeDetails item)
        {
            return _BOMAndRecipeDetailsBA.SelectByID(item);
        }
        public IBaseEntityCollectionResponse<BOMAndRecipeDetails> SelectIngridentsByVarients(BOMAndRecipeDetailsSearchRequest searchRequest)
        {
            return _BOMAndRecipeDetailsBA.SelectIngridentsByVarients(searchRequest);
        }
        public IBaseEntityCollectionResponse<BOMAndRecipeDetails> GetConsumptionUnitList(BOMAndRecipeDetailsSearchRequest searchRequest)
        {
            return _BOMAndRecipeDetailsBA.GetConsumptionUnitList(searchRequest);
        }
        public IBaseEntityCollectionResponse<BOMAndRecipeDetails> GetItemsList(BOMAndRecipeDetailsSearchRequest searchRequest)
        {
            return _BOMAndRecipeDetailsBA.GetItemsList(searchRequest);
        }
        public IBaseEntityCollectionResponse<BOMAndRecipeDetails> GetUoMCodeWisePurchasePriceList(BOMAndRecipeDetailsSearchRequest searchRequest)
        {
            return _BOMAndRecipeDetailsBA.GetUoMCodeWisePurchasePriceList(searchRequest);
        }
    }
}
