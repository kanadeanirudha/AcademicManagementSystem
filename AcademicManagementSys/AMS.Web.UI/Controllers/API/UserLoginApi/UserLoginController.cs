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
    public class UserLoginController : BaseApiController
    {
        private readonly ILogger _logException;
        IUserMasterServiceAccess _userMasterServiceAcess = null;
        IUserMainMenuMasterServiceAccess _userMainMenuMasterServiceAccess = null;
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
        public UserLoginController()
        {
            _userMasterServiceAcess = new UserMasterServiceAccess();
            _userMainMenuMasterServiceAccess = new UserMainMenuMasterServiceAccess();
        }

        [HttpPost]
        [AllowAnonymous]
        public object Login(UserMasterViewModel model)
        {
            try
            {
                UserMasterViewModel _userMasterViewModel = new UserMasterViewModel();
                if (ModelState.IsValid && model != null && !string.IsNullOrEmpty(model.EmailID) && !string.IsNullOrEmpty(model.Password))
                {
                    _userMasterViewModel.UserMasterDTO = new UserMaster();
                    _userMasterViewModel.UserMasterDTO.EmailID = model.EmailID;
                    _userMasterViewModel.UserMasterDTO.Password = model.Password;
                    _userMasterViewModel.UserMasterDTO.DeviceToken = model.DeviceToken;
                    _userMasterViewModel.UserMasterDTO.ConnectionString = _connectioString;
                    IBaseEntityResponse<UserMaster> response = _userMasterServiceAcess.UserLoginApi(_userMasterViewModel.UserMasterDTO);
                    if (response != null)
                    {
                        if (response.Entity != null  && response.Entity.ErrorCode == 100)
                        {
                            string body = string.Empty;
                            string serviceUrl = Convert.ToString(System.Configuration.ConfigurationManager.AppSettings["ServiceURL"]);
                            byte[] time = BitConverter.GetBytes(DateTime.UtcNow.ToBinary());
                            //byte[] key = Guid.NewGuid().ToByteArray();
                            //string token = Convert.ToBase64String(time.Concat(key).ToArray());
                            string url = serviceUrl + "/Account/LoginReset/" + Base64Encode(Convert.ToString(response.Entity.UserID)) + "~" + Convert.ToBase64String(time);
                            body = "<Html><Body><div>"
                                    + "<div><span>Hello " + response.Entity.FirstName + " " + response.Entity.LastName + ",</span><br /><br />"
                                    + "<span>Please go through below link to reset previous login sessions.</span><br />"
                                    + "<a href='" + url + "'>Reset Session</a>"
                                    + "<br />"
                                    + "</div>"
                                    + "</div></Body></Html>";
                            _userMasterViewModel.UserMasterDTO.IsMailSentForLoginReset = SendEmail(model.EmailID, "Reset Previous Session", body, System.Configuration.ConfigurationManager.AppSettings["SendEmailID"], System.Configuration.ConfigurationManager.AppSettings["SendPassword"]);

                        }
                        else 
                        {
                            _userMasterViewModel.UserMasterDTO.ID = response.Entity.ID;
                            _userMasterViewModel.UserMasterDTO.EmailID = response.Entity.EmailID;
                            _userMasterViewModel.UserMasterDTO.Password = response.Entity.Password;
                            _userMasterViewModel.UserMasterDTO.UserTypeID = response.Entity.UserTypeID;
                            _userMasterViewModel.UserMasterDTO.FirstName = response.Entity.FirstName;
                            _userMasterViewModel.UserMasterDTO.MiddleName = response.Entity.MiddleName;
                            _userMasterViewModel.UserMasterDTO.LastName = response.Entity.LastName;
                            _userMasterViewModel.UserMasterDTO.PersonID = response.Entity.PersonID;
                            _userMasterViewModel.UserMasterDTO.GeneralPOSMasterID = response.Entity.GeneralPOSMasterID;
                            _userMasterViewModel.UserMasterDTO.GeneralCounterMasterID = response.Entity.GeneralCounterMasterID;
                            _userMasterViewModel.UserMasterDTO.GeneralUnitsID = response.Entity.GeneralUnitsID;
                        }
                    }
                    _userMasterViewModel.UserMasterDTO.ErrorCode = response.Entity.ErrorCode;
                    _userMasterViewModel.UserMasterDTO.ErrorMessage = response.Entity.ErrorMessage;
                    _userMasterViewModel.UserMasterDTO.Status = response.Entity.Status;
                    Dictionary<string, object> _dict = new Dictionary<string, object>
                    {
	                {"StatusCode", response.Entity.ErrorCode},
	                {"Message", response.Entity.ErrorMessage},
	                {"Login", response.Entity}};
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
        public object Logout(UserMasterViewModel model)
        {
            try
            {
                UserMasterViewModel _userMasterViewModel = new UserMasterViewModel();
                if (model != null)
                {
                    _userMasterViewModel.UserMasterDTO = new UserMaster();
                    _userMasterViewModel.UserMasterDTO.ID = model.ID;
                    _userMasterViewModel.UserMasterDTO.GeneralCounterMasterID = model.GeneralCounterMasterID;
                    _userMasterViewModel.UserMasterDTO.GeneralPOSMasterID = model.GeneralPOSMasterID;
                    _userMasterViewModel.UserMasterDTO.LogoutType = model.LogoutType;
                    _userMasterViewModel.UserMasterDTO.DeviceToken = model.DeviceToken;
                    _userMasterViewModel.UserMasterDTO.ConnectionString = _connectioString;
                    IBaseEntityResponse<UserMaster> response = _userMasterServiceAcess.UserLogoutApi(_userMasterViewModel.UserMasterDTO);
                    
                    _userMasterViewModel.UserMasterDTO.ErrorCode = response.Entity.ErrorCode;
                    _userMasterViewModel.UserMasterDTO.ErrorMessage = response.Entity.ErrorMessage;
                    _userMasterViewModel.UserMasterDTO.Status = response.Entity.Status;
                    Dictionary<string, object> _dict = new Dictionary<string, object>
                    {
	                {"StatusCode", response.Entity.ErrorCode},
	                {"Message", response.Entity.ErrorMessage},
	                {"Login", ""}};
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

        
        // GET api/userlogin
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/userlogin/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/userlogin
        public void Post([FromBody]string value)
        {
        }

        // PUT api/userlogin/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/userlogin/5
        public void Delete(int id)
        {
        }
    }
}
