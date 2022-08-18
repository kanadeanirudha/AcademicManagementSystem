
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
    public class OnlineExamAssignpapersetterController : BaseController
    {
        IOnlineExamAssignpapersetterServiceAccess _OnlineExamAssignpapersetterServiceAcess = null;
        IGeneralPaperSetMasterServiceAccess _GeneralPaperSetMasterServiceAccess = null;
        IOnlineExamStudentApplicableServiceAccess _OnlineExamStudentApplicableServiceAccess = null;
        IOnlineExamExaminationQuePaperDetailsServiceAccess _OnlineExamExaminationQuePaperDetailsServiceAcess = null;



        private readonly ILogger _logException;
        ActionModeEnum actionModeEnum;
        string _actionMode = string.Empty;
        string _sortBy = string.Empty;
        string _searchBy = string.Empty;
        string _sortDirection = string.Empty;
        int _startRow;
        int _rowLength;
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

        public OnlineExamAssignpapersetterController()
        {
            _OnlineExamAssignpapersetterServiceAcess = new OnlineExamAssignpapersetterServiceAccess();
            _GeneralPaperSetMasterServiceAccess = new GeneralPaperSetMasterServiceAccess();
            _OnlineExamStudentApplicableServiceAccess = new OnlineExamStudentApplicableServiceAccess();
            _OnlineExamExaminationQuePaperDetailsServiceAcess = new OnlineExamExaminationQuePaperDetailsServiceAccess();
        }

        // Controller Methods
        #region Controller Methods
        public ActionResult Index()
        {
            try
            {
                OnlineExamAssignpapersetterViewModel model = new OnlineExamAssignpapersetterViewModel();
                var AdminRoleMasterID = 0;
                if (Session["RoleID"] == null)
                {
                    AdminRoleMasterID = Convert.ToInt32(Session["DefaultRoleID"]);
                }
                else
                {
                    AdminRoleMasterID = Convert.ToInt32(Session["RoleID"]);
                }
                List<AdminRoleApplicableDetails> AdminRoleApplicableDetails = GetAdminRoleApplicableCentreByAcademicManager(Convert.ToInt32(AdminRoleMasterID));
                List<SelectListItem> listAdminRoleApplicableDetails = new List<SelectListItem>();
                foreach (AdminRoleApplicableDetails item in AdminRoleApplicableDetails)
                {
                    listAdminRoleApplicableDetails.Add(new SelectListItem { Text = item.CentreName, Value = Convert.ToString(item.CentreCode) });
                }

                ViewBag.listAdminRoleApplicableDetails = new SelectList(listAdminRoleApplicableDetails, "Value", "Text");

                return View("/Views/OnlineExam/OnlineExamAssignpapersetter/Index.cshtml");
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }

        }
        public ActionResult ViewQuestion(string OnlineExamExaminationQuestionPaperID, string OnlineExamSubjectGroupScheduleID)
        {
            OnlineExamAssignpapersetterViewModel model = new OnlineExamAssignpapersetterViewModel();
            model.OnlineExamExaminationQuestionPaperID = Convert.ToInt32(OnlineExamExaminationQuestionPaperID);
            model.OnlineExamSubjectGroupScheduleID = Convert.ToInt32(OnlineExamSubjectGroupScheduleID);
            return View("~/Views/OnlineExam/OnlineExamAssignpapersetter/ViewQuestion.cshtml", model);
        }
        public ActionResult List(string CentreCode, string OnlineExamExaminationMasterID)
        {
            try
            {
                OnlineExamAssignpapersetterViewModel model = new OnlineExamAssignpapersetterViewModel();
                model.CentreCode = CentreCode;
                model.OnlineExamExaminationMasterID = Convert.ToInt32(OnlineExamExaminationMasterID);
                return PartialView("/Views/OnlineExam/OnlineExamAssignpapersetter/List.cshtml", model);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }

        }

        public ActionResult ViewQuestionList(string actionmode)
        {
            try
            {
                OnlineExamAssignpapersetterViewModel model = new OnlineExamAssignpapersetterViewModel();
                if (!string.IsNullOrEmpty(actionmode))
                {
                    TempData["actionmode"] = actionmode;
                }
                return PartialView("~/Views/OnlineExam/OnlineExamAssignpapersetter/ViewQuestionList.cshtml", model);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        [HttpGet]
        public ActionResult Create(string IDs)
        {
            OnlineExamAssignpapersetterViewModel model = new OnlineExamAssignpapersetterViewModel();
            string[] IDsArray = IDs.Split('~');
            model.CentreCode = IDsArray[0];
            model.SubjectGroupID = Convert.ToInt32(IDsArray[1]);
            model.OnlineExamExaminationMasterID = Convert.ToInt32(IDsArray[2]);
            model.OnlineExamSubjectGroupScheduleID = Convert.ToInt32(IDsArray[3]);
            model.SubjectGroupDescription = IDsArray[4].Replace('$', ' ');
            //model.OnlineExamAllocateJobSupportStaffID = Convert.ToInt32(IDsArray[4]);
            List<GeneralPaperSetMaster> GeneralPaperSetMaster = GetListPaperSet();
            List<SelectListItem> GeneralPaperSetMasterList = new List<SelectListItem>();

            foreach (GeneralPaperSetMaster item in GeneralPaperSetMaster)
            {
                GeneralPaperSetMasterList.Add(new SelectListItem { Text = item.PaperSetCode, Value = Convert.ToString(item.PaperSetCode) });
            }
            ViewBag.GeneralPaperSetMasterListt = new SelectList(GeneralPaperSetMasterList, "Value", "Text");


            return PartialView("/Views/OnlineExam/OnlineExamAssignpapersetter/Create.cshtml", model);
        }

        [HttpPost]
        public ActionResult Create(OnlineExamAssignpapersetterViewModel model)
        {
            try
            {
                if (model != null && model.OnlineExamAssignpapersetterDTO != null)
                {
                    model.OnlineExamAssignpapersetterDTO.ConnectionString = _connectioString;
                    model.OnlineExamAssignpapersetterDTO.PaperSet = model.PaperSet;
                    model.OnlineExamAssignpapersetterDTO.OnlineExamExaminationMasterID = model.OnlineExamExaminationMasterID;
                    model.OnlineExamAssignpapersetterDTO.OnlineExamSubjectGroupScheduleID = model.OnlineExamSubjectGroupScheduleID;
                    model.OnlineExamAssignpapersetterDTO.OnlineExamAllocateJobSupportStaffID = model.OnlineExamAllocateJobSupportStaffID;
                    model.OnlineExamAssignpapersetterDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                    IBaseEntityResponse<OnlineExamAssignpapersetter> response = _OnlineExamAssignpapersetterServiceAcess.InsertOnlineExamAssignpapersetter(model.OnlineExamAssignpapersetterDTO);
                    model.OnlineExamAssignpapersetterDTO.errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                    return Json(model.OnlineExamAssignpapersetterDTO.errorMessage, JsonRequestBehavior.AllowGet);
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
        //public ActionResult Edit(int id)
        //{
        //    GeneralPaperSetMasterViewModel model = new GeneralPaperSetMasterViewModel();
        //    try
        //    {
        //        model.GeneralPaperSetMasterDTO = new GeneralPaperSetMaster();
        //        model.GeneralPaperSetMasterDTO.ID = id;
        //        model.GeneralPaperSetMasterDTO.ConnectionString = _connectioString;

        //        IBaseEntityResponse<GeneralPaperSetMaster> response = _GeneralPaperSetMasterServiceAcess.SelectByID(model.GeneralPaperSetMasterDTO);
        //        if (response != null && response.Entity != null)
        //        {
        //            model.GeneralPaperSetMasterDTO.ID = response.Entity.ID;
        //            model.GeneralPaperSetMasterDTO.GroupDescription = response.Entity.GroupDescription;
        //            model.GeneralPaperSetMasterDTO.GroupCode = response.Entity.GroupCode;
        //            model.GeneralPaperSetMasterDTO.CreatedBy = response.Entity.CreatedBy;
        //        }
        //        return PartialView(model);
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

        [HttpPost]
        public ActionResult Edit(OnlineExamAssignpapersetterViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model != null && model.OnlineExamAssignpapersetterDTO != null)
                {
                    if (model != null && model.OnlineExamAssignpapersetterDTO != null)
                    {
                        model.OnlineExamAssignpapersetterDTO.ConnectionString = _connectioString;
                        //model.OnlineExamAssignpapersetterDTO.PaperSetCode = model.PaperSetCode;
                        //model.OnlineExamAssignpapersetterDTO.MovementCode = model.MovementCode;
                        //model.OnlineExamAssignpapersetterDTO.IsActive = model.IsActive;

                        model.OnlineExamAssignpapersetterDTO.ModifiedBy = Convert.ToInt32(Session["UserID"]);
                        IBaseEntityResponse<OnlineExamAssignpapersetter> response = _OnlineExamAssignpapersetterServiceAcess.UpdateOnlineExamAssignpapersetter(model.OnlineExamAssignpapersetterDTO);
                        model.OnlineExamAssignpapersetterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Update);
                    }
                }
                return Json(model.OnlineExamAssignpapersetterDTO.errorMessage, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("Please review your form");
            }
        }


        public ActionResult Delete(int ID)
        {
            var errorMessage = string.Empty;
            if (ID > 0)
            {
                IBaseEntityResponse<OnlineExamAssignpapersetter> response = null;
                OnlineExamAssignpapersetter OnlineExamAssignpapersetterDTO = new OnlineExamAssignpapersetter();
                OnlineExamAssignpapersetterDTO.ConnectionString = _connectioString;
                OnlineExamAssignpapersetterDTO.ID = Convert.ToByte(ID);
                OnlineExamAssignpapersetterDTO.DeletedBy = Convert.ToInt32(Session["UserID"]);
                response = _OnlineExamAssignpapersetterServiceAcess.DeleteOnlineExamAssignpapersetter(OnlineExamAssignpapersetterDTO);
                errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Delete);
            }

            return Json(errorMessage, JsonRequestBehavior.AllowGet);
        }

        public ActionResult SelectQuestionPaper(int ID)
        {
            var errorMessage = string.Empty;
            if (ID > 0)
            {
                IBaseEntityResponse<OnlineExamAssignpapersetter> response = null;
                OnlineExamAssignpapersetter OnlineExamAssignpapersetterDTO = new OnlineExamAssignpapersetter();
                OnlineExamAssignpapersetterDTO.ConnectionString = _connectioString;
                OnlineExamAssignpapersetterDTO.OnlineExamExaminationQuestionPaperID = ID;
                OnlineExamAssignpapersetterDTO.ModifiedBy = Convert.ToInt32(Session["UserID"]);
                response = _OnlineExamAssignpapersetterServiceAcess.OnlineExamSelectQuestionPaper(OnlineExamAssignpapersetterDTO);
                if (response.Entity.ErrorCode == 25)
                {
                    string[] arrayList = { "Selected Paper Set can not be changed. Students are already applied for selected Paper Set.", "warning", string.Empty };
                    errorMessage = string.Join(",", arrayList);
                }
                else
                {
                    errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Update);
                }
            }

            return Json(errorMessage, JsonRequestBehavior.AllowGet);
        }

        #endregion
        protected List<GeneralPaperSetMaster> GetListPaperSet()
        {
            GeneralPaperSetMasterSearchRequest searchRequest = new GeneralPaperSetMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            List<GeneralPaperSetMaster> listPaperSetMaster = new List<GeneralPaperSetMaster>();
            IBaseEntityCollectionResponse<GeneralPaperSetMaster> baseEntityCollectionResponse = _GeneralPaperSetMasterServiceAccess.GetGeneralPaperSetMasterSearchList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listPaperSetMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listPaperSetMaster;
        }
        [HttpPost]
        public JsonResult GetListOnlineExamSupportStaff(string term, string CentreCode, string OnlineExamExaminationMasterID, string SubjectGroupId, string GlobalSessionID)
        {
            OnlineExamAssignpapersetterSearchRequest searchRequest = new OnlineExamAssignpapersetterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.SearchWord = term;
            searchRequest.CentreCode = CentreCode;
            searchRequest.OnlineExamExaminationMasterID = Convert.ToInt32(OnlineExamExaminationMasterID);
            searchRequest.SubjectGroupId = Convert.ToInt32(SubjectGroupId);
            searchRequest.GlobalSessionID = Convert.ToInt32(GlobalSessionID);
            List<OnlineExamAssignpapersetter> listOnlineExamAssignpapersetter = new List<OnlineExamAssignpapersetter>();
            IBaseEntityCollectionResponse<OnlineExamAssignpapersetter> baseEntityCollectionResponse = _OnlineExamAssignpapersetterServiceAcess.GetOnlineExamSupportStaffSearchList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listOnlineExamAssignpapersetter = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            var result = (from r in listOnlineExamAssignpapersetter
                          select new
                          {
                              id = r.OnlineExamAllocateSupportStaffID,
                              name = r.FullName,
                              OnlineExamAllocateJobSupportStaffID = r.OnlineExamAllocateJobSupportStaffID,
                          }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }


        public ActionResult GetOnlineExamGetExaminationListCentreWise(string CentreCode)
        {
            int EmployeeID = Convert.ToInt32(Session["PersonID"]);
            int RoleMasterID = Convert.ToInt32(Session["RoleID"]);
            var CuurentSession = GetCurrentSession(CentreCode);

            var resultCuurentSession = (from s in CuurentSession
                                        select new
                                        {
                                            SessionID = s.SessionID,
                                        }).ToList();

            if (resultCuurentSession.Count != 0)
            {
                int SessionID = resultCuurentSession[0].SessionID;

                var ExaminationMaster = OnlineExamGetExaminationListCentreWise(CentreCode, SessionID, EmployeeID, RoleMasterID);
                var result = (from s in ExaminationMaster
                              select new
                              {
                                  id = s.ID,
                                  name = s.ExaminationName,
                                  SessionID = SessionID,
                              }).ToList();

                return Json(result, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(0, JsonRequestBehavior.AllowGet);
            }

        }

        // Non-Action Method
        #region Methods
        public IEnumerable<OnlineExamAssignpapersetterViewModel> GetOnlineExamAssignpapersetter(out int TotalRecords, string CentreCode, string OnlineExamExaminationMasterID, int SessionID, int CourseYearID, int SemesterMstID)
        {
            OnlineExamAssignpapersetterSearchRequest searchRequest = new OnlineExamAssignpapersetterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.CentreCode = CentreCode;
            searchRequest.GenSessionMaster = SessionID;
            searchRequest.CourseYearID = CourseYearID;
            searchRequest.SemesterMstID = SemesterMstID;
            searchRequest.OnlineExamExaminationMasterID = Convert.ToInt32(OnlineExamExaminationMasterID);
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
            List<OnlineExamAssignpapersetterViewModel> listOnlineExamAssignpapersetterViewModel = new List<OnlineExamAssignpapersetterViewModel>();
            List<OnlineExamAssignpapersetter> listOnlineExamAssignpapersetter = new List<OnlineExamAssignpapersetter>();
            IBaseEntityCollectionResponse<OnlineExamAssignpapersetter> baseEntityCollectionResponse = _OnlineExamAssignpapersetterServiceAcess.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listOnlineExamAssignpapersetter = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (OnlineExamAssignpapersetter item in listOnlineExamAssignpapersetter)
                    {
                        OnlineExamAssignpapersetterViewModel OnlineExamAssignpapersetterViewModel = new OnlineExamAssignpapersetterViewModel();
                        OnlineExamAssignpapersetterViewModel.OnlineExamAssignpapersetterDTO = item;
                        listOnlineExamAssignpapersetterViewModel.Add(OnlineExamAssignpapersetterViewModel);
                    }
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listOnlineExamAssignpapersetterViewModel;
        }



        #endregion

        // AjaxHandler Method
        #region AjaxHandler
        public ActionResult AjaxHandler(JQueryDataTableParamModel param, string CentreCode, string OnlineExamExaminationMasterID,  int CourseYearID, int SemesterMstID,int SessionID)
        {
            if (Session["UserType"] != null)
            {
                int TotalRecords;
                var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
                string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc

                IEnumerable<OnlineExamAssignpapersetterViewModel> filteredGroupDescription;
                switch (Convert.ToInt32(sortColumnIndex))
                {
                    case 0:
                        _sortBy = "A.OnlineExamExaminationMasterID";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {

                            _searchBy = string.Empty;
                        }
                        else
                        {

                            _searchBy = "SubjectGroupDescription Like '%" + param.sSearch + "%'";  //this "if" block is added for search functionality
                        }
                        break;
                    case 1:
                        _sortBy = "PaperSet";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {

                            _searchBy = string.Empty;
                        }
                        else
                        {

                            _searchBy = "SubjectGroupDescription Like '%" + param.sSearch + "%'";//this "if" block is added for search functionality
                        }
                        break;
                    case 2:
                        _sortBy = "OnlineExamAllocateJobSupportStaff";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {

                            _searchBy = string.Empty;
                        }
                        else
                        {

                            _searchBy = "SubjectGroupDescription Like '%" + param.sSearch + "%'";//this "if" block is added for search functionality
                        }
                        break;
                }
                _sortDirection = sortDirection;
                _rowLength = param.iDisplayLength;
                _startRow = param.iDisplayStart;
                filteredGroupDescription = GetOnlineExamAssignpapersetter(out TotalRecords, CentreCode, OnlineExamExaminationMasterID, SessionID, CourseYearID, SemesterMstID);


                var records = filteredGroupDescription.Skip(0).Take(param.iDisplayLength);
                var result = from c in records select new[] { Convert.ToString(c.PaperSet), Convert.ToString(c.OnlineExamExaminationMasterID), Convert.ToString(c.OnlineExamSubjectGroupScheduleID), Convert.ToString(c.OnlineExamAllocateJobSupportStaffID), Convert.ToString(c.SubjectGroupDescription), Convert.ToString(c.SubjectGroupID), Convert.ToString(c.SelectedCentreCode), Convert.ToString(c.OnlineExamAllocateJobSupportStaff), Convert.ToString(c.GlobalSessionID), Convert.ToString(c.OnlineExamExaminationQuestionPaperID), Convert.ToString(c.CourseYearID), Convert.ToString(c.IsFinal), Convert.ToString(c.IsSelected) };

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