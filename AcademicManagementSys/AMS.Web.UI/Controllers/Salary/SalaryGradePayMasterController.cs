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
    public class SalaryGradePayMasterController : BaseController
    {
        ISalaryGradePayMasterServiceAccess _SalaryGradePayMasterServiceAcess = null;
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

        public SalaryGradePayMasterController()
        {
            _SalaryGradePayMasterServiceAcess = new SalaryGradePayMasterServiceAccess();
            _SalaryPayRulesServiceAccess = new SalaryPayRulesServiceAccess();

        }

        // Controller Methods
        #region Controller Methods
        public ActionResult Index()
        {

            return View("/Views/Salary/SalaryGradePayMaster/Index.cshtml");

        }

        public ActionResult List(string actionMode)
        {
            try
            {
                SalaryGradePayMasterViewModel model = new SalaryGradePayMasterViewModel();
                if (!string.IsNullOrEmpty(actionMode))
                {
                    TempData["ActionMode"] = actionMode;
                }
                return PartialView("/Views/Salary/SalaryGradePayMaster/List.cshtml", model);
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
            SalaryGradePayMasterViewModel model = new SalaryGradePayMasterViewModel();
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

         

            return PartialView("/Views/Salary/SalaryGradePayMaster/Create.cshtml", model);
        }

        [HttpPost]
        public ActionResult Create(SalaryGradePayMasterViewModel model)
        {
            try
            {
                if (model != null && model.SalaryGradePayMasterDTO != null)
                {
                    model.SalaryGradePayMasterDTO.ConnectionString = _connectioString;
                    model.SalaryGradePayMasterDTO.DesignationID = model.DesignationID;
                    model.SalaryGradePayMasterDTO.Description = model.Description;
                    model.SalaryGradePayMasterDTO.PayScaleRuleDescription = model.PayScaleRuleDescription;
                    model.SalaryGradePayMasterDTO.SalaryPayRulesID = model.SalaryPayRulesID;
                   
                    model.SalaryGradePayMasterDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                    IBaseEntityResponse<SalaryGradePayMaster> response = _SalaryGradePayMasterServiceAcess.InsertSalaryGradePayMaster(model.SalaryGradePayMasterDTO);

                    model.SalaryGradePayMasterDTO.ErrorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);

                    return Json(model.SalaryGradePayMasterDTO.ErrorMessage, JsonRequestBehavior.AllowGet);
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
            SalaryGradePayMasterViewModel model = new SalaryGradePayMasterViewModel();
            try
            {
                model.SalaryGradePayMasterDTO = new SalaryGradePayMaster();
                model.SalaryGradePayMasterDTO.ID = id;
                model.SalaryGradePayMasterDTO.ConnectionString = _connectioString;

                IBaseEntityResponse<SalaryGradePayMaster> response = _SalaryGradePayMasterServiceAcess.SelectByID(model.SalaryGradePayMasterDTO);
                if (response != null && response.Entity != null)
                {
                    model.SalaryGradePayMasterDTO.ID = response.Entity.ID;
                    model.SalaryGradePayMasterDTO.DesignationID = response.Entity.DesignationID;
                    model.SalaryGradePayMasterDTO.GradePayAmount = response.Entity.GradePayAmount;
                    model.SalaryGradePayMasterDTO.SalaryPayRulesID = response.Entity.SalaryPayRulesID;
                    //model.SalaryGradePayMasterDTO.Description = response.Entity.Description;
                    //model.SalaryGradePayMasterDTO.PayScaleRuleDescription = response.Entity.PayScaleRuleDescription;
                   

                    List<EmpDesignationMaster> DesignationIDs = GetListEmpDesignationMaster();
                    List<SelectListItem> DesignationIDsList = new List<SelectListItem>();
                    foreach (EmpDesignationMaster item in DesignationIDs)
                    {
                        DesignationIDsList.Add(new SelectListItem { Text = item.Description, Value = Convert.ToString(item.ID) });
                    }
                    ViewBag.DesignationIDsList = new SelectList(DesignationIDsList, "Value", "Text", model.SalaryGradePayMasterDTO.DesignationID);

                    //*****************DroDown List For Salary Rules****************
                    List<SalaryPayRules> SalaryPayRulesIDs = GetListSalaryPayRules();
                    List<SelectListItem> SalaryPayRulesIDsList = new List<SelectListItem>();
                    foreach (SalaryPayRules item in SalaryPayRulesIDs)
                    {
                        SalaryPayRulesIDsList.Add(new SelectListItem { Text = item.PayScaleRuleDescription, Value = Convert.ToString(item.ID) });
                    }
                    ViewBag.SalaryPayRulesIDsList = new SelectList(SalaryPayRulesIDsList, "Value", "Text", model.SalaryGradePayMasterDTO.SalaryPayRulesID);


                   
                }
                return PartialView("/Views/Salary/SalaryGradePayMaster/Edit.cshtml", model);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public ActionResult Edit(SalaryGradePayMasterViewModel model)
        {
            try
            {
                if (model != null && model.SalaryGradePayMasterDTO != null)
                {
                    model.SalaryGradePayMasterDTO.ConnectionString = _connectioString;
                    model.SalaryGradePayMasterDTO.ID = model.ID;
                    model.SalaryGradePayMasterDTO.DesignationID = model.DesignationID;
                    model.SalaryGradePayMasterDTO.GradePayAmount = model.GradePayAmount;
                    model.SalaryGradePayMasterDTO.SalaryPayRulesID = model.SalaryPayRulesID;
                    //model.SalaryGradePayMasterDTO.Description = model.Description;
                    //model.SalaryGradePayMasterDTO.PayScaleRuleDescription = model.PayScaleRuleDescription;
                   
                    model.SalaryGradePayMasterDTO.ModifiedBy = Convert.ToInt32(Session["UserID"]);
                    IBaseEntityResponse<SalaryGradePayMaster> response = _SalaryGradePayMasterServiceAcess.UpdateSalaryGradePayMaster(model.SalaryGradePayMasterDTO);
                    model.SalaryGradePayMasterDTO.ErrorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Update);

                    return Json(model.SalaryGradePayMasterDTO.ErrorMessage, JsonRequestBehavior.AllowGet);
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

      

        public ActionResult Delete(Int16 ID)
        {
            var errorMessage = string.Empty;
            if (ID > 0)
            {
                IBaseEntityResponse<SalaryGradePayMaster> response = null;
                SalaryGradePayMaster SalaryGradePayMasterDTO = new SalaryGradePayMaster();
                SalaryGradePayMasterDTO.ConnectionString = _connectioString;
                SalaryGradePayMasterDTO.ID = ID;
                SalaryGradePayMasterDTO.DeletedBy = Convert.ToInt32(Session["UserID"]);
                response = _SalaryGradePayMasterServiceAcess.DeleteSalaryGradePayMaster(SalaryGradePayMasterDTO);
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
        public IEnumerable<SalaryGradePayMasterViewModel> GetSalaryPayScale(out int TotalRecords)
        {
            SalaryGradePayMasterSearchRequest searchRequest = new SalaryGradePayMasterSearchRequest();
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
            List<SalaryGradePayMasterViewModel> listSalaryPayScaleViewModel = new List<SalaryGradePayMasterViewModel>();
            List<SalaryGradePayMaster> listSalaryPayScale = new List<SalaryGradePayMaster>();
            IBaseEntityCollectionResponse<SalaryGradePayMaster> baseEntityCollectionResponse = _SalaryGradePayMasterServiceAcess.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listSalaryPayScale = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (SalaryGradePayMaster item in listSalaryPayScale)
                    {
                        SalaryGradePayMasterViewModel SalaryPayScaleViewModel = new SalaryGradePayMasterViewModel();
                        SalaryPayScaleViewModel.SalaryGradePayMasterDTO = item;
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

                IEnumerable<SalaryGradePayMasterViewModel> filteredUnitType;

                switch (Convert.ToInt32(sortColumnIndex))
                {
                    case 0:
                        _sortBy = "A.ID";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            // _searchBy = "A.GroupDescription like '%'";
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            // _searchBy = "A.GroupDescription Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                            _searchBy = "B.Description Like '%" + param.sSearch + "%' or A.GradePayAmount Like '%" + param.sSearch + "%' or C.PayScaleRuleDescription Like'%" + param.sSearch + "%'";
                        }
                        break;

                    case 1:
                        _sortBy = " B.Description";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            // _searchBy = "A.GroupDescription like '%'";
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            // _searchBy = "A.GroupDescription Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                            _searchBy = "B.Description Like '%" + param.sSearch + "%' or A.GradePayAmount Like '%" + param.sSearch + "%' or C.PayScaleRuleDescription Like'%" + param.sSearch + "%'";
                        }
                        break;
                    case 2:
                        _sortBy = "A.GradePayAmount";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            // _searchBy = "A.MarchandiseGroupCode like '%'";
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            //  _searchBy = "A.MarchandiseGroupCode Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                            _searchBy = "B.Description Like '%" + param.sSearch + "%' or A.GradePayAmount Like '%" + param.sSearch + "%' or C.PayScaleRuleDescription Like'%" + param.sSearch + "%'";
                        }
                        break;
                
                    case 3:
                        _sortBy = " C.PayScaleRuleDescription";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            // _searchBy = "A.MarchandiseGroupCode like '%'";
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            //  _searchBy = "A.MarchandiseGroupCode Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                            _searchBy = "B.Description Like '%" + param.sSearch + "%' or A.GradePayAmount Like '%" + param.sSearch + "%' or C.PayScaleRuleDescription Like'%" + param.sSearch + "%'";
                        }
                        break;

                }
                _sortDirection = sortDirection;
                _rowLength = param.iDisplayLength;
                _startRow = param.iDisplayStart;
                filteredUnitType = GetSalaryPayScale(out TotalRecords);
                var records = filteredUnitType.Skip(0).Take(param.iDisplayLength);
                var result = from c in records select new[] { Convert.ToString(c.DesignationID),Convert.ToString(c.SalaryPayRulesID),Convert.ToString(c.Description),Convert.ToString(c.PayScaleRuleDescription), Convert.ToString(c.ID),Convert.ToString(c.GradePayAmount) };

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