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
    public class RegisterPOSAPIController : BaseApiController
    {
        private readonly ILogger _logException;
        IRegisterPOSAPIServiceAccess _RegisterPOSAPIServiceAccess = null;

        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
        public RegisterPOSAPIController()
        {
            _RegisterPOSAPIServiceAccess = new RegisterPOSAPIServiceAccess();
        }

        [HttpPost]
        [AllowAnonymous]
        public object RegisterPOS(RegisterPOSAPIViewModel model)
        {
            try
            {
                RegisterPOSAPIViewModel _RegisterPOSAPIViewModel = new RegisterPOSAPIViewModel();
                var dictionary = new object();
                if (ModelState.IsValid && model != null)
                {
                    _RegisterPOSAPIViewModel.RegisterPOSAPIDTO = new RegisterPOSAPI();
                    _RegisterPOSAPIViewModel.RegisterPOSAPIDTO.DeviceToken = model.DeviceToken;
                    _RegisterPOSAPIViewModel.RegisterPOSAPIDTO.CreatedBy = model.UserID;
                    _RegisterPOSAPIViewModel.RegisterPOSAPIDTO.ConnectionString = _connectioString;
                    IBaseEntityResponse<RegisterPOSAPI> response = _RegisterPOSAPIServiceAccess.RegisterPOS(_RegisterPOSAPIViewModel.RegisterPOSAPIDTO);
                    //dictionary = (IDictionary<string, object>)response;  
                    Dictionary<string, object> _dict = new Dictionary<string, object>
                    {
	                {"StatusCode", response.Entity.Status},
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


    }
}
