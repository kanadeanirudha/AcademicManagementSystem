using AMS.DTO.Enum;
using AMS.DTO;
using AMS.Base.DTO;
using AMS.ServiceAccess;
using AMS.ViewModel;
using AMS.Common;
using System.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Web.WebPages.OAuth;
using DotNetOpenAuth.AspNet;
using System.Web.Security;
using System.Security.Principal;
using System.IO;
using System.Net;
using System.Net.Mail;


namespace AMS.Web.UI.Controllers
{
    [AllowAnonymous]
    public class StudentSelfRegistrationController : BaseController
    {

        IStudentSelfRegistrationServiceAccess _StudentSelfRegistrationServiceAccess = null;
        StudentSelfRegistrationViewModel _StudentSelfRegistrationViewModel = null;
        IOrganisationStudyCentreMasterServiceAccess _organisationStudyCentreMasterServiceAccess = null;
        IOrganisationUniversityMasterServiceAccess _organisationUniversityMasterServiceAccess = null;
        IOrganisationStandardMasterServiceAccess _organisationStandardMasterServiceAccess = null;
        IGeneralLocationMasterServiceAccess _generalLocationMasterServiceAccess = null;

        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
        public StudentSelfRegistrationController()
        {
            _StudentSelfRegistrationServiceAccess = new StudentSelfRegistrationServiceAccess();
            _StudentSelfRegistrationViewModel = new StudentSelfRegistrationViewModel();
            _organisationStudyCentreMasterServiceAccess = new OrganisationStudyCentreMasterServiceAccess();
            _organisationUniversityMasterServiceAccess = new OrganisationUniversityMasterServiceAccess();
            _organisationStandardMasterServiceAccess = new OrganisationStandardMasterServiceAccess();
            _generalLocationMasterServiceAccess = new GeneralLocationMasterServiceAccess();

        }

        #region Controller Methods


        [HttpGet]
        public ActionResult AgreementPage()
        {
            StudentSelfRegistrationViewModel model = new StudentSelfRegistrationViewModel();
            return View("/Views/StudentSelfRegistration/AgreementPage.cshtml");
        }
        [HttpGet]
        public ActionResult RegistrationConfirmation(string EmailID, string FirstName)
        {
            StudentSelfRegistrationViewModel model = new StudentSelfRegistrationViewModel();
            model.FirstName = FirstName;
            model.EmailID = EmailID;
            return View("/Views/StudentSelfRegistration/RegistrationConfirmation.cshtml", model);
        }
        [HttpGet]
        public ActionResult StudentProfileStatus()
        {
            StudentSelfRegistrationViewModel model = new StudentSelfRegistrationViewModel();
            return View("/Views/StudentSelfRegistration/StudentProfileStatus.cshtml");
        }

        [HttpGet]
        public ActionResult Index()
        {
            StudentSelfRegistrationViewModel model = new StudentSelfRegistrationViewModel();
            try
            {
                //For Name Title
                List<GeneralTitleMaster> GeneralTitleMasterList = GetListGeneralTitleMaster();
                List<SelectListItem> ListGeneralTitleMaster = new List<SelectListItem>();
                foreach (GeneralTitleMaster item in GeneralTitleMasterList)
                {
                    ListGeneralTitleMaster.Add(new SelectListItem { Text = item.NameTitle, Value = item.NameTitle.ToString() });
                }
                ViewBag.GeneralTitleMasterList = new SelectList(ListGeneralTitleMaster, "Value", "Text");



                ////for Country 
                //List<GeneralCountryMaster> GeneralCountryMasterList = GetListGeneralCountryMaster();
                //List<SelectListItem> GeneralCountryMaster = new List<SelectListItem>();
                //foreach (GeneralCountryMaster item in GeneralCountryMasterList)
                //{
                //    GeneralCountryMaster.Add(new SelectListItem { Text = item.CountryName, Value = item.ID.ToString() });
                //}
                //ViewBag.GeneralCountryList = new SelectList(GeneralCountryMaster, "Value", "Text");

                ////for Category
                //List<GeneralCategoryMaster> listGeneralCategoryMaster = GetListGeneralCategoryMaster();
                //List<SelectListItem> GeneralCategoryMaster = new List<SelectListItem>();
                //foreach (GeneralCategoryMaster item in listGeneralCategoryMaster)
                //{
                //    GeneralCategoryMaster.Add(new SelectListItem { Text = item.CategoryName, Value = item.ID.ToString() });
                //}
                //ViewBag.GeneralCategoryMaster = new SelectList(GeneralCategoryMaster, "Value", "Text");

                ////// for Caste
                //List<GeneralCasteMaster> GeneralCasteMasterList = GetListGeneralCasteMaster(10);
                //List<SelectListItem> GeneralCasteMaster = new List<SelectListItem>();
                //foreach (GeneralCasteMaster item in GeneralCasteMasterList)
                //{
                //    GeneralCasteMaster.Add(new SelectListItem { Text = item.CasteName, Value = item.ID.ToString() });
                //}
                //ViewBag.GeneralCasteMasterList = new SelectList(GeneralCasteMaster, "Value", "Text");


                ////for Region 
                // string SelectedCountryID = string.Empty;
                //List<GeneralRegionMaster> generalRegionMasterList = GetListGeneralRegionMaster(SelectedCountryID);
                //List<SelectListItem> generalRegionMaster = new List<SelectListItem>();
                //foreach (GeneralRegionMaster item in generalRegionMasterList)
                //{
                //    generalRegionMaster.Add(new SelectListItem { Text = item.RegionName, Value = item.ID.ToString() });
                //}
                //ViewBag.GeneralRegionMaster = new SelectList(generalRegionMaster, "Value", "Text");



                //For study Center
                _StudentSelfRegistrationViewModel = new StudentSelfRegistrationViewModel();
                _StudentSelfRegistrationViewModel.ListOrgStudyCentreMaster = GetListOrgStudyCentreMasterOfApplicableToStudentTemplate(null);
                List<SelectListItem> OrganisationStudyCentreMaster = new List<SelectListItem>();
                foreach (StudentSelfRegistration item in _StudentSelfRegistrationViewModel.ListOrgStudyCentreMaster)
                {
                    OrganisationStudyCentreMaster.Add(new SelectListItem { Text = item.CentreName.ToString(), Value = item.CenterCode.ToString() });
                }
                ViewBag.StudyCentreList = new SelectList(OrganisationStudyCentreMaster, "Value", "Text");

                //for University
                //  _StudentSelfRegistrationViewModel.ListOrganisationUniversityMaster = GetListOrganisationUniversityMaster("0");
                List<SelectListItem> OrganisationUniversityMaster = new List<SelectListItem>();
                //foreach (OrganisationUniversityMaster item in _StudentSelfRegistrationViewModel.ListOrganisationUniversityMaster)
                //{
                //    OrganisationUniversityMaster.Add(new SelectListItem { Text = item.universityName.ToString(), Value = item.ID.ToString() });
                //}
                ViewBag.UniversityList = new SelectList(OrganisationUniversityMaster, "Value", "Text");


                //For Baranch
                //  int UniversityID=0;
                // List<ToolTemplateApplicable> organisationBranchDetailList = GetListBranchDetails(UniversityID);
                List<SelectListItem> organisationBranchDetail = new List<SelectListItem>();
                //foreach (ToolTemplateApplicable item in organisationBranchDetailList)
                //{
                //    organisationBranchDetail.Add(new SelectListItem { Text = item.BranchDescription + "(" + item.DivisionDescription + ")", Value = item.BranchDetailID.ToString() });
                //}
                ViewBag.organisationBranchDetail = new SelectList(organisationBranchDetail, "Value", "Text");

                //For Baranch
                string CountryID = "0";
                List<GeneralRegionMaster> GeneralRegionDetailList = GetListGeneralRegionMaster(CountryID);
                List<SelectListItem> GeneralRegionDetail = new List<SelectListItem>();
                foreach (GeneralRegionMaster item in GeneralRegionDetailList)
                {
                    GeneralRegionDetail.Add(new SelectListItem { Text = item.RegionName, Value = item.ID.ToString() });
                }
                ViewBag.GeneralRegionDetail = new SelectList(GeneralRegionDetail, "Value", "Text");
                // List for Standard
                List<OrganisationStandardMaster> organisationStandardMasterList = GetListOrganisationStandardMaster();
                List<SelectListItem> organisationStandardMaster = new List<SelectListItem>();
                //foreach (OrganisationStandardMaster item in organisationStandardMasterList)
                //{
                //    organisationStandardMaster.Add(new SelectListItem { Text = item.Description, Value = item.StandardNumber.ToString() });
                //}
                ViewBag.OrganisationStandardMaster = new SelectList(organisationStandardMaster, "Value", "Text");

                // for Admission Pattern

                List<SelectListItem> AdmissionPattern = new List<SelectListItem>();
                ViewBag.AdmissionPattern = new SelectList(AdmissionPattern, "Value", "Text");
                List<SelectListItem> li_AdmissionPattern = new List<SelectListItem>();
                li_AdmissionPattern.Add(new SelectListItem { Text = "New", Value = "1" });
                li_AdmissionPattern.Add(new SelectListItem { Text = "Tranfary", Value = "2" });
                li_AdmissionPattern.Add(new SelectListItem { Text = "Direct", Value = "3" });
                ViewData["AdmissionPattern"] = li_AdmissionPattern;



            }
            catch (Exception)
            {

                throw;
            }

            return PartialView(model);
        }

        [HttpPost]
        public ActionResult Create(StudentSelfRegistrationViewModel model)
        {

            if (ModelState.IsValid)
            {
                if (model != null && model.StudentSelfRegistrationDTO != null)
                {
                    model.StudentSelfRegistrationDTO.ConnectionString = _connectioString;
                    model.StudentSelfRegistrationDTO.Title = model.Title;
                    model.StudentSelfRegistrationDTO.FirstName = model.FirstName;
                    model.StudentSelfRegistrationDTO.MiddleName = model.MiddleName;
                    model.StudentSelfRegistrationDTO.LastName = model.LastName;
                    model.StudentSelfRegistrationDTO.EmailID = model.EmailID;
                    model.StudentSelfRegistrationDTO.Password = model.Password;
                    model.StudentSelfRegistrationDTO.Gender = model.Gender;
                    model.StudentSelfRegistrationDTO.DateOfBirth = model.DateOfBirth;
                    model.StudentSelfRegistrationDTO.ContactNumber = model.ContactNumber;
                    model.StudentSelfRegistrationDTO.CenterCode = model.CenterCode;
                    model.StudentSelfRegistrationDTO.UniversityID = model.UniversityID;
                    model.StudentSelfRegistrationDTO.BranchDetailID = model.BranchDetailID;
                    model.StudentSelfRegistrationDTO.StandardNumber = model.StandardNumber;
                    model.StudentSelfRegistrationDTO.AdmissionPattern = model.AdmissionPattern;
                    IBaseEntityResponse<StudentSelfRegistration> response = _StudentSelfRegistrationServiceAccess.InsertStudentSelfRegistration(model.StudentSelfRegistrationDTO);
                    model.StudentSelfRegistrationDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                    if (response.Entity != null)
                    {
                        // int AAA = response.Entity.ErrorCode;
                        string body = "<Html><Body><div>"
                            + "<div><span>Hello " + model.FirstName + ",</span><br /><br />"
                            + "<span>You have registered successfully.</span><br />"
                            + "<span>Your login credentials are :</span><br />"
                            + "<span><b>Email Id :  " + model.EmailID + "</b></span><br />"
                            + "<span><b>Password : " + model.Password + "</b></span><br /><br />"
                            + "</div>"
                            + "</div></Body></Html>";
                        bool aaaa = SendEmail(model.EmailID, "Self Registration Successfully!!!", body, System.Configuration.ConfigurationManager.AppSettings["SendEmailID"], System.Configuration.ConfigurationManager.AppSettings["SendPassword"]);
                    }
                }

                return Json(Boolean.TrueString);
            }
            else
            {
                return Json(Boolean.FalseString);
            }
        }



        #endregion

        #region Methods

        protected List<OrganisationUniversityMaster> GetListOrganisationUniversityMaster(string CenterCode)
        {
            OrganisationUniversityMasterSearchRequest searchRequest = new OrganisationUniversityMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.CentreCode = CenterCode;


            List<OrganisationUniversityMaster> listOrganisationUniversityMaster = new List<OrganisationUniversityMaster>();
            IBaseEntityCollectionResponse<OrganisationUniversityMaster> baseEntityCollectionResponse = _organisationUniversityMasterServiceAccess.GetByCentreCode(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listOrganisationUniversityMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listOrganisationUniversityMaster;
        }

        protected List<StudentSelfRegistration> GetListOrgStudyCentreMasterOfApplicableToStudentTemplate(string ApplicableForEntranceExam)
        {

            StudentSelfRegistrationSearchRequest searchRequest = new StudentSelfRegistrationSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.ApplicableForEntranceExam = ApplicableForEntranceExam;
            List<StudentSelfRegistration> listOrganisationStudyCentreMaster = new List<StudentSelfRegistration>();
            IBaseEntityCollectionResponse<StudentSelfRegistration> baseEntityCollectionResponse = _StudentSelfRegistrationServiceAccess.GetListOrgStudyCentreMasterOfApplicableToStudentTemplate(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listOrganisationStudyCentreMaster = baseEntityCollectionResponse.CollectionResponse.ToList();

                }
            }
            return listOrganisationStudyCentreMaster;
        }

        protected List<StudentSelfRegistration> GetListBranchDetailsOfApplicableToStudentTemplate(int UniversityID, string CentreCode)
        {
            StudentSelfRegistrationSearchRequest searchRequest = new StudentSelfRegistrationSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

            searchRequest.UniversityID = UniversityID;
            searchRequest.CenterCode = CentreCode;
            //searchRequest.SearchType = 1;
            List<StudentSelfRegistration> listBranchDetails = new List<StudentSelfRegistration>();
            IBaseEntityCollectionResponse<StudentSelfRegistration> baseEntityCollectionResponse = _StudentSelfRegistrationServiceAccess.GetListBranchDetailsOfApplicableToStudentTemplate(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listBranchDetails = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listBranchDetails;
        }

        protected List<StudentSelfRegistration> GetListStandardNumberOfApplicableToStudentTemplate(int BranchDetailID)
        {
            StudentSelfRegistrationSearchRequest searchRequest = new StudentSelfRegistrationSearchRequest();
            searchRequest.BranchDetailID = BranchDetailID;
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            List<StudentSelfRegistration> listOrganisationStandardMaster = new List<StudentSelfRegistration>();
            IBaseEntityCollectionResponse<StudentSelfRegistration> baseEntityCollectionResponse = _StudentSelfRegistrationServiceAccess.GetListStandardNumberOfApplicableToStudentTemplate(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listOrganisationStandardMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listOrganisationStandardMaster;
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult GetUniversityByCentreCode(string SelectedCentreCode)
        {

            int id = 0;
            bool isValid = Int32.TryParse(SelectedCentreCode, out id);
            var university = GetListOrganisationUniversityMaster(SelectedCentreCode);
            var result = (from s in university
                          select new
                          {
                              id = s.ID,
                              name = s.UniversityName,
                          }).OrderBy(x=>x.name).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetBranchDetailByUniversityIDAndCentreCode(string SelectedUniversityId, string SelectedCentreCode)
        {

            int id = 0;
            bool isValid = Int32.TryParse(SelectedUniversityId, out id);
            var BranchDetails = GetListBranchDetailsOfApplicableToStudentTemplate(Convert.ToInt32(SelectedUniversityId), SelectedCentreCode);
            var result = (from s in BranchDetails
                          select new
                          {
                              id = s.BranchDetailID,
                              name = s.BranchDescription + " (" + s.DivisionDescription + ")",
                          }).OrderBy(x => x.name).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetStandardNumberByBranchDetailID(string SelectedBranchDetailID)
        {

            int id = 0;
            bool isValid = Int32.TryParse(SelectedBranchDetailID, out id);
            var StandardNumber = GetListStandardNumberOfApplicableToStudentTemplate(Convert.ToInt32(SelectedBranchDetailID));
            var result = (from s in StandardNumber
                          select new
                          {
                              id = s.StandardNumber,
                              name = s.StandardDescription,
                          }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult GetGeneralRegionDetailByCountryID(string SelectedCountryID)
        {

            int id = 0;
            bool isValid = Int32.TryParse(SelectedCountryID, out id);
            var GeneralRegionDetails = GetListGeneralRegionMaster(SelectedCountryID);
            var result = (from s in GeneralRegionDetails
                          select new
                          {
                              id = s.ID,
                              name = s.RegionName,
                          }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        #endregion

        public ActionResult GetCastByCategoryID(string SelectedCategoryID)
        {

            int id = 0;
            bool isValid = Int32.TryParse(SelectedCategoryID, out id);
            var GeneralCasteDetails = GetListGeneralCasteMaster(Convert.ToInt32(SelectedCategoryID));
            var result = (from s in GeneralCasteDetails
                          select new
                          {
                              id = s.ID,
                              name = s.CasteName,
                          }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        //searchlist of location
        public JsonResult GetLocationList(string term, string CityID, string RegionID)//, string courseYearID, string sectionDetailID, string SessionID)  
        {
            var data = GetLocationListbyCityIDAndRegionID(term, CityID, RegionID);
            var result = (from r in data select new { LocationAddress = r.LocationAddress, id = r.ID }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [NonAction]
        protected List<GeneralLocationMaster> GetLocationListbyCityIDAndRegionID(string SearchKeyWord, string cityID, string RegionID)
        {
            GeneralLocationMasterSearchRequest searchRequest = new GeneralLocationMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.SearchWord = SearchKeyWord;
            searchRequest.MaxResults = 10;
            searchRequest.CityID = Convert.ToInt32(cityID);
            searchRequest.RegionID = Convert.ToInt32(RegionID);
            List<GeneralLocationMaster> listLocation = new List<GeneralLocationMaster>();
            IBaseEntityCollectionResponse<GeneralLocationMaster> baseEntityCollectionResponse = _generalLocationMasterServiceAccess.GetByRegionIDAndCityID(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listLocation = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listLocation;
        }
        //end of searchlist of location


        public ActionResult EmailVerification(string EmailID)
        {

            IGeneralVerificationServiceAccess _GeneralVerificationServiceAccess = new GeneralVerificationServiceAccess();
            GeneralVerification item = new GeneralVerification();
            item.ConnectionString = _connectioString;
            item.VerificationString = "Select Count(EmailID) as EmailCount from StuRegistration Where EmailID = '" + EmailID + "'";
            IBaseEntityResponse<GeneralVerification> response = _GeneralVerificationServiceAccess.EmailVerification(item);
            return Json(response.Entity.Status, JsonRequestBehavior.AllowGet);
        }
        public bool SendEmail(string To, string Subject, string Body, string FromUserID, string FromUserPassword)
        {
            try
            {
                using (MailMessage mm = new MailMessage(FromUserID, To))
                {
                    mm.Subject = Subject;
                    mm.Body = Body;
                    //if (fuAttachment.HasFile)
                    //{
                    //    string FileName = Path.GetFileName(fuAttachment.PostedFile.FileName);
                    //    mm.Attachments.Add(new Attachment(fuAttachment.PostedFile.InputStream, FileName));
                    //}
                    mm.IsBodyHtml = true;
                    SmtpClient smtp = new SmtpClient();
                    smtp.Host = "smtp.gmail.com";
                    smtp.EnableSsl = true;
                    NetworkCredential NetworkCred = new NetworkCredential(FromUserID, FromUserPassword);
                    smtp.UseDefaultCredentials = true;
                    smtp.Credentials = NetworkCred;
                    smtp.Port = 587;
                    smtp.Send(mm);
                    return true;
                }

            }
            catch
            {
                return false;
            }
        }


    }
}