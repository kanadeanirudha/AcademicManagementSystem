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
    public class InventoryBelowIndentLevelController : BaseController
    {
        #region ------------CONTROLLER CLASS VARIABLE------------

        IInventoryReportMasterServiceAccess _inventoryReportMasterServiceAccess = null;
        IInventoryIssueMasterAndIssueDetailsServiceAccess _inventoryIssueMasterAndIssueDetailsServiceAccess = null;
        private readonly ILogger _logException;
        protected static int _balanesheetMstID;
        protected static string _locationListXml = string.Empty;

        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"].ConnectionString);

        #endregion

        #region ------------CONTROLLER CLASS CONSTRUCTOR------------
        public InventoryBelowIndentLevelController()
        {
            _inventoryReportMasterServiceAccess = new InventoryReportMasterServiceAccess();
            _inventoryIssueMasterAndIssueDetailsServiceAccess = new InventoryIssueMasterAndIssueDetailsServiceAccess();
        }
        #endregion

        #region ------------CONTROLLER ACTION METHODS------------

        public ActionResult Index()
        {
            InventoryReportMasterViewModel model = new InventoryReportMasterViewModel();

            List<InventoryLocationMaster> inventoryLocationList = GetBelowIndendLevelLocationMasterList(Convert.ToInt32(Session["BalancesheetID"]));
            model.ListInventoryLocationMaster = inventoryLocationList;
            model.InventoryReportMasterDTO.AccountBalsheetMstID = Convert.ToInt32(Session["BalancesheetID"]);
            
            return View("/Views/Inventory/Report/BelowIndentLevelReport/Index.cshtml", model);
        }


        [HttpPost]
        public ActionResult Index(InventoryReportMasterViewModel model)
        {
            try
            {
                List<InventoryLocationMaster> inventoryLocationList = GetBelowIndendLevelLocationMasterList(Convert.ToInt32(Session["BalancesheetID"]));
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

                    _balanesheetMstID = model.AccountBalsheetMstID;
                    _locationListXml = model.LocationNameListXml;
                    model.IsPosted = false;
                }
                else
                {
                    xmlSelectedLocationIDs.LoadXml(!string.IsNullOrEmpty(_locationListXml) ? _locationListXml : emptypath);
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

                    model.AccountBalsheetMstID = _balanesheetMstID;
                    model.LocationNameListXml = _locationListXml;
                }
                //Code for Html Report
                if (System.Configuration.ConfigurationManager.AppSettings["IsInventoryHtmlReports"] == "1")
                {
                    if (model.LocationNameListXml != null)
                    {
                        model.ListInventoryBelowIndentReport = GetBelowIndendLevelReportData();
                        model.ListInventoryReportHeader = GetReportHeader();
                    }
                }
                return View("/Views/Inventory/Report/BelowIndentLevelReport/Index.cshtml", model);
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

        public List<InventoryReportMaster> GetBelowIndendLevelReportData()
        {
            try
            {
                List<InventoryReportMaster> listBelowIndendLevelReport = new List<InventoryReportMaster>();
                if (_balanesheetMstID > 0)
                {
                    InventoryReportMasterSearchRequest searchRequest = new InventoryReportMasterSearchRequest();
                    searchRequest.ConnectionString = _connectioString;
                    searchRequest.AccountBalsheetMstID = _balanesheetMstID;
                    searchRequest.LocationNameListXml = _locationListXml;

                    IBaseEntityCollectionResponse<InventoryReportMaster> response = _inventoryReportMasterServiceAccess.GetBelowIndendLevelReportBySearch(searchRequest);
                    if (response != null)
                    {
                        if (response.CollectionResponse != null && response.CollectionResponse.Count > 0)
                        {
                            listBelowIndendLevelReport = response.CollectionResponse.ToList();
                        }
                    }
                    return listBelowIndendLevelReport;
                }
                else
                {
                    return listBelowIndendLevelReport;
                }
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        [NonAction]
        protected List<InventoryLocationMaster> GetBelowIndendLevelLocationMasterList(int balancesheet)
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
