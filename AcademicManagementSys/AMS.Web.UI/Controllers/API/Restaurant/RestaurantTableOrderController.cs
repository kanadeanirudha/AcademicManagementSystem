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
    public class RestaurantTableOrderController : BaseApiController
    {
        private readonly ILogger _logException;
        IRestaurantTableOrderServiceAccess _restaurantTableOrderServiceAccess = null;

        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
        public RestaurantTableOrderController()
        {
            _restaurantTableOrderServiceAccess = new RestaurantTableOrderServiceAccess();
        }

        [HttpPost]
        [AllowAnonymous]
        public object PostTableOrder(RestaurantTableOrderViewModel model)
        {
            try
            {
                RestaurantTableOrderViewModel _restaurantTableOrderViewModel = new RestaurantTableOrderViewModel();
                var dictionary = new object();
                if (ModelState.IsValid && model != null)
                {
                    _restaurantTableOrderViewModel.RestaurantTableOrderDTO = new RestaurantTableOrder();
                    _restaurantTableOrderViewModel.RestaurantTableOrderDTO.ID = model.ID;
                    _restaurantTableOrderViewModel.RestaurantTableOrderDTO.CentreCode = model.CentreCode;
                    _restaurantTableOrderViewModel.RestaurantTableOrderDTO.TableNumber = model.TableNumber;
                    _restaurantTableOrderViewModel.RestaurantTableOrderDTO.OrderXML = model.OrderXML.Replace("&","[and]");
                    _restaurantTableOrderViewModel.RestaurantTableOrderDTO.PaymentReferenceCode = model.PaymentReferenceCode;
                    _restaurantTableOrderViewModel.RestaurantTableOrderDTO.IsTakeAway = model.IsTakeAway;
                    _restaurantTableOrderViewModel.RestaurantTableOrderDTO.TotalBillAmt = model.TotalBillAmt;
                    _restaurantTableOrderViewModel.RestaurantTableOrderDTO.PaidBillNumber = model.PaidBillNumber;
                    _restaurantTableOrderViewModel.RestaurantTableOrderDTO.CreatedBy = model.CreatedBy;
                    _restaurantTableOrderViewModel.RestaurantTableOrderDTO.ConnectionString = _connectioString;
                    IBaseEntityResponse<RestaurantTableOrder> response = _restaurantTableOrderServiceAccess.PostTableOrder(_restaurantTableOrderViewModel.RestaurantTableOrderDTO);
                    //dictionary = (IDictionary<string, object>)response;  
                    Dictionary<string, object> _dict = new Dictionary<string, object>
                    {
                    {"StatusCode", response.Entity.ErrorCode},
                    {"Message", response.Entity.ErrorMessage},
                    {"PostOnline", response.Entity}};
                    return _dict;
                }
                return 0;
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        [HttpPost]
        [AllowAnonymous]
        public object PostTableOrderStatus(RestaurantTableOrderViewModel model)
        {
            try
            {
                RestaurantTableOrderViewModel _restaurantTableOrderViewModel = new RestaurantTableOrderViewModel();
                var dictionary = new object();
                if (ModelState.IsValid && model != null)
                {
                    _restaurantTableOrderViewModel.RestaurantTableOrderDTO = new RestaurantTableOrder();
                    _restaurantTableOrderViewModel.RestaurantTableOrderDTO.ID = model.ID;
                    _restaurantTableOrderViewModel.RestaurantTableOrderDTO.IsOrderServed = model.IsOrderServed;
                    _restaurantTableOrderViewModel.RestaurantTableOrderDTO.CreatedBy = model.CreatedBy;
                    _restaurantTableOrderViewModel.RestaurantTableOrderDTO.ConnectionString = _connectioString;
                    IBaseEntityResponse<RestaurantTableOrder> response = _restaurantTableOrderServiceAccess.PostTableOrderStatus(_restaurantTableOrderViewModel.RestaurantTableOrderDTO);

                    Dictionary<string, object> _dict = new Dictionary<string, object>
                    {
                    {"ErrorCode", response.Entity.ErrorCode},
                    {"Message", response.Entity.ErrorMessage},
                    {"Data", response.Entity}};
                    return _dict;
                }
                return 0;
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        [HttpPost]
        [AllowAnonymous]
        public object GetTableOrder(RestaurantTableOrderViewModel model)
        {
            try
            {
                RestaurantTableOrderSearchRequest searchRequest = new RestaurantTableOrderSearchRequest();
                searchRequest.ConnectionString = _connectioString;
                searchRequest.CentreCode = model.CentreCode;
                searchRequest.TableNumber = model.TableNumber;
                IBaseEntityCollectionResponse<RestaurantTableOrder> baseEntityCollectionResponse = _restaurantTableOrderServiceAccess.GetTableOrder(searchRequest);
                List<RestaurantTableOrder> RestaurantTableOrderMasterList = new List<RestaurantTableOrder>();
                if (baseEntityCollectionResponse != null)
                {
                    if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                    {
                        RestaurantTableOrderMasterList = baseEntityCollectionResponse.CollectionResponse.ToList();
                    }
                }

                Dictionary<string, object> _dict = new Dictionary<string, object>
                    {
                    {"StatusCode", "200"},
                    {"Message", "Order List is retrived successfully."},
                    {"GetOnline", RestaurantTableOrderMasterList}};
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
