using AMS.Base.DTO;
using AMS.Business.BusinessActions;
using AMS.DTO;

namespace AMS.ServiceAccess
{
    public class InventoryRecipeFormulaDetailsServiceAccess : IInventoryRecipeFormulaDetailsServiceAccess
    {
        IInventoryRecipeFormulaDetailsBA _InventoryRecipeFormulaDetailsBA = null;
        public InventoryRecipeFormulaDetailsServiceAccess()
        {
            _InventoryRecipeFormulaDetailsBA = new InventoryRecipeFormulaDetailsBA();
        }
        public IBaseEntityResponse<InventoryRecipeFormulaDetails> InsertInventoryRecipeFormulaDetails(InventoryRecipeFormulaDetails item)
        {
            return _InventoryRecipeFormulaDetailsBA.InsertInventoryRecipeFormulaDetails(item);
        }
        public IBaseEntityResponse<InventoryRecipeFormulaDetails> UpdateInventoryRecipeFormulaDetails(InventoryRecipeFormulaDetails item)
        {
            return _InventoryRecipeFormulaDetailsBA.UpdateInventoryRecipeFormulaDetails(item);
        }
        public IBaseEntityResponse<InventoryRecipeFormulaDetails> DeleteInventoryRecipeFormulaDetails(InventoryRecipeFormulaDetails item)
        {
            return _InventoryRecipeFormulaDetailsBA.DeleteInventoryRecipeFormulaDetails(item);
        }
        public IBaseEntityCollectionResponse<InventoryRecipeFormulaDetails> GetBySearch(InventoryRecipeFormulaDetailsSearchRequest searchRequest)
        {
            return _InventoryRecipeFormulaDetailsBA.GetBySearch(searchRequest);
        }
        public IBaseEntityCollectionResponse<InventoryRecipeFormulaDetails> GetInventoryRecipeFormulaDetailsSearchList(InventoryRecipeFormulaDetailsSearchRequest searchRequest)
        {
            return _InventoryRecipeFormulaDetailsBA.GetInventoryRecipeFormulaDetailsSearchList(searchRequest);
        }
        public IBaseEntityResponse<InventoryRecipeFormulaDetails> SelectByID(InventoryRecipeFormulaDetails item)
        {
            return _InventoryRecipeFormulaDetailsBA.SelectByID(item);
        }
    }
}
