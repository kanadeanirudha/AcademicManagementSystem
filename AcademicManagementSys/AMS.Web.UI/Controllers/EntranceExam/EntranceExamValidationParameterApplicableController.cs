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
    public class EntranceExamValidationParameterApplicableController : BaseController
    {
        IEntranceExamValidationParameterApplicableServiceAccess _EntranceExamValidationParameterApplicableServiceAcess = null;
        StudentSelfRegistrationViewModel _StudentSelfRegistrationViewModel = null;
        IStudentSelfRegistrationServiceAccess _StudentSelfRegistrationServiceAccess = null;

        private readonly ILogger _logException;
        ActionModeEnum actionModeEnum;
        string _actionMode = string.Empty;
        string _sortBy = string.Empty;
        string _searchBy = string.Empty;
        string _sortDirection = string.Empty;
        int _startRow;
        int _rowLength;
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

        public EntranceExamValidationParameterApplicableController()
        {
            _EntranceExamValidationParameterApplicableServiceAcess = new EntranceExamValidationParameterApplicableServiceAccess();
            _StudentSelfRegistrationViewModel = new StudentSelfRegistrationViewModel();
            _StudentSelfRegistrationServiceAccess = new StudentSelfRegistrationServiceAccess();

        }

        // Controller Methods
        #region Controller Methods
        public ActionResult Index()
        {
                return View("/Views/EntranceExam/EntranceExamValidationParameterApplicable/Index.cshtml");
        }

        public ActionResult List(string actionMode, string CentreCode)
        {
            try
            {
                EntranceExamValidationParameterApplicableViewModel model = new EntranceExamValidationParameterApplicableViewModel();
                //list
                _StudentSelfRegistrationViewModel = new StudentSelfRegistrationViewModel();
                _StudentSelfRegistrationViewModel.ListOrgStudyCentreMaster = GetListOrgStudyCentreMasterOfApplicableToStudentTemplate("true");
                List<SelectListItem> OrganisationStudyCentreMaster = new List<SelectListItem>();
                foreach (StudentSelfRegistration item in _StudentSelfRegistrationViewModel.ListOrgStudyCentreMaster)
                {
                    OrganisationStudyCentreMaster.Add(new SelectListItem { Text = item.CentreName.ToString(), Value = item.CenterCode.ToString() });
                }
                ViewBag.StudyCentreList = new SelectList(OrganisationStudyCentreMaster, "Value", "Text");
                //string[] vcentreCode = model.CentreCode.Split(':');
                //endlist
                model.CentreCode = CentreCode;

                if (!string.IsNullOrEmpty(CentreCode))
                {
                    string[] splitCentreCode = CentreCode.Split(':');
                    // model.ListOrganisationUniversityMaster = GetListOrganisationUniversityMaster(splitCentreCode[0]);
                    List<OrganisationCentrewiseSession> list = GetCurrentSession(CentreCode);
                    model.SessionName = list.Count > 0 ? list[0].SessionName : "Session not defined !";
                    model.SessionID = list.Count > 0 ? list[0].SessionID : 0;
                }
                else
                {
                    // List<OrganisationCentrewiseSession> list = GetCurrentSession(model.ListGetAdminRoleApplicableCentre[0].CentreCode);
                    model.SessionName = "Session not defined !";
                    model.SessionID = 0;
                }
                if (!string.IsNullOrEmpty(actionMode))
                {
                    TempData["ActionMode"] = actionMode;
                }
                return PartialView("/Views/EntranceExam/EntranceExamValidationParameterApplicable/List.cshtml", model);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
            
        }


        [HttpGet]
        public ActionResult Create(int ID, string FeeCriteriaValueCombinationDescription,int FeeCriteriaValueCombinationMasterID)
        {
            EntranceExamValidationParameterApplicableViewModel model = new EntranceExamValidationParameterApplicableViewModel();
            model.EntranceExamValidationParameterApplicableDTO.FeeCriteriaValueCombinationDescription = FeeCriteriaValueCombinationDescription.Replace('~', ' ');
            
            return PartialView("/Views/EntranceExam/EntranceExamValidationParameterApplicable/Create.cshtml", model);
        }

        [HttpPost]
        public ActionResult Create(EntranceExamValidationParameterApplicableViewModel model)
        {
            try
            {
                
                
                    if (model != null && model.EntranceExamValidationParameterApplicableDTO != null)
                    {
                        model.EntranceExamValidationParameterApplicableDTO.ConnectionString = _connectioString;
                       
                        //model.EntranceExamValidationParameterApplicableDTO.FeeCriteriaValueCombinationDescription = model.FeeCriteriaValueCombinationDescription; ;
                        model.EntranceExamValidationParameterApplicableDTO.EntranceExamCutOff = model.EntranceExamCutOff;
                        model.EntranceExamValidationParameterApplicableDTO.EntranceExamFeeAmount = model.EntranceExamFeeAmount;
                        model.EntranceExamValidationParameterApplicableDTO.PreQualificationCutOff = model.PreQualificationCutOff;
                        model.EntranceExamValidationParameterApplicableDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                        IBaseEntityResponse<EntranceExamValidationParameterApplicable> response = _EntranceExamValidationParameterApplicableServiceAcess.InsertEntranceExamValidationParameterApplicable(model.EntranceExamValidationParameterApplicableDTO);
                        model.EntranceExamValidationParameterApplicableDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20 , ActionModeEnum.Insert);
                        return Json(model.EntranceExamValidationParameterApplicableDTO.errorMessage, JsonRequestBehavior.AllowGet);
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
        public ActionResult Edit(int id, string FeeCriteriaValueCombinationDescription, int FeeCriteriaValueCombinationMasterID)
        {
            EntranceExamValidationParameterApplicableViewModel model = new EntranceExamValidationParameterApplicableViewModel();
            try
            {                
                model.EntranceExamValidationParameterApplicableDTO = new EntranceExamValidationParameterApplicable();
                model.EntranceExamValidationParameterApplicableDTO.ID = id;
                model.EntranceExamValidationParameterApplicableDTO.FeeCriteriaValueCombinationDescription = FeeCriteriaValueCombinationDescription.Replace('~', ' ');
                
                model.EntranceExamValidationParameterApplicableDTO.ConnectionString = _connectioString;

                IBaseEntityResponse<EntranceExamValidationParameterApplicable> response = _EntranceExamValidationParameterApplicableServiceAcess.SelectByID(model.EntranceExamValidationParameterApplicableDTO);
                if (response != null && response.Entity != null)
                {
                    model.EntranceExamValidationParameterApplicableDTO.ID = response.Entity.ID;
                   // model.EntranceExamValidationParameterApplicableDTO.FeeCriteriaValueCombinationMasterID = response.Entity.FeeCriteriaValueCombinationMasterID;
                   // model.EntranceExamValidationParameterApplicableDTO.FeeCriteriaValueCombinationDescription = response.Entity.FeeCriteriaValueCombinationDescription;
                    model.EntranceExamValidationParameterApplicableDTO.PreQualificationCutOff = response.Entity.PreQualificationCutOff;
                    model.EntranceExamValidationParameterApplicableDTO.EntranceExamFeeAmount = response.Entity.EntranceExamFeeAmount;
                    model.EntranceExamValidationParameterApplicableDTO.EntranceExamCutOff = response.Entity.EntranceExamCutOff;
                    model.EntranceExamValidationParameterApplicableDTO.CreatedBy = response.Entity.CreatedBy;
                }
                return PartialView("/Views/EntranceExam/EntranceExamValidationParameterApplicable/Edit.cshtml", model);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public ActionResult Edit(EntranceExamValidationParameterApplicableViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model != null && model.EntranceExamValidationParameterApplicableDTO != null)
                {
                    if (model != null && model.EntranceExamValidationParameterApplicableDTO != null)
                    {
                        model.EntranceExamValidationParameterApplicableDTO.ConnectionString = _connectioString;
                       
                        model.EntranceExamValidationParameterApplicableDTO.FeeCriteriaValueCombinationDescription = model.FeeCriteriaValueCombinationDescription; ;
                        model.EntranceExamValidationParameterApplicableDTO.EntranceExamCutOff = model.EntranceExamCutOff;
                        model.EntranceExamValidationParameterApplicableDTO.EntranceExamFeeAmount = model.EntranceExamFeeAmount;
                        model.EntranceExamValidationParameterApplicableDTO.PreQualificationCutOff = model.PreQualificationCutOff;
                        model.EntranceExamValidationParameterApplicableDTO.ModifiedBy = Convert.ToInt32(Session["UserID"]);
                        IBaseEntityResponse<EntranceExamValidationParameterApplicable> response = _EntranceExamValidationParameterApplicableServiceAcess.UpdateEntranceExamValidationParameterApplicable(model.EntranceExamValidationParameterApplicableDTO);
                        model.EntranceExamValidationParameterApplicableDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Update);
                    }
                }
                return Json(model.EntranceExamValidationParameterApplicableDTO.errorMessage, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("Please review your form");
            }
        }

        [HttpGet]
        public ActionResult Delete(int ID)
        {
            EntranceExamValidationParameterApplicableViewModel model = new EntranceExamValidationParameterApplicableViewModel();
            model.EntranceExamValidationParameterApplicableDTO = new EntranceExamValidationParameterApplicable();
            model.EntranceExamValidationParameterApplicableDTO.ID = ID;
            return PartialView("/Views/EntranceExam/EntranceExamValidationParameterApplicable/Delete.cshtml", model);
        }

        [HttpPost]
        public ActionResult Delete(EntranceExamValidationParameterApplicableViewModel model)
        {
            if (!ModelState.IsValid)
            {
                if (model.ID > 0)
                {
                    EntranceExamValidationParameterApplicable EntranceExamValidationParameterApplicableDTO = new EntranceExamValidationParameterApplicable();
                    EntranceExamValidationParameterApplicableDTO.ConnectionString = _connectioString;
                    EntranceExamValidationParameterApplicableDTO.ID = model.ID;
                    EntranceExamValidationParameterApplicableDTO.DeletedBy = Convert.ToInt32(Session["UserID"]);
                    IBaseEntityResponse<EntranceExamValidationParameterApplicable> response = _EntranceExamValidationParameterApplicableServiceAcess.DeleteEntranceExamValidationParameterApplicable(EntranceExamValidationParameterApplicableDTO);
                    model.EntranceExamValidationParameterApplicableDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Delete);

                }
                return Json(model.EntranceExamValidationParameterApplicableDTO.errorMessage, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("Please review your form");
            }
        }
        #endregion

        // Non-Action Method
        #region Methods

        protected List<StudentSelfRegistration> GetListOrgStudyCentreMasterOfApplicableToStudentTemplate(string ApplicableForEntranceExam)
        {

            StudentSelfRegistrationSearchRequest searchRequest = new StudentSelfRegistrationSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.ApplicableForEntranceExam = ApplicableForEntranceExam;
            List<StudentSelfRegistration> listOrganisationStudyCentreMaster = new List<StudentSelfRegistration>();
            IBaseEntityCollectionResponse<StudentSelfRegistration> baseEntityCollectionResponse = _StudentSelfRegistrationServiceAccess.GetListOrgStudyCentreMasterOfApplicableToStudentTemplate(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listOrganisationStudyCentreMaster = baseEntityCollectionResponse.CollectionResponse.ToList();

                }
            }
            return listOrganisationStudyCentreMaster;
        }


        public IEnumerable<EntranceExamValidationParameterApplicableViewModel> GetEntranceExamValidationParameterApplicable(out int TotalRecords, string CentreCode, string CurrentSessionID)
        {
            EntranceExamValidationParameterApplicableSearchRequest searchRequest = new EntranceExamValidationParameterApplicableSearchRequest();
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
                }
                if (actionModeEnum == ActionModeEnum.Update)
                {
                    searchRequest.SortBy = "ModifiedDate";
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

                string[] Centre_code = CentreCode.Split(':');
                searchRequest.CentreCode = Centre_code[0];
                //  searchRequest.ScopeIdentity = Centre_code[1];
                searchRequest.SessionID = Convert.ToInt32(CurrentSessionID);

            }
            List<EntranceExamValidationParameterApplicableViewModel> listEntranceExamValidationParameterApplicableViewModel = new List<EntranceExamValidationParameterApplicableViewModel>();
            List<EntranceExamValidationParameterApplicable> listEntranceExamValidationParameterApplicable = new List<EntranceExamValidationParameterApplicable>();
            IBaseEntityCollectionResponse<EntranceExamValidationParameterApplicable> baseEntityCollectionResponse = _EntranceExamValidationParameterApplicableServiceAcess.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listEntranceExamValidationParameterApplicable = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (EntranceExamValidationParameterApplicable item in listEntranceExamValidationParameterApplicable)
                    {
                        EntranceExamValidationParameterApplicableViewModel EntranceExamValidationParameterApplicableViewModel = new EntranceExamValidationParameterApplicableViewModel();
                        EntranceExamValidationParameterApplicableViewModel.EntranceExamValidationParameterApplicableDTO = item;
                        listEntranceExamValidationParameterApplicableViewModel.Add(EntranceExamValidationParameterApplicableViewModel);
                    }
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listEntranceExamValidationParameterApplicableViewModel;
        }
        #endregion

        // AjaxHandler Method
        #region AjaxHandler
        public ActionResult AjaxHandler(JQueryDataTableParamModel param, string CentreCode, string CurrentSessionID)
        {
            if (Session["UserType"] != null)
            {
                int TotalRecords;
                var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
                string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc

                IEnumerable<EntranceExamValidationParameterApplicableViewModel> filteredCountryMaster;
                switch (Convert.ToInt32(sortColumnIndex))
                {
                    case 0:
                        _sortBy = "FeeCriteriaValueCombinationDescription";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            _searchBy = "FeeCriteriaValueCombinationDescription Like '%" + param.sSearch + "%' or FeeCriteriaValueCombinationDescription Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                        }
                        break;
                    case 1:
                        _sortBy = "EntranceExamFeeAmount";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            _searchBy = "FeeCriteriaValueCombinationDescription Like '%" + param.sSearch + "%' or FeeCriteriaValueCombinationDescription Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                        }
                        break;
                   
                    
                }
                _sortDirection = sortDirection;
                _rowLength = param.iDisplayLength;
                _startRow = param.iDisplayStart;
               // filteredCountryMaster = GetEntranceExamValidationParameterApplicable(out TotalRecords);

                if (!string.IsNullOrEmpty(CentreCode) && !string.IsNullOrEmpty(CurrentSessionID))
                {
                    filteredCountryMaster = GetEntranceExamValidationParameterApplicable(out TotalRecords, CentreCode, CurrentSessionID);
                }
                else
                {
                    filteredCountryMaster = new List<EntranceExamValidationParameterApplicableViewModel>();
                    TotalRecords = 0;
                }



                var records = filteredCountryMaster.Skip(0).Take(param.iDisplayLength);
                var result = from c in records select new[] { Convert.ToString(c.FeeCriteriaValueCombinationDescription), Convert.ToString(c.PreQualificationCutOff), Convert.ToString(c.EntranceExamFeeAmount), Convert.ToString(c.EntranceExamCutOff), Convert.ToString(c.ID) };

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