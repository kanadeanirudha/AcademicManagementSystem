using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AMS.ServiceAccess;
using AMS.Base.DTO;
using AMS.ExceptionManager;
using AMS.Common;
using System.Configuration;
using AMS.DTO;
using AMS.ViewModel;
using System.Globalization;
namespace AMS.Web.UI.Controllers.API
{
    public class GetIngredientsListController : BaseApiController
    {
        private readonly ILogger _logException;
        IGetIngredientsListServiceAccess _GetIngredientsListServiceAccess = null;

        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
        public GetIngredientsListController()
        {
            _GetIngredientsListServiceAccess = new GetIngredientsListServiceAccess();
        }


        [HttpPost]
        [AllowAnonymous]
        public object GetIngredientsList(GetIngredientsListViewModel model)
        {
            try
            {
                GetIngredientsListSearchRequest searchRequest = new GetIngredientsListSearchRequest();

                searchRequest.ConnectionString = _connectioString;
                searchRequest.InventoryVariationMasterID = model.InventoryVariationMasterID;
                IBaseEntityCollectionResponse<GetIngredientsList> baseEntityCollectionResponse = _GetIngredientsListServiceAccess.GetIngredientsListSelfService(searchRequest);
                List<GetIngredientsList> GetIngredientsListMasterList = new List<GetIngredientsList>();
                if (baseEntityCollectionResponse != null)
                {
                    if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                    {
                        GetIngredientsListMasterList = baseEntityCollectionResponse.CollectionResponse.ToList();
                    }
                }

                Dictionary<string, object> _dict = new Dictionary<string, object>
                    {
	                {"StatusCode", "200"},
	                {"Message", "Ingredients List is retrived successfully."},
	                {"GetIngredientsList", GetIngredientsListMasterList}};
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
