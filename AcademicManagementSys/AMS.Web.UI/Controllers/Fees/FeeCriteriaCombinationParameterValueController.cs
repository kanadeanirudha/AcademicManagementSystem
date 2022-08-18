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
    public class FeeCriteriaCombinationParameterValueController : BaseController
    {
        IFeeCriteriaCombinationParameterValueServiceAccess _feeCriteriaCombinationParameterValueServiceAcess = null;
        IFeeCriteriaMasterAndDetailsServiceAccess _feeCriteriaMasterAndDetailsServiceAccess = null;
        private readonly ILogger _logException;
        ActionModeEnum actionModeEnum;
        string _actionMode = string.Empty;
        string _sortBy = string.Empty;
        string _searchBy = string.Empty;
        string _sortDirection = string.Empty;
        int _startRow;
        int _rowLength;
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

        public FeeCriteriaCombinationParameterValueController()
        {
            _feeCriteriaCombinationParameterValueServiceAcess = new FeeCriteriaCombinationParameterValueServiceAccess();
            _feeCriteriaMasterAndDetailsServiceAccess = new FeeCriteriaMasterAndDetailsServiceAccess();
        }

        // Controller Methods
        #region Controller Methods
        public ActionResult Index()
        {

            return View("/Views/Fees/FeeCriteriaCombinationParameterValue/Index.cshtml");

        }

        public ActionResult List(string actionMode, string feeCriteriaMasterID)
        {
            try
            {
                FeeCriteriaCombinationParameterValueViewModel model = new FeeCriteriaCombinationParameterValueViewModel();
                if (!string.IsNullOrEmpty(actionMode))
                {
                    TempData["ActionMode"] = actionMode;

                }
                model.SelectedFeeCriteriaMasterID = feeCriteriaMasterID;
                model.ListGetFeeCriteria = GetFeeCriteriaMasterAndDetails(Convert.ToInt16(Session["BalancesheetID"]));
                return PartialView("/Views/Fees/FeeCriteriaCombinationParameterValue/List.cshtml", model);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }

        }




        
        public ActionResult CreateFeeCriteriaParameterValue(string feeCriteriaParameterValueIDs, int feeCriteriaMasterID, string feeCriteriaValueCombinationDescription)
        {
            try
            {
                  FeeCriteriaCombinationParameterValueViewModel model = new FeeCriteriaCombinationParameterValueViewModel();                
                    model.FeeCriteriaCombinationParameterValueDTO.ConnectionString = _connectioString;
                    model.FeeCriteriaCombinationParameterValueDTO.FeeCriteriaValueCombinationDescription = feeCriteriaValueCombinationDescription;
                    model.FeeCriteriaCombinationParameterValueDTO.FeeCriteriaMasterID = feeCriteriaMasterID;

                    string[] Array = feeCriteriaParameterValueIDs.Split('/');
                    string feeCriteriaParameterValueCombinationIDsXml = "<rows>";

                    for (int i = 0; i < Array.Length; i++)
                    {
                        feeCriteriaParameterValueCombinationIDsXml = feeCriteriaParameterValueCombinationIDsXml + "<row><FeeCriteriaParameterValuesID>" + Array[i] + "</FeeCriteriaParameterValuesID></row>";
                    }

                    model.FeeCriteriaCombinationParameterValueDTO.FeeCriteriaParameterValueCombinationIDsXml = feeCriteriaParameterValueCombinationIDsXml + "</rows>";
                    model.FeeCriteriaCombinationParameterValueDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                    IBaseEntityResponse<FeeCriteriaCombinationParameterValue> response = _feeCriteriaCombinationParameterValueServiceAcess.InsertFeeCriteriaCombinationParameterValue(model.FeeCriteriaCombinationParameterValueDTO);
                    model.errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);                   
                    model.errorMessage = string.Concat(model.errorMessage, ",", feeCriteriaMasterID);
                    return Json(model.errorMessage, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }

        }


        //public ActionResult DeleteFeeCriteriaParameterValue(string feeCriteriaValueCombinationMasterDetails, int feeCriteriaMasterID11)
        //{

        //    string[] Array = feeCriteriaValueCombinationMasterDetails.Split('~');
        //    FeeCriteriaCombinationParameterValueViewModel model = new FeeCriteriaCombinationParameterValueViewModel();
        //    model.FeeCriteriaValueCombinationMasterID = Convert.ToInt32(Array[0]);
        //    model.FeeCriteriaValueCombinationDescription = Array[1].Replace('`', '&');
        //    model.FeeCriteriaMasterID = feeCriteriaMasterID11;
        //    return PartialView("~/Views/Fees/FeeCriteriaCombinationParameterValue/DeleteFeeCriteriaCombinationParameterValue.cshtml", model);
        //}


        public ActionResult DeleteFeeCriteriaParameterValue(string feeCriteriaValueCombinationMasterID, int feeCriteriaMasterID)
        {
            try
            {
                FeeCriteriaCombinationParameterValueViewModel model = new FeeCriteriaCombinationParameterValueViewModel();
                FeeCriteriaCombinationParameterValue feeCriteriaCombinationParameterValueDTO = new FeeCriteriaCombinationParameterValue();
                feeCriteriaCombinationParameterValueDTO.ConnectionString = _connectioString;
                feeCriteriaCombinationParameterValueDTO.FeeCriteriaValueCombinationMasterID = Convert.ToInt32(feeCriteriaValueCombinationMasterID);
                feeCriteriaCombinationParameterValueDTO.DeletedBy = Convert.ToInt32(Session["UserID"]);
                IBaseEntityResponse<FeeCriteriaCombinationParameterValue> response = _feeCriteriaCombinationParameterValueServiceAcess.DeleteFeeCriteriaCombinationParameterValue(feeCriteriaCombinationParameterValueDTO);
                model.errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Delete);
                model.errorMessage = string.Concat(model.errorMessage,",", feeCriteriaMasterID);
                return Json(model.errorMessage, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }


        #endregion

        // Non-Action Method
        #region Methods

        protected List<FeeCriteriaMasterAndDetails> GetFeeCriteriaMasterAndDetails(Int16 accBalanceSheetID)
        {

            FeeCriteriaMasterAndDetailsSearchRequest searchRequest = new FeeCriteriaMasterAndDetailsSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            List<FeeCriteriaMasterAndDetails> listFeeCriteriaMasterAndDetails = new List<FeeCriteriaMasterAndDetails>();
            searchRequest.AccBalanceSheetID = accBalanceSheetID;
            IBaseEntityCollectionResponse<FeeCriteriaMasterAndDetails> baseEntityCollectionResponse = _feeCriteriaMasterAndDetailsServiceAccess.GetCriteriaMasterList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listFeeCriteriaMasterAndDetails = baseEntityCollectionResponse.CollectionResponse.ToList();

                }
            }
            return listFeeCriteriaMasterAndDetails;
        }
        public IEnumerable<FeeCriteriaCombinationParameterValueViewModel> GetFeeCriteriaCombinationParameterValue(int feeCriteriaMasterId, out int TotalRecords)
        {
            FeeCriteriaCombinationParameterValueSearchRequest searchRequest = new FeeCriteriaCombinationParameterValueSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            _actionMode = Convert.ToString(TempData["ActionMode"]);
            searchRequest.FeeCriteriaMasterID = feeCriteriaMasterId;
            if (Enum.TryParse(_actionMode, out actionModeEnum))     // checks actionMode i.e. Insert or Update // 
            {
                if (actionModeEnum == ActionModeEnum.Insert)        // parameters for SelectAll procedures under Insert or Update mode condition
                {

                    searchRequest.SortBy = "B.CreatedDate";
                    searchRequest.StartRow = 0;
                    searchRequest.EndRow = 10;
                    searchRequest.SearchBy = string.Empty;
                    searchRequest.SortDirection = "desc";
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
            List<FeeCriteriaCombinationParameterValueViewModel> listFeeCriteriaCombinationParameterValueViewModel = new List<FeeCriteriaCombinationParameterValueViewModel>();
            List<FeeCriteriaCombinationParameterValue> listFeeCriteriaCombinationParameterValue = new List<FeeCriteriaCombinationParameterValue>();
            IBaseEntityCollectionResponse<FeeCriteriaCombinationParameterValue> baseEntityCollectionResponse = _feeCriteriaCombinationParameterValueServiceAcess.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listFeeCriteriaCombinationParameterValue = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (FeeCriteriaCombinationParameterValue item in listFeeCriteriaCombinationParameterValue)
                    {
                        FeeCriteriaCombinationParameterValueViewModel feeCriteriaCombinationParameterValueViewModel = new FeeCriteriaCombinationParameterValueViewModel();
                        feeCriteriaCombinationParameterValueViewModel.FeeCriteriaCombinationParameterValueDTO = item;
                        listFeeCriteriaCombinationParameterValueViewModel.Add(feeCriteriaCombinationParameterValueViewModel);
                    }
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listFeeCriteriaCombinationParameterValueViewModel;
        }
        #endregion

        // AjaxHandler Method
        #region AjaxHandler
        public ActionResult AjaxHandler(JQueryDataTableParamModel param, string SelectedFeeCriteriaMasterID)
        {

            int TotalRecords;
            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc

            IEnumerable<FeeCriteriaCombinationParameterValueViewModel> filteredFeeCriteriaCombinationParameterValue;
            switch (Convert.ToInt32(sortColumnIndex))
            {
                case 0:
                    _sortBy = "FeeCriteriaParameterValueCombinations";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "FeeCriteriaParameterValueCombinations Like '%" + param.sSearch + "%' ";
                    }
                    break;

            }
            _sortDirection = sortDirection;
            _rowLength = param.iDisplayLength;
            _startRow = param.iDisplayStart;
            if (Convert.ToInt32(Session["BalancesheetID"]) > 0 && !string.IsNullOrEmpty(SelectedFeeCriteriaMasterID))
            {
                filteredFeeCriteriaCombinationParameterValue = GetFeeCriteriaCombinationParameterValue(Convert.ToInt32(SelectedFeeCriteriaMasterID), out TotalRecords);
            }
            else
            {
                filteredFeeCriteriaCombinationParameterValue = new List<FeeCriteriaCombinationParameterValueViewModel>();
                TotalRecords = 0;
            }

            var records = filteredFeeCriteriaCombinationParameterValue.Skip(0).Take(param.iDisplayLength);
            var result = from c in records select new[] { c.FeeCriteriaValueCombinationDescription.ToString(), c.ValueCombinationStatus.ToString(), Convert.ToString(c.FeeCriteriaValueCombinationMasterID), Convert.ToString(c.FeeCriteriaParameterValueCombinationIDs) };

            return Json(new { sEcho = param.sEcho, iTotalRecords = TotalRecords, iTotalDisplayRecords = TotalRecords, aaData = result }, JsonRequestBehavior.AllowGet);


        }
        #endregion
    }
}