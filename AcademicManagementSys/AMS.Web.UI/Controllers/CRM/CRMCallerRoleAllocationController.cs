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
    public class CRMCallerRoleAllocationController : BaseController
    {
        ICRMCallerRoleAllocationServiceAccess _CRMCallerRoleAllocationServiceAcess = null;
        private readonly ILogger _logException;
        ActionModeEnum actionModeEnum;
        string _actionMode = string.Empty;
        string _sortBy = string.Empty;
        string _searchBy = string.Empty;
        string _sortDirection = string.Empty;
        int _startRow;
        int _rowLength;
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

        public CRMCallerRoleAllocationController()
        {
            _CRMCallerRoleAllocationServiceAcess = new CRMCallerRoleAllocationServiceAccess();
        }

        // Controller Methods
        #region Controller Methods
        public ActionResult Index()
        {
           
                return View("/Views/CRM/CRMCallerRoleAllocation/Index.cshtml");
        }

        public ActionResult List(string actionMode)
        {
            try
            {
                CRMCallerRoleAllocationViewModel model = new CRMCallerRoleAllocationViewModel();
                if (!string.IsNullOrEmpty(actionMode))
                {
                    TempData["ActionMode"] = actionMode;
                }
                return PartialView("/Views/CRM/CRMCallerRoleAllocation/List.cshtml", model);
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
            CRMCallerRoleAllocationViewModel model = new CRMCallerRoleAllocationViewModel();
            List<CRMCallerRoleAllocation> CRMAdmineRoleCode = GetListCallerRoleAllocation();
            List<SelectListItem> CRMAdmineRoleCodelist = new List<SelectListItem>();
            foreach (CRMCallerRoleAllocation item in CRMAdmineRoleCode)
            {
                CRMAdmineRoleCodelist.Add(new SelectListItem { Text = item.AdminRoleCode, Value = Convert.ToString(item.AdminRoleMasterID) });
            }
            ViewBag.AdminRoleCodeList = new SelectList(CRMAdmineRoleCodelist, "Value", "Text");
            return PartialView("/Views/CRM/CRMCallerRoleAllocation/Create.cshtml", model);
        }

        [HttpPost]
        public ActionResult Create(CRMCallerRoleAllocationViewModel model)
        {
            try
            {
                if (model != null && model.CRMCallerRoleAllocationDTO != null)
                {
                    model.CRMCallerRoleAllocationDTO.ConnectionString = _connectioString;
                    model.CRMCallerRoleAllocationDTO.AdminRoleMasterID = model.AdminRoleMasterID;
                    model.CRMCallerRoleAllocationDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                    IBaseEntityResponse<CRMCallerRoleAllocation> response = _CRMCallerRoleAllocationServiceAcess.InsertCRMCallerRoleAllocation(model.CRMCallerRoleAllocationDTO);
                    model.CRMCallerRoleAllocationDTO.errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                    return Json(model.CRMCallerRoleAllocationDTO.errorMessage, JsonRequestBehavior.AllowGet);
                }

                return Json("Please review your form");

            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }

        }

     


        
        public ActionResult Edit(Int16 id)
        {
            try
            {
                CRMCallerRoleAllocationViewModel model = new CRMCallerRoleAllocationViewModel();
                model.CRMCallerRoleAllocationDTO.ConnectionString = _connectioString;
                model.CRMCallerRoleAllocationDTO.ID = id;                   
                model.CRMCallerRoleAllocationDTO.ModifiedBy= Convert.ToInt32(Session["UserID"]);
                IBaseEntityResponse<CRMCallerRoleAllocation> response = _CRMCallerRoleAllocationServiceAcess.UpdateCRMCallerRoleAllocation(model.CRMCallerRoleAllocationDTO);
                model.CRMCallerRoleAllocationDTO.errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Update);
                return Json(model.CRMCallerRoleAllocationDTO.errorMessage, JsonRequestBehavior.AllowGet);
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
        public IEnumerable<CRMCallerRoleAllocationViewModel> GetCRMCallerRoleAllocation(out int TotalRecords)
        {
            CRMCallerRoleAllocationSearchRequest searchRequest = new CRMCallerRoleAllocationSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            _actionMode = Convert.ToString(TempData["ActionMode"]);
            if (Enum.TryParse(_actionMode, out actionModeEnum))     // checks actionMode i.e. Insert or Update // 
            {
                if (actionModeEnum == ActionModeEnum.Insert)        // parameters for SelectAll procedures under Insert or Update mode condition
                {
                    searchRequest.SortBy = "A.CreatedDate";
                    searchRequest.StartRow = 0;
                    searchRequest.EndRow = 10;
                    searchRequest.SearchBy = String.Empty;
                    searchRequest.SortDirection = "Desc";
                }
                if (actionModeEnum == ActionModeEnum.Update)
                {
                    searchRequest.SortBy = "A.ModifiedDate";
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
            List<CRMCallerRoleAllocationViewModel> listCRMCallerRoleAllocationViewModel = new List<CRMCallerRoleAllocationViewModel>();
            List<CRMCallerRoleAllocation> listCRMCallerRoleAllocation = new List<CRMCallerRoleAllocation>();
            IBaseEntityCollectionResponse<CRMCallerRoleAllocation> baseEntityCollectionResponse = _CRMCallerRoleAllocationServiceAcess.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listCRMCallerRoleAllocation = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (CRMCallerRoleAllocation item in listCRMCallerRoleAllocation)
                    {
                        CRMCallerRoleAllocationViewModel CRMCallerRoleAllocationViewModel = new CRMCallerRoleAllocationViewModel();
                        CRMCallerRoleAllocationViewModel.CRMCallerRoleAllocationDTO = item;
                        listCRMCallerRoleAllocationViewModel.Add(CRMCallerRoleAllocationViewModel);
                    }
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listCRMCallerRoleAllocationViewModel;
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

                IEnumerable<CRMCallerRoleAllocationViewModel> filteredCountryMaster;
                switch (Convert.ToInt32(sortColumnIndex))
                {
                    case 0:
                        _sortBy = "B.AdminRoleCode";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = "B.AdminRoleCode like '%'";
                        }
                        else
                        {
                            _searchBy = "B.AdminRoleCode Like '%" + param.sSearch + "%' or B.AdminRoleCode Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                        }
                        break;
                    case 1:
                        _sortBy = "B.AdminRoleCode";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            _searchBy = "B.AdminRoleCode Like '%" + param.sSearch + "%' or B.AdminRoleCode Like '%" + param.sSearch + "%'";      //this "if" block is added for search functionality
                        }
                        break;
                }
                _sortDirection = sortDirection;
                _rowLength = param.iDisplayLength;
                _startRow = param.iDisplayStart;
                filteredCountryMaster = GetCRMCallerRoleAllocation(out TotalRecords);

                if ((filteredCountryMaster.Count()) == 0)
                {
                    filteredCountryMaster = new List<CRMCallerRoleAllocationViewModel>();
                    TotalRecords = 0;
                }

                var records = filteredCountryMaster.Skip(0).Take(param.iDisplayLength);
                var result = from c in records select new[] { Convert.ToString(c.AdminRoleMasterID), Convert.ToString(c.AdminRoleCode), Convert.ToString(c.ID) };

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