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
    public class OnlineExamSubjectGroupScheduleController : BaseController
    {
        IOnlineExamSubjectGroupScheduleServiceAccess _OnlineExamSubjectGroupScheduleServiceAcess = null;
        IOrganisationSubjectGroupDetailsServiceAccess _OrganisationSubjectGroupDetailsServiceAccess = null;
        IOnlineExamSubjectGroupScheduleViewModel _OnlineExamSubjectGroupScheduleViewModel = null;
        IEmpEmployeeMasterServiceAccess _EmpEmployeeMasterServiceAccess = null;
        IOnlineExamExaminationCourseApplicableServiceAccess _OnlineExamExaminationCourseApplicableServiceAccess = null;
        IOnlineExamExaminationMasterServiceAccess _OnlineExamExaminationMasterServiceAccess = null;
        IOrganisationCourseYearDetailsServiceAccess _OrganisationCourseYearDetailsServiceAccess = null;
        IOnlineExamStudentApplicableServiceAccess _OnlineExamStudentApplicableServiceAccess = null;
        private readonly ILogger _logException;
        ActionModeEnum actionModeEnum;
        string _actionMode = string.Empty;
        string _sortBy = string.Empty;
        string _searchBy = string.Empty;
        string _sortDirection = string.Empty;
        int _startRow;
        int _rowLength;
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

        public OnlineExamSubjectGroupScheduleController()
        {
            _OnlineExamSubjectGroupScheduleServiceAcess = new OnlineExamSubjectGroupScheduleServiceAccess();
            _OrganisationSubjectGroupDetailsServiceAccess = new OrganisationSubjectGroupDetailsServiceAccess();
            _OnlineExamSubjectGroupScheduleViewModel = new OnlineExamSubjectGroupScheduleViewModel();
            _EmpEmployeeMasterServiceAccess = new EmpEmployeeMasterServiceAccess();
            _OnlineExamExaminationMasterServiceAccess = new OnlineExamExaminationMasterServiceAccess();
            _OrganisationCourseYearDetailsServiceAccess = new OrganisationCourseYearDetailsServiceAccess();
            _OnlineExamExaminationCourseApplicableServiceAccess = new OnlineExamExaminationCourseApplicableServiceAccess();
            _OnlineExamStudentApplicableServiceAccess = new OnlineExamStudentApplicableServiceAccess();
        }


        // Controller Methods
        #region Controller Methods
        public ActionResult Index()
        {
            try
            {
                OnlineExamSubjectGroupScheduleViewModel model = new OnlineExamSubjectGroupScheduleViewModel();
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

                return View("/Views/OnlineExam/OnlineExamSubjectGroupSchedule/Index.cshtml");
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
                OnlineExamSubjectGroupScheduleViewModel model = new OnlineExamSubjectGroupScheduleViewModel();
                model.CentreCode = CentreCode;
                model.OnlineExamExaminationMasterID = Convert.ToInt32(OnlineExamExaminationMasterID);
                return PartialView("/Views/OnlineExam/OnlineExamSubjectGroupSchedule/List.cshtml", model);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }

        }


        [HttpGet]
        public ActionResult Create(string OnlineExamExaminationCourseApplicableID, string SubjectID, string SubjectGroupID, string SubjectGroupDescription, string CourseYearID, string CentreCode)
        {
            OnlineExamSubjectGroupScheduleViewModel model = new OnlineExamSubjectGroupScheduleViewModel();
            model.OnlineExamExaminationCourseApplicableID = Convert.ToInt32(OnlineExamExaminationCourseApplicableID);
            //model.OnlineExamQuestionBankMasterID = Convert.ToInt32(OnlineExamQuestionBankMasterID);
            model.SubjectID = Convert.ToInt32(SubjectID);
            model.SubjectGroupID = Convert.ToInt32(SubjectGroupID);
            model.CourseYearID = Convert.ToInt32(CourseYearID);
            model.CentreCode = CentreCode;
            model.SubjectGroupDescription = SubjectGroupDescription;

            
            List<SelectListItem> IsNegavieMarking = new List<SelectListItem>();
            ViewBag.IsNegavieMarking = new SelectList(IsNegavieMarking, "Value", "Text");
            List<SelectListItem> li_IsNegavieMarking = new List<SelectListItem>();
            li_IsNegavieMarking.Add(new SelectListItem { Text = "NO", Value = "false" });
            li_IsNegavieMarking.Add(new SelectListItem { Text = "YES", Value = "true" });
            ViewData["IsNegavieMarking"] = li_IsNegavieMarking;

           
            return PartialView("/Views/OnlineExam/OnlineExamSubjectGroupSchedule/Create.cshtml", model);
        }

        [HttpPost]
        public ActionResult Create(OnlineExamSubjectGroupScheduleViewModel model)
        {
            try
            {
                //if (ModelState.IsValid)
                // {
                if (model != null && model.OnlineExamSubjectGroupScheduleDTO != null)
                {
                    model.OnlineExamSubjectGroupScheduleDTO.ConnectionString = _connectioString;

                    model.OnlineExamSubjectGroupScheduleDTO.ID = model.ID;
                    model.OnlineExamSubjectGroupScheduleDTO.OnlineExamExaminationCourseApplicableID = model.OnlineExamExaminationCourseApplicableID;
                    model.OnlineExamSubjectGroupScheduleDTO.CentreCode = model.CentreCode;
                    model.OnlineExamSubjectGroupScheduleDTO.OnlineExamExaminationMasterID = model.OnlineExamExaminationMasterID;
                    model.OnlineExamSubjectGroupScheduleDTO.SubjectID = model.SubjectID;
                    model.OnlineExamSubjectGroupScheduleDTO.SubjectGroupID = model.SubjectGroupID;
                    model.OnlineExamSubjectGroupScheduleDTO.ExaminationStartDate = model.ExaminationStartDate;
                    model.OnlineExamSubjectGroupScheduleDTO.ExaminationEndDate = model.ExaminationEndDate;
                    model.OnlineExamSubjectGroupScheduleDTO.ExaminationStartTime = model.ExaminationStartTime;
                    model.OnlineExamSubjectGroupScheduleDTO.ExaminationEndTime = model.ExaminationEndTime;
                    model.OnlineExamSubjectGroupScheduleDTO.TotalQuestions = model.TotalQuestions;
                    model.OnlineExamSubjectGroupScheduleDTO.TotalMarks = model.TotalMarks;
                    model.OnlineExamSubjectGroupScheduleDTO.PassingMarks = model.PassingMarks;
                    model.OnlineExamSubjectGroupScheduleDTO.MarksForEachQues = model.MarksForEachQues;
                    model.OnlineExamSubjectGroupScheduleDTO.Level1Marks = model.Level1Marks;
                    model.OnlineExamSubjectGroupScheduleDTO.Level2Marks = model.Level2Marks;
                    model.OnlineExamSubjectGroupScheduleDTO.Level3Marks = model.Level3Marks;
                    model.OnlineExamSubjectGroupScheduleDTO.Level1TimeInMinutes = model.Level1TimeInMinutes;
                    model.OnlineExamSubjectGroupScheduleDTO.Level2TimeInMinutes = model.Level2TimeInMinutes;
                    model.OnlineExamSubjectGroupScheduleDTO.Level3TimeInMinutes = model.Level3TimeInMinutes;
                    model.OnlineExamSubjectGroupScheduleDTO.Level4TimeInMinutes = model.Level4TimeInMinutes;
                    model.OnlineExamSubjectGroupScheduleDTO.FixedFlexibleTime = model.FixedFlexibleTime;
                    model.OnlineExamSubjectGroupScheduleDTO.ExamDuration = model.ExamDuration;
                    model.OnlineExamSubjectGroupScheduleDTO.DayOpenTime = model.DayOpenTime;
                    model.OnlineExamSubjectGroupScheduleDTO.DayCloseTime = model.DayCloseTime;
                    model.OnlineExamSubjectGroupScheduleDTO.ExaminationStatus = model.ExaminationStatus;
                    //model.OnlineExamSubjectGroupScheduleDTO.OnlineExamExaminationMasterID = model.OnlineExamExaminationMasterID;
                    model.OnlineExamSubjectGroupScheduleDTO.TotalPaperSet = model.TotalPaperSet;
                    model.OnlineExamSubjectGroupScheduleDTO.ParameterXml = model.ParameterXml;
                    model.OnlineExamSubjectGroupScheduleDTO.IsNegavieMarking = model.IsNegavieMarking;
                    model.OnlineExamSubjectGroupScheduleDTO.MarksToBeDeducted = model.MarksToBeDeducted;
                    model.OnlineExamSubjectGroupScheduleDTO.IsScheduleForAllSections = model.IsScheduleForAllSections;
                    model.OnlineExamSubjectGroupScheduleDTO.IsTimeFlexible = model.IsTimeFlexible;
                    model.OnlineExamSubjectGroupScheduleDTO.CreatedBy = model.CreatedBy;
                    IBaseEntityResponse<OnlineExamSubjectGroupSchedule> response = _OnlineExamSubjectGroupScheduleServiceAcess.InsertOnlineExamSubjectGroupSchedule(model.OnlineExamSubjectGroupScheduleDTO);
                    model.OnlineExamSubjectGroupScheduleDTO.errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                    return Json(model.OnlineExamSubjectGroupScheduleDTO.errorMessage, JsonRequestBehavior.AllowGet);
                }


          //  }
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
        public ActionResult View(string OnlineExamExaminationCourseApplicableID, string OnlineExamSubjectGroupScheduleID, string SubjectGroupDescription, string CentreCode)
        {
            OnlineExamSubjectGroupScheduleViewModel model = new OnlineExamSubjectGroupScheduleViewModel();
            try
            {
                model.OnlineExamSubjectGroupScheduleDTO = new OnlineExamSubjectGroupSchedule();
                model.OnlineExamSubjectGroupScheduleDTO.OnlineExamExaminationCourseApplicableID =Convert.ToInt32(OnlineExamExaminationCourseApplicableID);
                model.OnlineExamSubjectGroupScheduleDTO.OnlineExamSubjectGroupScheduleID = Convert.ToInt32(OnlineExamSubjectGroupScheduleID);
                model.OnlineExamSubjectGroupScheduleDTO.SubjectGroupDescription = SubjectGroupDescription;
                model.OnlineExamSubjectGroupScheduleDTO.CentreCode = CentreCode;
                model.OnlineExamSubjectGroupScheduleDTO.ConnectionString = _connectioString;
                IBaseEntityResponse<OnlineExamSubjectGroupSchedule> response = _OnlineExamSubjectGroupScheduleServiceAcess.SelectByID(model.OnlineExamSubjectGroupScheduleDTO);
                if (response != null && response.Entity != null)
                {
                    model.OnlineExamSubjectGroupScheduleDTO.ID = response.Entity.ID;
                    model.OnlineExamSubjectGroupScheduleDTO.OnlineExamExaminationCourseApplicableID = response.Entity.OnlineExamExaminationCourseApplicableID;
                    model.OnlineExamSubjectGroupScheduleDTO.OnlineExamQuestionBankMasterID = response.Entity.OnlineExamQuestionBankMasterID;
                    model.OnlineExamSubjectGroupScheduleDTO.OnlineExamExaminationMasterID = response.Entity.OnlineExamExaminationMasterID;
                    model.OnlineExamSubjectGroupScheduleDTO.SubjectID = response.Entity.SubjectID;
                    model.OnlineExamSubjectGroupScheduleDTO.SubjectGroupID = response.Entity.SubjectGroupID;
                    model.OnlineExamSubjectGroupScheduleDTO.ExaminationStartDate = response.Entity.ExaminationStartDate;
                    model.OnlineExamSubjectGroupScheduleDTO.ExaminationEndDate = response.Entity.ExaminationEndDate;
                    model.OnlineExamSubjectGroupScheduleDTO.ExaminationStartTime = response.Entity.ExaminationStartTime;
                    model.OnlineExamSubjectGroupScheduleDTO.ExaminationEndTime = response.Entity.ExaminationEndTime;
                    model.OnlineExamSubjectGroupScheduleDTO.TotalQuestions = response.Entity.TotalQuestions;
                    model.OnlineExamSubjectGroupScheduleDTO.TotalMarks = response.Entity.TotalMarks;
                    model.OnlineExamSubjectGroupScheduleDTO.PassingMarks = response.Entity.PassingMarks;
                    model.OnlineExamSubjectGroupScheduleDTO.MarksForEachQues = response.Entity.MarksForEachQues;
                    model.OnlineExamSubjectGroupScheduleDTO.Level1Marks = response.Entity.Level1Marks;
                    model.OnlineExamSubjectGroupScheduleDTO.Level2Marks = response.Entity.Level2Marks;
                    model.OnlineExamSubjectGroupScheduleDTO.Level3Marks = response.Entity.Level3Marks;
                    model.OnlineExamSubjectGroupScheduleDTO.Level1TimeInMinutes = response.Entity.Level1TimeInMinutes;
                    model.OnlineExamSubjectGroupScheduleDTO.Level2TimeInMinutes = response.Entity.Level2TimeInMinutes;
                    model.OnlineExamSubjectGroupScheduleDTO.Level3TimeInMinutes = response.Entity.Level3TimeInMinutes;
                    model.OnlineExamSubjectGroupScheduleDTO.Level4TimeInMinutes = response.Entity.Level4TimeInMinutes;
                    model.OnlineExamSubjectGroupScheduleDTO.FixedFlexibleTime = response.Entity.FixedFlexibleTime;
                    model.OnlineExamSubjectGroupScheduleDTO.ExamDuration = response.Entity.ExamDuration;
                    model.OnlineExamSubjectGroupScheduleDTO.DayOpenTime = response.Entity.DayOpenTime;
                    model.OnlineExamSubjectGroupScheduleDTO.DayCloseTime = response.Entity.DayCloseTime;
                    model.OnlineExamSubjectGroupScheduleDTO.ExaminationStatus = response.Entity.ExaminationStatus;
                    //model.OnlineExamSubjectGroupScheduleDTO.OnlineExamExaminationMasterID = response.Entity.OnlineExamExaminationMasterID;
                    model.OnlineExamSubjectGroupScheduleDTO.TotalPaperSet = response.Entity.TotalPaperSet;
                    model.OnlineExamSubjectGroupScheduleDTO.SectionDetailsID = response.Entity.SectionDetailsID;
                    model.OnlineExamSubjectGroupScheduleDTO.IsNegavieMarking = response.Entity.IsNegavieMarking;
                    model.OnlineExamSubjectGroupScheduleDTO.MarksToBeDeducted = model.MarksToBeDeducted;
                    model.OnlineExamSubjectGroupScheduleDTO.IsScheduleForAllSections = response.Entity.IsScheduleForAllSections;
                    model.OnlineExamSubjectGroupScheduleDTO.IsTimeFlexible = response.Entity.IsTimeFlexible;
                    model.OnlineExamSubjectGroupScheduleDTO.SectionScheduleList = response.Entity.SectionScheduleList;
                    model.OnlineExamSubjectGroupScheduleDTO.CreatedBy = response.Entity.CreatedBy;
                }
                List<SelectListItem> IsNegavieMarking = new List<SelectListItem>();
                ViewBag.IsNegavieMarking = new SelectList(IsNegavieMarking, "Value", "Text");
                List<SelectListItem> li_IsNegavieMarking = new List<SelectListItem>();
                li_IsNegavieMarking.Add(new SelectListItem { Text = "YES", Value = "true" });
                li_IsNegavieMarking.Add(new SelectListItem { Text = "NO", Value = "false" });
                ViewData["IsNegavieMarking"] = new SelectList(li_IsNegavieMarking, "Value", "Text", (model.OnlineExamSubjectGroupScheduleDTO.IsNegavieMarking).ToString().Trim());
                return PartialView("/Views/OnlineExam/OnlineExamSubjectGroupSchedule/View.cshtml", model);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public ActionResult Edit(OnlineExamSubjectGroupScheduleViewModel model)
        {
            try
            {
                //if (ModelState.IsValid)
                // {
                if (model != null && model.OnlineExamSubjectGroupScheduleDTO != null)
                {
                    model.OnlineExamSubjectGroupScheduleDTO.ConnectionString = _connectioString;

                    model.OnlineExamSubjectGroupScheduleDTO.OnlineExamSubjectGroupScheduleID = model.ID;
                    model.OnlineExamSubjectGroupScheduleDTO.OnlineExamExaminationCourseApplicableID = model.OnlineExamExaminationCourseApplicableID;
                    model.OnlineExamSubjectGroupScheduleDTO.CentreCode = model.CentreCode;
                    model.OnlineExamSubjectGroupScheduleDTO.OnlineExamExaminationMasterID = model.OnlineExamExaminationMasterID;
                    model.OnlineExamSubjectGroupScheduleDTO.SubjectID = model.SubjectID;
                    model.OnlineExamSubjectGroupScheduleDTO.SubjectGroupID = model.SubjectGroupID;
                    model.OnlineExamSubjectGroupScheduleDTO.ExaminationStartDate = model.ExaminationStartDate;
                    model.OnlineExamSubjectGroupScheduleDTO.ExaminationEndDate = model.ExaminationEndDate;
                    model.OnlineExamSubjectGroupScheduleDTO.ExaminationStartTime = model.ExaminationStartTime;
                    model.OnlineExamSubjectGroupScheduleDTO.ExaminationEndTime = model.ExaminationEndTime;
                    model.OnlineExamSubjectGroupScheduleDTO.TotalQuestions = model.TotalQuestions;
                    model.OnlineExamSubjectGroupScheduleDTO.TotalMarks = model.TotalMarks;
                    model.OnlineExamSubjectGroupScheduleDTO.PassingMarks = model.PassingMarks;
                    model.OnlineExamSubjectGroupScheduleDTO.MarksForEachQues = model.MarksForEachQues;
                    model.OnlineExamSubjectGroupScheduleDTO.Level1Marks = model.Level1Marks;
                    model.OnlineExamSubjectGroupScheduleDTO.Level2Marks = model.Level2Marks;
                    model.OnlineExamSubjectGroupScheduleDTO.Level3Marks = model.Level3Marks;
                    model.OnlineExamSubjectGroupScheduleDTO.Level1TimeInMinutes = model.Level1TimeInMinutes;
                    model.OnlineExamSubjectGroupScheduleDTO.Level2TimeInMinutes = model.Level2TimeInMinutes;
                    model.OnlineExamSubjectGroupScheduleDTO.Level3TimeInMinutes = model.Level3TimeInMinutes;
                    model.OnlineExamSubjectGroupScheduleDTO.Level4TimeInMinutes = model.Level4TimeInMinutes;
                    model.OnlineExamSubjectGroupScheduleDTO.FixedFlexibleTime = model.FixedFlexibleTime;
                    model.OnlineExamSubjectGroupScheduleDTO.ExamDuration = model.ExamDuration;
                    model.OnlineExamSubjectGroupScheduleDTO.DayOpenTime = model.DayOpenTime;
                    model.OnlineExamSubjectGroupScheduleDTO.DayCloseTime = model.DayCloseTime;
                    model.OnlineExamSubjectGroupScheduleDTO.ExaminationStatus = model.ExaminationStatus;
                    //model.OnlineExamSubjectGroupScheduleDTO.OnlineExamExaminationMasterID = model.OnlineExamExaminationMasterID;
                    model.OnlineExamSubjectGroupScheduleDTO.TotalPaperSet = model.TotalPaperSet;
                    model.OnlineExamSubjectGroupScheduleDTO.ParameterXml = model.ParameterXml;
                    model.OnlineExamSubjectGroupScheduleDTO.IsNegavieMarking = model.IsNegavieMarking;
                    model.OnlineExamSubjectGroupScheduleDTO.MarksToBeDeducted = model.MarksToBeDeducted;
                    model.OnlineExamSubjectGroupScheduleDTO.IsScheduleForAllSections = model.IsScheduleForAllSections;
                    model.OnlineExamSubjectGroupScheduleDTO.IsTimeFlexible = model.IsTimeFlexible;

                    model.OnlineExamSubjectGroupScheduleDTO.CreatedBy = model.CreatedBy;
                    IBaseEntityResponse<OnlineExamSubjectGroupSchedule> response = _OnlineExamSubjectGroupScheduleServiceAcess.UpdateOnlineExamSubjectGroupSchedule(model.OnlineExamSubjectGroupScheduleDTO);
                    if (response.Entity.ErrorCode == 25)
                    {
                        var errorMessage = "Start date is exceeded";// "Record not updated successfully";
                        var colorCode = "danger";
                        var mode = string.Empty;

                        string[] arrayList = { errorMessage, colorCode, mode };
                        model.OnlineExamSubjectGroupScheduleDTO.errorMessage = string.Join(",", arrayList);
                    }
                    else
                    {
                        model.OnlineExamSubjectGroupScheduleDTO.errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                    }
                   
                    return Json(model.OnlineExamSubjectGroupScheduleDTO.errorMessage, JsonRequestBehavior.AllowGet);
                }


          //  }
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

        public ActionResult Delete(int ID)
        {
            var errorMessage = string.Empty;
            if (ID > 0)
            {
                IBaseEntityResponse<OnlineExamSubjectGroupSchedule> response = null;
                OnlineExamSubjectGroupSchedule OnlineExamSubjectGroupScheduleDTO = new OnlineExamSubjectGroupSchedule();
                OnlineExamSubjectGroupScheduleDTO.ConnectionString = _connectioString;
                OnlineExamSubjectGroupScheduleDTO.ID = Convert.ToInt32(ID);
                OnlineExamSubjectGroupScheduleDTO.DeletedBy = Convert.ToInt32(Session["UserID"]);
                response = _OnlineExamSubjectGroupScheduleServiceAcess.DeleteOnlineExamSubjectGroupSchedule(OnlineExamSubjectGroupScheduleDTO);
                errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Delete);
            }

            return Json(errorMessage, JsonRequestBehavior.AllowGet);
        }

        //[HttpPost]
        //public JsonResult GetSectionDetails(int OnlineExamExaminationCourseApplicableID, int OnlineExamExaminationMasterID)
        //{
        //    OnlineExamSubjectGroupScheduleViewModel model = new OnlineExamSubjectGroupScheduleViewModel();
        //    model.OnlineExamSubjectGroupScheduleDTO = new OnlineExamSubjectGroupSchedule();
        //    model.OnlineExamSubjectGroupScheduleDTO.OnlineExamExaminationCourseApplicableID = model.OnlineExamExaminationCourseApplicableID;
        //    model.OnlineExamSubjectGroupScheduleDTO.OnlineExamExaminationMasterID = model.OnlineExamExaminationMasterID;
        //    model.OnlineExamSubjectGroupScheduleDTO.ConnectionString = _connectioString;
        //    IBaseEntityResponse<OnlineExamSubjectGroupSchedule> response = _OnlineExamSubjectGroupScheduleServiceAcess.GetSectionDetails(model.OnlineExamSubjectGroupScheduleDTO);
        //    if (response != null && response.Entity != null)            
        //    {

        //        model.OnlineExamSubjectGroupScheduleDTO.SectionDetailID = response.Entity.SectionDetailID;

        //    }
        //    return Json(model.OnlineExamSubjectGroupScheduleDTO.SectionDetailID, JsonRequestBehavior.AllowGet);
        //}

        #endregion
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


        public ActionResult GetSectionListOnlineCourseYearWise(int CourseYearID)
        {

            var SectionList = SectionListOnlineCourseYearWise(CourseYearID);
            var result = (from s in SectionList
                          select new
                          {
                              id = s.SectionDetailID,
                              name = s.SectionDetailDescription,
                          }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);

        }

        protected List<OnlineExamStudentApplicable> SectionListOnlineCourseYearWise(int CourseYearID)
        {

            OnlineExamStudentApplicableSearchRequest searchRequest = new OnlineExamStudentApplicableSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.CourseYearID = CourseYearID;
            List<OnlineExamStudentApplicable> listExamination = new List<OnlineExamStudentApplicable>();
            IBaseEntityCollectionResponse<OnlineExamStudentApplicable> baseEntityCollectionResponse = _OnlineExamStudentApplicableServiceAccess.SectionListOnlineCourseYearWise(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listExamination = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listExamination;
        }

        public IEnumerable<OnlineExamSubjectGroupScheduleViewModel> GetOnlineExamSubjectGroupSchedule(out int TotalRecords, string CentreCode, string OnlineExamExaminationMasterID, int SessionID)
        {
            OnlineExamSubjectGroupScheduleSearchRequest searchRequest = new OnlineExamSubjectGroupScheduleSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.CentreCode = CentreCode;
            searchRequest.GenSessionMaster = SessionID;
            searchRequest.OnlineExamExaminationMasterID = Convert.ToInt32(OnlineExamExaminationMasterID);
            _actionMode = Convert.ToString(TempData["ActionMode"]);
            if (Enum.TryParse(_actionMode, out actionModeEnum))     // checks actionMode i.e. Insert or Update // 
            {
                if (actionModeEnum == ActionModeEnum.Insert)        // parameters for SelectAll procedures under Insert or Update mode condition
                {
                    searchRequest.SortBy = "A.CreatedDate";
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
            List<OnlineExamSubjectGroupScheduleViewModel> listOnlineExamSubjectGroupScheduleViewModel = new List<OnlineExamSubjectGroupScheduleViewModel>();
            List<OnlineExamSubjectGroupSchedule> listOnlineExamSubjectGroupSchedule = new List<OnlineExamSubjectGroupSchedule>();
            IBaseEntityCollectionResponse<OnlineExamSubjectGroupSchedule> baseEntityCollectionResponse = _OnlineExamSubjectGroupScheduleServiceAcess.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listOnlineExamSubjectGroupSchedule = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (OnlineExamSubjectGroupSchedule item in listOnlineExamSubjectGroupSchedule)
                    {
                        OnlineExamSubjectGroupScheduleViewModel OnlineExamSubjectGroupScheduleViewModel = new OnlineExamSubjectGroupScheduleViewModel();
                        OnlineExamSubjectGroupScheduleViewModel.OnlineExamSubjectGroupScheduleDTO = item;
                        listOnlineExamSubjectGroupScheduleViewModel.Add(OnlineExamSubjectGroupScheduleViewModel);
                    }
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listOnlineExamSubjectGroupScheduleViewModel;
        }


        // AjaxHandler Method
        #region AjaxHandler
        public ActionResult AjaxHandler(JQueryDataTableParamModel param, string CentreCode, string OnlineExamExaminationMasterID, int SessionID)
        {
            if (Session["UserType"] != null)
            {
                int TotalRecords;
                var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
                string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc

                IEnumerable<OnlineExamSubjectGroupScheduleViewModel> filteredGroupDescription;
                switch (Convert.ToInt32(sortColumnIndex))
                {
                    case 0:
                        _sortBy = "ExaminationName";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                           
                            _searchBy = string.Empty;
                        }
                        else
                        {

                            _searchBy = "SubjectGroupDescription Like '%" + param.sSearch + "%'";
                        }
                        break;

                    case 1:
                        _sortBy = "ExaminationStartDate";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {

                            _searchBy = string.Empty;
                        }
                        else
                        {

                            _searchBy = "SubjectGroupDescription Like '%" + param.sSearch + "%'";
                        }
                        break;
                    case 2:
                        _sortBy = "ExaminationEndDate";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {

                            _searchBy = string.Empty;
                        }
                        else
                        {

                            _searchBy = "SubjectGroupDescription Like '%" + param.sSearch + "%'";
                        }
                        break;
                    case 3:
                        _sortBy = "SubjectGroupDescription";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {

                            _searchBy = string.Empty;
                        }
                        else
                        {

                            _searchBy = "SubjectGroupDescription Like '%" + param.sSearch + "%'";
                        }
                        break;
                     
                }
                _sortDirection = sortDirection;
                _rowLength = param.iDisplayLength;
                _startRow = param.iDisplayStart;
                filteredGroupDescription = GetOnlineExamSubjectGroupSchedule(out TotalRecords, CentreCode, OnlineExamExaminationMasterID, SessionID);


                var records = filteredGroupDescription.Skip(0).Take(param.iDisplayLength);
                var result = from c in records select new[] { Convert.ToString(c.ExamName), Convert.ToString(c.ExaminationStartDate), Convert.ToString(c.ExaminationEndDate), Convert.ToString(c.ID), Convert.ToString(c.SelectedCentreCode), Convert.ToString(c.OnlineExamExaminationMasterID), Convert.ToString(c.CourseYearName), Convert.ToString(c.CourseYearCode), Convert.ToString(c.OrgSemesterName), Convert.ToString(c.CourseYearID), Convert.ToString(c.SemesterMstID), Convert.ToString(c.SubjectGroupDescription), Convert.ToString(c.ExaminationName), Convert.ToString(c.ExaminationStartTime), Convert.ToString(c.OnlineExamExaminationCourseApplicableID), Convert.ToString(c.OnlineExamQuestionBankMasterID), Convert.ToString(c.SubjectID), Convert.ToString(c.SubjectGroupID), Convert.ToString(c.CombinationCode),Convert.ToString(c.OnlineExamSubjectGroupScheduleID) };
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