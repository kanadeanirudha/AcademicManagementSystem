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
namespace AMS.Web.UI.Controllers
{
    public class EntranceExamController : BaseController
    {
        #region ------------CONTROLLER CLASS VARIABLE------------
        IEntranceExamServiceAccess _entranceExamServiceAcess = null;
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
        public EntranceExamController()
        {
            _entranceExamServiceAcess = new EntranceExamServiceAccess();
        }
        #endregion

        #region ------------CONTROLLER ACTION METHODS------------
        public ActionResult Index()
        {
            return View("~/Views/EntranceExam/EntranceExam/Index.cshtml");
        }

        public ActionResult List(string actionMode)
        {
            try
            {
                EntranceExamViewModel model = new EntranceExamViewModel();
                if (!string.IsNullOrEmpty(actionMode))
                {
                    TempData["ActionMode"] = actionMode;
                }
                return PartialView("~/Views/OnlineExam/EntranceExam/List.cshtml", model);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        [HttpGet]
        public ActionResult Create(int ID, string Exam, int TotalQue)
        {
            EntranceExamViewModel model = new EntranceExamViewModel();
            //model.ApplicableQuestionList = GetApplicableQuestionList(ID);
            //model.ExaminationName = Exam.Replace('~', ' ');
            //model.PaperSetCode = Exam.Replace('~', ' ').Split('-')[1].Split(']')[0].Trim();
            //model.OnlineExamExaminationMasterID = ID;
            //model.TotalQuestion = TotalQue;
            return PartialView("~/Views/OnlineExam/EntranceExam/Create.cshtml", model);
        }

        [HttpPost]
        public ActionResult Create(EntranceExamViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model != null && model.EntranceExamDTO != null)
                    {
                        model.EntranceExamDTO.ConnectionString = _connectioString;
                        model.EntranceExamDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                        IBaseEntityResponse<EntranceExam> response = _entranceExamServiceAcess.InsertEntranceExam(model.EntranceExamDTO);
                        model.EntranceExamDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                    }
                    return Json(model.EntranceExamDTO.errorMessage, JsonRequestBehavior.AllowGet);
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

        public ActionResult SpinQuestionList(int ID)
        {
            EntranceExamViewModel model = new EntranceExamViewModel();
           // model.ApplicableQuestionList = GetApplicableQuestionList(ID);
            return PartialView("~/Views/OnlineExam/EntranceExam/QuestionList.cshtml", model);
        }

        [HttpGet]
        public ActionResult View(int ID, string Exam)
        {
            try
            {
                EntranceExamViewModel model = new EntranceExamViewModel();
                EntranceExamSearchRequest searchRequest = new EntranceExamSearchRequest();
                searchRequest.ID = ID;
                searchRequest.ConnectionString = _connectioString;
                //model.IsViewOnly = true;
                //model.ExaminationName = Exam.Replace('~', ' ');
                //model.PaperSetCode = Exam.Replace('~', ' ').Split('-')[1].Split(']')[0].Trim();
                //IBaseEntityCollectionResponse<EntranceExam> baseEntityCollectionResponse = _entranceExamServiceAcess.SelectByID(searchRequest);
                //if (baseEntityCollectionResponse != null)
                //{
                //    model.ApplicableQuestionList = baseEntityCollectionResponse.CollectionResponse.ToList();
                //}
                return PartialView("~/Views/OnlineExam/EntranceExam/Create.cshtml", model);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }
        #endregion

        #region ------------CONTROLLER NON ACTION METHODS------------
        [NonAction] // gets question list applicable to exam and spins records
        public List<EntranceExam> GetApplicableQuestionList(int ID)
        {
            List<EntranceExam> questionList = new List<EntranceExam>();
            EntranceExamSearchRequest searchRequest = new EntranceExamSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.ID = ID;
            IBaseEntityCollectionResponse<EntranceExam> baseEntityCollectionResponse = _entranceExamServiceAcess.GetEntranceExamGetResultofStudent(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    questionList = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return questionList;
        }
        #endregion 
    }
}