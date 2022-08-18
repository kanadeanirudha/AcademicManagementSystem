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
    public class CRMSaleAllocateEmployeeInGroupController : BaseController
    {
        ICRMSaleGroupMasterAndAllocateEmployeeInGroupServiceAccess _CRMSaleGroupMasterAndAllocateEmployeeInGroupServiceAcess = null;
        private readonly ILogger _logException;
        ActionModeEnum actionModeEnum;
        string _actionMode = string.Empty;
        string _sortBy = string.Empty;
        string _searchBy = string.Empty;
        string _sortDirection = string.Empty;
        int _startRow;
        int _rowLength;
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

        public CRMSaleAllocateEmployeeInGroupController()
        {
            _CRMSaleGroupMasterAndAllocateEmployeeInGroupServiceAcess = new CRMSaleGroupMasterAndAllocateEmployeeInGroupServiceAccess();
        }

        // Controller Methods
        #region Controller Methods
        public ActionResult Index()
        {

            return View("/Views/CRMSales/CRMSaleAllocateEmployeeInGroup/Index.cshtml");
        }

        public ActionResult List(string CRMSaleGroupMasterID, string actionMode)
        {
            try
            {
                CRMSaleGroupMasterAndAllocateEmployeeInGroupViewModel model = new CRMSaleGroupMasterAndAllocateEmployeeInGroupViewModel();

                if (!string.IsNullOrEmpty(actionMode))
                {
                    TempData["ActionMode"] = actionMode;
                }
                List<CRMSaleGroupMasterAndAllocateEmployeeInGroup> CRMSaleGroupMaster = GetListCRMSaleGroupMaster();
                List<SelectListItem> CRMSaleGroupMasterList = new List<SelectListItem>();
                foreach (CRMSaleGroupMasterAndAllocateEmployeeInGroup item in CRMSaleGroupMaster)
                {
                    CRMSaleGroupMasterList.Add(new SelectListItem { Text = item.GroupName, Value = Convert.ToString(item.CRMSaleGroupMasterID) });
                }
                if (Convert.ToInt32(CRMSaleGroupMasterID) > 0)
                {
                    ViewBag.CRMSaleGroupMasterList = new SelectList(CRMSaleGroupMasterList, "Value", "Text", CRMSaleGroupMasterID);
                }
                else
                {
                    ViewBag.CRMSaleGroupMasterList = new SelectList(CRMSaleGroupMasterList, "Value", "Text");
                }
                return PartialView("/Views/CRMSales/CRMSaleAllocateEmployeeInGroup/List.cshtml", model);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }

        }



        public ActionResult Create()
        {
            CRMSaleGroupMasterAndAllocateEmployeeInGroupViewModel model = new CRMSaleGroupMasterAndAllocateEmployeeInGroupViewModel();
            List<CRMSaleGroupMasterAndAllocateEmployeeInGroup> CRMSaleGroupMaster = GetListCRMSaleGroupMaster();
            List<SelectListItem> CRMSaleGroupMasterList = new List<SelectListItem>();
            foreach (CRMSaleGroupMasterAndAllocateEmployeeInGroup item in CRMSaleGroupMaster)
            {
                CRMSaleGroupMasterList.Add(new SelectListItem { Text = item.GroupName, Value = Convert.ToString(item.CRMSaleGroupMasterID) });
            }
            ViewBag.CRMSaleGroupMasterList = new SelectList(CRMSaleGroupMasterList, "Value", "Text");

            List<SelectListItem> EmpEmployeeMaster = new List<SelectListItem>();
            ViewBag.EmpEmployeeMasterList = new SelectList(EmpEmployeeMaster, "Value", "Text");

            return PartialView("/Views/CRMSales/CRMSaleAllocateEmployeeInGroup/Create.cshtml", model);
        }

        [HttpPost]
        public ActionResult Create(CRMSaleGroupMasterAndAllocateEmployeeInGroupViewModel model)
        {
            try
            {
                if (model != null && model.CRMSaleGroupMasterAndAllocateEmployeeInGroupDTO != null)
                {
                    model.CRMSaleGroupMasterAndAllocateEmployeeInGroupDTO.ConnectionString = _connectioString;
                    model.CRMSaleGroupMasterAndAllocateEmployeeInGroupDTO.CRMSaleGroupMasterID = model.CRMSaleGroupMasterID;
                    model.CRMSaleGroupMasterAndAllocateEmployeeInGroupDTO.EmployeeId = model.EmployeeId;
                    model.CRMSaleGroupMasterAndAllocateEmployeeInGroupDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                    IBaseEntityResponse<CRMSaleGroupMasterAndAllocateEmployeeInGroup> response = _CRMSaleGroupMasterAndAllocateEmployeeInGroupServiceAcess.InsertCRMSaleAllocateEmployeeInGroup(model.CRMSaleGroupMasterAndAllocateEmployeeInGroupDTO);
                    model.errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                    return Json(model, JsonRequestBehavior.AllowGet);
                }
                return Json("Please review your form");
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }

        }

        public ActionResult InActive(string IDs)
        {
            var errorMessage = string.Empty;
            string[] IDsArray = IDs.Split('~');
            CRMSaleGroupMasterAndAllocateEmployeeInGroupViewModel model = new CRMSaleGroupMasterAndAllocateEmployeeInGroupViewModel();
            if (Convert.ToInt32(IDsArray[0]) > 0)
            {
               
                IBaseEntityResponse<CRMSaleGroupMasterAndAllocateEmployeeInGroup> response = null;
                CRMSaleGroupMasterAndAllocateEmployeeInGroup CRMSaleGroupMasterAndAllocateEmployeeInGroupDTO = new CRMSaleGroupMasterAndAllocateEmployeeInGroup();
                CRMSaleGroupMasterAndAllocateEmployeeInGroupDTO.ConnectionString = _connectioString;
                CRMSaleGroupMasterAndAllocateEmployeeInGroupDTO.CRMSaleAllocateEmployeeInGroupID = Convert.ToInt32(IDsArray[0]);
                model.CRMSaleGroupMasterID = Convert.ToInt32(IDsArray[1]);
                CRMSaleGroupMasterAndAllocateEmployeeInGroupDTO.ModifiedBy = Convert.ToInt32(Session["UserID"]);
                response = _CRMSaleGroupMasterAndAllocateEmployeeInGroupServiceAcess.UpdateCRMSaleAllocateEmployeeInGroup(CRMSaleGroupMasterAndAllocateEmployeeInGroupDTO);
                errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.InActive);
            }

            return Json(errorMessage, JsonRequestBehavior.AllowGet);
        }
        #endregion

        // Non-Action Method
        #region Methods

        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult GetEmployeeListNotInGroup(string SelectedGroupMasterID)
        {

            int id = 0;
            bool isValid = Int32.TryParse(SelectedGroupMasterID, out id);
            //var employee = GetListEmpEmployeeMasterInCRMSales(0, "EmployeeListNotInGroup");
            var employee = GetListEmpEmployeeMasterForCRMSalesGroup(Convert.ToInt32(SelectedGroupMasterID));
            var result = (from s in employee
                          select new
                          {
                              id = s.ID,
                              name = s.EmployeeFullName +'('+s.EmployeeDesignation+')',
                          }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }
       
     

        public IEnumerable<CRMSaleGroupMasterAndAllocateEmployeeInGroupViewModel> GetCRMSaleAllocateEmployeeInGroup(int SelectedGroupID, out int TotalRecords)
        {
            CRMSaleGroupMasterAndAllocateEmployeeInGroupSearchRequest searchRequest = new CRMSaleGroupMasterAndAllocateEmployeeInGroupSearchRequest();
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
                    searchRequest.CRMSaleGroupMasterID = SelectedGroupID;
                }
                if (actionModeEnum == ActionModeEnum.Update)
                {
                    searchRequest.SortBy = "A.ModifiedDate";
                    searchRequest.StartRow = 0;
                    searchRequest.EndRow = 10;
                    searchRequest.SearchBy = String.Empty;
                    searchRequest.SortDirection = "Desc";
                    searchRequest.CRMSaleGroupMasterID = SelectedGroupID;
                }
            }
            else
            {
                searchRequest.SortBy = _sortBy;                     // parameters for SelectAll procedures under normal condition
                searchRequest.StartRow = _startRow;
                searchRequest.EndRow = _startRow + _rowLength;
                searchRequest.SearchBy = _searchBy;
                searchRequest.SortDirection = _sortDirection;
                searchRequest.CRMSaleGroupMasterID = SelectedGroupID;
            }
            List<CRMSaleGroupMasterAndAllocateEmployeeInGroupViewModel> listCRMSaleGroupMasterViewModel = new List<CRMSaleGroupMasterAndAllocateEmployeeInGroupViewModel>();
            List<CRMSaleGroupMasterAndAllocateEmployeeInGroup> listCRMSaleGroupMaster = new List<CRMSaleGroupMasterAndAllocateEmployeeInGroup>();
            IBaseEntityCollectionResponse<CRMSaleGroupMasterAndAllocateEmployeeInGroup> baseEntityCollectionResponse = _CRMSaleGroupMasterAndAllocateEmployeeInGroupServiceAcess.GetBySearchCRMSaleAllocateEmployeeInGroup(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listCRMSaleGroupMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (CRMSaleGroupMasterAndAllocateEmployeeInGroup item in listCRMSaleGroupMaster)
                    {
                        CRMSaleGroupMasterAndAllocateEmployeeInGroupViewModel CRMSaleGroupMasterViewModel = new CRMSaleGroupMasterAndAllocateEmployeeInGroupViewModel();
                        CRMSaleGroupMasterViewModel.CRMSaleGroupMasterAndAllocateEmployeeInGroupDTO = item;
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
        public ActionResult AjaxHandler(JQueryDataTableParamModel param, string SelectedGroupID)
        {
            if (Session["UserType"] != null)
            {
                int TotalRecords;
                var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
                string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc

                IEnumerable<CRMSaleGroupMasterAndAllocateEmployeeInGroupViewModel> filteredCRMSaleAllocateEmployeeInGroup;
                switch (Convert.ToInt32(sortColumnIndex))
                {
                    case 0:
                        _sortBy = "B.DepartmentName";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            _searchBy = "B.EmployeeFirstName Like '%" + param.sSearch + "%' or B.EmployeeLastName Like '%" + param.sSearch + "%' or B.DepartmentName Like '%" + param.sSearch + "%' or B.EmployeeDesignation Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                        }
                        break;

                    case 1:
                        _sortBy = "B.EmployeeFirstName";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            _searchBy = "B.EmployeeFirstName Like '%" + param.sSearch + "%' or B.EmployeeLastName Like '%" + param.sSearch + "%' or B.DepartmentName Like '%" + param.sSearch + "%' or B.EmployeeDesignation Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                        }
                        break;
                    case 2:
                        _sortBy = "B.EmployeeDesignation";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            _searchBy = "B.EmployeeFirstName Like '%" + param.sSearch + "%' or B.EmployeeLastName Like '%" + param.sSearch + "%' or B.DepartmentName Like '%" + param.sSearch + "%' or B.EmployeeDesignation Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                        }
                        break;

                }
                _sortDirection = sortDirection;
                _rowLength = param.iDisplayLength;
                _startRow = param.iDisplayStart;
                if (!string.IsNullOrEmpty(SelectedGroupID))
                {
                    filteredCRMSaleAllocateEmployeeInGroup = GetCRMSaleAllocateEmployeeInGroup(Convert.ToInt32(SelectedGroupID), out TotalRecords);
                }
                else
                {
                    filteredCRMSaleAllocateEmployeeInGroup = new List<CRMSaleGroupMasterAndAllocateEmployeeInGroupViewModel>();
                    TotalRecords = 0;
                }

                var records = filteredCRMSaleAllocateEmployeeInGroup.Skip(0).Take(param.iDisplayLength);
                var result = from c in records select new[] { Convert.ToString(c.DepartmentName),  Convert.ToString(c.EmployeeName), Convert.ToString(c.EmployeeDesignation),Convert.ToString(c.CRMSaleAllocateEmployeeInGroupID) };

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














 