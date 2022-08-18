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
    public class InventoryItemwiseConsumptionReportController : BaseController
    {
        #region ------------CONTROLLER CLASS VARIABLE------------

        IInventoryReportMasterServiceAccess _inventoryReportMasterServiceAccess = null;
        private readonly ILogger _logException;
        protected static int _balanesheetMstID;
        protected static string _itemListXml = string.Empty;
        protected static string _fromDate = string.Empty;
        protected static string _uptoDate = string.Empty;
        ActionModeEnum actionModeEnum;

        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"].ConnectionString);

        #endregion


        #region ------------CONTROLLER CLASS CONSTRUCTOR------------
        public InventoryItemwiseConsumptionReportController()
        {
            _inventoryReportMasterServiceAccess = new InventoryReportMasterServiceAccess();
        }
        #endregion

        #region ------------CONTROLLER ACTION METHODS------------

        public ActionResult Index()
        {
            InventoryReportMasterViewModel model = new InventoryReportMasterViewModel();

            //---------------------------For Inventory Item List-------------------------//
            List<InventoryItemMaster> itemMasterList = GetInventoryItemMasterList();
            model.ListInventoryItemMaster = itemMasterList;
            model.InventoryReportMasterDTO.AccountBalsheetMstID = Convert.ToInt32(Session["BalancesheetID"]); ;
            return View("/Views/Inventory/Report/ItemWiseConsumptionReport/Index.cshtml", model);
        }


        [HttpPost]
        public ActionResult Index(InventoryReportMasterViewModel model)
        {
            try
            {
                List<InventoryItemMaster> itemMasterList = GetInventoryItemMasterList();
                string xpath = "rows/row/ID";
                string emptypath = "<rows><row><ID></ID></row></rows>";
                XmlDocument xmlSelectedItemMasterIDs = new XmlDocument();
                if (model.IsPosted == true)
                {
                    xmlSelectedItemMasterIDs.LoadXml(!string.IsNullOrEmpty(model.ItemNameListXml) ? model.ItemNameListXml : emptypath);
                    var ItemXmlNodes = xmlSelectedItemMasterIDs.SelectNodes(xpath);
                    foreach (var item in itemMasterList)
                    {
                        InventoryItemMaster list = new InventoryItemMaster();
                        list.ID = item.ID;
                        list.ItemName = item.ItemName;
                        foreach (XmlNode childrenNode in ItemXmlNodes)
                        {
                            if (item.ID == (!string.IsNullOrEmpty(childrenNode.InnerText) ? Convert.ToInt32(childrenNode.InnerText) : 0))
                            {
                                list.IsActive = true;
                                break;
                            }
                        }
                        model.ListInventoryItemMaster.Add(list);
                    }
                    /// Allocate parameters to local variable
                    _fromDate = model.FromDate;
                    _uptoDate = model.UptoDate;
                    _balanesheetMstID = model.AccountBalsheetMstID;
                    _itemListXml = model.ItemNameListXml;
                    model.IsPosted = false;
                }
                else
                {
                    xmlSelectedItemMasterIDs.LoadXml(!string.IsNullOrEmpty(_itemListXml) ? _itemListXml : emptypath);
                    var ItemXmlNodes = xmlSelectedItemMasterIDs.SelectNodes(xpath);
                    foreach (var item in itemMasterList)
                    {
                        InventoryItemMaster list = new InventoryItemMaster();
                        list.ID = item.ID;
                        list.ItemName = item.ItemName;
                        foreach (XmlNode childrenNode in ItemXmlNodes)
                        {
                            if (item.ID == (!string.IsNullOrEmpty(childrenNode.InnerText) ? Convert.ToInt32(childrenNode.InnerText) : 0))
                            {
                                list.IsActive = true;
                                break;
                            }
                        }
                        model.ListInventoryItemMaster.Add(list);
                    }

                    /// Allocate value from local variable to model properties 
                    model.FromDate = _fromDate;
                    model.UptoDate = _uptoDate;
                    model.AccountBalsheetMstID = _balanesheetMstID;
                    model.ItemNameListXml = _itemListXml;
                }

                //Code for Html Report
                if (System.Configuration.ConfigurationManager.AppSettings["IsInventoryHtmlReports"] == "1")
                {
                    if (model.FromDate != null && model.UptoDate != null && model.ItemNameListXml != null)
                    {
                        model.ListInventoryItemwiseConsumptionReport = GetItemwiseConsumptionData();
                        model.ListInventoryReportHeader = GetReportHeader();
                    }
                }

                return View("/Views/Inventory/Report/ItemWiseConsumptionReport/Index.cshtml", model);
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

        public List<InventoryReportMaster> GetItemwiseConsumptionData()
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
                    searchRequest.ItemNameListXml = _itemListXml;
                    IBaseEntityCollectionResponse<InventoryReportMaster> response = _inventoryReportMasterServiceAccess.GetItemWiseConsumptionBySearch(searchRequest);
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
