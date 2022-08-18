using AMS.Base.DTO;
using AMS.DTO;
using AMS.ServiceAccess;
using AMS.ExceptionManager;
using AMS.ViewModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web.Mvc;
using AMS.Common;
using AMS.DataProvider;
namespace AMS.Web.UI.Controllers
{
    public class InventoryDayEndJobController : BaseController
    {
        IInventoryDayEndJobServiceAccess _InventoryDayEndJobServiceAcess = null;
        private readonly ILogger _logException;
        ActionModeEnum actionModeEnum;
        string _actionMode = string.Empty;
        string _sortBy = string.Empty;
        string _searchBy = string.Empty;
        string _sortDirection = string.Empty;
        int _startRow;
        int _rowLength;
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

        public InventoryDayEndJobController()
        {
            _InventoryDayEndJobServiceAcess = new InventoryDayEndJobServiceAccess();
        }

        // Controller Methods
        #region Controller Methods

        public JsonResult GetDayEndJob(Int16 balancesheetID)
        {
            try
            {
                //Thread.Sleep(10000);
                IInventoryDayEndJobViewModel model = new InventoryDayEndJobViewModel();
                model.InventoryDayEndJobDTO.ConnectionString = _connectioString;
                model.InventoryDayEndJobDTO.AccBalsheetMstID = balancesheetID;
                model.InventoryDayEndJobDTO.Timezone = GetTimeZone(balancesheetID);
                //model.SyncDTO.SyncType = "InventorySync";
                model.InventoryDayEndJobDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                IBaseEntityResponse<InventoryDayEndJob> response = _InventoryDayEndJobServiceAcess.GetDayEndJob(model.InventoryDayEndJobDTO);
                if (response.Entity.ErrorCode == 18)
                {
                    model.InventoryDayEndJobDTO.errorMessage = string.Concat(Resources.Message_OpeningBalanceAlreadyExist, ",#F5CCCC");
                }
                else
                {
                    model.InventoryDayEndJobDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.FiredJob);
                }
                return Json(model.InventoryDayEndJobDTO.errorMessage, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                //_logException.Error(ex.Message);
                return Json(string.Concat(Resources.Message_UnexpectedErrorOccured, ",#F5CCCC"), JsonRequestBehavior.AllowGet);
            }
        }
        protected string GetTimeZone(Int16 balancesheetID)
        {
            try
            {
                IInventoryDayEndJobViewModel model = new InventoryDayEndJobViewModel();
                model.InventoryDayEndJobDTO = new InventoryDayEndJob();
                model.InventoryDayEndJobDTO.AccBalsheetMstID = balancesheetID;
                model.InventoryDayEndJobDTO.ConnectionString = _connectioString;
                IBaseEntityResponse<InventoryDayEndJob> response = _InventoryDayEndJobServiceAcess.GetTimeZone(model.InventoryDayEndJobDTO);
                return (response != null && response.Entity != null) ? response.Entity.Timezone : string.Empty;
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