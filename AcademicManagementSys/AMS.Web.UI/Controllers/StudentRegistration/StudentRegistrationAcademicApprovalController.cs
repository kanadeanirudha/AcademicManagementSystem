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
    public class StudentRegistrationAcademicApprovalController : BaseController
    {
        IStudentRegistrationAcademicApprovalServiceAccess _StudentRegistrationAcademicApprovalServiceAcess = null;
        IStudentRegistrationFormServiceAccess _StudentRegistrationFormServiceAccess = null;
        IGeneralLocationMasterServiceAccess _generalLocationMasterServiceAccess = null;
        IGeneralTaskReportingDetailsServiceAccess _generalTaskReportingDetailsServiceAccess = null;
        private readonly ILogger _logException;
        ActionModeEnum actionModeEnum;
        string _actionMode = string.Empty;
        string _sortBy = string.Empty;
        string _searchBy = string.Empty;
        string _sortDirection = string.Empty;
        int _startRow;
        int _rowLength;
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

        public StudentRegistrationAcademicApprovalController()
        {
            _StudentRegistrationAcademicApprovalServiceAcess = new StudentRegistrationAcademicApprovalServiceAccess();
            _StudentRegistrationFormServiceAccess = new StudentRegistrationFormServiceAccess();
            _generalLocationMasterServiceAccess = new GeneralLocationMasterServiceAccess();
            _generalTaskReportingDetailsServiceAccess = new GeneralTaskReportingDetailsServiceAccess();
        }

        // Controller Methods
        #region Controller Methods
        public ActionResult Index()
        {
            return View("/Views/StudentRegistration/StudentRegistrationAcademicApproval/Index.cshtml");

        }

        public ActionResult List(string actionMode)
        {
            try
            {
                StudentRegistrationAcademicApprovalViewModel model = new StudentRegistrationAcademicApprovalViewModel();
                if (!string.IsNullOrEmpty(actionMode))
                {
                    TempData["ActionMode"] = actionMode;
                }
                return PartialView("/Views/StudentRegistration/StudentRegistrationAcademicApproval/List.cshtml", model);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }

        }

        public ActionResult ListV2(string actionMode)
        {
            try
            {
                StudentRegistrationAcademicApprovalViewModel model = new StudentRegistrationAcademicApprovalViewModel();
                if (!string.IsNullOrEmpty(actionMode))
                {
                    TempData["ActionMode"] = actionMode;
                }
                return PartialView("/Views/StudentRegistration/StudentRegistrationAcademicApproval/ListV2.cshtml", model);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }

        }

        [HttpGet]
        public ActionResult Edit(string PersonID, string TNDID, string TNMID, string GTRDID1, string TaskCode, string StageSequenceNumber, string IsLast)
        {
            StudentRegistrationAcademicApprovalViewModel model = new StudentRegistrationAcademicApprovalViewModel();
            try
            {
                model.StudentRegistrationAcademicApprovalDTO = new StudentRegistrationAcademicApproval();

                string[] aaa = PersonID.Split('~');

                model.StudentRegistrationAcademicApprovalDTO.RegistrationID = Convert.ToInt32(PersonID);
                model.StudentRegistrationAcademicApprovalDTO.AuthorisationType = "Academic";
                model.StudentRegistrationAcademicApprovalDTO.ConnectionString = _connectioString;

                List<SelectListItem> StudentRegistrationForm_StudentPhysicallyHandicapped = new List<SelectListItem>();
                ViewBag.StudentRegistrationForm_StudentPhysicallyHandicapped = new SelectList(StudentRegistrationForm_StudentPhysicallyHandicapped, "Value", "Text");
                List<SelectListItem> li_StudentRegistrationForm_StudentPhysicallyHandicapped = new List<SelectListItem>();
                li_StudentRegistrationForm_StudentPhysicallyHandicapped.Add(new SelectListItem { Text = "NO", Value = "0" });
                li_StudentRegistrationForm_StudentPhysicallyHandicapped.Add(new SelectListItem { Text = "YES", Value = "1" });




                IBaseEntityResponse<StudentRegistrationAcademicApproval> response = _StudentRegistrationAcademicApprovalServiceAcess.SelectByID(model.StudentRegistrationAcademicApprovalDTO);
                if (response != null && response.Entity != null)
                {
                    model.StudentRegistrationAcademicApprovalDTO.ID = response.Entity.ID;
                    model.StudentRegistrationAcademicApprovalDTO.RegistrationID = response.Entity.RegistrationID;
                    model.StudentRegistrationAcademicApprovalDTO.StudentDateofRegistration = response.Entity.StudentDateofRegistration;
                    model.StudentRegistrationAcademicApprovalDTO.StudentTitle = response.Entity.StudentTitle;
                    model.StudentRegistrationAcademicApprovalDTO.StudentFirstName = response.Entity.StudentFirstName;
                    model.StudentRegistrationAcademicApprovalDTO.StudentMiddleName = response.Entity.StudentMiddleName;
                    model.StudentRegistrationAcademicApprovalDTO.StudentLastName = response.Entity.StudentLastName;
                    model.StudentRegistrationAcademicApprovalDTO.MotherFirstName = response.Entity.MotherFirstName;
                    model.StudentRegistrationAcademicApprovalDTO.StudentMobileNumber = response.Entity.StudentMobileNumber;
                    model.StudentRegistrationAcademicApprovalDTO.FatherMobileNumber = response.Entity.FatherMobileNumber;
                    model.StudentRegistrationAcademicApprovalDTO.GuardianMobileNumber = response.Entity.GuardianMobileNumber;
                    model.StudentRegistrationAcademicApprovalDTO.FatherLandLineNumber = response.Entity.FatherLandLineNumber;
                    model.StudentRegistrationAcademicApprovalDTO.FatherEmailId = response.Entity.FatherEmailId;
                    model.StudentRegistrationAcademicApprovalDTO.GuardianEmailId = response.Entity.GuardianEmailId;
                    model.StudentRegistrationAcademicApprovalDTO.FatherEmailId = response.Entity.FatherEmailId;
                    model.StudentRegistrationAcademicApprovalDTO.MotherEmailId = response.Entity.MotherEmailId;
                    model.StudentRegistrationAcademicApprovalDTO.StudentEmailID = response.Entity.StudentEmailID;

                    model.StudentRegistrationAcademicApprovalDTO.StudentNameAsPerMarkSheet = response.Entity.StudentNameAsPerMarkSheet;
                    model.StudentRegistrationAcademicApprovalDTO.StudentLastSchool_College = response.Entity.StudentLastSchool_College;
                    model.StudentRegistrationAcademicApprovalDTO.StudentPreviousLC_TCNo = response.Entity.StudentPreviousLC_TCNo;
                    model.StudentRegistrationAcademicApprovalDTO.StudentCasteAsPerTC_LC = response.Entity.StudentCasteAsPerTC_LC;
                    model.StudentRegistrationAcademicApprovalDTO.StudentEnrollmentNo = response.Entity.StudentEnrollmentNo;
                    model.StudentRegistrationAcademicApprovalDTO.StudentRegionID = response.Entity.StudentRegionID;
                    model.StudentRegistrationAcademicApprovalDTO.Student_Domesile_CountryId = response.Entity.Student_Domesile_CountryId;
                    model.StudentRegistrationAcademicApprovalDTO.StudentRegionOther = response.Entity.StudentRegionOther;
                    model.StudentRegistrationAcademicApprovalDTO.StudentMigrationNumber = response.Entity.StudentMigrationNumber;

                    model.StudentRegistrationAcademicApprovalDTO.StudentMigrationDate = response.Entity.StudentMigrationDate;

                    model.StudentRegistrationAcademicApprovalDTO.Student_DTE_AdmissionCategoryId = response.Entity.Student_DTE_AdmissionCategoryId;
                    model.StudentRegistrationAcademicApprovalDTO.Student_DTE_AdmissionTypeId = response.Entity.Student_DTE_AdmissionTypeId;
                    // ,[IsHostelResidency]
                    model.StudentRegistrationAcademicApprovalDTO.BranchDetailID = response.Entity.BranchDetailID;
                    model.StudentRegistrationAcademicApprovalDTO.StandardNumber = response.Entity.StandardNumber;
                    // ,[AdmissionPatternID]
                    // ,[StudentActiveFlag]
                    //,[AcademicYearID]
                    model.StudentRegistrationAcademicApprovalDTO.CenterCode = response.Entity.CenterCode;
                    model.StudentRegistrationAcademicApprovalDTO.UniversityID = response.Entity.UniversityID;

                    model.StudentRegistrationAcademicApprovalDTO.StudentNRI_POI = response.Entity.StudentNRI_POI;

                    //,[AllotAdmThrough]
                    //,[BankAccountNumber]
                    //,[BankBranchName]
                    //,[BankIFSCCode]
                    //,[BankMICRCode]
                    model.StudentRegistrationAcademicApprovalDTO.Student_Scholarship_AadhaarCardNo = response.Entity.Student_Scholarship_AadhaarCardNo;

                    //,[IdentificationType]

                    model.StudentRegistrationAcademicApprovalDTO.StudentPhoto = response.Entity.StudentPhoto;
                    model.StudentRegistrationAcademicApprovalDTO.StudentSignature = response.Entity.StudentSignature;
                    model.StudentRegistrationAcademicApprovalDTO.StudentThumb = response.Entity.StudentThumb;

                    model.StudentRegistrationAcademicApprovalDTO.StudentPhotoFileSize = response.Entity.StudentPhotoFileSize;
                    model.StudentRegistrationAcademicApprovalDTO.StudentSignatureFileSize = response.Entity.StudentSignatureFileSize;
                    model.StudentRegistrationAcademicApprovalDTO.StudentThumbFileSize = response.Entity.StudentThumbFileSize;


                    model.StudentRegistrationAcademicApprovalDTO.StudentPhotoType = response.Entity.StudentPhotoType;
                    model.StudentRegistrationAcademicApprovalDTO.StudentPhotoFilename = response.Entity.StudentPhotoFilename;
                    model.StudentRegistrationAcademicApprovalDTO.StudentPhotoFileWidth = response.Entity.StudentPhotoFileWidth;
                    model.StudentRegistrationAcademicApprovalDTO.StudentPhotoFileHeight = response.Entity.StudentPhotoFileHeight;

                    model.StudentRegistrationAcademicApprovalDTO.StudentSignatureType = response.Entity.StudentSignatureType;
                    model.StudentRegistrationAcademicApprovalDTO.StudentSignatureFilename = response.Entity.StudentSignatureFilename;
                    model.StudentRegistrationAcademicApprovalDTO.StudentSignatureFileWidth = response.Entity.StudentSignatureFileWidth;
                    model.StudentRegistrationAcademicApprovalDTO.StudentSignatureFileHeight = response.Entity.StudentSignatureFileHeight;

                    model.StudentRegistrationAcademicApprovalDTO.StudentThumbType = response.Entity.StudentThumbType;
                    model.StudentRegistrationAcademicApprovalDTO.StudentThumbFilename = response.Entity.StudentThumbFilename;
                    model.StudentRegistrationAcademicApprovalDTO.StudentThumbFileWidth = response.Entity.StudentThumbFileWidth;
                    model.StudentRegistrationAcademicApprovalDTO.StudentThumbFileHeight = response.Entity.StudentThumbFileHeight;


                    model.StudentRegistrationAcademicApprovalDTO.StudentDateofBirth = response.Entity.StudentDateofBirth;
                    model.StudentRegistrationAcademicApprovalDTO.StudentBirthPlace = response.Entity.StudentBirthPlace;
                    model.StudentRegistrationAcademicApprovalDTO.StudentGender = response.Entity.StudentGender;
                    model.StudentRegistrationAcademicApprovalDTO.StudentMaritalStatus = response.Entity.StudentMaritalStatus;
                    model.StudentRegistrationAcademicApprovalDTO.StudentNationalityID = response.Entity.StudentNationalityID;
                    model.StudentRegistrationAcademicApprovalDTO.StudentReligionID = response.Entity.StudentReligionID;
                    model.StudentRegistrationAcademicApprovalDTO.StudentMotherTongueID = response.Entity.StudentMotherTongueID;
                    model.StudentRegistrationAcademicApprovalDTO.StudentCategoryID = response.Entity.StudentCategoryID;
                    model.StudentRegistrationAcademicApprovalDTO.StudentCasteID = response.Entity.StudentCasteID;

                    //,C.SubCasteId
                    model.StudentRegistrationAcademicApprovalDTO.StudentBloodGroup = response.Entity.StudentBloodGroup;
                    model.StudentRegistrationAcademicApprovalDTO.StudentLandLineNumber = response.Entity.StudentLandLineNumber;
                    model.StudentRegistrationAcademicApprovalDTO.StudentIdentificationMark = response.Entity.StudentIdentificationMark;
                    model.StudentRegistrationAcademicApprovalDTO.StudentEmploymentSector = response.Entity.StudentEmploymentSector;
                    model.StudentRegistrationAcademicApprovalDTO.StudentOccupation = response.Entity.StudentOccupation;
                    model.StudentRegistrationAcademicApprovalDTO.StudentDesignation = response.Entity.StudentDesignation;
                    model.StudentRegistrationAcademicApprovalDTO.StudentOrganizationName = response.Entity.StudentOrganizationName;
                    model.StudentRegistrationAcademicApprovalDTO.StudentOfficeContactNo = response.Entity.StudentOfficeContactNo;
                    model.StudentRegistrationAcademicApprovalDTO.StudentAnnualIncome = response.Entity.StudentAnnualIncome;
                    if (response.Entity.PhysicallyHandicapped == "False")
                    {
                        model.StudentRegistrationAcademicApprovalDTO.PhysicallyHandicapped = "0";
                    }
                    else
                    {
                        model.StudentRegistrationAcademicApprovalDTO.PhysicallyHandicapped = "1";
                    }
                    if (response.Entity.StudentOrgandonor == "False")
                    {
                        model.StudentRegistrationAcademicApprovalDTO.StudentOrgandonor = "0";
                    }
                    else
                    {
                        model.StudentRegistrationAcademicApprovalDTO.StudentOrgandonor = "1";
                    }


                    model.StudentRegistrationAcademicApprovalDTO.StudentPrevNameofStudent = response.Entity.StudentPrevNameofStudent;
                    model.StudentRegistrationAcademicApprovalDTO.StudentReasonforNamechange = response.Entity.StudentReasonforNamechange;
                    if (response.Entity.StudentEmploymentStatus == "False")
                    {
                        model.StudentRegistrationAcademicApprovalDTO.StudentEmploymentStatus = "0";
                    }
                    else
                    {
                        model.StudentRegistrationAcademicApprovalDTO.StudentEmploymentStatus = "1";
                    }


                    model.StudentRegistrationAcademicApprovalDTO.FatherHusbondType = response.Entity.FatherHusbondType;
                    model.StudentRegistrationAcademicApprovalDTO.FatherTitle = response.Entity.FatherTitle;
                    model.StudentRegistrationAcademicApprovalDTO.FatherFirstName = response.Entity.FatherFirstName;
                    model.StudentRegistrationAcademicApprovalDTO.FatherMiddleName = response.Entity.FatherMiddleName;
                    model.StudentRegistrationAcademicApprovalDTO.FatherLastName = response.Entity.FatherLastName;
                    model.StudentRegistrationAcademicApprovalDTO.FatherEmailId = response.Entity.FatherEmailId;
                    model.StudentRegistrationAcademicApprovalDTO.FatherMobileNumber = response.Entity.FatherMobileNumber;
                    model.StudentRegistrationAcademicApprovalDTO.StudentDomicileStateofFather = response.Entity.StudentDomicileStateofFather;
                    model.StudentRegistrationAcademicApprovalDTO.FatherLandLineNumber = response.Entity.FatherLandLineNumber;
                    model.StudentRegistrationAcademicApprovalDTO.FatherEmploymentSector = response.Entity.FatherEmploymentSector;
                    model.StudentRegistrationAcademicApprovalDTO.FatherOccupation = response.Entity.FatherOccupation;
                    model.StudentRegistrationAcademicApprovalDTO.FatherDesignation = response.Entity.FatherDesignation;
                    model.StudentRegistrationAcademicApprovalDTO.FatherOrganizationName = response.Entity.FatherOrganizationName;
                    model.StudentRegistrationAcademicApprovalDTO.FatherOfficeContactNo = response.Entity.FatherOfficeContactNo;
                    model.StudentRegistrationAcademicApprovalDTO.FatherAnnualIncome = response.Entity.FatherAnnualIncome;

                    //   model.StudentRegistrationAcademicApprovalDTO.FatherHusbondType =  response.Entity.["M_EntityType";
                    model.StudentRegistrationAcademicApprovalDTO.MotherTitle = response.Entity.MotherTitle;
                    model.StudentRegistrationAcademicApprovalDTO.MotherFirstName = response.Entity.MotherFirstName;
                    model.StudentRegistrationAcademicApprovalDTO.MotherMiddleName = response.Entity.MotherMiddleName;
                    model.StudentRegistrationAcademicApprovalDTO.MotherLastName = response.Entity.MotherLastName;
                    model.StudentRegistrationAcademicApprovalDTO.MotherEmailId = response.Entity.MotherEmailId;
                    model.StudentRegistrationAcademicApprovalDTO.MotherMobileNumber = response.Entity.MotherMobileNumber;
                    model.StudentRegistrationAcademicApprovalDTO.StudentDomicileStateofMother = response.Entity.StudentDomicileStateofMother;
                    model.StudentRegistrationAcademicApprovalDTO.MotherLandLineNumber = response.Entity.MotherLandLineNumber;
                    model.StudentRegistrationAcademicApprovalDTO.MotherEmploymentSector = response.Entity.MotherEmploymentSector;
                    model.StudentRegistrationAcademicApprovalDTO.MotherOccupation = response.Entity.MotherOccupation;
                    model.StudentRegistrationAcademicApprovalDTO.MotherDesignation = response.Entity.MotherDesignation;
                    model.StudentRegistrationAcademicApprovalDTO.MotherOrganizationName = response.Entity.MotherOrganizationName;
                    model.StudentRegistrationAcademicApprovalDTO.MotherOfficeContactNo = response.Entity.MotherOfficeContactNo;
                    model.StudentRegistrationAcademicApprovalDTO.MotherAnnualIncome = response.Entity.MotherAnnualIncome;

                    model.StudentRegistrationAcademicApprovalDTO.GuardianTitle = response.Entity.GuardianTitle;
                    model.StudentRegistrationAcademicApprovalDTO.GuardianFirstName = response.Entity.GuardianFirstName;
                    model.StudentRegistrationAcademicApprovalDTO.GuardianMiddleName = response.Entity.GuardianMiddleName;
                    model.StudentRegistrationAcademicApprovalDTO.GuardianLastName = response.Entity.GuardianLastName;
                    model.StudentRegistrationAcademicApprovalDTO.GuardianEmailId = response.Entity.GuardianEmailId;
                    model.StudentRegistrationAcademicApprovalDTO.GuardianMobileNumber = response.Entity.GuardianMobileNumber;
                    //    model.StudentRegistrationAcademicApprovalDTO.StudentDomicileStateofGuardian =  response.Entity.["G_DomicileState";
                    model.StudentRegistrationAcademicApprovalDTO.GuardianLandLineNumber = response.Entity.GuardianLandLineNumber;
                    model.StudentRegistrationAcademicApprovalDTO.GuardianEmploymentSector = response.Entity.GuardianEmploymentSector;
                    model.StudentRegistrationAcademicApprovalDTO.GuardianOccupation = response.Entity.GuardianOccupation;
                    model.StudentRegistrationAcademicApprovalDTO.GuardianDesignation = response.Entity.GuardianDesignation;
                    model.StudentRegistrationAcademicApprovalDTO.GuardianOrganizationName = response.Entity.GuardianOrganizationName;
                    model.StudentRegistrationAcademicApprovalDTO.GuardianOfficeContactNo = response.Entity.GuardianOfficeContactNo;
                    model.StudentRegistrationAcademicApprovalDTO.GuardianAnnualIncome = response.Entity.GuardianAnnualIncome;

                    model.StudentRegistrationAcademicApprovalDTO.Student_Ex_Serviceman_Ward_of_Ex_Serviceman = response.Entity.Student_Ex_Serviceman_Ward_of_Ex_Serviceman;
                    model.StudentRegistrationAcademicApprovalDTO.Student_Active_Serviceman_Ward_of_Active_Serviceman = response.Entity.Student_Active_Serviceman_Ward_of_Active_Serviceman;
                    model.StudentRegistrationAcademicApprovalDTO.Student_FreedomFighterWardOfFreedomFighter = response.Entity.Student_FreedomFighterWardOfFreedomFighter;
                    model.StudentRegistrationAcademicApprovalDTO.Student_WardofPrimaryTeacher = response.Entity.Student_WardofPrimaryTeacher;
                    model.StudentRegistrationAcademicApprovalDTO.Student_WardofSecondaryTeacher = response.Entity.Student_WardofSecondaryTeacher;
                    model.StudentRegistrationAcademicApprovalDTO.Student_Deserted_Divorced_Widowed_Women = response.Entity.Student_Deserted_Divorced_Widowed_Women;
                    model.StudentRegistrationAcademicApprovalDTO.Student_MemberofProjectAffectedFamily = response.Entity.Student_MemberofProjectAffectedFamily;
                    model.StudentRegistrationAcademicApprovalDTO.Student_MemberofEarthquakeAffectedFamily = response.Entity.Student_MemberofEarthquakeAffectedFamily;
                    model.StudentRegistrationAcademicApprovalDTO.Student_MemberofFloodFamineAffectedFamily = response.Entity.Student_MemberofFloodFamineAffectedFamily;
                    model.StudentRegistrationAcademicApprovalDTO.Student_ResidentofTribalArea = response.Entity.Student_ResidentofTribalArea;
                    model.StudentRegistrationAcademicApprovalDTO.Student_KashmirMigrant = response.Entity.Student_KashmirMigrant;

                    model.StudentRegistrationAcademicApprovalDTO.StudentIndicatetypeofCandidature = response.Entity.StudentIndicatetypeofCandidature;
                    model.StudentRegistrationAcademicApprovalDTO.StudentSchoolFromHSCExaminationpassed = response.Entity.StudentSchoolFromHSCExaminationpassed;
                    if (response.Entity.StudentEconomicallyBackwardClass == "False")
                    {
                        model.StudentRegistrationAcademicApprovalDTO.StudentEconomicallyBackwardClass = "0";
                    }
                    else
                    {
                        model.StudentRegistrationAcademicApprovalDTO.StudentEconomicallyBackwardClass = "1";
                    }

                    model.StudentRegistrationAcademicApprovalDTO.StudentsNameOfDistrictWhereParentDomiciled = response.Entity.StudentsNameOfDistrictWhereParentDomiciled;
                    model.StudentRegistrationAcademicApprovalDTO.StudentsMKBCandidate = response.Entity.StudentsMKBCandidate;

                    model.StudentRegistrationAcademicApprovalDTO.Student_PermanentAddress_Address1 = response.Entity.Student_PermanentAddress_Address1;
                    model.StudentRegistrationAcademicApprovalDTO.Student_PermanentAddress_Address2 = response.Entity.Student_PermanentAddress_Address2;
                    model.StudentRegistrationAcademicApprovalDTO.Student_PermanentAddress_PloteNo = response.Entity.Student_PermanentAddress_PloteNo;
                    model.StudentRegistrationAcademicApprovalDTO.Student_PermanentAddress_StreeNo = response.Entity.Student_PermanentAddress_StreeNo;
                    model.StudentRegistrationAcademicApprovalDTO.Student_PermanentAddress_City_TahsilID = response.Entity.Student_PermanentAddress_City_TahsilID;
                    model.StudentRegistrationAcademicApprovalDTO.Student_PermanentAddress_City_TahsilName = response.Entity.Student_PermanentAddress_City_TahsilName;
                    model.StudentRegistrationAcademicApprovalDTO.Student_PermanentAddress_City_TahsilOther = response.Entity.Student_PermanentAddress_City_TahsilOther;
                    model.StudentRegistrationAcademicApprovalDTO.Student_PermanentAddress_DistrictID = response.Entity.Student_PermanentAddress_DistrictID;
                    model.StudentRegistrationAcademicApprovalDTO.Student_PermanentAddress_DistrictOther = response.Entity.Student_PermanentAddress_DistrictOther;
                    model.StudentRegistrationAcademicApprovalDTO.Student_PermanentAddress_State = response.Entity.Student_PermanentAddress_State;
                    model.StudentRegistrationAcademicApprovalDTO.Student_PermanentAddress_StateOther = response.Entity.Student_PermanentAddress_StateOther;
                    model.StudentRegistrationAcademicApprovalDTO.Student_PermanentAddress_CountryId = response.Entity.Student_PermanentAddress_CountryId;
                    model.StudentRegistrationAcademicApprovalDTO.Student_PermanentAddress_NearPoliceStation = response.Entity.Student_PermanentAddress_NearPoliceStation;
                    model.StudentRegistrationAcademicApprovalDTO.Student_PermanentAddress_Tahsil = response.Entity.Student_PermanentAddress_Tahsil;
                    model.StudentRegistrationAcademicApprovalDTO.Student_PermanentAddress_ZipCode = response.Entity.Student_PermanentAddress_ZipCode;
                    model.StudentRegistrationAcademicApprovalDTO.Student_PermanentAddress_City_Tahsil_Pattern = response.Entity.Student_PermanentAddress_City_Tahsil_Pattern;


                    model.StudentRegistrationAcademicApprovalDTO.Student_CorrespondenceAddress_Address1 = response.Entity.Student_CorrespondenceAddress_Address1;
                    model.StudentRegistrationAcademicApprovalDTO.Student_CorrespondenceAddress_Address2 = response.Entity.Student_CorrespondenceAddress_Address2;
                    model.StudentRegistrationAcademicApprovalDTO.Student_CorrespondenceAddress_PloteNo = response.Entity.Student_CorrespondenceAddress_PloteNo;
                    model.StudentRegistrationAcademicApprovalDTO.Student_CorrespondenceAddress_StreeNo = response.Entity.Student_CorrespondenceAddress_StreeNo;
                    model.StudentRegistrationAcademicApprovalDTO.Student_CorrespondenceAddress_City_TahsilID = response.Entity.Student_CorrespondenceAddress_City_TahsilID;
                    model.StudentRegistrationAcademicApprovalDTO.Student_CorrespondenceAddress_City_TahsilName = response.Entity.Student_CorrespondenceAddress_City_TahsilName;
                    model.StudentRegistrationAcademicApprovalDTO.Student_CorrespondenceAddress_City_TahsilOther = response.Entity.Student_CorrespondenceAddress_City_TahsilOther;
                    model.StudentRegistrationAcademicApprovalDTO.Student_CorrespondenceAddress_DistrictID = response.Entity.Student_CorrespondenceAddress_DistrictID;
                    model.StudentRegistrationAcademicApprovalDTO.Student_CorrespondenceAddress_DistrictOther = response.Entity.Student_CorrespondenceAddress_DistrictOther;
                    model.StudentRegistrationAcademicApprovalDTO.Student_CorrespondenceAddress_State = response.Entity.Student_CorrespondenceAddress_State;
                    model.StudentRegistrationAcademicApprovalDTO.Student_CorrespondenceAddress_StateOther = response.Entity.Student_CorrespondenceAddress_StateOther;
                    model.StudentRegistrationAcademicApprovalDTO.Student_CorrespondenceAddress_CountryId = response.Entity.Student_CorrespondenceAddress_CountryId;
                    model.StudentRegistrationAcademicApprovalDTO.Student_CorrespondenceAddress_NearPoliceStation = response.Entity.Student_CorrespondenceAddress_NearPoliceStation;
                    model.StudentRegistrationAcademicApprovalDTO.Student_CorrespondenceAddress_Tahsil = response.Entity.Student_CorrespondenceAddress_Tahsil;
                    model.StudentRegistrationAcademicApprovalDTO.Student_CorrespondenceAddress_ZipCode = response.Entity.Student_CorrespondenceAddress_ZipCode;
                    model.StudentRegistrationAcademicApprovalDTO.Student_CorrespondenceAddress_City_Tahsil_Pattern = response.Entity.Student_CorrespondenceAddress_City_Tahsil_Pattern;
                    model.StudentRegistrationAcademicApprovalDTO.Student_QualifyingExamId = response.Entity.Student_QualifyingExamId;
                    model.StudentRegistrationAcademicApprovalDTO.Student_QualifyingRollNo = response.Entity.Student_QualifyingRollNo;
                    model.StudentRegistrationAcademicApprovalDTO.Student_QualifyingExamTotalMarksPointsObtained = response.Entity.Student_QualifyingExamTotalMarksPointsObtained;
                    model.StudentRegistrationAcademicApprovalDTO.Student_QualifyingExamOutOffMark = response.Entity.Student_QualifyingExamOutOffMark;
                    model.StudentRegistrationAcademicApprovalDTO.Student_QualifyingExamRank = response.Entity.Student_QualifyingExamRank;

                    model.StudentRegistrationAcademicApprovalDTO.Student_Qualification_General_MediumOfInstitution = response.Entity.Student_Qualification_General_MediumOfInstitution;
                    model.StudentRegistrationAcademicApprovalDTO.Student_Qualification_General_MonthOfPassing = response.Entity.Student_Qualification_General_MonthOfPassing;
                    model.StudentRegistrationAcademicApprovalDTO.Student_Qualification_General_YearOfPassing = response.Entity.Student_Qualification_General_YearOfPassing;
                    if (response.Entity.Student_Qualification_General_SingleAttempt == "False")
                    {
                        model.StudentRegistrationAcademicApprovalDTO.Student_Qualification_General_SingleAttempt = "0";
                    }
                    else
                    {
                        model.StudentRegistrationAcademicApprovalDTO.Student_Qualification_General_SingleAttempt = "1";
                    }
                    model.StudentRegistrationAcademicApprovalDTO.Student_Qualification_General_ObtainedMark = response.Entity.Student_Qualification_General_ObtainedMark;
                    model.StudentRegistrationAcademicApprovalDTO.Student_Qualification_General_OutOfMark = response.Entity.Student_Qualification_General_OutOfMark;
                    model.StudentRegistrationAcademicApprovalDTO.Student_Qualification_General_Percent = response.Entity.Student_Qualification_General_Percent;
                    model.StudentRegistrationAcademicApprovalDTO.Student_Qualification_General_NameofInstitution = response.Entity.Student_Qualification_General_NameofInstitution;
                    model.StudentRegistrationAcademicApprovalDTO.Student_Qualification_General_Region_Division_Board = response.Entity.Student_Qualification_General_Region_Division_Board;

                    model.StudentRegistrationAcademicApprovalDTO.Student_Qualification_SSC_MediumOfInstitution = response.Entity.Student_Qualification_SSC_MediumOfInstitution;
                    model.StudentRegistrationAcademicApprovalDTO.Student_Qualification_SSC_MonthOfPassing = response.Entity.Student_Qualification_SSC_MonthOfPassing;
                    model.StudentRegistrationAcademicApprovalDTO.Student_Qualification_SSC_YearOfPassing = response.Entity.Student_Qualification_SSC_YearOfPassing;
                    if (response.Entity.Student_Qualification_SSC_SingleAttempt == "False")
                    {
                        model.StudentRegistrationAcademicApprovalDTO.Student_Qualification_SSC_SingleAttempt = "0";
                    }
                    else
                    {
                        model.StudentRegistrationAcademicApprovalDTO.Student_Qualification_SSC_SingleAttempt = "1";
                    }

                    model.StudentRegistrationAcademicApprovalDTO.Student_Qualification_SSC_ObtainedMark = response.Entity.Student_Qualification_SSC_ObtainedMark;
                    model.StudentRegistrationAcademicApprovalDTO.Student_Qualification_SSC_OutOfMark = response.Entity.Student_Qualification_SSC_OutOfMark;
                    model.StudentRegistrationAcademicApprovalDTO.Student_Qualification_SSC_Percent = response.Entity.Student_Qualification_SSC_Percent;
                    model.StudentRegistrationAcademicApprovalDTO.Student_Qualification_SSC_NameofInstitution = response.Entity.Student_Qualification_SSC_NameofInstitution;
                    model.StudentRegistrationAcademicApprovalDTO.Student_Qualification_SSC_Region_Division_Board = response.Entity.Student_Qualification_SSC_Region_Division_Board;

                    model.StudentRegistrationAcademicApprovalDTO.Student_Qualification_HSC_MediumOfInstitution = response.Entity.Student_Qualification_HSC_MediumOfInstitution;
                    model.StudentRegistrationAcademicApprovalDTO.Student_Qualification_HSC_MonthOfPassing = response.Entity.Student_Qualification_HSC_MonthOfPassing;
                    model.StudentRegistrationAcademicApprovalDTO.Student_Qualification_HSC_YearOfPassing = response.Entity.Student_Qualification_HSC_YearOfPassing;
                    if (response.Entity.Student_Qualification_HSC_SingleAttempt == "False")
                    {
                        model.StudentRegistrationAcademicApprovalDTO.Student_Qualification_HSC_SingleAttempt = "0";
                    }
                    else
                    {
                        model.StudentRegistrationAcademicApprovalDTO.Student_Qualification_HSC_SingleAttempt = "1";
                    }

                    model.StudentRegistrationAcademicApprovalDTO.Student_Qualification_HSC_ObtainedMark = response.Entity.Student_Qualification_HSC_ObtainedMark;
                    model.StudentRegistrationAcademicApprovalDTO.Student_Qualification_HSC_OutOfMark = response.Entity.Student_Qualification_HSC_OutOfMark;
                    model.StudentRegistrationAcademicApprovalDTO.Student_Qualification_HSC_Percent = response.Entity.Student_Qualification_HSC_Percent;
                    model.StudentRegistrationAcademicApprovalDTO.Student_Qualification_HSC_NameofInstitution = response.Entity.Student_Qualification_HSC_NameofInstitution;
                    model.StudentRegistrationAcademicApprovalDTO.Student_Qualification_HSC_Region_Division_Board = response.Entity.Student_Qualification_HSC_Region_Division_Board;
                    model.StudentRegistrationAcademicApprovalDTO.Student_Qualification_HSC_StreamID = response.Entity.Student_Qualification_HSC_StreamID;
                    model.StudentRegistrationAcademicApprovalDTO.Student_Qualification_HSC_StreamOther = response.Entity.Student_Qualification_HSC_StreamOther;
                    model.StudentRegistrationAcademicApprovalDTO.Student_Qualification_HSC_Class = response.Entity.Student_Qualification_HSC_Class;

                    model.StudentRegistrationAcademicApprovalDTO.Student_Qualification_HSC_PCM_PVM_ObtainedMark = response.Entity.Student_Qualification_HSC_PCM_PVM_ObtainedMark;
                    model.StudentRegistrationAcademicApprovalDTO.Student_Qualification_HSC_PCM_PVM_OutOfMark = response.Entity.Student_Qualification_HSC_PCM_PVM_OutOfMark;
                    model.StudentRegistrationAcademicApprovalDTO.Student_Qualification_HSC_PCB_ObtainedMark = response.Entity.Student_Qualification_HSC_PCB_ObtainedMark;
                    model.StudentRegistrationAcademicApprovalDTO.Student_Qualification_HSC_PCB_OutOfMark = response.Entity.Student_Qualification_HSC_PCB_OutOfMark;

                    model.StudentRegistrationAcademicApprovalDTO.Student_Qualification_Diploma_ITI_Details_MediumOfInstitution = response.Entity.Student_Qualification_Diploma_ITI_Details_MediumOfInstitution;
                    model.StudentRegistrationAcademicApprovalDTO.Student_Qualification_Diploma_ITI_Details_BranchName = response.Entity.Student_Qualification_Diploma_ITI_Details_BranchName;
                    model.StudentRegistrationAcademicApprovalDTO.Student_Qualification_Diploma_ITI_Details_ExamPattern = response.Entity.Student_Qualification_Diploma_ITI_Details_ExamPattern;
                    model.StudentRegistrationAcademicApprovalDTO.Student_Qualification_Diploma_ITI_Details_MonthOfPassing = response.Entity.Student_Qualification_Diploma_ITI_Details_MonthOfPassing;
                    model.StudentRegistrationAcademicApprovalDTO.Student_Qualification_Diploma_ITI_Details_YearOfPassing = response.Entity.Student_Qualification_Diploma_ITI_Details_YearOfPassing;
                    if (response.Entity.Student_Qualification_Diploma_ITI_Details_SingleAttempt == "False")
                    {
                        model.StudentRegistrationAcademicApprovalDTO.Student_Qualification_Diploma_ITI_Details_SingleAttempt = "0";
                    }
                    else
                    {
                        model.StudentRegistrationAcademicApprovalDTO.Student_Qualification_Diploma_ITI_Details_SingleAttempt = "1";
                    }

                    model.StudentRegistrationAcademicApprovalDTO.Student_Qualification_Diploma_ITI_Details_ObtainedMark = response.Entity.Student_Qualification_Diploma_ITI_Details_ObtainedMark;
                    model.StudentRegistrationAcademicApprovalDTO.Student_Qualification_Diploma_ITI_Details_OutOfMark = response.Entity.Student_Qualification_Diploma_ITI_Details_OutOfMark;
                    model.StudentRegistrationAcademicApprovalDTO.Student_Qualification_Diploma_ITI_Details_Percent = response.Entity.Student_Qualification_Diploma_ITI_Details_Percent;
                    model.StudentRegistrationAcademicApprovalDTO.Student_Qualification_Diploma_ITI_Details_NameofInstitution = response.Entity.Student_Qualification_Diploma_ITI_Details_NameofInstitution;
                    model.StudentRegistrationAcademicApprovalDTO.Student_Qualification_Diploma_ITI_Details_Board = response.Entity.Student_Qualification_Diploma_ITI_Details_Board;
                    model.StudentRegistrationAcademicApprovalDTO.Student_Qualification_Diploma_ITI_Details_State = response.Entity.Student_Qualification_Diploma_ITI_Details_State;
                    model.StudentRegistrationAcademicApprovalDTO.Student_Qualification_Diploma_ITI_Details_CountryId = response.Entity.Student_Qualification_Diploma_ITI_Details_CountryId;
                    model.StudentRegistrationAcademicApprovalDTO.Student_Qualification_Diploma_ITI_Details_StateOther = response.Entity.Student_Qualification_Diploma_ITI_Details_StateOther;
                    model.StudentRegistrationAcademicApprovalDTO.Student_Qualification_Diploma_ITI_Details_BoardEnrollmentNumber = response.Entity.Student_Qualification_Diploma_ITI_Details_BoardEnrollmentNumber;
                    model.StudentRegistrationAcademicApprovalDTO.Student_Qualification_Diploma_ITI_Details_Class = response.Entity.Student_Qualification_Diploma_ITI_Details_Class;

                    model.StudentRegistrationAcademicApprovalDTO.Student_Qualification_DegreeDetails_MediumOfInstitution = response.Entity.Student_Qualification_DegreeDetails_MediumOfInstitution;
                    model.StudentRegistrationAcademicApprovalDTO.Student_Qualification_DegreeDetails_BranchName = response.Entity.Student_Qualification_DegreeDetails_BranchName;
                    model.StudentRegistrationAcademicApprovalDTO.Student_Qualification_DegreeDetails_ExamPattern = response.Entity.Student_Qualification_DegreeDetails_ExamPattern;
                    model.StudentRegistrationAcademicApprovalDTO.Student_Qualification_DegreeDetails_MonthOfPassing = response.Entity.Student_Qualification_DegreeDetails_MonthOfPassing;
                    model.StudentRegistrationAcademicApprovalDTO.Student_Qualification_DegreeDetails_YearOfPassing = response.Entity.Student_Qualification_DegreeDetails_YearOfPassing;
                    if (response.Entity.Student_Qualification_DegreeDetails_SingleAttempt == "False")
                    {
                        model.StudentRegistrationAcademicApprovalDTO.Student_Qualification_DegreeDetails_SingleAttempt = "0";
                    }
                    else
                    {
                        model.StudentRegistrationAcademicApprovalDTO.Student_Qualification_DegreeDetails_SingleAttempt = "1";
                    }
                    model.StudentRegistrationAcademicApprovalDTO.Student_Qualification_DegreeDetails_ObtainedMark = response.Entity.Student_Qualification_DegreeDetails_ObtainedMark;
                    model.StudentRegistrationAcademicApprovalDTO.Student_Qualification_DegreeDetails_OutOfMark = response.Entity.Student_Qualification_DegreeDetails_OutOfMark;
                    model.StudentRegistrationAcademicApprovalDTO.Student_Qualification_DegreeDetails_Percent = response.Entity.Student_Qualification_DegreeDetails_Percent;
                    model.StudentRegistrationAcademicApprovalDTO.Student_Qualification_DegreeDetails_NameofInstitution = response.Entity.Student_Qualification_DegreeDetails_NameofInstitution;
                    model.StudentRegistrationAcademicApprovalDTO.Student_Qualification_DegreeDetails_UniversityName = response.Entity.Student_Qualification_DegreeDetails_UniversityName;
                    model.StudentRegistrationAcademicApprovalDTO.Student_Qualification_DegreeDetails_State = response.Entity.Student_Qualification_DegreeDetails_State;
                    model.StudentRegistrationAcademicApprovalDTO.Student_Qualification_DegreeDetails_CountryId = response.Entity.Student_Qualification_DegreeDetails_CountryId;
                    model.StudentRegistrationAcademicApprovalDTO.Student_Qualification_DegreeDetails_StateOther = response.Entity.Student_Qualification_DegreeDetails_StateOther;
                    model.StudentRegistrationAcademicApprovalDTO.Student_Qualification_DegreeDetails_Degree = response.Entity.Student_Qualification_DegreeDetails_Degree;
                    model.StudentRegistrationAcademicApprovalDTO.Student_Qualification_DegreeDetails_BoardEnrollmentNumber = response.Entity.Student_Qualification_DegreeDetails_BoardEnrollmentNumber;
                    model.StudentRegistrationAcademicApprovalDTO.Student_Qualification_DegreeDetails_Class = response.Entity.Student_Qualification_DegreeDetails_Class;

                    model.StudentRegistrationAcademicApprovalDTO.Student_Qualification_PostGraduationDetails_MediumOfInstitution = response.Entity.Student_Qualification_PostGraduationDetails_MediumOfInstitution;
                    model.StudentRegistrationAcademicApprovalDTO.Student_Qualification_PostGraduationDetails_BranchName = response.Entity.Student_Qualification_PostGraduationDetails_BranchName;
                    model.StudentRegistrationAcademicApprovalDTO.Student_Qualification_PostGraduationDetails_ExamPattern = response.Entity.Student_Qualification_PostGraduationDetails_ExamPattern;
                    model.StudentRegistrationAcademicApprovalDTO.Student_Qualification_PostGraduationDetails_MonthOfPassing = response.Entity.Student_Qualification_PostGraduationDetails_MonthOfPassing;
                    model.StudentRegistrationAcademicApprovalDTO.Student_Qualification_PostGraduationDetails_YearOfPassing = response.Entity.Student_Qualification_PostGraduationDetails_YearOfPassing;
                    if (response.Entity.Student_Qualification_PostGraduationDetails_SingleAttempt == "False")
                    {
                        model.StudentRegistrationAcademicApprovalDTO.Student_Qualification_PostGraduationDetails_SingleAttempt = "0";
                    }
                    else
                    {
                        model.StudentRegistrationAcademicApprovalDTO.Student_Qualification_PostGraduationDetails_SingleAttempt = "1";
                    }
                    model.StudentRegistrationAcademicApprovalDTO.Student_Qualification_PostGraduationDetails_ObtainedMark = response.Entity.Student_Qualification_PostGraduationDetails_ObtainedMark;
                    model.StudentRegistrationAcademicApprovalDTO.Student_Qualification_PostGraduationDetails_OutOfMark = response.Entity.Student_Qualification_PostGraduationDetails_OutOfMark;
                    model.StudentRegistrationAcademicApprovalDTO.Student_Qualification_PostGraduationDetails_Percent = response.Entity.Student_Qualification_PostGraduationDetails_Percent;
                    model.StudentRegistrationAcademicApprovalDTO.Student_Qualification_PostGraduationDetails_NameofInstitution = response.Entity.Student_Qualification_PostGraduationDetails_NameofInstitution;
                    model.StudentRegistrationAcademicApprovalDTO.Student_Qualification_PostGraduationDetails_UniversityName = response.Entity.Student_Qualification_PostGraduationDetails_UniversityName;
                    model.StudentRegistrationAcademicApprovalDTO.Student_Qualification_PostGraduationDetails_State = response.Entity.Student_Qualification_PostGraduationDetails_State;
                    model.StudentRegistrationAcademicApprovalDTO.Student_Qualification_PostGraduationDetails_CountryId = response.Entity.Student_Qualification_PostGraduationDetails_CountryId;
                    model.StudentRegistrationAcademicApprovalDTO.Student_Qualification_PostGraduationDetails_StateOther = response.Entity.Student_Qualification_PostGraduationDetails_StateOther;
                    model.StudentRegistrationAcademicApprovalDTO.Student_Qualification_PostGraduationDetails_PostGraduation = response.Entity.Student_Qualification_PostGraduationDetails_PostGraduation;
                    model.StudentRegistrationAcademicApprovalDTO.Student_Qualification_PostGraduationDetails_BoardEnrollmentNumber = response.Entity.Student_Qualification_PostGraduationDetails_BoardEnrollmentNumber;
                    model.StudentRegistrationAcademicApprovalDTO.Student_Qualification_PostGraduationDetails_Class = response.Entity.Student_Qualification_PostGraduationDetails_Class;
                    model.StudentRegistrationAcademicApprovalDTO.Student_DTE_DTEUserID = response.Entity.Student_DTE_DTEUserID;
                    model.StudentRegistrationAcademicApprovalDTO.Student_DTE_DTEPassword = response.Entity.Student_DTE_DTEPassword;
                    model.StudentRegistrationAcademicApprovalDTO.Student_DTE_DTESrNo = response.Entity.Student_DTE_DTESrNo;
                    model.StudentRegistrationAcademicApprovalDTO.Student_DTE_DTEMeritNo = response.Entity.Student_DTE_DTEMeritNo;
                    model.StudentRegistrationAcademicApprovalDTO.Student_DTE_AdmissionTypeId = response.Entity.Student_DTE_AdmissionTypeId;
                    model.StudentRegistrationAcademicApprovalDTO.Student_DTE_AdmissionRound = response.Entity.Student_DTE_AdmissionRound;
                    model.StudentRegistrationAcademicApprovalDTO.Student_DTE_AdmissionCategoryId = response.Entity.Student_DTE_AdmissionCategoryId;
                    model.StudentRegistrationAcademicApprovalDTO.Student_DTE_DTESeatNo = response.Entity.Student_DTE_DTESeatNo;
                    model.StudentRegistrationAcademicApprovalDTO.Student_DTE_QualifyingExamName = response.Entity.Student_DTE_QualifyingExamName;
                    model.StudentRegistrationAcademicApprovalDTO.Student_DTE_QualifyingExamMarks = response.Entity.Student_DTE_QualifyingExamMarks;
                    model.StudentRegistrationAcademicApprovalDTO.Student_QualifyingExamName = response.Entity.Student_DTE_QualifyingExamName;


                    //For Document
                    model.StudentRegistrationAcademicApprovalDTO.Student_AdmissionDocuments_JETMarkSheet = response.Entity.Student_AdmissionDocuments_JETMarkSheet;
                    model.StudentRegistrationAcademicApprovalDTO.Student_AdmissionDocuments_AllotmentLetter = response.Entity.Student_AdmissionDocuments_AllotmentLetter;
                    model.StudentRegistrationAcademicApprovalDTO.Student_AdmissionDocuments_TenthMarkSheet = response.Entity.Student_AdmissionDocuments_TenthMarkSheet;
                    model.StudentRegistrationAcademicApprovalDTO.Student_AdmissionDocuments_TwelvethMarkSheet = response.Entity.Student_AdmissionDocuments_TwelvethMarkSheet;
                    model.StudentRegistrationAcademicApprovalDTO.Student_AdmissionDocuments_AllDiplomaMarksheet = response.Entity.Student_AdmissionDocuments_AllDiplomaMarksheet;
                    model.StudentRegistrationAcademicApprovalDTO.Student_AdmissionDocuments_LeavingCertificate = response.Entity.Student_AdmissionDocuments_LeavingCertificate;
                    model.StudentRegistrationAcademicApprovalDTO.Student_AdmissionDocuments_Domicile_BirthCertificate = response.Entity.Student_AdmissionDocuments_Domicile_BirthCertificate;
                    model.StudentRegistrationAcademicApprovalDTO.Student_AdmissionDocuments_NationalityCertificate = response.Entity.Student_AdmissionDocuments_NationalityCertificate;
                    model.StudentRegistrationAcademicApprovalDTO.Student_AdmissionDocuments_CasteCertificate = response.Entity.Student_AdmissionDocuments_CasteCertificate;
                    model.StudentRegistrationAcademicApprovalDTO.Student_AdmissionDocuments_CasteValidityCertificate = response.Entity.Student_AdmissionDocuments_CasteValidityCertificate;
                    model.StudentRegistrationAcademicApprovalDTO.Student_AdmissionDocuments_NonCreamylayerCertificate = response.Entity.Student_AdmissionDocuments_NonCreamylayerCertificate;
                    model.StudentRegistrationAcademicApprovalDTO.Student_AdmissionDocuments_EquivalenceCertificate = response.Entity.Student_AdmissionDocuments_EquivalenceCertificate;
                    model.StudentRegistrationAcademicApprovalDTO.Student_AdmissionDocuments_MigrationCertificate = response.Entity.Student_AdmissionDocuments_MigrationCertificate;
                    model.StudentRegistrationAcademicApprovalDTO.Student_AdmissionDocuments_GapCertificate = response.Entity.Student_AdmissionDocuments_GapCertificate;
                    model.StudentRegistrationAcademicApprovalDTO.Student_AdmissionDocuments_AntiRaggingAffidavit = response.Entity.Student_AdmissionDocuments_AntiRaggingAffidavit;
                    model.StudentRegistrationAcademicApprovalDTO.Student_AdmissionDocuments_Proforma_Fand_F1_On_DoctorsLetter_Head = response.Entity.Student_AdmissionDocuments_Proforma_Fand_F1_On_DoctorsLetter_Head;
                    model.StudentRegistrationAcademicApprovalDTO.Student_AdmissionDocuments_Proforma_I = response.Entity.Student_AdmissionDocuments_Proforma_I;
                    model.StudentRegistrationAcademicApprovalDTO.Student_AdmissionDocuments_ProformaG1 = response.Entity.Student_AdmissionDocuments_ProformaG1;
                    model.StudentRegistrationAcademicApprovalDTO.Student_AdmissionDocuments_ProformaG2 = response.Entity.Student_AdmissionDocuments_ProformaG2;
                    model.StudentRegistrationAcademicApprovalDTO.Student_AdmissionDocuments_Proforma_C_D_E = response.Entity.Student_AdmissionDocuments_Proforma_C_D_E;
                    model.StudentRegistrationAcademicApprovalDTO.Student_AdmissionDocuments_FathersIncomeCertificate = response.Entity.Student_AdmissionDocuments_FathersIncomeCertificate;
                    model.StudentRegistrationAcademicApprovalDTO.Student_AdmissionDocuments_AadharCardXerox = response.Entity.Student_AdmissionDocuments_AadharCardXerox;
                    model.StudentRegistrationAcademicApprovalDTO.Student_AdmissionDocuments_B_WPhoto_I_card_size = response.Entity.Student_AdmissionDocuments_B_WPhoto_I_card_size;
                    model.StudentRegistrationAcademicApprovalDTO.Student_AdmissionDocuments_Colour_photo = response.Entity.Student_AdmissionDocuments_Colour_photo;
                    model.StudentRegistrationAcademicApprovalDTO.Student_BranchDetailIDOFBranchID = response.Entity.Student_BranchDetailIDOFBranchID;

                    //For PG Students
                    model.StudentRegistrationAcademicApprovalDTO.Student_AdmissionDocuments_PGStudents_DegreeMarksheet = response.Entity.Student_AdmissionDocuments_PGStudents_DegreeMarksheet;
                    model.StudentRegistrationAcademicApprovalDTO.Student_AdmissionDocuments_PGStudents_DegreeCertificate = response.Entity.Student_AdmissionDocuments_PGStudents_DegreeCertificate;
                    model.StudentRegistrationAcademicApprovalDTO.Student_AdmissionDocuments_PGStudents_GateScoreCard = response.Entity.Student_AdmissionDocuments_PGStudents_GateScoreCard;
                    model.StudentRegistrationAcademicApprovalDTO.Student_AdmissionDocuments_PGStudents_SponsorshipLetterforSponsoredCandidate = response.Entity.Student_AdmissionDocuments_PGStudents_SponsorshipLetterforSponsoredCandidate;

                    model.StudentRegistrationAcademicApprovalDTO.Student_StudentCode = "STU" + response.Entity.Student_CourseYearName + model.StudentRegistrationAcademicApprovalDTO.RegistrationID;


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
                ViewData["StudentNRI_POI"] = new SelectList(li_StudentRegistrationForm_NRI_POI, "Value", "Text", model.StudentRegistrationAcademicApprovalDTO.StudentNRI_POI);


                //For Academic Request Status
                List<SelectListItem> StudentRegistrationForm_AcademicRequestStatus = new List<SelectListItem>();
                ViewBag.StudentRegistrationForm_AcademicRequestStatus = new SelectList(StudentRegistrationForm_AcademicRequestStatus, "Value", "Text");
                List<SelectListItem> li_StudentRegistrationForm_AcademicRequestStatus = new List<SelectListItem>();
                li_StudentRegistrationForm_AcademicRequestStatus.Add(new SelectListItem { Text = "Accept", Value = "1" });
                li_StudentRegistrationForm_AcademicRequestStatus.Add(new SelectListItem { Text = "Reject", Value = "0" });
                ViewData["ApprovalStatus"] = li_StudentRegistrationForm_AcademicRequestStatus;

                //For Admitted Section details
                model.ListOrganisationSectionDetails = GetSectionDetailsRoleWise(Convert.ToInt32(model.StudentRegistrationAcademicApprovalDTO.Student_BranchDetailIDOFBranchID), model.StudentRegistrationAcademicApprovalDTO.CenterCode, Convert.ToString(model.StudentRegistrationAcademicApprovalDTO.UniversityID), "false");

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
                ViewData["StudentMaritalStatus"] = new SelectList(li_StudentRegistrationForm_StudentMaritalStatus, "Value", "Text", model.StudentRegistrationAcademicApprovalDTO.StudentMaritalStatus);

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
                ViewData["StudentBloodGroup"] = new SelectList(li_StudentRegistrationForm_StudentBloodGroup, "Value", "Text", model.StudentRegistrationAcademicApprovalDTO.StudentBloodGroup);

                //For PhysicallyHandicapped

                ViewData["PhysicallyHandicapped"] = new SelectList(li_StudentRegistrationForm_StudentPhysicallyHandicapped, "Value", "Text", model.StudentRegistrationAcademicApprovalDTO.PhysicallyHandicapped);

                ViewData["StudentEmploymentStatus"] = new SelectList(li_StudentRegistrationForm_StudentPhysicallyHandicapped, "Value", "Text", model.StudentRegistrationAcademicApprovalDTO.StudentEmploymentStatus);

                ViewData["Student_Qualification_General_SingleAttempt"] = new SelectList(li_StudentRegistrationForm_StudentPhysicallyHandicapped, "Value", "Text", model.StudentRegistrationAcademicApprovalDTO.Student_Qualification_General_SingleAttempt);
                ViewData["Student_Qualification_SSC_SingleAttempt"] = new SelectList(li_StudentRegistrationForm_StudentPhysicallyHandicapped, "Value", "Text", model.StudentRegistrationAcademicApprovalDTO.Student_Qualification_SSC_SingleAttempt);
                ViewData["Student_Qualification_HSC_SingleAttempt"] = new SelectList(li_StudentRegistrationForm_StudentPhysicallyHandicapped, "Value", "Text", model.StudentRegistrationAcademicApprovalDTO.Student_Qualification_HSC_SingleAttempt);
                ViewData["Student_Qualification_Diploma_ITI_Details_SingleAttempt"] = new SelectList(li_StudentRegistrationForm_StudentPhysicallyHandicapped, "Value", "Text", model.StudentRegistrationAcademicApprovalDTO.Student_Qualification_Diploma_ITI_Details_SingleAttempt);
                ViewData["Student_Qualification_DegreeDetails_SingleAttempt"] = new SelectList(li_StudentRegistrationForm_StudentPhysicallyHandicapped, "Value", "Text", model.StudentRegistrationAcademicApprovalDTO.Student_Qualification_DegreeDetails_SingleAttempt);
                ViewData["Student_Qualification_PostGraduationDetails_SingleAttempt"] = new SelectList(li_StudentRegistrationForm_StudentPhysicallyHandicapped, "Value", "Text", model.StudentRegistrationAcademicApprovalDTO.Student_Qualification_PostGraduationDetails_SingleAttempt);
                //For Organ donor
                List<SelectListItem> StudentRegistrationForm_StudentOrgandonor = new List<SelectListItem>();
                ViewBag.StudentRegistrationForm_StudentOrgandonor = new SelectList(StudentRegistrationForm_StudentOrgandonor, "Value", "Text");
                List<SelectListItem> li_StudentRegistrationForm_StudentOrgandonor = new List<SelectListItem>();
                li_StudentRegistrationForm_StudentOrgandonor.Add(new SelectListItem { Text = "NO", Value = "0" });
                li_StudentRegistrationForm_StudentOrgandonor.Add(new SelectListItem { Text = "YES", Value = "1" });
                ViewData["StudentOrgandonor"] = new SelectList(li_StudentRegistrationForm_StudentOrgandonor, "Value", "Text", model.StudentRegistrationAcademicApprovalDTO.StudentOrgandonor);





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

                List<GeneralRegionMaster> generalRegionMasterListforPermanentAddress = GetListGeneralRegionMaster(Convert.ToString(model.StudentRegistrationAcademicApprovalDTO.Student_PermanentAddress_CountryId));
                List<SelectListItem> generalRegionMasterforPermanentAddress = new List<SelectListItem>();
                generalRegionMasterforPermanentAddress.Add(new SelectListItem { Text = "Other", Value = "Other" });
                foreach (GeneralRegionMaster item in generalRegionMasterListforPermanentAddress)
                {
                    generalRegionMasterforPermanentAddress.Add(new SelectListItem { Text = item.RegionName + " ( " + item.CountryName + " )", Value = item.ID.ToString() });
                }
                ViewBag.GeneralRegionMasterforPermanentAddress = new SelectList(generalRegionMasterforPermanentAddress, "Value", "Text");

                //Student_PermanentAddress_DistrictID
                // string SelectedRegionID = "A";

                List<GeneralCityMaster> GeneralCityMasterListforPermanentAddress = GetListGeneralCityMaster(Convert.ToString(model.StudentRegistrationAcademicApprovalDTO.Student_PermanentAddress_State));
                List<SelectListItem> GeneralCityMasterforPermanentAddress = new List<SelectListItem>();
                GeneralCityMasterforPermanentAddress.Add(new SelectListItem { Text = "Other", Value = "Other" });
                foreach (GeneralCityMaster item in GeneralCityMasterListforPermanentAddress)
                {
                    GeneralCityMasterforPermanentAddress.Add(new SelectListItem { Text = item.Description, Value = item.ID.ToString() });
                }

                ViewBag.GeneralCityListforPermanentAddress = new SelectList(GeneralCityMasterforPermanentAddress, "Value", "Text");

                //Student_PermanentAddress_CityID
                List<GeneralLocationMaster> GeneralLocationMasterListforPermanentAddress = GetListGeneralLocationMasterByCityID(Convert.ToString(model.StudentRegistrationAcademicApprovalDTO.Student_PermanentAddress_DistrictID));
                List<SelectListItem> GeneralLocationMasterforPermanentAddress = new List<SelectListItem>();
                GeneralLocationMasterforPermanentAddress.Add(new SelectListItem { Text = "Other", Value = "Other" });
                foreach (GeneralLocationMaster item in GeneralLocationMasterListforPermanentAddress)
                {
                    GeneralLocationMasterforPermanentAddress.Add(new SelectListItem { Text = item.LocationAddress, Value = item.ID.ToString() });
                }

                ViewBag.GeneralLocationListforPermanentAddress = new SelectList(GeneralLocationMasterforPermanentAddress, "Value", "Text");

                //For Student_CorrespondenceAddress_State

                List<GeneralRegionMaster> generalRegionMasterListforCorrespondenceAddress = GetListGeneralRegionMaster(Convert.ToString(model.StudentRegistrationAcademicApprovalDTO.Student_CorrespondenceAddress_CountryId));
                List<SelectListItem> generalRegionMasterforCorrespondenceAddress = new List<SelectListItem>();
                generalRegionMasterforCorrespondenceAddress.Add(new SelectListItem { Text = "Other", Value = "Other" });
                foreach (GeneralRegionMaster item in generalRegionMasterListforCorrespondenceAddress)
                {
                    generalRegionMasterforCorrespondenceAddress.Add(new SelectListItem { Text = item.RegionName + " ( " + item.CountryName + " )", Value = item.ID.ToString() });
                }
                ViewBag.GeneralRegionMasterforCorrespondenceAddress = new SelectList(generalRegionMasterforCorrespondenceAddress, "Value", "Text");

                //Student_CorrespondenceAddress_DistrictID
                // string SelectedRegionID = "A";

                List<GeneralCityMaster> GeneralCityMasterListforCorrespondenceAddress = GetListGeneralCityMaster(Convert.ToString(model.StudentRegistrationAcademicApprovalDTO.Student_CorrespondenceAddress_State));
                List<SelectListItem> GeneralCityMasterforCorrespondenceAddress = new List<SelectListItem>();
                GeneralCityMasterforCorrespondenceAddress.Add(new SelectListItem { Text = "Other", Value = "Other" });
                foreach (GeneralCityMaster item in GeneralCityMasterListforCorrespondenceAddress)
                {
                    GeneralCityMasterforCorrespondenceAddress.Add(new SelectListItem { Text = item.Description, Value = item.ID.ToString() });
                }

                ViewBag.GeneralCityListforCorrespondenceAddress = new SelectList(GeneralCityMasterforCorrespondenceAddress, "Value", "Text");

                //Student_CorrespondenceAddress_CityID
                List<GeneralLocationMaster> GeneralLocationMasterListforCorrespondenceAddress = GetListGeneralLocationMasterByCityID(Convert.ToString(model.StudentRegistrationAcademicApprovalDTO.Student_CorrespondenceAddress_DistrictID));
                List<SelectListItem> GeneralLocationMasterforCorrespondenceAddress = new List<SelectListItem>();
                GeneralLocationMasterforCorrespondenceAddress.Add(new SelectListItem { Text = "Other", Value = "Other" });
                foreach (GeneralLocationMaster item in GeneralLocationMasterListforCorrespondenceAddress)
                {
                    GeneralLocationMasterforCorrespondenceAddress.Add(new SelectListItem { Text = item.LocationAddress, Value = item.ID.ToString() });
                }

                ViewBag.GeneralLocationListforCorrespondenceAddress = new SelectList(GeneralLocationMasterforPermanentAddress, "Value", "Text");
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

                List<GeneralCasteMaster> GeneralCasteMasterList = GetListGeneralCasteMaster(model.StudentRegistrationAcademicApprovalDTO.StudentCategoryID);
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
                ViewData["StudentEconomicallyBackwardClass"] = new SelectList(li_StudentRegistrationForm_StudentEconomicallyBackwardClass, "Value", "Text", model.StudentRegistrationAcademicApprovalDTO.StudentEconomicallyBackwardClass);

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
                ViewData["Student_PermanentAddress_City_Tahsil_Pattern"] = new SelectList(li_StudentRegistrationForm_PermanentAddress_City_Tahsil_Pattern, "Value", "Text", model.StudentRegistrationAcademicApprovalDTO.Student_PermanentAddress_City_Tahsil_Pattern);

                ViewData["Student_CorrespondenceAddress_City_Tahsil_Pattern"] = new SelectList(li_StudentRegistrationForm_PermanentAddress_City_Tahsil_Pattern, "Value", "Text", model.StudentRegistrationAcademicApprovalDTO.Student_CorrespondenceAddress_City_Tahsil_Pattern);
                //For Exam_Pattern
                List<SelectListItem> StudentRegistrationForm_Exam_Pattern = new List<SelectListItem>();
                ViewBag.StudentRegistrationForm_Exam_Pattern = new SelectList(StudentRegistrationForm_Exam_Pattern, "Value", "Text");
                List<SelectListItem> li_StudentRegistrationForm_Exam_Pattern = new List<SelectListItem>();
                li_StudentRegistrationForm_Exam_Pattern.Add(new SelectListItem { Text = "Yearly", Value = "Y" });
                li_StudentRegistrationForm_Exam_Pattern.Add(new SelectListItem { Text = "Semester", Value = "S" });
                ViewData["Student_Qualification_Diploma_ITI_Details_ExamPattern"] = new SelectList(li_StudentRegistrationForm_Exam_Pattern, "Value", "Text", model.StudentRegistrationAcademicApprovalDTO.Student_Qualification_Diploma_ITI_Details_ExamPattern);
                ViewData["Student_Qualification_DegreeDetails_ExamPattern"] = new SelectList(li_StudentRegistrationForm_Exam_Pattern, "Value", "Text", model.StudentRegistrationAcademicApprovalDTO.Student_Qualification_DegreeDetails_ExamPattern);
                ViewData["Student_Qualification_PostGraduationDetails_ExamPattern"] = new SelectList(li_StudentRegistrationForm_Exam_Pattern, "Value", "Text", model.StudentRegistrationAcademicApprovalDTO.Student_Qualification_PostGraduationDetails_ExamPattern);
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
                ViewData["Student_Qualification_General_MonthOfPassing"] = new SelectList(li_Student_Qualification_General_MonthOfPassing, "Value", "Text", model.StudentRegistrationAcademicApprovalDTO.Student_Qualification_General_MonthOfPassing);
                ViewData["Student_Qualification_SSC_MonthOfPassing"] = new SelectList(li_Student_Qualification_General_MonthOfPassing, "Value", "Text", model.StudentRegistrationAcademicApprovalDTO.Student_Qualification_SSC_MonthOfPassing);
                ViewData["Student_Qualification_HSC_MonthOfPassing"] = new SelectList(li_Student_Qualification_General_MonthOfPassing, "Value", "Text", model.StudentRegistrationAcademicApprovalDTO.Student_Qualification_HSC_MonthOfPassing);
                ViewData["Student_Qualification_Diploma_ITI_Details_MonthOfPassing"] = new SelectList(li_Student_Qualification_General_MonthOfPassing, "Value", "Text", model.StudentRegistrationAcademicApprovalDTO.Student_Qualification_Diploma_ITI_Details_MonthOfPassing);
                ViewData["Student_Qualification_DegreeDetails_MonthOfPassing"] = new SelectList(li_Student_Qualification_General_MonthOfPassing, "Value", "Text", model.StudentRegistrationAcademicApprovalDTO.Student_Qualification_DegreeDetails_MonthOfPassing);
                ViewData["Student_Qualification_PostGraduationDetails_MonthOfPassing"] = new SelectList(li_Student_Qualification_General_MonthOfPassing, "Value", "Text", model.StudentRegistrationAcademicApprovalDTO.Student_Qualification_PostGraduationDetails_MonthOfPassing);

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
                ViewData["Student_Qualification_General_YearOfPassing"] = new SelectList(li_Student_Qualification_General_YearOfPassing, "Value", "Text", model.StudentRegistrationAcademicApprovalDTO.Student_Qualification_General_YearOfPassing);
                ViewData["Student_Qualification_SSC_YearOfPassing"] = new SelectList(li_Student_Qualification_General_YearOfPassing, "Value", "Text", model.StudentRegistrationAcademicApprovalDTO.Student_Qualification_SSC_YearOfPassing);
                ViewData["Student_Qualification_HSC_YearOfPassing"] = new SelectList(li_Student_Qualification_General_YearOfPassing, "Value", "Text", model.StudentRegistrationAcademicApprovalDTO.Student_Qualification_HSC_YearOfPassing);
                ViewData["Student_Qualification_Diploma_ITI_Details_YearOfPassing"] = new SelectList(li_Student_Qualification_General_YearOfPassing, "Value", "Text", model.StudentRegistrationAcademicApprovalDTO.Student_Qualification_Diploma_ITI_Details_YearOfPassing);
                ViewData["Student_Qualification_DegreeDetails_YearOfPassing"] = new SelectList(li_Student_Qualification_General_YearOfPassing, "Value", "Text", model.StudentRegistrationAcademicApprovalDTO.Student_Qualification_DegreeDetails_YearOfPassing);
                ViewData["Student_Qualification_PostGraduationDetails_YearOfPassing"] = new SelectList(li_Student_Qualification_General_YearOfPassing, "Value", "Text", model.StudentRegistrationAcademicApprovalDTO.Student_Qualification_PostGraduationDetails_YearOfPassing);


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
                ViewData["Student_Qualification_HSC_Class"] = new SelectList(li_StudentRegistrationForm_Class, "Value", "Text", model.StudentRegistrationAcademicApprovalDTO.Student_Qualification_HSC_Class);
                ViewData["Student_Qualification_Diploma_ITI_Details_Class"] = new SelectList(li_StudentRegistrationForm_Class, "Value", "Text", model.StudentRegistrationAcademicApprovalDTO.Student_Qualification_Diploma_ITI_Details_Class);
                ViewData["Student_Qualification_DegreeDetails_Class"] = new SelectList(li_StudentRegistrationForm_Class, "Value", "Text", model.StudentRegistrationAcademicApprovalDTO.Student_Qualification_DegreeDetails_Class);
                ViewData["Student_Qualification_PostGraduationDetails_Class"] = new SelectList(li_StudentRegistrationForm_Class, "Value", "Text", model.StudentRegistrationAcademicApprovalDTO.Student_Qualification_PostGraduationDetails_Class);
                #endregion Method
                model.StudentRegistrationFormList = GetListStudentRegistrationForm(model.StudentRegistrationAcademicApprovalDTO.CenterCode, model.StudentRegistrationAcademicApprovalDTO.UniversityID, model.StudentRegistrationAcademicApprovalDTO.BranchDetailID, model.StudentRegistrationAcademicApprovalDTO.StandardNumber);


                List<ToolTemplateApplicable> organisationBranchDetailList = GetListBranchDetails(model.StudentRegistrationAcademicApprovalDTO.UniversityID, model.StudentRegistrationAcademicApprovalDTO.CenterCode);
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
                model.QualifyingExamSubjectList = GetListQualifyingExamSubject(model.StudentRegistrationAcademicApprovalDTO.RegistrationID);

                // For Qualification Exam Subject   for General
                model.QualificationMasterSubjectListForGeneral = GetByQualificationSubjectListByStudentRegistrationIDAndEducationType(model.StudentRegistrationAcademicApprovalDTO.RegistrationID, "G");

                // For Qualification Exam Subject   for SSC
                model.QualificationMasterSubjectListForSSC = GetByQualificationSubjectListByStudentRegistrationIDAndEducationType(model.StudentRegistrationAcademicApprovalDTO.RegistrationID, "S");

                // For Qualification Exam Subject   for HSC
                model.QualificationMasterSubjectListForHSC = GetByQualificationSubjectListByStudentRegistrationIDAndEducationType(model.StudentRegistrationAcademicApprovalDTO.RegistrationID, "H");
                // for Academic year
                List<OrganisationCentrewiseSession> list = GetCurrentSession(model.StudentRegistrationAcademicApprovalDTO.CenterCode);
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



                ////For Branch Details
                model.OrganisationBranchDetailsDTO = GetOrganisationBranchDetailsSelectByID(model.BranchDetailID);
                model.Student_CourseName = model.OrganisationBranchDetailsDTO.BranchDescription;

                ////For Task Approval               
                model.TaskCode = TaskCode;
                model.TaskNotificationDetailsID = Convert.ToInt32(TNDID);
                model.TaskNotificationMasterID = Convert.ToInt32(TNMID);
                model.GeneralTaskReportingDetailsID = Convert.ToInt32(GTRDID1);
                model.PersonID = Convert.ToInt32(PersonID);
                model.StageSequenceNumber = Convert.ToInt32(StageSequenceNumber);
                model.IsLastRecord = Convert.ToBoolean(IsLast);


                GeneralTaskReportingDetails GeneralTaskReportingDetailsDTO = new GeneralTaskReportingDetails();
                GeneralTaskReportingDetailsDTO.TaskNotificationMasterID = model.TaskNotificationMasterID;
                GeneralTaskReportingDetailsDTO.ModifiedBy = Convert.ToInt32(Session["UserID"]);
                GeneralTaskReportingDetailsDTO.ConnectionString = _connectioString;
                IBaseEntityResponse<GeneralTaskReportingDetails> response1 = _generalTaskReportingDetailsServiceAccess.UpdateEnagedByUserID(GeneralTaskReportingDetailsDTO);
                model.StudentRegistrationAcademicApprovalDTO.errorMessage = CheckError((response1.Entity != null) ? response1.Entity.ErrorCode : 20, ActionModeEnum.Update);
                return View("/Views/StudentRegistration/StudentRegistrationAcademicApproval/Edit.cshtml", model);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet]
        public ActionResult EditV2(string PersonID, string TNDID, string TNMID, string GTRDID1, string TaskCode, string StageSequenceNumber, string IsLast)
        {
            StudentRegistrationAcademicApprovalViewModel model = new StudentRegistrationAcademicApprovalViewModel();
            try
            {
                model.StudentRegistrationAcademicApprovalDTO = new StudentRegistrationAcademicApproval();

                string[] aaa = PersonID.Split('~');

                model.StudentRegistrationAcademicApprovalDTO.RegistrationID = Convert.ToInt32(PersonID);
                model.StudentRegistrationAcademicApprovalDTO.AuthorisationType = "Academic";
                model.StudentRegistrationAcademicApprovalDTO.ConnectionString = _connectioString;

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


                IBaseEntityResponse<StudentRegistrationAcademicApproval> response = _StudentRegistrationAcademicApprovalServiceAcess.SelectByID(model.StudentRegistrationAcademicApprovalDTO);
                if (response != null && response.Entity != null)
                {
                    model.StudentRegistrationAcademicApprovalDTO.ID = response.Entity.ID;
                    model.StudentRegistrationAcademicApprovalDTO.RegistrationID = response.Entity.RegistrationID;
                    model.StudentRegistrationAcademicApprovalDTO.StudentDateofRegistration = response.Entity.StudentDateofRegistration;
                    model.StudentRegistrationAcademicApprovalDTO.StudentTitle = response.Entity.StudentTitle;
                    model.StudentRegistrationAcademicApprovalDTO.StudentFirstName = response.Entity.StudentFirstName;
                    model.StudentRegistrationAcademicApprovalDTO.StudentMiddleName = response.Entity.StudentMiddleName;
                    model.StudentRegistrationAcademicApprovalDTO.StudentLastName = response.Entity.StudentLastName;
                    model.StudentRegistrationAcademicApprovalDTO.MotherFirstName = response.Entity.MotherFirstName;
                    model.StudentRegistrationAcademicApprovalDTO.StudentMobileNumber = response.Entity.StudentMobileNumber;
                    model.StudentRegistrationAcademicApprovalDTO.FatherMobileNumber = response.Entity.FatherMobileNumber;
                    model.StudentRegistrationAcademicApprovalDTO.GuardianMobileNumber = response.Entity.GuardianMobileNumber;
                    model.StudentRegistrationAcademicApprovalDTO.FatherLandLineNumber = response.Entity.FatherLandLineNumber;
                    model.StudentRegistrationAcademicApprovalDTO.FatherEmailId = response.Entity.FatherEmailId;
                    model.StudentRegistrationAcademicApprovalDTO.GuardianEmailId = response.Entity.GuardianEmailId;
                    model.StudentRegistrationAcademicApprovalDTO.FatherEmailId = response.Entity.FatherEmailId;
                    model.StudentRegistrationAcademicApprovalDTO.MotherEmailId = response.Entity.MotherEmailId;
                    model.StudentRegistrationAcademicApprovalDTO.StudentEmailID = response.Entity.StudentEmailID;

                    model.StudentRegistrationAcademicApprovalDTO.StudentNameAsPerMarkSheet = response.Entity.StudentNameAsPerMarkSheet;
                    model.StudentRegistrationAcademicApprovalDTO.StudentLastSchool_College = response.Entity.StudentLastSchool_College;
                    model.StudentRegistrationAcademicApprovalDTO.StudentPreviousLC_TCNo = response.Entity.StudentPreviousLC_TCNo;
                    model.StudentRegistrationAcademicApprovalDTO.StudentCasteAsPerTC_LC = response.Entity.StudentCasteAsPerTC_LC;
                    model.StudentRegistrationAcademicApprovalDTO.StudentEnrollmentNo = response.Entity.StudentEnrollmentNo;
                    model.StudentRegistrationAcademicApprovalDTO.StudentRegionID = response.Entity.StudentRegionID;
                    model.StudentRegistrationAcademicApprovalDTO.Student_Domesile_CountryId = response.Entity.Student_Domesile_CountryId;
                    model.StudentRegistrationAcademicApprovalDTO.StudentRegionOther = response.Entity.StudentRegionOther;
                    model.StudentRegistrationAcademicApprovalDTO.StudentMigrationNumber = response.Entity.StudentMigrationNumber;

                    model.StudentRegistrationAcademicApprovalDTO.StudentMigrationDate = response.Entity.StudentMigrationDate;

                    model.StudentRegistrationAcademicApprovalDTO.Student_DTE_AdmissionCategoryId = response.Entity.Student_DTE_AdmissionCategoryId;
                    model.StudentRegistrationAcademicApprovalDTO.Student_DTE_AdmissionTypeId = response.Entity.Student_DTE_AdmissionTypeId;
                    // ,[IsHostelResidency]
                    model.StudentRegistrationAcademicApprovalDTO.BranchDetailID = response.Entity.BranchDetailID;
                    model.StudentRegistrationAcademicApprovalDTO.StandardNumber = response.Entity.StandardNumber;
                    // ,[AdmissionPatternID]
                    // ,[StudentActiveFlag]
                    //,[AcademicYearID]
                    model.StudentRegistrationAcademicApprovalDTO.CenterCode = response.Entity.CenterCode;
                    model.StudentRegistrationAcademicApprovalDTO.UniversityID = response.Entity.UniversityID;

                    model.StudentRegistrationAcademicApprovalDTO.StudentNRI_POI = response.Entity.StudentNRI_POI;

                    model.StudentRegistrationAcademicApprovalDTO.NameOfApplicant = response.Entity.NameOfApplicant;
                    model.StudentRegistrationAcademicApprovalDTO.TitleOfProject = response.Entity.TitleOfProject;
                    model.StudentRegistrationAcademicApprovalDTO.ProjectSummary = response.Entity.ProjectSummary;

                    //,[AllotAdmThrough]
                    //,[BankAccountNumber]
                    //,[BankBranchName]
                    //,[BankIFSCCode]
                    //,[BankMICRCode]
                    model.StudentRegistrationAcademicApprovalDTO.Student_Scholarship_AadhaarCardNo = response.Entity.Student_Scholarship_AadhaarCardNo;

                    //,[IdentificationType]

                    model.StudentRegistrationAcademicApprovalDTO.StudentPhoto = response.Entity.StudentPhoto;
                    model.StudentRegistrationAcademicApprovalDTO.StudentSignature = response.Entity.StudentSignature;
                    model.StudentRegistrationAcademicApprovalDTO.StudentThumb = response.Entity.StudentThumb;

                    model.StudentRegistrationAcademicApprovalDTO.StudentPhotoFileSize = response.Entity.StudentPhotoFileSize;
                    model.StudentRegistrationAcademicApprovalDTO.StudentSignatureFileSize = response.Entity.StudentSignatureFileSize;
                    model.StudentRegistrationAcademicApprovalDTO.StudentThumbFileSize = response.Entity.StudentThumbFileSize;


                    model.StudentRegistrationAcademicApprovalDTO.StudentPhotoType = response.Entity.StudentPhotoType;
                    model.StudentRegistrationAcademicApprovalDTO.StudentPhotoFilename = response.Entity.StudentPhotoFilename;
                    model.StudentRegistrationAcademicApprovalDTO.StudentPhotoFileWidth = response.Entity.StudentPhotoFileWidth;
                    model.StudentRegistrationAcademicApprovalDTO.StudentPhotoFileHeight = response.Entity.StudentPhotoFileHeight;

                    model.StudentRegistrationAcademicApprovalDTO.StudentSignatureType = response.Entity.StudentSignatureType;
                    model.StudentRegistrationAcademicApprovalDTO.StudentSignatureFilename = response.Entity.StudentSignatureFilename;
                    model.StudentRegistrationAcademicApprovalDTO.StudentSignatureFileWidth = response.Entity.StudentSignatureFileWidth;
                    model.StudentRegistrationAcademicApprovalDTO.StudentSignatureFileHeight = response.Entity.StudentSignatureFileHeight;

                    model.StudentRegistrationAcademicApprovalDTO.StudentThumbType = response.Entity.StudentThumbType;
                    model.StudentRegistrationAcademicApprovalDTO.StudentThumbFilename = response.Entity.StudentThumbFilename;
                    model.StudentRegistrationAcademicApprovalDTO.StudentThumbFileWidth = response.Entity.StudentThumbFileWidth;
                    model.StudentRegistrationAcademicApprovalDTO.StudentThumbFileHeight = response.Entity.StudentThumbFileHeight;


                    model.StudentRegistrationAcademicApprovalDTO.StudentDateofBirth = response.Entity.StudentDateofBirth;
                    model.StudentRegistrationAcademicApprovalDTO.StudentBirthPlace = response.Entity.StudentBirthPlace;
                    model.StudentRegistrationAcademicApprovalDTO.StudentGender = response.Entity.StudentGender;
                    model.StudentRegistrationAcademicApprovalDTO.StudentMaritalStatus = response.Entity.StudentMaritalStatus;
                    model.StudentRegistrationAcademicApprovalDTO.StudentNationalityID = response.Entity.StudentNationalityID;
                    model.StudentRegistrationAcademicApprovalDTO.StudentReligionID = response.Entity.StudentReligionID;
                    model.StudentRegistrationAcademicApprovalDTO.StudentMotherTongueID = response.Entity.StudentMotherTongueID;
                    model.StudentRegistrationAcademicApprovalDTO.StudentCategoryID = response.Entity.StudentCategoryID;
                    model.StudentRegistrationAcademicApprovalDTO.StudentCasteID = response.Entity.StudentCasteID;

                    //,C.SubCasteId
                    model.StudentRegistrationAcademicApprovalDTO.StudentBloodGroup = response.Entity.StudentBloodGroup;
                    model.StudentRegistrationAcademicApprovalDTO.StudentLandLineNumber = response.Entity.StudentLandLineNumber;
                    model.StudentRegistrationAcademicApprovalDTO.StudentIdentificationMark = response.Entity.StudentIdentificationMark;
                    model.StudentRegistrationAcademicApprovalDTO.StudentEmploymentSector = response.Entity.StudentEmploymentSector;
                    model.StudentRegistrationAcademicApprovalDTO.StudentOccupation = response.Entity.StudentOccupation;
                    model.StudentRegistrationAcademicApprovalDTO.StudentDesignation = response.Entity.StudentDesignation;
                    model.StudentRegistrationAcademicApprovalDTO.StudentOrganizationName = response.Entity.StudentOrganizationName;
                    model.StudentRegistrationAcademicApprovalDTO.StudentOfficeContactNo = response.Entity.StudentOfficeContactNo;
                    model.StudentRegistrationAcademicApprovalDTO.StudentAnnualIncome = response.Entity.StudentAnnualIncome;
                    if (response.Entity.PhysicallyHandicapped == "False")
                    {
                        model.StudentRegistrationAcademicApprovalDTO.PhysicallyHandicapped = "0";
                    }
                    else
                    {
                        model.StudentRegistrationAcademicApprovalDTO.PhysicallyHandicapped = "1";
                    }
                    if (response.Entity.StudentOrgandonor == "False")
                    {
                        model.StudentRegistrationAcademicApprovalDTO.StudentOrgandonor = "0";
                    }
                    else
                    {
                        model.StudentRegistrationAcademicApprovalDTO.StudentOrgandonor = "1";
                    }


                    model.StudentRegistrationAcademicApprovalDTO.StudentPrevNameofStudent = response.Entity.StudentPrevNameofStudent;
                    model.StudentRegistrationAcademicApprovalDTO.StudentReasonforNamechange = response.Entity.StudentReasonforNamechange;
                    if (response.Entity.StudentEmploymentStatus == "False")
                    {
                        model.StudentRegistrationAcademicApprovalDTO.StudentEmploymentStatus = "0";
                    }
                    else
                    {
                        model.StudentRegistrationAcademicApprovalDTO.StudentEmploymentStatus = "1";
                    }


                    model.StudentRegistrationAcademicApprovalDTO.FatherHusbondType = response.Entity.FatherHusbondType;
                    model.StudentRegistrationAcademicApprovalDTO.FatherTitle = response.Entity.FatherTitle;
                    model.StudentRegistrationAcademicApprovalDTO.FatherFirstName = response.Entity.FatherFirstName;
                    model.StudentRegistrationAcademicApprovalDTO.FatherMiddleName = response.Entity.FatherMiddleName;
                    model.StudentRegistrationAcademicApprovalDTO.FatherLastName = response.Entity.FatherLastName;
                    model.StudentRegistrationAcademicApprovalDTO.FatherEmailId = response.Entity.FatherEmailId;
                    model.StudentRegistrationAcademicApprovalDTO.FatherMobileNumber = response.Entity.FatherMobileNumber;
                    model.StudentRegistrationAcademicApprovalDTO.StudentDomicileStateofFather = response.Entity.StudentDomicileStateofFather;
                    model.StudentRegistrationAcademicApprovalDTO.FatherLandLineNumber = response.Entity.FatherLandLineNumber;
                    model.StudentRegistrationAcademicApprovalDTO.FatherEmploymentSector = response.Entity.FatherEmploymentSector;
                    model.StudentRegistrationAcademicApprovalDTO.FatherOccupation = response.Entity.FatherOccupation;
                    model.StudentRegistrationAcademicApprovalDTO.FatherDesignation = response.Entity.FatherDesignation;
                    model.StudentRegistrationAcademicApprovalDTO.FatherOrganizationName = response.Entity.FatherOrganizationName;
                    model.StudentRegistrationAcademicApprovalDTO.FatherOfficeContactNo = response.Entity.FatherOfficeContactNo;
                    model.StudentRegistrationAcademicApprovalDTO.FatherAnnualIncome = response.Entity.FatherAnnualIncome;

                    //   model.StudentRegistrationAcademicApprovalDTO.FatherHusbondType =  response.Entity.["M_EntityType";
                    model.StudentRegistrationAcademicApprovalDTO.MotherTitle = response.Entity.MotherTitle;
                    model.StudentRegistrationAcademicApprovalDTO.MotherFirstName = response.Entity.MotherFirstName;
                    model.StudentRegistrationAcademicApprovalDTO.MotherMiddleName = response.Entity.MotherMiddleName;
                    model.StudentRegistrationAcademicApprovalDTO.MotherLastName = response.Entity.MotherLastName;
                    model.StudentRegistrationAcademicApprovalDTO.MotherEmailId = response.Entity.MotherEmailId;
                    model.StudentRegistrationAcademicApprovalDTO.MotherMobileNumber = response.Entity.MotherMobileNumber;
                    model.StudentRegistrationAcademicApprovalDTO.StudentDomicileStateofMother = response.Entity.StudentDomicileStateofMother;
                    model.StudentRegistrationAcademicApprovalDTO.MotherLandLineNumber = response.Entity.MotherLandLineNumber;
                    model.StudentRegistrationAcademicApprovalDTO.MotherEmploymentSector = response.Entity.MotherEmploymentSector;
                    model.StudentRegistrationAcademicApprovalDTO.MotherOccupation = response.Entity.MotherOccupation;
                    model.StudentRegistrationAcademicApprovalDTO.MotherDesignation = response.Entity.MotherDesignation;
                    model.StudentRegistrationAcademicApprovalDTO.MotherOrganizationName = response.Entity.MotherOrganizationName;
                    model.StudentRegistrationAcademicApprovalDTO.MotherOfficeContactNo = response.Entity.MotherOfficeContactNo;
                    model.StudentRegistrationAcademicApprovalDTO.MotherAnnualIncome = response.Entity.MotherAnnualIncome;

                    model.StudentRegistrationAcademicApprovalDTO.GuardianTitle = response.Entity.GuardianTitle;
                    model.StudentRegistrationAcademicApprovalDTO.GuardianFirstName = response.Entity.GuardianFirstName;
                    model.StudentRegistrationAcademicApprovalDTO.GuardianMiddleName = response.Entity.GuardianMiddleName;
                    model.StudentRegistrationAcademicApprovalDTO.GuardianLastName = response.Entity.GuardianLastName;
                    model.StudentRegistrationAcademicApprovalDTO.GuardianEmailId = response.Entity.GuardianEmailId;
                    model.StudentRegistrationAcademicApprovalDTO.GuardianMobileNumber = response.Entity.GuardianMobileNumber;
                    //    model.StudentRegistrationAcademicApprovalDTO.StudentDomicileStateofGuardian =  response.Entity.["G_DomicileState";
                    model.StudentRegistrationAcademicApprovalDTO.GuardianLandLineNumber = response.Entity.GuardianLandLineNumber;
                    model.StudentRegistrationAcademicApprovalDTO.GuardianEmploymentSector = response.Entity.GuardianEmploymentSector;
                    model.StudentRegistrationAcademicApprovalDTO.GuardianOccupation = response.Entity.GuardianOccupation;
                    model.StudentRegistrationAcademicApprovalDTO.GuardianDesignation = response.Entity.GuardianDesignation;
                    model.StudentRegistrationAcademicApprovalDTO.GuardianOrganizationName = response.Entity.GuardianOrganizationName;
                    model.StudentRegistrationAcademicApprovalDTO.GuardianOfficeContactNo = response.Entity.GuardianOfficeContactNo;
                    model.StudentRegistrationAcademicApprovalDTO.GuardianAnnualIncome = response.Entity.GuardianAnnualIncome;

                    model.StudentRegistrationAcademicApprovalDTO.Student_Ex_Serviceman_Ward_of_Ex_Serviceman = response.Entity.Student_Ex_Serviceman_Ward_of_Ex_Serviceman;
                    model.StudentRegistrationAcademicApprovalDTO.Student_Active_Serviceman_Ward_of_Active_Serviceman = response.Entity.Student_Active_Serviceman_Ward_of_Active_Serviceman;
                    model.StudentRegistrationAcademicApprovalDTO.Student_FreedomFighterWardOfFreedomFighter = response.Entity.Student_FreedomFighterWardOfFreedomFighter;
                    model.StudentRegistrationAcademicApprovalDTO.Student_WardofPrimaryTeacher = response.Entity.Student_WardofPrimaryTeacher;
                    model.StudentRegistrationAcademicApprovalDTO.Student_WardofSecondaryTeacher = response.Entity.Student_WardofSecondaryTeacher;
                    model.StudentRegistrationAcademicApprovalDTO.Student_Deserted_Divorced_Widowed_Women = response.Entity.Student_Deserted_Divorced_Widowed_Women;
                    model.StudentRegistrationAcademicApprovalDTO.Student_MemberofProjectAffectedFamily = response.Entity.Student_MemberofProjectAffectedFamily;
                    model.StudentRegistrationAcademicApprovalDTO.Student_MemberofEarthquakeAffectedFamily = response.Entity.Student_MemberofEarthquakeAffectedFamily;
                    model.StudentRegistrationAcademicApprovalDTO.Student_MemberofFloodFamineAffectedFamily = response.Entity.Student_MemberofFloodFamineAffectedFamily;
                    model.StudentRegistrationAcademicApprovalDTO.Student_ResidentofTribalArea = response.Entity.Student_ResidentofTribalArea;
                    model.StudentRegistrationAcademicApprovalDTO.Student_KashmirMigrant = response.Entity.Student_KashmirMigrant;

                    model.StudentRegistrationAcademicApprovalDTO.StudentIndicatetypeofCandidature = response.Entity.StudentIndicatetypeofCandidature;
                    model.StudentRegistrationAcademicApprovalDTO.StudentSchoolFromHSCExaminationpassed = response.Entity.StudentSchoolFromHSCExaminationpassed;
                    if (response.Entity.StudentEconomicallyBackwardClass == "False")
                    {
                        model.StudentRegistrationAcademicApprovalDTO.StudentEconomicallyBackwardClass = "0";
                    }
                    else
                    {
                        model.StudentRegistrationAcademicApprovalDTO.StudentEconomicallyBackwardClass = "1";
                    }

                    model.StudentRegistrationAcademicApprovalDTO.StudentsNameOfDistrictWhereParentDomiciled = response.Entity.StudentsNameOfDistrictWhereParentDomiciled;
                    model.StudentRegistrationAcademicApprovalDTO.StudentsMKBCandidate = response.Entity.StudentsMKBCandidate;

                    model.StudentRegistrationAcademicApprovalDTO.Student_PermanentAddress_Address1 = response.Entity.Student_PermanentAddress_Address1;
                    model.StudentRegistrationAcademicApprovalDTO.Student_PermanentAddress_Address2 = response.Entity.Student_PermanentAddress_Address2;
                    model.StudentRegistrationAcademicApprovalDTO.Student_PermanentAddress_PloteNo = response.Entity.Student_PermanentAddress_PloteNo;
                    model.StudentRegistrationAcademicApprovalDTO.Student_PermanentAddress_StreeNo = response.Entity.Student_PermanentAddress_StreeNo;
                    model.StudentRegistrationAcademicApprovalDTO.Student_PermanentAddress_City_TahsilID = response.Entity.Student_PermanentAddress_City_TahsilID;
                    model.StudentRegistrationAcademicApprovalDTO.Student_PermanentAddress_City_TahsilName = response.Entity.Student_PermanentAddress_City_TahsilName;
                    model.StudentRegistrationAcademicApprovalDTO.Student_PermanentAddress_City_TahsilOther = response.Entity.Student_PermanentAddress_City_TahsilOther;
                    model.StudentRegistrationAcademicApprovalDTO.Student_PermanentAddress_DistrictID = response.Entity.Student_PermanentAddress_DistrictID;
                    model.StudentRegistrationAcademicApprovalDTO.Student_PermanentAddress_DistrictOther = response.Entity.Student_PermanentAddress_DistrictOther;
                    model.StudentRegistrationAcademicApprovalDTO.Student_PermanentAddress_State = response.Entity.Student_PermanentAddress_State;
                    model.StudentRegistrationAcademicApprovalDTO.Student_PermanentAddress_StateOther = response.Entity.Student_PermanentAddress_StateOther;
                    model.StudentRegistrationAcademicApprovalDTO.Student_PermanentAddress_CountryId = response.Entity.Student_PermanentAddress_CountryId;
                    model.StudentRegistrationAcademicApprovalDTO.Student_PermanentAddress_NearPoliceStation = response.Entity.Student_PermanentAddress_NearPoliceStation;
                    model.StudentRegistrationAcademicApprovalDTO.Student_PermanentAddress_Tahsil = response.Entity.Student_PermanentAddress_Tahsil;
                    model.StudentRegistrationAcademicApprovalDTO.Student_PermanentAddress_ZipCode = response.Entity.Student_PermanentAddress_ZipCode;
                    model.StudentRegistrationAcademicApprovalDTO.Student_PermanentAddress_City_Tahsil_Pattern = response.Entity.Student_PermanentAddress_City_Tahsil_Pattern;


                    model.StudentRegistrationAcademicApprovalDTO.Student_CorrespondenceAddress_Address1 = response.Entity.Student_CorrespondenceAddress_Address1;
                    model.StudentRegistrationAcademicApprovalDTO.Student_CorrespondenceAddress_Address2 = response.Entity.Student_CorrespondenceAddress_Address2;
                    model.StudentRegistrationAcademicApprovalDTO.Student_CorrespondenceAddress_PloteNo = response.Entity.Student_CorrespondenceAddress_PloteNo;
                    model.StudentRegistrationAcademicApprovalDTO.Student_CorrespondenceAddress_StreeNo = response.Entity.Student_CorrespondenceAddress_StreeNo;
                    model.StudentRegistrationAcademicApprovalDTO.Student_CorrespondenceAddress_City_TahsilID = response.Entity.Student_CorrespondenceAddress_City_TahsilID;
                    model.StudentRegistrationAcademicApprovalDTO.Student_CorrespondenceAddress_City_TahsilName = response.Entity.Student_CorrespondenceAddress_City_TahsilName;
                    model.StudentRegistrationAcademicApprovalDTO.Student_CorrespondenceAddress_City_TahsilOther = response.Entity.Student_CorrespondenceAddress_City_TahsilOther;
                    model.StudentRegistrationAcademicApprovalDTO.Student_CorrespondenceAddress_DistrictID = response.Entity.Student_CorrespondenceAddress_DistrictID;
                    model.StudentRegistrationAcademicApprovalDTO.Student_CorrespondenceAddress_DistrictOther = response.Entity.Student_CorrespondenceAddress_DistrictOther;
                    model.StudentRegistrationAcademicApprovalDTO.Student_CorrespondenceAddress_State = response.Entity.Student_CorrespondenceAddress_State;
                    model.StudentRegistrationAcademicApprovalDTO.Student_CorrespondenceAddress_StateOther = response.Entity.Student_CorrespondenceAddress_StateOther;
                    model.StudentRegistrationAcademicApprovalDTO.Student_CorrespondenceAddress_CountryId = response.Entity.Student_CorrespondenceAddress_CountryId;
                    model.StudentRegistrationAcademicApprovalDTO.Student_CorrespondenceAddress_NearPoliceStation = response.Entity.Student_CorrespondenceAddress_NearPoliceStation;
                    model.StudentRegistrationAcademicApprovalDTO.Student_CorrespondenceAddress_Tahsil = response.Entity.Student_CorrespondenceAddress_Tahsil;
                    model.StudentRegistrationAcademicApprovalDTO.Student_CorrespondenceAddress_ZipCode = response.Entity.Student_CorrespondenceAddress_ZipCode;
                    model.StudentRegistrationAcademicApprovalDTO.Student_CorrespondenceAddress_City_Tahsil_Pattern = response.Entity.Student_CorrespondenceAddress_City_Tahsil_Pattern;
                    model.StudentRegistrationAcademicApprovalDTO.Student_QualifyingExamId = response.Entity.Student_QualifyingExamId;
                    model.StudentRegistrationAcademicApprovalDTO.Student_QualifyingRollNo = response.Entity.Student_QualifyingRollNo;
                    model.StudentRegistrationAcademicApprovalDTO.Student_QualifyingExamTotalMarksPointsObtained = response.Entity.Student_QualifyingExamTotalMarksPointsObtained;
                    model.StudentRegistrationAcademicApprovalDTO.Student_QualifyingExamOutOffMark = response.Entity.Student_QualifyingExamOutOffMark;
                    model.StudentRegistrationAcademicApprovalDTO.Student_QualifyingExamRank = response.Entity.Student_QualifyingExamRank;

                    model.StudentRegistrationAcademicApprovalDTO.Student_Qualification_General_MediumOfInstitution = response.Entity.Student_Qualification_General_MediumOfInstitution;
                    model.StudentRegistrationAcademicApprovalDTO.Student_Qualification_General_MonthOfPassing = response.Entity.Student_Qualification_General_MonthOfPassing;
                    model.StudentRegistrationAcademicApprovalDTO.Student_Qualification_General_YearOfPassing = response.Entity.Student_Qualification_General_YearOfPassing;
                    if (response.Entity.Student_Qualification_General_SingleAttempt == "False")
                    {
                        model.StudentRegistrationAcademicApprovalDTO.Student_Qualification_General_SingleAttempt = "0";
                    }
                    else
                    {
                        model.StudentRegistrationAcademicApprovalDTO.Student_Qualification_General_SingleAttempt = "1";
                    }
                    model.StudentRegistrationAcademicApprovalDTO.Student_Qualification_General_ObtainedMark = response.Entity.Student_Qualification_General_ObtainedMark;
                    model.StudentRegistrationAcademicApprovalDTO.Student_Qualification_General_OutOfMark = response.Entity.Student_Qualification_General_OutOfMark;
                    model.StudentRegistrationAcademicApprovalDTO.Student_Qualification_General_Percent = response.Entity.Student_Qualification_General_Percent;
                    model.StudentRegistrationAcademicApprovalDTO.Student_Qualification_General_NameofInstitution = response.Entity.Student_Qualification_General_NameofInstitution;
                    model.StudentRegistrationAcademicApprovalDTO.Student_Qualification_General_Region_Division_Board = response.Entity.Student_Qualification_General_Region_Division_Board;

                    model.StudentRegistrationAcademicApprovalDTO.Student_Qualification_SSC_MediumOfInstitution = response.Entity.Student_Qualification_SSC_MediumOfInstitution;
                    model.StudentRegistrationAcademicApprovalDTO.Student_Qualification_SSC_MonthOfPassing = response.Entity.Student_Qualification_SSC_MonthOfPassing;
                    model.StudentRegistrationAcademicApprovalDTO.Student_Qualification_SSC_YearOfPassing = response.Entity.Student_Qualification_SSC_YearOfPassing;
                    if (response.Entity.Student_Qualification_SSC_SingleAttempt == "False")
                    {
                        model.StudentRegistrationAcademicApprovalDTO.Student_Qualification_SSC_SingleAttempt = "0";
                    }
                    else
                    {
                        model.StudentRegistrationAcademicApprovalDTO.Student_Qualification_SSC_SingleAttempt = "1";
                    }

                    model.StudentRegistrationAcademicApprovalDTO.Student_Qualification_SSC_ObtainedMark = response.Entity.Student_Qualification_SSC_ObtainedMark;
                    model.StudentRegistrationAcademicApprovalDTO.Student_Qualification_SSC_OutOfMark = response.Entity.Student_Qualification_SSC_OutOfMark;
                    model.StudentRegistrationAcademicApprovalDTO.Student_Qualification_SSC_Percent = response.Entity.Student_Qualification_SSC_Percent;
                    model.StudentRegistrationAcademicApprovalDTO.Student_Qualification_SSC_NameofInstitution = response.Entity.Student_Qualification_SSC_NameofInstitution;
                    model.StudentRegistrationAcademicApprovalDTO.Student_Qualification_SSC_Region_Division_Board = response.Entity.Student_Qualification_SSC_Region_Division_Board;

                    model.StudentRegistrationAcademicApprovalDTO.Student_Qualification_HSC_MediumOfInstitution = response.Entity.Student_Qualification_HSC_MediumOfInstitution;
                    model.StudentRegistrationAcademicApprovalDTO.Student_Qualification_HSC_MonthOfPassing = response.Entity.Student_Qualification_HSC_MonthOfPassing;
                    model.StudentRegistrationAcademicApprovalDTO.Student_Qualification_HSC_YearOfPassing = response.Entity.Student_Qualification_HSC_YearOfPassing;
                    if (response.Entity.Student_Qualification_HSC_SingleAttempt == "False")
                    {
                        model.StudentRegistrationAcademicApprovalDTO.Student_Qualification_HSC_SingleAttempt = "0";
                    }
                    else
                    {
                        model.StudentRegistrationAcademicApprovalDTO.Student_Qualification_HSC_SingleAttempt = "1";
                    }

                    model.StudentRegistrationAcademicApprovalDTO.Student_Qualification_HSC_ObtainedMark = response.Entity.Student_Qualification_HSC_ObtainedMark;
                    model.StudentRegistrationAcademicApprovalDTO.Student_Qualification_HSC_OutOfMark = response.Entity.Student_Qualification_HSC_OutOfMark;
                    model.StudentRegistrationAcademicApprovalDTO.Student_Qualification_HSC_Percent = response.Entity.Student_Qualification_HSC_Percent;
                    model.StudentRegistrationAcademicApprovalDTO.Student_Qualification_HSC_NameofInstitution = response.Entity.Student_Qualification_HSC_NameofInstitution;
                    model.StudentRegistrationAcademicApprovalDTO.Student_Qualification_HSC_Region_Division_Board = response.Entity.Student_Qualification_HSC_Region_Division_Board;
                    model.StudentRegistrationAcademicApprovalDTO.Student_Qualification_HSC_StreamID = response.Entity.Student_Qualification_HSC_StreamID;
                    model.StudentRegistrationAcademicApprovalDTO.Student_Qualification_HSC_StreamOther = response.Entity.Student_Qualification_HSC_StreamOther;
                    model.StudentRegistrationAcademicApprovalDTO.Student_Qualification_HSC_Class = response.Entity.Student_Qualification_HSC_Class;

                    model.StudentRegistrationAcademicApprovalDTO.Student_Qualification_HSC_PCM_PVM_ObtainedMark = response.Entity.Student_Qualification_HSC_PCM_PVM_ObtainedMark;
                    model.StudentRegistrationAcademicApprovalDTO.Student_Qualification_HSC_PCM_PVM_OutOfMark = response.Entity.Student_Qualification_HSC_PCM_PVM_OutOfMark;
                    model.StudentRegistrationAcademicApprovalDTO.Student_Qualification_HSC_PCB_ObtainedMark = response.Entity.Student_Qualification_HSC_PCB_ObtainedMark;
                    model.StudentRegistrationAcademicApprovalDTO.Student_Qualification_HSC_PCB_OutOfMark = response.Entity.Student_Qualification_HSC_PCB_OutOfMark;

                    model.StudentRegistrationAcademicApprovalDTO.Student_Qualification_Diploma_ITI_Details_MediumOfInstitution = response.Entity.Student_Qualification_Diploma_ITI_Details_MediumOfInstitution;
                    model.StudentRegistrationAcademicApprovalDTO.Student_Qualification_Diploma_ITI_Details_BranchName = response.Entity.Student_Qualification_Diploma_ITI_Details_BranchName;
                    model.StudentRegistrationAcademicApprovalDTO.Student_Qualification_Diploma_ITI_Details_ExamPattern = response.Entity.Student_Qualification_Diploma_ITI_Details_ExamPattern;
                    model.StudentRegistrationAcademicApprovalDTO.Student_Qualification_Diploma_ITI_Details_MonthOfPassing = response.Entity.Student_Qualification_Diploma_ITI_Details_MonthOfPassing;
                    model.StudentRegistrationAcademicApprovalDTO.Student_Qualification_Diploma_ITI_Details_YearOfPassing = response.Entity.Student_Qualification_Diploma_ITI_Details_YearOfPassing;
                    if (response.Entity.Student_Qualification_Diploma_ITI_Details_SingleAttempt == "False")
                    {
                        model.StudentRegistrationAcademicApprovalDTO.Student_Qualification_Diploma_ITI_Details_SingleAttempt = "0";
                    }
                    else
                    {
                        model.StudentRegistrationAcademicApprovalDTO.Student_Qualification_Diploma_ITI_Details_SingleAttempt = "1";
                    }

                    model.StudentRegistrationAcademicApprovalDTO.Student_Qualification_Diploma_ITI_Details_ObtainedMark = response.Entity.Student_Qualification_Diploma_ITI_Details_ObtainedMark;
                    model.StudentRegistrationAcademicApprovalDTO.Student_Qualification_Diploma_ITI_Details_OutOfMark = response.Entity.Student_Qualification_Diploma_ITI_Details_OutOfMark;
                    model.StudentRegistrationAcademicApprovalDTO.Student_Qualification_Diploma_ITI_Details_Percent = response.Entity.Student_Qualification_Diploma_ITI_Details_Percent;
                    model.StudentRegistrationAcademicApprovalDTO.Student_Qualification_Diploma_ITI_Details_NameofInstitution = response.Entity.Student_Qualification_Diploma_ITI_Details_NameofInstitution;
                    model.StudentRegistrationAcademicApprovalDTO.Student_Qualification_Diploma_ITI_Details_Board = response.Entity.Student_Qualification_Diploma_ITI_Details_Board;
                    model.StudentRegistrationAcademicApprovalDTO.Student_Qualification_Diploma_ITI_Details_State = response.Entity.Student_Qualification_Diploma_ITI_Details_State;
                    model.StudentRegistrationAcademicApprovalDTO.Student_Qualification_Diploma_ITI_Details_CountryId = response.Entity.Student_Qualification_Diploma_ITI_Details_CountryId;
                    model.StudentRegistrationAcademicApprovalDTO.Student_Qualification_Diploma_ITI_Details_StateOther = response.Entity.Student_Qualification_Diploma_ITI_Details_StateOther;
                    model.StudentRegistrationAcademicApprovalDTO.Student_Qualification_Diploma_ITI_Details_BoardEnrollmentNumber = response.Entity.Student_Qualification_Diploma_ITI_Details_BoardEnrollmentNumber;
                    model.StudentRegistrationAcademicApprovalDTO.Student_Qualification_Diploma_ITI_Details_Class = response.Entity.Student_Qualification_Diploma_ITI_Details_Class;

                    model.StudentRegistrationAcademicApprovalDTO.Student_Qualification_DegreeDetails_MediumOfInstitution = response.Entity.Student_Qualification_DegreeDetails_MediumOfInstitution;
                    model.StudentRegistrationAcademicApprovalDTO.Student_Qualification_DegreeDetails_BranchName = response.Entity.Student_Qualification_DegreeDetails_BranchName;
                    model.StudentRegistrationAcademicApprovalDTO.Student_Qualification_DegreeDetails_ExamPattern = response.Entity.Student_Qualification_DegreeDetails_ExamPattern;
                    model.StudentRegistrationAcademicApprovalDTO.Student_Qualification_DegreeDetails_MonthOfPassing = response.Entity.Student_Qualification_DegreeDetails_MonthOfPassing;
                    model.StudentRegistrationAcademicApprovalDTO.Student_Qualification_DegreeDetails_YearOfPassing = response.Entity.Student_Qualification_DegreeDetails_YearOfPassing;
                    if (response.Entity.Student_Qualification_DegreeDetails_SingleAttempt == "False")
                    {
                        model.StudentRegistrationAcademicApprovalDTO.Student_Qualification_DegreeDetails_SingleAttempt = "0";
                    }
                    else
                    {
                        model.StudentRegistrationAcademicApprovalDTO.Student_Qualification_DegreeDetails_SingleAttempt = "1";
                    }
                    model.StudentRegistrationAcademicApprovalDTO.Student_Qualification_DegreeDetails_ObtainedMark = response.Entity.Student_Qualification_DegreeDetails_ObtainedMark;
                    model.StudentRegistrationAcademicApprovalDTO.Student_Qualification_DegreeDetails_OutOfMark = response.Entity.Student_Qualification_DegreeDetails_OutOfMark;
                    model.StudentRegistrationAcademicApprovalDTO.Student_Qualification_DegreeDetails_Percent = response.Entity.Student_Qualification_DegreeDetails_Percent;
                    model.StudentRegistrationAcademicApprovalDTO.Student_Qualification_DegreeDetails_NameofInstitution = response.Entity.Student_Qualification_DegreeDetails_NameofInstitution;
                    model.StudentRegistrationAcademicApprovalDTO.Student_Qualification_DegreeDetails_UniversityName = response.Entity.Student_Qualification_DegreeDetails_UniversityName;
                    model.StudentRegistrationAcademicApprovalDTO.Student_Qualification_DegreeDetails_State = response.Entity.Student_Qualification_DegreeDetails_State;
                    model.StudentRegistrationAcademicApprovalDTO.Student_Qualification_DegreeDetails_CountryId = response.Entity.Student_Qualification_DegreeDetails_CountryId;
                    model.StudentRegistrationAcademicApprovalDTO.Student_Qualification_DegreeDetails_StateOther = response.Entity.Student_Qualification_DegreeDetails_StateOther;
                    model.StudentRegistrationAcademicApprovalDTO.Student_Qualification_DegreeDetails_Degree = response.Entity.Student_Qualification_DegreeDetails_Degree;
                    model.StudentRegistrationAcademicApprovalDTO.Student_Qualification_DegreeDetails_BoardEnrollmentNumber = response.Entity.Student_Qualification_DegreeDetails_BoardEnrollmentNumber;
                    model.StudentRegistrationAcademicApprovalDTO.Student_Qualification_DegreeDetails_Class = response.Entity.Student_Qualification_DegreeDetails_Class;

                    model.StudentRegistrationAcademicApprovalDTO.Student_Qualification_PostGraduationDetails_MediumOfInstitution = response.Entity.Student_Qualification_PostGraduationDetails_MediumOfInstitution;
                    model.StudentRegistrationAcademicApprovalDTO.Student_Qualification_PostGraduationDetails_BranchName = response.Entity.Student_Qualification_PostGraduationDetails_BranchName;
                    model.StudentRegistrationAcademicApprovalDTO.Student_Qualification_PostGraduationDetails_ExamPattern = response.Entity.Student_Qualification_PostGraduationDetails_ExamPattern;
                    model.StudentRegistrationAcademicApprovalDTO.Student_Qualification_PostGraduationDetails_MonthOfPassing = response.Entity.Student_Qualification_PostGraduationDetails_MonthOfPassing;
                    model.StudentRegistrationAcademicApprovalDTO.Student_Qualification_PostGraduationDetails_YearOfPassing = response.Entity.Student_Qualification_PostGraduationDetails_YearOfPassing;
                    if (response.Entity.Student_Qualification_PostGraduationDetails_SingleAttempt == "False")
                    {
                        model.StudentRegistrationAcademicApprovalDTO.Student_Qualification_PostGraduationDetails_SingleAttempt = "0";
                    }
                    else
                    {
                        model.StudentRegistrationAcademicApprovalDTO.Student_Qualification_PostGraduationDetails_SingleAttempt = "1";
                    }
                    model.StudentRegistrationAcademicApprovalDTO.Student_Qualification_PostGraduationDetails_ObtainedMark = response.Entity.Student_Qualification_PostGraduationDetails_ObtainedMark;
                    model.StudentRegistrationAcademicApprovalDTO.Student_Qualification_PostGraduationDetails_OutOfMark = response.Entity.Student_Qualification_PostGraduationDetails_OutOfMark;
                    model.StudentRegistrationAcademicApprovalDTO.Student_Qualification_PostGraduationDetails_Percent = response.Entity.Student_Qualification_PostGraduationDetails_Percent;
                    model.StudentRegistrationAcademicApprovalDTO.Student_Qualification_PostGraduationDetails_NameofInstitution = response.Entity.Student_Qualification_PostGraduationDetails_NameofInstitution;
                    model.StudentRegistrationAcademicApprovalDTO.Student_Qualification_PostGraduationDetails_UniversityName = response.Entity.Student_Qualification_PostGraduationDetails_UniversityName;
                    model.StudentRegistrationAcademicApprovalDTO.Student_Qualification_PostGraduationDetails_State = response.Entity.Student_Qualification_PostGraduationDetails_State;
                    model.StudentRegistrationAcademicApprovalDTO.Student_Qualification_PostGraduationDetails_CountryId = response.Entity.Student_Qualification_PostGraduationDetails_CountryId;
                    model.StudentRegistrationAcademicApprovalDTO.Student_Qualification_PostGraduationDetails_StateOther = response.Entity.Student_Qualification_PostGraduationDetails_StateOther;
                    model.StudentRegistrationAcademicApprovalDTO.Student_Qualification_PostGraduationDetails_PostGraduation = response.Entity.Student_Qualification_PostGraduationDetails_PostGraduation;
                    model.StudentRegistrationAcademicApprovalDTO.Student_Qualification_PostGraduationDetails_BoardEnrollmentNumber = response.Entity.Student_Qualification_PostGraduationDetails_BoardEnrollmentNumber;
                    model.StudentRegistrationAcademicApprovalDTO.Student_Qualification_PostGraduationDetails_Class = response.Entity.Student_Qualification_PostGraduationDetails_Class;
                    model.StudentRegistrationAcademicApprovalDTO.Student_DTE_DTEUserID = response.Entity.Student_DTE_DTEUserID;
                    model.StudentRegistrationAcademicApprovalDTO.Student_DTE_DTEPassword = response.Entity.Student_DTE_DTEPassword;
                    model.StudentRegistrationAcademicApprovalDTO.Student_DTE_DTESrNo = response.Entity.Student_DTE_DTESrNo;
                    model.StudentRegistrationAcademicApprovalDTO.Student_DTE_DTEMeritNo = response.Entity.Student_DTE_DTEMeritNo;
                    model.StudentRegistrationAcademicApprovalDTO.Student_DTE_AdmissionTypeId = response.Entity.Student_DTE_AdmissionTypeId;
                    model.StudentRegistrationAcademicApprovalDTO.Student_DTE_AdmissionRound = response.Entity.Student_DTE_AdmissionRound;
                    model.StudentRegistrationAcademicApprovalDTO.Student_DTE_AdmissionCategoryId = response.Entity.Student_DTE_AdmissionCategoryId;
                    model.StudentRegistrationAcademicApprovalDTO.Student_DTE_DTESeatNo = response.Entity.Student_DTE_DTESeatNo;
                    model.StudentRegistrationAcademicApprovalDTO.Student_DTE_QualifyingExamName = response.Entity.Student_DTE_QualifyingExamName;
                    model.StudentRegistrationAcademicApprovalDTO.Student_DTE_QualifyingExamMarks = response.Entity.Student_DTE_QualifyingExamMarks;
                    model.StudentRegistrationAcademicApprovalDTO.Student_QualifyingExamName = response.Entity.Student_DTE_QualifyingExamName;


                    //For Document
                    model.StudentRegistrationAcademicApprovalDTO.Student_AdmissionDocuments_JETMarkSheet = response.Entity.Student_AdmissionDocuments_JETMarkSheet;
                    model.StudentRegistrationAcademicApprovalDTO.Student_AdmissionDocuments_AllotmentLetter = response.Entity.Student_AdmissionDocuments_AllotmentLetter;
                    model.StudentRegistrationAcademicApprovalDTO.Student_AdmissionDocuments_TenthMarkSheet = response.Entity.Student_AdmissionDocuments_TenthMarkSheet;
                    model.StudentRegistrationAcademicApprovalDTO.Student_AdmissionDocuments_TwelvethMarkSheet = response.Entity.Student_AdmissionDocuments_TwelvethMarkSheet;
                    model.StudentRegistrationAcademicApprovalDTO.Student_AdmissionDocuments_AllDiplomaMarksheet = response.Entity.Student_AdmissionDocuments_AllDiplomaMarksheet;
                    model.StudentRegistrationAcademicApprovalDTO.Student_AdmissionDocuments_LeavingCertificate = response.Entity.Student_AdmissionDocuments_LeavingCertificate;
                    model.StudentRegistrationAcademicApprovalDTO.Student_AdmissionDocuments_Domicile_BirthCertificate = response.Entity.Student_AdmissionDocuments_Domicile_BirthCertificate;
                    model.StudentRegistrationAcademicApprovalDTO.Student_AdmissionDocuments_NationalityCertificate = response.Entity.Student_AdmissionDocuments_NationalityCertificate;
                    model.StudentRegistrationAcademicApprovalDTO.Student_AdmissionDocuments_CasteCertificate = response.Entity.Student_AdmissionDocuments_CasteCertificate;
                    model.StudentRegistrationAcademicApprovalDTO.Student_AdmissionDocuments_CasteValidityCertificate = response.Entity.Student_AdmissionDocuments_CasteValidityCertificate;
                    model.StudentRegistrationAcademicApprovalDTO.Student_AdmissionDocuments_NonCreamylayerCertificate = response.Entity.Student_AdmissionDocuments_NonCreamylayerCertificate;
                    model.StudentRegistrationAcademicApprovalDTO.Student_AdmissionDocuments_EquivalenceCertificate = response.Entity.Student_AdmissionDocuments_EquivalenceCertificate;
                    model.StudentRegistrationAcademicApprovalDTO.Student_AdmissionDocuments_MigrationCertificate = response.Entity.Student_AdmissionDocuments_MigrationCertificate;
                    model.StudentRegistrationAcademicApprovalDTO.Student_AdmissionDocuments_GapCertificate = response.Entity.Student_AdmissionDocuments_GapCertificate;
                    model.StudentRegistrationAcademicApprovalDTO.Student_AdmissionDocuments_AntiRaggingAffidavit = response.Entity.Student_AdmissionDocuments_AntiRaggingAffidavit;
                    model.StudentRegistrationAcademicApprovalDTO.Student_AdmissionDocuments_Proforma_Fand_F1_On_DoctorsLetter_Head = response.Entity.Student_AdmissionDocuments_Proforma_Fand_F1_On_DoctorsLetter_Head;
                    model.StudentRegistrationAcademicApprovalDTO.Student_AdmissionDocuments_Proforma_I = response.Entity.Student_AdmissionDocuments_Proforma_I;
                    model.StudentRegistrationAcademicApprovalDTO.Student_AdmissionDocuments_ProformaG1 = response.Entity.Student_AdmissionDocuments_ProformaG1;
                    model.StudentRegistrationAcademicApprovalDTO.Student_AdmissionDocuments_ProformaG2 = response.Entity.Student_AdmissionDocuments_ProformaG2;
                    model.StudentRegistrationAcademicApprovalDTO.Student_AdmissionDocuments_Proforma_C_D_E = response.Entity.Student_AdmissionDocuments_Proforma_C_D_E;
                    model.StudentRegistrationAcademicApprovalDTO.Student_AdmissionDocuments_FathersIncomeCertificate = response.Entity.Student_AdmissionDocuments_FathersIncomeCertificate;
                    model.StudentRegistrationAcademicApprovalDTO.Student_AdmissionDocuments_AadharCardXerox = response.Entity.Student_AdmissionDocuments_AadharCardXerox;
                    model.StudentRegistrationAcademicApprovalDTO.Student_AdmissionDocuments_B_WPhoto_I_card_size = response.Entity.Student_AdmissionDocuments_B_WPhoto_I_card_size;
                    model.StudentRegistrationAcademicApprovalDTO.Student_AdmissionDocuments_Colour_photo = response.Entity.Student_AdmissionDocuments_Colour_photo;
                    model.StudentRegistrationAcademicApprovalDTO.Student_BranchDetailIDOFBranchID = response.Entity.Student_BranchDetailIDOFBranchID;

                    //For PG Students
                    model.StudentRegistrationAcademicApprovalDTO.Student_AdmissionDocuments_PGStudents_DegreeMarksheet = response.Entity.Student_AdmissionDocuments_PGStudents_DegreeMarksheet;
                    model.StudentRegistrationAcademicApprovalDTO.Student_AdmissionDocuments_PGStudents_DegreeCertificate = response.Entity.Student_AdmissionDocuments_PGStudents_DegreeCertificate;
                    model.StudentRegistrationAcademicApprovalDTO.Student_AdmissionDocuments_PGStudents_GateScoreCard = response.Entity.Student_AdmissionDocuments_PGStudents_GateScoreCard;
                    model.StudentRegistrationAcademicApprovalDTO.Student_AdmissionDocuments_PGStudents_SponsorshipLetterforSponsoredCandidate = response.Entity.Student_AdmissionDocuments_PGStudents_SponsorshipLetterforSponsoredCandidate;

                    model.StudentRegistrationAcademicApprovalDTO.Student_StudentCode = "STU" + response.Entity.Student_CourseYearName + model.StudentRegistrationAcademicApprovalDTO.RegistrationID;


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
                ViewData["StudentNRI_POI"] = new SelectList(li_StudentRegistrationForm_NRI_POI, "Value", "Text", model.StudentRegistrationAcademicApprovalDTO.StudentNRI_POI);

                //For Fees payment details
                ViewData["FeesPaidBy"] = new SelectList(li_FeesPaidBy, "Value", "Text", response.Entity.FeesPaidBy);

                //For Academic Request Status
                List<SelectListItem> StudentRegistrationForm_AcademicRequestStatus = new List<SelectListItem>();
                ViewBag.StudentRegistrationForm_AcademicRequestStatus = new SelectList(StudentRegistrationForm_AcademicRequestStatus, "Value", "Text");
                List<SelectListItem> li_StudentRegistrationForm_AcademicRequestStatus = new List<SelectListItem>();
                li_StudentRegistrationForm_AcademicRequestStatus.Add(new SelectListItem { Text = "Accept", Value = "1" });
                li_StudentRegistrationForm_AcademicRequestStatus.Add(new SelectListItem { Text = "Reject", Value = "0" });
                ViewData["ApprovalStatus"] = li_StudentRegistrationForm_AcademicRequestStatus;

                //For Admitted Section details
                model.ListOrganisationSectionDetails = GetSectionDetailsRoleWise(Convert.ToInt32(model.StudentRegistrationAcademicApprovalDTO.Student_BranchDetailIDOFBranchID), model.StudentRegistrationAcademicApprovalDTO.CenterCode, Convert.ToString(model.StudentRegistrationAcademicApprovalDTO.UniversityID), "false");

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
                ViewData["StudentMaritalStatus"] = new SelectList(li_StudentRegistrationForm_StudentMaritalStatus, "Value", "Text", model.StudentRegistrationAcademicApprovalDTO.StudentMaritalStatus);

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
                ViewData["StudentBloodGroup"] = new SelectList(li_StudentRegistrationForm_StudentBloodGroup, "Value", "Text", model.StudentRegistrationAcademicApprovalDTO.StudentBloodGroup);

                //For PhysicallyHandicapped

                ViewData["PhysicallyHandicapped"] = new SelectList(li_StudentRegistrationForm_StudentPhysicallyHandicapped, "Value", "Text", model.StudentRegistrationAcademicApprovalDTO.PhysicallyHandicapped);

                ViewData["StudentEmploymentStatus"] = new SelectList(li_StudentRegistrationForm_StudentPhysicallyHandicapped, "Value", "Text", model.StudentRegistrationAcademicApprovalDTO.StudentEmploymentStatus);

                ViewData["Student_Qualification_General_SingleAttempt"] = new SelectList(li_StudentRegistrationForm_StudentPhysicallyHandicapped, "Value", "Text", model.StudentRegistrationAcademicApprovalDTO.Student_Qualification_General_SingleAttempt);
                ViewData["Student_Qualification_SSC_SingleAttempt"] = new SelectList(li_StudentRegistrationForm_StudentPhysicallyHandicapped, "Value", "Text", model.StudentRegistrationAcademicApprovalDTO.Student_Qualification_SSC_SingleAttempt);
                ViewData["Student_Qualification_HSC_SingleAttempt"] = new SelectList(li_StudentRegistrationForm_StudentPhysicallyHandicapped, "Value", "Text", model.StudentRegistrationAcademicApprovalDTO.Student_Qualification_HSC_SingleAttempt);
                ViewData["Student_Qualification_Diploma_ITI_Details_SingleAttempt"] = new SelectList(li_StudentRegistrationForm_StudentPhysicallyHandicapped, "Value", "Text", model.StudentRegistrationAcademicApprovalDTO.Student_Qualification_Diploma_ITI_Details_SingleAttempt);
                ViewData["Student_Qualification_DegreeDetails_SingleAttempt"] = new SelectList(li_StudentRegistrationForm_StudentPhysicallyHandicapped, "Value", "Text", model.StudentRegistrationAcademicApprovalDTO.Student_Qualification_DegreeDetails_SingleAttempt);
                ViewData["Student_Qualification_PostGraduationDetails_SingleAttempt"] = new SelectList(li_StudentRegistrationForm_StudentPhysicallyHandicapped, "Value", "Text", model.StudentRegistrationAcademicApprovalDTO.Student_Qualification_PostGraduationDetails_SingleAttempt);
                //For Organ donor
                List<SelectListItem> StudentRegistrationForm_StudentOrgandonor = new List<SelectListItem>();
                ViewBag.StudentRegistrationForm_StudentOrgandonor = new SelectList(StudentRegistrationForm_StudentOrgandonor, "Value", "Text");
                List<SelectListItem> li_StudentRegistrationForm_StudentOrgandonor = new List<SelectListItem>();
                li_StudentRegistrationForm_StudentOrgandonor.Add(new SelectListItem { Text = "NO", Value = "0" });
                li_StudentRegistrationForm_StudentOrgandonor.Add(new SelectListItem { Text = "YES", Value = "1" });
                ViewData["StudentOrgandonor"] = new SelectList(li_StudentRegistrationForm_StudentOrgandonor, "Value", "Text", model.StudentRegistrationAcademicApprovalDTO.StudentOrgandonor);





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

                List<GeneralRegionMaster> generalRegionMasterListforPermanentAddress = GetListGeneralRegionMaster(Convert.ToString(model.StudentRegistrationAcademicApprovalDTO.Student_PermanentAddress_CountryId));
                List<SelectListItem> generalRegionMasterforPermanentAddress = new List<SelectListItem>();
                generalRegionMasterforPermanentAddress.Add(new SelectListItem { Text = "Other", Value = "Other" });
                foreach (GeneralRegionMaster item in generalRegionMasterListforPermanentAddress)
                {
                    generalRegionMasterforPermanentAddress.Add(new SelectListItem { Text = item.RegionName + " ( " + item.CountryName + " )", Value = item.ID.ToString() });
                }
                ViewBag.GeneralRegionMasterforPermanentAddress = new SelectList(generalRegionMasterforPermanentAddress, "Value", "Text");

                //Student_PermanentAddress_DistrictID
                // string SelectedRegionID = "A";

                List<GeneralCityMaster> GeneralCityMasterListforPermanentAddress = GetListGeneralCityMaster(Convert.ToString(model.StudentRegistrationAcademicApprovalDTO.Student_PermanentAddress_State));
                List<SelectListItem> GeneralCityMasterforPermanentAddress = new List<SelectListItem>();
                GeneralCityMasterforPermanentAddress.Add(new SelectListItem { Text = "Other", Value = "Other" });
                foreach (GeneralCityMaster item in GeneralCityMasterListforPermanentAddress)
                {
                    GeneralCityMasterforPermanentAddress.Add(new SelectListItem { Text = item.Description, Value = item.ID.ToString() });
                }

                ViewBag.GeneralCityListforPermanentAddress = new SelectList(GeneralCityMasterforPermanentAddress, "Value", "Text");

                //Student_PermanentAddress_CityID
                List<GeneralLocationMaster> GeneralLocationMasterListforPermanentAddress = GetListGeneralLocationMasterByCityID(Convert.ToString(model.StudentRegistrationAcademicApprovalDTO.Student_PermanentAddress_DistrictID));
                List<SelectListItem> GeneralLocationMasterforPermanentAddress = new List<SelectListItem>();
                GeneralLocationMasterforPermanentAddress.Add(new SelectListItem { Text = "Other", Value = "Other" });
                foreach (GeneralLocationMaster item in GeneralLocationMasterListforPermanentAddress)
                {
                    GeneralLocationMasterforPermanentAddress.Add(new SelectListItem { Text = item.LocationAddress, Value = item.ID.ToString() });
                }

                ViewBag.GeneralLocationListforPermanentAddress = new SelectList(GeneralLocationMasterforPermanentAddress, "Value", "Text");

                //For Student_CorrespondenceAddress_State

                List<GeneralRegionMaster> generalRegionMasterListforCorrespondenceAddress = GetListGeneralRegionMaster(Convert.ToString(model.StudentRegistrationAcademicApprovalDTO.Student_CorrespondenceAddress_CountryId));
                List<SelectListItem> generalRegionMasterforCorrespondenceAddress = new List<SelectListItem>();
                generalRegionMasterforCorrespondenceAddress.Add(new SelectListItem { Text = "Other", Value = "Other" });
                foreach (GeneralRegionMaster item in generalRegionMasterListforCorrespondenceAddress)
                {
                    generalRegionMasterforCorrespondenceAddress.Add(new SelectListItem { Text = item.RegionName + " ( " + item.CountryName + " )", Value = item.ID.ToString() });
                }
                ViewBag.GeneralRegionMasterforCorrespondenceAddress = new SelectList(generalRegionMasterforCorrespondenceAddress, "Value", "Text");

                //Student_CorrespondenceAddress_DistrictID
                // string SelectedRegionID = "A";

                List<GeneralCityMaster> GeneralCityMasterListforCorrespondenceAddress = GetListGeneralCityMaster(Convert.ToString(model.StudentRegistrationAcademicApprovalDTO.Student_CorrespondenceAddress_State));
                List<SelectListItem> GeneralCityMasterforCorrespondenceAddress = new List<SelectListItem>();
                GeneralCityMasterforCorrespondenceAddress.Add(new SelectListItem { Text = "Other", Value = "Other" });
                foreach (GeneralCityMaster item in GeneralCityMasterListforCorrespondenceAddress)
                {
                    GeneralCityMasterforCorrespondenceAddress.Add(new SelectListItem { Text = item.Description, Value = item.ID.ToString() });
                }

                ViewBag.GeneralCityListforCorrespondenceAddress = new SelectList(GeneralCityMasterforCorrespondenceAddress, "Value", "Text");

                //Student_CorrespondenceAddress_CityID
                List<GeneralLocationMaster> GeneralLocationMasterListforCorrespondenceAddress = GetListGeneralLocationMasterByCityID(Convert.ToString(model.StudentRegistrationAcademicApprovalDTO.Student_CorrespondenceAddress_DistrictID));
                List<SelectListItem> GeneralLocationMasterforCorrespondenceAddress = new List<SelectListItem>();
                GeneralLocationMasterforCorrespondenceAddress.Add(new SelectListItem { Text = "Other", Value = "Other" });
                foreach (GeneralLocationMaster item in GeneralLocationMasterListforCorrespondenceAddress)
                {
                    GeneralLocationMasterforCorrespondenceAddress.Add(new SelectListItem { Text = item.LocationAddress, Value = item.ID.ToString() });
                }

                ViewBag.GeneralLocationListforCorrespondenceAddress = new SelectList(GeneralLocationMasterforPermanentAddress, "Value", "Text");
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

                List<GeneralCasteMaster> GeneralCasteMasterList = GetListGeneralCasteMaster(model.StudentRegistrationAcademicApprovalDTO.StudentCategoryID);
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
                ViewData["StudentEconomicallyBackwardClass"] = new SelectList(li_StudentRegistrationForm_StudentEconomicallyBackwardClass, "Value", "Text", model.StudentRegistrationAcademicApprovalDTO.StudentEconomicallyBackwardClass);

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
                ViewData["Student_PermanentAddress_City_Tahsil_Pattern"] = new SelectList(li_StudentRegistrationForm_PermanentAddress_City_Tahsil_Pattern, "Value", "Text", model.StudentRegistrationAcademicApprovalDTO.Student_PermanentAddress_City_Tahsil_Pattern);

                ViewData["Student_CorrespondenceAddress_City_Tahsil_Pattern"] = new SelectList(li_StudentRegistrationForm_PermanentAddress_City_Tahsil_Pattern, "Value", "Text", model.StudentRegistrationAcademicApprovalDTO.Student_CorrespondenceAddress_City_Tahsil_Pattern);
                //For Exam_Pattern
                List<SelectListItem> StudentRegistrationForm_Exam_Pattern = new List<SelectListItem>();
                ViewBag.StudentRegistrationForm_Exam_Pattern = new SelectList(StudentRegistrationForm_Exam_Pattern, "Value", "Text");
                List<SelectListItem> li_StudentRegistrationForm_Exam_Pattern = new List<SelectListItem>();
                li_StudentRegistrationForm_Exam_Pattern.Add(new SelectListItem { Text = "Yearly", Value = "Y" });
                li_StudentRegistrationForm_Exam_Pattern.Add(new SelectListItem { Text = "Semester", Value = "S" });
                ViewData["Student_Qualification_Diploma_ITI_Details_ExamPattern"] = new SelectList(li_StudentRegistrationForm_Exam_Pattern, "Value", "Text", model.StudentRegistrationAcademicApprovalDTO.Student_Qualification_Diploma_ITI_Details_ExamPattern);
                ViewData["Student_Qualification_DegreeDetails_ExamPattern"] = new SelectList(li_StudentRegistrationForm_Exam_Pattern, "Value", "Text", model.StudentRegistrationAcademicApprovalDTO.Student_Qualification_DegreeDetails_ExamPattern);
                ViewData["Student_Qualification_PostGraduationDetails_ExamPattern"] = new SelectList(li_StudentRegistrationForm_Exam_Pattern, "Value", "Text", model.StudentRegistrationAcademicApprovalDTO.Student_Qualification_PostGraduationDetails_ExamPattern);
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
                ViewData["Student_Qualification_General_MonthOfPassing"] = new SelectList(li_Student_Qualification_General_MonthOfPassing, "Value", "Text", model.StudentRegistrationAcademicApprovalDTO.Student_Qualification_General_MonthOfPassing);
                ViewData["Student_Qualification_SSC_MonthOfPassing"] = new SelectList(li_Student_Qualification_General_MonthOfPassing, "Value", "Text", model.StudentRegistrationAcademicApprovalDTO.Student_Qualification_SSC_MonthOfPassing);
                ViewData["Student_Qualification_HSC_MonthOfPassing"] = new SelectList(li_Student_Qualification_General_MonthOfPassing, "Value", "Text", model.StudentRegistrationAcademicApprovalDTO.Student_Qualification_HSC_MonthOfPassing);
                ViewData["Student_Qualification_Diploma_ITI_Details_MonthOfPassing"] = new SelectList(li_Student_Qualification_General_MonthOfPassing, "Value", "Text", model.StudentRegistrationAcademicApprovalDTO.Student_Qualification_Diploma_ITI_Details_MonthOfPassing);
                ViewData["Student_Qualification_DegreeDetails_MonthOfPassing"] = new SelectList(li_Student_Qualification_General_MonthOfPassing, "Value", "Text", model.StudentRegistrationAcademicApprovalDTO.Student_Qualification_DegreeDetails_MonthOfPassing);
                ViewData["Student_Qualification_PostGraduationDetails_MonthOfPassing"] = new SelectList(li_Student_Qualification_General_MonthOfPassing, "Value", "Text", model.StudentRegistrationAcademicApprovalDTO.Student_Qualification_PostGraduationDetails_MonthOfPassing);

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
                ViewData["Student_Qualification_General_YearOfPassing"] = new SelectList(li_Student_Qualification_General_YearOfPassing, "Value", "Text", model.StudentRegistrationAcademicApprovalDTO.Student_Qualification_General_YearOfPassing);
                ViewData["Student_Qualification_SSC_YearOfPassing"] = new SelectList(li_Student_Qualification_General_YearOfPassing, "Value", "Text", model.StudentRegistrationAcademicApprovalDTO.Student_Qualification_SSC_YearOfPassing);
                ViewData["Student_Qualification_HSC_YearOfPassing"] = new SelectList(li_Student_Qualification_General_YearOfPassing, "Value", "Text", model.StudentRegistrationAcademicApprovalDTO.Student_Qualification_HSC_YearOfPassing);
                ViewData["Student_Qualification_Diploma_ITI_Details_YearOfPassing"] = new SelectList(li_Student_Qualification_General_YearOfPassing, "Value", "Text", model.StudentRegistrationAcademicApprovalDTO.Student_Qualification_Diploma_ITI_Details_YearOfPassing);
                ViewData["Student_Qualification_DegreeDetails_YearOfPassing"] = new SelectList(li_Student_Qualification_General_YearOfPassing, "Value", "Text", model.StudentRegistrationAcademicApprovalDTO.Student_Qualification_DegreeDetails_YearOfPassing);
                ViewData["Student_Qualification_PostGraduationDetails_YearOfPassing"] = new SelectList(li_Student_Qualification_General_YearOfPassing, "Value", "Text", model.StudentRegistrationAcademicApprovalDTO.Student_Qualification_PostGraduationDetails_YearOfPassing);


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
                ViewData["Student_Qualification_HSC_Class"] = new SelectList(li_StudentRegistrationForm_Class, "Value", "Text", model.StudentRegistrationAcademicApprovalDTO.Student_Qualification_HSC_Class);
                ViewData["Student_Qualification_Diploma_ITI_Details_Class"] = new SelectList(li_StudentRegistrationForm_Class, "Value", "Text", model.StudentRegistrationAcademicApprovalDTO.Student_Qualification_Diploma_ITI_Details_Class);
                ViewData["Student_Qualification_DegreeDetails_Class"] = new SelectList(li_StudentRegistrationForm_Class, "Value", "Text", model.StudentRegistrationAcademicApprovalDTO.Student_Qualification_DegreeDetails_Class);
                ViewData["Student_Qualification_PostGraduationDetails_Class"] = new SelectList(li_StudentRegistrationForm_Class, "Value", "Text", model.StudentRegistrationAcademicApprovalDTO.Student_Qualification_PostGraduationDetails_Class);
                #endregion Method
                model.StudentRegistrationFormList = GetListStudentRegistrationForm(model.StudentRegistrationAcademicApprovalDTO.CenterCode, model.StudentRegistrationAcademicApprovalDTO.UniversityID, model.StudentRegistrationAcademicApprovalDTO.BranchDetailID, model.StudentRegistrationAcademicApprovalDTO.StandardNumber);


                List<ToolTemplateApplicable> organisationBranchDetailList = GetListBranchDetails(model.StudentRegistrationAcademicApprovalDTO.UniversityID, model.StudentRegistrationAcademicApprovalDTO.CenterCode);
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
                model.QualifyingExamSubjectList = GetListQualifyingExamSubject(model.StudentRegistrationAcademicApprovalDTO.RegistrationID);

                // For Qualification Exam Subject   for General
                model.QualificationMasterSubjectListForGeneral = GetByQualificationSubjectListByStudentRegistrationIDAndEducationType(model.StudentRegistrationAcademicApprovalDTO.RegistrationID, "G");

                // For Qualification Exam Subject   for SSC
                model.QualificationMasterSubjectListForSSC = GetByQualificationSubjectListByStudentRegistrationIDAndEducationType(model.StudentRegistrationAcademicApprovalDTO.RegistrationID, "S");

                // For Qualification Exam Subject   for HSC
                model.QualificationMasterSubjectListForHSC = GetByQualificationSubjectListByStudentRegistrationIDAndEducationType(model.StudentRegistrationAcademicApprovalDTO.RegistrationID, "H");
                // for Academic year
                List<OrganisationCentrewiseSession> list = GetCurrentSession(model.StudentRegistrationAcademicApprovalDTO.CenterCode);
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
                model.PreviousWorkExperienceList = GetPreviousWorkExperience(model.StudentRegistrationAcademicApprovalDTO.RegistrationID);

                ////For Branch Details
                model.OrganisationBranchDetailsDTO = GetOrganisationBranchDetailsSelectByID(model.BranchDetailID);
                model.Student_CourseName = model.OrganisationBranchDetailsDTO.BranchDescription;

                ////For Task Approval               
                model.TaskCode = TaskCode;
                model.TaskNotificationDetailsID = Convert.ToInt32(TNDID);
                model.TaskNotificationMasterID = Convert.ToInt32(TNMID);
                model.GeneralTaskReportingDetailsID = Convert.ToInt32(GTRDID1);
                model.PersonID = Convert.ToInt32(PersonID);
                model.StageSequenceNumber = Convert.ToInt32(StageSequenceNumber);
                model.IsLastRecord = Convert.ToBoolean(IsLast);


                GeneralTaskReportingDetails GeneralTaskReportingDetailsDTO = new GeneralTaskReportingDetails();
                GeneralTaskReportingDetailsDTO.TaskNotificationMasterID = model.TaskNotificationMasterID;
                GeneralTaskReportingDetailsDTO.ModifiedBy = Convert.ToInt32(Session["UserID"]);
                GeneralTaskReportingDetailsDTO.ConnectionString = _connectioString;
                IBaseEntityResponse<GeneralTaskReportingDetails> response1 = _generalTaskReportingDetailsServiceAccess.UpdateEnagedByUserID(GeneralTaskReportingDetailsDTO);
                model.StudentRegistrationAcademicApprovalDTO.errorMessage = CheckError((response1.Entity != null) ? response1.Entity.ErrorCode : 20, ActionModeEnum.Update);
                return View("/Views/StudentRegistration/StudentRegistrationAcademicApproval/EditV2.cshtml", model);
            }
            catch (Exception)
            {
                throw;
            }
        }


        [HttpPost]
        public ActionResult Edit(StudentRegistrationAcademicApprovalViewModel model)
        {
            if (model != null && model.StudentRegistrationAcademicApprovalDTO != null)
            {
                model.StudentRegistrationAcademicApprovalDTO.ConnectionString = _connectioString;

                model.StudentRegistrationAcademicApprovalDTO.RegistrationID = model.RegistrationID;

                model.StudentRegistrationAcademicApprovalDTO.Student_Domesile_CountryId = model.Student_Domesile_CountryId;
                model.StudentRegistrationAcademicApprovalDTO.StudentRegionOther = model.StudentRegionOther;

                model.StudentRegistrationAcademicApprovalDTO.Student_PermanentAddress_CountryId = model.Student_PermanentAddress_CountryId;
                model.StudentRegistrationAcademicApprovalDTO.Student_PermanentAddress_State = model.Student_PermanentAddress_State;
                model.StudentRegistrationAcademicApprovalDTO.Student_PermanentAddress_StateOther = model.Student_PermanentAddress_StateOther;
                model.StudentRegistrationAcademicApprovalDTO.Student_PermanentAddress_DistrictID = model.Student_PermanentAddress_DistrictID;
                model.StudentRegistrationAcademicApprovalDTO.Student_PermanentAddress_DistrictOther = model.Student_PermanentAddress_DistrictOther;
                model.StudentRegistrationAcademicApprovalDTO.Student_PermanentAddress_City_TahsilID = model.Student_PermanentAddress_City_TahsilID;
                model.StudentRegistrationAcademicApprovalDTO.Student_PermanentAddress_City_TahsilOther = model.Student_PermanentAddress_City_TahsilOther;

                model.StudentRegistrationAcademicApprovalDTO.Student_CorrespondenceAddress_CountryId = model.Student_CorrespondenceAddress_CountryId;
                model.StudentRegistrationAcademicApprovalDTO.Student_CorrespondenceAddress_State = model.Student_CorrespondenceAddress_State;
                model.StudentRegistrationAcademicApprovalDTO.Student_CorrespondenceAddress_StateOther = model.Student_CorrespondenceAddress_StateOther;
                model.StudentRegistrationAcademicApprovalDTO.Student_CorrespondenceAddress_DistrictID = model.Student_CorrespondenceAddress_DistrictID;
                model.StudentRegistrationAcademicApprovalDTO.Student_CorrespondenceAddress_DistrictOther = model.Student_CorrespondenceAddress_DistrictOther;
                model.StudentRegistrationAcademicApprovalDTO.Student_CorrespondenceAddress_City_TahsilID = model.Student_CorrespondenceAddress_City_TahsilID;
                model.StudentRegistrationAcademicApprovalDTO.Student_CorrespondenceAddress_City_TahsilOther = model.Student_CorrespondenceAddress_City_TahsilOther;

                model.StudentRegistrationAcademicApprovalDTO.Student_Qualification_Diploma_ITI_Details_CountryId = model.Student_Qualification_Diploma_ITI_Details_CountryId;
                model.StudentRegistrationAcademicApprovalDTO.Student_Qualification_Diploma_ITI_Details_StateOther = model.Student_Qualification_Diploma_ITI_Details_StateOther;
                model.StudentRegistrationAcademicApprovalDTO.Student_Qualification_DegreeDetails_CountryId = model.Student_Qualification_DegreeDetails_CountryId;
                model.StudentRegistrationAcademicApprovalDTO.Student_Qualification_DegreeDetails_StateOther = model.Student_Qualification_DegreeDetails_StateOther;
                model.StudentRegistrationAcademicApprovalDTO.Student_Qualification_PostGraduationDetails_CountryId = model.Student_Qualification_PostGraduationDetails_CountryId;
                model.StudentRegistrationAcademicApprovalDTO.Student_Qualification_PostGraduationDetails_StateOther = model.Student_Qualification_PostGraduationDetails_StateOther;
                model.StudentRegistrationAcademicApprovalDTO.ApprovalStatus = model.ApprovalStatus;
                model.StudentRegistrationAcademicApprovalDTO.ReasonIfRejected = model.ReasonIfRejected;
                model.StudentRegistrationAcademicApprovalDTO.SelectedSectionDetailID = Convert.ToInt32(model.SelectedSectionDetailID);


                model.StudentRegistrationAcademicApprovalDTO.StuRegistrationStudentPhotoSignThumb = model.StuRegistrationStudentPhotoSignThumb;
                model.StudentRegistrationAcademicApprovalDTO.StuRegistrationStudentSocialReservationInformation = model.StuRegistrationStudentSocialReservationInformation;
                model.StudentRegistrationAcademicApprovalDTO.StuRegistrationOtherInfoOfStudent = model.StuRegistrationOtherInfoOfStudent;
                model.StudentRegistrationAcademicApprovalDTO.stuRegistrationAddressDetails = model.stuRegistrationAddressDetails;
                model.StudentRegistrationAcademicApprovalDTO.StuRegistrationPreQualificationSchoolTransaction = model.StuRegistrationPreQualificationSchoolTransaction;
                model.StudentRegistrationAcademicApprovalDTO.StuRegistrationPreEntranceExaminationTransaction = model.StuRegistrationPreEntranceExaminationTransaction;
                model.StudentRegistrationAcademicApprovalDTO.StuRegistrationPreEntranceExaminationSubjectDetail = model.StuRegistrationPreEntranceExaminationSubjectDetail;
                model.StudentRegistrationAcademicApprovalDTO.StuRegistrationPreQualificationCollegeTransaction = model.StuRegistrationPreQualificationCollegeTransaction;
                model.StudentRegistrationAcademicApprovalDTO.StuRegistrationQualifyingSelectionInfo = model.StuRegistrationQualifyingSelectionInfo;
                model.StudentRegistrationAcademicApprovalDTO.StuRegistrationDocumentSubmitted = model.StuRegistrationDocumentSubmitted;

                model.StudentRegistrationAcademicApprovalDTO.StageSequenceNumber = model.StageSequenceNumber;
                model.StudentRegistrationAcademicApprovalDTO.IsLastRecord = model.IsLastRecord;
                model.StudentRegistrationAcademicApprovalDTO.TaskNotificationMasterID = model.TaskNotificationMasterID;
                model.StudentRegistrationAcademicApprovalDTO.TaskNotificationDetailsID = model.TaskNotificationDetailsID;
                model.StudentRegistrationAcademicApprovalDTO.GeneralTaskReportingDetailsID = model.GeneralTaskReportingDetailsID;

                model.StudentRegistrationAcademicApprovalDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                IBaseEntityResponse<StudentRegistrationAcademicApproval> response = _StudentRegistrationAcademicApprovalServiceAcess.InsertStudentRegistrationAcademicApproval(model.StudentRegistrationAcademicApprovalDTO);
                model.StudentRegistrationAcademicApprovalDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Update);

                if (response.Entity != null)
                {
                    string body = "";
                    if (model.ApprovalStatus == 0)
                    {
                        body = "<Html><Body><div>"
                           + "<div><span>Hello " + model.StudentFirstName + ",</span><br /><br />"
                           + "<span>Your submitted application is not accepted because of " + model.ReasonIfRejected + " .</span><br />"
                           + "<span>Please login and recorrect it.</span><br />"
                           + "</div>"
                           + "</div></Body></Html>";
                    }
                    else
                    {
                        body = "<Html><Body><div>"
                              + "<div><span>Hello " + model.StudentFirstName + ",</span><br /><br />"
                              + "<span>Your submitted application is successfully accepted by academic authority.</span><br />"
                              + "<span>Please now contact with fee department.</span><br />"
                              + "</div>"
                              + "</div></Body></Html>";
                    }
                    bool aaaa = SendEmail(model.StudentEmailID, "Submitted Application Status!!!", body, System.Configuration.ConfigurationManager.AppSettings["SendEmailID"], System.Configuration.ConfigurationManager.AppSettings["SendPassword"]);
                }
                return Json(model.StudentRegistrationAcademicApprovalDTO.errorMessage, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("Please review your form");
            }
        }

        [HttpPost]
        public ActionResult EditV2(StudentRegistrationAcademicApprovalViewModel model)
        {
            if (model != null && model.StudentRegistrationAcademicApprovalDTO != null)
            {
                model.StudentRegistrationAcademicApprovalDTO.ConnectionString = _connectioString;

                model.StudentRegistrationAcademicApprovalDTO.RegistrationID = model.RegistrationID;

                model.StudentRegistrationAcademicApprovalDTO.Student_Domesile_CountryId = model.Student_Domesile_CountryId;
                model.StudentRegistrationAcademicApprovalDTO.StudentRegionOther = model.StudentRegionOther;

                model.StudentRegistrationAcademicApprovalDTO.Student_PermanentAddress_CountryId = model.Student_PermanentAddress_CountryId;
                model.StudentRegistrationAcademicApprovalDTO.Student_PermanentAddress_State = model.Student_PermanentAddress_State;
                model.StudentRegistrationAcademicApprovalDTO.Student_PermanentAddress_StateOther = model.Student_PermanentAddress_StateOther;
                model.StudentRegistrationAcademicApprovalDTO.Student_PermanentAddress_DistrictID = model.Student_PermanentAddress_DistrictID;
                model.StudentRegistrationAcademicApprovalDTO.Student_PermanentAddress_DistrictOther = model.Student_PermanentAddress_DistrictOther;
                model.StudentRegistrationAcademicApprovalDTO.Student_PermanentAddress_City_TahsilID = model.Student_PermanentAddress_City_TahsilID;
                model.StudentRegistrationAcademicApprovalDTO.Student_PermanentAddress_City_TahsilOther = model.Student_PermanentAddress_City_TahsilOther;

                model.StudentRegistrationAcademicApprovalDTO.Student_CorrespondenceAddress_CountryId = model.Student_CorrespondenceAddress_CountryId;
                model.StudentRegistrationAcademicApprovalDTO.Student_CorrespondenceAddress_State = model.Student_CorrespondenceAddress_State;
                model.StudentRegistrationAcademicApprovalDTO.Student_CorrespondenceAddress_StateOther = model.Student_CorrespondenceAddress_StateOther;
                model.StudentRegistrationAcademicApprovalDTO.Student_CorrespondenceAddress_DistrictID = model.Student_CorrespondenceAddress_DistrictID;
                model.StudentRegistrationAcademicApprovalDTO.Student_CorrespondenceAddress_DistrictOther = model.Student_CorrespondenceAddress_DistrictOther;
                model.StudentRegistrationAcademicApprovalDTO.Student_CorrespondenceAddress_City_TahsilID = model.Student_CorrespondenceAddress_City_TahsilID;
                model.StudentRegistrationAcademicApprovalDTO.Student_CorrespondenceAddress_City_TahsilOther = model.Student_CorrespondenceAddress_City_TahsilOther;

                model.StudentRegistrationAcademicApprovalDTO.Student_Qualification_Diploma_ITI_Details_CountryId = model.Student_Qualification_Diploma_ITI_Details_CountryId;
                model.StudentRegistrationAcademicApprovalDTO.Student_Qualification_Diploma_ITI_Details_StateOther = model.Student_Qualification_Diploma_ITI_Details_StateOther;
                model.StudentRegistrationAcademicApprovalDTO.Student_Qualification_DegreeDetails_CountryId = model.Student_Qualification_DegreeDetails_CountryId;
                model.StudentRegistrationAcademicApprovalDTO.Student_Qualification_DegreeDetails_StateOther = model.Student_Qualification_DegreeDetails_StateOther;
                model.StudentRegistrationAcademicApprovalDTO.Student_Qualification_PostGraduationDetails_CountryId = model.Student_Qualification_PostGraduationDetails_CountryId;
                model.StudentRegistrationAcademicApprovalDTO.Student_Qualification_PostGraduationDetails_StateOther = model.Student_Qualification_PostGraduationDetails_StateOther;
                model.StudentRegistrationAcademicApprovalDTO.ApprovalStatus = model.ApprovalStatus;
                model.StudentRegistrationAcademicApprovalDTO.ReasonIfRejected = model.ReasonIfRejected;
                model.StudentRegistrationAcademicApprovalDTO.SelectedSectionDetailID = Convert.ToInt32(model.SelectedSectionDetailID);


                model.StudentRegistrationAcademicApprovalDTO.StuRegistrationStudentPhotoSignThumb = model.StuRegistrationStudentPhotoSignThumb;
                model.StudentRegistrationAcademicApprovalDTO.StuRegistrationStudentSocialReservationInformation = model.StuRegistrationStudentSocialReservationInformation;
                model.StudentRegistrationAcademicApprovalDTO.StuRegistrationOtherInfoOfStudent = model.StuRegistrationOtherInfoOfStudent;
                model.StudentRegistrationAcademicApprovalDTO.stuRegistrationAddressDetails = model.stuRegistrationAddressDetails;
                model.StudentRegistrationAcademicApprovalDTO.StuRegistrationPreQualificationSchoolTransaction = model.StuRegistrationPreQualificationSchoolTransaction;
                model.StudentRegistrationAcademicApprovalDTO.StuRegistrationPreEntranceExaminationTransaction = model.StuRegistrationPreEntranceExaminationTransaction;
                model.StudentRegistrationAcademicApprovalDTO.StuRegistrationPreEntranceExaminationSubjectDetail = model.StuRegistrationPreEntranceExaminationSubjectDetail;
                model.StudentRegistrationAcademicApprovalDTO.StuRegistrationPreQualificationCollegeTransaction = model.StuRegistrationPreQualificationCollegeTransaction;
                model.StudentRegistrationAcademicApprovalDTO.StuRegistrationQualifyingSelectionInfo = model.StuRegistrationQualifyingSelectionInfo;
                model.StudentRegistrationAcademicApprovalDTO.StuRegistrationDocumentSubmitted = model.StuRegistrationDocumentSubmitted;

                model.StudentRegistrationAcademicApprovalDTO.StageSequenceNumber = model.StageSequenceNumber;
                model.StudentRegistrationAcademicApprovalDTO.IsLastRecord = model.IsLastRecord;
                model.StudentRegistrationAcademicApprovalDTO.TaskNotificationMasterID = model.TaskNotificationMasterID;
                model.StudentRegistrationAcademicApprovalDTO.TaskNotificationDetailsID = model.TaskNotificationDetailsID;
                model.StudentRegistrationAcademicApprovalDTO.GeneralTaskReportingDetailsID = model.GeneralTaskReportingDetailsID;

                model.StudentRegistrationAcademicApprovalDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                IBaseEntityResponse<StudentRegistrationAcademicApproval> response = _StudentRegistrationAcademicApprovalServiceAcess.InsertStudentRegistrationAcademicApproval(model.StudentRegistrationAcademicApprovalDTO);
                model.StudentRegistrationAcademicApprovalDTO.errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Update);

                if (response.Entity != null)
                {
                    string body = "";
                    if (model.ApprovalStatus == 0)
                    {
                        body = "<Html><Body><div>"
                           + "<div><span>Hello " + model.StudentFirstName + ",</span><br /><br />"
                           + "<span>Your submitted application is not accepted because of " + model.ReasonIfRejected + " .</span><br />"
                           + "<span>Please login and recorrect it.</span><br />"
                           + "</div>"
                           + "</div></Body></Html>";
                    }
                    else
                    {
                        body = "<Html><Body><div>"
                              + "<div><span>Hello " + model.StudentFirstName + ",</span><br /><br />"
                              + "<span>Your submitted application is successfully accepted by academic authority.</span><br />"
                              + "<span>Please now contact with fee department.</span><br />"
                              + "</div>"
                              + "</div></Body></Html>";
                    }
                    bool aaaa = SendEmail(model.StudentEmailID, "Submitted Application Status!!!", body, System.Configuration.ConfigurationManager.AppSettings["SendEmailID"], System.Configuration.ConfigurationManager.AppSettings["SendPassword"]);
                }
                return Json(model.StudentRegistrationAcademicApprovalDTO.errorMessage, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("Please review your form");
            }
        }

        #endregion

        // Non-Action Method
        #region Methods
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
        //get previous experience
        protected List<PreviousWorkExperienceAcademicApproval> GetPreviousWorkExperience(int StudentRegistrationId)
        {
            PreviousWorkExperienceAcademicApprovalSearchRequest searchRequest = new PreviousWorkExperienceAcademicApprovalSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.RegistrationID = StudentRegistrationId;
            List<PreviousWorkExperienceAcademicApproval> PreviousWorkExperienceList = new List<PreviousWorkExperienceAcademicApproval>();
            IBaseEntityCollectionResponse<PreviousWorkExperienceAcademicApproval> baseEntityCollectionResponse = _StudentRegistrationAcademicApprovalServiceAcess.GetPreviousWorkExperienceAcademicApproval(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    PreviousWorkExperienceList = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return PreviousWorkExperienceList;
        }
        public IEnumerable<StudentRegistrationAcademicApprovalViewModel> GetStudentRegistrationAcademicApproval(out int TotalRecords)
        {
            StudentRegistrationAcademicApprovalSearchRequest searchRequest = new StudentRegistrationAcademicApprovalSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.RoleId = Convert.ToInt32(Session["RoleID"]);
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
                    searchRequest.PersonID = Convert.ToInt32(Session["PersonID"]);
                    searchRequest.TaskCode = "SRAA";
                }
                if (actionModeEnum == ActionModeEnum.Update)
                {
                    searchRequest.SortBy = "ModifiedDate";
                    searchRequest.StartRow = 0;
                    searchRequest.EndRow = 10;
                    searchRequest.SearchBy = string.Empty;
                    searchRequest.SortDirection = "Desc";
                    searchRequest.PersonID = Convert.ToInt32(Session["PersonID"]);
                    searchRequest.TaskCode = "SRAA";
                }
            }
            else
            {
                searchRequest.SortBy = _sortBy;                     // parameters for SelectAll procedures under normal condition
                searchRequest.StartRow = _startRow;
                searchRequest.EndRow = _startRow + _rowLength;
                searchRequest.SearchBy = _searchBy;
                searchRequest.SortDirection = _sortDirection;
                searchRequest.PersonID = Convert.ToInt32(Session["PersonID"]);
                searchRequest.TaskCode = "SRAA";
            }
            List<StudentRegistrationAcademicApprovalViewModel> listStudentRegistrationAcademicApprovalViewModel = new List<StudentRegistrationAcademicApprovalViewModel>();
            List<StudentRegistrationAcademicApproval> listStudentRegistrationAcademicApproval = new List<StudentRegistrationAcademicApproval>();
            IBaseEntityCollectionResponse<StudentRegistrationAcademicApproval> baseEntityCollectionResponse = _StudentRegistrationAcademicApprovalServiceAcess.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listStudentRegistrationAcademicApproval = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (StudentRegistrationAcademicApproval item in listStudentRegistrationAcademicApproval)
                    {
                        StudentRegistrationAcademicApprovalViewModel StudentRegistrationAcademicApprovalViewModel = new StudentRegistrationAcademicApprovalViewModel();
                        StudentRegistrationAcademicApprovalViewModel.StudentRegistrationAcademicApprovalDTO = item;
                        listStudentRegistrationAcademicApprovalViewModel.Add(StudentRegistrationAcademicApprovalViewModel);
                    }
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listStudentRegistrationAcademicApprovalViewModel;
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
        #endregion

        // AjaxHandler Method
        #region AjaxHandler
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
        //For Admitted Section details
        [HttpGet]
        public ActionResult GetSectionDetails(string SelectedBranchID, string CentreCode, string UniversityID)
        {
            // string[] vcentreCode = CentreCode.Split(':');
            int id = 0;
            bool isValid = Int32.TryParse(SelectedBranchID, out id);
            var OrganisationSectionDetails = GetSectionDetailsRoleWise(Convert.ToInt32(SelectedBranchID), CentreCode, UniversityID, "false");
            var result = (from s in OrganisationSectionDetails
                          select new
                          {
                              id = s.ID,
                              name = s.Descriptions,
                          }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }


        public ActionResult AjaxHandler(JQueryDataTableParamModel param)
        {
            if (Session["UserType"] != null)
            {
                int TotalRecords;
                var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
                string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc

                IEnumerable<StudentRegistrationAcademicApprovalViewModel> filteredCountryMaster;
                switch (Convert.ToInt32(sortColumnIndex))
                {
                    case 0:
                        _sortBy = "Description";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            _searchBy = "Description Like '%" + param.sSearch + "%' or ApprovalStatus Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                        }
                        break;
                    case 1:
                        _sortBy = "ApplicationDate";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            _searchBy = "ApplicationDate Like '%" + param.sSearch + "%' or ApplicationDate Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                        }
                        break;
                }
                _sortDirection = sortDirection;
                _rowLength = param.iDisplayLength;
                _startRow = param.iDisplayStart;
                filteredCountryMaster = GetStudentRegistrationAcademicApproval(out TotalRecords);
                var records = filteredCountryMaster.Skip(0).Take(10000);
                var result = from c in records select new[] { Convert.ToString(c.StudentFirstName), Convert.ToString(c.ApprovalStatus), Convert.ToString(c.MenuCodeLink), Convert.ToString(c.TaskNotificationDetailsID), Convert.ToString(c.TaskNotificationMasterID), Convert.ToString(c.GeneralTaskReportingDetailsID), Convert.ToString(c.StageSequenceNumber), Convert.ToString(c.IsLastRecordFlag), Convert.ToString(c.ApplicationDate), Convert.ToString(c.IsEngaged), (Convert.ToString(c.EngagedByUserID) == Convert.ToString(Session["UserID"]) ? Convert.ToString(true) : Convert.ToString(false)) };
                return Json(new { sEcho = param.sEcho, iTotalRecords = TotalRecords, iTotalDisplayRecords = TotalRecords, aaData = result }, JsonRequestBehavior.AllowGet);
            }
            else
            {

                var result = 0;
                return Json(new { aaData = result }, JsonRequestBehavior.AllowGet);

            }
        }


        #endregion
    }
}