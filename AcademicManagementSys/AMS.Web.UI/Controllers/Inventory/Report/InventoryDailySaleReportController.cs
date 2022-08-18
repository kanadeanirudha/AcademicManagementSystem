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
    public class InventoryDailySaleReportController : BaseController
    {
        #region ------------CONTROLLER CLASS VARIABLE------------
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
        IInventoryDailySaleReportServiceAccess _InventoryDailySaleReportServiceAccess = null;
        private readonly ILogger _logException;
        protected static string _uptoDate = string.Empty;
        protected string _centreCode = string.Empty;
        protected static string _fromDate = string.Empty;
        protected static int _balanesheetMstID;
        #endregion

        #region ------------CONTROLLER CLASS CONSTRUCTOR------------
        public InventoryDailySaleReportController()
        {
            _InventoryDailySaleReportServiceAccess = new InventoryDailySaleReportServiceAccess();
        }
        #endregion

        #region ------------CONTROLLER ACTION METHODS------------
        public ActionResult Index()
        {
            InventoryDailySaleReportViewModel model = new InventoryDailySaleReportViewModel();
            return View("/Views/Inventory/Report/InventoryDailySaleReport/Index.cshtml", model);
        }
        [HttpPost]
        public ActionResult Index(InventoryDailySaleReportViewModel model)
        {
            if (model.IsPosted == true)
            {
                _balanesheetMstID = model.BalanceSheetID;
                _fromDate = model.FromDate;
                _uptoDate = model.UptoDate;
                model.IsPosted = false;
            }
            else
            {
               model.BalanceSheetID = _balanesheetMstID ;
               model.FromDate = _fromDate ;
               model.UptoDate =_uptoDate;
            }
            //Code for Html Report
            if (System.Configuration.ConfigurationManager.AppSettings["IsInventoryHtmlReports"] == "1")
            {
                if (model.FromDate != null && model.UptoDate != null)
                {
                    List<InventoryDailySaleReport> saleRepot = GetInventoryDailySaleReport();
                    model.ListInventoryDailySaleReport = saleRepot.OrderBy(x=>x.TransactionDate).ToList();
                    model.ListInventoryReportHeader = GetReportHeader();
                }
            }
            return View("/Views/Inventory/Report/InventoryDailySaleReport/Index.cshtml", model);
        }
        #endregion

        #region ------------CONTROLLER NON ACTION METHODS------------

        public List<OrganisationStudyCentreMaster> GetReportHeader()
        {
            List<OrganisationStudyCentreMaster> listOrganisationStudyCentreMaster = new List<OrganisationStudyCentreMaster>();
            listOrganisationStudyCentreMaster = GetStudyCentreDetailsForReports(string.Empty, _balanesheetMstID);
            return listOrganisationStudyCentreMaster;
        }

        public List<InventoryDailySaleReport> GetInventoryDailySaleReport()
        {
            try
            {
                List<InventoryDailySaleReport> listInventoryDailySaleReport = new List<InventoryDailySaleReport>();
                InventoryDailySaleReportSearchRequest searchRequest = new InventoryDailySaleReportSearchRequest();
                searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
                searchRequest.FromDate = _fromDate;
                searchRequest.UptoDate = _uptoDate;
                searchRequest.BalanceSheetID = _balanesheetMstID;
                IBaseEntityCollectionResponse<InventoryDailySaleReport> baseEntityCollectionResponse = _InventoryDailySaleReportServiceAccess.GetBySearch(searchRequest);
                if (baseEntityCollectionResponse != null)
                {
                    if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                    {
                        listInventoryDailySaleReport = baseEntityCollectionResponse.CollectionResponse.ToList();
                    }
                }
                return listInventoryDailySaleReport;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                //_headID = 0;
                //_categoryID = 0;
                //_groupID = 0;
                //   _balanesheetMstID = 0;
            }

        }
        #endregion



    }
}
