using AMS.Base.DTO;
using AMS.ExceptionManager;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web.Http;
using AMS.DTO;
using AMS.ViewModel;
using AMS.ServiceAccess;
namespace AMS.Web.UI.Controllers.API
{
    public class UserMasterAPIController : BaseApiController
    {
        private readonly ILogger _logException;
        IUserMasterAPIServiceAccess _UserMasterAPIServiceAccess = null;
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
        public UserMasterAPIController()
        {
            _UserMasterAPIServiceAccess = new UserMasterAPIServiceAccess();
        }
        [HttpPost]
        [AllowAnonymous]
        public object GetUserMaster(UserMasterAPIViewModel model)
        {
            try
            {
                UserMasterAPISearchRequest searchRequest = new UserMasterAPISearchRequest();
                searchRequest.ConnectionString = _connectioString;
                searchRequest.LastSyncDate = model.LastSyncDate;
                searchRequest.DeviceCode = model.DeviceCode;
                IBaseEntityCollectionResponse<UserMasterAPI> baseEntityCollectionResponse = _UserMasterAPIServiceAccess.GetUserMasterAPI(searchRequest);
                List<UserMasterAPI> UserMasterAPIList = new List<UserMasterAPI>();
                if (baseEntityCollectionResponse != null)
                {
                    if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                    {
                        UserMasterAPIList = baseEntityCollectionResponse.CollectionResponse.ToList();
                    }
                }

                Dictionary<string, object> _dict = new Dictionary<string, object>
               {
                    {"StatusCode", "200"},
                    {"Message", "User List retrived successfully."},
                    {"Data", UserMasterAPIList}};
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
        public object PostUserLogAndLogsData(UserMasterAPIViewModel model)
        {
            try
            {
                UserMasterAPIViewModel _UserMasterAPIViewModel = new UserMasterAPIViewModel();
                var dictionary = new object();
                if (ModelState.IsValid && model != null)
                {
                    _UserMasterAPIViewModel.UserMasterAPIDTO = new UserMasterAPI();
                    _UserMasterAPIViewModel.UserMasterAPIDTO.UserLogsXML = model.UserLogsXML;
                    _UserMasterAPIViewModel.UserMasterAPIDTO.UserLogXML = model.UserLogXML;
                    _UserMasterAPIViewModel.UserMasterAPIDTO.ConnectionString = _connectioString;
                    IBaseEntityResponse<UserMasterAPI> response = _UserMasterAPIServiceAccess.PostUserLogAndLogsData(_UserMasterAPIViewModel.UserMasterAPIDTO);

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
        public object GetAcccountSessionMaster(UserMasterAPIViewModel model)
        {
            try
            {
                UserMasterAPISearchRequest searchRequest = new UserMasterAPISearchRequest();
                searchRequest.ConnectionString = _connectioString;
                searchRequest.LastSyncDate = model.LastSyncDate;
                IBaseEntityCollectionResponse<UserMasterAPI> baseEntityCollectionResponse = _UserMasterAPIServiceAccess.GetAccountSessionMaster(searchRequest);
                List<UserMasterAPI> UserMasterAPIList = new List<UserMasterAPI>();
                if (baseEntityCollectionResponse != null)
                {
                    if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                    {
                        UserMasterAPIList = baseEntityCollectionResponse.CollectionResponse.ToList();
                    }
                }

                Dictionary<string, object> _dict = new Dictionary<string, object>
               {
                    {"StatusCode", "200"},
                    {"Message", "Account session List retrived successfully."},
                    {"Data", UserMasterAPIList}};
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
