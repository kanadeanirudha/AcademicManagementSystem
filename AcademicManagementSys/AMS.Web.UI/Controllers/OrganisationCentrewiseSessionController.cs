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
    public class OrganisationCentrewiseSessionController : BaseController
    {
        IOrganisationCentrewiseSessionServiceAccess _OrganisationCentrewiseSessionServiceAccess = null;
        private readonly ILogger _logException;
        ActionModeEnum actionModeEnum;
        string _actionMode = string.Empty;
        string _sortBy = string.Empty;
        string _searchBy = string.Empty;
        string _sortDirection = string.Empty;
        int _startRow;
        int _rowLength;
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

        public OrganisationCentrewiseSessionController()
        {
            _OrganisationCentrewiseSessionServiceAccess = new OrganisationCentrewiseSessionServiceAccess();
        }

        // Controller Methods
        #region Controller Methods
        public ActionResult Index()
        {

            if (Convert.ToString(Session["UserType"]) == "A" || Convert.ToInt32(Session["SuperUser"]) > 0 || Convert.ToInt32(Session["AcadMgr"]) > 0 || Convert.ToInt32(Session["EstMgr"]) > 0)
            {
                return View("/Views/OrganisationCentrewiseSession/Index.cshtml");
            }
            else
            {
                return RedirectToAction("UnauthorizedAccess", "Home");
            }


        }

        public ActionResult List(string centreCode, string centreName, string actionMode)
        {
            try
            {
                OrganisationCentrewiseSessionViewModel model = new OrganisationCentrewiseSessionViewModel();
                if (Convert.ToString(Session["UserType"]) == "A")
                {
                    List<OrganisationStudyCentreMaster> listAdminRoleApplicableDetails = GetListOrgStudyCentreMaster();
                    AdminRoleApplicableDetails a = null;
                    foreach (var item in listAdminRoleApplicableDetails)
                    {

                        a = new AdminRoleApplicableDetails();
                        a.CentreCode = item.CentreCode;
                        a.CentreName = item.CentreName;
                        model.ListGetAdminRoleApplicableCentre.Add(a);

                    }
                }
                else
                {
                    int AdminRoleMasterID = 0;
                    if (Session["RoleID"] == null)
                    {
                        AdminRoleMasterID = !string.IsNullOrEmpty(Convert.ToString(Session["DefaultRoleID"])) ? Convert.ToInt32(Session["DefaultRoleID"]) : 0;
                    }

                    else
                    {
                        AdminRoleMasterID = !string.IsNullOrEmpty(Convert.ToString(Session["RoleID"])) ? Convert.ToInt32(Session["RoleID"]) : 0;
                    }

                    List<AdminRoleApplicableDetails> listAdminRoleApplicableDetails = GetAdminRoleApplicableCentreByAcademicManager(AdminRoleMasterID);
                    AdminRoleApplicableDetails a = null;
                    foreach (var item in listAdminRoleApplicableDetails)
                    {
                        if (item.IsSuperUser == 1 || item.IsAcadMgr == 1)
                        {
                            a = new AdminRoleApplicableDetails();
                            a.CentreCode = item.CentreCode;
                            a.CentreName = item.CentreName;
                            model.ListGetAdminRoleApplicableCentre.Add(a);
                        }
                    }
                }
                model.SelectedCentreCode = centreCode;
                model.CentreName = centreName;

                if (!string.IsNullOrEmpty(actionMode))
                {
                    TempData["ActionMode"] = actionMode;
                }
                return PartialView("List", model);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }

        }


        [HttpGet]
        public ActionResult Create(string centerCode, string centerName) 
        {
            try
            {

                OrganisationCentrewiseSessionViewModel model = new OrganisationCentrewiseSessionViewModel();
                model.CentreCode = centerCode;
                model.CentreName = centerName;
                model.OrganisationCentrewiseSessionDTO.CentreName = centerName.Replace('~', ' ');
                model.OrganisationCentrewiseSessionDTO.CentreCode = centerCode.ToString();

                List<GeneralSessionMaster> GeneralSessionMasterList = GetListGeneralSessionMaster();
                List<SelectListItem> GeneralSessionMaster = new List<SelectListItem>();
                foreach (GeneralSessionMaster item in GeneralSessionMasterList)
                {
                    GeneralSessionMaster.Add(new SelectListItem { Text = item.SessionName, Value = item.ID.ToString() });
                }
                ViewBag.GeneralSessionMaster = new SelectList(GeneralSessionMaster, "Value", "Text");
                return PartialView(model);

                //return PartialView(model);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        [HttpPost]
        public ActionResult Create(OrganisationCentrewiseSessionViewModel model)
        {
            try
            {


                if (model != null && model.OrganisationCentrewiseSessionDTO != null)
                {
                    model.OrganisationCentrewiseSessionDTO.ConnectionString = _connectioString;
                    model.OrganisationCentrewiseSessionDTO.SessionID = model.SessionID;
                    //model.OrganisationCentrewiseSessionDTO.SessionName = model.SessionName;
                    
                    model.OrganisationCentrewiseSessionDTO.SessionFromDate = model.SessionFromDate;
                    model.OrganisationCentrewiseSessionDTO.SessionUptoDate = model.SessionUptoDate;
                    model.OrganisationCentrewiseSessionDTO.CentreCode = model.CentreCode;
                    model.OrganisationCentrewiseSessionDTO.ActiveSessionType = model.ActiveSessionType;
                    model.OrganisationCentrewiseSessionDTO.ActiveSessionFlag = model.ActiveSessionFlag;
                   // model.OrganisationCentrewiseSessionDTO.LockStatus = model.LockStatus;
                    model.OrganisationCentrewiseSessionDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                    IBaseEntityResponse<OrganisationCentrewiseSession> response = _OrganisationCentrewiseSessionServiceAccess.InsertOrganisationCentrewiseSession(model.OrganisationCentrewiseSessionDTO);
                    model.OrganisationCentrewiseSessionDTO.errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                    return Json(model.OrganisationCentrewiseSessionDTO.errorMessage, JsonRequestBehavior.AllowGet);
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
        public ActionResult Edit(int ID)
        {
            OrganisationCentrewiseSessionViewModel model = new OrganisationCentrewiseSessionViewModel();
            try
            {
                List<GeneralSessionMaster> GeneralSessionMasterList = GetListGeneralSessionMaster();
                List<SelectListItem> GeneralSessionMaster = new List<SelectListItem>();
                foreach (GeneralSessionMaster item in GeneralSessionMasterList)
                {
                    GeneralSessionMaster.Add(new SelectListItem { Text = item.SessionName, Value = item.ID.ToString() });
                }
                ViewBag.GeneralSessionMaster = new SelectList(GeneralSessionMaster, "Value", "Text");
                model.OrganisationCentrewiseSessionDTO = new OrganisationCentrewiseSession();
                model.OrganisationCentrewiseSessionDTO.ID = ID;
                model.OrganisationCentrewiseSessionDTO.ConnectionString = _connectioString;

                IBaseEntityResponse<OrganisationCentrewiseSession> response = _OrganisationCentrewiseSessionServiceAccess.SelectByID(model.OrganisationCentrewiseSessionDTO);
                if (response != null && response.Entity != null)
                {
                    model.OrganisationCentrewiseSessionDTO.ID = response.Entity.ID;
                    model.OrganisationCentrewiseSessionDTO.SessionID = response.Entity.SessionID;
                    model.OrganisationCentrewiseSessionDTO.CentreCode = response.Entity.CentreCode;
                    model.OrganisationCentrewiseSessionDTO.SessionFromDate = response.Entity.SessionFromDate;
                    model.OrganisationCentrewiseSessionDTO.SessionUptoDate = response.Entity.SessionUptoDate; ;
                    model.OrganisationCentrewiseSessionDTO.ActiveSessionType = response.Entity.ActiveSessionType;
                   // model.OrganisationCentrewiseSessionDTO.ActiveSessionFlag = response.Entity.ActiveSessionFlag;
                    model.OrganisationCentrewiseSessionDTO.CreatedBy = response.Entity.CreatedBy;
                    ViewBag.GeneralSessionMaster = new SelectList(GeneralSessionMaster, "Value", "Text", model.SessionID);
                }
                return PartialView("/Views/OrganisationCentrewiseSession/Edit.cshtml", model);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public ActionResult Edit(OrganisationCentrewiseSessionViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model != null && model.OrganisationCentrewiseSessionDTO != null)
                {
                    if (model != null && model.OrganisationCentrewiseSessionDTO != null)
                    {
                        model.OrganisationCentrewiseSessionDTO.ConnectionString = _connectioString;
                        model.OrganisationCentrewiseSessionDTO.ID = model.ID;
                        //model.OrganisationCentrewiseSessionDTO.SessionID = model.SessionID;
                        //model.OrganisationCentrewiseSessionDTO.CentreCode = model.CentreCode;
                        //model.OrganisationCentrewiseSessionDTO.SessionFromDate = model.SessionFromDate;
                        //model.OrganisationCentrewiseSessionDTO.SessionUptoDate = model.SessionUptoDate; 
                        model.OrganisationCentrewiseSessionDTO.ActiveSessionType = model.ActiveSessionType;
                        //model.OrganisationCentrewiseSessionDTO.ActiveSessionFlag = model.ActiveSessionFlag;

                        model.OrganisationCentrewiseSessionDTO.ModifiedBy = Convert.ToInt32(Session["UserID"]);
                        IBaseEntityResponse<OrganisationCentrewiseSession> response = _OrganisationCentrewiseSessionServiceAccess.UpdateOrganisationCentrewiseSession(model.OrganisationCentrewiseSessionDTO);
                        model.OrganisationCentrewiseSessionDTO.errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Update);
                    }
                }
                return Json(model.OrganisationCentrewiseSessionDTO.errorMessage, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("Please review your form");
            }
        }

        //[HttpGet]
        //public ActionResult Delete(int ID)
        //{
        //    OrganisationCentrewiseSessionViewModel model = new OrganisationCentrewiseSessionViewModel();
        //    model.OrganisationCentrewiseSessionDTO = new OrganisationCentrewiseSession();
        //    model.OrganisationCentrewiseSessionDTO.ID = ID;
        //    return PartialView("/Views/OrganisationCentrewiseSession/Delete.cshtml", model);
        //}

        //[HttpPost]
        //public ActionResult Delete(OrganisationCentrewiseSessionViewModel model)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        if (model.ID > 0)
        //        {
        //            OrganisationCentrewiseSession OrganisationCentrewiseSessionDTO = new OrganisationCentrewiseSession();
        //            OrganisationCentrewiseSessionDTO.ConnectionString = _connectioString;
        //            OrganisationCentrewiseSessionDTO.ID = model.ID;
        //            OrganisationCentrewiseSessionDTO.DeletedBy = Convert.ToInt32(Session["UserID"]);
        //            IBaseEntityResponse<OrganisationCentrewiseSession> response = _OrganisationCentrewiseSessionServiceAccess.DeleteOrganisationCentrewiseSession(OrganisationCentrewiseSessionDTO);
        //            model.OrganisationCentrewiseSessionDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Delete);

        //        }
        //        return Json(model.OrganisationCentrewiseSessionDTO.errorMessage, JsonRequestBehavior.AllowGet);
        //    }
        //    else
        //    {
        //        return Json("Please review your form");
        //    }
        //}

        //[HttpPost]
        public ActionResult Delete(int ID)
        {
            OrganisationCentrewiseSessionViewModel model = new OrganisationCentrewiseSessionViewModel();
            //if (!ModelState.IsValid)
            //{
                if (ID > 0)
                {
                    OrganisationCentrewiseSession OrganisationCentrewiseSessionDTO = new OrganisationCentrewiseSession();
                    OrganisationCentrewiseSessionDTO.ConnectionString = _connectioString;
                    OrganisationCentrewiseSessionDTO.ID = ID;
                    OrganisationCentrewiseSessionDTO.DeletedBy = Convert.ToInt32(Session["UserID"]);
                    IBaseEntityResponse<OrganisationCentrewiseSession> response = _OrganisationCentrewiseSessionServiceAccess.DeleteOrganisationCentrewiseSession(OrganisationCentrewiseSessionDTO);
                    model.OrganisationCentrewiseSessionDTO.errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Delete);

                }
                return Json(model.OrganisationCentrewiseSessionDTO.errorMessage, JsonRequestBehavior.AllowGet);
            //}
            //else
            //{
            //    return Json("Please review your form");
            //}
        }
        #endregion

        // Non-Action Method
        #region Methods
        //public IEnumerable<OrganisationCentrewiseSessionViewModel> GetOrganisationCentrewiseSession(out int TotalRecords)
        protected List<OrganisationCentrewiseSessionViewModel> listOrganisationCentrewiseDepartment(string centreCode, out int TotalRecords)
        {
            OrganisationCentrewiseSessionSearchRequest searchRequest = new OrganisationCentrewiseSessionSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            _actionMode = Convert.ToString(TempData["ActionMode"]);
            if (Enum.TryParse(_actionMode, out actionModeEnum))     // checks actionMode i.e. Insert or Update // 
            {
                if (actionModeEnum == ActionModeEnum.Insert)        // parameters for SelectAll procedures under Insert or Update mode condition
                {
                    searchRequest.SortBy = "CreatedDate";
                    searchRequest.StartRow = 0;
                    searchRequest.EndRow = 10;
                    searchRequest.SearchBy = string.Empty;
                    searchRequest.SortDirection = "Desc";
                    searchRequest.CentreCode = centreCode;
                }
                if (actionModeEnum == ActionModeEnum.Update)
                {
                    searchRequest.SortBy = "ModifiedDate";
                    searchRequest.StartRow = 0;
                    searchRequest.EndRow = 10;
                    searchRequest.SearchBy = string.Empty;
                    searchRequest.SortDirection = "Desc";
                    searchRequest.CentreCode = centreCode;
                }
            }
            else
            {
                searchRequest.SortBy = _sortBy;                     // parameters for SelectAll procedures under normal condition
                searchRequest.StartRow = _startRow;
                searchRequest.EndRow = _startRow + _rowLength;
                searchRequest.SearchBy = _searchBy;
                searchRequest.SortDirection = _sortDirection;
                searchRequest.CentreCode = centreCode;
            }
            List<OrganisationCentrewiseSessionViewModel> listOrganisationCentrewiseSessionViewModel = new List<OrganisationCentrewiseSessionViewModel>();
            List<OrganisationCentrewiseSession> listOrganisationCentrewiseSession = new List<OrganisationCentrewiseSession>();
            IBaseEntityCollectionResponse<OrganisationCentrewiseSession> baseEntityCollectionResponse = _OrganisationCentrewiseSessionServiceAccess.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listOrganisationCentrewiseSession = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (OrganisationCentrewiseSession item in listOrganisationCentrewiseSession)
                    {
                        OrganisationCentrewiseSessionViewModel OrganisationCentrewiseSessionViewModel = new OrganisationCentrewiseSessionViewModel();
                        OrganisationCentrewiseSessionViewModel.OrganisationCentrewiseSessionDTO = item;
                        listOrganisationCentrewiseSessionViewModel.Add(OrganisationCentrewiseSessionViewModel);
                    }
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listOrganisationCentrewiseSessionViewModel;
        }
        #endregion

        // AjaxHandler Method
        #region AjaxHandler
        public ActionResult AjaxHandler(JQueryDataTableParamModel param, string SelectedCentreCode)
        {
            int TotalRecords;
            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc

            IEnumerable<OrganisationCentrewiseSessionViewModel> filteredOrganisationCentrewiseSession;
            switch (Convert.ToInt32(sortColumnIndex))
            {
                case 0:
                    _sortBy = "SessionName";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "SessionName Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;
            }
            _sortDirection = sortDirection;
            _rowLength = param.iDisplayLength;
            _startRow = param.iDisplayStart;
            if (!string.IsNullOrEmpty(SelectedCentreCode))
            {
                filteredOrganisationCentrewiseSession = listOrganisationCentrewiseDepartment(SelectedCentreCode, out TotalRecords);
            }
            else
            {
                filteredOrganisationCentrewiseSession = new List<OrganisationCentrewiseSessionViewModel>();
                TotalRecords = 0;
            }

            var records = filteredOrganisationCentrewiseSession.Skip(0).Take(param.iDisplayLength);
            var result = from c in records select new[] { c.SessionName.ToString(), c.SessionFromDate.ToString(), c.SessionUptoDate.ToString(), c.ActiveSessionFlag.ToString(), Convert.ToString(c.LockStatus), Convert.ToString(c.ID), Convert.ToString(TotalRecords)};

            return Json(new { sEcho = param.sEcho, iTotalRecords = TotalRecords, iTotalDisplayRecords = TotalRecords, aaData = result }, JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}
