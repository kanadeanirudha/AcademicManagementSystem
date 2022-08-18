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
    public class CRMSaleAccountProgressTypeRuleController : BaseController
    {
        ICRMSaleAccountProgressTypeMasterAndRuleServiceAccess _CRMSaleAccountProgressTypeMasterAndRuleServiceAcess = null;
        private readonly ILogger _logException;
        ActionModeEnum actionModeEnum;
        string _actionMode = string.Empty;
        string _sortBy = string.Empty;
        string _searchBy = string.Empty;
        string _sortDirection = string.Empty;
        int _startRow;
        int _rowLength;
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

        public CRMSaleAccountProgressTypeRuleController()
        {
            _CRMSaleAccountProgressTypeMasterAndRuleServiceAcess = new CRMSaleAccountProgressTypeMasterAndRuleServiceAccess();
        }

        // Controller Methods
        #region Controller Methods
        public ActionResult Index()
        {

            return View("/Views/CRMSales/CRMSaleAccountProgressTypeRule/Index.cshtml");
        }

        public ActionResult List(string CRMSaleGroupMasterID, string actionMode)
        {
            try
            {
                CRMSaleAccountProgressTypeMasterAndRuleViewModel model = new CRMSaleAccountProgressTypeMasterAndRuleViewModel();

                if (!string.IsNullOrEmpty(actionMode))
                {
                    TempData["ActionMode"] = actionMode;
                }
                return PartialView("/Views/CRMSales/CRMSaleAccountProgressTypeRule/List.cshtml", model);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }

        }



        public ActionResult Create(string IDs)
        {
            CRMSaleAccountProgressTypeMasterAndRuleViewModel model = new CRMSaleAccountProgressTypeMasterAndRuleViewModel();
            string[] IDsArray = IDs.Split('~');
            model.ProgressType = IDsArray[1].Replace('$', ' ');
            model.CRMSaleAccountProgressTypeID = Convert.ToInt16(IDsArray[0]);
            List<SelectListItem> Operator = new List<SelectListItem>();
            ViewBag.Operator = new SelectList(Operator, "Value", "Text");
            List<SelectListItem> Operator_li = new List<SelectListItem>();
            Operator_li.Add(new SelectListItem { Text = ">", Value = ">" });
            Operator_li.Add(new SelectListItem { Text = ">=", Value = ">=" });
            Operator_li.Add(new SelectListItem { Text = "<", Value = "<" });
            Operator_li.Add(new SelectListItem { Text = "<=", Value = "<=" });
            Operator_li.Add(new SelectListItem { Text = "=", Value = "=" });
            ViewData["Operator"] = Operator_li;
            return PartialView("/Views/CRMSales/CRMSaleAccountProgressTypeRule/Create.cshtml", model);
        }

        [HttpPost]
        public ActionResult Create(CRMSaleAccountProgressTypeMasterAndRuleViewModel model)
        {
            try
            {
                if (model != null && model.CRMSaleAccountProgressTypeMasterAndRuleDTO != null)
                {
                    model.CRMSaleAccountProgressTypeMasterAndRuleDTO.ConnectionString = _connectioString;
                    model.CRMSaleAccountProgressTypeMasterAndRuleDTO.CRMSaleAccountProgressTypeID = model.CRMSaleAccountProgressTypeID;
                    model.CRMSaleAccountProgressTypeMasterAndRuleDTO.Operator = model.Operator;
                    model.CRMSaleAccountProgressTypeMasterAndRuleDTO.Days = model.Days;
                    model.CRMSaleAccountProgressTypeMasterAndRuleDTO.FromDate = model.FromDate;
                    model.CRMSaleAccountProgressTypeMasterAndRuleDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                    IBaseEntityResponse<CRMSaleAccountProgressTypeMasterAndRule> response = _CRMSaleAccountProgressTypeMasterAndRuleServiceAcess.InsertCRMSaleAccountProgressTypeRule(model.CRMSaleAccountProgressTypeMasterAndRuleDTO);
                    model.CRMSaleAccountProgressTypeMasterAndRuleDTO.errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                    return Json(model.CRMSaleAccountProgressTypeMasterAndRuleDTO.errorMessage, JsonRequestBehavior.AllowGet);
                }
                return Json("Please review your form");
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }

        }

        public ActionResult InActive(int ID)
        {
            var errorMessage = string.Empty;
            if (ID > 0)
            {

                IBaseEntityResponse<CRMSaleAccountProgressTypeMasterAndRule> response = null;
                CRMSaleAccountProgressTypeMasterAndRule CRMSaleAccountProgressTypeMasterAndRuleDTO = new CRMSaleAccountProgressTypeMasterAndRule();
                CRMSaleAccountProgressTypeMasterAndRuleDTO.ConnectionString = _connectioString;
                CRMSaleAccountProgressTypeMasterAndRuleDTO.CRMSaleAccountProgressTypeRuleID = Convert.ToInt16(ID);
                CRMSaleAccountProgressTypeMasterAndRuleDTO.ModifiedBy = Convert.ToInt32(Session["UserID"]);
                response = _CRMSaleAccountProgressTypeMasterAndRuleServiceAcess.UpdateCRMSaleAccountProgressTypeRule(CRMSaleAccountProgressTypeMasterAndRuleDTO);
                errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.InActive);
            }

            return Json(errorMessage, JsonRequestBehavior.AllowGet);
        }
        #endregion

        // Non-Action Method
        #region Methods

        protected List<CRMSaleAccountProgressTypeMasterAndRule> GetListCRMSaleAccountProgressType()
        {
            CRMSaleAccountProgressTypeMasterAndRuleSearchRequest searchRequest = new CRMSaleAccountProgressTypeMasterAndRuleSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            List<CRMSaleAccountProgressTypeMasterAndRule> listCRMSaleTargetType = new List<CRMSaleAccountProgressTypeMasterAndRule>();
            IBaseEntityCollectionResponse<CRMSaleAccountProgressTypeMasterAndRule> baseEntityCollectionResponse = _CRMSaleAccountProgressTypeMasterAndRuleServiceAcess.GetCRMSaleAccountProgressTypeMasterSearchList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listCRMSaleTargetType = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listCRMSaleTargetType;
        }
        public IEnumerable<CRMSaleAccountProgressTypeMasterAndRuleViewModel> GetCRMSaleAccountProgressTypeRule(out int TotalRecords)
        {
            CRMSaleAccountProgressTypeMasterAndRuleSearchRequest searchRequest = new CRMSaleAccountProgressTypeMasterAndRuleSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            _actionMode = Convert.ToString(TempData["ActionMode"]);
            if (Enum.TryParse(_actionMode, out actionModeEnum))     // checks actionMode i.e. Insert or Update // 
            {
                if (actionModeEnum == ActionModeEnum.Insert)        // parameters for SelectAll procedures under Insert or Update mode condition
                {
                    searchRequest.SortBy = "B.CreatedDate";
                    searchRequest.StartRow = 0;
                    searchRequest.EndRow = 10;
                    searchRequest.SearchBy = String.Empty;
                    searchRequest.SortDirection = "Desc";
                }
                if (actionModeEnum == ActionModeEnum.Update)
                {
                    searchRequest.SortBy = "B.ModifiedDate";
                    searchRequest.StartRow = 0;
                    searchRequest.EndRow = 10;
                    searchRequest.SearchBy = String.Empty;
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
            List<CRMSaleAccountProgressTypeMasterAndRuleViewModel> listCRMSaleGroupMasterViewModel = new List<CRMSaleAccountProgressTypeMasterAndRuleViewModel>();
            List<CRMSaleAccountProgressTypeMasterAndRule> listCRMSaleGroupMaster = new List<CRMSaleAccountProgressTypeMasterAndRule>();
            IBaseEntityCollectionResponse<CRMSaleAccountProgressTypeMasterAndRule> baseEntityCollectionResponse = _CRMSaleAccountProgressTypeMasterAndRuleServiceAcess.GetBySearchCRMSaleAccountProgressTypeRule(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listCRMSaleGroupMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (CRMSaleAccountProgressTypeMasterAndRule item in listCRMSaleGroupMaster)
                    {
                        CRMSaleAccountProgressTypeMasterAndRuleViewModel CRMSaleGroupMasterViewModel = new CRMSaleAccountProgressTypeMasterAndRuleViewModel();
                        CRMSaleGroupMasterViewModel.CRMSaleAccountProgressTypeMasterAndRuleDTO = item;
                        listCRMSaleGroupMasterViewModel.Add(CRMSaleGroupMasterViewModel);
                    }
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listCRMSaleGroupMasterViewModel;
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

                IEnumerable<CRMSaleAccountProgressTypeMasterAndRuleViewModel> filteredCRMSaleAccountProgressTypeRule;
                switch (Convert.ToInt32(sortColumnIndex))
                {
                    case 0:
                        _sortBy = "A.ProgressType";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            _searchBy = "A.ProgressType Like '%" + param.sSearch + "%' or B.Days Like '%" + param.sSearch + "%' or B.Operator Like '%" + param.sSearch + "%' or B.FromDate Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                        }
                        break;
                    case 1:
                        _sortBy = "A.ProgressType";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            _searchBy = "A.ProgressType Like '%" + param.sSearch + "%' or B.Days Like '%" + param.sSearch + "%' or B.Operator Like '%" + param.sSearch + "%' or B.FromDate Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                        }
                        break;
                    case 2:
                        _sortBy = "B.FromDate";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            _searchBy = "A.ProgressType Like '%" + param.sSearch + "%' or B.Days Like '%" + param.sSearch + "%' or B.Operator Like '%" + param.sSearch + "%' or B.FromDate Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                        }
                        break;
                    case 3:
                        _sortBy = "B.Operator";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            _searchBy = "A.ProgressType Like '%" + param.sSearch + "%' or B.Days Like '%" + param.sSearch + "%' or B.Operator Like '%" + param.sSearch + "%' or B.FromDate Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                        }
                        break;


                }
                _sortDirection = sortDirection;
                _rowLength = param.iDisplayLength;
                _startRow = param.iDisplayStart;
                filteredCRMSaleAccountProgressTypeRule = GetCRMSaleAccountProgressTypeRule(out TotalRecords);

                if ((filteredCRMSaleAccountProgressTypeRule.Count()) == 0)
                {
                    filteredCRMSaleAccountProgressTypeRule = new List<CRMSaleAccountProgressTypeMasterAndRuleViewModel>();
                    TotalRecords = 0;
                }

                var records = filteredCRMSaleAccountProgressTypeRule.Skip(0).Take(param.iDisplayLength);
                var result = from c in records select new[] { Convert.ToString(c.ProgressType), Convert.ToString(c.Days), Convert.ToString(c.Operator), Convert.ToString(c.FromDate), Convert.ToString(c.CRMSaleAccountProgressTypeID), Convert.ToString(c.CRMSaleAccountProgressTypeRuleID) };
                return Json(new { sEcho = param.sEcho, iTotalRecords = TotalRecords, iTotalDisplayRecords = TotalRecords, aaData = result }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var result = 0;
                return Json(new { aaData = result }, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion
    }
}














