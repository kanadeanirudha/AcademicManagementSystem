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
    public class StudentQuickRegistrationController : BaseController
    {
        IStudentQuickRegistrationServiceAccess _StudentQuickRegistrationServiceAcess = null;
        private readonly ILogger _logException;
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

        public StudentQuickRegistrationController()
        {
            _StudentQuickRegistrationServiceAcess = new StudentQuickRegistrationServiceAccess();
        }

        // Controller Methods
        #region Controller Methods
        [HttpGet]
        public ActionResult Index()
        {
            try
            {
                StudentQuickRegistrationViewModel model = new StudentQuickRegistrationViewModel();

                model.ListOrganisationStudyCentreMaster = GetCentreListRoleWise(Convert.ToInt32(Session["RoleID"]));

                foreach (var b in model.ListOrganisationStudyCentreMaster)
                {
                    b.CentreCode = b.CentreCode + ":" + b.ScopeIdentity;
                }

                //var splitData = model.ListOrganisationStudyCentreMaster[0].CentreCode.Split(':');
                //model.ListBranchRoleWise = GetBranchListRoleWise(splitData[0], model.ListOrganisationStudyCentreMaster[0].ScopeIdentity, Convert.ToInt32(Session["RoleID"]), "false");

                List<SelectListItem> AdmissionPattern = new List<SelectListItem>();
                ViewBag.AdmissionPattern = new SelectList(AdmissionPattern, "Value", "Text");
                List<SelectListItem> li = new List<SelectListItem>();
                li.Add(new SelectListItem { Text = "--Select Admission Pattern--", Value = "" });
                li.Add(new SelectListItem { Text = "Regular", Value = "1" });
                li.Add(new SelectListItem { Text = "Direct Second Year", Value = "2" });
             //   li.Add(new SelectListItem { Text = "Tranfary", Value = "3" });
                ViewData["AdmissionPattern"] = li;
                //model.ListOrganisationCentrewiseSession = GetCentreWiseSessionListRoleWise(splitData[0]);
                //model.ListOrganisationCentrewiseSessionForNewAdmission = GetCurrentSession(splitData[0]);

                //For Name Title
                List<GeneralTitleMaster> GeneralTitleMasterList = GetListGeneralTitleMaster();
                List<SelectListItem> ListGeneralTitleMaster = new List<SelectListItem>();
                foreach (GeneralTitleMaster item in GeneralTitleMasterList)
                {
                    ListGeneralTitleMaster.Add(new SelectListItem { Text = item.NameTitle, Value = item.NameTitle.ToString() });
                }
                ViewBag.GeneralTitleMasterList = new SelectList(ListGeneralTitleMaster, "Value", "Text");


                List<SelectListItem> SelectSectionDetails = new List<SelectListItem>();
                ViewBag.SectionDetails = new SelectList(SelectSectionDetails, "Value", "Text");

                List<SelectListItem> SelectUniversityDetails = new List<SelectListItem>();
                ViewBag.UniversityDetails = new SelectList(SelectUniversityDetails, "Value", "Text");
                return PartialView("/Views/Student/StudentQuickRegistration/Index.cshtml", model);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }
        [HttpPost]
        public ActionResult Index(StudentQuickRegistrationViewModel model)
        {
            try
            {
                //if (ModelState.IsValid)
                //{
                    if (model != null && model.StudentQuickRegistrationDTO != null)
                    {

                        string[] vcentreCode = model.CentreCode.Split(':');
                       

                        model.StudentQuickRegistrationDTO.ConnectionString = _connectioString;
                        model.StudentQuickRegistrationDTO.CentreCode = vcentreCode[0];
                        model.StudentQuickRegistrationDTO.UniversityID = model.UniversityID; ;
                        model.StudentQuickRegistrationDTO.BranchID = model.BranchID;
                        model.StudentQuickRegistrationDTO.AdmissionPattern = model.AdmissionPattern;
                        model.StudentQuickRegistrationDTO.AdmittedSessionID = model.AdmittedSessionID;
                        model.StudentQuickRegistrationDTO.AdmitAcademicYear = model.AdmitAcademicYear;
                        model.StudentQuickRegistrationDTO.IsBackStudent = model.IsBackStudent;
                        model.StudentQuickRegistrationDTO.AcademicSessionID = model.AcademicSessionID;
                        model.StudentQuickRegistrationDTO.SectionDetailID = model.SectionDetailID;
                        model.StudentQuickRegistrationDTO.Title = model.Title;
                        model.StudentQuickRegistrationDTO.FirstName = model.FirstName;
                        model.StudentQuickRegistrationDTO.MiddleName = model.MiddleName;
                        model.StudentQuickRegistrationDTO.LastName = model.LastName;
                        model.StudentQuickRegistrationDTO.MotherName = model.MotherName;
                        model.StudentQuickRegistrationDTO.StudentEmailID = model.StudentEmailID;
                      //  model.StudentQuickRegistrationDTO.StudentCode = model.StudentCode;
                        model.StudentQuickRegistrationDTO.StudentMobileNumber = model.StudentMobileNumber;
                        model.StudentQuickRegistrationDTO.StudentGender = model.StudentGender;
                        model.StudentQuickRegistrationDTO.DateofBirth = model.DateofBirth;
                        model.StudentQuickRegistrationDTO.StudentActiveFlag = true;
                        model.StudentQuickRegistrationDTO.StudentStatus = false;
                        model.StudentQuickRegistrationDTO.StatusCode = "Pursuing";
                        model.StudentQuickRegistrationDTO.CourseYearId = model.CourseYearId;
                        model.StudentQuickRegistrationDTO.studentAddress = model.studentAddress;
                        model.StudentQuickRegistrationDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                        IBaseEntityResponse<StudentQuickRegistration> response = _StudentQuickRegistrationServiceAcess.InsertStudentQuickRegistration(model.StudentQuickRegistrationDTO);
                        model.StudentQuickRegistrationDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                        return Json(model.StudentQuickRegistrationDTO.errorMessage, JsonRequestBehavior.AllowGet);
                    }
                   
                //}
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


        #region ------------CONTROLLER AJAX HANDLER METHODS------------
        [HttpGet]
        public ActionResult GetBranchDetails(string CentreCode, string UniversityID)
        {
            string[] vcentreCode = CentreCode.Split(':');
            var OrganisationBranchDetails = GetBranchListRoleWise(vcentreCode[0], vcentreCode[1], Convert.ToInt32(Session["RoleID"]), Convert.ToInt32(UniversityID), "false");
            var result = (from s in OrganisationBranchDetails
                          select new
                          {
                              id = s.ID,
                              name = s.BranchDescription,
                          }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult GetSessionDetails(string CentreCode)
        {
            string[] vcentreCode = CentreCode.Split(':');
            var OrganisationSessionDetails = GetCentreWiseSessionListRoleWise(vcentreCode[0], 0);
            var result = (from s in OrganisationSessionDetails
                          select new
                          {
                              id = s.ID,
                              name = s.SessionName,
                          }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetAllSessionDetails(string CentreCode)
        {
            string[] vcentreCode = CentreCode.Split(':');
            var OrganisationSessionDetails = GetCentreWiseSessionListRoleWise(vcentreCode[0], 1);
            var result = (from s in OrganisationSessionDetails
                          select new
                          {
                              id = s.ID,
                              name = s.SessionName,
                          }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult GetCurrentSessionDetails(string CentreCode)
        {
            string[] vcentreCode = CentreCode.Split(':');
            var OrganisationCurrentSessionDetails = GetCurrentSession(vcentreCode[0]);
            var result = (from s in OrganisationCurrentSessionDetails
                          select new
                          {
                              id = s.ID,
                              name = s.SessionName,
                          }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult GetSectionDetails(string SelectedBranchID, string CentreCode,string UniversityID)
        {
            string[] vcentreCode = CentreCode.Split(':');
            int id = 0;
            bool isValid = Int32.TryParse(SelectedBranchID, out id);
            var OrganisationSectionDetails = GetSectionDetailsRoleWise(Convert.ToInt32(SelectedBranchID), vcentreCode[0],UniversityID,"false");
            var result = (from s in OrganisationSectionDetails
                          select new
                          {
                              id = s.ID, 
                              name = s.Descriptions,
                          }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

          [HttpGet]
        public ActionResult GetUniversityByCentreCode(string CentreCode)
        {
            string[] vcentreCode = CentreCode.Split(':');
            //int id = 0;
            //bool isValid = Int32.TryParse(SelectedCentreCode, out id);
            var university = GetListOrganisationUniversityMaster(vcentreCode[0]);
            var result = (from s in university
                          select new
                          {
                              id = s.ID,
                              name = s.UniversityName,
                          }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        #endregion

    }
}