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
    public class CRMSaleGroupMasterController : BaseController
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

        public CRMSaleGroupMasterController()
        {
            _CRMSaleGroupMasterAndAllocateEmployeeInGroupServiceAcess = new CRMSaleGroupMasterAndAllocateEmployeeInGroupServiceAccess();
        }

        // Controller Methods
        #region Controller Methods
        public ActionResult Index()
        {

            return View("/Views/CRMSales/CRMSaleGroupMaster/Index.cshtml");
        }

        public ActionResult List(string actionMode)
        {
            try
            {
                CRMSaleGroupMasterAndAllocateEmployeeInGroupViewModel model = new CRMSaleGroupMasterAndAllocateEmployeeInGroupViewModel();
                if (!string.IsNullOrEmpty(actionMode))
                {
                    TempData["ActionMode"] = actionMode;
                }
                return PartialView("/Views/CRMSales/CRMSaleGroupMaster/List.cshtml", model);
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
            try
            {
                model.CRMSaleGroupMasterAndAllocateEmployeeInGroupDTO = new CRMSaleGroupMasterAndAllocateEmployeeInGroup();
                model.CRMSaleGroupMasterAndAllocateEmployeeInGroupDTO.ConnectionString = _connectioString;
                model.CRMSaleGroupMasterAndAllocateEmployeeInGroupDTO.EmployeeId = Convert.ToInt32(Session["PersonID"]);
                model.CRMSaleGroupMasterAndAllocateEmployeeInGroupDTO.AuthorRoleID = Convert.ToInt32(Session["DefaultRoleID"]);

                IBaseEntityResponse<CRMSaleGroupMasterAndAllocateEmployeeInGroup> response = _CRMSaleGroupMasterAndAllocateEmployeeInGroupServiceAcess.CheckAuthorityToCreateGroup(model.CRMSaleGroupMasterAndAllocateEmployeeInGroupDTO);
                if (response != null && response.Entity != null)
                {
                    model.CRMSaleGroupMasterAndAllocateEmployeeInGroupDTO.GeneralGroupTypeAttributesId = response.Entity.GeneralGroupTypeAttributesId;
                }

                return PartialView("/Views/CRMSales/CRMSaleGroupMaster/Create.cshtml", model);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        [HttpPost]
        public ActionResult Create(CRMSaleGroupMasterAndAllocateEmployeeInGroupViewModel model)
        {
            try
            {
                if (model != null && model.CRMSaleGroupMasterAndAllocateEmployeeInGroupDTO != null)
                {
                    model.CRMSaleGroupMasterAndAllocateEmployeeInGroupDTO.ConnectionString = _connectioString;
                    model.CRMSaleGroupMasterAndAllocateEmployeeInGroupDTO.GroupName = model.GroupName;
                    model.CRMSaleGroupMasterAndAllocateEmployeeInGroupDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                    model.CRMSaleGroupMasterAndAllocateEmployeeInGroupDTO.EmployeeId = Convert.ToInt32(Session["PersonID"]);
                    model.CRMSaleGroupMasterAndAllocateEmployeeInGroupDTO.AuthorRoleID = Convert.ToInt32(Session["DefaultRoleID"]);
                    model.CRMSaleGroupMasterAndAllocateEmployeeInGroupDTO.GeneralGroupTypeAttributesId = model.GeneralGroupTypeAttributesId;
                    IBaseEntityResponse<CRMSaleGroupMasterAndAllocateEmployeeInGroup> response = _CRMSaleGroupMasterAndAllocateEmployeeInGroupServiceAcess.InsertCRMSaleGroupMaster(model.CRMSaleGroupMasterAndAllocateEmployeeInGroupDTO);
                    model.CRMSaleGroupMasterAndAllocateEmployeeInGroupDTO.errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                    return Json(model.CRMSaleGroupMasterAndAllocateEmployeeInGroupDTO.errorMessage, JsonRequestBehavior.AllowGet);
                }
                return Json("Please review your form");
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }

        }

        public ActionResult Delete(int ID)
        {
            var errorMessage = string.Empty;
            if (ID > 0)
            {
                IBaseEntityResponse<CRMSaleGroupMasterAndAllocateEmployeeInGroup> response = null;
                CRMSaleGroupMasterAndAllocateEmployeeInGroup CRMSaleGroupMasterAndAllocateEmployeeInGroupDTO = new CRMSaleGroupMasterAndAllocateEmployeeInGroup();
                CRMSaleGroupMasterAndAllocateEmployeeInGroupDTO.ConnectionString = _connectioString;
                CRMSaleGroupMasterAndAllocateEmployeeInGroupDTO.CRMSaleGroupMasterID = ID;
                CRMSaleGroupMasterAndAllocateEmployeeInGroupDTO.DeletedBy = Convert.ToInt32(Session["UserID"]);
                response = _CRMSaleGroupMasterAndAllocateEmployeeInGroupServiceAcess.DeleteCRMSaleGroupMaster(CRMSaleGroupMasterAndAllocateEmployeeInGroupDTO);
                errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Delete);
            }

            return Json(errorMessage, JsonRequestBehavior.AllowGet);
        }
        #endregion

        // Non-Action Method
        #region Methods
        public IEnumerable<CRMSaleGroupMasterAndAllocateEmployeeInGroupViewModel> GetCRMSaleGroupMaster(out int TotalRecords)
        {
            CRMSaleGroupMasterAndAllocateEmployeeInGroupSearchRequest searchRequest = new CRMSaleGroupMasterAndAllocateEmployeeInGroupSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.EmployeeID = Convert.ToInt32(Session["PersonID"]);
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
            List<CRMSaleGroupMasterAndAllocateEmployeeInGroupViewModel> listCRMSaleGroupMasterViewModel = new List<CRMSaleGroupMasterAndAllocateEmployeeInGroupViewModel>();
            List<CRMSaleGroupMasterAndAllocateEmployeeInGroup> listCRMSaleGroupMaster = new List<CRMSaleGroupMasterAndAllocateEmployeeInGroup>();
            IBaseEntityCollectionResponse<CRMSaleGroupMasterAndAllocateEmployeeInGroup> baseEntityCollectionResponse = _CRMSaleGroupMasterAndAllocateEmployeeInGroupServiceAcess.GetBySearchCRMSaleGroupMaster(searchRequest);
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
        public ActionResult AjaxHandler(JQueryDataTableParamModel param)
        {
            if (Session["UserType"] != null)
            {
                int TotalRecords;
                var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
                string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc

                IEnumerable<CRMSaleGroupMasterAndAllocateEmployeeInGroupViewModel> filteredCountryMaster;
                switch (Convert.ToInt32(sortColumnIndex))
                {
                    case 0:
                        _sortBy = "A.GroupName";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = "A.GroupName like '%'";
                        }
                        else
                        {
                            _searchBy = "A.GroupName Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                        }
                        break;

                }
                _sortDirection = sortDirection;
                _rowLength = param.iDisplayLength;
                _startRow = param.iDisplayStart;
                filteredCountryMaster = GetCRMSaleGroupMaster(out TotalRecords);

                if ((filteredCountryMaster.Count()) == 0)
                {
                    filteredCountryMaster = new List<CRMSaleGroupMasterAndAllocateEmployeeInGroupViewModel>();
                    TotalRecords = 0;
                }

                var records = filteredCountryMaster.Skip(0).Take(param.iDisplayLength);
                var result = from c in records select new[] { Convert.ToString(c.GroupName), Convert.ToString(c.CRMSaleGroupMasterID) };

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