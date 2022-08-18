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
    public class CRMSaleTargetExceptionController : BaseController
    {
        ICRMSaleTargetDetailsServiceAccess _CRMSaleTargetDetailsServiceAcess = null;
        private readonly ILogger _logException;
        ActionModeEnum actionModeEnum;
        string _actionMode = string.Empty;
        string _sortBy = string.Empty;
        string _searchBy = string.Empty;
        string _sortDirection = string.Empty;
        int _startRow;
        int _rowLength;
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

        public CRMSaleTargetExceptionController()
        {
            _CRMSaleTargetDetailsServiceAcess = new CRMSaleTargetDetailsServiceAccess();
        }

        // Controller Methods
        #region Controller Methods
        public ActionResult Index()
        {

            return View("/Views/CRMSales/CRMSaleTargetException/Index.cshtml");
        }

        public ActionResult List(string CRMSaleGroupMasterID, string actionMode)
        {
            try
            {
                CRMSaleTargetDetailsViewModel model = new CRMSaleTargetDetailsViewModel();
                if (!string.IsNullOrEmpty(actionMode))
                {
                    TempData["ActionMode"] = actionMode;
                }
                return PartialView("/Views/CRMSales/CRMSaleTargetException/List.cshtml", model);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }



        public ActionResult Create()
        {
            CRMSaleTargetDetailsViewModel model = new CRMSaleTargetDetailsViewModel();
            List<CRMSaleTargetDetails> CRMSaleTargetType = GetListCRMSaleTargetType();
            List<SelectListItem> CRMSaleTargetTypeList = new List<SelectListItem>();
            foreach (CRMSaleTargetDetails item in CRMSaleTargetType)
            {
                CRMSaleTargetTypeList.Add(new SelectListItem { Text = item.TargetType, Value = Convert.ToString(item.CRMSaleTargetTypeId) });
            }

            ViewBag.CRMSaleTargetTypeList = new SelectList(CRMSaleTargetTypeList, "Value", "Text");

            List<SelectListItem> EmpEmployeeMaster = new List<SelectListItem>();
            ViewBag.EmpEmployeeMasterList = new SelectList(EmpEmployeeMaster, "Value", "Text");

            //Get GeneralPeriodTypeMaster List
            List<GeneralPeriodTypeMaster> GeneralPeriodTypeMaster = GetListGeneralPeriodTypeMaster();
            List<SelectListItem> GeneralPeriodTypeMasterList = new List<SelectListItem>();
            foreach (GeneralPeriodTypeMaster item in GeneralPeriodTypeMaster)
            {
                GeneralPeriodTypeMasterList.Add(new SelectListItem { Text = item.PeriodType, Value = Convert.ToString(item.GeneralPeriodTypeMasterID) });
            }

            ViewBag.GetGeneralPeriodTypeMasterList = new SelectList(GeneralPeriodTypeMasterList, "Value", "Text");

            return PartialView("/Views/CRMSales/CRMSaleTargetException/Create.cshtml", model);
        }

        [HttpPost]
        public ActionResult Create(CRMSaleTargetDetailsViewModel model)
        {
            try
            {
                if (model != null && model.CRMSaleTargetDetailsDTO != null)
                {
                    model.CRMSaleTargetDetailsDTO.ConnectionString = _connectioString;
                    model.CRMSaleTargetDetailsDTO.EmployeeId = model.EmployeeId;
                    model.CRMSaleTargetDetailsDTO.CRMSaleTargetTypeId = model.CRMSaleTargetTypeId;
                    model.CRMSaleTargetDetailsDTO.TargetValue = model.TargetValue;
                    model.CRMSaleTargetDetailsDTO.FromDate = model.FromDate;
                    model.CRMSaleTargetDetailsDTO.GeneralPeriodTypeMasterID = model.GeneralPeriodTypeMasterID;

                    model.CRMSaleTargetDetailsDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                    IBaseEntityResponse<CRMSaleTargetDetails> response = _CRMSaleTargetDetailsServiceAcess.InsertCRMSaleTargetException(model.CRMSaleTargetDetailsDTO);
                    model.CRMSaleTargetDetailsDTO.errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                    return Json(model.CRMSaleTargetDetailsDTO.errorMessage, JsonRequestBehavior.AllowGet);
                }
                return Json("Please review your form");
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }

        }

        public ActionResult InActive(int ID)
        {
            var errorMessage = string.Empty;
            if (ID > 0)
            {

                IBaseEntityResponse<CRMSaleTargetDetails> response = null;
                CRMSaleTargetDetails CRMSaleTargetDetailsDTO = new CRMSaleTargetDetails();
                CRMSaleTargetDetailsDTO.ConnectionString = _connectioString;
                CRMSaleTargetDetailsDTO.CRMSaleTargetExceptionID = Convert.ToInt16(ID);
                CRMSaleTargetDetailsDTO.ModifiedBy = Convert.ToInt32(Session["UserID"]);
                response = _CRMSaleTargetDetailsServiceAcess.UpdateCRMSaleTargetException(CRMSaleTargetDetailsDTO);
                errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.InActive);
            }

            return Json(errorMessage, JsonRequestBehavior.AllowGet);
        }
        #endregion

        // Non-Action Method
        #region Methods

        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult GetEmployeeListNotInTargetException(string SelectedTargetTypeID)
        {

            int id = 0;
            bool isValid = Int32.TryParse(SelectedTargetTypeID, out id);
            //var employee = GetListEmpEmployeeMasterInCRMSales(0, "EmployeeListNotInTargetException");
            var employee = GetListEmpEmployeeMasterForTargetException(Convert.ToInt32(SelectedTargetTypeID));
            var result = (from s in employee
                          select new
                          {
                              id = s.ID,
                              name = s.EmployeeFullName + '(' + s.EmployeeDesignation + ')',
                          }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public IEnumerable<CRMSaleTargetDetailsViewModel> GetCRMSaleTargetException(out int TotalRecords)
        {
            CRMSaleTargetDetailsSearchRequest searchRequest = new CRMSaleTargetDetailsSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            _actionMode = Convert.ToString(TempData["ActionMode"]);
            if (Enum.TryParse(_actionMode, out actionModeEnum))     // checks actionMode i.e. Insert or Update // 
            {
                if (actionModeEnum == ActionModeEnum.Insert)        // parameters for SelectAll procedures under Insert or Update mode condition
                {
                    searchRequest.SortBy = "B.CreatedDate";
                    searchRequest.StartRow = 0;
                    searchRequest.EndRow = 10;
                    searchRequest.SearchBy = String.Empty;
                    searchRequest.SortDirection = "Desc";
                }
                if (actionModeEnum == ActionModeEnum.Update)
                {
                    searchRequest.SortBy = "B.ModifiedDate";
                    searchRequest.StartRow = 0;
                    searchRequest.EndRow = 10;
                    searchRequest.SearchBy = String.Empty;
                    searchRequest.SortDirection = "Desc";
                }
            }
            else
            {
                searchRequest.SortBy = _sortBy;                     // parameters for SelectAll procedures under normal condition
                searchRequest.StartRow = _startRow;
                searchRequest.EndRow = _startRow + _rowLength;
                searchRequest.SearchBy = _searchBy;
                searchRequest.SortDirection = _sortDirection;
            }
            List<CRMSaleTargetDetailsViewModel> listCRMSaleGroupMasterViewModel = new List<CRMSaleTargetDetailsViewModel>();
            List<CRMSaleTargetDetails> listCRMSaleGroupMaster = new List<CRMSaleTargetDetails>();
            IBaseEntityCollectionResponse<CRMSaleTargetDetails> baseEntityCollectionResponse = _CRMSaleTargetDetailsServiceAcess.GetBySearchCRMSaleTargetException(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listCRMSaleGroupMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (CRMSaleTargetDetails item in listCRMSaleGroupMaster)
                    {
                        CRMSaleTargetDetailsViewModel CRMSaleGroupMasterViewModel = new CRMSaleTargetDetailsViewModel();
                        CRMSaleGroupMasterViewModel.CRMSaleTargetDetailsDTO = item;
                        listCRMSaleGroupMasterViewModel.Add(CRMSaleGroupMasterViewModel);
                    }
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listCRMSaleGroupMasterViewModel;
        }




        #endregion

        // AjaxHandler Method
        #region AjaxHandler
        public ActionResult AjaxHandler(JQueryDataTableParamModel param)
        {
            if (Session["UserType"] != null)
            {
                int TotalRecords;
                var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
                string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc

                IEnumerable<CRMSaleTargetDetailsViewModel> filteredCRMSaleTargetException;
                switch (Convert.ToInt32(sortColumnIndex))
                {
                    case 0:
                        _sortBy = "B.EmployeeName";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            _searchBy = "A.TargetType Like '%" + param.sSearch + "%' or B.EmployeeName Like '%" + param.sSearch + "%' or B.TargetValue Like '%" + param.sSearch + "%' or B.FromDate Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                        }
                        break;
                    case 1:
                        _sortBy = "B.EmployeeName";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            _searchBy = "A.TargetType Like '%" + param.sSearch + "%' or B.EmployeeName Like '%" + param.sSearch + "%' or B.TargetValue Like '%" + param.sSearch + "%' or B.FromDate Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                        }
                        break;
                    case 2:
                        _sortBy = "B.FromDate";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            _searchBy = "A.TargetType Like '%" + param.sSearch + "%' or B.EmployeeName Like '%" + param.sSearch + "%' or B.TargetValue Like '%" + param.sSearch + "%' or B.FromDate Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                        }
                        break;
                    case 3:
                        _sortBy = "B.TargetValue";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            _searchBy = "A.TargetType Like '%" + param.sSearch + "%' or B.EmployeeName Like '%" + param.sSearch + "%' or B.TargetValue Like '%" + param.sSearch + "%' or B.FromDate Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                        }
                        break;


                }
                _sortDirection = sortDirection;
                _rowLength = param.iDisplayLength;
                _startRow = param.iDisplayStart;
                filteredCRMSaleTargetException = GetCRMSaleTargetException(out TotalRecords);

                if ((filteredCRMSaleTargetException.Count()) == 0)
                {
                    filteredCRMSaleTargetException = new List<CRMSaleTargetDetailsViewModel>();
                    TotalRecords = 0;
                }

                var records = filteredCRMSaleTargetException.Skip(0).Take(param.iDisplayLength);
                var result = from c in records select new[] { Convert.ToString(c.EmployeeName), Convert.ToString(c.TargetType), Convert.ToString(c.FromDate), Convert.ToString(c.TargetValue), Convert.ToString(c.CRMSaleTargetTypeId), Convert.ToString(c.CRMSaleTargetExceptionID) };
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














