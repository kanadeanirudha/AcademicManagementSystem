using AMS.Base.DTO;
using AMS.DTO;
using AMS.ExceptionManager;
using AMS.ServiceAccess;
using AMS.ViewModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web.Http;
namespace AMS.Web.UI.Controllers.API
{
    public class RestaurantTableMasterController : BaseApiController
    {
        private readonly ILogger _logException;
        IRestaurantTableMasterServiceAccess _RestaurantTableMasterServiceAccess = null;

        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
        public RestaurantTableMasterController()
        {
            _RestaurantTableMasterServiceAccess = new RestaurantTableMasterServiceAccess();
        }

        [HttpPost]
        [AllowAnonymous]
        public object RestaurantTableGetOnline(RestaurantTableMasterViewModel model)
        {
            try
            {
                RestaurantTableMasterSearchRequest searchRequest = new RestaurantTableMasterSearchRequest();
                searchRequest.GeneralUnitsID = model.GeneralUnitsID;
                searchRequest.ConnectionString = _connectioString;
                IBaseEntityCollectionResponse<RestaurantTableMaster> baseEntityCollectionResponse = _RestaurantTableMasterServiceAccess.RestaurantTableGetOnline(searchRequest);
                List<RestaurantTableMaster> RestaurantTableMasterMasterList = new List<RestaurantTableMaster>();
                if (baseEntityCollectionResponse != null)
                {
                    if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                    {
                        RestaurantTableMasterMasterList = baseEntityCollectionResponse.CollectionResponse.ToList();
                    }
                }

                Dictionary<string, object> _dict = new Dictionary<string, object>
                    {{"StatusCode", "200"},
                    {"Message", "Table list is retrived successfully."},
                    {"GetOnline", RestaurantTableMasterMasterList}};
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
