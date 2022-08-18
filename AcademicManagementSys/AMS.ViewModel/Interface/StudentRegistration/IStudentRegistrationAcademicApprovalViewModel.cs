using AMS.DTO;
using System;
using System.Collections.Generic;

namespace AMS.ViewModel
{
    public interface IStudentRegistrationAcademicApprovalViewModel
    {
        StudentRegistrationAcademicApproval StudentRegistrationAcademicApprovalDTO
        {
            get;
            set;
        }
        int ID { get; set; }


        int RegistrationID
        {
            get;
            set;
        }
        string AuthorisationType
        {
            get;
            set;
        }
        int RoleID
        {
            get;
            set;
        }
        bool Status
        {
            get;
            set;
        }
        string ReasonIfRejected
        {
            get;
            set;
        }
        bool IslastStatus
        {
            get;
            set;
        }

        string StudentStatus
        {
            get;
            set;
        }

        // bool ApprovalStatus
        //{
        //    get;
        //    set;
        //}


        #region Oficial Info
        int Student_AcademicYearId
        {
            get;
            set;
        }
        string Student_AcademicYear
        {
            get;
            set;
        }
        string Student_StudentCode
        {
            get;
            set;
        }
        int Student_CourseYearId
        {
            get;
            set;
        }
        string Student_CourseYearName
        {
            get;
            set;
        }
        string Student_SelfRegistrationCode
        {
            get;
            set;
        }
        string Student_CourseName
        {
            get;
            set;
        }

        #endregion Oficial Info

        #region File Upload
        byte[] StudentPhoto
        {
            get;
            set;
        }

        string StudentPhotoType
        {
            get;
            set;
        }
        string StudentPhotoFilename
        {
            get;

            set;

        }

        string StudentPhotoFileWidth
        {
            get;

            set;
        }


        string StudentPhotoFileHeight
        {
            get;
            set;
        }


        string StudentPhotoFileSize
        {
            get;
            set;
        }

        // for Signature
        byte[] StudentSignature
        {
            get;
            set;
        }

        string StudentSignatureType
        {
            get;
            set;
        }
        string StudentSignatureFilename
        {
            get;

            set;

        }

        string StudentSignatureFileWidth
        {
            get;

            set;
        }


        string StudentSignatureFileHeight
        {
            get;
            set;
        }


        string StudentSignatureFileSize
        {
            get;
            set;
        }


        // for Thumb
        byte[] StudentThumb
        {
            get;
            set;
        }

        string StudentThumbType
        {
            get;
            set;
        }
        string StudentThumbFilename
        {
            get;

            set;

        }

        string StudentThumbFileWidth
        {
            get;

            set;
        }


        string StudentThumbFileHeight
        {
            get;
            set;
        }


        string StudentThumbFileSize
        {
            get;
            set;
        }
        #endregion File Upload
        #region Student General  Info


        string StudentEmailID
        {
            get;
            set;
        }
        string Password
        {
            get;
            set;
        }
        string StudentTitle
        {
            get;
            set;
        }
        string StudentFirstName
        {
            get;
            set;
        }
        string StudentMiddleName
        {
            get;
            set;
        }
        string StudentLastName
        {
            get;
            set;
        }
        string StudentDateofRegistration
        {
            get;
            set;
        }
        string StudentMobileNumber
        {
            get;
            set;
        }
        string StudentLandLineNumber
        {
            get;
            set;
        }
        string StudentEmploymentSector
        {
            get;
            set;
        }
        string StudentOccupation
        {
            get;
            set;
        }
        string StudentDesignation
        {
            get;
            set;
        }
        string StudentOrganizationName
        {
            get;
            set;
        }
        string StudentOfficeContactNo
        {
            get;
            set;
        }
        double StudentAnnualIncome
        {
            get;
            set;
        }
        string StudentGender
        {
            get;
            set;
        }

        string CenterCode
        {
            get;
            set;
        }
        int UniversityID
        {
            get;
            set;
        }
        bool IsActive
        {
            get;
            set;
        }
        string WebRegistrationStatus
        {
            get;
            set;
        }
        string WebAdminComments
        {
            get;
            set;
        }
        DateTime ApprovalDate
        {
            get;
            set;
        }
        int AdminApprovedBy
        {
            get;
            set;
        }
        int StudentID
        {
            get;
            set;
        }
        string StudentCode
        {
            get;
            set;
        }
        int ApprovStudSecEmployeeID
        {
            get;
            set;
        }
        int ApprovAcctSecEmployeeID
        {
            get;
            set;
        }
        int StandardNumber
        {
            get;
            set;
        }
        int AdmissionPattern
        {
            get;
            set;
        }
        int BranchDetailID
        {
            get;
            set;
        }

        int ToolRegistrationTemplateMstID
        {
            get;
            set;
        }
        #endregion Student General  Info
        #region Father InFormation
        string FatherHusbondType
        {
            get;
            set;
        }
        string FatherTitle
        {
            get;
            set;
        }
        string FatherFirstName { get; set; }
        string FatherMiddleName
        {
            get;
            set;
        }
        string FatherLastName
        {
            get;
            set;
        }

        string FatherEmailId
        {
            get;
            set;
        }

        string FatherMobileNumber
        {
            get;
            set;
        }
        string FatherLandLineNumber
        {
            get;
            set;
        }


        string FatherEmploymentSector
        {
            get;
            set;
        }
        string FatherOccupation
        {
            get;
            set;
        }
        string FatherOrganizationName
        {
            get;
            set;
        }
        string FatherOfficeContactNo
        {
            get;
            set;
        }
        double FatherAnnualIncome
        {
            get;
            set;
        }
        string FatherDesignation
        {
            get;
            set;
        }
        #endregion

        #region Mother InFormation
        string MotherTitle
        {
            get;
            set;
        }
        string MotherFirstName { get; set; }
        string MotherMiddleName
        {
            get;
            set;
        }
        string MotherLastName
        {
            get;
            set;
        }

        string MotherEmailId
        {
            get;
            set;
        }

        string MotherMobileNumber
        {
            get;
            set;
        }
        string MotherLandLineNumber
        {
            get;
            set;
        }


        string MotherEmploymentSector
        {
            get;
            set;
        }
        string MotherOccupation
        {
            get;
            set;
        }
        string MotherOrganizationName
        {
            get;
            set;
        }
        string MotherOfficeContactNo
        {
            get;
            set;
        }
        double MotherAnnualIncome
        {
            get;
            set;
        }
        string MotherDesignation
        {
            get;
            set;
        }
        #endregion


        #region Guardian InFormation
        string GuardianTitle
        {
            get;
            set;
        }
        string GuardianFirstName { get; set; }
        string GuardianMiddleName
        {
            get;
            set;
        }
        string GuardianLastName
        {
            get;
            set;
        }

        string GuardianEmailId
        {
            get;
            set;
        }

        string GuardianMobileNumber
        {
            get;
            set;
        }
        string GuardianLandLineNumber
        {
            get;
            set;
        }


        string GuardianEmploymentSector
        {
            get;
            set;
        }
        string GuardianOccupation
        {
            get;
            set;
        }
        string GuardianOrganizationName
        {
            get;
            set;
        }
        string GuardianOfficeContactNo
        {
            get;
            set;
        }
        double GuardianAnnualIncome
        {
            get;
            set;
        }
        string GuardianDesignation
        {
            get;
            set;
        }
        #endregion

        #region Student Specific  Info
        string StudentEnrollmentNo
        {
            get;
            set;
        }
        string StudentNRI_POI
        {
            get;
            set;
        }
        string StudentMigrationNumber
        {
            get;
            set;
        }
        int StudentNationalityID
        {
            get;
            set;
        }
        string StudentMigrationDate
        {
            get;
            set;
        }
        string StudentRegionOther
        {
            get;
            set;
        }
        int StudentRegionID
        {
            get;
            set;
        }
        string StudentMaritalStatus
        {
            get;
            set;
        }
        string StudentDomicileStateofFather
        {
            get;
            set;
        }
        string StudentBloodGroup
        {
            get;
            set;
        }
        string StudentDomicileStateofMother
        {
            get;
            set;
        }
        string PhysicallyHandicapped
        {
            get;
            set;
        }
        string StudentEmploymentStatus
        {
            get;
            set;
        }
        string StudentIdentificationMark
        {
            get;
            set;
        }
        string StudentPrevNameofStudent
        {
            get;
            set;
        }
        string StudentOrgandonor
        {
            get;
            set;
        }
        string StudentReasonforNamechange
        {
            get;
            set;
        }

        int Student_Domesile_CountryId
        {
            get;
            set;
        }
        int StudentSelfRegistrationID
        {
            get;
            set;
        }
        #endregion Student Specific  Info

        #region Information As Per Leaving Certificate
        string StudentDateofBirth
        {
            get;
            set;
        }
        string StudentBirthPlace
        {
            get;
            set;
        }
        int StudentReligionID
        {
            get;
            set;
        }
        int StudentCasteID
        {
            get;
            set;
        }
        int StudentCategoryID
        {
            get;
            set;
        }
        string StudentCasteAsPerTC_LC
        {
            get;
            set;
        }

        int StudentMotherTongueID
        {
            get;
            set;
        }
        string StudentNameAsPerMarkSheet
        {
            get;
            set;
        }
        string StudentLastSchool_College
        {
            get;
            set;
        }
        string StudentPreviousLC_TCNo
        {
            get;
            set;
        }
        #endregion  Information As Per Leaving Certificate

        #region  Social Reservation Information
        bool Student_Ex_Serviceman_Ward_of_Ex_Serviceman
        {
            get;
            set;
        }
        bool Student_Active_Serviceman_Ward_of_Active_Serviceman
        {
            get;
            set;
        }

        bool Student_FreedomFighterWardOfFreedomFighter
        {
            get;
            set;
        }

        bool Student_WardofPrimaryTeacher
        {
            get;
            set;
        }

        bool Student_WardofSecondaryTeacher
        {
            get;
            set;
        }

        bool Student_Deserted_Divorced_Widowed_Women
        {
            get;
            set;
        }
        bool Student_MemberofProjectAffectedFamily
        {
            get;
            set;
        }
        bool Student_KashmirMigrant
        {
            get;
            set;
        }
        bool Student_MemberofEarthquakeAffectedFamily
        {
            get;
            set;
        }
        bool Student_MemberofFloodFamineAffectedFamily
        {
            get;
            set;
        }
        bool Student_ResidentofTribalArea
        {
            get;
            set;
        }
        #endregion  Social Reservation Information

        #region  Other Information Of The Student
        string StudentIndicatetypeofCandidature
        {
            get;
            set;
        }
        string StudentSchoolFromHSCExaminationpassed
        {
            get;
            set;
        }
        string StudentEconomicallyBackwardClass
        {
            get;
            set;
        }
        string StudentsNameOfDistrictWhereParentDomiciled
        {
            get;
            set;
        }
        string StudentsMKBCandidate
        {
            get;
            set;
        }

        #endregion  Other Information Of The Student

        #region  Address Information

        #region  Permanent Address
        string Student_PermanentAddress_PloteNo
        {
            get;
            set;
        }
        string Student_PermanentAddress_StreeNo
        {
            get;
            set;
        }
        string Student_PermanentAddress_Address1
        {
            get;
            set;
        }
        string Student_PermanentAddress_Address2
        {
            get;
            set;
        }
        int Student_PermanentAddress_City_TahsilID
        {
            get;
            set;
        }
        string Student_PermanentAddress_City_TahsilOther
        {
            get;
            set;
        }
        int Student_PermanentAddress_CountryId
        {
            get;
            set;
        }
        int Student_PermanentAddress_State
        {
            get;
            set;
        }
        string Student_PermanentAddress_StateOther
        {
            get;
            set;
        }
        int Student_PermanentAddress_DistrictID
        {
            get;
            set;
        }
        string Student_PermanentAddress_DistrictOther
        {
            get;
            set;
        }
        string Student_PermanentAddress_Tahsil
        {
            get;
            set;
        }
        string Student_PermanentAddress_NearPoliceStation
        {
            get;
            set;
        }
        string Student_PermanentAddress_ZipCode
        {
            get;
            set;
        }
        string Student_PermanentAddress_City_Tahsil_Pattern
        {
            get;
            set;
        }
        #endregion  Permanent Address

        #region  Correspondence Address
        bool SameAsPerPermanentAddress
        {
            get;
            set;
        }
        string Student_CorrespondenceAddress_PloteNo
        {
            get;
            set;
        }
        string Student_CorrespondenceAddress_StreeNo
        {
            get;
            set;
        }
        string Student_CorrespondenceAddress_Address1
        {
            get;
            set;
        }
        string Student_CorrespondenceAddress_Address2
        {
            get;
            set;
        }
        string Student_CorrespondenceAddress_City_TahsilOther
        {
            get;
            set;
        }
        int Student_CorrespondenceAddress_City_TahsilID
        {
            get;
            set;
        }
        int Student_CorrespondenceAddress_CountryId
        {
            get;
            set;
        }
        int Student_CorrespondenceAddress_State
        {
            get;
            set;
        }
        string Student_CorrespondenceAddress_StateOther
        {
            get;
            set;
        }
        string Student_CorrespondenceAddress_DistrictOther
        {
            get;
            set;
        }
        int Student_CorrespondenceAddress_DistrictID
        {
            get;
            set;
        }
        string Student_CorrespondenceAddress_Tahsil
        {
            get;
            set;
        }
        string Student_CorrespondenceAddress_NearPoliceStation
        {
            get;
            set;
        }
        string Student_CorrespondenceAddress_ZipCode
        {
            get;
            set;
        }
        string Student_CorrespondenceAddress_City_Tahsil_Pattern
        {
            get;
            set;
        }
        #endregion  Correspondence Address

        #endregion  Address Information

        #region Qualifying Exam Details


        int Student_QualifyingExamId
        {
            get;
            set;
        }
        string Student_QualifyingExamName
        {
            get;
            set;
        }
        string Student_QualifyingRollNo
        {
            get;
            set;
        }
        int Student_QualifyingExamTotalMarksPointsObtained
        {
            get;
            set;
        }

        int Student_QualifyingExamOutOffMark
        {
            get;
            set;
        }
        string Student_QualifyingExamRank
        {
            get;
            set;
        }
        int Student_QualifyingExamTotalMarksPointsObtainedInSubject
        {
            get;
            set;
        }
        int Student_QualifyingTransactionID
        {
            get;
            set;
        }

        #endregion Qualifying Exam Details

        #region Qualification Details
        #region General Details

        int Student_Qualification_General_MediumOfInstitution
        {
            get;
            set;

        }
        int Student_Qualification_General_MonthOfPassing
        {
            get;
            set;

        }
        int Student_Qualification_General_YearOfPassing
        {
            get;
            set;

        }
        string Student_Qualification_General_SingleAttempt
        {
            get;
            set;

        }
        int Student_Qualification_General_Percent
        {
            get;
            set;

        }
        int Student_Qualification_General_ObtainedMark
        {
            get;
            set;

        }
        int Student_Qualification_General_OutOfMark
        {
            get;
            set;
        }
        string Student_Qualification_General_Region_Division_Board
        {
            get;
            set;
        }

        string Student_Qualification_General_NameofInstitution
        {
            get;
            set;
        }
        #endregion General Details
        #region SSC Details

        int Student_Qualification_SSC_MediumOfInstitution
        {
            get;
            set;

        }
        int Student_Qualification_SSC_MonthOfPassing
        {
            get;
            set;

        }
        int Student_Qualification_SSC_YearOfPassing
        {
            get;
            set;

        }
        string Student_Qualification_SSC_SingleAttempt
        {
            get;
            set;

        }
        int Student_Qualification_SSC_Percent
        {
            get;
            set;

        }
        int Student_Qualification_SSC_ObtainedMark
        {
            get;
            set;

        }
        int Student_Qualification_SSC_OutOfMark
        {
            get;
            set;
        }
        string Student_Qualification_SSC_Region_Division_Board
        {
            get;
            set;
        }

        string Student_Qualification_SSC_NameofInstitution
        {
            get;
            set;
        }

        #endregion SSC Details
        #region HSC Details
        int Student_Qualification_HSC_MediumOfInstitution
        {
            get;
            set;

        }
        int Student_Qualification_HSC_MonthOfPassing
        {
            get;
            set;

        }
        int Student_Qualification_HSC_YearOfPassing
        {
            get;
            set;

        }
        int Student_Qualification_HSC_StreamID
        {
            get;
            set;

        }
        string Student_Qualification_HSC_StreamOther
        {
            get;
            set;

        }
        string Student_Qualification_HSC_SingleAttempt
        {
            get;
            set;

        }
        string Student_Qualification_HSC_Class
        {
            get;
            set;

        }
        int Student_Qualification_HSC_ObtainedMark
        {
            get;
            set;

        }
        int Student_Qualification_HSC_OutOfMark
        {
            get;
            set;
        }
        int Student_Qualification_HSC_Percent
        {
            get;
            set;

        }

        int Student_Qualification_HSC_PCM_PVM_ObtainedMark
        {
            get;
            set;

        }
        int Student_Qualification_HSC_PCM_PVM_OutOfMark
        {
            get;
            set;
        }
        int Student_Qualification_HSC_PCB_ObtainedMark
        {
            get;
            set;

        }
        int Student_Qualification_HSC_PCB_OutOfMark
        {
            get;
            set;
        }
        string Student_Qualification_HSC_Region_Division_Board
        {
            get;
            set;
        }
        string Student_Qualification_HSC_NameofInstitution
        {
            get;
            set;
        }
        #endregion HSC Details
        #region Diploma / ITI Details
        int Student_Qualification_Diploma_ITI_Details_MediumOfInstitution
        {
            get;
            set;

        }
        int Student_Qualification_Diploma_ITI_Details_BranchId
        {
            get;
            set;

        }
        string Student_Qualification_Diploma_ITI_Details_BranchName
        {
            get;
            set;

        }
        string Student_Qualification_Diploma_ITI_Details_ExamPattern
        {
            get;
            set;

        }

        int Student_Qualification_Diploma_ITI_Details_MonthOfPassing
        {
            get;
            set;

        }
        int Student_Qualification_Diploma_ITI_Details_YearOfPassing
        {
            get;
            set;

        }
        string Student_Qualification_Diploma_ITI_Details_Class
        {
            get;
            set;

        }
        int Student_Qualification_Diploma_ITI_Details_ObtainedMark
        {
            get;
            set;

        }
        int Student_Qualification_Diploma_ITI_Details_OutOfMark
        {
            get;
            set;
        }
        int Student_Qualification_Diploma_ITI_Details_Percent
        {
            get;
            set;

        }
        string Student_Qualification_Diploma_ITI_Details_SingleAttempt
        {
            get;
            set;

        }
        string Student_Qualification_Diploma_ITI_Details_BoardEnrollmentNumber
        {
            get;
            set;

        }
        string Student_Qualification_Diploma_ITI_Details_NameofInstitution
        {
            get;
            set;

        }
        string Student_Qualification_Diploma_ITI_Details_Board
        {
            get;
            set;

        }
        int Student_Qualification_Diploma_ITI_Details_State
        {
            get;
            set;
        }
        string Student_Qualification_Diploma_ITI_Details_StateOther
        {
            get;
            set;
        }
        int Student_Qualification_Diploma_ITI_Details_CountryId
        {
            get;
            set;
        }
        #endregion Diploma / ITI Details

        #region Degree Details
        int Student_Qualification_DegreeDetails_MediumOfInstitution
        {
            get;
            set;

        }
        int Student_Qualification_DegreeDetails_BranchId
        {
            get;
            set;

        }
        string Student_Qualification_DegreeDetails_BranchName
        {
            get;
            set;

        }
        string Student_Qualification_DegreeDetails_ExamPattern
        {
            get;
            set;

        }

        int Student_Qualification_DegreeDetails_MonthOfPassing
        {
            get;
            set;

        }
        int Student_Qualification_DegreeDetails_YearOfPassing
        {
            get;
            set;

        }
        string Student_Qualification_DegreeDetails_Class
        {
            get;
            set;

        }
        int Student_Qualification_DegreeDetails_ObtainedMark
        {
            get;
            set;

        }
        int Student_Qualification_DegreeDetails_OutOfMark
        {
            get;
            set;
        }
        int Student_Qualification_DegreeDetails_Percent
        {
            get;
            set;

        }
        string Student_Qualification_DegreeDetails_SingleAttempt
        {
            get;
            set;

        }
        string Student_Qualification_DegreeDetails_BoardEnrollmentNumber
        {
            get;
            set;

        }
        string Student_Qualification_DegreeDetails_NameofInstitution
        {
            get;
            set;

        }
        int Student_Qualification_DegreeDetails_UniversityId
        {
            get;
            set;

        }
        string Student_Qualification_DegreeDetails_UniversityName
        {
            get;
            set;

        }
        int Student_Qualification_DegreeDetails_State
        {
            get;
            set;
        }

        string Student_Qualification_DegreeDetails_Degree
        {
            get;
            set;

        }
        string Student_Qualification_DegreeDetails_StateOther
        {
            get;
            set;
        }

        int Student_Qualification_DegreeDetails_CountryId
        {
            get;
            set;
        }
        #endregion Degree Details

        #region Post Graduation Details
        int Student_Qualification_PostGraduationDetails_MediumOfInstitution
        {
            get;
            set;

        }
        int Student_Qualification_PostGraduationDetails_BranchId
        {
            get;
            set;

        }
        string Student_Qualification_PostGraduationDetails_BranchName
        {
            get;
            set;

        }
        string Student_Qualification_PostGraduationDetails_ExamPattern
        {
            get;
            set;

        }

        int Student_Qualification_PostGraduationDetails_MonthOfPassing
        {
            get;
            set;

        }
        int Student_Qualification_PostGraduationDetails_YearOfPassing
        {
            get;
            set;

        }
        string Student_Qualification_PostGraduationDetails_Class
        {
            get;
            set;

        }
        int Student_Qualification_PostGraduationDetails_ObtainedMark
        {
            get;
            set;

        }
        int Student_Qualification_PostGraduationDetails_OutOfMark
        {
            get;
            set;
        }
        int Student_Qualification_PostGraduationDetails_Percent
        {
            get;
            set;

        }
        string Student_Qualification_PostGraduationDetails_SingleAttempt
        {
            get;
            set;

        }
        string Student_Qualification_PostGraduationDetails_BoardEnrollmentNumber
        {
            get;
            set;

        }
        string Student_Qualification_PostGraduationDetails_NameofInstitution
        {
            get;
            set;

        }
        int Student_Qualification_PostGraduationDetails_UniversityId
        {
            get;
            set;

        }
        string Student_Qualification_PostGraduationDetails_UniversityName
        {
            get;
            set;

        }
        int Student_Qualification_PostGraduationDetails_State
        {
            get;
            set;
        }
        string Student_Qualification_PostGraduationDetails_StateOther
        {
            get;
            set;
        }
        string Student_Qualification_PostGraduationDetails_PostGraduation
        {
            get;
            set;

        }

        int Student_Qualification_PostGraduationDetails_CountryId
        {
            get;
            set;
        }

        #endregion Post Graduation Details
        #endregion Qualification Details

        # region DTE & Scholarship Information

        # region DTE  Information
        string Student_DTE_DTEUserID
        {
            get;
            set;
        }
        string Student_DTE_DTEPassword
        {
            get;
            set;
        }
        string Student_DTE_DTESrNo
        {
            get;
            set;
        }
        string Student_DTE_DTEMeritNo
        {
            get;
            set;
        }
        int Student_DTE_AdmissionTypeId
        {
            get;
            set;
        }

        int Student_DTE_AdmissionRound
        {
            get;
            set;
        }
        int Student_DTE_AdmissionCategoryId
        {
            get;
            set;
        }
        string Student_DTE_DTESeatNo
        {
            get;
            set;
        }

        int Student_DTE_QualifyingExamId
        {
            get;
            set;
        }
        string Student_DTE_QualifyingExamName
        {
            get;
            set;
        }
        int Student_DTE_QualifyingExamMarks
        {
            get;
            set;
        }
        # endregion DTE  Information

        # region  Scholarship Information
        string Student_Scholarship_ScholarshipId
        {
            get;
            set;
        }
        string Student_Scholarship_ScholarshipType
        {
            get;
            set;
        }
        int Student_Scholarship_CastCategoryId
        {
            get;
            set;
        }
        string Student_Scholarship_CastCategoryOther
        {
            get;
            set;
        }
        string Student_Scholarship_AadhaarCardNo
        {
            get;
            set;
        }
        double Student_Scholarship_AnnualIncome
        {
            get;
            set;
        }
        int Student_Scholarship_NoofSibling
        {
            get;
            set;
        }
        int Student_Scholarship_ChildNoOutofSibling
        {
            get;
            set;
        }
        string Student_Scholarship_HostelDayScholar
        {
            get;
            set;
        }
        string Student_Scholarship_Bank_BranchName
        {
            get;
            set;
        }
        string Student_Scholarship_Bank_AC_No
        {
            get;
            set;
        }
        string Student_Scholarship_Bank_IFSCCode
        {
            get;
            set;
        }
        string Student_Scholarship_Bank_MICRCode
        {
            get;
            set;
        }
        # endregion Scholarship Information
        # endregion DTE & Scholarship Information

        #region Student Documents Information
        #region Admission Documents Information
        bool Student_AdmissionDocuments_JETMarkSheet
        {
            get;
            set;
        }
        bool Student_AdmissionDocuments_AllotmentLetter
        {
            get;
            set;
        }
        bool Student_AdmissionDocuments_TenthMarkSheet
        {
            get;
            set;
        }
        bool Student_AdmissionDocuments_TwelvethMarkSheet
        {
            get;
            set;
        }
        bool Student_AdmissionDocuments_AllDiplomaMarksheet
        {
            get;
            set;
        }
        bool Student_AdmissionDocuments_LeavingCertificate
        {
            get;
            set;
        }

        bool Student_AdmissionDocuments_Domicile_BirthCertificate
        {
            get;
            set;
        }
        bool Student_AdmissionDocuments_NationalityCertificate
        {
            get;
            set;
        }
        bool Student_AdmissionDocuments_CasteCertificate
        {
            get;
            set;
        }
        bool Student_AdmissionDocuments_CasteValidityCertificate
        {
            get;
            set;
        }
        bool Student_AdmissionDocuments_NonCreamylayerCertificate
        {
            get;
            set;
        }

        bool Student_AdmissionDocuments_EquivalenceCertificate
        {
            get;
            set;
        }
        bool Student_AdmissionDocuments_MigrationCertificate
        {
            get;
            set;
        }
        bool Student_AdmissionDocuments_GapCertificate
        {
            get;
            set;
        }
        bool Student_AdmissionDocuments_AntiRaggingAffidavit
        {
            get;
            set;
        }
        bool Student_AdmissionDocuments_Proforma_Fand_F1_On_DoctorsLetter_Head
        {
            get;
            set;
        }
        bool Student_AdmissionDocuments_Proforma_I
        {
            get;
            set;
        }
        bool Student_AdmissionDocuments_ProformaG1
        {
            get;
            set;
        }
        bool Student_AdmissionDocuments_ProformaG2
        {
            get;
            set;
        }
        bool Student_AdmissionDocuments_Proforma_C_D_E
        {
            get;
            set;
        }
        bool Student_AdmissionDocuments_FathersIncomeCertificate
        {
            get;
            set;
        }
        bool Student_AdmissionDocuments_AadharCardXerox
        {
            get;
            set;
        }
        bool Student_AdmissionDocuments_B_WPhoto_I_card_size
        {
            get;
            set;
        }
        bool Student_AdmissionDocuments_Colour_photo
        {
            get;
            set;
        }
        string StudentSubmitedDocumentFlagIDs
        {
            get;
            set;
        }

        string StudentSubmitedDocumentIDs
        {
            get;
            set;
        }

        #region Admission Documents Information
        #endregion Admission Documents Information
        #region For PG Students
        bool Student_AdmissionDocuments_PGStudents_DegreeMarksheet
        {
            get;
            set;
        }
        bool Student_AdmissionDocuments_PGStudents_DegreeCertificate
        {
            get;
            set;
        }
        bool Student_AdmissionDocuments_PGStudents_GateScoreCard
        {
            get;
            set;
        }
        bool Student_AdmissionDocuments_PGStudents_SponsorshipLetterforSponsoredCandidate
        {
            get;
            set;
        }
        #endregion For PG Students
        #region Comments
        string Student_AdmissionDocuments_Comments
        {
            get;
            set;
        }
        #endregion Comments
        #endregion Admission Documents Information

        #region Scholarship Documents Information
        #region Scholarship Documents Information
        bool Student_ScholarshipDocuments_IncomeCertificateOriginal
        {
            get;
            set;
        }
        bool Student_ScholarshipDocuments_TenthMarkSheet
        {
            get;
            set;
        }
        bool Student_ScholarshipDocuments_TwelvethMarkSheet
        {
            get;
            set;
        }
        bool Student_ScholarshipDocuments_AdharCard
        {
            get;
            set;
        }
        bool Student_ScholarshipDocuments_AdmissionConfirmationLetter
        {
            get;
            set;
        }
        bool Student_ScholarshipDocuments_AllotmentLetter
        {
            get;
            set;
        }
        bool Student_ScholarshipDocuments_BankPassBookXerox
        {
            get;
            set;
        }
        bool Student_ScholarshipDocuments_CastCertificate
        {
            get;
            set;
        }

        bool Student_ScholarshipDocuments_CastValidity
        {
            get;
            set;
        }
        bool Student_ScholarshipDocuments_Domicile
        {
            get;
            set;
        }
        bool Student_ScholarshipDocuments_Receipt
        {
            get;
            set;
        }
        bool Student_ScholarshipDocuments_GateScoreCard
        {
            get;
            set;
        }
        bool Student_ScholarshipDocuments_HandicapCertificate
        {
            get;
            set;
        }
        bool Student_ScholarshipDocuments_Icardsizephoto
        {
            get;
            set;
        }
        bool Student_ScholarshipDocuments_IDProof
        {
            get;
            set;
        }
        bool Student_ScholarshipDocuments_IncomeAffidavitOriginal
        {
            get;
            set;
        }
        bool Student_ScholarshipDocuments_JEEMainScoreCard
        {
            get;
            set;
        }
        bool Student_ScholarshipDocuments_Leavingcertificate
        {
            get;
            set;
        }
        bool Student_ScholarshipDocuments_ParentsFromNo16
        {
            get;
            set;
        }
        bool Student_ScholarshipDocuments_LastYearMarksheet
        {
            get;
            set;
        }
        bool Student_ScholarshipDocuments_RationCard
        {
            get;
            set;
        }
        bool Student_ScholarshipDocuments_MHCETScoreCard
        {
            get;
            set;
        }
        bool Student_ScholarshipDocuments_LastCollegeletterAboutScholarshipOriginal
        {
            get;
            set;
        }
        bool Student_ScholarshipDocuments_Colourphoto
        {
            get;
            set;
        }
        #endregion Scholarship Documents Information
        #region If Applicable
        bool Student_ScholarshipDocuments_IfApplicable_NonCreamylayer
        {
            get;
            set;
        }
        bool Student_ScholarshipDocuments_IfApplicable_DeathcertificateFatherMother
        {
            get;
            set;
        }
        bool Student_ScholarshipDocuments_IfApplicable_DisabilityAbilityCertificate
        {
            get;
            set;
        }
        bool Student_ScholarshipDocuments_IfApplicable_GapCertificate
        {
            get;
            set;
        }
        #endregion If Applicable
        #region Comments
        string Student_ScholarshipDocuments_Comments
        {
            get;
            set;
        }
        #endregion Comments
        #endregion Scholarship Documents Information

        #endregion Student Documents Information


        #region Subject IDs
        string QualifyingExamSubjectDetailsIDs
        {
            get;
            set;
        }
        string QualificationExamSubjectGeneralDetailsIDs
        {
            get;
            set;
        }
        string QualificationExamSubjectSSCDetailsIDs
        {
            get;
            set;
        }
        string QualificationExamSubjectHSCDetailsIDs
        {
            get;
            set;
        }
        #endregion Subject IDs


        #region Table Name
        bool StuRegistrationStudentPhotoSignThumb
        {
            get;
            set;
        }
        bool StuRegistrationStudentSocialReservationInformation
        {
            get;
            set;
        }
        bool StuRegistrationOtherInfoOfStudent
        {
            get;
            set;
        }

        bool stuRegistrationAddressDetails
        {
            get;
            set;
        }

        bool StuRegistrationPreQualificationSchoolTransaction
        {
            get;
            set;
        }

        bool StuRegistrationPreQualificationSchoolSubjectDetail
        {
            get;
            set;
        }

        bool StuRegistrationPreEntranceExaminationTransaction
        {
            get;
            set;
        }

        bool StuRegistrationPreEntranceExaminationSubjectDetail
        {
            get;
            set;
        }

        bool StuRegistrationPreQualificationCollegeTransaction
        {
            get;
            set;
        }
        bool StuRegistrationQualifyingSelectionInfo
        {
            get;
            set;
        }
        bool StuRegistrationDocumentSubmitted
        {
            get;
            set;
        }
        #endregion Table Name

        bool IsDeleted
        {
            get;
            set;
        }

        int CreatedBy
        {
            get;
            set;
        }

        DateTime CreatedDate
        {
            get;
            set;
        }

        int? ModifiedBy
        {
            get;
            set;
        }

        DateTime? ModifiedDate
        {
            get;
            set;
        }

        int? DeletedBy
        {
            get;
            set;
        }

        DateTime? DeletedDate
        {
            get;
            set;
        }
        string errorMessage { get; set; }

        #region Task Approval Fields
        string TaskCode
        {
            get;
            set;
        }
        int TaskNotificationDetailsID
        {
            get;
            set;
        }
        int TaskNotificationMasterID
        {
            get;
            set;
        }
        int GeneralTaskReportingDetailsID
        {
            get;
            set;
        }
        int PersonID
        {
            get;
            set;
        }
        int StageSequenceNumber
        {
            get;
            set;
        }
        bool IsLastRecord
        {
            get;
            set;
        }
        #endregion
    }
}
