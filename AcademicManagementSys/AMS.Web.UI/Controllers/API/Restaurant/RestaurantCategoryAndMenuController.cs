using AMS.Base.DTO;
using AMS.ExceptionManager;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web.Http;
using System.Web;
using AMS.ServiceAccess;
using AMS.ViewModel;
using AMS.DTO;
namespace AMS.Web.UI.Controllers.API
{

    public class RestaurantCategoryAndMenuController : BaseApiController
    {
        private readonly ILogger _logException;
        IRestaurantCategoryAndMenuServiceAccess _RestaurantCategoryAndMenuServiceAccess = null;

        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
        public RestaurantCategoryAndMenuController()
        {
            _RestaurantCategoryAndMenuServiceAccess = new RestaurantCategoryAndMenuServiceAccess();
        }


        [HttpPost]
        [AllowAnonymous]
        public object GetRestaurantCategory(RestaurantCategoryAndMenuViewModel model)
        {
            try
            {
                RestaurantCategoryAndMenuSearchRequest searchRequest = new RestaurantCategoryAndMenuSearchRequest();
                searchRequest.ConnectionString = _connectioString;
                IBaseEntityCollectionResponse<RestaurantCategoryAndMenu> baseEntityCollectionResponse = _RestaurantCategoryAndMenuServiceAccess.GetRestaurantCategory(searchRequest);
                List<RestaurantCategoryAndMenu> RestaurantCategoryAndMenuMasterList = new List<RestaurantCategoryAndMenu>();
                if (baseEntityCollectionResponse != null)
                {
                    if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                    {
                        RestaurantCategoryAndMenuMasterList = baseEntityCollectionResponse.CollectionResponse.ToList();
                    }
                }

                Dictionary<string, object> _dict = new Dictionary<string, object>
                    {
                    {"StatusCode", "200"},
                    {"Message", "Categories retrived successfully."},
                    {"GetOnline", RestaurantCategoryAndMenuMasterList}};
                return _dict;
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        [HttpPost]
        [AllowAnonymous]
        public object GetRestaurantMenu(RestaurantCategoryAndMenuViewModel model)
        {
            try
            {
                RestaurantCategoryAndMenuSearchRequest searchRequest = new RestaurantCategoryAndMenuSearchRequest();
                searchRequest.MenuCategoryID = model.MenuCategoryID;
                searchRequest.GeneralUnitsID = model.GeneralUnitsID;
                searchRequest.ConnectionString = _connectioString;
                searchRequest.ImagePath = Request.RequestUri.Scheme + System.Uri.SchemeDelimiter + Request.RequestUri.Host + "/Content/UploadedFiles/ArticleImage/";
                IBaseEntityCollectionResponse<RestaurantCategoryAndMenu> baseEntityCollectionResponse = _RestaurantCategoryAndMenuServiceAccess.GetRestaurantMenu(searchRequest);
                List<RestaurantCategoryAndMenu> RestaurantCategoryAndMenuMasterList = new List<RestaurantCategoryAndMenu>();
                if (baseEntityCollectionResponse != null)
                {
                    if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                    {
                        RestaurantCategoryAndMenuMasterList = baseEntityCollectionResponse.CollectionResponse.ToList();
                    }
                }

                Dictionary<string, object> _dict = new Dictionary<string, object>
                    {
                    {"StatusCode", "200"},
                    {"Message", "Menu list retrived successfully."},
                    {"GetOnline", RestaurantCategoryAndMenuMasterList}};
                return _dict;
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        [HttpPost]
        [AllowAnonymous]
        public object GetRestaurantMenuSpecification(RestaurantCategoryAndMenuViewModel model)
        {
        try
            {
                RestaurantCategoryAndMenuViewModel _RestaurantCategoryAndMenuViewModel = new RestaurantCategoryAndMenuViewModel();
                _RestaurantCategoryAndMenuViewModel.RestaurantCategoryAndMenuDTO.ConnectionString = _connectioString;
                //RestaurantCategoryAndMenuSearchRequest searchRequest = new RestaurantCategoryAndMenuSearchRequest();
                //searchRequest.ConnectionString = _connectioString;
                IBaseEntityResponse<RestaurantCategoryAndMenu> baseEntityResponse = _RestaurantCategoryAndMenuServiceAccess.GetRestaurantMenuSpecification(_RestaurantCategoryAndMenuViewModel.RestaurantCategoryAndMenuDTO);
                Dictionary<string, object> _dict = new Dictionary<string, object>
                    {
                    {"StatusCode", "200"},
                    {"Message", "Menu Specification List retrived successfully."},
                    {"GetOnline", baseEntityResponse}};
                return _dict;
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        [HttpPost]
        [AllowAnonymous]
        public object GetInventoryRecipeMenuCategory(RestaurantCategoryAndMenuViewModel model)
        {
            try
            {
                RestaurantCategoryAndMenuSearchRequest searchRequest = new RestaurantCategoryAndMenuSearchRequest();
                searchRequest.ConnectionString = _connectioString;
                searchRequest.LastSyncDate = model.LastSyncDate;
                IBaseEntityCollectionResponse<RestaurantCategoryAndMenu> baseEntityCollectionResponse = _RestaurantCategoryAndMenuServiceAccess.GetInventoryRecipeMenuCategory(searchRequest);
                List<RestaurantCategoryAndMenu> RestaurantCategoryAndMenuMasterList = new List<RestaurantCategoryAndMenu>();
                if (baseEntityCollectionResponse != null)
                {
                    if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                    {
                        RestaurantCategoryAndMenuMasterList = baseEntityCollectionResponse.CollectionResponse.ToList();
                    }
                }

                Dictionary<string, object> _dict = new Dictionary<string, object>
                    {
                    {"StatusCode", "200"},
                    {"Message", "Categories retrived successfully."},
                    {"GetOnline", RestaurantCategoryAndMenuMasterList}};
                return _dict;
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        [HttpPost]
        [AllowAnonymous]
        public object GetInventoryRecipeMenuMaster(RestaurantCategoryAndMenuViewModel model)
        {
            try
            {
                RestaurantCategoryAndMenuSearchRequest searchRequest = new RestaurantCategoryAndMenuSearchRequest();
                searchRequest.ConnectionString = _connectioString;
                searchRequest.LastSyncDate = model.LastSyncDate;
                IBaseEntityCollectionResponse<RestaurantCategoryAndMenu> baseEntityCollectionResponse = _RestaurantCategoryAndMenuServiceAccess.GetInventoryRecipeMenuMaster(searchRequest);
                List<RestaurantCategoryAndMenu> RestaurantCategoryAndMenuMasterList = new List<RestaurantCategoryAndMenu>();
                if (baseEntityCollectionResponse != null)
                {
                    if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                    {
                        RestaurantCategoryAndMenuMasterList = baseEntityCollectionResponse.CollectionResponse.ToList();
                    }
                }

                Dictionary<string, object> _dict = new Dictionary<string, object>
                    {
                    {"StatusCode", "200"},
                    {"Message", "Menus retrived successfully."},
                    {"GetOnline", RestaurantCategoryAndMenuMasterList}};
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

