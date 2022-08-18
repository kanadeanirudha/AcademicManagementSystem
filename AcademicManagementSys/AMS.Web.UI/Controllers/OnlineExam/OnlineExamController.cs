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
using System.IO;
namespace AMS.Web.UI.Controllers
{
    public class OnlineExamController : BaseController
    {
        #region ------------CONTROLLER CLASS VARIABLE------------
        IOnlineExamServiceAccess _OnlineExamServiceAcess = null;
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

        #region ------------CONTROLLER CLASS CONSTRUCTOR------------
        public OnlineExamController()
        {
            _OnlineExamServiceAcess = new OnlineExamServiceAccess();
        }
        #endregion

        #region ------------CONTROLLER ACTION METHODS------------
        public ActionResult Index()
        {
            //OnlineExamViewModel model = new OnlineExamViewModel();
            return View("~/Views/OnlineExam/OnlineExam/Index.cshtml");
        }

        public ActionResult Instructions(int OnlineExamIndStudentExamInfoID)
        {
            OnlineExamViewModel model = new OnlineExamViewModel();
            model.OnlineExamDTO.OnlineExamIndStudentExamInfoID = OnlineExamIndStudentExamInfoID;
            return View("~/Views/OnlineExam/OnlineExam/Instructions.cshtml", model);
        }

        public ActionResult OnlineExam(int OnlineExamIndStudentExamInfoID)
        {
            OnlineExamViewModel model = new OnlineExamViewModel();

            model.OnlineExamDTO = new OnlineExam();
            model.OnlineExamDTO.ConnectionString = _connectioString;
            model.OnlineExamDTO.OnlineExamIndStudentExamInfoID = OnlineExamIndStudentExamInfoID;
            IBaseEntityResponse<OnlineExam> response = _OnlineExamServiceAcess.SelectOnlineExamDetails(model.OnlineExamDTO);
            if (response != null && response.Entity != null)
            {
                model.OnlineExamDTO.ExaminationName = response.Entity.ExaminationName;
                model.OnlineExamDTO.TotalQuestions = response.Entity.TotalQuestions;
                model.OnlineExamDTO.OnlineExamTimeDuration = response.Entity.OnlineExamTimeDuration;
                model.OnlineExamDTO.IsDescriptiveQuestionInExam = response.Entity.IsDescriptiveQuestionInExam;
                model.OnlineExamDTO.IsObjectiveQuestionInExam = response.Entity.IsObjectiveQuestionInExam;
                model.OnlineExamDTO.DescriptiveStartQuestionOrder = response.Entity.DescriptiveStartQuestionOrder;
                model.OnlineExamDTO.ObjectiveStartQuestionOrder = response.Entity.ObjectiveStartQuestionOrder;

                return View("~/Views/OnlineExam/OnlineExam/OnlineExam.cshtml", model);
            }
            else
            {
                return View("~/Views/Home/UnauthorizedAccess.cshtml", model);
            }
        }

        public ActionResult OnlineExamLoadQuestion(int OnlineExamIndStudentExamInfoID, Int16 QuestionOrder)
        {
            OnlineExamViewModel model = new OnlineExamViewModel();
            try
            {
                model.OnlineExamDTO = new OnlineExam();
                model.OnlineExamDTO.ConnectionString = _connectioString;
                model.OnlineExamDTO.OnlineExamIndStudentExamInfoID = OnlineExamIndStudentExamInfoID;
                model.OnlineExamDTO.QuestionOrder = QuestionOrder;

                IBaseEntityResponse<OnlineExam> response = _OnlineExamServiceAcess.SelectOnlineExamQuestion(model.OnlineExamDTO);
                if (response != null && response.Entity != null)
                {
                    model.OnlineExamDTO.QuestionLableText = response.Entity.QuestionLableText;
                    model.OnlineExamDTO.ImageType = response.Entity.ImageType;
                    model.OnlineExamDTO.ImageName = response.Entity.ImageName;
                    model.OnlineExamDTO.IsQuestionInImage = response.Entity.IsQuestionInImage;
                    model.OnlineExamDTO.QuestionOrder = response.Entity.QuestionOrder;
                    model.OnlineExamDTO.AnswerOptionID = response.Entity.AnswerOptionID;
                    model.OnlineExamDTO.IsQuestionDescriptive = response.Entity.IsQuestionDescriptive;
                    model.OnlineExamDTO.IsAttachmentCompalsary = response.Entity.IsAttachmentCompalsary;
                    model.OnlineExamDTO.OptionImage = response.Entity.OptionImage;
                    model.OnlineExamDTO.OptionText = response.Entity.OptionText;
                    model.OnlineExamDTO.OptionIDsList = response.Entity.OptionIDsList;
                    model.OnlineExamDTO.CurrentStatusList = response.Entity.CurrentStatusList;
                    model.OnlineExamDTO.QuestionOrderList = response.Entity.QuestionOrderList;
                    model.OnlineExamDTO.DescriptiveAnswer = response.Entity.DescriptiveAnswer;
                    model.OnlineExamDTO.AttachedDocument = response.Entity.AttachedDocument;
                }
                if (model.OnlineExamDTO.IsQuestionDescriptive == true)
                {
                    return PartialView("/Views/OnlineExam/OnlineExam/OnlineExamLoadDescriptiveQuestion.cshtml", model);
                }
                else
                {
                    return PartialView("/Views/OnlineExam/OnlineExam/OnlineExamLoadQuestion.cshtml", model);
                }

            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        public ActionResult List(string actionmode)
        {
            try
            {
                OnlineExamViewModel model = new OnlineExamViewModel();
                if (!string.IsNullOrEmpty(actionmode))
                {
                    TempData["actionmode"] = actionmode;
                }
                return PartialView("~/Views/OnlineExam/OnlineExam/List.cshtml", model);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        [HttpPost]
        public ActionResult OnlineExamSaveAnswer(OnlineExamViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model != null && model.OnlineExamDTO != null)
                    {
                        model.OnlineExamDTO.ConnectionString = _connectioString;
                        model.OnlineExamDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                        model.OnlineExamDTO.OnlineExamIndStudentExamInfoID = model.OnlineExamIndStudentExamInfoID;
                        model.OnlineExamDTO.QuestionOrder = model.QuestionOrder;
                        model.OnlineExamDTO.AnswerOptionID = model.AnswerOptionID;
                        model.OnlineExamDTO.CurrentStatus = model.CurrentStatus;
                        model.OnlineExamDTO.DescriptiveAnswer = model.DescriptiveAnswer;
                        model.OnlineExamDTO.AttachedDocument = model.AttachedDocument;
                        model.OnlineExamDTO.IsQuestionDescriptive = model.IsQuestionDescriptive;

                        if(model.OnlineExamDTO.CurrentStatus == 2 && model.OnlineExamDTO.AttachedDocument != null)
                        {
                            string filePath = Path.Combine(Server.MapPath("~") + "\\Content\\UploadedFiles\\ExamAttachedDocument\\", model.OnlineExamDTO.AttachedDocument);
                            FileInfo file = new FileInfo(filePath);
                            if (Directory.Exists(filePath) || file.Exists)
                            {
                                System.IO.File.Delete(filePath);
                            }
                            model.OnlineExamDTO.AttachedDocument = null;
                        }

                        IBaseEntityResponse<OnlineExam> response = _OnlineExamServiceAcess.OnlineExamSaveAnswer(model.OnlineExamDTO);
                        model.OnlineExamDTO.errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                    }
                    return Json(model.OnlineExamDTO.errorMessage, JsonRequestBehavior.AllowGet);
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

        [HttpPost]
        public ActionResult OnlineExamFinalSubmit(OnlineExamViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model != null && model.OnlineExamDTO != null)
                    {
                        model.OnlineExamDTO.ConnectionString = _connectioString;
                        model.OnlineExamDTO.ModifiedBy = Convert.ToInt32(Session["UserID"]);
                        model.OnlineExamDTO.OnlineExamIndStudentExamInfoID = model.OnlineExamIndStudentExamInfoID;
                        IBaseEntityResponse<OnlineExam> response = _OnlineExamServiceAcess.OnlineExamFinalSubmit(model.OnlineExamDTO);
                        model.OnlineExamDTO.errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                    }
                    return Json(model.OnlineExamDTO.errorMessage, JsonRequestBehavior.AllowGet);
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

        #endregion

        #region ------------CONTROLLER NON ACTION METHODS------------

        [AcceptVerbs(HttpVerbs.Post)]
        public JsonResult UploadAttachedDocument()
        {
            string _imgname = string.Empty;
            if (System.Web.HttpContext.Current.Request.Files.AllKeys.Any())
            {
                var pic = System.Web.HttpContext.Current.Request.Files["NewFile"];
                string OldFile = System.Web.HttpContext.Current.Request["OldFile"];
                if (pic.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(pic.FileName);
                    var _ext = Path.GetExtension(pic.FileName);

                    _imgname = Guid.NewGuid().ToString();
                    var _comPath = Server.MapPath("~") + "\\Content\\UploadedFiles\\ExamAttachedDocument\\";
                    _imgname = "oead_" + _imgname + _ext;

                    if (!Directory.Exists(_comPath))
                    {
                        Directory.CreateDirectory(_comPath);
                    }
                    pic.SaveAs(_comPath + "\\" + Path.GetFileName(_imgname));

                    ViewBag.Msg = _comPath;
                    var path = _comPath;
                    MemoryStream ms = new MemoryStream();

                    if (OldFile != "" && OldFile != null)
                    {
                        string filePath = Path.Combine(Server.MapPath("~") + "\\Content\\UploadedFiles\\ExamAttachedDocument\\", OldFile);
                        FileInfo file = new FileInfo(filePath);
                        if (Directory.Exists(filePath) || file.Exists)
                        {
                            System.IO.File.Delete(filePath);
                        }
                    }
                }
            }
            return Json(Convert.ToString(_imgname), JsonRequestBehavior.AllowGet);
        }

        public ActionResult DownloadAttachedDocument(string AttachedDocument)
        {
            string filePath = Path.Combine(Server.MapPath("~") + "Content\\UploadedFiles\\ExamAttachedDocument\\", AttachedDocument);
            string contentType = "image";
            return File(filePath, contentType, AttachedDocument);
        }

        public IEnumerable<OnlineExamViewModel> GetOnlineExamPerStudent(out int TotalRecords)
        {
            OnlineExamSearchRequest searchRequest = new OnlineExamSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.StudentID = Convert.ToInt32(Session["PersonID"]);
            _actionMode = Convert.ToString(TempData["ActionMode"]);
            if (Enum.TryParse(_actionMode, out actionModeEnum))     // checks actionMode i.e. Insert or Update // 
            {
                if (actionModeEnum == ActionModeEnum.Insert)        // parameters for SelectAll procedures under Insert or Update mode condition
                {
                    searchRequest.SortBy = "CreatedDate";
                    searchRequest.StartRow = 0;
                    searchRequest.EndRow = 10;
                    searchRequest.SearchBy = "ExaminationName like '%'";
                    searchRequest.SortDirection = "Desc";
                }
                if (actionModeEnum == ActionModeEnum.Update)
                {
                    searchRequest.SortBy = "ModifiedDate";
                    searchRequest.StartRow = 0;
                    searchRequest.EndRow = 10;
                    searchRequest.SearchBy = "ExaminationName like '%'";
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
            List<OnlineExamViewModel> listOnlineExamViewModel = new List<OnlineExamViewModel>();
            List<OnlineExam> listOnlineExaminationMaster = new List<OnlineExam>();
            IBaseEntityCollectionResponse<OnlineExam> baseEntityCollectionResponse = _OnlineExamServiceAcess.GetOnlineExamsPerStudentBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listOnlineExaminationMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (OnlineExam item in listOnlineExaminationMaster)
                    {
                        OnlineExamViewModel OnlineExamViewModel = new OnlineExamViewModel();
                        OnlineExamViewModel.OnlineExamDTO = item;
                        listOnlineExamViewModel.Add(OnlineExamViewModel);
                    }
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listOnlineExamViewModel;
        }

        #endregion

        #region  ------------CONTROLLER AJAX HANDLER METHODS------------
        public ActionResult AjaxHandler(JQueryDataTableParamModel param)
        {
            int TotalRecords;
            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc

            IEnumerable<OnlineExamViewModel> filteredOnlineExam;
            switch (Convert.ToInt32(sortColumnIndex))
            {
                case 0:
                    _sortBy = "C.ExaminationName";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "C.ExaminationName Like '%" + param.sSearch + "%' or A.ExaminationDate Like '%" + param.sSearch + "%' or A.ExaminationStartTime Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;
                case 1:
                    _sortBy = "A.ExaminationDate";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "C.ExaminationName Like '%" + param.sSearch + "%' or A.ExaminationDate Like '%" + param.sSearch + "%' or A.ExaminationStartTime Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;
                case 2:
                    _sortBy = "A.ExaminationDate";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "C.ExaminationName Like '%" + param.sSearch + "%' or A.ExaminationDate Like '%" + param.sSearch + "%' or A.ExaminationStartTime Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;
            }
            _sortDirection = sortDirection;
            _rowLength = param.iDisplayLength;
            _startRow = param.iDisplayStart;
            filteredOnlineExam = GetOnlineExamPerStudent(out TotalRecords);
            var records = filteredOnlineExam.Skip(0).Take(param.iDisplayLength);
            var result = from c in records
                         select new[] { Convert.ToString(c.OnlineExamIndStudentExamInfoID), Convert.ToString(c.ExaminationID), Convert.ToString(c.ExaminationName), Convert.ToString(c.ExaminationDate), Convert.ToString(c.ExaminationStartTime), Convert.ToString(c.ExaminationEndTime), Convert.ToString(c.IsExaminationOver), Convert.ToString(c.SubjectName), Convert.ToString(c.IsExamStart), Convert.ToString(c.ResultAnnounceDate), Convert.ToString(c.IsResultAnnounce), Convert.ToString(c.OnlineExamExaminationCourseApplicableID),Convert.ToString(c.ExaminationEndDate) };
            return Json(new { sEcho = param.sEcho, iTotalRecords = TotalRecords, iTotalDisplayRecords = TotalRecords, aaData = result }, JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}