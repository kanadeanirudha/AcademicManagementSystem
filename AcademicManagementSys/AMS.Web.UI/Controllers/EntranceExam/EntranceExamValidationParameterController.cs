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
    public class EntranceExamValidationParameterController : BaseController
    {
        IEntranceExamValidationParameterServiceAccess _EntranceExamValidationParameterServiceAcess = null;
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

        public EntranceExamValidationParameterController()
        {
            _EntranceExamValidationParameterServiceAcess = new EntranceExamValidationParameterServiceAccess();
            _StudentSelfRegistrationViewModel = new StudentSelfRegistrationViewModel();
            _StudentSelfRegistrationServiceAccess = new StudentSelfRegistrationServiceAccess();

        }

        // Controller Methods
        #region Controller Methods
        public ActionResult Index()
        {
                return View("/Views/EntranceExam/EntranceExamValidationParameter/Index.cshtml");
        }

        public ActionResult List(string actionMode, string CentreCode)
        {
            try
            {
                EntranceExamValidationParameterViewModel model = new EntranceExamValidationParameterViewModel();
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
                return PartialView("/Views/EntranceExam/EntranceExamValidationParameter/List.cshtml", model);
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
            EntranceExamValidationParameterViewModel model = new EntranceExamValidationParameterViewModel();
            model.EntranceExamValidationParameterDTO.FeeCriteriaValueCombinationDescription = FeeCriteriaValueCombinationDescription.Replace('~', ' ');
            model.EntranceExamValidationParameterDTO.FeeCriteriaValueCombinationMasterID = FeeCriteriaValueCombinationMasterID;
            return PartialView("/Views/EntranceExam/EntranceExamValidationParameter/Create.cshtml", model);
        }

        [HttpPost]
        public ActionResult Create(EntranceExamValidationParameterViewModel model)
        {
            try
            {
                
                
                    if (model != null && model.EntranceExamValidationParameterDTO != null)
                    {
                        model.EntranceExamValidationParameterDTO.ConnectionString = _connectioString;
                        model.EntranceExamValidationParameterDTO.FeeCriteriaValueCombinationMasterID = model.FeeCriteriaValueCombinationMasterID;
                        //model.EntranceExamValidationParameterDTO.FeeCriteriaValueCombinationDescription = model.FeeCriteriaValueCombinationDescription; ;
                        model.EntranceExamValidationParameterDTO.EntranceExamCutOff = model.EntranceExamCutOff;
                        model.EntranceExamValidationParameterDTO.EntranceExamFeeAmount = model.EntranceExamFeeAmount;
                        model.EntranceExamValidationParameterDTO.PreQualificationCutOff = model.PreQualificationCutOff;
                        model.EntranceExamValidationParameterDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                        IBaseEntityResponse<EntranceExamValidationParameter> response = _EntranceExamValidationParameterServiceAcess.InsertEntranceExamValidationParameter(model.EntranceExamValidationParameterDTO);
                        model.EntranceExamValidationParameterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20 , ActionModeEnum.Insert);
                        return Json(model.EntranceExamValidationParameterDTO.errorMessage, JsonRequestBehavior.AllowGet);
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
            EntranceExamValidationParameterViewModel model = new EntranceExamValidationParameterViewModel();
            try
            {                
                model.EntranceExamValidationParameterDTO = new EntranceExamValidationParameter();
                model.EntranceExamValidationParameterDTO.ID = id;
                model.EntranceExamValidationParameterDTO.FeeCriteriaValueCombinationDescription = FeeCriteriaValueCombinationDescription.Replace('~', ' ');
                model.EntranceExamValidationParameterDTO.FeeCriteriaValueCombinationMasterID = FeeCriteriaValueCombinationMasterID;
                model.EntranceExamValidationParameterDTO.ConnectionString = _connectioString;

                IBaseEntityResponse<EntranceExamValidationParameter> response = _EntranceExamValidationParameterServiceAcess.SelectByID(model.EntranceExamValidationParameterDTO);
                if (response != null && response.Entity != null)
                {
                    model.EntranceExamValidationParameterDTO.ID = response.Entity.ID;
                   // model.EntranceExamValidationParameterDTO.FeeCriteriaValueCombinationMasterID = response.Entity.FeeCriteriaValueCombinationMasterID;
                   // model.EntranceExamValidationParameterDTO.FeeCriteriaValueCombinationDescription = response.Entity.FeeCriteriaValueCombinationDescription;
                    model.EntranceExamValidationParameterDTO.PreQualificationCutOff = response.Entity.PreQualificationCutOff;
                    model.EntranceExamValidationParameterDTO.EntranceExamFeeAmount = response.Entity.EntranceExamFeeAmount;
                    model.EntranceExamValidationParameterDTO.EntranceExamCutOff = response.Entity.EntranceExamCutOff;
                    model.EntranceExamValidationParameterDTO.CreatedBy = response.Entity.CreatedBy;
                }
                return PartialView("/Views/EntranceExam/EntranceExamValidationParameter/Edit.cshtml", model);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public ActionResult Edit(EntranceExamValidationParameterViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model != null && model.EntranceExamValidationParameterDTO != null)
                {
                    if (model != null && model.EntranceExamValidationParameterDTO != null)
                    {
                        model.EntranceExamValidationParameterDTO.ConnectionString = _connectioString;
                        model.EntranceExamValidationParameterDTO.FeeCriteriaValueCombinationMasterID = model.FeeCriteriaValueCombinationMasterID;
                        model.EntranceExamValidationParameterDTO.FeeCriteriaValueCombinationDescription = model.FeeCriteriaValueCombinationDescription; ;
                        model.EntranceExamValidationParameterDTO.EntranceExamCutOff = model.EntranceExamCutOff;
                        model.EntranceExamValidationParameterDTO.EntranceExamFeeAmount = model.EntranceExamFeeAmount;
                        model.EntranceExamValidationParameterDTO.PreQualificationCutOff = model.PreQualificationCutOff;
                        model.EntranceExamValidationParameterDTO.ModifiedBy = Convert.ToInt32(Session["UserID"]);
                        IBaseEntityResponse<EntranceExamValidationParameter> response = _EntranceExamValidationParameterServiceAcess.UpdateEntranceExamValidationParameter(model.EntranceExamValidationParameterDTO);
                        model.EntranceExamValidationParameterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Update);
                    }
                }
                return Json(model.EntranceExamValidationParameterDTO.errorMessage, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("Please review your form");
            }
        }

        [HttpGet]
        public ActionResult Delete(int ID)
        {
            EntranceExamValidationParameterViewModel model = new EntranceExamValidationParameterViewModel();
            model.EntranceExamValidationParameterDTO = new EntranceExamValidationParameter();
            model.EntranceExamValidationParameterDTO.ID = ID;
            return PartialView("/Views/EntranceExam/EntranceExamValidationParameter/Delete.cshtml", model);
        }

        [HttpPost]
        public ActionResult Delete(EntranceExamValidationParameterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                if (model.ID > 0)
                {
                    EntranceExamValidationParameter EntranceExamValidationParameterDTO = new EntranceExamValidationParameter();
                    EntranceExamValidationParameterDTO.ConnectionString = _connectioString;
                    EntranceExamValidationParameterDTO.ID = model.ID;
                    EntranceExamValidationParameterDTO.DeletedBy = Convert.ToInt32(Session["UserID"]);
                    IBaseEntityResponse<EntranceExamValidationParameter> response = _EntranceExamValidationParameterServiceAcess.DeleteEntranceExamValidationParameter(EntranceExamValidationParameterDTO);
                    model.EntranceExamValidationParameterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Delete);

                }
                return Json(model.EntranceExamValidationParameterDTO.errorMessage, JsonRequestBehavior.AllowGet);
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


        public IEnumerable<EntranceExamValidationParameterViewModel> GetEntranceExamValidationParameter(out int TotalRecords)
        {
            EntranceExamValidationParameterSearchRequest searchRequest = new EntranceExamValidationParameterSearchRequest();
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

               
            }
            List<EntranceExamValidationParameterViewModel> listEntranceExamValidationParameterViewModel = new List<EntranceExamValidationParameterViewModel>();
            List<EntranceExamValidationParameter> listEntranceExamValidationParameter = new List<EntranceExamValidationParameter>();
            IBaseEntityCollectionResponse<EntranceExamValidationParameter> baseEntityCollectionResponse = _EntranceExamValidationParameterServiceAcess.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listEntranceExamValidationParameter = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (EntranceExamValidationParameter item in listEntranceExamValidationParameter)
                    {
                        EntranceExamValidationParameterViewModel EntranceExamValidationParameterViewModel = new EntranceExamValidationParameterViewModel();
                        EntranceExamValidationParameterViewModel.EntranceExamValidationParameterDTO = item;
                        listEntranceExamValidationParameterViewModel.Add(EntranceExamValidationParameterViewModel);
                    }
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listEntranceExamValidationParameterViewModel;
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

                IEnumerable<EntranceExamValidationParameterViewModel> filteredCountryMaster;
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
                filteredCountryMaster = GetEntranceExamValidationParameter(out TotalRecords);
                var records = filteredCountryMaster.Skip(0).Take(param.iDisplayLength);
                var result = from c in records select new[] { Convert.ToString(c.FeeCriteriaValueCombinationDescription), Convert.ToString(c.PreQualificationCutOff), Convert.ToString(c.EntranceExamFeeAmount), Convert.ToString(c.EntranceExamCutOff), Convert.ToString(c.FeeCriteriaValueCombinationMasterID), Convert.ToString(c.ID) };

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