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
    public class FeeCriteriaParametersAndValuesController : BaseController
    {
        IFeeCriteriaParametersAndValuesServiceAccess _feeCriteriaParametersAndValuesServiceAcess = null;
        private readonly ILogger _logException;
        ActionModeEnum actionModeEnum;
        string _actionMode = string.Empty;
        string _sortBy = string.Empty;
        string _searchBy = string.Empty;
        string _sortDirection = string.Empty;
        int _startRow;
        int _rowLength;
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

        public FeeCriteriaParametersAndValuesController()
        {
            _feeCriteriaParametersAndValuesServiceAcess = new FeeCriteriaParametersAndValuesServiceAccess();
        }

        // Controller Methods
        #region Controller Methods
        public ActionResult Index()
        {

            return View("/Views/Fees/FeeCriteriaParametersAndValues/Index.cshtml");


        }

        public ActionResult List(string actionMode, string feeCriteriaParameterOrValue)
        {
            try
            {
                FeeCriteriaParametersAndValuesViewModel model = new FeeCriteriaParametersAndValuesViewModel();
                if (!string.IsNullOrEmpty(actionMode))
                {
                    TempData["ActionMode"] = actionMode;

                }
                if (!string.IsNullOrEmpty(feeCriteriaParameterOrValue))
                {
                    TempData["FeeCriteriaParameterOrValue"] = feeCriteriaParameterOrValue;
                }
                return PartialView("/Views/Fees/FeeCriteriaParametersAndValues/List.cshtml", model);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }

        }


        [HttpGet]
        public ActionResult CreateFeeCriteriaParameter(int ID)
        {
            FeeCriteriaParametersAndValuesViewModel model = new FeeCriteriaParametersAndValuesViewModel();
            model.FeeCriteriaParametersID = ID;
            //List of FeePredefinedCriteriaParameters
            model.PredefinedCriteriaParametersList = GetFeePredefinedCriteriaParametersList(Convert.ToInt32(Session["BalancesheetID"]));            
            return PartialView("~/Views/Fees/FeeCriteriaParametersAndValues/CreateFeeCriteriaParameter.cshtml", model);
        }

        [HttpPost]
        public ActionResult CreateFeeCriteriaParameter(FeeCriteriaParametersAndValuesViewModel model)
        {
            try
            {

                model.AccBalanceSheetID = Convert.ToInt32(Session["BalancesheetID"]);
                if (model != null && model.AccBalanceSheetID > 0)
                {
                    model.FeeCriteriaParametersAndValuesDTO.ConnectionString = _connectioString;
                    model.FeeCriteriaParametersAndValuesDTO.FeeCriteriaParameterOrValue = "Parameter";
                    model.FeeCriteriaParametersAndValuesDTO.FeeCriteriaParametersDescription = model.FeeCriteriaParametersDescription;
                    model.FeeCriteriaParametersAndValuesDTO.FeeCriteriaParametersCode = model.FeeCriteriaParametersCode; ;
                    model.FeeCriteriaParametersAndValuesDTO.RelatedWith = model.RelatedWith;
                    model.FeeCriteriaParametersAndValuesDTO.IsActive = true;
                    model.FeeCriteriaParametersAndValuesDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                    IBaseEntityResponse<FeeCriteriaParametersAndValues> response = _feeCriteriaParametersAndValuesServiceAcess.InsertFeeCriteriaParametersAndValues(model.FeeCriteriaParametersAndValuesDTO);
                    model.FeeCriteriaParametersAndValuesDTO.errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                    if (response.Entity.ErrorCode == 0)
                    {
                        model.FeeCriteriaParametersAndValuesDTO.errorMessage = model.FeeCriteriaParametersAndValuesDTO.errorMessage + ",Parameter";
                    }
                    return Json(model.FeeCriteriaParametersAndValuesDTO.errorMessage, JsonRequestBehavior.AllowGet);
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
        public ActionResult CreateFeeCriteriaParametersValue(string feeCriteriaParametersDetails)
        {
            string[] feeCriteriaParametersDetailsArray = feeCriteriaParametersDetails.Split(':');

            FeeCriteriaParametersAndValuesViewModel model = new FeeCriteriaParametersAndValuesViewModel();
            model.FeeCriteriaParametersDescription = Convert.ToString(feeCriteriaParametersDetailsArray[0].Replace('~', ' '));
            model.FeeCriteriaParametersID = Convert.ToInt32(feeCriteriaParametersDetailsArray[1]);
            model.PredefinedCriteriaParametersValueList = GetPredefinedCriteriaParametersValueList(Convert.ToInt32(feeCriteriaParametersDetailsArray[1]));
            return PartialView("~/Views/Fees/FeeCriteriaParametersAndValues/CreateFeeCriteriaParametersValue.cshtml", model);
        }

        [HttpPost]
        public ActionResult CreateFeeCriteriaParametersValue(FeeCriteriaParametersAndValuesViewModel model)
        {
            try
            {

                model.AccBalanceSheetID = Convert.ToInt32(Session["BalancesheetID"]);
                if (model != null && model.AccBalanceSheetID > 0)
                {
                    model.FeeCriteriaParametersAndValuesDTO.ConnectionString = _connectioString;
                    model.FeeCriteriaParametersAndValuesDTO.FeeCriteriaParameterOrValue = "Value";
                    model.FeeCriteriaParametersAndValuesDTO.FeeCriteriaParametersID = model.FeeCriteriaParametersID;
                    model.FeeCriteriaParametersAndValuesDTO.FeeCriteriaParameterValue = model.FeeCriteriaParameterValue;
                    //model.FeeCriteriaParametersAndValuesDTO.IsActive = true;
                    model.FeeCriteriaParametersAndValuesDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                    IBaseEntityResponse<FeeCriteriaParametersAndValues> response = _feeCriteriaParametersAndValuesServiceAcess.InsertFeeCriteriaParametersAndValues(model.FeeCriteriaParametersAndValuesDTO);
                    model.FeeCriteriaParametersAndValuesDTO.errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                    if (response.Entity.ErrorCode == 0)
                    {
                        model.FeeCriteriaParametersAndValuesDTO.errorMessage = model.FeeCriteriaParametersAndValuesDTO.errorMessage + ",Value";
                    }
                    return Json(model.FeeCriteriaParametersAndValuesDTO.errorMessage, JsonRequestBehavior.AllowGet);
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
        //[HttpGet]
        //public ActionResult DeleteFeeCriteriaParameter(int feeCriteriaParametersID)
        //{

        //    FeeCriteriaParametersAndValuesViewModel model = new FeeCriteriaParametersAndValuesViewModel();
        //    model.FeeCriteriaParametersAndValuesDTO = new FeeCriteriaParametersAndValues();
        //    model.FeeCriteriaParametersAndValuesDTO.FeeCriteriaParametersID = feeCriteriaParametersID;
        //    return PartialView("~/Views/Fees/FeeCriteriaParametersAndValues/DeleteFeeCriteriaParameter.cshtml", model);
        //}

        //[HttpPost]
        public ActionResult DeleteFeeCriteriaParameter(int feeCriteriaParametersID)
        {

                FeeCriteriaParametersAndValuesViewModel model = new FeeCriteriaParametersAndValuesViewModel();
                FeeCriteriaParametersAndValues feeCriteriaParametersAndValuesDTO = new FeeCriteriaParametersAndValues();
                feeCriteriaParametersAndValuesDTO.ConnectionString = _connectioString;
                feeCriteriaParametersAndValuesDTO.FeeCriteriaParameterOrValue = "Parameter";
                feeCriteriaParametersAndValuesDTO.FeeCriteriaParametersID = feeCriteriaParametersID;
                feeCriteriaParametersAndValuesDTO.DeletedBy = Convert.ToInt32(Session["UserID"]);
                IBaseEntityResponse<FeeCriteriaParametersAndValues> response = _feeCriteriaParametersAndValuesServiceAcess.DeleteFeeCriteriaParametersAndValues(feeCriteriaParametersAndValuesDTO);
                model.FeeCriteriaParametersAndValuesDTO.errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Delete);
                return Json(model.FeeCriteriaParametersAndValuesDTO.errorMessage, JsonRequestBehavior.AllowGet);
           
        }


        //[HttpGet]
        //public ActionResult DeleteFeeCriteriaParameterValue(int feeCriteriaParametersValueID)
        //{

        //    FeeCriteriaParametersAndValuesViewModel model = new FeeCriteriaParametersAndValuesViewModel();
        //    model.FeeCriteriaParametersAndValuesDTO = new FeeCriteriaParametersAndValues();
        //    model.FeeCriteriaParametersAndValuesDTO.FeeCriteriaParametersValuesID = feeCriteriaParametersValueID;
        //    return PartialView("~/Views/Fees/FeeCriteriaParametersAndValues/DeleteFeeCriteriaParametersValue.cshtml", model);
        //}

        //[HttpPost]
        public ActionResult DeleteFeeCriteriaParameterValue(int feeCriteriaParametersValueID)
        {

                FeeCriteriaParametersAndValuesViewModel model = new FeeCriteriaParametersAndValuesViewModel();
                FeeCriteriaParametersAndValues feeCriteriaParametersAndValuesDTO = new FeeCriteriaParametersAndValues();
                feeCriteriaParametersAndValuesDTO.ConnectionString = _connectioString;
                feeCriteriaParametersAndValuesDTO.FeeCriteriaParameterOrValue = "Value";
                feeCriteriaParametersAndValuesDTO.FeeCriteriaParametersValuesID = feeCriteriaParametersValueID;
                feeCriteriaParametersAndValuesDTO.DeletedBy = Convert.ToInt32(Session["UserID"]);
                IBaseEntityResponse<FeeCriteriaParametersAndValues> response = _feeCriteriaParametersAndValuesServiceAcess.DeleteFeeCriteriaParametersAndValues(feeCriteriaParametersAndValuesDTO);
                model.FeeCriteriaParametersAndValuesDTO.errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Delete);
                return Json(model.FeeCriteriaParametersAndValuesDTO.errorMessage, JsonRequestBehavior.AllowGet);
           
        }

        #endregion

        // Non-Action Method
        #region Methods
        public IEnumerable<FeeCriteriaParametersAndValuesViewModel> GetFeeCriteriaParametersAndValues(out int TotalRecords)
        {
            FeeCriteriaParametersAndValuesSearchRequest searchRequest = new FeeCriteriaParametersAndValuesSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            _actionMode = Convert.ToString(TempData["ActionMode"]);

            searchRequest.AccBalanceSheetID = Convert.ToInt32(Session["BalancesheetID"]);
            if (Enum.TryParse(_actionMode, out actionModeEnum))     // checks actionMode i.e. Insert or Update // 
            {
                if (actionModeEnum == ActionModeEnum.Insert)        // parameters for SelectAll procedures under Insert or Update mode condition
                {
                    if (Convert.ToString(TempData["FeeCriteriaParameterOrValue"]) == "Parameter")
                    {
                        searchRequest.SortBy = "A.CreatedDate";
                    }
                    else if (Convert.ToString(TempData["FeeCriteriaParameterOrValue"]) == "Value")
                    {
                        searchRequest.SortBy = "C.CreatedDate";
                    }
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
            List<FeeCriteriaParametersAndValuesViewModel> listFeeCriteriaParametersAndValuesViewModel = new List<FeeCriteriaParametersAndValuesViewModel>();
            List<FeeCriteriaParametersAndValues> listFeeCriteriaParametersAndValues = new List<FeeCriteriaParametersAndValues>();
            IBaseEntityCollectionResponse<FeeCriteriaParametersAndValues> baseEntityCollectionResponse = _feeCriteriaParametersAndValuesServiceAcess.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listFeeCriteriaParametersAndValues = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (FeeCriteriaParametersAndValues item in listFeeCriteriaParametersAndValues)
                    {
                        FeeCriteriaParametersAndValuesViewModel feeCriteriaParametersAndValuesViewModel = new FeeCriteriaParametersAndValuesViewModel();
                        feeCriteriaParametersAndValuesViewModel.FeeCriteriaParametersAndValuesDTO = item;
                        listFeeCriteriaParametersAndValuesViewModel.Add(feeCriteriaParametersAndValuesViewModel);
                    }
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listFeeCriteriaParametersAndValuesViewModel;
        }


        [NonAction]
        protected List<FeePredefinedCriteriaParameters> GetFeePredefinedCriteriaParametersList(int balanceSheetID)
        {
            FeePredefinedCriteriaParametersSearchRequest searchRequest = new FeePredefinedCriteriaParametersSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.BalanceSheetID = balanceSheetID;
            List<FeePredefinedCriteriaParameters> listCriteriaParameters = new List<FeePredefinedCriteriaParameters>();
            IBaseEntityCollectionResponse<FeePredefinedCriteriaParameters> baseEntityCollectionResponse = _feeCriteriaParametersAndValuesServiceAcess.GetFeePredefinedCriteriaParametersList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listCriteriaParameters = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listCriteriaParameters;
        }

        [NonAction]
        protected List<FeeCriteriaParametersAndValues> GetPredefinedCriteriaParametersValueList(int parameterID)
        {
            FeeCriteriaParametersAndValuesSearchRequest searchRequest = new FeeCriteriaParametersAndValuesSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.FeeCriteriaParametersValuesID = parameterID;
            List<FeeCriteriaParametersAndValues> listCriteriaParameters = new List<FeeCriteriaParametersAndValues>();
            IBaseEntityCollectionResponse<FeeCriteriaParametersAndValues> baseEntityCollectionResponse = _feeCriteriaParametersAndValuesServiceAcess.GetPredefinedCriteriaParametersValueList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listCriteriaParameters = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listCriteriaParameters;
        }

        #endregion

        // AjaxHandler Method
        #region AjaxHandler
        public ActionResult AjaxHandler(JQueryDataTableParamModel param)
        {

            int TotalRecords;
            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc

            IEnumerable<FeeCriteriaParametersAndValuesViewModel> filteredFeeCriteriaParametersAndValues;
            switch (Convert.ToInt32(sortColumnIndex))
            {
                case 0:
                    _sortBy = "A.FeeCriteriaParametersDescription";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "A.FeeCriteriaParametersDescription Like '%" + param.sSearch + "%' or C.FeeCriteriaParameterValue Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;
                case 1:
                    _sortBy = "C.FeeCriteriaParameterValue";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "A.FeeCriteriaParametersDescription Like '%" + param.sSearch + "%' or C.FeeCriteriaParameterValue Like '%" + param.sSearch + "%'";      //this "if" block is added for search functionality
                    }
                    break;
            }
            _sortDirection = sortDirection;
            _rowLength = param.iDisplayLength;
            _startRow = param.iDisplayStart;
            if (Convert.ToInt32(Session["BalancesheetID"]) > 0)
            {
                filteredFeeCriteriaParametersAndValues = GetFeeCriteriaParametersAndValues(out TotalRecords);
            }
            else
            {
                filteredFeeCriteriaParametersAndValues = new List<FeeCriteriaParametersAndValuesViewModel>();
                TotalRecords = 0;
            }

            var records = filteredFeeCriteriaParametersAndValues.Skip(0).Take(param.iDisplayLength);
            var result = from c in records select new[] { c.FeeCriteriaParametersDescription.ToString(), c.FeeCriteriaParameterValue.ToString(), Convert.ToString(c.FeeCriteriaParametersID), Convert.ToString(c.FeeCriteriaParametersValuesID) };

            return Json(new { sEcho = param.sEcho, iTotalRecords = TotalRecords, iTotalDisplayRecords = TotalRecords, aaData = result }, JsonRequestBehavior.AllowGet);


        }
        #endregion
    }
}