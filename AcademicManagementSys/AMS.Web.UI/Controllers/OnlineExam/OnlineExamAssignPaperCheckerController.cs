
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
    public class OnlineExamAssignPaperCheckerController : BaseController
    {
        IOnlineExamAssignPaperCheckerServiceAccess _OnlineExamAssignPaperCheckerServiceAcess = null;
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

        public OnlineExamAssignPaperCheckerController()
        {
            _OnlineExamAssignPaperCheckerServiceAcess = new OnlineExamAssignPaperCheckerServiceAccess();
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
                OnlineExamAssignPaperCheckerViewModel model = new OnlineExamAssignPaperCheckerViewModel();
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

                return View("/Views/OnlineExam/OnlineExamAssignPaperChecker/Index.cshtml");
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }

        }
       
        public ActionResult List(string CentreCode, string OnlineExamExaminationMasterID)
        {
            try
            {
                OnlineExamAssignPaperCheckerViewModel model = new OnlineExamAssignPaperCheckerViewModel();
                model.CentreCode = CentreCode;
                model.OnlineExamExaminationMasterID = Convert.ToInt32(OnlineExamExaminationMasterID);
                return PartialView("/Views/OnlineExam/OnlineExamAssignPaperChecker/List.cshtml", model);
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
            OnlineExamAssignPaperCheckerViewModel model = new OnlineExamAssignPaperCheckerViewModel();
            string[] IDsArray = IDs.Split('~');
            model.CentreCode = IDsArray[0];
            model.SubjectGroupID = Convert.ToInt32(IDsArray[1]);
            model.OnlineExamExaminationMasterID = Convert.ToInt32(IDsArray[2]);
            model.OnlineExamSubjectGroupScheduleID = Convert.ToInt32(IDsArray[3]);
            model.SectionDetailID = Convert.ToInt32(IDsArray[5]);
            model.SubjectGroupDescription = IDsArray[4].Replace('$', ' ');
            return PartialView("/Views/OnlineExam/OnlineExamAssignPaperChecker/Create.cshtml", model);
        }

        [HttpPost]
        public ActionResult Create(OnlineExamAssignPaperCheckerViewModel model)
        {
            try
            {
                if (model != null && model.OnlineExamAssignPaperCheckerDTO != null)
                {
                    model.OnlineExamAssignPaperCheckerDTO.ConnectionString = _connectioString;
                    model.OnlineExamAssignPaperCheckerDTO.OnlineExamExaminationMasterID = model.OnlineExamExaminationMasterID;
                    model.OnlineExamAssignPaperCheckerDTO.OnlineExamSubjectGroupScheduleID = model.OnlineExamSubjectGroupScheduleID;
                    model.OnlineExamAssignPaperCheckerDTO.OnlineExamAllocateJobSupportStaffID = model.OnlineExamAllocateJobSupportStaffID;
                    model.OnlineExamAssignPaperCheckerDTO.SectionDetailID = model.SectionDetailID;
                    model.OnlineExamAssignPaperCheckerDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                    IBaseEntityResponse<OnlineExamAssignPaperChecker> response = _OnlineExamAssignPaperCheckerServiceAcess.InsertOnlineExamAssignPaperChecker(model.OnlineExamAssignPaperCheckerDTO);
                    model.OnlineExamAssignPaperCheckerDTO.errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                    return Json(model.OnlineExamAssignPaperCheckerDTO.errorMessage, JsonRequestBehavior.AllowGet);
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
        //[HttpPost]
        //public ActionResult Edit(OnlineExamAssignPaperCheckerViewModel model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        if (model != null && model.OnlineExamAssignPaperCheckerDTO != null)
        //        {
        //            if (model != null && model.OnlineExamAssignPaperCheckerDTO != null)
        //            {
        //                model.OnlineExamAssignPaperCheckerDTO.ConnectionString = _connectioString;

        //                model.OnlineExamAssignPaperCheckerDTO.ModifiedBy = Convert.ToInt32(Session["UserID"]);
        //                IBaseEntityResponse<OnlineExamAssignPaperChecker> response = _OnlineExamAssignPaperCheckerServiceAcess.UpdateOnlineExamAssignPaperChecker(model.OnlineExamAssignPaperCheckerDTO);
        //                model.OnlineExamAssignPaperCheckerDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Update);
        //            }
        //        }
        //        return Json(model.OnlineExamAssignPaperCheckerDTO.errorMessage, JsonRequestBehavior.AllowGet);
        //    }
        //    else
        //    {
        //        return Json("Please review your form");
        //    }
        //}
        public ActionResult Delete(int ID)
        {
            var errorMessage = string.Empty;
            if (ID > 0)
            {
                IBaseEntityResponse<OnlineExamAssignPaperChecker> response = null;
                OnlineExamAssignPaperChecker OnlineExamAssignPaperCheckerDTO = new OnlineExamAssignPaperChecker();
                OnlineExamAssignPaperCheckerDTO.ConnectionString = _connectioString;
                OnlineExamAssignPaperCheckerDTO.ID = Convert.ToByte(ID);
                OnlineExamAssignPaperCheckerDTO.DeletedBy = Convert.ToInt32(Session["UserID"]);
                response = _OnlineExamAssignPaperCheckerServiceAcess.DeleteOnlineExamAssignPaperChecker(OnlineExamAssignPaperCheckerDTO);
                if (response.Entity.ErrorCode == 22)
                {
                    string[] arrayList = { "Record not Deleted It is Assign as a Paper Checker on Examination.", "warning", string.Empty };
                    errorMessage = string.Join(",", arrayList);
                }
                else
                {
                    errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Delete);
                }
            }

            return Json(errorMessage, JsonRequestBehavior.AllowGet);
        }
        #endregion
        [HttpPost]
        public JsonResult GetListOnlineExamSupportStaff(string term, string CentreCode, string OnlineExamExaminationMasterID, string SubjectGroupId, string GlobalSessionID, string SectionDetailID)
        {
            OnlineExamAssignPaperCheckerSearchRequest searchRequest = new OnlineExamAssignPaperCheckerSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.SearchWord = term;
            searchRequest.CentreCode = CentreCode;
            searchRequest.OnlineExamExaminationMasterID = Convert.ToInt32(OnlineExamExaminationMasterID);
            searchRequest.SubjectGroupId = Convert.ToInt32(SubjectGroupId);
            searchRequest.GlobalSessionID = Convert.ToInt32(GlobalSessionID);
            searchRequest.SectionDetailID = Convert.ToInt32(SectionDetailID);
            List<OnlineExamAssignPaperChecker> listOnlineExamAssignPaperChecker = new List<OnlineExamAssignPaperChecker>();
            IBaseEntityCollectionResponse<OnlineExamAssignPaperChecker> baseEntityCollectionResponse = _OnlineExamAssignPaperCheckerServiceAcess.GetOnlineExamSupportStaffSearchList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listOnlineExamAssignPaperChecker = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            var result = (from r in listOnlineExamAssignPaperChecker
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
        public IEnumerable<OnlineExamAssignPaperCheckerViewModel> GetOnlineExamAssignPaperChecker(out int TotalRecords, string CentreCode, string OnlineExamExaminationMasterID, int SessionID, int CourseYearID, int SemesterMstID, int SectionDetailID)
        {
            OnlineExamAssignPaperCheckerSearchRequest searchRequest = new OnlineExamAssignPaperCheckerSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.CentreCode = CentreCode;
            searchRequest.GenSessionMaster = SessionID;
            searchRequest.CourseYearID = CourseYearID;
            searchRequest.SemesterMstID = SemesterMstID;
            searchRequest.SectionDetailID = SectionDetailID;
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
            List<OnlineExamAssignPaperCheckerViewModel> listOnlineExamAssignPaperCheckerViewModel = new List<OnlineExamAssignPaperCheckerViewModel>();
            List<OnlineExamAssignPaperChecker> listOnlineExamAssignPaperChecker = new List<OnlineExamAssignPaperChecker>();
            IBaseEntityCollectionResponse<OnlineExamAssignPaperChecker> baseEntityCollectionResponse = _OnlineExamAssignPaperCheckerServiceAcess.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listOnlineExamAssignPaperChecker = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (OnlineExamAssignPaperChecker item in listOnlineExamAssignPaperChecker)
                    {
                        OnlineExamAssignPaperCheckerViewModel OnlineExamAssignPaperCheckerViewModel = new OnlineExamAssignPaperCheckerViewModel();
                        OnlineExamAssignPaperCheckerViewModel.OnlineExamAssignPaperCheckerDTO = item;
                        listOnlineExamAssignPaperCheckerViewModel.Add(OnlineExamAssignPaperCheckerViewModel);
                    }
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listOnlineExamAssignPaperCheckerViewModel;
        }
        #endregion
        #region AjaxHandler
        public ActionResult AjaxHandler(JQueryDataTableParamModel param, string CentreCode, string OnlineExamExaminationMasterID, int CourseYearID, int SemesterMstID, int SessionID, int SectionDetailID)
        {
            if (Session["UserType"] != null)
            {
                int TotalRecords;
                var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
                string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc

                IEnumerable<OnlineExamAssignPaperCheckerViewModel> filteredGroupDescription;
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
                filteredGroupDescription = GetOnlineExamAssignPaperChecker(out TotalRecords, CentreCode, OnlineExamExaminationMasterID, SessionID, CourseYearID, SemesterMstID, SectionDetailID);


                var records = filteredGroupDescription.Skip(0).Take(param.iDisplayLength);
                var result = from c in records select new[] { Convert.ToString(c.OnlineExamExaminationMasterID), Convert.ToString(c.OnlineExamSubjectGroupScheduleID), Convert.ToString(c.OnlineExamAllocateJobSupportStaffID), Convert.ToString(c.SubjectGroupDescription), Convert.ToString(c.SubjectGroupID), Convert.ToString(c.SelectedCentreCode), Convert.ToString(c.OnlineExamAllocateJobSupportStaff), Convert.ToString(c.GlobalSessionID), Convert.ToString(c.OnlineExamQuestionPaperCheckerID), Convert.ToString(c.CourseYearID),Convert.ToString(c.IsAllChecked),Convert.ToString(c.SectionDetailID) };

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