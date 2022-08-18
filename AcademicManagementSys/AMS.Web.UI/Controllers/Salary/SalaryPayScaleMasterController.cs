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
    public class SalaryPayScaleMasterController : BaseController
    {
        ISalaryPayScaleMasterServiceAccess _SalaryPayScaleMasterServiceAcess = null;
        ISalaryPayRulesServiceAccess _SalaryPayRulesServiceAccess = null;
        private readonly ILogger _logException;
        ActionModeEnum actionModeEnum;
        string _actionMode = string.Empty;
        string _sortBy = string.Empty;
        string _searchBy = string.Empty;
        string _sortDirection = string.Empty;
        int _startRow;
        int _rowLength;
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

        public SalaryPayScaleMasterController()
        {
            _SalaryPayScaleMasterServiceAcess = new SalaryPayScaleMasterServiceAccess();
            _SalaryPayRulesServiceAccess = new SalaryPayRulesServiceAccess();

        }

        // Controller Methods
        #region Controller Methods
        public ActionResult Index()
        {

            return View("/Views/Salary/SalaryPayScaleMaster/Index.cshtml");

        }

        public ActionResult List(string actionMode)
        {
            try
            {
                SalaryPayScaleMasterViewModel model = new SalaryPayScaleMasterViewModel();
                if (!string.IsNullOrEmpty(actionMode))
                {
                    TempData["ActionMode"] = actionMode;
                }
                return PartialView("/Views/Salary/SalaryPayScaleMaster/List.cshtml", model);
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
            SalaryPayScaleMasterViewModel model = new SalaryPayScaleMasterViewModel();
            //******************DropDown List For Designation********************
            List<EmpDesignationMaster> DesignationIDs = GetListEmpDesignationMaster();
            List<SelectListItem> DesignationIDsList = new List<SelectListItem>();
            foreach (EmpDesignationMaster item in DesignationIDs)
            {
                DesignationIDsList.Add(new SelectListItem { Text = item.Description, Value = Convert.ToString(item.ID) });
            }
            ViewBag.DesignationIDsList = new SelectList(DesignationIDsList, "Value", "Text");

            //******************DropDown List For Salary Pay Rules****************

            List<SalaryPayRules> SalaryPayRulesIDs = GetListSalaryPayRules();
            List<SelectListItem> SalaryPayRulesIDsList = new List<SelectListItem>();
            foreach (SalaryPayRules item in SalaryPayRulesIDs)
            {
                SalaryPayRulesIDsList.Add(new SelectListItem { Text = item.PayScaleRuleDescription, Value = Convert.ToString(item.ID) });
            }
            ViewBag.SalaryPayRulesIDsList = new SelectList(SalaryPayRulesIDsList, "Value", "Text");

            //******************Dropdown List For Pay Band Period Unit*************
            List<SelectListItem> PaybandPeriodUnit = new List<SelectListItem>();
            ViewBag.PaybandPeriodUnit = new SelectList(PaybandPeriodUnit, "Value", "Text");
            List<SelectListItem> PaybandPeriodUnit_li = new List<SelectListItem>();
            PaybandPeriodUnit_li.Add(new SelectListItem { Text = "Year", Value = "Year" });
            PaybandPeriodUnit_li.Add(new SelectListItem { Text = "Month", Value = "Month" });
            PaybandPeriodUnit_li.Add(new SelectListItem { Text = "Day", Value = "Day" });
            ViewData["PaybandPeriodUnit"] = new SelectList(PaybandPeriodUnit_li, "Value", "Text");

            return PartialView("/Views/Salary/SalaryPayScaleMaster/Create.cshtml", model);
        }

        [HttpPost]
        public ActionResult Create(SalaryPayScaleMasterViewModel model)
        {
            try
            {
                if (model != null && model.SalaryPayScaleMasterDTO != null)
                {
                    model.SalaryPayScaleMasterDTO.ConnectionString = _connectioString;
                    model.SalaryPayScaleMasterDTO.DesignationID = model.DesignationID;
                    model.SalaryPayScaleMasterDTO.Description = model.Description;
                    model.SalaryPayScaleMasterDTO.PayScaleRuleDescription = model.PayScaleRuleDescription;
                    model.SalaryPayScaleMasterDTO.SalaryPayRulesID = model.SalaryPayRulesID;
                    model.SalaryPayScaleMasterDTO.PayScaleRange = model.PayScaleRange;
                    model.SalaryPayScaleMasterDTO.RangeFrom = model.RangeFrom;
                    model.SalaryPayScaleMasterDTO.RangeUpto = model.RangeUpto;
                    model.SalaryPayScaleMasterDTO.PayBandIncrementPercent = model.PayBandIncrementPercent;
                    model.SalaryPayScaleMasterDTO.PaybandPeriodSpan = model.PaybandPeriodSpan;
                    model.SalaryPayScaleMasterDTO.PaybandPeriodUnit = model.PaybandPeriodUnit;
                    model.SalaryPayScaleMasterDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                    IBaseEntityResponse<SalaryPayScaleMaster> response = _SalaryPayScaleMasterServiceAcess.InsertSalaryPayScaleMaster(model.SalaryPayScaleMasterDTO);

                    model.SalaryPayScaleMasterDTO.errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);

                    return Json(model.SalaryPayScaleMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
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
        public ActionResult Edit(Int16 id)
        {
            SalaryPayScaleMasterViewModel model = new SalaryPayScaleMasterViewModel();
            try
            {
                model.SalaryPayScaleMasterDTO = new SalaryPayScaleMaster();
                model.SalaryPayScaleMasterDTO.ID = id;
                model.SalaryPayScaleMasterDTO.ConnectionString = _connectioString;

                IBaseEntityResponse<SalaryPayScaleMaster> response = _SalaryPayScaleMasterServiceAcess.SelectByID(model.SalaryPayScaleMasterDTO);
                if (response != null && response.Entity != null)
                {
                    model.SalaryPayScaleMasterDTO.ID = response.Entity.ID;
                    model.SalaryPayScaleMasterDTO.DesignationID = response.Entity.DesignationID;
                    model.SalaryPayScaleMasterDTO.SalaryPayRulesID = response.Entity.SalaryPayRulesID;
                    model.SalaryPayScaleMasterDTO.PayScaleRange = response.Entity.PayScaleRange;
                    model.SalaryPayScaleMasterDTO.RangeFrom = response.Entity.RangeFrom;
                    model.SalaryPayScaleMasterDTO.RangeUpto = response.Entity.RangeUpto;
                    model.SalaryPayScaleMasterDTO.PayBandIncrementPercent = response.Entity.PayBandIncrementPercent;
                    model.SalaryPayScaleMasterDTO.PaybandPeriodSpan = response.Entity.PaybandPeriodSpan;
                    model.SalaryPayScaleMasterDTO.PaybandPeriodUnit = response.Entity.PaybandPeriodUnit;

                    List<EmpDesignationMaster> DesignationIDs = GetListEmpDesignationMaster();
                    List<SelectListItem> DesignationIDsList = new List<SelectListItem>();
                    foreach (EmpDesignationMaster item in DesignationIDs)
                    {
                        DesignationIDsList.Add(new SelectListItem { Text = item.Description, Value = Convert.ToString(item.ID) });
                    }
                    ViewBag.DesignationIDsList = new SelectList(DesignationIDsList, "Value", "Text", model.SalaryPayScaleMasterDTO.DesignationID);

                    //*****************DroDown List For Salary Rules****************
                    List<SalaryPayRules> SalaryPayRulesIDs = GetListSalaryPayRules();
                    List<SelectListItem> SalaryPayRulesIDsList = new List<SelectListItem>();
                    foreach (SalaryPayRules item in SalaryPayRulesIDs)
                    {
                        SalaryPayRulesIDsList.Add(new SelectListItem { Text = item.PayScaleRuleDescription, Value = Convert.ToString(item.ID) });
                    }
                    ViewBag.SalaryPayRulesIDsList = new SelectList(SalaryPayRulesIDsList, "Value", "Text", model.SalaryPayScaleMasterDTO.SalaryPayRulesID);


                    List<SelectListItem> PaybandPeriodUnit = new List<SelectListItem>();
                    ViewBag.PaybandPeriodUnit = new SelectList(PaybandPeriodUnit, "Value", "Text");
                    List<SelectListItem> PaybandPeriodUnit_li = new List<SelectListItem>();
                    PaybandPeriodUnit_li.Add(new SelectListItem { Text = "Year", Value = "Year" });
                    PaybandPeriodUnit_li.Add(new SelectListItem { Text = "Month", Value = "Month" });
                    PaybandPeriodUnit_li.Add(new SelectListItem { Text = "Day", Value = "Day" });
                    ViewData["PaybandPeriodUnit"] = new SelectList(PaybandPeriodUnit_li, "Value", "Text", model.SalaryPayScaleMasterDTO.PaybandPeriodUnit);
                }
                return PartialView("/Views/Salary/SalaryPayScaleMaster/Edit.cshtml", model);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public ActionResult Edit(SalaryPayScaleMasterViewModel model)
        {
            try
            {
                if (model != null && model.SalaryPayScaleMasterDTO != null)
                {
                    model.SalaryPayScaleMasterDTO.ConnectionString = _connectioString;
                    model.SalaryPayScaleMasterDTO.ID = model.ID;
                    model.SalaryPayScaleMasterDTO.DesignationID = model.DesignationID;
                    model.SalaryPayScaleMasterDTO.SalaryPayRulesID = model.SalaryPayRulesID;
                    model.SalaryPayScaleMasterDTO.PayScaleRange = model.PayScaleRange;
                    model.SalaryPayScaleMasterDTO.RangeFrom = model.RangeFrom;
                    model.SalaryPayScaleMasterDTO.RangeUpto = model.RangeUpto;
                    model.SalaryPayScaleMasterDTO.PayBandIncrementPercent = model.PayBandIncrementPercent;
                    model.SalaryPayScaleMasterDTO.PaybandPeriodSpan = model.PaybandPeriodSpan;
                    model.SalaryPayScaleMasterDTO.PaybandPeriodUnit = model.PaybandPeriodUnit;
                    model.SalaryPayScaleMasterDTO.ModifiedBy = Convert.ToInt32(Session["UserID"]);
                    IBaseEntityResponse<SalaryPayScaleMaster> response = _SalaryPayScaleMasterServiceAcess.UpdateSalaryPayScaleMaster(model.SalaryPayScaleMasterDTO);
                    model.SalaryPayScaleMasterDTO.errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Update);

                    return Json(model.SalaryPayScaleMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
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
                SalaryPayScaleMasterViewModel model = new SalaryPayScaleMasterViewModel();
                model.SalaryPayScaleMasterDTO = new SalaryPayScaleMaster();
                model.SalaryPayScaleMasterDTO.ID = Convert.ToInt16(ID);
                model.SalaryPayScaleMasterDTO.ConnectionString = _connectioString;

                IBaseEntityResponse<SalaryPayScaleMaster> response = _SalaryPayScaleMasterServiceAcess.SelectByID(model.SalaryPayScaleMasterDTO);
                if (response != null && response.Entity != null)
                {

                }

                return PartialView("/Views/Salary/SalaryPayScaleMaster/ViewDetails.cshtml", model);
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
                IBaseEntityResponse<SalaryPayScaleMaster> response = null;
                SalaryPayScaleMaster SalaryPayScaleMasterDTO = new SalaryPayScaleMaster();
                SalaryPayScaleMasterDTO.ConnectionString = _connectioString;
                SalaryPayScaleMasterDTO.ID = ID;
                SalaryPayScaleMasterDTO.DeletedBy = Convert.ToInt32(Session["UserID"]);
                response = _SalaryPayScaleMasterServiceAcess.DeleteSalaryPayScaleMaster(SalaryPayScaleMasterDTO);
                errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Delete);
            }

            return Json(errorMessage, JsonRequestBehavior.AllowGet);
        }

        #endregion

        // Non-Action Method
        //***************************For Dropdown List Of Salary Rule Master********************
        protected List<SalaryPayRules> GetListSalaryPayRules()
        {
            SalaryPayRulesSearchRequest searchRequest = new SalaryPayRulesSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            List<SalaryPayRules> listSalaryPayRules = new List<SalaryPayRules>();
            IBaseEntityCollectionResponse<SalaryPayRules> baseEntityCollectionResponse = _SalaryPayRulesServiceAccess.GetBySearchList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listSalaryPayRules = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listSalaryPayRules;
        }
        #region Methods
        public IEnumerable<SalaryPayScaleMasterViewModel> GetSalaryPayScale(out int TotalRecords)
        {
            SalaryPayScaleMasterSearchRequest searchRequest = new SalaryPayScaleMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            _actionMode = Convert.ToString(TempData["ActionMode"]);
            if (Enum.TryParse(_actionMode, out actionModeEnum))     // checks actionMode i.e. Insert or Update // 
            {
                if (actionModeEnum == ActionModeEnum.Insert)        // parameters for SelectAll procedures under Insert or Update mode condition
                {
                    searchRequest.SortBy = "A.CreatedDate";
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
            List<SalaryPayScaleMasterViewModel> listSalaryPayScaleViewModel = new List<SalaryPayScaleMasterViewModel>();
            List<SalaryPayScaleMaster> listSalaryPayScale = new List<SalaryPayScaleMaster>();
            IBaseEntityCollectionResponse<SalaryPayScaleMaster> baseEntityCollectionResponse = _SalaryPayScaleMasterServiceAcess.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listSalaryPayScale = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (SalaryPayScaleMaster item in listSalaryPayScale)
                    {
                        SalaryPayScaleMasterViewModel SalaryPayScaleViewModel = new SalaryPayScaleMasterViewModel();
                        SalaryPayScaleViewModel.SalaryPayScaleMasterDTO = item;
                        listSalaryPayScaleViewModel.Add(SalaryPayScaleViewModel);
                    }
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listSalaryPayScaleViewModel;
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

                IEnumerable<SalaryPayScaleMasterViewModel> filteredUnitType;

                switch (Convert.ToInt32(sortColumnIndex))
                {
                    case 0:
                        _sortBy = " A.ID";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            // _searchBy = "A.GroupDescription like '%'";
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            // _searchBy = "A.GroupDescription Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                            _searchBy = "B.Description Like '%" + param.sSearch + "%' or A.PayScaleRange Like '%" + param.sSearch + "%' or A.RangeFrom Like'%" + param.sSearch + "%' or A.RangeUpto Like'%" + param.sSearch + "%'or A.PayBandIncrementPercent Like'%" + param.sSearch + "%' or A.PayBandPeriodSpan Like '%" + param.sSearch + "%'or A.PayBandPeriodUnit Like '%" + param.sSearch + "%'or C.PayScaleRuleDescription Like '%" + param.sSearch + "%'";
                        }
                        break;

                   case 1:
                        _sortBy = "A.PayScaleRange";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            // _searchBy = "A.MarchandiseGroupCode like '%'";
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            //  _searchBy = "A.MarchandiseGroupCode Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                            _searchBy = "B.Description Like '%" + param.sSearch + "%' or A.PayScaleRange Like '%" + param.sSearch + "%' or A.RangeFrom Like'%" + param.sSearch + "%' or A.RangeUpto Like'%" + param.sSearch + "%' or A.PayBandIncrementPercent Like'%" + param.sSearch + "%'or A.PayBandPeriodSpan Like '%" + param.sSearch + "%'or A.PayBandPeriodUnit Like '%" + param.sSearch + "%'or C.PayScaleRuleDescription Like '%" + param.sSearch + "%'";
                        }
                        break;
                    case 2:
                        _sortBy = "A.RangeFrom";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            // _searchBy = "A.MarchandiseGroupCode like '%'";
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            //  _searchBy = "A.MarchandiseGroupCode Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                            _searchBy = "B.Description Like '%" + param.sSearch + "%' or A.PayScaleRange Like '%" + param.sSearch + "%' or A.RangeFrom Like'%" + param.sSearch + "%' or A.RangeUpto Like'%" + param.sSearch + "%' or A.PayBandIncrementPercent Like'%" + param.sSearch + "%'or A.PayBandPeriodSpan Like '%" + param.sSearch + "%'or A.PayBandPeriodUnit Like '%" + param.sSearch + "%'or C.PayScaleRuleDescription Like '%" + param.sSearch + "%'";
                        }
                        break;
                    case 3:
                        _sortBy = "A.RangeUpto";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            // _searchBy = "A.MarchandiseGroupCode like '%'";
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            //  _searchBy = "A.MarchandiseGroupCode Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                            _searchBy = "B.Description Like '%" + param.sSearch + "%' or A.PayScaleRange Like '%" + param.sSearch + "%' or A.RangeFrom Like'%" + param.sSearch + "%' or A.RangeUpto Like'%" + param.sSearch + "%' or A.PayBandIncrementPercent Like'%" + param.sSearch + "%'or A.PayBandPeriodSpan Like '%" + param.sSearch + "%'or A.PayBandPeriodUnit Like '%" + param.sSearch + "%'or C.PayScaleRuleDescription Like '%" + param.sSearch + "%'";
                        }
                        break;
                    case 4:
                        _sortBy = "A.PayBandIncrementPercent";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            // _searchBy = "A.MarchandiseGroupCode like '%'";
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            //  _searchBy = "A.MarchandiseGroupCode Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                            _searchBy = "B.Description Like '%" + param.sSearch + "%' or A.PayScaleRange Like '%" + param.sSearch + "%' or A.RangeFrom Like'%" + param.sSearch + "%' or A.RangeUpto Like'%" + param.sSearch + "%' or A.PayBandIncrementPercent Like'%" + param.sSearch + "%'or A.PayBandPeriodSpan Like '%" + param.sSearch + "%'or A.PayBandPeriodUnit Like '%" + param.sSearch + "%'or C.PayScaleRuleDescription Like '%" + param.sSearch + "%'";
                        }
                        break;
                    case 5:
                        _sortBy = "A.PayBandPeriodSpan";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            // _searchBy = "A.MarchandiseGroupCode like '%'";
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            //  _searchBy = "A.MarchandiseGroupCode Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                            _searchBy = "B.Description Like '%" + param.sSearch + "%' or A.PayScaleRange Like '%" + param.sSearch + "%' or A.RangeFrom Like'%" + param.sSearch + "%' or A.RangeUpto Like'%" + param.sSearch + "%' or A.PayBandIncrementPercent Like'%" + param.sSearch + "%'or A.PayBandPeriodSpan Like '%" + param.sSearch + "%'or A.PayBandPeriodUnit Like '%" + param.sSearch + "%'or C.PayScaleRuleDescription Like '%" + param.sSearch + "%'";
                        }
                        break;
                    case 6:
                        _sortBy = "A.PayBandPeriodUnit";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            // _searchBy = "A.MarchandiseGroupCode like '%'";
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            //  _searchBy = "A.MarchandiseGroupCode Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                            _searchBy = "B.Description Like '%" + param.sSearch + "%' or A.PayScaleRange Like '%" + param.sSearch + "%' or A.RangeFrom Like'%" + param.sSearch + "%' or A.RangeUpto Like'%" + param.sSearch + "%' or A.PayBandIncrementPercent Like'%" + param.sSearch + "%'or A.PayBandPeriodSpan Like '%" + param.sSearch + "%'or A.PayBandPeriodUnit Like '%" + param.sSearch + "%'or C.PayScaleRuleDescription Like '%" + param.sSearch + "%'";
                        }
                        break;
                    case 7:
                        _sortBy = " C.PayScaleRuleDescription";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            // _searchBy = "A.MarchandiseGroupCode like '%'";
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            //  _searchBy = "A.MarchandiseGroupCode Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                            _searchBy = "B.Description Like '%" + param.sSearch + "%' or A.PayScaleRange Like '%" + param.sSearch + "%' or A.RangeFrom Like'%" + param.sSearch + "%' or A.RangeUpto Like'%" + param.sSearch + "%' or A.PayBandIncrementPercent Like'%" + param.sSearch + "%'or A.PayBandPeriodSpan Like'%" + param.sSearch + "%'or A.PayBandPeriodUnit Like '%" + param.sSearch + "%'or C.PayScaleRuleDescription Like '%" + param.sSearch + "%'";
                        }
                        break;

                }
                _sortDirection = sortDirection;
                _rowLength = param.iDisplayLength;
                _startRow = param.iDisplayStart;
                filteredUnitType = GetSalaryPayScale(out TotalRecords);
                var records = filteredUnitType.Skip(0).Take(param.iDisplayLength);
                var result = from c in records select new[] { Convert.ToString(c.DesignationID), Convert.ToString(c.PayScaleRange), Convert.ToString(c.RangeFrom), Convert.ToString(c.RangeUpto),Convert.ToString(c.PayBandIncrementPercent),Convert.ToString(c.PaybandPeriodSpan),Convert.ToString(c.PaybandPeriodUnit),Convert.ToString(c.SalaryPayRulesID),Convert.ToString(c.Description),Convert.ToString(c.PayScaleRuleDescription), Convert.ToString(c.ID) };

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