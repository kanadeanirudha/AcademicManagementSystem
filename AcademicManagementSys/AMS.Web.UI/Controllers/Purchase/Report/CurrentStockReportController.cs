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
    public class CurrentStockReportController : BaseController
    {
        #region ------------CONTROLLER CLASS VARIABLE------------
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
        IPurchaseReportMasterServiceAccess _PurchaseReportMasterServiceAccess = null;
        IGeneralItemMasterServiceAccess _generalItemMasterServiceAccess = null;
        IInventoryLocationMaster_1ServiceAccess _InventoryLocationMaster_1ServiceAccess = null;
        private readonly ILogger _logException;
        protected static string _uptoDate = string.Empty;
        protected string _centreCode = string.Empty;
        protected static string _fromDate = string.Empty;
        protected static int _balanesheetMstID;
        protected static string _locationListXml = string.Empty;
        #endregion

        #region ------------CONTROLLER CLASS CONSTRUCTOR------------
        public CurrentStockReportController()
        {
            _PurchaseReportMasterServiceAccess = new PurchaseReportMasterServiceAccess();
            _generalItemMasterServiceAccess = new GeneralItemMasterServiceAccess();
            _InventoryLocationMaster_1ServiceAccess = new InventoryLocationMaster_1ServiceAccess();

        }
        #endregion

        #region ------------CONTROLLER ACTION METHODS------------
        public ActionResult Index()
        {
             PurchaseReportMasterViewModel model = new PurchaseReportMasterViewModel();
            //---------------------------For Inventory Location List-------------------------//
            int AdminRoleMasterID = 0;
            if (Session["RoleID"] == null)
            {
                AdminRoleMasterID = !string.IsNullOrEmpty(Convert.ToString(Session["DefaultRoleID"])) ? Convert.ToInt32(Session["DefaultRoleID"]) : 0;
            }

            else
            {
                AdminRoleMasterID = !string.IsNullOrEmpty(Convert.ToString(Session["RoleID"])) ? Convert.ToInt32(Session["RoleID"]) : 0;
            }

            List<InventoryLocationMaster_1> inventoryLocationList = GetInventoryLocationMasterList(AdminRoleMasterID);
            model.ListInventoryLocationMaster = inventoryLocationList;
            model.PurchaseReportMasterDTO.BalancesheetID = Convert.ToInt32(Session["BalancesheetID"]);
            return View("/Views/Purchase/Report/CurrentStockReport/Index.cshtml", model);
        }
         
        public ActionResult CurrentStock(PurchaseReportMasterViewModel model)
        {
            //PurchaseReportMasterViewModel model = new PurchaseReportMasterViewModel();
            model.PurchaseReportMasterDTO.BalancesheetID = Convert.ToInt32(Session["BalancesheetID"]);
            model.PurchaseReportMasterDTO.LocationNameListXml = model.LocationNameListXml;
            model.PurchaseReportMasterDTO.ItemNumber = model.ItemNumber;


            model.PurchaseReportMasterDetails = GetCurrentStockReportMaster(model.PurchaseReportMasterDTO.BalancesheetID, model.PurchaseReportMasterDTO.LocationNameListXml, model.PurchaseReportMasterDTO.ItemNumber);
           
            return PartialView("/Views/Purchase/Report/CurrentStockReport/List.cshtml", model);
        }
        #endregion

        #region ------------CONTROLLER NON ACTION METHODS------------

        public List<OrganisationStudyCentreMaster> GetReportHeader()
        {
            List<OrganisationStudyCentreMaster> listOrganisationStudyCentreMaster = new List<OrganisationStudyCentreMaster>();
            listOrganisationStudyCentreMaster = GetStudyCentreDetailsForReports(string.Empty, _balanesheetMstID);
            return listOrganisationStudyCentreMaster;
        }
        [NonAction]
        protected List<InventoryLocationMaster_1> GetInventoryLocationMasterList(int UserID)
        {
            InventoryLocationMaster_1SearchRequest searchRequest = new InventoryLocationMaster_1SearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.UserID = Convert.ToInt32(UserID);
            List<InventoryLocationMaster_1> listLocationMaster = new List<InventoryLocationMaster_1>();
            IBaseEntityCollectionResponse<InventoryLocationMaster_1> baseEntityCollectionResponse = _InventoryLocationMaster_1ServiceAccess.GetInventoryLocationMasterlistCenterCodeWise(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listLocationMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listLocationMaster;
        }
        public List<PurchaseReportMaster> GetCurrentStockReportMaster(int BalncesheetID, string Xmlstring, int ItemNumber)
        {
            try
            {
                List<PurchaseReportMaster> listPurchaseReportMaster = new List<PurchaseReportMaster>();
                PurchaseReportMasterSearchRequest searchRequest = new PurchaseReportMasterSearchRequest();
                searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
                searchRequest.BalancesheetID = BalncesheetID;
                searchRequest.LocationNameListXml = Xmlstring;
                searchRequest.ItemNumber = ItemNumber;
                //searchRequest.UptoDate = _uptoDate;
                //searchRequest.BalanceSheetID = _balanesheetMstID;
                IBaseEntityCollectionResponse<PurchaseReportMaster> baseEntityCollectionResponse = _PurchaseReportMasterServiceAccess.GetLocationWiseCurrentStockReport(searchRequest);
                if (baseEntityCollectionResponse != null)
                {
                    if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                    {
                        listPurchaseReportMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                    }
                }
                return listPurchaseReportMaster;
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
        [HttpPost]
        public JsonResult GetItemSearchList(string term, string StorageLocationID)
        {
            GeneralItemMasterSearchRequest searchRequest = new GeneralItemMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            //   searchRequest.LocationID = Convert.ToInt32(!string.IsNullOrEmpty(StorageLocationID) ? StorageLocationID : null);
            searchRequest.SearchWord = term;
            List<GeneralItemMaster> listFeeSubType = new List<GeneralItemMaster>();
            IBaseEntityCollectionResponse<GeneralItemMaster> baseEntityCollectionResponse = _generalItemMasterServiceAccess.GetGeneralItemMasterSearchListForReport(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listFeeSubType = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            var result = (from r in listFeeSubType
                          select new
                          {
                              itemNumber = r.ItemNumber,
                              //itemDescription = String.Concat(r.ItemDescription, '(', r.UomCode, ')'),
                              itemDescription = r.ItemDescription,
                              barCode = r.BarCode,
                              uomCode = r.UomCode,
                              generalItemCodeID = r.GeneralItemCodeID,
                              id = r.GeneralItemMasterID,
                              orderUomCode = r.OrderUomCode,
                              baseUomCode = r.BaseUOMCode,
                              baseUomQuantity = r.BaseUOMQuantity
                              //  lastPurchasePrice = r.LastPurchasePrice,
                              //  genTaxGroupMasterID = r.GenTaxGroupMasterID,
                              //   PurchaseGroupCode = r.PurchaseGroupCode

                          }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        #endregion



    }
}
