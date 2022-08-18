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
using System.IO;
using System.Web.Hosting;
using System.Data;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf.parser;
using System.Web;
using iTextSharp.text.html;
using System.Drawing;
using System.Drawing.Imaging;



namespace AMS.Web.UI.Controllers
{
    public class PurchaseOrderMasterAndDetailsController : BaseController
    {
        IPurchaseOrderMasterAndDetailsServiceAccess _PurchaseOrderMasterAndDetailsServiceAccess = null;
        ICRMCallTypeServiceAccess _CRMCallTypeServiceAcess = null;
        IPurchaseRequisitionMasterServiceAccess _PurchaseRequisitionMasterServiceAcess = null;
        private readonly ILogger _logException;
        ActionModeEnum actionModeEnum;
        string _actionMode = string.Empty;
        string _sortBy = string.Empty;
        string _searchBy = string.Empty;
        string _sortDirection = string.Empty;
        int _startRow;
        int _rowLength;
        static string xmlParameter = null;
        static bool IsExcelValid = true;
        static string errorMessage = null;
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

        public PurchaseOrderMasterAndDetailsController()
        {
            _PurchaseOrderMasterAndDetailsServiceAccess = new PurchaseOrderMasterAndDetailsServiceAccess();
            _CRMCallTypeServiceAcess = new CRMCallTypeServiceAccess();
            _PurchaseRequisitionMasterServiceAcess = new PurchaseRequisitionMasterServiceAccess();
        }

        // Controller Methods
        #region ---------------Controller Methods------------------
        public ActionResult Index(string ReplishmentCode, string centerCode,string GeneralUnitsID)
        {
            PurchaseOrderMasterAndDetailsViewModel model = new PurchaseOrderMasterAndDetailsViewModel();
            model.PurchaseOrderMasterAndDetailsDTO.ReplishmentCode = ReplishmentCode;
            model.PurchaseOrderMasterAndDetailsDTO.CentreCode = centerCode;
            model.PurchaseOrderMasterAndDetailsDTO.GeneralUnitsID = Convert.ToInt32(GeneralUnitsID);
            if (TempData["_errorMsg"] != null)
            {
                model.errorMessage = Convert.ToString(TempData["_errorMsg"]);
            }
            else
            {
                model.errorMessage = "NoMessage";
            }
            List<SelectListItem> li = new List<SelectListItem>();
           // li.Add(new SelectListItem { Text = "--Select--", Value = " " });
            //li.Add(new SelectListItem { Text = "Sub Contracting Requisition", Value = "1" });
            //li.Add(new SelectListItem { Text = "Consignment Requision", Value = "2" });
            li.Add(new SelectListItem { Text = "Standard Requisition", Value = "5" });
            li.Add(new SelectListItem { Text = "Stock Transfer Order", Value = "3" });
            //li.Add(new SelectListItem { Text = "Service Requisition", Value = "4" });
           

            ViewData["PurchaseOrderType"] = li;
            return View("/Views/Purchase/PurchaseOrderMasterAndDetails/Index.cshtml", model);
        }

        public ActionResult List(string actionMode, PurchaseOrderMasterAndDetailsViewModel model)
        {
            try
            {
                int AdminRoleID = 0;
                if (Session["RoleID"] == null)
                {
                    AdminRoleID = !string.IsNullOrEmpty(Convert.ToString(Session["DefaultRoleID"])) ? Convert.ToInt32(Session["DefaultRoleID"]) : 0;
                }

                else
                {
                    AdminRoleID = !string.IsNullOrEmpty(Convert.ToString(Session["RoleID"])) ? Convert.ToInt32(Session["RoleID"]) : 0;
                }

                if (!string.IsNullOrEmpty(actionMode))
                {
                    TempData["ActionMode"] = actionMode;
                }
                model.AdminRoleID = AdminRoleID;
                return PartialView("/Views/Purchase/PurchaseOrderMasterAndDetails/List.cshtml", model);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        [HttpGet]
        public ActionResult Create(int PurchaseRequisitionMasterID, string Vendor, string PurchaseOrderTypeDescription, int VendorID, Int16 PurchaseOrderType)
        {
            PurchaseOrderMasterAndDetailsViewModel model = new PurchaseOrderMasterAndDetailsViewModel();
            model.PurchaseRequisitionMasterID = PurchaseRequisitionMasterID;
            model.Vendor = Vendor;
            model.PurchaseOrderTypeDescription = PurchaseOrderTypeDescription;
            model.VendorID = VendorID;
            model.PurchaseOrderType = PurchaseOrderType;
            PurchaseOrderMasterAndDetailsSearchRequest searchRequest = new PurchaseOrderMasterAndDetailsSearchRequest();
            searchRequest.ConnectionString = _connectioString;
            searchRequest.PurchaseRequisitionMasterID = PurchaseRequisitionMasterID;
            IBaseEntityCollectionResponse<PurchaseOrderMasterAndDetails> baseEntityCollectionResponse = _PurchaseOrderMasterAndDetailsServiceAccess.SelectByPurchaseRequisitionMasterID(searchRequest);

            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    model.PurchaseRequisitionList = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return PartialView("/Views/Purchase/PurchaseOrderMasterAndDetails/Create.cshtml", model);
        }


        [HttpGet]
        public ActionResult ViewPurchasaeOrder(int PurchaseRequisitionMasterID, string PurchaseOrderTypeDescription, int VendorID, Int16 PurchaseOrderType)
        {
            PurchaseOrderMasterAndDetailsViewModel model = new PurchaseOrderMasterAndDetailsViewModel();
            model.PurchaseRequisitionMasterID = PurchaseRequisitionMasterID;
            //model.Vendor = Vendor;
            model.PurchaseOrderTypeDescription = PurchaseOrderTypeDescription;
            model.VendorID = VendorID;
            model.PurchaseOrderType = PurchaseOrderType;
            PurchaseOrderMasterAndDetailsSearchRequest searchRequest = new PurchaseOrderMasterAndDetailsSearchRequest();
            searchRequest.ConnectionString = _connectioString;
            searchRequest.PurchaseRequisitionMasterID = PurchaseRequisitionMasterID;
            IBaseEntityCollectionResponse<PurchaseOrderMasterAndDetails> baseEntityCollectionResponse = _PurchaseOrderMasterAndDetailsServiceAccess.SelectByPurchaseRequisitionMasterID(searchRequest);

            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    model.PurchaseRequisitionList = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            model.Vendor = model.PurchaseRequisitionList[0].Vendor;
            return PartialView("/Views/Purchase/PurchaseOrderMasterAndDetails/ViewPurchaseOrder.cshtml", model);
        }

        [HttpGet]
        public ActionResult ViewPurchaseRequisition(int PurchaseRequisitionMasterID)
        {
            try
            {
                PurchaseRequisitionMasterViewModel model = new PurchaseRequisitionMasterViewModel();
                model.PurchaseRequisitionMasterList = GetPurchaseRequisitionMasterList(PurchaseRequisitionMasterID);
                //model.PurchaseRequisitionMasterList = GetPurchaseRequisitionMasterList(id);
                if (model.PurchaseRequisitionMasterList.Count > 0 && model.PurchaseRequisitionMasterList != null)
                {
                    model.PurchaseRequisitionNumber = model.PurchaseRequisitionMasterList[0].PurchaseRequisitionNumber;
                    model.TransDate = model.PurchaseRequisitionMasterList[0].TransDate;
                }
                return PartialView("/Views/Purchase/PurchaseOrderMasterAndDetails/ViewPurchaseRequisition.cshtml", model);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        [HttpPost]
        public ActionResult Create(PurchaseOrderMasterAndDetailsViewModel model)
        {
            string errorMessage = string.Empty;
            try
            {
                if (ModelState.IsValid)
                {
                    model.PurchaseOrderMasterAndDetailsDTO.ConnectionString = _connectioString;
                    model.PurchaseOrderMasterAndDetailsDTO.PurchaseRequisitionMasterID = model.PurchaseRequisitionMasterID;
                    model.PurchaseOrderMasterAndDetailsDTO.PurchaseOrderType = model.PurchaseOrderType;
                    model.PurchaseOrderMasterAndDetailsDTO.VendorID = model.VendorID;
                    model.PurchaseOrderMasterAndDetailsDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                    IBaseEntityResponse<PurchaseOrderMasterAndDetails> response = _PurchaseOrderMasterAndDetailsServiceAccess.InsertPurchaseOrderMasterAndDetails(model.PurchaseOrderMasterAndDetailsDTO);
                    errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert) +','+ response.Entity.ID;
                    

                  
                   return Json(errorMessage, JsonRequestBehavior.AllowGet);


                }
                return Json("Please review your form");
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
                IBaseEntityResponse<PurchaseOrderMasterAndDetails> response = null;
                PurchaseOrderMasterAndDetailsViewModel model = new PurchaseOrderMasterAndDetailsViewModel();
                model.PurchaseOrderMasterAndDetailsDTO.ConnectionString = _connectioString;
                model.PurchaseOrderMasterAndDetailsDTO.ID = ID;
                model.PurchaseOrderMasterAndDetailsDTO.DeletedBy = Convert.ToInt32(Session["UserID"]);
                response = _PurchaseOrderMasterAndDetailsServiceAccess.DeletePurchaseOrderMasterAndDetails(model.PurchaseOrderMasterAndDetailsDTO);
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
        public FileStreamResult Download(int id)
        {
            PurchaseOrderMasterAndDetailsViewModel model = new PurchaseOrderMasterAndDetailsViewModel();
            try
            {
                 
                
                model.PurchaseOrderMasterAndDetailsDTO = new PurchaseOrderMasterAndDetails();
                model.PurchaseOrderMasterAndDetailsDTO.ID = id;
                model.PurchaseOrderMasterAndDetailsDTO.ConnectionString = _connectioString;
                decimal amount1 = 0; int itemcount = 0; decimal taxamount1 = 0; decimal totalamount = 0; decimal Grossamount = 0; decimal discountamount = 0;
                //Code For Generate PDF
                model.PurchaseOrderList = GetRecordForPurchaseOrderPDF(id);
                model.PurchaseOrderNumber = model.PurchaseOrderList[0].PurchaseOrderNumber;

                string PurchasePDF = " ";
                if (model.PurchaseOrderList[0].PurchaseOrderType == 3)
                {
                PurchasePDF = PurchasePDF + "<html><body><span style='text-align:center'><b>Stock Transfer Order</b><br></body></html>";
                }
                else
                {
                PurchasePDF = PurchasePDF + "<html><body><span style='text-align:center'><b>Purchase Order</b><br></body></html>";
                }
               
               
                //*********** Code for Logo********
                PurchasePDF = PurchasePDF + "<table><tr><td style='text-align:left;'><img src='" + Path.Combine(Server.MapPath("~") + "Content\\UploadedFiles\\Inventory_1\\Logo\\" + model.PurchaseOrderList[0].LogoPath) + "' height='70' width='130'></td></tr></table>";
                PurchasePDF = PurchasePDF + "<table style='width:100%; border-collapse:collapse;border-spacing:0;margin: 0;padding: 0;'><tr><td width='40%' valign='top'>";
                //PurchasePDF = PurchasePDF + "<table style=' border-collapse:collapse; border-spacing:0;margin: 0;padding: 0;'><tr><th style='padding: 5px;font-size:7pt;text-align:left'><b>Company Name:<b></th></tr><tr><td style='font-size:7pt;text-align:left'>" + model.PurchaseOrderList[0].PrintingLine1 + "</td></tr> <tr><td style='font-size:7pt;text-align:left'>" + model.PurchaseOrderList[0].PrintingLine2 + "</td></tr><tr><td style='font-size:7pt;text-align:left'>" + model.PurchaseOrderList[0].PrintingLine3 + "</td></tr><tr><td style='font-size:7pt;text-align:left'>" + model.PurchaseOrderList[0].PrintingLine4 + "</td></tr></table></td style='font-size:7pt'><td style='border: 1px solid black;border-collapse: collapse; padding: 5px; width='50%';'>";
                //PurchasePDF = PurchasePDF + "<table style=' border-collapse:collapse; border-spacing:0;margin: 0;padding: 0;'><tr><th style='padding: 5px;font-size:7pt;text-align:left'><b>Company Name:<b></th></tr><tr><td style='font-size:7pt;text-align:left'>" + model.PurchaseOrderList[0].PrintingLine1 + "</td></tr> <tr><td style='font-size:7pt;text-align:left'>" + model.PurchaseOrderList[0].LocationAddress + "</td></tr><tr><td style='font-size:7pt;text-align:left'>" + model.PurchaseOrderList[0].City + " - PO Box - " + model.PurchaseOrderList[0].Pincode + "</td></tr><tr><td style='font-size:7pt;text-align:left'></td></tr></table></td style='font-size:7pt'><td style='border: 1px solid black;border-collapse: collapse; padding: 5px; width='50%';'>";
                PurchasePDF = PurchasePDF + "<table style=' border-collapse:collapse; border-spacing:0;margin: 0;padding: 0;'><tr><th style='padding: 5px;font-size:7pt;text-align:left'><b>Company Name:<b></th></tr><tr><td style='font-size:7pt;text-align:left'>" + model.PurchaseOrderList[0].PrintingLine1 + "</td></tr> <tr><td style='font-size:7pt;text-align:left'>" + model.PurchaseOrderList[0].LocationAddress + "</td></tr><tr><td style='font-size:7pt;text-align:left'>" + model.PurchaseOrderList[0].City + " - PO Box - " + model.PurchaseOrderList[0].Pincode + "</td></tr><tr><td style='font-size:7pt;text-align:left'></td></tr></table></td style='font-size:7pt'><td style='border: 1px solid black;border-collapse: collapse; padding: 5px; width='50%';'>";
                PurchasePDF = PurchasePDF + "<table border= '1' bgcolor='#fff;' color='black' style=' border-collapse:collapse;font-size:7pt;'><b>PurchaseOrder</b><tr><td bgcolor='#D3D3D3' style='border: 1px solid black;border-collapse: collapse; padding: 5px;font-size:7pt;text-align:left; '>Purchase Order Number</td><td style='border: 1px solid black;border-collapse: collapse; padding: 5px;font-size:7pt;text-align:left; '>" + model.PurchaseOrderList[0].PurchaseOrderNumber + "</td></tr><tr><td bgcolor='#D3D3D3' style='border: 1px solid black;border-collapse: collapse; padding: 5px;font-size:7pt;text-align:left;'> Order Date</td><td style='border: 1px solid black;border-collapse: collapse; padding: 5px;font-size:7pt;text-align:left; '>" + model.PurchaseOrderList[0].PurchaseOrderDate + "</td></tr><tr><td bgcolor='#D3D3D3' style='border: 1px solid black;border-collapse: collapse; padding: 5px;text-align:left; '>Delivery Date</td><td style='border: 1px solid black;border-collapse: collapse; padding: 5px;font-size:7pt;text-align:left; '>" + model.PurchaseOrderList[0].ExpectedDeliveryDate + "</td> </tr><tr><td bgcolor='#D3D3D3' style='border: 1px solid black;border-collapse: collapse; padding: 5px;text-align:left; '>Currency</td><td style='border: 1px solid black;border-collapse: collapse; padding: 5px;font-size:7pt;text-align:left; '>" + model.PurchaseOrderList[0].Currency + "</td> </tr><tr><td bgcolor='#D3D3D3' style='border: 1px solid black;border-collapse: collapse; padding: 5px;text-align:left; '>Ship To</td><td style='border: 1px solid black;border-collapse: collapse; padding: 5px;font-size:7pt;text-align:left; '>" + model.PurchaseOrderList[0].UnitName + "</td></tr></table></td></tr></table>";
               // PurchasePDF = PurchasePDF + "<table border= '1' bgcolor='#fff;' color='black' style=' border-collapse:collapse;font-size:7pt;'><b>PurchaseOrder</b><tr><td bgcolor='#D3D3D3' style='border: 1px solid black;border-collapse: collapse; padding: 5px;font-size:7pt;text-align:left; '>Purchase Order Number</td><td style='border: 1px solid black;border-collapse: collapse; padding: 5px;font-size:7pt;text-align:left; '>" + model.PurchaseOrderList[0].PurchaseOrderNumber + "</td></tr><tr><td bgcolor='#D3D3D3' style='border: 1px solid black;border-collapse: collapse; padding: 5px;font-size:7pt;text-align:left;'> Order Date</td><td style='border: 1px solid black;border-collapse: collapse; padding: 5px;font-size:7pt;text-align:left; '>" + model.PurchaseOrderList[0].PurchaseOrderDate + "</td></tr><tr><td bgcolor='#D3D3D3' style='border: 1px solid black;border-collapse: collapse; padding: 5px;text-align:left; '>Delivery Date</td><td style='border: 1px solid black;border-collapse: collapse; padding: 5px;font-size:7pt;text-align:left; '>" + model.PurchaseOrderList[0].ExpectedDeliveryDate + "</td> </tr><tr><td bgcolor='#D3D3D3' style='border: 1px solid black;border-collapse: collapse; padding: 5px;text-align:left; '>Currency</td><td style='border: 1px solid black;border-collapse: collapse; padding: 5px;font-size:7pt;text-align:left; '>" + model.PurchaseOrderList[0].Currency + "</td> </tr><tr><td bgcolor='#D3D3D3' style='border: 1px solid black;border-collapse: collapse; padding: 5px;text-align:left; '>Ship To</td><td style='border: 1px solid black;border-collapse: collapse; padding: 5px;font-size:7pt;text-align:left; '>" + model.PurchaseOrderList[0].UnitName + "</td> </tr><tr><td bgcolor='#D3D3D3' style='border: 1px solid black;border-collapse: collapse; padding: 5px;text-align:left; '>Address</td><td style='border: 1px solid black;border-collapse: collapse; padding: 5px;font-size:7pt;text-align:left; '>" + model.PurchaseOrderList[0].LocationAddress + "," + model.PurchaseOrderList[0].City + "</td></tr></table></td></tr></table>";
                if (model.PurchaseOrderList[0].PurchaseOrderType == 3)
                {
                    PurchasePDF = PurchasePDF + "<table style='width:100%;'><tr><td valign='top'>";
                    PurchasePDF = PurchasePDF + "<table style='border-collapse: collapse;border-spacing:0;margin: 0;padding: 0;'><tr><td style='padding-top: 0;font-size:7pt;text-align:left'>Ship From: " + model.PurchaseOrderList[0].FromUnitName + "</td></tr><tr><td style='padding-top: 0;font-size:7pt;text-align:left'>" + model.PurchaseOrderList[0].FromLocationAddress + "</td></tr><tr><td style='padding-top: 0;font-size:7pt;text-align:left'>" + model.PurchaseOrderList[0].FromCity + " - PO Box - " + model.PurchaseOrderList[0].FromPincode + "</td></tr></table></td><td>";
                    PurchasePDF = PurchasePDF + "</td></tr></table>";
                }
                else           
                {
                    PurchasePDF = PurchasePDF + "<table style='width:100%;'><tr><td valign='top'>";
                    PurchasePDF = PurchasePDF + "<table style='border-collapse: collapse;border-spacing:0;margin: 0;padding: 0;'><tr><td style='padding-top: 0;font-size:7pt;text-align:left'>Vendor: " + model.PurchaseOrderList[0].VendorName + "</td></tr><tr><td style='padding-top: 0;font-size:7pt;text-align:left'>" + model.PurchaseOrderList[0].VendorAddress + "</td></tr><tr><td style='padding-top: 0;font-size:7pt;text-align:left'>" + model.PurchaseOrderList[0].VendorPinCode + "</td></tr><tr><td style='padding-top: 0;font-size:7pt;text-align:left'>" + model.PurchaseOrderList[0].VendorPhoneNumber + "</td></tr></table></td><td>";
                    PurchasePDF = PurchasePDF + "</td></tr></table>";
                }

                PurchasePDF = PurchasePDF + "<table  border= '0' style='width:100%;'><tr><td style='text-align:left;font-size:7pt;' width='10%'>Mode Of Payment :</td>";
             
                    if (model.PurchaseOrderList[0].CashOnDelivery == Convert.ToBoolean(0))
                    {
                        PurchasePDF = PurchasePDF + "<td style='text-align:left;font-size:7pt;' width='8%'><img  src='" + Path.Combine(Server.MapPath("~") + "Content\\images\\", "Unchecked.gif") + "' height='10' width='10'>  Cash On Delivery</td>";
                        //PurchasePDF = PurchasePDF + "<td style='text-align:left;font-size:7pt;' width='12%'>Cash On Delivery</td>";
                    
                    }
                    else
                    {
                        PurchasePDF = PurchasePDF + "<td style='text-align:left;font-size:7pt;' width='8%'><img  src='" + Path.Combine(Server.MapPath("~") + "Content\\images\\", "Checked.jpg") + "' height='10' width='10'>  Cash On Delivery</td>";
                        //PurchasePDF = PurchasePDF + "<td style='text-align:left;font-size:7pt;' width='12%'>Cash On Delivery</td>";
                    }

                    if (model.PurchaseOrderList[0].CurrentDatedCheque == Convert.ToBoolean(0))
                    {
                        PurchasePDF = PurchasePDF + "<td style='text-align:left;font-size:7pt;'width='8%'><img src='" + Path.Combine(Server.MapPath("~") + "Content\\images\\", "Unchecked.gif") + "' height='10' width='10'>  Current Dated Cheque</td>";
                        //PurchasePDF = PurchasePDF + "<td style='text-align:left;font-size:7pt;' width='13%'>Current Dated Cheque</td>";
                    }
                    else
                    {
                        PurchasePDF = PurchasePDF + "<td style='text-align:left;font-size:7pt;'width='8%'><img  src='" + Path.Combine(Server.MapPath("~") + "Content\\images\\", "Checked.jpg") + "' height='10' width='10'>  Current Dated Cheque</td>";
                        //PurchasePDF = PurchasePDF + "<td style='text-align:left;font-size:7pt;' width='13%'>Current Dated Cheque</td>";
                    }

                    if (model.PurchaseOrderList[0].Credit == Convert.ToBoolean(0))
                    {
                        PurchasePDF = PurchasePDF + "<td style='text-align:left;font-size:7pt;' width='5%'><img src='" + Path.Combine(Server.MapPath("~") + "Content\\images\\", "Unchecked.gif") + "' height='10' width='10'>  Credit</td>";
                        //PurchasePDF = PurchasePDF + "<td style='text-align:left;font-size:7pt;' width='5%'>Credit</td>";
                    }
                    else
                    {
                        PurchasePDF = PurchasePDF + "<td style='text-align:left;font-size:7pt;' width='5%'><img src='" + Path.Combine(Server.MapPath("~") + "Content\\images\\", "Checked.jpg") + "' height='10' width='10'>  Credit</td>";
                        //PurchasePDF = PurchasePDF + "<td style='text-align:left;font-size:7pt;' width='5%'>Credit</td>";
                    }
              
                PurchasePDF = PurchasePDF + "</tr></table>";

                PurchasePDF = PurchasePDF + "<br><table border= '1' bgcolor='#fff;' color='black'><tr><th  bgcolor='#D3D3D3' color='black' style='border: 1px solid black; border-collapse: collapse; text-align: center; padding: 5px;font-size:7pt'>Item Name</th><th  bgcolor='#D3D3D3' color='black' style='border: 1px solid black; border-collapse: collapse; text-align: center; padding: 5px;font-size:7pt'>Barcode</th><th  bgcolor='#D3D3D3' color='black' style='border: 1px solid black; border-collapse: collapse; text-align: center; padding: 5px;font-size:7pt'>Quantity</th><th  bgcolor='#D3D3D3' color='black' style='border: 1px solid black; border-collapse: collapse; text-align: center; padding: 0px;font-size:7pt'>Unit</th><th  bgcolor='#D3D3D3' color='black' style='border: 1px solid black; border-collapse: collapse; text-align: center; padding: 0px;font-size:7pt'>Pack Size</th><th  bgcolor='#D3D3D3' color='black' style='border: 1px solid black; border-collapse: collapse; text-align: center; padding: 5px;font-size:7pt'>Location</th><th  bgcolor='#D3D3D3' color='black' style='border: 1px solid black; border-collapse: collapse; text-align: center; padding: 5px;font-size:7pt'>Rate</th><th  bgcolor='#D3D3D3' color='black' style='border: 1px solid black; border-collapse: collapse; text-align: center; padding: 5px;font-size:7pt'>Amount</th></tr>";

                if (model.PurchaseOrderList.Count > 0 && model.PurchaseOrderList != null)
                {
                    foreach (var item in model.PurchaseOrderList)
                    {
                        amount1 = Math.Round((amount1 + item.Amount),2);
                        taxamount1 = Math.Round((taxamount1 +   item.TotalTaxAmount),2);
                        //itemcount = itemcount + item.ItemCount;
                        PurchasePDF = PurchasePDF + "<tr><td  bgcolor='#F7F2F2' width='27%' color='black' style='border-collapse: collapse; text-align: left; padding: 5px;font-size:7pt;'>" + item.ItemName + "</td><td  bgcolor='#F7F2F2' width='12%' color='black' style='border: 1px black; border-collapse: collapse; text-align: center; padding: 5px;font-size:7pt;'>" + item.BarCode + "</td><td  bgcolor='#F7F2F2' width='7%' color='black' style='border: 1px black; border-collapse: collapse; text-align: center; padding: 5px;font-size:7pt;'>" + Math.Round(item.Quantity, 3) + "</td><td  bgcolor='#F7F2F2' width='7%' color='black' style='border: 1px black; border-collapse: collapse; text-align: center; padding: 5px;font-size:7pt;'>" + item.OrderUomCode + "</td><td  bgcolor='#F7F2F2'  width='9%' color='black' style='border: 1px black; border-collapse: collapse; text-align: center; padding: 5px;font-size:7pt;'>" + Math.Round(item.Quantity) + "*" + item.BaseUOMQuantity + "</td><td  bgcolor='#F7F2F2' width='7%' color='black' style='border: 1px black; border-collapse: collapse; text-align: left; padding: 5px; font-size:7pt;'>" + item.LocationName + "</td><td  bgcolor='#F7F2F2'  width='8%' color='black' style='border: 1px black; border-collapse: collapse; text-align: center; padding: 5px;font-size:7pt;text-align:right '>" + Math.Round(item.Rate, 2) + "</td><td  bgcolor='#F7F2F2'  width='8%' color='black' style='border: 1px black; border-collapse: collapse; text-align: center; padding: 5px;font-size:7pt; text-align:right'>" + Math.Round(item.Amount, 2) + "</td></tr>";
                    }
                }
                discountamount =Math.Round(((amount1 * model.PurchaseOrderList[0].Discount)/100),2);
                Grossamount = Math.Round((amount1 + taxamount1 - discountamount + model.PurchaseOrderList[0].Freight + model.PurchaseOrderList[0].ShippingHandling), 2);
                PurchasePDF = PurchasePDF + "</table>";
                PurchasePDF = PurchasePDF + "<br><table style='width:100%;'><tr><td width='40%'>";
                //PurchasePDF = PurchasePDF + "<table border= '1' bgcolor='#fff;' color='black'><tr><th  bgcolor='#D3D3D3' style='border: 1px solid black;border-collapse: collapse; padding: 5px;font-size:8pt'>Vendor</th></tr><tr><td  bgcolor='#F7F2F2'  color='black' style=' text-align: Left; padding: 5px;font-size:8pt'>" + model.PurchaseOrderList[0].VendorName + "<br>" + model.PurchaseOrderList[0].VendorAddress + "<br>" + model.PurchaseOrderList[0].VendorPinCode + "<br>" + model.PurchaseOrderList[0].VendorPhoneNumber + "</td><br><br></td></tr></table></td style='font-size:8pt'><td style='border: 1px solid black;border-collapse: collapse; padding: 5px; width='45%';'>";

                //PurchasePDF = PurchasePDF + "<table border= '1' bgcolor='#fff;' color='black'><tr><td bgcolor='#D3D3D3' style='border: 1px;font-size:8pt; solid black;border-collapse: collapse; padding: 5px;text-align:right;'>Sub Total</td><td style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:right; '>" + amount1 + "</td></tr></tr><tr><td bgcolor='#D3D3D3' style='border: 1px solid black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:right;'>Tax</td><td style='border: 1px black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:right;'>" + taxamount1 + "</td></tr><tr><td bgcolor='#D3D3D3' style='border: 1px;font-size:8pt; solid black;border-collapse: collapse; padding: 5px; text-align:right;'>Discount(%)</td><td style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt; text-align:right;'>" + Math.Round(model.PurchaseOrderList[0].Discount,2) + "</td></tr><tr><td bgcolor='#D3D3D3' style='border: 1px;font-size:8pt; solid black;border-collapse: collapse; padding: 5px; text-align:right;'>S & H</td><td style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt ;text-align:right;'>" + Math.Round(model.PurchaseOrderList[0].ShippingHandling, 2) + "</td></tr><tr><td bgcolor='#D3D3D3' style='border: 1px;font-size:8pt; solid black;border-collapse: collapse; padding: 5px;text-align:right; '>Misc</td><td style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:right; '>" + Math.Round(model.PurchaseOrderList[0].Freight, 2) + "</td></tr><tr><td bgcolor='#D3D3D3' style='border: 1px;font-size:8pt; solid black;border-collapse: collapse; padding: 5px;text-align:right; '> Total Amount</td><td style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:right; '>" + Grossamount + "</td> </tr></table></td></tr></table>";
                PurchasePDF = PurchasePDF + "<table border= '1' bgcolor='#fff;' color='black'><tr><td bgcolor='#D3D3D3' style='border: 1px;font-size:8pt; solid black;border-collapse: collapse; padding: 5px;text-align:right;'>Sub Total</td><td style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:right; '>" + amount1 + "</td></tr></tr><tr><td bgcolor='#D3D3D3' style='border: 1px solid black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:right;'>Tax</td><td style='border: 1px black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:right;'>" + taxamount1 + "</td></tr><tr><td bgcolor='#D3D3D3' style='border: 1px;font-size:8pt; solid black;border-collapse: collapse; padding: 5px;text-align:right; '> Total Amount</td><td style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:right; '>" + Grossamount + "</td> </tr></table></td></tr></table>";

                PurchasePDF = PurchasePDF + "<table><tr><td width='50%'>";
                PurchasePDF = PurchasePDF + "<table style='width:50%' ><tr><th style='font-size:8pt;text-align:left'>Authorized By</th></tr><tr><td style='text-align:left'> ___________________</td></tr></table><td width='50%'>";
                PurchasePDF = PurchasePDF + "<table style='width:50%' ><tr><th style='font-size:8pt;text-align:left'>Date</th></tr><tr><td style='text-align:left'> ___________________</td></tr></table></td></tr></table>";
                DownloadPDF1(PurchasePDF, model.PurchaseOrderNumber, model.PurchaseOrderList[0].VendorNumber, model.PurchaseOrderList[0].IsDeleted);
                MemoryStream workStream = new MemoryStream();
                return new FileStreamResult(workStream, "application/pdf");


            }
            catch (Exception)
            {
                throw;
            }
        }
       
        public void DownloadPDF1(string PurchasePDF,string PurchaseOrderNumber,int VendorNumber,bool IsDeleted)
        {
            //string HTMLContent = "Hello <b>World</b>";

            Response.Clear();
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;filename=" +VendorNumber + "_" + PurchaseOrderNumber+".pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.BinaryWrite(GetPDF(PurchasePDF, IsDeleted));
            Response.End();
        }
        //Code For  Download PDF
        public byte[] GetPDF(string pHTML, bool IsDeleted)
        {
            byte[] bPDF = null;

            MemoryStream ms = new MemoryStream();
            TextReader txtReader = new StringReader(pHTML);

            // 1: create object of a itextsharp document class
            Document doc = new Document(PageSize.A4, 25, 25, 25, 25);

            // 2: we create a itextsharp pdfwriter that listens to the document and directs a XML-stream to a file
            PdfWriter oPdfWriter = PdfWriter.GetInstance(doc, ms);
            if (IsDeleted == true)
            {
                PdfWriterEvents writerEvent = new PdfWriterEvents("DELETED");
                oPdfWriter.PageEvent = writerEvent;
            }
            // 3: we create a worker parse the document
            HTMLWorker htmlWorker = new HTMLWorker(doc);


            // 4: we open document and start the worker on the document
            doc.Open();
            //var logo = iTextSharp.text.Image.GetInstance(Server.MapPath("~/Content/images/logo-2.png"));
            //logo.SetAbsolutePosition(440, 800);
            //doc.Add(logo);
            
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
        public FileResult Download()
        {
            string FileName = "CallEnquiryExcelFile.xlsx";
            string filePath = Path.Combine(Server.MapPath("~") + "Content\\DownloadFiles\\", FileName);
            string contentType = "application/vnd.ms-excel";
            return File(filePath, contentType, FileName);
        }

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

        [HttpGet]
        public ActionResult PurchaseOrderApproval(int PersonID, string TNDID, string TNMID, string GTRDID1, string TaskCode, string StageSequenceNumber, string IsLast)
        {
            PurchaseOrderMasterAndDetailsViewModel model = new PurchaseOrderMasterAndDetailsViewModel();
            model.PersonID = Convert.ToInt32(PersonID);
            model.TaskNotificationDetailsID = Convert.ToInt32(TNDID);
            model.TaskNotificationMasterID = Convert.ToInt32(TNMID);
            model.GeneralTaskReportingDetailsID = Convert.ToInt32(GTRDID1);
            model.TaskCode = TaskCode;
            model.StageSequenceNumber = Convert.ToInt32(StageSequenceNumber);
            model.IsLastRecord = Convert.ToBoolean(IsLast);
            model.PurchaseRequisitionList = GetPurchaseOrderRecord(PersonID, Convert.ToInt32(TNMID));
            model.ID = model.PurchaseRequisitionList.Count > 0 ? model.PurchaseRequisitionList[0].ID : 0;
            model.TransDate = model.PurchaseRequisitionList.Count > 0 ? model.PurchaseRequisitionList[0].TransDate : null;
            model.Vendor = model.PurchaseRequisitionList.Count > 0 ? model.PurchaseRequisitionList[0].Vendor : null;
            model.PurchaseOrderTypeDescription = model.PurchaseRequisitionList.Count > 0 ? model.PurchaseRequisitionList[0].PurchaseOrderTypeDescription : null;
            //model.PurchaseRequirementNumber = model.PurchaseRequisitionList.Count > 0 ? model.PurchaseRequisitionList[0].PurchaseRequirementNumber : null;

            return View("/Views/Purchase/PurchaseOrderMasterAndDetails/PurchaseOrderApproval.cshtml", model);
        }

        [HttpPost]
        public ActionResult PurchaseOrderApproval(PurchaseOrderMasterAndDetailsViewModel model)
        {
            try
            {

                if (model != null && model.PurchaseOrderMasterAndDetailsDTO != null)
                {
                    model.PurchaseOrderMasterAndDetailsDTO.ConnectionString = _connectioString;
                    model.PurchaseOrderMasterAndDetailsDTO.PersonID = model.PersonID;
                    model.PurchaseOrderMasterAndDetailsDTO.ID = model.ID;
                    model.PurchaseOrderMasterAndDetailsDTO.IsLastRecord = Convert.ToBoolean(model.IsLastRecord);
                    model.PurchaseOrderMasterAndDetailsDTO.TaskNotificationMasterID = model.TaskNotificationMasterID;
                    model.PurchaseOrderMasterAndDetailsDTO.TaskNotificationDetailsID = model.TaskNotificationDetailsID;
                    model.PurchaseOrderMasterAndDetailsDTO.GeneralTaskReportingDetailsID = model.GeneralTaskReportingDetailsID;
                    model.PurchaseOrderMasterAndDetailsDTO.StageSequenceNumber = model.StageSequenceNumber;
                    model.PurchaseOrderMasterAndDetailsDTO.ApprovedStatus = model.ApprovedStatus;
                    model.PurchaseOrderMasterAndDetailsDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                    IBaseEntityResponse<PurchaseOrderMasterAndDetails> response = _PurchaseOrderMasterAndDetailsServiceAccess.InsertApprovedPurchaseOrderRecord(model.PurchaseOrderMasterAndDetailsDTO);
                    model.PurchaseOrderMasterAndDetailsDTO.errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                    return Json(model.PurchaseOrderMasterAndDetailsDTO.errorMessage, JsonRequestBehavior.AllowGet);

                }
                else
                {
                    return Json("Please review your form");
                }

            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        [NonAction]
        protected List<PurchaseOrderMasterAndDetails> GetPurchaseOrderRecord(int personId, int taskNotificationMasterID)
        {
            PurchaseOrderMasterAndDetailsSearchRequest searchRequest = new PurchaseOrderMasterAndDetailsSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.PersonID = personId;
            searchRequest.TaskNotificationMasterID = taskNotificationMasterID;
            List<PurchaseOrderMasterAndDetails> listPurchaseOrderDetails = new List<PurchaseOrderMasterAndDetails>();
            IBaseEntityCollectionResponse<PurchaseOrderMasterAndDetails> baseEntityCollectionResponse = _PurchaseOrderMasterAndDetailsServiceAccess.GetPurchaseOrderForApproval(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listPurchaseOrderDetails = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listPurchaseOrderDetails;
        }
        #endregion


        #region ----------------------Methods----------------------

        public IEnumerable<PurchaseOrderMasterAndDetailsViewModel> GetPurchaseOrderMasterAndDetails(string PurchaseOrderType, string PurchaseOrderDate, int AdminRoleID,out int TotalRecords)
        {
            PurchaseOrderMasterAndDetailsSearchRequest searchRequest = new PurchaseOrderMasterAndDetailsSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            _actionMode = Convert.ToString(TempData["ActionMode"]);
            if (Enum.TryParse(_actionMode, out actionModeEnum))     // checks actionMode i.e. Insert or Update // 
            {
                if (actionModeEnum == ActionModeEnum.Insert)        // parameters for SelectAll procedures under Insert or Update mode condition
                {
                    searchRequest.SortBy = "C.CreatedDate";
                    searchRequest.StartRow = 0;
                    searchRequest.EndRow = 10;
                    searchRequest.SearchBy = _searchBy;
                    searchRequest.SortDirection = "Desc";
                    searchRequest.PurchaseOrderType = Convert.ToInt16(PurchaseOrderType);
                    searchRequest.PurchaseOrderDate = Convert.ToString(PurchaseOrderDate);
                    searchRequest.AdminRoleID = AdminRoleID;

                }
                if (actionModeEnum == ActionModeEnum.Update)
                {
                    searchRequest.SortBy = "C.ModifiedDate";
                    searchRequest.StartRow = 0;
                    searchRequest.EndRow = 10;
                    searchRequest.SearchBy = _searchBy;
                    searchRequest.SortDirection = "Desc";
                    searchRequest.PurchaseOrderType = Convert.ToInt16(PurchaseOrderType);
                    searchRequest.PurchaseOrderDate = Convert.ToString(PurchaseOrderDate);
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
                searchRequest.PurchaseOrderType = Convert.ToInt16(PurchaseOrderType);
                searchRequest.PurchaseOrderDate = Convert.ToString(PurchaseOrderDate);
                searchRequest.AdminRoleID = AdminRoleID;

            }
            List<PurchaseOrderMasterAndDetailsViewModel> listPurchaseOrderMasterAndDetailsViewModel = new List<PurchaseOrderMasterAndDetailsViewModel>();
            List<PurchaseOrderMasterAndDetails> listPurchaseOrderMasterAndDetails = new List<PurchaseOrderMasterAndDetails>();
            IBaseEntityCollectionResponse<PurchaseOrderMasterAndDetails> baseEntityCollectionResponse = _PurchaseOrderMasterAndDetailsServiceAccess.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listPurchaseOrderMasterAndDetails = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (PurchaseOrderMasterAndDetails item in listPurchaseOrderMasterAndDetails)
                    {
                        PurchaseOrderMasterAndDetailsViewModel PurchaseOrderMasterAndDetailsViewModel = new PurchaseOrderMasterAndDetailsViewModel();
                        PurchaseOrderMasterAndDetailsViewModel.PurchaseOrderMasterAndDetailsDTO = item;
                        listPurchaseOrderMasterAndDetailsViewModel.Add(PurchaseOrderMasterAndDetailsViewModel);
                    }
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listPurchaseOrderMasterAndDetailsViewModel;
        }

        [NonAction]
        protected List<PurchaseOrderMasterAndDetails> GetRecordForPurchaseOrderPDF(int id)
         {
            PurchaseOrderMasterAndDetailsSearchRequest searchRequest = new PurchaseOrderMasterAndDetailsSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.ID = id;
            List<PurchaseOrderMasterAndDetails> listPurchaseOrderMasterAndDetails = new List<PurchaseOrderMasterAndDetails>();
            
            IBaseEntityCollectionResponse<PurchaseOrderMasterAndDetails> baseEntityCollectionResponse = _PurchaseOrderMasterAndDetailsServiceAccess.GetRecordForPurchaseOrderPDF(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listPurchaseOrderMasterAndDetails = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listPurchaseOrderMasterAndDetails;
        }

        #endregion

        // AjaxHandler Method
        #region ------------------AjaxHandler----------------------
        public ActionResult AjaxHandler(JQueryDataTableParamModel param, string PurchaseOrderDate, string PurchaseOrderType, int AdminRoleID)
        {
            if (Session["UserType"] != null)
            {
                int TotalRecords;
                var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
                string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc

                IEnumerable<PurchaseOrderMasterAndDetailsViewModel> filteredCountryMaster;
                switch (Convert.ToInt32(sortColumnIndex))
                {
                    case 0:
                        _sortBy = "A.VendorID,A.PurchaseRequisitionNumber";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = "A.PurchaseRequisitionNumber like '%'";
                        }
                        else
                        {
                            _searchBy = "A.PurchaseRequisitionNumber Like '%" + param.sSearch + "%' or C.PurchaseOrderNumber Like '%" + param.sSearch + "%' or  A.Vendor Like '%" + param.sSearch + "%'";      //this "if" block is added for search functionality
                            //_searchBy = "A.PurchaseRequisitionNumber like Like '%" + param.sSearch + "%' or A.PurchaseRequisitionNumber Like '%" + param.sSearch + "%' or A.Vendor Like '%'";        //this "if" block is added for search functionality
                        }
                        break;
                    case 1:
                        _sortBy = "A.Vendor " + sortDirection + " ,C.PurchaseOrderNumber";
                        if (string.IsNullOrEmpty(param.sSearch)) 
                        {
                            _searchBy = "C.PurchaseOrderNumber like '%'";
                        }
                        else
                        {
                            _searchBy = "A.PurchaseRequisitionNumber Like '%" + param.sSearch + "%' or C.PurchaseOrderNumber Like '%" + param.sSearch + "%' or  A.Vendor Like '%" + param.sSearch + "%'";         //this "if" block is added for search functionality
                        }
                        break;
                    case 2:
                        _sortBy = "A.Vendor " + sortDirection + " ,A.PurchaseRequisitionNumber";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = "C.PurchaseOrderNumber like '%'";
                        }
                        else
                        {
                            _searchBy = "A.PurchaseRequisitionNumber Like '%" + param.sSearch + "%' or C.PurchaseOrderNumber Like '%" + param.sSearch + "%' or  A.Vendor Like '%" + param.sSearch + "%'";         //this "if" block is added for search functionality
                        }
                        break;
                    //case 4:
                    //    _sortBy = "Source";
                    //    if (string.IsNullOrEmpty(param.sSearch))
                    //    {
                    //        _searchBy = "B.CalleeFirstName like '%'";
                    //    }
                    //    else
                    //    {
                    //        _searchBy = "A.ID like Like '%" + param.sSearch + "%' or A.PurchaseRequisitionNumber Like '%" + param.sSearch + "%' or A.Vendor Like '%'";        //this "if" block is added for search functionality
                    //    }
                    //    break;
                    //case 5:
                    //    _sortBy = "SourceContactPerson";
                    //    if (string.IsNullOrEmpty(param.sSearch))
                    //    {
                    //        _searchBy = "B.CalleeFirstName like '%'";
                    //    }
                    //    else
                    //    {
                    //        _searchBy = "A.ID like Like '%" + param.sSearch + "%' or A.PurchaseRequisitionNumber Like '%" + param.sSearch + "%' or A.Vendor Like '%'";        //this "if" block is added for search functionality
                    //    }
                    //    break;

                }
                _sortDirection = sortDirection;
                _rowLength = param.iDisplayLength;
                _startRow = param.iDisplayStart;
                //filteredCountryMaster = new List<PurchaseOrderMasterAndDetailsViewModel>(); 

                if (!string.IsNullOrEmpty(PurchaseOrderType))
                {
                    filteredCountryMaster = GetPurchaseOrderMasterAndDetails(PurchaseOrderType,PurchaseOrderDate,AdminRoleID, out TotalRecords);
                }
                else
                {
                    filteredCountryMaster = new List<PurchaseOrderMasterAndDetailsViewModel>();
                    TotalRecords = 0;
                }


                var records = filteredCountryMaster.Skip(0).Take(param.iDisplayLength);
                var result = from c in records select new[] { Convert.ToString(c.VendorID), Convert.ToString(c.PurchaseRequisitionNumber), Convert.ToString(c.PurchaseOrderNumber), Convert.ToString(c.Vendor), Convert.ToString(c.PurchaseRequisitionMasterID), Convert.ToString(c.ID), Convert.ToString(c.POStatus),Convert.ToString(c.IsDeleted) };
                
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