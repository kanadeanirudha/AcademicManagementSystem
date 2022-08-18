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
    public class EntranceExamApplicableExamToCourseController : BaseController
    {
        IEntranceExamApplicableExamToCourseServiceAccess _EntranceExamApplicableExamToCourseServiceAcess = null;
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

        public EntranceExamApplicableExamToCourseController()
        {
            _EntranceExamApplicableExamToCourseServiceAcess = new EntranceExamApplicableExamToCourseServiceAccess();
            _StudentSelfRegistrationViewModel = new StudentSelfRegistrationViewModel();
            _StudentSelfRegistrationServiceAccess = new StudentSelfRegistrationServiceAccess();

        }

        // Controller Methods
        #region Controller Methods
        public ActionResult Index()
        {
            return View("/Views/EntranceExam/EntranceExamApplicableExamToCourse/Index.cshtml");
        }

        public ActionResult List(string actionMode, string CentreCode)
        {
            try
            {
                EntranceExamApplicableExamToCourseViewModel model = new EntranceExamApplicableExamToCourseViewModel();

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
                return PartialView("/Views/EntranceExam/EntranceExamApplicableExamToCourse/List.cshtml", model);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
            
        }


        [HttpGet]
        public ActionResult Create(string EntranceExamApplicableExamToCourseString,string CentreCode )
        {
            EntranceExamApplicableExamToCourseViewModel model = new EntranceExamApplicableExamToCourseViewModel();

            string[] TemplateStringArrays = EntranceExamApplicableExamToCourseString.Split('~');
            model.EntranceExamApplicableExamToCourseDTO.CourseYearDetailID = Convert.ToInt32(TemplateStringArrays[2]);
            model.EntranceExamApplicableExamToCourseDTO.CourseName = TemplateStringArrays[3].Replace('$', ' ');
            model.EntranceExamApplicableExamToCourseDTO.SessionID = Convert.ToInt32(TemplateStringArrays[4]);
          
            string[] CentreCodeArrays = CentreCode.Split('~');
            string[] CentreArray = CentreCodeArrays[0].Split(':');
            model.EntranceExamApplicableExamToCourseDTO.CentreCode = CentreCodeArrays[0];
            model.EntranceExamApplicableExamToCourseDTO.CentreName = CentreCodeArrays[1].Replace('$', ' ');

            


            return PartialView("/Views/EntranceExam/EntranceExamApplicableExamToCourse/Create.cshtml", model);
        }

        [HttpPost]
        public ActionResult Create(EntranceExamApplicableExamToCourseViewModel model)
        {
            try
            {
                    if (model != null && model.EntranceExamApplicableExamToCourseDTO != null)
                    {
                        model.EntranceExamApplicableExamToCourseDTO.ConnectionString = _connectioString;
                        model.EntranceExamApplicableExamToCourseDTO.ExaminationName = model.ExaminationName;
                        model.EntranceExamApplicableExamToCourseDTO.CourseYearDetailID = model.CourseYearDetailID; 
                        model.EntranceExamApplicableExamToCourseDTO.ExaminationFromDate = model.ExaminationFromDate;
                        model.EntranceExamApplicableExamToCourseDTO.ExaminationUpToDate = model.ExaminationUpToDate;
                        model.EntranceExamApplicableExamToCourseDTO.CourseName = model.CourseName;
                        model.EntranceExamApplicableExamToCourseDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                        IBaseEntityResponse<EntranceExamApplicableExamToCourse> response = _EntranceExamApplicableExamToCourseServiceAcess.InsertEntranceExamApplicableExamToCourse(model.EntranceExamApplicableExamToCourseDTO);
                        model.EntranceExamApplicableExamToCourseDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20 , ActionModeEnum.Insert);
                        return Json(model.EntranceExamApplicableExamToCourseDTO.errorMessage, JsonRequestBehavior.AllowGet);
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
        public ActionResult Edit(int id, string CourseName)
        {
            EntranceExamApplicableExamToCourseViewModel model = new EntranceExamApplicableExamToCourseViewModel();
            try
            {                
                model.EntranceExamApplicableExamToCourseDTO = new EntranceExamApplicableExamToCourse();
                model.EntranceExamApplicableExamToCourseDTO.ID = id;
                model.EntranceExamApplicableExamToCourseDTO.CourseName = CourseName;
                model.EntranceExamApplicableExamToCourseDTO.ConnectionString = _connectioString;

                IBaseEntityResponse<EntranceExamApplicableExamToCourse> response = _EntranceExamApplicableExamToCourseServiceAcess.SelectByID(model.EntranceExamApplicableExamToCourseDTO);
                if (response != null && response.Entity != null)
                {
                    model.EntranceExamApplicableExamToCourseDTO.ID = response.Entity.ID;
                    model.EntranceExamApplicableExamToCourseDTO.CourseYearDetailID = response.Entity.CourseYearDetailID;
                    model.EntranceExamApplicableExamToCourseDTO.SessionID = response.Entity.SessionID;
                    model.EntranceExamApplicableExamToCourseDTO.ExaminationName = response.Entity.ExaminationName;
                    model.EntranceExamApplicableExamToCourseDTO.CentreCode = response.Entity.CentreCode;
                    model.EntranceExamApplicableExamToCourseDTO.ExaminationFromDate = response.Entity.ExaminationFromDate;
                    model.EntranceExamApplicableExamToCourseDTO.ExaminationUpToDate = response.Entity.ExaminationUpToDate;
                    model.EntranceExamApplicableExamToCourseDTO.OnlineExamExaminationMasterID = response.Entity.OnlineExamExaminationMasterID;
                   
                    model.EntranceExamApplicableExamToCourseDTO.CreatedBy = response.Entity.CreatedBy;
                }
                return PartialView("/Views/EntranceExam/EntranceExamApplicableExamToCourse/Edit.cshtml", model);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public ActionResult Edit(EntranceExamApplicableExamToCourseViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model != null && model.EntranceExamApplicableExamToCourseDTO != null)
                {
                    if (model != null && model.EntranceExamApplicableExamToCourseDTO != null)
                    {
                        model.EntranceExamApplicableExamToCourseDTO.ConnectionString = _connectioString;
                        //model.EntranceExamApplicableExamToCourseDTO.FeeCriteriaParametersDescription = model.FeeCriteriaParametersDescription;
                        //model.EntranceExamApplicableExamToCourseDTO.FeeCriteriaParametersCode = model.FeeCriteriaParametersCode; ;
                        //model.EntranceExamApplicableExamToCourseDTO.TableEntityName = model.TableEntityName;
                        //model.EntranceExamApplicableExamToCourseDTO.PrimaryKeyFieldName = model.PrimaryKeyFieldName;
                        //model.EntranceExamApplicableExamToCourseDTO.DisplayKeyFieldName = model.DisplayKeyFieldName;
                        model.EntranceExamApplicableExamToCourseDTO.ModifiedBy = Convert.ToInt32(Session["UserID"]);
                        IBaseEntityResponse<EntranceExamApplicableExamToCourse> response = _EntranceExamApplicableExamToCourseServiceAcess.UpdateEntranceExamApplicableExamToCourse(model.EntranceExamApplicableExamToCourseDTO);
                        model.EntranceExamApplicableExamToCourseDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Update);
                    }
                }
                return Json(model.EntranceExamApplicableExamToCourseDTO.errorMessage, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("Please review your form");
            }
        }

        [HttpGet]
        public ActionResult Delete(int ID)
        {
            EntranceExamApplicableExamToCourseViewModel model = new EntranceExamApplicableExamToCourseViewModel();
            model.EntranceExamApplicableExamToCourseDTO = new EntranceExamApplicableExamToCourse();
            model.EntranceExamApplicableExamToCourseDTO.ID = ID;
            return PartialView("/Views/EntranceExam/EntranceExamApplicableExamToCourse/Delete.cshtml", model);
        }

        [HttpPost]
        public ActionResult Delete(EntranceExamApplicableExamToCourseViewModel model)
        {
            if (!ModelState.IsValid)
            {
                if (model.ID > 0)
                {
                    EntranceExamApplicableExamToCourse EntranceExamApplicableExamToCourseDTO = new EntranceExamApplicableExamToCourse();
                    EntranceExamApplicableExamToCourseDTO.ConnectionString = _connectioString;
                    EntranceExamApplicableExamToCourseDTO.ID = model.ID;
                    EntranceExamApplicableExamToCourseDTO.DeletedBy = Convert.ToInt32(Session["UserID"]);
                    IBaseEntityResponse<EntranceExamApplicableExamToCourse> response = _EntranceExamApplicableExamToCourseServiceAcess.DeleteEntranceExamApplicableExamToCourse(EntranceExamApplicableExamToCourseDTO);
                    model.EntranceExamApplicableExamToCourseDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Delete);

                }
                return Json(model.EntranceExamApplicableExamToCourseDTO.errorMessage, JsonRequestBehavior.AllowGet);
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


        public IEnumerable<EntranceExamApplicableExamToCourseViewModel> GetEntranceExamApplicableExamToCourse(out int TotalRecords, string CentreCode, string CurrentSessionID)
        {
            EntranceExamApplicableExamToCourseSearchRequest searchRequest = new EntranceExamApplicableExamToCourseSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            _actionMode = Convert.ToString(TempData["ActionMode"]);
            if (Enum.TryParse(_actionMode, out actionModeEnum))     // checks actionMode i.e. Insert or Update // 
            {
                if (actionModeEnum == ActionModeEnum.Insert)        // parameters for SelectAll procedures under Insert or Update mode condition
                {
                    searchRequest.SortBy = "CreatedDate";
                    searchRequest.StartRow = 0;
                    searchRequest.EndRow = 10;
                    searchRequest.SearchBy = "CourseYearCode like '%'";
                    searchRequest.SortDirection = "Desc";

                    string[] Centre_code = CentreCode.Split(':');
                    searchRequest.CentreCode = Centre_code[0];
                    //searchRequest.CentreName = Centre_code[1];
                    searchRequest.SessionID = Convert.ToInt32(CurrentSessionID);
                }
                if (actionModeEnum == ActionModeEnum.Update)
                {
                    searchRequest.SortBy = "ModifiedDate";
                    searchRequest.StartRow = 0;
                    searchRequest.EndRow = 10;
                    searchRequest.SearchBy = "CourseYearCode like '%'";
                    searchRequest.SortDirection = "Desc";

                    string[] Centre_code = CentreCode.Split(':');
                    searchRequest.CentreCode = Centre_code[0];
                    searchRequest.ScopeIdentity = Centre_code[1];
                    searchRequest.SessionID = Convert.ToInt32(CurrentSessionID);
                }
            }
            else
            {
                searchRequest.SortBy = _sortBy;                     // parameters for SelectAll procedures under normal condition
                searchRequest.StartRow = _startRow;
                searchRequest.EndRow = _startRow + _rowLength;
                searchRequest.SearchBy = _searchBy;
                searchRequest.SortDirection = "Desc";

                string[] Centre_code = CentreCode.Split(':');
                searchRequest.CentreCode = Centre_code[0];
              //  searchRequest.ScopeIdentity = Centre_code[1];
                searchRequest.SessionID = Convert.ToInt32(CurrentSessionID);

            }
  
            List<EntranceExamApplicableExamToCourseViewModel> listEntranceExamApplicableExamToCourseViewModel = new List<EntranceExamApplicableExamToCourseViewModel>();
            List<EntranceExamApplicableExamToCourse> listEntranceExamApplicableExamToCourse = new List<EntranceExamApplicableExamToCourse>();
            IBaseEntityCollectionResponse<EntranceExamApplicableExamToCourse> baseEntityCollectionResponse = _EntranceExamApplicableExamToCourseServiceAcess.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listEntranceExamApplicableExamToCourse = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (EntranceExamApplicableExamToCourse item in listEntranceExamApplicableExamToCourse)
                    {
                        EntranceExamApplicableExamToCourseViewModel EntranceExamApplicableExamToCourseViewModel = new EntranceExamApplicableExamToCourseViewModel();
                        EntranceExamApplicableExamToCourseViewModel.EntranceExamApplicableExamToCourseDTO = item;
                        listEntranceExamApplicableExamToCourseViewModel.Add(EntranceExamApplicableExamToCourseViewModel);
                    }
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listEntranceExamApplicableExamToCourseViewModel;
        }

        //searchlist of ExaminationName
        public JsonResult GetExaminationName(string term)
        {
            var data = GetExaminationNameByCourseID(term);
            var result = (from r in data select new { ExaminationName = r.ExaminationName, id = r.ID }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
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

                IEnumerable<EntranceExamApplicableExamToCourseViewModel> filteredCountryMaster;
                switch (Convert.ToInt32(sortColumnIndex))
                {
                    case 0:
                        _sortBy = "CreatedDate";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = "CourseYearCode like '%'";
                        }
                        else
                        {
                            _searchBy = "CourseYearCode Like '%" + param.sSearch + "%' or ExaminationName Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                        }
                        break;
                    case 1:
                        _sortBy = "CourseYearCode";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = "CourseYearCode like '%'";
                        }
                        else
                        {
                            _searchBy = "CourseYearCode Like '%" + param.sSearch + "%' or ExaminationName Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                        }
                        break;
                    case 2:
                        _sortBy = "ExaminationName";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = "CourseYearCode like '%'";
                        }
                        else
                        {
                            _searchBy = "CourseYearCode Like '%" + param.sSearch + "%' or ExaminationName Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                        }
                        break;
                   
                }
                _sortDirection = sortDirection;
                _rowLength = param.iDisplayLength;
                _startRow = param.iDisplayStart;

                if (!string.IsNullOrEmpty(CentreCode) && !string.IsNullOrEmpty(CurrentSessionID))
                {
                    filteredCountryMaster = GetEntranceExamApplicableExamToCourse(out TotalRecords, CentreCode, CurrentSessionID);
                }
                else
                {
                    filteredCountryMaster = new List<EntranceExamApplicableExamToCourseViewModel>();
                    TotalRecords = 0;
                }

                var records = filteredCountryMaster.Skip(0).Take(param.iDisplayLength);
                var result = from c in records select new[] { Convert.ToString(c.CourseName), Convert.ToString(c.ExaminationName), Convert.ToString(c.ExaminationFromDate), Convert.ToString(c.ExaminationUpToDate), Convert.ToString(c.ID), Convert.ToString(c.OnlineExamExaminationMasterID + "~" + c.ExaminationName + "~" + c.CourseYearDetailID + "~" + c.CourseName +"~" + c.SessionID),Convert.ToString(c.CourseName) };

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

        //public ActionResult GetAllSessionDetails(string CentreCode)
        //{
        //    string[] vcentreCode = CentreCode.Split(':');
        //    var OrganisationSessionDetails = GetCentreWiseSessionListRoleWise(vcentreCode[0], 1);
        //    var result = (from s in OrganisationSessionDetails
        //                  select new
        //                  {
        //                      id = s.SessionID,
        //                      name = s.SessionName,
        //                  }).ToList();
        //    return Json(result, JsonRequestBehavior.AllowGet);
        //}
    }
}