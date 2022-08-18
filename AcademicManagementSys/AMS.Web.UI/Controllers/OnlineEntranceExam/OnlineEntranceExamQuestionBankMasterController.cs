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
using System.IO;
namespace AMS.Web.UI.Controllers
{
    public class OnlineEntranceExamQuestionBankMasterController : BaseController
    {
        #region ------------CONTROLLER CLASS VARIABLE------------

        OnlineEntranceExamQuestionBankMasterViewModel onlineEntranceExamQuestionBankMaster = null;
        IOnlineEntranceExamQuestionBankMasterServiceAccess onlineEntranceExamQuestionBankMasterServiceAccess = null;
        IOrganisationSubjectMasterServiceAccess organizationSubjectMasterServiceAccess = null;

        private readonly ILogger _logException;
        ActionModeEnum actionModeEnum;
        string _actionMode = string.Empty;
        string _sortBy = string.Empty;
        string _searchBy = string.Empty;
        string _sortDirection = string.Empty;
        int _startRow;
        int _rowLength;
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

        #endregion

        #region -----------CONTROLLER CLASS CONSTRUCTOR----------
        public OnlineEntranceExamQuestionBankMasterController()
        {
            onlineEntranceExamQuestionBankMasterServiceAccess = new OnlineEntranceExamQuestionBankMasterServiceAccess();
            organizationSubjectMasterServiceAccess = new OrganisationSubjectMasterServiceAccess();

        }
        #endregion


        #region -----------CONTROLLER Methods----------

        public ActionResult Index()
        {
            if (Convert.ToString(Session["UserType"]) == "A" || Convert.ToInt32(Session["SuperUser"]) > 0 || Convert.ToInt32(Session["AcadMgr"]) > 0 || Convert.ToInt32(Session["EstMgr"]) > 0)
            {
                return View("/Views/OnlineEntranceExam/OnlineEntranceExamQuestionBankMaster/Index.cshtml");
            }
            else
            {
                return RedirectToAction("UnauthorizedAccess", "Home");
            }
        }


        public ActionResult List(string actionMode, string centreCode, string universityID, string departmentID, string course, string courseYr, string subjectName, int subjectID = 0)
        {
            try
            {
                OnlineEntranceExamQuestionBankMasterViewModel model = new OnlineEntranceExamQuestionBankMasterViewModel();
                model.SelectedCentreCode = centreCode;
                model.SelectedUniversityID = universityID;
                model.DepartmentID = Convert.ToInt32(departmentID);
                model.SelectedCourseID = course;
                model.SelectedCourseYearID = courseYr;
                if (subjectID > 0)
                {
                    model.SubjectName = subjectName;
                }

                int AdminRoleMasterID = 0;
                if (Session["RoleID"] == null)
                {
                    AdminRoleMasterID = Convert.ToInt32(Session["DefaultRoleID"]);
                }
                else
                {
                    AdminRoleMasterID = Convert.ToInt32(Session["RoleID"]);
                }
                List<AdminRoleApplicableDetails> listAdminRoleApplicableDetails = GetAdminRoleApplicableCentre(AdminRoleMasterID, Convert.ToInt32(Session["PersonID"]));
                AdminRoleApplicableDetails admin = null;

                foreach (var item in listAdminRoleApplicableDetails)
                {
                    admin = new AdminRoleApplicableDetails();
                    admin.CentreCode = item.CentreCode;
                    admin.CentreName = item.CentreName;
                    admin.ScopeIdentity = item.ScopeIdentity;
                    model.ListGetAdminRoleApplicableCentre.Add(admin);
                }
                foreach (var b in model.ListGetAdminRoleApplicableCentre)
                {
                    b.CentreCode = b.CentreCode + ":" + b.ScopeIdentity;
                }


                if (centreCode != null && centreCode != "")
                {
                    model.ListOrganisationUniversityMaster = GetListOrganisationUniversityMaster(centreCode);
                    string[] splited = centreCode.Split(':');
                    if (String.IsNullOrEmpty(centreCode))
                    {
                        throw new ArgumentNullException("CentreCode");
                    }
                    int id = 0;
                    bool isValid = Int32.TryParse(centreCode, out id);
                    model.ListOrganisationDepartmentMaster = GetListOrganisationMasterCentreAndRoleWise(splited[0], splited[1], AdminRoleMasterID);

                }

                if (centreCode != null && centreCode != "" && universityID != null && universityID != "")
                {
                    string[] splited = centreCode.Split(':');
                    model.ListOnlineExamCourse = GetCourseByCentreCodeAndUniversity(splited[0], universityID);
                }

                if (course != null && course != "")
                {
                    model.ListOrganisationCourseYear = GetCourseYearFromBranchMasterID(Convert.ToInt32(course));
                }



                if (!string.IsNullOrEmpty(actionMode))
                {
                    TempData["ActionMode"] = actionMode;
                }
                return PartialView("/Views/OnlineEntranceExam/OnlineEntranceExamQuestionBankMaster/List.cshtml", model);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }


        [HttpGet]
        public ActionResult CreateSubject()
        {
            OnlineEntranceExamQuestionBankMasterViewModel model = new OnlineEntranceExamQuestionBankMasterViewModel();


            int AdminRoleMasterID = 0;
            if (Session["RoleID"] == null)
            {
                AdminRoleMasterID = Convert.ToInt32(Session["DefaultRoleID"]);
            }
            else
            {
                AdminRoleMasterID = Convert.ToInt32(Session["RoleID"]);
            }
            List<AdminRoleApplicableDetails> listAdminRoleApplicableDetails = GetAdminRoleApplicableCentre(AdminRoleMasterID, Convert.ToInt32(Session["PersonID"]));
            AdminRoleApplicableDetails admin = null;

            foreach (var item in listAdminRoleApplicableDetails)
            {
                admin = new AdminRoleApplicableDetails();
                admin.CentreCode = item.CentreCode;
                admin.CentreName = item.CentreName;
                admin.ScopeIdentity = item.ScopeIdentity;
                model.ListGetAdminRoleApplicableCentre.Add(admin);
            }
            foreach (var b in model.ListGetAdminRoleApplicableCentre)
            {
                b.CentreCode = b.CentreCode + ":" + b.ScopeIdentity;
            }

            //--------------------------------------For Acadamic----------------------------------------//
            var list = new List<SelectListItem>
            {           
            new SelectListItem { Text = "Select Academic", Value="" },
            new SelectListItem { Text = "Academic", Value = "1" },
            new SelectListItem { Text = "Non-Academic", Value = "2" },
           };
            ViewData["Academic"] = list;
            return PartialView("/Views/OnlineEntranceExam/OnlineEntranceExamQuestionBankMaster/CreateSubject.cshtml", model);
        }

        [HttpPost]
        public ActionResult CreateSubject(OnlineEntranceExamQuestionBankMasterViewModel model)
        {
            try
            {
                //if (ModelState.IsValid)
                //{
                if (model != null && model.OnlineEntranceExamQuestionBankMasterDTO != null)
                {
                    model.OnlineEntranceExamQuestionBankMasterDTO.SubjectID = model.SubjectID;
                    // model.OnlineEntranceExamQuestionBankMasterDTO.SubjectgroupID = model.SubjectgroupID;
                    model.OnlineEntranceExamQuestionBankMasterDTO.SubjectGroupID = model.SubjectGroupID;
                    model.OnlineEntranceExamQuestionBankMasterDTO.CourseYearDetailID = model.CourseYearDetailID;
                    model.OnlineEntranceExamQuestionBankMasterDTO.DepartmentID = model.DepartmentID;
                    model.OnlineEntranceExamQuestionBankMasterDTO.IsAcademic = model.IsAcademic;
                    model.OnlineEntranceExamQuestionBankMasterDTO.OldOnlineExamQuestionBankMasterID = model.OldOnlineExamQuestionBankMasterID;

                    model.OnlineEntranceExamQuestionBankMasterDTO.ConnectionString = _connectioString;
                    model.OnlineEntranceExamQuestionBankMasterDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);


                    IBaseEntityResponse<OnlineEntranceExamQuestionBankMaster> response = onlineEntranceExamQuestionBankMasterServiceAccess.InsertSubjectOnlineExamQuestionBank(model.OnlineEntranceExamQuestionBankMasterDTO);
                    model.OnlineEntranceExamQuestionBankMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                }
                return Json(model.OnlineEntranceExamQuestionBankMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
                //}
                //else
                //{
                //    return Json("Please review your form");
                //}
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }


        [HttpGet]
        public ActionResult CreateQuestionBank(string OnlineExamQuestionBankMastrID)
        {
            try
            {
                OnlineEntranceExamQuestionBankMasterViewModel model = new OnlineEntranceExamQuestionBankMasterViewModel();
                string[] Arrays = OnlineExamQuestionBankMastrID.Split('~');
                model.OnlineExamQuestionBankMasterID = Convert.ToInt32(Arrays[0]);

                //int subjectGroupID = Convert.ToInt32(Arrays[1]);
                List<OrganisationSyllabusGroupMaster> ListSyllabusGroupUnit = GetSyllabusGroupUnitList(Convert.ToInt32(Arrays[1]));
                OrganisationSyllabusGroupMaster syllabusUnit = null;

                foreach (var item in ListSyllabusGroupUnit)
                {
                    syllabusUnit = new OrganisationSyllabusGroupMaster();
                    syllabusUnit.SyllabusGrpAndDetailID = Convert.ToString(item.SyllabusGroupID) + "~" + Convert.ToString(item.SyllabusGroupDetID);
                    syllabusUnit.UnitDescription = item.UnitDescription;

                    model.ListSyllabusGroupUnit.Add(syllabusUnit);
                }

                model.ListQuestionLevelMaster = GetGeneralQuestionLevelMaster();
                model.QuestionTypeList = GetQuestionTypeList();
                return PartialView("/Views/OnlineEntranceExam/OnlineEntranceExamQuestionBankMaster/CreateQuestionBank.cshtml", model);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }


        [HttpPost]
        public ActionResult CreateQuestionBank(OnlineEntranceExamQuestionBankMasterViewModel model)
        {
            try
            {
                if (model != null && model.OnlineEntranceExamQuestionBankMasterDTO != null)
                {
                    model.OnlineEntranceExamQuestionBankMasterDTO.ConnectionString = _connectioString;
                    model.OnlineEntranceExamQuestionBankMasterDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);                    
                    model.OnlineEntranceExamQuestionBankMasterDTO.OnlineExamQuestionBankMasterID = model.OnlineExamQuestionBankMasterID;
                    model.OnlineEntranceExamQuestionBankMasterDTO.GeneralQuestionTypeID = model.GeneralQuestionTypeID;
                    model.OnlineEntranceExamQuestionBankMasterDTO.GeneralQuestionLevelID = model.GeneralQuestionLevelID;
                    model.OnlineEntranceExamQuestionBankMasterDTO.SyllabusGroupID = model.SyllabusGroupID;
                    model.OnlineEntranceExamQuestionBankMasterDTO.SyllabusGroupDetID = model.SyllabusGroupDetID;
                    model.OnlineEntranceExamQuestionBankMasterDTO.SyllabusTopicGroupID = model.SyllabusTopicGroupID;
                    if (model.IsQuestionInImage == true)
                    {
                        model.OnlineEntranceExamQuestionBankMasterDTO.IsQuestionInImage = model.IsQuestionInImage;
                        model.OnlineEntranceExamQuestionBankMasterDTO.ImageType = model.ImageType;
                        model.OnlineEntranceExamQuestionBankMasterDTO.ImageName = model.ImageName;
                    }
                    else
                    {
                        model.OnlineEntranceExamQuestionBankMasterDTO.QuestionLableText = model.QuestionLableText;
                    }                    

                    model.OnlineEntranceExamQuestionBankMasterDTO.SelectedXml = model.SelectedXml;
                    IBaseEntityResponse<OnlineEntranceExamQuestionBankMaster> response = onlineEntranceExamQuestionBankMasterServiceAccess.InsertOnlineEntranceExamQuestionBankMaster(model.OnlineEntranceExamQuestionBankMasterDTO);
                    model.OnlineEntranceExamQuestionBankMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                }
                return Json(model.OnlineEntranceExamQuestionBankMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        public ActionResult Delete(int ID)
        {
            OnlineEntranceExamQuestionBankMasterViewModel model = new OnlineEntranceExamQuestionBankMasterViewModel();
            model.OnlineEntranceExamQuestionBankMasterDTO.OnlineExamQuestionBankAnsDetailsID = ID;
            return PartialView("/Views/OnlineEntranceExam/OnlineEntranceExamQuestionBankMaster/Delete.cshtml", model);
        }

        [HttpPost]
        public ActionResult Delete(OnlineEntranceExamQuestionBankMasterViewModel model)
        {
            model.OnlineEntranceExamQuestionBankMasterDTO.ConnectionString = _connectioString;
            model.OnlineEntranceExamQuestionBankMasterDTO.DeletedBy = Convert.ToInt32(Session["UserID"]);
            model.OnlineEntranceExamQuestionBankMasterDTO.OnlineExamQuestionBankAnsDetailsID = model.OnlineExamQuestionBankAnsDetailsID;

            IBaseEntityResponse<OnlineEntranceExamQuestionBankMaster> response = onlineEntranceExamQuestionBankMasterServiceAccess.DeleteOnlineEntranceExamQuestionBankMaster(model.OnlineEntranceExamQuestionBankMasterDTO);
            model.OnlineEntranceExamQuestionBankMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Delete);

            return Json(model.OnlineEntranceExamQuestionBankMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult View(int QuestionBankDetailID)
        {
            OnlineEntranceExamQuestionBankMasterViewModel model = new OnlineEntranceExamQuestionBankMasterViewModel();
            model.OnlineEntranceExamQuestionBankMasterDTO.OnlineExamQuestionBankAnsDetailsID = QuestionBankDetailID;
            model.GetQuestionBankAndDetailList = GetQuestionBankAndDetailList(QuestionBankDetailID);


            return PartialView("/Views/OnlineEntranceExam/OnlineEntranceExamQuestionBankMaster/View.cshtml", model);
        }

        #endregion


        #region ---------CONTROLLER AJAX HANDLER METHODS---------

        public ActionResult AjaxHandler(JQueryDataTableParamModel param, string departmentID, string courseYrID, int subejctID)
        {
            int TotalRecords;
            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc

            IEnumerable<OnlineEntranceExamQuestionBankMasterViewModel> filteredOnlineEntranceExamQuestionBankMaster;
            switch (Convert.ToInt32(sortColumnIndex))
            {
                case 0:
                    _sortBy = "A.Description";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "QuestionType Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;
                case 1:
                    _sortBy = "QuestionLableText";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "QuestionLableText Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;
                case 2:
                    _sortBy = "OptionText";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "OptionText Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;
            }

            _sortDirection = sortDirection;
            _rowLength = param.iDisplayLength;
            _startRow = param.iDisplayStart;
            if (!string.IsNullOrEmpty(courseYrID))
            {
                filteredOnlineEntranceExamQuestionBankMaster = GetOnlineEntranceExamQuestionBankMaster(departmentID, courseYrID, subejctID, out TotalRecords);
            }
            else
            {
                filteredOnlineEntranceExamQuestionBankMaster = new List<OnlineEntranceExamQuestionBankMasterViewModel>();
                TotalRecords = 0;
            }
            var records = filteredOnlineEntranceExamQuestionBankMaster.Skip(0).Take(param.iDisplayLength);
            var result = from c in records select new[] { 
                                                        Convert.ToString(c.SubjectGroupDesc + " - " + c.SubjectName), 
                                                        Convert.ToString(c.SubjectGroupID), 
                                                        Convert.ToString(c.SubjectID), 
                                                        Convert.ToString(c.DepartmentID), 
                                                        Convert.ToString(c.OnlineExamQuestionBankMasterID), 
                                                        Convert.ToString(c.IsAcademic), 
                                                        Convert.ToString(c.QuestionLableText != null ? c.QuestionLableText : ""), 
                                                        Convert.ToString(c.ImageType), 
                                                        Convert.ToString(c.ImageName), 
                                                        Convert.ToString(c.IsQuestionInImage), 
                                                        Convert.ToString(c.OptionImage), 
                                                        Convert.ToString(c.OptionText),
                                                        Convert.ToString(c.IsAnswer),
                                                        Convert.ToString(c.OnlineQuestionBankDetailsID),
                                                        Convert.ToString(c.OnlineExamQuestionBankAnsDetailsID)};

            return Json(new { sEcho = param.sEcho, iTotalRecords = TotalRecords, iTotalDisplayRecords = TotalRecords, aaData = result }, JsonRequestBehavior.AllowGet);
        }

        #endregion


        #region Non-Action Methods

        [NonAction]
        public IEnumerable<OnlineEntranceExamQuestionBankMasterViewModel> GetOnlineEntranceExamQuestionBankMaster(string departmentID, string courseYrID, int subejctID, out int TotalRecords)
        {
            OnlineEntranceExamQuestionBankMasterSearchRequest searchRequest = new OnlineEntranceExamQuestionBankMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            _actionMode = Convert.ToString(TempData["ActionMode"]);
            if (Enum.TryParse(_actionMode, out actionModeEnum))     // checks actionMode i.e. Insert or Update // 
            {
                if (actionModeEnum == ActionModeEnum.Insert)        // parameters for SelectAll procedures under Insert or Update mode condition
                {
                    searchRequest.SortBy = "B.CreatedDate";
                    searchRequest.StartRow = 0;
                    searchRequest.EndRow = 10;
                    searchRequest.SearchBy = string.Empty;
                    searchRequest.SortDirection = "Desc";
                    
                    searchRequest.DepartmentID = Convert.ToInt32(departmentID);
                    searchRequest.CourseYearDetailID = Convert.ToInt32(courseYrID);
                    searchRequest.SubjectID = subejctID;
                }
            }
            else
            {
                searchRequest.SortBy = _sortBy;                     // parameters for SelectAll procedures under normal condition
                searchRequest.StartRow = _startRow;
                searchRequest.EndRow = _startRow + _rowLength;
                searchRequest.SearchBy = _searchBy;
                searchRequest.SortDirection = _sortDirection;
               
                searchRequest.DepartmentID = Convert.ToInt32(departmentID);
                searchRequest.CourseYearDetailID = Convert.ToInt32(courseYrID);
                searchRequest.SubjectID = subejctID;
            }

            List<OnlineEntranceExamQuestionBankMasterViewModel> listOnlineExamQuesBankMasterVM = new List<OnlineEntranceExamQuestionBankMasterViewModel>();
            List<OnlineEntranceExamQuestionBankMaster> listOnineExam = new List<OnlineEntranceExamQuestionBankMaster>();
            IBaseEntityCollectionResponse<OnlineEntranceExamQuestionBankMaster> baseEntityCollectionResponse = onlineEntranceExamQuestionBankMasterServiceAccess.GetOnlineEntranceExamQuestionBankMasterSelectAll(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listOnineExam = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (OnlineEntranceExamQuestionBankMaster item in listOnineExam)
                    {
                        OnlineEntranceExamQuestionBankMasterViewModel OnlineExamQuestionViewModel = new OnlineEntranceExamQuestionBankMasterViewModel();
                        OnlineExamQuestionViewModel.OnlineEntranceExamQuestionBankMasterDTO = item;
                        listOnlineExamQuesBankMasterVM.Add(OnlineExamQuestionViewModel);
                    }
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;

            return listOnlineExamQuesBankMasterVM;
        }


        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult GetUniversityByCentreCode(string centreCode)
        {
            string[] splited;
            splited = centreCode.Split(':');
            //onlineEntranceExamQuestionBankMaster.SelectedCentreName = splited[1];
            centreCode = splited[0];
            if (String.IsNullOrEmpty(centreCode))
            {
                throw new ArgumentNullException("SelectedCentreCode");
            }
            int id = 0;
            bool isValid = Int32.TryParse(centreCode, out id);
            var university = GetListOrganisationUniversityMaster(centreCode);
            var result = (from s in university
                          select new
                          {
                              id = s.ID,
                              name = s.UniversityName,
                          }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        //Get Department by Center code.
        public ActionResult GetDepartmentByCentreCode(string centreCode)
        {
            int AdminRoleMasterID = 0;
            if (Convert.ToString(Session["UserType"]) == "A")
            {
                AdminRoleMasterID = 0;
            }
            else
            {
                if (Session["RoleID"] == null)
                {
                    AdminRoleMasterID = Convert.ToInt32(Session["DefaultRoleID"]);
                }
                else
                {
                    AdminRoleMasterID = Convert.ToInt32(Session["RoleID"]);
                }
            }
            string[] splited = centreCode.Split(':');
            if (String.IsNullOrEmpty(centreCode))
            {
                throw new ArgumentNullException("CentreCode");
            }
            int id = 0;
            bool isValid = Int32.TryParse(centreCode, out id);
            var department = GetListOrganisationMasterCentreAndRoleWise(splited[0], splited[1], AdminRoleMasterID);
            var result = (from s in department
                          select new
                          {
                              id = s.ID,
                              name = s.DepartmentName,
                          }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        //Get Course from university and Center code.
        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult GetCourseFromCentreCodeAndUniversity(string centreCode, string universityID)
        {
            string[] splited;
            splited = centreCode.Split(':');
            //onlineEntranceExamQuestionBankMaster.SelectedCentreName = splited[1];
            centreCode = splited[0];
            if (String.IsNullOrEmpty(centreCode))
            {
                throw new ArgumentNullException("SelectedCentreCode");
            }
            int id = 0;
            bool isValid = Int32.TryParse(centreCode, out id);
            var course = GetCourseByCentreCodeAndUniversity(centreCode, universityID);
            var result = (from s in course
                          select new
                          {
                              id = s.OrgBranchMasterID,
                              name = s.BranchDescription,
                          }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }


        //Get Course from course id.
        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult GetCourseYearFromBranchMaster(int branchMasterID)
        {

            var courseYear = GetCourseYearFromBranchMasterID(branchMasterID);
            var result = (from s in courseYear
                          select new
                          {
                              id = s.SelectedCourseYearID,
                              name = s.CourseYearDetailsDescription,
                          }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public ActionResult GetSubjectSearchList(string term)
        {
            var subject = GetSubjectList(term);
            return Json(subject, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GetCourseYearDetailList(string term)
        {
            var course = GetCourseYearDetailSearchList(term);
            var result = (from s in course
                          select new
                          {
                              id = s.ID,
                              name = s.CourseDescription,
                          }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        //Get Subject from course Yr id.
        [AcceptVerbs(HttpVerbs.Get)]
        public JsonResult GetSubjectFromCourseYearDetail(int courseYearID)
        {
            var subject = GetSubjectGroupFromCourseYearDetail(courseYearID);
            var result = (from s in subject
                          select new
                          {
                              //id = s.SubjectIDnew + "~" + s.SubjectgroupID,
                              id = s.SubjectID + "~" + s.SubjectGroupID,
                              name = s.SubjectName,
                          }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }



        protected List<GeneralQuestionLevelMaster> GetGeneralQuestionLevelMaster()
        {
            GeneralQuestionLevelMasterSearchRequest searchRequest = new GeneralQuestionLevelMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            List<GeneralQuestionLevelMaster> listGeneralQuestionLevelMaster = new List<GeneralQuestionLevelMaster>();
            IBaseEntityCollectionResponse<GeneralQuestionLevelMaster> baseEntityCollectionResponse = onlineEntranceExamQuestionBankMasterServiceAccess.GetGeneralQuestionLevelMasterList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listGeneralQuestionLevelMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listGeneralQuestionLevelMaster;
        }

        protected List<OrganisationSyllabusGroupMaster> GetSyllabusGroupUnitList(int subjectGroupID)
        {
            OrganisationSyllabusGroupMasterSearchRequest searchRequest = new OrganisationSyllabusGroupMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.SubjectGroupID = subjectGroupID;
            List<OrganisationSyllabusGroupMaster> listSyllabusUnit = new List<OrganisationSyllabusGroupMaster>();
            IBaseEntityCollectionResponse<OrganisationSyllabusGroupMaster> baseEntityCollectionResponse = onlineEntranceExamQuestionBankMasterServiceAccess.GetSyllabusGroupUnitList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listSyllabusUnit = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listSyllabusUnit;
        }

        //Get Subject from course Yr id.
        [AcceptVerbs(HttpVerbs.Get)]
        public JsonResult GetSyllabusGroupTopicList(string syllabusGroupDetail)
        {
            string[] Arrays = syllabusGroupDetail.Split('~');
            int syllabusGroupID = Convert.ToInt32(Arrays[0]);
            int syllabusGroupDetID = Convert.ToInt32(Arrays[1]);

            var subject = GetSyllabusGroupTopicMasterList(syllabusGroupID, syllabusGroupDetID);
            var result = (from s in subject
                          select new
                          {
                              //id = s.SubjectIDnew + "~" + s.SubjectgroupID,
                              id = s.SyllabusGrpTopicsID,
                              name = s.TopicName,
                          }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }



        protected List<OrganisationSyllabusGroupMaster> GetSyllabusGroupTopicMasterList(int syllabusGroupID, int syllabusGroupDetID)
        {
            OrganisationSyllabusGroupMasterSearchRequest searchRequest = new OrganisationSyllabusGroupMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.SyllabusGroupID = syllabusGroupID;
            searchRequest.SyllabusGroupDetID = syllabusGroupDetID;

            List<OrganisationSyllabusGroupMaster> listSyllabusTopic = new List<OrganisationSyllabusGroupMaster>();
            IBaseEntityCollectionResponse<OrganisationSyllabusGroupMaster> baseEntityCollectionResponse = onlineEntranceExamQuestionBankMasterServiceAccess.GetSyllabusGroupTopicMasterList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listSyllabusTopic = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listSyllabusTopic;
        }

        //For option img.
        [AcceptVerbs(HttpVerbs.Post)]
        public JsonResult UploadFile()
        {
            string _imgname = string.Empty;
            if (System.Web.HttpContext.Current.Request.Files.AllKeys.Any())
            {
                var pic = System.Web.HttpContext.Current.Request.Files["MyImages"];
                if (pic.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(pic.FileName);
                    var _ext = Path.GetExtension(pic.FileName);

                    _imgname = Guid.NewGuid().ToString();
                    var _comPath = Server.MapPath("~") + "\\Content\\UploadedFiles\\AnswerImage\\";
                    _imgname = "option_" + _imgname + _ext;

                    if (!Directory.Exists(_comPath))
                    {
                        Directory.CreateDirectory(_comPath);
                    }
                    pic.SaveAs(_comPath + "\\" + Path.GetFileName(_imgname));

                    ViewBag.Msg = _comPath;
                    var path = _comPath;
                    MemoryStream ms = new MemoryStream();
                }
            }
            return Json(Convert.ToString(_imgname), JsonRequestBehavior.AllowGet);
        }

        //Get Question and its option.
        protected List<OnlineEntranceExamQuestionBankMaster> GetQuestionBankAndDetailList(int onlineExamQuestionBankAnsDetailsID)
        {
            OnlineEntranceExamQuestionBankMasterSearchRequest searchRequest = new OnlineEntranceExamQuestionBankMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            List<OnlineEntranceExamQuestionBankMaster> listQuestionAndOption = new List<OnlineEntranceExamQuestionBankMaster>();
            searchRequest.OnlineExamQuestionBankAnsDetailsID = onlineExamQuestionBankAnsDetailsID;
            IBaseEntityCollectionResponse<OnlineEntranceExamQuestionBankMaster> baseEntityCollectionResponse = onlineEntranceExamQuestionBankMasterServiceAccess.GetQuestionBankAndDetailList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listQuestionAndOption = baseEntityCollectionResponse.CollectionResponse.ToList();

                }
            }
            return listQuestionAndOption;
        }

        //For Question Img
        [AcceptVerbs(HttpVerbs.Post)]
        public JsonResult UploadQuestionFile()
        {
            string _imgname = string.Empty;
            if (System.Web.HttpContext.Current.Request.Files.AllKeys.Any())
            {
                var pic = System.Web.HttpContext.Current.Request.Files["MyImages"];
                if (pic.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(pic.FileName);
                    var _ext = Path.GetExtension(pic.FileName);

                    _imgname = Guid.NewGuid().ToString();
                    var _comPath = Server.MapPath("~") + "\\Content\\UploadedFiles\\QuestionImage\\";
                    _imgname = "que_" + _imgname + _ext;

                    if (!Directory.Exists(_comPath))
                    {
                        Directory.CreateDirectory(_comPath);
                    }
                    pic.SaveAs(_comPath + "\\" + Path.GetFileName(_imgname));

                    ViewBag.Msg = _comPath;
                    var path = _comPath;
                    MemoryStream ms = new MemoryStream();
                }
            }
            return Json(Convert.ToString(_imgname), JsonRequestBehavior.AllowGet);
        }


        protected List<OnlineEntranceExamQuestionBankMaster> GetCourseByCentreCodeAndUniversity(string centreCode, string universityID)
        {
            OnlineEntranceExamQuestionBankMasterSearchRequest searchRequest = new OnlineEntranceExamQuestionBankMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.SelectedCentreCode = centreCode;
            searchRequest.SelectedUniversityID = universityID;
            //searchRequest.SearchType = 1;
            List<OnlineEntranceExamQuestionBankMaster> courseList = new List<OnlineEntranceExamQuestionBankMaster>();
            IBaseEntityCollectionResponse<OnlineEntranceExamQuestionBankMaster> baseEntityCollectionResponse = onlineEntranceExamQuestionBankMasterServiceAccess.GetCourseByCentreCodeAndUniversity(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    courseList = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return courseList;
        }


        protected List<OnlineEntranceExamQuestionBankMaster> GetCourseYearFromBranchMasterID(int branchMasterID)
        {
            OnlineEntranceExamQuestionBankMasterSearchRequest searchRequest = new OnlineEntranceExamQuestionBankMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.SelectedCourseID = Convert.ToString(branchMasterID);

            List<OnlineEntranceExamQuestionBankMaster> courseYearList = new List<OnlineEntranceExamQuestionBankMaster>();
            IBaseEntityCollectionResponse<OnlineEntranceExamQuestionBankMaster> baseEntityCollectionResponse = onlineEntranceExamQuestionBankMasterServiceAccess.GetCourseYearFromBranchMasterID(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    courseYearList = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return courseYearList;
        }

        protected List<OnlineEntranceExamQuestionBankMaster> GetSubjectGroupFromCourseYearDetail(int courseYearID)
        {
            OnlineEntranceExamQuestionBankMasterSearchRequest searchRequest = new OnlineEntranceExamQuestionBankMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.CourseYearID = courseYearID;

            List<OnlineEntranceExamQuestionBankMaster> subjectGroupList = new List<OnlineEntranceExamQuestionBankMaster>();
            IBaseEntityCollectionResponse<OnlineEntranceExamQuestionBankMaster> baseEntityCollectionResponse = onlineEntranceExamQuestionBankMasterServiceAccess.GetSubjectGroupFromCourseYearDetail(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    subjectGroupList = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return subjectGroupList;
        }

        #endregion
    }
}
