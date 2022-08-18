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
    public class StudentSectionChangeRequestController : BaseController
    {
        IStudentSectionChangeRequestServiceAccess _studentSectionChangeRequestServiceAcess = null;
        IStudentMasterServiceAccess _studentMasterServiceAccess = null; 
        private readonly ILogger _logException;
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

        public StudentSectionChangeRequestController()
        {
            _studentSectionChangeRequestServiceAcess = new StudentSectionChangeRequestServiceAccess();
            _studentMasterServiceAccess = new StudentMasterServiceAccess();
        }

        // Controller Methods
        #region Controller Methods
        [HttpGet]
        public ActionResult Index()
        {
            try
            {
                StudentSectionChangeRequestViewModel model = new StudentSectionChangeRequestViewModel();
                //---------------------------Used static studentid....---------------------------------------------------------
                model.StudentId = 2;//Convert.ToInt32(Session["PersonId"]);
                model.StudentMasterDTO = GetStudentCentreByID(model.StudentId,"CurrentYearStudent");

                List<OrganisationCentrewiseSession> list = GetCurrentSession(model.StudentMasterDTO.CentreCode);
                model.SessionName = list.Count > 0 ? list[0].SessionName : "Session not defined !";
                model.SessionID = list.Count > 0 ? list[0].SessionID : 0;

                model.StudentMasterDTO = GetStudentDetails(model.StudentId, model.StudentMasterDTO.CentreCode);
                if (model.StudentMasterDTO != null)
                {
                    model.StudentId = model.StudentMasterDTO.ID;
                    model.StudentName = model.StudentMasterDTO.StudentName;
                    model.CentreCode = model.StudentMasterDTO.CentreCode;
                    model.CentreName = model.StudentMasterDTO.CentreName;
                    model.SectionDesc = model.StudentMasterDTO.SectionDesc;
                    model.BranchDescription = model.StudentMasterDTO.BranchDescription;
                    model.CourseYearDesc = model.StudentMasterDTO.CourseYearDesc;
                    model.CourseYearId = model.StudentMasterDTO.CourseYearId;
                    model.AcademicYear = model.StudentMasterDTO.AcademicYear;
                    model.StudentId = model.StudentMasterDTO.StudentId;
                    model.OldSectionDetailID = model.StudentMasterDTO.SectionDetailID;
                    model.CentreName = model.StudentMasterDTO.CentreName;
                    model.BranchId = model.StudentMasterDTO.BranchId;
                    model.StudentCode = model.StudentMasterDTO.StudentCode;                    
                }

                List<StudentSectionChangeRequest> organisationSectionMasterList = GetListOrganisationSectionMaster(model.CourseYearId, model.OldSectionDetailID,model.CentreCode);
                List<SelectListItem> studentSectionChangeRequest = new List<SelectListItem>();
                foreach (StudentSectionChangeRequest item in organisationSectionMasterList)
                {
                    studentSectionChangeRequest.Add(new SelectListItem { Text = item.SectionDesc, Value = item.SectionDetailID.ToString() });
                }
                ViewBag.SectionList = new SelectList(studentSectionChangeRequest, "Value", "Text");

                return PartialView("/Views/Student/StudentSectionChangeRequest/Index.cshtml", model);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;  
            }
        }
        [HttpPost]
        public ActionResult Index(StudentSectionChangeRequestViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model != null && model.StudentSectionChangeRequestDTO != null)
                    {
                        model.StudentSectionChangeRequestDTO.ConnectionString = _connectioString;
                        model.StudentSectionChangeRequestDTO.RequestSectionDetailId = model.SectionDetailID;
                        model.StudentSectionChangeRequestDTO.OldSectionDetailID = model.OldSectionDetailID; ;
                        model.StudentSectionChangeRequestDTO.CentreCode = model.CentreCode;
                        model.StudentSectionChangeRequestDTO.StudentId = model.StudentId;
                        model.StudentSectionChangeRequestDTO.SessionID = model.SessionID;
                        model.StudentSectionChangeRequestDTO.StatusOfRequest= "Pending";
                        model.StudentSectionChangeRequestDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                        IBaseEntityResponse<StudentSectionChangeRequest> response = _studentSectionChangeRequestServiceAcess.InsertStudentSectionChangeRequest(model.StudentSectionChangeRequestDTO);

                        if (response.Entity != null && !string.IsNullOrEmpty(response.Entity.errorMessage) && response.Entity.ErrorCode == 11)
                        {
                            string[] arrayList = { response.Entity.errorMessage, "#FFCC80", string.Empty };
                            model.StudentSectionChangeRequestDTO.errorMessage = string.Join(",", arrayList);
                        }
                        else if (response.Entity != null && !string.IsNullOrEmpty(response.Entity.errorMessage) && response.Entity.ErrorCode == 0)
                        {
                            string[] arrayList = { response.Entity.errorMessage, "#9FEA7A", string.Empty };
                            model.StudentSectionChangeRequestDTO.errorMessage = string.Join(",", arrayList);
                        }
                        else 
                        {
                            string[] arrayList = { response.Entity.errorMessage, "#F5CCCC", string.Empty };
                            model.StudentSectionChangeRequestDTO.errorMessage = string.Join(",", arrayList);
                        }
                    }
                    return Json(model.StudentSectionChangeRequestDTO.errorMessage, JsonRequestBehavior.AllowGet);
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
       
       
        #endregion
    }
}