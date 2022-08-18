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
    public class CheckTabRegistrationController : BaseApiController
    {
        private readonly ILogger _logException;
        ICheckTabRegistrationServiceAccess _CheckTabRegistrationServiceAccess = null;

        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
        public CheckTabRegistrationController()
        {
            _CheckTabRegistrationServiceAccess = new CheckTabRegistrationServiceAccess();
        }


        [HttpPost]
        [AllowAnonymous]
        public object CheckTabRegistrationSelfService(CheckTabRegistrationViewModel model)
        {
            try
            {
                CheckTabRegistrationViewModel _CheckTabRegistrationViewModel = new CheckTabRegistrationViewModel();
                var dictionary = new object();
                if (ModelState.IsValid && model != null)
                {
                    _CheckTabRegistrationViewModel.CheckTabRegistrationDTO = new CheckTabRegistration();
                    _CheckTabRegistrationViewModel.CheckTabRegistrationDTO.ConnectionString = _connectioString;
                    _CheckTabRegistrationViewModel.CheckTabRegistrationDTO.DeviceToken = model.DeviceToken;
                    IBaseEntityResponse<CheckTabRegistration> response = _CheckTabRegistrationServiceAccess.CheckTabRegistrationSelfService(_CheckTabRegistrationViewModel.CheckTabRegistrationDTO);
                    //dictionary = (IDictionary<string, object>)response;  
                    Dictionary<string, object> _dict = new Dictionary<string, object>
                    {
                    {"StatusCode", response.Entity.ErrorCode},
                    {"Message", response.Entity.ErrorMessage},
	                {"CheckTabRegistrationSelfService", response.Entity}};
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
