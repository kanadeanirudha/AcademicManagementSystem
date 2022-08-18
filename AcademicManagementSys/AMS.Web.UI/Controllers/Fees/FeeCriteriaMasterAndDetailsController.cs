using AMS.Base.DTO;
using AMS.DTO;
using AMS.ServiceAccess;
using AMS.ViewModel;
using System;
using AMS.ExceptionManager;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web.Mvc;
using AMS.Common;

namespace AMS.Web.UI.Controllers
{
    public class FeeCriteriaMasterAndDetailsController : BaseController
    {
        #region ------------CONTROLLER CLASS VARIABLE------------

        IFeeCriteriaMasterAndDetailsServiceAccess _feeCriteriaMasterAndDetailsServiceAccess = null;
        IFeeCriteriaParametersAndValuesServiceAccess _feeCriteriaParametersAndValuesServiceAccess = null;
        
        private readonly ILogger _logException;
        ActionModeEnum actionModeEnum;
        string _actionMode = string.Empty;
        string _sortBy = string.Empty;
        string _searchBy = string.Empty;
        string _sortDirection = string.Empty;
        int _startRow;
        int _rowLength;
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
        #endregion

        #region ------------CONTROLLER CLASS CONSTRUCTOR------------
        public FeeCriteriaMasterAndDetailsController()
        {
            _feeCriteriaMasterAndDetailsServiceAccess = new FeeCriteriaMasterAndDetailsServiceAccess();
            _feeCriteriaParametersAndValuesServiceAccess = new FeeCriteriaParametersAndValuesServiceAccess();
            
        }
        #endregion

        #region ------------CONTROLLER ACTION METHODS------------
        public ActionResult Index()
        {
           return View("/Views/Fees/FeeCriteriaMasterAndDetails/Index.cshtml");
        }

        public ActionResult List(string actionMode)
        {
            try
            {
                FeeCriteriaMasterAndDetailsViewModel model = new FeeCriteriaMasterAndDetailsViewModel();
                if (!string.IsNullOrEmpty(actionMode))
                {
                    TempData["ActionMode"] = actionMode;
                }
                return PartialView("/Views/Fees/FeeCriteriaMasterAndDetails/List.cshtml",model);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        [HttpGet]
        public ActionResult CreateCriteriaMasterAndDetails()
        {
            try
            {
                FeeCriteriaMasterAndDetailsViewModel model = new FeeCriteriaMasterAndDetailsViewModel();
                model.FeeTypeList = GetFeeTypeList();
                model.FeeCriteriaParametersAndValuesList = GetFeeCriteriaParametersAndValuesList(Convert.ToInt16(Session["BalancesheetID"]));
                model.AccBalanceSheetName = Convert.ToString(Session["BalancesheetName"]);
                model.AccBalanceSheetID = Convert.ToInt16(Session["BalancesheetID"]);
                return PartialView("/Views/Fees/FeeCriteriaMasterAndDetails/CreateCriteriaMasterAndDetails.cshtml", model); 
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }
        [HttpPost]
        public ActionResult CreateCriteriaMasterAndDetails(FeeCriteriaMasterAndDetailsViewModel model)
        {
            try
            {
                model.FeeCriteriaMasterAndDetailsDTO.ConnectionString = _connectioString;
                model.FeeCriteriaMasterAndDetailsDTO.FeeTypeID = model.FeeTypeID;
                model.FeeCriteriaMasterAndDetailsDTO.AccBalanceSheetID = model.AccBalanceSheetID;
                model.FeeCriteriaMasterAndDetailsDTO.FeeCriteriaParametersXML = model.FeeCriteriaParametersXML;
                model.FeeCriteriaMasterAndDetailsDTO.FeeCriteriaDescription = model.FeeCriteriaDescription;
                model.FeeCriteriaMasterAndDetailsDTO.FeeCriteriaCode = model.FeeCriteriaCode; 
                model.FeeCriteriaMasterAndDetailsDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                IBaseEntityResponse<FeeCriteriaMasterAndDetails> response = _feeCriteriaMasterAndDetailsServiceAccess.InsertFeeCriteriaMasterAndDetails(model.FeeCriteriaMasterAndDetailsDTO);
                model.FeeCriteriaMasterAndDetailsDTO.errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                return Json(model.FeeCriteriaMasterAndDetailsDTO.errorMessage, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }
        //[HttpGet]
        //public ActionResult DeleteCriteriaMasterAndDetails(int ID)
        //{
        //    try
        //    {
        ////        FeeCriteriaMasterAndDetailsViewModel model = new FeeCriteriaMasterAndDetailsViewModel();
        ////        model.FeeCriteriaMasterAndDetailsDTO = new FeeCriteriaMasterAndDetails();
        ////        model.FeeCriteriaMasterAndDetailsDTO.ID = ID;
        ////        return PartialView("/Views/Fees/FeeCriteriaMasterAndDetails/DeleteCriteriaMasterAndDetails.cshtml", model);
        ////    }
        ////    catch (Exception ex)
        ////    {
        ////        _logException.Error(ex.Message);
        ////        throw;
        ////    }
        //}
        //[HttpPost]
        public ActionResult DeleteCriteriaMasterAndDetails(int ID)
        {
            try
            {               
                FeeCriteriaMasterAndDetailsViewModel model = new FeeCriteriaMasterAndDetailsViewModel();
                FeeCriteriaMasterAndDetails FeeCriteriaMasterAndDetailsDTO = new FeeCriteriaMasterAndDetails();
                FeeCriteriaMasterAndDetailsDTO.ConnectionString = _connectioString;
                FeeCriteriaMasterAndDetailsDTO.ID = ID;
                FeeCriteriaMasterAndDetailsDTO.DeletedBy = Convert.ToInt32(Session["UserID"]);
                IBaseEntityResponse<FeeCriteriaMasterAndDetails> response = _feeCriteriaMasterAndDetailsServiceAccess.DeleteFeeCriteriaMasterAndDetails(FeeCriteriaMasterAndDetailsDTO);
                model.FeeCriteriaMasterAndDetailsDTO.errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Delete);
                return Json(model.FeeCriteriaMasterAndDetailsDTO.errorMessage, JsonRequestBehavior.AllowGet);               
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }




        #endregion

        #region ------------CONTROLLER NON ACTION METHODS------------
        //Non-Action method to fetch list of Balancesheet
        protected List<FeeTypeAndSubType> GetFeeTypeList()
        {
            FeeTypeAndSubTypeSearchRequest searchRequest = new FeeTypeAndSubTypeSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            List<FeeTypeAndSubType> listFeeType = new List<FeeTypeAndSubType>();
            IBaseEntityCollectionResponse<FeeTypeAndSubType> baseEntityCollectionResponse = _feeCriteriaMasterAndDetailsServiceAccess.GetFeeTypeList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listFeeType = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listFeeType;
        }
        protected List<FeeCriteriaParametersAndValues> GetFeeCriteriaParametersAndValuesList(Int16 balancesheetID)
        {
            FeeCriteriaParametersAndValuesSearchRequest searchRequest = new FeeCriteriaParametersAndValuesSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.AccBalanceSheetID = balancesheetID;
            List<FeeCriteriaParametersAndValues> listFeeCriteriaParametersAndValues = new List<FeeCriteriaParametersAndValues>();
            IBaseEntityCollectionResponse<FeeCriteriaParametersAndValues> baseEntityCollectionResponse = _feeCriteriaParametersAndValuesServiceAccess.SearchList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listFeeCriteriaParametersAndValues = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listFeeCriteriaParametersAndValues;
        }
        
        // Non-Action method to fetch all records from table.
        [NonAction]
        public List<FeeCriteriaMasterAndDetails> GetListFeeCriteriaMasterAndDetails( out int TotalRecords)
        {
            List<FeeCriteriaMasterAndDetails> listFeeCriteriaMasterAndDetails = new List<FeeCriteriaMasterAndDetails>();
            FeeCriteriaMasterAndDetailsSearchRequest searchRequest = new FeeCriteriaMasterAndDetailsSearchRequest();
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
                    searchRequest.AccBalanceSheetID = Convert.ToInt16(Session["BalancesheetID"]);
                }
                if (actionModeEnum == ActionModeEnum.Update)
                {
                    searchRequest.SortBy = "A.ModifiedDate";
                    searchRequest.StartRow = 0;
                    searchRequest.EndRow = 10;
                    searchRequest.SearchBy = string.Empty;
                    searchRequest.SortDirection = "Desc";
                    searchRequest.AccBalanceSheetID = Convert.ToInt16(Session["BalancesheetID"]);
                }
            }
            else
            {
                searchRequest.SortBy = _sortBy;                     // parameters for SelectAll procedures under normal condition
                searchRequest.StartRow = _startRow;
                searchRequest.EndRow = _startRow + _rowLength;
                searchRequest.SearchBy = _searchBy;
                searchRequest.SortDirection = _sortDirection;
                searchRequest.AccBalanceSheetID = Convert.ToInt16(Session["BalancesheetID"]);
            }
            IBaseEntityCollectionResponse<FeeCriteriaMasterAndDetails> baseEntityCollectionResponse = _feeCriteriaMasterAndDetailsServiceAccess.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listFeeCriteriaMasterAndDetails = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listFeeCriteriaMasterAndDetails;
        }
        #endregion

        #region ------------CONTROLLER AJAX HANDLER METHODS------------
        /// <summary>
        /// AJAX Method for binding List Account category master
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public ActionResult AjaxHandler(JQueryDataTableParamModel param)
        {
            int TotalRecords;
            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc
            IEnumerable<FeeCriteriaMasterAndDetails> filteredFeeCriteriaMasterAndDetails;
            switch (Convert.ToInt32(sortColumnIndex))
            {
                case 0:
                    _sortBy = "A.FeeCriteriaDescription";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "(A.FeeCriteriaDescription Like '%" + param.sSearch + "%' or B.FeeCriteriaParametersDescription Like '%" + param.sSearch + "%' or A.CentreName Like '%" + param.sSearch + "%')";         //this "if" block is added for search functionality
                    }
                    break;
                case 1:
                    _sortBy = "A.CentreName";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "(A.FeeCriteriaDescription Like '%" + param.sSearch + "%' or B.FeeCriteriaParametersDescription Like '%" + param.sSearch + "%' or A.CentreName Like '%" + param.sSearch + "%')";         //this "if" block is added for search functionality
                    }
                    break;
            }
            _sortDirection = sortDirection;
            _rowLength = param.iDisplayLength;
            _startRow = param.iDisplayStart;
            if (Convert.ToInt16(Session["BalancesheetID"]) > 0 )
            {
                filteredFeeCriteriaMasterAndDetails = GetListFeeCriteriaMasterAndDetails( out TotalRecords);    
            }
            else
            {
                filteredFeeCriteriaMasterAndDetails = new List<FeeCriteriaMasterAndDetails>();
                TotalRecords = 0;
            }
            var records = filteredFeeCriteriaMasterAndDetails.Skip(0).Take(param.iDisplayLength);
            var result = from c in records select new[] { Convert.ToString(c.FeeCriteriaDescription), Convert.ToString(c.FeeCriteriaParametersDescription), Convert.ToString(c.CentreName), Convert.ToString(c.AccBalanceSheetName), Convert.ToString(c.ID), Convert.ToString(c.FeeCriteriaDetailsID) };
            return Json(new { sEcho = param.sEcho, iTotalRecords = TotalRecords, iTotalDisplayRecords = TotalRecords, aaData = result }, JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}
