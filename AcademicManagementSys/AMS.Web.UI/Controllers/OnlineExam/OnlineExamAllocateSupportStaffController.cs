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
    public class OnlineExamAllocateSupportStaffController : BaseController
    {
           IOnlineExamAllocateSupportStaffServiceAccess _OnlineExamAllocateSupportStaffServiceAcess = null;
           IOrganisationSubjectGroupDetailsServiceAccess _OrganisationSubjectGroupDetailsServiceAccess = null;
           IOnlineExamAllocateSupportStaffViewModel _OnlineExamAllocateSupportStaffViewModel = null;
           IEmpEmployeeMasterServiceAccess _EmpEmployeeMasterServiceAccess = null;
           IGeneralSessionMasterServiceAccess _GeneralSessionMasterServiceAccess = null;
           IOnlineExamExaminationMasterServiceAccess _OnlineExamExaminationMasterServiceAccess = null;

        private readonly ILogger _logException;
        ActionModeEnum actionModeEnum;
        string _actionMode = string.Empty;
        string _sortBy = string.Empty;
        string _searchBy = string.Empty;
        string _sortDirection = string.Empty;
        int _startRow;
        int _rowLength;
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

        public OnlineExamAllocateSupportStaffController()
        {
             _OnlineExamAllocateSupportStaffServiceAcess = new OnlineExamAllocateSupportStaffServiceAccess();
             _OrganisationSubjectGroupDetailsServiceAccess = new OrganisationSubjectGroupDetailsServiceAccess();
             _OnlineExamAllocateSupportStaffViewModel = new OnlineExamAllocateSupportStaffViewModel();
             _EmpEmployeeMasterServiceAccess = new EmpEmployeeMasterServiceAccess();
             _GeneralSessionMasterServiceAccess = new GeneralSessionMasterServiceAccess();
             _OnlineExamExaminationMasterServiceAccess = new OnlineExamExaminationMasterServiceAccess();
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

                        return View("/Views/OnlineExam/OnlineExamAllocateSupportStaff/Index.cshtml");
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
                    OnlineExamAllocateSupportStaffViewModel model = new OnlineExamAllocateSupportStaffViewModel();
                    model.CentreCode = CentreCode;
                    model.OnlineExamExaminationMasterID = Convert.ToInt32(OnlineExamExaminationMasterID);
                    return PartialView("/Views/OnlineExam/OnlineExamAllocateSupportStaff/List.cshtml", model);
                }
                catch (Exception ex)
                {
                    _logException.Error(ex.Message);
                    throw;
                }

            }
           

            [HttpGet]
            public ActionResult Create(string OnlineExamAllocateSupportStaffID,  string EmployeeFullName)
            {
           
                OnlineExamAllocateSupportStaffViewModel model = new OnlineExamAllocateSupportStaffViewModel();
               // model.EmployeeID = Convert.ToInt32(EmployeeID);
                model.OnlineExamAllocateSupportStaffID = Convert.ToInt32(OnlineExamAllocateSupportStaffID);
                model.EmployeeFullName = EmployeeFullName;
           
                //*************Static DropDownList For AllotedJobCode**********************************
                       List<SelectListItem> AllotedJobCode = new List<SelectListItem>();
                       ViewBag.AllotedJobCode = new SelectList(AllotedJobCode, "Value", "Text");
                       List<SelectListItem> li_AllotedJobCode = new List<SelectListItem>();
                       li_AllotedJobCode.Add(new SelectListItem { Text = "Invigilator", Value = "Invigilator" });
                       li_AllotedJobCode.Add(new SelectListItem { Text = "Paper Modulator", Value = "PaperModulator" });
                       li_AllotedJobCode.Add(new SelectListItem { Text = "Exam Modulator", Value = "ExamModulator" });
                       li_AllotedJobCode.Add(new SelectListItem { Text = "Paper Checker", Value = "PaperChecker" });
                      // li_AllotedJobCode.Add(new SelectListItem { Text = "Other", Value = "Other" });

                       ViewBag.AllotedJobCode = li_AllotedJobCode;
                  
            

               //************************** Dynamic Drop Down For Subject********************************

                         List<OrganisationSubjectGroupDetails> OrganisationSubjectGroupDetails = GetListOrganisationSubjectGroupDetails();
                         List<SelectListItem> OrganisationSubjectGroupDetailsList = new List<SelectListItem>();

                         foreach (OrganisationSubjectGroupDetails item in OrganisationSubjectGroupDetails)
                         {
                             OrganisationSubjectGroupDetailsList.Add(new SelectListItem { Text = item.Description, Value = Convert.ToString(item.ID) });
                         }
                         ViewBag.OrganisationSubjectGroupDetailsListt = new SelectList(OrganisationSubjectGroupDetailsList, "Value", "Text");
                    
                //************************** Dynamic Drop Down For Subject********************************

                         List<GeneralSessionMaster> GeneralSessionMaster = GetListGeneralSessionMaster();
                         List<SelectListItem> GeneralSessionMasterList = new List<SelectListItem>();
               
                         foreach(GeneralSessionMaster item in GeneralSessionMaster)
                         {
                             GeneralSessionMasterList.Add(new SelectListItem { Text = item.SessionName, Value = Convert.ToString(item.ID) });
                         }
                         ViewBag.GeneralSessionMasteListt = new SelectList(GeneralSessionMasterList, "value", "Text");

                       return PartialView("/Views/OnlineExam/OnlineExamAllocateSupportStaff/Create.cshtml", model);
            }

            [HttpPost]
            public ActionResult Create(OnlineExamAllocateSupportStaffViewModel model)
            {
                try
                {
                    //if (ModelState.IsValid)
                    // {
                    if (model != null && model.OnlineExamAllocateSupportStaffDTO != null)
                    {
                        model.OnlineExamAllocateSupportStaffDTO.ConnectionString = _connectioString;
                   
                  
                        //Fields From OnlineExamAllocateJobSupportStaff
                  
                        model.OnlineExamAllocateSupportStaffDTO.OnlineExamAllocateSupportStaffID = model.OnlineExamAllocateSupportStaffID;
                        model.OnlineExamAllocateSupportStaffDTO.AllotedJobName=model.AllotedJobName;
                        model.OnlineExamAllocateSupportStaffDTO.AllotedJobCode = model.AllotedJobCode;
                        model.OnlineExamAllocateSupportStaffDTO.JobStartDate = model.JobStartDate;
                        model.OnlineExamAllocateSupportStaffDTO.JobEndDate = model.JobEndDate;
                        model.OnlineExamAllocateSupportStaffDTO.SubjectGroupId = model.SubjectGroupId;
                        model.OnlineExamAllocateSupportStaffDTO.AcademicSessionID = model.AcademicSessionID;
                        model.OnlineExamAllocateSupportStaffDTO.IsNotificationNeedToSentCompulsory = model.IsNotificationNeedToSentCompulsory;
                        model.OnlineExamAllocateSupportStaffDTO.CentreCode = model.CentreCode;
                        model.OnlineExamAllocateSupportStaffDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                        IBaseEntityResponse<OnlineExamAllocateSupportStaff> response = _OnlineExamAllocateSupportStaffServiceAcess.InsertOnlineExamAllocateJobSupportStaff(model.OnlineExamAllocateSupportStaffDTO);

                        model.OnlineExamAllocateSupportStaffDTO.errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                        return Json(model.OnlineExamAllocateSupportStaffDTO.errorMessage, JsonRequestBehavior.AllowGet);
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
            public ActionResult CreateEmployeeForExam(string CentreCode, int OnlineExamExaminationMasterID)
            {
                OnlineExamAllocateSupportStaffViewModel model = new OnlineExamAllocateSupportStaffViewModel();
                model.CentreCode = CentreCode;
                model.OnlineExamExaminationMasterID = OnlineExamExaminationMasterID;
                return PartialView("/Views/OnlineEXam/OnlineExamAllocateSupportStaff/CreateEmployeeForExam.cshtml", model);
            }

            [HttpPost]
            public ActionResult CreateEmployeeForExam(OnlineExamAllocateSupportStaffViewModel model)
            {
                try
                {
                    if (model != null && model.OnlineExamAllocateSupportStaffDTO != null)
                    {
                        model.OnlineExamAllocateSupportStaffDTO.ConnectionString = _connectioString;
                        model.OnlineExamAllocateSupportStaffDTO.EmployeeID = model.EmployeeID;
                        model.OnlineExamAllocateSupportStaffDTO.OnlineExamExaminationMasterID = model.OnlineExamExaminationMasterID;
                        model.OnlineExamAllocateSupportStaffDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                        IBaseEntityResponse<OnlineExamAllocateSupportStaff> response = _OnlineExamAllocateSupportStaffServiceAcess.InsertOnlineExamAllocateSupportStaff(model.OnlineExamAllocateSupportStaffDTO);

                        model.OnlineExamAllocateSupportStaffDTO.errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                        return Json(model.OnlineExamAllocateSupportStaffDTO.errorMessage, JsonRequestBehavior.AllowGet);
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
            //    OnlineExamAllocateSupportStaffViewModel model = new OnlineExamAllocateSupportStaffViewModel();
            //    try
            //    {
            //        model.OnlineExamAllocateSupportStaffDTO = new OnlineExamAllocateSupportStaff();
            //        model.OnlineExamAllocateSupportStaffDTO.ID = id;
            //        model.OnlineExamAllocateSupportStaffDTO.ConnectionString = _connectioString;

            //        IBaseEntityResponse<OnlineExamAllocateSupportStaff> response = _OnlineExamAllocateSupportStaffServiceAcess.SelectByID(model.OnlineExamAllocateSupportStaffDTO);
            //        if (response != null && response.Entity != null)
            //        {
            //            model.OnlineExamAllocateSupportStaffDTO.ID = response.Entity.ID;
            //            model.OnlineExamAllocateSupportStaffDTO.GroupDescription = response.Entity.GroupDescription;
            //            model.OnlineExamAllocateSupportStaffDTO.GroupCode = response.Entity.GroupCode;
            //            model.OnlineExamAllocateSupportStaffDTO.CreatedBy = response.Entity.CreatedBy;
            //        }
            //        return PartialView(model);
            //    }
            //    catch (Exception)
            //    {
            //        throw;
            //    }
            //}

            //[HttpPost]
            //public ActionResult Edit(OnlineExamAllocateSupportStaffViewModel model)
            //{
            //    if (ModelState.IsValid)
            //    {
            //        if (model != null && model.OnlineExamAllocateSupportStaffDTO != null)
            //        {
            //            if (model != null && model.OnlineExamAllocateSupportStaffDTO != null)
            //            {
            //                model.OnlineExamAllocateSupportStaffDTO.ConnectionString = _connectioString;
            //                model.OnlineExamAllocateSupportStaffDTO.MovementType = model.MovementType;
            //                model.OnlineExamAllocateSupportStaffDTO.MovementCode = model.MovementCode;
            //                model.OnlineExamAllocateSupportStaffDTO.IsActive = model.IsActive;
                      
            //                model.OnlineExamAllocateSupportStaffDTO.ModifiedBy = Convert.ToInt32(Session["UserID"]);
            //                IBaseEntityResponse<OnlineExamAllocateSupportStaff> response = _OnlineExamAllocateSupportStaffServiceAcess.UpdateOnlineExamAllocateSupportStaff(model.OnlineExamAllocateSupportStaffDTO);
            //                model.OnlineExamAllocateSupportStaffDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Update);
            //            }
            //        }
            //        return Json(model.OnlineExamAllocateSupportStaffDTO.errorMessage, JsonRequestBehavior.AllowGet);
            //    }
            //    else
            //    {
            //        return Json("Please review your form");
            //    }
            //}

         
            [HttpGet]
            public ActionResult ViewDetails(Int32 OnlineExamAllocateJobSupportStaffID, String EmployeeFullName, String AllotedJobName)
            {
                OnlineExamAllocateSupportStaffViewModel model = new OnlineExamAllocateSupportStaffViewModel();
                try
                {
                        model.OnlineExamAllocateSupportStaffDTO = new OnlineExamAllocateSupportStaff();
                        model.OnlineExamAllocateSupportStaffDTO.OnlineExamAllocateJobSupportStaffID = OnlineExamAllocateJobSupportStaffID;
                        model.OnlineExamAllocateSupportStaffDTO.EmployeeFullName = EmployeeFullName;
                        model.OnlineExamAllocateSupportStaffDTO.AllotedJobName = AllotedJobName;       
                        model.OnlineExamAllocateSupportStaffDTO.ConnectionString = _connectioString;

                    IBaseEntityResponse<OnlineExamAllocateSupportStaff> response = _OnlineExamAllocateSupportStaffServiceAcess.SelectByID(model.OnlineExamAllocateSupportStaffDTO);
                    if (response != null && response.Entity != null)
                    {
                       
                        model.OnlineExamAllocateSupportStaffDTO.OnlineExamAllocateJobSupportStaffID = response.Entity.OnlineExamAllocateJobSupportStaffID;
                        model.OnlineExamAllocateSupportStaffDTO.OnlineExamAllocateSupportStaffID= response.Entity.OnlineExamAllocateSupportStaffID;
                        model.OnlineExamAllocateSupportStaffDTO.EmployeeFullName = response.Entity.EmployeeFullName;
                        model.OnlineExamAllocateSupportStaffDTO.AllotedJobName = response.Entity.AllotedJobName;
                        model.OnlineExamAllocateSupportStaffDTO.AllotedJobCode = response.Entity.AllotedJobCode;
                        model.OnlineExamAllocateSupportStaffDTO.JobStartDate = response.Entity.JobStartDate;
                        model.OnlineExamAllocateSupportStaffDTO.JobEndDate = response.Entity.JobEndDate;

                        model.OnlineExamAllocateSupportStaffDTO.CreatedBy = response.Entity.CreatedBy;
                    }
                    return PartialView("/Views/OnlineExam/OnlineExamAllocateSupportStaff/View.cshtml", model);
                }
                catch (Exception)
                {
                    throw;
                }
            }

            public ActionResult Delete(int ID)
            {
                var errorMessage = string.Empty;
                if (ID > 0)
                {
                    IBaseEntityResponse<OnlineExamAllocateSupportStaff> response = null;
                    OnlineExamAllocateSupportStaff OnlineExamAllocateSupportStaffDTO = new OnlineExamAllocateSupportStaff();
                    OnlineExamAllocateSupportStaffDTO.ConnectionString = _connectioString;
                    OnlineExamAllocateSupportStaffDTO.ID = Convert.ToInt32(ID);
                    OnlineExamAllocateSupportStaffDTO.DeletedBy = Convert.ToInt32(Session["UserID"]);
                    response = _OnlineExamAllocateSupportStaffServiceAcess.DeleteOnlineExamAllocateSupportStaff(OnlineExamAllocateSupportStaffDTO);
                    errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Delete);
                }

                return Json(errorMessage, JsonRequestBehavior.AllowGet);
            }


            #endregion

            //For GetSession By Subject

            //public ActionResult GetSessionBySubject(String SubjectGroupId)
            //{

            //    if (String.IsNullOrEmpty(SubjectGroupId))
            //    {
            //        throw new ArgumentNullException("SubjectGroupId");
            //    }
            //    int id = 0;
            //    bool isValid = Int32.TryParse(SubjectGroupId, out id);
            //    var Session = GetSessionListGeneralSessionMaster(SubjectGroupId);
            //    var result = (from s in Session
            //                  select new
            //                  {
            //                      id = s.ID,
            //                      name = s.SessionName,
            //                  }).ToList();
            //    return Json(result, JsonRequestBehavior.AllowGet);
            //}

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

            public ActionResult ExaminationNameList(string CentreCode)
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

                    var ExaminationMaster = GetExaminationNameList();
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
            public JsonResult GetEmployeeName(string term)
            {
                var data = GetListEmpEmployeeMaster(term);
                var result = (from r in data
                              select new
                              {
                                  id = r.ID,
                                  name = r.EmployeeFirstName,
                              }).ToList();
                return Json(result, JsonRequestBehavior.AllowGet);
            }

            //Dropdown For Subject 
            protected List<OrganisationSubjectGroupDetails> GetListOrganisationSubjectGroupDetails()
            {
                OrganisationSubjectGroupDetailsSearchRequest searchRequest = new OrganisationSubjectGroupDetailsSearchRequest();
                searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
                List<OrganisationSubjectGroupDetails> listOrganisationSubjectGroupDetails = new List<OrganisationSubjectGroupDetails>();
                IBaseEntityCollectionResponse<OrganisationSubjectGroupDetails> baseEntityCollectionResponse = _OrganisationSubjectGroupDetailsServiceAccess.GetByDescriptionList(searchRequest);
                if (baseEntityCollectionResponse != null)
                {
                    if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                    {
                        listOrganisationSubjectGroupDetails = baseEntityCollectionResponse.CollectionResponse.ToList();
                    }
                }
                return listOrganisationSubjectGroupDetails;
            }

            protected List<OnlineExamExaminationMaster> GetExaminationNameList()
            {
                
                OnlineExamExaminationMasterSearchRequest searchRequest = new OnlineExamExaminationMasterSearchRequest();
                searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
                List<OnlineExamExaminationMaster> listExamination = new List<OnlineExamExaminationMaster>();
                IBaseEntityCollectionResponse<OnlineExamExaminationMaster> baseEntityCollectionResponse = _OnlineExamExaminationMasterServiceAccess.GetExaminationNameList(searchRequest);
                if (baseEntityCollectionResponse != null)
                {
                    if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                    {
                        listExamination = baseEntityCollectionResponse.CollectionResponse.ToList();
                    }
                }
                return listExamination;
                
            }
           ////DropDown For Session

           // protected List<GeneralSessionMaster> GetListGeneralSessionMaster()
           // {
           //     GeneralSessionMasterSearchRequest searchRequest = new GeneralSessionMasterSearchRequest();
           //     searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
           //     List<GeneralSessionMaster> listGeneralSessionMaster = new List<GeneralSessionMaster>();
           //     IBaseEntityCollectionResponse<GeneralSessionMaster> baseEntityCollectionResponse = _GeneralSessionMasterServiceAccess.GetSession(searchRequest);
           //     if (baseEntityCollectionResponse != null)
           //     {
           //         if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
           //         {
           //             listGeneralSessionMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
           //         }
           //     }
           //     return listGeneralSessionMaster;
           // }

            //// Dropdown For EmployeeName
            //protected List<EmpEmployeeMaster> GetListEmpEmployeeMaster()
            //{
            //    EmpEmployeeMasterSearchRequest searchRequest = new EmpEmployeeMasterSearchRequest();
            //    searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            //    List<EmpEmployeeMaster> listEmpEmployeeMaster = new List<EmpEmployeeMaster>();
            //    IBaseEntityCollectionResponse<EmpEmployeeMaster> baseEntityCollectionResponse = _EmpEmployeeMasterServiceAccess.GetEmployeeNameList(searchRequest);
            //    if (baseEntityCollectionResponse != null)
            //    {
            //        if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
            //        {
            //            listEmpEmployeeMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
            //        }
            //    }
            //    return listEmpEmployeeMaster;

            //}
            public IEnumerable<OnlineExamAllocateSupportStaffViewModel> GetOnlineExamAllocateSupportStaff(out int TotalRecords, int SessionID, int SelectedExam)
            {
                OnlineExamAllocateSupportStaffSearchRequest searchRequest = new OnlineExamAllocateSupportStaffSearchRequest();
                searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
                searchRequest.SessionId = SessionID;
                searchRequest.OnlineExamExaminationMasterID = SelectedExam;
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
                List<OnlineExamAllocateSupportStaffViewModel> listOnlineExamAllocateSupportStaffViewModel = new List<OnlineExamAllocateSupportStaffViewModel>();
                List<OnlineExamAllocateSupportStaff> listOnlineExamAllocateSupportStaff = new List<OnlineExamAllocateSupportStaff>();
                IBaseEntityCollectionResponse<OnlineExamAllocateSupportStaff> baseEntityCollectionResponse = _OnlineExamAllocateSupportStaffServiceAcess.GetBySearch(searchRequest);
                if (baseEntityCollectionResponse != null)
                {
                    if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                    {
                        listOnlineExamAllocateSupportStaff = baseEntityCollectionResponse.CollectionResponse.ToList();
                        foreach (OnlineExamAllocateSupportStaff item in listOnlineExamAllocateSupportStaff)
                        {
                            OnlineExamAllocateSupportStaffViewModel OnlineExamAllocateSupportStaffViewModel = new OnlineExamAllocateSupportStaffViewModel();
                            OnlineExamAllocateSupportStaffViewModel.OnlineExamAllocateSupportStaffDTO = item;
                            listOnlineExamAllocateSupportStaffViewModel.Add(OnlineExamAllocateSupportStaffViewModel);
                        }
                    }
                }
                TotalRecords = baseEntityCollectionResponse.TotalRecords;
                return listOnlineExamAllocateSupportStaffViewModel;
            }
            #endregion

            // AjaxHandler Method
            #region AjaxHandler
            public ActionResult AjaxHandler(JQueryDataTableParamModel param, int SessionID, int SelectedExam)
            {
                if (Session["UserType"] != null)
                {
                    int TotalRecords;
                    var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
                    string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc

                    IEnumerable<OnlineExamAllocateSupportStaffViewModel> filteredGroupDescription;
                    switch (Convert.ToInt32(sortColumnIndex))
                    {
                        case 0:
                            _sortBy = "A.EmployeeID, b.OnlineExamAllocateJobSupportStaffId";
                            if (string.IsNullOrEmpty(param.sSearch))
                            {
                               
                                _searchBy = string.Empty;
                            }
                            else
                            {
                                     
                                _searchBy = "EmployeeFullName Like '%" + param.sSearch + "%' or B.AllotedJobName Like '%" + param.sSearch + "%' or B.AllotedJobCode Like '%" + param.sSearch + "%'";//this "if" block is added for search functionality
                            }
                            break;

                        case 1:
                            _sortBy = "EmployeeFullName";
                            if (string.IsNullOrEmpty(param.sSearch))
                            {
                                // _searchBy = "A.MarchandiseGroupCode like '%'";
                                _searchBy = string.Empty;
                            }
                            else
                            {
                                //  _searchBy = "A.MarchandiseGroupCode Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                                _searchBy = "EmployeeFullName Like '%" + param.sSearch + "%' or B.AllotedJobName Like '%" + param.sSearch + "%' or B.AllotedJobCode Like '%" + param.sSearch + "%'";
                            }
                            break;
                        case 2:
                            _sortBy = "B.AllotedJobName";
                            if (string.IsNullOrEmpty(param.sSearch))
                            {
                                // _searchBy = "A.MarchandiseGroupCode like '%'";
                                _searchBy = string.Empty;
                            }
                            else
                            {
                                //  _searchBy = "A.MarchandiseGroupCode Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                                _searchBy = "EmployeeFullName Like '%"  + param.sSearch + "%' or B.AllotedJobName Like '%" + param.sSearch + "%' or B.AllotedJobCode Like '%" + param.sSearch + "%'";
                            }
                            break;
                        case 3:
                            _sortBy = "B.AllotedJobCode";
                            if (string.IsNullOrEmpty(param.sSearch))
                            {
                                // _searchBy = "A.MarchandiseGroupCode like '%'";
                                _searchBy = string.Empty;
                            }
                            else
                            {
                                //  _searchBy = "A.MarchandiseGroupCode Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                                _searchBy = "EmployeeFullName Like '%" + param.sSearch + "%' or B.AllotedJobName Like '%" + param.sSearch + "%' or B.AllotedJobCode Like '%" + param.sSearch + "%'";
                            }
                            break;
                       

                   
                    }
                    _sortDirection = sortDirection;
                    _rowLength = param.iDisplayLength;
                    _startRow = param.iDisplayStart;
                    filteredGroupDescription = GetOnlineExamAllocateSupportStaff(out TotalRecords, SessionID, SelectedExam);


                    var records = filteredGroupDescription.Skip(0).Take(param.iDisplayLength);
                    var result = from c in records select new[] { Convert.ToString(c.EmployeeFullName), Convert.ToString(c.ExaminationName) , Convert.ToString(c.AllotedJobName), Convert.ToString(c.AllotedJobCode), Convert.ToString(c.JobStartDate), Convert.ToString(c.JobEndDate), Convert.ToString(c.OnlineExamExaminationMasterID), Convert.ToString(c.ID), Convert.ToString(c.CentreCode), Convert.ToString(c.EmployeeID),Convert.ToString(c.AcademicSessionID),Convert.ToString(c.OnlineExamAllocateSupportStaffID),Convert.ToString(c.OnlineExamAllocateJobSupportStaffID),Convert.ToString(c.JobAllotedForCentreCode)};

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