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
    public class OnlineExamQuestionBankMasterAndDetailsController : BaseController
    {
        #region ------------CONTROLLER CLASS VARIABLE------------
        IOnlineExamQuestionBankMasterAndDetailsServiceAccess _onlineExamQuestionBankMasterAndDetailsServiceAccess = null;
        IGeneralQuestionTypeMasterServiceAccess _generalQuestionTypeMasterServiceAcess = null;
        IOrganisationCourseYearDetailsServiceAccess _organisationCourseYearDetailsServiceAccess = null;
        IOrganisationSubjectGroupDetailsServiceAccess _organisationSubjectGroupDetailsServiceAccess = null;
        IGeneralQuestionLevelMasterServiceAccess _GeneralQuestionLevelMasterServiceAccess = null;


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
        public OnlineExamQuestionBankMasterAndDetailsController()
        {
            _onlineExamQuestionBankMasterAndDetailsServiceAccess = new OnlineExamQuestionBankMasterAndDetailsServiceAccess();
            _generalQuestionTypeMasterServiceAcess = new GeneralQuestionTypeMasterServiceAccess();
            _organisationCourseYearDetailsServiceAccess = new OrganisationCourseYearDetailsServiceAccess();
            _organisationSubjectGroupDetailsServiceAccess = new OrganisationSubjectGroupDetailsServiceAccess();
            _GeneralQuestionLevelMasterServiceAccess = new GeneralQuestionLevelMasterServiceAccess();
           

        }
        #endregion

        #region ------------CONTROLLER ACTION METHODS------------
        public ActionResult Index()
        {
            if (Convert.ToString(Session["UserType"]) == "A" || Convert.ToInt32(Session["SuperUser"]) > 0 || Convert.ToInt32(Session["AcadMgr"]) > 0 || Convert.ToInt32(Session["EstMgr"]) > 0)
            {
                OnlineExamQuestionBankMasterAndDetailsViewModel model = new OnlineExamQuestionBankMasterAndDetailsViewModel();
                List<OnlineExamQuestionBankMasterAndDetails> QuestionBankMaster = GetListQuestionBankMaster();
                List<SelectListItem> QuestionBankMasterList = new List<SelectListItem>();
                foreach (OnlineExamQuestionBankMasterAndDetails item in QuestionBankMaster)
                {
                    QuestionBankMasterList.Add(new SelectListItem { Text = item.QuestionBankMasterDescription, Value = Convert.ToString(item.OnlineExamQuestionBankMasterID + "~" + item.SubjectID).Trim() });
                }
                ViewBag.QuestionBankMasterList = new SelectList(QuestionBankMasterList, "Value", "Text");
                return View("/Views/OnlineExam/OnlineExamQuestionBankMasterAndDetails/Index.cshtml",model);
            }
            else
            {
                return RedirectToAction("UnauthorizedAccess", "Home");
            }
        }

        public ActionResult List(string actionMode)
        {
            try
            {
                OnlineExamQuestionBankMasterAndDetailsViewModel model = new OnlineExamQuestionBankMasterAndDetailsViewModel();
                if (!string.IsNullOrEmpty(actionMode))
                {
                    TempData["ActionMode"] = actionMode;
                }
                return PartialView("/Views/OnlineExam/OnlineExamQuestionBankMasterAndDetails/List.cshtml", model);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        [HttpGet]
        public ActionResult Create(int OnlineExamQuestionBankMasterID)
        {
            try
            {
                OnlineExamQuestionBankMasterAndDetailsViewModel model = new OnlineExamQuestionBankMasterAndDetailsViewModel();
                //model.QuestionTypeList = GetQuestionTypeList();
                model.OnlineExamQuestionBankMasterID = OnlineExamQuestionBankMasterID;
                List<GeneralQuestionTypeMaster> QuestionTypeMaster = GetQuestionTypeList();
                List<SelectListItem> QuestionTypeMasterList = new List<SelectListItem>();
                foreach (GeneralQuestionTypeMaster item in QuestionTypeMaster)
                {
                    QuestionTypeMasterList.Add(new SelectListItem { Text =item.QuestionType, Value = Convert.ToString(item.GeneralQuestionTypeMasterID +"~" + item.QuestionType) });
                }
                ViewBag.QuestionTypeMasterListt = new SelectList(QuestionTypeMasterList, "Value", "Text");

                List<GeneralQuestionLevelMaster> QuestionLevelMaster = GetQuestionLevelList();
                List<SelectListItem> QuestionLevelMasterList = new List<SelectListItem>();
                foreach (GeneralQuestionLevelMaster item in QuestionLevelMaster)
                {
                    QuestionLevelMasterList.Add(new SelectListItem { Text = item.LevelDescription, Value = Convert.ToString(item.ID) });
                }
                ViewBag.QuestionLevelMasterListt = new SelectList(QuestionLevelMasterList, "Value", "Text");
                return PartialView("/Views/OnlineExam/OnlineExamQuestionBankMasterAndDetails/Create.cshtml", model);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        [HttpPost]
        public ActionResult Create(OnlineExamQuestionBankMasterAndDetailsViewModel model)
        {
            try
            {
                //if (ModelState.IsValid)
                //{
                    if (model != null && model.OnlineExamQuestionBankMasterAndDetailsDTO != null)
                    {
                        model.OnlineExamQuestionBankMasterAndDetailsDTO.ConnectionString = _connectioString;
                        model.OnlineExamQuestionBankMasterAndDetailsDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                        model.OnlineExamQuestionBankMasterAndDetailsDTO.OnlineExamQuestionBankMasterID = model.OnlineExamQuestionBankMasterID;
                        model.OnlineExamQuestionBankMasterAndDetailsDTO.GenQuestionTypeID = model.GenQuestionTypeID;
                        model.OnlineExamQuestionBankMasterAndDetailsDTO.GeneralQuestionLevelMasterID = model.GeneralQuestionLevelMasterID;
                        //model.OnlineExamQuestionBankMasterAndDetailsDTO.SubjectID = model.SubjectID;
                        model.OnlineExamQuestionBankMasterAndDetailsDTO.QuestionLableText = model.QuestionLableText;
                        model.OnlineExamQuestionBankMasterAndDetailsDTO.ImageType = model.ImageType;
                        model.OnlineExamQuestionBankMasterAndDetailsDTO.ImageName = model.ImageName;
                        model.OnlineExamQuestionBankMasterAndDetailsDTO.IsQuestionInImage = model.IsQuestionInImage;
                        model.OnlineExamQuestionBankMasterAndDetailsDTO.IsQuestionDescriptive = model.IsQuestionDescriptive;
                        model.OnlineExamQuestionBankMasterAndDetailsDTO.IsAttachmentCompalsary = model.IsAttachmentCompalsary;
                        model.OnlineExamQuestionBankMasterAndDetailsDTO.SelectedXml = model.SelectedXml;

                        IBaseEntityResponse<OnlineExamQuestionBankMasterAndDetails> response = _onlineExamQuestionBankMasterAndDetailsServiceAccess.InsertOnlineExamQuestionBankMasterAndDetails(model.OnlineExamQuestionBankMasterAndDetailsDTO);
                        model.OnlineExamQuestionBankMasterAndDetailsDTO.errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                    }
                    return Json(model.OnlineExamQuestionBankMasterAndDetailsDTO.errorMessage, JsonRequestBehavior.AllowGet);
           //// }
           //     else
           //     {
           //         return Json("Please review your form");
           //     }
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        [HttpGet]
        public ActionResult Edit(string OnlineExamQuestionBankDetailsID, int OnlineExamQuestionBankMasterID)
        {
            OnlineExamQuestionBankMasterAndDetailsViewModel model = new OnlineExamQuestionBankMasterAndDetailsViewModel();
            try
            {
                model.OnlineExamQuestionBankMasterAndDetailsDTO = new OnlineExamQuestionBankMasterAndDetails();
                model.OnlineExamQuestionBankMasterAndDetailsDTO.OnlineExamQuestionBankDetailsID = Convert.ToInt32(OnlineExamQuestionBankDetailsID);
                model.OnlineExamQuestionBankMasterID = OnlineExamQuestionBankMasterID;
                model.OnlineExamQuestionBankMasterAndDetailsDTO.ConnectionString = _connectioString;
                IBaseEntityResponse<OnlineExamQuestionBankMasterAndDetails> response = _onlineExamQuestionBankMasterAndDetailsServiceAccess.SelectoneOnlineExamQuestionBankMasterAndDetails(model.OnlineExamQuestionBankMasterAndDetailsDTO);
                if (response != null && response.Entity != null)
                {
                    model.OnlineExamQuestionBankMasterAndDetailsDTO.QuestionLableText = response.Entity.QuestionLableText;
                    model.OnlineExamQuestionBankMasterAndDetailsDTO.ImageName = response.Entity.ImageName;
                    model.OnlineExamQuestionBankMasterAndDetailsDTO.ImageType = response.Entity.ImageType;
                    model.OnlineExamQuestionBankMasterAndDetailsDTO.IsQuestionInImage = response.Entity.IsQuestionInImage;
                    model.OnlineExamQuestionBankMasterAndDetailsDTO.GeneralQuestionLevelMasterID = response.Entity.GeneralQuestionLevelMasterID;
                    model.OnlineExamQuestionBankMasterAndDetailsDTO.GenQuestionTypeID = response.Entity.GenQuestionTypeID;
                    model.OnlineExamQuestionBankMasterAndDetailsDTO.IsQuestionDescriptive = response.Entity.IsQuestionDescriptive;
                    model.OnlineExamQuestionBankMasterAndDetailsDTO.IsAttachmentCompalsary = response.Entity.IsAttachmentCompalsary;
                    model.OnlineExamQuestionBankMasterAndDetailsDTO.OptionTextList = response.Entity.OptionTextList;
                }

                List<GeneralQuestionLevelMaster> QuestionLevelMaster = GetQuestionLevelList();
                List<SelectListItem> QuestionLevelMasterList = new List<SelectListItem>();
                foreach (GeneralQuestionLevelMaster item in QuestionLevelMaster)
                {
                    QuestionLevelMasterList.Add(new SelectListItem { Text = item.LevelDescription, Value = Convert.ToString(item.ID) });
                }
                ViewBag.QuestionLevelMasterListt = new SelectList(QuestionLevelMasterList, "Value", "Text");
                List<GeneralQuestionTypeMaster> QuestionTypeMaster = GetQuestionTypeList();
                List<SelectListItem> QuestionTypeMasterList = new List<SelectListItem>();
                foreach (GeneralQuestionTypeMaster item in QuestionTypeMaster)
                {
                    QuestionTypeMasterList.Add(new SelectListItem { Text = item.QuestionType, Value = Convert.ToString(item.GeneralQuestionTypeMasterID) });
                }
                ViewBag.QuestionTypeMasterListt = new SelectList(QuestionTypeMasterList, "Value", "Text");

                return PartialView("/Views/OnlineExam/OnlineExamQuestionBankMasterAndDetails/Edit.cshtml", model);
            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpPost]
        public ActionResult Edit(OnlineExamQuestionBankMasterAndDetailsViewModel model)
        {
            try
            {
                //if (ModelState.IsValid)
                //{
                if (model != null && model.OnlineExamQuestionBankMasterAndDetailsDTO != null)
                {
                    model.OnlineExamQuestionBankMasterAndDetailsDTO.ConnectionString = _connectioString;
                    model.OnlineExamQuestionBankMasterAndDetailsDTO.OnlineExamQuestionBankMasterID = model.OnlineExamQuestionBankMasterID;
                    model.OnlineExamQuestionBankMasterAndDetailsDTO.OnlineExamQuestionBankDetailsID = model.OnlineExamQuestionBankDetailsID;
                    model.OnlineExamQuestionBankMasterAndDetailsDTO.QuestionLableText = model.QuestionLableText;
                    model.OnlineExamQuestionBankMasterAndDetailsDTO.ImageType = model.ImageType;
                    model.OnlineExamQuestionBankMasterAndDetailsDTO.ImageName = model.ImageName;
                    model.OnlineExamQuestionBankMasterAndDetailsDTO.IsQuestionInImage = model.IsQuestionInImage;
                    model.OnlineExamQuestionBankMasterAndDetailsDTO.IsQuestionDescriptive = model.IsQuestionDescriptive;
                    model.OnlineExamQuestionBankMasterAndDetailsDTO.IsAttachmentCompalsary = model.IsAttachmentCompalsary;
                    model.OnlineExamQuestionBankMasterAndDetailsDTO.SelectedXml = model.SelectedXml;
                    model.OnlineExamQuestionBankMasterAndDetailsDTO.ModifiedBy = Convert.ToInt32(Session["UserID"]);
                    IBaseEntityResponse<OnlineExamQuestionBankMasterAndDetails> response = _onlineExamQuestionBankMasterAndDetailsServiceAccess.UpdateOnlineExamQuestionBankMasterAndDetails(model.OnlineExamQuestionBankMasterAndDetailsDTO);
                    model.OnlineExamQuestionBankMasterAndDetailsDTO.errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Update);
                }
                return Json(model.OnlineExamQuestionBankMasterAndDetailsDTO.errorMessage, JsonRequestBehavior.AllowGet);
                //// }
                //     else
                //     {
                //         return Json("Please review your form");
                //     }
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        [HttpGet]
        public ActionResult CreateQuestionBank()
        {
            try
            {

                OnlineExamQuestionBankMasterAndDetailsViewModel model = new OnlineExamQuestionBankMasterAndDetailsViewModel();

                if (Session["RoleID"] == null)
                {
                    int AdminRoleMasterID = !string.IsNullOrEmpty(Convert.ToString(Session["DefaultRoleID"])) ? Convert.ToInt32(Session["DefaultRoleID"]) : 0;
                    List<AdminRoleApplicableDetails> listAdminRoleApplicableDetails = GetAdminRoleApplicableCentre(AdminRoleMasterID, 0);
                    AdminRoleApplicableDetails a = null;
                    foreach (var item in listAdminRoleApplicableDetails)
                    {
                        a = new AdminRoleApplicableDetails();
                        a.CentreCode = item.CentreCode;
                        a.CentreName = item.CentreName;
                        model.AdminRoleApplicableCenter.Add(a);
                    }

                }
                else
                {
                    int AdminRoleMasterID = !string.IsNullOrEmpty(Convert.ToString(Session["RoleID"])) ? Convert.ToInt32(Session["RoleID"]) : 0;
                    List<AdminRoleApplicableDetails> listAdminRoleApplicableDetails = GetAdminRoleApplicableCentreByAcademicManager(AdminRoleMasterID);
                    AdminRoleApplicableDetails a = null;
                    foreach (var item in listAdminRoleApplicableDetails)
                    {
                        if (item.IsSuperUser == 1 || item.IsAcadMgr == 1)
                        {
                            a = new AdminRoleApplicableDetails();
                            a.CentreCode = item.CentreCode;
                            a.CentreName = item.CentreName;
                            model.AdminRoleApplicableCenter.Add(a);
                        }
                    }
                }

                //model.CorseListList = GetCoursesDropList();
                return PartialView("/Views/OnlineExam/OnlineExamQuestionBankMasterAndDetails/CreateQuestionBank.cshtml", model);

            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }

        }

        [HttpPost]
        public ActionResult CreateQuestionBank(OnlineExamQuestionBankMasterAndDetailsViewModel model)
        {

            try
            {

                if (model != null && model.OnlineExamQuestionBankMasterAndDetailsDTO != null)
                {
                    model.OnlineExamQuestionBankMasterAndDetailsDTO.ConnectionString = _connectioString;
                    model.OnlineExamQuestionBankMasterAndDetailsDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                    model.OnlineExamQuestionBankMasterAndDetailsDTO.Center = model.Center;
                    model.OnlineExamQuestionBankMasterAndDetailsDTO.CourseYearDetailID = model.CourseYearDetailID;
                    model.OnlineExamQuestionBankMasterAndDetailsDTO.OrgSemesterMstID = model.OrgSemesterMstID;
                    model.OnlineExamQuestionBankMasterAndDetailsDTO.SubjectID = model.SubjectID;
                    model.OnlineExamQuestionBankMasterAndDetailsDTO.SubjectGroupID = model.SubjectGroupID;

                    IBaseEntityResponse<OnlineExamQuestionBankMasterAndDetails> response = _onlineExamQuestionBankMasterAndDetailsServiceAccess.InsertOnlineExamQuestionBankMaster(model.OnlineExamQuestionBankMasterAndDetailsDTO);
                    model.OnlineExamQuestionBankMasterAndDetailsDTO.errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);

                    return Json(model.OnlineExamQuestionBankMasterAndDetailsDTO.errorMessage, JsonRequestBehavior.AllowGet);
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

            //return Json("Please review your form");
        }

        public ActionResult DeleteImage(string ImageName)
        {
            var errorMessage = string.Empty;
            if (ImageName != null)
            {
                string filePath = Path.Combine(Server.MapPath("~") + "\\Content\\UploadedFiles\\AnswerImage\\", ImageName);
                FileInfo file = new FileInfo(filePath);
                if (Directory.Exists(filePath) || file.Exists)
                {
                    System.IO.File.Delete(filePath);

                }
            }

            return Json(errorMessage, JsonRequestBehavior.AllowGet);
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult GetCourseYearByCenterCode(string SelectedCenterCode)
        {
            var courseCode = GetCourseByCenterCode(SelectedCenterCode);
            var result = (from s in courseCode
                          select new
                          {
                              ID = s.CourseYearDetailID,
                              Name = s.CourseYearDescription,
                              OrgSemesterMstID = s.OrgSemesterMstID,
                          }).ToList();

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult GetSubjectGroup(int SelectedCourseID, int SemesterID)
        {

            var subjectGroup = GetSubjectGroupInfo(SelectedCourseID, SemesterID);
            var result = (from s in subjectGroup
                          select new
                          {
                              id = s.SubjectID,
                              name = s.SubjectName,
                              SubjectGroupID = s.SubjectGroupID,
                          }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        private List<OnlineExamQuestionBankMasterAndDetails> GetCourseByCenterCode(string CenterCodeStr)
        {

            OnlineExamQuestionBankMasterAndDetailsSearchRequest courseYearReq = new OnlineExamQuestionBankMasterAndDetailsSearchRequest();
            courseYearReq.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            courseYearReq.CentreCode = Convert.ToString(CenterCodeStr);
            List<OnlineExamQuestionBankMasterAndDetails> listCourseYear = new List<OnlineExamQuestionBankMasterAndDetails>();
            IBaseEntityCollectionResponse<OnlineExamQuestionBankMasterAndDetails> baseEntityCollectionresponce = _onlineExamQuestionBankMasterAndDetailsServiceAccess.GetCourseYearDetailsByCentreCode(courseYearReq);
            if (baseEntityCollectionresponce != null)
            {

                if (baseEntityCollectionresponce.CollectionResponse != null && baseEntityCollectionresponce.CollectionResponse.Count > 0)
                {
                    listCourseYear = baseEntityCollectionresponce.CollectionResponse.ToList();
                }

            }

            return listCourseYear;

        }

        private List<OnlineExamQuestionBankMasterAndDetails> GetSubjectGroupInfo(int courseYearID, int SemesterID)
        {
            OnlineExamQuestionBankMasterAndDetailsSearchRequest searchReq = new OnlineExamQuestionBankMasterAndDetailsSearchRequest();
            searchReq.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchReq.CourseYearDetailID = Convert.ToInt16(courseYearID);
            searchReq.OrgSemesterMstID = Convert.ToInt16(SemesterID);
            List<OnlineExamQuestionBankMasterAndDetails> listSubjectGrpInfo = new List<OnlineExamQuestionBankMasterAndDetails>();
            IBaseEntityCollectionResponse<OnlineExamQuestionBankMasterAndDetails> baseEntityCollectionResponce = _onlineExamQuestionBankMasterAndDetailsServiceAccess.GetSubjectDetailsByCourseAndSem(searchReq);
            if (baseEntityCollectionResponce != null)
            {

                if (baseEntityCollectionResponce.CollectionResponse != null && baseEntityCollectionResponce.CollectionResponse.Count > 0)
                {
                    listSubjectGrpInfo = baseEntityCollectionResponce.CollectionResponse.ToList();
                }

            }

            return listSubjectGrpInfo;
            //throw new NotImplementedException();
        }


        //protected List<OrganisationSubjectMaster> GetSubjectsList()
        //{

        //    OrganisationSubjectMasterSearchRequest searchRequest = new OrganisationSubjectMasterSearchRequest();
        //    searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
        //    List<OrganisationSubjectMaster> listOrganisationSubjectMaster = new List<OrganisationSubjectMaster>();
        //    IBaseEntityCollectionResponse<OrganisationSubjectMaster> baseEntityCollectionResponse = _organisationSubjectMasterServiceAccess.GetSubjectList(searchRequest);
        //    if (baseEntityCollectionResponse != null)
        //    {
        //        if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
        //        {
        //            listOrganisationSubjectMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
        //        }
        //    }
        //    return listOrganisationSubjectMaster;

        //}


        protected List<OrganisationCourseYearDetails> GetCoursesDropList()
        {
            OrganisationCourseYearDetailsSearchRequest searchReq = new OrganisationCourseYearDetailsSearchRequest();
            searchReq.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            List<OrganisationCourseYearDetails> listOrganisationCourseMaster = new List<OrganisationCourseYearDetails>();
            IBaseEntityCollectionResponse<OrganisationCourseYearDetails> baseEntityCollectionResponse = _organisationCourseYearDetailsServiceAccess.GetCourseYearDetailDescription(searchReq);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listOrganisationCourseMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listOrganisationCourseMaster;

        }

        #endregion
        protected List<OnlineExamQuestionBankMasterAndDetails> GetListQuestionBankMaster()
        {
            OnlineExamQuestionBankMasterAndDetailsSearchRequest searchRequest = new OnlineExamQuestionBankMasterAndDetailsSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            List<OnlineExamQuestionBankMasterAndDetails> listQuestionBankMaster = new List<OnlineExamQuestionBankMasterAndDetails>();
            IBaseEntityCollectionResponse<OnlineExamQuestionBankMasterAndDetails> baseEntityCollectionResponse = _onlineExamQuestionBankMasterAndDetailsServiceAccess.GetListQuestionBankMaster(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listQuestionBankMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listQuestionBankMaster;
        }
        protected List<GeneralQuestionLevelMaster> GetQuestionLevelList()
        {
            GeneralQuestionLevelMasterSearchRequest searchRequest = new GeneralQuestionLevelMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            List<GeneralQuestionLevelMaster> listGeneralQuestionLevelMaster = new List<GeneralQuestionLevelMaster>();
            IBaseEntityCollectionResponse<GeneralQuestionLevelMaster> baseEntityCollectionResponse = _GeneralQuestionLevelMasterServiceAccess.GetGeneralQuestionLevelMasterSearchList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listGeneralQuestionLevelMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listGeneralQuestionLevelMaster;
        }
        #region -----------CONTROLLER NON ACTION METHODS---------
        public IEnumerable<OnlineExamQuestionBankMasterAndDetails> GetOnlineExamQuestionBankMasterAndDetails(out int TotalRecords, int OnlineExamQuestionBankMasterID, int SubjectID)
        {
            List<OnlineExamQuestionBankMasterAndDetails> listOnlineExamQuestionBankMasterAndDetails = new List<OnlineExamQuestionBankMasterAndDetails>();
            OnlineExamQuestionBankMasterAndDetailsSearchRequest searchRequest = new OnlineExamQuestionBankMasterAndDetailsSearchRequest();
            searchRequest.OnlineExamQuestionBankMasterID = OnlineExamQuestionBankMasterID;
            searchRequest.SubjectID = SubjectID;
            //searchRequest.GeneralQuestionLevelMasterID = GeneralQuestionLevelMasterID;
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
            List<OnlineExamQuestionBankMasterAndDetailsViewModel> listOnlineExamQuestionBankMasterAndDetailsViewModel = new List<OnlineExamQuestionBankMasterAndDetailsViewModel>();
            IBaseEntityCollectionResponse<OnlineExamQuestionBankMasterAndDetails> baseEntityCollectionResponse = _onlineExamQuestionBankMasterAndDetailsServiceAccess.OnlineExamExaminationQuestionsList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listOnlineExamQuestionBankMasterAndDetails = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (OnlineExamQuestionBankMasterAndDetails item in listOnlineExamQuestionBankMasterAndDetails)
                    {
                        OnlineExamQuestionBankMasterAndDetailsViewModel OnlineExamQuestionBankMasterAndDetailsViewModel = new OnlineExamQuestionBankMasterAndDetailsViewModel();
                        OnlineExamQuestionBankMasterAndDetailsViewModel.OnlineExamQuestionBankMasterAndDetailsDTO = item;
                        listOnlineExamQuestionBankMasterAndDetailsViewModel.Add(OnlineExamQuestionBankMasterAndDetailsViewModel);
                    }
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listOnlineExamQuestionBankMasterAndDetails;
        }

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
        #endregion

        #region ---------CONTROLLER AJAX HANDLER METHODS---------
        public ActionResult AjaxHandler(JQueryDataTableParamModel param, int OnlineExamQuestionBankMasterID, int SubjectID)
        {

            int TotalRecords;
            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc

            IEnumerable<OnlineExamQuestionBankMasterAndDetails> filteredOnlineExamQuestionBankMasterAndDetails;
            switch (Convert.ToInt32(sortColumnIndex))
            {
                case 0:
                    _sortBy = "OnlineExamQuestionBankDetailsID";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "QuestionLableText Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
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
               
            }
            _sortDirection = sortDirection;
            _rowLength = param.iDisplayLength;
            _startRow = param.iDisplayStart;
            filteredOnlineExamQuestionBankMasterAndDetails = GetOnlineExamQuestionBankMasterAndDetails(out TotalRecords, OnlineExamQuestionBankMasterID, SubjectID);
            var records = filteredOnlineExamQuestionBankMasterAndDetails.Skip(0).Take(param.iDisplayLength);
            var result = from c in records select new[] { Convert.ToString(c.GenQuestionType), Convert.ToString(c.QuestionLableText), Convert.ToString(c.OptionText), Convert.ToString(c.SubjectName), Convert.ToString(c.ID), Convert.ToString(c.GenQuestionTypeID), Convert.ToString(c.SubjectID), Convert.ToString(c.ImageName), Convert.ToString(c.IsQuestionInImage), Convert.ToString(c.OptionImage), Convert.ToString(c.QuestionBankMasterDescription), Convert.ToString(c.OnlineExamQuestionBankDetailsID),Convert.ToString(c.OptionTextList),Convert.ToString(c.OptionImageList),Convert.ToString(c.IsAnswer)};

            return Json(new { sEcho = param.sEcho, iTotalRecords = TotalRecords, iTotalDisplayRecords = TotalRecords, aaData = result }, JsonRequestBehavior.AllowGet);


        }
        #endregion
    }
}


