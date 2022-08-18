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
    public class SalaryDeductionMasterController : BaseController
    {
        ISalaryDeductionMasterServiceAccess _SalaryDeductionMasterServiceAcess = null;
        private readonly ILogger _logException;
        ActionModeEnum actionModeEnum;
        string _actionMode = string.Empty;
        string _sortBy = string.Empty;
        string _searchBy = string.Empty;
        string _sortDirection = string.Empty;
        int _startRow;
        int _rowLength;
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

        public SalaryDeductionMasterController()
        {
            _SalaryDeductionMasterServiceAcess = new SalaryDeductionMasterServiceAccess();
        }

        // Controller Methods
        #region Controller Methods
        public ActionResult Index()
        {

            return View("/Views/Salary/SalaryDeductionMaster/Index.cshtml");

        }

        public ActionResult List(string actionMode)
        {
            try
            {
                SalaryDeductionMasterViewModel model = new SalaryDeductionMasterViewModel();
                if (!string.IsNullOrEmpty(actionMode))
                {
                    TempData["ActionMode"] = actionMode;
                }
                return PartialView("/Views/Salary/SalaryDeductionMaster/List.cshtml", model);
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
            SalaryDeductionMasterViewModel model = new SalaryDeductionMasterViewModel();
            
            //*****************Dropdown****************************
            List<SelectListItem> DeductionType = new List<SelectListItem>();
            ViewBag.DeductionType = new SelectList(DeductionType, "Value", "Text");
            List<SelectListItem> DeductionType_li = new List<SelectListItem>();
            DeductionType_li.Add(new SelectListItem { Text = "PF", Value = "PF" });
            DeductionType_li.Add(new SelectListItem { Text = "ESI", Value = "ESI" });
            DeductionType_li.Add(new SelectListItem { Text = "PT", Value = "PT" });
            DeductionType_li.Add(new SelectListItem { Text = "LIC", Value = "LIC" });
            DeductionType_li.Add(new SelectListItem { Text = "LOAN", Value = "LOAN" });
            DeductionType_li.Add(new SelectListItem { Text = "TDS", Value = "TDS" });

            ViewData["DeductionType"] = new SelectList(DeductionType_li, "Value", "Text");
            return PartialView("/Views/Salary/SalaryDeductionMaster/Create.cshtml", model);
        }

        [HttpPost]
        public ActionResult Create(SalaryDeductionMasterViewModel model)
        {
            try
            {
                if (model != null && model.SalaryDeductionMasterDTO != null)
                {
                    model.SalaryDeductionMasterDTO.ConnectionString = _connectioString;
                    model.SalaryDeductionMasterDTO.DeductionHeadName = model.DeductionHeadName;
                    model.SalaryDeductionMasterDTO.DeductionType = model.DeductionType;
                 
                    model.SalaryDeductionMasterDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                    IBaseEntityResponse<SalaryDeductionMaster> response = _SalaryDeductionMasterServiceAcess.InsertSalaryDeductionMaster(model.SalaryDeductionMasterDTO);

                    model.SalaryDeductionMasterDTO.ErrorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);


                    return Json(model.SalaryDeductionMasterDTO.ErrorMessage, JsonRequestBehavior.AllowGet);
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

        [HttpGet]
        public ActionResult Edit(int id)
        {
            SalaryDeductionMasterViewModel model = new SalaryDeductionMasterViewModel();
            try
            {
                model.SalaryDeductionMasterDTO = new SalaryDeductionMaster();
                model.SalaryDeductionMasterDTO.ID = id;
                model.SalaryDeductionMasterDTO.ConnectionString = _connectioString;

                IBaseEntityResponse<SalaryDeductionMaster> response = _SalaryDeductionMasterServiceAcess.SelectByID(model.SalaryDeductionMasterDTO);
                if (response != null && response.Entity != null)
                {
                    model.SalaryDeductionMasterDTO.ID = response.Entity.ID;
                    model.SalaryDeductionMasterDTO.DeductionHeadName = response.Entity.DeductionHeadName;
                    model.SalaryDeductionMasterDTO.DeductionType = response.Entity.DeductionType;
                   
                    model.SalaryDeductionMasterDTO.CreatedBy = response.Entity.CreatedBy;
                    List<SelectListItem> DeductionType = new List<SelectListItem>();
                    ViewBag.DeductionType = new SelectList(DeductionType, "Value", "Text");
                    List<SelectListItem> DeductionType_li = new List<SelectListItem>();
                    DeductionType_li.Add(new SelectListItem { Text = "PF", Value = "PF" });
                    DeductionType_li.Add(new SelectListItem { Text = "ESI", Value = "ESI" });
                    DeductionType_li.Add(new SelectListItem { Text = "PT", Value = "PT" });
                    DeductionType_li.Add(new SelectListItem { Text = "LIC", Value = "LIC" });
                    DeductionType_li.Add(new SelectListItem { Text = "LOAN", Value = "LOAN" });
                    DeductionType_li.Add(new SelectListItem { Text = "TDS", Value = "TDS" });

                    ViewData["DeductionType"] = new SelectList(DeductionType_li, "Value", "Text");
                }
                return PartialView("/Views/Salary/SalaryDeductionMaster/Edit.cshtml", model);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public ActionResult Edit(SalaryDeductionMasterViewModel model)
        {
            try
            {
                if (model != null && model.SalaryDeductionMasterDTO != null)
                {
                    model.SalaryDeductionMasterDTO.ConnectionString = _connectioString;
                    model.SalaryDeductionMasterDTO.ID = model.ID;
                    model.SalaryDeductionMasterDTO.DeductionHeadName = model.DeductionHeadName;
                    model.SalaryDeductionMasterDTO.DeductionType = model.DeductionType;
                   
                    model.SalaryDeductionMasterDTO.ModifiedBy = Convert.ToInt32(Session["UserID"]);
                    IBaseEntityResponse<SalaryDeductionMaster> response = _SalaryDeductionMasterServiceAcess.UpdateSalaryDeductionMaster(model.SalaryDeductionMasterDTO);
                    model.SalaryDeductionMasterDTO.ErrorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Update);

                    return Json(model.SalaryDeductionMasterDTO.ErrorMessage, JsonRequestBehavior.AllowGet);
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

        [HttpGet]
        public ActionResult ViewDetails(string ID)
        {
            try
            {
                SalaryDeductionMasterViewModel model = new SalaryDeductionMasterViewModel();
                model.SalaryDeductionMasterDTO = new SalaryDeductionMaster();
                model.SalaryDeductionMasterDTO.ID = Convert.ToInt16(ID);
                model.SalaryDeductionMasterDTO.ConnectionString = _connectioString;

                IBaseEntityResponse<SalaryDeductionMaster> response = _SalaryDeductionMasterServiceAcess.SelectByID(model.SalaryDeductionMasterDTO);
                if (response != null && response.Entity != null)
                {

                }

                return PartialView("/Views/Salary/SalaryDeductionMaster/ViewDetails.cshtml", model);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }

        }

        public ActionResult Delete(Int16 ID)
        {
            var errorMessage = string.Empty;
            if (ID > 0)
            {
                IBaseEntityResponse<SalaryDeductionMaster> response = null;
                SalaryDeductionMaster SalaryDeductionMasterDTO = new SalaryDeductionMaster();
                SalaryDeductionMasterDTO.ConnectionString = _connectioString;
                SalaryDeductionMasterDTO.ID = ID;
                SalaryDeductionMasterDTO.DeletedBy = Convert.ToInt32(Session["UserID"]);
                response = _SalaryDeductionMasterServiceAcess.DeleteSalaryDeductionMaster(SalaryDeductionMasterDTO);
                errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Delete);
            }

            return Json(errorMessage, JsonRequestBehavior.AllowGet);
        }

        #endregion

        // Non-Action Method
        #region Methods
        public IEnumerable<SalaryDeductionMasterViewModel> GetSalaryDeductionMaster(out int TotalRecords)
        {
            SalaryDeductionMasterSearchRequest searchRequest = new SalaryDeductionMasterSearchRequest();
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
                    searchRequest.SortBy = "ModifiedDate";
                    searchRequest.StartRow = 0;
                    searchRequest.EndRow = 10;
                    searchRequest.SearchBy = string.Empty;
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
            List<SalaryDeductionMasterViewModel> listSalaryDeductionMasterViewModel = new List<SalaryDeductionMasterViewModel>();
            List<SalaryDeductionMaster> listSalaryDeductionMaster = new List<SalaryDeductionMaster>();
            IBaseEntityCollectionResponse<SalaryDeductionMaster> baseEntityCollectionResponse = _SalaryDeductionMasterServiceAcess.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listSalaryDeductionMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (SalaryDeductionMaster item in listSalaryDeductionMaster)
                    {
                        SalaryDeductionMasterViewModel SalaryDeductionMasterViewModel = new SalaryDeductionMasterViewModel();
                        SalaryDeductionMasterViewModel.SalaryDeductionMasterDTO = item;
                        listSalaryDeductionMasterViewModel.Add(SalaryDeductionMasterViewModel);
                    }
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listSalaryDeductionMasterViewModel;
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

                IEnumerable<SalaryDeductionMasterViewModel> filteredUnitType;
                switch (Convert.ToInt32(sortColumnIndex))
                {
                    case 0:
                        _sortBy = "ID";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            _searchBy = "DeductionHeadName Like '%" + param.sSearch + "%' or DeductionType Like '%" + param.sSearch + "%'";      //this "if" block is added for search functionality
                        }
                        break;
                    case 1:
                        _sortBy = "DeductionType ";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            _searchBy = "DeductionHeadName Like '%" + param.sSearch + "%' or DeductionType Like '%" + param.sSearch + "%'";
                        }
                        break;
                   
                }
                _sortDirection = sortDirection;
                _rowLength = param.iDisplayLength;
                _startRow = param.iDisplayStart;
                filteredUnitType = GetSalaryDeductionMaster(out TotalRecords);
                var records = filteredUnitType.Skip(0).Take(param.iDisplayLength);
                var result = from c in records select new[] { Convert.ToString(c.DeductionHeadName), Convert.ToString(c.DeductionType), Convert.ToString(c.ID) };

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