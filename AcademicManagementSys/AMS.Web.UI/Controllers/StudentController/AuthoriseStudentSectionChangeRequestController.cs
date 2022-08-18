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
    public class AuthoriseStudentSectionChangeRequestController : BaseController
    {
        /// <summary>
        /// Student Readmission layers are used in this form
        /// </summary>
        IStudentReadmissionServiceAccess _studentReadmissionServiceAcess = null;
        private readonly ILogger _logException;
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

        public AuthoriseStudentSectionChangeRequestController()
        {
            _studentReadmissionServiceAcess = new StudentReadmissionServiceAccess();
        }

        // Controller Methods
        #region Controller Methods
        public ActionResult Index()
        {
            try
            {
                StudentReadmissionViewModel model = new StudentReadmissionViewModel();
                //model.StudentReadmissionDTO.CentreName = Convert.ToString(Session["CentreName"]);
                //model.StudentReadmissionDTO.CentreCode = Convert.ToString(Session["CentreCode"]);
                model.ListOrganisationStudyCentreMaster = GetCentreListRoleWise(Convert.ToInt32(Session["RoleID"]));

                List<OrganisationCentrewiseSession> list = GetCurrentSession(model.ListOrganisationStudyCentreMaster[0].CentreCode);
                model.StudentReadmissionDTO.SessionName = list.Count > 0 ? list[0].SessionName : "Session not defined !";
                model.StudentReadmissionDTO.SessionID = list.Count > 0 ? list[0].SessionID : 0;
               
                List<SelectListItem> studentSectionChangeRequest = new List<SelectListItem>();
                ViewBag.SectionList = new SelectList(studentSectionChangeRequest, "Value", "Text");
                return PartialView("/Views/Student/AuthoriseStudentSectionChangeRequest/Index.cshtml", model);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;  
            }
        }

        [HttpGet]
        public ActionResult StudentDetails(int ID, string centreCode, int courseYearID, int sectionDetailID)
        {
            try
            {
                StudentReadmissionViewModel model = new StudentReadmissionViewModel();
                model.StudentReadmissionDTO = new StudentReadmission();
                model.StudentReadmissionDTO.StudentId = ID;
                model.StudentReadmissionDTO.CentreCode = centreCode;
                model.StudentReadmissionDTO.ConnectionString = _connectioString;
                model.StudentReadmissionDTO.searchType = "CurrentYearStudent";
                IBaseEntityResponse<StudentReadmission> response = _studentReadmissionServiceAcess.SelectByID(model.StudentReadmissionDTO);
                if (response != null && response.Entity != null)
                {
                    model.StudentReadmissionDTO.ID = response.Entity.ID;
                    model.StudentReadmissionDTO.CentreCode = response.Entity.CentreCode;
                    model.StudentReadmissionDTO.AdmissionDate = response.Entity.AdmissionDate;
                    model.StudentReadmissionDTO.SectionDesc = response.Entity.SectionDesc;
                    model.StudentReadmissionDTO.BranchDescription = response.Entity.BranchDescription;
                    model.StudentReadmissionDTO.CourseYearDesc = response.Entity.CourseYearDesc;
                    model.StudentReadmissionDTO.AcademicYear = response.Entity.AcademicYear;
                    model.StudentReadmissionDTO.StudentId = response.Entity.StudentId;
                    model.StudentReadmissionDTO.StuAdmissionDetailID = response.Entity.StuAdmissionDetailID;
                    model.StudentReadmissionDTO.CentreName = response.Entity.CentreName;
                    model.StudentReadmissionDTO.BranchId = response.Entity.BranchId;
                    model.StudentReadmissionDTO.AdmissionDate = response.Entity.AdmissionDate;
                    model.StudentReadmissionDTO.StudentCode = response.Entity.StudentCode;
                }
                List<StudentSectionChangeRequest> organisationSectionMasterList = GetListOrganisationSectionMaster(courseYearID, sectionDetailID, centreCode);
                List<SelectListItem> studentSectionChangeRequest = new List<SelectListItem>();
                foreach (StudentSectionChangeRequest item in organisationSectionMasterList)
                {
                    studentSectionChangeRequest.Add(new SelectListItem { Text = item.SectionDesc, Value = item.SectionDetailID.ToString() });
                }
                ViewBag.SectionList = new SelectList(studentSectionChangeRequest, "Value", "Text");
                return PartialView("/Views/Student/AuthoriseStudentSectionChangeRequest/StudentDetails.cshtml", model);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;  
            }
        }

        [HttpPost]
        public ActionResult StudentDetails(StudentReadmissionViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model != null && model.StudentReadmissionDTO != null)
                    {
                        model.StudentReadmissionDTO.ConnectionString = _connectioString;
                        model.StudentReadmissionDTO.SectionDetailID = model.SectionDetailID;
                        model.StudentReadmissionDTO.StuAdmissionDetailID = model.StuAdmissionDetailID;
                        model.StudentReadmissionDTO.CentreCode = model.SelectedCentreCode;
                        model.StudentReadmissionDTO.AdmissionDate = model.AdmissionDate;
                        model.StudentReadmissionDTO.StudentId = model.StudentId;
                        model.StudentReadmissionDTO.AdmissionActiveFlag = true;
                        model.StudentReadmissionDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                        IBaseEntityResponse<StudentReadmission> response = _studentReadmissionServiceAcess.InsertAuthoriseStudentSectionChangeRequest(model.StudentReadmissionDTO);
                        model.StudentReadmissionDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Update);
                    }
                    return Json(model.StudentReadmissionDTO.errorMessage, JsonRequestBehavior.AllowGet);
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
        
        #region Methods
        // Non-Action Method
        public JsonResult GetStudentSearchList(string term, string maxResults, string centreCode)
        {
            try
            {
                var searchType = "AuthoriseStudentSectionChange";
                var data = GetStudentSearchList(term, maxResults, centreCode, searchType, string.Empty);
                var result = (from r in data select new { name = r.StudentName, id = r.ID, centreCode = r.CentreCode, courseYearID = r.CourseYearId, sectionDetailID = r.SectionDetailID }).ToList();
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;    
            }
        }
        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult GetSessionCentreWise(string SelectedCentreCode)
        {
            if (String.IsNullOrEmpty(SelectedCentreCode))
            {
                throw new ArgumentNullException("SelectedCentreCode");
            }

            var sessionstatus = GetCurrentSession(SelectedCentreCode+":");
            var result = (from s in sessionstatus select new { id = s.SessionID, name = s.SessionName, }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}