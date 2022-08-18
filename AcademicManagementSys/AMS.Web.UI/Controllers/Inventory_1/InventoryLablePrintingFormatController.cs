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
using AMS.Business.BusinessActions;
namespace AMS.Web.UI.Controllers
{
    public class InventoryLablePrintingFormatController : BaseController
    {
        #region ------------CONTROLLER CLASS VARIABLE------------
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
        IInventoryLablePrintingFormatServiceAccess _InventoryLablePrintingFormatServiceAccess = null;
        IGeneralItemMasterServiceAccess _generalItemMasterServiceAccess = null;
        IGeneralUnitsServiceAccess _GeneralUnitsServiceAccess = null;
        IInventoryUoMMasterServiceAccess _InventoryUoMMasterServiceAccess = null;
        private readonly ILogger _logException;
        protected string _centreCode = string.Empty;
        public string _ReportFor { get; set; }

        #endregion

        #region ------------CONTROLLER CLASS CONSTRUCTOR------------
        public InventoryLablePrintingFormatController()
        {
            _InventoryLablePrintingFormatServiceAccess = new InventoryLablePrintingFormatServiceAccess();
            _generalItemMasterServiceAccess = new GeneralItemMasterServiceAccess();
            _GeneralUnitsServiceAccess = new GeneralUnitsServiceAccess();
            _InventoryUoMMasterServiceAccess = new InventoryUoMMasterServiceAccess();
        }
        #endregion

        #region ------------CONTROLLER ACTION METHODS------------
        public ActionResult Index(string SelectedCentreCode)
        {
            InventoryLablePrintingFormatViewModel model = new InventoryLablePrintingFormatViewModel();

            if (Convert.ToString(Session["UserType"]) == "A")
            {
                List<OrganisationStudyCentreMaster> listAdminRoleApplicableDetails = GetListOrgStudyCentreMaster();
                AdminRoleApplicableDetails a = null;
                foreach (var item in listAdminRoleApplicableDetails)
                {

                    a = new AdminRoleApplicableDetails();
                    a.CentreCode = item.CentreCode + ":Centre";
                    a.CentreName = item.CentreName;
                    // a.ScopeIdentity = item.ScopeIdentity;
                    model.ListGetAdminRoleApplicableCentre.Add(a);

                }
            }
            else
            {
                int AdminRoleMasterID = 0;
                if (Session["RoleID"] == null)
                {
                    AdminRoleMasterID = !string.IsNullOrEmpty(Convert.ToString(Session["DefaultRoleID"])) ? Convert.ToInt32(Session["DefaultRoleID"]) : 0;
                }

                else
                {
                    AdminRoleMasterID = !string.IsNullOrEmpty(Convert.ToString(Session["RoleID"])) ? Convert.ToInt32(Session["RoleID"]) : 0;
                }

                List<AdminRoleApplicableDetails> listAdminRoleApplicableDetails = GetAdminRoleApplicableCentre(AdminRoleMasterID, 0);
                AdminRoleApplicableDetails a = null;
                foreach (var item in listAdminRoleApplicableDetails)
                {
                    a = new AdminRoleApplicableDetails();
                    a.CentreCode = item.CentreCode + ":" + item.ScopeIdentity;
                    a.CentreName = item.CentreName;
                    // a.ScopeIdentity = item.ScopeIdentity;
                    model.ListGetAdminRoleApplicableCentre.Add(a);
                }
            }
            if (!string.IsNullOrEmpty(SelectedCentreCode))
            {
                string[] splitCentreCode = SelectedCentreCode.Split(':');
                model.CentreCode = splitCentreCode[0];
            }


             //********Drop down for Units *********************************//
            List<GeneralUnits> GeneralUnits = GetGeneralUnitsForItemmaster(model.CentreCode);
            List<SelectListItem> GeneralUnitsList = new List<SelectListItem>();
            foreach (GeneralUnits item in GeneralUnits)
            {
                GeneralUnitsList.Add(new SelectListItem { Text = item.UnitName, Value = Convert.ToString(item.ID) });
            }
            ViewBag.GeneralUnitsList = new SelectList(GeneralUnitsList, "Value", "Text");

            //********Drop down for Units *********************************//
            List<InventoryLablePrintingFormat> ItemNumber = GetItemNumberList();
            List<SelectListItem> ItemNumberList = new List<SelectListItem>();
            foreach (InventoryLablePrintingFormat item in ItemNumber)
            {
                ItemNumberList.Add(new SelectListItem { Text = Convert.ToString(item.ItemNumber), Value = Convert.ToString(item.ItemNumber) });
            }
            ViewBag.ItemNumberList = new SelectList(ItemNumberList, "Value", "Text");


            return View("/Views/Inventory_1/InventoryLablePrintingFormat/Index.cshtml", model);
        }
       
        #endregion

        #region ------------CONTROLLER NON ACTION METHODS------------
        [HttpPost]
        public JsonResult GetItemSearchList(string term, string StorageLocationID)
        {
            GeneralItemMasterSearchRequest searchRequest = new GeneralItemMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            //   searchRequest.LocationID = Convert.ToInt32(!string.IsNullOrEmpty(StorageLocationID) ? StorageLocationID : null);
            searchRequest.SearchWord = term;
            List<GeneralItemMaster> listFeeSubType = new List<GeneralItemMaster>();
            IBaseEntityCollectionResponse<GeneralItemMaster> baseEntityCollectionResponse = _generalItemMasterServiceAccess.GetGeneralItemDetailsForSupliersDataSearchList(searchRequest);
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
                              lastPurchasePrice = r.LastPurchasePrice,
                              genTaxGroupMasterID = r.GenTaxGroupMasterID,
                              generalItemCodeID = r.GeneralItemCodeID,
                              id = r.GeneralItemMasterID,
                              PurchaseGroupCode = r.PurchaseGroupCode

                          }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);

        }

        public ActionResult GetSaleUomCodeList(string ItemNumber)
        {

            var SaleUoMCode = GetSaleUomCode(ItemNumber);
            var result = (from s in SaleUoMCode
                          select new
                          {
                              id = s.ID,
                              name = s.UomCode,
                              UoMDescription = s.UoMDescription
                          }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        protected List<GeneralUnits> GetGeneralUnitsForItemmaster(string CentreCode)
        {
            GeneralUnitsSearchRequest searchRequest = new GeneralUnitsSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.CentreCode = CentreCode;
            List<GeneralUnits> ListGeneralUnits = new List<GeneralUnits>();
            IBaseEntityCollectionResponse<GeneralUnits> baseEntityCollectionResponse = _GeneralUnitsServiceAccess.GetGeneralUnitsSearchList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    ListGeneralUnits = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return ListGeneralUnits;
        }

        protected List<InventoryLablePrintingFormat> GetItemNumberList()
        {
            InventoryLablePrintingFormatSearchRequest searchRequest = new InventoryLablePrintingFormatSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            List<InventoryLablePrintingFormat> ListGeneralUnits = new List<InventoryLablePrintingFormat>();
            IBaseEntityCollectionResponse<InventoryLablePrintingFormat> baseEntityCollectionResponse = _InventoryLablePrintingFormatServiceAccess.GetItemNumberList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    ListGeneralUnits = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return ListGeneralUnits;
        }
        protected List<InventoryUoMMaster> GetSaleUomCode(string ItemNumber)
        {
            InventoryUoMMasterSearchRequest searchRequest = new InventoryUoMMasterSearchRequest();

            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.ItemNumber = Convert.ToInt32(!string.IsNullOrEmpty(ItemNumber) ? ItemNumber : null);
            List<InventoryUoMMaster> ListInventoryUoMMasterForSaleUomCode = new List<InventoryUoMMaster>();
            IBaseEntityCollectionResponse<InventoryUoMMaster> baseEntityCollectionResponse = _InventoryUoMMasterServiceAccess.GetInventoryUoMMasterDropDownforSaleUomCode(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    ListInventoryUoMMasterForSaleUomCode = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return ListInventoryUoMMasterForSaleUomCode;
        }

        [HttpGet]
        public ActionResult GetInventoryLablePrintingFormatByGeneralunitsID(string FromItemNumber, string ToItemNumber, string GeneralUnitsID, string SalesUoM)
        {
            List<InventoryLablePrintingFormat> listInventoryLablePrintingFormat = new List<InventoryLablePrintingFormat>();
            InventoryLablePrintingFormatSearchRequest searchRequest = new InventoryLablePrintingFormatSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            //searchRequest.ItemNumber = Convert.ToInt32(ItemNumber);
            searchRequest.ToItemNumber = Convert.ToInt32(ToItemNumber);
            searchRequest.FromItemNumber = Convert.ToInt32(FromItemNumber);

            searchRequest.GeneralUnitsID = Convert.ToInt32(GeneralUnitsID);
            searchRequest.SaleUoM = SalesUoM;
            if (searchRequest.GeneralUnitsID > 0 && searchRequest.GeneralUnitsID > 0)
            {
                IBaseEntityCollectionResponse<InventoryLablePrintingFormat> baseEntityCollectionResponse = _InventoryLablePrintingFormatServiceAccess.GetInventoryLablePrintingFormatByGeneralUnitsID(searchRequest);
                if (baseEntityCollectionResponse != null)
                {
                    if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                    {
                        listInventoryLablePrintingFormat = baseEntityCollectionResponse.CollectionResponse.ToList();
                    }
                }
            }
            return Json(listInventoryLablePrintingFormat, JsonRequestBehavior.AllowGet);
        }

        #endregion
    }
}
