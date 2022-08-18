using AMS.Base.DTO;
using AMS.ExceptionManager;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web.Http;
using AMS.ServiceAccess;
using AMS.ViewModel;
using AMS.DTO;
namespace AMS.Web.UI.Controllers.API
{

    public class InventoryRecipeGetVariationController : BaseApiController
    {
        private readonly ILogger _logException;
        IInventoryRecipeDetailsServiceAccess _InventoryRecipeDetailsServiceAccess = null;

        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
        public InventoryRecipeGetVariationController()
        {
            _InventoryRecipeDetailsServiceAccess = new InventoryRecipeDetailsServiceAccess();
        }


      
        [HttpPost]
        [AllowAnonymous]
        public object GetInventoryVariationMaster(InventoryRecipeDetailsViewModel model)
        {
            try
            {
                InventoryRecipeDetailsSearchRequest searchRequest = new InventoryRecipeDetailsSearchRequest();
                searchRequest.LastSyncDate = model.LastSyncDate;
                searchRequest.ConnectionString = _connectioString;
                IBaseEntityCollectionResponse<InventoryRecipeDetails> baseEntityCollectionResponse = _InventoryRecipeDetailsServiceAccess.GetInventoryVariationMaster(searchRequest);
                List<InventoryRecipeDetails> InventoryRecipeDetailsMasterListt = new List<InventoryRecipeDetails>();
                if (baseEntityCollectionResponse != null)
                {
                    if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                    {
                        InventoryRecipeDetailsMasterListt = baseEntityCollectionResponse.CollectionResponse.ToList();
                    }
                }

                Dictionary<string, object> _dict = new Dictionary<string, object>
                    {
                    {"StatusCode", "200"},
                    {"Message", "Recipe Variation retrieved successfully."},
                    {"GetOnline", InventoryRecipeDetailsMasterListt}};
                return _dict;
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }


       


    }
}

