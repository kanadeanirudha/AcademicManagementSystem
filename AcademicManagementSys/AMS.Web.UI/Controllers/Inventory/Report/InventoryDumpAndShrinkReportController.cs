using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using System.Linq;

using AMS.Base.DTO;
using AMS.DTO;
using AMS.ServiceAccess;
using AMS.ExceptionManager;
using AMS.ViewModel;
using AMS.Common;
using AMS.DataProvider;
using System.Configuration;
using System.Xml;

namespace AMS.Web.UI.Controllers
{
    public class InventoryDumpAndShrinkReportController : BaseController
    {
        #region ------------CONTROLLER CLASS VARIABLE------------

        IInventoryReportMasterServiceAccess _inventoryReportMasterServiceAccess = null;
        IInventoryIssueMasterAndIssueDetailsServiceAccess _inventoryIssueMasterAndIssueDetailsServiceAccess = null;
        private readonly ILogger _logException;
        protected static int _balanesheetMstID;
        protected static string _locationListXml = string.Empty;
        protected static string _fromDate = string.Empty;
        protected static string _uptoDate = string.Empty;
        protected static int _locationID;
        ActionModeEnum actionModeEnum;

        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"].ConnectionString);

        #endregion

        #region ------------CONTROLLER CLASS CONSTRUCTOR------------
        public InventoryDumpAndShrinkReportController()
        {
            _inventoryReportMasterServiceAccess = new InventoryReportMasterServiceAccess();
            _inventoryIssueMasterAndIssueDetailsServiceAccess = new InventoryIssueMasterAndIssueDetailsServiceAccess();
        }
        #endregion

        
        #region ------------CONTROLLER ACTION METHODS for RDLC Report------------

        public ActionResult Index()
        {
            InventoryReportMasterViewModel model = new InventoryReportMasterViewModel();

            //---------------------------For Inventory Location List-------------------------//
            List<InventoryLocationMaster> inventoryLocationList = GetInventoryIssueLocationMasterList(Convert.ToInt32(Session["BalancesheetID"]));
            model.ListInventoryLocationMaster = inventoryLocationList;
            //model.ListInventoryDumpAndShrink = List<SelectListItem>();

            //List<SelectListItem> listInventoryLocationMaster = new List<SelectListItem>();
            //foreach (InventoryLocationMaster location in inventoryLocationList)
            //{
            //    listInventoryLocationMaster.Add(new SelectListItem { Text = location.LocationName, Value = Convert.ToString(location.ID) });
            //}
            //ViewBag.InventoryLocationMasterList = new SelectList(listInventoryLocationMaster, "Value", "Text");
            model.InventoryReportMasterDTO.AccountBalsheetMstID = Convert.ToInt32(Session["BalancesheetID"]);

            return View("/Views/Inventory/Report/DumpAndShrinkReport/Index.cshtml", model);
        }

        [HttpPost]
        public ActionResult Index(InventoryReportMasterViewModel model)
        {
            try
            {
                List<InventoryLocationMaster> inventoryLocationList = GetInventoryIssueLocationMasterList(Convert.ToInt32(Session["BalancesheetID"]));
                string xpath = "rows/row/LocationID";
                string emptypath = "<rows><row><ID>0</ID><LocationID></LocationID></row></rows>";
                XmlDocument xmlSelectedLocationIDs = new XmlDocument();

                if (model.IsPosted == true)
                {
                    xmlSelectedLocationIDs.LoadXml(!string.IsNullOrEmpty(model.LocationNameListXml) ? model.LocationNameListXml : emptypath);
                    var LocationXmlNodes = xmlSelectedLocationIDs.SelectNodes(xpath);

                    foreach (var location in inventoryLocationList)
                    {
                        InventoryLocationMaster list = new InventoryLocationMaster();
                        list.ID = location.ID;
                        list.LocationName = location.LocationName;
                        foreach (XmlNode childrenNode in LocationXmlNodes)
                        {
                            if (location.ID == (!string.IsNullOrEmpty(childrenNode.InnerText) ? Convert.ToInt32(childrenNode.InnerText) : 0))
                            {
                                list.IsActive = true;
                                break;
                            }
                        }
                        model.ListInventoryLocationMaster.Add(list);
                    }

                    /// Allocate parameters to local variable
                    _fromDate = model.FromDate;
                    _uptoDate = model.UptoDate;
                    _balanesheetMstID = model.AccountBalsheetMstID;
                    _locationID = model.LocationID;
                    _locationListXml = model.LocationNameListXml;
                    model.IsPosted = false;
                }
                else
                {
                    xmlSelectedLocationIDs.LoadXml(!string.IsNullOrEmpty(model.LocationNameListXml) ? model.LocationNameListXml : emptypath);
                    var LocationXmlNodes = xmlSelectedLocationIDs.SelectNodes(xpath);

                    foreach (var location in inventoryLocationList)
                    {
                        InventoryLocationMaster list = new InventoryLocationMaster();
                        list.ID = location.ID;
                        list.LocationName = location.LocationName;
                        foreach (XmlNode childrenNode in LocationXmlNodes)
                        {
                            if (location.ID == (!string.IsNullOrEmpty(childrenNode.InnerText) ? Convert.ToInt32(childrenNode.InnerText) : 0))
                            {
                                list.IsActive = true;
                                break;
                            }
                        }
                        model.ListInventoryLocationMaster.Add(list);
                    }

                    /// Allocate value from local variable to model properties 
                    model.FromDate = _fromDate;
                    model.UptoDate = _uptoDate;
                    model.AccountBalsheetMstID = _balanesheetMstID;
                    model.LocationID = _locationID;
                    model.LocationNameListXml = _locationListXml;
                }
                //Code for Html Report
                if (System.Configuration.ConfigurationManager.AppSettings["IsInventoryHtmlReports"] == "1")
                {
                    if (model.FromDate != null && model.UptoDate != null && model.LocationNameListXml != null)
                    {
                        model.ListInventoryDumpAndShrink = GetDumpAndShrinkReportData();
                        model.ListInventoryReportHeader = GetReportHeader();
                    }                    
                }

                return View("/Views/Inventory/Report/DumpAndShrinkReport/Index.cshtml", model);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }


        #endregion


        #region ------------CONTROLLER NON ACTION METHODS------------

        public List<OrganisationStudyCentreMaster> GetReportHeader()
        {
            List<OrganisationStudyCentreMaster> listOrganisationStudyCentreMaster = new List<OrganisationStudyCentreMaster>();
            listOrganisationStudyCentreMaster = GetStudyCentreDetailsForReports(string.Empty, _balanesheetMstID);
            return listOrganisationStudyCentreMaster;
        }

        public List<InventoryReportMaster> GetDumpAndShrinkReportData()
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
                    searchRequest.LocationID = _locationID;
                    searchRequest.LocationNameListXml = _locationListXml;

                    IBaseEntityCollectionResponse<InventoryReportMaster> response = _inventoryReportMasterServiceAccess.GetDumpAndShrinkReportBySearch(searchRequest);
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

        [NonAction]
        protected List<InventoryLocationMaster> GetInventoryIssueLocationMasterList(int balancesheet)
        {
            InventoryLocationMasterSearchRequest searchRequest = new InventoryLocationMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.AccBalanceSheetID = Convert.ToInt16(balancesheet);
            List<InventoryLocationMaster> listLocationMaster = new List<InventoryLocationMaster>();
            IBaseEntityCollectionResponse<InventoryLocationMaster> baseEntityCollectionResponse = _inventoryIssueMasterAndIssueDetailsServiceAccess.GetInventoryIssueLocationMasterList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listLocationMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listLocationMaster;
        }
        #endregion


    }
}
