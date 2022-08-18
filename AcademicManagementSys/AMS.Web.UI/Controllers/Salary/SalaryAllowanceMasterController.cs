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
    public class SalaryAllowanceMasterController : BaseController
    {
        ISalaryAllowanceMasterServiceAccess _SalaryAllowanceMasterServiceAcess = null;
        private readonly ILogger _logException;
        ActionModeEnum actionModeEnum;
        string _actionMode = string.Empty;
        string _sortBy = string.Empty;
        string _searchBy = string.Empty;
        string _sortDirection = string.Empty;
        int _startRow;
        int _rowLength;
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

        public SalaryAllowanceMasterController()
        {
            _SalaryAllowanceMasterServiceAcess = new SalaryAllowanceMasterServiceAccess();
        }

        // Controller Methods
        #region Controller Methods
        public ActionResult Index()
        {

            return View("/Views/Salary/SalaryAllowanceMaster/Index.cshtml");

        }

        public ActionResult List(string actionMode)
        {
            try
            {
                SalaryAllowanceMasterViewModel model = new SalaryAllowanceMasterViewModel();
                if (!string.IsNullOrEmpty(actionMode))
                {
                    TempData["ActionMode"] = actionMode;
                }
                return PartialView("/Views/Salary/SalaryAllowanceMaster/List.cshtml", model);
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
            SalaryAllowanceMasterViewModel model = new SalaryAllowanceMasterViewModel();
            return PartialView("/Views/Salary/SalaryAllowanceMaster/Create.cshtml", model);
        }

        [HttpPost]
        public ActionResult Create(SalaryAllowanceMasterViewModel model)
        {
            try
            {
                if (model != null && model.SalaryAllowanceMasterDTO != null)
                {
                    model.SalaryAllowanceMasterDTO.ConnectionString = _connectioString;
                    model.SalaryAllowanceMasterDTO.AllowanceHeadName = model.AllowanceHeadName;
                    model.SalaryAllowanceMasterDTO.AllowanceType = model.AllowanceType;
                 
                    model.SalaryAllowanceMasterDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                    IBaseEntityResponse<SalaryAllowanceMaster> response = _SalaryAllowanceMasterServiceAcess.InsertSalaryAllowanceMaster(model.SalaryAllowanceMasterDTO);

                    model.SalaryAllowanceMasterDTO.ErrorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);


                    return Json(model.SalaryAllowanceMasterDTO.ErrorMessage, JsonRequestBehavior.AllowGet);
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
            SalaryAllowanceMasterViewModel model = new SalaryAllowanceMasterViewModel();
            try
            {
                model.SalaryAllowanceMasterDTO = new SalaryAllowanceMaster();
                model.SalaryAllowanceMasterDTO.ID = id;
                model.SalaryAllowanceMasterDTO.ConnectionString = _connectioString;

                IBaseEntityResponse<SalaryAllowanceMaster> response = _SalaryAllowanceMasterServiceAcess.SelectByID(model.SalaryAllowanceMasterDTO);
                if (response != null && response.Entity != null)
                {
                    model.SalaryAllowanceMasterDTO.ID = response.Entity.ID;
                    model.SalaryAllowanceMasterDTO.AllowanceHeadName = response.Entity.AllowanceHeadName;
                    model.SalaryAllowanceMasterDTO.AllowanceType = response.Entity.AllowanceType;
                   
                    model.SalaryAllowanceMasterDTO.CreatedBy = response.Entity.CreatedBy;
                }
                return PartialView("/Views/Salary/SalaryAllowanceMaster/Edit.cshtml", model);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public ActionResult Edit(SalaryAllowanceMasterViewModel model)
        {
            try
            {
                if (model != null && model.SalaryAllowanceMasterDTO != null)
                {
                    model.SalaryAllowanceMasterDTO.ConnectionString = _connectioString;
                    model.SalaryAllowanceMasterDTO.ID = model.ID;
                    model.SalaryAllowanceMasterDTO.AllowanceHeadName = model.AllowanceHeadName;
                    model.SalaryAllowanceMasterDTO.AllowanceType = model.AllowanceType;
                   
                    model.SalaryAllowanceMasterDTO.ModifiedBy = Convert.ToInt32(Session["UserID"]);
                    IBaseEntityResponse<SalaryAllowanceMaster> response = _SalaryAllowanceMasterServiceAcess.UpdateSalaryAllowanceMaster(model.SalaryAllowanceMasterDTO);
                    model.SalaryAllowanceMasterDTO.ErrorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Update);

                    return Json(model.SalaryAllowanceMasterDTO.ErrorMessage, JsonRequestBehavior.AllowGet);
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
                SalaryAllowanceMasterViewModel model = new SalaryAllowanceMasterViewModel();
                model.SalaryAllowanceMasterDTO = new SalaryAllowanceMaster();
                model.SalaryAllowanceMasterDTO.ID = Convert.ToInt16(ID);
                model.SalaryAllowanceMasterDTO.ConnectionString = _connectioString;

                IBaseEntityResponse<SalaryAllowanceMaster> response = _SalaryAllowanceMasterServiceAcess.SelectByID(model.SalaryAllowanceMasterDTO);
                if (response != null && response.Entity != null)
                {

                }

                return PartialView("/Views/Salary/SalaryAllowanceMaster/ViewDetails.cshtml", model);
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
                IBaseEntityResponse<SalaryAllowanceMaster> response = null;
                SalaryAllowanceMaster SalaryAllowanceMasterDTO = new SalaryAllowanceMaster();
                SalaryAllowanceMasterDTO.ConnectionString = _connectioString;
                SalaryAllowanceMasterDTO.ID = ID;
                SalaryAllowanceMasterDTO.DeletedBy = Convert.ToInt32(Session["UserID"]);
                response = _SalaryAllowanceMasterServiceAcess.DeleteSalaryAllowanceMaster(SalaryAllowanceMasterDTO);
                errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Delete);
            }

            return Json(errorMessage, JsonRequestBehavior.AllowGet);
        }

        #endregion

        // Non-Action Method
        #region Methods
        public IEnumerable<SalaryAllowanceMasterViewModel> GetSalaryAllowanceMaster(out int TotalRecords)
        {
            SalaryAllowanceMasterSearchRequest searchRequest = new SalaryAllowanceMasterSearchRequest();
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
            List<SalaryAllowanceMasterViewModel> listSalaryAllowanceMasterViewModel = new List<SalaryAllowanceMasterViewModel>();
            List<SalaryAllowanceMaster> listSalaryAllowanceMaster = new List<SalaryAllowanceMaster>();
            IBaseEntityCollectionResponse<SalaryAllowanceMaster> baseEntityCollectionResponse = _SalaryAllowanceMasterServiceAcess.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listSalaryAllowanceMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (SalaryAllowanceMaster item in listSalaryAllowanceMaster)
                    {
                        SalaryAllowanceMasterViewModel SalaryAllowanceMasterViewModel = new SalaryAllowanceMasterViewModel();
                        SalaryAllowanceMasterViewModel.SalaryAllowanceMasterDTO = item;
                        listSalaryAllowanceMasterViewModel.Add(SalaryAllowanceMasterViewModel);
                    }
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listSalaryAllowanceMasterViewModel;
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

                IEnumerable<SalaryAllowanceMasterViewModel> filteredUnitType;
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
                            _searchBy = "AllowanceHeadName Like '%" + param.sSearch + "%' or AllowanceType Like '%" + param.sSearch + "%'";      //this "if" block is added for search functionality
                        }
                        break;
                    case 1:
                        _sortBy = "AllowanceType " ;
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            _searchBy = "AllowanceHeadName Like '%" + param.sSearch + "%' or AllowanceType Like '%" + param.sSearch + "%'";
                        }
                        break;
                   
                }
                _sortDirection = sortDirection;
                _rowLength = param.iDisplayLength;
                _startRow = param.iDisplayStart;
                filteredUnitType = GetSalaryAllowanceMaster(out TotalRecords);
                var records = filteredUnitType.Skip(0).Take(param.iDisplayLength);
                var result = from c in records select new[] { Convert.ToString(c.AllowanceHeadName), Convert.ToString(c.AllowanceType), Convert.ToString(c.ID) };

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