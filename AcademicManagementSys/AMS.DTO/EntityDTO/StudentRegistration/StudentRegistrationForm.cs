using AMS.Base.DTO;
using System;
namespace AMS.DTO
{
    public class StudentRegistrationForm : BaseDTO
    {



        #region Oficial Info
        public int Student_AcademicYearId
        {
            get;
            set;
        }
        public string Student_AcademicYear
        {
            get;
            set;
        }
        public string Student_StudentCode
        {
            get;
            set;
        }
        public int Student_CourseYearId
        {
            get;
            set;
        }
        public string Student_CourseYearName
        {
            get;
            set;
        }
        public string Student_SelfRegistrationCode
        {
            get;
            set;
        }
        public string Student_CourseName
        {
            get;
            set;
        }
        public string Student_DateofRegistration
        {
            get;
            set;
        }
        #endregion Oficial Info
        #region File Upload
        public byte[] StudentPhoto
        {
            get;
            set;
        }
    
        public string StudentPhotoType
        {
              get;
            set;
        }
        public string StudentPhotoFilename
        {
            get;

            set;

        }

        public string StudentPhotoFileWidth
        {
            get;

            set;
        }


        public string StudentPhotoFileHeight
        {
            get;
            set;
        }


        public string StudentPhotoFileSize
        {
            get;
            set;
        }

        // for Signature
        public byte[] StudentSignature
        {
            get;
            set;
        }

        public string StudentSignatureType
        {
            get;
            set;
        }
        public string StudentSignatureFilename
        {
            get;

            set;

        }

        public string StudentSignatureFileWidth
        {
            get;

            set;
        }


        public string StudentSignatureFileHeight
        {
            get;
            set;
        }


        public string StudentSignatureFileSize
        {
            get;
            set;
        }


        // for Thumb
        public byte[] StudentThumb
        {
            get;
            set;
        }

        public string StudentThumbType
        {
            get;
            set;
        }
        public string StudentThumbFilename
        {
            get;

            set;

        }

        public string StudentThumbFileWidth
        {
            get;

            set;
        }


        public string StudentThumbFileHeight
        {
            get;
            set;
        }


        public string StudentThumbFileSize
        {
            get;
            set;
        }
        #endregion File Upload
        #region Student General  Info
        public int ID
        {
            get;
            set;
        }

        public string StudentEmailID
        {
            get;
            set;
        }
        public string Password
        {
            get;
            set;
        }
        public string StudentTitle
        {
            get;
            set;
        }
        public string StudentFirstName
        {
            get;
            set;
        }
        public string StudentMiddleName
        {
            get;
            set;
        }
        public string StudentLastName
        {
            get;
            set;
        }
      
        public string StudentMobileNumber
        {
            get;
            set;
        }
        public string StudentLandLineNumber
        {
            get;
            set;
        }
        public string StudentEmploymentSector
        {
            get;
            set;
        }
        public string StudentOccupation
        {
            get;
            set;
        }
        public string StudentOrganizationName
        {
            get;
            set;
        }
        public string StudentOfficeContactNo
        {
            get;
            set;
        }
        public double StudentAnnualIncome
        {
            get;
            set;
        }
        public string StudentDesignation
        {
            get;
            set;
        }
        public string StudentGender
        {
            get;
            set;
        }


        public string CenterCode
        {
            get;
            set;
        }
        public int UniversityID
        {
            get;
            set;
        }
        public bool IsActive
        {
            get;
            set;
        }
        public string WebRegistrationStatus
        {
            get;
            set;
        }
        public string WebAdminComments
        {
            get;
            set;
        }
        public string ApprovalDate
        {
            get;
            set;
        }
        public int AdminApprovedBy
        {
            get;
            set;
        }
        public int StudentID
        {
            get;
            set;
        }
        public string StudentCode
        {
            get;
            set;
        }
        public int AdmissionPattern
        {
            get;
            set;
        }
        public int ApprovStudSecEmployeeID
        {
            get;
            set;
        }
        public int ApprovAcctSecEmployeeID
        {
            get;
            set;
        }
        public int BranchDetailID
        {
            get;
            set;
        }
        public string BranchDescription
        {
            get;
            set;
        }
        public string DivisionDescription
        {
            get;
            set;
        }
        public int StandardNumber
        {
            get;
            set;
        }
        public int ToolRegistrationFieldDetailsID
        {
            get;
            set;
        }
        public int ToolRegistrationTemplateMstID
        {
            get;
            set;
        }
        public string SubstitudeTitleName
        {
            get;
            set;
        }
        public string TemplateName
        {
            get;
            set;
        }
        public bool EnableDisableStatus
        {
            get;
            set;
        }
        #endregion Student General  Info

        #region Father InFormation
        public string FatherHusbondType
        {
            get;
            set;
        }
        public string FatherTitle
        {
            get;
            set;
        }
        public string FatherFirstName { get; set; }
        public string FatherMiddleName
        {
            get;
            set;
        }
        public string FatherLastName
        {
            get;
            set;
        }
        public string FatherEmailId
        {
            get;
            set;
        }
        public string FatherMobileNumber
        {
            get;
            set;
        }
        public string FatherLandLineNumber
        {
            get;
            set;
        }

        public string FatherEmploymentSector
        {
            get;
            set;
        }
        public string FatherOccupation
        {
            get;
            set;
        }
        public string FatherOrganizationName
        {
            get;
            set;
        }
        public string FatherOfficeContactNo
        {
            get;
            set;
        }
        public double FatherAnnualIncome
        {
            get;
            set;
        }
        public string FatherDesignation
        {
            get;
            set;
        }
        #endregion

        #region Mother InFormation
        public string MotherTitle
        {
            get;
            set;
        }
        public string MotherFirstName { get; set; }
        public string MotherMiddleName
        {
            get;
            set;
        }
        public string MotherLastName
        {
            get;
            set;
        }
        public string MotherEmailId
        {
            get;
            set;
        }
        public string MotherMobileNumber
        {
            get;
            set;
        }
        public string MotherLandLineNumber
        {
            get;
            set;
        }

        public string MotherEmploymentSector
        {
            get;
            set;
        }
        public string MotherOccupation
        {
            get;
            set;
        }
        public string MotherOrganizationName
        {
            get;
            set;
        }
        public string MotherOfficeContactNo
        {
            get;
            set;
        }
        public double MotherAnnualIncome
        {
            get;
            set;
        }
        public string MotherDesignation
        {
            get;
            set;
        }
        #endregion

        #region Guardian InFormation
        public string GuardianTitle
        {
            get;
            set;
        }
        public string GuardianFirstName { get; set; }
        public string GuardianMiddleName
        {
            get;
            set;
        }
        public string GuardianLastName
        {
            get;
            set;
        }
        public string GuardianEmailId
        {
            get;
            set;
        }
        public string GuardianMobileNumber
        {
            get;
            set;
        }
        public string GuardianLandLineNumber
        {
            get;
            set;
        }

        public string GuardianEmploymentSector
        {
            get;
            set;
        }
        public string GuardianOccupation
        {
            get;
            set;
        }
        public string GuardianOrganizationName
        {
            get;
            set;
        }
        public string GuardianOfficeContactNo
        {
            get;
            set;
        }
        public double GuardianAnnualIncome
        {
            get;
            set;
        }
        public string GuardianDesignation
        {
            get;
            set;
        }
        #endregion

        #region Student Specific  Info


        public int StudentSelfRegistrationID
        {
            get;
            set;
        }
        public string StudentEnrollmentNo
        {
            get;
            set;
        }
        public string StudentNRI_POI
        {
            get;
            set;
        }
        public string StudentMigrationNumber
        {
            get;
            set;
        }
        public int StudentNationalityID
        {
            get;
            set;
        }
        public string StudentMigrationDate
        {
            get;
            set;
        }
        public string StudentRegionOther
        {
            get;
            set;
        }
        public int StudentRegionID
        {
            get;
            set;
        }
        public int Student_Domesile_CountryId
        {
            get;
            set;
        }
        public string StudentMaritalStatus
        {
            get;
            set;
        }
        public string StudentDomicileStateofFather
        {
            get;
            set;
        }
        public string StudentBloodGroup
        {
            get;
            set;
        }
        public string StudentDomicileStateofMother
        {
            get;
            set;
        }
        public string PhysicallyHandicapped
        {
            get;
            set;
        }
        public string StudentEmploymentStatus
        {
            get;
            set;
        }
        public string StudentIdentificationMark
        {
            get;
            set;
        }
        public string StudentPrevNameofStudent
        {
            get;
            set;
        }
        public string StudentOrgandonor
        {
            get;
            set;
        }
        public string StudentReasonforNamechange
        {
            get;
            set;
        }
        #endregion Student Specific  Info

        #region Information As Per Leaving Certificate
        public string StudentDateofBirth
        {
            get;
            set;
        }
        public string StudentBirthPlace
        {
            get;
            set;
        }
        public int StudentReligionID
        {
            get;
            set;
        }
        public int StudentCasteID
        {
            get;
            set;
        }
        public int StudentCategoryID
        {
            get;
            set;
        }

        public string StudentCasteAsPerTC_LC
        {
            get;
            set;
        }
        public int StudentMotherTongueID
        {
            get;
            set;
        }
        public string StudentNameAsPerMarkSheet
        {
            get;
            set;
        }
        public string StudentLastSchool_College
        {
            get;
            set;
        }
        public string StudentPreviousLC_TCNo
        {
            get;
            set;
        }

        #endregion  Information As Per Leaving Certificate

        #region  Social Reservation Information
        public bool Student_Ex_Serviceman_Ward_of_Ex_Serviceman
        {
            get;
            set;
        }
        public bool Student_Active_Serviceman_Ward_of_Active_Serviceman
        {
            get;
            set;
        }

        public bool Student_FreedomFighterWardOfFreedomFighter
        {
            get;
            set;
        }

        public bool Student_WardofPrimaryTeacher
        {
            get;
            set;
        }

        public bool Student_WardofSecondaryTeacher
        {
            get;
            set;
        }

        public bool Student_Deserted_Divorced_Widowed_Women
        {
            get;
            set;
        }
        public bool Student_MemberofProjectAffectedFamily
        {
            get;
            set;
        }

        public bool Student_MemberofEarthquakeAffectedFamily
        {
            get;
            set;
        }
        public bool Student_MemberofFloodFamineAffectedFamily
        {
            get;
            set;
        }
        public bool Student_ResidentofTribalArea
        {
            get;
            set;
        }

        public bool Student_KashmirMigrant
        {
            get;
            set;
        }


        #endregion  Social Reservation Information

        #region  Other Information Of The Student
        public string StudentIndicatetypeofCandidature
        {
            get;
            set;
        }
        public string StudentSchoolFromHSCExaminationpassed
        {
            get;
            set;
        }
        public string StudentEconomicallyBackwardClass
        {
            get;
            set;
        }
        public string StudentsNameOfDistrictWhereParentDomiciled
        {
            get;
            set;
        }
        public string StudentsMKBCandidate
        {
            get;
            set;
        }

        #endregion  Other Information Of The Student


        #region  Address Information

        #region  Permanent Address
        public string Student_PermanentAddress_PloteNo
        {
            get;
            set;
        }
        public string Student_PermanentAddress_StreeNo
        {
            get;
            set;
        }
        public string Student_PermanentAddress_Address1
        {
            get;
            set;
        }
        public string Student_PermanentAddress_Address2
        {
            get;
            set;
        }
        public int Student_PermanentAddress_City_TahsilID
        {
            get;
            set;
        }
        public string Student_PermanentAddress_City_TahsilName
        {
            get;
            set;
        }
        public string Student_PermanentAddress_City_TahsilOther
        {
            get;
            set;
        }
        public int Student_PermanentAddress_CountryId
        {
            get;
            set;
        }
        public int Student_PermanentAddress_State
        {
            get;
            set;
        }
        public string Student_PermanentAddress_StateOther
        {
            get;
            set;
        }
        public int Student_PermanentAddress_DistrictID
        {
            get;
            set;
        }
        public string Student_PermanentAddress_DistrictOther
        {
            get;
            set;
        }
        public string Student_PermanentAddress_Tahsil
        {
            get;
            set;
        }
        public string Student_PermanentAddress_NearPoliceStation
        {
            get;
            set;
        }
        public string Student_PermanentAddress_ZipCode
        {
            get;
            set;
        }
        public string Student_PermanentAddress_City_Tahsil_Pattern
        {
            get;
            set;
        }
        #endregion  Permanent Address

        #region  Correspondence Address

        public bool SameAsPerPermanentAddress
        {
            get;
            set;
        }
        public string Student_CorrespondenceAddress_PloteNo
        {
            get;
            set;
        }
        public string Student_CorrespondenceAddress_StreeNo
        {
            get;
            set;
        }
        public string Student_CorrespondenceAddress_Address1
        {
            get;
            set;
        }
        public string Student_CorrespondenceAddress_Address2
        {
            get;
            set;
        }
        public string Student_CorrespondenceAddress_City_TahsilOther
        {
            get;
            set;
        }
        public int Student_CorrespondenceAddress_City_TahsilID
        {
            get;
            set;
        }
        public string Student_CorrespondenceAddress_City_TahsilName
        {
            get;
            set;
        }
        public int Student_CorrespondenceAddress_CountryId
        {
            get;
            set;
        }
        public int Student_CorrespondenceAddress_State
        {
            get;
            set;
        }
        public string Student_CorrespondenceAddress_StateOther
        {
            get;
            set;
        }
        public string Student_CorrespondenceAddress_DistrictOther
        {
            get;
            set;
        }
        public int Student_CorrespondenceAddress_DistrictID
        {
            get;
            set;
        }
        public string Student_CorrespondenceAddress_Tahsil
        {
            get;
            set;
        }
        public string Student_CorrespondenceAddress_NearPoliceStation
        {
            get;
            set;
        }
        public string Student_CorrespondenceAddress_ZipCode
        {
            get;
            set;
        }
        public string Student_CorrespondenceAddress_City_Tahsil_Pattern
        {
            get;
            set;
        }
        #endregion  Correspondence Address

        #endregion  Address Information

        #region Qualifying Exam Details

        public int Student_QualifyingExamId
        {
            get;
            set;
        }
        public string Student_QualifyingExamName
        {
            get;
            set;
        }
        public string Student_QualifyingRollNo
        {
            get;
            set;
        }
        public int Student_QualifyingExamTotalMarksPointsObtained
        {
            get;
            set;
        }

        public int Student_QualifyingExamOutOffMark
        {
            get;
            set;
        }
        public string Student_QualifyingExamRank
        {
            get;
            set;
        }
        public int Student_QualifyingExamTotalMarksPointsObtainedInSubject
        {
            get;
            set;
        }
        public int Student_QualifyingTransactionID
        {
            get;
            set;
        }

        #endregion Qualifying Exam Details

        #region Qualification Details


        #region General Details

        public int Student_Qualification_General_MediumOfInstitution
        {
            get;
            set;

        }
        public int Student_Qualification_General_MonthOfPassing
        {
            get;
            set;

        }
        public int Student_Qualification_General_YearOfPassing
        {
            get;
            set;

        }
        public string Student_Qualification_General_SingleAttempt
        {
            get;
            set;

        }
        public int Student_Qualification_General_Percent
        {
            get;
            set;

        }
        public int Student_Qualification_General_ObtainedMark
        {
            get;
            set;

        }
        public int Student_Qualification_General_OutOfMark
        {
            get;
            set;
        }
        public string Student_Qualification_General_Region_Division_Board
        {
            get;
            set;
        }
        public string Student_Qualification_General_NameofInstitution
        {
            get;
            set;
        }
        public int Student_QualificationTransactionID
        {
            get;
            set;
        }
        //public int Student_QualifyingExamTotalMarksPointsObtainedInSubject
        //{
        //    get;
        //    set;
        //}
        #endregion General Details

        #region SSC Details
        public int Student_Qualification_SSC_MediumOfInstitution
        {
            get;
            set;

        }
        public int Student_Qualification_SSC_MonthOfPassing
        {
            get;
            set;

        }
        public int Student_Qualification_SSC_YearOfPassing
        {
            get;
            set;

        }
        public string Student_Qualification_SSC_SingleAttempt
        {
            get;
            set;

        }
        public int Student_Qualification_SSC_Percent
        {
            get;
            set;

        }
        public int Student_Qualification_SSC_ObtainedMark
        {
            get;
            set;

        }
        public int Student_Qualification_SSC_OutOfMark
        {
            get;
            set;
        }
        public string Student_Qualification_SSC_Region_Division_Board
        {
            get;
            set;
        }
        public string Student_Qualification_SSC_NameofInstitution
        {
            get;
            set;
        }
        #endregion SSC Details
        #region HSC Details
        public int Student_Qualification_HSC_MediumOfInstitution
        {
            get;
            set;

        }
        public int Student_Qualification_HSC_MonthOfPassing
        {
            get;
            set;

        }
        public int Student_Qualification_HSC_YearOfPassing
        {
            get;
            set;

        }
        public int Student_Qualification_HSC_StreamID
        {
            get;
            set;

        }
        public string Student_Qualification_HSC_StreamOther
        {
            get;
            set;

        }
        public string Student_Qualification_HSC_SingleAttempt
        {
            get;
            set;

        }

        public string Student_Qualification_HSC_Class
        {
            get;
            set;

        }
        public int Student_Qualification_HSC_ObtainedMark
        {
            get;
            set;

        }
        public int Student_Qualification_HSC_OutOfMark
        {
            get;
            set;
        }
        public int Student_Qualification_HSC_Percent
        {
            get;
            set;

        }

        public int Student_Qualification_HSC_PCM_PVM_ObtainedMark
        {
            get;
            set;

        }
        public int Student_Qualification_HSC_PCM_PVM_OutOfMark
        {
            get;
            set;
        }
        public int Student_Qualification_HSC_PCB_ObtainedMark
        {
            get;
            set;

        }
        public int Student_Qualification_HSC_PCB_OutOfMark
        {
            get;
            set;
        }
        public string Student_Qualification_HSC_Region_Division_Board
        {
            get;
            set;
        }
        public string Student_Qualification_HSC_NameofInstitution
        {
            get;
            set;
        }
        #endregion HSC Details

        #region Diploma / ITI Details
        public int Student_Qualification_Diploma_ITI_Details_MediumOfInstitution
        {
            get;
            set;

        }
        public int Student_Qualification_Diploma_ITI_Details_BranchId
        {
            get;
            set;

        }
        public string Student_Qualification_Diploma_ITI_Details_BranchName
        {
            get;
            set;

        }
        public string Student_Qualification_Diploma_ITI_Details_ExamPattern
        {
            get;
            set;

        }

        public int Student_Qualification_Diploma_ITI_Details_MonthOfPassing
        {
            get;
            set;

        }
        public int Student_Qualification_Diploma_ITI_Details_YearOfPassing
        {
            get;
            set;

        }
        public string Student_Qualification_Diploma_ITI_Details_Class
        {
            get;
            set;

        }
        public int Student_Qualification_Diploma_ITI_Details_ObtainedMark
        {
            get;
            set;

        }
        public int Student_Qualification_Diploma_ITI_Details_OutOfMark
        {
            get;
            set;
        }
        public int Student_Qualification_Diploma_ITI_Details_Percent
        {
            get;
            set;

        }
        public string Student_Qualification_Diploma_ITI_Details_SingleAttempt
        {
            get;
            set;

        }
        public string Student_Qualification_Diploma_ITI_Details_BoardEnrollmentNumber
        {
            get;
            set;

        }
        public string Student_Qualification_Diploma_ITI_Details_NameofInstitution
        {
            get;
            set;

        }
        public string Student_Qualification_Diploma_ITI_Details_Board
        {
            get;
            set;

        }
        public int Student_Qualification_Diploma_ITI_Details_State
        {
            get;
            set;
        }
        public string Student_Qualification_Diploma_ITI_Details_StateOther
        {
            get;
            set;
        }

        public int Student_Qualification_Diploma_ITI_Details_CountryId
        {
            get;
            set;
        }
        #endregion Diploma / ITI Details


        #region Degree Details


        public int Student_Qualification_DegreeDetails_MediumOfInstitution
        {
            get;
            set;

        }
        public int Student_Qualification_DegreeDetails_BranchId
        {
            get;
            set;

        }
        public string Student_Qualification_DegreeDetails_BranchName
        {
            get;
            set;

        }
        public string Student_Qualification_DegreeDetails_ExamPattern
        {
            get;
            set;

        }

        public int Student_Qualification_DegreeDetails_MonthOfPassing
        {
            get;
            set;

        }
        public int Student_Qualification_DegreeDetails_YearOfPassing
        {
            get;
            set;

        }
        public string Student_Qualification_DegreeDetails_Class
        {
            get;
            set;

        }
        public int Student_Qualification_DegreeDetails_ObtainedMark
        {
            get;
            set;

        }
        public int Student_Qualification_DegreeDetails_OutOfMark
        {
            get;
            set;
        }
        public int Student_Qualification_DegreeDetails_Percent
        {
            get;
            set;

        }
        public string Student_Qualification_DegreeDetails_SingleAttempt
        {
            get;
            set;

        }
        public string Student_Qualification_DegreeDetails_BoardEnrollmentNumber
        {
            get;
            set;

        }
        public string Student_Qualification_DegreeDetails_NameofInstitution
        {
            get;
            set;

        }
        public int Student_Qualification_DegreeDetails_UniversityId
        {
            get;
            set;

        }
        public string Student_Qualification_DegreeDetails_UniversityName
        {
            get;
            set;

        }
        public int Student_Qualification_DegreeDetails_State
        {
            get;
            set;
        }
        public string Student_Qualification_DegreeDetails_StateOther
        {
            get;
            set;
        }
        public string Student_Qualification_DegreeDetails_Degree
        {
            get;
            set;

        }
        public int Student_Qualification_DegreeDetails_CountryId
        {
            get;
            set;
        }

        #endregion Degree Details

        #region PostGraduation Details
        public int Student_Qualification_PostGraduationDetails_MediumOfInstitution
        {
            get;
            set;

        }
        public int Student_Qualification_PostGraduationDetails_BranchId
        {
            get;
            set;

        }
        public string Student_Qualification_PostGraduationDetails_BranchName
        {
            get;
            set;

        }
        public string Student_Qualification_PostGraduationDetails_ExamPattern
        {
            get;
            set;

        }

        public int Student_Qualification_PostGraduationDetails_MonthOfPassing
        {
            get;
            set;

        }
        public int Student_Qualification_PostGraduationDetails_YearOfPassing
        {
            get;
            set;

        }
        public string Student_Qualification_PostGraduationDetails_Class
        {
            get;
            set;

        }
        public int Student_Qualification_PostGraduationDetails_ObtainedMark
        {
            get;
            set;

        }
        public int Student_Qualification_PostGraduationDetails_OutOfMark
        {
            get;
            set;
        }
        public int Student_Qualification_PostGraduationDetails_Percent
        {
            get;
            set;

        }
        public string Student_Qualification_PostGraduationDetails_SingleAttempt
        {
            get;
            set;

        }
        public string Student_Qualification_PostGraduationDetails_BoardEnrollmentNumber
        {
            get;
            set;

        }
        public string Student_Qualification_PostGraduationDetails_NameofInstitution
        {
            get;
            set;

        }
        public int Student_Qualification_PostGraduationDetails_UniversityId
        {
            get;
            set;

        }
        public string Student_Qualification_PostGraduationDetails_UniversityName
        {
            get;
            set;

        }
        public int Student_Qualification_PostGraduationDetails_State
        {
            get;
            set;
        }
        public string Student_Qualification_PostGraduationDetails_StateOther
        {
            get;
            set;
        }
        public string Student_Qualification_PostGraduationDetails_PostGraduation
        {
            get;
            set;

        }
        public int Student_Qualification_PostGraduationDetails_CountryId
        {
            get;
            set;
        }

        #endregion Post Graduation Details
        #endregion Qualification Details

        # region DTE & Scholarship Information

        # region DTE  Information
        public string Student_DTE_DTEUserID
        {
            get;
            set;
        }
        public string Student_DTE_DTEPassword
        {
            get;
            set;
        }
        public string Student_DTE_DTESrNo
        {
            get;
            set;
        }
        public string Student_DTE_DTEMeritNo
        {
            get;
            set;
        }
        public int Student_DTE_AdmissionTypeId
        {
            get;
            set;
        }

        public int Student_DTE_AdmissionRound
        {
            get;
            set;
        }
        public int Student_DTE_AdmissionCategoryId
        {
            get;
            set;
        }
        public string Student_DTE_DTESeatNo
        {
            get;
            set;
        }
        public int Student_DTE_QualifyingExamId
        {
            get;
            set;
        }

        public string Student_DTE_QualifyingExamName
        {
            get;
            set;
        }
        public int Student_DTE_QualifyingExamMarks
        {
            get;
            set;
        }
        # endregion DTE  Information

        # region  Scholarship Information
        public string Student_Scholarship_ScholarshipId
        {
            get;
            set;
        }
        public string Student_Scholarship_ScholarshipType
        {
            get;
            set;
        }
        public int Student_Scholarship_CastCategoryId
        {
            get;
            set;
        }
        public string Student_Scholarship_CastCategoryOther
        {
            get;
            set;
        }
        public string Student_Scholarship_AadhaarCardNo
        {
            get;
            set;
        }
        public double Student_Scholarship_AnnualIncome
        {
            get;
            set;
        }
        public int Student_Scholarship_NoofSibling
        {
            get;
            set;
        }
        public int Student_Scholarship_ChildNoOutofSibling
        {
            get;
            set;
        }
        public string Student_Scholarship_HostelDayScholar
        {
            get;
            set;
        }
        public string Student_Scholarship_Bank_BranchName
        {
            get;
            set;
        }
        public string Student_Scholarship_Bank_AC_No
        {
            get;
            set;
        }
        public string Student_Scholarship_Bank_IFSCCode
        {
            get;
            set;
        }
        public string Student_Scholarship_Bank_MICRCode
        {
            get;
            set;
        }
        # endregion Scholarship Information
        # endregion DTE & Scholarship Information

        #region Student Documents Information
        #region Admission Documents Information

        #region Admission Documents Information
        public bool Student_AdmissionDocuments_JETMarkSheet
        {
            get;
            set;
        }
        public bool Student_AdmissionDocuments_AllotmentLetter
        {
            get;
            set;
        }
        public bool Student_AdmissionDocuments_TenthMarkSheet
        {
            get;
            set;
        }
        public bool Student_AdmissionDocuments_TwelvethMarkSheet
        {
            get;
            set;
        }
        public bool Student_AdmissionDocuments_AllDiplomaMarksheet
        {
            get;
            set;
        }
        public bool Student_AdmissionDocuments_LeavingCertificate
        {
            get;
            set;
        }

        public bool Student_AdmissionDocuments_Domicile_BirthCertificate
        {
            get;
            set;
        }
        public bool Student_AdmissionDocuments_NationalityCertificate
        {
            get;
            set;
        }
        public bool Student_AdmissionDocuments_CasteCertificate
        {
            get;
            set;
        }
        public bool Student_AdmissionDocuments_CasteValidityCertificate
        {
            get;
            set;
        }
        public bool Student_AdmissionDocuments_NonCreamylayerCertificate
        {
            get;
            set;
        }

        public bool Student_AdmissionDocuments_EquivalenceCertificate
        {
            get;
            set;
        }
        public bool Student_AdmissionDocuments_MigrationCertificate
        {
            get;
            set;
        }
        public bool Student_AdmissionDocuments_GapCertificate
        {
            get;
            set;
        }
        public bool Student_AdmissionDocuments_AntiRaggingAffidavit
        {
            get;
            set;
        }
        public bool Student_AdmissionDocuments_Proforma_Fand_F1_On_DoctorsLetter_Head
        {
            get;
            set;
        }
        public bool Student_AdmissionDocuments_Proforma_I
        {
            get;
            set;
        }
        public bool Student_AdmissionDocuments_ProformaG1
        {
            get;
            set;
        }
        public bool Student_AdmissionDocuments_ProformaG2
        {
            get;
            set;
        }
        public bool Student_AdmissionDocuments_Proforma_C_D_E
        {
            get;
            set;
        }
        public bool Student_AdmissionDocuments_FathersIncomeCertificate
        {
            get;
            set;
        }
        public bool Student_AdmissionDocuments_AadharCardXerox
        {
            get;
            set;
        }
        public bool Student_AdmissionDocuments_B_WPhoto_I_card_size
        {
            get;
            set;
        }
        public bool Student_AdmissionDocuments_Colour_photo
        {
            get;
            set;
        }

        #endregion Admission Documents Information
        #region For PG Students
        public bool Student_AdmissionDocuments_PGStudents_DegreeMarksheet
        {
            get;
            set;
        }
        public bool Student_AdmissionDocuments_PGStudents_DegreeCertificate
        {
            get;
            set;
        }
        public bool Student_AdmissionDocuments_PGStudents_GateScoreCard
        {
            get;
            set;
        }
        public bool Student_AdmissionDocuments_PGStudents_SponsorshipLetterforSponsoredCandidate
        {
            get;
            set;
        }
        #endregion For PG Students
        #region Comments
        public string Student_AdmissionDocuments_Comments
        {
            get;
            set;
        }
        #endregion Comments
        #endregion Admission Documents Information

        #region Scholarship Documents Information
        #region Scholarship Documents Information
        public bool Student_ScholarshipDocuments_IncomeCertificateOriginal
        {
            get;
            set;
        }
        public bool Student_ScholarshipDocuments_TenthMarkSheet
        {
            get;
            set;
        }
        public bool Student_ScholarshipDocuments_TwelvethMarkSheet
        {
            get;
            set;
        }
        public bool Student_ScholarshipDocuments_AdharCard
        {
            get;
            set;
        }
        public bool Student_ScholarshipDocuments_AdmissionConfirmationLetter
        {
            get;
            set;
        }
        public bool Student_ScholarshipDocuments_AllotmentLetter
        {
            get;
            set;
        }
        public bool Student_ScholarshipDocuments_BankPassBookXerox
        {
            get;
            set;
        }
        public bool Student_ScholarshipDocuments_CastCertificate
        {
            get;
            set;
        }

        public bool Student_ScholarshipDocuments_CastValidity
        {
            get;
            set;
        }
        public bool Student_ScholarshipDocuments_Domicile
        {
            get;
            set;
        }
        public bool Student_ScholarshipDocuments_Receipt
        {
            get;
            set;
        }
        public bool Student_ScholarshipDocuments_GateScoreCard
        {
            get;
            set;
        }

        public bool Student_ScholarshipDocuments_HandicapCertificate
        {
            get;
            set;
        }
        public bool Student_ScholarshipDocuments_Icardsizephoto
        {
            get;
            set;
        }

        public bool Student_ScholarshipDocuments_IDProof
        {
            get;
            set;
        }
        public bool Student_ScholarshipDocuments_IncomeAffidavitOriginal
        {
            get;
            set;
        }

        public bool Student_ScholarshipDocuments_JEEMainScoreCard
        {
            get;
            set;
        }
        public bool Student_ScholarshipDocuments_Leavingcertificate
        {
            get;
            set;
        }

        public bool Student_ScholarshipDocuments_ParentsFromNo16
        {
            get;
            set;
        }
        public bool Student_ScholarshipDocuments_LastYearMarksheet
        {
            get;
            set;
        }
        public bool Student_ScholarshipDocuments_RationCard
        {
            get;
            set;
        }
        public bool Student_ScholarshipDocuments_MHCETScoreCard
        {
            get;
            set;
        }
        public bool Student_ScholarshipDocuments_LastCollegeletterAboutScholarshipOriginal
        {
            get;
            set;
        }
        public bool Student_ScholarshipDocuments_Colourphoto
        {
            get;
            set;
        }
        #endregion Scholarship Documents Information
        #region If Applicable
        public bool Student_ScholarshipDocuments_IfApplicable_NonCreamylayer
        {
            get;
            set;
        }
        public bool Student_ScholarshipDocuments_IfApplicable_DeathcertificateFatherMother
        {
            get;
            set;
        }
        public bool Student_ScholarshipDocuments_IfApplicable_DisabilityAbilityCertificate
        {
            get;
            set;
        }
        public bool Student_ScholarshipDocuments_IfApplicable_GapCertificate
        {
            get;
            set;
        }
        public string StudentSubmitedDocumentFlagIDs
        {
            get;
            set;
        }

        public string StudentSubmitedDocumentIDs
        {
            get;
            set;
        }
        
        #endregion If Applicable
        #region Comments
        public string Student_ScholarshipDocuments_Comments
        {
            get;
            set;
        }
        #endregion Comments
        #endregion Scholarship Documents Information

        #endregion Student Documents Information

        #region Subject IDs
        public string QualifyingExamSubjectDetailsIDs
        {
            get;
            set;
        }
        public string QualificationExamSubjectGeneralDetailsIDs
        {
            get;
            set;
        }
        public string QualificationExamSubjectSSCDetailsIDs
        {
            get;
            set;
        }
        public string QualificationExamSubjectHSCDetailsIDs
        {
            get;
            set;
        }
        #endregion Subject IDs

        public bool StudentActiveFlag
        {
            get;
            set;
        }
        public bool IsDeleted
        {
            get;
            set;
        }

        public int CreatedBy
        {
            get;
            set;
        }
        public DateTime CreatedDate
        {
            get;
            set;
        }
        public int? ModifiedBy
        {
            get;
            set;
        }
        public DateTime? ModifiedDate
        {
            get;
            set;
        }
        public int? DeletedBy
        {
            get;
            set;
        }
        public DateTime? DeletedDate
        {
            get;
            set;
        }
        public int Status
        {
            get;
            set;
        }

        public string AuthorisationType
        {
            get;
            set;
        }
        public int SectionDetailsID
        {
            get;
            set;
        }
        public bool IsTaskGeneratedForApproval
        {
            get;
            set;
        }
        public string ReasonIfRejected
        {
            get;
            set;
        }

        public string NameOfApplicant { get; set;}
        public string TitleOfProject { get; set;}
        public string ProjectSummary { get; set; }
        public short FeesPaidBy { get; set; }
        public string WorkExperienceXML { get; set; }
        public string DeletedPreviousExperienceIDs { get; set; }
        

    }
    public class PreviousWorkExperience : BaseDTO
    {
        public int StudentPreviousExperienceID { get; set; }
        public string NameOfOrganization { get; set; }
        public string Position { get; set; }
        public string FullPartTimeFlag { get; set; }
        public string FromDate { get; set; }
        public string UptoDate { get; set; }
    }
}
