using AMS.Base.DTO;
using AMS.DTO;
using AMS.ServiceAccess;
using AMS.ViewModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web.Mvc;
using System.Web;
using AMS.Common;
using System.IO;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Net;

namespace AMS.Web.UI.Controllers
{
    [AllowAnonymous]
    public class StudentRegistrationFormController : BaseController
    {
        //
        // GET: /StudentRegistrationForm/
        IGeneralLocationMasterServiceAccess _generalLocationMasterServiceAccess = null;
        IStudentRegistrationFormServiceAccess _StudentRegistrationFormServiceAccess = null;
        IStudentRegistrationAcademicApprovalServiceAccess _StudentRegistrationAcademicApprovalServiceAcess = null;
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
        public StudentRegistrationFormController()
        {
            _StudentRegistrationFormServiceAccess = new StudentRegistrationFormServiceAccess();
            _generalLocationMasterServiceAccess = new GeneralLocationMasterServiceAccess();
            _StudentRegistrationAcademicApprovalServiceAcess = new StudentRegistrationAcademicApprovalServiceAccess();
        }
         [AllowAnonymous]
        public ActionResult Index()
        {


            StudentRegistrationFormViewModel model = new StudentRegistrationFormViewModel();

            model.StudentRegistrationFormDTO.ConnectionString = _connectioString;
            model.StudentRegistrationFormDTO.StudentEmailID = Session["EmailID"].ToString();
            model.StudentRegistrationFormDTO.Password = Session["Password"].ToString();
            // For Student Information
            IBaseEntityResponse<StudentRegistrationForm> response = _StudentRegistrationFormServiceAccess.SelectByEmailIDAndPassword(model.StudentRegistrationFormDTO);
            if (response != null && response.Entity != null)
            {
                // model.StudentRegistrationFormDTO.ID = response.Entity.ID;
                model.StudentRegistrationFormDTO.StudentSelfRegistrationID = response.Entity.StudentSelfRegistrationID;
                model.StudentRegistrationFormDTO.StudentTitle = response.Entity.StudentTitle;
                model.StudentRegistrationFormDTO.StudentFirstName = response.Entity.StudentFirstName;
                model.StudentRegistrationFormDTO.StudentMiddleName = response.Entity.StudentMiddleName;
                model.StudentRegistrationFormDTO.StudentLastName = response.Entity.StudentLastName;
                model.StudentRegistrationFormDTO.StudentEmailID = response.Entity.StudentEmailID;
                model.StudentRegistrationFormDTO.StudentGender = response.Entity.StudentGender;
                model.StudentRegistrationFormDTO.StudentMobileNumber = response.Entity.StudentMobileNumber;
                model.StudentRegistrationFormDTO.FatherTitle = "Mr.";
                model.StudentRegistrationFormDTO.FatherFirstName = response.Entity.StudentMiddleName;
                model.StudentRegistrationFormDTO.FatherLastName = response.Entity.StudentLastName;
                model.StudentRegistrationFormDTO.StudentDateofBirth = response.Entity.StudentDateofBirth;
                model.StudentRegistrationFormDTO.BranchDetailID = response.Entity.BranchDetailID;
                model.StudentRegistrationFormDTO.StandardNumber = response.Entity.StandardNumber;
                model.StudentRegistrationFormDTO.CenterCode = response.Entity.CenterCode;
                model.StudentRegistrationFormDTO.UniversityID = response.Entity.UniversityID;
                model.StudentRegistrationFormDTO.Student_QualifyingExamId = response.Entity.Student_QualifyingExamId;
                model.StudentRegistrationFormDTO.Student_QualifyingExamName = response.Entity.Student_QualifyingExamName;
                model.StudentRegistrationFormDTO.Student_DTE_QualifyingExamId = response.Entity.Student_QualifyingExamId;
                model.StudentRegistrationFormDTO.Student_DTE_QualifyingExamName = response.Entity.Student_QualifyingExamName;
                model.StudentRegistrationFormDTO.AdmissionPattern = response.Entity.AdmissionPattern;
                // model.StudentRegistrationFormDTO.MotherTitle = "Mrs.";

                #region Method
                //For Title
                List<SelectListItem> StudentRegistrationForm = new List<SelectListItem>();
                ViewBag.StudentRegistrationForm = new SelectList(StudentRegistrationForm, "Value", "Text");
                List<SelectListItem> li = new List<SelectListItem>();
                li.Add(new SelectListItem { Text = "Mr.", Value = "Mr." });
                li.Add(new SelectListItem { Text = "Mrs.", Value = "Mrs." });
                li.Add(new SelectListItem { Text = "Miss.", Value = "Miss." });
                ViewData["Title"] = li;

                //For NRI_POI
                List<SelectListItem> StudentRegistrationForm_NRI_POI = new List<SelectListItem>();
                ViewBag.StudentRegistrationForm_NRI_POI = new SelectList(StudentRegistrationForm_NRI_POI, "Value", "Text");
                List<SelectListItem> li_StudentRegistrationForm_NRI_POI = new List<SelectListItem>();
                li_StudentRegistrationForm_NRI_POI.Add(new SelectListItem { Text = "NONE", Value = "NONE" });
                li_StudentRegistrationForm_NRI_POI.Add(new SelectListItem { Text = "NRI", Value = "NRI" });
                li_StudentRegistrationForm_NRI_POI.Add(new SelectListItem { Text = "POI", Value = "POI" });
                ViewData["StudentNRI_POI"] = li_StudentRegistrationForm_NRI_POI;

                //For Nationality

                List<GeneralNationalityMaster> generalNationalityMasterList = GetListGeneralNationalityMaster();
                List<SelectListItem> generalNationalityMaster = new List<SelectListItem>();
                foreach (GeneralNationalityMaster item in generalNationalityMasterList)
                {
                    generalNationalityMaster.Add(new SelectListItem { Text = item.Description, Value = item.ID.ToString() });
                }
                ViewBag.GeneralNationalityMaster = new SelectList(generalNationalityMaster, "Value", "Text");

                //For MaritalStatus
                List<SelectListItem> StudentRegistrationForm_StudentMaritalStatus = new List<SelectListItem>();
                ViewBag.StudentRegistrationForm_StudentMaritalStatus = new SelectList(StudentRegistrationForm_StudentMaritalStatus, "Value", "Text");
                List<SelectListItem> li_StudentRegistrationForm_StudentMaritalStatus = new List<SelectListItem>();
                li_StudentRegistrationForm_StudentMaritalStatus.Add(new SelectListItem { Text = "-- Select Marital Status -- ", Value = "N" });
                li_StudentRegistrationForm_StudentMaritalStatus.Add(new SelectListItem { Text = "UNMARRIED", Value = "U" });
                li_StudentRegistrationForm_StudentMaritalStatus.Add(new SelectListItem { Text = "MARRIED", Value = "M" });
                li_StudentRegistrationForm_StudentMaritalStatus.Add(new SelectListItem { Text = "DIVORCEE", Value = "D" });
                li_StudentRegistrationForm_StudentMaritalStatus.Add(new SelectListItem { Text = "WIDOW", Value = "W" });
                li_StudentRegistrationForm_StudentMaritalStatus.Add(new SelectListItem { Text = "JUDICIALLY SEPARETED", Value = "J" });
                ViewData["StudentMaritalStatus"] = li_StudentRegistrationForm_StudentMaritalStatus;

                //For Blood Group
                List<SelectListItem> StudentRegistrationForm_StudentBloodGroup = new List<SelectListItem>();
                ViewBag.StudentRegistrationForm_StudentBloodGroup = new SelectList(StudentRegistrationForm_StudentBloodGroup, "Value", "Text");
                List<SelectListItem> li_StudentRegistrationForm_StudentBloodGroup = new List<SelectListItem>();
                li_StudentRegistrationForm_StudentBloodGroup.Add(new SelectListItem { Text = "-- Select Blood Group -- ", Value = "" });
                li_StudentRegistrationForm_StudentBloodGroup.Add(new SelectListItem { Text = "O-", Value = "O-" });
                li_StudentRegistrationForm_StudentBloodGroup.Add(new SelectListItem { Text = "O+", Value = "O+" });
                li_StudentRegistrationForm_StudentBloodGroup.Add(new SelectListItem { Text = "A-", Value = "A-" });
                li_StudentRegistrationForm_StudentBloodGroup.Add(new SelectListItem { Text = "A+", Value = "A+" });
                li_StudentRegistrationForm_StudentBloodGroup.Add(new SelectListItem { Text = "B-", Value = "B-" });
                li_StudentRegistrationForm_StudentBloodGroup.Add(new SelectListItem { Text = "B+", Value = "B+" });
                li_StudentRegistrationForm_StudentBloodGroup.Add(new SelectListItem { Text = "AB-", Value = "AB-" });
                li_StudentRegistrationForm_StudentBloodGroup.Add(new SelectListItem { Text = "AB+", Value = "AB+" });
                ViewData["StudentBloodGroup"] = li_StudentRegistrationForm_StudentBloodGroup;

                //For PhysicallyHandicapped
                List<SelectListItem> StudentRegistrationForm_StudentPhysicallyHandicapped = new List<SelectListItem>();
                ViewBag.StudentRegistrationForm_StudentPhysicallyHandicapped = new SelectList(StudentRegistrationForm_StudentPhysicallyHandicapped, "Value", "Text");
                List<SelectListItem> li_StudentRegistrationForm_StudentPhysicallyHandicapped = new List<SelectListItem>();
                li_StudentRegistrationForm_StudentPhysicallyHandicapped.Add(new SelectListItem { Text = "NO", Value = "0" });
                li_StudentRegistrationForm_StudentPhysicallyHandicapped.Add(new SelectListItem { Text = "YES", Value = "1" });
                ViewData["StudentPhysicallyHandicapped"] = li_StudentRegistrationForm_StudentPhysicallyHandicapped;
                //For Organ donor
                List<SelectListItem> StudentRegistrationForm_StudentOrgandonor = new List<SelectListItem>();
                ViewBag.StudentRegistrationForm_StudentOrgandonor = new SelectList(StudentRegistrationForm_StudentOrgandonor, "Value", "Text");
                List<SelectListItem> li_StudentRegistrationForm_StudentOrgandonor = new List<SelectListItem>();
                li_StudentRegistrationForm_StudentOrgandonor.Add(new SelectListItem { Text = "NO", Value = "0" });
                li_StudentRegistrationForm_StudentOrgandonor.Add(new SelectListItem { Text = "YES", Value = "1" });
                ViewData["StudentOrgandonor"] = li_StudentRegistrationForm_StudentOrgandonor;

                //For Religion
                List<GeneralReligionMaster> generalReligionMasterList = GetListGeneralReligionMaster();
                List<SelectListItem> generalReligionMaster = new List<SelectListItem>();
                foreach (GeneralReligionMaster item in generalReligionMasterList)
                {
                    generalReligionMaster.Add(new SelectListItem { Text = item.Description, Value = item.ID.ToString() });
                }
                ViewBag.GeneralReligionMaster = new SelectList(generalReligionMaster, "Value", "Text");

                //For Region
                int CountryId = 0;
                List<GeneralRegionMaster> generalRegionMasterList = GetListGeneralRegionMaster(Convert.ToString(CountryId));
                List<SelectListItem> generalRegionMaster = new List<SelectListItem>();
                generalRegionMaster.Add(new SelectListItem { Text = "-- Select Region--", Value = "" });
                foreach (GeneralRegionMaster item in generalRegionMasterList)
                {
                    generalRegionMaster.Add(new SelectListItem { Text = item.RegionName + " ( " + item.CountryName + " )", Value = item.ID.ToString() });
                }
                generalRegionMaster.Add(new SelectListItem { Text = "Other", Value = "Other" });

                ViewBag.GeneralRegionMaster = new SelectList(generalRegionMaster, "Value", "Text");

                //For Category
                List<GeneralCategoryMaster> generalCategoryMasterList = GetListGeneralCategoryMaster();
                List<SelectListItem> generalCategoryMaster = new List<SelectListItem>();
                foreach (GeneralCategoryMaster item in generalCategoryMasterList)
                {
                    generalCategoryMaster.Add(new SelectListItem { Text = item.CategoryName + " ( " + item.CategoryType + " )", Value = item.ID.ToString() });
                }
                ViewBag.GeneralCategoryMaster = new SelectList(generalCategoryMaster, "Value", "Text");

                //For Caste
                int CategoryID = 0;

                List<GeneralCasteMaster> GeneralCasteMasterList = GetListGeneralCasteMaster(CategoryID);
                List<SelectListItem> GeneralCasteMaster = new List<SelectListItem>();
                foreach (GeneralCasteMaster item in GeneralCasteMasterList)
                {
                    GeneralCasteMaster.Add(new SelectListItem { Text = item.CasteName, Value = item.ID.ToString() });
                }
                ViewBag.GeneralCasteMasterList = new SelectList(GeneralCasteMaster, "Value", "Text");

                //For Language
                List<GeneralLanguageMaster> generalLanguageMasterList = GetListGeneralLanguageMaster();
                List<SelectListItem> generalLanguageMaster = new List<SelectListItem>();
                foreach (GeneralLanguageMaster item in generalLanguageMasterList)
                {
                    generalLanguageMaster.Add(new SelectListItem { Text = item.LanguageName, Value = item.ID.ToString() });
                }
                ViewBag.GeneralLanguageMaster = new SelectList(generalLanguageMaster, "Value", "Text");

                //For AdmissionType
                List<OrganisationAdmissionTypeMaster> OrganisationAdmissionTypeMasterList = GetListOrganisationAdmissionTypeMaster();
                List<SelectListItem> OrganisationAdmissionTypeMaster = new List<SelectListItem>();
                foreach (OrganisationAdmissionTypeMaster item in OrganisationAdmissionTypeMasterList)
                {
                    OrganisationAdmissionTypeMaster.Add(new SelectListItem { Text = item.AdmissionType, Value = item.ID.ToString() });
                }
                ViewBag.OrganisationAdmissionTypeMaster = new SelectList(OrganisationAdmissionTypeMaster, "Value", "Text");

                //For AllotAdmission
                List<OrganisationAllotAdmissionMaster> OrganisationAllotAdmissionMasterList = GetListOrganisationAllotAdmissionMaster();
                List<SelectListItem> OrganisationAllotAdmissionMaster = new List<SelectListItem>();
                foreach (OrganisationAllotAdmissionMaster item in OrganisationAllotAdmissionMasterList)
                {
                    OrganisationAllotAdmissionMaster.Add(new SelectListItem { Text = item.AllotAdmission, Value = item.ID.ToString() });
                }
                ViewBag.OrganisationAllotAdmissionMaster = new SelectList(OrganisationAllotAdmissionMaster, "Value", "Text");

                //For EconomicallyBackwardClass 
                List<SelectListItem> StudentRegistrationForm_StudentEconomicallyBackwardClass = new List<SelectListItem>();
                ViewBag.StudentRegistrationForm_StudentEconomicallyBackwardClass = new SelectList(StudentRegistrationForm_StudentEconomicallyBackwardClass, "Value", "Text");
                List<SelectListItem> li_StudentRegistrationForm_StudentEconomicallyBackwardClass = new List<SelectListItem>();
                li_StudentRegistrationForm_StudentEconomicallyBackwardClass.Add(new SelectListItem { Text = "NO", Value = "0" });
                li_StudentRegistrationForm_StudentEconomicallyBackwardClass.Add(new SelectListItem { Text = "YES", Value = "1" });
                ViewData["StudentEconomicallyBackwardClass"] = li_StudentRegistrationForm_StudentEconomicallyBackwardClass;

                //for Country 
                List<GeneralCountryMaster> GeneralCountryMasterList = GetListGeneralCountryMaster();
                List<SelectListItem> GeneralCountryMaster = new List<SelectListItem>();
                foreach (GeneralCountryMaster item in GeneralCountryMasterList)
                {
                    GeneralCountryMaster.Add(new SelectListItem { Text = item.CountryName, Value = item.ID.ToString() });
                }

                ViewBag.GeneralCountryList = new SelectList(GeneralCountryMaster, "Value", "Text");


                //for Region  Perticular Country
                string SelectedCountryID = string.Empty;
                List<GeneralRegionMaster> generalRegionMasterForPerticularCountryList = GetListGeneralRegionMaster(SelectedCountryID);
                List<SelectListItem> generalRegionMasterForPerticularCountry = new List<SelectListItem>();
                foreach (GeneralRegionMaster item in generalRegionMasterForPerticularCountryList)
                {
                    generalRegionMasterForPerticularCountry.Add(new SelectListItem { Text = item.RegionName, Value = item.ID.ToString() });
                }

                ViewBag.GeneralRegionMasterForPerticularCountry = new SelectList(generalRegionMaster, "Value", "Text");


                List<SelectListItem> GeneralBlankRegionMaster = new List<SelectListItem>();
                //foreach (GeneralCityMaster item in GeneralCityMasterList)
                //{
                //    GeneralCityMaster.Add(new SelectListItem { Text = item.Description, Value = item.ID.ToString() });
                //}

                ViewBag.GeneralBlankRegionMasterList = new SelectList(GeneralBlankRegionMaster, "Value", "Text");

                //for City  
                // string SelectedRegionID = "A";

                // List<GeneralCityMaster> GeneralCityMasterList = GetListGeneralCityMaster(SelectedRegionID);
                List<SelectListItem> GeneralCityMaster = new List<SelectListItem>();
                //foreach (GeneralCityMaster item in GeneralCityMasterList)
                //{
                //    GeneralCityMaster.Add(new SelectListItem { Text = item.Description, Value = item.ID.ToString() });
                //}

                ViewBag.GeneralCityList = new SelectList(GeneralCityMaster, "Value", "Text");


                List<SelectListItem> GeneralLocationMaster = new List<SelectListItem>();
                ViewBag.GeneralLocationList = new SelectList(GeneralLocationMaster, "Value", "Text");


                //For City_Tahsil_Pattern
                List<SelectListItem> StudentRegistrationForm_PermanentAddress_City_Tahsil_Pattern = new List<SelectListItem>();
                ViewBag.StudentRegistrationForm_PermanentAddress_City_Tahsil_Pattern = new SelectList(StudentRegistrationForm_PermanentAddress_City_Tahsil_Pattern, "Value", "Text");
                List<SelectListItem> li_StudentRegistrationForm_PermanentAddress_City_Tahsil_Pattern = new List<SelectListItem>();
                li_StudentRegistrationForm_PermanentAddress_City_Tahsil_Pattern.Add(new SelectListItem { Text = "Urban", Value = "U" });
                li_StudentRegistrationForm_PermanentAddress_City_Tahsil_Pattern.Add(new SelectListItem { Text = "Rural", Value = "R" });
                li_StudentRegistrationForm_PermanentAddress_City_Tahsil_Pattern.Add(new SelectListItem { Text = "Tribal", Value = "T" });
                ViewData["StudentPermanentAddress_City_Tahsil_Pattern"] = li_StudentRegistrationForm_PermanentAddress_City_Tahsil_Pattern;
                //For Exam_Pattern
                List<SelectListItem> StudentRegistrationForm_Exam_Pattern = new List<SelectListItem>();
                ViewBag.StudentRegistrationForm_Exam_Pattern = new SelectList(StudentRegistrationForm_Exam_Pattern, "Value", "Text");
                List<SelectListItem> li_StudentRegistrationForm_Exam_Pattern = new List<SelectListItem>();
                li_StudentRegistrationForm_Exam_Pattern.Add(new SelectListItem { Text = "Yearly", Value = "Y" });
                li_StudentRegistrationForm_Exam_Pattern.Add(new SelectListItem { Text = "Semester", Value = "S" });
                ViewData["StudentRegistrationForm_Exam_Pattern"] = li_StudentRegistrationForm_Exam_Pattern;

                //For FatherHusband
                List<SelectListItem> StudentRegistrationForm_FatherHusband = new List<SelectListItem>();
                ViewBag.StudentRegistrationForm_FatherHusband = new SelectList(StudentRegistrationForm_FatherHusband, "Value", "Text");
                List<SelectListItem> li_StudentRegistrationForm_FatherHusband = new List<SelectListItem>();
                li_StudentRegistrationForm_FatherHusband.Add(new SelectListItem { Text = "Father", Value = "F" });
                li_StudentRegistrationForm_FatherHusband.Add(new SelectListItem { Text = "Husband", Value = "H" });
                ViewData["StudentRegistrationForm_FatherHusband"] = li_StudentRegistrationForm_FatherHusband;

                //For Qualification_General_MediumOfInstitution

                List<OrganisationMediumMaster> organisationMediumMasterList = GetListOrganisationMediumMaster();
                List<SelectListItem> organisationMediumMaster = new List<SelectListItem>();
                foreach (OrganisationMediumMaster item in organisationMediumMasterList)
                {
                    organisationMediumMaster.Add(new SelectListItem { Text = item.Description, Value = item.ID.ToString() });
                }
                ViewBag.organisationMediumMaster = new SelectList(organisationMediumMaster, "Value", "Text");

                //For Month
                List<SelectListItem> Student_Qualification_General_MonthOfPassing = new List<SelectListItem>();
                ViewBag.Student_Qualification_General_MonthOfPassing = new SelectList(Student_Qualification_General_MonthOfPassing, "Value", "Text");
                List<SelectListItem> li_Student_Qualification_General_MonthOfPassing = new List<SelectListItem>();
                li_Student_Qualification_General_MonthOfPassing.Add(new SelectListItem { Text = "Select Month", Value = "0" });
                li_Student_Qualification_General_MonthOfPassing.Add(new SelectListItem { Text = "January", Value = "1" });
                li_Student_Qualification_General_MonthOfPassing.Add(new SelectListItem { Text = "February", Value = "2" });
                li_Student_Qualification_General_MonthOfPassing.Add(new SelectListItem { Text = "March", Value = "3" });
                li_Student_Qualification_General_MonthOfPassing.Add(new SelectListItem { Text = "April", Value = "4" });
                li_Student_Qualification_General_MonthOfPassing.Add(new SelectListItem { Text = "May", Value = "5" });
                li_Student_Qualification_General_MonthOfPassing.Add(new SelectListItem { Text = "June", Value = "6" });
                li_Student_Qualification_General_MonthOfPassing.Add(new SelectListItem { Text = "July", Value = "7" });
                li_Student_Qualification_General_MonthOfPassing.Add(new SelectListItem { Text = "August", Value = "8" });
                li_Student_Qualification_General_MonthOfPassing.Add(new SelectListItem { Text = "September", Value = "9" });
                li_Student_Qualification_General_MonthOfPassing.Add(new SelectListItem { Text = "October", Value = "10" });
                li_Student_Qualification_General_MonthOfPassing.Add(new SelectListItem { Text = "November", Value = "11" });
                li_Student_Qualification_General_MonthOfPassing.Add(new SelectListItem { Text = "December", Value = "12" });
                ViewData["Student_Qualification_General_MonthOfPassing"] = li_Student_Qualification_General_MonthOfPassing;


                //For Year
                int year = DateTime.Now.Year - 65;
                List<SelectListItem> Student_Qualification_General_YearOfPassing = new List<SelectListItem>();
                ViewBag.Student_Qualification_General_YearOfPassing = new SelectList(Student_Qualification_General_YearOfPassing, "Value", "Text");
                List<SelectListItem> li_Student_Qualification_General_YearOfPassing = new List<SelectListItem>();

                li_Student_Qualification_General_YearOfPassing.Add(new SelectListItem { Text = "Select Year", Value = "0" });
                for (int i = DateTime.Now.Year; year <= i; i--)
                {
                    li_Student_Qualification_General_YearOfPassing.Add(new SelectListItem { Text = Convert.ToString(i), Value = Convert.ToString(i) });
                }
                ViewData["Student_Qualification_General_YearOfPassing"] = li_Student_Qualification_General_YearOfPassing;

                //For For Count Number
                List<SelectListItem> StudentRegistrationForm_NumberList = new List<SelectListItem>();
                ViewBag.StudentRegistrationForm_Number = new SelectList(StudentRegistrationForm_NumberList, "Value", "Text");
                List<SelectListItem> li_StudentRegistrationForm_Number = new List<SelectListItem>();

                li_StudentRegistrationForm_Number.Add(new SelectListItem { Text = "-- Select --", Value = "" });
                for (int i = 1; i <= 10; i++)
                {
                    li_StudentRegistrationForm_Number.Add(new SelectListItem { Text = Convert.ToString(i), Value = Convert.ToString(i) });
                }
                ViewData["StudentRegistrationForm_Number"] = li_StudentRegistrationForm_Number;

                //For University

                List<OrganisationUniversityMaster> OrganisationUniversityMasterList = GetListOrganisationUniversityMasterWithoutCenterCode();
                List<SelectListItem> OrganisationUniversityMaster = new List<SelectListItem>();
                foreach (OrganisationUniversityMaster item in OrganisationUniversityMasterList)
                {
                    OrganisationUniversityMaster.Add(new SelectListItem { Text = item.UniversityName, Value = item.ID.ToString() });
                }
                OrganisationUniversityMaster.Add(new SelectListItem { Text = "Other", Value = "Other" });
                ViewBag.OrganisationUniversityMasterList = new SelectList(OrganisationUniversityMaster, "Value", "Text");


                //For Stream

                List<OrganisationStreamMaster> OrganisationStreamMasterMasterList = GetListOrganisationStreamMaster();
                List<SelectListItem> OrganisationStreamMasterMaster = new List<SelectListItem>();
                foreach (OrganisationStreamMaster item in OrganisationStreamMasterMasterList)
                {
                    OrganisationStreamMasterMaster.Add(new SelectListItem { Text = item.StreamDescription, Value = item.ID.ToString() });
                }
                //  OrganisationStreamMasterMaster.Add(new SelectListItem { Text = "Other", Value = "Other" });
                ViewBag.OrganisationStreamMasterMasterList = new SelectList(OrganisationStreamMasterMaster, "Value", "Text");

                //For Class
                List<SelectListItem> StudentRegistrationForm_Class = new List<SelectListItem>();
                ViewBag.StudentRegistrationForm_Class = new SelectList(StudentRegistrationForm_Class, "Value", "Text");
                List<SelectListItem> li_StudentRegistrationForm_Class = new List<SelectListItem>();
                li_StudentRegistrationForm_Class.Add(new SelectListItem { Text = "First", Value = "1" });
                li_StudentRegistrationForm_Class.Add(new SelectListItem { Text = "Second", Value = "2" });
                li_StudentRegistrationForm_Class.Add(new SelectListItem { Text = "Third", Value = "3" });
                li_StudentRegistrationForm_Class.Add(new SelectListItem { Text = "Fourth", Value = "4" });
                ViewData["StudentRegistrationForm_Class"] = li_StudentRegistrationForm_Class;

                #endregion Method

                model.StudentRegistrationFormList = GetListStudentRegistrationForm(model.StudentRegistrationFormDTO.CenterCode, model.StudentRegistrationFormDTO.UniversityID, model.StudentRegistrationFormDTO.BranchDetailID, model.StudentRegistrationFormDTO.StandardNumber);

                model.StudentRegistrationFormDTO.ToolRegistrationTemplateMstID = Convert.ToInt32(model.StudentRegistrationFormList[1].ToolRegistrationTemplateMstID);
                //For Baranch

                List<ToolTemplateApplicable> organisationBranchDetailList = GetListBranchDetails(model.StudentRegistrationFormDTO.UniversityID, model.StudentRegistrationFormDTO.CenterCode);
                List<SelectListItem> organisationBranchDetail = new List<SelectListItem>();
                foreach (ToolTemplateApplicable item in organisationBranchDetailList)
                {
                    organisationBranchDetail.Add(new SelectListItem { Text = item.BranchDescription + "(" + item.DivisionDescription + ")", Value = item.BranchDetailID.ToString() });
                }
                ViewBag.organisationBranchDetail = new SelectList(organisationBranchDetail, "Value", "Text");

                //// For Qualifying Exam
                //List<StudentRegistrationForm> studentRegistrationFormQualifyingExamList = GetListStudentRegistrationFormQualifyingExamList(model.StudentRegistrationFormDTO.BranchDetailID, model.StudentRegistrationFormDTO.StandardNumber);
                //List<SelectListItem> studentRegistrationFormQualifyingExam = new List<SelectListItem>();
                //foreach (StudentRegistrationForm item in studentRegistrationFormQualifyingExamList)
                //{
                //    studentRegistrationFormQualifyingExam.Add(new SelectListItem { Text = item.Student_QualifyingExamName, Value = item.Student_QualifyingExamId.ToString() });
                //}
                //ViewBag.studentRegistrationFormQualifyingExamList = new SelectList(studentRegistrationFormQualifyingExam, "Value", "Text");
                //  For Qualifying Exam Subject

                model.ToolQualifyingExamSubjectList = GetListToolQualifyingExamSubject(model.StudentRegistrationFormDTO.Student_QualifyingExamId);

                // For Qualification Exam Subject   for General
                model.ToolQualificationMasterSubjectListForGeneral = GetByQualificationMasterSubjectListByBranchDetailID_StandardNumber_EducationType(model.BranchDetailID, model.StandardNumber, "G");

                // For Qualification Exam Subject   for SSC
                model.ToolQualificationMasterSubjectListForSSC = GetByQualificationMasterSubjectListByBranchDetailID_StandardNumber_EducationType(model.BranchDetailID, model.StandardNumber, "S");

                // For Qualification Exam Subject   for HSC
                model.ToolQualificationMasterSubjectListForHSC = GetByQualificationMasterSubjectListByBranchDetailID_StandardNumber_EducationType(model.BranchDetailID, model.StandardNumber, "H");
                // for Academic year
                List<OrganisationCentrewiseSession> list = GetCurrentSession(model.StudentRegistrationFormDTO.CenterCode);
                model.Student_AcademicYear = list.Count > 0 ? list[0].SessionName : "Session not defined !";
                model.Student_AcademicYearId = list.Count > 0 ? list[0].SessionID : 0;

                //For Course year 
                model.OrganisationCourseYearDetailsDTO = GetCourseYearByBranchDetIDAndStandardNumber(model.BranchDetailID, model.StandardNumber);
                model.Student_CourseYearName = model.OrganisationCourseYearDetailsDTO.Description;
                model.Student_CourseYearId = model.OrganisationCourseYearDetailsDTO.ID;

                //For Branch Details
                model.OrganisationBranchDetailsDTO = GetOrganisationBranchDetailsSelectByID(model.BranchDetailID);
                model.Student_CourseName = model.OrganisationBranchDetailsDTO.BranchDescription;
                //    model.Student_CourseYearId = model.OrganisationCourseYearDetailsDTO.ID;
                model.Student_DateofRegistration = DateTime.Now.ToString("dd-MMM-yyyy");

                //For Fees Payment Details
                List<SelectListItem> FeesPaidBy = new List<SelectListItem>();
                ViewBag.FeesPaidBy = new SelectList(FeesPaidBy, "Value", "Text");
                List<SelectListItem> li_FeesPaidBy = new List<SelectListItem>();
                li_FeesPaidBy.Add(new SelectListItem { Text = "You", Value = "1" });
                li_FeesPaidBy.Add(new SelectListItem { Text = "Family", Value = "2" });
                li_FeesPaidBy.Add(new SelectListItem { Text = "Employer", Value = "3" });
                li_FeesPaidBy.Add(new SelectListItem { Text = "Research Council", Value = "4" });
                li_FeesPaidBy.Add(new SelectListItem { Text = "Other external Sponsor", Value = "5" }); 
                ViewData["FeesPaidBy"] = li_FeesPaidBy;

                //  return PartialView(model);
                return View("/Views/StudentRegistrationForm/IndexV2.cshtml", model);
            }
            else
            {
                return PartialView("/Views/StudentRegistrationForm/Message.cshtml", model);
            }
        }
        [HttpPost]
        public ActionResult Create(StudentRegistrationFormViewModel model)
        {

            //if (ModelState.IsValid)
            //{
            if (model != null && model.StudentRegistrationFormDTO != null)
            {

                model.StudentRegistrationFormDTO.ConnectionString = _connectioString;

                // For Hidden Field
                model.StudentRegistrationFormDTO.Student_QualifyingExamId = model.Student_QualifyingExamId;
                model.StudentRegistrationFormDTO.BranchDetailID = model.BranchDetailID;
                model.StudentRegistrationFormDTO.StandardNumber = model.StandardNumber;
                model.StudentRegistrationFormDTO.AdmissionPattern = model.AdmissionPattern;
                model.StudentRegistrationFormDTO.Student_AcademicYearId = model.Student_AcademicYearId;
                model.StudentRegistrationFormDTO.Student_AcademicYear = model.Student_AcademicYear;
                model.StudentRegistrationFormDTO.Student_CourseYearId = model.Student_CourseYearId;
                model.StudentRegistrationFormDTO.Student_DateofRegistration = model.Student_DateofRegistration;
                model.StudentRegistrationFormDTO.CenterCode = model.CenterCode;
                model.StudentRegistrationFormDTO.UniversityID = model.UniversityID;
                model.StudentRegistrationFormDTO.StudentSelfRegistrationID = model.StudentSelfRegistrationID;
                model.StudentRegistrationFormDTO.ToolRegistrationTemplateMstID = model.ToolRegistrationTemplateMstID;

                // upload Data
                //for Photo
                model.StudentRegistrationFormDTO.StudentPhoto = model.StudentPhoto;
                model.StudentRegistrationFormDTO.StudentPhotoFilename = model.StudentPhotoFilename;
                model.StudentRegistrationFormDTO.StudentPhotoType = model.StudentPhotoType;
                model.StudentRegistrationFormDTO.StudentPhotoFileSize = model.StudentPhotoFileSize;
                model.StudentRegistrationFormDTO.StudentPhotoFileWidth = model.StudentPhotoFileWidth;
                model.StudentRegistrationFormDTO.StudentPhotoFileHeight = model.StudentPhotoFileHeight;

                //for Signature
                model.StudentRegistrationFormDTO.StudentSignature = model.StudentSignature;
                model.StudentRegistrationFormDTO.StudentSignatureFilename = model.StudentSignatureFilename;
                model.StudentRegistrationFormDTO.StudentSignatureType = model.StudentSignatureType;
                model.StudentRegistrationFormDTO.StudentSignatureFileSize = model.StudentSignatureFileSize;
                model.StudentRegistrationFormDTO.StudentSignatureFileWidth = model.StudentSignatureFileWidth;
                model.StudentRegistrationFormDTO.StudentSignatureFileHeight = model.StudentSignatureFileHeight;

                //for Thumb
                model.StudentRegistrationFormDTO.StudentThumb = model.StudentThumb;
                model.StudentRegistrationFormDTO.StudentThumbFilename = model.StudentThumbFilename;
                model.StudentRegistrationFormDTO.StudentThumbType = model.StudentThumbType;
                model.StudentRegistrationFormDTO.StudentThumbFileSize = model.StudentThumbFileSize;
                model.StudentRegistrationFormDTO.StudentThumbFileWidth = model.StudentThumbFileWidth;
                model.StudentRegistrationFormDTO.StudentThumbFileHeight = model.StudentThumbFileHeight;

                // Student Personal Information 
                model.StudentRegistrationFormDTO.StudentTitle = model.StudentTitle;
                model.StudentRegistrationFormDTO.StudentFirstName = model.StudentFirstName;
                model.StudentRegistrationFormDTO.StudentMiddleName = model.StudentMiddleName;
                model.StudentRegistrationFormDTO.StudentLastName = model.StudentLastName;
                model.StudentRegistrationFormDTO.StudentEmailID = model.StudentEmailID;
                model.StudentRegistrationFormDTO.StudentGender = model.StudentGender;
                model.StudentRegistrationFormDTO.StudentMobileNumber = model.StudentMobileNumber;
                model.StudentRegistrationFormDTO.StudentLandLineNumber = model.StudentLandLineNumber;
                model.StudentRegistrationFormDTO.StudentEmploymentSector = model.StudentEmploymentSector;
                model.StudentRegistrationFormDTO.StudentOccupation = model.StudentOccupation;
                model.StudentRegistrationFormDTO.StudentDesignation = model.StudentDesignation;
                model.StudentRegistrationFormDTO.StudentOrganizationName = model.StudentOrganizationName;
                model.StudentRegistrationFormDTO.StudentOfficeContactNo = model.StudentOfficeContactNo;
                model.StudentRegistrationFormDTO.StudentAnnualIncome = model.StudentAnnualIncome;

                //Father/Husband Personal Information 
                model.StudentRegistrationFormDTO.FatherTitle = model.FatherTitle;
                model.StudentRegistrationFormDTO.FatherHusbondType = model.FatherHusbondType;
                model.StudentRegistrationFormDTO.FatherFirstName = model.FatherFirstName;
                model.StudentRegistrationFormDTO.FatherMiddleName = model.FatherMiddleName;
                model.StudentRegistrationFormDTO.FatherLastName = model.FatherLastName;
                model.StudentRegistrationFormDTO.FatherEmailId = model.FatherEmailId;
                model.StudentRegistrationFormDTO.FatherMobileNumber = model.FatherMobileNumber;
                model.StudentRegistrationFormDTO.FatherLandLineNumber = model.FatherLandLineNumber;
                model.StudentRegistrationFormDTO.FatherEmploymentSector = model.FatherEmploymentSector;
                model.StudentRegistrationFormDTO.FatherOccupation = model.FatherOccupation;
                model.StudentRegistrationFormDTO.FatherDesignation = model.FatherDesignation;
                model.StudentRegistrationFormDTO.FatherOrganizationName = model.FatherOrganizationName;
                model.StudentRegistrationFormDTO.FatherOfficeContactNo = model.FatherOfficeContactNo;
                model.StudentRegistrationFormDTO.FatherAnnualIncome = model.FatherAnnualIncome;

                //Mother Personal Information
                model.StudentRegistrationFormDTO.MotherTitle = model.MotherTitle;
                model.StudentRegistrationFormDTO.MotherFirstName = model.MotherFirstName;
                model.StudentRegistrationFormDTO.MotherMiddleName = model.MotherMiddleName;
                model.StudentRegistrationFormDTO.MotherLastName = model.MotherLastName;
                model.StudentRegistrationFormDTO.MotherEmailId = model.MotherEmailId;
                model.StudentRegistrationFormDTO.MotherMobileNumber = model.MotherMobileNumber;
                model.StudentRegistrationFormDTO.MotherLandLineNumber = model.MotherLandLineNumber;
                model.StudentRegistrationFormDTO.MotherEmploymentSector = model.MotherEmploymentSector;
                model.StudentRegistrationFormDTO.MotherOccupation = model.MotherOccupation;
                model.StudentRegistrationFormDTO.MotherDesignation = model.MotherDesignation;
                model.StudentRegistrationFormDTO.MotherOrganizationName = model.MotherOrganizationName;
                model.StudentRegistrationFormDTO.MotherOfficeContactNo = model.MotherOfficeContactNo;
                model.StudentRegistrationFormDTO.MotherAnnualIncome = model.MotherAnnualIncome;

                //Guardian Personal Information 
                model.StudentRegistrationFormDTO.GuardianTitle = model.GuardianTitle;
                model.StudentRegistrationFormDTO.GuardianFirstName = model.GuardianFirstName;
                model.StudentRegistrationFormDTO.GuardianMiddleName = model.GuardianMiddleName;
                model.StudentRegistrationFormDTO.GuardianLastName = model.GuardianLastName;
                model.StudentRegistrationFormDTO.GuardianEmailId = model.GuardianEmailId;
                model.StudentRegistrationFormDTO.GuardianMobileNumber = model.GuardianMobileNumber;
                model.StudentRegistrationFormDTO.GuardianLandLineNumber = model.GuardianLandLineNumber;
                model.StudentRegistrationFormDTO.GuardianEmploymentSector = model.GuardianEmploymentSector;
                model.StudentRegistrationFormDTO.GuardianOccupation = model.GuardianOccupation;
                model.StudentRegistrationFormDTO.GuardianDesignation = model.GuardianDesignation;
                model.StudentRegistrationFormDTO.GuardianOrganizationName = model.GuardianOrganizationName;
                model.StudentRegistrationFormDTO.GuardianOfficeContactNo = model.GuardianOfficeContactNo;
                model.StudentRegistrationFormDTO.GuardianAnnualIncome = model.GuardianAnnualIncome;

                //Student Specific Information 
                model.StudentRegistrationFormDTO.StudentEnrollmentNo = model.StudentEnrollmentNo;
                model.StudentRegistrationFormDTO.StudentNRI_POI = model.StudentNRI_POI;
                model.StudentRegistrationFormDTO.StudentMigrationNumber = model.StudentMigrationNumber;
                model.StudentRegistrationFormDTO.StudentNationalityID = model.StudentNationalityID;
                model.StudentRegistrationFormDTO.StudentMigrationDate = model.StudentMigrationDate;
                model.StudentRegistrationFormDTO.StudentRegionID = model.StudentRegionID;
                //  model.StudentRegistrationFormDTO.StudentRegionOther = model.StudentRegionOther;
                model.StudentRegistrationFormDTO.StudentMaritalStatus = model.StudentMaritalStatus;
                model.StudentRegistrationFormDTO.StudentDomicileStateofFather = model.StudentDomicileStateofFather;
                model.StudentRegistrationFormDTO.StudentBloodGroup = model.StudentBloodGroup;
                model.StudentRegistrationFormDTO.StudentDomicileStateofMother = model.StudentDomicileStateofMother;
                model.StudentRegistrationFormDTO.PhysicallyHandicapped = model.PhysicallyHandicapped;
                model.StudentRegistrationFormDTO.StudentEmploymentStatus = model.StudentEmploymentStatus;
                model.StudentRegistrationFormDTO.StudentIdentificationMark = model.StudentIdentificationMark;
                model.StudentRegistrationFormDTO.StudentPrevNameofStudent = model.StudentPrevNameofStudent;
                model.StudentRegistrationFormDTO.StudentOrgandonor = model.StudentOrgandonor;
                model.StudentRegistrationFormDTO.StudentReasonforNamechange = model.StudentReasonforNamechange;
                if (model.StudentRegionID == 0)
                {
                    model.StudentRegistrationFormDTO.Student_Domesile_CountryId = model.Student_Domesile_CountryId;
                    model.StudentRegistrationFormDTO.StudentRegionOther = model.StudentRegionOther;
                }
                else
                {
                    model.StudentRegistrationFormDTO.Student_Domesile_CountryId = 0;
                    model.StudentRegistrationFormDTO.StudentRegionOther = null;
                }

                //Information As Per Leaving Certificate 
                model.StudentRegistrationFormDTO.StudentDateofBirth = model.StudentDateofBirth;
                model.StudentRegistrationFormDTO.StudentBirthPlace = model.StudentBirthPlace;
                model.StudentRegistrationFormDTO.StudentReligionID = model.StudentReligionID;
                model.StudentRegistrationFormDTO.StudentCategoryID = model.StudentCategoryID;
                model.StudentRegistrationFormDTO.StudentCasteID = model.StudentCasteID;
                model.StudentRegistrationFormDTO.StudentCasteAsPerTC_LC = model.StudentCasteAsPerTC_LC;
                model.StudentRegistrationFormDTO.StudentMotherTongueID = model.StudentMotherTongueID;
                model.StudentRegistrationFormDTO.StudentNameAsPerMarkSheet = model.StudentNameAsPerMarkSheet;
                model.StudentRegistrationFormDTO.StudentLastSchool_College = model.StudentLastSchool_College;
                model.StudentRegistrationFormDTO.StudentPreviousLC_TCNo = model.StudentPreviousLC_TCNo;

                //Social Reservation Information 

                model.StudentRegistrationFormDTO.Student_Ex_Serviceman_Ward_of_Ex_Serviceman = model.Student_Ex_Serviceman_Ward_of_Ex_Serviceman;
                model.StudentRegistrationFormDTO.Student_Active_Serviceman_Ward_of_Active_Serviceman = model.Student_Active_Serviceman_Ward_of_Active_Serviceman;
                model.StudentRegistrationFormDTO.Student_FreedomFighterWardOfFreedomFighter = model.Student_FreedomFighterWardOfFreedomFighter;
                model.StudentRegistrationFormDTO.Student_WardofPrimaryTeacher = model.Student_WardofPrimaryTeacher;
                model.StudentRegistrationFormDTO.Student_WardofSecondaryTeacher = model.Student_WardofSecondaryTeacher;
                model.StudentRegistrationFormDTO.Student_Deserted_Divorced_Widowed_Women = model.Student_Deserted_Divorced_Widowed_Women;
                model.StudentRegistrationFormDTO.Student_MemberofProjectAffectedFamily = model.Student_MemberofProjectAffectedFamily;
                model.StudentRegistrationFormDTO.Student_MemberofEarthquakeAffectedFamily = model.Student_MemberofEarthquakeAffectedFamily;
                model.StudentRegistrationFormDTO.Student_MemberofFloodFamineAffectedFamily = model.Student_MemberofFloodFamineAffectedFamily;
                model.StudentRegistrationFormDTO.Student_ResidentofTribalArea = model.Student_ResidentofTribalArea;
                model.StudentRegistrationFormDTO.Student_KashmirMigrant = model.Student_KashmirMigrant;

                //Other Information Of The Student 
                model.StudentRegistrationFormDTO.StudentIndicatetypeofCandidature = model.StudentIndicatetypeofCandidature;
                model.StudentRegistrationFormDTO.StudentSchoolFromHSCExaminationpassed = model.StudentSchoolFromHSCExaminationpassed;
                model.StudentRegistrationFormDTO.StudentEconomicallyBackwardClass = model.StudentEconomicallyBackwardClass;
                model.StudentRegistrationFormDTO.StudentsNameOfDistrictWhereParentDomiciled = model.StudentsNameOfDistrictWhereParentDomiciled;
                model.StudentRegistrationFormDTO.StudentsMKBCandidate = model.StudentsMKBCandidate;

                //Address Information 
                //Permanent Address
                model.StudentRegistrationFormDTO.Student_PermanentAddress_PloteNo = model.Student_PermanentAddress_PloteNo;
                model.StudentRegistrationFormDTO.Student_PermanentAddress_StreeNo = model.Student_PermanentAddress_StreeNo;
                model.StudentRegistrationFormDTO.Student_PermanentAddress_Address1 = model.Student_PermanentAddress_Address1;
                model.StudentRegistrationFormDTO.Student_PermanentAddress_Address2 = model.Student_PermanentAddress_Address2;
                model.StudentRegistrationFormDTO.Student_PermanentAddress_City_TahsilID = model.Student_PermanentAddress_City_TahsilID;
                model.StudentRegistrationFormDTO.Student_PermanentAddress_City_TahsilOther = model.Student_PermanentAddress_City_TahsilOther;
                model.StudentRegistrationFormDTO.Student_PermanentAddress_CountryId = model.Student_PermanentAddress_CountryId;
                model.StudentRegistrationFormDTO.Student_PermanentAddress_State = model.Student_PermanentAddress_State;
                model.StudentRegistrationFormDTO.Student_PermanentAddress_StateOther = model.Student_PermanentAddress_StateOther;
                model.StudentRegistrationFormDTO.Student_PermanentAddress_DistrictID = model.Student_PermanentAddress_DistrictID;
                model.StudentRegistrationFormDTO.Student_PermanentAddress_DistrictOther = model.Student_PermanentAddress_DistrictOther;
                model.StudentRegistrationFormDTO.Student_PermanentAddress_Tahsil = model.Student_PermanentAddress_Tahsil;
                model.StudentRegistrationFormDTO.Student_PermanentAddress_NearPoliceStation = model.Student_PermanentAddress_NearPoliceStation;
                model.StudentRegistrationFormDTO.Student_PermanentAddress_ZipCode = model.Student_PermanentAddress_ZipCode;
                model.StudentRegistrationFormDTO.Student_PermanentAddress_City_Tahsil_Pattern = model.Student_PermanentAddress_City_Tahsil_Pattern;

                //Correspondence Address

                model.StudentRegistrationFormDTO.SameAsPerPermanentAddress = model.SameAsPerPermanentAddress;
                model.StudentRegistrationFormDTO.Student_CorrespondenceAddress_PloteNo = model.Student_CorrespondenceAddress_PloteNo;
                model.StudentRegistrationFormDTO.Student_CorrespondenceAddress_StreeNo = model.Student_CorrespondenceAddress_StreeNo;
                model.StudentRegistrationFormDTO.Student_CorrespondenceAddress_Address1 = model.Student_CorrespondenceAddress_Address1;
                model.StudentRegistrationFormDTO.Student_CorrespondenceAddress_Address2 = model.Student_CorrespondenceAddress_Address2;
                model.StudentRegistrationFormDTO.Student_CorrespondenceAddress_City_TahsilID = model.Student_CorrespondenceAddress_City_TahsilID;
                model.StudentRegistrationFormDTO.Student_CorrespondenceAddress_City_TahsilOther = model.Student_CorrespondenceAddress_City_TahsilOther;
                model.StudentRegistrationFormDTO.Student_CorrespondenceAddress_CountryId = model.Student_CorrespondenceAddress_CountryId;
                model.StudentRegistrationFormDTO.Student_CorrespondenceAddress_State = model.Student_CorrespondenceAddress_State;
                model.StudentRegistrationFormDTO.Student_CorrespondenceAddress_StateOther = model.Student_CorrespondenceAddress_StateOther;
                model.StudentRegistrationFormDTO.Student_CorrespondenceAddress_DistrictID = model.Student_CorrespondenceAddress_DistrictID;
                model.StudentRegistrationFormDTO.Student_CorrespondenceAddress_DistrictOther = model.Student_CorrespondenceAddress_DistrictOther;
                model.StudentRegistrationFormDTO.Student_CorrespondenceAddress_Tahsil = model.Student_CorrespondenceAddress_Tahsil;
                model.StudentRegistrationFormDTO.Student_CorrespondenceAddress_NearPoliceStation = model.Student_CorrespondenceAddress_NearPoliceStation;
                model.StudentRegistrationFormDTO.Student_CorrespondenceAddress_ZipCode = model.Student_CorrespondenceAddress_ZipCode;
                model.StudentRegistrationFormDTO.Student_CorrespondenceAddress_City_Tahsil_Pattern = model.Student_CorrespondenceAddress_City_Tahsil_Pattern;

                //Qualifying Exam Details 
                model.StudentRegistrationFormDTO.Student_QualifyingExamName = model.Student_QualifyingExamName;
                model.StudentRegistrationFormDTO.Student_QualifyingRollNo = model.Student_QualifyingRollNo;
                model.StudentRegistrationFormDTO.Student_QualifyingExamTotalMarksPointsObtained = model.Student_QualifyingExamTotalMarksPointsObtained;
                model.StudentRegistrationFormDTO.Student_QualifyingExamOutOffMark = model.Student_QualifyingExamOutOffMark;
                model.StudentRegistrationFormDTO.Student_QualifyingExamRank = model.Student_QualifyingExamRank;

                //Qualification Details 
                //    General Details 
                model.StudentRegistrationFormDTO.Student_Qualification_General_MediumOfInstitution = model.Student_Qualification_General_MediumOfInstitution;
                model.StudentRegistrationFormDTO.Student_Qualification_General_MonthOfPassing = model.Student_Qualification_General_MonthOfPassing;
                model.StudentRegistrationFormDTO.Student_Qualification_General_YearOfPassing = model.Student_Qualification_General_YearOfPassing;
                model.StudentRegistrationFormDTO.Student_Qualification_General_SingleAttempt = model.Student_Qualification_General_SingleAttempt;
                model.StudentRegistrationFormDTO.Student_Qualification_General_ObtainedMark = model.Student_Qualification_General_ObtainedMark;
                model.StudentRegistrationFormDTO.Student_Qualification_General_OutOfMark = model.Student_Qualification_General_OutOfMark;
                model.StudentRegistrationFormDTO.Student_Qualification_General_Percent = model.Student_Qualification_General_Percent;

                //    SSC Details 
                model.StudentRegistrationFormDTO.Student_Qualification_SSC_MediumOfInstitution = model.Student_Qualification_SSC_MediumOfInstitution;
                model.StudentRegistrationFormDTO.Student_Qualification_SSC_MonthOfPassing = model.Student_Qualification_SSC_MonthOfPassing;
                model.StudentRegistrationFormDTO.Student_Qualification_SSC_YearOfPassing = model.Student_Qualification_SSC_YearOfPassing;
                model.StudentRegistrationFormDTO.Student_Qualification_SSC_SingleAttempt = model.Student_Qualification_SSC_SingleAttempt;
                model.StudentRegistrationFormDTO.Student_Qualification_SSC_ObtainedMark = model.Student_Qualification_SSC_ObtainedMark;
                model.StudentRegistrationFormDTO.Student_Qualification_SSC_OutOfMark = model.Student_Qualification_SSC_OutOfMark;
                model.StudentRegistrationFormDTO.Student_Qualification_SSC_Percent = model.Student_Qualification_SSC_Percent;
                model.StudentRegistrationFormDTO.Student_Qualification_SSC_NameofInstitution = model.Student_Qualification_SSC_NameofInstitution;
                model.StudentRegistrationFormDTO.Student_Qualification_SSC_Region_Division_Board = model.Student_Qualification_SSC_Region_Division_Board;

                //    HSC Details 
                model.StudentRegistrationFormDTO.Student_Qualification_HSC_MediumOfInstitution = model.Student_Qualification_HSC_MediumOfInstitution;
                model.StudentRegistrationFormDTO.Student_Qualification_HSC_MonthOfPassing = model.Student_Qualification_HSC_MonthOfPassing;
                model.StudentRegistrationFormDTO.Student_Qualification_HSC_YearOfPassing = model.Student_Qualification_HSC_YearOfPassing;
                model.StudentRegistrationFormDTO.Student_Qualification_HSC_StreamID = model.Student_Qualification_HSC_StreamID;
                model.StudentRegistrationFormDTO.Student_Qualification_HSC_StreamOther = model.Student_Qualification_HSC_StreamOther;
                model.StudentRegistrationFormDTO.Student_Qualification_HSC_SingleAttempt = model.Student_Qualification_HSC_SingleAttempt;
                model.StudentRegistrationFormDTO.Student_Qualification_HSC_Class = model.Student_Qualification_HSC_Class;
                model.StudentRegistrationFormDTO.Student_Qualification_HSC_ObtainedMark = model.Student_Qualification_HSC_ObtainedMark;
                model.StudentRegistrationFormDTO.Student_Qualification_HSC_OutOfMark = model.Student_Qualification_HSC_OutOfMark;
                model.StudentRegistrationFormDTO.Student_Qualification_HSC_Percent = model.Student_Qualification_HSC_Percent;
                model.StudentRegistrationFormDTO.Student_Qualification_HSC_PCM_PVM_ObtainedMark = model.Student_Qualification_HSC_PCM_PVM_ObtainedMark;
                model.StudentRegistrationFormDTO.Student_Qualification_HSC_PCM_PVM_OutOfMark = model.Student_Qualification_HSC_PCM_PVM_OutOfMark;
                model.StudentRegistrationFormDTO.Student_Qualification_HSC_PCB_ObtainedMark = model.Student_Qualification_HSC_PCB_ObtainedMark;
                model.StudentRegistrationFormDTO.Student_Qualification_HSC_PCB_OutOfMark = model.Student_Qualification_HSC_PCB_OutOfMark;
                model.StudentRegistrationFormDTO.Student_Qualification_HSC_NameofInstitution = model.Student_Qualification_HSC_NameofInstitution;
                model.StudentRegistrationFormDTO.Student_Qualification_HSC_Region_Division_Board = model.Student_Qualification_HSC_Region_Division_Board;

                //Diploma / ITI Details 
                model.StudentRegistrationFormDTO.Student_Qualification_Diploma_ITI_Details_MediumOfInstitution = model.Student_Qualification_Diploma_ITI_Details_MediumOfInstitution;
                model.StudentRegistrationFormDTO.Student_Qualification_Diploma_ITI_Details_BranchName = model.Student_Qualification_Diploma_ITI_Details_BranchName;
                model.StudentRegistrationFormDTO.Student_Qualification_Diploma_ITI_Details_ExamPattern = model.Student_Qualification_Diploma_ITI_Details_ExamPattern;
                model.StudentRegistrationFormDTO.Student_Qualification_Diploma_ITI_Details_MonthOfPassing = model.Student_Qualification_Diploma_ITI_Details_MonthOfPassing;
                model.StudentRegistrationFormDTO.Student_Qualification_Diploma_ITI_Details_YearOfPassing = model.Student_Qualification_Diploma_ITI_Details_YearOfPassing;
                model.StudentRegistrationFormDTO.Student_Qualification_Diploma_ITI_Details_Class = model.Student_Qualification_Diploma_ITI_Details_Class;
                model.StudentRegistrationFormDTO.Student_Qualification_Diploma_ITI_Details_ObtainedMark = model.Student_Qualification_Diploma_ITI_Details_ObtainedMark;
                model.StudentRegistrationFormDTO.Student_Qualification_Diploma_ITI_Details_OutOfMark = model.Student_Qualification_Diploma_ITI_Details_OutOfMark;
                model.StudentRegistrationFormDTO.Student_Qualification_Diploma_ITI_Details_Percent = model.Student_Qualification_Diploma_ITI_Details_Percent;
                model.StudentRegistrationFormDTO.Student_Qualification_Diploma_ITI_Details_SingleAttempt = model.Student_Qualification_Diploma_ITI_Details_SingleAttempt;
                model.StudentRegistrationFormDTO.Student_Qualification_Diploma_ITI_Details_BoardEnrollmentNumber = model.Student_Qualification_Diploma_ITI_Details_BoardEnrollmentNumber;
                model.StudentRegistrationFormDTO.Student_Qualification_Diploma_ITI_Details_NameofInstitution = model.Student_Qualification_Diploma_ITI_Details_NameofInstitution;
                model.StudentRegistrationFormDTO.Student_Qualification_Diploma_ITI_Details_Board = model.Student_Qualification_Diploma_ITI_Details_Board;
                model.StudentRegistrationFormDTO.Student_Qualification_Diploma_ITI_Details_State = model.Student_Qualification_Diploma_ITI_Details_State;

                if (model.Student_Qualification_Diploma_ITI_Details_State == 0)
                {
                    model.StudentRegistrationFormDTO.Student_Qualification_Diploma_ITI_Details_CountryId = model.Student_Qualification_Diploma_ITI_Details_CountryId;
                    model.StudentRegistrationFormDTO.Student_Qualification_Diploma_ITI_Details_StateOther = model.Student_Qualification_Diploma_ITI_Details_StateOther;
                }
                else
                {
                    model.StudentRegistrationFormDTO.Student_Qualification_Diploma_ITI_Details_CountryId = 0;
                    model.StudentRegistrationFormDTO.Student_Qualification_Diploma_ITI_Details_StateOther = null;
                }


                //    Degree Details 
                model.StudentRegistrationFormDTO.Student_Qualification_DegreeDetails_MediumOfInstitution = model.Student_Qualification_DegreeDetails_MediumOfInstitution;
                model.StudentRegistrationFormDTO.Student_Qualification_DegreeDetails_Degree = model.Student_Qualification_DegreeDetails_Degree;
                model.StudentRegistrationFormDTO.Student_Qualification_DegreeDetails_BranchName = model.Student_Qualification_DegreeDetails_BranchName;
                model.StudentRegistrationFormDTO.Student_Qualification_DegreeDetails_ExamPattern = model.Student_Qualification_DegreeDetails_ExamPattern;
                model.StudentRegistrationFormDTO.Student_Qualification_DegreeDetails_MonthOfPassing = model.Student_Qualification_DegreeDetails_MonthOfPassing;
                model.StudentRegistrationFormDTO.Student_Qualification_DegreeDetails_YearOfPassing = model.Student_Qualification_DegreeDetails_YearOfPassing;
                model.StudentRegistrationFormDTO.Student_Qualification_DegreeDetails_ObtainedMark = model.Student_Qualification_DegreeDetails_ObtainedMark;
                model.StudentRegistrationFormDTO.Student_Qualification_DegreeDetails_OutOfMark = model.Student_Qualification_DegreeDetails_OutOfMark;
                model.StudentRegistrationFormDTO.Student_Qualification_DegreeDetails_Percent = model.Student_Qualification_DegreeDetails_Percent;
                model.StudentRegistrationFormDTO.Student_Qualification_DegreeDetails_Class = model.Student_Qualification_DegreeDetails_Class;
                model.StudentRegistrationFormDTO.Student_Qualification_DegreeDetails_SingleAttempt = model.Student_Qualification_DegreeDetails_SingleAttempt;
                model.StudentRegistrationFormDTO.Student_Qualification_DegreeDetails_BoardEnrollmentNumber = model.Student_Qualification_DegreeDetails_BoardEnrollmentNumber;
                model.StudentRegistrationFormDTO.Student_Qualification_DegreeDetails_NameofInstitution = model.Student_Qualification_DegreeDetails_NameofInstitution;
                //model.StudentRegistrationFormDTO.Student_Qualification_DegreeDetails_UniversityId = model.Student_Qualification_DegreeDetails_UniversityId;
                model.StudentRegistrationFormDTO.Student_Qualification_DegreeDetails_UniversityName = model.Student_Qualification_DegreeDetails_UniversityName;
                model.StudentRegistrationFormDTO.Student_Qualification_DegreeDetails_State = model.Student_Qualification_DegreeDetails_State;
                if (model.Student_Qualification_DegreeDetails_State == 0)
                {
                    model.StudentRegistrationFormDTO.Student_Qualification_DegreeDetails_CountryId = model.Student_Qualification_DegreeDetails_CountryId;
                    model.StudentRegistrationFormDTO.Student_Qualification_DegreeDetails_StateOther = model.Student_Qualification_DegreeDetails_StateOther;
                }
                else
                {
                    model.StudentRegistrationFormDTO.Student_Qualification_DegreeDetails_CountryId = 0;
                    model.StudentRegistrationFormDTO.Student_Qualification_DegreeDetails_StateOther = null;
                }

                //Post Graduation Details 
                model.StudentRegistrationFormDTO.Student_Qualification_PostGraduationDetails_MediumOfInstitution = model.Student_Qualification_PostGraduationDetails_MediumOfInstitution;
                model.StudentRegistrationFormDTO.Student_Qualification_PostGraduationDetails_PostGraduation = model.Student_Qualification_PostGraduationDetails_PostGraduation;
                model.StudentRegistrationFormDTO.Student_Qualification_PostGraduationDetails_BranchName = model.Student_Qualification_PostGraduationDetails_BranchName;
                model.StudentRegistrationFormDTO.Student_Qualification_PostGraduationDetails_ExamPattern = model.Student_Qualification_PostGraduationDetails_ExamPattern;
                model.StudentRegistrationFormDTO.Student_Qualification_PostGraduationDetails_MonthOfPassing = model.Student_Qualification_PostGraduationDetails_MonthOfPassing;
                model.StudentRegistrationFormDTO.Student_Qualification_PostGraduationDetails_YearOfPassing = model.Student_Qualification_PostGraduationDetails_YearOfPassing;
                model.StudentRegistrationFormDTO.Student_Qualification_PostGraduationDetails_ObtainedMark = model.Student_Qualification_PostGraduationDetails_ObtainedMark;
                model.StudentRegistrationFormDTO.Student_Qualification_PostGraduationDetails_OutOfMark = model.Student_Qualification_PostGraduationDetails_OutOfMark;
                model.StudentRegistrationFormDTO.Student_Qualification_PostGraduationDetails_Percent = model.Student_Qualification_PostGraduationDetails_Percent;
                model.StudentRegistrationFormDTO.Student_Qualification_PostGraduationDetails_Class = model.Student_Qualification_PostGraduationDetails_Class;
                model.StudentRegistrationFormDTO.Student_Qualification_PostGraduationDetails_SingleAttempt = model.Student_Qualification_PostGraduationDetails_SingleAttempt;
                model.StudentRegistrationFormDTO.Student_Qualification_PostGraduationDetails_BoardEnrollmentNumber = model.Student_Qualification_PostGraduationDetails_BoardEnrollmentNumber;
                model.StudentRegistrationFormDTO.Student_Qualification_PostGraduationDetails_NameofInstitution = model.Student_Qualification_PostGraduationDetails_NameofInstitution;
                model.StudentRegistrationFormDTO.Student_Qualification_PostGraduationDetails_UniversityName = model.Student_Qualification_PostGraduationDetails_UniversityName;
                model.StudentRegistrationFormDTO.Student_Qualification_PostGraduationDetails_State = model.Student_Qualification_PostGraduationDetails_State;
                if (model.Student_Qualification_PostGraduationDetails_State == 0)
                {
                    model.StudentRegistrationFormDTO.Student_Qualification_PostGraduationDetails_CountryId = model.Student_Qualification_PostGraduationDetails_CountryId;
                    model.StudentRegistrationFormDTO.Student_Qualification_PostGraduationDetails_StateOther = model.Student_Qualification_PostGraduationDetails_StateOther;
                }
                else
                {
                    model.StudentRegistrationFormDTO.Student_Qualification_PostGraduationDetails_CountryId = 0;
                    model.StudentRegistrationFormDTO.Student_Qualification_PostGraduationDetails_StateOther = null;
                }

                //  DTE And Scholarship Information
                //  DTE Information
                model.StudentRegistrationFormDTO.Student_DTE_DTEUserID = model.Student_DTE_DTEUserID;
                model.StudentRegistrationFormDTO.Student_DTE_DTEPassword = model.Student_DTE_DTEPassword;
                model.StudentRegistrationFormDTO.Student_DTE_DTESrNo = model.Student_DTE_DTESrNo;
                model.StudentRegistrationFormDTO.Student_DTE_DTEMeritNo = model.Student_DTE_DTEMeritNo;
                model.StudentRegistrationFormDTO.Student_DTE_AdmissionTypeId = model.Student_DTE_AdmissionTypeId;
                model.StudentRegistrationFormDTO.Student_DTE_AdmissionRound = model.Student_DTE_AdmissionRound;
                model.StudentRegistrationFormDTO.Student_DTE_AdmissionCategoryId = model.Student_DTE_AdmissionCategoryId;
                model.StudentRegistrationFormDTO.Student_DTE_DTESeatNo = model.Student_DTE_DTESeatNo;
                model.StudentRegistrationFormDTO.Student_QualifyingExamId = model.Student_QualifyingExamId;
                model.StudentRegistrationFormDTO.Student_DTE_QualifyingExamName = model.Student_DTE_QualifyingExamName;
                model.StudentRegistrationFormDTO.Student_DTE_QualifyingExamMarks = model.Student_DTE_QualifyingExamMarks;

                //Scholarship Information
                model.StudentRegistrationFormDTO.Student_Scholarship_ScholarshipId = model.Student_Scholarship_ScholarshipId;
                model.StudentRegistrationFormDTO.Student_Scholarship_ScholarshipType = model.Student_Scholarship_ScholarshipType;
                model.StudentRegistrationFormDTO.Student_Scholarship_CastCategoryId = model.Student_Scholarship_CastCategoryId;
                model.StudentRegistrationFormDTO.Student_Scholarship_AadhaarCardNo = model.Student_Scholarship_AadhaarCardNo;
                model.StudentRegistrationFormDTO.Student_Scholarship_AnnualIncome = model.Student_Scholarship_AnnualIncome;
                model.StudentRegistrationFormDTO.Student_Scholarship_NoofSibling = model.Student_Scholarship_NoofSibling;
                model.StudentRegistrationFormDTO.Student_Scholarship_ChildNoOutofSibling = model.Student_Scholarship_ChildNoOutofSibling;
                model.StudentRegistrationFormDTO.Student_Scholarship_HostelDayScholar = model.Student_Scholarship_HostelDayScholar;
                model.StudentRegistrationFormDTO.Student_Scholarship_Bank_BranchName = model.Student_Scholarship_Bank_BranchName;
                model.StudentRegistrationFormDTO.Student_Scholarship_Bank_AC_No = model.Student_Scholarship_Bank_AC_No;
                model.StudentRegistrationFormDTO.Student_Scholarship_Bank_IFSCCode = model.Student_Scholarship_Bank_IFSCCode;
                model.StudentRegistrationFormDTO.Student_Scholarship_Bank_MICRCode = model.Student_Scholarship_Bank_MICRCode;

                //For Document
                model.Student_AdmissionDocuments_JETMarkSheet = model.Student_AdmissionDocuments_JETMarkSheet;
                model.Student_AdmissionDocuments_AllotmentLetter = model.Student_AdmissionDocuments_AllotmentLetter;
                model.Student_AdmissionDocuments_TenthMarkSheet = model.Student_AdmissionDocuments_TenthMarkSheet;
                model.Student_AdmissionDocuments_TwelvethMarkSheet = model.Student_AdmissionDocuments_TwelvethMarkSheet;
                model.Student_AdmissionDocuments_AllDiplomaMarksheet = model.Student_AdmissionDocuments_AllDiplomaMarksheet;
                model.Student_AdmissionDocuments_LeavingCertificate = model.Student_AdmissionDocuments_LeavingCertificate;
                model.Student_AdmissionDocuments_Domicile_BirthCertificate = model.Student_AdmissionDocuments_Domicile_BirthCertificate;
                model.Student_AdmissionDocuments_NationalityCertificate = model.Student_AdmissionDocuments_NationalityCertificate;
                model.Student_AdmissionDocuments_CasteCertificate = model.Student_AdmissionDocuments_CasteCertificate;
                model.Student_AdmissionDocuments_CasteValidityCertificate = model.Student_AdmissionDocuments_CasteValidityCertificate;
                model.Student_AdmissionDocuments_NonCreamylayerCertificate = model.Student_AdmissionDocuments_NonCreamylayerCertificate;
                model.Student_AdmissionDocuments_EquivalenceCertificate = model.Student_AdmissionDocuments_EquivalenceCertificate;
                model.Student_AdmissionDocuments_MigrationCertificate = model.Student_AdmissionDocuments_MigrationCertificate;
                model.Student_AdmissionDocuments_GapCertificate = model.Student_AdmissionDocuments_GapCertificate;
                model.Student_AdmissionDocuments_AntiRaggingAffidavit = model.Student_AdmissionDocuments_AntiRaggingAffidavit;
                model.Student_AdmissionDocuments_Proforma_Fand_F1_On_DoctorsLetter_Head = model.Student_AdmissionDocuments_Proforma_Fand_F1_On_DoctorsLetter_Head;
                model.Student_AdmissionDocuments_Proforma_I = model.Student_AdmissionDocuments_Proforma_I;
                model.Student_AdmissionDocuments_ProformaG1 = model.Student_AdmissionDocuments_ProformaG1;
                model.Student_AdmissionDocuments_ProformaG2 = model.Student_AdmissionDocuments_ProformaG2;
                model.Student_AdmissionDocuments_Proforma_C_D_E = model.Student_AdmissionDocuments_Proforma_C_D_E;
                model.Student_AdmissionDocuments_FathersIncomeCertificate = model.Student_AdmissionDocuments_FathersIncomeCertificate;
                model.Student_AdmissionDocuments_AadharCardXerox = model.Student_AdmissionDocuments_AadharCardXerox;
                model.Student_AdmissionDocuments_B_WPhoto_I_card_size = model.Student_AdmissionDocuments_B_WPhoto_I_card_size;
                model.Student_AdmissionDocuments_Colour_photo = model.Student_AdmissionDocuments_Colour_photo;


                //For PG Students
                model.Student_AdmissionDocuments_PGStudents_DegreeMarksheet = model.Student_AdmissionDocuments_PGStudents_DegreeMarksheet;
                model.Student_AdmissionDocuments_PGStudents_DegreeCertificate = model.Student_AdmissionDocuments_PGStudents_DegreeCertificate;
                model.Student_AdmissionDocuments_PGStudents_GateScoreCard = model.Student_AdmissionDocuments_PGStudents_GateScoreCard;
                model.Student_AdmissionDocuments_PGStudents_SponsorshipLetterforSponsoredCandidate = model.Student_AdmissionDocuments_PGStudents_SponsorshipLetterforSponsoredCandidate;

                if (model.StudentSubmitedDocumentIDs.Length > 13)
                    model.StudentRegistrationFormDTO.StudentSubmitedDocumentIDs = model.StudentSubmitedDocumentIDs;
                else
                    model.StudentRegistrationFormDTO.StudentSubmitedDocumentIDs = "";

                model.StudentRegistrationFormDTO.Student_AdmissionDocuments_Comments = model.Student_AdmissionDocuments_Comments;



                //Subject Ids
                model.StudentRegistrationFormDTO.QualifyingExamSubjectDetailsIDs = model.QualifyingExamSubjectDetailsIDs;
                model.StudentRegistrationFormDTO.QualificationExamSubjectGeneralDetailsIDs = model.QualificationExamSubjectGeneralDetailsIDs;
                model.StudentRegistrationFormDTO.QualificationExamSubjectSSCDetailsIDs = model.QualificationExamSubjectSSCDetailsIDs;
                model.StudentRegistrationFormDTO.QualificationExamSubjectHSCDetailsIDs = model.QualificationExamSubjectHSCDetailsIDs;

                //for Research Degree Synopsis
                model.StudentRegistrationFormDTO.NameOfApplicant = string.IsNullOrEmpty(model.NameOfApplicant) ? string.Empty: model.NameOfApplicant;
                model.StudentRegistrationFormDTO.TitleOfProject = string.IsNullOrEmpty(model.TitleOfProject) ? string.Empty:model.TitleOfProject;
                model.StudentRegistrationFormDTO.ProjectSummary = string.IsNullOrEmpty(model.ProjectSummary)? string.Empty :model.ProjectSummary;

                //for Previous Work Experience
                model.StudentRegistrationFormDTO.WorkExperienceXML = string.IsNullOrEmpty(model.WorkExperienceXML)? string.Empty:model.WorkExperienceXML;

                //for Fees Details
                model.StudentRegistrationFormDTO.FeesPaidBy = model.FeesPaidBy;

                model.StudentRegistrationFormDTO.IsTaskGeneratedForApproval = model.IsTaskGeneratedForApproval;
                IBaseEntityResponse<StudentRegistrationForm> response = _StudentRegistrationFormServiceAccess.InsertStudentRegistrationForm(model.StudentRegistrationFormDTO);
                Session["StudentRegistrationMasterID"] = Convert.ToString(response.Entity.ID);
            }

            return Json(Boolean.TrueString);
            //}
            //else
            //{
            //    return Json(Boolean.FalseString);
            //}
        }
       
        [HttpGet]
        public ActionResult ViewDetails()
        {
            StudentRegistrationFormViewModel model = new StudentRegistrationFormViewModel();
            try
            {
                model.StudentRegistrationFormDTO = new StudentRegistrationForm();
                model.StudentRegistrationFormDTO.ID = Convert.ToInt32(Session["StudentRegistrationMasterID"]);
                model.StudentRegistrationFormDTO.AuthorisationType = "Academic";
                model.StudentRegistrationFormDTO.ConnectionString = _connectioString;

                List<SelectListItem> StudentRegistrationForm_StudentPhysicallyHandicapped = new List<SelectListItem>();
                ViewBag.StudentRegistrationForm_StudentPhysicallyHandicapped = new SelectList(StudentRegistrationForm_StudentPhysicallyHandicapped, "Value", "Text");
                List<SelectListItem> li_StudentRegistrationForm_StudentPhysicallyHandicapped = new List<SelectListItem>();
                li_StudentRegistrationForm_StudentPhysicallyHandicapped.Add(new SelectListItem { Text = "NO", Value = "0" });
                li_StudentRegistrationForm_StudentPhysicallyHandicapped.Add(new SelectListItem { Text = "YES", Value = "1" });
                
                //For Fees Payment Details
                List<SelectListItem> li_FeesPaidBy = new List<SelectListItem>();
                li_FeesPaidBy.Add(new SelectListItem { Text = "You", Value = "1" });
                li_FeesPaidBy.Add(new SelectListItem { Text = "Family", Value = "2" });
                li_FeesPaidBy.Add(new SelectListItem { Text = "Employer", Value = "3" });
                li_FeesPaidBy.Add(new SelectListItem { Text = "Research Council", Value = "4" });
                li_FeesPaidBy.Add(new SelectListItem { Text = "Other external Sponsor", Value = "5" });



                IBaseEntityResponse<StudentRegistrationForm> response = _StudentRegistrationFormServiceAccess.SelectByID(model.StudentRegistrationFormDTO);
                if (response != null && response.Entity != null)
                {
                    model.StudentRegistrationFormDTO.ID = response.Entity.ID;
                    //model.StudentRegistrationFormDTO.RegistrationID = response.Entity.RegistrationID;
                    model.StudentRegistrationFormDTO.Student_DateofRegistration = response.Entity.Student_DateofRegistration;
                    model.StudentRegistrationFormDTO.StudentTitle = response.Entity.StudentTitle;
                    model.StudentRegistrationFormDTO.StudentFirstName = response.Entity.StudentFirstName;
                    model.StudentRegistrationFormDTO.StudentMiddleName = response.Entity.StudentMiddleName;
                    model.StudentRegistrationFormDTO.StudentLastName = response.Entity.StudentLastName;
                    model.StudentRegistrationFormDTO.MotherFirstName = response.Entity.MotherFirstName;
                    model.StudentRegistrationFormDTO.StudentMobileNumber = response.Entity.StudentMobileNumber;
                    model.StudentRegistrationFormDTO.FatherMobileNumber = response.Entity.FatherMobileNumber;
                    model.StudentRegistrationFormDTO.GuardianMobileNumber = response.Entity.GuardianMobileNumber;
                    model.StudentRegistrationFormDTO.FatherLandLineNumber = response.Entity.FatherLandLineNumber;
                    model.StudentRegistrationFormDTO.FatherEmailId = response.Entity.FatherEmailId;
                    model.StudentRegistrationFormDTO.GuardianEmailId = response.Entity.GuardianEmailId;
                    model.StudentRegistrationFormDTO.FatherEmailId = response.Entity.FatherEmailId;
                    model.StudentRegistrationFormDTO.MotherEmailId = response.Entity.MotherEmailId;
                    model.StudentRegistrationFormDTO.StudentEmailID = response.Entity.StudentEmailID;

                    model.StudentRegistrationFormDTO.StudentNameAsPerMarkSheet = response.Entity.StudentNameAsPerMarkSheet;
                    model.StudentRegistrationFormDTO.StudentLastSchool_College = response.Entity.StudentLastSchool_College;
                    model.StudentRegistrationFormDTO.StudentPreviousLC_TCNo = response.Entity.StudentPreviousLC_TCNo;
                    model.StudentRegistrationFormDTO.StudentCasteAsPerTC_LC = response.Entity.StudentCasteAsPerTC_LC;
                    model.StudentRegistrationFormDTO.StudentEnrollmentNo = response.Entity.StudentEnrollmentNo;
                    model.StudentRegistrationFormDTO.StudentRegionID = response.Entity.StudentRegionID;
                    model.StudentRegistrationFormDTO.Student_Domesile_CountryId = response.Entity.Student_Domesile_CountryId;
                    model.StudentRegistrationFormDTO.StudentRegionOther = response.Entity.StudentRegionOther;
                    model.StudentRegistrationFormDTO.StudentMigrationNumber = response.Entity.StudentMigrationNumber;

                    model.StudentRegistrationFormDTO.StudentMigrationDate = response.Entity.StudentMigrationDate;

                    model.StudentRegistrationFormDTO.Student_DTE_AdmissionCategoryId = response.Entity.Student_DTE_AdmissionCategoryId;
                    model.StudentRegistrationFormDTO.Student_DTE_AdmissionTypeId = response.Entity.Student_DTE_AdmissionTypeId;
                    // ,[IsHostelResidency]
                    model.StudentRegistrationFormDTO.BranchDetailID = response.Entity.BranchDetailID;
                    model.StudentRegistrationFormDTO.StandardNumber = response.Entity.StandardNumber;
                    // ,[AdmissionPatternID]
                    // ,[StudentActiveFlag]
                    //,[AcademicYearID]
                    model.StudentRegistrationFormDTO.CenterCode = response.Entity.CenterCode;
                    model.StudentRegistrationFormDTO.UniversityID = response.Entity.UniversityID;

                    model.StudentRegistrationFormDTO.StudentNRI_POI = response.Entity.StudentNRI_POI;

                    model.StudentRegistrationFormDTO.NameOfApplicant = response.Entity.NameOfApplicant;
                    model.StudentRegistrationFormDTO.TitleOfProject = response.Entity.TitleOfProject;
                    model.StudentRegistrationFormDTO.ProjectSummary = response.Entity.ProjectSummary;

                    //,[AllotAdmThrough]
                    //,[BankAccountNumber]
                    //,[BankBranchName]
                    //,[BankIFSCCode]
                    //,[BankMICRCode]
                    model.StudentRegistrationFormDTO.Student_Scholarship_AadhaarCardNo = response.Entity.Student_Scholarship_AadhaarCardNo;

                    //,[IdentificationType]

                    model.StudentRegistrationFormDTO.StudentPhoto = response.Entity.StudentPhoto;
                    model.StudentRegistrationFormDTO.StudentSignature = response.Entity.StudentSignature;
                    model.StudentRegistrationFormDTO.StudentThumb = response.Entity.StudentThumb;

                    model.StudentRegistrationFormDTO.StudentPhotoFileSize = response.Entity.StudentPhotoFileSize;
                    model.StudentRegistrationFormDTO.StudentSignatureFileSize = response.Entity.StudentSignatureFileSize;
                    model.StudentRegistrationFormDTO.StudentThumbFileSize = response.Entity.StudentThumbFileSize;


                    model.StudentRegistrationFormDTO.StudentPhotoType = response.Entity.StudentPhotoType;
                    model.StudentRegistrationFormDTO.StudentPhotoFilename = response.Entity.StudentPhotoFilename;
                    model.StudentRegistrationFormDTO.StudentPhotoFileWidth = response.Entity.StudentPhotoFileWidth;
                    model.StudentRegistrationFormDTO.StudentPhotoFileHeight = response.Entity.StudentPhotoFileHeight;

                    model.StudentRegistrationFormDTO.StudentSignatureType = response.Entity.StudentSignatureType;
                    model.StudentRegistrationFormDTO.StudentSignatureFilename = response.Entity.StudentSignatureFilename;
                    model.StudentRegistrationFormDTO.StudentSignatureFileWidth = response.Entity.StudentSignatureFileWidth;
                    model.StudentRegistrationFormDTO.StudentSignatureFileHeight = response.Entity.StudentSignatureFileHeight;

                    model.StudentRegistrationFormDTO.StudentThumbType = response.Entity.StudentThumbType;
                    model.StudentRegistrationFormDTO.StudentThumbFilename = response.Entity.StudentThumbFilename;
                    model.StudentRegistrationFormDTO.StudentThumbFileWidth = response.Entity.StudentThumbFileWidth;
                    model.StudentRegistrationFormDTO.StudentThumbFileHeight = response.Entity.StudentThumbFileHeight;


                    model.StudentRegistrationFormDTO.StudentDateofBirth = response.Entity.StudentDateofBirth;
                    model.StudentRegistrationFormDTO.StudentBirthPlace = response.Entity.StudentBirthPlace;
                    model.StudentRegistrationFormDTO.StudentGender = response.Entity.StudentGender;
                    model.StudentRegistrationFormDTO.StudentMaritalStatus = response.Entity.StudentMaritalStatus;
                    model.StudentRegistrationFormDTO.StudentNationalityID = response.Entity.StudentNationalityID;
                    model.StudentRegistrationFormDTO.StudentReligionID = response.Entity.StudentReligionID;
                    model.StudentRegistrationFormDTO.StudentMotherTongueID = response.Entity.StudentMotherTongueID;
                    model.StudentRegistrationFormDTO.StudentCategoryID = response.Entity.StudentCategoryID;
                    model.StudentRegistrationFormDTO.StudentCasteID = response.Entity.StudentCasteID;

                    //,C.SubCasteId
                    model.StudentRegistrationFormDTO.StudentBloodGroup = response.Entity.StudentBloodGroup;
                    model.StudentRegistrationFormDTO.StudentLandLineNumber = response.Entity.StudentLandLineNumber;
                    model.StudentRegistrationFormDTO.StudentIdentificationMark = response.Entity.StudentIdentificationMark;
                    model.StudentRegistrationFormDTO.StudentEmploymentSector = response.Entity.StudentEmploymentSector;
                    model.StudentRegistrationFormDTO.StudentOccupation = response.Entity.StudentOccupation;
                    model.StudentRegistrationFormDTO.StudentDesignation = response.Entity.StudentDesignation;
                    model.StudentRegistrationFormDTO.StudentOrganizationName = response.Entity.StudentOrganizationName;
                    model.StudentRegistrationFormDTO.StudentOfficeContactNo = response.Entity.StudentOfficeContactNo;
                    model.StudentRegistrationFormDTO.StudentAnnualIncome = response.Entity.StudentAnnualIncome;
                    if (response.Entity.PhysicallyHandicapped == "False")
                    {
                        model.StudentRegistrationFormDTO.PhysicallyHandicapped = "0";
                    }
                    else
                    {
                        model.StudentRegistrationFormDTO.PhysicallyHandicapped = "1";
                    }
                    if (response.Entity.StudentOrgandonor == "False")
                    {
                        model.StudentRegistrationFormDTO.StudentOrgandonor = "0";
                    }
                    else
                    {
                        model.StudentRegistrationFormDTO.StudentOrgandonor = "1";
                    }


                    model.StudentRegistrationFormDTO.StudentPrevNameofStudent = response.Entity.StudentPrevNameofStudent;
                    model.StudentRegistrationFormDTO.StudentReasonforNamechange = response.Entity.StudentReasonforNamechange;
                    if (response.Entity.StudentEmploymentStatus == "False")
                    {
                        model.StudentRegistrationFormDTO.StudentEmploymentStatus = "0";
                    }
                    else
                    {
                        model.StudentRegistrationFormDTO.StudentEmploymentStatus = "1";
                    }


                    model.StudentRegistrationFormDTO.FatherHusbondType = response.Entity.FatherHusbondType;
                    model.StudentRegistrationFormDTO.FatherTitle = response.Entity.FatherTitle;
                    model.StudentRegistrationFormDTO.FatherFirstName = response.Entity.FatherFirstName;
                    model.StudentRegistrationFormDTO.FatherMiddleName = response.Entity.FatherMiddleName;
                    model.StudentRegistrationFormDTO.FatherLastName = response.Entity.FatherLastName;
                    model.StudentRegistrationFormDTO.FatherEmailId = response.Entity.FatherEmailId;
                    model.StudentRegistrationFormDTO.FatherMobileNumber = response.Entity.FatherMobileNumber;
                    model.StudentRegistrationFormDTO.StudentDomicileStateofFather = response.Entity.StudentDomicileStateofFather;
                    model.StudentRegistrationFormDTO.FatherLandLineNumber = response.Entity.FatherLandLineNumber;
                    model.StudentRegistrationFormDTO.FatherEmploymentSector = response.Entity.FatherEmploymentSector;
                    model.StudentRegistrationFormDTO.FatherOccupation = response.Entity.FatherOccupation;
                    model.StudentRegistrationFormDTO.FatherDesignation = response.Entity.FatherDesignation;
                    model.StudentRegistrationFormDTO.FatherOrganizationName = response.Entity.FatherOrganizationName;
                    model.StudentRegistrationFormDTO.FatherOfficeContactNo = response.Entity.FatherOfficeContactNo;
                    model.StudentRegistrationFormDTO.FatherAnnualIncome = response.Entity.FatherAnnualIncome;

                    //   model.StudentRegistrationFormDTO.FatherHusbondType =  response.Entity.["M_EntityType";
                    model.StudentRegistrationFormDTO.MotherTitle = response.Entity.MotherTitle;
                    model.StudentRegistrationFormDTO.MotherFirstName = response.Entity.MotherFirstName;
                    model.StudentRegistrationFormDTO.MotherMiddleName = response.Entity.MotherMiddleName;
                    model.StudentRegistrationFormDTO.MotherLastName = response.Entity.MotherLastName;
                    model.StudentRegistrationFormDTO.MotherEmailId = response.Entity.MotherEmailId;
                    model.StudentRegistrationFormDTO.MotherMobileNumber = response.Entity.MotherMobileNumber;
                    model.StudentRegistrationFormDTO.StudentDomicileStateofMother = response.Entity.StudentDomicileStateofMother;
                    model.StudentRegistrationFormDTO.MotherLandLineNumber = response.Entity.MotherLandLineNumber;
                    model.StudentRegistrationFormDTO.MotherEmploymentSector = response.Entity.MotherEmploymentSector;
                    model.StudentRegistrationFormDTO.MotherOccupation = response.Entity.MotherOccupation;
                    model.StudentRegistrationFormDTO.MotherDesignation = response.Entity.MotherDesignation;
                    model.StudentRegistrationFormDTO.MotherOrganizationName = response.Entity.MotherOrganizationName;
                    model.StudentRegistrationFormDTO.MotherOfficeContactNo = response.Entity.MotherOfficeContactNo;
                    model.StudentRegistrationFormDTO.MotherAnnualIncome = response.Entity.MotherAnnualIncome;

                    model.StudentRegistrationFormDTO.GuardianTitle = response.Entity.GuardianTitle;
                    model.StudentRegistrationFormDTO.GuardianFirstName = response.Entity.GuardianFirstName;
                    model.StudentRegistrationFormDTO.GuardianMiddleName = response.Entity.GuardianMiddleName;
                    model.StudentRegistrationFormDTO.GuardianLastName = response.Entity.GuardianLastName;
                    model.StudentRegistrationFormDTO.GuardianEmailId = response.Entity.GuardianEmailId;
                    model.StudentRegistrationFormDTO.GuardianMobileNumber = response.Entity.GuardianMobileNumber;
                    //    model.StudentRegistrationFormDTO.StudentDomicileStateofGuardian =  response.Entity.["G_DomicileState";
                    model.StudentRegistrationFormDTO.GuardianLandLineNumber = response.Entity.GuardianLandLineNumber;
                    model.StudentRegistrationFormDTO.GuardianEmploymentSector = response.Entity.GuardianEmploymentSector;
                    model.StudentRegistrationFormDTO.GuardianOccupation = response.Entity.GuardianOccupation;
                    model.StudentRegistrationFormDTO.GuardianDesignation = response.Entity.GuardianDesignation;
                    model.StudentRegistrationFormDTO.GuardianOrganizationName = response.Entity.GuardianOrganizationName;
                    model.StudentRegistrationFormDTO.GuardianOfficeContactNo = response.Entity.GuardianOfficeContactNo;
                    model.StudentRegistrationFormDTO.GuardianAnnualIncome = response.Entity.GuardianAnnualIncome;

                    model.StudentRegistrationFormDTO.Student_Ex_Serviceman_Ward_of_Ex_Serviceman = response.Entity.Student_Ex_Serviceman_Ward_of_Ex_Serviceman;
                    model.StudentRegistrationFormDTO.Student_Active_Serviceman_Ward_of_Active_Serviceman = response.Entity.Student_Active_Serviceman_Ward_of_Active_Serviceman;
                    model.StudentRegistrationFormDTO.Student_FreedomFighterWardOfFreedomFighter = response.Entity.Student_FreedomFighterWardOfFreedomFighter;
                    model.StudentRegistrationFormDTO.Student_WardofPrimaryTeacher = response.Entity.Student_WardofPrimaryTeacher;
                    model.StudentRegistrationFormDTO.Student_WardofSecondaryTeacher = response.Entity.Student_WardofSecondaryTeacher;
                    model.StudentRegistrationFormDTO.Student_Deserted_Divorced_Widowed_Women = response.Entity.Student_Deserted_Divorced_Widowed_Women;
                    model.StudentRegistrationFormDTO.Student_MemberofProjectAffectedFamily = response.Entity.Student_MemberofProjectAffectedFamily;
                    model.StudentRegistrationFormDTO.Student_MemberofEarthquakeAffectedFamily = response.Entity.Student_MemberofEarthquakeAffectedFamily;
                    model.StudentRegistrationFormDTO.Student_MemberofFloodFamineAffectedFamily = response.Entity.Student_MemberofFloodFamineAffectedFamily;
                    model.StudentRegistrationFormDTO.Student_ResidentofTribalArea = response.Entity.Student_ResidentofTribalArea;
                    model.StudentRegistrationFormDTO.Student_KashmirMigrant = response.Entity.Student_KashmirMigrant;

                    model.StudentRegistrationFormDTO.StudentIndicatetypeofCandidature = response.Entity.StudentIndicatetypeofCandidature;
                    model.StudentRegistrationFormDTO.StudentSchoolFromHSCExaminationpassed = response.Entity.StudentSchoolFromHSCExaminationpassed;
                    if (response.Entity.StudentEconomicallyBackwardClass == "False")
                    {
                        model.StudentRegistrationFormDTO.StudentEconomicallyBackwardClass = "0";
                    }
                    else
                    {
                        model.StudentRegistrationFormDTO.StudentEconomicallyBackwardClass = "1";
                    }

                    model.StudentRegistrationFormDTO.StudentsNameOfDistrictWhereParentDomiciled = response.Entity.StudentsNameOfDistrictWhereParentDomiciled;
                    model.StudentRegistrationFormDTO.StudentsMKBCandidate = response.Entity.StudentsMKBCandidate;

                    model.StudentRegistrationFormDTO.Student_PermanentAddress_Address1 = response.Entity.Student_PermanentAddress_Address1;
                    model.StudentRegistrationFormDTO.Student_PermanentAddress_Address2 = response.Entity.Student_PermanentAddress_Address2;
                    model.StudentRegistrationFormDTO.Student_PermanentAddress_PloteNo = response.Entity.Student_PermanentAddress_PloteNo;
                    model.StudentRegistrationFormDTO.Student_PermanentAddress_StreeNo = response.Entity.Student_PermanentAddress_StreeNo;
                    model.StudentRegistrationFormDTO.Student_PermanentAddress_City_TahsilID = response.Entity.Student_PermanentAddress_City_TahsilID;
                    model.StudentRegistrationFormDTO.Student_PermanentAddress_City_TahsilName = response.Entity.Student_PermanentAddress_City_TahsilName;
                    model.StudentRegistrationFormDTO.Student_PermanentAddress_City_TahsilOther = response.Entity.Student_PermanentAddress_City_TahsilOther;
                    model.StudentRegistrationFormDTO.Student_PermanentAddress_DistrictID = response.Entity.Student_PermanentAddress_DistrictID;
                    model.StudentRegistrationFormDTO.Student_PermanentAddress_DistrictOther = response.Entity.Student_PermanentAddress_DistrictOther;
                    model.StudentRegistrationFormDTO.Student_PermanentAddress_State = response.Entity.Student_PermanentAddress_State;
                    model.StudentRegistrationFormDTO.Student_PermanentAddress_StateOther = response.Entity.Student_PermanentAddress_StateOther;
                    model.StudentRegistrationFormDTO.Student_PermanentAddress_CountryId = response.Entity.Student_PermanentAddress_CountryId;
                    model.StudentRegistrationFormDTO.Student_PermanentAddress_NearPoliceStation = response.Entity.Student_PermanentAddress_NearPoliceStation;
                    model.StudentRegistrationFormDTO.Student_PermanentAddress_Tahsil = response.Entity.Student_PermanentAddress_Tahsil;
                    model.StudentRegistrationFormDTO.Student_PermanentAddress_ZipCode = response.Entity.Student_PermanentAddress_ZipCode;
                    model.StudentRegistrationFormDTO.Student_PermanentAddress_City_Tahsil_Pattern = response.Entity.Student_PermanentAddress_City_Tahsil_Pattern;


                    model.StudentRegistrationFormDTO.Student_CorrespondenceAddress_Address1 = response.Entity.Student_CorrespondenceAddress_Address1;
                    model.StudentRegistrationFormDTO.Student_CorrespondenceAddress_Address2 = response.Entity.Student_CorrespondenceAddress_Address2;
                    model.StudentRegistrationFormDTO.Student_CorrespondenceAddress_PloteNo = response.Entity.Student_CorrespondenceAddress_PloteNo;
                    model.StudentRegistrationFormDTO.Student_CorrespondenceAddress_StreeNo = response.Entity.Student_CorrespondenceAddress_StreeNo;
                    model.StudentRegistrationFormDTO.Student_CorrespondenceAddress_City_TahsilID = response.Entity.Student_CorrespondenceAddress_City_TahsilID;
                    model.StudentRegistrationFormDTO.Student_CorrespondenceAddress_City_TahsilName = response.Entity.Student_CorrespondenceAddress_City_TahsilName;
                    model.StudentRegistrationFormDTO.Student_CorrespondenceAddress_City_TahsilOther = response.Entity.Student_CorrespondenceAddress_City_TahsilOther;
                    model.StudentRegistrationFormDTO.Student_CorrespondenceAddress_DistrictID = response.Entity.Student_CorrespondenceAddress_DistrictID;
                    model.StudentRegistrationFormDTO.Student_CorrespondenceAddress_DistrictOther = response.Entity.Student_CorrespondenceAddress_DistrictOther;
                    model.StudentRegistrationFormDTO.Student_CorrespondenceAddress_State = response.Entity.Student_CorrespondenceAddress_State;
                    model.StudentRegistrationFormDTO.Student_CorrespondenceAddress_StateOther = response.Entity.Student_CorrespondenceAddress_StateOther;
                    model.StudentRegistrationFormDTO.Student_CorrespondenceAddress_CountryId = response.Entity.Student_CorrespondenceAddress_CountryId;
                    model.StudentRegistrationFormDTO.Student_CorrespondenceAddress_NearPoliceStation = response.Entity.Student_CorrespondenceAddress_NearPoliceStation;
                    model.StudentRegistrationFormDTO.Student_CorrespondenceAddress_Tahsil = response.Entity.Student_CorrespondenceAddress_Tahsil;
                    model.StudentRegistrationFormDTO.Student_CorrespondenceAddress_ZipCode = response.Entity.Student_CorrespondenceAddress_ZipCode;
                    model.StudentRegistrationFormDTO.Student_CorrespondenceAddress_City_Tahsil_Pattern = response.Entity.Student_CorrespondenceAddress_City_Tahsil_Pattern;
                    model.StudentRegistrationFormDTO.Student_QualifyingExamId = response.Entity.Student_QualifyingExamId;
                    model.StudentRegistrationFormDTO.Student_QualifyingRollNo = response.Entity.Student_QualifyingRollNo;
                    model.StudentRegistrationFormDTO.Student_QualifyingExamTotalMarksPointsObtained = response.Entity.Student_QualifyingExamTotalMarksPointsObtained;
                    model.StudentRegistrationFormDTO.Student_QualifyingExamOutOffMark = response.Entity.Student_QualifyingExamOutOffMark;
                    model.StudentRegistrationFormDTO.Student_QualifyingExamRank = response.Entity.Student_QualifyingExamRank;

                    model.StudentRegistrationFormDTO.Student_Qualification_General_MediumOfInstitution = response.Entity.Student_Qualification_General_MediumOfInstitution;
                    model.StudentRegistrationFormDTO.Student_Qualification_General_MonthOfPassing = response.Entity.Student_Qualification_General_MonthOfPassing;
                    model.StudentRegistrationFormDTO.Student_Qualification_General_YearOfPassing = response.Entity.Student_Qualification_General_YearOfPassing;
                    if (response.Entity.Student_Qualification_General_SingleAttempt == "False")
                    {
                        model.StudentRegistrationFormDTO.Student_Qualification_General_SingleAttempt = "0";
                    }
                    else
                    {
                        model.StudentRegistrationFormDTO.Student_Qualification_General_SingleAttempt = "1";
                    }
                    model.StudentRegistrationFormDTO.Student_Qualification_General_ObtainedMark = response.Entity.Student_Qualification_General_ObtainedMark;
                    model.StudentRegistrationFormDTO.Student_Qualification_General_OutOfMark = response.Entity.Student_Qualification_General_OutOfMark;
                    model.StudentRegistrationFormDTO.Student_Qualification_General_Percent = response.Entity.Student_Qualification_General_Percent;
                    model.StudentRegistrationFormDTO.Student_Qualification_General_NameofInstitution = response.Entity.Student_Qualification_General_NameofInstitution;
                    model.StudentRegistrationFormDTO.Student_Qualification_General_Region_Division_Board = response.Entity.Student_Qualification_General_Region_Division_Board;

                    model.StudentRegistrationFormDTO.Student_Qualification_SSC_MediumOfInstitution = response.Entity.Student_Qualification_SSC_MediumOfInstitution;
                    model.StudentRegistrationFormDTO.Student_Qualification_SSC_MonthOfPassing = response.Entity.Student_Qualification_SSC_MonthOfPassing;
                    model.StudentRegistrationFormDTO.Student_Qualification_SSC_YearOfPassing = response.Entity.Student_Qualification_SSC_YearOfPassing;
                    if (response.Entity.Student_Qualification_SSC_SingleAttempt == "False")
                    {
                        model.StudentRegistrationFormDTO.Student_Qualification_SSC_SingleAttempt = "0";
                    }
                    else
                    {
                        model.StudentRegistrationFormDTO.Student_Qualification_SSC_SingleAttempt = "1";
                    }

                    model.StudentRegistrationFormDTO.Student_Qualification_SSC_ObtainedMark = response.Entity.Student_Qualification_SSC_ObtainedMark;
                    model.StudentRegistrationFormDTO.Student_Qualification_SSC_OutOfMark = response.Entity.Student_Qualification_SSC_OutOfMark;
                    model.StudentRegistrationFormDTO.Student_Qualification_SSC_Percent = response.Entity.Student_Qualification_SSC_Percent;
                    model.StudentRegistrationFormDTO.Student_Qualification_SSC_NameofInstitution = response.Entity.Student_Qualification_SSC_NameofInstitution;
                    model.StudentRegistrationFormDTO.Student_Qualification_SSC_Region_Division_Board = response.Entity.Student_Qualification_SSC_Region_Division_Board;

                    model.StudentRegistrationFormDTO.Student_Qualification_HSC_MediumOfInstitution = response.Entity.Student_Qualification_HSC_MediumOfInstitution;
                    model.StudentRegistrationFormDTO.Student_Qualification_HSC_MonthOfPassing = response.Entity.Student_Qualification_HSC_MonthOfPassing;
                    model.StudentRegistrationFormDTO.Student_Qualification_HSC_YearOfPassing = response.Entity.Student_Qualification_HSC_YearOfPassing;
                    if (response.Entity.Student_Qualification_HSC_SingleAttempt == "False")
                    {
                        model.StudentRegistrationFormDTO.Student_Qualification_HSC_SingleAttempt = "0";
                    }
                    else
                    {
                        model.StudentRegistrationFormDTO.Student_Qualification_HSC_SingleAttempt = "1";
                    }

                    model.StudentRegistrationFormDTO.Student_Qualification_HSC_ObtainedMark = response.Entity.Student_Qualification_HSC_ObtainedMark;
                    model.StudentRegistrationFormDTO.Student_Qualification_HSC_OutOfMark = response.Entity.Student_Qualification_HSC_OutOfMark;
                    model.StudentRegistrationFormDTO.Student_Qualification_HSC_Percent = response.Entity.Student_Qualification_HSC_Percent;
                    model.StudentRegistrationFormDTO.Student_Qualification_HSC_NameofInstitution = response.Entity.Student_Qualification_HSC_NameofInstitution;
                    model.StudentRegistrationFormDTO.Student_Qualification_HSC_Region_Division_Board = response.Entity.Student_Qualification_HSC_Region_Division_Board;
                    model.StudentRegistrationFormDTO.Student_Qualification_HSC_StreamID = response.Entity.Student_Qualification_HSC_StreamID;
                    model.StudentRegistrationFormDTO.Student_Qualification_HSC_StreamOther = response.Entity.Student_Qualification_HSC_StreamOther;
                    model.StudentRegistrationFormDTO.Student_Qualification_HSC_Class = response.Entity.Student_Qualification_HSC_Class;

                    model.StudentRegistrationFormDTO.Student_Qualification_HSC_PCM_PVM_ObtainedMark = response.Entity.Student_Qualification_HSC_PCM_PVM_ObtainedMark;
                    model.StudentRegistrationFormDTO.Student_Qualification_HSC_PCM_PVM_OutOfMark = response.Entity.Student_Qualification_HSC_PCM_PVM_OutOfMark;
                    model.StudentRegistrationFormDTO.Student_Qualification_HSC_PCB_ObtainedMark = response.Entity.Student_Qualification_HSC_PCB_ObtainedMark;
                    model.StudentRegistrationFormDTO.Student_Qualification_HSC_PCB_OutOfMark = response.Entity.Student_Qualification_HSC_PCB_OutOfMark;

                    model.StudentRegistrationFormDTO.Student_Qualification_Diploma_ITI_Details_MediumOfInstitution = response.Entity.Student_Qualification_Diploma_ITI_Details_MediumOfInstitution;
                    model.StudentRegistrationFormDTO.Student_Qualification_Diploma_ITI_Details_BranchName = response.Entity.Student_Qualification_Diploma_ITI_Details_BranchName;
                    model.StudentRegistrationFormDTO.Student_Qualification_Diploma_ITI_Details_ExamPattern = response.Entity.Student_Qualification_Diploma_ITI_Details_ExamPattern;
                    model.StudentRegistrationFormDTO.Student_Qualification_Diploma_ITI_Details_MonthOfPassing = response.Entity.Student_Qualification_Diploma_ITI_Details_MonthOfPassing;
                    model.StudentRegistrationFormDTO.Student_Qualification_Diploma_ITI_Details_YearOfPassing = response.Entity.Student_Qualification_Diploma_ITI_Details_YearOfPassing;
                    if (response.Entity.Student_Qualification_Diploma_ITI_Details_SingleAttempt == "False")
                    {
                        model.StudentRegistrationFormDTO.Student_Qualification_Diploma_ITI_Details_SingleAttempt = "0";
                    }
                    else
                    {
                        model.StudentRegistrationFormDTO.Student_Qualification_Diploma_ITI_Details_SingleAttempt = "1";
                    }

                    model.StudentRegistrationFormDTO.Student_Qualification_Diploma_ITI_Details_ObtainedMark = response.Entity.Student_Qualification_Diploma_ITI_Details_ObtainedMark;
                    model.StudentRegistrationFormDTO.Student_Qualification_Diploma_ITI_Details_OutOfMark = response.Entity.Student_Qualification_Diploma_ITI_Details_OutOfMark;
                    model.StudentRegistrationFormDTO.Student_Qualification_Diploma_ITI_Details_Percent = response.Entity.Student_Qualification_Diploma_ITI_Details_Percent;
                    model.StudentRegistrationFormDTO.Student_Qualification_Diploma_ITI_Details_NameofInstitution = response.Entity.Student_Qualification_Diploma_ITI_Details_NameofInstitution;
                    model.StudentRegistrationFormDTO.Student_Qualification_Diploma_ITI_Details_Board = response.Entity.Student_Qualification_Diploma_ITI_Details_Board;
                    model.StudentRegistrationFormDTO.Student_Qualification_Diploma_ITI_Details_State = response.Entity.Student_Qualification_Diploma_ITI_Details_State;
                    model.StudentRegistrationFormDTO.Student_Qualification_Diploma_ITI_Details_CountryId = response.Entity.Student_Qualification_Diploma_ITI_Details_CountryId;
                    model.StudentRegistrationFormDTO.Student_Qualification_Diploma_ITI_Details_StateOther = response.Entity.Student_Qualification_Diploma_ITI_Details_StateOther;
                    model.StudentRegistrationFormDTO.Student_Qualification_Diploma_ITI_Details_BoardEnrollmentNumber = response.Entity.Student_Qualification_Diploma_ITI_Details_BoardEnrollmentNumber;
                    model.StudentRegistrationFormDTO.Student_Qualification_Diploma_ITI_Details_Class = response.Entity.Student_Qualification_Diploma_ITI_Details_Class;

                    model.StudentRegistrationFormDTO.Student_Qualification_DegreeDetails_MediumOfInstitution = response.Entity.Student_Qualification_DegreeDetails_MediumOfInstitution;
                    model.StudentRegistrationFormDTO.Student_Qualification_DegreeDetails_BranchName = response.Entity.Student_Qualification_DegreeDetails_BranchName;
                    model.StudentRegistrationFormDTO.Student_Qualification_DegreeDetails_ExamPattern = response.Entity.Student_Qualification_DegreeDetails_ExamPattern;
                    model.StudentRegistrationFormDTO.Student_Qualification_DegreeDetails_MonthOfPassing = response.Entity.Student_Qualification_DegreeDetails_MonthOfPassing;
                    model.StudentRegistrationFormDTO.Student_Qualification_DegreeDetails_YearOfPassing = response.Entity.Student_Qualification_DegreeDetails_YearOfPassing;
                    if (response.Entity.Student_Qualification_DegreeDetails_SingleAttempt == "False")
                    {
                        model.StudentRegistrationFormDTO.Student_Qualification_DegreeDetails_SingleAttempt = "0";
                    }
                    else
                    {
                        model.StudentRegistrationFormDTO.Student_Qualification_DegreeDetails_SingleAttempt = "1";
                    }
                    model.StudentRegistrationFormDTO.Student_Qualification_DegreeDetails_ObtainedMark = response.Entity.Student_Qualification_DegreeDetails_ObtainedMark;
                    model.StudentRegistrationFormDTO.Student_Qualification_DegreeDetails_OutOfMark = response.Entity.Student_Qualification_DegreeDetails_OutOfMark;
                    model.StudentRegistrationFormDTO.Student_Qualification_DegreeDetails_Percent = response.Entity.Student_Qualification_DegreeDetails_Percent;
                    model.StudentRegistrationFormDTO.Student_Qualification_DegreeDetails_NameofInstitution = response.Entity.Student_Qualification_DegreeDetails_NameofInstitution;
                    model.StudentRegistrationFormDTO.Student_Qualification_DegreeDetails_UniversityName = response.Entity.Student_Qualification_DegreeDetails_UniversityName;
                    model.StudentRegistrationFormDTO.Student_Qualification_DegreeDetails_State = response.Entity.Student_Qualification_DegreeDetails_State;
                    model.StudentRegistrationFormDTO.Student_Qualification_DegreeDetails_CountryId = response.Entity.Student_Qualification_DegreeDetails_CountryId;
                    model.StudentRegistrationFormDTO.Student_Qualification_DegreeDetails_StateOther = response.Entity.Student_Qualification_DegreeDetails_StateOther;
                    model.StudentRegistrationFormDTO.Student_Qualification_DegreeDetails_Degree = response.Entity.Student_Qualification_DegreeDetails_Degree;
                    model.StudentRegistrationFormDTO.Student_Qualification_DegreeDetails_BoardEnrollmentNumber = response.Entity.Student_Qualification_DegreeDetails_BoardEnrollmentNumber;
                    model.StudentRegistrationFormDTO.Student_Qualification_DegreeDetails_Class = response.Entity.Student_Qualification_DegreeDetails_Class;

                    model.StudentRegistrationFormDTO.Student_Qualification_PostGraduationDetails_MediumOfInstitution = response.Entity.Student_Qualification_PostGraduationDetails_MediumOfInstitution;
                    model.StudentRegistrationFormDTO.Student_Qualification_PostGraduationDetails_BranchName = response.Entity.Student_Qualification_PostGraduationDetails_BranchName;
                    model.StudentRegistrationFormDTO.Student_Qualification_PostGraduationDetails_ExamPattern = response.Entity.Student_Qualification_PostGraduationDetails_ExamPattern;
                    model.StudentRegistrationFormDTO.Student_Qualification_PostGraduationDetails_MonthOfPassing = response.Entity.Student_Qualification_PostGraduationDetails_MonthOfPassing;
                    model.StudentRegistrationFormDTO.Student_Qualification_PostGraduationDetails_YearOfPassing = response.Entity.Student_Qualification_PostGraduationDetails_YearOfPassing;
                    if (response.Entity.Student_Qualification_PostGraduationDetails_SingleAttempt == "False")
                    {
                        model.StudentRegistrationFormDTO.Student_Qualification_PostGraduationDetails_SingleAttempt = "0";
                    }
                    else
                    {
                        model.StudentRegistrationFormDTO.Student_Qualification_PostGraduationDetails_SingleAttempt = "1";
                    }
                    model.StudentRegistrationFormDTO.Student_Qualification_PostGraduationDetails_ObtainedMark = response.Entity.Student_Qualification_PostGraduationDetails_ObtainedMark;
                    model.StudentRegistrationFormDTO.Student_Qualification_PostGraduationDetails_OutOfMark = response.Entity.Student_Qualification_PostGraduationDetails_OutOfMark;
                    model.StudentRegistrationFormDTO.Student_Qualification_PostGraduationDetails_Percent = response.Entity.Student_Qualification_PostGraduationDetails_Percent;
                    model.StudentRegistrationFormDTO.Student_Qualification_PostGraduationDetails_NameofInstitution = response.Entity.Student_Qualification_PostGraduationDetails_NameofInstitution;
                    model.StudentRegistrationFormDTO.Student_Qualification_PostGraduationDetails_UniversityName = response.Entity.Student_Qualification_PostGraduationDetails_UniversityName;
                    model.StudentRegistrationFormDTO.Student_Qualification_PostGraduationDetails_State = response.Entity.Student_Qualification_PostGraduationDetails_State;
                    model.StudentRegistrationFormDTO.Student_Qualification_PostGraduationDetails_CountryId = response.Entity.Student_Qualification_PostGraduationDetails_CountryId;
                    model.StudentRegistrationFormDTO.Student_Qualification_PostGraduationDetails_StateOther = response.Entity.Student_Qualification_PostGraduationDetails_StateOther;
                    model.StudentRegistrationFormDTO.Student_Qualification_PostGraduationDetails_PostGraduation = response.Entity.Student_Qualification_PostGraduationDetails_PostGraduation;
                    model.StudentRegistrationFormDTO.Student_Qualification_PostGraduationDetails_BoardEnrollmentNumber = response.Entity.Student_Qualification_PostGraduationDetails_BoardEnrollmentNumber;
                    model.StudentRegistrationFormDTO.Student_Qualification_PostGraduationDetails_Class = response.Entity.Student_Qualification_PostGraduationDetails_Class;
                    model.StudentRegistrationFormDTO.Student_DTE_DTEUserID = response.Entity.Student_DTE_DTEUserID;
                    model.StudentRegistrationFormDTO.Student_DTE_DTEPassword = response.Entity.Student_DTE_DTEPassword;
                    model.StudentRegistrationFormDTO.Student_DTE_DTESrNo = response.Entity.Student_DTE_DTESrNo;
                    model.StudentRegistrationFormDTO.Student_DTE_DTEMeritNo = response.Entity.Student_DTE_DTEMeritNo;
                    model.StudentRegistrationFormDTO.Student_DTE_AdmissionTypeId = response.Entity.Student_DTE_AdmissionTypeId;
                    model.StudentRegistrationFormDTO.Student_DTE_AdmissionRound = response.Entity.Student_DTE_AdmissionRound;
                    model.StudentRegistrationFormDTO.Student_DTE_AdmissionCategoryId = response.Entity.Student_DTE_AdmissionCategoryId;
                    model.StudentRegistrationFormDTO.Student_DTE_DTESeatNo = response.Entity.Student_DTE_DTESeatNo;
                    model.StudentRegistrationFormDTO.Student_DTE_QualifyingExamName = response.Entity.Student_DTE_QualifyingExamName;
                    model.StudentRegistrationFormDTO.Student_DTE_QualifyingExamMarks = response.Entity.Student_DTE_QualifyingExamMarks;
                    model.StudentRegistrationFormDTO.Student_QualifyingExamName = response.Entity.Student_DTE_QualifyingExamName;


                    //For Document
                    model.StudentRegistrationFormDTO.Student_AdmissionDocuments_JETMarkSheet = response.Entity.Student_AdmissionDocuments_JETMarkSheet;
                    model.StudentRegistrationFormDTO.Student_AdmissionDocuments_AllotmentLetter = response.Entity.Student_AdmissionDocuments_AllotmentLetter;
                    model.StudentRegistrationFormDTO.Student_AdmissionDocuments_TenthMarkSheet = response.Entity.Student_AdmissionDocuments_TenthMarkSheet;
                    model.StudentRegistrationFormDTO.Student_AdmissionDocuments_TwelvethMarkSheet = response.Entity.Student_AdmissionDocuments_TwelvethMarkSheet;
                    model.StudentRegistrationFormDTO.Student_AdmissionDocuments_AllDiplomaMarksheet = response.Entity.Student_AdmissionDocuments_AllDiplomaMarksheet;
                    model.StudentRegistrationFormDTO.Student_AdmissionDocuments_LeavingCertificate = response.Entity.Student_AdmissionDocuments_LeavingCertificate;
                    model.StudentRegistrationFormDTO.Student_AdmissionDocuments_Domicile_BirthCertificate = response.Entity.Student_AdmissionDocuments_Domicile_BirthCertificate;
                    model.StudentRegistrationFormDTO.Student_AdmissionDocuments_NationalityCertificate = response.Entity.Student_AdmissionDocuments_NationalityCertificate;
                    model.StudentRegistrationFormDTO.Student_AdmissionDocuments_CasteCertificate = response.Entity.Student_AdmissionDocuments_CasteCertificate;
                    model.StudentRegistrationFormDTO.Student_AdmissionDocuments_CasteValidityCertificate = response.Entity.Student_AdmissionDocuments_CasteValidityCertificate;
                    model.StudentRegistrationFormDTO.Student_AdmissionDocuments_NonCreamylayerCertificate = response.Entity.Student_AdmissionDocuments_NonCreamylayerCertificate;
                    model.StudentRegistrationFormDTO.Student_AdmissionDocuments_EquivalenceCertificate = response.Entity.Student_AdmissionDocuments_EquivalenceCertificate;
                    model.StudentRegistrationFormDTO.Student_AdmissionDocuments_MigrationCertificate = response.Entity.Student_AdmissionDocuments_MigrationCertificate;
                    model.StudentRegistrationFormDTO.Student_AdmissionDocuments_GapCertificate = response.Entity.Student_AdmissionDocuments_GapCertificate;
                    model.StudentRegistrationFormDTO.Student_AdmissionDocuments_AntiRaggingAffidavit = response.Entity.Student_AdmissionDocuments_AntiRaggingAffidavit;
                    model.StudentRegistrationFormDTO.Student_AdmissionDocuments_Proforma_Fand_F1_On_DoctorsLetter_Head = response.Entity.Student_AdmissionDocuments_Proforma_Fand_F1_On_DoctorsLetter_Head;
                    model.StudentRegistrationFormDTO.Student_AdmissionDocuments_Proforma_I = response.Entity.Student_AdmissionDocuments_Proforma_I;
                    model.StudentRegistrationFormDTO.Student_AdmissionDocuments_ProformaG1 = response.Entity.Student_AdmissionDocuments_ProformaG1;
                    model.StudentRegistrationFormDTO.Student_AdmissionDocuments_ProformaG2 = response.Entity.Student_AdmissionDocuments_ProformaG2;
                    model.StudentRegistrationFormDTO.Student_AdmissionDocuments_Proforma_C_D_E = response.Entity.Student_AdmissionDocuments_Proforma_C_D_E;
                    model.StudentRegistrationFormDTO.Student_AdmissionDocuments_FathersIncomeCertificate = response.Entity.Student_AdmissionDocuments_FathersIncomeCertificate;
                    model.StudentRegistrationFormDTO.Student_AdmissionDocuments_AadharCardXerox = response.Entity.Student_AdmissionDocuments_AadharCardXerox;
                    model.StudentRegistrationFormDTO.Student_AdmissionDocuments_B_WPhoto_I_card_size = response.Entity.Student_AdmissionDocuments_B_WPhoto_I_card_size;
                    model.StudentRegistrationFormDTO.Student_AdmissionDocuments_Colour_photo = response.Entity.Student_AdmissionDocuments_Colour_photo;
                    model.StudentRegistrationFormDTO.SectionDetailsID = response.Entity.SectionDetailsID;

                    //For PG Students
                    model.StudentRegistrationFormDTO.Student_AdmissionDocuments_PGStudents_DegreeMarksheet = response.Entity.Student_AdmissionDocuments_PGStudents_DegreeMarksheet;
                    model.StudentRegistrationFormDTO.Student_AdmissionDocuments_PGStudents_DegreeCertificate = response.Entity.Student_AdmissionDocuments_PGStudents_DegreeCertificate;
                    model.StudentRegistrationFormDTO.Student_AdmissionDocuments_PGStudents_GateScoreCard = response.Entity.Student_AdmissionDocuments_PGStudents_GateScoreCard;
                    model.StudentRegistrationFormDTO.Student_AdmissionDocuments_PGStudents_SponsorshipLetterforSponsoredCandidate = response.Entity.Student_AdmissionDocuments_PGStudents_SponsorshipLetterforSponsoredCandidate;

                    model.StudentRegistrationFormDTO.Student_StudentCode = "STU" + response.Entity.Student_CourseYearName + model.StudentRegistrationFormDTO.ID;


                }

                #region Method
                //For Title
                List<SelectListItem> StudentRegistrationForm = new List<SelectListItem>();
                ViewBag.StudentRegistrationForm = new SelectList(StudentRegistrationForm, "Value", "Text");
                List<SelectListItem> li = new List<SelectListItem>();
                li.Add(new SelectListItem { Text = "Mr.", Value = "Mr." });
                li.Add(new SelectListItem { Text = "Mrs.", Value = "Mrs." });
                li.Add(new SelectListItem { Text = "Miss.", Value = "Miss." });
                ViewData["Title"] = li;

                //For NRI_POI
                List<SelectListItem> StudentRegistrationForm_NRI_POI = new List<SelectListItem>();
                ViewBag.StudentRegistrationForm_NRI_POI = new SelectList(StudentRegistrationForm_NRI_POI, "Value", "Text");
                List<SelectListItem> li_StudentRegistrationForm_NRI_POI = new List<SelectListItem>();
                li_StudentRegistrationForm_NRI_POI.Add(new SelectListItem { Text = "NONE", Value = "NONE" });
                li_StudentRegistrationForm_NRI_POI.Add(new SelectListItem { Text = "NRI", Value = "NRI" });
                li_StudentRegistrationForm_NRI_POI.Add(new SelectListItem { Text = "POI", Value = "POI" });
                ViewData["StudentNRI_POI"] = new SelectList(li_StudentRegistrationForm_NRI_POI, "Value", "Text", model.StudentRegistrationFormDTO.StudentNRI_POI);

                //For Fees payment details
                ViewData["FeesPaidBy"] = new SelectList(li_FeesPaidBy, "Value", "Text", response.Entity.FeesPaidBy);

                //For Academic Request Status
                List<SelectListItem> StudentRegistrationForm_AcademicRequestStatus = new List<SelectListItem>();
                ViewBag.StudentRegistrationForm_AcademicRequestStatus = new SelectList(StudentRegistrationForm_AcademicRequestStatus, "Value", "Text");
                List<SelectListItem> li_StudentRegistrationForm_AcademicRequestStatus = new List<SelectListItem>();
                li_StudentRegistrationForm_AcademicRequestStatus.Add(new SelectListItem { Text = "Accept", Value = "True" });
                li_StudentRegistrationForm_AcademicRequestStatus.Add(new SelectListItem { Text = "Reject", Value = "False" });
                ViewData["ApprovalStatus"] = li_StudentRegistrationForm_AcademicRequestStatus;

                //For Admitted Section details
                model.ListOrganisationSectionDetails = GetSectionDetailsRoleWise(Convert.ToInt32(model.StudentRegistrationFormDTO.SectionDetailsID), model.StudentRegistrationFormDTO.CenterCode, Convert.ToString(model.StudentRegistrationFormDTO.UniversityID), "false");

                foreach (var b in model.ListOrganisationSectionDetails)
                {
                    b.ID = b.ID;
                }

                //For Nationality

                List<GeneralNationalityMaster> generalNationalityMasterList = GetListGeneralNationalityMaster();
                List<SelectListItem> generalNationalityMaster = new List<SelectListItem>();
                foreach (GeneralNationalityMaster item in generalNationalityMasterList)
                {
                    generalNationalityMaster.Add(new SelectListItem { Text = item.Description, Value = item.ID.ToString() });
                }
                ViewBag.GeneralNationalityMaster = new SelectList(generalNationalityMaster, "Value", "Text");


                //For MaritalStatus
                List<SelectListItem> StudentRegistrationForm_StudentMaritalStatus = new List<SelectListItem>();
                ViewBag.StudentRegistrationForm_StudentMaritalStatus = new SelectList(StudentRegistrationForm_StudentMaritalStatus, "Value", "Text");
                List<SelectListItem> li_StudentRegistrationForm_StudentMaritalStatus = new List<SelectListItem>();
                li_StudentRegistrationForm_StudentMaritalStatus.Add(new SelectListItem { Text = "-- Select Marital Status -- ", Value = "N" });
                li_StudentRegistrationForm_StudentMaritalStatus.Add(new SelectListItem { Text = "UNMARRIED", Value = "U" });
                li_StudentRegistrationForm_StudentMaritalStatus.Add(new SelectListItem { Text = "MARRIED", Value = "M" });
                li_StudentRegistrationForm_StudentMaritalStatus.Add(new SelectListItem { Text = "DIVORCEE", Value = "D" });
                li_StudentRegistrationForm_StudentMaritalStatus.Add(new SelectListItem { Text = "WIDOW", Value = "W" });
                li_StudentRegistrationForm_StudentMaritalStatus.Add(new SelectListItem { Text = "JUDICIALLY SEPARETED", Value = "J" });
                ViewData["StudentMaritalStatus"] = new SelectList(li_StudentRegistrationForm_StudentMaritalStatus, "Value", "Text", model.StudentRegistrationFormDTO.StudentMaritalStatus);

                //For Blood Group
                List<SelectListItem> StudentRegistrationForm_StudentBloodGroup = new List<SelectListItem>();
                ViewBag.StudentRegistrationForm_StudentBloodGroup = new SelectList(StudentRegistrationForm_StudentBloodGroup, "Value", "Text");
                List<SelectListItem> li_StudentRegistrationForm_StudentBloodGroup = new List<SelectListItem>();
                li_StudentRegistrationForm_StudentBloodGroup.Add(new SelectListItem { Text = "-- Select Blood Group -- ", Value = "" });
                li_StudentRegistrationForm_StudentBloodGroup.Add(new SelectListItem { Text = "O-", Value = "O-" });
                li_StudentRegistrationForm_StudentBloodGroup.Add(new SelectListItem { Text = "O+", Value = "O+" });
                li_StudentRegistrationForm_StudentBloodGroup.Add(new SelectListItem { Text = "A-", Value = "A-" });
                li_StudentRegistrationForm_StudentBloodGroup.Add(new SelectListItem { Text = "A+", Value = "A+" });
                li_StudentRegistrationForm_StudentBloodGroup.Add(new SelectListItem { Text = "B-", Value = "B-" });
                li_StudentRegistrationForm_StudentBloodGroup.Add(new SelectListItem { Text = "B+", Value = "B+" });
                li_StudentRegistrationForm_StudentBloodGroup.Add(new SelectListItem { Text = "AB-", Value = "AB-" });
                li_StudentRegistrationForm_StudentBloodGroup.Add(new SelectListItem { Text = "AB+", Value = "AB+" });
                ViewData["StudentBloodGroup"] = new SelectList(li_StudentRegistrationForm_StudentBloodGroup, "Value", "Text", model.StudentRegistrationFormDTO.StudentBloodGroup);

                //For PhysicallyHandicapped

                ViewData["PhysicallyHandicapped"] = new SelectList(li_StudentRegistrationForm_StudentPhysicallyHandicapped, "Value", "Text", model.StudentRegistrationFormDTO.PhysicallyHandicapped);

                ViewData["StudentEmploymentStatus"] = new SelectList(li_StudentRegistrationForm_StudentPhysicallyHandicapped, "Value", "Text", model.StudentRegistrationFormDTO.StudentEmploymentStatus);

                ViewData["Student_Qualification_General_SingleAttempt"] = new SelectList(li_StudentRegistrationForm_StudentPhysicallyHandicapped, "Value", "Text", model.StudentRegistrationFormDTO.Student_Qualification_General_SingleAttempt);
                ViewData["Student_Qualification_SSC_SingleAttempt"] = new SelectList(li_StudentRegistrationForm_StudentPhysicallyHandicapped, "Value", "Text", model.StudentRegistrationFormDTO.Student_Qualification_SSC_SingleAttempt);
                ViewData["Student_Qualification_HSC_SingleAttempt"] = new SelectList(li_StudentRegistrationForm_StudentPhysicallyHandicapped, "Value", "Text", model.StudentRegistrationFormDTO.Student_Qualification_HSC_SingleAttempt);
                ViewData["Student_Qualification_Diploma_ITI_Details_SingleAttempt"] = new SelectList(li_StudentRegistrationForm_StudentPhysicallyHandicapped, "Value", "Text", model.StudentRegistrationFormDTO.Student_Qualification_Diploma_ITI_Details_SingleAttempt);
                ViewData["Student_Qualification_DegreeDetails_SingleAttempt"] = new SelectList(li_StudentRegistrationForm_StudentPhysicallyHandicapped, "Value", "Text", model.StudentRegistrationFormDTO.Student_Qualification_DegreeDetails_SingleAttempt);
                ViewData["Student_Qualification_PostGraduationDetails_SingleAttempt"] = new SelectList(li_StudentRegistrationForm_StudentPhysicallyHandicapped, "Value", "Text", model.StudentRegistrationFormDTO.Student_Qualification_PostGraduationDetails_SingleAttempt);
                //For Organ donor
                List<SelectListItem> StudentRegistrationForm_StudentOrgandonor = new List<SelectListItem>();
                ViewBag.StudentRegistrationForm_StudentOrgandonor = new SelectList(StudentRegistrationForm_StudentOrgandonor, "Value", "Text");
                List<SelectListItem> li_StudentRegistrationForm_StudentOrgandonor = new List<SelectListItem>();
                li_StudentRegistrationForm_StudentOrgandonor.Add(new SelectListItem { Text = "NO", Value = "0" });
                li_StudentRegistrationForm_StudentOrgandonor.Add(new SelectListItem { Text = "YES", Value = "1" });
                ViewData["StudentOrgandonor"] = new SelectList(li_StudentRegistrationForm_StudentOrgandonor, "Value", "Text", model.StudentRegistrationFormDTO.StudentOrgandonor);





                //For Religion
                List<GeneralReligionMaster> generalReligionMasterList = GetListGeneralReligionMaster();
                List<SelectListItem> generalReligionMaster = new List<SelectListItem>();
                foreach (GeneralReligionMaster item in generalReligionMasterList)
                {
                    generalReligionMaster.Add(new SelectListItem { Text = item.Description, Value = item.ID.ToString() });
                }
                ViewBag.GeneralReligionMaster = new SelectList(generalReligionMaster, "Value", "Text");

                //For Region
                int CountryId = 0;
                List<GeneralRegionMaster> generalRegionMasterList = GetListGeneralRegionMaster(Convert.ToString(CountryId));
                List<SelectListItem> generalRegionMaster = new List<SelectListItem>();
                // generalRegionMaster.Add(new SelectListItem { Text = "-- Select Region--", Value = "" });
                generalRegionMaster.Add(new SelectListItem { Text = "Other", Value = "Other" });
                foreach (GeneralRegionMaster item in generalRegionMasterList)
                {
                    generalRegionMaster.Add(new SelectListItem { Text = item.RegionName + " ( " + item.CountryName + " )", Value = item.ID.ToString() });
                }

                ViewBag.GeneralRegionMaster = new SelectList(generalRegionMaster, "Value", "Text");


                //For Student_PermanentAddress_State

                List<GeneralRegionMaster> generalRegionMasterListforPermanentAddress = GetListGeneralRegionMaster(Convert.ToString(model.StudentRegistrationFormDTO.Student_PermanentAddress_CountryId));
                List<SelectListItem> generalRegionMasterforPermanentAddress = new List<SelectListItem>();
                generalRegionMasterforPermanentAddress.Add(new SelectListItem { Text = "Other", Value = "Other" });
                foreach (GeneralRegionMaster item in generalRegionMasterListforPermanentAddress)
                {
                    generalRegionMasterforPermanentAddress.Add(new SelectListItem { Text = item.RegionName + " ( " + item.CountryName + " )", Value = item.ID.ToString() });
                }
                ViewBag.GeneralRegionMasterforPermanentAddress = new SelectList(generalRegionMasterforPermanentAddress, "Value", "Text");

                //Student_PermanentAddress_DistrictID
                // string SelectedRegionID = "A";

                List<GeneralCityMaster> GeneralCityMasterListforPermanentAddress = GetListGeneralCityMaster(Convert.ToString(model.StudentRegistrationFormDTO.Student_PermanentAddress_State));
                List<SelectListItem> GeneralCityMasterforPermanentAddress = new List<SelectListItem>();
                GeneralCityMasterforPermanentAddress.Add(new SelectListItem { Text = "Other", Value = "Other" });
                foreach (GeneralCityMaster item in GeneralCityMasterListforPermanentAddress)
                {
                    GeneralCityMasterforPermanentAddress.Add(new SelectListItem { Text = item.Description, Value = item.ID.ToString() });
                }

                ViewBag.GeneralCityListforPermanentAddress = new SelectList(GeneralCityMasterforPermanentAddress, "Value", "Text");

                //Student_PermanentAddress_CityID
                //List<GeneralLocationMaster> GeneralLocationMasterListforPermanentAddress = GetListGeneralLocationMasterByCityID(Convert.ToString(model.StudentRegistrationFormDTO.Student_PermanentAddress_DistrictID));
                //List<SelectListItem> GeneralLocationMasterforPermanentAddress = new List<SelectListItem>();
                //GeneralLocationMasterforPermanentAddress.Add(new SelectListItem { Text = "Other", Value = "Other" });
                //foreach (GeneralLocationMaster item in GeneralLocationMasterListforPermanentAddress)
                //{
                //    GeneralLocationMasterforPermanentAddress.Add(new SelectListItem { Text = item.LocationAddress, Value = item.ID.ToString() });
                //}

                //ViewBag.GeneralLocationListforPermanentAddress = new SelectList(GeneralLocationMasterforPermanentAddress, "Value", "Text");

                //For Student_CorrespondenceAddress_State

                List<GeneralRegionMaster> generalRegionMasterListforCorrespondenceAddress = GetListGeneralRegionMaster(Convert.ToString(model.StudentRegistrationFormDTO.Student_CorrespondenceAddress_CountryId));
                List<SelectListItem> generalRegionMasterforCorrespondenceAddress = new List<SelectListItem>();
                generalRegionMasterforCorrespondenceAddress.Add(new SelectListItem { Text = "Other", Value = "Other" });
                foreach (GeneralRegionMaster item in generalRegionMasterListforCorrespondenceAddress)
                {
                    generalRegionMasterforCorrespondenceAddress.Add(new SelectListItem { Text = item.RegionName + " ( " + item.CountryName + " )", Value = item.ID.ToString() });
                }
                ViewBag.GeneralRegionMasterforCorrespondenceAddress = new SelectList(generalRegionMasterforCorrespondenceAddress, "Value", "Text");

                //Student_CorrespondenceAddress_DistrictID
                // string SelectedRegionID = "A";

                List<GeneralCityMaster> GeneralCityMasterListforCorrespondenceAddress = GetListGeneralCityMaster(Convert.ToString(model.StudentRegistrationFormDTO.Student_CorrespondenceAddress_State));
                List<SelectListItem> GeneralCityMasterforCorrespondenceAddress = new List<SelectListItem>();
                GeneralCityMasterforCorrespondenceAddress.Add(new SelectListItem { Text = "Other", Value = "Other" });
                foreach (GeneralCityMaster item in GeneralCityMasterListforCorrespondenceAddress)
                {
                    GeneralCityMasterforCorrespondenceAddress.Add(new SelectListItem { Text = item.Description, Value = item.ID.ToString() });
                }

                ViewBag.GeneralCityListforCorrespondenceAddress = new SelectList(GeneralCityMasterforCorrespondenceAddress, "Value", "Text");

                //Student_CorrespondenceAddress_CityID
                //List<GeneralLocationMaster> GeneralLocationMasterListforCorrespondenceAddress = GetListGeneralLocationMasterByCityID(Convert.ToString(model.StudentRegistrationFormDTO.Student_CorrespondenceAddress_DistrictID));
                //List<SelectListItem> GeneralLocationMasterforCorrespondenceAddress = new List<SelectListItem>();
                //GeneralLocationMasterforCorrespondenceAddress.Add(new SelectListItem { Text = "Other", Value = "Other" });
                //foreach (GeneralLocationMaster item in GeneralLocationMasterListforCorrespondenceAddress)
                //{
                //    GeneralLocationMasterforCorrespondenceAddress.Add(new SelectListItem { Text = item.LocationAddress, Value = item.ID.ToString() });
                //}

                //ViewBag.GeneralLocationListforCorrespondenceAddress = new SelectList(GeneralLocationMasterforPermanentAddress, "Value", "Text");
                //For Category
                List<GeneralCategoryMaster> generalCategoryMasterList = GetListGeneralCategoryMaster();
                List<SelectListItem> generalCategoryMaster = new List<SelectListItem>();
                foreach (GeneralCategoryMaster item in generalCategoryMasterList)
                {
                    generalCategoryMaster.Add(new SelectListItem { Text = item.CategoryName + " ( " + item.CategoryType + " )", Value = item.ID.ToString() });
                }
                ViewBag.GeneralCategoryMaster = new SelectList(generalCategoryMaster, "Value", "Text");

                //For Caste
                //  int CategoryID = 0;

                List<GeneralCasteMaster> GeneralCasteMasterList = GetListGeneralCasteMaster(model.StudentRegistrationFormDTO.StudentCategoryID);
                List<SelectListItem> GeneralCasteMaster = new List<SelectListItem>();
                foreach (GeneralCasteMaster item in GeneralCasteMasterList)
                {
                    GeneralCasteMaster.Add(new SelectListItem { Text = item.CasteName, Value = item.ID.ToString() });
                }
                ViewBag.GeneralCasteMasterList = new SelectList(GeneralCasteMaster, "Value", "Text");

                //For Language
                List<GeneralLanguageMaster> generalLanguageMasterList = GetListGeneralLanguageMaster();
                List<SelectListItem> generalLanguageMaster = new List<SelectListItem>();
                foreach (GeneralLanguageMaster item in generalLanguageMasterList)
                {
                    generalLanguageMaster.Add(new SelectListItem { Text = item.LanguageName, Value = item.ID.ToString() });
                }
                ViewBag.GeneralLanguageMaster = new SelectList(generalLanguageMaster, "Value", "Text");

                //For AdmissionType
                List<OrganisationAdmissionTypeMaster> OrganisationAdmissionTypeMasterList = GetListOrganisationAdmissionTypeMaster();
                List<SelectListItem> OrganisationAdmissionTypeMaster = new List<SelectListItem>();
                foreach (OrganisationAdmissionTypeMaster item in OrganisationAdmissionTypeMasterList)
                {
                    OrganisationAdmissionTypeMaster.Add(new SelectListItem { Text = item.AdmissionType, Value = item.ID.ToString() });
                }
                ViewBag.OrganisationAdmissionTypeMaster = new SelectList(OrganisationAdmissionTypeMaster, "Value", "Text");

                //For AllotAdmission
                List<OrganisationAllotAdmissionMaster> OrganisationAllotAdmissionMasterList = GetListOrganisationAllotAdmissionMaster();
                List<SelectListItem> OrganisationAllotAdmissionMaster = new List<SelectListItem>();
                foreach (OrganisationAllotAdmissionMaster item in OrganisationAllotAdmissionMasterList)
                {
                    OrganisationAllotAdmissionMaster.Add(new SelectListItem { Text = item.AllotAdmission, Value = item.ID.ToString() });
                }
                ViewBag.OrganisationAllotAdmissionMaster = new SelectList(OrganisationAllotAdmissionMaster, "Value", "Text");

                //For EconomicallyBackwardClass 
                List<SelectListItem> StudentRegistrationForm_StudentEconomicallyBackwardClass = new List<SelectListItem>();
                ViewBag.StudentRegistrationForm_StudentEconomicallyBackwardClass = new SelectList(StudentRegistrationForm_StudentEconomicallyBackwardClass, "Value", "Text");
                List<SelectListItem> li_StudentRegistrationForm_StudentEconomicallyBackwardClass = new List<SelectListItem>();
                li_StudentRegistrationForm_StudentEconomicallyBackwardClass.Add(new SelectListItem { Text = "NO", Value = "0" });
                li_StudentRegistrationForm_StudentEconomicallyBackwardClass.Add(new SelectListItem { Text = "YES", Value = "1" });
                ViewData["StudentEconomicallyBackwardClass"] = new SelectList(li_StudentRegistrationForm_StudentEconomicallyBackwardClass, "Value", "Text", model.StudentRegistrationFormDTO.StudentEconomicallyBackwardClass);

                //for Country 
                List<GeneralCountryMaster> GeneralCountryMasterList = GetListGeneralCountryMaster();
                List<SelectListItem> GeneralCountryMaster = new List<SelectListItem>();
                foreach (GeneralCountryMaster item in GeneralCountryMasterList)
                {
                    GeneralCountryMaster.Add(new SelectListItem { Text = item.CountryName, Value = item.ID.ToString() });
                }

                ViewBag.GeneralCountryList = new SelectList(GeneralCountryMaster, "Value", "Text");


                //for Region  Perticular Country
                string SelectedCountryID = string.Empty;
                //   List<GeneralRegionMaster> generalRegionMasterForPerticularCountryList = GetListGeneralRegionMaster(SelectedCountryID);
                List<SelectListItem> generalRegionMasterForPerticularCountry = new List<SelectListItem>();
                //foreach (GeneralRegionMaster item in generalRegionMasterForPerticularCountryList)
                //{
                //    generalRegionMasterForPerticularCountry.Add(new SelectListItem { Text = item.RegionName, Value = item.ID.ToString() });
                //}
                ViewBag.GeneralRegionMasterForPerticularCountry = new SelectList(generalRegionMaster, "Value", "Text");


                //List<SelectListItem> GeneralBlankRegionMaster = new List<SelectListItem>();
                ////foreach (GeneralCityMaster item in GeneralCityMasterList)
                ////{
                ////    GeneralCityMaster.Add(new SelectListItem { Text = item.Description, Value = item.ID.ToString() });
                ////}

                //ViewBag.GeneralBlankRegionMasterList = new SelectList(GeneralBlankRegionMaster, "Value", "Text");

                ////for City  
                //// string SelectedRegionID = "A";

                //// List<GeneralCityMaster> GeneralCityMasterList = GetListGeneralCityMaster(SelectedRegionID);
                //List<SelectListItem> GeneralCityMaster = new List<SelectListItem>();
                ////foreach (GeneralCityMaster item in GeneralCityMasterList)
                ////{
                ////    GeneralCityMaster.Add(new SelectListItem { Text = item.Description, Value = item.ID.ToString() });
                ////}

                //ViewBag.GeneralCityList = new SelectList(GeneralCityMaster, "Value", "Text");


                //List<SelectListItem> GeneralLocationMaster = new List<SelectListItem>();
                //ViewBag.GeneralLocationList = new SelectList(GeneralLocationMaster, "Value", "Text");


                //For City_Tahsil_Pattern
                List<SelectListItem> StudentRegistrationForm_PermanentAddress_City_Tahsil_Pattern = new List<SelectListItem>();
                ViewBag.StudentRegistrationForm_PermanentAddress_City_Tahsil_Pattern = new SelectList(StudentRegistrationForm_PermanentAddress_City_Tahsil_Pattern, "Value", "Text");
                List<SelectListItem> li_StudentRegistrationForm_PermanentAddress_City_Tahsil_Pattern = new List<SelectListItem>();
                li_StudentRegistrationForm_PermanentAddress_City_Tahsil_Pattern.Add(new SelectListItem { Text = "Urban", Value = "U" });
                li_StudentRegistrationForm_PermanentAddress_City_Tahsil_Pattern.Add(new SelectListItem { Text = "Rural", Value = "R" });
                li_StudentRegistrationForm_PermanentAddress_City_Tahsil_Pattern.Add(new SelectListItem { Text = "Tribal", Value = "T" });
                ViewData["Student_PermanentAddress_City_Tahsil_Pattern"] = new SelectList(li_StudentRegistrationForm_PermanentAddress_City_Tahsil_Pattern, "Value", "Text", model.StudentRegistrationFormDTO.Student_PermanentAddress_City_Tahsil_Pattern);

                ViewData["Student_CorrespondenceAddress_City_Tahsil_Pattern"] = new SelectList(li_StudentRegistrationForm_PermanentAddress_City_Tahsil_Pattern, "Value", "Text", model.StudentRegistrationFormDTO.Student_CorrespondenceAddress_City_Tahsil_Pattern);
                //For Exam_Pattern
                List<SelectListItem> StudentRegistrationForm_Exam_Pattern = new List<SelectListItem>();
                ViewBag.StudentRegistrationForm_Exam_Pattern = new SelectList(StudentRegistrationForm_Exam_Pattern, "Value", "Text");
                List<SelectListItem> li_StudentRegistrationForm_Exam_Pattern = new List<SelectListItem>();
                li_StudentRegistrationForm_Exam_Pattern.Add(new SelectListItem { Text = "Yearly", Value = "Y" });
                li_StudentRegistrationForm_Exam_Pattern.Add(new SelectListItem { Text = "Semester", Value = "S" });
                ViewData["Student_Qualification_Diploma_ITI_Details_ExamPattern"] = new SelectList(li_StudentRegistrationForm_Exam_Pattern, "Value", "Text", model.StudentRegistrationFormDTO.Student_Qualification_Diploma_ITI_Details_ExamPattern);
                ViewData["Student_Qualification_DegreeDetails_ExamPattern"] = new SelectList(li_StudentRegistrationForm_Exam_Pattern, "Value", "Text", model.StudentRegistrationFormDTO.Student_Qualification_DegreeDetails_ExamPattern);
                ViewData["Student_Qualification_PostGraduationDetails_ExamPattern"] = new SelectList(li_StudentRegistrationForm_Exam_Pattern, "Value", "Text", model.StudentRegistrationFormDTO.Student_Qualification_PostGraduationDetails_ExamPattern);
                //For FatherHusband
                List<SelectListItem> StudentRegistrationForm_FatherHusband = new List<SelectListItem>();
                ViewBag.StudentRegistrationForm_FatherHusband = new SelectList(StudentRegistrationForm_FatherHusband, "Value", "Text");
                List<SelectListItem> li_StudentRegistrationForm_FatherHusband = new List<SelectListItem>();
                li_StudentRegistrationForm_FatherHusband.Add(new SelectListItem { Text = "Father", Value = "F" });
                li_StudentRegistrationForm_FatherHusband.Add(new SelectListItem { Text = "Husband", Value = "H" });
                ViewData["StudentRegistrationForm_FatherHusband"] = li_StudentRegistrationForm_FatherHusband;

                //For Qualification_General_MediumOfInstitution

                List<OrganisationMediumMaster> organisationMediumMasterList = GetListOrganisationMediumMaster();
                List<SelectListItem> organisationMediumMaster = new List<SelectListItem>();
                foreach (OrganisationMediumMaster item in organisationMediumMasterList)
                {
                    organisationMediumMaster.Add(new SelectListItem { Text = item.Description, Value = item.ID.ToString() });
                }
                ViewBag.organisationMediumMaster = new SelectList(organisationMediumMaster, "Value", "Text");

                //For Month
                List<SelectListItem> Student_Qualification_General_MonthOfPassing = new List<SelectListItem>();
                ViewBag.Student_Qualification_General_MonthOfPassing = new SelectList(Student_Qualification_General_MonthOfPassing, "Value", "Text");
                List<SelectListItem> li_Student_Qualification_General_MonthOfPassing = new List<SelectListItem>();
                li_Student_Qualification_General_MonthOfPassing.Add(new SelectListItem { Text = "-- Select Month --", Value = "0" });
                li_Student_Qualification_General_MonthOfPassing.Add(new SelectListItem { Text = "January", Value = "1" });
                li_Student_Qualification_General_MonthOfPassing.Add(new SelectListItem { Text = "February", Value = "2" });
                li_Student_Qualification_General_MonthOfPassing.Add(new SelectListItem { Text = "March", Value = "3" });
                li_Student_Qualification_General_MonthOfPassing.Add(new SelectListItem { Text = "April", Value = "4" });
                li_Student_Qualification_General_MonthOfPassing.Add(new SelectListItem { Text = "May", Value = "5" });
                li_Student_Qualification_General_MonthOfPassing.Add(new SelectListItem { Text = "June", Value = "6" });
                li_Student_Qualification_General_MonthOfPassing.Add(new SelectListItem { Text = "July", Value = "7" });
                li_Student_Qualification_General_MonthOfPassing.Add(new SelectListItem { Text = "August", Value = "8" });
                li_Student_Qualification_General_MonthOfPassing.Add(new SelectListItem { Text = "September", Value = "9" });
                li_Student_Qualification_General_MonthOfPassing.Add(new SelectListItem { Text = "October", Value = "10" });
                li_Student_Qualification_General_MonthOfPassing.Add(new SelectListItem { Text = "November", Value = "11" });
                li_Student_Qualification_General_MonthOfPassing.Add(new SelectListItem { Text = "December", Value = "12" });
                ViewData["Student_Qualification_General_MonthOfPassing"] = new SelectList(li_Student_Qualification_General_MonthOfPassing, "Value", "Text", model.StudentRegistrationFormDTO.Student_Qualification_General_MonthOfPassing);
                ViewData["Student_Qualification_SSC_MonthOfPassing"] = new SelectList(li_Student_Qualification_General_MonthOfPassing, "Value", "Text", model.StudentRegistrationFormDTO.Student_Qualification_SSC_MonthOfPassing);
                ViewData["Student_Qualification_HSC_MonthOfPassing"] = new SelectList(li_Student_Qualification_General_MonthOfPassing, "Value", "Text", model.StudentRegistrationFormDTO.Student_Qualification_HSC_MonthOfPassing);
                ViewData["Student_Qualification_Diploma_ITI_Details_MonthOfPassing"] = new SelectList(li_Student_Qualification_General_MonthOfPassing, "Value", "Text", model.StudentRegistrationFormDTO.Student_Qualification_Diploma_ITI_Details_MonthOfPassing);
                ViewData["Student_Qualification_DegreeDetails_MonthOfPassing"] = new SelectList(li_Student_Qualification_General_MonthOfPassing, "Value", "Text", model.StudentRegistrationFormDTO.Student_Qualification_DegreeDetails_MonthOfPassing);
                ViewData["Student_Qualification_PostGraduationDetails_MonthOfPassing"] = new SelectList(li_Student_Qualification_General_MonthOfPassing, "Value", "Text", model.StudentRegistrationFormDTO.Student_Qualification_PostGraduationDetails_MonthOfPassing);

                //For Year
                int year = DateTime.Now.Year - 65;
                List<SelectListItem> Student_Qualification_General_YearOfPassing = new List<SelectListItem>();
                ViewBag.Student_Qualification_General_YearOfPassing = new SelectList(Student_Qualification_General_YearOfPassing, "Value", "Text");
                List<SelectListItem> li_Student_Qualification_General_YearOfPassing = new List<SelectListItem>();

                li_Student_Qualification_General_YearOfPassing.Add(new SelectListItem { Text = "-- Select Year --", Value = "0" });
                for (int i = DateTime.Now.Year; year <= i; i--)
                {
                    li_Student_Qualification_General_YearOfPassing.Add(new SelectListItem { Text = Convert.ToString(i), Value = Convert.ToString(i) });
                }
                ViewData["Student_Qualification_General_YearOfPassing"] = new SelectList(li_Student_Qualification_General_YearOfPassing, "Value", "Text", model.StudentRegistrationFormDTO.Student_Qualification_General_YearOfPassing);
                ViewData["Student_Qualification_SSC_YearOfPassing"] = new SelectList(li_Student_Qualification_General_YearOfPassing, "Value", "Text", model.StudentRegistrationFormDTO.Student_Qualification_SSC_YearOfPassing);
                ViewData["Student_Qualification_HSC_YearOfPassing"] = new SelectList(li_Student_Qualification_General_YearOfPassing, "Value", "Text", model.StudentRegistrationFormDTO.Student_Qualification_HSC_YearOfPassing);
                ViewData["Student_Qualification_Diploma_ITI_Details_YearOfPassing"] = new SelectList(li_Student_Qualification_General_YearOfPassing, "Value", "Text", model.StudentRegistrationFormDTO.Student_Qualification_Diploma_ITI_Details_YearOfPassing);
                ViewData["Student_Qualification_DegreeDetails_YearOfPassing"] = new SelectList(li_Student_Qualification_General_YearOfPassing, "Value", "Text", model.StudentRegistrationFormDTO.Student_Qualification_DegreeDetails_YearOfPassing);
                ViewData["Student_Qualification_PostGraduationDetails_YearOfPassing"] = new SelectList(li_Student_Qualification_General_YearOfPassing, "Value", "Text", model.StudentRegistrationFormDTO.Student_Qualification_PostGraduationDetails_YearOfPassing);


                //For For Count Number
                List<SelectListItem> StudentRegistrationForm_NumberList = new List<SelectListItem>();
                ViewBag.StudentRegistrationForm_Number = new SelectList(StudentRegistrationForm_NumberList, "Value", "Text");
                List<SelectListItem> li_StudentRegistrationForm_Number = new List<SelectListItem>();

                li_StudentRegistrationForm_Number.Add(new SelectListItem { Text = "-- Select --", Value = "" });
                for (int i = 1; i <= 10; i++)
                {
                    li_StudentRegistrationForm_Number.Add(new SelectListItem { Text = Convert.ToString(i), Value = Convert.ToString(i) });
                }
                ViewData["StudentRegistrationForm_Number"] = li_StudentRegistrationForm_Number;

                //For University

                List<OrganisationUniversityMaster> OrganisationUniversityMasterList = GetListOrganisationUniversityMasterWithoutCenterCode();
                List<SelectListItem> OrganisationUniversityMaster = new List<SelectListItem>();
                foreach (OrganisationUniversityMaster item in OrganisationUniversityMasterList)
                {
                    OrganisationUniversityMaster.Add(new SelectListItem { Text = item.UniversityName, Value = item.ID.ToString() });
                }
                OrganisationUniversityMaster.Add(new SelectListItem { Text = "Other", Value = "Other" });
                ViewBag.OrganisationUniversityMasterList = new SelectList(OrganisationUniversityMaster, "Value", "Text");


                //For Stream

                List<OrganisationStreamMaster> OrganisationStreamMasterMasterList = GetListOrganisationStreamMaster();
                List<SelectListItem> OrganisationStreamMasterMaster = new List<SelectListItem>();
                foreach (OrganisationStreamMaster item in OrganisationStreamMasterMasterList)
                {
                    OrganisationStreamMasterMaster.Add(new SelectListItem { Text = item.StreamDescription, Value = item.ID.ToString() });
                }
                //  OrganisationStreamMasterMaster.Add(new SelectListItem { Text = "Other", Value = "Other" });
                ViewBag.OrganisationStreamMasterMasterList = new SelectList(OrganisationStreamMasterMaster, "Value", "Text");

                //For Class
                List<SelectListItem> StudentRegistrationForm_Class = new List<SelectListItem>();
                ViewBag.StudentRegistrationForm_Class = new SelectList(StudentRegistrationForm_Class, "Value", "Text");
                List<SelectListItem> li_StudentRegistrationForm_Class = new List<SelectListItem>();
                li_StudentRegistrationForm_Class.Add(new SelectListItem { Text = "First", Value = "1" });
                li_StudentRegistrationForm_Class.Add(new SelectListItem { Text = "Second", Value = "2" });
                li_StudentRegistrationForm_Class.Add(new SelectListItem { Text = "Third", Value = "3" });
                li_StudentRegistrationForm_Class.Add(new SelectListItem { Text = "Fourth", Value = "4" });
                ViewData["Student_Qualification_HSC_Class"] = new SelectList(li_StudentRegistrationForm_Class, "Value", "Text", model.StudentRegistrationFormDTO.Student_Qualification_HSC_Class);
                ViewData["Student_Qualification_Diploma_ITI_Details_Class"] = new SelectList(li_StudentRegistrationForm_Class, "Value", "Text", model.StudentRegistrationFormDTO.Student_Qualification_Diploma_ITI_Details_Class);
                ViewData["Student_Qualification_DegreeDetails_Class"] = new SelectList(li_StudentRegistrationForm_Class, "Value", "Text", model.StudentRegistrationFormDTO.Student_Qualification_DegreeDetails_Class);
                ViewData["Student_Qualification_PostGraduationDetails_Class"] = new SelectList(li_StudentRegistrationForm_Class, "Value", "Text", model.StudentRegistrationFormDTO.Student_Qualification_PostGraduationDetails_Class);
                #endregion Method
                model.StudentRegistrationFormList = GetListStudentRegistrationForm(model.StudentRegistrationFormDTO.CenterCode, model.StudentRegistrationFormDTO.UniversityID, model.StudentRegistrationFormDTO.BranchDetailID, model.StudentRegistrationFormDTO.StandardNumber);


                List<ToolTemplateApplicable> organisationBranchDetailList = GetListBranchDetails(model.StudentRegistrationFormDTO.UniversityID, model.StudentRegistrationFormDTO.CenterCode);
                List<SelectListItem> organisationBranchDetail = new List<SelectListItem>();
                foreach (ToolTemplateApplicable item in organisationBranchDetailList)
                {
                    organisationBranchDetail.Add(new SelectListItem { Text = item.BranchDescription + "(" + item.DivisionDescription + ")", Value = item.BranchDetailID.ToString() });
                }
                ViewBag.organisationBranchDetail = new SelectList(organisationBranchDetail, "Value", "Text");

                //// For Qualifying Exam
                //List<StudentRegistrationForm> studentRegistrationFormQualifyingExamList = GetListStudentRegistrationFormQualifyingExamList(model.StudentRegistrationFormDTO.BranchDetailID, model.StudentRegistrationFormDTO.StandardNumber);
                //List<SelectListItem> studentRegistrationFormQualifyingExam = new List<SelectListItem>();
                //foreach (StudentRegistrationForm item in studentRegistrationFormQualifyingExamList)
                //{
                //    studentRegistrationFormQualifyingExam.Add(new SelectListItem { Text = item.Student_QualifyingExamName, Value = item.Student_QualifyingExamId.ToString() });
                //}
                //ViewBag.studentRegistrationFormQualifyingExamList = new SelectList(studentRegistrationFormQualifyingExam, "Value", "Text");
                //  For Qualifying Exam Subject
                model.QualifyingExamSubjectList = GetListQualifyingExamSubject(model.StudentRegistrationFormDTO.ID);

                // For Qualification Exam Subject   for General
                model.QualificationMasterSubjectListForGeneral = GetByQualificationSubjectListByStudentRegistrationIDAndEducationType(model.StudentRegistrationFormDTO.ID, "G");

                // For Qualification Exam Subject   for SSC
                model.QualificationMasterSubjectListForSSC = GetByQualificationSubjectListByStudentRegistrationIDAndEducationType(model.StudentRegistrationFormDTO.ID, "S");

                // For Qualification Exam Subject   for HSC
                model.QualificationMasterSubjectListForHSC = GetByQualificationSubjectListByStudentRegistrationIDAndEducationType(model.StudentRegistrationFormDTO.ID, "H");
                // for Academic year
                List<OrganisationCentrewiseSession> list = GetCurrentSession(model.StudentRegistrationFormDTO.CenterCode);
                model.Student_AcademicYear = list.Count > 0 ? list[0].SessionName : "Session not defined !";
                model.Student_AcademicYearId = list.Count > 0 ? list[0].SessionID : 0;

                //  For Course year 
                model.OrganisationCourseYearDetailsDTO = GetCourseYearByBranchDetIDAndStandardNumber(model.BranchDetailID, model.StandardNumber);
                if (model.OrganisationCourseYearDetailsDTO.Description == "" || model.OrganisationCourseYearDetailsDTO.Description == null)
                {
                    model.Student_CourseYearName = "";
                }
                else
                {
                    model.Student_CourseYearName = model.OrganisationCourseYearDetailsDTO.Description;
                }
                if (model.OrganisationCourseYearDetailsDTO.Description == "" || model.OrganisationCourseYearDetailsDTO.Description == null)
                {
                    model.Student_CourseYearId = 0;
                }
                else
                {
                    model.Student_CourseYearId = model.OrganisationCourseYearDetailsDTO.ID;
                }

                // for previous work experience
                model.PreviousWorkExperienceList = GetPreviousWorkExperience(model.StudentRegistrationFormDTO.ID);

                ////For Branch Details
                model.OrganisationBranchDetailsDTO = GetOrganisationBranchDetailsSelectByID(model.BranchDetailID);
                model.Student_CourseName = model.OrganisationBranchDetailsDTO.BranchDescription;

                ////For Task Approval               
                //model.TaskCode = TaskCode;
                //model.TaskNotificationDetailsID = Convert.ToInt32(TNDID);
                //model.TaskNotificationMasterID = Convert.ToInt32(TNMID);
                //model.GeneralTaskReportingDetailsID = Convert.ToInt32(GTRDID1);
                //model.PersonID = Convert.ToInt32(PersonID);
                //model.StageSequenceNumber = Convert.ToInt32(StageSequenceNumber);
                //model.IsLastRecord = Convert.ToBoolean(IsLast);


                // GeneralTaskReportingDetails GeneralTaskReportingDetailsDTO = new GeneralTaskReportingDetails();
                //GeneralTaskReportingDetailsDTO.TaskNotificationMasterID = model.TaskNotificationMasterID;
                //GeneralTaskReportingDetailsDTO.ModifiedBy = Convert.ToInt32(Session["UserID"]);
                //GeneralTaskReportingDetailsDTO.ConnectionString = _connectioString;
                //IBaseEntityResponse<GeneralTaskReportingDetails> response1 = _generalTaskReportingDetailsServiceAccess.UpdateEnagedByUserID(GeneralTaskReportingDetailsDTO);
                //model.StudentRegistrationFormDTO.errorMessage = CheckError((response1.Entity != null) ? response1.Entity.ErrorCode : 20, ActionModeEnum.Update);
                return View("/Views/StudentRegistrationForm/ViewDetailsV2.cshtml", model);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet]
        public ActionResult Edit(string status)
        {
            StudentRegistrationFormViewModel model = new StudentRegistrationFormViewModel();
            try
            {
                model.StudentRegistrationFormDTO = new StudentRegistrationForm();
                model.StudentRegistrationFormDTO.ID = Convert.ToInt32(Session["StudentRegistrationMasterID"]);
                model.StudentRegistrationFormDTO.AuthorisationType = "Academic";
                model.StudentRegistrationFormDTO.ConnectionString = _connectioString;

                List<SelectListItem> StudentRegistrationForm_StudentPhysicallyHandicapped = new List<SelectListItem>();
                ViewBag.StudentRegistrationForm_StudentPhysicallyHandicapped = new SelectList(StudentRegistrationForm_StudentPhysicallyHandicapped, "Value", "Text");
                List<SelectListItem> li_StudentRegistrationForm_StudentPhysicallyHandicapped = new List<SelectListItem>();
                li_StudentRegistrationForm_StudentPhysicallyHandicapped.Add(new SelectListItem { Text = "NO", Value = "0" });
                li_StudentRegistrationForm_StudentPhysicallyHandicapped.Add(new SelectListItem { Text = "YES", Value = "1" });

                //For Fees Payment Details
                List<SelectListItem> li_FeesPaidBy = new List<SelectListItem>();
                li_FeesPaidBy.Add(new SelectListItem { Text = "You", Value = "1" });
                li_FeesPaidBy.Add(new SelectListItem { Text = "Family", Value = "2" });
                li_FeesPaidBy.Add(new SelectListItem { Text = "Employer", Value = "3" });
                li_FeesPaidBy.Add(new SelectListItem { Text = "Research Council", Value = "4" });
                li_FeesPaidBy.Add(new SelectListItem { Text = "Other external Sponsor", Value = "5" });
                


                IBaseEntityResponse<StudentRegistrationForm> response = _StudentRegistrationFormServiceAccess.SelectByID(model.StudentRegistrationFormDTO);
                if (response != null && response.Entity != null)
                {
                    model.StudentRegistrationFormDTO.ID = response.Entity.ID;
                    model.StudentRegistrationFormDTO.ReasonIfRejected = response.Entity.ReasonIfRejected;
                    //model.StudentRegistrationFormDTO.RegistrationID = response.Entity.RegistrationID;
                    model.StudentRegistrationFormDTO.Student_DateofRegistration = response.Entity.Student_DateofRegistration;
                    model.StudentRegistrationFormDTO.StudentTitle = response.Entity.StudentTitle;
                    model.StudentRegistrationFormDTO.StudentFirstName = response.Entity.StudentFirstName;
                    model.StudentRegistrationFormDTO.StudentMiddleName = response.Entity.StudentMiddleName;
                    model.StudentRegistrationFormDTO.StudentLastName = response.Entity.StudentLastName;
                    model.StudentRegistrationFormDTO.MotherFirstName = response.Entity.MotherFirstName;
                    model.StudentRegistrationFormDTO.StudentMobileNumber = response.Entity.StudentMobileNumber;
                    model.StudentRegistrationFormDTO.FatherMobileNumber = response.Entity.FatherMobileNumber;
                    model.StudentRegistrationFormDTO.GuardianMobileNumber = response.Entity.GuardianMobileNumber;
                    model.StudentRegistrationFormDTO.FatherLandLineNumber = response.Entity.FatherLandLineNumber;
                    model.StudentRegistrationFormDTO.FatherEmailId = response.Entity.FatherEmailId;
                    model.StudentRegistrationFormDTO.GuardianEmailId = response.Entity.GuardianEmailId;
                    model.StudentRegistrationFormDTO.FatherEmailId = response.Entity.FatherEmailId;
                    model.StudentRegistrationFormDTO.MotherEmailId = response.Entity.MotherEmailId;
                    model.StudentRegistrationFormDTO.StudentEmailID = response.Entity.StudentEmailID;

                    model.StudentRegistrationFormDTO.StudentNameAsPerMarkSheet = response.Entity.StudentNameAsPerMarkSheet;
                    model.StudentRegistrationFormDTO.StudentLastSchool_College = response.Entity.StudentLastSchool_College;
                    model.StudentRegistrationFormDTO.StudentPreviousLC_TCNo = response.Entity.StudentPreviousLC_TCNo;
                    model.StudentRegistrationFormDTO.StudentCasteAsPerTC_LC = response.Entity.StudentCasteAsPerTC_LC;
                    model.StudentRegistrationFormDTO.StudentEnrollmentNo = response.Entity.StudentEnrollmentNo;
                    model.StudentRegistrationFormDTO.StudentRegionID = response.Entity.StudentRegionID;
                    model.StudentRegistrationFormDTO.Student_Domesile_CountryId = response.Entity.Student_Domesile_CountryId;
                    model.StudentRegistrationFormDTO.StudentRegionOther = response.Entity.StudentRegionOther;
                    model.StudentRegistrationFormDTO.StudentMigrationNumber = response.Entity.StudentMigrationNumber;

                    model.StudentRegistrationFormDTO.StudentMigrationDate = response.Entity.StudentMigrationDate;

                    model.StudentRegistrationFormDTO.Student_DTE_AdmissionCategoryId = response.Entity.Student_DTE_AdmissionCategoryId;
                    model.StudentRegistrationFormDTO.Student_DTE_AdmissionTypeId = response.Entity.Student_DTE_AdmissionTypeId;
                    // ,[IsHostelResidency]
                    model.StudentRegistrationFormDTO.BranchDetailID = response.Entity.BranchDetailID;
                    model.StudentRegistrationFormDTO.StandardNumber = response.Entity.StandardNumber;
                    model.StudentRegistrationFormDTO.AdmissionPattern = response.Entity.AdmissionPattern;
                    // ,[StudentActiveFlag]
                    //,[AcademicYearID]
                    model.StudentRegistrationFormDTO.CenterCode = response.Entity.CenterCode;
                    model.StudentRegistrationFormDTO.UniversityID = response.Entity.UniversityID;

                    model.StudentRegistrationFormDTO.StudentNRI_POI = response.Entity.StudentNRI_POI;

                    model.StudentRegistrationFormDTO.NameOfApplicant = response.Entity.NameOfApplicant;
                    model.StudentRegistrationFormDTO.TitleOfProject = response.Entity.TitleOfProject;
                    model.StudentRegistrationFormDTO.ProjectSummary = response.Entity.ProjectSummary;

                    //,[AllotAdmThrough]
                    //,[BankAccountNumber]
                    //,[BankBranchName]
                    //,[BankIFSCCode]
                    //,[BankMICRCode]
                    model.StudentRegistrationFormDTO.Student_Scholarship_AadhaarCardNo = response.Entity.Student_Scholarship_AadhaarCardNo;

                    //,[IdentificationType]

                    model.StudentRegistrationFormDTO.StudentPhoto = response.Entity.StudentPhoto;
                    model.StudentRegistrationFormDTO.StudentSignature = response.Entity.StudentSignature;
                    model.StudentRegistrationFormDTO.StudentThumb = response.Entity.StudentThumb;

                    model.StudentRegistrationFormDTO.StudentPhotoFileSize = response.Entity.StudentPhotoFileSize;
                    model.StudentRegistrationFormDTO.StudentSignatureFileSize = response.Entity.StudentSignatureFileSize;
                    model.StudentRegistrationFormDTO.StudentThumbFileSize = response.Entity.StudentThumbFileSize;


                    model.StudentRegistrationFormDTO.StudentPhotoType = response.Entity.StudentPhotoType;
                    model.StudentRegistrationFormDTO.StudentPhotoFilename = response.Entity.StudentPhotoFilename;
                    model.StudentRegistrationFormDTO.StudentPhotoFileWidth = response.Entity.StudentPhotoFileWidth;
                    model.StudentRegistrationFormDTO.StudentPhotoFileHeight = response.Entity.StudentPhotoFileHeight;

                    model.StudentRegistrationFormDTO.StudentSignatureType = response.Entity.StudentSignatureType;
                    model.StudentRegistrationFormDTO.StudentSignatureFilename = response.Entity.StudentSignatureFilename;
                    model.StudentRegistrationFormDTO.StudentSignatureFileWidth = response.Entity.StudentSignatureFileWidth;
                    model.StudentRegistrationFormDTO.StudentSignatureFileHeight = response.Entity.StudentSignatureFileHeight;

                    model.StudentRegistrationFormDTO.StudentThumbType = response.Entity.StudentThumbType;
                    model.StudentRegistrationFormDTO.StudentThumbFilename = response.Entity.StudentThumbFilename;
                    model.StudentRegistrationFormDTO.StudentThumbFileWidth = response.Entity.StudentThumbFileWidth;
                    model.StudentRegistrationFormDTO.StudentThumbFileHeight = response.Entity.StudentThumbFileHeight;


                    model.StudentRegistrationFormDTO.StudentDateofBirth = response.Entity.StudentDateofBirth;
                    model.StudentRegistrationFormDTO.StudentBirthPlace = response.Entity.StudentBirthPlace;
                    model.StudentRegistrationFormDTO.StudentGender = response.Entity.StudentGender;
                    model.StudentRegistrationFormDTO.StudentMaritalStatus = response.Entity.StudentMaritalStatus;
                    model.StudentRegistrationFormDTO.StudentNationalityID = response.Entity.StudentNationalityID;
                    model.StudentRegistrationFormDTO.StudentReligionID = response.Entity.StudentReligionID;
                    model.StudentRegistrationFormDTO.StudentMotherTongueID = response.Entity.StudentMotherTongueID;
                    model.StudentRegistrationFormDTO.StudentCategoryID = response.Entity.StudentCategoryID;
                    model.StudentRegistrationFormDTO.StudentCasteID = response.Entity.StudentCasteID;

                    //,C.SubCasteId
                    model.StudentRegistrationFormDTO.StudentBloodGroup = response.Entity.StudentBloodGroup;
                    model.StudentRegistrationFormDTO.StudentLandLineNumber = response.Entity.StudentLandLineNumber;
                    model.StudentRegistrationFormDTO.StudentIdentificationMark = response.Entity.StudentIdentificationMark;
                    model.StudentRegistrationFormDTO.StudentEmploymentSector = response.Entity.StudentEmploymentSector;
                    model.StudentRegistrationFormDTO.StudentOccupation = response.Entity.StudentOccupation;
                    model.StudentRegistrationFormDTO.StudentDesignation = response.Entity.StudentDesignation;
                    model.StudentRegistrationFormDTO.StudentOrganizationName = response.Entity.StudentOrganizationName;
                    model.StudentRegistrationFormDTO.StudentOfficeContactNo = response.Entity.StudentOfficeContactNo;
                    model.StudentRegistrationFormDTO.StudentAnnualIncome = response.Entity.StudentAnnualIncome;
                    if (response.Entity.PhysicallyHandicapped == "False")
                    {
                        model.StudentRegistrationFormDTO.PhysicallyHandicapped = "0";
                    }
                    else
                    {
                        model.StudentRegistrationFormDTO.PhysicallyHandicapped = "1";
                    }
                    if (response.Entity.StudentOrgandonor == "False")
                    {
                        model.StudentRegistrationFormDTO.StudentOrgandonor = "0";
                    }
                    else
                    {
                        model.StudentRegistrationFormDTO.StudentOrgandonor = "1";
                    }


                    model.StudentRegistrationFormDTO.StudentPrevNameofStudent = response.Entity.StudentPrevNameofStudent;
                    model.StudentRegistrationFormDTO.StudentReasonforNamechange = response.Entity.StudentReasonforNamechange;
                    if (response.Entity.StudentEmploymentStatus == "False")
                    {
                        model.StudentRegistrationFormDTO.StudentEmploymentStatus = "0";
                    }
                    else
                    {
                        model.StudentRegistrationFormDTO.StudentEmploymentStatus = "1";
                    }


                    model.StudentRegistrationFormDTO.FatherHusbondType = response.Entity.FatherHusbondType;
                    model.StudentRegistrationFormDTO.FatherTitle = response.Entity.FatherTitle;
                    model.StudentRegistrationFormDTO.FatherFirstName = response.Entity.FatherFirstName;
                    model.StudentRegistrationFormDTO.FatherMiddleName = response.Entity.FatherMiddleName;
                    model.StudentRegistrationFormDTO.FatherLastName = response.Entity.FatherLastName;
                    model.StudentRegistrationFormDTO.FatherEmailId = response.Entity.FatherEmailId;
                    model.StudentRegistrationFormDTO.FatherMobileNumber = response.Entity.FatherMobileNumber;
                    model.StudentRegistrationFormDTO.StudentDomicileStateofFather = response.Entity.StudentDomicileStateofFather;
                    model.StudentRegistrationFormDTO.FatherLandLineNumber = response.Entity.FatherLandLineNumber;
                    model.StudentRegistrationFormDTO.FatherEmploymentSector = response.Entity.FatherEmploymentSector;
                    model.StudentRegistrationFormDTO.FatherOccupation = response.Entity.FatherOccupation;
                    model.StudentRegistrationFormDTO.FatherDesignation = response.Entity.FatherDesignation;
                    model.StudentRegistrationFormDTO.FatherOrganizationName = response.Entity.FatherOrganizationName;
                    model.StudentRegistrationFormDTO.FatherOfficeContactNo = response.Entity.FatherOfficeContactNo;
                    model.StudentRegistrationFormDTO.FatherAnnualIncome = response.Entity.FatherAnnualIncome;

                    //   model.StudentRegistrationFormDTO.FatherHusbondType =  response.Entity.["M_EntityType";
                    model.StudentRegistrationFormDTO.MotherTitle = response.Entity.MotherTitle;
                    model.StudentRegistrationFormDTO.MotherFirstName = response.Entity.MotherFirstName;
                    model.StudentRegistrationFormDTO.MotherMiddleName = response.Entity.MotherMiddleName;
                    model.StudentRegistrationFormDTO.MotherLastName = response.Entity.MotherLastName;
                    model.StudentRegistrationFormDTO.MotherEmailId = response.Entity.MotherEmailId;
                    model.StudentRegistrationFormDTO.MotherMobileNumber = response.Entity.MotherMobileNumber;
                    model.StudentRegistrationFormDTO.StudentDomicileStateofMother = response.Entity.StudentDomicileStateofMother;
                    model.StudentRegistrationFormDTO.MotherLandLineNumber = response.Entity.MotherLandLineNumber;
                    model.StudentRegistrationFormDTO.MotherEmploymentSector = response.Entity.MotherEmploymentSector;
                    model.StudentRegistrationFormDTO.MotherOccupation = response.Entity.MotherOccupation;
                    model.StudentRegistrationFormDTO.MotherDesignation = response.Entity.MotherDesignation;
                    model.StudentRegistrationFormDTO.MotherOrganizationName = response.Entity.MotherOrganizationName;
                    model.StudentRegistrationFormDTO.MotherOfficeContactNo = response.Entity.MotherOfficeContactNo;
                    model.StudentRegistrationFormDTO.MotherAnnualIncome = response.Entity.MotherAnnualIncome;

                    model.StudentRegistrationFormDTO.GuardianTitle = response.Entity.GuardianTitle;
                    model.StudentRegistrationFormDTO.GuardianFirstName = response.Entity.GuardianFirstName;
                    model.StudentRegistrationFormDTO.GuardianMiddleName = response.Entity.GuardianMiddleName;
                    model.StudentRegistrationFormDTO.GuardianLastName = response.Entity.GuardianLastName;
                    model.StudentRegistrationFormDTO.GuardianEmailId = response.Entity.GuardianEmailId;
                    model.StudentRegistrationFormDTO.GuardianMobileNumber = response.Entity.GuardianMobileNumber;
                    //    model.StudentRegistrationFormDTO.StudentDomicileStateofGuardian =  response.Entity.["G_DomicileState";
                    model.StudentRegistrationFormDTO.GuardianLandLineNumber = response.Entity.GuardianLandLineNumber;
                    model.StudentRegistrationFormDTO.GuardianEmploymentSector = response.Entity.GuardianEmploymentSector;
                    model.StudentRegistrationFormDTO.GuardianOccupation = response.Entity.GuardianOccupation;
                    model.StudentRegistrationFormDTO.GuardianDesignation = response.Entity.GuardianDesignation;
                    model.StudentRegistrationFormDTO.GuardianOrganizationName = response.Entity.GuardianOrganizationName;
                    model.StudentRegistrationFormDTO.GuardianOfficeContactNo = response.Entity.GuardianOfficeContactNo;
                    model.StudentRegistrationFormDTO.GuardianAnnualIncome = response.Entity.GuardianAnnualIncome;

                    model.StudentRegistrationFormDTO.Student_Ex_Serviceman_Ward_of_Ex_Serviceman = response.Entity.Student_Ex_Serviceman_Ward_of_Ex_Serviceman;
                    model.StudentRegistrationFormDTO.Student_Active_Serviceman_Ward_of_Active_Serviceman = response.Entity.Student_Active_Serviceman_Ward_of_Active_Serviceman;
                    model.StudentRegistrationFormDTO.Student_FreedomFighterWardOfFreedomFighter = response.Entity.Student_FreedomFighterWardOfFreedomFighter;
                    model.StudentRegistrationFormDTO.Student_WardofPrimaryTeacher = response.Entity.Student_WardofPrimaryTeacher;
                    model.StudentRegistrationFormDTO.Student_WardofSecondaryTeacher = response.Entity.Student_WardofSecondaryTeacher;
                    model.StudentRegistrationFormDTO.Student_Deserted_Divorced_Widowed_Women = response.Entity.Student_Deserted_Divorced_Widowed_Women;
                    model.StudentRegistrationFormDTO.Student_MemberofProjectAffectedFamily = response.Entity.Student_MemberofProjectAffectedFamily;
                    model.StudentRegistrationFormDTO.Student_MemberofEarthquakeAffectedFamily = response.Entity.Student_MemberofEarthquakeAffectedFamily;
                    model.StudentRegistrationFormDTO.Student_MemberofFloodFamineAffectedFamily = response.Entity.Student_MemberofFloodFamineAffectedFamily;
                    model.StudentRegistrationFormDTO.Student_ResidentofTribalArea = response.Entity.Student_ResidentofTribalArea;
                    model.StudentRegistrationFormDTO.Student_KashmirMigrant = response.Entity.Student_KashmirMigrant;

                    model.StudentRegistrationFormDTO.StudentIndicatetypeofCandidature = response.Entity.StudentIndicatetypeofCandidature;
                    model.StudentRegistrationFormDTO.StudentSchoolFromHSCExaminationpassed = response.Entity.StudentSchoolFromHSCExaminationpassed;
                    if (response.Entity.StudentEconomicallyBackwardClass == "False")
                    {
                        model.StudentRegistrationFormDTO.StudentEconomicallyBackwardClass = "0";
                    }
                    else
                    {
                        model.StudentRegistrationFormDTO.StudentEconomicallyBackwardClass = "1";
                    }

                    model.StudentRegistrationFormDTO.StudentsNameOfDistrictWhereParentDomiciled = response.Entity.StudentsNameOfDistrictWhereParentDomiciled;
                    model.StudentRegistrationFormDTO.StudentsMKBCandidate = response.Entity.StudentsMKBCandidate;

                    model.StudentRegistrationFormDTO.Student_PermanentAddress_Address1 = response.Entity.Student_PermanentAddress_Address1;
                    model.StudentRegistrationFormDTO.Student_PermanentAddress_Address2 = response.Entity.Student_PermanentAddress_Address2;
                    model.StudentRegistrationFormDTO.Student_PermanentAddress_PloteNo = response.Entity.Student_PermanentAddress_PloteNo;
                    model.StudentRegistrationFormDTO.Student_PermanentAddress_StreeNo = response.Entity.Student_PermanentAddress_StreeNo;
                    model.StudentRegistrationFormDTO.Student_PermanentAddress_City_TahsilID = response.Entity.Student_PermanentAddress_City_TahsilID;
                    model.StudentRegistrationFormDTO.Student_PermanentAddress_City_TahsilName = response.Entity.Student_PermanentAddress_City_TahsilName;
                    model.StudentRegistrationFormDTO.Student_PermanentAddress_City_TahsilOther = response.Entity.Student_PermanentAddress_City_TahsilOther;
                    model.StudentRegistrationFormDTO.Student_PermanentAddress_DistrictID = response.Entity.Student_PermanentAddress_DistrictID;
                    model.StudentRegistrationFormDTO.Student_PermanentAddress_DistrictOther = response.Entity.Student_PermanentAddress_DistrictOther;
                    model.StudentRegistrationFormDTO.Student_PermanentAddress_State = response.Entity.Student_PermanentAddress_State;
                    model.StudentRegistrationFormDTO.Student_PermanentAddress_StateOther = response.Entity.Student_PermanentAddress_StateOther;
                    model.StudentRegistrationFormDTO.Student_PermanentAddress_CountryId = response.Entity.Student_PermanentAddress_CountryId;
                    model.StudentRegistrationFormDTO.Student_PermanentAddress_NearPoliceStation = response.Entity.Student_PermanentAddress_NearPoliceStation;
                    model.StudentRegistrationFormDTO.Student_PermanentAddress_Tahsil = response.Entity.Student_PermanentAddress_Tahsil;
                    model.StudentRegistrationFormDTO.Student_PermanentAddress_ZipCode = response.Entity.Student_PermanentAddress_ZipCode;
                    model.StudentRegistrationFormDTO.Student_PermanentAddress_City_Tahsil_Pattern = response.Entity.Student_PermanentAddress_City_Tahsil_Pattern;


                    model.StudentRegistrationFormDTO.Student_CorrespondenceAddress_Address1 = response.Entity.Student_CorrespondenceAddress_Address1;
                    model.StudentRegistrationFormDTO.Student_CorrespondenceAddress_Address2 = response.Entity.Student_CorrespondenceAddress_Address2;
                    model.StudentRegistrationFormDTO.Student_CorrespondenceAddress_PloteNo = response.Entity.Student_CorrespondenceAddress_PloteNo;
                    model.StudentRegistrationFormDTO.Student_CorrespondenceAddress_StreeNo = response.Entity.Student_CorrespondenceAddress_StreeNo;
                    model.StudentRegistrationFormDTO.Student_CorrespondenceAddress_City_TahsilID = response.Entity.Student_CorrespondenceAddress_City_TahsilID;
                    model.StudentRegistrationFormDTO.Student_CorrespondenceAddress_City_TahsilName = response.Entity.Student_CorrespondenceAddress_City_TahsilName;
                    model.StudentRegistrationFormDTO.Student_CorrespondenceAddress_City_TahsilOther = response.Entity.Student_CorrespondenceAddress_City_TahsilOther;
                    model.StudentRegistrationFormDTO.Student_CorrespondenceAddress_DistrictID = response.Entity.Student_CorrespondenceAddress_DistrictID;
                    model.StudentRegistrationFormDTO.Student_CorrespondenceAddress_DistrictOther = response.Entity.Student_CorrespondenceAddress_DistrictOther;
                    model.StudentRegistrationFormDTO.Student_CorrespondenceAddress_State = response.Entity.Student_CorrespondenceAddress_State;
                    model.StudentRegistrationFormDTO.Student_CorrespondenceAddress_StateOther = response.Entity.Student_CorrespondenceAddress_StateOther;
                    model.StudentRegistrationFormDTO.Student_CorrespondenceAddress_CountryId = response.Entity.Student_CorrespondenceAddress_CountryId;
                    model.StudentRegistrationFormDTO.Student_CorrespondenceAddress_NearPoliceStation = response.Entity.Student_CorrespondenceAddress_NearPoliceStation;
                    model.StudentRegistrationFormDTO.Student_CorrespondenceAddress_Tahsil = response.Entity.Student_CorrespondenceAddress_Tahsil;
                    model.StudentRegistrationFormDTO.Student_CorrespondenceAddress_ZipCode = response.Entity.Student_CorrespondenceAddress_ZipCode;
                    model.StudentRegistrationFormDTO.Student_CorrespondenceAddress_City_Tahsil_Pattern = response.Entity.Student_CorrespondenceAddress_City_Tahsil_Pattern;
                    model.StudentRegistrationFormDTO.Student_QualifyingExamId = response.Entity.Student_QualifyingExamId;
                    model.StudentRegistrationFormDTO.Student_QualifyingRollNo = response.Entity.Student_QualifyingRollNo;
                    model.StudentRegistrationFormDTO.Student_QualifyingExamTotalMarksPointsObtained = response.Entity.Student_QualifyingExamTotalMarksPointsObtained;
                    model.StudentRegistrationFormDTO.Student_QualifyingExamOutOffMark = response.Entity.Student_QualifyingExamOutOffMark;
                    model.StudentRegistrationFormDTO.Student_QualifyingExamRank = response.Entity.Student_QualifyingExamRank;

                    model.StudentRegistrationFormDTO.Student_Qualification_General_MediumOfInstitution = response.Entity.Student_Qualification_General_MediumOfInstitution;
                    model.StudentRegistrationFormDTO.Student_Qualification_General_MonthOfPassing = response.Entity.Student_Qualification_General_MonthOfPassing;
                    model.StudentRegistrationFormDTO.Student_Qualification_General_YearOfPassing = response.Entity.Student_Qualification_General_YearOfPassing;
                    if (response.Entity.Student_Qualification_General_SingleAttempt == "False")
                    {
                        model.StudentRegistrationFormDTO.Student_Qualification_General_SingleAttempt = "0";
                    }
                    else
                    {
                        model.StudentRegistrationFormDTO.Student_Qualification_General_SingleAttempt = "1";
                    }
                    model.StudentRegistrationFormDTO.Student_Qualification_General_ObtainedMark = response.Entity.Student_Qualification_General_ObtainedMark;
                    model.StudentRegistrationFormDTO.Student_Qualification_General_OutOfMark = response.Entity.Student_Qualification_General_OutOfMark;
                    model.StudentRegistrationFormDTO.Student_Qualification_General_Percent = response.Entity.Student_Qualification_General_Percent;
                    model.StudentRegistrationFormDTO.Student_Qualification_General_NameofInstitution = response.Entity.Student_Qualification_General_NameofInstitution;
                    model.StudentRegistrationFormDTO.Student_Qualification_General_Region_Division_Board = response.Entity.Student_Qualification_General_Region_Division_Board;

                    model.StudentRegistrationFormDTO.Student_Qualification_SSC_MediumOfInstitution = response.Entity.Student_Qualification_SSC_MediumOfInstitution;
                    model.StudentRegistrationFormDTO.Student_Qualification_SSC_MonthOfPassing = response.Entity.Student_Qualification_SSC_MonthOfPassing;
                    model.StudentRegistrationFormDTO.Student_Qualification_SSC_YearOfPassing = response.Entity.Student_Qualification_SSC_YearOfPassing;
                    if (response.Entity.Student_Qualification_SSC_SingleAttempt == "False")
                    {
                        model.StudentRegistrationFormDTO.Student_Qualification_SSC_SingleAttempt = "0";
                    }
                    else
                    {
                        model.StudentRegistrationFormDTO.Student_Qualification_SSC_SingleAttempt = "1";
                    }

                    model.StudentRegistrationFormDTO.Student_Qualification_SSC_ObtainedMark = response.Entity.Student_Qualification_SSC_ObtainedMark;
                    model.StudentRegistrationFormDTO.Student_Qualification_SSC_OutOfMark = response.Entity.Student_Qualification_SSC_OutOfMark;
                    model.StudentRegistrationFormDTO.Student_Qualification_SSC_Percent = response.Entity.Student_Qualification_SSC_Percent;
                    model.StudentRegistrationFormDTO.Student_Qualification_SSC_NameofInstitution = response.Entity.Student_Qualification_SSC_NameofInstitution;
                    model.StudentRegistrationFormDTO.Student_Qualification_SSC_Region_Division_Board = response.Entity.Student_Qualification_SSC_Region_Division_Board;

                    model.StudentRegistrationFormDTO.Student_Qualification_HSC_MediumOfInstitution = response.Entity.Student_Qualification_HSC_MediumOfInstitution;
                    model.StudentRegistrationFormDTO.Student_Qualification_HSC_MonthOfPassing = response.Entity.Student_Qualification_HSC_MonthOfPassing;
                    model.StudentRegistrationFormDTO.Student_Qualification_HSC_YearOfPassing = response.Entity.Student_Qualification_HSC_YearOfPassing;
                    if (response.Entity.Student_Qualification_HSC_SingleAttempt == "False")
                    {
                        model.StudentRegistrationFormDTO.Student_Qualification_HSC_SingleAttempt = "0";
                    }
                    else
                    {
                        model.StudentRegistrationFormDTO.Student_Qualification_HSC_SingleAttempt = "1";
                    }

                    model.StudentRegistrationFormDTO.Student_Qualification_HSC_ObtainedMark = response.Entity.Student_Qualification_HSC_ObtainedMark;
                    model.StudentRegistrationFormDTO.Student_Qualification_HSC_OutOfMark = response.Entity.Student_Qualification_HSC_OutOfMark;
                    model.StudentRegistrationFormDTO.Student_Qualification_HSC_Percent = response.Entity.Student_Qualification_HSC_Percent;
                    model.StudentRegistrationFormDTO.Student_Qualification_HSC_NameofInstitution = response.Entity.Student_Qualification_HSC_NameofInstitution;
                    model.StudentRegistrationFormDTO.Student_Qualification_HSC_Region_Division_Board = response.Entity.Student_Qualification_HSC_Region_Division_Board;
                    model.StudentRegistrationFormDTO.Student_Qualification_HSC_StreamID = response.Entity.Student_Qualification_HSC_StreamID;
                    model.StudentRegistrationFormDTO.Student_Qualification_HSC_StreamOther = response.Entity.Student_Qualification_HSC_StreamOther;
                    model.StudentRegistrationFormDTO.Student_Qualification_HSC_Class = response.Entity.Student_Qualification_HSC_Class;

                    model.StudentRegistrationFormDTO.Student_Qualification_HSC_PCM_PVM_ObtainedMark = response.Entity.Student_Qualification_HSC_PCM_PVM_ObtainedMark;
                    model.StudentRegistrationFormDTO.Student_Qualification_HSC_PCM_PVM_OutOfMark = response.Entity.Student_Qualification_HSC_PCM_PVM_OutOfMark;
                    model.StudentRegistrationFormDTO.Student_Qualification_HSC_PCB_ObtainedMark = response.Entity.Student_Qualification_HSC_PCB_ObtainedMark;
                    model.StudentRegistrationFormDTO.Student_Qualification_HSC_PCB_OutOfMark = response.Entity.Student_Qualification_HSC_PCB_OutOfMark;

                    model.StudentRegistrationFormDTO.Student_Qualification_Diploma_ITI_Details_MediumOfInstitution = response.Entity.Student_Qualification_Diploma_ITI_Details_MediumOfInstitution;
                    model.StudentRegistrationFormDTO.Student_Qualification_Diploma_ITI_Details_BranchName = response.Entity.Student_Qualification_Diploma_ITI_Details_BranchName;
                    model.StudentRegistrationFormDTO.Student_Qualification_Diploma_ITI_Details_ExamPattern = response.Entity.Student_Qualification_Diploma_ITI_Details_ExamPattern;
                    model.StudentRegistrationFormDTO.Student_Qualification_Diploma_ITI_Details_MonthOfPassing = response.Entity.Student_Qualification_Diploma_ITI_Details_MonthOfPassing;
                    model.StudentRegistrationFormDTO.Student_Qualification_Diploma_ITI_Details_YearOfPassing = response.Entity.Student_Qualification_Diploma_ITI_Details_YearOfPassing;
                    if (response.Entity.Student_Qualification_Diploma_ITI_Details_SingleAttempt == "False")
                    {
                        model.StudentRegistrationFormDTO.Student_Qualification_Diploma_ITI_Details_SingleAttempt = "0";
                    }
                    else
                    {
                        model.StudentRegistrationFormDTO.Student_Qualification_Diploma_ITI_Details_SingleAttempt = "1";
                    }

                    model.StudentRegistrationFormDTO.Student_Qualification_Diploma_ITI_Details_ObtainedMark = response.Entity.Student_Qualification_Diploma_ITI_Details_ObtainedMark;
                    model.StudentRegistrationFormDTO.Student_Qualification_Diploma_ITI_Details_OutOfMark = response.Entity.Student_Qualification_Diploma_ITI_Details_OutOfMark;
                    model.StudentRegistrationFormDTO.Student_Qualification_Diploma_ITI_Details_Percent = response.Entity.Student_Qualification_Diploma_ITI_Details_Percent;
                    model.StudentRegistrationFormDTO.Student_Qualification_Diploma_ITI_Details_NameofInstitution = response.Entity.Student_Qualification_Diploma_ITI_Details_NameofInstitution;
                    model.StudentRegistrationFormDTO.Student_Qualification_Diploma_ITI_Details_Board = response.Entity.Student_Qualification_Diploma_ITI_Details_Board;
                    model.StudentRegistrationFormDTO.Student_Qualification_Diploma_ITI_Details_State = response.Entity.Student_Qualification_Diploma_ITI_Details_State;
                    model.StudentRegistrationFormDTO.Student_Qualification_Diploma_ITI_Details_CountryId = response.Entity.Student_Qualification_Diploma_ITI_Details_CountryId;
                    model.StudentRegistrationFormDTO.Student_Qualification_Diploma_ITI_Details_StateOther = response.Entity.Student_Qualification_Diploma_ITI_Details_StateOther;
                    model.StudentRegistrationFormDTO.Student_Qualification_Diploma_ITI_Details_BoardEnrollmentNumber = response.Entity.Student_Qualification_Diploma_ITI_Details_BoardEnrollmentNumber;
                    model.StudentRegistrationFormDTO.Student_Qualification_Diploma_ITI_Details_Class = response.Entity.Student_Qualification_Diploma_ITI_Details_Class;

                    model.StudentRegistrationFormDTO.Student_Qualification_DegreeDetails_MediumOfInstitution = response.Entity.Student_Qualification_DegreeDetails_MediumOfInstitution;
                    model.StudentRegistrationFormDTO.Student_Qualification_DegreeDetails_BranchName = response.Entity.Student_Qualification_DegreeDetails_BranchName;
                    model.StudentRegistrationFormDTO.Student_Qualification_DegreeDetails_ExamPattern = response.Entity.Student_Qualification_DegreeDetails_ExamPattern;
                    model.StudentRegistrationFormDTO.Student_Qualification_DegreeDetails_MonthOfPassing = response.Entity.Student_Qualification_DegreeDetails_MonthOfPassing;
                    model.StudentRegistrationFormDTO.Student_Qualification_DegreeDetails_YearOfPassing = response.Entity.Student_Qualification_DegreeDetails_YearOfPassing;
                    if (response.Entity.Student_Qualification_DegreeDetails_SingleAttempt == "False")
                    {
                        model.StudentRegistrationFormDTO.Student_Qualification_DegreeDetails_SingleAttempt = "0";
                    }
                    else
                    {
                        model.StudentRegistrationFormDTO.Student_Qualification_DegreeDetails_SingleAttempt = "1";
                    }
                    model.StudentRegistrationFormDTO.Student_Qualification_DegreeDetails_ObtainedMark = response.Entity.Student_Qualification_DegreeDetails_ObtainedMark;
                    model.StudentRegistrationFormDTO.Student_Qualification_DegreeDetails_OutOfMark = response.Entity.Student_Qualification_DegreeDetails_OutOfMark;
                    model.StudentRegistrationFormDTO.Student_Qualification_DegreeDetails_Percent = response.Entity.Student_Qualification_DegreeDetails_Percent;
                    model.StudentRegistrationFormDTO.Student_Qualification_DegreeDetails_NameofInstitution = response.Entity.Student_Qualification_DegreeDetails_NameofInstitution;
                    model.StudentRegistrationFormDTO.Student_Qualification_DegreeDetails_UniversityName = response.Entity.Student_Qualification_DegreeDetails_UniversityName;
                    model.StudentRegistrationFormDTO.Student_Qualification_DegreeDetails_State = response.Entity.Student_Qualification_DegreeDetails_State;
                    model.StudentRegistrationFormDTO.Student_Qualification_DegreeDetails_CountryId = response.Entity.Student_Qualification_DegreeDetails_CountryId;
                    model.StudentRegistrationFormDTO.Student_Qualification_DegreeDetails_StateOther = response.Entity.Student_Qualification_DegreeDetails_StateOther;
                    model.StudentRegistrationFormDTO.Student_Qualification_DegreeDetails_Degree = response.Entity.Student_Qualification_DegreeDetails_Degree;
                    model.StudentRegistrationFormDTO.Student_Qualification_DegreeDetails_BoardEnrollmentNumber = response.Entity.Student_Qualification_DegreeDetails_BoardEnrollmentNumber;
                    model.StudentRegistrationFormDTO.Student_Qualification_DegreeDetails_Class = response.Entity.Student_Qualification_DegreeDetails_Class;

                    model.StudentRegistrationFormDTO.Student_Qualification_PostGraduationDetails_MediumOfInstitution = response.Entity.Student_Qualification_PostGraduationDetails_MediumOfInstitution;
                    model.StudentRegistrationFormDTO.Student_Qualification_PostGraduationDetails_BranchName = response.Entity.Student_Qualification_PostGraduationDetails_BranchName;
                    model.StudentRegistrationFormDTO.Student_Qualification_PostGraduationDetails_ExamPattern = response.Entity.Student_Qualification_PostGraduationDetails_ExamPattern;
                    model.StudentRegistrationFormDTO.Student_Qualification_PostGraduationDetails_MonthOfPassing = response.Entity.Student_Qualification_PostGraduationDetails_MonthOfPassing;
                    model.StudentRegistrationFormDTO.Student_Qualification_PostGraduationDetails_YearOfPassing = response.Entity.Student_Qualification_PostGraduationDetails_YearOfPassing;
                    if (response.Entity.Student_Qualification_PostGraduationDetails_SingleAttempt == "False")
                    {
                        model.StudentRegistrationFormDTO.Student_Qualification_PostGraduationDetails_SingleAttempt = "0";
                    }
                    else
                    {
                        model.StudentRegistrationFormDTO.Student_Qualification_PostGraduationDetails_SingleAttempt = "1";
                    }
                    model.StudentRegistrationFormDTO.Student_Qualification_PostGraduationDetails_ObtainedMark = response.Entity.Student_Qualification_PostGraduationDetails_ObtainedMark;
                    model.StudentRegistrationFormDTO.Student_Qualification_PostGraduationDetails_OutOfMark = response.Entity.Student_Qualification_PostGraduationDetails_OutOfMark;
                    model.StudentRegistrationFormDTO.Student_Qualification_PostGraduationDetails_Percent = response.Entity.Student_Qualification_PostGraduationDetails_Percent;
                    model.StudentRegistrationFormDTO.Student_Qualification_PostGraduationDetails_NameofInstitution = response.Entity.Student_Qualification_PostGraduationDetails_NameofInstitution;
                    model.StudentRegistrationFormDTO.Student_Qualification_PostGraduationDetails_UniversityName = response.Entity.Student_Qualification_PostGraduationDetails_UniversityName;
                    model.StudentRegistrationFormDTO.Student_Qualification_PostGraduationDetails_State = response.Entity.Student_Qualification_PostGraduationDetails_State;
                    model.StudentRegistrationFormDTO.Student_Qualification_PostGraduationDetails_CountryId = response.Entity.Student_Qualification_PostGraduationDetails_CountryId;
                    model.StudentRegistrationFormDTO.Student_Qualification_PostGraduationDetails_StateOther = response.Entity.Student_Qualification_PostGraduationDetails_StateOther;
                    model.StudentRegistrationFormDTO.Student_Qualification_PostGraduationDetails_PostGraduation = response.Entity.Student_Qualification_PostGraduationDetails_PostGraduation;
                    model.StudentRegistrationFormDTO.Student_Qualification_PostGraduationDetails_BoardEnrollmentNumber = response.Entity.Student_Qualification_PostGraduationDetails_BoardEnrollmentNumber;
                    model.StudentRegistrationFormDTO.Student_Qualification_PostGraduationDetails_Class = response.Entity.Student_Qualification_PostGraduationDetails_Class;
                    model.StudentRegistrationFormDTO.Student_DTE_DTEUserID = response.Entity.Student_DTE_DTEUserID;
                    model.StudentRegistrationFormDTO.Student_DTE_DTEPassword = response.Entity.Student_DTE_DTEPassword;
                    model.StudentRegistrationFormDTO.Student_DTE_DTESrNo = response.Entity.Student_DTE_DTESrNo;
                    model.StudentRegistrationFormDTO.Student_DTE_DTEMeritNo = response.Entity.Student_DTE_DTEMeritNo;
                    model.StudentRegistrationFormDTO.Student_DTE_AdmissionTypeId = response.Entity.Student_DTE_AdmissionTypeId;
                    model.StudentRegistrationFormDTO.Student_DTE_AdmissionRound = response.Entity.Student_DTE_AdmissionRound;
                    model.StudentRegistrationFormDTO.Student_DTE_AdmissionCategoryId = response.Entity.Student_DTE_AdmissionCategoryId;
                    model.StudentRegistrationFormDTO.Student_DTE_DTESeatNo = response.Entity.Student_DTE_DTESeatNo;
                    model.StudentRegistrationFormDTO.Student_DTE_QualifyingExamName = response.Entity.Student_DTE_QualifyingExamName;
                    model.StudentRegistrationFormDTO.Student_DTE_QualifyingExamMarks = response.Entity.Student_DTE_QualifyingExamMarks;
                    model.StudentRegistrationFormDTO.Student_QualifyingExamName = response.Entity.Student_DTE_QualifyingExamName;


                    //For Document
                    model.StudentRegistrationFormDTO.Student_AdmissionDocuments_JETMarkSheet = response.Entity.Student_AdmissionDocuments_JETMarkSheet;
                    model.StudentRegistrationFormDTO.Student_AdmissionDocuments_AllotmentLetter = response.Entity.Student_AdmissionDocuments_AllotmentLetter;
                    model.StudentRegistrationFormDTO.Student_AdmissionDocuments_TenthMarkSheet = response.Entity.Student_AdmissionDocuments_TenthMarkSheet;
                    model.StudentRegistrationFormDTO.Student_AdmissionDocuments_TwelvethMarkSheet = response.Entity.Student_AdmissionDocuments_TwelvethMarkSheet;
                    model.StudentRegistrationFormDTO.Student_AdmissionDocuments_AllDiplomaMarksheet = response.Entity.Student_AdmissionDocuments_AllDiplomaMarksheet;
                    model.StudentRegistrationFormDTO.Student_AdmissionDocuments_LeavingCertificate = response.Entity.Student_AdmissionDocuments_LeavingCertificate;
                    model.StudentRegistrationFormDTO.Student_AdmissionDocuments_Domicile_BirthCertificate = response.Entity.Student_AdmissionDocuments_Domicile_BirthCertificate;
                    model.StudentRegistrationFormDTO.Student_AdmissionDocuments_NationalityCertificate = response.Entity.Student_AdmissionDocuments_NationalityCertificate;
                    model.StudentRegistrationFormDTO.Student_AdmissionDocuments_CasteCertificate = response.Entity.Student_AdmissionDocuments_CasteCertificate;
                    model.StudentRegistrationFormDTO.Student_AdmissionDocuments_CasteValidityCertificate = response.Entity.Student_AdmissionDocuments_CasteValidityCertificate;
                    model.StudentRegistrationFormDTO.Student_AdmissionDocuments_NonCreamylayerCertificate = response.Entity.Student_AdmissionDocuments_NonCreamylayerCertificate;
                    model.StudentRegistrationFormDTO.Student_AdmissionDocuments_EquivalenceCertificate = response.Entity.Student_AdmissionDocuments_EquivalenceCertificate;
                    model.StudentRegistrationFormDTO.Student_AdmissionDocuments_MigrationCertificate = response.Entity.Student_AdmissionDocuments_MigrationCertificate;
                    model.StudentRegistrationFormDTO.Student_AdmissionDocuments_GapCertificate = response.Entity.Student_AdmissionDocuments_GapCertificate;
                    model.StudentRegistrationFormDTO.Student_AdmissionDocuments_AntiRaggingAffidavit = response.Entity.Student_AdmissionDocuments_AntiRaggingAffidavit;
                    model.StudentRegistrationFormDTO.Student_AdmissionDocuments_Proforma_Fand_F1_On_DoctorsLetter_Head = response.Entity.Student_AdmissionDocuments_Proforma_Fand_F1_On_DoctorsLetter_Head;
                    model.StudentRegistrationFormDTO.Student_AdmissionDocuments_Proforma_I = response.Entity.Student_AdmissionDocuments_Proforma_I;
                    model.StudentRegistrationFormDTO.Student_AdmissionDocuments_ProformaG1 = response.Entity.Student_AdmissionDocuments_ProformaG1;
                    model.StudentRegistrationFormDTO.Student_AdmissionDocuments_ProformaG2 = response.Entity.Student_AdmissionDocuments_ProformaG2;
                    model.StudentRegistrationFormDTO.Student_AdmissionDocuments_Proforma_C_D_E = response.Entity.Student_AdmissionDocuments_Proforma_C_D_E;
                    model.StudentRegistrationFormDTO.Student_AdmissionDocuments_FathersIncomeCertificate = response.Entity.Student_AdmissionDocuments_FathersIncomeCertificate;
                    model.StudentRegistrationFormDTO.Student_AdmissionDocuments_AadharCardXerox = response.Entity.Student_AdmissionDocuments_AadharCardXerox;
                    model.StudentRegistrationFormDTO.Student_AdmissionDocuments_B_WPhoto_I_card_size = response.Entity.Student_AdmissionDocuments_B_WPhoto_I_card_size;
                    model.StudentRegistrationFormDTO.Student_AdmissionDocuments_Colour_photo = response.Entity.Student_AdmissionDocuments_Colour_photo;
                 

                    //For PG Students
                    model.StudentRegistrationFormDTO.Student_AdmissionDocuments_PGStudents_DegreeMarksheet = response.Entity.Student_AdmissionDocuments_PGStudents_DegreeMarksheet;
                    model.StudentRegistrationFormDTO.Student_AdmissionDocuments_PGStudents_DegreeCertificate = response.Entity.Student_AdmissionDocuments_PGStudents_DegreeCertificate;
                    model.StudentRegistrationFormDTO.Student_AdmissionDocuments_PGStudents_GateScoreCard = response.Entity.Student_AdmissionDocuments_PGStudents_GateScoreCard;
                    model.StudentRegistrationFormDTO.Student_AdmissionDocuments_PGStudents_SponsorshipLetterforSponsoredCandidate = response.Entity.Student_AdmissionDocuments_PGStudents_SponsorshipLetterforSponsoredCandidate;

                    model.StudentRegistrationFormDTO.Student_StudentCode = "STU" + response.Entity.Student_CourseYearName + model.StudentRegistrationFormDTO.ID;


                }

                #region Method
                //For Title
                List<SelectListItem> StudentRegistrationForm = new List<SelectListItem>();
                ViewBag.StudentRegistrationForm = new SelectList(StudentRegistrationForm, "Value", "Text");
                List<SelectListItem> li = new List<SelectListItem>();
                li.Add(new SelectListItem { Text = "Mr.", Value = "Mr." });
                li.Add(new SelectListItem { Text = "Mrs.", Value = "Mrs." });
                li.Add(new SelectListItem { Text = "Miss.", Value = "Miss." });
                ViewData["Title"] = li;

                //For NRI_POI
                List<SelectListItem> StudentRegistrationForm_NRI_POI = new List<SelectListItem>();
                ViewBag.StudentRegistrationForm_NRI_POI = new SelectList(StudentRegistrationForm_NRI_POI, "Value", "Text");
                List<SelectListItem> li_StudentRegistrationForm_NRI_POI = new List<SelectListItem>();
                li_StudentRegistrationForm_NRI_POI.Add(new SelectListItem { Text = "NONE", Value = "NONE" });
                li_StudentRegistrationForm_NRI_POI.Add(new SelectListItem { Text = "NRI", Value = "NRI" });
                li_StudentRegistrationForm_NRI_POI.Add(new SelectListItem { Text = "POI", Value = "POI" });
                ViewData["StudentNRI_POI"] = new SelectList(li_StudentRegistrationForm_NRI_POI, "Value", "Text", model.StudentRegistrationFormDTO.StudentNRI_POI);

                //For Fees payment details
                ViewData["FeesPaidBy"] = new SelectList(li_FeesPaidBy, "Value", "Text", response.Entity.FeesPaidBy); 

                //For Academic Request Status
                List<SelectListItem> StudentRegistrationForm_AcademicRequestStatus = new List<SelectListItem>();
                ViewBag.StudentRegistrationForm_AcademicRequestStatus = new SelectList(StudentRegistrationForm_AcademicRequestStatus, "Value", "Text");
                List<SelectListItem> li_StudentRegistrationForm_AcademicRequestStatus = new List<SelectListItem>();
                li_StudentRegistrationForm_AcademicRequestStatus.Add(new SelectListItem { Text = "Accept", Value = "True" });
                li_StudentRegistrationForm_AcademicRequestStatus.Add(new SelectListItem { Text = "Reject", Value = "False" });
                ViewData["ApprovalStatus"] = li_StudentRegistrationForm_AcademicRequestStatus;

                

                //For Nationality

                List<GeneralNationalityMaster> generalNationalityMasterList = GetListGeneralNationalityMaster();
                List<SelectListItem> generalNationalityMaster = new List<SelectListItem>();
                foreach (GeneralNationalityMaster item in generalNationalityMasterList)
                {
                    generalNationalityMaster.Add(new SelectListItem { Text = item.Description, Value = item.ID.ToString() });
                }
                ViewBag.GeneralNationalityMaster = new SelectList(generalNationalityMaster, "Value", "Text");


                //For MaritalStatus
                List<SelectListItem> StudentRegistrationForm_StudentMaritalStatus = new List<SelectListItem>();
                ViewBag.StudentRegistrationForm_StudentMaritalStatus = new SelectList(StudentRegistrationForm_StudentMaritalStatus, "Value", "Text");
                List<SelectListItem> li_StudentRegistrationForm_StudentMaritalStatus = new List<SelectListItem>();
                li_StudentRegistrationForm_StudentMaritalStatus.Add(new SelectListItem { Text = "-- Select Marital Status -- ", Value = "N" });
                li_StudentRegistrationForm_StudentMaritalStatus.Add(new SelectListItem { Text = "UNMARRIED", Value = "U" });
                li_StudentRegistrationForm_StudentMaritalStatus.Add(new SelectListItem { Text = "MARRIED", Value = "M" });
                li_StudentRegistrationForm_StudentMaritalStatus.Add(new SelectListItem { Text = "DIVORCEE", Value = "D" });
                li_StudentRegistrationForm_StudentMaritalStatus.Add(new SelectListItem { Text = "WIDOW", Value = "W" });
                li_StudentRegistrationForm_StudentMaritalStatus.Add(new SelectListItem { Text = "JUDICIALLY SEPARETED", Value = "J" });
                ViewData["StudentMaritalStatus"] = new SelectList(li_StudentRegistrationForm_StudentMaritalStatus, "Value", "Text", model.StudentRegistrationFormDTO.StudentMaritalStatus);

                //For Blood Group
                List<SelectListItem> StudentRegistrationForm_StudentBloodGroup = new List<SelectListItem>();
                ViewBag.StudentRegistrationForm_StudentBloodGroup = new SelectList(StudentRegistrationForm_StudentBloodGroup, "Value", "Text");
                List<SelectListItem> li_StudentRegistrationForm_StudentBloodGroup = new List<SelectListItem>();
                li_StudentRegistrationForm_StudentBloodGroup.Add(new SelectListItem { Text = "-- Select Blood Group -- ", Value = "" });
                li_StudentRegistrationForm_StudentBloodGroup.Add(new SelectListItem { Text = "O-", Value = "O-" });
                li_StudentRegistrationForm_StudentBloodGroup.Add(new SelectListItem { Text = "O+", Value = "O+" });
                li_StudentRegistrationForm_StudentBloodGroup.Add(new SelectListItem { Text = "A-", Value = "A-" });
                li_StudentRegistrationForm_StudentBloodGroup.Add(new SelectListItem { Text = "A+", Value = "A+" });
                li_StudentRegistrationForm_StudentBloodGroup.Add(new SelectListItem { Text = "B-", Value = "B-" });
                li_StudentRegistrationForm_StudentBloodGroup.Add(new SelectListItem { Text = "B+", Value = "B+" });
                li_StudentRegistrationForm_StudentBloodGroup.Add(new SelectListItem { Text = "AB-", Value = "AB-" });
                li_StudentRegistrationForm_StudentBloodGroup.Add(new SelectListItem { Text = "AB+", Value = "AB+" });
                ViewData["StudentBloodGroup"] = new SelectList(li_StudentRegistrationForm_StudentBloodGroup, "Value", "Text", model.StudentRegistrationFormDTO.StudentBloodGroup);

                //For PhysicallyHandicapped

                ViewData["PhysicallyHandicapped"] = new SelectList(li_StudentRegistrationForm_StudentPhysicallyHandicapped, "Value", "Text", model.StudentRegistrationFormDTO.PhysicallyHandicapped);

                ViewData["StudentEmploymentStatus"] = new SelectList(li_StudentRegistrationForm_StudentPhysicallyHandicapped, "Value", "Text", model.StudentRegistrationFormDTO.StudentEmploymentStatus);

                ViewData["Student_Qualification_General_SingleAttempt"] = new SelectList(li_StudentRegistrationForm_StudentPhysicallyHandicapped, "Value", "Text", model.StudentRegistrationFormDTO.Student_Qualification_General_SingleAttempt);
                ViewData["Student_Qualification_SSC_SingleAttempt"] = new SelectList(li_StudentRegistrationForm_StudentPhysicallyHandicapped, "Value", "Text", model.StudentRegistrationFormDTO.Student_Qualification_SSC_SingleAttempt);
                ViewData["Student_Qualification_HSC_SingleAttempt"] = new SelectList(li_StudentRegistrationForm_StudentPhysicallyHandicapped, "Value", "Text", model.StudentRegistrationFormDTO.Student_Qualification_HSC_SingleAttempt);
                ViewData["Student_Qualification_Diploma_ITI_Details_SingleAttempt"] = new SelectList(li_StudentRegistrationForm_StudentPhysicallyHandicapped, "Value", "Text", model.StudentRegistrationFormDTO.Student_Qualification_Diploma_ITI_Details_SingleAttempt);
                ViewData["Student_Qualification_DegreeDetails_SingleAttempt"] = new SelectList(li_StudentRegistrationForm_StudentPhysicallyHandicapped, "Value", "Text", model.StudentRegistrationFormDTO.Student_Qualification_DegreeDetails_SingleAttempt);
                ViewData["Student_Qualification_PostGraduationDetails_SingleAttempt"] = new SelectList(li_StudentRegistrationForm_StudentPhysicallyHandicapped, "Value", "Text", model.StudentRegistrationFormDTO.Student_Qualification_PostGraduationDetails_SingleAttempt);
                //For Organ donor
                List<SelectListItem> StudentRegistrationForm_StudentOrgandonor = new List<SelectListItem>();
                ViewBag.StudentRegistrationForm_StudentOrgandonor = new SelectList(StudentRegistrationForm_StudentOrgandonor, "Value", "Text");
                List<SelectListItem> li_StudentRegistrationForm_StudentOrgandonor = new List<SelectListItem>();
                li_StudentRegistrationForm_StudentOrgandonor.Add(new SelectListItem { Text = "NO", Value = "0" });
                li_StudentRegistrationForm_StudentOrgandonor.Add(new SelectListItem { Text = "YES", Value = "1" });
                ViewData["StudentOrgandonor"] = new SelectList(li_StudentRegistrationForm_StudentOrgandonor, "Value", "Text", model.StudentRegistrationFormDTO.StudentOrgandonor);





                //For Religion
                List<GeneralReligionMaster> generalReligionMasterList = GetListGeneralReligionMaster();
                List<SelectListItem> generalReligionMaster = new List<SelectListItem>();
                foreach (GeneralReligionMaster item in generalReligionMasterList)
                {
                    generalReligionMaster.Add(new SelectListItem { Text = item.Description, Value = item.ID.ToString() });
                }
                ViewBag.GeneralReligionMaster = new SelectList(generalReligionMaster, "Value", "Text");

                //For Region
                int CountryId = 0;
                List<GeneralRegionMaster> generalRegionMasterList = GetListGeneralRegionMaster(Convert.ToString(CountryId));
                List<SelectListItem> generalRegionMaster = new List<SelectListItem>();
                // generalRegionMaster.Add(new SelectListItem { Text = "-- Select Region--", Value = "" });
                generalRegionMaster.Add(new SelectListItem { Text = "Other", Value = "Other" });
                foreach (GeneralRegionMaster item in generalRegionMasterList)
                {
                    generalRegionMaster.Add(new SelectListItem { Text = item.RegionName + " ( " + item.CountryName + " )", Value = item.ID.ToString() });
                }

                ViewBag.GeneralRegionMaster = new SelectList(generalRegionMaster, "Value", "Text");


                //For Student_PermanentAddress_State

                List<GeneralRegionMaster> generalRegionMasterListforPermanentAddress = GetListGeneralRegionMaster(Convert.ToString(model.StudentRegistrationFormDTO.Student_PermanentAddress_CountryId));
                List<SelectListItem> generalRegionMasterforPermanentAddress = new List<SelectListItem>();
                generalRegionMasterforPermanentAddress.Add(new SelectListItem { Text = "Other", Value = "Other" });
                foreach (GeneralRegionMaster item in generalRegionMasterListforPermanentAddress)
                {
                    generalRegionMasterforPermanentAddress.Add(new SelectListItem { Text = item.RegionName + " ( " + item.CountryName + " )", Value = item.ID.ToString() });
                }
                ViewBag.GeneralRegionMasterforPermanentAddress = new SelectList(generalRegionMasterforPermanentAddress, "Value", "Text");

                //Student_PermanentAddress_DistrictID
                // string SelectedRegionID = "A";

                List<GeneralCityMaster> GeneralCityMasterListforPermanentAddress = GetListGeneralCityMaster(Convert.ToString(model.StudentRegistrationFormDTO.Student_PermanentAddress_State));
                List<SelectListItem> GeneralCityMasterforPermanentAddress = new List<SelectListItem>();
                GeneralCityMasterforPermanentAddress.Add(new SelectListItem { Text = "Other", Value = "Other" });
                foreach (GeneralCityMaster item in GeneralCityMasterListforPermanentAddress)
                {
                    GeneralCityMasterforPermanentAddress.Add(new SelectListItem { Text = item.Description, Value = item.ID.ToString() });
                }

                ViewBag.GeneralCityListforPermanentAddress = new SelectList(GeneralCityMasterforPermanentAddress, "Value", "Text");

                //Student_PermanentAddress_CityID
                //List<GeneralLocationMaster> GeneralLocationMasterListforPermanentAddress = GetListGeneralLocationMasterByCityID(Convert.ToString(model.StudentRegistrationFormDTO.Student_PermanentAddress_DistrictID));
                //List<SelectListItem> GeneralLocationMasterforPermanentAddress = new List<SelectListItem>();
                //GeneralLocationMasterforPermanentAddress.Add(new SelectListItem { Text = "Other", Value = "Other" });
                //foreach (GeneralLocationMaster item in GeneralLocationMasterListforPermanentAddress)
                //{
                //    GeneralLocationMasterforPermanentAddress.Add(new SelectListItem { Text = item.LocationAddress, Value = item.ID.ToString() });
                //}

                //ViewBag.GeneralLocationListforPermanentAddress = new SelectList(GeneralLocationMasterforPermanentAddress, "Value", "Text");

                //For Student_CorrespondenceAddress_State

                List<GeneralRegionMaster> generalRegionMasterListforCorrespondenceAddress = GetListGeneralRegionMaster(Convert.ToString(model.StudentRegistrationFormDTO.Student_CorrespondenceAddress_CountryId));
                List<SelectListItem> generalRegionMasterforCorrespondenceAddress = new List<SelectListItem>();
                generalRegionMasterforCorrespondenceAddress.Add(new SelectListItem { Text = "Other", Value = "Other" });
                foreach (GeneralRegionMaster item in generalRegionMasterListforCorrespondenceAddress)
                {
                    generalRegionMasterforCorrespondenceAddress.Add(new SelectListItem { Text = item.RegionName + " ( " + item.CountryName + " )", Value = item.ID.ToString() });
                }
                ViewBag.GeneralRegionMasterforCorrespondenceAddress = new SelectList(generalRegionMasterforCorrespondenceAddress, "Value", "Text");

                //Student_CorrespondenceAddress_DistrictID
                // string SelectedRegionID = "A";

                List<GeneralCityMaster> GeneralCityMasterListforCorrespondenceAddress = GetListGeneralCityMaster(Convert.ToString(model.StudentRegistrationFormDTO.Student_CorrespondenceAddress_State));
                List<SelectListItem> GeneralCityMasterforCorrespondenceAddress = new List<SelectListItem>();
                GeneralCityMasterforCorrespondenceAddress.Add(new SelectListItem { Text = "Other", Value = "Other" });
                foreach (GeneralCityMaster item in GeneralCityMasterListforCorrespondenceAddress)
                {
                    GeneralCityMasterforCorrespondenceAddress.Add(new SelectListItem { Text = item.Description, Value = item.ID.ToString() });
                }

                ViewBag.GeneralCityListforCorrespondenceAddress = new SelectList(GeneralCityMasterforCorrespondenceAddress, "Value", "Text");

                //Student_CorrespondenceAddress_CityID
                //List<GeneralLocationMaster> GeneralLocationMasterListforCorrespondenceAddress = GetListGeneralLocationMasterByCityID(Convert.ToString(model.StudentRegistrationFormDTO.Student_CorrespondenceAddress_DistrictID));
                //List<SelectListItem> GeneralLocationMasterforCorrespondenceAddress = new List<SelectListItem>();
                //GeneralLocationMasterforCorrespondenceAddress.Add(new SelectListItem { Text = "Other", Value = "Other" });
                //foreach (GeneralLocationMaster item in GeneralLocationMasterListforCorrespondenceAddress)
                //{
                //    GeneralLocationMasterforCorrespondenceAddress.Add(new SelectListItem { Text = item.LocationAddress, Value = item.ID.ToString() });
                //}

                //ViewBag.GeneralLocationListforCorrespondenceAddress = new SelectList(GeneralLocationMasterforPermanentAddress, "Value", "Text");
                //For Category
                List<GeneralCategoryMaster> generalCategoryMasterList = GetListGeneralCategoryMaster();
                List<SelectListItem> generalCategoryMaster = new List<SelectListItem>();
                foreach (GeneralCategoryMaster item in generalCategoryMasterList)
                {
                    generalCategoryMaster.Add(new SelectListItem { Text = item.CategoryName + " ( " + item.CategoryType + " )", Value = item.ID.ToString() });
                }
                ViewBag.GeneralCategoryMaster = new SelectList(generalCategoryMaster, "Value", "Text");

                //For Caste
                //  int CategoryID = 0;

                List<GeneralCasteMaster> GeneralCasteMasterList = GetListGeneralCasteMaster(model.StudentRegistrationFormDTO.StudentCategoryID);
                List<SelectListItem> GeneralCasteMaster = new List<SelectListItem>();
                foreach (GeneralCasteMaster item in GeneralCasteMasterList)
                {
                    GeneralCasteMaster.Add(new SelectListItem { Text = item.CasteName, Value = item.ID.ToString() });
                }
                ViewBag.GeneralCasteMasterList = new SelectList(GeneralCasteMaster, "Value", "Text");

                //For Language
                List<GeneralLanguageMaster> generalLanguageMasterList = GetListGeneralLanguageMaster();
                List<SelectListItem> generalLanguageMaster = new List<SelectListItem>();
                foreach (GeneralLanguageMaster item in generalLanguageMasterList)
                {
                    generalLanguageMaster.Add(new SelectListItem { Text = item.LanguageName, Value = item.ID.ToString() });
                }
                ViewBag.GeneralLanguageMaster = new SelectList(generalLanguageMaster, "Value", "Text");

                //For AdmissionType
                List<OrganisationAdmissionTypeMaster> OrganisationAdmissionTypeMasterList = GetListOrganisationAdmissionTypeMaster();
                List<SelectListItem> OrganisationAdmissionTypeMaster = new List<SelectListItem>();
                foreach (OrganisationAdmissionTypeMaster item in OrganisationAdmissionTypeMasterList)
                {
                    OrganisationAdmissionTypeMaster.Add(new SelectListItem { Text = item.AdmissionType, Value = item.ID.ToString() });
                }
                ViewBag.OrganisationAdmissionTypeMaster = new SelectList(OrganisationAdmissionTypeMaster, "Value", "Text");

                //For AllotAdmission
                List<OrganisationAllotAdmissionMaster> OrganisationAllotAdmissionMasterList = GetListOrganisationAllotAdmissionMaster();
                List<SelectListItem> OrganisationAllotAdmissionMaster = new List<SelectListItem>();
                foreach (OrganisationAllotAdmissionMaster item in OrganisationAllotAdmissionMasterList)
                {
                    OrganisationAllotAdmissionMaster.Add(new SelectListItem { Text = item.AllotAdmission, Value = item.ID.ToString() });
                }
                ViewBag.OrganisationAllotAdmissionMaster = new SelectList(OrganisationAllotAdmissionMaster, "Value", "Text");

                //For EconomicallyBackwardClass 
                List<SelectListItem> StudentRegistrationForm_StudentEconomicallyBackwardClass = new List<SelectListItem>();
                ViewBag.StudentRegistrationForm_StudentEconomicallyBackwardClass = new SelectList(StudentRegistrationForm_StudentEconomicallyBackwardClass, "Value", "Text");
                List<SelectListItem> li_StudentRegistrationForm_StudentEconomicallyBackwardClass = new List<SelectListItem>();
                li_StudentRegistrationForm_StudentEconomicallyBackwardClass.Add(new SelectListItem { Text = "NO", Value = "0" });
                li_StudentRegistrationForm_StudentEconomicallyBackwardClass.Add(new SelectListItem { Text = "YES", Value = "1" });
                ViewData["StudentEconomicallyBackwardClass"] = new SelectList(li_StudentRegistrationForm_StudentEconomicallyBackwardClass, "Value", "Text", model.StudentRegistrationFormDTO.StudentEconomicallyBackwardClass);

                //for Country 
                List<GeneralCountryMaster> GeneralCountryMasterList = GetListGeneralCountryMaster();
                List<SelectListItem> GeneralCountryMaster = new List<SelectListItem>();
                foreach (GeneralCountryMaster item in GeneralCountryMasterList)
                {
                    GeneralCountryMaster.Add(new SelectListItem { Text = item.CountryName, Value = item.ID.ToString() });
                }

                ViewBag.GeneralCountryList = new SelectList(GeneralCountryMaster, "Value", "Text");


                //for Region  Perticular Country
                string SelectedCountryID = string.Empty;
                //   List<GeneralRegionMaster> generalRegionMasterForPerticularCountryList = GetListGeneralRegionMaster(SelectedCountryID);
                List<SelectListItem> generalRegionMasterForPerticularCountry = new List<SelectListItem>();
                //foreach (GeneralRegionMaster item in generalRegionMasterForPerticularCountryList)
                //{
                //    generalRegionMasterForPerticularCountry.Add(new SelectListItem { Text = item.RegionName, Value = item.ID.ToString() });
                //}
                ViewBag.GeneralRegionMasterForPerticularCountry = new SelectList(generalRegionMaster, "Value", "Text");


                //List<SelectListItem> GeneralBlankRegionMaster = new List<SelectListItem>();
                ////foreach (GeneralCityMaster item in GeneralCityMasterList)
                ////{
                ////    GeneralCityMaster.Add(new SelectListItem { Text = item.Description, Value = item.ID.ToString() });
                ////}

                //ViewBag.GeneralBlankRegionMasterList = new SelectList(GeneralBlankRegionMaster, "Value", "Text");

                ////for City  
                //// string SelectedRegionID = "A";

                //// List<GeneralCityMaster> GeneralCityMasterList = GetListGeneralCityMaster(SelectedRegionID);
                //List<SelectListItem> GeneralCityMaster = new List<SelectListItem>();
                ////foreach (GeneralCityMaster item in GeneralCityMasterList)
                ////{
                ////    GeneralCityMaster.Add(new SelectListItem { Text = item.Description, Value = item.ID.ToString() });
                ////}

                //ViewBag.GeneralCityList = new SelectList(GeneralCityMaster, "Value", "Text");


                //List<SelectListItem> GeneralLocationMaster = new List<SelectListItem>();
                //ViewBag.GeneralLocationList = new SelectList(GeneralLocationMaster, "Value", "Text");


                //For City_Tahsil_Pattern
                List<SelectListItem> StudentRegistrationForm_PermanentAddress_City_Tahsil_Pattern = new List<SelectListItem>();
                ViewBag.StudentRegistrationForm_PermanentAddress_City_Tahsil_Pattern = new SelectList(StudentRegistrationForm_PermanentAddress_City_Tahsil_Pattern, "Value", "Text");
                List<SelectListItem> li_StudentRegistrationForm_PermanentAddress_City_Tahsil_Pattern = new List<SelectListItem>();
                li_StudentRegistrationForm_PermanentAddress_City_Tahsil_Pattern.Add(new SelectListItem { Text = "Urban", Value = "U" });
                li_StudentRegistrationForm_PermanentAddress_City_Tahsil_Pattern.Add(new SelectListItem { Text = "Rural", Value = "R" });
                li_StudentRegistrationForm_PermanentAddress_City_Tahsil_Pattern.Add(new SelectListItem { Text = "Tribal", Value = "T" });
                ViewData["Student_PermanentAddress_City_Tahsil_Pattern"] = new SelectList(li_StudentRegistrationForm_PermanentAddress_City_Tahsil_Pattern, "Value", "Text", model.StudentRegistrationFormDTO.Student_PermanentAddress_City_Tahsil_Pattern);

                ViewData["Student_CorrespondenceAddress_City_Tahsil_Pattern"] = new SelectList(li_StudentRegistrationForm_PermanentAddress_City_Tahsil_Pattern, "Value", "Text", model.StudentRegistrationFormDTO.Student_CorrespondenceAddress_City_Tahsil_Pattern);
                //For Exam_Pattern
                List<SelectListItem> StudentRegistrationForm_Exam_Pattern = new List<SelectListItem>();
                ViewBag.StudentRegistrationForm_Exam_Pattern = new SelectList(StudentRegistrationForm_Exam_Pattern, "Value", "Text");
                List<SelectListItem> li_StudentRegistrationForm_Exam_Pattern = new List<SelectListItem>();
                li_StudentRegistrationForm_Exam_Pattern.Add(new SelectListItem { Text = "Yearly", Value = "Y" });
                li_StudentRegistrationForm_Exam_Pattern.Add(new SelectListItem { Text = "Semester", Value = "S" });
                ViewData["Student_Qualification_Diploma_ITI_Details_ExamPattern"] = new SelectList(li_StudentRegistrationForm_Exam_Pattern, "Value", "Text", model.StudentRegistrationFormDTO.Student_Qualification_Diploma_ITI_Details_ExamPattern);
                ViewData["Student_Qualification_DegreeDetails_ExamPattern"] = new SelectList(li_StudentRegistrationForm_Exam_Pattern, "Value", "Text", model.StudentRegistrationFormDTO.Student_Qualification_DegreeDetails_ExamPattern);
                ViewData["Student_Qualification_PostGraduationDetails_ExamPattern"] = new SelectList(li_StudentRegistrationForm_Exam_Pattern, "Value", "Text", model.StudentRegistrationFormDTO.Student_Qualification_PostGraduationDetails_ExamPattern);
                //For FatherHusband
                List<SelectListItem> StudentRegistrationForm_FatherHusband = new List<SelectListItem>();
                ViewBag.StudentRegistrationForm_FatherHusband = new SelectList(StudentRegistrationForm_FatherHusband, "Value", "Text");
                List<SelectListItem> li_StudentRegistrationForm_FatherHusband = new List<SelectListItem>();
                li_StudentRegistrationForm_FatherHusband.Add(new SelectListItem { Text = "Father", Value = "F" });
                li_StudentRegistrationForm_FatherHusband.Add(new SelectListItem { Text = "Husband", Value = "H" });
                ViewData["StudentRegistrationForm_FatherHusband"] = li_StudentRegistrationForm_FatherHusband;

                //For Qualification_General_MediumOfInstitution

                List<OrganisationMediumMaster> organisationMediumMasterList = GetListOrganisationMediumMaster();
                List<SelectListItem> organisationMediumMaster = new List<SelectListItem>();
                foreach (OrganisationMediumMaster item in organisationMediumMasterList)
                {
                    organisationMediumMaster.Add(new SelectListItem { Text = item.Description, Value = item.ID.ToString() });
                }
                ViewBag.organisationMediumMaster = new SelectList(organisationMediumMaster, "Value", "Text");

                //For Month
                List<SelectListItem> Student_Qualification_General_MonthOfPassing = new List<SelectListItem>();
                ViewBag.Student_Qualification_General_MonthOfPassing = new SelectList(Student_Qualification_General_MonthOfPassing, "Value", "Text");
                List<SelectListItem> li_Student_Qualification_General_MonthOfPassing = new List<SelectListItem>();
                li_Student_Qualification_General_MonthOfPassing.Add(new SelectListItem { Text = "-- Select Month --", Value = "0" });
                li_Student_Qualification_General_MonthOfPassing.Add(new SelectListItem { Text = "January", Value = "1" });
                li_Student_Qualification_General_MonthOfPassing.Add(new SelectListItem { Text = "February", Value = "2" });
                li_Student_Qualification_General_MonthOfPassing.Add(new SelectListItem { Text = "March", Value = "3" });
                li_Student_Qualification_General_MonthOfPassing.Add(new SelectListItem { Text = "April", Value = "4" });
                li_Student_Qualification_General_MonthOfPassing.Add(new SelectListItem { Text = "May", Value = "5" });
                li_Student_Qualification_General_MonthOfPassing.Add(new SelectListItem { Text = "June", Value = "6" });
                li_Student_Qualification_General_MonthOfPassing.Add(new SelectListItem { Text = "July", Value = "7" });
                li_Student_Qualification_General_MonthOfPassing.Add(new SelectListItem { Text = "August", Value = "8" });
                li_Student_Qualification_General_MonthOfPassing.Add(new SelectListItem { Text = "September", Value = "9" });
                li_Student_Qualification_General_MonthOfPassing.Add(new SelectListItem { Text = "October", Value = "10" });
                li_Student_Qualification_General_MonthOfPassing.Add(new SelectListItem { Text = "November", Value = "11" });
                li_Student_Qualification_General_MonthOfPassing.Add(new SelectListItem { Text = "December", Value = "12" });
                ViewData["Student_Qualification_General_MonthOfPassing"] = new SelectList(li_Student_Qualification_General_MonthOfPassing, "Value", "Text", model.StudentRegistrationFormDTO.Student_Qualification_General_MonthOfPassing);
                ViewData["Student_Qualification_SSC_MonthOfPassing"] = new SelectList(li_Student_Qualification_General_MonthOfPassing, "Value", "Text", model.StudentRegistrationFormDTO.Student_Qualification_SSC_MonthOfPassing);
                ViewData["Student_Qualification_HSC_MonthOfPassing"] = new SelectList(li_Student_Qualification_General_MonthOfPassing, "Value", "Text", model.StudentRegistrationFormDTO.Student_Qualification_HSC_MonthOfPassing);
                ViewData["Student_Qualification_Diploma_ITI_Details_MonthOfPassing"] = new SelectList(li_Student_Qualification_General_MonthOfPassing, "Value", "Text", model.StudentRegistrationFormDTO.Student_Qualification_Diploma_ITI_Details_MonthOfPassing);
                ViewData["Student_Qualification_DegreeDetails_MonthOfPassing"] = new SelectList(li_Student_Qualification_General_MonthOfPassing, "Value", "Text", model.StudentRegistrationFormDTO.Student_Qualification_DegreeDetails_MonthOfPassing);
                ViewData["Student_Qualification_PostGraduationDetails_MonthOfPassing"] = new SelectList(li_Student_Qualification_General_MonthOfPassing, "Value", "Text", model.StudentRegistrationFormDTO.Student_Qualification_PostGraduationDetails_MonthOfPassing);

                //For Year
                int year = DateTime.Now.Year - 65;
                List<SelectListItem> Student_Qualification_General_YearOfPassing = new List<SelectListItem>();
                ViewBag.Student_Qualification_General_YearOfPassing = new SelectList(Student_Qualification_General_YearOfPassing, "Value", "Text");
                List<SelectListItem> li_Student_Qualification_General_YearOfPassing = new List<SelectListItem>();

                li_Student_Qualification_General_YearOfPassing.Add(new SelectListItem { Text = "-- Select Year --", Value = "0" });
                for (int i = DateTime.Now.Year; year <= i; i--)
                {
                    li_Student_Qualification_General_YearOfPassing.Add(new SelectListItem { Text = Convert.ToString(i), Value = Convert.ToString(i) });
                }
                ViewData["Student_Qualification_General_YearOfPassing"] = new SelectList(li_Student_Qualification_General_YearOfPassing, "Value", "Text", model.StudentRegistrationFormDTO.Student_Qualification_General_YearOfPassing);
                ViewData["Student_Qualification_SSC_YearOfPassing"] = new SelectList(li_Student_Qualification_General_YearOfPassing, "Value", "Text", model.StudentRegistrationFormDTO.Student_Qualification_SSC_YearOfPassing);
                ViewData["Student_Qualification_HSC_YearOfPassing"] = new SelectList(li_Student_Qualification_General_YearOfPassing, "Value", "Text", model.StudentRegistrationFormDTO.Student_Qualification_HSC_YearOfPassing);
                ViewData["Student_Qualification_Diploma_ITI_Details_YearOfPassing"] = new SelectList(li_Student_Qualification_General_YearOfPassing, "Value", "Text", model.StudentRegistrationFormDTO.Student_Qualification_Diploma_ITI_Details_YearOfPassing);
                ViewData["Student_Qualification_DegreeDetails_YearOfPassing"] = new SelectList(li_Student_Qualification_General_YearOfPassing, "Value", "Text", model.StudentRegistrationFormDTO.Student_Qualification_DegreeDetails_YearOfPassing);
                ViewData["Student_Qualification_PostGraduationDetails_YearOfPassing"] = new SelectList(li_Student_Qualification_General_YearOfPassing, "Value", "Text", model.StudentRegistrationFormDTO.Student_Qualification_PostGraduationDetails_YearOfPassing);


                //For For Count Number
                List<SelectListItem> StudentRegistrationForm_NumberList = new List<SelectListItem>();
                ViewBag.StudentRegistrationForm_Number = new SelectList(StudentRegistrationForm_NumberList, "Value", "Text");
                List<SelectListItem> li_StudentRegistrationForm_Number = new List<SelectListItem>();

                li_StudentRegistrationForm_Number.Add(new SelectListItem { Text = "-- Select --", Value = "" });
                for (int i = 1; i <= 10; i++)
                {
                    li_StudentRegistrationForm_Number.Add(new SelectListItem { Text = Convert.ToString(i), Value = Convert.ToString(i) });
                }
                ViewData["StudentRegistrationForm_Number"] = li_StudentRegistrationForm_Number;

                //For University

                List<OrganisationUniversityMaster> OrganisationUniversityMasterList = GetListOrganisationUniversityMasterWithoutCenterCode();
                List<SelectListItem> OrganisationUniversityMaster = new List<SelectListItem>();
                foreach (OrganisationUniversityMaster item in OrganisationUniversityMasterList)
                {
                    OrganisationUniversityMaster.Add(new SelectListItem { Text = item.UniversityName, Value = item.ID.ToString() });
                }
                OrganisationUniversityMaster.Add(new SelectListItem { Text = "Other", Value = "Other" });
                ViewBag.OrganisationUniversityMasterList = new SelectList(OrganisationUniversityMaster, "Value", "Text");


                //For Stream

                List<OrganisationStreamMaster> OrganisationStreamMasterMasterList = GetListOrganisationStreamMaster();
                List<SelectListItem> OrganisationStreamMasterMaster = new List<SelectListItem>();
                foreach (OrganisationStreamMaster item in OrganisationStreamMasterMasterList)
                {
                    OrganisationStreamMasterMaster.Add(new SelectListItem { Text = item.StreamDescription, Value = item.ID.ToString() });
                }
                //  OrganisationStreamMasterMaster.Add(new SelectListItem { Text = "Other", Value = "Other" });
                ViewBag.OrganisationStreamMasterMasterList = new SelectList(OrganisationStreamMasterMaster, "Value", "Text");

                //For Class
                List<SelectListItem> StudentRegistrationForm_Class = new List<SelectListItem>();
                ViewBag.StudentRegistrationForm_Class = new SelectList(StudentRegistrationForm_Class, "Value", "Text");
                List<SelectListItem> li_StudentRegistrationForm_Class = new List<SelectListItem>();
                li_StudentRegistrationForm_Class.Add(new SelectListItem { Text = "First", Value = "1" });
                li_StudentRegistrationForm_Class.Add(new SelectListItem { Text = "Second", Value = "2" });
                li_StudentRegistrationForm_Class.Add(new SelectListItem { Text = "Third", Value = "3" });
                li_StudentRegistrationForm_Class.Add(new SelectListItem { Text = "Fourth", Value = "4" });
                ViewData["Student_Qualification_HSC_Class"] = new SelectList(li_StudentRegistrationForm_Class, "Value", "Text", model.StudentRegistrationFormDTO.Student_Qualification_HSC_Class);
                ViewData["Student_Qualification_Diploma_ITI_Details_Class"] = new SelectList(li_StudentRegistrationForm_Class, "Value", "Text", model.StudentRegistrationFormDTO.Student_Qualification_Diploma_ITI_Details_Class);
                ViewData["Student_Qualification_DegreeDetails_Class"] = new SelectList(li_StudentRegistrationForm_Class, "Value", "Text", model.StudentRegistrationFormDTO.Student_Qualification_DegreeDetails_Class);
                ViewData["Student_Qualification_PostGraduationDetails_Class"] = new SelectList(li_StudentRegistrationForm_Class, "Value", "Text", model.StudentRegistrationFormDTO.Student_Qualification_PostGraduationDetails_Class);
                #endregion Method
                model.StudentRegistrationFormList = GetListStudentRegistrationForm(model.StudentRegistrationFormDTO.CenterCode, model.StudentRegistrationFormDTO.UniversityID, model.StudentRegistrationFormDTO.BranchDetailID, model.StudentRegistrationFormDTO.StandardNumber);


                List<ToolTemplateApplicable> organisationBranchDetailList = GetListBranchDetails(model.StudentRegistrationFormDTO.UniversityID, model.StudentRegistrationFormDTO.CenterCode);
                List<SelectListItem> organisationBranchDetail = new List<SelectListItem>();
                foreach (ToolTemplateApplicable item in organisationBranchDetailList)
                {
                    organisationBranchDetail.Add(new SelectListItem { Text = item.BranchDescription + "(" + item.DivisionDescription + ")", Value = item.BranchDetailID.ToString() });
                }
                ViewBag.organisationBranchDetail = new SelectList(organisationBranchDetail, "Value", "Text");

                //// For Qualifying Exam
                //List<StudentRegistrationForm> studentRegistrationFormQualifyingExamList = GetListStudentRegistrationFormQualifyingExamList(model.StudentRegistrationFormDTO.BranchDetailID, model.StudentRegistrationFormDTO.StandardNumber);
                //List<SelectListItem> studentRegistrationFormQualifyingExam = new List<SelectListItem>();
                //foreach (StudentRegistrationForm item in studentRegistrationFormQualifyingExamList)
                //{
                //    studentRegistrationFormQualifyingExam.Add(new SelectListItem { Text = item.Student_QualifyingExamName, Value = item.Student_QualifyingExamId.ToString() });
                //}
                //ViewBag.studentRegistrationFormQualifyingExamList = new SelectList(studentRegistrationFormQualifyingExam, "Value", "Text");
                //  For Qualifying Exam Subject
                model.QualifyingExamSubjectList = GetListQualifyingExamSubject(model.StudentRegistrationFormDTO.ID);

                // For Qualification Exam Subject   for General
                model.QualificationMasterSubjectListForGeneral = GetByQualificationSubjectListByStudentRegistrationIDAndEducationType(model.StudentRegistrationFormDTO.ID, "G");

                // For Qualification Exam Subject   for SSC
                model.QualificationMasterSubjectListForSSC = GetByQualificationSubjectListByStudentRegistrationIDAndEducationType(model.StudentRegistrationFormDTO.ID, "S");

                // For Qualification Exam Subject   for HSC
                model.QualificationMasterSubjectListForHSC = GetByQualificationSubjectListByStudentRegistrationIDAndEducationType(model.StudentRegistrationFormDTO.ID, "H");
                // for Academic year
                List<OrganisationCentrewiseSession> list = GetCurrentSession(model.StudentRegistrationFormDTO.CenterCode);
                model.Student_AcademicYear = list.Count > 0 ? list[0].SessionName : "Session not defined !";
                model.Student_AcademicYearId = list.Count > 0 ? list[0].SessionID : 0;

                // for previous work experience
                model.PreviousWorkExperienceList = GetPreviousWorkExperience(model.StudentRegistrationFormDTO.ID);

                //  For Course year 
                model.OrganisationCourseYearDetailsDTO = GetCourseYearByBranchDetIDAndStandardNumber(model.BranchDetailID, model.StandardNumber);
                if (model.OrganisationCourseYearDetailsDTO.Description == "" || model.OrganisationCourseYearDetailsDTO.Description == null)
                {
                    model.Student_CourseYearName = "";
                }
                else
                {
                    model.Student_CourseYearName = model.OrganisationCourseYearDetailsDTO.Description;
                }
                if (model.OrganisationCourseYearDetailsDTO.Description == "" || model.OrganisationCourseYearDetailsDTO.Description == null)
                {
                    model.Student_CourseYearId = 0;
                }
                else
                {
                    model.Student_CourseYearId = model.OrganisationCourseYearDetailsDTO.ID;
                }



                ////For Branch Details
                model.OrganisationBranchDetailsDTO = GetOrganisationBranchDetailsSelectByID(model.BranchDetailID);
                model.Student_CourseName = model.OrganisationBranchDetailsDTO.BranchDescription;
                model.StudentRegistrationFormDTO.StudentSelfRegistrationID = response.Entity.StudentSelfRegistrationID;
                ////For Task Approval               
                //model.TaskCode = TaskCode;
                //model.TaskNotificationDetailsID = Convert.ToInt32(TNDID);
                //model.TaskNotificationMasterID = Convert.ToInt32(TNMID);
                //model.GeneralTaskReportingDetailsID = Convert.ToInt32(GTRDID1);
                //model.PersonID = Convert.ToInt32(PersonID);
                //model.StageSequenceNumber = Convert.ToInt32(StageSequenceNumber);
                //model.IsLastRecord = Convert.ToBoolean(IsLast);


                // GeneralTaskReportingDetails GeneralTaskReportingDetailsDTO = new GeneralTaskReportingDetails();
                //GeneralTaskReportingDetailsDTO.TaskNotificationMasterID = model.TaskNotificationMasterID;
                //GeneralTaskReportingDetailsDTO.ModifiedBy = Convert.ToInt32(Session["UserID"]);
                //GeneralTaskReportingDetailsDTO.ConnectionString = _connectioString;
                //IBaseEntityResponse<GeneralTaskReportingDetails> response1 = _generalTaskReportingDetailsServiceAccess.UpdateEnagedByUserID(GeneralTaskReportingDetailsDTO);
                //model.StudentRegistrationFormDTO.errorMessage = CheckError((response1.Entity != null) ? response1.Entity.ErrorCode : 20, ActionModeEnum.Update);
                return View("/Views/StudentRegistrationForm/EditV2.cshtml", model);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public ActionResult Edit(StudentRegistrationFormViewModel model)
        {

            //if (ModelState.IsValid)
            //{
            if (model != null && model.StudentRegistrationFormDTO != null)
            {

                model.StudentRegistrationFormDTO.ConnectionString = _connectioString;

                // For Hidden Field
              
                model.StudentRegistrationFormDTO.Student_QualifyingExamId = model.Student_QualifyingExamId;
                model.StudentRegistrationFormDTO.BranchDetailID = model.BranchDetailID;
                model.StudentRegistrationFormDTO.StandardNumber = model.StandardNumber;
                model.StudentRegistrationFormDTO.AdmissionPattern = model.AdmissionPattern;
                model.StudentRegistrationFormDTO.Student_AcademicYearId = model.Student_AcademicYearId;
                model.StudentRegistrationFormDTO.Student_AcademicYear = model.Student_AcademicYear;
                model.StudentRegistrationFormDTO.Student_CourseYearId = model.Student_CourseYearId;
                model.StudentRegistrationFormDTO.Student_DateofRegistration = model.Student_DateofRegistration;
                model.StudentRegistrationFormDTO.CenterCode = model.CenterCode;
                model.StudentRegistrationFormDTO.UniversityID = model.UniversityID;
                model.StudentRegistrationFormDTO.StudentSelfRegistrationID = model.StudentSelfRegistrationID;
                model.StudentRegistrationFormDTO.ToolRegistrationTemplateMstID = model.ToolRegistrationTemplateMstID;
                model.StudentRegistrationFormDTO.ID = model.ID;
                // upload Data
                //for Photo
                model.StudentRegistrationFormDTO.StudentPhoto = model.StudentPhoto;
                model.StudentRegistrationFormDTO.StudentPhotoFilename = model.StudentPhotoFilename;
                model.StudentRegistrationFormDTO.StudentPhotoType = model.StudentPhotoType;
                model.StudentRegistrationFormDTO.StudentPhotoFileSize = model.StudentPhotoFileSize;
                model.StudentRegistrationFormDTO.StudentPhotoFileWidth = model.StudentPhotoFileWidth;
                model.StudentRegistrationFormDTO.StudentPhotoFileHeight = model.StudentPhotoFileHeight;

                //for Signature
                model.StudentRegistrationFormDTO.StudentSignature = model.StudentSignature;
                model.StudentRegistrationFormDTO.StudentSignatureFilename = model.StudentSignatureFilename;
                model.StudentRegistrationFormDTO.StudentSignatureType = model.StudentSignatureType;
                model.StudentRegistrationFormDTO.StudentSignatureFileSize = model.StudentSignatureFileSize;
                model.StudentRegistrationFormDTO.StudentSignatureFileWidth = model.StudentSignatureFileWidth;
                model.StudentRegistrationFormDTO.StudentSignatureFileHeight = model.StudentSignatureFileHeight;

                //for Thumb
                model.StudentRegistrationFormDTO.StudentThumb = model.StudentThumb;
                model.StudentRegistrationFormDTO.StudentThumbFilename = model.StudentThumbFilename;
                model.StudentRegistrationFormDTO.StudentThumbType = model.StudentThumbType;
                model.StudentRegistrationFormDTO.StudentThumbFileSize = model.StudentThumbFileSize;
                model.StudentRegistrationFormDTO.StudentThumbFileWidth = model.StudentThumbFileWidth;
                model.StudentRegistrationFormDTO.StudentThumbFileHeight = model.StudentThumbFileHeight;

                // Student Personal Information 
                model.StudentRegistrationFormDTO.StudentTitle = model.StudentTitle;
                model.StudentRegistrationFormDTO.StudentFirstName = model.StudentFirstName;
                model.StudentRegistrationFormDTO.StudentMiddleName = model.StudentMiddleName;
                model.StudentRegistrationFormDTO.StudentLastName = model.StudentLastName;
                model.StudentRegistrationFormDTO.StudentEmailID = model.StudentEmailID;
                model.StudentRegistrationFormDTO.StudentGender = model.StudentGender;
                model.StudentRegistrationFormDTO.StudentMobileNumber = model.StudentMobileNumber;
                model.StudentRegistrationFormDTO.StudentLandLineNumber = model.StudentLandLineNumber;
                model.StudentRegistrationFormDTO.StudentEmploymentSector = model.StudentEmploymentSector;
                model.StudentRegistrationFormDTO.StudentOccupation = model.StudentOccupation;
                model.StudentRegistrationFormDTO.StudentDesignation = model.StudentDesignation;
                model.StudentRegistrationFormDTO.StudentOrganizationName = model.StudentOrganizationName;
                model.StudentRegistrationFormDTO.StudentOfficeContactNo = model.StudentOfficeContactNo;
                model.StudentRegistrationFormDTO.StudentAnnualIncome = model.StudentAnnualIncome;

                //Father/Husband Personal Information 
                model.StudentRegistrationFormDTO.FatherTitle = model.FatherTitle;
                model.StudentRegistrationFormDTO.FatherHusbondType = model.FatherHusbondType;
                model.StudentRegistrationFormDTO.FatherFirstName = model.FatherFirstName;
                model.StudentRegistrationFormDTO.FatherMiddleName = model.FatherMiddleName;
                model.StudentRegistrationFormDTO.FatherLastName = model.FatherLastName;
                model.StudentRegistrationFormDTO.FatherEmailId = model.FatherEmailId;
                model.StudentRegistrationFormDTO.FatherMobileNumber = model.FatherMobileNumber;
                model.StudentRegistrationFormDTO.FatherLandLineNumber = model.FatherLandLineNumber;
                model.StudentRegistrationFormDTO.FatherEmploymentSector = model.FatherEmploymentSector;
                model.StudentRegistrationFormDTO.FatherOccupation = model.FatherOccupation;
                model.StudentRegistrationFormDTO.FatherDesignation = model.FatherDesignation;
                model.StudentRegistrationFormDTO.FatherOrganizationName = model.FatherOrganizationName;
                model.StudentRegistrationFormDTO.FatherOfficeContactNo = model.FatherOfficeContactNo;
                model.StudentRegistrationFormDTO.FatherAnnualIncome = model.FatherAnnualIncome;

                //Mother Personal Information
                model.StudentRegistrationFormDTO.MotherTitle = model.MotherTitle;
                model.StudentRegistrationFormDTO.MotherFirstName = model.MotherFirstName;
                model.StudentRegistrationFormDTO.MotherMiddleName = model.MotherMiddleName;
                model.StudentRegistrationFormDTO.MotherLastName = model.MotherLastName;
                model.StudentRegistrationFormDTO.MotherEmailId = model.MotherEmailId;
                model.StudentRegistrationFormDTO.MotherMobileNumber = model.MotherMobileNumber;
                model.StudentRegistrationFormDTO.MotherLandLineNumber = model.MotherLandLineNumber;
                model.StudentRegistrationFormDTO.MotherEmploymentSector = model.MotherEmploymentSector;
                model.StudentRegistrationFormDTO.MotherOccupation = model.MotherOccupation;
                model.StudentRegistrationFormDTO.MotherDesignation = model.MotherDesignation;
                model.StudentRegistrationFormDTO.MotherOrganizationName = model.MotherOrganizationName;
                model.StudentRegistrationFormDTO.MotherOfficeContactNo = model.MotherOfficeContactNo;
                model.StudentRegistrationFormDTO.MotherAnnualIncome = model.MotherAnnualIncome;

                //Guardian Personal Information 
                model.StudentRegistrationFormDTO.GuardianTitle = model.GuardianTitle;
                model.StudentRegistrationFormDTO.GuardianFirstName = model.GuardianFirstName;
                model.StudentRegistrationFormDTO.GuardianMiddleName = model.GuardianMiddleName;
                model.StudentRegistrationFormDTO.GuardianLastName = model.GuardianLastName;
                model.StudentRegistrationFormDTO.GuardianEmailId = model.GuardianEmailId;
                model.StudentRegistrationFormDTO.GuardianMobileNumber = model.GuardianMobileNumber;
                model.StudentRegistrationFormDTO.GuardianLandLineNumber = model.GuardianLandLineNumber;
                model.StudentRegistrationFormDTO.GuardianEmploymentSector = model.GuardianEmploymentSector;
                model.StudentRegistrationFormDTO.GuardianOccupation = model.GuardianOccupation;
                model.StudentRegistrationFormDTO.GuardianDesignation = model.GuardianDesignation;
                model.StudentRegistrationFormDTO.GuardianOrganizationName = model.GuardianOrganizationName;
                model.StudentRegistrationFormDTO.GuardianOfficeContactNo = model.GuardianOfficeContactNo;
                model.StudentRegistrationFormDTO.GuardianAnnualIncome = model.GuardianAnnualIncome;

                //Student Specific Information 
                model.StudentRegistrationFormDTO.StudentEnrollmentNo = model.StudentEnrollmentNo;
                model.StudentRegistrationFormDTO.StudentNRI_POI = model.StudentNRI_POI;
                model.StudentRegistrationFormDTO.StudentMigrationNumber = model.StudentMigrationNumber;
                model.StudentRegistrationFormDTO.StudentNationalityID = model.StudentNationalityID;
                model.StudentRegistrationFormDTO.StudentMigrationDate = model.StudentMigrationDate;
                model.StudentRegistrationFormDTO.StudentRegionID = model.StudentRegionID;
                //  model.StudentRegistrationFormDTO.StudentRegionOther = model.StudentRegionOther;
                model.StudentRegistrationFormDTO.StudentMaritalStatus = model.StudentMaritalStatus;
                model.StudentRegistrationFormDTO.StudentDomicileStateofFather = model.StudentDomicileStateofFather;
                model.StudentRegistrationFormDTO.StudentBloodGroup = model.StudentBloodGroup;
                model.StudentRegistrationFormDTO.StudentDomicileStateofMother = model.StudentDomicileStateofMother;
                model.StudentRegistrationFormDTO.PhysicallyHandicapped = model.PhysicallyHandicapped;
                model.StudentRegistrationFormDTO.StudentEmploymentStatus = model.StudentEmploymentStatus;
                model.StudentRegistrationFormDTO.StudentIdentificationMark = model.StudentIdentificationMark;
                model.StudentRegistrationFormDTO.StudentPrevNameofStudent = model.StudentPrevNameofStudent;
                model.StudentRegistrationFormDTO.StudentOrgandonor = model.StudentOrgandonor;
                model.StudentRegistrationFormDTO.StudentReasonforNamechange = model.StudentReasonforNamechange;
                if (model.StudentRegionID == 0)
                {
                    model.StudentRegistrationFormDTO.Student_Domesile_CountryId = model.Student_Domesile_CountryId;
                    model.StudentRegistrationFormDTO.StudentRegionOther = model.StudentRegionOther;
                }
                else
                {
                    model.StudentRegistrationFormDTO.Student_Domesile_CountryId = 0;
                    model.StudentRegistrationFormDTO.StudentRegionOther = null;
                }

                //Information As Per Leaving Certificate 
                model.StudentRegistrationFormDTO.StudentDateofBirth = model.StudentDateofBirth;
                model.StudentRegistrationFormDTO.StudentBirthPlace = model.StudentBirthPlace;
                model.StudentRegistrationFormDTO.StudentReligionID = model.StudentReligionID;
                model.StudentRegistrationFormDTO.StudentCategoryID = model.StudentCategoryID;
                model.StudentRegistrationFormDTO.StudentCasteID = model.StudentCasteID;
                model.StudentRegistrationFormDTO.StudentCasteAsPerTC_LC = model.StudentCasteAsPerTC_LC;
                model.StudentRegistrationFormDTO.StudentMotherTongueID = model.StudentMotherTongueID;
                model.StudentRegistrationFormDTO.StudentNameAsPerMarkSheet = model.StudentNameAsPerMarkSheet;
                model.StudentRegistrationFormDTO.StudentLastSchool_College = model.StudentLastSchool_College;
                model.StudentRegistrationFormDTO.StudentPreviousLC_TCNo = model.StudentPreviousLC_TCNo;

                //Social Reservation Information 

                model.StudentRegistrationFormDTO.Student_Ex_Serviceman_Ward_of_Ex_Serviceman = model.Student_Ex_Serviceman_Ward_of_Ex_Serviceman;
                model.StudentRegistrationFormDTO.Student_Active_Serviceman_Ward_of_Active_Serviceman = model.Student_Active_Serviceman_Ward_of_Active_Serviceman;
                model.StudentRegistrationFormDTO.Student_FreedomFighterWardOfFreedomFighter = model.Student_FreedomFighterWardOfFreedomFighter;
                model.StudentRegistrationFormDTO.Student_WardofPrimaryTeacher = model.Student_WardofPrimaryTeacher;
                model.StudentRegistrationFormDTO.Student_WardofSecondaryTeacher = model.Student_WardofSecondaryTeacher;
                model.StudentRegistrationFormDTO.Student_Deserted_Divorced_Widowed_Women = model.Student_Deserted_Divorced_Widowed_Women;
                model.StudentRegistrationFormDTO.Student_MemberofProjectAffectedFamily = model.Student_MemberofProjectAffectedFamily;
                model.StudentRegistrationFormDTO.Student_MemberofEarthquakeAffectedFamily = model.Student_MemberofEarthquakeAffectedFamily;
                model.StudentRegistrationFormDTO.Student_MemberofFloodFamineAffectedFamily = model.Student_MemberofFloodFamineAffectedFamily;
                model.StudentRegistrationFormDTO.Student_ResidentofTribalArea = model.Student_ResidentofTribalArea;
                model.StudentRegistrationFormDTO.Student_KashmirMigrant = model.Student_KashmirMigrant;

                //Other Information Of The Student 
                model.StudentRegistrationFormDTO.StudentIndicatetypeofCandidature = model.StudentIndicatetypeofCandidature;
                model.StudentRegistrationFormDTO.StudentSchoolFromHSCExaminationpassed = model.StudentSchoolFromHSCExaminationpassed;
                model.StudentRegistrationFormDTO.StudentEconomicallyBackwardClass = model.StudentEconomicallyBackwardClass;
                model.StudentRegistrationFormDTO.StudentsNameOfDistrictWhereParentDomiciled = model.StudentsNameOfDistrictWhereParentDomiciled;
                model.StudentRegistrationFormDTO.StudentsMKBCandidate = model.StudentsMKBCandidate;

                //Address Information 
                //Permanent Address
                model.StudentRegistrationFormDTO.Student_PermanentAddress_PloteNo = model.Student_PermanentAddress_PloteNo;
                model.StudentRegistrationFormDTO.Student_PermanentAddress_StreeNo = model.Student_PermanentAddress_StreeNo;
                model.StudentRegistrationFormDTO.Student_PermanentAddress_Address1 = model.Student_PermanentAddress_Address1;
                model.StudentRegistrationFormDTO.Student_PermanentAddress_Address2 = model.Student_PermanentAddress_Address2;
                model.StudentRegistrationFormDTO.Student_PermanentAddress_City_TahsilID = model.Student_PermanentAddress_City_TahsilID;
                model.StudentRegistrationFormDTO.Student_PermanentAddress_City_TahsilOther = model.Student_PermanentAddress_City_TahsilOther;
                model.StudentRegistrationFormDTO.Student_PermanentAddress_CountryId = model.Student_PermanentAddress_CountryId;
                model.StudentRegistrationFormDTO.Student_PermanentAddress_State = model.Student_PermanentAddress_State;
                model.StudentRegistrationFormDTO.Student_PermanentAddress_StateOther = model.Student_PermanentAddress_StateOther;
                model.StudentRegistrationFormDTO.Student_PermanentAddress_DistrictID = model.Student_PermanentAddress_DistrictID;
                model.StudentRegistrationFormDTO.Student_PermanentAddress_DistrictOther = model.Student_PermanentAddress_DistrictOther;
                model.StudentRegistrationFormDTO.Student_PermanentAddress_Tahsil = model.Student_PermanentAddress_Tahsil;
                model.StudentRegistrationFormDTO.Student_PermanentAddress_NearPoliceStation = model.Student_PermanentAddress_NearPoliceStation;
                model.StudentRegistrationFormDTO.Student_PermanentAddress_ZipCode = model.Student_PermanentAddress_ZipCode;
                model.StudentRegistrationFormDTO.Student_PermanentAddress_City_Tahsil_Pattern = model.Student_PermanentAddress_City_Tahsil_Pattern;

                //Correspondence Address

                model.StudentRegistrationFormDTO.SameAsPerPermanentAddress = model.SameAsPerPermanentAddress;
                model.StudentRegistrationFormDTO.Student_CorrespondenceAddress_PloteNo = model.Student_CorrespondenceAddress_PloteNo;
                model.StudentRegistrationFormDTO.Student_CorrespondenceAddress_StreeNo = model.Student_CorrespondenceAddress_StreeNo;
                model.StudentRegistrationFormDTO.Student_CorrespondenceAddress_Address1 = model.Student_CorrespondenceAddress_Address1;
                model.StudentRegistrationFormDTO.Student_CorrespondenceAddress_Address2 = model.Student_CorrespondenceAddress_Address2;
                model.StudentRegistrationFormDTO.Student_CorrespondenceAddress_City_TahsilID = model.Student_CorrespondenceAddress_City_TahsilID;
                model.StudentRegistrationFormDTO.Student_CorrespondenceAddress_City_TahsilOther = model.Student_CorrespondenceAddress_City_TahsilOther;
                model.StudentRegistrationFormDTO.Student_CorrespondenceAddress_CountryId = model.Student_CorrespondenceAddress_CountryId;
                model.StudentRegistrationFormDTO.Student_CorrespondenceAddress_State = model.Student_CorrespondenceAddress_State;
                model.StudentRegistrationFormDTO.Student_CorrespondenceAddress_StateOther = model.Student_CorrespondenceAddress_StateOther;
                model.StudentRegistrationFormDTO.Student_CorrespondenceAddress_DistrictID = model.Student_CorrespondenceAddress_DistrictID;
                model.StudentRegistrationFormDTO.Student_CorrespondenceAddress_DistrictOther = model.Student_CorrespondenceAddress_DistrictOther;
                model.StudentRegistrationFormDTO.Student_CorrespondenceAddress_Tahsil = model.Student_CorrespondenceAddress_Tahsil;
                model.StudentRegistrationFormDTO.Student_CorrespondenceAddress_NearPoliceStation = model.Student_CorrespondenceAddress_NearPoliceStation;
                model.StudentRegistrationFormDTO.Student_CorrespondenceAddress_ZipCode = model.Student_CorrespondenceAddress_ZipCode;
                model.StudentRegistrationFormDTO.Student_CorrespondenceAddress_City_Tahsil_Pattern = model.Student_CorrespondenceAddress_City_Tahsil_Pattern;

                //Qualifying Exam Details 
                model.StudentRegistrationFormDTO.Student_QualifyingExamName = model.Student_QualifyingExamName;
                model.StudentRegistrationFormDTO.Student_QualifyingRollNo = model.Student_QualifyingRollNo;
                model.StudentRegistrationFormDTO.Student_QualifyingExamTotalMarksPointsObtained = model.Student_QualifyingExamTotalMarksPointsObtained;
                model.StudentRegistrationFormDTO.Student_QualifyingExamOutOffMark = model.Student_QualifyingExamOutOffMark;
                model.StudentRegistrationFormDTO.Student_QualifyingExamRank = model.Student_QualifyingExamRank;

                //Qualification Details 
                //    General Details 
                model.StudentRegistrationFormDTO.Student_Qualification_General_MediumOfInstitution = model.Student_Qualification_General_MediumOfInstitution;
                model.StudentRegistrationFormDTO.Student_Qualification_General_MonthOfPassing = model.Student_Qualification_General_MonthOfPassing;
                model.StudentRegistrationFormDTO.Student_Qualification_General_YearOfPassing = model.Student_Qualification_General_YearOfPassing;
                model.StudentRegistrationFormDTO.Student_Qualification_General_SingleAttempt = model.Student_Qualification_General_SingleAttempt;
                model.StudentRegistrationFormDTO.Student_Qualification_General_ObtainedMark = model.Student_Qualification_General_ObtainedMark;
                model.StudentRegistrationFormDTO.Student_Qualification_General_OutOfMark = model.Student_Qualification_General_OutOfMark;
                model.StudentRegistrationFormDTO.Student_Qualification_General_Percent = model.Student_Qualification_General_Percent;

                //    SSC Details 
                model.StudentRegistrationFormDTO.Student_Qualification_SSC_MediumOfInstitution = model.Student_Qualification_SSC_MediumOfInstitution;
                model.StudentRegistrationFormDTO.Student_Qualification_SSC_MonthOfPassing = model.Student_Qualification_SSC_MonthOfPassing;
                model.StudentRegistrationFormDTO.Student_Qualification_SSC_YearOfPassing = model.Student_Qualification_SSC_YearOfPassing;
                model.StudentRegistrationFormDTO.Student_Qualification_SSC_SingleAttempt = model.Student_Qualification_SSC_SingleAttempt;
                model.StudentRegistrationFormDTO.Student_Qualification_SSC_ObtainedMark = model.Student_Qualification_SSC_ObtainedMark;
                model.StudentRegistrationFormDTO.Student_Qualification_SSC_OutOfMark = model.Student_Qualification_SSC_OutOfMark;
                model.StudentRegistrationFormDTO.Student_Qualification_SSC_Percent = model.Student_Qualification_SSC_Percent;
                model.StudentRegistrationFormDTO.Student_Qualification_SSC_NameofInstitution = model.Student_Qualification_SSC_NameofInstitution;
                model.StudentRegistrationFormDTO.Student_Qualification_SSC_Region_Division_Board = model.Student_Qualification_SSC_Region_Division_Board;

                //    HSC Details 
                model.StudentRegistrationFormDTO.Student_Qualification_HSC_MediumOfInstitution = model.Student_Qualification_HSC_MediumOfInstitution;
                model.StudentRegistrationFormDTO.Student_Qualification_HSC_MonthOfPassing = model.Student_Qualification_HSC_MonthOfPassing;
                model.StudentRegistrationFormDTO.Student_Qualification_HSC_YearOfPassing = model.Student_Qualification_HSC_YearOfPassing;
                model.StudentRegistrationFormDTO.Student_Qualification_HSC_StreamID = model.Student_Qualification_HSC_StreamID;
                model.StudentRegistrationFormDTO.Student_Qualification_HSC_StreamOther = model.Student_Qualification_HSC_StreamOther;
                model.StudentRegistrationFormDTO.Student_Qualification_HSC_SingleAttempt = model.Student_Qualification_HSC_SingleAttempt;
                model.StudentRegistrationFormDTO.Student_Qualification_HSC_Class = model.Student_Qualification_HSC_Class;
                model.StudentRegistrationFormDTO.Student_Qualification_HSC_ObtainedMark = model.Student_Qualification_HSC_ObtainedMark;
                model.StudentRegistrationFormDTO.Student_Qualification_HSC_OutOfMark = model.Student_Qualification_HSC_OutOfMark;
                model.StudentRegistrationFormDTO.Student_Qualification_HSC_Percent = model.Student_Qualification_HSC_Percent;
                model.StudentRegistrationFormDTO.Student_Qualification_HSC_PCM_PVM_ObtainedMark = model.Student_Qualification_HSC_PCM_PVM_ObtainedMark;
                model.StudentRegistrationFormDTO.Student_Qualification_HSC_PCM_PVM_OutOfMark = model.Student_Qualification_HSC_PCM_PVM_OutOfMark;
                model.StudentRegistrationFormDTO.Student_Qualification_HSC_PCB_ObtainedMark = model.Student_Qualification_HSC_PCB_ObtainedMark;
                model.StudentRegistrationFormDTO.Student_Qualification_HSC_PCB_OutOfMark = model.Student_Qualification_HSC_PCB_OutOfMark;
                model.StudentRegistrationFormDTO.Student_Qualification_HSC_NameofInstitution = model.Student_Qualification_HSC_NameofInstitution;
                model.StudentRegistrationFormDTO.Student_Qualification_HSC_Region_Division_Board = model.Student_Qualification_HSC_Region_Division_Board;

                //Diploma / ITI Details 
                model.StudentRegistrationFormDTO.Student_Qualification_Diploma_ITI_Details_MediumOfInstitution = model.Student_Qualification_Diploma_ITI_Details_MediumOfInstitution;
                model.StudentRegistrationFormDTO.Student_Qualification_Diploma_ITI_Details_BranchName = model.Student_Qualification_Diploma_ITI_Details_BranchName;
                model.StudentRegistrationFormDTO.Student_Qualification_Diploma_ITI_Details_ExamPattern = model.Student_Qualification_Diploma_ITI_Details_ExamPattern;
                model.StudentRegistrationFormDTO.Student_Qualification_Diploma_ITI_Details_MonthOfPassing = model.Student_Qualification_Diploma_ITI_Details_MonthOfPassing;
                model.StudentRegistrationFormDTO.Student_Qualification_Diploma_ITI_Details_YearOfPassing = model.Student_Qualification_Diploma_ITI_Details_YearOfPassing;
                model.StudentRegistrationFormDTO.Student_Qualification_Diploma_ITI_Details_Class = model.Student_Qualification_Diploma_ITI_Details_Class;
                model.StudentRegistrationFormDTO.Student_Qualification_Diploma_ITI_Details_ObtainedMark = model.Student_Qualification_Diploma_ITI_Details_ObtainedMark;
                model.StudentRegistrationFormDTO.Student_Qualification_Diploma_ITI_Details_OutOfMark = model.Student_Qualification_Diploma_ITI_Details_OutOfMark;
                model.StudentRegistrationFormDTO.Student_Qualification_Diploma_ITI_Details_Percent = model.Student_Qualification_Diploma_ITI_Details_Percent;
                model.StudentRegistrationFormDTO.Student_Qualification_Diploma_ITI_Details_SingleAttempt = model.Student_Qualification_Diploma_ITI_Details_SingleAttempt;
                model.StudentRegistrationFormDTO.Student_Qualification_Diploma_ITI_Details_BoardEnrollmentNumber = model.Student_Qualification_Diploma_ITI_Details_BoardEnrollmentNumber;
                model.StudentRegistrationFormDTO.Student_Qualification_Diploma_ITI_Details_NameofInstitution = model.Student_Qualification_Diploma_ITI_Details_NameofInstitution;
                model.StudentRegistrationFormDTO.Student_Qualification_Diploma_ITI_Details_Board = model.Student_Qualification_Diploma_ITI_Details_Board;
                model.StudentRegistrationFormDTO.Student_Qualification_Diploma_ITI_Details_State = model.Student_Qualification_Diploma_ITI_Details_State;

                if (model.Student_Qualification_Diploma_ITI_Details_State == 0)
                {
                    model.StudentRegistrationFormDTO.Student_Qualification_Diploma_ITI_Details_CountryId = model.Student_Qualification_Diploma_ITI_Details_CountryId;
                    model.StudentRegistrationFormDTO.Student_Qualification_Diploma_ITI_Details_StateOther = model.Student_Qualification_Diploma_ITI_Details_StateOther;
                }
                else
                {
                    model.StudentRegistrationFormDTO.Student_Qualification_Diploma_ITI_Details_CountryId = 0;
                    model.StudentRegistrationFormDTO.Student_Qualification_Diploma_ITI_Details_StateOther = null;
                }


                //    Degree Details 
                model.StudentRegistrationFormDTO.Student_Qualification_DegreeDetails_MediumOfInstitution = model.Student_Qualification_DegreeDetails_MediumOfInstitution;
                model.StudentRegistrationFormDTO.Student_Qualification_DegreeDetails_Degree = model.Student_Qualification_DegreeDetails_Degree;
                model.StudentRegistrationFormDTO.Student_Qualification_DegreeDetails_BranchName = model.Student_Qualification_DegreeDetails_BranchName;
                model.StudentRegistrationFormDTO.Student_Qualification_DegreeDetails_ExamPattern = model.Student_Qualification_DegreeDetails_ExamPattern;
                model.StudentRegistrationFormDTO.Student_Qualification_DegreeDetails_MonthOfPassing = model.Student_Qualification_DegreeDetails_MonthOfPassing;
                model.StudentRegistrationFormDTO.Student_Qualification_DegreeDetails_YearOfPassing = model.Student_Qualification_DegreeDetails_YearOfPassing;
                model.StudentRegistrationFormDTO.Student_Qualification_DegreeDetails_ObtainedMark = model.Student_Qualification_DegreeDetails_ObtainedMark;
                model.StudentRegistrationFormDTO.Student_Qualification_DegreeDetails_OutOfMark = model.Student_Qualification_DegreeDetails_OutOfMark;
                model.StudentRegistrationFormDTO.Student_Qualification_DegreeDetails_Percent = model.Student_Qualification_DegreeDetails_Percent;
                model.StudentRegistrationFormDTO.Student_Qualification_DegreeDetails_Class = model.Student_Qualification_DegreeDetails_Class;
                model.StudentRegistrationFormDTO.Student_Qualification_DegreeDetails_SingleAttempt = model.Student_Qualification_DegreeDetails_SingleAttempt;
                model.StudentRegistrationFormDTO.Student_Qualification_DegreeDetails_BoardEnrollmentNumber = model.Student_Qualification_DegreeDetails_BoardEnrollmentNumber;
                model.StudentRegistrationFormDTO.Student_Qualification_DegreeDetails_NameofInstitution = model.Student_Qualification_DegreeDetails_NameofInstitution;
                //model.StudentRegistrationFormDTO.Student_Qualification_DegreeDetails_UniversityId = model.Student_Qualification_DegreeDetails_UniversityId;
                model.StudentRegistrationFormDTO.Student_Qualification_DegreeDetails_UniversityName = model.Student_Qualification_DegreeDetails_UniversityName;
                model.StudentRegistrationFormDTO.Student_Qualification_DegreeDetails_State = model.Student_Qualification_DegreeDetails_State;
                if (model.Student_Qualification_DegreeDetails_State == 0)
                {
                    model.StudentRegistrationFormDTO.Student_Qualification_DegreeDetails_CountryId = model.Student_Qualification_DegreeDetails_CountryId;
                    model.StudentRegistrationFormDTO.Student_Qualification_DegreeDetails_StateOther = model.Student_Qualification_DegreeDetails_StateOther;
                }
                else
                {
                    model.StudentRegistrationFormDTO.Student_Qualification_DegreeDetails_CountryId = 0;
                    model.StudentRegistrationFormDTO.Student_Qualification_DegreeDetails_StateOther = null;
                }

                //Post Graduation Details 
                model.StudentRegistrationFormDTO.Student_Qualification_PostGraduationDetails_MediumOfInstitution = model.Student_Qualification_PostGraduationDetails_MediumOfInstitution;
                model.StudentRegistrationFormDTO.Student_Qualification_PostGraduationDetails_PostGraduation = model.Student_Qualification_PostGraduationDetails_PostGraduation;
                model.StudentRegistrationFormDTO.Student_Qualification_PostGraduationDetails_BranchName = model.Student_Qualification_PostGraduationDetails_BranchName;
                model.StudentRegistrationFormDTO.Student_Qualification_PostGraduationDetails_ExamPattern = model.Student_Qualification_PostGraduationDetails_ExamPattern;
                model.StudentRegistrationFormDTO.Student_Qualification_PostGraduationDetails_MonthOfPassing = model.Student_Qualification_PostGraduationDetails_MonthOfPassing;
                model.StudentRegistrationFormDTO.Student_Qualification_PostGraduationDetails_YearOfPassing = model.Student_Qualification_PostGraduationDetails_YearOfPassing;
                model.StudentRegistrationFormDTO.Student_Qualification_PostGraduationDetails_ObtainedMark = model.Student_Qualification_PostGraduationDetails_ObtainedMark;
                model.StudentRegistrationFormDTO.Student_Qualification_PostGraduationDetails_OutOfMark = model.Student_Qualification_PostGraduationDetails_OutOfMark;
                model.StudentRegistrationFormDTO.Student_Qualification_PostGraduationDetails_Percent = model.Student_Qualification_PostGraduationDetails_Percent;
                model.StudentRegistrationFormDTO.Student_Qualification_PostGraduationDetails_Class = model.Student_Qualification_PostGraduationDetails_Class;
                model.StudentRegistrationFormDTO.Student_Qualification_PostGraduationDetails_SingleAttempt = model.Student_Qualification_PostGraduationDetails_SingleAttempt;
                model.StudentRegistrationFormDTO.Student_Qualification_PostGraduationDetails_BoardEnrollmentNumber = model.Student_Qualification_PostGraduationDetails_BoardEnrollmentNumber;
                model.StudentRegistrationFormDTO.Student_Qualification_PostGraduationDetails_NameofInstitution = model.Student_Qualification_PostGraduationDetails_NameofInstitution;
                model.StudentRegistrationFormDTO.Student_Qualification_PostGraduationDetails_UniversityName = model.Student_Qualification_PostGraduationDetails_UniversityName;
                model.StudentRegistrationFormDTO.Student_Qualification_PostGraduationDetails_State = model.Student_Qualification_PostGraduationDetails_State;
                if (model.Student_Qualification_PostGraduationDetails_State == 0)
                {
                    model.StudentRegistrationFormDTO.Student_Qualification_PostGraduationDetails_CountryId = model.Student_Qualification_PostGraduationDetails_CountryId;
                    model.StudentRegistrationFormDTO.Student_Qualification_PostGraduationDetails_StateOther = model.Student_Qualification_PostGraduationDetails_StateOther;
                }
                else
                {
                    model.StudentRegistrationFormDTO.Student_Qualification_PostGraduationDetails_CountryId = 0;
                    model.StudentRegistrationFormDTO.Student_Qualification_PostGraduationDetails_StateOther = null;
                }

                //  DTE And Scholarship Information
                //  DTE Information
                model.StudentRegistrationFormDTO.Student_DTE_DTEUserID = model.Student_DTE_DTEUserID;
                model.StudentRegistrationFormDTO.Student_DTE_DTEPassword = model.Student_DTE_DTEPassword;
                model.StudentRegistrationFormDTO.Student_DTE_DTESrNo = model.Student_DTE_DTESrNo;
                model.StudentRegistrationFormDTO.Student_DTE_DTEMeritNo = model.Student_DTE_DTEMeritNo;
                model.StudentRegistrationFormDTO.Student_DTE_AdmissionTypeId = model.Student_DTE_AdmissionTypeId;
                model.StudentRegistrationFormDTO.Student_DTE_AdmissionRound = model.Student_DTE_AdmissionRound;
                model.StudentRegistrationFormDTO.Student_DTE_AdmissionCategoryId = model.Student_DTE_AdmissionCategoryId;
                model.StudentRegistrationFormDTO.Student_DTE_DTESeatNo = model.Student_DTE_DTESeatNo;
                model.StudentRegistrationFormDTO.Student_QualifyingExamId = model.Student_QualifyingExamId;
                model.StudentRegistrationFormDTO.Student_DTE_QualifyingExamName = model.Student_DTE_QualifyingExamName;
                model.StudentRegistrationFormDTO.Student_DTE_QualifyingExamMarks = model.Student_DTE_QualifyingExamMarks;

                //Scholarship Information
                model.StudentRegistrationFormDTO.Student_Scholarship_ScholarshipId = model.Student_Scholarship_ScholarshipId;
                model.StudentRegistrationFormDTO.Student_Scholarship_ScholarshipType = model.Student_Scholarship_ScholarshipType;
                model.StudentRegistrationFormDTO.Student_Scholarship_CastCategoryId = model.Student_Scholarship_CastCategoryId;
                model.StudentRegistrationFormDTO.Student_Scholarship_AadhaarCardNo = model.Student_Scholarship_AadhaarCardNo;
                model.StudentRegistrationFormDTO.Student_Scholarship_AnnualIncome = model.Student_Scholarship_AnnualIncome;
                model.StudentRegistrationFormDTO.Student_Scholarship_NoofSibling = model.Student_Scholarship_NoofSibling;
                model.StudentRegistrationFormDTO.Student_Scholarship_ChildNoOutofSibling = model.Student_Scholarship_ChildNoOutofSibling;
                model.StudentRegistrationFormDTO.Student_Scholarship_HostelDayScholar = model.Student_Scholarship_HostelDayScholar;
                model.StudentRegistrationFormDTO.Student_Scholarship_Bank_BranchName = model.Student_Scholarship_Bank_BranchName;
                model.StudentRegistrationFormDTO.Student_Scholarship_Bank_AC_No = model.Student_Scholarship_Bank_AC_No;
                model.StudentRegistrationFormDTO.Student_Scholarship_Bank_IFSCCode = model.Student_Scholarship_Bank_IFSCCode;
                model.StudentRegistrationFormDTO.Student_Scholarship_Bank_MICRCode = model.Student_Scholarship_Bank_MICRCode;

                //For Document
                model.Student_AdmissionDocuments_JETMarkSheet = model.Student_AdmissionDocuments_JETMarkSheet;
                model.Student_AdmissionDocuments_AllotmentLetter = model.Student_AdmissionDocuments_AllotmentLetter;
                model.Student_AdmissionDocuments_TenthMarkSheet = model.Student_AdmissionDocuments_TenthMarkSheet;
                model.Student_AdmissionDocuments_TwelvethMarkSheet = model.Student_AdmissionDocuments_TwelvethMarkSheet;
                model.Student_AdmissionDocuments_AllDiplomaMarksheet = model.Student_AdmissionDocuments_AllDiplomaMarksheet;
                model.Student_AdmissionDocuments_LeavingCertificate = model.Student_AdmissionDocuments_LeavingCertificate;
                model.Student_AdmissionDocuments_Domicile_BirthCertificate = model.Student_AdmissionDocuments_Domicile_BirthCertificate;
                model.Student_AdmissionDocuments_NationalityCertificate = model.Student_AdmissionDocuments_NationalityCertificate;
                model.Student_AdmissionDocuments_CasteCertificate = model.Student_AdmissionDocuments_CasteCertificate;
                model.Student_AdmissionDocuments_CasteValidityCertificate = model.Student_AdmissionDocuments_CasteValidityCertificate;
                model.Student_AdmissionDocuments_NonCreamylayerCertificate = model.Student_AdmissionDocuments_NonCreamylayerCertificate;
                model.Student_AdmissionDocuments_EquivalenceCertificate = model.Student_AdmissionDocuments_EquivalenceCertificate;
                model.Student_AdmissionDocuments_MigrationCertificate = model.Student_AdmissionDocuments_MigrationCertificate;
                model.Student_AdmissionDocuments_GapCertificate = model.Student_AdmissionDocuments_GapCertificate;
                model.Student_AdmissionDocuments_AntiRaggingAffidavit = model.Student_AdmissionDocuments_AntiRaggingAffidavit;
                model.Student_AdmissionDocuments_Proforma_Fand_F1_On_DoctorsLetter_Head = model.Student_AdmissionDocuments_Proforma_Fand_F1_On_DoctorsLetter_Head;
                model.Student_AdmissionDocuments_Proforma_I = model.Student_AdmissionDocuments_Proforma_I;
                model.Student_AdmissionDocuments_ProformaG1 = model.Student_AdmissionDocuments_ProformaG1;
                model.Student_AdmissionDocuments_ProformaG2 = model.Student_AdmissionDocuments_ProformaG2;
                model.Student_AdmissionDocuments_Proforma_C_D_E = model.Student_AdmissionDocuments_Proforma_C_D_E;
                model.Student_AdmissionDocuments_FathersIncomeCertificate = model.Student_AdmissionDocuments_FathersIncomeCertificate;
                model.Student_AdmissionDocuments_AadharCardXerox = model.Student_AdmissionDocuments_AadharCardXerox;
                model.Student_AdmissionDocuments_B_WPhoto_I_card_size = model.Student_AdmissionDocuments_B_WPhoto_I_card_size;
                model.Student_AdmissionDocuments_Colour_photo = model.Student_AdmissionDocuments_Colour_photo;


                //For PG Students
                model.Student_AdmissionDocuments_PGStudents_DegreeMarksheet = model.Student_AdmissionDocuments_PGStudents_DegreeMarksheet;
                model.Student_AdmissionDocuments_PGStudents_DegreeCertificate = model.Student_AdmissionDocuments_PGStudents_DegreeCertificate;
                model.Student_AdmissionDocuments_PGStudents_GateScoreCard = model.Student_AdmissionDocuments_PGStudents_GateScoreCard;
                model.Student_AdmissionDocuments_PGStudents_SponsorshipLetterforSponsoredCandidate = model.Student_AdmissionDocuments_PGStudents_SponsorshipLetterforSponsoredCandidate;

                if (model.StudentSubmitedDocumentIDs.Length > 13)
                    model.StudentRegistrationFormDTO.StudentSubmitedDocumentIDs = model.StudentSubmitedDocumentIDs;
                else
                    model.StudentRegistrationFormDTO.StudentSubmitedDocumentIDs = "";

                model.StudentRegistrationFormDTO.Student_AdmissionDocuments_Comments = model.Student_AdmissionDocuments_Comments;



                //Subject Ids
                model.StudentRegistrationFormDTO.QualifyingExamSubjectDetailsIDs = model.QualifyingExamSubjectDetailsIDs;
                model.StudentRegistrationFormDTO.QualificationExamSubjectGeneralDetailsIDs = model.QualificationExamSubjectGeneralDetailsIDs;
                model.StudentRegistrationFormDTO.QualificationExamSubjectSSCDetailsIDs = model.QualificationExamSubjectSSCDetailsIDs;
                model.StudentRegistrationFormDTO.QualificationExamSubjectHSCDetailsIDs = model.QualificationExamSubjectHSCDetailsIDs;
                model.StudentRegistrationFormDTO.ModifiedBy=Convert.ToInt32(Session["UserID"]);

                //for Research Degree Synopsis
                model.StudentRegistrationFormDTO.NameOfApplicant = string.IsNullOrEmpty(model.NameOfApplicant) ? string.Empty : model.NameOfApplicant;
                model.StudentRegistrationFormDTO.TitleOfProject = string.IsNullOrEmpty(model.TitleOfProject) ? string.Empty : model.TitleOfProject;
                model.StudentRegistrationFormDTO.ProjectSummary = string.IsNullOrEmpty(model.ProjectSummary) ? string.Empty : model.ProjectSummary;

                //for Previous Work Experience
                model.StudentRegistrationFormDTO.WorkExperienceXML = string.IsNullOrEmpty(model.WorkExperienceXML) ? string.Empty : model.WorkExperienceXML;
                model.StudentRegistrationFormDTO.DeletedPreviousExperienceIDs = string.IsNullOrEmpty(model.DeletedPreviousExperienceIDs) ? string.Empty : model.DeletedPreviousExperienceIDs; 

                //for Fees Details
                model.StudentRegistrationFormDTO.FeesPaidBy = model.FeesPaidBy;

                model.StudentRegistrationFormDTO.IsTaskGeneratedForApproval = model.IsTaskGeneratedForApproval;
                IBaseEntityResponse<StudentRegistrationForm> response = _StudentRegistrationFormServiceAccess.UpdateStudentRegistrationForm(model.StudentRegistrationFormDTO);
                Session["StudentRegistrationMasterID"] = model.ID;
            }

            return Json(Boolean.TrueString);
            //}
            //else
            //{
            //    return Json(Boolean.FalseString);
            //}
        }

        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Index", "StudentLogin");
        }
        
        protected List<StudentRegistrationForm> GetListStudentRegistrationForm(string CenterCode, int UniversityID, int BranchDetailsID, int StandardNumber)
        {
            StudentRegistrationFormSearchRequest searchRequest = new StudentRegistrationFormSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.CenterCode = CenterCode;
            searchRequest.UniversityID = UniversityID;
            searchRequest.BranchDetailsID = BranchDetailsID;
            searchRequest.StandardNumber = StandardNumber;
            List<StudentRegistrationForm> ToolRegistrationFieldList = new List<StudentRegistrationForm>();
            IBaseEntityCollectionResponse<StudentRegistrationForm> baseEntityCollectionResponse = _StudentRegistrationFormServiceAccess.GetByToolRegistrationFieldList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    ToolRegistrationFieldList = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return ToolRegistrationFieldList;
        }

        protected List<GeneralLocationMaster> GetListGeneralLocationMasterByCityID(string CityID)
        {
            GeneralLocationMasterSearchRequest searchRequest = new GeneralLocationMasterSearchRequest();
            if (CityID == "Other")
            {
                CityID = "0";
            }
            searchRequest.CityID = Convert.ToInt32(CityID);
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            List<GeneralLocationMaster> listGeneralLocationMaster = new List<GeneralLocationMaster>();
            IBaseEntityCollectionResponse<GeneralLocationMaster> baseEntityCollectionResponse = _generalLocationMasterServiceAccess.GetBySearchList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listGeneralLocationMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listGeneralLocationMaster;
        }

        public byte[] ConvertToBytes(HttpPostedFileBase image)
        {
            byte[] imageBytes = null;
            BinaryReader reader = new BinaryReader(image.InputStream);
            imageBytes = reader.ReadBytes((int)image.ContentLength);
            return imageBytes;
        }

        /// <summary>
        /// Gets the filename that is placed under a certain URL.
        /// </summary>
        /// <param name="url">The URL which should be investigated for a file name.</param>
        /// <returns>The file name.</returns>
        string GetUrlFileName(string url)
        {
            var parts = url.Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
            var last = parts[parts.Length - 1];
            return Path.GetFileNameWithoutExtension(last);
        }

        /// <summary>
        /// Gets an image from the specified URL.
        /// </summary>
        /// <param name="url">The URL containing an image.</param>
        /// <returns>The image as a bitmap.</returns>
        Bitmap GetImageFromUrl(string url)
        {
            var buffer = 1024;
            Bitmap image = null;

            if (!Uri.IsWellFormedUriString(url, UriKind.Absolute))
                return image;

            using (var ms = new MemoryStream())
            {
                var req = WebRequest.Create(url);

                using (var resp = req.GetResponse())
                {
                    using (var stream = resp.GetResponseStream())
                    {
                        var bytes = new byte[buffer];
                        var n = 0;

                        while ((n = stream.Read(bytes, 0, buffer)) != 0)
                            ms.Write(bytes, 0, n);
                    }
                }

                image = Bitmap.FromStream(ms) as Bitmap;
            }

            return image;
        }
        protected List<StudentRegistrationAcademicApproval> GetByQualificationSubjectListByStudentRegistrationIDAndEducationType(int StudentRegistrationId, string EducationType)
        {
            StudentRegistrationAcademicApprovalSearchRequest searchRequest = new StudentRegistrationAcademicApprovalSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

            searchRequest.RegistrationID = StudentRegistrationId;
            searchRequest.EducationType = EducationType;
            List<StudentRegistrationAcademicApproval> QualificationSubjectList = new List<StudentRegistrationAcademicApproval>();
            IBaseEntityCollectionResponse<StudentRegistrationAcademicApproval> baseEntityCollectionResponse = _StudentRegistrationAcademicApprovalServiceAcess.GetByQualificationSubjectListByStudentRegistrationIDAndEducationType(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    QualificationSubjectList = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return QualificationSubjectList;
        }

        //get previous experience
        protected List<PreviousWorkExperience> GetPreviousWorkExperience(int StudentRegistrationId)
        {
            PreviousWorkExperienceSearchRequest searchRequest = new PreviousWorkExperienceSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.RegistrationID = StudentRegistrationId;
            List<PreviousWorkExperience> PreviousWorkExperienceList = new List<PreviousWorkExperience>();
            IBaseEntityCollectionResponse<PreviousWorkExperience> baseEntityCollectionResponse = _StudentRegistrationFormServiceAccess.GetPreviousWorkExperience(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    PreviousWorkExperienceList = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return PreviousWorkExperienceList;
        }

        //searchlist of location
        public JsonResult GetLocationList(string term, string CityID, string RegionID)//, string courseYearID, string sectionDetailID, string SessionID)  
        {
            var data = GetLocationListbyCityIDAndRegionID(term, CityID, RegionID);
            var result = (from r in data select new { LocationAddress = r.LocationAddress, id = r.ID }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [NonAction]
        protected List<GeneralLocationMaster> GetLocationListbyCityIDAndRegionID(string SearchKeyWord, string CityID, string RegionID)
        {
            GeneralLocationMasterSearchRequest searchRequest = new GeneralLocationMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.SearchWord = SearchKeyWord;
            searchRequest.MaxResults = 10;
            searchRequest.CityID = Convert.ToInt32(CityID);
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
       //end of SearchList of Location



        //protected List<StudentRegistrationForm> GetListStudentRegistrationFormQualifyingExamList(int BranchDetailID, int StandardNumber)
        //{
        //    StudentRegistrationFormSearchRequest searchRequest = new StudentRegistrationFormSearchRequest();
        //    searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
        //    searchRequest.BranchDetailsID = BranchDetailID;
        //    searchRequest.StandardNumber = StandardNumber;
        //    List<StudentRegistrationForm> listQualifyingExam = new List<StudentRegistrationForm>();
        //    IBaseEntityCollectionResponse<StudentRegistrationForm> baseEntityCollectionResponse = _StudentRegistrationFormServiceAccess.GetListQualifyingExamSelectList(searchRequest);
        //    if (baseEntityCollectionResponse != null)
        //    {
        //        if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
        //        {
        //            listQualifyingExam = baseEntityCollectionResponse.CollectionResponse.ToList();
        //        }
        //    }
        //    return listQualifyingExam;
        //}
        #region ActionResult
        //For CastByCategory
        [HttpGet]
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
        // For RegionDetailByCountry
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

        // For CitynDetailByCountry
        [HttpGet]
        public ActionResult GetGeneralCityByRegionID(string SelectedRegionID)
        {
            if (SelectedRegionID == "Other")
            {
                SelectedRegionID = "0";
            }
            int id = 0;
            bool isValid = Int32.TryParse(SelectedRegionID, out id);
            var GeneralCityDetails = GetListGeneralCityMaster(SelectedRegionID);
            var result = (from s in GeneralCityDetails
                          select new
                          {
                              id = s.ID,
                              name = s.Description,
                          }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        // For LocationDetailByCountry
        [HttpGet]
        public ActionResult GetGeneralLocationByCityID(string SelectedCityID)
        {

            int id = 0;
            bool isValid = Int32.TryParse(SelectedCityID, out id);
            var GeneralCityDetails = GetListGeneralLocationMasterByCityID(SelectedCityID);
            var result = (from s in GeneralCityDetails
                          select new
                          {
                              id = s.ID,
                              name = s.LocationAddress,
                          }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        #endregion ActionResult
    }

}


