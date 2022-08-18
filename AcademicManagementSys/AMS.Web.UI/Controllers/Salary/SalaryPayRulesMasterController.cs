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
    public class SalaryPayRulesMasterController : BaseController
    {
        ISalaryPayRulesServiceAccess _SalaryPayRulesServiceAcess = null;
        private readonly ILogger _logException;
        ActionModeEnum actionModeEnum;
        string _actionMode = string.Empty;
        string _sortBy = string.Empty;
        string _searchBy = string.Empty;
        string _sortDirection = string.Empty;
        int _startRow;
        int _rowLength;
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

        public SalaryPayRulesMasterController()
        {
            _SalaryPayRulesServiceAcess = new SalaryPayRulesServiceAccess();
        }

        // Controller Methods
        #region Controller Methods
        public ActionResult Index()
        {

            return View("/Views/Salary/SalaryPayRulesMaster/Index.cshtml");

        }

        public ActionResult List(string actionMode)
        {
            try
            {
                SalaryPayRulesViewModel model = new SalaryPayRulesViewModel();
                if (!string.IsNullOrEmpty(actionMode))
                {
                    TempData["ActionMode"] = actionMode;
                }
                return PartialView("/Views/Salary/SalaryPayRulesMaster/List.cshtml", model);
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
            SalaryPayRulesViewModel model = new SalaryPayRulesViewModel();
            return PartialView("/Views/Salary/SalaryPayRulesMaster/Create.cshtml", model);
        }

        [HttpPost]
        public ActionResult Create(SalaryPayRulesViewModel model)
        {
            try
            {
                if (model != null && model.SalaryPayRulesDTO != null)
                {
                    model.SalaryPayRulesDTO.ConnectionString = _connectioString;
                    model.SalaryPayRulesDTO.PayScaleRuleDescription = model.PayScaleRuleDescription;
                    model.SalaryPayRulesDTO.PayScaleFromDate = model.PayScaleFromDate;
                    model.SalaryPayRulesDTO.PayScaleUptoDate = model.PayScaleUptoDate;
                    model.SalaryPayRulesDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                    IBaseEntityResponse<SalaryPayRules> response = _SalaryPayRulesServiceAcess.InsertSalaryPayRules(model.SalaryPayRulesDTO);

                    model.SalaryPayRulesDTO.errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);

                    return Json(model.SalaryPayRulesDTO.errorMessage, JsonRequestBehavior.AllowGet);
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
            SalaryPayRulesViewModel model = new SalaryPayRulesViewModel();
            try
            {
                model.SalaryPayRulesDTO = new SalaryPayRules();
                model.SalaryPayRulesDTO.ID = id;
                model.SalaryPayRulesDTO.ConnectionString = _connectioString;

                IBaseEntityResponse<SalaryPayRules> response = _SalaryPayRulesServiceAcess.SelectByID(model.SalaryPayRulesDTO);
                if (response != null && response.Entity != null)
                {
                    model.SalaryPayRulesDTO.ID = response.Entity.ID;
                    model.SalaryPayRulesDTO.PayScaleRuleDescription = response.Entity.PayScaleRuleDescription;
                    model.SalaryPayRulesDTO.PayScaleFromDate = response.Entity.PayScaleFromDate;
                    model.SalaryPayRulesDTO.PayScaleUptoDate = response.Entity.PayScaleUptoDate;
                    model.SalaryPayRulesDTO.IsActive = response.Entity.IsActive;
                    model.SalaryPayRulesDTO.CreatedBy = response.Entity.CreatedBy;
                }
                return PartialView("/Views/Salary/SalaryPayRulesMaster/Edit.cshtml", model);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public ActionResult Edit(SalaryPayRulesViewModel model)
        {
            try
            {
                if (model != null && model.SalaryPayRulesDTO != null)
                {
                    model.SalaryPayRulesDTO.ConnectionString = _connectioString;
                    model.SalaryPayRulesDTO.ID = model.ID;
                    model.SalaryPayRulesDTO.PayScaleRuleDescription = model.PayScaleRuleDescription;
                    model.SalaryPayRulesDTO.PayScaleFromDate = model.PayScaleFromDate;
                    model.SalaryPayRulesDTO.PayScaleUptoDate = model.PayScaleUptoDate;
                    model.SalaryPayRulesDTO.IsActive = model.IsActive;
                    model.SalaryPayRulesDTO.ModifiedBy = Convert.ToInt32(Session["UserID"]);
                    IBaseEntityResponse<SalaryPayRules> response = _SalaryPayRulesServiceAcess.UpdateSalaryPayRules(model.SalaryPayRulesDTO);
                    model.SalaryPayRulesDTO.errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Update);

                    return Json(model.SalaryPayRulesDTO.errorMessage, JsonRequestBehavior.AllowGet);
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
                SalaryPayRulesViewModel model = new SalaryPayRulesViewModel();
                model.SalaryPayRulesDTO = new SalaryPayRules();
                model.SalaryPayRulesDTO.ID = Convert.ToInt16(ID);
                model.SalaryPayRulesDTO.ConnectionString = _connectioString;

                IBaseEntityResponse<SalaryPayRules> response = _SalaryPayRulesServiceAcess.SelectByID(model.SalaryPayRulesDTO);
                if (response != null && response.Entity != null)
                {

                }

                return PartialView("/Views/Salary/SalaryPayRulesMaster/ViewDetails.cshtml", model);
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
                IBaseEntityResponse<SalaryPayRules> response = null;
                SalaryPayRules SalaryPayRulesDTO = new SalaryPayRules();
                SalaryPayRulesDTO.ConnectionString = _connectioString;
                SalaryPayRulesDTO.ID = ID;
                SalaryPayRulesDTO.DeletedBy = Convert.ToInt32(Session["UserID"]);
                response = _SalaryPayRulesServiceAcess.DeleteSalaryPayRules(SalaryPayRulesDTO);
                errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Delete);
            }

            return Json(errorMessage, JsonRequestBehavior.AllowGet);
        }

        #endregion

        // Non-Action Method
        #region Methods
        public IEnumerable<SalaryPayRulesViewModel> GetSalaryPayRules(out int TotalRecords)
        {
            SalaryPayRulesSearchRequest searchRequest = new SalaryPayRulesSearchRequest();
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
            List<SalaryPayRulesViewModel> listSalaryPayRulesViewModel = new List<SalaryPayRulesViewModel>();
            List<SalaryPayRules> listSalaryPayRules = new List<SalaryPayRules>();
            IBaseEntityCollectionResponse<SalaryPayRules> baseEntityCollectionResponse = _SalaryPayRulesServiceAcess.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listSalaryPayRules = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (SalaryPayRules item in listSalaryPayRules)
                    {
                        SalaryPayRulesViewModel SalaryPayRulesViewModel = new SalaryPayRulesViewModel();
                        SalaryPayRulesViewModel.SalaryPayRulesDTO = item;
                        listSalaryPayRulesViewModel.Add(SalaryPayRulesViewModel);
                    }
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listSalaryPayRulesViewModel;
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

                IEnumerable<SalaryPayRulesViewModel> filteredUnitType;
                switch (Convert.ToInt32(sortColumnIndex))
                {
                    case 0:
                        _sortBy = "PayScaleRuleDescription";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            _searchBy = "PayScaleRuleDescription Like '%" + param.sSearch + "%' or PayScaleFromDate Like '%" + param.sSearch + "%' or PayScaleUptoDate Like '%" + param.sSearch + "%'";      //this "if" block is added for search functionality
                        }
                        break;
                    case 1:
                        _sortBy = "YEAR(PayScaleFromDate) " + sortDirection + ",MONTH(PayScaleFromDate) " + sortDirection + ",DAY(PayScaleFromDate) " + sortDirection + ", PayScaleRuleDescription";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            _searchBy = "PayScaleRuleDescription Like '%" + param.sSearch + "%' or PayScaleFromDate Like '%" + param.sSearch + "%' or PayScaleUptoDate Like '%" + param.sSearch + "%'";
                        }
                        break;
                    case 2:
                        _sortBy = "YEAR(PayScaleUptoDate) " + sortDirection + ",MONTH(PayScaleUptoDate) " + sortDirection + ",DAY(PayScaleUptoDate) " + sortDirection + ", PayScaleRuleDescription";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            _searchBy = "PayScaleRuleDescription Like '%" + param.sSearch + "%' or PayScaleFromDate Like '%" + param.sSearch + "%' or PayScaleUptoDate Like '%" + param.sSearch + "%'";
                        }
                        break;
                }
                _sortDirection = sortDirection;
                _rowLength = param.iDisplayLength;
                _startRow = param.iDisplayStart;
                filteredUnitType = GetSalaryPayRules(out TotalRecords);
                var records = filteredUnitType.Skip(0).Take(param.iDisplayLength);
                var result = from c in records select new[] { Convert.ToString(c.ID), Convert.ToString(c.PayScaleRuleDescription), Convert.ToString(c.PayScaleFromDate), Convert.ToString(c.PayScaleUptoDate), Convert.ToString(c.IsActive) };

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