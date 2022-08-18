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
    public class StudentReadmissionController : BaseController
    {
        IStudentReadmissionServiceAccess _studentReadmissionServiceAcess = null;
        private readonly ILogger _logException;
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

        public StudentReadmissionController()
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
                model.ListOrganisationStudyCentreMaster = GetCentreListRoleWise(Convert.ToInt32(Session["RoleID"]));

                List<OrganisationCentrewiseSession> list = GetCurrentSession(model.ListOrganisationStudyCentreMaster[0].CentreCode);
                model.StudentReadmissionDTO.SessionName = list.Count > 0 ? list[0].SessionName : "Session not defined !";
                model.StudentReadmissionDTO.SessionID = list.Count > 0 ? list[0].SessionID : 0;
                


                List<SelectListItem> li = new List<SelectListItem>();
                li.Add(new SelectListItem { Text = "Current Year Student", Value = "1" });
                li.Add(new SelectListItem { Text = "Back Year Student", Value = "0" });
                ViewData["IsCurrentYearStudent"] = li;

                return PartialView("/Views/Student/StudentReadmission/Index.cshtml", model);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;  
            }
        }

        [HttpGet]
        public ActionResult StudentDetails(int ID, string centreCode,string StudentType)
        {
            try
            {
                StudentReadmissionViewModel model = new StudentReadmissionViewModel();
                model.StudentReadmissionDTO = new StudentReadmission();
                model.StudentReadmissionDTO.StudentId = ID;
                model.StudentReadmissionDTO.CentreCode = centreCode;
                model.StudentReadmissionDTO.ConnectionString = _connectioString;
                if (StudentType =="1")
                {
                    model.StudentReadmissionDTO.searchType = "CurrentYearStudent";    
                }
                else if (StudentType == "0")
                {
                    model.StudentReadmissionDTO.searchType = "BackYearStudent";    
                }
                
                IBaseEntityResponse<StudentReadmission> response = _studentReadmissionServiceAcess.SelectByID(model.StudentReadmissionDTO);
                if (response != null && response.Entity != null)
                {
                    model.StudentReadmissionDTO.CentreCode = response.Entity.CentreCode;
                    model.StudentReadmissionDTO.SectionDesc = response.Entity.SectionDesc;
                    model.StudentReadmissionDTO.BranchDescription = response.Entity.BranchDescription;
                    model.StudentReadmissionDTO.CourseYearDesc = response.Entity.CourseYearDesc;
                    model.StudentReadmissionDTO.AcademicYear = response.Entity.AcademicYear;
                    model.StudentReadmissionDTO.StudentId = response.Entity.StudentId;
                    if (StudentType =="1")
                    {
                        model.StudentReadmissionDTO.SectionDetailID = response.Entity.OldSectionDetailID;
                    }
                    else if (StudentType == "0")
                    {
                        model.StudentReadmissionDTO.SectionDetailID = response.Entity.SectionDetailID;
                    }
                    if (StudentType == "1")
                    {
                        model.StudentReadmissionDTO.CourseYearId = response.Entity.CourseYearOldId;
                    }
                    else if (StudentType == "0")
                    {
                        model.StudentReadmissionDTO.CourseYearId = response.Entity.CourseYearId;
                    }
                    model.StudentReadmissionDTO.CentreName = response.Entity.CentreName;
                    model.StudentReadmissionDTO.BranchId = response.Entity.BranchId;
                    model.StudentReadmissionDTO.StudentCode = response.Entity.StudentCode;
                }
                return PartialView("/Views/Student/StudentReadmission/StudentDetails.cshtml",model);
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
                        model.StudentReadmissionDTO.CourseYearId = model.CourseYearId;
                        model.StudentReadmissionDTO.BranchId = model.BranchId; ;
                        model.StudentReadmissionDTO.CentreCode = model.SelectedCentreCode;
                        model.StudentReadmissionDTO.AdmissionDate = model.AdmissionDate;
                        model.StudentReadmissionDTO.StudentId = model.StudentId;
                        model.StudentReadmissionDTO.SessionID = model.SessionID;
                        model.StudentReadmissionDTO.searchType = "BackYearStudent";   
                        model.StudentReadmissionDTO.AcademicYear = model.AcademicYear;
                        model.StudentReadmissionDTO.ActiveSessionFlag = model.IsCurrentYearStudent;
                        model.StudentReadmissionDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                        IBaseEntityResponse<StudentReadmission> response = _studentReadmissionServiceAcess.InsertStudentReadmission(model.StudentReadmissionDTO);
                        model.StudentReadmissionDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
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
        public JsonResult GetStudentSearchList(string term, string maxResults, string centreCode, string studentType)
        {
            try
            {
                var searchType = "StudentReadmission";
                var data = GetStudentSearchList(term, maxResults, centreCode, searchType, studentType);
                var result = (from r in data select new { name = r.StudentName, id = r.ID, centreCode = r.CentreCode, }).ToList();
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

            var sessionstatus = GetCurrentSession(SelectedCentreCode + ":");
            var result = (from s in sessionstatus select new { id = s.SessionID, name = s.SessionName, }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}