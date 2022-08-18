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
    public class FeePredefinedCriteriaParametersController : BaseController
    {
        IFeePredefinedCriteriaParametersServiceAccess _FeePredefinedCriteriaParametersServiceAcess = null;
        private readonly ILogger _logException;
        ActionModeEnum actionModeEnum;
        string _actionMode = string.Empty;
        string _sortBy = string.Empty;
        string _searchBy = string.Empty;
        string _sortDirection = string.Empty;
        int _startRow;
        int _rowLength;
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

        public FeePredefinedCriteriaParametersController()
        {
            _FeePredefinedCriteriaParametersServiceAcess = new FeePredefinedCriteriaParametersServiceAccess();
        }

        // Controller Methods
        #region Controller Methods
        public ActionResult Index()
        {
              return View("/Views/Fees/FeePredefinedCriteriaParameters/Index.cshtml");
        }

        public ActionResult List(string actionMode)
        {
            try
            {
                FeePredefinedCriteriaParametersViewModel model = new FeePredefinedCriteriaParametersViewModel();
                if (!string.IsNullOrEmpty(actionMode))
                {
                    TempData["ActionMode"] = actionMode;
                }
                return PartialView("/Views/Fees/FeePredefinedCriteriaParameters/List.cshtml", model);
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
            FeePredefinedCriteriaParametersViewModel model = new FeePredefinedCriteriaParametersViewModel();

            model.TableEntityNameList = GetTableEntityNameList();
            ViewBag.PrimaryKeyFieldNameList = new List<SelectListItem>();
            ViewBag.DisplayKeyFieldNameList = new List<SelectListItem>();
            return PartialView("/Views/Fees/FeePredefinedCriteriaParameters/Create.cshtml", model);
        }

        [HttpPost]
        public ActionResult Create(FeePredefinedCriteriaParametersViewModel model)
        {
            try
            {
                    if (model != null && model.FeePredefinedCriteriaParametersDTO != null)
                    {
                        model.FeePredefinedCriteriaParametersDTO.ConnectionString = _connectioString;
                        model.FeePredefinedCriteriaParametersDTO.FeeCriteriaParametersDescription = model.FeeCriteriaParametersDescription;
                        model.FeePredefinedCriteriaParametersDTO.FeeCriteriaParametersCode = model.FeeCriteriaParametersCode; ;
                        model.FeePredefinedCriteriaParametersDTO.TableEntityName = model.TableEntityName;
                        model.FeePredefinedCriteriaParametersDTO.PrimaryKeyFieldName = model.PrimaryKeyFieldName;
                        model.FeePredefinedCriteriaParametersDTO.DisplayKeyFieldName = model.DisplayKeyFieldName;

                        model.FeePredefinedCriteriaParametersDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                        IBaseEntityResponse<FeePredefinedCriteriaParameters> response = _FeePredefinedCriteriaParametersServiceAcess.InsertFeePredefinedCriteriaParameters(model.FeePredefinedCriteriaParametersDTO);
                        model.FeePredefinedCriteriaParametersDTO.errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20 , ActionModeEnum.Insert);
                        return Json(model.FeePredefinedCriteriaParametersDTO.errorMessage, JsonRequestBehavior.AllowGet);
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
        public ActionResult Edit(int id)
        {
            FeePredefinedCriteriaParametersViewModel model = new FeePredefinedCriteriaParametersViewModel();
            try
            {                
                model.FeePredefinedCriteriaParametersDTO = new FeePredefinedCriteriaParameters();
                model.FeePredefinedCriteriaParametersDTO.ID = id;
                model.FeePredefinedCriteriaParametersDTO.ConnectionString = _connectioString;

                IBaseEntityResponse<FeePredefinedCriteriaParameters> response = _FeePredefinedCriteriaParametersServiceAcess.SelectByID(model.FeePredefinedCriteriaParametersDTO);
                if (response != null && response.Entity != null)
                {
                    model.FeePredefinedCriteriaParametersDTO.ID = response.Entity.ID;
                    model.FeePredefinedCriteriaParametersDTO.FeeCriteriaParametersDescription = response.Entity.FeeCriteriaParametersDescription;
                    model.FeePredefinedCriteriaParametersDTO.FeeCriteriaParametersCode = response.Entity.FeeCriteriaParametersCode;
                    model.FeePredefinedCriteriaParametersDTO.TableEntityName = response.Entity.TableEntityName;
                    model.FeePredefinedCriteriaParametersDTO.PrimaryKeyFieldName = response.Entity.PrimaryKeyFieldName;
                    model.FeePredefinedCriteriaParametersDTO.DisplayKeyFieldName = response.Entity.DisplayKeyFieldName;
                    model.FeePredefinedCriteriaParametersDTO.CreatedBy = response.Entity.CreatedBy;
                }
                return PartialView("/Views/Fees/FeePredefinedCriteriaParameters/Edit.cshtml", model);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public ActionResult Edit(FeePredefinedCriteriaParametersViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model != null && model.FeePredefinedCriteriaParametersDTO != null)
                {
                    if (model != null && model.FeePredefinedCriteriaParametersDTO != null)
                    {
                        model.FeePredefinedCriteriaParametersDTO.ConnectionString = _connectioString;
                        model.FeePredefinedCriteriaParametersDTO.FeeCriteriaParametersDescription = model.FeeCriteriaParametersDescription;
                        model.FeePredefinedCriteriaParametersDTO.FeeCriteriaParametersCode = model.FeeCriteriaParametersCode; ;
                        model.FeePredefinedCriteriaParametersDTO.TableEntityName = model.TableEntityName;
                        model.FeePredefinedCriteriaParametersDTO.PrimaryKeyFieldName = model.PrimaryKeyFieldName;
                        model.FeePredefinedCriteriaParametersDTO.DisplayKeyFieldName = model.DisplayKeyFieldName;
                        model.FeePredefinedCriteriaParametersDTO.ModifiedBy = Convert.ToInt32(Session["UserID"]);
                        IBaseEntityResponse<FeePredefinedCriteriaParameters> response = _FeePredefinedCriteriaParametersServiceAcess.UpdateFeePredefinedCriteriaParameters(model.FeePredefinedCriteriaParametersDTO);
                        model.FeePredefinedCriteriaParametersDTO.errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Update);
                    }
                }
                return Json(model.FeePredefinedCriteriaParametersDTO.errorMessage, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("Please review your form");
            }
        }

        //[HttpGet]
        //public ActionResult Delete(int ID)
        //{
        //    FeePredefinedCriteriaParametersViewModel model = new FeePredefinedCriteriaParametersViewModel();
        //    model.FeePredefinedCriteriaParametersDTO = new FeePredefinedCriteriaParameters();
        //    model.FeePredefinedCriteriaParametersDTO.ID = ID;
        //    return PartialView("/Views/Fees/FeePredefinedCriteriaParameters/Delete.cshtml", model);
        //}

        //[HttpPost]
        //public ActionResult Delete(FeePredefinedCriteriaParametersViewModel model)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        if (model.ID > 0)
        //        {
        //            FeePredefinedCriteriaParameters FeePredefinedCriteriaParametersDTO = new FeePredefinedCriteriaParameters();
        //            FeePredefinedCriteriaParametersDTO.ConnectionString = _connectioString;
        //            FeePredefinedCriteriaParametersDTO.ID = model.ID;
        //            FeePredefinedCriteriaParametersDTO.DeletedBy = Convert.ToInt32(Session["UserID"]);
        //            IBaseEntityResponse<FeePredefinedCriteriaParameters> response = _FeePredefinedCriteriaParametersServiceAcess.DeleteFeePredefinedCriteriaParameters(FeePredefinedCriteriaParametersDTO);
        //            model.FeePredefinedCriteriaParametersDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Delete);

        //        }
        //        return Json(model.FeePredefinedCriteriaParametersDTO.errorMessage, JsonRequestBehavior.AllowGet);
        //    }
        //    else
        //    {
        //        return Json("Please review your form");
        //    }
        //}

        //[HttpPost]
        public ActionResult Delete(int ID)
        {
            FeePredefinedCriteriaParametersViewModel model = new FeePredefinedCriteriaParametersViewModel();
            //if (!ModelState.IsValid)
            //{
                if (ID > 0)
                {
                    FeePredefinedCriteriaParameters FeePredefinedCriteriaParametersDTO = new FeePredefinedCriteriaParameters();
                    FeePredefinedCriteriaParametersDTO.ConnectionString = _connectioString;
                    FeePredefinedCriteriaParametersDTO.ID = ID;
                    FeePredefinedCriteriaParametersDTO.DeletedBy = Convert.ToInt32(Session["UserID"]);
                    IBaseEntityResponse<FeePredefinedCriteriaParameters> response = _FeePredefinedCriteriaParametersServiceAcess.DeleteFeePredefinedCriteriaParameters(FeePredefinedCriteriaParametersDTO);
                    model.FeePredefinedCriteriaParametersDTO.errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Delete);

                }
                return Json(model.FeePredefinedCriteriaParametersDTO.errorMessage, JsonRequestBehavior.AllowGet);
            //}
            //else
            //{
            //    return Json("Please review your form");
            //}
        }
        #endregion

        //list for fetching the names of tables
        protected List<FeePredefinedCriteriaParameters> GetTableEntityNameList()
        {
            FeePredefinedCriteriaParametersSearchRequest searchRequest = new FeePredefinedCriteriaParametersSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            List<FeePredefinedCriteriaParameters> TableEntityNameList = new List<FeePredefinedCriteriaParameters>();
            IBaseEntityCollectionResponse<FeePredefinedCriteriaParameters> baseEntityCollectionResponse = _FeePredefinedCriteriaParametersServiceAcess.GetTableEntityNameList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    TableEntityNameList = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return TableEntityNameList;
        }

        protected List<FeePredefinedCriteriaParameters> GetPrimaryKeyFieldNameList(string tableName)
        {
            FeePredefinedCriteriaParametersSearchRequest searchRequest = new FeePredefinedCriteriaParametersSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.TableName = tableName;
            List<FeePredefinedCriteriaParameters> PrimaryKeyFieldNameList = new List<FeePredefinedCriteriaParameters>();
            IBaseEntityCollectionResponse<FeePredefinedCriteriaParameters> baseEntityCollectionResponse = _FeePredefinedCriteriaParametersServiceAcess.GetPrimaryKeyFieldNameList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    PrimaryKeyFieldNameList = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return PrimaryKeyFieldNameList;
        }
        protected List<FeePredefinedCriteriaParameters> GetDisplayKeyFieldNameList(string tableName)
        {
            FeePredefinedCriteriaParametersSearchRequest searchRequest = new FeePredefinedCriteriaParametersSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.TableName = tableName;
            List<FeePredefinedCriteriaParameters> DisplayKeyFieldNameList = new List<FeePredefinedCriteriaParameters>();
            IBaseEntityCollectionResponse<FeePredefinedCriteriaParameters> baseEntityCollectionResponse = _FeePredefinedCriteriaParametersServiceAcess.GetDisplayKeyFieldNameList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    DisplayKeyFieldNameList = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return DisplayKeyFieldNameList;
        }
        [AcceptVerbs(HttpVerbs.Get)]
        public JsonResult GetPrimaryKeyList(string tableName)
        {
            try
            {
                var dataList1 = GetPrimaryKeyFieldNameList(!string.IsNullOrEmpty(tableName) ? tableName : string.Empty);
                var result1 = (from s in dataList1 select new { id = s.PrimaryKeyFieldName, name = s.PrimaryKeyFieldName }).ToList();
                var dataList2 = GetDisplayKeyFieldNameList(!string.IsNullOrEmpty(tableName) ? tableName : string.Empty);
                var result2 = (from s in dataList2 select new { id = s.DisplayKeyFieldName, name = s.DisplayKeyFieldName }).ToList();
                var objList = new { Result1 = result1, Result2 = result2 };
                return Json(objList, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        // Non-Action Method
        #region Methods
        public IEnumerable<FeePredefinedCriteriaParametersViewModel> GetFeePredefinedCriteriaParameters(out int TotalRecords)
        {
            FeePredefinedCriteriaParametersSearchRequest searchRequest = new FeePredefinedCriteriaParametersSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            _actionMode = Convert.ToString(TempData["ActionMode"]);
            if (Enum.TryParse(_actionMode, out actionModeEnum))     // checks actionMode i.e. Insert or Update // 
            {
                if (actionModeEnum == ActionModeEnum.Insert)        // parameters for SelectAll procedures under Insert or Update mode condition
                {
                    searchRequest.SortBy = "CreatedDate";
                    searchRequest.StartRow = 0;
                    searchRequest.EndRow = 10;
                    searchRequest.SearchBy = "FeeCriteriaParametersDescription Like '%'";
                    searchRequest.SortDirection = "Desc";
                }
                if (actionModeEnum == ActionModeEnum.Update)
                {
                    searchRequest.SortBy = "ModifiedDate";
                    searchRequest.StartRow = 0;
                    searchRequest.EndRow = 10;
                    searchRequest.SearchBy = "FeeCriteriaParametersDescription Like '%'";
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
            List<FeePredefinedCriteriaParametersViewModel> listFeePredefinedCriteriaParametersViewModel = new List<FeePredefinedCriteriaParametersViewModel>();
            List<FeePredefinedCriteriaParameters> listFeePredefinedCriteriaParameters = new List<FeePredefinedCriteriaParameters>();
            IBaseEntityCollectionResponse<FeePredefinedCriteriaParameters> baseEntityCollectionResponse = _FeePredefinedCriteriaParametersServiceAcess.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listFeePredefinedCriteriaParameters = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (FeePredefinedCriteriaParameters item in listFeePredefinedCriteriaParameters)
                    {
                        FeePredefinedCriteriaParametersViewModel FeePredefinedCriteriaParametersViewModel = new FeePredefinedCriteriaParametersViewModel();
                        FeePredefinedCriteriaParametersViewModel.FeePredefinedCriteriaParametersDTO = item;
                        listFeePredefinedCriteriaParametersViewModel.Add(FeePredefinedCriteriaParametersViewModel);
                    }
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listFeePredefinedCriteriaParametersViewModel;
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

                IEnumerable<FeePredefinedCriteriaParametersViewModel> filteredCountryMaster;
                switch (Convert.ToInt32(sortColumnIndex))
                {
                    case 0:
                        _sortBy = "FeeCriteriaParametersDescription";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = "FeeCriteriaParametersDescription Like '%'";
                        }
                        else
                        {
                            _searchBy = "FeeCriteriaParametersDescription Like '%" + param.sSearch + "%' or FeeCriteriaParametersCode Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                        }
                        break;
                    case 1:
                        _sortBy = "FeeCriteriaParametersCode";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = "FeeCriteriaParametersDescription Like '%'";
                        }
                        else
                        {
                            _searchBy = "FeeCriteriaParametersDescription Like '%" + param.sSearch + "%' or FeeCriteriaParametersCode Like '%" + param.sSearch + "%'";     //this "if" block is added for search functionality
                        }
                        break;

                    case 2:
                        _sortBy = "TableEntityName";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = "FeeCriteriaParametersDescription Like '%'";
                        }
                        else
                        {
                            _searchBy = "FeeCriteriaParametersDescription Like '%" + param.sSearch + "%' or FeeCriteriaParametersCode Like '%" + param.sSearch + "%'";     //this "if" block is added for search functionality
                        }
                        break;
                    case 3:
                        _sortBy = "PrimaryKeyFieldName";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = "FeeCriteriaParametersDescription Like '%'";
                        }
                        else
                        {
                            _searchBy = "FeeCriteriaParametersDescription Like '%" + param.sSearch + "%' or FeeCriteriaParametersCode Like '%" + param.sSearch + "%'";     //this "if" block is added for search functionality
                        }
                        break;
                    case 4:
                        _sortBy = "DisplayKeyFieldName";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = "FeeCriteriaParametersDescription Like '%'";
                        }
                        else
                        {
                            _searchBy = "FeeCriteriaParametersDescription Like '%" + param.sSearch + "%' or FeeCriteriaParametersCode Like '%" + param.sSearch + "%'";     //this "if" block is added for search functionality
                        }
                        break;

                }
                _sortDirection = sortDirection;
                _rowLength = param.iDisplayLength;
                _startRow = param.iDisplayStart;
                filteredCountryMaster = GetFeePredefinedCriteriaParameters(out TotalRecords);
                var records = filteredCountryMaster.Skip(0).Take(param.iDisplayLength);
                var result = from c in records select new[] { c.FeeCriteriaParametersDescription.ToString(), c.FeeCriteriaParametersCode.ToString(), c.TableEntityName.ToString(), c.PrimaryKeyFieldName.ToString(), c.DisplayKeyFieldName.ToString(), Convert.ToString(c.ID) };

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