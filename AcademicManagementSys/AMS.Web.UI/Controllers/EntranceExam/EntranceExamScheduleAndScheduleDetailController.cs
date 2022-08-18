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
    public class EntranceExamScheduleAndScheduleDetailController : BaseController
    {
        #region------------CONTROLLER CLASS VARIABLE------------

        IEntranceExamScheduleAndScheduleDetailServiceAccess _entranceExamScheduleAndScheduleDetailServiceAccess = null;
       
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

        public EntranceExamScheduleAndScheduleDetailController()
        {
            _entranceExamScheduleAndScheduleDetailServiceAccess = new EntranceExamScheduleAndScheduleDetailServiceAccess();
        }

        #endregion

        #region ------------CONTROLLER ACTION METHODS------------

        public ActionResult Index()
        {
            return View("/Views/EntranceExam/EntranceExamScheduleAndScheduleDetail/Index.cshtml");
        }


        public ActionResult List(string actionMode, string examName = "", int examinationID = 0)
        {
            try
            {
                EntranceExamScheduleAndScheduleDetailViewModel model = new EntranceExamScheduleAndScheduleDetailViewModel();

                model.EntranceExamScheduleAndScheduleDetailDTO.ExaminationName = examName;
                model.EntranceExamScheduleAndScheduleDetailDTO.ExaminationID = examinationID;
                if (!string.IsNullOrEmpty(actionMode))
                {
                    TempData["ActionMode"] = actionMode;
                }
                return PartialView("/Views/EntranceExam/EntranceExamScheduleAndScheduleDetail/List.cshtml", model);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }

        }

        public ActionResult Create(string scheduleGroupID)
        {
            try
            {
                EntranceExamScheduleAndScheduleDetailViewModel model = new EntranceExamScheduleAndScheduleDetailViewModel(); 
                
                int OnlineExamApplicableExamToCourseID = Convert.ToInt32(scheduleGroupID.Split('~')[3]);
                int EntranceExamAvailbleCentreID = Convert.ToInt32(scheduleGroupID.Split('~')[4]);
                int OnlineExamExaminationMasterID = Convert.ToInt32(scheduleGroupID.Split('~')[0]);

                model.OnlineExamExaminationMasterID = OnlineExamExaminationMasterID;
                model.EntranceExamCenteApllicableToExamID = Convert.ToInt32(scheduleGroupID.Split('~')[1]);
                model.EntranceExamInfrastructureDetailID = Convert.ToInt32(scheduleGroupID.Split('~')[2]);;

                //--------------Get Question Paper List----------------------------
                List<EntranceExamScheduleAndScheduleDetail> questionPaperList = GetOnlineExamExaminationQuestionPaperSet(OnlineExamExaminationMasterID);
                List<SelectListItem> selectList = new List<SelectListItem>();
                foreach (EntranceExamScheduleAndScheduleDetail item in questionPaperList    )
                {
                    selectList.Add(new SelectListItem { Text = item.PaperSet, Value = item.OnlineExamExaminationQuestionPaperID.ToString() });
                }

                ViewBag.OnlineExamExaminationQuestionPaperSet = new SelectList(selectList, "Value", "Text");

                //--------------Get Unalloted Student List----------------------------
                ViewBag.ListEntranceExamNotAllotedStuentForScheduleAvailCentre = GetAllotedStuentForScheduleAvailCentre(OnlineExamApplicableExamToCourseID, EntranceExamAvailbleCentreID);

                return PartialView("/Views/EntranceExam/EntranceExamScheduleAndScheduleDetail/Create.cshtml", model);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        [HttpPost]
        public ActionResult Create(EntranceExamScheduleAndScheduleDetailViewModel model)
        {
            try
            {
                if (model.EntranceExamScheduleAndScheduleDetailDTO != null)
                {
                    model.EntranceExamScheduleAndScheduleDetailDTO.ConnectionString = _connectioString;

                    model.EntranceExamScheduleAndScheduleDetailDTO.OnlineExamExaminationMasterID = model.OnlineExamExaminationMasterID;
                    model.EntranceExamScheduleAndScheduleDetailDTO.OnlineExamExaminationQuestionPaperID = model.OnlineExamExaminationQuestionPaperID;
                    model.EntranceExamScheduleAndScheduleDetailDTO.EntranceExamInfrastructureDetailID = model.EntranceExamInfrastructureDetailID;
                    model.EntranceExamScheduleAndScheduleDetailDTO.EntranceExamCenteApllicableToExamID = model.EntranceExamCenteApllicableToExamID;
                    model.EntranceExamScheduleAndScheduleDetailDTO.ScheduleName = model.ScheduleName;
                    model.EntranceExamScheduleAndScheduleDetailDTO.ScheduleDate = model.ScheduleDate;
                    model.EntranceExamScheduleAndScheduleDetailDTO.ScheduleTimeStart = model.ScheduleTimeStart;
                    model.EntranceExamScheduleAndScheduleDetailDTO.ScheduleEndTime = model.ScheduleEndTime;
                    model.EntranceExamScheduleAndScheduleDetailDTO.SelectedUnAllotedStudentXml = model.SelectedUnAllotedStudentXml != null ? model.SelectedUnAllotedStudentXml : "";
                    if (model.TotalStudentApllicable > 0)
                    {
                        model.EntranceExamScheduleAndScheduleDetailDTO.TotalStudentApllicable = model.TotalStudentApllicable;
                    }

                    model.EntranceExamScheduleAndScheduleDetailDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);

                    IBaseEntityResponse<EntranceExamScheduleAndScheduleDetail> response = _entranceExamScheduleAndScheduleDetailServiceAccess.InsertEntranceExamSchedule(model.EntranceExamScheduleAndScheduleDetailDTO);
                    model.EntranceExamScheduleAndScheduleDetailDTO.ErrorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                    return Json(model.EntranceExamScheduleAndScheduleDetailDTO.ErrorMessage, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(Resources.DisplayMessage_PleaseReviewYourForm);
                }
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }


        public ActionResult ViewAllotedStudent(int EntranceExamScheduleID)
        {
            try
            {
            EntranceExamScheduleAndScheduleDetailViewModel model = new EntranceExamScheduleAndScheduleDetailViewModel();

            model.AllotedStudentListForCentreList = GetAllotedStudentListForCentre(EntranceExamScheduleID);
            return PartialView("/Views/EntranceExam/EntranceExamScheduleAndScheduleDetail/AllotedStudentToCentre.cshtml", model);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        #endregion


        //Non Action Method
        #region---------------Non Action Method----------------------

        //Get Alloted Student List For Centre
        protected List<EntranceExamScheduleAndScheduleDetail> GetAllotedStudentListForCentre(int EntranceExamScheduleID)
        {
            EntranceExamScheduleAndScheduleDetailSearchRequest searchRequest = new EntranceExamScheduleAndScheduleDetailSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

            searchRequest.EntranceExamScheduleID = EntranceExamScheduleID;
            List<EntranceExamScheduleAndScheduleDetail> studentList = new List<EntranceExamScheduleAndScheduleDetail>();
            IBaseEntityCollectionResponse<EntranceExamScheduleAndScheduleDetail> baseEntityCollectionResponse = _entranceExamScheduleAndScheduleDetailServiceAccess.GetAllotedStudentListForCentre(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    studentList = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return studentList;
        }


        public IEnumerable<EntranceExamScheduleAndScheduleDetailViewModel> GetEntranceExamScheduleAndScheduleDetails(out int TotalRecords, int examinationID)
        {
            EntranceExamScheduleAndScheduleDetailSearchRequest entranceExamScheduleAndScheduleDetailSR = new EntranceExamScheduleAndScheduleDetailSearchRequest();
            entranceExamScheduleAndScheduleDetailSR.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"].ConnectionString);
            _actionMode = Convert.ToString(TempData["ActionMode"]);

            // checks actionMode i.e. Insert or Update //
            if (Enum.TryParse(_actionMode, out actionModeEnum))
            {
                if (actionModeEnum == ActionModeEnum.Insert)
                {
                    // parameters for SelectAll procedures under Insert or Update mode condition
                    entranceExamScheduleAndScheduleDetailSR.SortBy = "CreatedDate";
                    entranceExamScheduleAndScheduleDetailSR.StartRow = 0;
                    entranceExamScheduleAndScheduleDetailSR.EndRow = 10;
                    entranceExamScheduleAndScheduleDetailSR.SearchBy = string.Empty;
                    entranceExamScheduleAndScheduleDetailSR.SortDirection = "Desc";
                    entranceExamScheduleAndScheduleDetailSR.ExaminationID = examinationID;
                    
                }               
            }
            else
            {
                entranceExamScheduleAndScheduleDetailSR.SortBy = _sortBy;                     // parameters for SelectAll procedures under normal condition
                entranceExamScheduleAndScheduleDetailSR.StartRow = _startRow;
                entranceExamScheduleAndScheduleDetailSR.EndRow = _startRow + _rowLength;
                entranceExamScheduleAndScheduleDetailSR.SearchBy = _searchBy;
                entranceExamScheduleAndScheduleDetailSR.SortDirection = _sortDirection;
                entranceExamScheduleAndScheduleDetailSR.ExaminationID = examinationID;
                
            }

            List<EntranceExamScheduleAndScheduleDetailViewModel> listEntranceExamScheduleAndScheduleDetailVM = new List<EntranceExamScheduleAndScheduleDetailViewModel>();
            List<EntranceExamScheduleAndScheduleDetail> listEntranceExamScheduleAndScheduleDetail = new List<EntranceExamScheduleAndScheduleDetail>();
            IBaseEntityCollectionResponse<EntranceExamScheduleAndScheduleDetail> baseEntityEntranceExamScheduleAndScheduleDetail = _entranceExamScheduleAndScheduleDetailServiceAccess.GetEntranceExamScheduleBySearch(entranceExamScheduleAndScheduleDetailSR);

            if (baseEntityEntranceExamScheduleAndScheduleDetail != null)
            {
                if (baseEntityEntranceExamScheduleAndScheduleDetail.CollectionResponse != null && baseEntityEntranceExamScheduleAndScheduleDetail.CollectionResponse.Count > 0)
                {
                    listEntranceExamScheduleAndScheduleDetail = baseEntityEntranceExamScheduleAndScheduleDetail.CollectionResponse.ToList();
                    foreach (EntranceExamScheduleAndScheduleDetail data in listEntranceExamScheduleAndScheduleDetail)
                    {
                        EntranceExamScheduleAndScheduleDetailViewModel item = new EntranceExamScheduleAndScheduleDetailViewModel();
                        item.EntranceExamScheduleAndScheduleDetailDTO = data;
                        listEntranceExamScheduleAndScheduleDetailVM.Add(item);
                    }
                }
            }
            TotalRecords = baseEntityEntranceExamScheduleAndScheduleDetail.TotalRecords;
            return listEntranceExamScheduleAndScheduleDetailVM;
        }


        //Method to Get Examination Name List for Search text.
        [HttpPost]
        public ActionResult GetEntranceExamNameSearch(string searchText)
        {
            var data = GetExaminationNameByCourseID(searchText);
            var result = (from item in data
                          select new
                          {
                              examinationID = item.ID,
                              examinationName = item.ExaminationName
                          }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        //Get Allorted Student List.
        protected List<EntranceExamScheduleAndScheduleDetail> GetOnlineExamExaminationQuestionPaperSet(int OnlineExamExaminationMasterID)
        {
            EntranceExamScheduleAndScheduleDetailSearchRequest searchRequest = new EntranceExamScheduleAndScheduleDetailSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.OnlineExamExaminationMasterID = OnlineExamExaminationMasterID;            

            List<EntranceExamScheduleAndScheduleDetail> listQuestionPaper = new List<EntranceExamScheduleAndScheduleDetail>();
            IBaseEntityCollectionResponse<EntranceExamScheduleAndScheduleDetail> baseEntityCollectionResponse = _entranceExamScheduleAndScheduleDetailServiceAccess.GetOnlineExamQuestionPaperSet(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listQuestionPaper = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listQuestionPaper;
        }

        //Get Allorted Student List.
        protected List<EntranceExamScheduleAndScheduleDetail> GetAllotedStuentForScheduleAvailCentre(int OnlineExamApplicableExamToCourseID, int EntranceExamAvailbleCentreID)
        {
            EntranceExamScheduleAndScheduleDetailSearchRequest searchRequest = new EntranceExamScheduleAndScheduleDetailSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.OnlineExamApplicableExamToCourseID = OnlineExamApplicableExamToCourseID;
            searchRequest.EntranceExamAvailbleCentreID = EntranceExamAvailbleCentreID;

            List<EntranceExamScheduleAndScheduleDetail> listUnAllotedStudent = new List<EntranceExamScheduleAndScheduleDetail>();
            IBaseEntityCollectionResponse<EntranceExamScheduleAndScheduleDetail> baseEntityCollectionResponse = _entranceExamScheduleAndScheduleDetailServiceAccess.GetAllotedStuentForScheduleAvailCentreList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listUnAllotedStudent = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listUnAllotedStudent;
        }

        #endregion

        // AjaxHandler Method
        #region AjaxHandler
        public ActionResult AjaxHandler(JQueryDataTableParamModel param, int examinationID = 0)
        {
            int TotalRecords;
            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc

            IEnumerable<EntranceExamScheduleAndScheduleDetailViewModel> entranceExamSchedule;

            switch (Convert.ToInt32(sortColumnIndex))
            {
                case 0:
                    _sortBy = "ScheduleName";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "ScheduleName Like '%" + param.sSearch + "%'or ScheduleTimeStart Like '%" + param.sSearch + "%' or ScheduleEndTime Like '%" + param.sSearch + "%' or ScheduleDate Like '%" + param.sSearch + "%' or RoomCapacity Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;

                case 2:
                    _sortBy = "ScheduleTimeStart";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "ScheduleName Like '%" + param.sSearch + "%'or ScheduleTimeStart Like '%" + param.sSearch + "%' or ScheduleEndTime Like '%" + param.sSearch + "%' or ScheduleDate Like '%" + param.sSearch + "%' or RoomCapacity Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;
                case 3:
                    _sortBy = "ScheduleDate";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "ScheduleName Like '%" + param.sSearch + "%'or ScheduleTimeStart Like '%" + param.sSearch + "%' or ScheduleEndTime Like '%" + param.sSearch + "%' or ScheduleDate Like '%" + param.sSearch + "%' or RoomCapacity Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality

                    }
                    break;
                case 4:
                    _sortBy = "RoomCapacity";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "ScheduleName Like '%" + param.sSearch + "%'or ScheduleTimeStart Like '%" + param.sSearch + "%' or ScheduleEndTime Like '%" + param.sSearch + "%' or ScheduleDate Like '%" + param.sSearch + "%' or RoomCapacity Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality

                    }
                    break;
            }

            _sortDirection = sortDirection;
            _rowLength = param.iDisplayLength;
            _startRow = param.iDisplayStart;

            if (examinationID > 0)
            {
                entranceExamSchedule = GetEntranceExamScheduleAndScheduleDetails(out TotalRecords, examinationID);
            }
            else
            {
                entranceExamSchedule = new List<EntranceExamScheduleAndScheduleDetailViewModel>();
                TotalRecords = 0;
            }
            var records = entranceExamSchedule.Skip(0).Take(param.iDisplayLength);
            var result = from c in records
                         select new[] { Convert.ToString(c.ScheduleName), 
                                        Convert.ToString(c.ScheduleTimeStart + " - " + c.ScheduleEndTime), 
                                        Convert.ToString(c.ScheduleDate),
                                        Convert.ToString(c.StudentCount),       
                                        Convert.ToString("[ " +c.CentreName + "]  " + "[ Room No : "+ c.RoomName + "] "+ "[ Room Capacity : " + c.RoomCapacity + "] "),
                                        Convert.ToString(c.EntranceExamScheduleID ),
                                        Convert.ToString(c.OnlineExamExaminationMasterID + "~" + 
                                                         c.EntranceExamCenteApllicableToExamID + "~" + 
                                                         c.EntranceExamInfrastructureDetailID + "~" +
                                                         c.OnlineExamApplicableExamToCourseID + "~" + 
                                                         c.EntranceExamAvailbleCentreID) };
            return Json(new { sEcho = param.sEcho, iTotalRecords = TotalRecords, iTotalDisplayRecords = TotalRecords, aaData = result }, JsonRequestBehavior.AllowGet);
        }

        #endregion

    }
}
