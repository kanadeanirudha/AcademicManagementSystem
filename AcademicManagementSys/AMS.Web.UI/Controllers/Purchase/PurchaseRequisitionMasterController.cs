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
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf.parser;
using System.Web;
using iTextSharp.text.html;
namespace AMS.Web.UI.Controllers
{
    public class PurchaseRequisitionMasterController : BaseController
    {
        IPurchaseRequisitionMasterServiceAccess _PurchaseRequisitionMasterServiceAcess = null;
        IGeneralItemMasterServiceAccess _GeneralItemMasterServiceAcess = null;
        IGeneralItemMasterServiceAccess _generalItemMasterServiceAccess = null;
        IGeneralPolicyRulesServiceAccess _GeneralPolicyRulesServiceAcess = null;
        IInventoryIssueMasterAndIssueDetailsServiceAccess _inventoryIssueMasterAndIssueDetailsServiceAccess = null;
        IGeneralSupplierMasterServiceAccess _IGeneralSupplierMasterServiceAccess = null;
        IOrganisationDepartmentMasterServiceAccess _organisationDepartmentMasterServiceAcess = null;
        IInventoryLocationMaster_1ServiceAccess _inventoryLocationMaster_1ServiceAccess = null;
        IGeneralUnitsStorageLocationServiceAccess _GeneralUnitsStorageLocationServiceAccess = null;
        IVendorMasterServiceAccess _VendorMasterServiceAccess = null;

        private readonly ILogger _logException;
        ActionModeEnum actionModeEnum;
        string _actionMode = string.Empty;
        string _sortBy = string.Empty;
        string _searchBy = string.Empty;
        string _sortDirection = string.Empty;
        int _startRow;
        int _rowLength;
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

        public PurchaseRequisitionMasterController()
        {
            _PurchaseRequisitionMasterServiceAcess = new PurchaseRequisitionMasterServiceAccess();
            _generalItemMasterServiceAccess = new GeneralItemMasterServiceAccess();
            _GeneralPolicyRulesServiceAcess = new GeneralPolicyRulesServiceAccess();
            _inventoryIssueMasterAndIssueDetailsServiceAccess = new InventoryIssueMasterAndIssueDetailsServiceAccess();
            _IGeneralSupplierMasterServiceAccess = new GeneralSupplierMasterServiceAccess();
            _organisationDepartmentMasterServiceAcess = new OrganisationDepartmentMasterServiceAccess();
            _inventoryLocationMaster_1ServiceAccess = new InventoryLocationMaster_1ServiceAccess();
            _GeneralUnitsStorageLocationServiceAccess = new GeneralUnitsStorageLocationServiceAccess();
            _VendorMasterServiceAccess = new VendorMasterServiceAccess();
            _GeneralItemMasterServiceAcess = new GeneralItemMasterServiceAccess();
        }

        // Controller Methods
        #region Controller Methods
        public ActionResult Index(string VendorID, string ReplishmentCode, string CenterCode, string GeneralUnitsID)
        {
            try 
          {
            PurchaseRequisitionMasterViewModel model = new PurchaseRequisitionMasterViewModel();

            model.ReplishmentCode = ReplishmentCode;
            model.GeneralUnitsID = Convert.ToInt32(GeneralUnitsID);
            model.CenterCode = CenterCode;
            model.PolicyCode = "IsPurchaseRequisitionByMannal";
            model.PolicyApplicableStatus = GetPolicyApplicableStatus(model.PolicyCode);
            model.CentreCode = "";
            model.PolicyAnswerByPolicyStatus = GetPolicyAnswerByPolicyStatus(model.CentreCode, model.PolicyApplicableStatus, model.PolicyCode);
            model.PolicyDefaultAnswer = model.PolicyAnswerByPolicyStatus.Where(x => x.PolicyCode == model.PolicyCode).Select(x => x.PolicyDefaultAnswer).FirstOrDefault();

            List<SelectListItem> li = new List<SelectListItem>();
            //li.Add(new SelectListItem { Text = "--Select--", Value = " " });
            //li.Add(new SelectListItem { Text = "Sub Contracting Requisition", Value = "1" });
            //li.Add(new SelectListItem { Text = "Consignment Requision", Value = "2" });
            li.Add(new SelectListItem { Text = "Standard Requisition", Value = "5" });
            li.Add(new SelectListItem { Text = "Stock Transfer Order", Value = "3" });
            //li.Add(new SelectListItem { Text = "Service Requisition", Value = "4" });
           

            ViewData["PurchaseRequisitionType"] = li;
            
            if (model.PolicyDefaultAnswer == "1")
            {
                List<SelectListItem> li1 = new List<SelectListItem>();
                li1.Add(new SelectListItem { Text = "--Select--", Value = " " });
                li1.Add(new SelectListItem { Text = "Purchase Requirement", Value = "1" });
                li1.Add(new SelectListItem { Text = "Below Stock safety Level", Value = "2" });
                li1.Add(new SelectListItem { Text = "Mannual", Value = "3" });
                li1.Add(new SelectListItem { Text = "Reorder Point", Value = "4" });
                ViewData["RequisitionBy"] = li1;
            }
            else
            {
                List<SelectListItem> li1 = new List<SelectListItem>();
                li1.Add(new SelectListItem { Text = "--Select--", Value = " " });
                li1.Add(new SelectListItem { Text = "Purchase Requirement", Value = "1" });
                li1.Add(new SelectListItem { Text = "Below Stock safety Level", Value = "2" });
                li1.Add(new SelectListItem { Text = "Reorder Point", Value = "3" });
                ViewData["RequisitionBy"] = li1;
            }

            List<SelectListItem> li2 = new List<SelectListItem>();
            //li1.Add(new SelectListItem { Text = "--Select--", Value = " " });
            li2.Add(new SelectListItem { Text = "High", Value = "1" });
            li2.Add(new SelectListItem { Text = "Medium", Value = "2" });
            li2.Add(new SelectListItem { Text = "Low", Value = "3" });
            ViewData["PriorityFlag"] = li2;


            //Dropdown for centre
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

            if (!string.IsNullOrEmpty(CenterCode))
            {
                string[] splitCentreCode = CenterCode.Split(':');

            }
            model.SelectedCentreCode = CenterCode;

            //List For Location.

            int AdminRoleID = 0;
            if (Session["RoleID"] == null)
            {
                AdminRoleID = !string.IsNullOrEmpty(Convert.ToString(Session["DefaultRoleID"])) ? Convert.ToInt32(Session["DefaultRoleID"]) : 0;
            }

            else
            {
                AdminRoleID = !string.IsNullOrEmpty(Convert.ToString(Session["RoleID"])) ? Convert.ToInt32(Session["RoleID"]) : 0;
            }
                //List<InventoryLocationMaster_1> locationMasterList = GetInventoryIssueLocationMasterList(Convert.ToInt32(Session["BalancesheetID"]));
               List<InventoryLocationMaster_1> locationMasterList = GetInventoryIssueLocationMasterList(AdminRoleID);
                List<SelectListItem> listLocationMaster = new List<SelectListItem>();
                foreach (InventoryLocationMaster_1 item in locationMasterList)
                {
                    listLocationMaster.Add(new SelectListItem { Text = item.CentreCode + " " +"-" +" "+ item.LocationName, Value = Convert.ToString(item.ID) });
                }

                if (TempData["_errorMsg"] != null)
                {
                    model.errorMessage = Convert.ToString(TempData["_errorMsg"]);
                }
                else
                {
                    model.errorMessage = "NoMessage";
                }
                ViewBag.GeneralLocationList = new SelectList(listLocationMaster, "Value", "Text");


                //List<GeneralUnitsStorageLocation> LocationName = GetGeneralUnitsLocationList(model.CentreCode);
                //List<SelectListItem> listLocationName = new List<SelectListItem>();
                //foreach (GeneralUnitsStorageLocation item in LocationName)
                //{
                //    listLocationName.Add(new SelectListItem { Text = item.LocationName, Value = Convert.ToString(item.InventoryLocationMasterID) });
                //}
                //ViewBag.GeneralUnitsStorageLocationList = new SelectList(listLocationName, "Value", "Text");

                if (VendorID != "0" || VendorID != null)
               {
                   model.Vendor = GetVendorName(VendorID);
                   
               }

          

                    return View("/Views/Purchase/PurchaseRequisitionMaster/Index.cshtml", model);
              }
                catch (Exception ex)
                {
                    _logException.Error(ex.Message);
                    throw;
                }



        }

        public ActionResult List(string PurchaseRequisitionType, string TransDate, string StatusFlag, string actionMode, string ReplishmentCode, string centerCode, string GeneralUnitsID)
        {
            try
            {
                PurchaseRequisitionMasterViewModel model = new PurchaseRequisitionMasterViewModel();
                model.PurchaseRequisitionMasterDTO.ReplishmentCode = ReplishmentCode;
                model.GeneralUnitsID = Convert.ToInt32(GeneralUnitsID);
                model.CenterCode = centerCode;
                List<SelectListItem> li = new List<SelectListItem>();
               // li.Add(new SelectListItem { Text = "--Select--", Value = " " });
                //li.Add(new SelectListItem { Text = "Sub Contracting Requisition", Value = "1" });
                //li.Add(new SelectListItem { Text = "Consignment Requision", Value = "2" });
                li.Add(new SelectListItem { Text = "Standard Requisition", Value = "5" });
                li.Add(new SelectListItem { Text = "Stock Transfer Order", Value = "3" });
                //li.Add(new SelectListItem { Text = "Service Requisition", Value = "4" });
                int AdminRoleID = 0;
                if (Session["RoleID"] == null)
                {
                    AdminRoleID = !string.IsNullOrEmpty(Convert.ToString(Session["DefaultRoleID"])) ? Convert.ToInt32(Session["DefaultRoleID"]) : 0;
                }

                else
                {
                    AdminRoleID = !string.IsNullOrEmpty(Convert.ToString(Session["RoleID"])) ? Convert.ToInt32(Session["RoleID"]) : 0;
                }

                ViewData["PurchaseRequisitionType"] = li;


                model.PurchaseRequisitionType = Convert.ToInt16(PurchaseRequisitionType);
                model.TransDate = TransDate;
                model.AdminRoleID = AdminRoleID;
                if (!string.IsNullOrEmpty(actionMode))
                {
                    TempData["ActionMode"] = actionMode;
                }
                model.StatusFlag = Convert.ToInt32(StatusFlag);
                return PartialView("/Views/Purchase/PurchaseRequisitionMaster/List.cshtml", model);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }

        }
        public ActionResult DataList(string PurchaseRequisitionType, string VendorID, string PurchaseRequisitionBy,string CentreCode)
        {
            try
            {
                PurchaseRequisitionMasterViewModel model = new PurchaseRequisitionMasterViewModel();
                // get detail list of purchase requirement for purchase requisation

                string[] accnmArray = CentreCode.Split(':');
                CentreCode = Convert.ToString(accnmArray[0]);
                model.InventoryPurchaseRequirementListForRequisition = GetPurchaseRequirementMasterListForRequisition(VendorID, PurchaseRequisitionBy, CentreCode);
                model.PurchaseRequisitionType = Convert.ToInt16(PurchaseRequisitionType);
                model.PurchaseRequisitionBy = Convert.ToInt16(PurchaseRequisitionBy);
                ViewData["PurchaseRequisitionType"] = PurchaseRequisitionType;
                //List For Location.

                int AdminRoleID = 0;
                if (Session["RoleID"] == null)
                {
                    AdminRoleID = !string.IsNullOrEmpty(Convert.ToString(Session["DefaultRoleID"])) ? Convert.ToInt32(Session["DefaultRoleID"]) : 0;
                }

                else
                {
                    AdminRoleID = !string.IsNullOrEmpty(Convert.ToString(Session["RoleID"])) ? Convert.ToInt32(Session["RoleID"]) : 0;
                }
                //List<InventoryLocationMaster_1> locationMasterList = GetInventoryIssueLocationMasterList(Convert.ToInt32(Session["BalancesheetID"]));
                List<InventoryLocationMaster_1> locationMasterList = GetInventoryIssueLocationMasterList(AdminRoleID);
                List<SelectListItem> listLocationMaster = new List<SelectListItem>();
                foreach (InventoryLocationMaster_1 item in locationMasterList)
                {
                    listLocationMaster.Add(new SelectListItem { Text = item.CentreCode + " " + "-" + " " + item.LocationName, Value = Convert.ToString(item.ID) });
                    //listLocationMaster.Add(new SelectListItem { Text = item.LocationName, Value = Convert.ToString(item.ID) });
                }
                ViewBag.GeneralLocationList = new SelectList(listLocationMaster, "Value", "Text");



                return PartialView("/Views/Purchase/PurchaseRequisitionMaster/DataList.cshtml", model);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }

        }

        [HttpGet]
        public ActionResult Create()
        {
            PurchaseRequisitionMasterViewModel model = new PurchaseRequisitionMasterViewModel();
            return PartialView("/Views/Purchase/PurchaseRequisitionMaster/Create.cshtml", model);
        }

        [HttpGet]
        public ActionResult ReplenishmentView(string ReplishmentCode, string StatusFlag, string centerCode, string GeneralUnitsID)
        {
            PurchaseRequisitionMasterViewModel model = new PurchaseRequisitionMasterViewModel();
            model.PurchaseRequisitionMasterDTO.ReplishmentCode = ReplishmentCode;
            model.PurchaseRequisitionMasterDTO.StatusFlag = Convert.ToInt32(StatusFlag);
            model.PurchaseRequisitionMasterDTO.CentreCode = centerCode;
            model.PurchaseRequisitionMasterDTO.GeneralUnitsID = Convert.ToInt32(GeneralUnitsID);
            return View("/Views/Purchase/PurchaseRequisitionMaster/ReplenishmentView.cshtml", model);
        }

        [HttpPost]
        public ActionResult Create(PurchaseRequisitionMasterViewModel model)
        {
            try
            {


                if (model != null && model.PurchaseRequisitionMasterDTO != null)
                {
                    model.PurchaseRequisitionMasterDTO.ConnectionString = _connectioString;
                   
                    model.PurchaseRequisitionMasterDTO.TransDate = model.TransDate;
                    model.PurchaseRequisitionMasterDTO.PurchaseRequisitionType = model.PurchaseRequisitionType;
                    model.PurchaseRequisitionMasterDTO.VendorID = model.VendorID;
                    model.PurchaseRequisitionMasterDTO.Vendor = model.Vendor;
                    model.PurchaseRequisitionMasterDTO.IsOpenForPO = model.IsOpenForPO;
                    model.PurchaseRequisitionMasterDTO.PRStatus = model.PRStatus;
                    model.PurchaseRequisitionMasterDTO.XMLstring = model.XMLstring;
                    if (model.PurchaseRequisitionType == 3)
                    {
                        model.PurchaseRequisitionBehaviour = "Internal";
                    }
                    else
                    {
                        model.PurchaseRequisitionBehaviour = "External";
                    }
                    model.PurchaseRequisitionMasterDTO.PurchaseRequisitionBehaviour = model.PurchaseRequisitionBehaviour;
                    model.PurchaseRequisitionMasterDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                    IBaseEntityResponse<PurchaseRequisitionMaster> response = _PurchaseRequisitionMasterServiceAcess.InsertPurchaseRequisitionMaster(model.PurchaseRequisitionMasterDTO);
                    model.PurchaseRequisitionMasterDTO.ReplishmentCode = response.Entity.ReplishmentCode;


                    model.PurchaseRequisitionMasterDTO.errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert) +','+ response.Entity.ReplishmentCode;
                    TempData["_errorMsg"] = model.PurchaseRequisitionMasterDTO.errorMessage;
                    return Json(model.PurchaseRequisitionMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
                    
                }

                return Json("Please review your form");


            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }

        }

        [HttpGet]
        public ActionResult Edit(int id, string ReplishmentCode, string centerCode, string GeneralUnitsID)
        {
            PurchaseRequisitionMasterViewModel model = new PurchaseRequisitionMasterViewModel();
            try
            {
                model.PurchaseRequisitionMasterDTO = new PurchaseRequisitionMaster();
                model.PurchaseRequisitionMasterDTO.ID = id;
                model.PurchaseRequisitionMasterDTO.ReplishmentCode = ReplishmentCode;
                model.GeneralUnitsID = Convert.ToInt32(GeneralUnitsID);
                model.CenterCode = centerCode;
                model.PurchaseRequisitionMasterDTO.ConnectionString = _connectioString;

                model.PurchaseRequisitionMasterList = GetPurchaseRequisitionMasterList(id);
                for (int i = 0; i < model.PurchaseRequisitionMasterList.Count; i++)
                {
                    if (model.PurchaseRequisitionMasterList.Count > 0 && model.PurchaseRequisitionMasterList != null)
                    {
                        model.PurchaseRequisitionNumber = model.PurchaseRequisitionMasterList[i].PurchaseRequisitionNumber;
                        model.TransDate = model.PurchaseRequisitionMasterList[i].TransDate;
                        model.AmmountIncludingTax = Math.Round(model.PurchaseRequisitionMasterList[i].AmmountIncludingTax, 2);
                        model.TaxAmount = Math.Round(model.PurchaseRequisitionMasterList[i].TaxAmount, 2);
                        model.Ammount = Math.Round(model.PurchaseRequisitionMasterList[i].GrossAmount, 2);
                    }
                }
                return PartialView("/Views/Purchase/PurchaseRequisitionMaster/Edit.cshtml", model);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public ActionResult Edit(PurchaseRequisitionMasterViewModel model)
        {
            if (model != null && model.PurchaseRequisitionMasterDTO != null)
            {
                model.PurchaseRequisitionMasterDTO.ConnectionString = _connectioString;
                model.PurchaseRequisitionMasterDTO.ID = model.ID;
                model.PurchaseRequisitionMasterDTO.IsOpenForPO = model.IsOpenForPO;
                model.PurchaseRequisitionMasterDTO.XMLstring = model.XMLstring;
                model.PurchaseRequisitionMasterDTO.TaxAmount = model.TaxAmount;
                model.PurchaseRequisitionMasterDTO.Freight = model.Freight;
                model.PurchaseRequisitionMasterDTO.ShippingHandling = model.ShippingHandling;
                model.PurchaseRequisitionMasterDTO.Discount = model.Discount;
                model.PurchaseRequisitionMasterDTO.AmmountIncludingTax = model.AmmountIncludingTax; ;
                model.PurchaseRequisitionMasterDTO.ModifiedBy = Convert.ToInt32(Session["UserID"]);
                IBaseEntityResponse<PurchaseRequisitionMaster> response = _PurchaseRequisitionMasterServiceAcess.UpdatePurchaseRequisitionMaster(model.PurchaseRequisitionMasterDTO);
                model.PurchaseRequisitionMasterDTO.ReplishmentCode = response.Entity.ReplishmentCode;
                if (response.Entity.ErrorCode == 18)
                {
                    model.PurchaseRequisitionMasterDTO.errorMessage = "PO can not be Created As Vendor Restriction Amount is Greater then PO amount,warning";
                }
                else
                {
                    model.PurchaseRequisitionMasterDTO.errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Update) + ',' + response.Entity.ReplishmentCode;
                }

                
                //model.PurchaseRequisitionMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Update);
                TempData["_errorMsg"] = model.PurchaseRequisitionMasterDTO.errorMessage;
                return Json(model.PurchaseRequisitionMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
            }


            else
            {
                return Json("Please review your form");
            }
        }
        [HttpGet]
        public ActionResult View(int id)
        {
            try
            {
                PurchaseRequisitionMasterViewModel model = new PurchaseRequisitionMasterViewModel();
                model.PurchaseRequisitionMasterList = GetPurchaseRequisitionMasterList(id);
                //model.PurchaseRequisitionMasterList = GetPurchaseRequisitionMasterList(id);
                if (model.PurchaseRequisitionMasterList.Count > 0 && model.PurchaseRequisitionMasterList != null)
                {
                    model.PurchaseRequisitionNumber = model.PurchaseRequisitionMasterList[0].PurchaseRequisitionNumber;
                    model.TransDate = model.PurchaseRequisitionMasterList[0].TransDate;
                }
                return PartialView("/Views/Purchase/PurchaseRequisitionMaster/View.cshtml", model);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }
        
        public ActionResult Delete(int ID)
        {
            var errorMessage = string.Empty;
            if (ID > 0)
            {
                IBaseEntityResponse<PurchaseRequisitionMaster> response = null;
                PurchaseRequisitionMasterViewModel model = new PurchaseRequisitionMasterViewModel();
                model.PurchaseRequisitionMasterDTO.ConnectionString = _connectioString;
                model.PurchaseRequisitionMasterDTO.ID = ID;
                model.PurchaseRequisitionMasterDTO.DeletedBy = Convert.ToInt32(Session["UserID"]);
                response = _PurchaseRequisitionMasterServiceAcess.DeletePurchaseRequisitionMaster(model.PurchaseRequisitionMasterDTO);
                string errorMessageDis = string.Empty;
                string colorCode = string.Empty;
                string mode = string.Empty;
                if (response.Entity.ErrorCode == 77)
                {
                    errorMessageDis = response.Entity.errorMessage;
                    colorCode = "danger";
                }
                else if (response.Entity.ErrorCode == 0)
                {
                    errorMessageDis = response.Entity.errorMessage;
                    colorCode = "success";
                }
                string[] arrayList = { errorMessageDis, colorCode, mode };
                errorMessage = string.Join(",", arrayList);
            }
            return Json(errorMessage, JsonRequestBehavior.AllowGet);
        }


        [HttpGet]
        public FileStreamResult DownloadPDF(int id)
        {
            PurchaseRequisitionMasterViewModel model = new PurchaseRequisitionMasterViewModel();
            try
            {
                model.PurchaseRequisitionMasterDTO = new PurchaseRequisitionMaster();
                model.PurchaseRequisitionMasterDTO.ID = id;
                model.PurchaseRequisitionMasterDTO.ConnectionString = _connectioString;
                decimal amount1 = 0; int itemcount = 0; decimal taxamount1 = 0; decimal totalamount = 0;
                model.PurchaseRequisitionMasterList = GetPurchaseRequisitionMasterList(id);
                model.PurchaseRequisitionNumber = model.PurchaseRequisitionMasterList[0].PurchaseRequisitionNumber;
                string PurchasePDF = " ";
                if (model.PurchaseRequisitionMasterList[0].PurchaseRequisitionType == 3)
                {
                    PurchasePDF = PurchasePDF + "<html><body><span style='text-align:center'>Stock Transfer Requisition<br></body></html>";
                }
                else
                {
                    PurchasePDF = PurchasePDF + "<html><body><span style='text-align:center'>Standard Requisition<br></body></html>";
                }

                PurchasePDF = PurchasePDF + "<br/><br/><table style='width:100%; border-collapse:collapse;border-spacing:0;margin: 0;padding: 0;'><tr><td width='40%'>";
                //PurchasePDF = PurchasePDF + "<table style=' border-collapse:collapse; border-spacing:0;margin: 0;padding: 0;'><tr><th style='padding: 5px;font-size:8pt;text-align:left'>Company Name:</th></tr><tr><td style='font-size:8pt;text-align:left'>" + model.PurchaseRequisitionMasterList[0].PrintingLine1 + "</td></tr> <tr><td style='font-size:8pt;text-align:left'>" + model.PurchaseRequisitionMasterList[0].PrintingLine2 + "</td></tr><tr><td style='font-size:8pt;text-align:left'>" + model.PurchaseRequisitionMasterList[0].PrintingLine3 + "</td></tr><tr><td style='font-size:8pt;text-align:left'>" + model.PurchaseRequisitionMasterList[0].PrintingLine4 + "</td></tr></table></td style='font-size:8pt;text-align:left'><td style='border: 1px solid black;border-collapse: collapse; padding: 5px; width='50%';'>";
                PurchasePDF = PurchasePDF + "<table style=' border-collapse:collapse; border-spacing:0;margin: 0;padding: 0;'><tr><th style='padding: 5px;font-size:7pt;text-align:left'><b>Company Name:<b></th></tr><tr><td style='font-size:7pt;text-align:left'>" + model.PurchaseRequisitionMasterList[0].PrintingLine1 + "</td></tr> <tr><td style='font-size:7pt;text-align:left'>" + model.PurchaseRequisitionMasterList[0].LocationAddress + "</td></tr><tr><td style='font-size:7pt;text-align:left'>" + model.PurchaseRequisitionMasterList[0].City + " - PO Box - " + model.PurchaseRequisitionMasterList[0].Pincode + "</td></tr><tr><td style='font-size:7pt;text-align:left'></td></tr></table></td style='font-size:7pt'><td style='border: 1px solid black;border-collapse: collapse; padding: 5px; width='50%';'>";
                PurchasePDF = PurchasePDF + "<table border= '1' bgcolor='#fff;' color='black' style=' border-collapse:collapse;font-size:7pt;'><b>PurchaseOrder</b><tr><td bgcolor='#D3D3D3' style='border: 1px solid black;border-collapse: collapse; padding: 5px;font-size:7pt;text-align:left; '>Requisition Number</td><td style='border: 1px solid black;border-collapse: collapse; padding: 5px;font-size:7pt;text-align:left; '>" + model.PurchaseRequisitionMasterList[0].PurchaseRequisitionNumber + "</td></tr><tr><td bgcolor='#D3D3D3' style='border: 1px solid black;border-collapse: collapse; padding: 5px;font-size:7pt;text-align:left;'> Order Date</td><td style='border: 1px solid black;border-collapse: collapse; padding: 5px;font-size:7pt;text-align:left; '>" + model.PurchaseRequisitionMasterList[0].TransDate + "</td></tr><tr><td bgcolor='#D3D3D3' style='border: 1px solid black;border-collapse: collapse; padding: 5px;text-align:left; '>Delivery Date</td><td style='border: 1px solid black;border-collapse: collapse; padding: 5px;font-size:7pt;text-align:left; '>" + model.PurchaseRequisitionMasterList[0].ExpectedDeliveryDate + "</td> </tr><tr><td bgcolor='#D3D3D3' style='border: 1px solid black;border-collapse: collapse; padding: 5px;text-align:left; '>Currency</td><td style='border: 1px solid black;border-collapse: collapse; padding: 5px;font-size:7pt;text-align:left; '>" + model.PurchaseRequisitionMasterList[0].Currency + "</td> </tr><tr><td bgcolor='#D3D3D3' style='border: 1px solid black;border-collapse: collapse; padding: 5px;text-align:left; '>Ship To</td><td style='border: 1px solid black;border-collapse: collapse; padding: 5px;font-size:7pt;text-align:left; '>" + model.PurchaseRequisitionMasterList[0].UnitName + "</td></tr></table></td></tr></table>";
                if (model.PurchaseRequisitionMasterList[0].PurchaseRequisitionType == 3)
                {
                    PurchasePDF = PurchasePDF + "<table style='width:100%;'><tr><td valign='top'>";
                    PurchasePDF = PurchasePDF + "<table style='border-collapse: collapse;border-spacing:0;margin: 0;padding: 0;'><tr><td style='padding-top: 0;font-size:7pt;text-align:left'>Ship From:</td></tr><tr><td style='padding-top: 0;font-size:7pt;text-align:left'>" + model.PurchaseRequisitionMasterList[0].FromUnitName + "</td></tr><tr><td style='padding-top: 0;font-size:7pt;text-align:left'>" + model.PurchaseRequisitionMasterList[0].FromLocationAddress + "</td></tr><tr><td style='padding-top: 0;font-size:7pt;text-align:left'>" + model.PurchaseRequisitionMasterList[0].FromCity + " - PO Box - " + model.PurchaseRequisitionMasterList[0].FromPincode + "</td></tr></table></td><td>";
                    PurchasePDF = PurchasePDF + "</td></tr></table>";
                }
                else
                {
                PurchasePDF = PurchasePDF + "<table style='width:100%;'><tr><td>";
                PurchasePDF = PurchasePDF + "<table style='border-collapse: collapse;border-spacing:0;margin: 0;padding: 0;'><tr><td style='padding-top: 0;font-size:8pt;text-align:left'>Vendor:" + model.PurchaseRequisitionMasterList[0].VendorName + "</td></tr><tr><td style='padding-top: 0;font-size:8pt;text-align:left'>" + model.PurchaseRequisitionMasterList[0].VendorAddress + "</td></tr><tr><td style='padding-top: 0;font-size:8pt;text-align:left'>" + model.PurchaseRequisitionMasterList[0].VendorPinCode + "</td></tr><tr><td style='padding-top: 0;font-size:8pt;text-align:left'>" + model.PurchaseRequisitionMasterList[0].VendorPhoneNumber + "</td></tr></table></td><td>";
                PurchasePDF = PurchasePDF + "</td></tr></table><br>";
                }
                //PurchasePDF = PurchasePDF + "<table style='width:100%;'><tr><td width='40%'>";
                //PurchasePDF = PurchasePDF + "<table border= '1' bgcolor='#fff;' color='black'><tr><th  bgcolor='#D3D3D3' style='border:0; padding: 5px;font-size:12pt;'>Vendor</th></tr><tr style='border:0;font-size:10pt;'><td border :0>CompanyName</td></tr border:0><tr><td style='border:0;font-size:10pt;'>Address</td></tr></table></td style='font-size:10pt'><td style='border: 1px solid black;border-collapse: collapse; padding: 5px; width='40%';'>";
                //PurchasePDF = PurchasePDF + "<table border= '1' bgcolor='#fff;' color='black'><tr><th  bgcolor='#D3D3D3' style='border:0; padding: 5px;font-size:12pt; '>Ship to</th></tr> <tr style='border:0;font-size:10pt;'><td border :0>CompanyName</td></tr><tr border:0;font-size:10pt;><td style='border:0;font-size:10pt;'>Address</td></tr></table></td></tr></table>";

                PurchasePDF = PurchasePDF + "<br><br><table border= '1' bgcolor='#fff;' color='black'><tr><th  bgcolor='#D3D3D3' color='black' style='border: 1px solid black; font-size:8pt; border-collapse: collapse; text-align: center; padding: 5px;' width='25%'>Item Name</th><th  bgcolor='#D3D3D3' color='black' style='border: 1px solid black;font-size:8pt; border-collapse: collapse; text-align: center; padding: 5px;' width='15%'>Barcode</th><th  bgcolor='#D3D3D3' color='black' style='border: 1px solid black;font-size:8pt; border-collapse: collapse; text-align: center; padding: 5px;' width='7%'>Quantity</th><th  bgcolor='#D3D3D3' color='black' style='border: 1px solid black; font-size:8pt; border-collapse: collapse; text-align: center; padding: 5px;' width='7%'>Unit</th><th  bgcolor='#D3D3D3' color='black' style='border: 1px solid black; border-collapse: collapse;font-size:8pt; text-align: center; padding: 5px;'>Pack Size</th><th  bgcolor='#D3D3D3' color='black' style='border: 1px solid black;font-size:8pt; border-collapse: collapse; text-align: center; padding: 5px;' width='8%'>Location</th><th  bgcolor='#D3D3D3' color='black' style='border: 1px solid black;font-size:8pt; border-collapse: collapse; text-align: center; padding: 5px;'>Rate</th><th  bgcolor='#D3D3D3' color='black' style='border: 1px solid black;font-size:8pt; border-collapse: collapse; text-align: center; padding: 5px;'>Amount</th></tr>";

                if (model.PurchaseRequisitionMasterList.Count > 0 && model.PurchaseRequisitionMasterList != null)
                {
                    foreach (var item in model.PurchaseRequisitionMasterList)
                    {
                        amount1 = amount1 + item.Ammount;
                        taxamount1 = item.TaxAmount;
                        totalamount = totalamount + item.AmmountIncludingTax;
                        itemcount = itemcount + item.ItemCount;
                        PurchasePDF = PurchasePDF + "<tr><td  bgcolor='#F7F2F2' color='black' style='border: 1px solid black; border-collapse: collapse; text-align: left; padding: 5px;font-size:8pt; '>" + item.ItemName + "</td><td  bgcolor='#F7F2F2' color='black' style='border: 1px solid black; border-collapse: collapse; text-align: left; padding: 5px;font-size:8pt; '>" + item.BarCode + "</td><td  bgcolor='#F7F2F2' color='black' style='border: 1px solid black; border-collapse: collapse; text-align: left; padding: 5px;font-size:8pt; '>" + Math.Round(item.Quantity, 3) + "</td><td  bgcolor='#F7F2F2' color='black' style='border: 1px solid black; border-collapse: collapse; text-align: left; padding: 5px;font-size:8pt; '>" + item.BaseUOMCode + "</td><td  bgcolor='#F7F2F2' color='black' style='border: 1px solid black; border-collapse: collapse; text-align: left; padding: 5px;font-size:8pt; '>" + Math.Round(item.Quantity) + "*" + item.BaseUOMQuantity + "</td><td  bgcolor='#F7F2F2' color='black' style='border: 1px solid black; border-collapse: collapse; text-align: left; padding: 5px;font-size:8pt; '>" + item.LocationName + "</td><td  bgcolor='#F7F2F2' color='black' style='border: 1px solid black; border-collapse: collapse; text-align: left; padding: 5px;font-size:8pt;text-align:right '>" + Math.Round(item.Rate,2) + "</td><td  bgcolor='#F7F2F2' color='black' style='border: 1px solid black; border-collapse: collapse; text-align: left; padding: 5px;font-size:8pt;text-align:right '>" + item.Ammount + "</td></tr>";
                    }
                }
                PurchasePDF = PurchasePDF + "</table><br>";

                PurchasePDF = PurchasePDF + "<table style='width:100%;'><tr><td width='40%'>";
                //PurchasePDF = PurchasePDF + "<table border= '1' bgcolor='#fff;' color='black'><tr><th  bgcolor='#D3D3D3' style='border: 1px solid black;border-collapse: collapse; padding: 5px;'>Vendor</th></tr><tr><td ><br><br><br><br></td></tr></table></td style='font-size:10pt'><td style='border: 1px solid black;border-collapse: collapse; padding: 5px; width='45%';'>";
                PurchasePDF = PurchasePDF + "<table border= '1' bgcolor='#fff;' color='black'><tr><td bgcolor='#D3D3D3' style='border: 1px;font-size:8pt; solid black;border-collapse: collapse; padding: 5px;text-align:right; '>Sub Total</td><td style='border: 1px solid black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:right; '>" + amount1 + "</td></tr><tr><td bgcolor='#D3D3D3' style='border: 1px solid black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:right; '>Tax Rate</td><td style='border: 1px solid black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:right; '>" + Math.Round(model.PurchaseRequisitionMasterList[0].TaxRate,2) + "</td></tr><tr><td bgcolor='#D3D3D3' style='border: 1px solid black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:right;'>Tax</td><td style='border: 1px solid black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:right; '>" + Math.Round(taxamount1,2) + "</td></tr><tr><td bgcolor='#D3D3D3' style='border: 1px;font-size:8pt; solid black;border-collapse: collapse; padding: 5px;text-align:right; '> Total Amount</td><td style='border: 1px solid black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:right; '>" + totalamount + "</td> </tr></table></td></tr></table>";

                PurchasePDF = PurchasePDF + "<table><tr><td width='50%'>";
                PurchasePDF = PurchasePDF + "<table style='width:50%;font-size:8pt;text-align:left' ><tr><th style='text-align:left'>Authorized By</th></tr><tr><td style='text-align:left'> ___________________</td></tr></table><td width='50%'>";
                PurchasePDF = PurchasePDF + "<table style='width:50%;font-size:8pt;text-align:left' ><tr><th style='text-align:left'>Date</th></tr><tr><td style='text-align:left'> ___________________</td></tr></table></td></tr></table>";




                // PurchasePDF = PurchasePDF + "<table><tr><th>ItemCount: " + itemcount + "</th><th style='text-align:right' >Ammount :" + amount + "</th></tr></table>";
                // PurchasePDF = PurchasePDF + "<table border='1' background-color='red'><tr><td>hii</td><td>" + model.PurchaseRequisitionMasterList[0].PurchaseRequisitionNumber + "</td><td>date</td><td>" + model.PurchaseRequisitionMasterList[0].TransDate + "</td></tr></table>";
                DownloadPDF1(PurchasePDF, model.PurchaseRequisitionNumber, model.PurchaseRequisitionMasterList[0].VendorNumber);
                MemoryStream workStream = new MemoryStream();
                return new FileStreamResult(workStream, "application/pdf");



            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpGet]
        public ActionResult PurchaseRequisitionRequestApproval(int PersonID, string TNDID, string TNMID, string GTRDID1, string TaskCode, string StageSequenceNumber, string IsLast)
        {
            PurchaseRequisitionMasterViewModel model = new PurchaseRequisitionMasterViewModel();
            model.PersonID = Convert.ToInt32(PersonID);
            model.TaskNotificationDetailsID = Convert.ToInt32(TNDID);
            model.TaskNotificationMasterID = Convert.ToInt32(TNMID);
            model.GeneralTaskReportingDetailsID = Convert.ToInt32(GTRDID1);
            model.TaskCode = TaskCode;
            model.StageSequenceNumber = Convert.ToInt32(StageSequenceNumber);
            model.IsLastRecord = Convert.ToBoolean(IsLast);
            model.PurchaseRequisitionMasterList = GetPurchaseRequirementRecord(PersonID, Convert.ToInt32(TNMID));
            model.ID = model.PurchaseRequisitionMasterList.Count > 0 ? model.PurchaseRequisitionMasterList[0].ID : 0;
            model.TransDate = model.PurchaseRequisitionMasterList.Count > 0 ? model.PurchaseRequisitionMasterList[0].TransDate : null;
            model.PurchaseRequisitionNumber = model.PurchaseRequisitionMasterList.Count > 0 ? model.PurchaseRequisitionMasterList[0].PurchaseRequisitionNumber : null;

            return View("/Views/Purchase/PurchaseRequisitionMaster/PurchaseRequisitionRequestApproval.cshtml", model);
        }

        #endregion

        // Non-Action Method
        #region Methods
        public IEnumerable<PurchaseRequisitionMasterViewModel> GetPurchaseRequisitionMaster(string PurchaseRequisitionType, string TransDate, int AdminRoleID,out int TotalRecords)
        {
            PurchaseRequisitionMasterSearchRequest searchRequest = new PurchaseRequisitionMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            _actionMode = Convert.ToString(TempData["ActionMode"]);
            if (Enum.TryParse(_actionMode, out actionModeEnum))     // checks actionMode i.e. Insert or Update // 
            {
                if (actionModeEnum == ActionModeEnum.Insert)        // parameters for SelectAll procedures under Insert or Update mode condition
                {
                    searchRequest.SortBy = "CreatedDate";
                    searchRequest.StartRow = 0;
                    searchRequest.EndRow = 10;
                    searchRequest.SearchBy = string.Empty;
                    searchRequest.SortDirection = "Desc";
                }
                if (actionModeEnum == ActionModeEnum.Update)
                {
                    searchRequest.SortBy = "A.ModifiedDate";
                    searchRequest.StartRow = 0;
                    searchRequest.EndRow = 10;
                    searchRequest.SearchBy = _searchBy;
                    searchRequest.SortDirection = "Desc";
                    searchRequest.PurchaseRequisitionType = Convert.ToInt16(PurchaseRequisitionType);
                    searchRequest.TransDate = TransDate;
                    searchRequest.AdminRoleID = AdminRoleID;
                }
            }
            else
            {
                searchRequest.SortBy = _sortBy;                     // parameters for SelectAll procedures under normal condition
                searchRequest.StartRow = _startRow;
                searchRequest.EndRow = _startRow + _rowLength;
                searchRequest.SearchBy = _searchBy;
                searchRequest.SortDirection = _sortDirection;
                searchRequest.PurchaseRequisitionType = Convert.ToInt16(PurchaseRequisitionType);
                searchRequest.TransDate = TransDate;
                searchRequest.AdminRoleID = AdminRoleID;
            }
            List<PurchaseRequisitionMasterViewModel> listPurchaseRequisitionMasterViewModel = new List<PurchaseRequisitionMasterViewModel>();
            List<PurchaseRequisitionMaster> listPurchaseRequisitionMaster = new List<PurchaseRequisitionMaster>();
            IBaseEntityCollectionResponse<PurchaseRequisitionMaster> baseEntityCollectionResponse = _PurchaseRequisitionMasterServiceAcess.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listPurchaseRequisitionMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (PurchaseRequisitionMaster item in listPurchaseRequisitionMaster)
                    {
                        PurchaseRequisitionMasterViewModel PurchaseRequisitionMasterViewModel = new PurchaseRequisitionMasterViewModel();
                        PurchaseRequisitionMasterViewModel.PurchaseRequisitionMasterDTO = item;
                        listPurchaseRequisitionMasterViewModel.Add(PurchaseRequisitionMasterViewModel);
                    }
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listPurchaseRequisitionMasterViewModel;
        }
        [NonAction]
        protected List<PurchaseRequisitionMaster> GetPurchaseRequirementRecord(int personId, int taskNotificationMasterID)
        {
            PurchaseRequisitionMasterSearchRequest searchRequest = new PurchaseRequisitionMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.PersonID = personId;
            searchRequest.TaskNotificationMasterID = taskNotificationMasterID;
            List<PurchaseRequisitionMaster> listPurchaseRequisitionMaster = new List<PurchaseRequisitionMaster>();
            IBaseEntityCollectionResponse<PurchaseRequisitionMaster> baseEntityCollectionResponse = _PurchaseRequisitionMasterServiceAcess.GetPurchaseRequisitionForApproval(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listPurchaseRequisitionMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listPurchaseRequisitionMaster;
        }
        [NonAction]
        protected List<PurchaseRequisitionMaster> GetPurchaseRequirementMasterListForRequisition(string VendorID, string PurchaseRequisitionBy,string CentreCode)
        {
            PurchaseRequisitionMasterSearchRequest searchRequest = new PurchaseRequisitionMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.VendorID = Convert.ToInt16(VendorID);
            searchRequest.PurchaseRequisitionBy = Convert.ToInt16(PurchaseRequisitionBy);
            searchRequest.CentreCode = CentreCode;
            List<PurchaseRequisitionMaster> listPurchaseRequirementMaster = new List<PurchaseRequisitionMaster>();
            IBaseEntityCollectionResponse<PurchaseRequisitionMaster> baseEntityCollectionResponse = _PurchaseRequisitionMasterServiceAcess.GetPurchaseRequisitionMasterList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listPurchaseRequirementMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listPurchaseRequirementMaster;
        }


        public ActionResult GetUoMCodeByItemNumber(string ItemNumber)
        {

            var UOMCodeDesc = GetUoMCodeByItemNumberList(ItemNumber);
            var result = (from s in UOMCodeDesc
                          select new
                          {
                              id = s.ID,
                              name = s.UnitCode,
                              BaseUOMQuantity = s.BaseUOMQuantity,
                              Rate=s.UomPurchasePrice,
                          }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        protected List<PurchaseRequisitionMaster> GetUoMCodeByItemNumberList(string ItemNumber)
        {

            PurchaseRequisitionMasterSearchRequest searchRequest = new PurchaseRequisitionMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.ItemNumber = Convert.ToInt32(ItemNumber);

            List<PurchaseRequisitionMaster> listOrganisationDepartmentMaster = new List<PurchaseRequisitionMaster>();
            IBaseEntityCollectionResponse<PurchaseRequisitionMaster> baseEntityCollectionResponse = _PurchaseRequisitionMasterServiceAcess.GetUomDetailsForSTOWithPurchasePrice(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listOrganisationDepartmentMaster = baseEntityCollectionResponse.CollectionResponse.ToList();

                }
            }
            return listOrganisationDepartmentMaster;
        }


        public ActionResult GetUoMCodeByItemNumberForPurchasePrice(string ItemNumber,string UoMCode)
        {

            var UOMCodeDesc = GetUoMCodeByItemNumberForPurchasePriceList(ItemNumber, UoMCode);
            var result = (from s in UOMCodeDesc
                          select new
                          {
                              id = s.ID,
                              name = s.UnitCode,
                              BaseUOMQuantity = s.BaseUOMQuantity,
                              UomPurchasePrice = s.UomPurchasePrice,
                          }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        protected List<PurchaseRequisitionMaster> GetUoMCodeByItemNumberForPurchasePriceList(string ItemNumber, string UoMCode)
        {

            PurchaseRequisitionMasterSearchRequest searchRequest = new PurchaseRequisitionMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.ItemNumber = Convert.ToInt32(ItemNumber);
            searchRequest.UnitCode = Convert.ToString(UoMCode);

            List<PurchaseRequisitionMaster> listOrganisationDepartmentMaster = new List<PurchaseRequisitionMaster>();
            IBaseEntityCollectionResponse<PurchaseRequisitionMaster> baseEntityCollectionResponse = _PurchaseRequisitionMasterServiceAcess.GetUomWisePurchasePrice(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listOrganisationDepartmentMaster = baseEntityCollectionResponse.CollectionResponse.ToList();

                }
            }
            return listOrganisationDepartmentMaster;
        }
        
        //Code for Batch Quantity

        public ActionResult GetBatchQuantityByItemNumber(string ItemNumber, string InventoryLocationMasterID)
        {

            var UOMCodeDesc = GetBatchQuantity(ItemNumber, InventoryLocationMasterID);
            var result = (from s in UOMCodeDesc
                          select new
                          {
                              ItemNumber = s.ItemNumber,
                              StorageLocationID =s.StorageLocationID,
                              BatchQuantity = s.BatchQuantity,
                          }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        protected List<PurchaseRequisitionMaster> GetBatchQuantity(string ItemNumber, string InventoryLocationMasterID)
        {

            PurchaseRequisitionMasterSearchRequest searchRequest = new PurchaseRequisitionMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.ItemNumber = Convert.ToInt32(ItemNumber);
            searchRequest.InventoryLocationMasterID = Convert.ToInt32(InventoryLocationMasterID);

            List<PurchaseRequisitionMaster> listOrganisationDepartmentMaster = new List<PurchaseRequisitionMaster>();
            IBaseEntityCollectionResponse<PurchaseRequisitionMaster> baseEntityCollectionResponse = _PurchaseRequisitionMasterServiceAcess.GetItemAndLocationWiseBatchQuantity(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listOrganisationDepartmentMaster = baseEntityCollectionResponse.CollectionResponse.ToList();

                }
            }
            return listOrganisationDepartmentMaster;
        }
        
        //Code For  Download PDF
        public byte[] GetPDF(string pHTML)
        {
            byte[] bPDF = null;

            MemoryStream ms = new MemoryStream();
            TextReader txtReader = new StringReader(pHTML);

            // 1: create object of a itextsharp document class
            Document doc = new Document(PageSize.A4, 25, 25, 25, 25);

            // 2: we create a itextsharp pdfwriter that listens to the document and directs a XML-stream to a file
            PdfWriter oPdfWriter = PdfWriter.GetInstance(doc, ms);

            // 3: we create a worker parse the document
            HTMLWorker htmlWorker = new HTMLWorker(doc);

            // 4: we open document and start the worker on the document
            doc.Open();
            htmlWorker.StartDocument();

            // 5: parse the html into the document
            htmlWorker.Parse(txtReader);

            // 6: close the document and the worker
            htmlWorker.EndDocument();
            htmlWorker.Close();
            doc.Close();

            bPDF = ms.ToArray();

            return bPDF;
        }

        public void DownloadPDF1(string PurchasePDF, string PurchaseRequisitionNumber, int VendorNumber)
        {
            //string HTMLContent = "Hello <b>World</b>";

            Response.Clear();
            Response.ContentType = "application/pdf";
           // Response.AddHeader("content-disposition", "attachment;filename=" + "Purchase-RequsitionPDF.pdf");
            Response.AddHeader("content-disposition", "attachment;filename=" + VendorNumber + "_" + PurchaseRequisitionNumber + ".pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.BinaryWrite(GetPDF(PurchasePDF));
            Response.End();
        }

        [NonAction]
        protected List<PurchaseRequisitionMaster> GetPurchaseRequisitionMasterList(int id)
        {
            PurchaseRequisitionMasterSearchRequest searchRequest = new PurchaseRequisitionMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.ID = id;
            List<PurchaseRequisitionMaster> listPurchaseRequirementMaster = new List<PurchaseRequisitionMaster>();
            IBaseEntityCollectionResponse<PurchaseRequisitionMaster> baseEntityCollectionResponse = _PurchaseRequisitionMasterServiceAcess.GetPurchaseRequisitionMasterDetailLists(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listPurchaseRequirementMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listPurchaseRequirementMaster;
        }

        //Code for Get Policy Applicable status
        protected string GetPolicyApplicableStatus(string PolicyCode)
        {
            try
            {
                IGeneralPolicyRulesViewModel model = new GeneralPolicyRulesViewModel();
                model.GeneralPolicyRulesDTO = new GeneralPolicyRules();
                model.GeneralPolicyRulesDTO.ConnectionString = _connectioString;
                model.GeneralPolicyRulesDTO.PolicyCode = PolicyCode;
                IBaseEntityResponse<GeneralPolicyRules> response = _GeneralPolicyRulesServiceAcess.GetPolicyApplicableStatus(model.GeneralPolicyRulesDTO);
                return (response != null && response.Entity != null) ? response.Entity.PolicyApplicableStatus : string.Empty;
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }
        //get vendor name
        protected string GetVendorName(string VendorID)
        {
            try
            {
                IVendorMasterViewModel model = new VendorMasterViewModel();
                model.VendorMasterDTO = new VendorMaster();
                model.VendorMasterDTO.ConnectionString = _connectioString;
                model.VendorMasterDTO.VendorID = Convert.ToInt32(VendorID);
                IBaseEntityResponse<VendorMaster> response = _VendorMasterServiceAccess.GetGeneralDataByVendorNumber(model.VendorMasterDTO);
                return (response != null && response.Entity != null) ? response.Entity.VendorName : string.Empty;
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }
        // get policy answer
        protected List<GeneralPolicyRules> GetPolicyAnswerByPolicyStatus(string CentreCode, string PolicyApplicableStatus, string PolicyCode)
        {
            GeneralPolicyRulesSearchRequest searchRequest = new GeneralPolicyRulesSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.PolicyApplicableStatus = PolicyApplicableStatus;
            searchRequest.centreCode = CentreCode;
            searchRequest.PolicyCode = PolicyCode;
            List<GeneralPolicyRules> listInWardMasterAndInWardDetails = new List<GeneralPolicyRules>();

            IBaseEntityCollectionResponse<GeneralPolicyRules> baseEntityCollectionResponse = _GeneralPolicyRulesServiceAcess.GetPolicyAnswerByPolicyStatus(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listInWardMasterAndInWardDetails = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listInWardMasterAndInWardDetails;
        }
        //DropDown List For Location
        [NonAction]
        protected List<InventoryLocationMaster_1> GetInventoryIssueLocationMasterList(int AdminRoleID)
        {
            InventoryLocationMaster_1SearchRequest searchRequest = new InventoryLocationMaster_1SearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.AdminRoleID = Convert.ToInt16(AdminRoleID);
            List<InventoryLocationMaster_1> listLocationMaster = new List<InventoryLocationMaster_1>();
            IBaseEntityCollectionResponse<InventoryLocationMaster_1> baseEntityCollectionResponse = _inventoryLocationMaster_1ServiceAccess.GetInventoryLocationMasterlistByAdminRole(searchRequest);
            //IBaseEntityCollectionResponse<InventoryLocationMaster_1> baseEntityCollectionResponse = _inventoryLocationMaster_1ServiceAccess.GetInventoryLocationMasterSearchList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listLocationMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listLocationMaster;
        }

        public ActionResult GetGeneralUnitsLocationListByCentreCode(string CentreCode)
        {

            string[] accnmArray = CentreCode.Split(':');
            CentreCode = Convert.ToString(accnmArray[0]);
            var UOMCodeDesc = GetGeneralUnitsLocationList(CentreCode);
            var result = (from s in UOMCodeDesc
                          select new
                          {
                              id = s.InventoryLocationMasterID,
                              name = s.LocationName,
                          }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        protected List<GeneralUnitsStorageLocation> GetGeneralUnitsLocationList(string CentreCode)
        {
            GeneralUnitsStorageLocationSearchRequest searchRequest = new GeneralUnitsStorageLocationSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.CentreCode = CentreCode;
            List<GeneralUnitsStorageLocation> listLocationMaster = new List<GeneralUnitsStorageLocation>();
            IBaseEntityCollectionResponse<GeneralUnitsStorageLocation> baseEntityCollectionResponse = _GeneralUnitsStorageLocationServiceAccess.GetStorageLocationForRequisition(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listLocationMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listLocationMaster;
        }

        //Code for Item Serach List
        //[HttpPost]
        //public JsonResult GetItemSearchList(string term, string StorageLocationID)
        //{
        //    InventoryItemMasterSearchRequest searchRequest = new InventoryItemMasterSearchRequest();
        //    searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
        //    searchRequest.LocationID = Convert.ToInt32(!string.IsNullOrEmpty(StorageLocationID) ? StorageLocationID : null);
        //    searchRequest.SearchWord = term;
        //    List<InventoryItemMaster> listFeeSubType = new List<InventoryItemMaster>();
        //    IBaseEntityCollectionResponse<InventoryItemMaster> baseEntityCollectionResponse = _inventoryItemMasterServiceAccess.GetInventoryItemSearchList(searchRequest);
        //    if (baseEntityCollectionResponse != null)
        //    {
        //        if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
        //        {
        //            listFeeSubType = baseEntityCollectionResponse.CollectionResponse.ToList();
        //        }
        //    }
        //    var result = (from r in listFeeSubType
        //                  select new
        //                  {
        //                      id = r.ID,
        //                      name = r.ItemName,
        //                      itemCode = r.ItemCode,
        //                      rate = r.SaleRate,
        //                      picture = r.Picture,
        //                      currencyCode = r.CurrencyCode,
        //                      currentStockQty = r.CurrentStockQty,
        //                      unitID = r.UnitID,
        //                      unitCode = r.UnitCode,
        //                      IsExpiry = r.IsExpiry,
        //                      IsTaxInclusive = r.IsTaxInclusive,
        //                      GenTaxGroupMasterID = r.GenTaxGroupMasterID,
        //                      TaxRatePercentage = r.TaxRatePercentage

        //                  }).ToList();
        //    return Json(result, JsonRequestBehavior.AllowGet);
        //}

        public JsonResult GetItemSearchList(string term, string StorageLocationID, string GeneralVendorID, string CentreCode, string PurchaseRequisitionType)
        {
            GeneralItemMasterSearchRequest searchRequest = new GeneralItemMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.GeneralVendorID = Convert.ToInt32(!string.IsNullOrEmpty(GeneralVendorID) ? GeneralVendorID : null);
            searchRequest.SearchWord = term;
            if (CentreCode != null)
            {
            string[] accnmArray = CentreCode.Split(':');
            CentreCode = Convert.ToString(accnmArray[0]);
            searchRequest.CentreCode = CentreCode;
            }
            else
            {
            searchRequest.CentreCode = null;
            }
            searchRequest.PurchaseRequisitionType = Convert.ToInt32(PurchaseRequisitionType);
            List<GeneralItemMaster> listFeeSubType = new List<GeneralItemMaster>();
            IBaseEntityCollectionResponse<GeneralItemMaster> baseEntityCollectionResponse = _generalItemMasterServiceAccess.GetVendorWiseItemSearchListForRequisition(searchRequest);
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
                              //itemDescription = String.Concat(r.ItemDescription, '(', r.OrderUomCode, ')'),
                              itemDescription = r.ItemDescription,
                              barCode = r.BarCode,
                              uomCode = r.OrderUomCode,
                              lastPurchasePrice = r.LastPurchasePrice,
                              genTaxGroupMasterID = r.GenTaxGroupMasterID,
                              generalItemCodeID = r.GeneralItemCodeID,
                              id = r.GeneralItemMasterID,
                              baseUOMQuantity = r.BaseUOMQuantity,
                              baseUOMCode = r.BaseUOMCode,
                              taxpercentage = r.TaxRate,
                              PurchaseGroupCode=r.PurchaseGroupCode,
                              MinimumOrderquantity = r.MinimumOrderquantity,
                              SerialAndBatchManagedBy = r.SerialAndBatchManagedBy,

                          }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        //Serachlist for Vendor name
        [HttpPost]
        public JsonResult GetVendorSearchList(string term)
        {
            GeneralSupplierMasterSearchRequest searchRequest = new GeneralSupplierMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.SearchWord = term;
            List<GeneralSupplierMaster> listFeeSubType = new List<GeneralSupplierMaster>();
            IBaseEntityCollectionResponse<GeneralSupplierMaster> baseEntityCollectionResponse = _IGeneralSupplierMasterServiceAccess.GetBySearchList(searchRequest);
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
                              id = r.ID,
                              name = r.Vender,

                          }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        //Serachlist for department name
        [HttpPost]
        public JsonResult GetDepartmentNameSearchList(string term)
        {
            OrganisationDepartmentMasterSearchRequest searchRequest = new OrganisationDepartmentMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.SearchWord = term;
            List<OrganisationDepartmentMaster> listFeeSubType = new List<OrganisationDepartmentMaster>();
            IBaseEntityCollectionResponse<OrganisationDepartmentMaster> baseEntityCollectionResponse = _organisationDepartmentMasterServiceAcess.GetByDepartmentNameSearchList_ForPurchase(searchRequest);
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
                              id = r.ID,
                              name = r.DepartmentName,

                          }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        #endregion

        // AjaxHandler Method
        #region AjaxHandler
        public ActionResult AjaxHandler(JQueryDataTableParamModel param, string PurchaseRequisitionType, string TransDate,int AdminRoleID)
        {
            if (Session["UserType"] != null)
            {
                int TotalRecords;
                var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
                string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc

                IEnumerable<PurchaseRequisitionMasterViewModel> filteredCountryMaster;
                switch (Convert.ToInt32(sortColumnIndex))
                {
                    case 0:
                        _sortBy = " A.VendorID,PurchaseRequisitionNumber";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = "A.PurchaseRequisitionNumber like '%'";
                        }
                        else
                        {
                            _searchBy = "A.PurchaseRequisitionNumber Like '%" + param.sSearch + "%' or B.Vender Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                        }
                        break;
                    case 1:
                        _sortBy = "Vender " + sortDirection + " ,PurchaseRequisitionNumber";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = "A.PurchaseRequisitionNumber like '%'";
                        }
                        else
                        {
                            _searchBy = "A.PurchaseRequisitionNumber Like '%" + param.sSearch + "%' or B.Vender Like '%" + param.sSearch + "%'";      //this "if" block is added for search functionality
                        }
                        break;
                }
                _sortDirection = sortDirection;
                _rowLength = param.iDisplayLength;
                _startRow = param.iDisplayStart;


                if (!string.IsNullOrEmpty(PurchaseRequisitionType))
                {
                    filteredCountryMaster = GetPurchaseRequisitionMaster(PurchaseRequisitionType, TransDate,AdminRoleID, out TotalRecords);
                }
                else
                {
                    filteredCountryMaster = new List<PurchaseRequisitionMasterViewModel>();
                    TotalRecords = 0;
                }


                if ((filteredCountryMaster.Count()) == 0)
                {
                    filteredCountryMaster = new List<PurchaseRequisitionMasterViewModel>();
                    TotalRecords = 0;
                }

                var records = filteredCountryMaster.Skip(0).Take(param.iDisplayLength);
                var result = from c in records select new[] { Convert.ToString(c.PurchaseRequirementMasterID), Convert.ToString(c.PurchaseRequisitionNumber), Convert.ToString(c.Vendor), Convert.ToString(c.VendorID), Convert.ToString(c.IsOpenForPO), Convert.ToString(c.PurchaseRequisitionBehaviour), Convert.ToString(c.ID) };

                return Json(new { sEcho = param.sEcho, iTotalRecords = TotalRecords, iTotalDisplayRecords = TotalRecords, aaData = result }, JsonRequestBehavior.AllowGet);
            }
            else
            {

                //return View("Login","Account");
                //return RedirectToAction("Login", "Account");
                var result = 0;
                return Json(new { aaData = result }, JsonRequestBehavior.AllowGet);
                // return PartialView("Login");
            }
        }
        #endregion
    }
}