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
    public class POSCounterController : BaseApiController
    {
        private readonly ILogger _logException;
        IPOSCounterServiceAccess _POSCounterServiceAccess = null;

        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
        public POSCounterController()
        {
            _POSCounterServiceAccess = new POSCounterServiceAccess();
        }

        [HttpPost]
        [AllowAnonymous]
        public object GeneralCounterPOSApplicable(POSCounterViewModel model)
        {
            try
            {
                POSCounterSearchRequest searchRequest = new POSCounterSearchRequest();

                searchRequest.DeviceToken = model.DeviceToken;
                searchRequest.LastSyncDate = model.LastSyncDate;
                searchRequest.ConnectionString = _connectioString;
                IBaseEntityCollectionResponse<POSCounter> baseEntityCollectionResponse = _POSCounterServiceAccess.GeneralCounterPOSApplicableGetOnline(searchRequest);
                List<POSCounter> GeneralCounterPOSApplicableList = new List<POSCounter>();
                if (baseEntityCollectionResponse != null)
                {
                    if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                    {
                        GeneralCounterPOSApplicableList = baseEntityCollectionResponse.CollectionResponse.ToList();
                    }
                }

                Dictionary<string, object> _dict = new Dictionary<string, object>
                    {
	                {"StatusCode", "200"},
	                {"Message", "Counter POS Applicable is retrived successfully."},
	                {"GeneralCounterPOSApplicable", GeneralCounterPOSApplicableList}};
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
        public object UserMasterForPOS(POSCounterViewModel model)
        {
            try
            {
                POSCounterSearchRequest searchRequest = new POSCounterSearchRequest();

                searchRequest.DeviceToken = model.DeviceToken;
                searchRequest.LastSyncDate = model.LastSyncDate;
                searchRequest.ConnectionString = _connectioString;
                IBaseEntityCollectionResponse<POSCounter> baseEntityCollectionResponse = _POSCounterServiceAccess.UserMasterGetOnlineForPOS(searchRequest);
                List<POSCounter> UserMasterForPOSList = new List<POSCounter>();
                if (baseEntityCollectionResponse != null)
                {
                    if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                    {
                        UserMasterForPOSList = baseEntityCollectionResponse.CollectionResponse.ToList();
                    }
                }

                Dictionary<string, object> _dict = new Dictionary<string, object>
                    {
	                {"StatusCode", "200"},
	                {"Message", "User Master is retrived successfully."},
	                {"UserMasterForPOS", UserMasterForPOSList}};
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
        public object InventoryPOSSelfAssign(POSCounterViewModel model)
        {
            try
            {
                POSCounterViewModel _POSCounterViewModel = new POSCounterViewModel();
                var dictionary = new object();
                if (ModelState.IsValid && model != null)
                {
                    _POSCounterViewModel.POSCounterDTO = new POSCounter();

                    _POSCounterViewModel.POSCounterDTO.DeviceToken = model.DeviceToken;
                    _POSCounterViewModel.POSCounterDTO.InventoryPOSSelfAssignXML = model.InventoryPOSSelfAssignXML;
                    _POSCounterViewModel.POSCounterDTO.ConnectionString = _connectioString;
                    IBaseEntityResponse<POSCounter> response = _POSCounterServiceAccess.InventoryPOSSelfAssignPostOnline(_POSCounterViewModel.POSCounterDTO);
                    //dictionary = (IDictionary<string, object>)response;  
                    Dictionary<string, object> _dict = new Dictionary<string, object>
                    {
	                {"StatusCode", response.Entity.Status},
	                {"Message", response.Entity.ErrorMessage},
	                {"InventoryPOSSelfAssign", ""}};
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
        public object CounterLog(POSCounterViewModel model)
        {
            try
            {
                POSCounterViewModel _POSCounterViewModel = new POSCounterViewModel();

                var dictionary = new object();
                if (ModelState.IsValid && model != null)
                {
                    _POSCounterViewModel.POSCounterDTO = new POSCounter();
                    _POSCounterViewModel.POSCounterDTO.DeviceToken = model.DeviceToken;
                    _POSCounterViewModel.POSCounterDTO.InventoryCounterLogXML = model.InventoryCounterLogXML;
                    _POSCounterViewModel.POSCounterDTO.ConnectionString = _connectioString;
                    IBaseEntityResponse<POSCounter> response = _POSCounterServiceAccess.CounterLogPostOnline(_POSCounterViewModel.POSCounterDTO);
                    Dictionary<string, object> _dict = new Dictionary<string, object>
                    {
	                {"StatusCode", response.Entity.Status},
	                {"Message", response.Entity.ErrorMessage},
	                {"CounterLog", ""}};
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
        public object UserLog(POSCounterViewModel model)
        {
            try
            {
                POSCounterViewModel _POSCounterViewModel = new POSCounterViewModel();

                var dictionary = new object();
                if (ModelState.IsValid && model != null)
                {
                    _POSCounterViewModel.POSCounterDTO = new POSCounter();
                    _POSCounterViewModel.POSCounterDTO.DeviceToken = model.DeviceToken;
                    _POSCounterViewModel.POSCounterDTO.UserLogXML = model.UserLogXML;
                    _POSCounterViewModel.POSCounterDTO.ConnectionString = _connectioString;
                    IBaseEntityResponse<POSCounter> response = _POSCounterServiceAccess.UserLogPostOnline(_POSCounterViewModel.POSCounterDTO);
                    Dictionary<string, object> _dict = new Dictionary<string, object>
                    {
	                {"StatusCode", response.Entity.Status},
	                {"Message", response.Entity.ErrorMessage},
	                {"UserLog", ""}};
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
        public object UserLogs(POSCounterViewModel model)
        {
            try
            {
                POSCounterViewModel _POSCounterViewModel = new POSCounterViewModel();

                var dictionary = new object();
                if (ModelState.IsValid && model != null)
                {
                    _POSCounterViewModel.POSCounterDTO = new POSCounter();
                    _POSCounterViewModel.POSCounterDTO.DeviceToken = model.DeviceToken;
                    _POSCounterViewModel.POSCounterDTO.UserLogsXML = model.UserLogsXML;
                    _POSCounterViewModel.POSCounterDTO.ConnectionString = _connectioString;
                    IBaseEntityResponse<POSCounter> response = _POSCounterServiceAccess.UserLogsPostOnline(_POSCounterViewModel.POSCounterDTO);
                    Dictionary<string, object> _dict = new Dictionary<string, object>
                    {
	                {"StatusCode", response.Entity.Status},
	                {"Message", response.Entity.ErrorMessage},
	                {"UserLogs", ""}};
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
