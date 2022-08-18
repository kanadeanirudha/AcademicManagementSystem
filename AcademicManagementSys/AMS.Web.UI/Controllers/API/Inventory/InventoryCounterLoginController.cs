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
    public class InventoryCounterLoginController : BaseApiController
    {
        private readonly ILogger _logException;
        IAPIInventoryServiceAccess _apiInventoryServiceAccess = null;
        
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
        public InventoryCounterLoginController()
        {
            _apiInventoryServiceAccess = new APIInventoryServiceAccess();
        }

        [HttpPost]
        [AllowAnonymous]
        public object CounterLogin(APIInventoryViewModel model)
        {
            try
            {
                APIInventoryViewModel _apiInventoryViewModel = new APIInventoryViewModel();
                APIInventoryViewModel _apiInventoryViewModel1 = new APIInventoryViewModel();
                var dictionary = new object();
                if (ModelState.IsValid && model != null)
                {
                    _apiInventoryViewModel.APIInventoryDTO = new APIInventory();
                    _apiInventoryViewModel.APIInventoryDTO.POSMasterID = model.POSMasterID;
                    _apiInventoryViewModel.APIInventoryDTO.UserID = model.UserID;
                    _apiInventoryViewModel.APIInventoryDTO.DeviceToken = model.DeviceToken;
                    _apiInventoryViewModel.APIInventoryDTO.TimeZone = model.TimeZone;
                    _apiInventoryViewModel.APIInventoryDTO.CounterMstID = model.CounterMstID;
                    _apiInventoryViewModel.APIInventoryDTO.CreatedBy = model.CreatedBy;
                    _apiInventoryViewModel.APIInventoryDTO.ConnectionString = _connectioString;
                    IBaseEntityResponse<APIInventory> response = _apiInventoryServiceAccess.InventoryCounterLogin(_apiInventoryViewModel.APIInventoryDTO);
                    //dictionary = (IDictionary<string, object>)response;  
                    Dictionary<string, object> _dict = new Dictionary<string, object>
                    {
	                {"StatusCode", response.Entity.Status},
	                {"Message", response.Entity.ErrorMessage},
	                {"CounterLogin", response.Entity}};
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
    }
}
