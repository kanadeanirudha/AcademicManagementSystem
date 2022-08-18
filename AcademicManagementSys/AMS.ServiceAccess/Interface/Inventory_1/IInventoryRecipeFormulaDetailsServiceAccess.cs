using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.ServiceAccess
{
    public interface IInventoryRecipeFormulaDetailsServiceAccess
    {
        IBaseEntityResponse<InventoryRecipeFormulaDetails> InsertInventoryRecipeFormulaDetails(InventoryRecipeFormulaDetails item);
        IBaseEntityResponse<InventoryRecipeFormulaDetails> UpdateInventoryRecipeFormulaDetails(InventoryRecipeFormulaDetails item);
        IBaseEntityResponse<InventoryRecipeFormulaDetails> DeleteInventoryRecipeFormulaDetails(InventoryRecipeFormulaDetails item);
        IBaseEntityCollectionResponse<InventoryRecipeFormulaDetails> GetBySearch(InventoryRecipeFormulaDetailsSearchRequest searchRequest);
        IBaseEntityResponse<InventoryRecipeFormulaDetails> SelectByID(InventoryRecipeFormulaDetails item);
        IBaseEntityCollectionResponse<InventoryRecipeFormulaDetails> GetInventoryRecipeFormulaDetailsSearchList(InventoryRecipeFormulaDetailsSearchRequest searchRequest);
    }
}
