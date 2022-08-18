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
    public class StudentCasteCategoryWiseReportController : BaseController
    {

        IStudentReportServiceAccess _StudentReportServiceAcess = null;

        protected static int _SectionDetailID = 0;
        protected static int _CourseYearId = 0;
        protected static int _SessionID = 0;
        protected static string _AdmissionStatus = string.Empty;
        protected static string _SortOrder = string.Empty;
        protected static int _CategoryId = 0;
        protected static string _courseOrSection = string.Empty;

        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

        public StudentCasteCategoryWiseReportController()
        {
            _StudentReportServiceAcess = new StudentReportServiceAccess();
        }

        /// <summary>
        /// First Load When controller call List Method
        /// </summary>
        /// <returns>view</returns>
        [HttpGet]
        public ActionResult Index()//string CentreCode, string UniversityID, string SectionDetailID, string CourseYearId, string AcademicYear, string admissionStatus, string sortOrder, string ReportType, string actionMode)
        {
            try
            {
                StudentReportViewModel model = new StudentReportViewModel();


                model.ListOrganisationStudyCentreMaster = GetCentreListRoleWise(Convert.ToInt32(Session["RoleID"]));

                foreach (var b in model.ListOrganisationStudyCentreMaster)
                {
                    b.CentreCode = b.CentreCode + ":" + b.ScopeIdentity;
                }


                model.ListGeneralCategoryMaster = GetListGeneralCategoryMaster();

                foreach (var b in model.ListGeneralCategoryMaster)
                {
                    b.ID = b.ID;
                    b.CategoryName = b.CategoryName;
                }

                //ForAdmissionStatus
                List<SelectListItem> AdmissionStatus = new List<SelectListItem>();
                ViewBag.AdmissionStatus = new SelectList(AdmissionStatus, "Value", "Text");
                List<SelectListItem> li_AdmissionStatus = new List<SelectListItem>();
                li_AdmissionStatus.Add(new SelectListItem { Text = "Both", Value = "B" });
                li_AdmissionStatus.Add(new SelectListItem { Text = "Provisional", Value = "P" });
                li_AdmissionStatus.Add(new SelectListItem { Text = "Confirm", Value = "C" });
                ViewData["AdmissionStatus"] = new SelectList(li_AdmissionStatus, "Value", "Text", model.StudentReportDTO.AdmissionStatus);


                List<SelectListItem> SortOrder = new List<SelectListItem>();
                ViewBag.SortOrder = new SelectList(SortOrder, "Value", "Text");
                List<SelectListItem> li_SortOrder = new List<SelectListItem>();
                li_SortOrder.Add(new SelectListItem { Text = "Roll Number Wise", Value = "R" });
                li_SortOrder.Add(new SelectListItem { Text = "Last Name Wise", Value = "L" });
                li_SortOrder.Add(new SelectListItem { Text = "First Name Wise", Value = "F" });
                ViewData["SortOrder"] = new SelectList(li_SortOrder, "Value", "Text", model.StudentReportDTO.SortOrder);


                //ForAdmissionStatus
                List<SelectListItem> Course_Section = new List<SelectListItem>();
                ViewBag.Course_Section = new SelectList(Course_Section, "Value", "Text");
                List<SelectListItem> li_Course_Section = new List<SelectListItem>();
                li_Course_Section.Add(new SelectListItem { Text = "Section", Value = "S" });
                li_Course_Section.Add(new SelectListItem { Text = "Coures Year", Value = "C" });

                ViewData["Course_Section"] = new SelectList(li_Course_Section, "Value", "Text", model.StudentReportDTO.Course_Section);



                return View("/Views/Student/Report/StudentCasteCategoryWiseReport/Index.cshtml", model);
            }
            catch (Exception)
            {

                throw;
            }


        }


        [HttpPost]
        public ActionResult Index(StudentReportViewModel model)//string SelectedHeadID, string SelectedCategoryID)
        {
            try
            {
                string[] vCentreCode = null;
                string vCentreCode1 = null;
                string vCentreCode2 = null;
                if (model.SelectedCentreCode != null)
                {
                    vCentreCode = model.SelectedCentreCode.Split(':');
                    vCentreCode1 = vCentreCode[0];
                    vCentreCode2 = vCentreCode[1];
                }
                else
                {
                    vCentreCode1 = "0";
                }

                model.ListOrganisationStudyCentreMaster = GetCentreListRoleWise(Convert.ToInt32(Session["RoleID"]));

                foreach (var b in model.ListOrganisationStudyCentreMaster)
                {
                    b.CentreCode = b.CentreCode + ":" + b.ScopeIdentity;
                }

                model.ListOrganisationCentrewiseSessionDetails = GetCentreWiseSessionListRoleWise(vCentreCode1, 1);

                foreach (var b in model.ListOrganisationCentrewiseSessionDetails)
                {
                    b.SessionID = b.SessionID;
                }

                model.ListOrganisationUniversityMaster = GetListOrganisationUniversityMaster(vCentreCode1);

                foreach (var b in model.ListOrganisationUniversityMaster)
                {
                    b.universityID = b.ID + ":" + b.universityName;
                }

                model.ListOrganisationCourseYearDetails = GetCourseYearListRole_CentreCode_UniversityWise(Convert.ToInt32(Session["RoleID"]), vCentreCode1, vCentreCode2, Convert.ToInt32(model.SelectedUniversityID));

                foreach (var b in model.ListOrganisationCourseYearDetails)
                {
                    b.ID = b.ID;
                    b.Description = b.CourseDescription;
                }
                model.ListOrganisationSectionDetails = GetSectionDetailsRole_CentreCode_UniversityWise(Convert.ToInt32(Session["RoleID"]), vCentreCode1, vCentreCode2, Convert.ToInt32(model.SelectedUniversityID));

                foreach (var b in model.ListOrganisationSectionDetails)
                {
                    b.ID = b.ID;
                }

                model.ListGeneralCategoryMaster = GetListGeneralCategoryMaster();
                foreach (var b in model.ListGeneralCategoryMaster)
                {
                    b.ID = b.ID;
                    b.CategoryName = b.CategoryName;
                }

                //ForAdmissionStatus
                List<SelectListItem> AdmissionStatus = new List<SelectListItem>();
                ViewBag.AdmissionStatus = new SelectList(AdmissionStatus, "Value", "Text");
                List<SelectListItem> li_AdmissionStatus = new List<SelectListItem>();
                li_AdmissionStatus.Add(new SelectListItem { Text = "Both", Value = "B" });
                li_AdmissionStatus.Add(new SelectListItem { Text = "Provisional", Value = "P" });
                li_AdmissionStatus.Add(new SelectListItem { Text = "Confirm", Value = "C" });
                
                List<SelectListItem> SortOrder = new List<SelectListItem>();
                ViewBag.SortOrder = new SelectList(SortOrder, "Value", "Text");
                List<SelectListItem> li_SortOrder = new List<SelectListItem>();
                li_SortOrder.Add(new SelectListItem { Text = "Roll Number Wise", Value = "R" });
                li_SortOrder.Add(new SelectListItem { Text = "Last Name Wise", Value = "L" });
                li_SortOrder.Add(new SelectListItem { Text = "First Name Wise", Value = "F" });

                //ForAdmissionStatus
                List<SelectListItem> Course_Section = new List<SelectListItem>();
                ViewBag.Course_Section = new SelectList(Course_Section, "Value", "Text");
                List<SelectListItem> li_Course_Section = new List<SelectListItem>();
                li_Course_Section.Add(new SelectListItem { Text = "Section", Value = "S" });
                li_Course_Section.Add(new SelectListItem { Text = "Coures Year", Value = "C" });
                
                if (model.IsPosted == true)
                {
                    _courseOrSection = !string.IsNullOrEmpty(model.Course_Section) ? model.Course_Section : string.Empty;
                    _SectionDetailID = !string.IsNullOrEmpty(model.Course_Section) && model.Course_Section == "S" && model.IsAllCourse == false ? Convert.ToInt32(model.SelectedSectionDetailID) : 0;
                    _CourseYearId = !string.IsNullOrEmpty(model.Course_Section) && model.Course_Section == "C" && model.IsAllCourse == false ? Convert.ToInt32(model.SelectedSectionDetailID) : 0; ;
                    _SessionID = !string.IsNullOrEmpty(model.SelectedAcademicYear) ? Convert.ToInt32(model.SelectedAcademicYear) : 0;
                    _AdmissionStatus = model.AdmissionStatus;
                    _SortOrder = model.SortOrder;
                    _CategoryId = Convert.ToInt32(model.SelectedCategoryId);
                    ViewData["AdmissionStatus"] = new SelectList(li_AdmissionStatus, "Value", "Text", model.StudentReportDTO.AdmissionStatus);
                    ViewData["SortOrder"] = new SelectList(li_SortOrder, "Value", "Text", model.StudentReportDTO.SortOrder);
                    ViewData["Course_Section"] = new SelectList(li_Course_Section, "Value", "Text", model.StudentReportDTO.Course_Section);
                    model.IsPosted = false;
                }
                else
                {
                    model.Course_Section = _courseOrSection;
                    model.SelectedSectionDetailID = _courseOrSection == "S" ? Convert.ToString(_SectionDetailID) : Convert.ToString(_CourseYearId);
                    model.SelectedAcademicYear = Convert.ToString(_SessionID);
                    model.AdmissionStatus = _AdmissionStatus;
                    model.SortOrder = _SortOrder;
                    model.SelectedCategoryId = Convert.ToString(_CategoryId);
                    ViewData["AdmissionStatus"] = new SelectList(li_AdmissionStatus, "Value", "Text", model.StudentReportDTO.AdmissionStatus);
                    ViewData["SortOrder"] = new SelectList(li_SortOrder, "Value", "Text", model.StudentReportDTO.SortOrder);
                    ViewData["Course_Section"] = new SelectList(li_Course_Section, "Value", "Text", model.StudentReportDTO.Course_Section);
                }
                return View("/Views/Student/Report/StudentCasteCategoryWiseReport/Index.cshtml", model);
            }
            catch (Exception)
            {
                throw;
            }
        }


        #region Methods
        // Non-Action Method 
        public List<StudentReport> GetListStudentCasteCategoryReport()
        {
            try
            {
                StudentReportSearchRequest searchRequest = new StudentReportSearchRequest();
                searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
                searchRequest.SectionDetailID = _SectionDetailID;
                searchRequest.CourseYearId = _CourseYearId;
                searchRequest.AcademicYear = Convert.ToString(_SessionID);
                searchRequest.AdmissionStatus = _AdmissionStatus;
                searchRequest.SortOrder = _SortOrder;
                searchRequest.CategoryId = _CategoryId;
                List<StudentReport> StudentReportFieldList = new List<StudentReport>();
                if (!string.IsNullOrEmpty(searchRequest.AcademicYear) && !string.IsNullOrEmpty(searchRequest.AdmissionStatus) && searchRequest.CategoryId > 0)
                {
                    IBaseEntityCollectionResponse<StudentReport> baseEntityCollectionResponse = _StudentReportServiceAcess.GetBySearchForCategorywise(searchRequest);
                    if (baseEntityCollectionResponse != null)
                    {
                        if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                        {
                            StudentReportFieldList = baseEntityCollectionResponse.CollectionResponse.ToList();
                        }
                    }
                }
                return StudentReportFieldList;
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion


        #region ------------CONTROLLER AJAX HANDLER METHODS------------


        [HttpGet]
        public ActionResult GetCourseYearDetails(string CentreCode, string UniversityID)
        {
            string[] vcentreCode = CentreCode.Split(':');
            var OrganisationCourseYearDetails = GetCourseYearListRole_CentreCode_UniversityWise(Convert.ToInt32(Session["RoleID"]), vcentreCode[0], vcentreCode[1], Convert.ToInt32(UniversityID));
            var result = (from s in OrganisationCourseYearDetails
                          select new
                          {
                              id = s.ID,
                              name = s.CourseDescription,
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
                              id = s.SessionID,
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
                              id = s.SessionID,
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
                              id = s.SessionID,
                              name = s.SessionName,
                          }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult GetSectionDetails(string CentreCode, string UniversityID)
        {
            string[] vcentreCode = CentreCode.Split(':');
            var OrganisationSectionDetails = GetSectionDetailsRole_CentreCode_UniversityWise(Convert.ToInt32(Session["RoleID"]), vcentreCode[0], vcentreCode[1], Convert.ToInt32(UniversityID));
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