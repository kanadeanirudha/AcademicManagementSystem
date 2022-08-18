using AMS.Base.DTO;
using System.Net;
using AMS.DTO;
using AMS.ServiceAccess;
using AMS.ExceptionManager;
using AMS.ViewModel;
using System.Threading;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web.Mvc;
using AMS.Common;
using AMS.DataProvider;
namespace AMS.Web.UI.Controllers
{
    public class SyncController : BaseController
    {
        ISyncServiceAccess _syncServiceAcess = null;
        private readonly ILogger _logException;
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
        public SyncController()
        {
            _syncServiceAcess = new SyncServiceAccess();
        }

        #region Controller  Methods
        
        public bool CheckLoginUser()
        {
            try
            {
                ISyncViewModel model = new SyncViewModel();
                model.SyncDTO = new Sync();
                model.SyncDTO.ConnectionString = _connectioString;
                IBaseEntityResponse<Sync> response = _syncServiceAcess.CheckLoggedInUserCount(model.SyncDTO);
                if (response != null && response.Entity != null)
                {
                    model.SyncDTO.IsValidUserCount = response.Entity.IsValidUserCount;
                }
                return model.SyncDTO.IsValidUserCount;        
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        public JsonResult SyncInventoryData(int balancesheetID) 
        {
            try
            {
                //Thread.Sleep(10000);
                ISyncViewModel model = new SyncViewModel();
                model.SyncDTO.ConnectionString = _connectioString;
                model.SyncDTO.BalancesheetID = balancesheetID;
                model.SyncDTO.LastSyncDate = GetLastSyncDate("InventorySync");
                model.SyncDTO.SyncType = "InventorySync";
                model.SyncDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                IBaseEntityResponse<Sync> response = _syncServiceAcess.InventorySyncProcess(model.SyncDTO);
                if (response.Entity.ErrorCode == 30)
                {
                    model.SyncDTO.errorMessage = string.Concat(Resources.Message_SyncProcessAborted, ",#F5CCCC");
                }
                else { 
                model.SyncDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Sync);
                }
                return Json(model.SyncDTO.errorMessage,JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                //_logException.Error(ex.Message);
                return Json(string.Concat(Resources.Message_SyncProcessAborted,",#F5CCCC"), JsonRequestBehavior.AllowGet);
            }
        }
        
        public  bool CheckForInternetConnection()
        {
            try
            {
                using (var client = new WebClient())
                {
                    using (var stream = client.OpenRead("http://www.google.com"))
                    {
                        return true;
                    }
                }
            }
            catch
            {
                return false;
            }
        }
       
        protected string GetLastSyncDate(string syncType)
        {
            try
            {
                 ISyncViewModel model = new SyncViewModel();
                 model.SyncDTO = new Sync();
                 model.SyncDTO.SyncType = syncType;
                 model.SyncDTO.ConnectionString = _connectioString;
                 IBaseEntityResponse<Sync> response = _syncServiceAcess.GetLastSyncDate(model.SyncDTO);
                 return (response != null && response.Entity != null) ? response.Entity.LastSyncDate : string.Empty;
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }
       
        #endregion




    }
}