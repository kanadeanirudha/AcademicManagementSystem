using AMS.Base.DTO;
using AMS.DTO;
using AMS.ServiceAccess;
using AMS.ViewModel;
using AMS.ExceptionManager;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web.Mvc;
using AMS.Common;

namespace AMS.Web.UI.Controllers
{
    public class OrganisationSubjectMasterController : BaseController
    {
        IOrganisationSubjectMasterServiceAccess _organisationSubjectMasterServiceAcess = null;
        OrganisationSubjectMasterBaseViewModel _organisationSubjectMasterBaseViewModel = null;
        private readonly ILogger _logException;
        ActionModeEnum actionModeEnum;
        string _actionMode = string.Empty;
        string _sortBy = string.Empty;
        string _searchBy = string.Empty;
        string _sortDirection = string.Empty;
        int _startRow;
        int _rowLength;
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

        public OrganisationSubjectMasterController()
        {
            _organisationSubjectMasterServiceAcess = new OrganisationSubjectMasterServiceAccess();
            _organisationSubjectMasterBaseViewModel = new OrganisationSubjectMasterBaseViewModel();
        }

        #region Controller Methods
        public ActionResult Index()
        {
            if (Convert.ToString(Session["UserType"]) == "A" || Convert.ToInt32(Session["SuperUser"]) > 0 || Convert.ToInt32(Session["AcadMgr"]) > 0 || Convert.ToInt32(Session["EstMgr"]) > 0)
            {
                return View();
            }
            else
            {
                return RedirectToAction("UnauthorizedAccess", "Home");
            }
        }

        public ActionResult List(string centerCode, string universityID, string actionMode)
        {
            try
            {
                OrganisationSubjectMasterViewModel model = new OrganisationSubjectMasterViewModel();

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
                        AdminRoleMasterID    = !string.IsNullOrEmpty(Convert.ToString(Session["DefaultRoleID"])) ? Convert.ToInt32(Session["DefaultRoleID"]) : 0;
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
              
                if (!string.IsNullOrEmpty(centerCode))
                {
                    model.ListOrganisationUniversityMaster = GetListOrganisationUniversityMaster(centerCode);
                }
                model.SelectedCentreCode = centerCode;
                model.SelectedUniversityID = universityID;
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
        public ActionResult Create(int universityID, string CentreCode)
        {
            try
            {
                OrganisationSubjectMasterViewModel model = new OrganisationSubjectMasterViewModel();

                model.OrganisationSubjectMasterDTO.UniversityID = universityID;
                model.OrganisationSubjectMasterDTO.CentreCode = CentreCode;

                List<GeneralLanguageMaster> GeneralLanguageMasterList = GetListGeneralLanguageMaster();
                List<SelectListItem> GeneralLanguageMaster = new List<SelectListItem>();
                foreach (GeneralLanguageMaster item in GeneralLanguageMasterList)
                {
                    GeneralLanguageMaster.Add(new SelectListItem { Text = item.LanguageName, Value = item.ID.ToString() });
                }
                ViewBag.GeneralLanguageMaster = new SelectList(GeneralLanguageMaster, "Value", "Text");
                return PartialView(model);

            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        [HttpPost]
        public ActionResult Create(OrganisationSubjectMasterViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model != null && model.OrganisationSubjectMasterDTO != null)
                    {
                        model.OrganisationSubjectMasterDTO.ConnectionString = _connectioString;
                        model.OrganisationSubjectMasterDTO.Descriptions = model.Descriptions;
                        model.OrganisationSubjectMasterDTO.PaperCode = model.PaperCode;
                        model.OrganisationSubjectMasterDTO.SubjectCode = model.SubjectCode;
                        model.OrganisationSubjectMasterDTO.SubjectIntroYear = model.SubjectIntroYear;
                        model.OrganisationSubjectMasterDTO.UniversityID = model.UniversityID;
                        model.OrganisationSubjectMasterDTO.LanguageID = model.LanguageID;
                        model.OrganisationSubjectMasterDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                        IBaseEntityResponse<OrganisationSubjectMaster> response = _organisationSubjectMasterServiceAcess.InsertOrganisationSubjectMaster(model.OrganisationSubjectMasterDTO);
                        model.errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                    }
                    model.CentreCodeWithName = model.CentreCode;
                    model.UniversityIDWithName = Convert.ToString(model.UniversityID);
                    return Json(model, JsonRequestBehavior.AllowGet);
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
        public ActionResult Edit(int id, string CentreCode)
        {
            try
            {
                OrganisationSubjectMasterViewModel model = new OrganisationSubjectMasterViewModel();
                model.OrganisationSubjectMasterDTO.CentreCode = CentreCode;

                //List<OrganisationUniversityMaster> OrganisationUniversityMasterList = GetListOrganisationUniversityMaster();
                //List<SelectListItem> OrganisationUniversityMaster = new List<SelectListItem>();
                //foreach (OrganisationUniversityMaster item in OrganisationUniversityMasterList)
                //{
                //    OrganisationUniversityMaster.Add(new SelectListItem { Text = item.UniversityName, Value = item.universityID.ToString() });
                //}
                List<GeneralLanguageMaster> GeneralLanguageMasterList = GetListGeneralLanguageMaster();
                List<SelectListItem> GeneralLanguageMaster = new List<SelectListItem>();
                foreach (GeneralLanguageMaster item in GeneralLanguageMasterList)
                {
                    GeneralLanguageMaster.Add(new SelectListItem { Text = item.LanguageName, Value = item.ID.ToString() });
                }
                model.OrganisationSubjectMasterDTO = new OrganisationSubjectMaster();
                model.OrganisationSubjectMasterDTO.ID = id;
                model.OrganisationSubjectMasterDTO.ConnectionString = _connectioString;

                IBaseEntityResponse<OrganisationSubjectMaster> response = _organisationSubjectMasterServiceAcess.SelectByID(model.OrganisationSubjectMasterDTO);
                if (response != null && response.Entity != null)
                {
                    model.OrganisationSubjectMasterDTO.ID = response.Entity.ID;
                    model.OrganisationSubjectMasterDTO.Descriptions = response.Entity.Descriptions;
                    model.OrganisationSubjectMasterDTO.SubjectCode = response.Entity.SubjectCode;
                    model.OrganisationSubjectMasterDTO.SubjectIntroYear = response.Entity.SubjectIntroYear;
                    model.OrganisationSubjectMasterDTO.PaperCode = response.Entity.PaperCode;
                    model.OrganisationSubjectMasterDTO.UniversityID = response.Entity.UniversityID;
                    model.OrganisationSubjectMasterDTO.LanguageID = response.Entity.LanguageID;
                    //    ViewBag.OrganisationUniversityMaster = new SelectList(OrganisationUniversityMaster, "Value", "Text", response.Entity.UniversityID);
                    ViewBag.GeneralLanguageMaster = new SelectList(GeneralLanguageMaster, "Value", "Text", response.Entity.LanguageID);
                }
                return PartialView(model);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        [HttpPost]
        public ActionResult Edit(OrganisationSubjectMasterViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model != null && model.OrganisationSubjectMasterDTO != null)
                    {
                        if (model != null && model.OrganisationSubjectMasterDTO != null)
                        {
                            model.OrganisationSubjectMasterDTO.ConnectionString = _connectioString;
                            model.OrganisationSubjectMasterDTO.Descriptions = model.Descriptions;
                            model.OrganisationSubjectMasterDTO.SubjectCode = model.SubjectCode;
                            model.OrganisationSubjectMasterDTO.SubjectIntroYear = model.SubjectIntroYear;
                            model.OrganisationSubjectMasterDTO.PaperCode = model.PaperCode;
                            model.OrganisationSubjectMasterDTO.UniversityID = model.UniversityID;
                            model.OrganisationSubjectMasterDTO.LanguageID = model.LanguageID;
                            model.OrganisationSubjectMasterDTO.ModifiedBy = Convert.ToInt32(Session["UserID"]);
                            IBaseEntityResponse<OrganisationSubjectMaster> response = _organisationSubjectMasterServiceAcess.UpdateOrganisationSubjectMaster(model.OrganisationSubjectMasterDTO);
                            model.errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Update);
                        }
                        model.CentreCodeWithName = model.CentreCode;
                        model.UniversityIDWithName = Convert.ToString(model.UniversityID);
                    }

                    return Json(model, JsonRequestBehavior.AllowGet);
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
        //public ActionResult Delete(int ID, int universityID, string CentreCode)
        //{
        //    try
        //    {
        //        OrganisationSubjectMasterViewModel model = new OrganisationSubjectMasterViewModel();
        //        model.OrganisationSubjectMasterDTO = new OrganisationSubjectMaster();
        //        model.OrganisationSubjectMasterDTO.ID = ID;
        //        model.OrganisationSubjectMasterDTO.UniversityID = universityID;
        //        model.OrganisationSubjectMasterDTO.CentreCode = CentreCode;
        //        return PartialView(model);
        //    }
        //    catch (Exception ex)
        //    {
        //        _logException.Error(ex.Message);
        //        throw;
        //    }
        //}

        //[HttpPost]
        //public ActionResult Delete(OrganisationSubjectMasterViewModel model)
        //{
        //    try
        //    {
        //        if (model.ID > 0)
        //        {
        //            OrganisationSubjectMaster OrganisationSubjectMasterDTO = new OrganisationSubjectMaster();
        //            OrganisationSubjectMasterDTO.ConnectionString = _connectioString;
        //            OrganisationSubjectMasterDTO.ID = model.ID;
        //            OrganisationSubjectMasterDTO.DeletedBy = Convert.ToInt32(Session["UserID"]);
        //            IBaseEntityResponse<OrganisationSubjectMaster> response = _organisationSubjectMasterServiceAcess.DeleteOrganisationSubjectMaster(OrganisationSubjectMasterDTO);
        //            model.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Delete);
        //            model.CentreCodeWithName = model.CentreCode;
        //            model.UniversityIDWithName = Convert.ToString(model.UniversityID);
        //            return Json(model, JsonRequestBehavior.AllowGet);

        //        }

        //        else
        //        {
        //            model.CentreCodeWithName = model.CentreCode;
        //            model.UniversityIDWithName = Convert.ToString(model.UniversityID);
        //            return Json("Please review your form");
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        _logException.Error(ex.Message);
        //        throw;
        //    }
        //}

        //, string SelectedCentreCode, int SelectedUniversityID
        public ActionResult Delete(int ID)
        {
            OrganisationSubjectMasterViewModel model = new OrganisationSubjectMasterViewModel();
            try
            {
                if (ID > 0)
                {
                    OrganisationSubjectMaster OrganisationSubjectMasterDTO = new OrganisationSubjectMaster();
                    OrganisationSubjectMasterDTO.ConnectionString = _connectioString;
                    OrganisationSubjectMasterDTO.ID = ID;
                    OrganisationSubjectMasterDTO.DeletedBy = Convert.ToInt32(Session["UserID"]);
                    IBaseEntityResponse<OrganisationSubjectMaster> response = _organisationSubjectMasterServiceAcess.DeleteOrganisationSubjectMaster(OrganisationSubjectMasterDTO);
                    model.errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Delete);
                    model.CentreCodeWithName = model.CentreCode;
                    model.UniversityIDWithName = Convert.ToString(model.UniversityID);

                    //model.CentreCodeWithName = SelectedCentreCode;
                    //model.UniversityIDWithName = Convert.ToString(SelectedUniversityID);
                    return Json(model, JsonRequestBehavior.AllowGet);

                }

                else
                {
                    model.CentreCodeWithName = model.CentreCode;
                    model.UniversityIDWithName = Convert.ToString(model.UniversityID);
                    return Json("Please review your form");
                }

            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult GetUniversityByCentreCode(string SelectedCentreCode)
        {
            //string[] splited;
            // splited = SelectedCentreCode.Split(':');
            //_organisationBranchDetailsBaseViewModel.SelectedCentreName = splited[1];
            // SelectedCentreCode = splited[0];
            if (String.IsNullOrEmpty(SelectedCentreCode))
            {
                throw new ArgumentNullException("SelectedCentreCode");
            }
            int id = 0;
            bool isValid = Int32.TryParse(SelectedCentreCode, out id);
            var university = GetListOrganisationUniversityMaster(SelectedCentreCode);
            var result = (from s in university
                          select new
                          {
                              id = s.ID,
                              name = s.UniversityName,
                          }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region Methods
        public IEnumerable<OrganisationSubjectMasterViewModel> GetOrganisationSubjectMaster(string centerCode, int universityId, out int TotalRecords)
        {
            OrganisationSubjectMasterSearchRequest searchRequest = new OrganisationSubjectMasterSearchRequest();
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

                    searchRequest.UniversityID = universityId;
                }
                if (actionModeEnum == ActionModeEnum.Update)
                {
                    searchRequest.SortBy = "ModifiedDate";
                    searchRequest.StartRow = 0;
                    searchRequest.EndRow = 10;
                    searchRequest.SearchBy = string.Empty;
                    searchRequest.SortDirection = "Desc";

                    searchRequest.UniversityID = universityId;
                }
            }
            else
            {
                searchRequest.SortBy = _sortBy;                     // parameters for SelectAll procedures under normal condition
                searchRequest.StartRow = _startRow;
                searchRequest.EndRow = _startRow + _rowLength;
                searchRequest.SearchBy = _searchBy;
                searchRequest.SortDirection = _sortDirection;

                searchRequest.UniversityID = universityId;
            }
            List<OrganisationSubjectMasterViewModel> listOrganisationSubjectMasterViewModel = new List<OrganisationSubjectMasterViewModel>();
            List<OrganisationSubjectMaster> listOrganisationSubjectMaster = new List<OrganisationSubjectMaster>();
            IBaseEntityCollectionResponse<OrganisationSubjectMaster> baseEntityCollectionResponse = _organisationSubjectMasterServiceAcess.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listOrganisationSubjectMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (OrganisationSubjectMaster item in listOrganisationSubjectMaster)
                    {
                        OrganisationSubjectMasterViewModel organisationMediumMasterViewModel = new OrganisationSubjectMasterViewModel();
                        organisationMediumMasterViewModel.OrganisationSubjectMasterDTO = item;
                        listOrganisationSubjectMasterViewModel.Add(organisationMediumMasterViewModel);
                    }
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listOrganisationSubjectMasterViewModel;
        }
        #endregion

        #region AjaxHandler
        public ActionResult AjaxHandler(JQueryDataTableParamModel param, string SelectedCentreCode, string SelectedUniversityID)
        {
            int TotalRecords;
            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc

            IEnumerable<OrganisationSubjectMasterViewModel> filteredOrganisationSubjectMaster;
            switch (Convert.ToInt32(sortColumnIndex))
            {
                case 0:
                    _sortBy = "Descriptions";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "Descriptions Like '%" + param.sSearch + "%' or SubjectCode Like '%" + param.sSearch + "%' or PaperCode Like '%" + param.sSearch + "%' or SubjectIntroYear Like '%" + param.sSearch + "%' ";        //this "if" block is added for search functionality
                    }
                    break;
                case 1:
                    _sortBy = "SubjectCode";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "Descriptions Like '%" + param.sSearch + "%' or SubjectCode Like '%" + param.sSearch + "%' or PaperCode Like '%" + param.sSearch + "%' or SubjectIntroYear Like '%" + param.sSearch + "%' ";        //this "if" block is added for search functionality
                    }
                    break;
                case 2:
                    _sortBy = "PaperCode";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "Descriptions Like '%" + param.sSearch + "%' or SubjectCode Like '%" + param.sSearch + "%' or PaperCode Like '%" + param.sSearch + "%' or SubjectIntroYear Like '%" + param.sSearch + "%' ";        //this "if" block is added for search functionality
                    }
                    break;
                case 3:
                    _sortBy = "SubjectIntroYear";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "Descriptions Like '%" + param.sSearch + "%' or SubjectCode Like '%" + param.sSearch + "%' or PaperCode Like '%" + param.sSearch + "%' or SubjectIntroYear Like '%" + param.sSearch + "%' ";        //this "if" block is added for search functionality
                    }
                    break;
            }
            _sortDirection = sortDirection;
            _rowLength = param.iDisplayLength;
            _startRow = param.iDisplayStart;
            if (!string.IsNullOrEmpty(SelectedCentreCode) && !string.IsNullOrEmpty(SelectedUniversityID))
            {
                filteredOrganisationSubjectMaster = GetOrganisationSubjectMaster(SelectedCentreCode, Convert.ToInt32(SelectedUniversityID), out TotalRecords);
            }
            else
            {
                filteredOrganisationSubjectMaster = new List<OrganisationSubjectMasterViewModel>();
                TotalRecords = 0;
            }
            var records = filteredOrganisationSubjectMaster.Skip(0).Take(param.iDisplayLength);
            var result = from c in records select new[] { c.Descriptions.ToString(), c.SubjectCode.ToString(), c.PaperCode.ToString(), c.SubjectIntroYear.ToString(), Convert.ToString(c.ID) };

            return Json(new { sEcho = param.sEcho, iTotalRecords = TotalRecords, iTotalDisplayRecords = TotalRecords, aaData = result }, JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}