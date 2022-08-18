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
    public class FeeTypeAndSubTypeController : BaseController
    {
        #region ------------CONTROLLER CLASS VARIABLE------------

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
        public FeeTypeAndSubTypeController()
        {
            _feeTypeAndSubTypeServiceAccess = new FeeTypeAndSubTypeServiceAccess();
            _accountBalancesheetMasterServiceAccess = new AccountBalancesheetMasterServiceAccess();
        }
        #endregion

        #region ------------CONTROLLER ACTION METHODS------------
        public ActionResult Index()
        {
            if (Convert.ToString(Session["UserType"]) == "A" || Convert.ToInt32(!string.IsNullOrEmpty(Convert.ToString(Session["BalancesheetID"])) ? Session["BalancesheetID"] : 0) > 0)
            {
                return View("/Views/Fees/FeeTypeAndSubType/Index.cshtml");
            }
            else
            {
                return RedirectToAction("UnauthorizedAccess", "Home");
            }
        }

        public ActionResult List(string selectedBalsheet, string actionMode)
        {
            try
            {
                if (!string.IsNullOrEmpty(selectedBalsheet) || Convert.ToString(Session["UserType"]) == "A")
                {
                    FeeTypeAndSubTypeViewModel model = new FeeTypeAndSubTypeViewModel();
                    if (!string.IsNullOrEmpty(actionMode))
                    {
                        TempData["ActionMode"] = actionMode;
                    }
                    return PartialView("/Views/Fees/FeeTypeAndSubType/List.cshtml",model);
                }
                else
                {
                    return RedirectToActionPermanent("UnauthorizedAccess", "Home");
                }
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        [HttpGet]
        public ActionResult CreateFeeType()
        {
            try
            {
                FeeTypeAndSubTypeViewModel model = new FeeTypeAndSubTypeViewModel();
                List<SelectListItem> li1 = new List<SelectListItem>();
                li1.Add(new SelectListItem { Text = "Structural", Value = "STRUCT" });
                li1.Add(new SelectListItem { Text = "Non-Structural", Value = "NONSTRUCT" });
                ViewData["FeeTypeCode"] = li1;
                return PartialView("/Views/Fees/FeeTypeAndSubType/CreateFeeType.cshtml", model); 
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }
        [HttpPost]
        public ActionResult CreateFeeType(FeeTypeAndSubTypeViewModel model)
        {
            try
            {
                model.FeeTypeAndSubTypeDTO.ConnectionString = _connectioString;
                model.FeeTypeAndSubTypeDTO.FeeTypeDesc = model.FeeTypeDesc;
                model.FeeTypeAndSubTypeDTO.FeeTypeCode = model.FeeTypeCode;
                model.FeeTypeAndSubTypeDTO.IsFeeTypeTransaction = true;
                model.FeeTypeAndSubTypeDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                IBaseEntityResponse<FeeTypeAndSubType> response = _feeTypeAndSubTypeServiceAccess.InsertFeeTypeAndSubType(model.FeeTypeAndSubTypeDTO);
                model.FeeTypeAndSubTypeDTO.errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                return Json(model.FeeTypeAndSubTypeDTO.errorMessage, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }
        //[HttpGet]
        //public ActionResult DeleteFeeType(short ID)
        //{
        //    try
        //    {
        //        FeeTypeAndSubTypeViewModel model = new FeeTypeAndSubTypeViewModel();
        //        model.FeeTypeAndSubTypeDTO = new FeeTypeAndSubType();
        //        model.FeeTypeAndSubTypeDTO.ID = ID;
        //        return PartialView("/Views/Fees/FeeTypeAndSubType/DeleteFeeType.cshtml", model);
        //    }
        //    catch (Exception ex)
        //    {
        //        _logException.Error(ex.Message);
        //        throw;
        //    }
        //}
        //[HttpPost]
        public ActionResult DeleteFeeType(short ID)
        {
            try
            {
                    FeeTypeAndSubTypeViewModel model = new FeeTypeAndSubTypeViewModel();
                    FeeTypeAndSubType FeeTypeAndSubTypeDTO = new FeeTypeAndSubType();
                    FeeTypeAndSubTypeDTO.ConnectionString = _connectioString;
                    FeeTypeAndSubTypeDTO.ID = ID;
                    FeeTypeAndSubTypeDTO.IsFeeTypeTransaction= true;
                    FeeTypeAndSubTypeDTO.DeletedBy = Convert.ToInt32(Session["UserID"]);
                    IBaseEntityResponse<FeeTypeAndSubType> response = _feeTypeAndSubTypeServiceAccess.DeleteFeeTypeAndSubType(FeeTypeAndSubTypeDTO);
                    model.FeeTypeAndSubTypeDTO.errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Delete);
                    return Json(model.FeeTypeAndSubTypeDTO.errorMessage, JsonRequestBehavior.AllowGet);
               
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        [HttpGet]
        public ActionResult CreateFeeSubType(string FeeTypeDetails)
        {
            try
            {
                FeeTypeAndSubTypeViewModel model = new FeeTypeAndSubTypeViewModel();
                var splitData = FeeTypeDetails.Split(':');
                model.ID =Convert.ToInt16(splitData[0]);
                model.FeeTypeDesc = splitData[1].Replace('~',' ');
                model.SelectedBalanceSheetID = Convert.ToInt16(Session["BalancesheetID"]);
                model.SelectedBalanceSheet = Convert.ToString(Session["BalancesheetName"]);
                model.AccountMasterList = GetAccountList("L",string.Empty);
                model.FeeSubTypeList = GetFeeSubTypeList();
                
                List<SelectListItem> li1 = new List<SelectListItem>();
                li1.Add(new SelectListItem { Text = Resources.MainMenu_Student, Value = "1" });
                li1.Add(new SelectListItem { Text = Resources.DisplayName_Government, Value = "2" });
                ViewData["FeeSource"] = li1;

                List<SelectListItem> li2 = new List<SelectListItem>();
                li2.Add(new SelectListItem { Text = Resources.DisplayName_Other, Value = "1" });
                li2.Add(new SelectListItem { Text = Resources.DisplayName_Advanced, Value = "2" });
                li2.Add(new SelectListItem { Text = Resources.DisplayName_Outstanding, Value = "3" });
                ViewData["SubTypeIdentification"] = li2;

                return PartialView("/Views/Fees/FeeTypeAndSubType/CreateFeeSubType.cshtml", model);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }
        [HttpPost]
        public ActionResult CreateFeeSubType(FeeTypeAndSubTypeViewModel model)
        {
            try
            {
                model.FeeTypeAndSubTypeDTO.ConnectionString = _connectioString;
                model.FeeTypeAndSubTypeDTO.ID = model.ID;
                model.FeeTypeAndSubTypeDTO.FeeSubTypeDesc = model.FeeSubTypeDesc;
                model.FeeTypeAndSubTypeDTO.FeeSubShortDesc= model.FeeSubShortDesc;
                model.FeeTypeAndSubTypeDTO.AccountID = model.AccountID;
                model.FeeTypeAndSubTypeDTO.SubTypeIdentification = model.SubTypeIdentification;
                model.FeeTypeAndSubTypeDTO.CarryForwardFeeSubtypeID = model.CarryForwardFeeSubtypeID;
                model.FeeTypeAndSubTypeDTO.FeeSource = model.FeeSource;
                model.FeeTypeAndSubTypeDTO.IsFeeTypeTransaction = false;
                model.FeeTypeAndSubTypeDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                IBaseEntityResponse<FeeTypeAndSubType> response = _feeTypeAndSubTypeServiceAccess.InsertFeeTypeAndSubType(model.FeeTypeAndSubTypeDTO);
                model.FeeTypeAndSubTypeDTO.errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                return Json(model.FeeTypeAndSubTypeDTO.errorMessage, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }
        //[HttpGet]
        //public ActionResult DeleteFeeSubType(short FeeSubTypeID)
        //{
        //    try
        //    {
        //        FeeTypeAndSubTypeViewModel model = new FeeTypeAndSubTypeViewModel();
        //        model.FeeTypeAndSubTypeDTO = new FeeTypeAndSubType();
        //        model.FeeTypeAndSubTypeDTO.FeeSubTypeID = FeeSubTypeID;
        //        return PartialView("/Views/Fees/FeeTypeAndSubType/DeleteFeeSubType.cshtml", model);
        //    }
        //    catch (Exception ex)
        //    {
        //        _logException.Error(ex.Message);
        //        throw;
        //    }
        //}
        //[HttpPost]
        public ActionResult DeleteFeeSubType(short FeeSubTypeID)
        {
            try
            {
                FeeTypeAndSubTypeViewModel model = new FeeTypeAndSubTypeViewModel();
                FeeTypeAndSubType FeeTypeAndSubTypeDTO = new FeeTypeAndSubType();
                FeeTypeAndSubTypeDTO.ConnectionString = _connectioString;
                FeeTypeAndSubTypeDTO.FeeSubTypeID = FeeSubTypeID;
                FeeTypeAndSubTypeDTO.IsFeeTypeTransaction = false;
                FeeTypeAndSubTypeDTO.DeletedBy = Convert.ToInt32(Session["UserID"]);
                IBaseEntityResponse<FeeTypeAndSubType> response = _feeTypeAndSubTypeServiceAccess.DeleteFeeTypeAndSubType(FeeTypeAndSubTypeDTO);
                model.FeeTypeAndSubTypeDTO.errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Delete);
                return Json(model.FeeTypeAndSubTypeDTO.errorMessage, JsonRequestBehavior.AllowGet);
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

        // Non-Action method to fetch all records from table.
        [NonAction]
        public List<FeeTypeAndSubType> GetListFeeTypeAndSubType( out int TotalRecords)
        {
            List<FeeTypeAndSubType> listFeeTypeAndSubType = new List<FeeTypeAndSubType>();
            FeeTypeAndSubTypeSearchRequest searchRequest = new FeeTypeAndSubTypeSearchRequest();
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
            IBaseEntityCollectionResponse<FeeTypeAndSubType> baseEntityCollectionResponse = _feeTypeAndSubTypeServiceAccess.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listFeeTypeAndSubType = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listFeeTypeAndSubType;
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

            IEnumerable<FeeTypeAndSubType> filteredFeeTypeAndSubType;
            switch (Convert.ToInt32(sortColumnIndex))
            {
                case 0:
                    _sortBy = "A.FeeTypeDesc";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "(A.FeeTypeDesc Like '%" + param.sSearch + "%' or B.FeeSubTypeDesc Like '%" + param.sSearch + "%'  or B.FeeSubShortDesc Like '%" + param.sSearch + "%'  or B.AccountName Like '%" + param.sSearch + "%' or B.SubTypeIdentification Like '%" + param.sSearch + "%' or B.FeeSource Like '%" + param.sSearch + "%')";         //this "if" block is added for search functionality
                    }
                    break;
                case 1:
                    _sortBy = "B.FeeSubShortDesc";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "(A.FeeTypeDesc Like '%" + param.sSearch + "%' or B.FeeSubTypeDesc Like '%" + param.sSearch + "%'  or B.FeeSubShortDesc Like '%" + param.sSearch + "%'  or B.AccountName Like '%" + param.sSearch + "%' or B.SubTypeIdentification Like '%" + param.sSearch + "%' or B.FeeSource Like '%" + param.sSearch + "%')";         //this "if" block is added for search functionality
                    }
                    break;
                case 2:
                    _sortBy = "B.AccountName";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "(A.FeeTypeDesc Like '%" + param.sSearch + "%' or B.FeeSubTypeDesc Like '%" + param.sSearch + "%'  or B.FeeSubShortDesc Like '%" + param.sSearch + "%'  or B.AccountName Like '%" + param.sSearch + "%' or B.SubTypeIdentification Like '%" + param.sSearch + "%' or B.FeeSource Like '%" + param.sSearch + "%')";         //this "if" block is added for search functionality
                    }
                    break;
                case 3:
                    _sortBy = "B.SubTypeIdentification";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "(A.FeeTypeDesc Like '%" + param.sSearch + "%' or B.FeeSubTypeDesc Like '%" + param.sSearch + "%'  or B.FeeSubShortDesc Like '%" + param.sSearch + "%'  or B.AccountName Like '%" + param.sSearch + "%' or B.SubTypeIdentification Like '%" + param.sSearch + "%' or B.FeeSource Like '%" + param.sSearch + "%')";         //this "if" block is added for search functionality
                    }
                    break;
                case 4:
                    _sortBy = "B.FeeSource";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "(A.FeeTypeDesc Like '%" + param.sSearch + "%' or B.FeeSubTypeDesc Like '%" + param.sSearch + "%'  or B.FeeSubShortDesc Like '%" + param.sSearch + "%'  or B.AccountName Like '%" + param.sSearch + "%' or B.SubTypeIdentification Like '%" + param.sSearch + "%' or B.FeeSource Like '%" + param.sSearch + "%')";         //this "if" block is added for search functionality
                    }
                    break;  
            }
            _sortDirection = sortDirection;
            _rowLength = param.iDisplayLength;
            _startRow = param.iDisplayStart;
            if (Convert.ToInt16(Session["BalancesheetID"]) > 0 || Convert.ToString(Session["UserType"]) == "A")
            {
                filteredFeeTypeAndSubType = GetListFeeTypeAndSubType( out TotalRecords);    
            }
            else
            {
                filteredFeeTypeAndSubType = new List<FeeTypeAndSubType>();
                TotalRecords = 0;
            }
            var records = filteredFeeTypeAndSubType.Skip(0).Take(param.iDisplayLength);
            var result = from c in records select new[] { Convert.ToString(c.FeeTypeDesc), Convert.ToString(c.FeeSubTypeDesc), Convert.ToString(c.FeeSubShortDesc), Convert.ToString(c.AccountName), Convert.ToString(c.SubTypeIdentification), Convert.ToString(c.FeeSource), Convert.ToString(c.ID), Convert.ToString(c.FeeSubTypeID) };
            return Json(new { sEcho = param.sEcho, iTotalRecords = TotalRecords, iTotalDisplayRecords = TotalRecords, aaData = result }, JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}
