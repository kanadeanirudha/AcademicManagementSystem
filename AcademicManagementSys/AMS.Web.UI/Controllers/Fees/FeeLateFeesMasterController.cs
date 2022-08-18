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
    public class FeeLateFeesMasterController : BaseController
    {
        #region ------------CONTROLLER CLASS VARIABLE------------

        IFeeLateFeesMasterServiceAccess _FeeLateFeesMasterServiceAccess = null;
        IFeeTypeAndSubTypeServiceAccess _feeTypeAndSubTypeServiceAccess = null;
        IAccountBalancesheetMasterServiceAccess _accountBalancesheetMasterServiceAccess = null;
        
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
        public FeeLateFeesMasterController()
        {
            _FeeLateFeesMasterServiceAccess = new FeeLateFeesMasterServiceAccess();
            _feeTypeAndSubTypeServiceAccess = new FeeTypeAndSubTypeServiceAccess();
            _accountBalancesheetMasterServiceAccess = new AccountBalancesheetMasterServiceAccess();
        }
        #endregion

        #region ------------CONTROLLER ACTION METHODS------------
        public ActionResult Index()
        {
                return View("/Views/Fees/FeeLateFeesMaster/Index.cshtml");
        }

        public ActionResult List(string actionMode)
        {
            try
            {
                FeeLateFeesMasterViewModel model = new FeeLateFeesMasterViewModel();
                if (!string.IsNullOrEmpty(actionMode))
                {
                    TempData["ActionMode"] = actionMode;
                }
                return PartialView("/Views/Fees/FeeLateFeesMaster/List.cshtml",model);
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
            try
            {
                FeeLateFeesMasterViewModel model = new FeeLateFeesMasterViewModel();
                List<SelectListItem> li1 = new List<SelectListItem>();
                li1.Add(new SelectListItem { Text = "Penalty", Value = "1" });
                ViewData["LateFeeTypeList"] = li1;

                List<SelectListItem> li2 = new List<SelectListItem>();
                li2.Add(new SelectListItem { Text = "Fixed", Value = "1" });
                li2.Add(new SelectListItem { Text = "Slab", Value = "2" });
                ViewData["SlabFixedFlagList"] = li2;

                model.FeeSubTypeList = GetFeeSubTypeList();

                model.PeriodList = GetPeriodTypeList();

                return PartialView("/Views/Fees/FeeLateFeesMaster/Create.cshtml", model); 
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }
        [HttpPost]
        public ActionResult Create(FeeLateFeesMasterViewModel model)
        {
            try
            {
                model.FeeLateFeesMasterDTO.ConnectionString = _connectioString;
                model.FeeLateFeesMasterDTO.LateFeeDescription = model.LateFeeDescription;
                model.FeeLateFeesMasterDTO.LateFeeType = model.LateFeeType;
                model.FeeLateFeesMasterDTO.FeeSubTypeID = model.FeeSubTypeID;
                model.FeeLateFeesMasterDTO.SlabFixedFlag = model.SlabFixedFlag;
                model.FeeLateFeesMasterDTO.LateFeeAmount = model.LateFeeAmount;
                model.FeeLateFeesMasterDTO.PeriodTypeID = model.PeriodTypeID;
                model.FeeLateFeesMasterDTO.IsIncremental = model.IsIncremental;
                model.FeeLateFeesMasterDTO.SelectedXml = model.SelectedXml;
                model.FeeLateFeesMasterDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                IBaseEntityResponse<FeeLateFeesMaster> response = _FeeLateFeesMasterServiceAccess.InsertFeeLateFeesMaster(model.FeeLateFeesMasterDTO);
                model.FeeLateFeesMasterDTO.errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                return Json(model.FeeLateFeesMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }
      
        public ActionResult Delete(int ID)
        {
            try
            {
                FeeLateFeesMaster FeeLateFeesMasterDTO = new FeeLateFeesMaster();
                FeeLateFeesMasterDTO.ConnectionString = _connectioString;
                FeeLateFeesMasterDTO.ID = ID;                  
                FeeLateFeesMasterDTO.DeletedBy = Convert.ToInt32(Session["UserID"]);
                IBaseEntityResponse<FeeLateFeesMaster> response = _FeeLateFeesMasterServiceAccess.DeleteFeeLateFeesMaster(FeeLateFeesMasterDTO);
                FeeLateFeesMasterDTO.errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Delete);
                return Json(FeeLateFeesMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }
        #endregion

        #region ------------CONTROLLER NON ACTION METHODS------------

        protected List<FeeTypeAndSubType> GetFeeSubTypeList()
        {
            FeeTypeAndSubTypeSearchRequest searchRequest = new FeeTypeAndSubTypeSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            List<FeeTypeAndSubType> listFeeSubType = new List<FeeTypeAndSubType>();
            IBaseEntityCollectionResponse<FeeTypeAndSubType> baseEntityCollectionResponse = _feeTypeAndSubTypeServiceAccess.GetFeeSubTypeList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listFeeSubType = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listFeeSubType;
        }

        protected List<FeeLateFeesMaster> GetPeriodTypeList()
        {
            FeeLateFeesMasterSearchRequest searchRequest = new FeeLateFeesMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            List<FeeLateFeesMaster> listPeriodType = new List<FeeLateFeesMaster>();
            IBaseEntityCollectionResponse<FeeLateFeesMaster> baseEntityCollectionResponse = _FeeLateFeesMasterServiceAccess.GetPeriodSearchList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listPeriodType = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listPeriodType;
        }

        // Non-Action method to fetch all records from table.
        [NonAction]
        public List<FeeLateFeesMaster> GetListFeeLateFeesMaster( out int TotalRecords)
        {
            List<FeeLateFeesMaster> listFeeLateFeesMaster = new List<FeeLateFeesMaster>();
            FeeLateFeesMasterSearchRequest searchRequest = new FeeLateFeesMasterSearchRequest();
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
            IBaseEntityCollectionResponse<FeeLateFeesMaster> baseEntityCollectionResponse = _FeeLateFeesMasterServiceAccess.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listFeeLateFeesMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listFeeLateFeesMaster;
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

            IEnumerable<FeeLateFeesMaster> filteredFeeLateFeesMaster;
            switch (Convert.ToInt32(sortColumnIndex))
            {
                case 0:
                    _sortBy = "A.LateFeeDescription";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "(A.LateFeeDescription Like '%" + param.sSearch + "%' or A.SlabFixedFlag Like '%" + param.sSearch + "%'  or A.LateFeeAmount Like '%" + param.sSearch + "%'  or B.PeriodType Like '%" + param.sSearch + "%')";         //this "if" block is added for search functionality
                    }
                    break;
                case 1:
                    _sortBy = "A.SlabFixedFlag";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "(A.LateFeeDescription Like '%" + param.sSearch + "%' or A.SlabFixedFlag Like '%" + param.sSearch + "%'  or A.LateFeeAmount Like '%" + param.sSearch + "%'  or B.PeriodType Like '%" + param.sSearch + "%')";         //this "if" block is added for search functionality
                    }
                    break;
                case 2:
                    _sortBy = "A.LateFeeAmount";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "(A.LateFeeDescription Like '%" + param.sSearch + "%' or A.SlabFixedFlag Like '%" + param.sSearch + "%'  or A.LateFeeAmount Like '%" + param.sSearch + "%'  or B.PeriodType Like '%" + param.sSearch + "%')";         //this "if" block is added for search functionality
                    }
                    break;
                case 3:
                    _sortBy = "B.PeriodType";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "(A.LateFeeDescription Like '%" + param.sSearch + "%' or A.SlabFixedFlag Like '%" + param.sSearch + "%'  or A.LateFeeAmount Like '%" + param.sSearch + "%'  or B.PeriodType Like '%" + param.sSearch + "%')";         //this "if" block is added for search functionality
                    }
                    break;
            }
            _sortDirection = sortDirection;
            _rowLength = param.iDisplayLength;
            _startRow = param.iDisplayStart;            
            filteredFeeLateFeesMaster = GetListFeeLateFeesMaster( out TotalRecords);             
            var records = filteredFeeLateFeesMaster.Skip(0).Take(param.iDisplayLength);
            var result = from c in records select new[] { Convert.ToString(c.LateFeeDescription), Convert.ToString(c.SlabFixedFlag), Convert.ToString( c.LateFeeAmount), Convert.ToString(c.PeriodType), Convert.ToString(c.ID) };
            return Json(new { sEcho = param.sEcho, iTotalRecords = TotalRecords, iTotalDisplayRecords = TotalRecords, aaData = result }, JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}
