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
    public class ScholarShipAllocationController : BaseController
    {
        IScholarShipAllocationServiceAccess _ScholarShipAllocationServiceAcess = null;
        IFeeCriteriaMasterAndDetailsServiceAccess _feeCriteriaMasterAndDetailsServiceAccess = null;
        IFeeStructureMasterAndDetailsServiceAccess _feeStructureMasterAndDetailsServiceAccess = null;
        private readonly ILogger _logException;
        ActionModeEnum actionModeEnum;
        string _actionMode = string.Empty;
        string _sortBy = string.Empty;
        string _searchBy = string.Empty;
        string _sortDirection = string.Empty;
        int _startRow;
        const int _recordsPerPage = 5;
        int _rowLength;
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

        public ScholarShipAllocationController()
        {
            _ScholarShipAllocationServiceAcess = new ScholarShipAllocationServiceAccess();
            _feeCriteriaMasterAndDetailsServiceAccess = new FeeCriteriaMasterAndDetailsServiceAccess();
            _feeStructureMasterAndDetailsServiceAccess = new FeeStructureMasterAndDetailsServiceAccess();
        }

        // Controller Methods
        #region Controller Methods
        public ActionResult Index()
        {
            ScholarShipAllocationViewModel model = new ScholarShipAllocationViewModel();
            if (Convert.ToString(Session["UserType"]) == "A")
            {
                //--------------------------------------For Centre Code list---------------------------------//
                List<OrganisationStudyCentreMaster> listAdminRoleApplicableDetails = GetListOrgStudyCentreMaster();
                AdminRoleApplicableDetails a = null;
                foreach (var item in listAdminRoleApplicableDetails)
                {
                    a = new AdminRoleApplicableDetails();
                    a.CentreCode = item.CentreCode;
                    a.CentreName = item.CentreName;
                    a.ScopeIdentity = item.ScopeIdentity;
                    model.ListGetAdminRoleApplicableCentre.Add(a);
                }
                model.EntityLevel = "Centre";

                foreach (var b in model.ListGetAdminRoleApplicableCentre)
                {
                    b.CentreCode = b.CentreCode + ":" + "Centre";
                }
            }
            else
            {
                int AdminRoleMasterID = 0;
                if (Session["RoleID"] == null)
                {
                    AdminRoleMasterID = Convert.ToInt32(Session["DefaultRoleID"]);
                }
                else
                {
                    AdminRoleMasterID = Convert.ToInt32(Session["RoleID"]);
                }
                List<AdminRoleApplicableDetails> listAdminRoleApplicableDetails = GetAdminRoleApplicableCentre(AdminRoleMasterID, 0);
                AdminRoleApplicableDetails a = null;
                foreach (var item in listAdminRoleApplicableDetails)
                {
                    a = new AdminRoleApplicableDetails();
                    a.CentreCode = item.CentreCode;
                    a.CentreName = item.CentreName;
                    model.ListGetAdminRoleApplicableCentre.Add(a);
                }
                foreach (var b in model.ListGetAdminRoleApplicableCentre)
                {
                    b.CentreCode = b.CentreCode;
                }
            }
            return PartialView("/Views/ScholarShip/ScholarShipAllocation/Index.cshtml", model);
        }

        public ActionResult List(string actionMode, string centreCode)
        {
            try
            {
                ScholarShipAllocationViewModel model = new ScholarShipAllocationViewModel();
                if (!string.IsNullOrEmpty(actionMode))
                {
                    TempData["ActionMode"] = actionMode;
                }
                model.CentreCode = centreCode;
                return PartialView("/Views/ScholarShip/ScholarShipAllocation/List.cshtml", model);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        [HttpGet]
        public ActionResult Create(string centreCode)
        {
            ScholarShipAllocationViewModel model = new ScholarShipAllocationViewModel();
            model.CourseList = GetCourseSearchList(centreCode);
            model.SelectedCentreCode = centreCode;
            model.ScholarShipList = GetScholarShip();
            return PartialView("~/Views/ScholarShip/ScholarShipAllocation/Create.cshtml", model);
        }

        [HttpPost]
        public ActionResult Create(ScholarShipAllocationViewModel model)
        {
            try
            {
                model.ScholarShipAllocationDTO.ConnectionString = _connectioString;
                model.ScholarShipAllocationDTO.CentreCode= model.CentreCode;
                model.ScholarShipAllocationDTO.StudentID = model.StudentID;
                model.ScholarShipAllocationDTO.StudentAmissionDetailID = model.StudentAmissionDetailID;
                model.ScholarShipAllocationDTO.SectionDetailId = model.SectionDetailId;          
                model.ScholarShipAllocationDTO.StandarNumber =  model.StandarNumber;          
                model.ScholarShipAllocationDTO.LastSectionDetailID =model.LastSectionDetailID;      
                model.ScholarShipAllocationDTO.ScholarShipMasterID = model.ScholarShipMasterID;
                model.ScholarShipAllocationDTO.ScholarSheepDocumentNumber = model.ScholarSheepDocumentNumber;  
                model.ScholarShipAllocationDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                IBaseEntityResponse<ScholarShipAllocation> response = _ScholarShipAllocationServiceAcess.InsertScholarShipAllocation(model.ScholarShipAllocationDTO);
                model.ScholarShipAllocationDTO.errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                return Json(model.ScholarShipAllocationDTO.errorMessage, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }



        [HttpGet]
        public ActionResult ScholarShipAllocationRequestApproval(int PersonID, string TNDID, string TNMID, string GTRDID1, string TaskCode, string StageSequenceNumber, string IsLast)
        {
            ScholarShipAllocationViewModel model = new ScholarShipAllocationViewModel();
            model.PersonID = Convert.ToInt32(PersonID);
            model.TaskNotificationDetailsID = Convert.ToInt32(TNDID);
            model.TaskNotificationMasterID = Convert.ToInt32(TNMID);
            model.GeneralTaskReportingDetailsID = Convert.ToInt32(GTRDID1);
            model.TaskCode = TaskCode;
            model.StageSequenceNumber = Convert.ToInt32(StageSequenceNumber);
            model.IsLastRecord = Convert.ToBoolean(IsLast);


            model.ScholarShipAllocationApprovalList = GetScholarShipAllocationApprovalList(PersonID, Convert.ToInt32(TNMID));
            if (model.ScholarShipAllocationApprovalList.Count > 0)
            {
                model.StudentName = model.ScholarShipAllocationApprovalList[0].StudentName;
                model.SectionDetailDescription = model.ScholarShipAllocationApprovalList[0].SectionDetailDescription;
                model.SessionName = model.ScholarShipAllocationApprovalList[0].SessionName;
                model.ScholarSheepDocumentNumber = model.ScholarShipAllocationApprovalList[0].ScholarSheepDocumentNumber;
                model.ScholarShipDescription = model.ScholarShipAllocationApprovalList[0].ScholarShipDescription;
                model.CentreName = model.ScholarShipAllocationApprovalList[0].CentreName;
                model.CentreCode = model.ScholarShipAllocationApprovalList[0].CentreCode;
                model.StudentID = model.ScholarShipAllocationApprovalList[0].StudentID;
                model.ScholarShipAllocationID = model.ScholarShipAllocationApprovalList[0].ID;               
            }
            return View("/Views/ScholarShip/ScholarShipAllocation/ScholarShipAllocationRequestApproval.cshtml", model);
        }

        
        [HttpPost]
        public ActionResult ScholarShipAllocationRequestApproval(ScholarShipAllocationViewModel model)
        {
            model.ScholarShipAllocationDTO.ConnectionString = _connectioString;
            model.ScholarShipAllocationDTO.XMLstring = model.XMLstring;
            model.ScholarShipAllocationDTO.StudentID = model.StudentID;
            model.ScholarShipAllocationDTO.ScholarShipAllocationID = model.ScholarShipAllocationID;
            model.ScholarShipAllocationDTO.TaskCode = model.TaskCode;
            model.ScholarShipAllocationDTO.RequestApprovedStatus = model.RequestApprovedStatus;
            model.ScholarShipAllocationDTO.CentreCode = model.CentreCode;
            model.ScholarShipAllocationDTO.PersonID = model.PersonID;
            model.ScholarShipAllocationDTO.StageSequenceNumber = model.StageSequenceNumber;
            model.ScholarShipAllocationDTO.TaskNotificationMasterID = model.TaskNotificationMasterID;
            model.ScholarShipAllocationDTO.TaskNotificationDetailsID = model.TaskNotificationDetailsID;
            model.ScholarShipAllocationDTO.GeneralTaskReportingDetailsID = model.GeneralTaskReportingDetailsID;
            model.ScholarShipAllocationDTO.IsLastRecord = model.IsLastRecord;
            model.ScholarShipAllocationDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
            IBaseEntityResponse<ScholarShipAllocation> response = _ScholarShipAllocationServiceAcess.InsertScholarShipAllocationApproveRequest(model.ScholarShipAllocationDTO);
            model.ScholarShipAllocationDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
            return Json(model.ScholarShipAllocationDTO.errorMessage, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult ScholarShipAllocationRequestApprovalV2(int PersonID, string TNDID, string TNMID, string GTRDID1, string TaskCode, string StageSequenceNumber, string IsLast)
        {
            ScholarShipAllocationViewModel model = new ScholarShipAllocationViewModel();
            model.PersonID = Convert.ToInt32(PersonID);
            model.TaskNotificationDetailsID = Convert.ToInt32(TNDID);
            model.TaskNotificationMasterID = Convert.ToInt32(TNMID);
            model.GeneralTaskReportingDetailsID = Convert.ToInt32(GTRDID1);
            model.TaskCode = TaskCode;
            model.StageSequenceNumber = Convert.ToInt32(StageSequenceNumber);
            model.IsLastRecord = Convert.ToBoolean(IsLast);


            model.ScholarShipAllocationApprovalList = GetScholarShipAllocationApprovalList(PersonID, Convert.ToInt32(TNMID));
            if (model.ScholarShipAllocationApprovalList.Count > 0)
            {
                model.StudentName = model.ScholarShipAllocationApprovalList[0].StudentName;
                model.SectionDetailDescription = model.ScholarShipAllocationApprovalList[0].SectionDetailDescription;
                model.SessionName = model.ScholarShipAllocationApprovalList[0].SessionName;
                model.ScholarSheepDocumentNumber = model.ScholarShipAllocationApprovalList[0].ScholarSheepDocumentNumber;
                model.ScholarShipDescription = model.ScholarShipAllocationApprovalList[0].ScholarShipDescription;
                model.CentreName = model.ScholarShipAllocationApprovalList[0].CentreName;
                model.CentreCode = model.ScholarShipAllocationApprovalList[0].CentreCode;
                model.StudentID = model.ScholarShipAllocationApprovalList[0].StudentID;
                model.ScholarShipAllocationID = model.ScholarShipAllocationApprovalList[0].ID;
            }
            return View("/Views/ScholarShip/ScholarShipAllocation/ScholarShipAllocationRequestApprovalV2.cshtml", model);
        }


        [HttpPost]
        public ActionResult ScholarShipAllocationRequestApprovalV2(ScholarShipAllocationViewModel model)
        {
            model.ScholarShipAllocationDTO.ConnectionString = _connectioString;
            model.ScholarShipAllocationDTO.XMLstring = model.XMLstring;
            model.ScholarShipAllocationDTO.StudentID = model.StudentID;
            model.ScholarShipAllocationDTO.ScholarShipAllocationID = model.ScholarShipAllocationID;
            model.ScholarShipAllocationDTO.TaskCode = model.TaskCode;
            model.ScholarShipAllocationDTO.RequestApprovedStatus = model.RequestApprovedStatus;
            model.ScholarShipAllocationDTO.CentreCode = model.CentreCode;
            model.ScholarShipAllocationDTO.PersonID = model.PersonID;
            model.ScholarShipAllocationDTO.StageSequenceNumber = model.StageSequenceNumber;
            model.ScholarShipAllocationDTO.TaskNotificationMasterID = model.TaskNotificationMasterID;
            model.ScholarShipAllocationDTO.TaskNotificationDetailsID = model.TaskNotificationDetailsID;
            model.ScholarShipAllocationDTO.GeneralTaskReportingDetailsID = model.GeneralTaskReportingDetailsID;
            model.ScholarShipAllocationDTO.IsLastRecord = model.IsLastRecord;
            model.ScholarShipAllocationDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
            IBaseEntityResponse<ScholarShipAllocation> response = _ScholarShipAllocationServiceAcess.InsertScholarShipAllocationApproveRequest(model.ScholarShipAllocationDTO);
            model.ScholarShipAllocationDTO.errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
            return Json(model.ScholarShipAllocationDTO.errorMessage, JsonRequestBehavior.AllowGet);
        }

        #endregion

        // Non-Action Method
        #region Methods
        [NonAction]
        protected List<ScholarShipAllocation> GetCourseSearchList(string centreCode)
        {

            ScholarShipAllocationSearchRequest searchRequest = new ScholarShipAllocationSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            List<ScholarShipAllocation> CourseList = new List<ScholarShipAllocation>();
            searchRequest.CentreCode = centreCode;
            IBaseEntityCollectionResponse<ScholarShipAllocation> baseEntityCollectionResponse = _ScholarShipAllocationServiceAcess.GetCourseYearList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    CourseList = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return CourseList;
        }
         [NonAction]
        protected List<ScholarShipAllocation> GetScholarShip()
        {

            ScholarShipAllocationSearchRequest searchRequest = new ScholarShipAllocationSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            List<ScholarShipAllocation> ScholarShipList = new List<ScholarShipAllocation>();
            IBaseEntityCollectionResponse<ScholarShipAllocation> baseEntityCollectionResponse = _ScholarShipAllocationServiceAcess.GetScholarShipList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    ScholarShipList = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return ScholarShipList;
        }
        [HttpPost]
        public JsonResult GetStudentDetails(string query, string centreCode, int branchID) 
        {
            var data = GetStudentDetailsByCentreCodeAndCourse(query, centreCode, branchID);
            var result = (from r in data
                         select new
                         {
                             studentId=r.StudentID,
                             studentName=r.StudentName,
                             studentAmissionDetailID = r.StudentAmissionDetailID,
                             academicYearId=r.AcademicYearID,
                             branchId=r.BranchID,
                             admissionPatternID=r.AdmissionPatternID,
                             courseYearId=r.CourseYearId,
                             gender=r.Gender,
                             enrollmentNumber=r.EnrollmentNumber,
                             standardNumber=r.StandardNumber,
                             sectionDetailID=r.SectionDetailID,
                             oldSectionDetailID=r.OldSectionDetailID,
                             admitAcademicYear=r.AdmitAcademicYear,
                             studentEmailID=r.StudentEmailID,
                             studentPhoto= r.StudentPhoto != null ? Convert.ToBase64String(r.StudentPhoto) : string.Empty,
                             studentPhotoFileHeight=r.StudentPhotoFileHeight,
                             studentPhotoFilename=r.StudentPhotoFilename,
                             studentSignatureFileSize=r.StudentSignatureFileSize,
                             studentPhotoFileWidth=r.StudentPhotoFileWidth,
                             studentPhotoType=r.StudentPhotoType,
                             branchDescription=r.BranchDescription,
                             branchShortCode=r.BranchShortCode,
                             admissionPattern=r.AdmissionPattern,
                             courseYearDesc=r.CourseYearDesc,
                             courseYearCode=r.CourseYearCode,
                             sectionDetailsDesc = r.SectionDetailsDesc,
                             sessionName = r.SessionName
                         }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }
       
        [NonAction]
        protected List<ScholarShipAllocation> GetStudentDetailsByCentreCodeAndCourse(string query, string centreCode, int branchID)
        {

            ScholarShipAllocationSearchRequest searchRequest = new ScholarShipAllocationSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            List<ScholarShipAllocation> studentList = new List<ScholarShipAllocation>();
            searchRequest.SearchWord = query;
            searchRequest.CentreCode= centreCode;
            searchRequest.BranchID = branchID;
            IBaseEntityCollectionResponse<ScholarShipAllocation> baseEntityCollectionResponse = _ScholarShipAllocationServiceAcess.GetStudentListBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    studentList = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return studentList;
        }

       
        [NonAction]
        public IEnumerable<ScholarShipAllocationViewModel> GetScholarShipAllocation(string centreCode, out int TotalRecords)
        {
            ScholarShipAllocationSearchRequest searchRequest = new ScholarShipAllocationSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.CentreCode = centreCode;
            _actionMode = Convert.ToString(TempData["ActionMode"]);
            if (Enum.TryParse(_actionMode, out actionModeEnum))     // checks actionMode i.e. Insert or Update // 
            {
                if (actionModeEnum == ActionModeEnum.Insert)        // parameters for SelectAll procedures under Insert or Update mode condition
                {
                    searchRequest.SortBy = "B.CreatedDate";
                    searchRequest.StartRow = 0;
                    searchRequest.EndRow = 10;
                    searchRequest.SearchBy = string.Empty;
                    searchRequest.SortDirection = "desc";
                }
                if (actionModeEnum == ActionModeEnum.Update)        // parameters for SelectAll procedures under Insert or Update mode condition
                {
                    searchRequest.SortBy = "B.ModifiedDate";
                    searchRequest.StartRow = 0;
                    searchRequest.EndRow = 10;
                    searchRequest.SearchBy = string.Empty;
                    searchRequest.SortDirection = "desc";
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
            List<ScholarShipAllocationViewModel> listScholarShipAllocationViewModel = new List<ScholarShipAllocationViewModel>();
            List<ScholarShipAllocation> listScholarShipAllocation = new List<ScholarShipAllocation>();
            IBaseEntityCollectionResponse<ScholarShipAllocation> baseEntityCollectionResponse = _ScholarShipAllocationServiceAcess.GetScholarShipAllocationBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listScholarShipAllocation = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (ScholarShipAllocation item in listScholarShipAllocation)
                    {
                        ScholarShipAllocationViewModel ScholarShipAllocationViewModel = new ScholarShipAllocationViewModel();
                        ScholarShipAllocationViewModel.ScholarShipAllocationDTO = item;
                        listScholarShipAllocationViewModel.Add(ScholarShipAllocationViewModel);
                    }
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listScholarShipAllocationViewModel;
        }

        [NonAction]
        protected List<ScholarShipAllocation> GetScholarShipAllocationApprovalList(int personId, int taskNotificationMasterID)
        {
            ScholarShipAllocationSearchRequest searchRequest = new ScholarShipAllocationSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.PersonID = personId;
            searchRequest.TaskNotificationMasterID = taskNotificationMasterID;
            List<ScholarShipAllocation> listFeeApproval = new List<ScholarShipAllocation>();
            IBaseEntityCollectionResponse<ScholarShipAllocation> baseEntityCollectionResponse = _ScholarShipAllocationServiceAcess.GetScholarShipAllocationRequestForApproval(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listFeeApproval = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listFeeApproval;
        }

        #endregion

        // AjaxHandler Method
        #region AjaxHandler
        public ActionResult AjaxHandler(JQueryDataTableParamModel param, string CentreCode)
        {

            int TotalRecords;
            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc

            IEnumerable<ScholarShipAllocationViewModel> filteredScholarShipAllocation;
            switch (Convert.ToInt32(sortColumnIndex))
            {
                case 0:
                    _sortBy = "b.FirstName";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "b.FirstName  Like '%" + param.sSearch + "%' or b.LastName  Like '%" + param.sSearch + "%' or a.TransDate Like '%" + param.sSearch + "%' or a.ScholarSheepDocumentNumber Like '%" + param.sSearch + "%' or a.ApproveStatus Like '%" + param.sSearch + "%' ";         //this "if" block is added for search functionality
                    }                                                            
                    break;                                                       
                                                                                 
                case 1:                                                          
                    _sortBy = "a.TransDate";                                       
                    if (string.IsNullOrEmpty(param.sSearch))                     
                    {                                                            
                        _searchBy = string.Empty;                                
                    }                                                            
                    else                                                         
                    {
                        _searchBy = "b.FirstName  Like '%" + param.sSearch + "%' or b.LastName  Like '%" + param.sSearch + "%' or a.TransDate Like '%" + param.sSearch + "%' or a.ScholarSheepDocumentNumber Like '%" + param.sSearch + "%' or a.ApproveStatus Like '%" + param.sSearch + "%' ";         //this "if" block is added for search functionality
                    }                                                            
                    break;                                                       
                                                                                 
                case 2:                                                          
                    _sortBy = "a.ScholarSheepDocumentNumber";                      
                    if (string.IsNullOrEmpty(param.sSearch))                     
                    {                                                            
                        _searchBy = string.Empty;                                
                    }                                                            
                    else                                                         
                    {                                                           
                        _searchBy = "b.FirstName  Like '%" + param.sSearch + "%' or b.LastName  Like '%" + param.sSearch + "%' or a.TransDate Like '%" + param.sSearch + "%' or a.ScholarSheepDocumentNumber Like '%" + param.sSearch + "%' or a.ApproveStatus Like '%" + param.sSearch + "%' ";         //this "if" block is added for search functionality       //this "if" block is added for search functionality
                    }                                                            
                    break;                                                       
                case 3:                                                          
                    _sortBy = "a.ApproveStatus";                               
                    if (string.IsNullOrEmpty(param.sSearch))                     
                    {                                                            
                        _searchBy = string.Empty;                                
                    }                                                            
                    else                                                         
                    {                                                            
                        _searchBy = "b.FirstName  Like '%" + param.sSearch + "%' or b.LastName  Like '%" + param.sSearch + "%' or a.TransDate Like '%" + param.sSearch + "%' or a.ScholarSheepDocumentNumber Like '%" + param.sSearch + "%' or a.ApproveStatus Like '%" + param.sSearch + "%' ";         //this "if" block is added for search functionality       //this "if" block is added for search functionality
                    }
                    break;
            }
            _sortDirection = sortDirection;
            _rowLength = param.iDisplayLength;
            _startRow = param.iDisplayStart;
            if (!string.IsNullOrEmpty(CentreCode))
            {
                var centreCode = CentreCode;
                var RoleID = "";
                if (Session["UserType"].ToString() == "A")
                {
                    RoleID = Convert.ToString(0);
                }
                else
                {
                    RoleID = Session["RoleID"].ToString();
                }
                filteredScholarShipAllocation = GetScholarShipAllocation(centreCode, out TotalRecords);
            }
            else
            {
                filteredScholarShipAllocation = new List<ScholarShipAllocationViewModel>();
                TotalRecords = 0;
            }
            var records = filteredScholarShipAllocation.Skip(0).Take(param.iDisplayLength);
            var result = from c in records select new[] { Convert.ToString(c.StudentName), Convert.ToString(c.TransDate), Convert.ToString(c.ScholarSheepDocumentNumber), Convert.ToString(c.ApproveStatus), Convert.ToString(c.BranchDesc), Convert.ToString(c.StudentID) };
            return Json(new { sEcho = param.sEcho, iTotalRecords = TotalRecords, iTotalDisplayRecords = TotalRecords, aaData = result }, JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}