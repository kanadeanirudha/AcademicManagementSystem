
using AMS.Base.DTO;
using AMS.DTO;
using AMS.ServiceAccess;
using AMS.ViewModel;
using System;
using AMS.ExceptionManager;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web.Mvc;
using AMS.Common;
using System.Web.Mvc.Ajax;
using System.IO;

namespace AMS.Web.UI.Controllers
{
    public class InventoryDailyItemRateChangeReportController : BaseController
    {
        #region ------------CONTROLLER CLASS VARIABLE------------
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
        IInventoryReportMasterServiceAccess _inventoryReportMasterServiceAccess = null;
        private readonly ILogger _logException;
        protected static string _uptoDate = string.Empty;
        protected static string _fromDate = string.Empty;
        protected static int _balanesheetMstID;
        #endregion

        #region ------------CONTROLLER CLASS CONSTRUCTOR------------
        public InventoryDailyItemRateChangeReportController()
        {
            _inventoryReportMasterServiceAccess = new InventoryReportMasterServiceAccess();
        }
        #endregion

        #region ------------CONTROLLER ACTION METHODS------------
        public ActionResult Index()
        {
            InventoryReportMasterViewModel model = new InventoryReportMasterViewModel();
            model.InventoryReportMasterDTO.AccountBalsheetMstID = Convert.ToInt32(Session["BalancesheetID"]); ;
            return View("/Views/Inventory/Report/InventoryDailyItemRateChangeReport/Index.cshtml", model);
        }
        [HttpPost]
        public ActionResult Index(InventoryReportMasterViewModel model)
        {
            if (model.IsPosted == true)
            {
                _balanesheetMstID = model.AccountBalsheetMstID;
                _fromDate = model.FromDate;
                _uptoDate = model.UptoDate;
                model.IsPosted = false;
            }
            else
            {
                model.AccountBalsheetMstID = _balanesheetMstID;
               model.FromDate = _fromDate ;
               model.UptoDate =_uptoDate;
            }

            //Code for Html Report
            if (System.Configuration.ConfigurationManager.AppSettings["IsInventoryHtmlReports"] == "1")
            {
                if (model.FromDate != null && model.UptoDate != null)
                {
                    model.ListInventoryDailyItemRateChangeReport = GetInventoryDailyItemRateChange();
                    model.ListInventoryReportHeader = GetReportHeader();
                }
            }
            return View("/Views/Inventory/Report/InventoryDailyItemRateChangeReport/Index.cshtml", model);
        }
        #endregion

        #region ------------CONTROLLER NON ACTION METHODS------------

        public List<OrganisationStudyCentreMaster> GetReportHeader()
        {
            List<OrganisationStudyCentreMaster> listOrganisationStudyCentreMaster = new List<OrganisationStudyCentreMaster>();
            listOrganisationStudyCentreMaster = GetStudyCentreDetailsForReports(string.Empty, _balanesheetMstID);
            return listOrganisationStudyCentreMaster;
        }

        public List<InventoryReportMaster> GetInventoryDailyItemRateChange()
        {
            try
            {
                List<InventoryReportMaster> listItemReport = new List<InventoryReportMaster>();
                if (_balanesheetMstID > 0)
                {
                    InventoryReportMasterSearchRequest searchRequest = new InventoryReportMasterSearchRequest();
                    searchRequest.ConnectionString = _connectioString;
                    searchRequest.AccountBalsheetMstID = _balanesheetMstID;
                    searchRequest.FromDate = _fromDate;
                    searchRequest.UptoDate = _uptoDate;
                    IBaseEntityCollectionResponse<InventoryReportMaster> response = _inventoryReportMasterServiceAccess.GetDailyItemRateChangeReportBySearch(searchRequest);
                    if (response != null)
                    {
                        if (response.CollectionResponse != null && response.CollectionResponse.Count > 0)
                        {
                            listItemReport = response.CollectionResponse.ToList();
                        }
                    }
                    return listItemReport;
                }
                else
                {
                    return listItemReport;
                }
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



