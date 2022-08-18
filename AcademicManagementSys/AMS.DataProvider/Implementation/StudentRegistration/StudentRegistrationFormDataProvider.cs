using AMS.Base.DTO;
using AMS.DTO;
using AMS.ExceptionManager;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
namespace AMS.DataProvider
{
    public class StudentRegistrationFormDataProvider : DBInteractionBase, IStudentRegistrationFormDataProvider
    {
        #region Variable Declaration
        private readonly string _connectionString;
        private readonly ILogger _logException;
        #endregion
        #region Constructor
        /// <summary>
        /// Constructor to initialized data member and member functions
        /// </summary>
        public StudentRegistrationFormDataProvider()
        {
        }
        /// <summary>
        /// Constructor to initialized data member and member functions
        /// </summary>
        /// <param name="logException"></param>
        public StudentRegistrationFormDataProvider(ILogger logException)
        {
            _connectionString = ""; //ConfigurationManager.ConnectionStrings["AMSEntities"].ToString();
            _logException = logException; // This should fix later
        }
        #endregion
        #region Method Implementation
        /// <summary>
        /// Create new record of the table
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<StudentRegistrationForm> InsertStudentRegistrationForm(StudentRegistrationForm item)
        {
            IBaseEntityResponse<StudentRegistrationForm> response = new BaseEntityResponse<StudentRegistrationForm>();
            SqlCommand cmdToExecute = new SqlCommand();
            SqlCommand cmdToExecute1 = new SqlCommand();
            SqlCommand cmdToExecute2 = new SqlCommand();
            SqlCommand cmdToExecute3 = new SqlCommand();
            SqlCommand cmdToExecute4 = new SqlCommand();
            SqlCommand cmdToExecute5 = new SqlCommand();
            SqlCommand cmdToExecute6 = new SqlCommand();
            SqlCommand cmdToExecute7 = new SqlCommand();
            SqlCommand cmdToExecute8 = new SqlCommand();
            SqlCommand cmdToExecute9 = new SqlCommand();
            SqlCommand cmdToExecute10 = new SqlCommand();
            SqlCommand cmdToExecute11 = new SqlCommand();
            SqlCommand cmdToExecute12 = new SqlCommand();
            SqlCommand cmdToExecute13 = new SqlCommand();
            SqlCommand cmdToExecute14 = new SqlCommand();
            SqlCommand cmdToExecute15 = new SqlCommand();
            SqlCommand cmdToExecute16 = new SqlCommand();
            SqlCommand cmdToExecute17 = new SqlCommand();
            SqlCommand cmdToExecute18 = new SqlCommand();
            SqlCommand cmdToExecute19 = new SqlCommand();
            SqlCommand cmdToExecute20 = new SqlCommand();
            SqlCommand cmdToExecute21 = new SqlCommand();
            SqlCommand cmdToExecute22 = new SqlCommand();
            SqlCommand cmdToExecute23 = new SqlCommand();
            SqlCommand cmdToExecute24 = new SqlCommand();
            SqlCommand cmdToExecute25 = new SqlCommand();
            SqlCommand cmdToExecute26 = new SqlCommand();
            SqlTransaction transaction = null;


            try
            {
                if (string.IsNullOrEmpty(item.ConnectionString))
                {
                    response.Message.Add(new MessageDTO()
                    {
                        ErrorMessage = "Connection string is empty.",
                        MessageType = MessageTypeEnum.Error
                    });
                }
                else
                {
                    _mainConnection.ConnectionString = item.ConnectionString;
                    cmdToExecute.Connection = _mainConnection;
                    cmdToExecute1.Connection = _mainConnection;
                    cmdToExecute2.Connection = _mainConnection;
                    cmdToExecute3.Connection = _mainConnection;
                    cmdToExecute4.Connection = _mainConnection;
                    cmdToExecute5.Connection = _mainConnection;
                    cmdToExecute6.Connection = _mainConnection;
                    cmdToExecute7.Connection = _mainConnection;
                    cmdToExecute8.Connection = _mainConnection;
                    cmdToExecute9.Connection = _mainConnection;
                    cmdToExecute10.Connection = _mainConnection;
                    cmdToExecute11.Connection = _mainConnection;
                    cmdToExecute12.Connection = _mainConnection;
                    cmdToExecute13.Connection = _mainConnection;
                    cmdToExecute14.Connection = _mainConnection;
                    cmdToExecute15.Connection = _mainConnection;
                    cmdToExecute16.Connection = _mainConnection;
                    cmdToExecute17.Connection = _mainConnection;
                    cmdToExecute18.Connection = _mainConnection;
                    cmdToExecute19.Connection = _mainConnection;
                    cmdToExecute20.Connection = _mainConnection;
                    cmdToExecute21.Connection = _mainConnection;
                    cmdToExecute22.Connection = _mainConnection;
                    cmdToExecute23.Connection = _mainConnection;
                    cmdToExecute24.Connection = _mainConnection;
                    cmdToExecute25.Connection = _mainConnection;
                    cmdToExecute26.Connection = _mainConnection;


                    #region USP_StuWebStudentRegistration_Insert

                    cmdToExecute.CommandText = "dbo.USP_StuRegistrationStudentMaster_Insert";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 10, ParameterDirection.Output, false, 0, 0, "", DataRowVersion.Proposed, item.ID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@daDateOfRegistration", SqlDbType.DateTime, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsTitle", SqlDbType.NVarChar, 0, ParameterDirection.Input, false, 20, 0, "", DataRowVersion.Proposed, item.StudentTitle));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsFirstName", SqlDbType.NVarChar, 0, ParameterDirection.Input, false, 50, 0, "", DataRowVersion.Proposed, item.StudentFirstName));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsMiddleName", SqlDbType.NVarChar, 0, ParameterDirection.Input, false, 50, 0, "", DataRowVersion.Proposed, (item.StudentMiddleName != null) ? item.StudentMiddleName : string.Empty));
                    if (item.StudentLastName != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsLastName", SqlDbType.NVarChar, 0, ParameterDirection.Input, false, 50, 0, "", DataRowVersion.Proposed, item.StudentLastName));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsLastName", SqlDbType.NVarChar, 0, ParameterDirection.Input, false, 50, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.MotherFirstName != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsMotherName", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, item.MotherFirstName));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsMotherName", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    //  cmdToExecute.Parameters.Add(new SqlParameter("@sStudentOccupation", SqlDbType.VarChar, 0, ParameterDirection.Input, false, 50, 0, "", DataRowVersion.Proposed, item.StudentOccupation));
                    if (item.MotherFirstName != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsStudentMobileNumber", SqlDbType.NVarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.StudentMobileNumber));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsStudentMobileNumber", SqlDbType.NVarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.FatherMobileNumber != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsParentMobileNumber", SqlDbType.NVarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.FatherMobileNumber));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsParentMobileNumber", SqlDbType.NVarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.GuardianMobileNumber != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsGuardianMobileNumber", SqlDbType.NVarChar, 0, ParameterDirection.Input, false, 15, 0, "", DataRowVersion.Proposed, item.GuardianMobileNumber));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsGuardianMobileNumber", SqlDbType.NVarChar, 0, ParameterDirection.Input, false, 15, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.FatherLandLineNumber != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsParentLandlineNumber", SqlDbType.NVarChar, 0, ParameterDirection.Input, false, 15, 0, "", DataRowVersion.Proposed, item.FatherLandLineNumber));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsParentLandlineNumber", SqlDbType.NVarChar, 0, ParameterDirection.Input, false, 15, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.FatherEmailId != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@sParentEmailID", SqlDbType.VarChar, 0, ParameterDirection.Input, false, 50, 0, "", DataRowVersion.Proposed, item.FatherEmailId));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@sParentEmailID", SqlDbType.VarChar, 0, ParameterDirection.Input, false, 50, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.GuardianEmailId != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@sGuardianEmailID", SqlDbType.VarChar, 0, ParameterDirection.Input, false, 50, 0, "", DataRowVersion.Proposed, item.GuardianEmailId));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@sGuardianEmailID", SqlDbType.VarChar, 0, ParameterDirection.Input, false, 50, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.FatherEmailId != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@sFatherEmailID", SqlDbType.VarChar, 0, ParameterDirection.Input, false, 50, 0, "", DataRowVersion.Proposed, item.FatherEmailId));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@sFatherEmailID", SqlDbType.VarChar, 0, ParameterDirection.Input, false, 50, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.MotherEmailId != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@sMotherEmailID", SqlDbType.VarChar, 0, ParameterDirection.Input, false, 50, 0, "", DataRowVersion.Proposed, item.MotherEmailId));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@sMotherEmailID", SqlDbType.VarChar, 0, ParameterDirection.Input, false, 50, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.StudentEmailID != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@sStudentEmailID", SqlDbType.VarChar, 0, ParameterDirection.Input, false, 50, 0, "", DataRowVersion.Proposed, item.StudentEmailID));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@sStudentEmailID", SqlDbType.VarChar, 0, ParameterDirection.Input, false, 50, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.StudentNameAsPerMarkSheet != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsNameAsPerLeaving", SqlDbType.NVarChar, 0, ParameterDirection.Input, false, 50, 0, "", DataRowVersion.Proposed, item.StudentNameAsPerMarkSheet));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsNameAsPerLeaving", SqlDbType.NVarChar, 0, ParameterDirection.Input, false, 50, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.StudentLastSchool_College != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@sLastSchoolCollegeAttend", SqlDbType.VarChar, 0, ParameterDirection.Input, false, 50, 0, "", DataRowVersion.Proposed, item.StudentLastSchool_College));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@sLastSchoolCollegeAttend", SqlDbType.VarChar, 0, ParameterDirection.Input, false, 50, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.StudentPreviousLC_TCNo != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsPreviousLeavingNumber", SqlDbType.NVarChar, 0, ParameterDirection.Input, false, 50, 0, "", DataRowVersion.Proposed, item.StudentPreviousLC_TCNo));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsPreviousLeavingNumber", SqlDbType.NVarChar, 0, ParameterDirection.Input, false, 50, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.StudentCasteAsPerTC_LC != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsCastAsPerLeaving", SqlDbType.NVarChar, 0, ParameterDirection.Input, false, 50, 0, "", DataRowVersion.Proposed, item.StudentCasteAsPerTC_LC));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsCastAsPerLeaving", SqlDbType.NVarChar, 0, ParameterDirection.Input, false, 50, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.StudentEnrollmentNo != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsCurrentEnrollmentNumber", SqlDbType.NVarChar, 0, ParameterDirection.Input, false, 50, 0, "", DataRowVersion.Proposed, item.StudentEnrollmentNo));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsCurrentEnrollmentNumber", SqlDbType.NVarChar, 0, ParameterDirection.Input, false, 50, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }

                    cmdToExecute.Parameters.Add(new SqlParameter("@siDomicileStateID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.StudentRegionID));
                    if (item.StudentRegionOther != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsDomicileStateOther", SqlDbType.NVarChar, 0, ParameterDirection.Input, false, 50, 0, "", DataRowVersion.Proposed, item.StudentRegionOther));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsDomicileStateOther", SqlDbType.NVarChar, 0, ParameterDirection.Input, false, 50, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    cmdToExecute.Parameters.Add(new SqlParameter("@siDomicileCountryID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_Domesile_CountryId));
                    if (item.StudentMigrationNumber != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsMigrationNumber", SqlDbType.NVarChar, 0, ParameterDirection.Input, false, 50, 0, "", DataRowVersion.Proposed, item.StudentMigrationNumber));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsMigrationNumber", SqlDbType.NVarChar, 0, ParameterDirection.Input, false, 50, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.StudentMigrationDate != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@daMigrationDatetime", SqlDbType.DateTime, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Convert.ToDateTime(item.StudentMigrationDate)));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@daMigrationDatetime", SqlDbType.DateTime, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.Student_DTE_AdmissionCategoryId != 0)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@iAdmissionCategoryID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_DTE_AdmissionCategoryId));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@iAdmissionCategoryID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.StudentCategoryID));
                    }
                    if (item.Student_DTE_AdmissionTypeId != 0)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@iAdmissionTypeID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_DTE_AdmissionTypeId));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@iAdmissionTypeID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, 1));
                    }
                    if (item.Student_Scholarship_HostelDayScholar == "0")
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@bIsHostelResidency", SqlDbType.Bit, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, false));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@bIsHostelResidency", SqlDbType.Bit, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, true));

                    }

                    cmdToExecute.Parameters.Add(new SqlParameter("@iBranchDetailID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.BranchDetailID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iStandardNumber", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.StandardNumber));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iAdmissionPatternID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.AdmissionPattern));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bStudentActiveFlag ", SqlDbType.Bit, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.StudentActiveFlag));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iAcademicYearID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_AcademicYearId));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsCentreCode", SqlDbType.NVarChar, 0, ParameterDirection.Input, false, 50, 0, "", DataRowVersion.Proposed, item.CenterCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iUniversityID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.UniversityID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iCourseYearId", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_CourseYearId));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iSelfRegistrationID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.StudentSelfRegistrationID));
                    if (item.StudentNRI_POI != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsNriPoi", SqlDbType.NVarChar, 0, ParameterDirection.Input, false, 50, 0, "", DataRowVersion.Proposed, item.StudentNRI_POI));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsNriPoi", SqlDbType.NVarChar, 0, ParameterDirection.Input, false, 50, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    cmdToExecute.Parameters.Add(new SqlParameter("@iAllotAdmThrough", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_DTE_AdmissionRound));
                    if (item.Student_Scholarship_Bank_AC_No != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@sBankAccountNumber", SqlDbType.VarChar, 0, ParameterDirection.Input, false, 50, 0, "", DataRowVersion.Proposed, item.Student_Scholarship_Bank_AC_No));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@sBankAccountNumber", SqlDbType.VarChar, 0, ParameterDirection.Input, false, 50, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.Student_Scholarship_Bank_BranchName != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsBankBranchName", SqlDbType.VarChar, 0, ParameterDirection.Input, false, 50, 0, "", DataRowVersion.Proposed, item.Student_Scholarship_Bank_BranchName));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsBankBranchName", SqlDbType.VarChar, 0, ParameterDirection.Input, false, 50, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.Student_Scholarship_Bank_IFSCCode != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsBankIFSCCode", SqlDbType.VarChar, 0, ParameterDirection.Input, false, 20, 0, "", DataRowVersion.Proposed, item.Student_Scholarship_Bank_IFSCCode));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsBankIFSCCode", SqlDbType.VarChar, 0, ParameterDirection.Input, false, 20, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.Student_Scholarship_Bank_MICRCode != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsBankMICRCode", SqlDbType.VarChar, 0, ParameterDirection.Input, false, 20, 0, "", DataRowVersion.Proposed, item.Student_Scholarship_Bank_MICRCode));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsBankMICRCode", SqlDbType.VarChar, 0, ParameterDirection.Input, false, 20, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.Student_Scholarship_AadhaarCardNo != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsUniqueIdentificatinNumber", SqlDbType.VarChar, 0, ParameterDirection.Input, false, 20, 0, "", DataRowVersion.Proposed, item.Student_Scholarship_AadhaarCardNo));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsUniqueIdentificatinNumber", SqlDbType.VarChar, 0, ParameterDirection.Input, false, 20, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.StudentBloodGroup != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@sBloodgroup", SqlDbType.VarChar, 5, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, item.StudentBloodGroup));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@sBloodgroup", SqlDbType.VarChar, 5, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.StudentOccupation != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsStudentOccupation", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.StudentOccupation));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsStudentOccupation", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.Student_QualifyingExamName != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsStudentQualifyingExam", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_QualifyingExamName));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsStudentQualifyingExam", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }

                    cmdToExecute.Parameters.Add(new SqlParameter("@sStudentAcademicYear", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_AcademicYear));

                    cmdToExecute.Parameters.Add(new SqlParameter("@sStudentAdmissionType", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_DTE_AdmissionTypeId));

                    cmdToExecute.Parameters.Add(new SqlParameter("@nsNameOfApplicant", SqlDbType.NVarChar, 40, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.NameOfApplicant));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsTitleOfProject", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.TitleOfProject));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsProjectSummary", SqlDbType.NVarChar, 250, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.ProjectSummary));
                    cmdToExecute.Parameters.Add(new SqlParameter("@tiFeesPaidBy", SqlDbType.TinyInt, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.FeesPaidBy));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iCreatedBy", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.StudentSelfRegistrationID));

                    if (_mainConnectionIsCreatedLocal)
                    {
                        // Open connection. 
                        _mainConnection.Open();
                    }
                    else
                    {
                        if (_mainConnectionProvider.IsTransactionPending)
                        {
                            cmdToExecute.Transaction = _mainConnectionProvider.CurrentTransaction;
                        }
                    }
                    // Execute query.
                    transaction = _mainConnection.BeginTransaction("SampleTransaction");
                    cmdToExecute.Transaction = transaction;
                    _rowsAffected = cmdToExecute.ExecuteNonQuery();
                    item.ID = (Int32)cmdToExecute.Parameters["@iID"].Value;


                    #endregion USP_StuWebStudentRegistration_Insert

                    #region USP_StuWebStudentPhotoSignThumb_Insert

                    cmdToExecute1.CommandText = "dbo.USP_StuRegistrationStudentPhotoSignThumb_Insert";
                    cmdToExecute1.CommandType = CommandType.StoredProcedure;

                    // cmdToExecute1.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 10, ParameterDirection.Output, false, 0, 0, "", DataRowVersion.Proposed, item.ID));
                    cmdToExecute1.Parameters.Add(new SqlParameter("@iStudentWebRegistrationID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.ID));
                    #region Photo
                    if (item.StudentPhoto != null)
                    {
                        cmdToExecute1.Parameters.Add(new SqlParameter("@sStudentPhoto", SqlDbType.VarBinary, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.StudentPhoto));
                    }
                    else
                    {
                        cmdToExecute1.Parameters.Add(new SqlParameter("@sStudentPhoto", SqlDbType.VarBinary, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.StudentPhotoFilename != null)
                    {
                        cmdToExecute1.Parameters.Add(new SqlParameter("@sStudentPhotoFilename", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.StudentPhotoFilename));
                    }
                    else
                    {
                        cmdToExecute1.Parameters.Add(new SqlParameter("@sStudentPhotoFilename", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.StudentPhotoType != null)
                    {
                        cmdToExecute1.Parameters.Add(new SqlParameter("@sStudentPhotoType", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.StudentPhotoType));
                    }
                    else
                    {
                        cmdToExecute1.Parameters.Add(new SqlParameter("@sStudentPhotoType", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.StudentPhotoFileWidth != null)
                    {
                        cmdToExecute1.Parameters.Add(new SqlParameter("@sStudentPhotoFileWidth", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.StudentPhotoFileWidth));
                    }
                    else
                    {
                        cmdToExecute1.Parameters.Add(new SqlParameter("@sStudentPhotoFileWidth", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.StudentPhotoFileHeight != null)
                    {
                        cmdToExecute1.Parameters.Add(new SqlParameter("@sStudentPhotoFileHeight", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.StudentPhotoFileHeight));
                    }
                    else
                    {
                        cmdToExecute1.Parameters.Add(new SqlParameter("@sStudentPhotoFileHeight", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.StudentPhotoFileHeight != null)
                    {
                        cmdToExecute1.Parameters.Add(new SqlParameter("@sStudentPhotoFileSize", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.StudentPhotoFileSize));
                    }
                    else
                    {
                        cmdToExecute1.Parameters.Add(new SqlParameter("@sStudentPhotoFileSize", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }

                    #endregion Photo
                    #region Signature
                    if (item.StudentSignature != null)
                    {
                        cmdToExecute1.Parameters.Add(new SqlParameter("@sStudentSignature", SqlDbType.VarBinary, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.StudentSignature));
                    }
                    else
                    {
                        cmdToExecute1.Parameters.Add(new SqlParameter("@sStudentSignature", SqlDbType.VarBinary, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.StudentSignatureFilename != null)
                    {
                        cmdToExecute1.Parameters.Add(new SqlParameter("@sStudentSignatureFilename", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.StudentSignatureFilename));
                    }
                    else
                    {
                        cmdToExecute1.Parameters.Add(new SqlParameter("@sStudentSignatureFilename", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.StudentSignatureType != null)
                    {
                        cmdToExecute1.Parameters.Add(new SqlParameter("@sStudentSignatureType", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.StudentSignatureType));
                    }
                    else
                    {
                        cmdToExecute1.Parameters.Add(new SqlParameter("@sStudentSignatureType", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.StudentSignatureFileWidth != null)
                    {
                        cmdToExecute1.Parameters.Add(new SqlParameter("@sStudentSignatureFileWidth", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.StudentSignatureFileWidth));
                    }
                    else
                    {
                        cmdToExecute1.Parameters.Add(new SqlParameter("@sStudentSignatureFileWidth", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.StudentSignatureFileHeight != null)
                    {
                        cmdToExecute1.Parameters.Add(new SqlParameter("@sStudentSignatureFileHeight", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.StudentSignatureFileHeight));
                    }
                    else
                    {
                        cmdToExecute1.Parameters.Add(new SqlParameter("@sStudentSignatureFileHeight", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.StudentSignatureFileHeight != null)
                    {
                        cmdToExecute1.Parameters.Add(new SqlParameter("@sStudentSignatureFileSize", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.StudentSignatureFileSize));
                    }
                    else
                    {
                        cmdToExecute1.Parameters.Add(new SqlParameter("@sStudentSignatureFileSize", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    #endregion Signature
                    #region Thumb
                    if (item.StudentThumb != null)
                    {
                        cmdToExecute1.Parameters.Add(new SqlParameter("@sStudentThumb", SqlDbType.VarBinary, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.StudentThumb));
                    }
                    else
                    {
                        cmdToExecute1.Parameters.Add(new SqlParameter("@sStudentThumb", SqlDbType.VarBinary, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.StudentThumbFilename != null)
                    {
                        cmdToExecute1.Parameters.Add(new SqlParameter("@sStudentThumbFilename", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.StudentThumbFilename));
                    }
                    else
                    {
                        cmdToExecute1.Parameters.Add(new SqlParameter("@sStudentThumbFilename", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.StudentThumbType != null)
                    {
                        cmdToExecute1.Parameters.Add(new SqlParameter("@sStudentThumbType", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.StudentThumbType));
                    }
                    else
                    {
                        cmdToExecute1.Parameters.Add(new SqlParameter("@sStudentThumbType", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.StudentThumbFileWidth != null)
                    {
                        cmdToExecute1.Parameters.Add(new SqlParameter("@sStudentThumbFileWidth", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.StudentThumbFileWidth));
                    }
                    else
                    {
                        cmdToExecute1.Parameters.Add(new SqlParameter("@sStudentThumbFileWidth", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.StudentThumbFileHeight != null)
                    {
                        cmdToExecute1.Parameters.Add(new SqlParameter("@sStudentThumbFileHeight", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.StudentThumbFileHeight));
                    }
                    else
                    {
                        cmdToExecute1.Parameters.Add(new SqlParameter("@sStudentThumbFileHeight", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.StudentThumbFileHeight != null)
                    {
                        cmdToExecute1.Parameters.Add(new SqlParameter("@sStudentThumbFileSize", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.StudentThumbFileSize));
                    }
                    else
                    {
                        cmdToExecute1.Parameters.Add(new SqlParameter("@sStudentThumbFileSize", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    #endregion Thumb
                    cmdToExecute1.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute1.Parameters.Add(new SqlParameter("@iCreatedBy", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.ID));

                    //transaction1 = _mainConnection.BeginTransaction("SampleTransaction");
                    cmdToExecute1.Transaction = transaction;
                    _rowsAffected = cmdToExecute1.ExecuteNonQuery();
                    #endregion USP_StuWebStudentPhotoSignThumb_Insert

                    #region USP_StuWebStudentPersonalDetails_Insert

                    cmdToExecute2.CommandText = "dbo.USP_StuRegistrationPersonalDetails_Insert";
                    cmdToExecute2.CommandType = CommandType.StoredProcedure;
                    cmdToExecute2.Parameters.Add(new SqlParameter("@iStudentRegistrationId", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.ID));
                    if (item.StudentDateofBirth != null)
                    {
                        cmdToExecute2.Parameters.Add(new SqlParameter("@daDateOfBirth", SqlDbType.DateTime, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.StudentDateofBirth));
                    }
                    else
                    {
                        cmdToExecute2.Parameters.Add(new SqlParameter("@daDateOfBirth", SqlDbType.DateTime, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.StudentBirthPlace != null)
                    {
                        cmdToExecute2.Parameters.Add(new SqlParameter("@nsBirthPlace", SqlDbType.VarChar, 20, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, item.StudentBirthPlace));
                    }
                    else
                    {
                        cmdToExecute2.Parameters.Add(new SqlParameter("@nsBirthPlace", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.StudentGender != null)
                    {
                        cmdToExecute2.Parameters.Add(new SqlParameter("@cGender", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.StudentGender));
                    }
                    else
                    {
                        cmdToExecute2.Parameters.Add(new SqlParameter("@cGender", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }


                    if (item.StudentMaritalStatus != null)
                    {
                        cmdToExecute2.Parameters.Add(new SqlParameter("@cMaritalStatus", SqlDbType.Char, 1, ParameterDirection.Input, false, 1, 0, "", DataRowVersion.Proposed, item.StudentMaritalStatus ));
                    }
                    else
                    {
                        cmdToExecute2.Parameters.Add(new SqlParameter("@cMaritalStatus", SqlDbType.Char, 1, ParameterDirection.Input, false, 1, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }                    
                    cmdToExecute2.Parameters.Add(new SqlParameter("@iNationalityId", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.StudentNationalityID));
                    cmdToExecute2.Parameters.Add(new SqlParameter("@iReligionId", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.StudentReligionID));
                    cmdToExecute2.Parameters.Add(new SqlParameter("@iLanguageId", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.StudentMotherTongueID));
                    cmdToExecute2.Parameters.Add(new SqlParameter("@iCategoryId", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.StudentCategoryID));
                    cmdToExecute2.Parameters.Add(new SqlParameter("@iCasteId", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.StudentCasteID));

                    if (item.StudentBloodGroup != null)
                    {
                        cmdToExecute2.Parameters.Add(new SqlParameter("@sBloodgroup", SqlDbType.VarChar, 5, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, item.StudentBloodGroup));
                    }
                    else
                    {
                        cmdToExecute2.Parameters.Add(new SqlParameter("@sBloodgroup", SqlDbType.VarChar, 5, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.StudentLandLineNumber != null)
                    {
                        cmdToExecute2.Parameters.Add(new SqlParameter("@nsLandLineNumber", SqlDbType.NVarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.StudentLandLineNumber));
                    }
                    else
                    {
                        cmdToExecute2.Parameters.Add(new SqlParameter("@nsLandLineNumber", SqlDbType.NVarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.StudentIdentificationMark != null)
                    {
                        cmdToExecute2.Parameters.Add(new SqlParameter("@nsIdentificationMark", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.StudentIdentificationMark));
                    }
                    else
                    {
                        cmdToExecute2.Parameters.Add(new SqlParameter("@nsIdentificationMark", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.StudentEmploymentSector != null)
                    {
                        cmdToExecute2.Parameters.Add(new SqlParameter("@nsEmploymentSector", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.StudentEmploymentSector));
                    }
                    else
                    {
                        cmdToExecute2.Parameters.Add(new SqlParameter("@nsEmploymentSector", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.StudentOccupation != null)
                    {
                        cmdToExecute2.Parameters.Add(new SqlParameter("@nsOccupation", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.StudentOccupation));
                    }
                    else
                    {
                        cmdToExecute2.Parameters.Add(new SqlParameter("@nsOccupation", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.StudentDesignation != null)
                    {
                        cmdToExecute2.Parameters.Add(new SqlParameter("@nsDesignation", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.StudentDesignation));
                    }
                    else
                    {
                        cmdToExecute2.Parameters.Add(new SqlParameter("@nsDesignation", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.StudentOrganizationName != null)
                    {
                        cmdToExecute2.Parameters.Add(new SqlParameter("@nsOrganizationName", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.StudentOrganizationName));
                    }
                    else
                    {
                        cmdToExecute2.Parameters.Add(new SqlParameter("@nsOrganizationName", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.StudentOfficeContactNo != null)
                    {
                        cmdToExecute2.Parameters.Add(new SqlParameter("@iOfficeContactNumber", SqlDbType.VarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.StudentOfficeContactNo));
                    }
                    else
                    {
                        cmdToExecute2.Parameters.Add(new SqlParameter("@iOfficeContactNumber", SqlDbType.VarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    cmdToExecute2.Parameters.Add(new SqlParameter("@iAnnualIncome", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.StudentAnnualIncome));
                    if (item.PhysicallyHandicapped == "0")
                    {
                        cmdToExecute2.Parameters.Add(new SqlParameter("@bIsHandicapped", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, false));
                    }
                    else
                    {
                        cmdToExecute2.Parameters.Add(new SqlParameter("@bIsHandicapped", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, true));

                    }
                    if (item.StudentOrgandonor == "0")
                    {
                        cmdToExecute2.Parameters.Add(new SqlParameter("@bIsOrganDoner", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, false));
                    }
                    else
                    {
                        cmdToExecute2.Parameters.Add(new SqlParameter("@bIsOrganDoner", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, true));

                    }
                    if (item.StudentPrevNameofStudent != null)
                    {
                        cmdToExecute2.Parameters.Add(new SqlParameter("@nsPreviousNameOfStudentIfChange", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.StudentPrevNameofStudent));
                    }
                    else
                    {
                        cmdToExecute2.Parameters.Add(new SqlParameter("@nsPreviousNameOfStudentIfChange", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.StudentReasonforNamechange != null)
                    {
                        cmdToExecute2.Parameters.Add(new SqlParameter("@nsReasonNameChange", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.StudentReasonforNamechange));
                    }
                    else
                    {
                        cmdToExecute2.Parameters.Add(new SqlParameter("@nsReasonNameChange", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.StudentEmploymentStatus == "0")
                    {
                        cmdToExecute2.Parameters.Add(new SqlParameter("@bEmploymentStatus", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, false));
                    }
                    else
                    {
                        cmdToExecute2.Parameters.Add(new SqlParameter("@bEmploymentStatus", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, true));

                    }

                    cmdToExecute2.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute2.Parameters.Add(new SqlParameter("@iCreatedBy", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.StudentSelfRegistrationID));

                    cmdToExecute2.Transaction = transaction;
                    _rowsAffected = cmdToExecute2.ExecuteNonQuery();



                    #endregion USP_StuWebStudentPersonalDetails_Insert

                    #region USP_StuWebParentPersonalInformation_Insert FOR Father

                    cmdToExecute3.CommandText = "dbo.USP_StuRegistrationParentPersonalInformation_Insert";
                    cmdToExecute3.CommandType = CommandType.StoredProcedure;

                    cmdToExecute3.Parameters.Add(new SqlParameter("@iStudentRegistrationId", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.ID));

                    if (item.FatherHusbondType != null)
                    {
                        cmdToExecute3.Parameters.Add(new SqlParameter("@nsEntityType", SqlDbType.NVarChar, 5, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.FatherHusbondType));
                    }
                    else
                    {
                        cmdToExecute3.Parameters.Add(new SqlParameter("@nsEntityType", SqlDbType.NVarChar, 5, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.FatherTitle != null)
                    {
                        cmdToExecute3.Parameters.Add(new SqlParameter("@nsTitle", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.FatherTitle));
                    }
                    else
                    {
                        cmdToExecute3.Parameters.Add(new SqlParameter("@nsTitle", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));

                    }
                    cmdToExecute3.Parameters.Add(new SqlParameter("@cGender", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, "M"));


                    if (item.FatherFirstName != null)
                    {
                        cmdToExecute3.Parameters.Add(new SqlParameter("@nsFirstName", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.FatherFirstName));
                    }
                    else
                    {
                        cmdToExecute3.Parameters.Add(new SqlParameter("@nsFirstName", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.FatherMiddleName != null)
                    {
                        cmdToExecute3.Parameters.Add(new SqlParameter("@nsMiddleName", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.FatherMiddleName));
                    }
                    else
                    {
                        cmdToExecute3.Parameters.Add(new SqlParameter("@nsMiddleName", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }

                    if (item.FatherLastName != null)
                    {
                        cmdToExecute3.Parameters.Add(new SqlParameter("@nsLastName", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.FatherLastName));
                    }
                    else
                    {
                        cmdToExecute3.Parameters.Add(new SqlParameter("@nsLastName", SqlDbType.NVarChar, 0, ParameterDirection.Input, false, 50, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.FatherEmailId != null)
                    {
                        cmdToExecute3.Parameters.Add(new SqlParameter("@sEmailID", SqlDbType.VarChar, 80, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, item.FatherEmailId));
                    }
                    else
                    {
                        cmdToExecute3.Parameters.Add(new SqlParameter("@sEmailID", SqlDbType.VarChar, 80, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.FatherMobileNumber != null)
                    {
                        cmdToExecute3.Parameters.Add(new SqlParameter("@nsMobileNumber", SqlDbType.VarChar, 15, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, item.FatherMobileNumber));
                    }
                    else
                    {
                        cmdToExecute3.Parameters.Add(new SqlParameter("@nsMobileNumber", SqlDbType.VarChar, 15, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }

                    if (item.StudentDomicileStateofFather != null)
                    {
                        cmdToExecute3.Parameters.Add(new SqlParameter("@nsDomicileState", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, item.StudentDomicileStateofFather));
                    }
                    else
                    {
                        cmdToExecute3.Parameters.Add(new SqlParameter("@nsDomicileState", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.FatherLandLineNumber != null)
                    {
                        cmdToExecute3.Parameters.Add(new SqlParameter("@nsLandlineNumber", SqlDbType.VarChar, 15, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, item.FatherLandLineNumber));
                    }
                    else
                    {
                        cmdToExecute3.Parameters.Add(new SqlParameter("@nsLandlineNumber", SqlDbType.VarChar, 15, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.FatherEmploymentSector != null)
                    {
                        cmdToExecute3.Parameters.Add(new SqlParameter("@nsEmploymentSector", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.FatherEmploymentSector));
                    }
                    else
                    {
                        cmdToExecute3.Parameters.Add(new SqlParameter("@nsEmploymentSector", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.FatherOccupation != null)
                    {
                        cmdToExecute3.Parameters.Add(new SqlParameter("@nsOccupation", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.FatherOccupation));
                    }
                    else
                    {
                        cmdToExecute3.Parameters.Add(new SqlParameter("@nsOccupation", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.FatherDesignation != null)
                    {
                        cmdToExecute3.Parameters.Add(new SqlParameter("@nsDesignation", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.FatherDesignation));
                    }
                    else
                    {
                        cmdToExecute3.Parameters.Add(new SqlParameter("@nsDesignation", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.FatherOrganizationName != null)
                    {
                        cmdToExecute3.Parameters.Add(new SqlParameter("@nsOrganizationName", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.FatherOrganizationName));
                    }
                    else
                    {
                        cmdToExecute3.Parameters.Add(new SqlParameter("@nsOrganizationName", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.FatherOfficeContactNo != null)
                    {
                        cmdToExecute3.Parameters.Add(new SqlParameter("@iOfficeContactNumber", SqlDbType.VarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.FatherOfficeContactNo));
                    }
                    else
                    {
                        cmdToExecute3.Parameters.Add(new SqlParameter("@iOfficeContactNumber", SqlDbType.VarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    cmdToExecute3.Parameters.Add(new SqlParameter("@iAnnualIncome", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.FatherAnnualIncome));

                    cmdToExecute3.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute3.Parameters.Add(new SqlParameter("@iCreatedBy", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.StudentSelfRegistrationID));

                    cmdToExecute3.Transaction = transaction;
                    _rowsAffected = cmdToExecute3.ExecuteNonQuery();
                    #endregion USP_StuWebParentPersonalInformation_Insert FOR Father

                    #region USP_StuWebParentPersonalInformation_Insert FOR Mother

                    cmdToExecute4.CommandText = "dbo.USP_StuRegistrationParentPersonalInformation_Insert";
                    cmdToExecute4.CommandType = CommandType.StoredProcedure;

                    cmdToExecute4.Parameters.Add(new SqlParameter("@iStudentRegistrationId", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.ID));
                    cmdToExecute4.Parameters.Add(new SqlParameter("@nsEntityType", SqlDbType.NVarChar, 5, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, "M"));
                    if (item.MotherTitle != null)
                    {
                        cmdToExecute4.Parameters.Add(new SqlParameter("@nsTitle", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.MotherTitle));
                    }
                    else
                    {
                        cmdToExecute4.Parameters.Add(new SqlParameter("@nsTitle", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }

                    cmdToExecute4.Parameters.Add(new SqlParameter("@cGender", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, "F"));


                    if (item.MotherFirstName != null)
                    {
                        cmdToExecute4.Parameters.Add(new SqlParameter("@nsFirstName", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.MotherFirstName));
                    }
                    else
                    {
                        cmdToExecute4.Parameters.Add(new SqlParameter("@nsFirstName", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.MotherMiddleName != null)
                    {
                        cmdToExecute4.Parameters.Add(new SqlParameter("@nsMiddleName", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.MotherMiddleName));
                    }
                    else
                    {
                        cmdToExecute4.Parameters.Add(new SqlParameter("@nsMiddleName", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }

                    if (item.MotherLastName != null)
                    {
                        cmdToExecute4.Parameters.Add(new SqlParameter("@nsLastName", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.MotherLastName));
                    }
                    else
                    {
                        cmdToExecute4.Parameters.Add(new SqlParameter("@nsLastName", SqlDbType.NVarChar, 0, ParameterDirection.Input, false, 50, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.MotherEmailId != null)
                    {
                        cmdToExecute4.Parameters.Add(new SqlParameter("@sEmailID", SqlDbType.VarChar, 80, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, item.MotherEmailId));
                    }
                    else
                    {
                        cmdToExecute4.Parameters.Add(new SqlParameter("@sEmailID", SqlDbType.VarChar, 80, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.MotherMobileNumber != null)
                    {
                        cmdToExecute4.Parameters.Add(new SqlParameter("@nsMobileNumber", SqlDbType.VarChar, 15, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, item.MotherMobileNumber));
                    }
                    else
                    {
                        cmdToExecute4.Parameters.Add(new SqlParameter("@nsMobileNumber", SqlDbType.VarChar, 15, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }

                    if (item.StudentDomicileStateofMother != null)
                    {
                        cmdToExecute4.Parameters.Add(new SqlParameter("@nsDomicileState", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, item.StudentDomicileStateofMother));
                    }
                    else
                    {
                        cmdToExecute4.Parameters.Add(new SqlParameter("@nsDomicileState", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.MotherLandLineNumber != null)
                    {
                        cmdToExecute4.Parameters.Add(new SqlParameter("@nsLandlineNumber", SqlDbType.VarChar, 15, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, item.MotherLandLineNumber));
                    }
                    else
                    {
                        cmdToExecute4.Parameters.Add(new SqlParameter("@nsLandlineNumber", SqlDbType.VarChar, 15, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.MotherEmploymentSector != null)
                    {
                        cmdToExecute4.Parameters.Add(new SqlParameter("@nsEmploymentSector", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.MotherEmploymentSector));
                    }
                    else
                    {
                        cmdToExecute4.Parameters.Add(new SqlParameter("@nsEmploymentSector", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.MotherOccupation != null)
                    {
                        cmdToExecute4.Parameters.Add(new SqlParameter("@nsOccupation", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.MotherOccupation));
                    }
                    else
                    {
                        cmdToExecute4.Parameters.Add(new SqlParameter("@nsOccupation", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.MotherDesignation != null)
                    {
                        cmdToExecute4.Parameters.Add(new SqlParameter("@nsDesignation", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.MotherDesignation));
                    }
                    else
                    {
                        cmdToExecute4.Parameters.Add(new SqlParameter("@nsDesignation", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.MotherOrganizationName != null)
                    {
                        cmdToExecute4.Parameters.Add(new SqlParameter("@nsOrganizationName", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.MotherOrganizationName));
                    }
                    else
                    {
                        cmdToExecute4.Parameters.Add(new SqlParameter("@nsOrganizationName", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.MotherOfficeContactNo != null)
                    {
                        cmdToExecute4.Parameters.Add(new SqlParameter("@iOfficeContactNumber", SqlDbType.VarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.MotherOfficeContactNo));
                    }
                    else
                    {
                        cmdToExecute4.Parameters.Add(new SqlParameter("@iOfficeContactNumber", SqlDbType.VarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    cmdToExecute4.Parameters.Add(new SqlParameter("@iAnnualIncome", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.MotherAnnualIncome));

                    cmdToExecute4.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute4.Parameters.Add(new SqlParameter("@iCreatedBy", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.StudentSelfRegistrationID));

                    cmdToExecute4.Transaction = transaction;
                    _rowsAffected = cmdToExecute4.ExecuteNonQuery();
                    #endregion USP_StuWebParentPersonalInformation_Insert FOR Mother

                    #region USP_StuWebParentPersonalInformation_Insert FOR Gurdian

                    cmdToExecute5.CommandText = "dbo.USP_StuRegistrationParentPersonalInformation_Insert";
                    cmdToExecute5.CommandType = CommandType.StoredProcedure;

                    cmdToExecute5.Parameters.Add(new SqlParameter("@iStudentRegistrationId", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.ID));
                    cmdToExecute5.Parameters.Add(new SqlParameter("@nsEntityType", SqlDbType.NVarChar, 5, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, "G"));
                    if (item.MotherTitle != null)
                    {
                        cmdToExecute5.Parameters.Add(new SqlParameter("@nsTitle", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.MotherTitle));
                    }
                    else
                    {
                        cmdToExecute5.Parameters.Add(new SqlParameter("@nsTitle", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }

                    cmdToExecute5.Parameters.Add(new SqlParameter("@cGender", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));


                    if (item.MotherFirstName != null)
                    {
                        cmdToExecute5.Parameters.Add(new SqlParameter("@nsFirstName", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.MotherFirstName));
                    }
                    else
                    {
                        cmdToExecute5.Parameters.Add(new SqlParameter("@nsFirstName", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.MotherMiddleName != null)
                    {
                        cmdToExecute5.Parameters.Add(new SqlParameter("@nsMiddleName", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.MotherMiddleName));
                    }
                    else
                    {
                        cmdToExecute5.Parameters.Add(new SqlParameter("@nsMiddleName", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }

                    if (item.MotherLastName != null)
                    {
                        cmdToExecute5.Parameters.Add(new SqlParameter("@nsLastName", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.MotherLastName));
                    }
                    else
                    {
                        cmdToExecute5.Parameters.Add(new SqlParameter("@nsLastName", SqlDbType.NVarChar, 0, ParameterDirection.Input, false, 50, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.MotherEmailId != null)
                    {
                        cmdToExecute5.Parameters.Add(new SqlParameter("@sEmailID", SqlDbType.VarChar, 80, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, item.MotherEmailId));
                    }
                    else
                    {
                        cmdToExecute5.Parameters.Add(new SqlParameter("@sEmailID", SqlDbType.VarChar, 80, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.MotherMobileNumber != null)
                    {
                        cmdToExecute5.Parameters.Add(new SqlParameter("@nsMobileNumber", SqlDbType.VarChar, 15, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, item.MotherMobileNumber));
                    }
                    else
                    {
                        cmdToExecute5.Parameters.Add(new SqlParameter("@nsMobileNumber", SqlDbType.VarChar, 15, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }

                    if (item.StudentDomicileStateofMother != null)
                    {
                        cmdToExecute5.Parameters.Add(new SqlParameter("@nsDomicileState", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, item.StudentDomicileStateofMother));
                    }
                    else
                    {
                        cmdToExecute5.Parameters.Add(new SqlParameter("@nsDomicileState", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.MotherLandLineNumber != null)
                    {
                        cmdToExecute5.Parameters.Add(new SqlParameter("@nsLandlineNumber", SqlDbType.VarChar, 15, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, item.MotherLandLineNumber));
                    }
                    else
                    {
                        cmdToExecute5.Parameters.Add(new SqlParameter("@nsLandlineNumber", SqlDbType.VarChar, 15, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.MotherEmploymentSector != null)
                    {
                        cmdToExecute5.Parameters.Add(new SqlParameter("@nsEmploymentSector", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.MotherEmploymentSector));
                    }
                    else
                    {
                        cmdToExecute5.Parameters.Add(new SqlParameter("@nsEmploymentSector", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.MotherOccupation != null)
                    {
                        cmdToExecute5.Parameters.Add(new SqlParameter("@nsOccupation", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.MotherOccupation));
                    }
                    else
                    {
                        cmdToExecute5.Parameters.Add(new SqlParameter("@nsOccupation", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.MotherDesignation != null)
                    {
                        cmdToExecute5.Parameters.Add(new SqlParameter("@nsDesignation", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.MotherDesignation));
                    }
                    else
                    {
                        cmdToExecute5.Parameters.Add(new SqlParameter("@nsDesignation", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.MotherOrganizationName != null)
                    {
                        cmdToExecute5.Parameters.Add(new SqlParameter("@nsOrganizationName", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.MotherOrganizationName));
                    }
                    else
                    {
                        cmdToExecute5.Parameters.Add(new SqlParameter("@nsOrganizationName", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.MotherOfficeContactNo != null)
                    {
                        cmdToExecute5.Parameters.Add(new SqlParameter("@iOfficeContactNumber", SqlDbType.VarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.MotherOfficeContactNo));
                    }
                    else
                    {
                        cmdToExecute5.Parameters.Add(new SqlParameter("@iOfficeContactNumber", SqlDbType.VarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    cmdToExecute5.Parameters.Add(new SqlParameter("@iAnnualIncome", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.MotherAnnualIncome));

                    cmdToExecute5.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute5.Parameters.Add(new SqlParameter("@iCreatedBy", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.StudentSelfRegistrationID));

                    cmdToExecute5.Transaction = transaction;
                    _rowsAffected = cmdToExecute5.ExecuteNonQuery();
                    #endregion USP_StuWebParentPersonalInformation_Insert FOR Guardian

                    #region USP_StuWebStudentSocialReservationInformation_Insert

                    cmdToExecute6.CommandText = "dbo.USP_StuRegistrationStudentSocialReservationInformation_Insert ";
                    cmdToExecute6.CommandType = CommandType.StoredProcedure;
                    cmdToExecute6.Parameters.Add(new SqlParameter("@iStudentRegistrationID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.ID));
                    cmdToExecute6.Parameters.Add(new SqlParameter("@bSocialReservation1", SqlDbType.Bit, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_Ex_Serviceman_Ward_of_Ex_Serviceman));
                    cmdToExecute6.Parameters.Add(new SqlParameter("@bSocialReservation2", SqlDbType.Bit, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_Active_Serviceman_Ward_of_Active_Serviceman));
                    cmdToExecute6.Parameters.Add(new SqlParameter("@bSocialReservation3", SqlDbType.Bit, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_FreedomFighterWardOfFreedomFighter));
                    cmdToExecute6.Parameters.Add(new SqlParameter("@bSocialReservation4", SqlDbType.Bit, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_WardofPrimaryTeacher));
                    cmdToExecute6.Parameters.Add(new SqlParameter("@bSocialReservation5", SqlDbType.Bit, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_WardofSecondaryTeacher));
                    cmdToExecute6.Parameters.Add(new SqlParameter("@bSocialReservation6", SqlDbType.Bit, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_Deserted_Divorced_Widowed_Women));
                    cmdToExecute6.Parameters.Add(new SqlParameter("@bSocialReservation7", SqlDbType.Bit, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_MemberofProjectAffectedFamily));
                    cmdToExecute6.Parameters.Add(new SqlParameter("@bSocialReservation8", SqlDbType.Bit, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_MemberofEarthquakeAffectedFamily));
                    cmdToExecute6.Parameters.Add(new SqlParameter("@bSocialReservation9", SqlDbType.Bit, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_MemberofFloodFamineAffectedFamily));
                    cmdToExecute6.Parameters.Add(new SqlParameter("@bSocialReservation10", SqlDbType.Bit, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_ResidentofTribalArea));
                    cmdToExecute6.Parameters.Add(new SqlParameter("@bSocialReservation11", SqlDbType.Bit, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_KashmirMigrant));


                    cmdToExecute6.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute6.Parameters.Add(new SqlParameter("@iCreatedBy", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.StudentSelfRegistrationID));




                    cmdToExecute6.Transaction = transaction;
                    _rowsAffected = cmdToExecute6.ExecuteNonQuery();
                    #endregion USP_StuWebStudentSocialReservationInformation_Insert

                    #region USP_StuRegistrationOtherInfoOfStudent_Insert

                    cmdToExecute7.CommandText = "dbo.USP_StuRegistrationOtherInfoOfStudent_Insert ";
                    cmdToExecute7.CommandType = CommandType.StoredProcedure;
                    cmdToExecute7.Parameters.Add(new SqlParameter("@iStudentRegistrationID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.ID));
                    if (item.StudentIndicatetypeofCandidature != null)
                    {
                        cmdToExecute7.Parameters.Add(new SqlParameter("@sIndicateTypeOfCandidature", SqlDbType.VarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.StudentIndicatetypeofCandidature));
                    }
                    else
                    {
                        cmdToExecute7.Parameters.Add(new SqlParameter("@sIndicateTypeOfCandidature", SqlDbType.VarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.StudentSchoolFromHSCExaminationpassed != null)
                    {
                        cmdToExecute7.Parameters.Add(new SqlParameter("@nsWhereTheSchoolFromWhichSSC", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.StudentSchoolFromHSCExaminationpassed));
                    }
                    else
                    {
                        cmdToExecute7.Parameters.Add(new SqlParameter("@nsWhereTheSchoolFromWhichSSC", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }

                    if (item.StudentEconomicallyBackwardClass == "0")
                    {
                        cmdToExecute7.Parameters.Add(new SqlParameter("@bIsEconomicallyBackwordClass", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, false));
                    }
                    else
                    {
                        cmdToExecute7.Parameters.Add(new SqlParameter("@bIsEconomicallyBackwordClass", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, true));

                    }
                    if (item.StudentsNameOfDistrictWhereParentDomiciled != null)
                    {
                        cmdToExecute7.Parameters.Add(new SqlParameter("@nsNameOfTheDistrictWhereParent", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.StudentsNameOfDistrictWhereParentDomiciled));
                    }
                    else
                    {
                        cmdToExecute7.Parameters.Add(new SqlParameter("@nsNameOfTheDistrictWhereParent", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.StudentsMKBCandidate != null)
                    {
                        cmdToExecute7.Parameters.Add(new SqlParameter("@sMKBCandidate", SqlDbType.VarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.StudentsMKBCandidate));
                    }
                    else
                    {
                        cmdToExecute7.Parameters.Add(new SqlParameter("@sMKBCandidate", SqlDbType.VarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }

                    cmdToExecute7.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute7.Parameters.Add(new SqlParameter("@iCreatedBy", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.StudentSelfRegistrationID));




                    cmdToExecute7.Transaction = transaction;
                    _rowsAffected = cmdToExecute7.ExecuteNonQuery();
                    #endregion USP_StuRegistrationOtherInfoOfStudent_Insert

                    #region USP_StuRegistrationPreEntranceExaminationTransaction_Insert

                    cmdToExecute8.CommandText = "dbo.USP_StuRegistrationPreEntranceExaminationTransaction_Insert ";
                    cmdToExecute8.CommandType = CommandType.StoredProcedure;
                    cmdToExecute8.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 10, ParameterDirection.Output, false, 0, 0, "", DataRowVersion.Proposed, item.Student_QualifyingTransactionID));
                    cmdToExecute8.Parameters.Add(new SqlParameter("@iStudentRegistrationID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.ID));
                    cmdToExecute8.Parameters.Add(new SqlParameter("@iQualifyingExamMasterId", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_QualifyingExamId));
                    if (item.Student_QualifyingRollNo != null)
                    {
                        cmdToExecute8.Parameters.Add(new SqlParameter("@nsRollNumber ", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_QualifyingRollNo));
                    }
                    else
                    {
                        cmdToExecute8.Parameters.Add(new SqlParameter("@nsRollNumber ", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    cmdToExecute8.Parameters.Add(new SqlParameter("@iMarksObtained", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_QualifyingExamTotalMarksPointsObtained));
                    cmdToExecute8.Parameters.Add(new SqlParameter("@iMarksOutOf", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_QualifyingExamOutOffMark));
                    if (item.Student_QualifyingExamRank != null)
                    {
                        cmdToExecute8.Parameters.Add(new SqlParameter("@nsRank", SqlDbType.NVarChar, 5, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_QualifyingExamRank));
                    }
                    else
                    {
                        cmdToExecute8.Parameters.Add(new SqlParameter("@nsRank", SqlDbType.NVarChar, 5, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }

                    cmdToExecute8.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute8.Parameters.Add(new SqlParameter("@iCreatedBy", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.StudentSelfRegistrationID));

                    cmdToExecute8.Transaction = transaction;
                    _rowsAffected = cmdToExecute8.ExecuteNonQuery();
                    item.Student_QualifyingTransactionID = (Int32)cmdToExecute8.Parameters["@iID"].Value;
                    #endregion USP_StuRegistrationOtherInfoOfStudent_Insert

                    #region USP_StuRegistrationPreEntranceExaminationSubjectDetail_InsertXML

                    cmdToExecute9.CommandText = "dbo.USP_StuRegistrationPreEntranceExaminationSubjectDetail_InsertXML ";
                    cmdToExecute9.CommandType = CommandType.StoredProcedure;

                    cmdToExecute9.Parameters.Add(new SqlParameter("@iStudent_QualifyingTransactionID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_QualifyingTransactionID));

                    //    cmdToExecute9.Parameters.Add(new SqlParameter("@iQualifyingExamMstID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_QualifyingExamId));
                    if (item.QualifyingExamSubjectDetailsIDs != null)
                    {
                        cmdToExecute9.Parameters.Add(new SqlParameter("@nsIDs ", SqlDbType.NVarChar, 4000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.QualifyingExamSubjectDetailsIDs));
                    }
                    else
                    {
                        cmdToExecute9.Parameters.Add(new SqlParameter("@nsIDs ", SqlDbType.NVarChar, 4000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, ""));
                    }

                    cmdToExecute9.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute9.Parameters.Add(new SqlParameter("@iCreatedBy", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.StudentSelfRegistrationID));

                    cmdToExecute9.Transaction = transaction;
                    _rowsAffected = cmdToExecute9.ExecuteNonQuery();

                    #endregion USP_StuRegistrationPreEntranceExaminationSubjectDetail_InsertXML

                    #region USP_StuRegistrationPreQualificationSchoolTransaction_Insert For General

                    cmdToExecute10.CommandText = "dbo.USP_StuRegistrationPreQualificationSchoolTransaction_Insert ";
                    cmdToExecute10.CommandType = CommandType.StoredProcedure;
                    cmdToExecute10.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 10, ParameterDirection.Output, false, 0, 0, "", DataRowVersion.Proposed, item.Student_QualificationTransactionID));
                    cmdToExecute10.Parameters.Add(new SqlParameter("@iStudentRegistrationID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.ID));
                    cmdToExecute10.Parameters.Add(new SqlParameter("@cEducationType ", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, "G"));
                    cmdToExecute10.Parameters.Add(new SqlParameter("@iMediumId", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_Qualification_General_MediumOfInstitution));
                    cmdToExecute10.Parameters.Add(new SqlParameter("@siMonthPassing", SqlDbType.SmallInt, 2, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_Qualification_General_MonthOfPassing));
                    cmdToExecute10.Parameters.Add(new SqlParameter("@iYearPassing", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_Qualification_General_YearOfPassing));
                    if (item.Student_Qualification_General_SingleAttempt == "0")
                    {
                        cmdToExecute10.Parameters.Add(new SqlParameter("@bIsSingleAttempt", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, false));
                    }
                    else
                    {
                        cmdToExecute10.Parameters.Add(new SqlParameter("@bIsSingleAttempt", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, true));
                    }
                    cmdToExecute10.Parameters.Add(new SqlParameter("@iMarksObtained", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_Qualification_General_ObtainedMark));
                    cmdToExecute10.Parameters.Add(new SqlParameter("@iMarksOutOf", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_Qualification_General_OutOfMark));
                    if (item.Student_Qualification_General_Percent != null)
                    {
                        cmdToExecute10.Parameters.Add(new SqlParameter("@nsMarksObtainedPercentage", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_Qualification_General_Percent));
                    }
                    else
                    {
                        cmdToExecute10.Parameters.Add(new SqlParameter("@nsMarksObtainedPercentage", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.Student_Qualification_General_NameofInstitution != null)
                    {
                        cmdToExecute10.Parameters.Add(new SqlParameter("@nsInstitutionName", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_Qualification_General_NameofInstitution));
                    }
                    else
                    {
                        cmdToExecute10.Parameters.Add(new SqlParameter("@nsInstitutionName", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.Student_Qualification_General_Region_Division_Board != null)
                    {
                        cmdToExecute10.Parameters.Add(new SqlParameter("@nsRegionDivisionBoard", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_Qualification_General_Region_Division_Board));
                    }
                    else
                    {
                        cmdToExecute10.Parameters.Add(new SqlParameter("@nsRegionDivisionBoard", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    cmdToExecute10.Parameters.Add(new SqlParameter("@iStreamId", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_Qualification_HSC_StreamID));
                    if (item.Student_Qualification_HSC_StreamOther != null)
                    {
                        cmdToExecute10.Parameters.Add(new SqlParameter("@nsOtherStream", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_Qualification_HSC_StreamOther));
                    }
                    else
                    {
                        cmdToExecute10.Parameters.Add(new SqlParameter("@nsOtherStream", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.Student_Qualification_HSC_Class != null)
                    {
                        cmdToExecute10.Parameters.Add(new SqlParameter("@sGrade", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_Qualification_HSC_Class));
                    }
                    else
                    {
                        cmdToExecute10.Parameters.Add(new SqlParameter("@sGrade", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    cmdToExecute10.Parameters.Add(new SqlParameter("@iGroupAObtainedMarks", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_Qualification_HSC_PCM_PVM_ObtainedMark));
                    cmdToExecute10.Parameters.Add(new SqlParameter("@iGroupAOutOfMarks", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_Qualification_HSC_PCM_PVM_OutOfMark));
                    cmdToExecute10.Parameters.Add(new SqlParameter("@iGroupBObtainedMarks", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_Qualification_HSC_PCB_ObtainedMark));
                    cmdToExecute10.Parameters.Add(new SqlParameter("@iGroupBOutOfMarks", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_Qualification_HSC_PCB_OutOfMark));
                    cmdToExecute10.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute10.Parameters.Add(new SqlParameter("@iCreatedBy", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.StudentSelfRegistrationID));

                    cmdToExecute10.Transaction = transaction;
                    _rowsAffected = cmdToExecute10.ExecuteNonQuery();
                    item.Student_QualificationTransactionID = (Int32)cmdToExecute10.Parameters["@iID"].Value;
                    #endregion USP_StuRegistrationPreQualificationSchoolTransaction_Insert For General

                    #region USP_StuRegistrationPreEntranceExaminationSubjectDetail_InsertXML For General

                    cmdToExecute11.CommandText = "dbo.USP_StuRegistrationPreQualificationSchoolSubjectDetail_InsertXML ";
                    cmdToExecute11.CommandType = CommandType.StoredProcedure;

                    cmdToExecute11.Parameters.Add(new SqlParameter("@iStudentQualificationTransactionID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_QualificationTransactionID));

                    if (item.QualificationExamSubjectGeneralDetailsIDs != null)
                    {
                        cmdToExecute11.Parameters.Add(new SqlParameter("@nsIDs ", SqlDbType.NVarChar, 4000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.QualificationExamSubjectGeneralDetailsIDs));
                    }
                    else
                    {
                        cmdToExecute11.Parameters.Add(new SqlParameter("@nsIDs ", SqlDbType.NVarChar, 4000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, ""));
                    }

                    cmdToExecute11.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute11.Parameters.Add(new SqlParameter("@iCreatedBy", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.StudentSelfRegistrationID));

                    cmdToExecute11.Transaction = transaction;
                    _rowsAffected = cmdToExecute11.ExecuteNonQuery();

                    #endregion USP_StuRegistrationPreEntranceExaminationSubjectDetail_InsertXML For General

                    #region USP_StuRegistrationPreQualificationSchoolTransaction_Insert For SSC

                    cmdToExecute12.CommandText = "dbo.USP_StuRegistrationPreQualificationSchoolTransaction_Insert ";
                    cmdToExecute12.CommandType = CommandType.StoredProcedure;
                    cmdToExecute12.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 10, ParameterDirection.Output, false, 0, 0, "", DataRowVersion.Proposed, item.Student_QualificationTransactionID));
                    cmdToExecute12.Parameters.Add(new SqlParameter("@iStudentRegistrationID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.ID));
                    cmdToExecute12.Parameters.Add(new SqlParameter("@cEducationType ", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, "S"));
                    cmdToExecute12.Parameters.Add(new SqlParameter("@iMediumId", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_Qualification_SSC_MediumOfInstitution));
                    cmdToExecute12.Parameters.Add(new SqlParameter("@siMonthPassing", SqlDbType.SmallInt, 2, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_Qualification_SSC_MonthOfPassing));
                    cmdToExecute12.Parameters.Add(new SqlParameter("@iYearPassing", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_Qualification_SSC_YearOfPassing));
                    if (item.Student_Qualification_SSC_SingleAttempt == "0")
                    {
                        cmdToExecute12.Parameters.Add(new SqlParameter("@bIsSingleAttempt", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, false));
                    }
                    else
                    {
                        cmdToExecute12.Parameters.Add(new SqlParameter("@bIsSingleAttempt", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, true));
                    }
                    cmdToExecute12.Parameters.Add(new SqlParameter("@iMarksObtained", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_Qualification_SSC_ObtainedMark));
                    cmdToExecute12.Parameters.Add(new SqlParameter("@iMarksOutOf", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_Qualification_SSC_OutOfMark));
                    if (item.Student_Qualification_SSC_Percent != null && item.Student_Qualification_SSC_Percent != 0)
                    {
                        cmdToExecute12.Parameters.Add(new SqlParameter("@nsMarksObtainedPercentage", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_Qualification_SSC_Percent));
                    }
                    else
                    {
                        cmdToExecute12.Parameters.Add(new SqlParameter("@nsMarksObtainedPercentage", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.Student_Qualification_SSC_NameofInstitution != null)
                    {
                        cmdToExecute12.Parameters.Add(new SqlParameter("@nsInstitutionName", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_Qualification_SSC_NameofInstitution));
                    }
                    else
                    {
                        cmdToExecute12.Parameters.Add(new SqlParameter("@nsInstitutionName", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.Student_Qualification_SSC_Region_Division_Board != null)
                    {
                        cmdToExecute12.Parameters.Add(new SqlParameter("@nsRegionDivisionBoard", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_Qualification_SSC_Region_Division_Board));
                    }
                    else
                    {
                        cmdToExecute12.Parameters.Add(new SqlParameter("@nsRegionDivisionBoard", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    cmdToExecute12.Parameters.Add(new SqlParameter("@iStreamId", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_Qualification_HSC_StreamID));
                    if (item.Student_Qualification_HSC_StreamOther != null)
                    {
                        cmdToExecute12.Parameters.Add(new SqlParameter("@nsOtherStream", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_Qualification_HSC_StreamOther));
                    }
                    else
                    {
                        cmdToExecute12.Parameters.Add(new SqlParameter("@nsOtherStream", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.Student_Qualification_HSC_Class != null)
                    {
                        cmdToExecute12.Parameters.Add(new SqlParameter("@sGrade", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_Qualification_HSC_Class));
                    }
                    else
                    {
                        cmdToExecute12.Parameters.Add(new SqlParameter("@sGrade", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    cmdToExecute12.Parameters.Add(new SqlParameter("@iGroupAObtainedMarks", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_Qualification_HSC_PCM_PVM_ObtainedMark));
                    cmdToExecute12.Parameters.Add(new SqlParameter("@iGroupAOutOfMarks", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_Qualification_HSC_PCM_PVM_OutOfMark));
                    cmdToExecute12.Parameters.Add(new SqlParameter("@iGroupBObtainedMarks", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_Qualification_HSC_PCB_ObtainedMark));
                    cmdToExecute12.Parameters.Add(new SqlParameter("@iGroupBOutOfMarks", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_Qualification_HSC_PCB_OutOfMark));
                    cmdToExecute12.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute12.Parameters.Add(new SqlParameter("@iCreatedBy", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.StudentSelfRegistrationID));

                    cmdToExecute12.Transaction = transaction;
                    _rowsAffected = cmdToExecute12.ExecuteNonQuery();
                    item.Student_QualificationTransactionID = (Int32)cmdToExecute12.Parameters["@iID"].Value;
                    #endregion USP_StuRegistrationPreQualificationSchoolTransaction_Insert For SSC

                    #region USP_StuRegistrationPreEntranceExaminationSubjectDetail_InsertXML For SSC

                    cmdToExecute13.CommandText = "dbo.USP_StuRegistrationPreQualificationSchoolSubjectDetail_InsertXML ";
                    cmdToExecute13.CommandType = CommandType.StoredProcedure;

                    cmdToExecute13.Parameters.Add(new SqlParameter("@iStudentQualificationTransactionID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_QualificationTransactionID));

                    if (item.QualificationExamSubjectSSCDetailsIDs != null)
                    {
                        cmdToExecute13.Parameters.Add(new SqlParameter("@nsIDs ", SqlDbType.NVarChar, 4000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.QualificationExamSubjectSSCDetailsIDs));
                    }
                    else
                    {
                        cmdToExecute13.Parameters.Add(new SqlParameter("@nsIDs ", SqlDbType.NVarChar, 4000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, ""));
                    }

                    cmdToExecute13.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute13.Parameters.Add(new SqlParameter("@iCreatedBy", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.StudentSelfRegistrationID));

                    cmdToExecute13.Transaction = transaction;
                    _rowsAffected = cmdToExecute13.ExecuteNonQuery();

                    #endregion USP_StuRegistrationPreEntranceExaminationSubjectDetail_InsertXML For SSC

                    #region USP_StuRegistrationPreQualificationSchoolTransaction_Insert For HSC

                    cmdToExecute14.CommandText = "dbo.USP_StuRegistrationPreQualificationSchoolTransaction_Insert ";
                    cmdToExecute14.CommandType = CommandType.StoredProcedure;
                    cmdToExecute14.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 10, ParameterDirection.Output, false, 0, 0, "", DataRowVersion.Proposed, item.Student_QualificationTransactionID));
                    cmdToExecute14.Parameters.Add(new SqlParameter("@iStudentRegistrationID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.ID));
                    cmdToExecute14.Parameters.Add(new SqlParameter("@cEducationType ", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, "H"));
                    cmdToExecute14.Parameters.Add(new SqlParameter("@iMediumId", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_Qualification_HSC_MediumOfInstitution));
                    cmdToExecute14.Parameters.Add(new SqlParameter("@siMonthPassing", SqlDbType.SmallInt, 2, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_Qualification_HSC_MonthOfPassing));
                    cmdToExecute14.Parameters.Add(new SqlParameter("@iYearPassing", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_Qualification_HSC_YearOfPassing));
                    if (item.Student_Qualification_HSC_SingleAttempt == "0")
                    {
                        cmdToExecute14.Parameters.Add(new SqlParameter("@bIsSingleAttempt", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, false));
                    }
                    else
                    {
                        cmdToExecute14.Parameters.Add(new SqlParameter("@bIsSingleAttempt", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, true));
                    }
                    cmdToExecute14.Parameters.Add(new SqlParameter("@iMarksObtained", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_Qualification_HSC_ObtainedMark));
                    cmdToExecute14.Parameters.Add(new SqlParameter("@iMarksOutOf", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_Qualification_HSC_OutOfMark));
                    if (item.Student_Qualification_HSC_Percent != null && item.Student_Qualification_HSC_Percent != 0)
                    {
                        cmdToExecute14.Parameters.Add(new SqlParameter("@nsMarksObtainedPercentage", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_Qualification_HSC_Percent));
                    }
                    else
                    {
                        cmdToExecute14.Parameters.Add(new SqlParameter("@nsMarksObtainedPercentage", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.Student_Qualification_HSC_NameofInstitution != null)
                    {
                        cmdToExecute14.Parameters.Add(new SqlParameter("@nsInstitutionName", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_Qualification_HSC_NameofInstitution));
                    }
                    else
                    {
                        cmdToExecute14.Parameters.Add(new SqlParameter("@nsInstitutionName", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.Student_Qualification_HSC_Region_Division_Board != null)
                    {
                        cmdToExecute14.Parameters.Add(new SqlParameter("@nsRegionDivisionBoard", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_Qualification_HSC_Region_Division_Board));
                    }
                    else
                    {
                        cmdToExecute14.Parameters.Add(new SqlParameter("@nsRegionDivisionBoard", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    cmdToExecute14.Parameters.Add(new SqlParameter("@iStreamId", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_Qualification_HSC_StreamID));
                    if (item.Student_Qualification_HSC_StreamOther != null)
                    {
                        cmdToExecute14.Parameters.Add(new SqlParameter("@nsOtherStream", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_Qualification_HSC_StreamOther));
                    }
                    else
                    {
                        cmdToExecute14.Parameters.Add(new SqlParameter("@nsOtherStream", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.Student_Qualification_HSC_Class != null)
                    {
                        cmdToExecute14.Parameters.Add(new SqlParameter("@sGrade", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_Qualification_HSC_Class));
                    }
                    else
                    {
                        cmdToExecute14.Parameters.Add(new SqlParameter("@sGrade", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    cmdToExecute14.Parameters.Add(new SqlParameter("@iGroupAObtainedMarks", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_Qualification_HSC_PCM_PVM_ObtainedMark));
                    cmdToExecute14.Parameters.Add(new SqlParameter("@iGroupAOutOfMarks", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_Qualification_HSC_PCM_PVM_OutOfMark));
                    cmdToExecute14.Parameters.Add(new SqlParameter("@iGroupBObtainedMarks", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_Qualification_HSC_PCB_ObtainedMark));
                    cmdToExecute14.Parameters.Add(new SqlParameter("@iGroupBOutOfMarks", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_Qualification_HSC_PCB_OutOfMark));
                    cmdToExecute14.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute14.Parameters.Add(new SqlParameter("@iCreatedBy", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.StudentSelfRegistrationID));

                    cmdToExecute14.Transaction = transaction;
                    _rowsAffected = cmdToExecute14.ExecuteNonQuery();
                    item.Student_QualificationTransactionID = (Int32)cmdToExecute14.Parameters["@iID"].Value;
                    #endregion USP_StuRegistrationPreQualificationSchoolTransaction_Insert For HSC

                    #region USP_StuRegistrationPreEntranceExaminationSubjectDetail_InsertXML For HSC

                    cmdToExecute15.CommandText = "dbo.USP_StuRegistrationPreQualificationSchoolSubjectDetail_InsertXML ";
                    cmdToExecute15.CommandType = CommandType.StoredProcedure;

                    cmdToExecute15.Parameters.Add(new SqlParameter("@iStudentQualificationTransactionID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_QualificationTransactionID));

                    if (item.QualificationExamSubjectHSCDetailsIDs != null)
                    {
                        cmdToExecute15.Parameters.Add(new SqlParameter("@nsIDs ", SqlDbType.NVarChar, 4000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.QualificationExamSubjectHSCDetailsIDs));
                    }
                    else
                    {
                        cmdToExecute15.Parameters.Add(new SqlParameter("@nsIDs ", SqlDbType.NVarChar, 4000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, ""));
                    }

                    cmdToExecute15.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute15.Parameters.Add(new SqlParameter("@iCreatedBy", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.StudentSelfRegistrationID));

                    cmdToExecute15.Transaction = transaction;
                    _rowsAffected = cmdToExecute15.ExecuteNonQuery();

                    #endregion USP_StuRegistrationPreEntranceExaminationSubjectDetail_InsertXML For HSC

                    #region USP_StuRegistrationPreQualificationCollegeTransaction_Insert For Diploma / ITI Details


                    cmdToExecute16.CommandText = "dbo.USP_StuRegistrationPreQualificationCollegeTransaction_Insert ";
                    cmdToExecute16.CommandType = CommandType.StoredProcedure;
                    //  cmdToExecute16.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 10, ParameterDirection.Output, false, 0, 0, "", DataRowVersion.Proposed, item.Student_QualificationTransactionID));
                    cmdToExecute16.Parameters.Add(new SqlParameter("@iStudentRegistrationID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.ID));
                    cmdToExecute16.Parameters.Add(new SqlParameter("@cEducationType ", SqlDbType.Char, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, "DIPLOMA"));
                    cmdToExecute16.Parameters.Add(new SqlParameter("@iMediumId", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_Qualification_Diploma_ITI_Details_MediumOfInstitution));
                    if (item.Student_Qualification_Diploma_ITI_Details_BranchName != null)
                    {
                        cmdToExecute16.Parameters.Add(new SqlParameter("@nsBranchName", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_Qualification_Diploma_ITI_Details_BranchName));
                    }
                    else
                    {
                        cmdToExecute16.Parameters.Add(new SqlParameter("@nsBranchName", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    cmdToExecute16.Parameters.Add(new SqlParameter("@cExamPattern", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_Qualification_Diploma_ITI_Details_ExamPattern != null ? item.Student_Qualification_Diploma_ITI_Details_ExamPattern : DBNull.Value.ToString()));

                    cmdToExecute16.Parameters.Add(new SqlParameter("@siMonthPassing", SqlDbType.SmallInt, 2, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_Qualification_Diploma_ITI_Details_MonthOfPassing));
                    cmdToExecute16.Parameters.Add(new SqlParameter("@iYearPassing", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_Qualification_Diploma_ITI_Details_YearOfPassing));
                    if (item.Student_Qualification_Diploma_ITI_Details_Class != null)
                    {
                        cmdToExecute16.Parameters.Add(new SqlParameter("@sGrade", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_Qualification_Diploma_ITI_Details_Class));
                    }
                    else
                    {
                        cmdToExecute16.Parameters.Add(new SqlParameter("@sGrade", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    cmdToExecute16.Parameters.Add(new SqlParameter("@iMarksObtained", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_Qualification_Diploma_ITI_Details_ObtainedMark));
                    cmdToExecute16.Parameters.Add(new SqlParameter("@iMarksOutOf", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_Qualification_Diploma_ITI_Details_OutOfMark));
                    //if (item.Student_Qualification_Diploma_ITI_Details_Percent != null)
                    //{
                    cmdToExecute16.Parameters.Add(new SqlParameter("@nsMarksObtainedPercentage", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Convert.ToString(item.Student_Qualification_Diploma_ITI_Details_Percent)));
                    //}
                    //else
                    //{
                    //    cmdToExecute16.Parameters.Add(new SqlParameter("@nsMarksObtainedPercentage", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    //}
                    if (item.Student_Qualification_Diploma_ITI_Details_SingleAttempt == "0")
                    {
                        cmdToExecute16.Parameters.Add(new SqlParameter("@bIsSingleAttempt", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, false));
                    }
                    else
                    {
                        cmdToExecute16.Parameters.Add(new SqlParameter("@bIsSingleAttempt", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, true));
                    }
                    if (item.Student_Qualification_Diploma_ITI_Details_BoardEnrollmentNumber != null)
                    {
                        cmdToExecute16.Parameters.Add(new SqlParameter("@nsEnrollmentNo", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_Qualification_Diploma_ITI_Details_BoardEnrollmentNumber));
                    }
                    else
                    {
                        cmdToExecute16.Parameters.Add(new SqlParameter("@nsEnrollmentNo", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.Student_Qualification_Diploma_ITI_Details_NameofInstitution != null)
                    {
                        cmdToExecute16.Parameters.Add(new SqlParameter("@nsInstitutionName", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_Qualification_Diploma_ITI_Details_NameofInstitution));
                    }
                    else
                    {
                        cmdToExecute16.Parameters.Add(new SqlParameter("@nsInstitutionName", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.Student_Qualification_Diploma_ITI_Details_Board != null)
                    {
                        cmdToExecute16.Parameters.Add(new SqlParameter("@nsRegionDivisionBoard", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_Qualification_Diploma_ITI_Details_Board));
                    }
                    else
                    {
                        cmdToExecute16.Parameters.Add(new SqlParameter("@nsRegionDivisionBoard", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    cmdToExecute16.Parameters.Add(new SqlParameter("@iRegionID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_Qualification_Diploma_ITI_Details_State));
                    cmdToExecute16.Parameters.Add(new SqlParameter("@iCountryID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_Qualification_Diploma_ITI_Details_CountryId));
                    if (item.Student_Qualification_Diploma_ITI_Details_StateOther != null)
                    {
                        cmdToExecute16.Parameters.Add(new SqlParameter("@nsOtherRegion", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_Qualification_Diploma_ITI_Details_StateOther));
                    }
                    else
                    {
                        cmdToExecute16.Parameters.Add(new SqlParameter("@nsOtherRegion", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    cmdToExecute16.Parameters.Add(new SqlParameter("@nsDegreeName", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));

                    cmdToExecute16.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute16.Parameters.Add(new SqlParameter("@iCreatedBy", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.StudentSelfRegistrationID));

                    cmdToExecute16.Transaction = transaction;
                    _rowsAffected = cmdToExecute16.ExecuteNonQuery();

                    #endregion USP_StuRegistrationPreQualificationCollegeTransaction_Insert For Diploma / ITI Details

                    #region USP_StuRegistrationPreQualificationCollegeTransaction_Insert For Degree Details


                    cmdToExecute17.CommandText = "dbo.USP_StuRegistrationPreQualificationCollegeTransaction_Insert ";
                    cmdToExecute17.CommandType = CommandType.StoredProcedure;
                    //  cmdToExecute17.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 10, ParameterDirection.Output, false, 0, 0, "", DataRowVersion.Proposed, item.Student_QualificationTransactionID));
                    cmdToExecute17.Parameters.Add(new SqlParameter("@iStudentRegistrationID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.ID));
                    cmdToExecute17.Parameters.Add(new SqlParameter("@cEducationType ", SqlDbType.Char, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, "UG"));
                    cmdToExecute17.Parameters.Add(new SqlParameter("@iMediumId", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_Qualification_DegreeDetails_MediumOfInstitution));
                    if (item.Student_Qualification_DegreeDetails_BranchName != null)
                    {
                        cmdToExecute17.Parameters.Add(new SqlParameter("@nsBranchName", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_Qualification_DegreeDetails_BranchName));
                    }
                    else
                    {
                        cmdToExecute17.Parameters.Add(new SqlParameter("@nsBranchName", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    cmdToExecute17.Parameters.Add(new SqlParameter("@cExamPattern", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_Qualification_DegreeDetails_ExamPattern != null ? item.Student_Qualification_DegreeDetails_ExamPattern : DBNull.Value.ToString()));

                    cmdToExecute17.Parameters.Add(new SqlParameter("@siMonthPassing", SqlDbType.SmallInt, 2, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_Qualification_DegreeDetails_MonthOfPassing));
                    cmdToExecute17.Parameters.Add(new SqlParameter("@iYearPassing", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_Qualification_DegreeDetails_YearOfPassing));
                    if (item.Student_Qualification_DegreeDetails_Class != null)
                    {
                        cmdToExecute17.Parameters.Add(new SqlParameter("@sGrade", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_Qualification_DegreeDetails_Class));
                    }
                    else
                    {
                        cmdToExecute17.Parameters.Add(new SqlParameter("@sGrade", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    cmdToExecute17.Parameters.Add(new SqlParameter("@iMarksObtained", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_Qualification_DegreeDetails_ObtainedMark));
                    cmdToExecute17.Parameters.Add(new SqlParameter("@iMarksOutOf", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_Qualification_DegreeDetails_OutOfMark));
                    //if (item.Student_Qualification_DegreeDetails_Percent != null)
                    //{
                    cmdToExecute17.Parameters.Add(new SqlParameter("@nsMarksObtainedPercentage", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Convert.ToString(item.Student_Qualification_DegreeDetails_Percent)));
                    //}
                    //else
                    //{
                    //    cmdToExecute17.Parameters.Add(new SqlParameter("@nsMarksObtainedPercentage", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    //}
                    if (item.Student_Qualification_DegreeDetails_SingleAttempt == "0")
                    {
                        cmdToExecute17.Parameters.Add(new SqlParameter("@bIsSingleAttempt", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, false));
                    }
                    else
                    {
                        cmdToExecute17.Parameters.Add(new SqlParameter("@bIsSingleAttempt", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, true));
                    }
                    if (item.Student_Qualification_DegreeDetails_BoardEnrollmentNumber != null)
                    {
                        cmdToExecute17.Parameters.Add(new SqlParameter("@nsEnrollmentNo", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_Qualification_DegreeDetails_BoardEnrollmentNumber));
                    }
                    else
                    {
                        cmdToExecute17.Parameters.Add(new SqlParameter("@nsEnrollmentNo", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.Student_Qualification_DegreeDetails_NameofInstitution != null)
                    {
                        cmdToExecute17.Parameters.Add(new SqlParameter("@nsInstitutionName", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_Qualification_DegreeDetails_NameofInstitution));
                    }
                    else
                    {
                        cmdToExecute17.Parameters.Add(new SqlParameter("@nsInstitutionName", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.Student_Qualification_DegreeDetails_UniversityName != null)
                    {
                        cmdToExecute17.Parameters.Add(new SqlParameter("@nsRegionDivisionBoard", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_Qualification_DegreeDetails_UniversityName));
                    }
                    else
                    {
                        cmdToExecute17.Parameters.Add(new SqlParameter("@nsRegionDivisionBoard", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    cmdToExecute17.Parameters.Add(new SqlParameter("@iRegionID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_Qualification_DegreeDetails_State));
                    cmdToExecute17.Parameters.Add(new SqlParameter("@iCountryID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_Qualification_DegreeDetails_CountryId));
                    if (item.Student_Qualification_DegreeDetails_StateOther != null)
                    {
                        cmdToExecute17.Parameters.Add(new SqlParameter("@nsOtherRegion", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_Qualification_Diploma_ITI_Details_StateOther));
                    }
                    else
                    {
                        cmdToExecute17.Parameters.Add(new SqlParameter("@nsOtherRegion", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }

                    if (item.Student_Qualification_DegreeDetails_Degree != null)
                    {
                        cmdToExecute17.Parameters.Add(new SqlParameter("@nsDegreeName", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_Qualification_DegreeDetails_Degree));
                    }
                    else
                    {
                        cmdToExecute17.Parameters.Add(new SqlParameter("@nsDegreeName", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    cmdToExecute17.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute17.Parameters.Add(new SqlParameter("@iCreatedBy", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.StudentSelfRegistrationID));

                    cmdToExecute17.Transaction = transaction;
                    _rowsAffected = cmdToExecute17.ExecuteNonQuery();

                    #endregion USP_StuRegistrationPreQualificationCollegeTransaction_Insert For Degree Details

                    #region USP_StuRegistrationPreQualificationCollegeTransaction_Insert For     Post Graduation Details


                    cmdToExecute18.CommandText = "dbo.USP_StuRegistrationPreQualificationCollegeTransaction_Insert ";
                    cmdToExecute18.CommandType = CommandType.StoredProcedure;
                    //  cmdToExecute18.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 10, ParameterDirection.Output, false, 0, 0, "", DataRowVersion.Proposed, item.Student_QualificationTransactionID));
                    cmdToExecute18.Parameters.Add(new SqlParameter("@iStudentRegistrationID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.ID));
                    cmdToExecute18.Parameters.Add(new SqlParameter("@cEducationType ", SqlDbType.Char, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, "PG"));
                    cmdToExecute18.Parameters.Add(new SqlParameter("@iMediumId", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_Qualification_PostGraduationDetails_MediumOfInstitution));
                    if (item.Student_Qualification_PostGraduationDetails_BranchName != null)
                    {
                        cmdToExecute18.Parameters.Add(new SqlParameter("@nsBranchName", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_Qualification_PostGraduationDetails_BranchName));
                    }
                    else
                    {
                        cmdToExecute18.Parameters.Add(new SqlParameter("@nsBranchName", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    cmdToExecute18.Parameters.Add(new SqlParameter("@cExamPattern", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_Qualification_PostGraduationDetails_ExamPattern != null ? item.Student_Qualification_PostGraduationDetails_ExamPattern : DBNull.Value.ToString()));

                    cmdToExecute18.Parameters.Add(new SqlParameter("@siMonthPassing", SqlDbType.SmallInt, 2, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_Qualification_PostGraduationDetails_MonthOfPassing));
                    cmdToExecute18.Parameters.Add(new SqlParameter("@iYearPassing", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_Qualification_PostGraduationDetails_YearOfPassing));
                    if (item.Student_Qualification_PostGraduationDetails_Class != null)
                    {
                        cmdToExecute18.Parameters.Add(new SqlParameter("@sGrade", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_Qualification_PostGraduationDetails_Class));
                    }
                    else
                    {
                        cmdToExecute18.Parameters.Add(new SqlParameter("@sGrade", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    cmdToExecute18.Parameters.Add(new SqlParameter("@iMarksObtained", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_Qualification_PostGraduationDetails_ObtainedMark));
                    cmdToExecute18.Parameters.Add(new SqlParameter("@iMarksOutOf", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_Qualification_PostGraduationDetails_OutOfMark));
                    //if (item.Student_Qualification_PostGraduationDetails_Percent != null)
                    //{
                    cmdToExecute18.Parameters.Add(new SqlParameter("@nsMarksObtainedPercentage", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Convert.ToString(item.Student_Qualification_PostGraduationDetails_Percent)));
                    //}
                    //else
                    //{
                    //    cmdToExecute18.Parameters.Add(new SqlParameter("@nsMarksObtainedPercentage", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    //}
                    if (item.Student_Qualification_PostGraduationDetails_SingleAttempt == "0")
                    {
                        cmdToExecute18.Parameters.Add(new SqlParameter("@bIsSingleAttempt", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, false));
                    }
                    else
                    {
                        cmdToExecute18.Parameters.Add(new SqlParameter("@bIsSingleAttempt", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, true));
                    }
                    if (item.Student_Qualification_PostGraduationDetails_BoardEnrollmentNumber != null)
                    {
                        cmdToExecute18.Parameters.Add(new SqlParameter("@nsEnrollmentNo", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_Qualification_PostGraduationDetails_BoardEnrollmentNumber));
                    }
                    else
                    {
                        cmdToExecute18.Parameters.Add(new SqlParameter("@nsEnrollmentNo", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.Student_Qualification_PostGraduationDetails_NameofInstitution != null)
                    {
                        cmdToExecute18.Parameters.Add(new SqlParameter("@nsInstitutionName", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_Qualification_PostGraduationDetails_NameofInstitution));
                    }
                    else
                    {
                        cmdToExecute18.Parameters.Add(new SqlParameter("@nsInstitutionName", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.Student_Qualification_PostGraduationDetails_UniversityName != null)
                    {
                        cmdToExecute18.Parameters.Add(new SqlParameter("@nsRegionDivisionBoard", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_Qualification_PostGraduationDetails_UniversityName));
                    }
                    else
                    {
                        cmdToExecute18.Parameters.Add(new SqlParameter("@nsRegionDivisionBoard", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    cmdToExecute18.Parameters.Add(new SqlParameter("@iRegionID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_Qualification_PostGraduationDetails_State));
                    cmdToExecute18.Parameters.Add(new SqlParameter("@iCountryID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_Qualification_PostGraduationDetails_CountryId));
                    if (item.Student_Qualification_PostGraduationDetails_StateOther != null)
                    {
                        cmdToExecute18.Parameters.Add(new SqlParameter("@nsOtherRegion", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_Qualification_Diploma_ITI_Details_StateOther));
                    }
                    else
                    {
                        cmdToExecute18.Parameters.Add(new SqlParameter("@nsOtherRegion", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }

                    if (item.Student_Qualification_PostGraduationDetails_PostGraduation != null)
                    {
                        cmdToExecute18.Parameters.Add(new SqlParameter("@nsDegreeName", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_Qualification_PostGraduationDetails_PostGraduation));
                    }
                    else
                    {
                        cmdToExecute18.Parameters.Add(new SqlParameter("@nsDegreeName", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    cmdToExecute18.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute18.Parameters.Add(new SqlParameter("@iCreatedBy", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.StudentSelfRegistrationID));

                    cmdToExecute18.Transaction = transaction;
                    _rowsAffected = cmdToExecute18.ExecuteNonQuery();

                    #endregion USP_StuRegistrationPreQualificationCollegeTransaction_Insert For    Post Graduation Details

                    #region USP_StuRegistrationQualifyingSelectionInfo_Insert


                    cmdToExecute19.CommandText = "dbo.USP_StuRegistrationQualifyingSelectionInfo_Insert ";
                    cmdToExecute19.CommandType = CommandType.StoredProcedure;
                    //  cmdToExecute19.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 10, ParameterDirection.Output, false, 0, 0, "", DataRowVersion.Proposed, item.Student_QualificationTransactionID));
                    cmdToExecute19.Parameters.Add(new SqlParameter("@iStudentRegistrationID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.ID));
                    if (item.Student_DTE_DTEUserID != null)
                    {
                        cmdToExecute19.Parameters.Add(new SqlParameter("@nsUserId", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_DTE_DTEUserID));
                    }
                    else
                    {
                        cmdToExecute19.Parameters.Add(new SqlParameter("@nsUserId", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.Student_DTE_DTEPassword != null)
                    {
                        cmdToExecute19.Parameters.Add(new SqlParameter("@nsUserPassword", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_DTE_DTEPassword));
                    }
                    else
                    {
                        cmdToExecute19.Parameters.Add(new SqlParameter("@nsUserPassword", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.Student_DTE_DTESrNo != null)
                    {
                        cmdToExecute19.Parameters.Add(new SqlParameter("@nsSerialNumber", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_DTE_DTESrNo));
                    }
                    else
                    {
                        cmdToExecute19.Parameters.Add(new SqlParameter("@nsSerialNumber", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.Student_DTE_DTEMeritNo != null)
                    {
                        cmdToExecute19.Parameters.Add(new SqlParameter("@nsMeritNumber", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_DTE_DTEMeritNo));
                    }
                    else
                    {
                        cmdToExecute19.Parameters.Add(new SqlParameter("@nsMeritNumber", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    cmdToExecute19.Parameters.Add(new SqlParameter("@sAdmissionType", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_DTE_AdmissionTypeId));
                    cmdToExecute19.Parameters.Add(new SqlParameter("@sAdmissionRound", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_DTE_AdmissionRound));
                    cmdToExecute19.Parameters.Add(new SqlParameter("@iAdmissionCategoryID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_DTE_AdmissionCategoryId));
                    if (item.Student_DTE_DTESeatNo != null)
                    {
                        cmdToExecute19.Parameters.Add(new SqlParameter("@sSeatType", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_DTE_DTESeatNo));
                    }
                    else
                    {
                        cmdToExecute19.Parameters.Add(new SqlParameter("@sSeatType", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }

                    if (item.Student_DTE_QualifyingExamName != null)
                    {
                        cmdToExecute19.Parameters.Add(new SqlParameter("@sQualifyingExaminationName", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_DTE_QualifyingExamName));
                    }
                    else
                    {
                        cmdToExecute19.Parameters.Add(new SqlParameter("@sQualifyingExaminationName", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    cmdToExecute19.Parameters.Add(new SqlParameter("@iMarksObtained", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_DTE_QualifyingExamMarks));

                    cmdToExecute19.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute19.Parameters.Add(new SqlParameter("@iCreatedBy", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.StudentSelfRegistrationID));

                    cmdToExecute19.Transaction = transaction;
                    _rowsAffected = cmdToExecute19.ExecuteNonQuery();

                    #endregion USP_StuRegistrationQualifyingSelectionInfo_Insert

                    #region USP_StuRegistrationDocumentFlag_InsertXML


                    cmdToExecute20.CommandText = "dbo.USP_StuRegistrationDocumentFlag_Insert ";
                    cmdToExecute20.CommandType = CommandType.StoredProcedure;
                    //  cmdToExecute20.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 10, ParameterDirection.Output, false, 0, 0, "", DataRowVersion.Proposed, item.Student_QualificationTransactionID));
                    cmdToExecute20.Parameters.Add(new SqlParameter("@iStudentRegistrationID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.ID));

                    cmdToExecute20.Parameters.Add(new SqlParameter("@bSubmitedDocument1", SqlDbType.Bit, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_AdmissionDocuments_JETMarkSheet));
                    cmdToExecute20.Parameters.Add(new SqlParameter("@bSubmitedDocument2", SqlDbType.Bit, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_AdmissionDocuments_AllotmentLetter));
                    cmdToExecute20.Parameters.Add(new SqlParameter("@bSubmitedDocument3", SqlDbType.Bit, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_AdmissionDocuments_TenthMarkSheet));
                    cmdToExecute20.Parameters.Add(new SqlParameter("@bSubmitedDocument4", SqlDbType.Bit, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_AdmissionDocuments_TwelvethMarkSheet));
                    cmdToExecute20.Parameters.Add(new SqlParameter("@bSubmitedDocument5", SqlDbType.Bit, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_AdmissionDocuments_AllDiplomaMarksheet));
                    cmdToExecute20.Parameters.Add(new SqlParameter("@bSubmitedDocument6", SqlDbType.Bit, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_AdmissionDocuments_LeavingCertificate));
                    cmdToExecute20.Parameters.Add(new SqlParameter("@bSubmitedDocument7", SqlDbType.Bit, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_AdmissionDocuments_Domicile_BirthCertificate));
                    cmdToExecute20.Parameters.Add(new SqlParameter("@bSubmitedDocument8", SqlDbType.Bit, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_AdmissionDocuments_NationalityCertificate));
                    cmdToExecute20.Parameters.Add(new SqlParameter("@bSubmitedDocument9", SqlDbType.Bit, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_AdmissionDocuments_CasteCertificate));
                    cmdToExecute20.Parameters.Add(new SqlParameter("@bSubmitedDocument10", SqlDbType.Bit, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_AdmissionDocuments_CasteValidityCertificate));
                    cmdToExecute20.Parameters.Add(new SqlParameter("@bSubmitedDocument11", SqlDbType.Bit, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_AdmissionDocuments_NonCreamylayerCertificate));
                    cmdToExecute20.Parameters.Add(new SqlParameter("@bSubmitedDocument12", SqlDbType.Bit, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_AdmissionDocuments_EquivalenceCertificate));
                    cmdToExecute20.Parameters.Add(new SqlParameter("@bSubmitedDocument13", SqlDbType.Bit, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_AdmissionDocuments_MigrationCertificate));
                    cmdToExecute20.Parameters.Add(new SqlParameter("@bSubmitedDocument14", SqlDbType.Bit, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_AdmissionDocuments_GapCertificate));
                    cmdToExecute20.Parameters.Add(new SqlParameter("@bSubmitedDocument15", SqlDbType.Bit, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_AdmissionDocuments_AntiRaggingAffidavit));
                    cmdToExecute20.Parameters.Add(new SqlParameter("@bSubmitedDocument16", SqlDbType.Bit, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_AdmissionDocuments_Proforma_Fand_F1_On_DoctorsLetter_Head));
                    cmdToExecute20.Parameters.Add(new SqlParameter("@bSubmitedDocument17", SqlDbType.Bit, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_AdmissionDocuments_Proforma_I));
                    cmdToExecute20.Parameters.Add(new SqlParameter("@bSubmitedDocument18", SqlDbType.Bit, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_AdmissionDocuments_ProformaG1));
                    cmdToExecute20.Parameters.Add(new SqlParameter("@bSubmitedDocument19", SqlDbType.Bit, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_AdmissionDocuments_ProformaG2));
                    cmdToExecute20.Parameters.Add(new SqlParameter("@bSubmitedDocument20", SqlDbType.Bit, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_AdmissionDocuments_Proforma_C_D_E));
                    cmdToExecute20.Parameters.Add(new SqlParameter("@bSubmitedDocument21", SqlDbType.Bit, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_AdmissionDocuments_FathersIncomeCertificate));
                    cmdToExecute20.Parameters.Add(new SqlParameter("@bSubmitedDocument22", SqlDbType.Bit, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_AdmissionDocuments_AadharCardXerox));
                    cmdToExecute20.Parameters.Add(new SqlParameter("@bSubmitedDocument23", SqlDbType.Bit, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_AdmissionDocuments_B_WPhoto_I_card_size));
                    cmdToExecute20.Parameters.Add(new SqlParameter("@bSubmitedDocument24", SqlDbType.Bit, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_AdmissionDocuments_Colour_photo));

                    ////  If Applicable
                    cmdToExecute20.Parameters.Add(new SqlParameter("@bSubmitedDocument25", SqlDbType.Bit, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_AdmissionDocuments_PGStudents_DegreeMarksheet));
                    cmdToExecute20.Parameters.Add(new SqlParameter("@bSubmitedDocument26", SqlDbType.Bit, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_AdmissionDocuments_PGStudents_DegreeCertificate));
                    cmdToExecute20.Parameters.Add(new SqlParameter("@bSubmitedDocument27", SqlDbType.Bit, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_AdmissionDocuments_PGStudents_GateScoreCard));
                    cmdToExecute20.Parameters.Add(new SqlParameter("@bSubmitedDocument28", SqlDbType.Bit, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_AdmissionDocuments_PGStudents_SponsorshipLetterforSponsoredCandidate));




                    cmdToExecute20.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute20.Parameters.Add(new SqlParameter("@iCreatedBy", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.StudentSelfRegistrationID));

                    cmdToExecute20.Transaction = transaction;
                    _rowsAffected = cmdToExecute20.ExecuteNonQuery();

                    #endregion USP_StuRegistrationQualifyingSelectionInfo_Insert

                    #region USP_StuRegistrationDocumentSubmitted_InsertXML


                    cmdToExecute21.CommandText = "dbo.USP_StuRegistrationDocumentSubmitted_InsertXML ";
                    cmdToExecute21.CommandType = CommandType.StoredProcedure;
                    cmdToExecute21.Parameters.Add(new SqlParameter("@iStudentRegistrationID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.ID));
                    cmdToExecute21.Parameters.Add(new SqlParameter("@iAcadSessionId ", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_AcademicYearId));
                    if (item.StudentSubmitedDocumentIDs != null || item.StudentSubmitedDocumentIDs != "")
                    {
                        cmdToExecute21.Parameters.Add(new SqlParameter("@nsIDs", SqlDbType.NVarChar, 4000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.StudentSubmitedDocumentIDs));
                    }
                    else
                    {
                        cmdToExecute21.Parameters.Add(new SqlParameter("@nsIDs", SqlDbType.NVarChar, 4000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    cmdToExecute21.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute21.Parameters.Add(new SqlParameter("@iCreatedBy", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.StudentSelfRegistrationID));

                    cmdToExecute21.Transaction = transaction;
                    _rowsAffected = cmdToExecute21.ExecuteNonQuery();

                    #endregion USP_StuRegistrationDocumentSubmitted_InsertXML

                    #region USP_stuRegistrationAddressDetails_Insert


                    cmdToExecute22.CommandText = "dbo.USP_stuRegistrationAddressDetails_Insert ";
                    cmdToExecute22.CommandType = CommandType.StoredProcedure;
                    //  cmdToExecute22.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 10, ParameterDirection.Output, false, 0, 0, "", DataRowVersion.Proposed, item.Student_QualificationTransactionID));
                    cmdToExecute22.Parameters.Add(new SqlParameter("@iStudentRegistrationID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.ID));
                    cmdToExecute22.Parameters.Add(new SqlParameter("@cAddressType", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, "P"));
                    if (item.Student_PermanentAddress_Address1 != null)
                    {
                        cmdToExecute22.Parameters.Add(new SqlParameter("@nsAddressLine1", SqlDbType.NVarChar, 150, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_PermanentAddress_Address1));
                    }
                    else
                    {
                        cmdToExecute22.Parameters.Add(new SqlParameter("@nsAddressLine1", SqlDbType.NVarChar, 150, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.Student_PermanentAddress_Address2 != null)
                    {
                        cmdToExecute22.Parameters.Add(new SqlParameter("@nsAddressLine2", SqlDbType.NVarChar, 150, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_PermanentAddress_Address2));
                    }
                    else
                    {
                        cmdToExecute22.Parameters.Add(new SqlParameter("@nsAddressLine2", SqlDbType.NVarChar, 150, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.Student_PermanentAddress_PloteNo != null)
                    {
                        cmdToExecute22.Parameters.Add(new SqlParameter("@nsPlotNumber", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_PermanentAddress_PloteNo));
                    }
                    else
                    {
                        cmdToExecute22.Parameters.Add(new SqlParameter("@nsPlotNumber", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.Student_PermanentAddress_StreeNo != null)
                    {
                        cmdToExecute22.Parameters.Add(new SqlParameter("@nsStreet", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_PermanentAddress_StreeNo));
                    }
                    else
                    {
                        cmdToExecute22.Parameters.Add(new SqlParameter("@nsStreet", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    cmdToExecute22.Parameters.Add(new SqlParameter("@iCountryId", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_PermanentAddress_CountryId));
                    cmdToExecute22.Parameters.Add(new SqlParameter("@iRegionId", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_PermanentAddress_State));
                    if (item.Student_PermanentAddress_StateOther != null)
                    {
                        cmdToExecute22.Parameters.Add(new SqlParameter("@nsRegionOther", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_PermanentAddress_StateOther));
                    }
                    else
                    {
                        cmdToExecute22.Parameters.Add(new SqlParameter("@nsRegionOther", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    cmdToExecute22.Parameters.Add(new SqlParameter("@iCityId", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_PermanentAddress_DistrictID));
                    if (item.Student_PermanentAddress_DistrictOther != null)
                    {
                        cmdToExecute22.Parameters.Add(new SqlParameter("@nsCityOther", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_PermanentAddress_DistrictOther));
                    }
                    else
                    {
                        cmdToExecute22.Parameters.Add(new SqlParameter("@nsCityOther", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    cmdToExecute22.Parameters.Add(new SqlParameter("@iLocationId", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_PermanentAddress_City_TahsilID));
                    if (item.Student_PermanentAddress_City_TahsilOther != null)
                    {
                        cmdToExecute22.Parameters.Add(new SqlParameter("@nsLocationOther", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_PermanentAddress_City_TahsilOther));
                    }
                    else
                    {
                        cmdToExecute22.Parameters.Add(new SqlParameter("@nsLocationOther", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.Student_PermanentAddress_NearPoliceStation != null)
                    {
                        cmdToExecute22.Parameters.Add(new SqlParameter("@nsNearPoliceStation", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_PermanentAddress_NearPoliceStation));
                    }
                    else
                    {
                        cmdToExecute22.Parameters.Add(new SqlParameter("@nsNearPoliceStation", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.Student_PermanentAddress_Tahsil != null)
                    {
                        cmdToExecute22.Parameters.Add(new SqlParameter("@nsTahsil", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_PermanentAddress_Tahsil));
                    }
                    else
                    {
                        cmdToExecute22.Parameters.Add(new SqlParameter("@nsTahsil", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.Student_PermanentAddress_ZipCode != null)
                    {
                        cmdToExecute22.Parameters.Add(new SqlParameter("@nsZipCode", SqlDbType.NVarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_PermanentAddress_ZipCode));
                    }
                    else
                    {
                        cmdToExecute22.Parameters.Add(new SqlParameter("@nsZipCode", SqlDbType.NVarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }

                    if (item.Student_PermanentAddress_City_Tahsil_Pattern != null)
                    {
                        cmdToExecute22.Parameters.Add(new SqlParameter("@nsCityTahsilPattern", SqlDbType.NVarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_PermanentAddress_City_Tahsil_Pattern));
                    }
                    else
                    {
                        cmdToExecute22.Parameters.Add(new SqlParameter("@nsCityTahsilPattern", SqlDbType.NVarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value)); 
                    }
                    

                    cmdToExecute22.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute22.Parameters.Add(new SqlParameter("@iCreatedBy", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.StudentSelfRegistrationID));

                    cmdToExecute22.Transaction = transaction;
                    _rowsAffected = cmdToExecute22.ExecuteNonQuery();

                    #endregion USP_stuRegistrationAddressDetails_Insert

                    #region USP_stuRegistrationAddressDetails_Insert For   Correspondence Address

                    if (item.SameAsPerPermanentAddress == true)
                    {

                        cmdToExecute23.CommandText = "dbo.USP_stuRegistrationAddressDetails_Insert ";
                        cmdToExecute23.CommandType = CommandType.StoredProcedure;
                        //  cmdToExecute23.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 10, ParameterDirection.Output, false, 0, 0, "", DataRowVersion.Proposed, item.Student_QualificationTransactionID));
                        cmdToExecute23.Parameters.Add(new SqlParameter("@iStudentRegistrationID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.ID));
                        cmdToExecute23.Parameters.Add(new SqlParameter("@cAddressType", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, "C"));
                        if (item.Student_PermanentAddress_Address1 != null)
                        {
                            cmdToExecute23.Parameters.Add(new SqlParameter("@nsAddressLine1", SqlDbType.NVarChar, 150, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_PermanentAddress_Address1));
                        }
                        else
                        {
                            cmdToExecute23.Parameters.Add(new SqlParameter("@nsAddressLine1", SqlDbType.NVarChar, 150, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                        }
                        if (item.Student_PermanentAddress_Address2 != null)
                        {
                            cmdToExecute23.Parameters.Add(new SqlParameter("@nsAddressLine2", SqlDbType.NVarChar, 150, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_PermanentAddress_Address2));
                        }
                        else
                        {
                            cmdToExecute23.Parameters.Add(new SqlParameter("@nsAddressLine2", SqlDbType.NVarChar, 150, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                        }
                        if (item.Student_PermanentAddress_PloteNo != null)
                        {
                            cmdToExecute23.Parameters.Add(new SqlParameter("@nsPlotNumber", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_PermanentAddress_PloteNo));
                        }
                        else
                        {
                            cmdToExecute23.Parameters.Add(new SqlParameter("@nsPlotNumber", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                        }
                        if (item.Student_PermanentAddress_StreeNo != null)
                        {
                            cmdToExecute23.Parameters.Add(new SqlParameter("@nsStreet", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_PermanentAddress_StreeNo));
                        }
                        else
                        {
                            cmdToExecute23.Parameters.Add(new SqlParameter("@nsStreet", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                        }
                        cmdToExecute23.Parameters.Add(new SqlParameter("@iCountryId", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_PermanentAddress_CountryId));
                        cmdToExecute23.Parameters.Add(new SqlParameter("@iRegionId", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_PermanentAddress_State));
                        if (item.Student_PermanentAddress_StateOther != null)
                        {
                            cmdToExecute23.Parameters.Add(new SqlParameter("@nsRegionOther", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_PermanentAddress_StateOther));
                        }
                        else
                        {
                            cmdToExecute23.Parameters.Add(new SqlParameter("@nsRegionOther", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                        }
                        cmdToExecute23.Parameters.Add(new SqlParameter("@iCityId", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_PermanentAddress_DistrictID));
                        if (item.Student_PermanentAddress_DistrictOther != null)
                        {
                            cmdToExecute23.Parameters.Add(new SqlParameter("@nsCityOther", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_PermanentAddress_DistrictOther));
                        }
                        else
                        {
                            cmdToExecute23.Parameters.Add(new SqlParameter("@nsCityOther", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                        }
                        cmdToExecute23.Parameters.Add(new SqlParameter("@iLocationId", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_PermanentAddress_City_TahsilID));
                        if (item.Student_PermanentAddress_City_TahsilOther != null)
                        {
                            cmdToExecute23.Parameters.Add(new SqlParameter("@nsLocationOther", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_PermanentAddress_City_TahsilOther));
                        }
                        else
                        {
                            cmdToExecute23.Parameters.Add(new SqlParameter("@nsLocationOther", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                        }
                        if (item.Student_PermanentAddress_NearPoliceStation != null)
                        {
                            cmdToExecute23.Parameters.Add(new SqlParameter("@nsNearPoliceStation", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_PermanentAddress_NearPoliceStation));
                        }
                        else
                        {
                            cmdToExecute23.Parameters.Add(new SqlParameter("@nsNearPoliceStation", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                        }
                        if (item.Student_PermanentAddress_Tahsil != null)
                        {
                            cmdToExecute23.Parameters.Add(new SqlParameter("@nsTahsil", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_PermanentAddress_Tahsil));
                        }
                        else
                        {
                            cmdToExecute23.Parameters.Add(new SqlParameter("@nsTahsil", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                        }
                        if (item.Student_PermanentAddress_ZipCode != null)
                        {
                            cmdToExecute23.Parameters.Add(new SqlParameter("@nsZipCode", SqlDbType.NVarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_PermanentAddress_ZipCode));
                        }
                        else
                        {
                            cmdToExecute23.Parameters.Add(new SqlParameter("@nsZipCode", SqlDbType.NVarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                        }
                        if (item.Student_PermanentAddress_City_Tahsil_Pattern != null)
                        {
                            cmdToExecute23.Parameters.Add(new SqlParameter("@nsCityTahsilPattern", SqlDbType.NVarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_PermanentAddress_City_Tahsil_Pattern));
                        }
                        else
                        {
                            cmdToExecute23.Parameters.Add(new SqlParameter("@nsCityTahsilPattern", SqlDbType.NVarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                        }
                        cmdToExecute23.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                        cmdToExecute23.Parameters.Add(new SqlParameter("@iCreatedBy", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.StudentSelfRegistrationID));

                        cmdToExecute23.Transaction = transaction;
                        _rowsAffected = cmdToExecute23.ExecuteNonQuery();
                    }

                    else
                    {
                        cmdToExecute23.CommandText = "dbo.USP_stuRegistrationAddressDetails_Insert ";
                        cmdToExecute23.CommandType = CommandType.StoredProcedure;
                        //  cmdToExecute23.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 10, ParameterDirection.Output, false, 0, 0, "", DataRowVersion.Proposed, item.Student_QualificationTransactionID));
                        cmdToExecute23.Parameters.Add(new SqlParameter("@iStudentRegistrationID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.ID));
                        cmdToExecute23.Parameters.Add(new SqlParameter("@cAddressType", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, "C"));
                        if (item.Student_CorrespondenceAddress_Address1 != null)
                        {
                            cmdToExecute23.Parameters.Add(new SqlParameter("@nsAddressLine1", SqlDbType.NVarChar, 150, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_CorrespondenceAddress_Address1));
                        }
                        else
                        {
                            cmdToExecute23.Parameters.Add(new SqlParameter("@nsAddressLine1", SqlDbType.NVarChar, 150, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                        }
                        if (item.Student_CorrespondenceAddress_Address2 != null)
                        {
                            cmdToExecute23.Parameters.Add(new SqlParameter("@nsAddressLine2", SqlDbType.NVarChar, 150, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_CorrespondenceAddress_Address2));
                        }
                        else
                        {
                            cmdToExecute23.Parameters.Add(new SqlParameter("@nsAddressLine2", SqlDbType.NVarChar, 150, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                        }
                        if (item.Student_CorrespondenceAddress_PloteNo != null)
                        {
                            cmdToExecute23.Parameters.Add(new SqlParameter("@nsPlotNumber", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_CorrespondenceAddress_PloteNo));
                        }
                        else
                        {
                            cmdToExecute23.Parameters.Add(new SqlParameter("@nsPlotNumber", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                        }
                        if (item.Student_CorrespondenceAddress_StreeNo != null)
                        {
                            cmdToExecute23.Parameters.Add(new SqlParameter("@nsStreet", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_CorrespondenceAddress_StreeNo));
                        }
                        else
                        {
                            cmdToExecute23.Parameters.Add(new SqlParameter("@nsStreet", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                        }
                        cmdToExecute23.Parameters.Add(new SqlParameter("@iCountryId", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_CorrespondenceAddress_CountryId));
                        cmdToExecute23.Parameters.Add(new SqlParameter("@iRegionId", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_CorrespondenceAddress_State));
                        if (item.Student_CorrespondenceAddress_StateOther != null)
                        {
                            cmdToExecute23.Parameters.Add(new SqlParameter("@nsRegionOther", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_CorrespondenceAddress_StateOther));
                        }
                        else
                        {
                            cmdToExecute23.Parameters.Add(new SqlParameter("@nsRegionOther", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                        }
                        cmdToExecute23.Parameters.Add(new SqlParameter("@iCityId", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_CorrespondenceAddress_DistrictID));
                        if (item.Student_CorrespondenceAddress_DistrictOther != null)
                        {
                            cmdToExecute23.Parameters.Add(new SqlParameter("@nsCityOther", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_CorrespondenceAddress_DistrictOther));
                        }
                        else
                        {
                            cmdToExecute23.Parameters.Add(new SqlParameter("@nsCityOther", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                        }
                        cmdToExecute23.Parameters.Add(new SqlParameter("@iLocationId", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_CorrespondenceAddress_City_TahsilID));
                        if (item.Student_CorrespondenceAddress_City_TahsilOther != null)
                        {
                            cmdToExecute23.Parameters.Add(new SqlParameter("@nsLocationOther", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_CorrespondenceAddress_City_TahsilOther));
                        }
                        else
                        {
                            cmdToExecute23.Parameters.Add(new SqlParameter("@nsLocationOther", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                        }
                        if (item.Student_CorrespondenceAddress_NearPoliceStation != null)
                        {
                            cmdToExecute23.Parameters.Add(new SqlParameter("@nsNearPoliceStation", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_CorrespondenceAddress_NearPoliceStation));
                        }
                        else
                        {
                            cmdToExecute23.Parameters.Add(new SqlParameter("@nsNearPoliceStation", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                        }
                        if (item.Student_CorrespondenceAddress_Tahsil != null)
                        {
                            cmdToExecute23.Parameters.Add(new SqlParameter("@nsTahsil", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_CorrespondenceAddress_Tahsil));
                        }
                        else
                        {
                            cmdToExecute23.Parameters.Add(new SqlParameter("@nsTahsil", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                        }
                        if (item.Student_CorrespondenceAddress_ZipCode != null)
                        {
                            cmdToExecute23.Parameters.Add(new SqlParameter("@nsZipCode", SqlDbType.NVarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_CorrespondenceAddress_ZipCode));
                        }
                        else
                        {
                            cmdToExecute23.Parameters.Add(new SqlParameter("@nsZipCode", SqlDbType.NVarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                        }
                        if (item.Student_PermanentAddress_City_Tahsil_Pattern != null)
                        {
                            cmdToExecute23.Parameters.Add(new SqlParameter("@nsCityTahsilPattern", SqlDbType.NVarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_PermanentAddress_City_Tahsil_Pattern));
                        }
                        else
                        {
                            cmdToExecute23.Parameters.Add(new SqlParameter("@nsCityTahsilPattern", SqlDbType.NVarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                        }

                        cmdToExecute23.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                        cmdToExecute23.Parameters.Add(new SqlParameter("@iCreatedBy", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.StudentSelfRegistrationID));

                        cmdToExecute23.Transaction = transaction;
                        _rowsAffected = cmdToExecute23.ExecuteNonQuery();


                    }
                    #endregion USP_stuRegistrationAddressDetails_Insert

                    #region USP_StuRegistrationPreviousWorkExperience_InsertXML

                    cmdToExecute26.CommandText = "dbo.USP_StuRegistrationPreviousWorkExperience_InsertXML ";
                    cmdToExecute26.CommandType = CommandType.StoredProcedure;

                    cmdToExecute26.Parameters.Add(new SqlParameter("@iStudentRegistrationID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.ID));
                    if (!string.IsNullOrEmpty(item.WorkExperienceXML))
                    {
                        cmdToExecute26.Parameters.Add(new SqlParameter("@xWorkExperienceXML", SqlDbType.Xml, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.WorkExperienceXML));
                    }
                    else
                    {
                        cmdToExecute26.Parameters.Add(new SqlParameter("@xWorkExperienceXML", SqlDbType.Xml, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    cmdToExecute26.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute26.Parameters.Add(new SqlParameter("@iCreatedBy", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.StudentSelfRegistrationID));

                    cmdToExecute26.Transaction = transaction;
                    _rowsAffected = cmdToExecute26.ExecuteNonQuery();

                    #endregion USP_StuRegistrationPreviousWorkExperience_InsertXML

                    #region USP_GeneralTaskApproverNotification_Insert

                    if (item.IsTaskGeneratedForApproval == true)
                    {
                        cmdToExecute24.CommandText = "dbo.USP_GeneralTaskApproverNotification_Insert";
                        cmdToExecute24.CommandType = CommandType.StoredProcedure;
                        cmdToExecute24.Parameters.Add(new SqlParameter("@nsMenuCode", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, "Stu_StudentRegistrationApplication"));
                        cmdToExecute24.Parameters.Add(new SqlParameter("@nsCentreCode", SqlDbType.NVarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.CenterCode));
                        cmdToExecute24.Parameters.Add(new SqlParameter("@sTaskApprovalBasedTable", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, "StuRegistrationStudentMaster"));
                        cmdToExecute24.Parameters.Add(new SqlParameter("@sTaskApprovalParamPrimaryKey", SqlDbType.VarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, "ID"));
                        cmdToExecute24.Parameters.Add(new SqlParameter("@iTaskApprovalKeyValue", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                        cmdToExecute24.Parameters.Add(new SqlParameter("@iStageSequenceNumber", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, 1));
                        cmdToExecute24.Parameters.Add(new SqlParameter("@sEntitytableName", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, "StuRegistrationStudentMaster"));
                        cmdToExecute24.Parameters.Add(new SqlParameter("@sEntityPKName", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, "ID"));
                        cmdToExecute24.Parameters.Add(new SqlParameter("@iEntityPKValue", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.ID));
                        cmdToExecute24.Parameters.Add(new SqlParameter("@iPersonID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.ID));
                        cmdToExecute24.Parameters.Add(new SqlParameter("@cPersonType", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, 'R'));
                        cmdToExecute24.Parameters.Add(new SqlParameter("@iApprovalStatus", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, 1));
                        cmdToExecute24.Parameters.Add(new SqlParameter("@iCreatedBy", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.ID));
                        cmdToExecute24.Parameters.Add(new SqlParameter("@iTaskNotificationMasterID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, 0));
                        cmdToExecute24.Parameters.Add(new SqlParameter("@iTaskNotificationDetailsID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, 0));
                        cmdToExecute24.Parameters.Add(new SqlParameter("@bIsLast", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, 0));
                        cmdToExecute24.Parameters.Add(new SqlParameter("@dRangeValue", SqlDbType.Decimal, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                        cmdToExecute24.Parameters.Add(new SqlParameter("@iStatus", SqlDbType.Int, 10, ParameterDirection.Output, false, 0, 0, "", DataRowVersion.Proposed, item.Status));
                        cmdToExecute24.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));

                        
                        cmdToExecute24.Transaction = transaction;
                        _rowsAffected = cmdToExecute24.ExecuteNonQuery();

                        cmdToExecute25.CommandText = "dbo.USP_StuRegistration_Update";
                        cmdToExecute25.CommandType = CommandType.StoredProcedure;
                        cmdToExecute25.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.StudentSelfRegistrationID));
                        cmdToExecute25.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                        cmdToExecute25.Transaction = transaction;
                        _rowsAffected = cmdToExecute25.ExecuteNonQuery();
                    #endregion USP_GeneralTaskApproverNotification_Insert


                    }
                    transaction.Commit();
                }
            }
            catch (SqlException ex)
            {
                transaction.Rollback();
                //transaction1.Rollback();
                response.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                _logException.Error(ex.Message);
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                response.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                _logException.Error(ex.Message);
            }
            finally
            {
                if (_mainConnectionIsCreatedLocal)
                {
                    // Close connection.
                    _mainConnection.Close();
                }
                response.Entity = item;
                cmdToExecute.Dispose();
                cmdToExecute1.Dispose();
                cmdToExecute2.Dispose();
                cmdToExecute3.Dispose();
                cmdToExecute4.Dispose();
                cmdToExecute5.Dispose();
                cmdToExecute6.Dispose();
                cmdToExecute7.Dispose();
                cmdToExecute8.Dispose();
                cmdToExecute9.Dispose();
                cmdToExecute10.Dispose();
                cmdToExecute11.Dispose();
                cmdToExecute12.Dispose();
                cmdToExecute13.Dispose();
                cmdToExecute14.Dispose();
                cmdToExecute15.Dispose();
                cmdToExecute16.Dispose();
                cmdToExecute17.Dispose();
                cmdToExecute18.Dispose();
                cmdToExecute19.Dispose();
                cmdToExecute20.Dispose();
                cmdToExecute21.Dispose();
                cmdToExecute22.Dispose();
                cmdToExecute23.Dispose();
                cmdToExecute24.Dispose();
                cmdToExecute25.Dispose();
                cmdToExecute26.Dispose();
            }
            return response;
        }

        public IBaseEntityResponse<StudentRegistrationForm> UpdateStudentRegistrationForm(StudentRegistrationForm item)
        {
            IBaseEntityResponse<StudentRegistrationForm> response = new BaseEntityResponse<StudentRegistrationForm>();
            SqlCommand cmdToExecute = new SqlCommand();
            SqlCommand cmdToExecute1 = new SqlCommand();
            SqlCommand cmdToExecute2 = new SqlCommand();
            SqlCommand cmdToExecute3 = new SqlCommand();
            SqlCommand cmdToExecute4 = new SqlCommand();
            SqlCommand cmdToExecute5 = new SqlCommand();
            SqlCommand cmdToExecute6 = new SqlCommand();
            SqlCommand cmdToExecute7 = new SqlCommand();
            SqlCommand cmdToExecute8 = new SqlCommand();
            SqlCommand cmdToExecute9 = new SqlCommand();
            SqlCommand cmdToExecute10 = new SqlCommand();
            SqlCommand cmdToExecute11 = new SqlCommand();
            SqlCommand cmdToExecute12 = new SqlCommand();
            SqlCommand cmdToExecute13 = new SqlCommand();
            SqlCommand cmdToExecute14 = new SqlCommand();
            SqlCommand cmdToExecute15 = new SqlCommand();
            SqlCommand cmdToExecute16 = new SqlCommand();
            SqlCommand cmdToExecute17 = new SqlCommand();
            SqlCommand cmdToExecute18 = new SqlCommand();
            SqlCommand cmdToExecute19 = new SqlCommand();
            SqlCommand cmdToExecute20 = new SqlCommand();
            SqlCommand cmdToExecute21 = new SqlCommand();
            SqlCommand cmdToExecute22 = new SqlCommand();
            SqlCommand cmdToExecute23 = new SqlCommand();
            SqlCommand cmdToExecute24 = new SqlCommand();
            SqlCommand cmdToExecute25 = new SqlCommand();
            SqlCommand cmdToExecute26 = new SqlCommand();
            SqlTransaction transaction = null;


            try
            {
                if (string.IsNullOrEmpty(item.ConnectionString))
                {
                    response.Message.Add(new MessageDTO()
                    {
                        ErrorMessage = "Connection string is empty.",
                        MessageType = MessageTypeEnum.Error
                    });
                }
                else
                {
                    _mainConnection.ConnectionString = item.ConnectionString;
                    cmdToExecute.Connection = _mainConnection;
                    cmdToExecute1.Connection = _mainConnection;
                    cmdToExecute2.Connection = _mainConnection;
                    cmdToExecute3.Connection = _mainConnection;
                    cmdToExecute4.Connection = _mainConnection;
                    cmdToExecute5.Connection = _mainConnection;
                    cmdToExecute6.Connection = _mainConnection;
                    cmdToExecute7.Connection = _mainConnection;
                    cmdToExecute8.Connection = _mainConnection;
                    cmdToExecute9.Connection = _mainConnection;
                    cmdToExecute10.Connection = _mainConnection;
                    cmdToExecute11.Connection = _mainConnection;
                    cmdToExecute12.Connection = _mainConnection;
                    cmdToExecute13.Connection = _mainConnection;
                    cmdToExecute14.Connection = _mainConnection;
                    cmdToExecute15.Connection = _mainConnection;
                    cmdToExecute16.Connection = _mainConnection;
                    cmdToExecute17.Connection = _mainConnection;
                    cmdToExecute18.Connection = _mainConnection;
                    cmdToExecute19.Connection = _mainConnection;
                    cmdToExecute20.Connection = _mainConnection;
                    cmdToExecute21.Connection = _mainConnection;
                    cmdToExecute22.Connection = _mainConnection;
                    cmdToExecute23.Connection = _mainConnection;
                    cmdToExecute24.Connection = _mainConnection;
                    cmdToExecute25.Connection = _mainConnection;
                    cmdToExecute26.Connection = _mainConnection;
                    


                    #region USP_StuWebStudentRegistration_Update

                    cmdToExecute.CommandText = "dbo.USP_StuRegistrationStudentMaster_Update";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.ID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@daDateOfRegistration", SqlDbType.DateTime, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_DateofRegistration));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsTitle", SqlDbType.NVarChar, 0, ParameterDirection.Input, false, 20, 0, "", DataRowVersion.Proposed, item.StudentTitle));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsFirstName", SqlDbType.NVarChar, 0, ParameterDirection.Input, false, 50, 0, "", DataRowVersion.Proposed, item.StudentFirstName));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsMiddleName", SqlDbType.NVarChar, 0, ParameterDirection.Input, false, 50, 0, "", DataRowVersion.Proposed, (item.StudentMiddleName != null) ? item.StudentMiddleName : string.Empty));
                    if (item.StudentLastName != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsLastName", SqlDbType.NVarChar, 0, ParameterDirection.Input, false, 50, 0, "", DataRowVersion.Proposed, item.StudentLastName));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsLastName", SqlDbType.NVarChar, 0, ParameterDirection.Input, false, 50, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.MotherFirstName != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsMotherName", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, item.MotherFirstName));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsMotherName", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    //  cmdToExecute.Parameters.Add(new SqlParameter("@sStudentOccupation", SqlDbType.VarChar, 0, ParameterDirection.Input, false, 50, 0, "", DataRowVersion.Proposed, item.StudentOccupation));
                    if (item.MotherFirstName != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsStudentMobileNumber", SqlDbType.NVarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.StudentMobileNumber));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsStudentMobileNumber", SqlDbType.NVarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.FatherMobileNumber != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsParentMobileNumber", SqlDbType.NVarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.FatherMobileNumber));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsParentMobileNumber", SqlDbType.NVarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.GuardianMobileNumber != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsGuardianMobileNumber", SqlDbType.NVarChar, 0, ParameterDirection.Input, false, 15, 0, "", DataRowVersion.Proposed, item.GuardianMobileNumber));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsGuardianMobileNumber", SqlDbType.NVarChar, 0, ParameterDirection.Input, false, 15, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.FatherLandLineNumber != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsParentLandlineNumber", SqlDbType.NVarChar, 0, ParameterDirection.Input, false, 15, 0, "", DataRowVersion.Proposed, item.FatherLandLineNumber));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsParentLandlineNumber", SqlDbType.NVarChar, 0, ParameterDirection.Input, false, 15, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.FatherEmailId != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@sParentEmailID", SqlDbType.VarChar, 0, ParameterDirection.Input, false, 50, 0, "", DataRowVersion.Proposed, item.FatherEmailId));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@sParentEmailID", SqlDbType.VarChar, 0, ParameterDirection.Input, false, 50, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.GuardianEmailId != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@sGuardianEmailID", SqlDbType.VarChar, 0, ParameterDirection.Input, false, 50, 0, "", DataRowVersion.Proposed, item.GuardianEmailId));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@sGuardianEmailID", SqlDbType.VarChar, 0, ParameterDirection.Input, false, 50, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.FatherEmailId != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@sFatherEmailID", SqlDbType.VarChar, 0, ParameterDirection.Input, false, 50, 0, "", DataRowVersion.Proposed, item.FatherEmailId));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@sFatherEmailID", SqlDbType.VarChar, 0, ParameterDirection.Input, false, 50, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.MotherEmailId != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@sMotherEmailID", SqlDbType.VarChar, 0, ParameterDirection.Input, false, 50, 0, "", DataRowVersion.Proposed, item.MotherEmailId));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@sMotherEmailID", SqlDbType.VarChar, 0, ParameterDirection.Input, false, 50, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.StudentEmailID != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@sStudentEmailID", SqlDbType.VarChar, 0, ParameterDirection.Input, false, 50, 0, "", DataRowVersion.Proposed, item.StudentEmailID));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@sStudentEmailID", SqlDbType.VarChar, 0, ParameterDirection.Input, false, 50, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.StudentNameAsPerMarkSheet != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsNameAsPerLeaving", SqlDbType.NVarChar, 0, ParameterDirection.Input, false, 50, 0, "", DataRowVersion.Proposed, item.StudentNameAsPerMarkSheet));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsNameAsPerLeaving", SqlDbType.NVarChar, 0, ParameterDirection.Input, false, 50, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.StudentLastSchool_College != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@sLastSchoolCollegeAttend", SqlDbType.VarChar, 0, ParameterDirection.Input, false, 50, 0, "", DataRowVersion.Proposed, item.StudentLastSchool_College));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@sLastSchoolCollegeAttend", SqlDbType.VarChar, 0, ParameterDirection.Input, false, 50, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.StudentPreviousLC_TCNo != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsPreviousLeavingNumber", SqlDbType.NVarChar, 0, ParameterDirection.Input, false, 50, 0, "", DataRowVersion.Proposed, item.StudentPreviousLC_TCNo));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsPreviousLeavingNumber", SqlDbType.NVarChar, 0, ParameterDirection.Input, false, 50, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.StudentCasteAsPerTC_LC != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsCastAsPerLeaving", SqlDbType.NVarChar, 0, ParameterDirection.Input, false, 50, 0, "", DataRowVersion.Proposed, item.StudentCasteAsPerTC_LC));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsCastAsPerLeaving", SqlDbType.NVarChar, 0, ParameterDirection.Input, false, 50, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.StudentEnrollmentNo != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsCurrentEnrollmentNumber", SqlDbType.NVarChar, 0, ParameterDirection.Input, false, 50, 0, "", DataRowVersion.Proposed, item.StudentEnrollmentNo));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsCurrentEnrollmentNumber", SqlDbType.NVarChar, 0, ParameterDirection.Input, false, 50, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }

                    cmdToExecute.Parameters.Add(new SqlParameter("@siDomicileStateID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.StudentRegionID));
                    if (item.StudentRegionOther != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsDomicileStateOther", SqlDbType.NVarChar, 0, ParameterDirection.Input, false, 50, 0, "", DataRowVersion.Proposed, item.StudentRegionOther));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsDomicileStateOther", SqlDbType.NVarChar, 0, ParameterDirection.Input, false, 50, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    cmdToExecute.Parameters.Add(new SqlParameter("@siDomicileCountryID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_Domesile_CountryId));
                    if (item.StudentMigrationNumber != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsMigrationNumber", SqlDbType.NVarChar, 0, ParameterDirection.Input, false, 50, 0, "", DataRowVersion.Proposed, item.StudentMigrationNumber));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsMigrationNumber", SqlDbType.NVarChar, 0, ParameterDirection.Input, false, 50, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.StudentMigrationDate != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@daMigrationDatetime", SqlDbType.DateTime, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Convert.ToDateTime(item.StudentMigrationDate)));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@daMigrationDatetime", SqlDbType.DateTime, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.Student_DTE_AdmissionCategoryId != 0)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@iAdmissionCategoryID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_DTE_AdmissionCategoryId));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@iAdmissionCategoryID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.StudentCategoryID));
                    }
                    if (item.Student_DTE_AdmissionTypeId != 0)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@iAdmissionTypeID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_DTE_AdmissionTypeId));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@iAdmissionTypeID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, 1));
                    }
                    if (item.Student_Scholarship_HostelDayScholar == "0")
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@bIsHostelResidency", SqlDbType.Bit, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, false));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@bIsHostelResidency", SqlDbType.Bit, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, true));

                    }

                    cmdToExecute.Parameters.Add(new SqlParameter("@iBranchDetailID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.BranchDetailID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iStandardNumber", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.StandardNumber));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iAdmissionPatternID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.AdmissionPattern));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bStudentActiveFlag ", SqlDbType.Bit, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.StudentActiveFlag));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iAcademicYearID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_AcademicYearId));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsCentreCode", SqlDbType.NVarChar, 0, ParameterDirection.Input, false, 50, 0, "", DataRowVersion.Proposed, item.CenterCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iUniversityID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.UniversityID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iCourseYearId", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_CourseYearId));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iSelfRegistrationID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.StudentSelfRegistrationID));

                    if (item.StudentNRI_POI != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsNriPoi", SqlDbType.NVarChar, 0, ParameterDirection.Input, false, 50, 0, "", DataRowVersion.Proposed, item.StudentNRI_POI));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsNriPoi", SqlDbType.NVarChar, 0, ParameterDirection.Input, false, 50, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    
                    cmdToExecute.Parameters.Add(new SqlParameter("@iAllotAdmThrough", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_DTE_AdmissionRound));
                    if (item.Student_Scholarship_Bank_AC_No != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@sBankAccountNumber", SqlDbType.VarChar, 0, ParameterDirection.Input, false, 50, 0, "", DataRowVersion.Proposed, item.Student_Scholarship_Bank_AC_No));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@sBankAccountNumber", SqlDbType.VarChar, 0, ParameterDirection.Input, false, 50, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.Student_Scholarship_Bank_BranchName != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsBankBranchName", SqlDbType.VarChar, 0, ParameterDirection.Input, false, 50, 0, "", DataRowVersion.Proposed, item.Student_Scholarship_Bank_BranchName));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsBankBranchName", SqlDbType.VarChar, 0, ParameterDirection.Input, false, 50, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.Student_Scholarship_Bank_IFSCCode != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsBankIFSCCode", SqlDbType.VarChar, 0, ParameterDirection.Input, false, 20, 0, "", DataRowVersion.Proposed, item.Student_Scholarship_Bank_IFSCCode));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsBankIFSCCode", SqlDbType.VarChar, 0, ParameterDirection.Input, false, 20, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.Student_Scholarship_Bank_MICRCode != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsBankMICRCode", SqlDbType.VarChar, 0, ParameterDirection.Input, false, 20, 0, "", DataRowVersion.Proposed, item.Student_Scholarship_Bank_MICRCode));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsBankMICRCode", SqlDbType.VarChar, 0, ParameterDirection.Input, false, 20, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.Student_Scholarship_AadhaarCardNo != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsUniqueIdentificatinNumber", SqlDbType.VarChar, 0, ParameterDirection.Input, false, 20, 0, "", DataRowVersion.Proposed, item.Student_Scholarship_AadhaarCardNo));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsUniqueIdentificatinNumber", SqlDbType.VarChar, 0, ParameterDirection.Input, false, 20, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.StudentBloodGroup != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@sBloodgroup", SqlDbType.VarChar, 5, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, item.StudentBloodGroup));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@sBloodgroup", SqlDbType.VarChar, 5, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.StudentOccupation != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsStudentOccupation", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.StudentOccupation));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsStudentOccupation", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.Student_QualifyingExamName != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsStudentQualifyingExam", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_QualifyingExamName));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsStudentQualifyingExam", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }

                    cmdToExecute.Parameters.Add(new SqlParameter("@sStudentAcademicYear", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_AcademicYear));

                    cmdToExecute.Parameters.Add(new SqlParameter("@sStudentAdmissionType", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_DTE_AdmissionTypeId));

                    cmdToExecute.Parameters.Add(new SqlParameter("@nsNameOfApplicant", SqlDbType.NVarChar, 40, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.NameOfApplicant));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsTitleOfProject", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.TitleOfProject));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsProjectSummary", SqlDbType.NVarChar, 250, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.ProjectSummary));
                    cmdToExecute.Parameters.Add(new SqlParameter("@tiFeesPaidBy", SqlDbType.TinyInt, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.FeesPaidBy));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iModifiedBy", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.ModifiedBy));

                    if (_mainConnectionIsCreatedLocal)
                    {
                        // Open connection. 
                        _mainConnection.Open();
                    }
                    else
                    {
                        if (_mainConnectionProvider.IsTransactionPending)
                        {
                            cmdToExecute.Transaction = _mainConnectionProvider.CurrentTransaction;
                        }
                    }
                    // Execute query.
                    transaction = _mainConnection.BeginTransaction("SampleTransaction");
                    cmdToExecute.Transaction = transaction;
                    _rowsAffected = cmdToExecute.ExecuteNonQuery();
                    //   item.ID = (Int32)cmdToExecute.Parameters["@iID"].Value;


                    #endregion USP_StuWebStudentRegistration_Update

                    #region USP_StuWebStudentPhotoSignThumb_Update

                    cmdToExecute1.CommandText = "dbo.USP_StuRegistrationStudentPhotoSignThumb_Update";
                    cmdToExecute1.CommandType = CommandType.StoredProcedure;

                    // cmdToExecute1.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 10, ParameterDirection.Output, false, 0, 0, "", DataRowVersion.Proposed, item.ID));
                    cmdToExecute1.Parameters.Add(new SqlParameter("@iStudentRegistrationID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.ID));
                    #region Photo
                    if (item.StudentPhoto != null)
                    {
                        cmdToExecute1.Parameters.Add(new SqlParameter("@sStudentPhoto", SqlDbType.VarBinary, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.StudentPhoto));
                    }
                    else
                    {
                        cmdToExecute1.Parameters.Add(new SqlParameter("@sStudentPhoto", SqlDbType.VarBinary, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.StudentPhotoFilename != null)
                    {
                        cmdToExecute1.Parameters.Add(new SqlParameter("@sStudentPhotoFilename", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.StudentPhotoFilename));
                    }
                    else
                    {
                        cmdToExecute1.Parameters.Add(new SqlParameter("@sStudentPhotoFilename", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.StudentPhotoType != null)
                    {
                        cmdToExecute1.Parameters.Add(new SqlParameter("@sStudentPhotoType", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.StudentPhotoType));
                    }
                    else
                    {
                        cmdToExecute1.Parameters.Add(new SqlParameter("@sStudentPhotoType", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.StudentPhotoFileWidth != null)
                    {
                        cmdToExecute1.Parameters.Add(new SqlParameter("@sStudentPhotoFileWidth", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.StudentPhotoFileWidth));
                    }
                    else
                    {
                        cmdToExecute1.Parameters.Add(new SqlParameter("@sStudentPhotoFileWidth", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.StudentPhotoFileHeight != null)
                    {
                        cmdToExecute1.Parameters.Add(new SqlParameter("@sStudentPhotoFileHeight", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.StudentPhotoFileHeight));
                    }
                    else
                    {
                        cmdToExecute1.Parameters.Add(new SqlParameter("@sStudentPhotoFileHeight", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.StudentPhotoFileHeight != null)
                    {
                        cmdToExecute1.Parameters.Add(new SqlParameter("@sStudentPhotoFileSize", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.StudentPhotoFileSize));
                    }
                    else
                    {
                        cmdToExecute1.Parameters.Add(new SqlParameter("@sStudentPhotoFileSize", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }

                    #endregion Photo
                    #region Signature
                    if (item.StudentSignature != null)
                    {
                        cmdToExecute1.Parameters.Add(new SqlParameter("@sStudentSignature", SqlDbType.VarBinary, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.StudentSignature));
                    }
                    else
                    {
                        cmdToExecute1.Parameters.Add(new SqlParameter("@sStudentSignature", SqlDbType.VarBinary, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.StudentSignatureFilename != null)
                    {
                        cmdToExecute1.Parameters.Add(new SqlParameter("@sStudentSignatureFilename", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.StudentSignatureFilename));
                    }
                    else
                    {
                        cmdToExecute1.Parameters.Add(new SqlParameter("@sStudentSignatureFilename", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.StudentSignatureType != null)
                    {
                        cmdToExecute1.Parameters.Add(new SqlParameter("@sStudentSignatureType", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.StudentSignatureType));
                    }
                    else
                    {
                        cmdToExecute1.Parameters.Add(new SqlParameter("@sStudentSignatureType", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.StudentSignatureFileWidth != null)
                    {
                        cmdToExecute1.Parameters.Add(new SqlParameter("@sStudentSignatureFileWidth", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.StudentSignatureFileWidth));
                    }
                    else
                    {
                        cmdToExecute1.Parameters.Add(new SqlParameter("@sStudentSignatureFileWidth", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.StudentSignatureFileHeight != null)
                    {
                        cmdToExecute1.Parameters.Add(new SqlParameter("@sStudentSignatureFileHeight", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.StudentSignatureFileHeight));
                    }
                    else
                    {
                        cmdToExecute1.Parameters.Add(new SqlParameter("@sStudentSignatureFileHeight", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.StudentSignatureFileHeight != null)
                    {
                        cmdToExecute1.Parameters.Add(new SqlParameter("@sStudentSignatureFileSize", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.StudentSignatureFileSize));
                    }
                    else
                    {
                        cmdToExecute1.Parameters.Add(new SqlParameter("@sStudentSignatureFileSize", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    #endregion Signature
                    #region Thumb
                    if (item.StudentThumb != null)
                    {
                        cmdToExecute1.Parameters.Add(new SqlParameter("@sStudentThumb", SqlDbType.VarBinary, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.StudentThumb));
                    }
                    else
                    {
                        cmdToExecute1.Parameters.Add(new SqlParameter("@sStudentThumb", SqlDbType.VarBinary, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.StudentThumbFilename != null)
                    {
                        cmdToExecute1.Parameters.Add(new SqlParameter("@sStudentThumbFilename", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.StudentThumbFilename));
                    }
                    else
                    {
                        cmdToExecute1.Parameters.Add(new SqlParameter("@sStudentThumbFilename", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.StudentThumbType != null)
                    {
                        cmdToExecute1.Parameters.Add(new SqlParameter("@sStudentThumbType", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.StudentThumbType));
                    }
                    else
                    {
                        cmdToExecute1.Parameters.Add(new SqlParameter("@sStudentThumbType", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.StudentThumbFileWidth != null)
                    {
                        cmdToExecute1.Parameters.Add(new SqlParameter("@sStudentThumbFileWidth", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.StudentThumbFileWidth));
                    }
                    else
                    {
                        cmdToExecute1.Parameters.Add(new SqlParameter("@sStudentThumbFileWidth", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.StudentThumbFileHeight != null)
                    {
                        cmdToExecute1.Parameters.Add(new SqlParameter("@sStudentThumbFileHeight", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.StudentThumbFileHeight));
                    }
                    else
                    {
                        cmdToExecute1.Parameters.Add(new SqlParameter("@sStudentThumbFileHeight", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.StudentThumbFileHeight != null)
                    {
                        cmdToExecute1.Parameters.Add(new SqlParameter("@sStudentThumbFileSize", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.StudentThumbFileSize));
                    }
                    else
                    {
                        cmdToExecute1.Parameters.Add(new SqlParameter("@sStudentThumbFileSize", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    #endregion Thumb
                    cmdToExecute1.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute1.Parameters.Add(new SqlParameter("@iModifiedBy", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.ModifiedBy));

                    //transaction1 = _mainConnection.BeginTransaction("SampleTransaction");
                    cmdToExecute1.Transaction = transaction;
                    _rowsAffected = cmdToExecute1.ExecuteNonQuery();
                    #endregion USP_StuWebStudentPhotoSignThumb_Update

                    #region USP_StuWebStudentPersonalDetails_Update

                    cmdToExecute2.CommandText = "dbo.USP_StuRegistrationPersonalDetails_Update";
                    cmdToExecute2.CommandType = CommandType.StoredProcedure;
                    cmdToExecute2.Parameters.Add(new SqlParameter("@iStudentRegistrationId", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.ID));
                    if (item.StudentDateofBirth != null)
                    {
                        cmdToExecute2.Parameters.Add(new SqlParameter("@daDateOfBirth", SqlDbType.DateTime, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.StudentDateofBirth));
                    }
                    else
                    {
                        cmdToExecute2.Parameters.Add(new SqlParameter("@daDateOfBirth", SqlDbType.DateTime, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.StudentBirthPlace != null)
                    {
                        cmdToExecute2.Parameters.Add(new SqlParameter("@nsBirthPlace", SqlDbType.VarChar, 20, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, item.StudentBirthPlace));
                    }
                    else
                    {
                        cmdToExecute2.Parameters.Add(new SqlParameter("@nsBirthPlace", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    cmdToExecute2.Parameters.Add(new SqlParameter("@cGender", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.StudentGender));
                    if (item.StudentBirthPlace != null)
                    {
                        cmdToExecute2.Parameters.Add(new SqlParameter("@cMaritalStatus", SqlDbType.Char, 1, ParameterDirection.Input, false, 1, 0, "", DataRowVersion.Proposed, item.StudentMaritalStatus));
                    }
                    else
                    {
                        cmdToExecute2.Parameters.Add(new SqlParameter("@cMaritalStatus", SqlDbType.Char, 1, ParameterDirection.Input, false, 1, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    
                    cmdToExecute2.Parameters.Add(new SqlParameter("@iNationalityId", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.StudentNationalityID));
                    cmdToExecute2.Parameters.Add(new SqlParameter("@iReligionId", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.StudentReligionID));
                    cmdToExecute2.Parameters.Add(new SqlParameter("@iLanguageId", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.StudentMotherTongueID));
                    cmdToExecute2.Parameters.Add(new SqlParameter("@iCategoryId", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.StudentCategoryID));
                    cmdToExecute2.Parameters.Add(new SqlParameter("@iCasteId", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.StudentCasteID));

                    if (item.StudentBloodGroup != null)
                    {
                        cmdToExecute2.Parameters.Add(new SqlParameter("@sBloodgroup", SqlDbType.VarChar, 5, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, item.StudentBloodGroup));
                    }
                    else
                    {
                        cmdToExecute2.Parameters.Add(new SqlParameter("@sBloodgroup", SqlDbType.VarChar, 5, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.StudentLandLineNumber != null)
                    {
                        cmdToExecute2.Parameters.Add(new SqlParameter("@nsLandLineNumber", SqlDbType.NVarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.StudentLandLineNumber));
                    }
                    else
                    {
                        cmdToExecute2.Parameters.Add(new SqlParameter("@nsLandLineNumber", SqlDbType.NVarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.StudentIdentificationMark != null)
                    {
                        cmdToExecute2.Parameters.Add(new SqlParameter("@nsIdentificationMark", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.StudentIdentificationMark));
                    }
                    else
                    {
                        cmdToExecute2.Parameters.Add(new SqlParameter("@nsIdentificationMark", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.StudentEmploymentSector != null)
                    {
                        cmdToExecute2.Parameters.Add(new SqlParameter("@nsEmploymentSector", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.StudentEmploymentSector));
                    }
                    else
                    {
                        cmdToExecute2.Parameters.Add(new SqlParameter("@nsEmploymentSector", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.StudentOccupation != null)
                    {
                        cmdToExecute2.Parameters.Add(new SqlParameter("@nsOccupation", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.StudentOccupation));
                    }
                    else
                    {
                        cmdToExecute2.Parameters.Add(new SqlParameter("@nsOccupation", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.StudentDesignation != null)
                    {
                        cmdToExecute2.Parameters.Add(new SqlParameter("@nsDesignation", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.StudentDesignation));
                    }
                    else
                    {
                        cmdToExecute2.Parameters.Add(new SqlParameter("@nsDesignation", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.StudentOrganizationName != null)
                    {
                        cmdToExecute2.Parameters.Add(new SqlParameter("@nsOrganizationName", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.StudentOrganizationName));
                    }
                    else
                    {
                        cmdToExecute2.Parameters.Add(new SqlParameter("@nsOrganizationName", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.StudentOfficeContactNo != null)
                    {
                        cmdToExecute2.Parameters.Add(new SqlParameter("@iOfficeContactNumber", SqlDbType.VarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.StudentOfficeContactNo));
                    }
                    else
                    {
                        cmdToExecute2.Parameters.Add(new SqlParameter("@iOfficeContactNumber", SqlDbType.VarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    cmdToExecute2.Parameters.Add(new SqlParameter("@iAnnualIncome", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.StudentAnnualIncome));
                    if (item.PhysicallyHandicapped == "0")
                    {
                        cmdToExecute2.Parameters.Add(new SqlParameter("@bIsHandicapped", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, false));
                    }
                    else
                    {
                        cmdToExecute2.Parameters.Add(new SqlParameter("@bIsHandicapped", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, true));

                    }
                    if (item.StudentOrgandonor == "0")
                    {
                        cmdToExecute2.Parameters.Add(new SqlParameter("@bIsOrganDoner", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, false));
                    }
                    else
                    {
                        cmdToExecute2.Parameters.Add(new SqlParameter("@bIsOrganDoner", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, true));

                    }
                    if (item.StudentPrevNameofStudent != null)
                    {
                        cmdToExecute2.Parameters.Add(new SqlParameter("@nsPreviousNameOfStudentIfChange", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.StudentPrevNameofStudent));
                    }
                    else
                    {
                        cmdToExecute2.Parameters.Add(new SqlParameter("@nsPreviousNameOfStudentIfChange", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.StudentReasonforNamechange != null)
                    {
                        cmdToExecute2.Parameters.Add(new SqlParameter("@nsReasonNameChange", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.StudentReasonforNamechange));
                    }
                    else
                    {
                        cmdToExecute2.Parameters.Add(new SqlParameter("@nsReasonNameChange", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.StudentEmploymentStatus == "0")
                    {
                        cmdToExecute2.Parameters.Add(new SqlParameter("@bEmploymentStatus", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, false));
                    }
                    else
                    {
                        cmdToExecute2.Parameters.Add(new SqlParameter("@bEmploymentStatus", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, true));

                    }

                    cmdToExecute2.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute2.Parameters.Add(new SqlParameter("@iModifiedBy", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.ModifiedBy));

                    cmdToExecute2.Transaction = transaction;
                    _rowsAffected = cmdToExecute2.ExecuteNonQuery();

                    #endregion USP_StuWebStudentPersonalDetails_Update

                    #region USP_StuWebParentPersonalInformation_Update FOR Father

                    cmdToExecute3.CommandText = "dbo.USP_StuRegistrationParentPersonalInformation_Update";
                    cmdToExecute3.CommandType = CommandType.StoredProcedure;

                    cmdToExecute3.Parameters.Add(new SqlParameter("@iStudentRegistrationId", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.ID));
                    if (item.FatherHusbondType != null)
                    {
                        cmdToExecute3.Parameters.Add(new SqlParameter("@nsEntityType", SqlDbType.NVarChar, 5, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.FatherHusbondType));
                    }
                    else
                    {
                        cmdToExecute3.Parameters.Add(new SqlParameter("@nsEntityType", SqlDbType.NVarChar, 5, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.FatherTitle != null)
                    {
                        cmdToExecute3.Parameters.Add(new SqlParameter("@nsTitle", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.FatherTitle));
                    }
                    else
                    {
                        cmdToExecute3.Parameters.Add(new SqlParameter("@nsTitle", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    cmdToExecute3.Parameters.Add(new SqlParameter("@cGender", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, "M"));


                    if (item.FatherFirstName != null)
                    {
                        cmdToExecute3.Parameters.Add(new SqlParameter("@nsFirstName", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.FatherFirstName));
                    }
                    else
                    {
                        cmdToExecute3.Parameters.Add(new SqlParameter("@nsFirstName", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.FatherMiddleName != null)
                    {
                        cmdToExecute3.Parameters.Add(new SqlParameter("@nsMiddleName", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.FatherMiddleName));
                    }
                    else
                    {
                        cmdToExecute3.Parameters.Add(new SqlParameter("@nsMiddleName", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }

                    if (item.FatherLastName != null)
                    {
                        cmdToExecute3.Parameters.Add(new SqlParameter("@nsLastName", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.FatherLastName));
                    }
                    else
                    {
                        cmdToExecute3.Parameters.Add(new SqlParameter("@nsLastName", SqlDbType.NVarChar, 0, ParameterDirection.Input, false, 50, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.FatherEmailId != null)
                    {
                        cmdToExecute3.Parameters.Add(new SqlParameter("@sEmailID", SqlDbType.VarChar, 80, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, item.FatherEmailId));
                    }
                    else
                    {
                        cmdToExecute3.Parameters.Add(new SqlParameter("@sEmailID", SqlDbType.VarChar, 80, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.FatherMobileNumber != null)
                    {
                        cmdToExecute3.Parameters.Add(new SqlParameter("@nsMobileNumber", SqlDbType.VarChar, 15, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, item.FatherMobileNumber));
                    }
                    else
                    {
                        cmdToExecute3.Parameters.Add(new SqlParameter("@nsMobileNumber", SqlDbType.VarChar, 15, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }

                    if (item.StudentDomicileStateofFather != null)
                    {
                        cmdToExecute3.Parameters.Add(new SqlParameter("@nsDomicileState", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, item.StudentDomicileStateofFather));
                    }
                    else
                    {
                        cmdToExecute3.Parameters.Add(new SqlParameter("@nsDomicileState", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.FatherLandLineNumber != null)
                    {
                        cmdToExecute3.Parameters.Add(new SqlParameter("@nsLandlineNumber", SqlDbType.VarChar, 15, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, item.FatherLandLineNumber));
                    }
                    else
                    {
                        cmdToExecute3.Parameters.Add(new SqlParameter("@nsLandlineNumber", SqlDbType.VarChar, 15, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.FatherEmploymentSector != null)
                    {
                        cmdToExecute3.Parameters.Add(new SqlParameter("@nsEmploymentSector", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.FatherEmploymentSector));
                    }
                    else
                    {
                        cmdToExecute3.Parameters.Add(new SqlParameter("@nsEmploymentSector", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.FatherOccupation != null)
                    {
                        cmdToExecute3.Parameters.Add(new SqlParameter("@nsOccupation", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.FatherOccupation));
                    }
                    else
                    {
                        cmdToExecute3.Parameters.Add(new SqlParameter("@nsOccupation", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.FatherDesignation != null)
                    {
                        cmdToExecute3.Parameters.Add(new SqlParameter("@nsDesignation", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.FatherDesignation));
                    }
                    else
                    {
                        cmdToExecute3.Parameters.Add(new SqlParameter("@nsDesignation", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.FatherOrganizationName != null)
                    {
                        cmdToExecute3.Parameters.Add(new SqlParameter("@nsOrganizationName", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.FatherOrganizationName));
                    }
                    else
                    {
                        cmdToExecute3.Parameters.Add(new SqlParameter("@nsOrganizationName", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.FatherOfficeContactNo != null)
                    {
                        cmdToExecute3.Parameters.Add(new SqlParameter("@iOfficeContactNumber", SqlDbType.VarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.FatherOfficeContactNo));
                    }
                    else
                    {
                        cmdToExecute3.Parameters.Add(new SqlParameter("@iOfficeContactNumber", SqlDbType.VarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    cmdToExecute3.Parameters.Add(new SqlParameter("@iAnnualIncome", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.FatherAnnualIncome));

                    cmdToExecute3.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute3.Parameters.Add(new SqlParameter("@iModifiedBy", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.ModifiedBy));

                    cmdToExecute3.Transaction = transaction;
                    _rowsAffected = cmdToExecute3.ExecuteNonQuery();
                    #endregion USP_StuWebParentPersonalInformation_Update FOR Father

                    #region USP_StuWebParentPersonalInformation_Update FOR Mother

                    cmdToExecute4.CommandText = "dbo.USP_StuRegistrationParentPersonalInformation_Update";
                    cmdToExecute4.CommandType = CommandType.StoredProcedure;

                    cmdToExecute4.Parameters.Add(new SqlParameter("@iStudentRegistrationId", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.ID));
                    cmdToExecute4.Parameters.Add(new SqlParameter("@nsEntityType", SqlDbType.NVarChar, 5, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, "M"));
                    if (item.MotherTitle != null)
                    {
                        cmdToExecute4.Parameters.Add(new SqlParameter("@nsTitle", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.MotherTitle));
                    }
                    else
                    {
                        cmdToExecute4.Parameters.Add(new SqlParameter("@nsTitle", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }

                    cmdToExecute4.Parameters.Add(new SqlParameter("@cGender", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, "F"));


                    if (item.MotherFirstName != null)
                    {
                        cmdToExecute4.Parameters.Add(new SqlParameter("@nsFirstName", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.MotherFirstName));
                    }
                    else
                    {
                        cmdToExecute4.Parameters.Add(new SqlParameter("@nsFirstName", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.MotherMiddleName != null)
                    {
                        cmdToExecute4.Parameters.Add(new SqlParameter("@nsMiddleName", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.MotherMiddleName));
                    }
                    else
                    {
                        cmdToExecute4.Parameters.Add(new SqlParameter("@nsMiddleName", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }

                    if (item.MotherLastName != null)
                    {
                        cmdToExecute4.Parameters.Add(new SqlParameter("@nsLastName", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.MotherLastName));
                    }
                    else
                    {
                        cmdToExecute4.Parameters.Add(new SqlParameter("@nsLastName", SqlDbType.NVarChar, 0, ParameterDirection.Input, false, 50, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.MotherEmailId != null)
                    {
                        cmdToExecute4.Parameters.Add(new SqlParameter("@sEmailID", SqlDbType.VarChar, 80, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, item.MotherEmailId));
                    }
                    else
                    {
                        cmdToExecute4.Parameters.Add(new SqlParameter("@sEmailID", SqlDbType.VarChar, 80, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.MotherMobileNumber != null)
                    {
                        cmdToExecute4.Parameters.Add(new SqlParameter("@nsMobileNumber", SqlDbType.VarChar, 15, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, item.MotherMobileNumber));
                    }
                    else
                    {
                        cmdToExecute4.Parameters.Add(new SqlParameter("@nsMobileNumber", SqlDbType.VarChar, 15, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }

                    if (item.StudentDomicileStateofMother != null)
                    {
                        cmdToExecute4.Parameters.Add(new SqlParameter("@nsDomicileState", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, item.StudentDomicileStateofMother));
                    }
                    else
                    {
                        cmdToExecute4.Parameters.Add(new SqlParameter("@nsDomicileState", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.MotherLandLineNumber != null)
                    {
                        cmdToExecute4.Parameters.Add(new SqlParameter("@nsLandlineNumber", SqlDbType.VarChar, 15, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, item.MotherLandLineNumber));
                    }
                    else
                    {
                        cmdToExecute4.Parameters.Add(new SqlParameter("@nsLandlineNumber", SqlDbType.VarChar, 15, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.MotherEmploymentSector != null)
                    {
                        cmdToExecute4.Parameters.Add(new SqlParameter("@nsEmploymentSector", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.MotherEmploymentSector));
                    }
                    else
                    {
                        cmdToExecute4.Parameters.Add(new SqlParameter("@nsEmploymentSector", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.MotherOccupation != null)
                    {
                        cmdToExecute4.Parameters.Add(new SqlParameter("@nsOccupation", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.MotherOccupation));
                    }
                    else
                    {
                        cmdToExecute4.Parameters.Add(new SqlParameter("@nsOccupation", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.MotherDesignation != null)
                    {
                        cmdToExecute4.Parameters.Add(new SqlParameter("@nsDesignation", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.MotherDesignation));
                    }
                    else
                    {
                        cmdToExecute4.Parameters.Add(new SqlParameter("@nsDesignation", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.MotherOrganizationName != null)
                    {
                        cmdToExecute4.Parameters.Add(new SqlParameter("@nsOrganizationName", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.MotherOrganizationName));
                    }
                    else
                    {
                        cmdToExecute4.Parameters.Add(new SqlParameter("@nsOrganizationName", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.MotherOfficeContactNo != null)
                    {
                        cmdToExecute4.Parameters.Add(new SqlParameter("@iOfficeContactNumber", SqlDbType.VarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.MotherOfficeContactNo));
                    }
                    else
                    {
                        cmdToExecute4.Parameters.Add(new SqlParameter("@iOfficeContactNumber", SqlDbType.VarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    cmdToExecute4.Parameters.Add(new SqlParameter("@iAnnualIncome", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.MotherAnnualIncome));

                    cmdToExecute4.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute4.Parameters.Add(new SqlParameter("@iModifiedBy", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.ModifiedBy));

                    cmdToExecute4.Transaction = transaction;
                    _rowsAffected = cmdToExecute4.ExecuteNonQuery();
                    #endregion USP_StuWebParentPersonalInformation_Update FOR Mother

                    #region USP_StuWebParentPersonalInformation_Update FOR Gurdian

                    cmdToExecute5.CommandText = "dbo.USP_StuRegistrationParentPersonalInformation_Update";
                    cmdToExecute5.CommandType = CommandType.StoredProcedure;

                    cmdToExecute5.Parameters.Add(new SqlParameter("@iStudentRegistrationId", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.ID));
                    cmdToExecute5.Parameters.Add(new SqlParameter("@nsEntityType", SqlDbType.NVarChar, 5, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, "G"));
                    if (item.MotherTitle != null)
                    {
                        cmdToExecute5.Parameters.Add(new SqlParameter("@nsTitle", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.MotherTitle));
                    }
                    else
                    {
                        cmdToExecute5.Parameters.Add(new SqlParameter("@nsTitle", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }

                    cmdToExecute5.Parameters.Add(new SqlParameter("@cGender", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));


                    if (item.MotherFirstName != null)
                    {
                        cmdToExecute5.Parameters.Add(new SqlParameter("@nsFirstName", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.MotherFirstName));
                    }
                    else
                    {
                        cmdToExecute5.Parameters.Add(new SqlParameter("@nsFirstName", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.MotherMiddleName != null)
                    {
                        cmdToExecute5.Parameters.Add(new SqlParameter("@nsMiddleName", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.MotherMiddleName));
                    }
                    else
                    {
                        cmdToExecute5.Parameters.Add(new SqlParameter("@nsMiddleName", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }

                    if (item.MotherLastName != null)
                    {
                        cmdToExecute5.Parameters.Add(new SqlParameter("@nsLastName", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.MotherLastName));
                    }
                    else
                    {
                        cmdToExecute5.Parameters.Add(new SqlParameter("@nsLastName", SqlDbType.NVarChar, 0, ParameterDirection.Input, false, 50, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.MotherEmailId != null)
                    {
                        cmdToExecute5.Parameters.Add(new SqlParameter("@sEmailID", SqlDbType.VarChar, 80, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, item.MotherEmailId));
                    }
                    else
                    {
                        cmdToExecute5.Parameters.Add(new SqlParameter("@sEmailID", SqlDbType.VarChar, 80, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.MotherMobileNumber != null)
                    {
                        cmdToExecute5.Parameters.Add(new SqlParameter("@nsMobileNumber", SqlDbType.VarChar, 15, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, item.MotherMobileNumber));
                    }
                    else
                    {
                        cmdToExecute5.Parameters.Add(new SqlParameter("@nsMobileNumber", SqlDbType.VarChar, 15, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }

                    if (item.StudentDomicileStateofMother != null)
                    {
                        cmdToExecute5.Parameters.Add(new SqlParameter("@nsDomicileState", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, item.StudentDomicileStateofMother));
                    }
                    else
                    {
                        cmdToExecute5.Parameters.Add(new SqlParameter("@nsDomicileState", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.MotherLandLineNumber != null)
                    {
                        cmdToExecute5.Parameters.Add(new SqlParameter("@nsLandlineNumber", SqlDbType.VarChar, 15, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, item.MotherLandLineNumber));
                    }
                    else
                    {
                        cmdToExecute5.Parameters.Add(new SqlParameter("@nsLandlineNumber", SqlDbType.VarChar, 15, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.MotherEmploymentSector != null)
                    {
                        cmdToExecute5.Parameters.Add(new SqlParameter("@nsEmploymentSector", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.MotherEmploymentSector));
                    }
                    else
                    {
                        cmdToExecute5.Parameters.Add(new SqlParameter("@nsEmploymentSector", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.MotherOccupation != null)
                    {
                        cmdToExecute5.Parameters.Add(new SqlParameter("@nsOccupation", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.MotherOccupation));
                    }
                    else
                    {
                        cmdToExecute5.Parameters.Add(new SqlParameter("@nsOccupation", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.MotherDesignation != null)
                    {
                        cmdToExecute5.Parameters.Add(new SqlParameter("@nsDesignation", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.MotherDesignation));
                    }
                    else
                    {
                        cmdToExecute5.Parameters.Add(new SqlParameter("@nsDesignation", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.MotherOrganizationName != null)
                    {
                        cmdToExecute5.Parameters.Add(new SqlParameter("@nsOrganizationName", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.MotherOrganizationName));
                    }
                    else
                    {
                        cmdToExecute5.Parameters.Add(new SqlParameter("@nsOrganizationName", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.MotherOfficeContactNo != null)
                    {
                        cmdToExecute5.Parameters.Add(new SqlParameter("@iOfficeContactNumber", SqlDbType.VarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.MotherOfficeContactNo));
                    }
                    else
                    {
                        cmdToExecute5.Parameters.Add(new SqlParameter("@iOfficeContactNumber", SqlDbType.VarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    cmdToExecute5.Parameters.Add(new SqlParameter("@iAnnualIncome", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.MotherAnnualIncome));

                    cmdToExecute5.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute5.Parameters.Add(new SqlParameter("@iModifiedBy", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.ModifiedBy));

                    cmdToExecute5.Transaction = transaction;
                    _rowsAffected = cmdToExecute5.ExecuteNonQuery();
                    #endregion USP_StuWebParentPersonalInformation_Update FOR Guardian

                    #region USP_StuWebStudentSocialReservationInformation_Update

                    cmdToExecute6.CommandText = "dbo.USP_StuRegistrationStudentSocialReservationInformation_Update ";
                    cmdToExecute6.CommandType = CommandType.StoredProcedure;
                    cmdToExecute6.Parameters.Add(new SqlParameter("@iStudentRegistrationID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.ID));
                    cmdToExecute6.Parameters.Add(new SqlParameter("@bSocialReservation1", SqlDbType.Bit, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_Ex_Serviceman_Ward_of_Ex_Serviceman));
                    cmdToExecute6.Parameters.Add(new SqlParameter("@bSocialReservation2", SqlDbType.Bit, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_Active_Serviceman_Ward_of_Active_Serviceman));
                    cmdToExecute6.Parameters.Add(new SqlParameter("@bSocialReservation3", SqlDbType.Bit, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_FreedomFighterWardOfFreedomFighter));
                    cmdToExecute6.Parameters.Add(new SqlParameter("@bSocialReservation4", SqlDbType.Bit, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_WardofPrimaryTeacher));
                    cmdToExecute6.Parameters.Add(new SqlParameter("@bSocialReservation5", SqlDbType.Bit, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_WardofSecondaryTeacher));
                    cmdToExecute6.Parameters.Add(new SqlParameter("@bSocialReservation6", SqlDbType.Bit, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_Deserted_Divorced_Widowed_Women));
                    cmdToExecute6.Parameters.Add(new SqlParameter("@bSocialReservation7", SqlDbType.Bit, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_MemberofProjectAffectedFamily));
                    cmdToExecute6.Parameters.Add(new SqlParameter("@bSocialReservation8", SqlDbType.Bit, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_MemberofEarthquakeAffectedFamily));
                    cmdToExecute6.Parameters.Add(new SqlParameter("@bSocialReservation9", SqlDbType.Bit, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_MemberofFloodFamineAffectedFamily));
                    cmdToExecute6.Parameters.Add(new SqlParameter("@bSocialReservation10", SqlDbType.Bit, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_ResidentofTribalArea));
                    cmdToExecute6.Parameters.Add(new SqlParameter("@bSocialReservation11", SqlDbType.Bit, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_KashmirMigrant));


                    cmdToExecute6.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute6.Parameters.Add(new SqlParameter("@iModifiedBy", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.ModifiedBy));




                    cmdToExecute6.Transaction = transaction;
                    _rowsAffected = cmdToExecute6.ExecuteNonQuery();
                    #endregion USP_StuWebStudentSocialReservationInformation_Update

                    #region USP_StuRegistrationOtherInfoOfStudent_Update

                    cmdToExecute7.CommandText = "dbo.USP_StuRegistrationOtherInfoOfStudent_Update ";
                    cmdToExecute7.CommandType = CommandType.StoredProcedure;
                    cmdToExecute7.Parameters.Add(new SqlParameter("@iStudentRegistrationID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.ID));
                    if (item.StudentIndicatetypeofCandidature != null)
                    {
                        cmdToExecute7.Parameters.Add(new SqlParameter("@sIndicateTypeOfCandidature", SqlDbType.VarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.StudentIndicatetypeofCandidature));
                    }
                    else
                    {
                        cmdToExecute7.Parameters.Add(new SqlParameter("@sIndicateTypeOfCandidature", SqlDbType.VarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.StudentSchoolFromHSCExaminationpassed != null)
                    {
                        cmdToExecute7.Parameters.Add(new SqlParameter("@nsWhereTheSchoolFromWhichSSC", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.StudentSchoolFromHSCExaminationpassed));
                    }
                    else
                    {
                        cmdToExecute7.Parameters.Add(new SqlParameter("@nsWhereTheSchoolFromWhichSSC", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }

                    if (item.StudentEconomicallyBackwardClass == "0")
                    {
                        cmdToExecute7.Parameters.Add(new SqlParameter("@bIsEconomicallyBackwordClass", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, false));
                    }
                    else
                    {
                        cmdToExecute7.Parameters.Add(new SqlParameter("@bIsEconomicallyBackwordClass", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, true));

                    }
                    if (item.StudentsNameOfDistrictWhereParentDomiciled != null)
                    {
                        cmdToExecute7.Parameters.Add(new SqlParameter("@nsNameOfTheDistrictWhereParent", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.StudentsNameOfDistrictWhereParentDomiciled));
                    }
                    else
                    {
                        cmdToExecute7.Parameters.Add(new SqlParameter("@nsNameOfTheDistrictWhereParent", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.StudentsMKBCandidate != null)
                    {
                        cmdToExecute7.Parameters.Add(new SqlParameter("@sMKBCandidate", SqlDbType.VarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.StudentsMKBCandidate));
                    }
                    else
                    {
                        cmdToExecute7.Parameters.Add(new SqlParameter("@sMKBCandidate", SqlDbType.VarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }

                    cmdToExecute7.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute7.Parameters.Add(new SqlParameter("@iModifiedBy", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.ModifiedBy));




                    cmdToExecute7.Transaction = transaction;
                    _rowsAffected = cmdToExecute7.ExecuteNonQuery();
                    #endregion USP_StuRegistrationOtherInfoOfStudent_Update

                    #region USP_StuRegistrationPreEntranceExaminationTransaction_Update

                    cmdToExecute8.CommandText = "dbo.USP_StuRegistrationPreEntranceExaminationTransaction_Update ";
                    cmdToExecute8.CommandType = CommandType.StoredProcedure;
                    cmdToExecute8.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_QualifyingTransactionID));
                    cmdToExecute8.Parameters.Add(new SqlParameter("@iStudentRegistrationID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.ID));
                    cmdToExecute8.Parameters.Add(new SqlParameter("@iQualifyingExamMasterId", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_QualifyingExamId));
                    if (item.Student_QualifyingRollNo != null)
                    {
                        cmdToExecute8.Parameters.Add(new SqlParameter("@nsRollNumber ", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_QualifyingRollNo));
                    }
                    else
                    {
                        cmdToExecute8.Parameters.Add(new SqlParameter("@nsRollNumber ", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    cmdToExecute8.Parameters.Add(new SqlParameter("@iMarksObtained", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_QualifyingExamTotalMarksPointsObtained));
                    cmdToExecute8.Parameters.Add(new SqlParameter("@iMarksOutOf", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_QualifyingExamOutOffMark));
                    if (item.Student_QualifyingExamRank != null)
                    {
                        cmdToExecute8.Parameters.Add(new SqlParameter("@nsRank", SqlDbType.NVarChar, 5, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_QualifyingExamRank));
                    }
                    else
                    {
                        cmdToExecute8.Parameters.Add(new SqlParameter("@nsRank", SqlDbType.NVarChar, 5, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }

                    cmdToExecute8.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute8.Parameters.Add(new SqlParameter("@iModifiedBy", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.ModifiedBy));

                    cmdToExecute8.Transaction = transaction;
                    _rowsAffected = cmdToExecute8.ExecuteNonQuery();
                    #endregion USP_StuRegistrationOtherInfoOfStudent_Update

                    //#region USP_StuRegistrationPreEntranceExaminationSubjectDetail_UpdateXML

                    //cmdToExecute9.CommandText = "dbo.USP_StuRegistrationPreEntranceExaminationSubjectDetail_UpdateXML ";
                    //cmdToExecute9.CommandType = CommandType.StoredProcedure;

                    //cmdToExecute9.Parameters.Add(new SqlParameter("@iStudent_QualifyingTransactionID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_QualifyingTransactionID));

                    ////    cmdToExecute9.Parameters.Add(new SqlParameter("@iQualifyingExamMstID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_QualifyingExamId));
                    //if (item.QualifyingExamSubjectDetailsIDs != null)
                    //{
                    //    cmdToExecute9.Parameters.Add(new SqlParameter("@nsIDs ", SqlDbType.NVarChar, 4000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.QualifyingExamSubjectDetailsIDs));
                    //}
                    //else
                    //{
                    //    cmdToExecute9.Parameters.Add(new SqlParameter("@nsIDs ", SqlDbType.NVarChar, 4000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, ""));
                    //}

                    //cmdToExecute9.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    //cmdToExecute9.Parameters.Add(new SqlParameter("@iModifiedBy", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.ModifiedBy));

                    //cmdToExecute9.Transaction = transaction;
                    //_rowsAffected = cmdToExecute9.ExecuteNonQuery();

                    //#endregion USP_StuRegistrationPreEntranceExaminationSubjectDetail_UpdateXML

                    #region USP_StuRegistrationPreQualificationSchoolTransaction_Update For General

                    cmdToExecute10.CommandText = "dbo.USP_StuRegistrationPreQualificationSchoolTransaction_Update ";
                    cmdToExecute10.CommandType = CommandType.StoredProcedure;
                    cmdToExecute10.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_QualificationTransactionID));
                    cmdToExecute10.Parameters.Add(new SqlParameter("@iStudentRegistrationID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.ID));
                    cmdToExecute10.Parameters.Add(new SqlParameter("@cEducationType ", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, "G"));
                    cmdToExecute10.Parameters.Add(new SqlParameter("@iMediumId", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_Qualification_General_MediumOfInstitution));
                    cmdToExecute10.Parameters.Add(new SqlParameter("@siMonthPassing", SqlDbType.SmallInt, 2, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_Qualification_General_MonthOfPassing));
                    cmdToExecute10.Parameters.Add(new SqlParameter("@iYearPassing", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_Qualification_General_YearOfPassing));
                    if (item.Student_Qualification_General_SingleAttempt == "0")
                    {
                        cmdToExecute10.Parameters.Add(new SqlParameter("@bIsSingleAttempt", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, false));
                    }
                    else
                    {
                        cmdToExecute10.Parameters.Add(new SqlParameter("@bIsSingleAttempt", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, true));
                    }
                    cmdToExecute10.Parameters.Add(new SqlParameter("@iMarksObtained", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_Qualification_General_ObtainedMark));
                    cmdToExecute10.Parameters.Add(new SqlParameter("@iMarksOutOf", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_Qualification_General_OutOfMark));
                    if (item.Student_Qualification_General_Percent != null)
                    {
                        cmdToExecute10.Parameters.Add(new SqlParameter("@nsMarksObtainedPercentage", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_Qualification_General_Percent));
                    }
                    else
                    {
                        cmdToExecute10.Parameters.Add(new SqlParameter("@nsMarksObtainedPercentage", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.Student_Qualification_General_NameofInstitution != null)
                    {
                        cmdToExecute10.Parameters.Add(new SqlParameter("@nsInstitutionName", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_Qualification_General_NameofInstitution));
                    }
                    else
                    {
                        cmdToExecute10.Parameters.Add(new SqlParameter("@nsInstitutionName", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.Student_Qualification_General_Region_Division_Board != null)
                    {
                        cmdToExecute10.Parameters.Add(new SqlParameter("@nsRegionDivisionBoard", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_Qualification_General_Region_Division_Board));
                    }
                    else
                    {
                        cmdToExecute10.Parameters.Add(new SqlParameter("@nsRegionDivisionBoard", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    cmdToExecute10.Parameters.Add(new SqlParameter("@iStreamId", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_Qualification_HSC_StreamID));
                    if (item.Student_Qualification_HSC_StreamOther != null)
                    {
                        cmdToExecute10.Parameters.Add(new SqlParameter("@nsOtherStream", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_Qualification_HSC_StreamOther));
                    }
                    else
                    {
                        cmdToExecute10.Parameters.Add(new SqlParameter("@nsOtherStream", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.Student_Qualification_HSC_Class != null)
                    {
                        cmdToExecute10.Parameters.Add(new SqlParameter("@sGrade", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_Qualification_HSC_Class));
                    }
                    else
                    {
                        cmdToExecute10.Parameters.Add(new SqlParameter("@sGrade", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    cmdToExecute10.Parameters.Add(new SqlParameter("@iGroupAObtainedMarks", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_Qualification_HSC_PCM_PVM_ObtainedMark));
                    cmdToExecute10.Parameters.Add(new SqlParameter("@iGroupAOutOfMarks", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_Qualification_HSC_PCM_PVM_OutOfMark));
                    cmdToExecute10.Parameters.Add(new SqlParameter("@iGroupBObtainedMarks", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_Qualification_HSC_PCB_ObtainedMark));
                    cmdToExecute10.Parameters.Add(new SqlParameter("@iGroupBOutOfMarks", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_Qualification_HSC_PCB_OutOfMark));
                    cmdToExecute10.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute10.Parameters.Add(new SqlParameter("@iModifiedBy", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.ModifiedBy));

                    cmdToExecute10.Transaction = transaction;
                    _rowsAffected = cmdToExecute10.ExecuteNonQuery();
                    #endregion USP_StuRegistrationPreQualificationSchoolTransaction_Update For General

                    //#region USP_StuRegistrationPreEntranceExaminationSubjectDetail_UpdateXML For General

                    //cmdToExecute11.CommandText = "dbo.USP_StuRegistrationPreQualificationSchoolSubjectDetail_UpdateXML ";
                    //cmdToExecute11.CommandType = CommandType.StoredProcedure;

                    //cmdToExecute11.Parameters.Add(new SqlParameter("@iStudentQualificationTransactionID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_QualificationTransactionID));

                    //if (item.QualificationExamSubjectGeneralDetailsIDs != null)
                    //{
                    //    cmdToExecute11.Parameters.Add(new SqlParameter("@nsIDs ", SqlDbType.NVarChar, 4000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.QualificationExamSubjectGeneralDetailsIDs));
                    //}
                    //else
                    //{
                    //    cmdToExecute11.Parameters.Add(new SqlParameter("@nsIDs ", SqlDbType.NVarChar, 4000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, ""));
                    //}

                    //cmdToExecute11.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    //cmdToExecute11.Parameters.Add(new SqlParameter("@iModifiedBy", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.ModifiedBy));

                    //cmdToExecute11.Transaction = transaction;
                    //_rowsAffected = cmdToExecute11.ExecuteNonQuery();

                    //#endregion USP_StuRegistrationPreEntranceExaminationSubjectDetail_UpdateXML For General

                    #region USP_StuRegistrationPreQualificationSchoolTransaction_Update For SSC

                    cmdToExecute12.CommandText = "dbo.USP_StuRegistrationPreQualificationSchoolTransaction_Update ";
                    cmdToExecute12.CommandType = CommandType.StoredProcedure;
                    cmdToExecute12.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_QualificationTransactionID));
                    cmdToExecute12.Parameters.Add(new SqlParameter("@iStudentRegistrationID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.ID));
                    cmdToExecute12.Parameters.Add(new SqlParameter("@cEducationType ", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, "S"));
                    cmdToExecute12.Parameters.Add(new SqlParameter("@iMediumId", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_Qualification_SSC_MediumOfInstitution));
                    cmdToExecute12.Parameters.Add(new SqlParameter("@siMonthPassing", SqlDbType.SmallInt, 2, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_Qualification_SSC_MonthOfPassing));
                    cmdToExecute12.Parameters.Add(new SqlParameter("@iYearPassing", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_Qualification_SSC_YearOfPassing));
                    if (item.Student_Qualification_SSC_SingleAttempt == "0")
                    {
                        cmdToExecute12.Parameters.Add(new SqlParameter("@bIsSingleAttempt", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, false));
                    }
                    else
                    {
                        cmdToExecute12.Parameters.Add(new SqlParameter("@bIsSingleAttempt", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, true));
                    }
                    cmdToExecute12.Parameters.Add(new SqlParameter("@iMarksObtained", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_Qualification_SSC_ObtainedMark));
                    cmdToExecute12.Parameters.Add(new SqlParameter("@iMarksOutOf", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_Qualification_SSC_OutOfMark));
                    if (item.Student_Qualification_SSC_Percent != null && item.Student_Qualification_SSC_Percent != 0)
                    {
                        cmdToExecute12.Parameters.Add(new SqlParameter("@nsMarksObtainedPercentage", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_Qualification_SSC_Percent));
                    }
                    else
                    {
                        cmdToExecute12.Parameters.Add(new SqlParameter("@nsMarksObtainedPercentage", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.Student_Qualification_SSC_NameofInstitution != null)
                    {
                        cmdToExecute12.Parameters.Add(new SqlParameter("@nsInstitutionName", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_Qualification_SSC_NameofInstitution));
                    }
                    else
                    {
                        cmdToExecute12.Parameters.Add(new SqlParameter("@nsInstitutionName", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.Student_Qualification_SSC_Region_Division_Board != null)
                    {
                        cmdToExecute12.Parameters.Add(new SqlParameter("@nsRegionDivisionBoard", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_Qualification_SSC_Region_Division_Board));
                    }
                    else
                    {
                        cmdToExecute12.Parameters.Add(new SqlParameter("@nsRegionDivisionBoard", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    cmdToExecute12.Parameters.Add(new SqlParameter("@iStreamId", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_Qualification_HSC_StreamID));
                    if (item.Student_Qualification_HSC_StreamOther != null)
                    {
                        cmdToExecute12.Parameters.Add(new SqlParameter("@nsOtherStream", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_Qualification_HSC_StreamOther));
                    }
                    else
                    {
                        cmdToExecute12.Parameters.Add(new SqlParameter("@nsOtherStream", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.Student_Qualification_HSC_Class != null)
                    {
                        cmdToExecute12.Parameters.Add(new SqlParameter("@sGrade", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_Qualification_HSC_Class));
                    }
                    else
                    {
                        cmdToExecute12.Parameters.Add(new SqlParameter("@sGrade", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    cmdToExecute12.Parameters.Add(new SqlParameter("@iGroupAObtainedMarks", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_Qualification_HSC_PCM_PVM_ObtainedMark));
                    cmdToExecute12.Parameters.Add(new SqlParameter("@iGroupAOutOfMarks", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_Qualification_HSC_PCM_PVM_OutOfMark));
                    cmdToExecute12.Parameters.Add(new SqlParameter("@iGroupBObtainedMarks", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_Qualification_HSC_PCB_ObtainedMark));
                    cmdToExecute12.Parameters.Add(new SqlParameter("@iGroupBOutOfMarks", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_Qualification_HSC_PCB_OutOfMark));
                    cmdToExecute12.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute12.Parameters.Add(new SqlParameter("@iModifiedBy", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.ModifiedBy));

                    cmdToExecute12.Transaction = transaction;
                    _rowsAffected = cmdToExecute12.ExecuteNonQuery();
                    #endregion USP_StuRegistrationPreQualificationSchoolTransaction_Update For SSC

                    //#region USP_StuRegistrationPreEntranceExaminationSubjectDetail_UpdateXML For SSC

                    //cmdToExecute13.CommandText = "dbo.USP_StuRegistrationPreQualificationSchoolSubjectDetail_UpdateXML ";
                    //cmdToExecute13.CommandType = CommandType.StoredProcedure;

                    //cmdToExecute13.Parameters.Add(new SqlParameter("@iStudentQualificationTransactionID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_QualificationTransactionID));

                    //if (item.QualificationExamSubjectSSCDetailsIDs != null)
                    //{
                    //    cmdToExecute13.Parameters.Add(new SqlParameter("@nsIDs ", SqlDbType.NVarChar, 4000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.QualificationExamSubjectSSCDetailsIDs));
                    //}
                    //else
                    //{
                    //    cmdToExecute13.Parameters.Add(new SqlParameter("@nsIDs ", SqlDbType.NVarChar, 4000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, ""));
                    //}

                    //cmdToExecute13.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    //cmdToExecute13.Parameters.Add(new SqlParameter("@iModifiedBy", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.ModifiedBy));

                    //cmdToExecute13.Transaction = transaction;
                    //_rowsAffected = cmdToExecute13.ExecuteNonQuery();

                    //#endregion USP_StuRegistrationPreEntranceExaminationSubjectDetail_UpdateXML For SSC

                    #region USP_StuRegistrationPreQualificationSchoolTransaction_Update For HSC

                    cmdToExecute14.CommandText = "dbo.USP_StuRegistrationPreQualificationSchoolTransaction_Update ";
                    cmdToExecute14.CommandType = CommandType.StoredProcedure;
                    cmdToExecute14.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_QualificationTransactionID));
                    cmdToExecute14.Parameters.Add(new SqlParameter("@iStudentRegistrationID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.ID));
                    cmdToExecute14.Parameters.Add(new SqlParameter("@cEducationType ", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, "H"));
                    cmdToExecute14.Parameters.Add(new SqlParameter("@iMediumId", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_Qualification_HSC_MediumOfInstitution));
                    cmdToExecute14.Parameters.Add(new SqlParameter("@siMonthPassing", SqlDbType.SmallInt, 2, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_Qualification_HSC_MonthOfPassing));
                    cmdToExecute14.Parameters.Add(new SqlParameter("@iYearPassing", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_Qualification_HSC_YearOfPassing));
                    if (item.Student_Qualification_HSC_SingleAttempt == "0")
                    {
                        cmdToExecute14.Parameters.Add(new SqlParameter("@bIsSingleAttempt", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, false));
                    }
                    else
                    {
                        cmdToExecute14.Parameters.Add(new SqlParameter("@bIsSingleAttempt", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, true));
                    }
                    cmdToExecute14.Parameters.Add(new SqlParameter("@iMarksObtained", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_Qualification_HSC_ObtainedMark));
                    cmdToExecute14.Parameters.Add(new SqlParameter("@iMarksOutOf", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_Qualification_HSC_OutOfMark));
                    if (item.Student_Qualification_HSC_Percent != null && item.Student_Qualification_HSC_Percent != 0)
                    {
                        cmdToExecute14.Parameters.Add(new SqlParameter("@nsMarksObtainedPercentage", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_Qualification_HSC_Percent));
                    }
                    else
                    {
                        cmdToExecute14.Parameters.Add(new SqlParameter("@nsMarksObtainedPercentage", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.Student_Qualification_HSC_NameofInstitution != null)
                    {
                        cmdToExecute14.Parameters.Add(new SqlParameter("@nsInstitutionName", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_Qualification_HSC_NameofInstitution));
                    }
                    else
                    {
                        cmdToExecute14.Parameters.Add(new SqlParameter("@nsInstitutionName", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.Student_Qualification_HSC_Region_Division_Board != null)
                    {
                        cmdToExecute14.Parameters.Add(new SqlParameter("@nsRegionDivisionBoard", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_Qualification_HSC_Region_Division_Board));
                    }
                    else
                    {
                        cmdToExecute14.Parameters.Add(new SqlParameter("@nsRegionDivisionBoard", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    cmdToExecute14.Parameters.Add(new SqlParameter("@iStreamId", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_Qualification_HSC_StreamID));
                    if (item.Student_Qualification_HSC_StreamOther != null)
                    {
                        cmdToExecute14.Parameters.Add(new SqlParameter("@nsOtherStream", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_Qualification_HSC_StreamOther));
                    }
                    else
                    {
                        cmdToExecute14.Parameters.Add(new SqlParameter("@nsOtherStream", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.Student_Qualification_HSC_Class != null)
                    {
                        cmdToExecute14.Parameters.Add(new SqlParameter("@sGrade", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_Qualification_HSC_Class));
                    }
                    else
                    {
                        cmdToExecute14.Parameters.Add(new SqlParameter("@sGrade", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    cmdToExecute14.Parameters.Add(new SqlParameter("@iGroupAObtainedMarks", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_Qualification_HSC_PCM_PVM_ObtainedMark));
                    cmdToExecute14.Parameters.Add(new SqlParameter("@iGroupAOutOfMarks", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_Qualification_HSC_PCM_PVM_OutOfMark));
                    cmdToExecute14.Parameters.Add(new SqlParameter("@iGroupBObtainedMarks", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_Qualification_HSC_PCB_ObtainedMark));
                    cmdToExecute14.Parameters.Add(new SqlParameter("@iGroupBOutOfMarks", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_Qualification_HSC_PCB_OutOfMark));
                    cmdToExecute14.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute14.Parameters.Add(new SqlParameter("@iModifiedBy", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.ModifiedBy));

                    cmdToExecute14.Transaction = transaction;
                    _rowsAffected = cmdToExecute14.ExecuteNonQuery();
                    //      item.Student_QualificationTransactionID = (Int32)cmdToExecute14.Parameters["@iID"].Value;
                    #endregion USP_StuRegistrationPreQualificationSchoolTransaction_Update For HSC

                    //#region USP_StuRegistrationPreEntranceExaminationSubjectDetail_UpdateXML For HSC

                    //cmdToExecute15.CommandText = "dbo.USP_StuRegistrationPreQualificationSchoolSubjectDetail_UpdateXML ";
                    //cmdToExecute15.CommandType = CommandType.StoredProcedure;

                    //cmdToExecute15.Parameters.Add(new SqlParameter("@iStudentQualificationTransactionID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_QualificationTransactionID));

                    //if (item.QualificationExamSubjectHSCDetailsIDs != null)
                    //{
                    //    cmdToExecute15.Parameters.Add(new SqlParameter("@nsIDs ", SqlDbType.NVarChar, 4000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.QualificationExamSubjectHSCDetailsIDs));
                    //}
                    //else
                    //{
                    //    cmdToExecute15.Parameters.Add(new SqlParameter("@nsIDs ", SqlDbType.NVarChar, 4000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, ""));
                    //}

                    //cmdToExecute15.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    //cmdToExecute15.Parameters.Add(new SqlParameter("@iModifiedBy", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.ModifiedBy));

                    //cmdToExecute15.Transaction = transaction;
                    //_rowsAffected = cmdToExecute15.ExecuteNonQuery();

                    //#endregion USP_StuRegistrationPreEntranceExaminationSubjectDetail_UpdateXML For HSC

                    #region USP_StuRegistrationPreQualificationCollegeTransaction_Update For Diploma / ITI Details


                    cmdToExecute16.CommandText = "dbo.USP_StuRegistrationPreQualificationCollegeTransaction_Update ";
                    cmdToExecute16.CommandType = CommandType.StoredProcedure;
                    //  cmdToExecute16.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 10, ParameterDirection.Output, false, 0, 0, "", DataRowVersion.Proposed, item.Student_QualificationTransactionID));
                    cmdToExecute16.Parameters.Add(new SqlParameter("@iStudentRegistrationID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.ID));
                    cmdToExecute16.Parameters.Add(new SqlParameter("@cEducationType ", SqlDbType.Char, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, "DIPLOMA"));
                    cmdToExecute16.Parameters.Add(new SqlParameter("@iMediumId", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_Qualification_Diploma_ITI_Details_MediumOfInstitution));
                    if (item.Student_Qualification_Diploma_ITI_Details_BranchName != null)
                    {
                        cmdToExecute16.Parameters.Add(new SqlParameter("@nsBranchName", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_Qualification_Diploma_ITI_Details_BranchName));
                    }
                    else
                    {
                        cmdToExecute16.Parameters.Add(new SqlParameter("@nsBranchName", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    cmdToExecute16.Parameters.Add(new SqlParameter("@cExamPattern", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_Qualification_Diploma_ITI_Details_ExamPattern != null ? item.Student_Qualification_Diploma_ITI_Details_ExamPattern : DBNull.Value.ToString()));

                    cmdToExecute16.Parameters.Add(new SqlParameter("@siMonthPassing", SqlDbType.SmallInt, 2, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_Qualification_Diploma_ITI_Details_MonthOfPassing));
                    cmdToExecute16.Parameters.Add(new SqlParameter("@iYearPassing", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_Qualification_Diploma_ITI_Details_YearOfPassing));
                    if (item.Student_Qualification_Diploma_ITI_Details_Class != null)
                    {
                        cmdToExecute16.Parameters.Add(new SqlParameter("@sGrade", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_Qualification_Diploma_ITI_Details_Class));
                    }
                    else
                    {
                        cmdToExecute16.Parameters.Add(new SqlParameter("@sGrade", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    cmdToExecute16.Parameters.Add(new SqlParameter("@iMarksObtained", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_Qualification_Diploma_ITI_Details_ObtainedMark));
                    cmdToExecute16.Parameters.Add(new SqlParameter("@iMarksOutOf", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_Qualification_Diploma_ITI_Details_OutOfMark));
                    //if (item.Student_Qualification_Diploma_ITI_Details_Percent != null)
                    //{
                    cmdToExecute16.Parameters.Add(new SqlParameter("@nsMarksObtainedPercentage", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Convert.ToString(item.Student_Qualification_Diploma_ITI_Details_Percent)));
                    //}
                    //else
                    //{
                    //    cmdToExecute16.Parameters.Add(new SqlParameter("@nsMarksObtainedPercentage", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    //}
                    if (item.Student_Qualification_Diploma_ITI_Details_SingleAttempt == "0")
                    {
                        cmdToExecute16.Parameters.Add(new SqlParameter("@bIsSingleAttempt", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, false));
                    }
                    else
                    {
                        cmdToExecute16.Parameters.Add(new SqlParameter("@bIsSingleAttempt", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, true));
                    }
                    if (item.Student_Qualification_Diploma_ITI_Details_BoardEnrollmentNumber != null)
                    {
                        cmdToExecute16.Parameters.Add(new SqlParameter("@nsEnrollmentNo", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_Qualification_Diploma_ITI_Details_BoardEnrollmentNumber));
                    }
                    else
                    {
                        cmdToExecute16.Parameters.Add(new SqlParameter("@nsEnrollmentNo", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.Student_Qualification_Diploma_ITI_Details_NameofInstitution != null)
                    {
                        cmdToExecute16.Parameters.Add(new SqlParameter("@nsInstitutionName", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_Qualification_Diploma_ITI_Details_NameofInstitution));
                    }
                    else
                    {
                        cmdToExecute16.Parameters.Add(new SqlParameter("@nsInstitutionName", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.Student_Qualification_Diploma_ITI_Details_Board != null)
                    {
                        cmdToExecute16.Parameters.Add(new SqlParameter("@nsRegionDivisionBoard", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_Qualification_Diploma_ITI_Details_Board));
                    }
                    else
                    {
                        cmdToExecute16.Parameters.Add(new SqlParameter("@nsRegionDivisionBoard", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    cmdToExecute16.Parameters.Add(new SqlParameter("@iRegionID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_Qualification_Diploma_ITI_Details_State));
                    cmdToExecute16.Parameters.Add(new SqlParameter("@iCountryID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_Qualification_Diploma_ITI_Details_CountryId));
                    if (item.Student_Qualification_Diploma_ITI_Details_StateOther != null)
                    {
                        cmdToExecute16.Parameters.Add(new SqlParameter("@nsOtherRegion", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_Qualification_Diploma_ITI_Details_StateOther));
                    }
                    else
                    {
                        cmdToExecute16.Parameters.Add(new SqlParameter("@nsOtherRegion", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    cmdToExecute16.Parameters.Add(new SqlParameter("@nsDegreeName", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));

                    cmdToExecute16.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute16.Parameters.Add(new SqlParameter("@iModifiedBy", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.ModifiedBy));

                    cmdToExecute16.Transaction = transaction;
                    _rowsAffected = cmdToExecute16.ExecuteNonQuery();

                    #endregion USP_StuRegistrationPreQualificationCollegeTransaction_Update For Diploma / ITI Details

                    #region USP_StuRegistrationPreQualificationCollegeTransaction_Update For Degree Details


                    cmdToExecute17.CommandText = "dbo.USP_StuRegistrationPreQualificationCollegeTransaction_Update ";
                    cmdToExecute17.CommandType = CommandType.StoredProcedure;
                    //  cmdToExecute17.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 10, ParameterDirection.Output, false, 0, 0, "", DataRowVersion.Proposed, item.Student_QualificationTransactionID));
                    cmdToExecute17.Parameters.Add(new SqlParameter("@iStudentRegistrationID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.ID));
                    cmdToExecute17.Parameters.Add(new SqlParameter("@cEducationType ", SqlDbType.Char, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, "UG"));
                    cmdToExecute17.Parameters.Add(new SqlParameter("@iMediumId", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_Qualification_DegreeDetails_MediumOfInstitution));
                    if (item.Student_Qualification_DegreeDetails_BranchName != null)
                    {
                        cmdToExecute17.Parameters.Add(new SqlParameter("@nsBranchName", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_Qualification_DegreeDetails_BranchName));
                    }
                    else
                    {
                        cmdToExecute17.Parameters.Add(new SqlParameter("@nsBranchName", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    cmdToExecute17.Parameters.Add(new SqlParameter("@cExamPattern", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_Qualification_DegreeDetails_ExamPattern != null ? item.Student_Qualification_DegreeDetails_ExamPattern : DBNull.Value.ToString()));

                    cmdToExecute17.Parameters.Add(new SqlParameter("@siMonthPassing", SqlDbType.SmallInt, 2, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_Qualification_DegreeDetails_MonthOfPassing));
                    cmdToExecute17.Parameters.Add(new SqlParameter("@iYearPassing", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_Qualification_DegreeDetails_YearOfPassing));
                    if (item.Student_Qualification_DegreeDetails_Class != null)
                    {
                        cmdToExecute17.Parameters.Add(new SqlParameter("@sGrade", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_Qualification_DegreeDetails_Class));
                    }
                    else
                    {
                        cmdToExecute17.Parameters.Add(new SqlParameter("@sGrade", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    cmdToExecute17.Parameters.Add(new SqlParameter("@iMarksObtained", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_Qualification_DegreeDetails_ObtainedMark));
                    cmdToExecute17.Parameters.Add(new SqlParameter("@iMarksOutOf", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_Qualification_DegreeDetails_OutOfMark));
                    //if (item.Student_Qualification_DegreeDetails_Percent != null)
                    //{
                    cmdToExecute17.Parameters.Add(new SqlParameter("@nsMarksObtainedPercentage", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Convert.ToString(item.Student_Qualification_DegreeDetails_Percent)));
                    //}
                    //else
                    //{
                    //    cmdToExecute17.Parameters.Add(new SqlParameter("@nsMarksObtainedPercentage", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    //}
                    if (item.Student_Qualification_DegreeDetails_SingleAttempt == "0")
                    {
                        cmdToExecute17.Parameters.Add(new SqlParameter("@bIsSingleAttempt", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, false));
                    }
                    else
                    {
                        cmdToExecute17.Parameters.Add(new SqlParameter("@bIsSingleAttempt", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, true));
                    }
                    if (item.Student_Qualification_DegreeDetails_BoardEnrollmentNumber != null)
                    {
                        cmdToExecute17.Parameters.Add(new SqlParameter("@nsEnrollmentNo", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_Qualification_DegreeDetails_BoardEnrollmentNumber));
                    }
                    else
                    {
                        cmdToExecute17.Parameters.Add(new SqlParameter("@nsEnrollmentNo", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.Student_Qualification_DegreeDetails_NameofInstitution != null)
                    {
                        cmdToExecute17.Parameters.Add(new SqlParameter("@nsInstitutionName", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_Qualification_DegreeDetails_NameofInstitution));
                    }
                    else
                    {
                        cmdToExecute17.Parameters.Add(new SqlParameter("@nsInstitutionName", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.Student_Qualification_DegreeDetails_UniversityName != null)
                    {
                        cmdToExecute17.Parameters.Add(new SqlParameter("@nsRegionDivisionBoard", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_Qualification_DegreeDetails_UniversityName));
                    }
                    else
                    {
                        cmdToExecute17.Parameters.Add(new SqlParameter("@nsRegionDivisionBoard", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    cmdToExecute17.Parameters.Add(new SqlParameter("@iRegionID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_Qualification_DegreeDetails_State));
                    cmdToExecute17.Parameters.Add(new SqlParameter("@iCountryID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_Qualification_DegreeDetails_CountryId));
                    if (item.Student_Qualification_DegreeDetails_StateOther != null)
                    {
                        cmdToExecute17.Parameters.Add(new SqlParameter("@nsOtherRegion", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_Qualification_Diploma_ITI_Details_StateOther));
                    }
                    else
                    {
                        cmdToExecute17.Parameters.Add(new SqlParameter("@nsOtherRegion", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }

                    if (item.Student_Qualification_DegreeDetails_Degree != null)
                    {
                        cmdToExecute17.Parameters.Add(new SqlParameter("@nsDegreeName", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_Qualification_DegreeDetails_Degree));
                    }
                    else
                    {
                        cmdToExecute17.Parameters.Add(new SqlParameter("@nsDegreeName", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    cmdToExecute17.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute17.Parameters.Add(new SqlParameter("@iModifiedBy", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.ModifiedBy));

                    cmdToExecute17.Transaction = transaction;
                    _rowsAffected = cmdToExecute17.ExecuteNonQuery();

                    #endregion USP_StuRegistrationPreQualificationCollegeTransaction_Update For Degree Details

                    #region USP_StuRegistrationPreQualificationCollegeTransaction_Update For     Post Graduation Details


                    cmdToExecute18.CommandText = "dbo.USP_StuRegistrationPreQualificationCollegeTransaction_Update ";
                    cmdToExecute18.CommandType = CommandType.StoredProcedure;
                    //  cmdToExecute18.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 10, ParameterDirection.Output, false, 0, 0, "", DataRowVersion.Proposed, item.Student_QualificationTransactionID));
                    cmdToExecute18.Parameters.Add(new SqlParameter("@iStudentRegistrationID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.ID));
                    cmdToExecute18.Parameters.Add(new SqlParameter("@cEducationType ", SqlDbType.Char, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, "PG"));
                    cmdToExecute18.Parameters.Add(new SqlParameter("@iMediumId", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_Qualification_PostGraduationDetails_MediumOfInstitution));
                    if (item.Student_Qualification_PostGraduationDetails_BranchName != null)
                    {
                        cmdToExecute18.Parameters.Add(new SqlParameter("@nsBranchName", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_Qualification_PostGraduationDetails_BranchName));
                    }
                    else
                    {
                        cmdToExecute18.Parameters.Add(new SqlParameter("@nsBranchName", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    cmdToExecute18.Parameters.Add(new SqlParameter("@cExamPattern", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_Qualification_PostGraduationDetails_ExamPattern != null ? item.Student_Qualification_PostGraduationDetails_ExamPattern : DBNull.Value.ToString()));

                    cmdToExecute18.Parameters.Add(new SqlParameter("@siMonthPassing", SqlDbType.SmallInt, 2, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_Qualification_PostGraduationDetails_MonthOfPassing));
                    cmdToExecute18.Parameters.Add(new SqlParameter("@iYearPassing", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_Qualification_PostGraduationDetails_YearOfPassing));
                    if (item.Student_Qualification_PostGraduationDetails_Class != null)
                    {
                        cmdToExecute18.Parameters.Add(new SqlParameter("@sGrade", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_Qualification_PostGraduationDetails_Class));
                    }
                    else
                    {
                        cmdToExecute18.Parameters.Add(new SqlParameter("@sGrade", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    cmdToExecute18.Parameters.Add(new SqlParameter("@iMarksObtained", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_Qualification_PostGraduationDetails_ObtainedMark));
                    cmdToExecute18.Parameters.Add(new SqlParameter("@iMarksOutOf", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_Qualification_PostGraduationDetails_OutOfMark));
                    //if (item.Student_Qualification_PostGraduationDetails_Percent != null)
                    //{
                    cmdToExecute18.Parameters.Add(new SqlParameter("@nsMarksObtainedPercentage", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Convert.ToString(item.Student_Qualification_PostGraduationDetails_Percent)));
                    //}
                    //else
                    //{
                    //    cmdToExecute18.Parameters.Add(new SqlParameter("@nsMarksObtainedPercentage", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    //}
                    if (item.Student_Qualification_PostGraduationDetails_SingleAttempt == "0")
                    {
                        cmdToExecute18.Parameters.Add(new SqlParameter("@bIsSingleAttempt", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, false));
                    }
                    else
                    {
                        cmdToExecute18.Parameters.Add(new SqlParameter("@bIsSingleAttempt", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, true));
                    }
                    if (item.Student_Qualification_PostGraduationDetails_BoardEnrollmentNumber != null)
                    {
                        cmdToExecute18.Parameters.Add(new SqlParameter("@nsEnrollmentNo", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_Qualification_PostGraduationDetails_BoardEnrollmentNumber));
                    }
                    else
                    {
                        cmdToExecute18.Parameters.Add(new SqlParameter("@nsEnrollmentNo", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.Student_Qualification_PostGraduationDetails_NameofInstitution != null)
                    {
                        cmdToExecute18.Parameters.Add(new SqlParameter("@nsInstitutionName", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_Qualification_PostGraduationDetails_NameofInstitution));
                    }
                    else
                    {
                        cmdToExecute18.Parameters.Add(new SqlParameter("@nsInstitutionName", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.Student_Qualification_PostGraduationDetails_UniversityName != null)
                    {
                        cmdToExecute18.Parameters.Add(new SqlParameter("@nsRegionDivisionBoard", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_Qualification_PostGraduationDetails_UniversityName));
                    }
                    else
                    {
                        cmdToExecute18.Parameters.Add(new SqlParameter("@nsRegionDivisionBoard", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    cmdToExecute18.Parameters.Add(new SqlParameter("@iRegionID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_Qualification_PostGraduationDetails_State));
                    cmdToExecute18.Parameters.Add(new SqlParameter("@iCountryID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_Qualification_PostGraduationDetails_CountryId));
                    if (item.Student_Qualification_PostGraduationDetails_StateOther != null)
                    {
                        cmdToExecute18.Parameters.Add(new SqlParameter("@nsOtherRegion", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_Qualification_Diploma_ITI_Details_StateOther));
                    }
                    else
                    {
                        cmdToExecute18.Parameters.Add(new SqlParameter("@nsOtherRegion", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }

                    if (item.Student_Qualification_PostGraduationDetails_PostGraduation != null)
                    {
                        cmdToExecute18.Parameters.Add(new SqlParameter("@nsDegreeName", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_Qualification_PostGraduationDetails_PostGraduation));
                    }
                    else
                    {
                        cmdToExecute18.Parameters.Add(new SqlParameter("@nsDegreeName", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    cmdToExecute18.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute18.Parameters.Add(new SqlParameter("@iModifiedBy", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.ModifiedBy));

                    cmdToExecute18.Transaction = transaction;
                    _rowsAffected = cmdToExecute18.ExecuteNonQuery();

                    #endregion USP_StuRegistrationPreQualificationCollegeTransaction_Update For    Post Graduation Details

                    #region USP_StuRegistrationQualifyingSelectionInfo_Update


                    cmdToExecute19.CommandText = "dbo.USP_StuRegistrationQualifyingSelectionInfo_Update ";
                    cmdToExecute19.CommandType = CommandType.StoredProcedure;
                    //  cmdToExecute19.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 10, ParameterDirection.Output, false, 0, 0, "", DataRowVersion.Proposed, item.Student_QualificationTransactionID));
                    cmdToExecute19.Parameters.Add(new SqlParameter("@iStudentRegistrationID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.ID));
                    if (item.Student_DTE_DTEUserID != null)
                    {
                        cmdToExecute19.Parameters.Add(new SqlParameter("@nsUserId", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_DTE_DTEUserID));
                    }
                    else
                    {
                        cmdToExecute19.Parameters.Add(new SqlParameter("@nsUserId", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.Student_DTE_DTEPassword != null)
                    {
                        cmdToExecute19.Parameters.Add(new SqlParameter("@nsUserPassword", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_DTE_DTEPassword));
                    }
                    else
                    {
                        cmdToExecute19.Parameters.Add(new SqlParameter("@nsUserPassword", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.Student_DTE_DTESrNo != null)
                    {
                        cmdToExecute19.Parameters.Add(new SqlParameter("@nsSerialNumber", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_DTE_DTESrNo));
                    }
                    else
                    {
                        cmdToExecute19.Parameters.Add(new SqlParameter("@nsSerialNumber", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.Student_DTE_DTEMeritNo != null)
                    {
                        cmdToExecute19.Parameters.Add(new SqlParameter("@nsMeritNumber", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_DTE_DTEMeritNo));
                    }
                    else
                    {
                        cmdToExecute19.Parameters.Add(new SqlParameter("@nsMeritNumber", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    cmdToExecute19.Parameters.Add(new SqlParameter("@sAdmissionType", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_DTE_AdmissionTypeId));
                    cmdToExecute19.Parameters.Add(new SqlParameter("@sAdmissionRound", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_DTE_AdmissionRound));
                    cmdToExecute19.Parameters.Add(new SqlParameter("@iAdmissionCategoryID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_DTE_AdmissionCategoryId));
                    if (item.Student_DTE_DTESeatNo != null)
                    {
                        cmdToExecute19.Parameters.Add(new SqlParameter("@sSeatType", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_DTE_DTESeatNo));
                    }
                    else
                    {
                        cmdToExecute19.Parameters.Add(new SqlParameter("@sSeatType", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }

                    if (item.Student_DTE_QualifyingExamName != null)
                    {
                        cmdToExecute19.Parameters.Add(new SqlParameter("@sQualifyingExaminationName", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_DTE_QualifyingExamName));
                    }
                    else
                    {
                        cmdToExecute19.Parameters.Add(new SqlParameter("@sQualifyingExaminationName", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    cmdToExecute19.Parameters.Add(new SqlParameter("@iMarksObtained", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_DTE_QualifyingExamMarks));

                    cmdToExecute19.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute19.Parameters.Add(new SqlParameter("@iModifiedBy", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.ModifiedBy));

                    cmdToExecute19.Transaction = transaction;
                    _rowsAffected = cmdToExecute19.ExecuteNonQuery();

                    #endregion USP_StuRegistrationQualifyingSelectionInfo_Update

                    #region USP_StuRegistrationDocumentFlag_UpdateXML


                    cmdToExecute20.CommandText = "dbo.USP_StuRegistrationDocumentFlag_Update ";
                    cmdToExecute20.CommandType = CommandType.StoredProcedure;
                    //  cmdToExecute20.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 10, ParameterDirection.Output, false, 0, 0, "", DataRowVersion.Proposed, item.Student_QualificationTransactionID));
                    cmdToExecute20.Parameters.Add(new SqlParameter("@iStudentRegistrationID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.ID));

                    cmdToExecute20.Parameters.Add(new SqlParameter("@bSubmitedDocument1", SqlDbType.Bit, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_AdmissionDocuments_JETMarkSheet));
                    cmdToExecute20.Parameters.Add(new SqlParameter("@bSubmitedDocument2", SqlDbType.Bit, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_AdmissionDocuments_AllotmentLetter));
                    cmdToExecute20.Parameters.Add(new SqlParameter("@bSubmitedDocument3", SqlDbType.Bit, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_AdmissionDocuments_TenthMarkSheet));
                    cmdToExecute20.Parameters.Add(new SqlParameter("@bSubmitedDocument4", SqlDbType.Bit, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_AdmissionDocuments_TwelvethMarkSheet));
                    cmdToExecute20.Parameters.Add(new SqlParameter("@bSubmitedDocument5", SqlDbType.Bit, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_AdmissionDocuments_AllDiplomaMarksheet));
                    cmdToExecute20.Parameters.Add(new SqlParameter("@bSubmitedDocument6", SqlDbType.Bit, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_AdmissionDocuments_LeavingCertificate));
                    cmdToExecute20.Parameters.Add(new SqlParameter("@bSubmitedDocument7", SqlDbType.Bit, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_AdmissionDocuments_Domicile_BirthCertificate));
                    cmdToExecute20.Parameters.Add(new SqlParameter("@bSubmitedDocument8", SqlDbType.Bit, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_AdmissionDocuments_NationalityCertificate));
                    cmdToExecute20.Parameters.Add(new SqlParameter("@bSubmitedDocument9", SqlDbType.Bit, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_AdmissionDocuments_CasteCertificate));
                    cmdToExecute20.Parameters.Add(new SqlParameter("@bSubmitedDocument10", SqlDbType.Bit, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_AdmissionDocuments_CasteValidityCertificate));
                    cmdToExecute20.Parameters.Add(new SqlParameter("@bSubmitedDocument11", SqlDbType.Bit, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_AdmissionDocuments_NonCreamylayerCertificate));
                    cmdToExecute20.Parameters.Add(new SqlParameter("@bSubmitedDocument12", SqlDbType.Bit, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_AdmissionDocuments_EquivalenceCertificate));
                    cmdToExecute20.Parameters.Add(new SqlParameter("@bSubmitedDocument13", SqlDbType.Bit, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_AdmissionDocuments_MigrationCertificate));
                    cmdToExecute20.Parameters.Add(new SqlParameter("@bSubmitedDocument14", SqlDbType.Bit, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_AdmissionDocuments_GapCertificate));
                    cmdToExecute20.Parameters.Add(new SqlParameter("@bSubmitedDocument15", SqlDbType.Bit, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_AdmissionDocuments_AntiRaggingAffidavit));
                    cmdToExecute20.Parameters.Add(new SqlParameter("@bSubmitedDocument16", SqlDbType.Bit, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_AdmissionDocuments_Proforma_Fand_F1_On_DoctorsLetter_Head));
                    cmdToExecute20.Parameters.Add(new SqlParameter("@bSubmitedDocument17", SqlDbType.Bit, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_AdmissionDocuments_Proforma_I));
                    cmdToExecute20.Parameters.Add(new SqlParameter("@bSubmitedDocument18", SqlDbType.Bit, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_AdmissionDocuments_ProformaG1));
                    cmdToExecute20.Parameters.Add(new SqlParameter("@bSubmitedDocument19", SqlDbType.Bit, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_AdmissionDocuments_ProformaG2));
                    cmdToExecute20.Parameters.Add(new SqlParameter("@bSubmitedDocument20", SqlDbType.Bit, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_AdmissionDocuments_Proforma_C_D_E));
                    cmdToExecute20.Parameters.Add(new SqlParameter("@bSubmitedDocument21", SqlDbType.Bit, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_AdmissionDocuments_FathersIncomeCertificate));
                    cmdToExecute20.Parameters.Add(new SqlParameter("@bSubmitedDocument22", SqlDbType.Bit, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_AdmissionDocuments_AadharCardXerox));
                    cmdToExecute20.Parameters.Add(new SqlParameter("@bSubmitedDocument23", SqlDbType.Bit, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_AdmissionDocuments_B_WPhoto_I_card_size));
                    cmdToExecute20.Parameters.Add(new SqlParameter("@bSubmitedDocument24", SqlDbType.Bit, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_AdmissionDocuments_Colour_photo));

                    ////  If Applicable
                    cmdToExecute20.Parameters.Add(new SqlParameter("@bSubmitedDocument25", SqlDbType.Bit, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_AdmissionDocuments_PGStudents_DegreeMarksheet));
                    cmdToExecute20.Parameters.Add(new SqlParameter("@bSubmitedDocument26", SqlDbType.Bit, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_AdmissionDocuments_PGStudents_DegreeCertificate));
                    cmdToExecute20.Parameters.Add(new SqlParameter("@bSubmitedDocument27", SqlDbType.Bit, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_AdmissionDocuments_PGStudents_GateScoreCard));
                    cmdToExecute20.Parameters.Add(new SqlParameter("@bSubmitedDocument28", SqlDbType.Bit, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_AdmissionDocuments_PGStudents_SponsorshipLetterforSponsoredCandidate));




                    cmdToExecute20.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute20.Parameters.Add(new SqlParameter("@iModifiedBy", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.ModifiedBy));

                    cmdToExecute20.Transaction = transaction;
                    _rowsAffected = cmdToExecute20.ExecuteNonQuery();

                    #endregion USP_StuRegistrationQualifyingSelectionInfo_Update

                    //#region USP_StuRegistrationDocumentSubmitted_UpdateXML


                    //cmdToExecute21.CommandText = "dbo.USP_StuRegistrationDocumentSubmitted_UpdateXML ";
                    //cmdToExecute21.CommandType = CommandType.StoredProcedure;
                    //cmdToExecute21.Parameters.Add(new SqlParameter("@iStudentRegistrationID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.ID));
                    //cmdToExecute21.Parameters.Add(new SqlParameter("@iAcadSessionId ", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_AcademicYearId));
                    //if (item.StudentSubmitedDocumentIDs != null || item.StudentSubmitedDocumentIDs != "")
                    //{
                    //    cmdToExecute21.Parameters.Add(new SqlParameter("@nsIDs", SqlDbType.NVarChar, 4000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.StudentSubmitedDocumentIDs));
                    //}
                    //else
                    //{

                    //    cmdToExecute21.Parameters.Add(new SqlParameter("@nsIDs", SqlDbType.NVarChar, 4000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    //}
                    //cmdToExecute21.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    //cmdToExecute21.Parameters.Add(new SqlParameter("@iModifiedBy", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.ModifiedBy));

                    //cmdToExecute21.Transaction = transaction;
                    //_rowsAffected = cmdToExecute21.ExecuteNonQuery();

                    //#endregion USP_StuRegistrationDocumentSubmitted_UpdateXML

                    #region USP_stuRegistrationAddressDetails_Update


                    cmdToExecute22.CommandText = "dbo.USP_stuRegistrationAddressDetails_Update ";
                    cmdToExecute22.CommandType = CommandType.StoredProcedure;
                    //  cmdToExecute22.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 10, ParameterDirection.Output, false, 0, 0, "", DataRowVersion.Proposed, item.Student_QualificationTransactionID));
                    cmdToExecute22.Parameters.Add(new SqlParameter("@iStudentRegistrationID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.ID));
                    cmdToExecute22.Parameters.Add(new SqlParameter("@cAddressType", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, "P"));
                    if (item.Student_PermanentAddress_Address1 != null)
                    {
                        cmdToExecute22.Parameters.Add(new SqlParameter("@nsAddressLine1", SqlDbType.NVarChar, 150, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_PermanentAddress_Address1));
                    }
                    else
                    {
                        cmdToExecute22.Parameters.Add(new SqlParameter("@nsAddressLine1", SqlDbType.NVarChar, 150, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.Student_PermanentAddress_Address2 != null)
                    {
                        cmdToExecute22.Parameters.Add(new SqlParameter("@nsAddressLine2", SqlDbType.NVarChar, 150, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_PermanentAddress_Address2));
                    }
                    else
                    {
                        cmdToExecute22.Parameters.Add(new SqlParameter("@nsAddressLine2", SqlDbType.NVarChar, 150, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.Student_PermanentAddress_PloteNo != null)
                    {
                        cmdToExecute22.Parameters.Add(new SqlParameter("@nsPlotNumber", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_PermanentAddress_PloteNo));
                    }
                    else
                    {
                        cmdToExecute22.Parameters.Add(new SqlParameter("@nsPlotNumber", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.Student_PermanentAddress_StreeNo != null)
                    {
                        cmdToExecute22.Parameters.Add(new SqlParameter("@nsStreet", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_PermanentAddress_StreeNo));
                    }
                    else
                    {
                        cmdToExecute22.Parameters.Add(new SqlParameter("@nsStreet", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    cmdToExecute22.Parameters.Add(new SqlParameter("@iCountryId", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_PermanentAddress_CountryId));
                    cmdToExecute22.Parameters.Add(new SqlParameter("@iRegionId", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_PermanentAddress_State));
                    if (item.Student_PermanentAddress_StateOther != null)
                    {
                        cmdToExecute22.Parameters.Add(new SqlParameter("@nsRegionOther", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_PermanentAddress_StateOther));
                    }
                    else
                    {
                        cmdToExecute22.Parameters.Add(new SqlParameter("@nsRegionOther", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    cmdToExecute22.Parameters.Add(new SqlParameter("@iCityId", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_PermanentAddress_DistrictID));
                    if (item.Student_PermanentAddress_DistrictOther != null)
                    {
                        cmdToExecute22.Parameters.Add(new SqlParameter("@nsCityOther", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_PermanentAddress_DistrictOther));
                    }
                    else
                    {
                        cmdToExecute22.Parameters.Add(new SqlParameter("@nsCityOther", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    cmdToExecute22.Parameters.Add(new SqlParameter("@iLocationId", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_PermanentAddress_City_TahsilID));
                    if (item.Student_PermanentAddress_City_TahsilOther != null)
                    {
                        cmdToExecute22.Parameters.Add(new SqlParameter("@nsLocationOther", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_PermanentAddress_City_TahsilOther));
                    }
                    else
                    {
                        cmdToExecute22.Parameters.Add(new SqlParameter("@nsLocationOther", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.Student_PermanentAddress_NearPoliceStation != null)
                    {
                        cmdToExecute22.Parameters.Add(new SqlParameter("@nsNearPoliceStation", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_PermanentAddress_NearPoliceStation));
                    }
                    else
                    {
                        cmdToExecute22.Parameters.Add(new SqlParameter("@nsNearPoliceStation", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.Student_PermanentAddress_Tahsil != null)
                    {
                        cmdToExecute22.Parameters.Add(new SqlParameter("@nsTahsil", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_PermanentAddress_Tahsil));
                    }
                    else
                    {
                        cmdToExecute22.Parameters.Add(new SqlParameter("@nsTahsil", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.Student_PermanentAddress_ZipCode != null)
                    {
                        cmdToExecute22.Parameters.Add(new SqlParameter("@nsZipCode", SqlDbType.NVarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_PermanentAddress_ZipCode));
                    }
                    else
                    {
                        cmdToExecute22.Parameters.Add(new SqlParameter("@nsZipCode", SqlDbType.NVarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.Student_PermanentAddress_City_Tahsil_Pattern != null)
                    {
                        cmdToExecute22.Parameters.Add(new SqlParameter("@nsCityTahsilPattern", SqlDbType.NVarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_PermanentAddress_City_Tahsil_Pattern));
                    }
                    else
                    {
                        cmdToExecute22.Parameters.Add(new SqlParameter("@nsCityTahsilPattern", SqlDbType.NVarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }

                    cmdToExecute22.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute22.Parameters.Add(new SqlParameter("@iModifiedBy", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.ModifiedBy));

                    cmdToExecute22.Transaction = transaction;
                    _rowsAffected = cmdToExecute22.ExecuteNonQuery();

                    #endregion USP_stuRegistrationAddressDetails_Update

                    #region USP_stuRegistrationAddressDetails_Update For   Correspondence Address

                    if (item.SameAsPerPermanentAddress == true)
                    {

                        cmdToExecute23.CommandText = "dbo.USP_stuRegistrationAddressDetails_Update ";
                        cmdToExecute23.CommandType = CommandType.StoredProcedure;
                        //  cmdToExecute23.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 10, ParameterDirection.Output, false, 0, 0, "", DataRowVersion.Proposed, item.Student_QualificationTransactionID));
                        cmdToExecute23.Parameters.Add(new SqlParameter("@iStudentRegistrationID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.ID));
                        cmdToExecute23.Parameters.Add(new SqlParameter("@cAddressType", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, "C"));
                        if (item.Student_PermanentAddress_Address1 != null)
                        {
                            cmdToExecute23.Parameters.Add(new SqlParameter("@nsAddressLine1", SqlDbType.NVarChar, 150, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_PermanentAddress_Address1));
                        }
                        else
                        {
                            cmdToExecute23.Parameters.Add(new SqlParameter("@nsAddressLine1", SqlDbType.NVarChar, 150, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                        }
                        if (item.Student_PermanentAddress_Address2 != null)
                        {
                            cmdToExecute23.Parameters.Add(new SqlParameter("@nsAddressLine2", SqlDbType.NVarChar, 150, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_PermanentAddress_Address2));
                        }
                        else
                        {
                            cmdToExecute23.Parameters.Add(new SqlParameter("@nsAddressLine2", SqlDbType.NVarChar, 150, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                        }
                        if (item.Student_PermanentAddress_PloteNo != null)
                        {
                            cmdToExecute23.Parameters.Add(new SqlParameter("@nsPlotNumber", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_PermanentAddress_PloteNo));
                        }
                        else
                        {
                            cmdToExecute23.Parameters.Add(new SqlParameter("@nsPlotNumber", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                        }
                        if (item.Student_PermanentAddress_StreeNo != null)
                        {
                            cmdToExecute23.Parameters.Add(new SqlParameter("@nsStreet", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_PermanentAddress_StreeNo));
                        }
                        else
                        {
                            cmdToExecute23.Parameters.Add(new SqlParameter("@nsStreet", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                        }
                        cmdToExecute23.Parameters.Add(new SqlParameter("@iCountryId", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_PermanentAddress_CountryId));
                        cmdToExecute23.Parameters.Add(new SqlParameter("@iRegionId", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_PermanentAddress_State));
                        if (item.Student_PermanentAddress_StateOther != null)
                        {
                            cmdToExecute23.Parameters.Add(new SqlParameter("@nsRegionOther", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_PermanentAddress_StateOther));
                        }
                        else
                        {
                            cmdToExecute23.Parameters.Add(new SqlParameter("@nsRegionOther", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                        }
                        cmdToExecute23.Parameters.Add(new SqlParameter("@iCityId", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_PermanentAddress_DistrictID));
                        if (item.Student_PermanentAddress_DistrictOther != null)
                        {
                            cmdToExecute23.Parameters.Add(new SqlParameter("@nsCityOther", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_PermanentAddress_DistrictOther));
                        }
                        else
                        {
                            cmdToExecute23.Parameters.Add(new SqlParameter("@nsCityOther", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                        }
                        cmdToExecute23.Parameters.Add(new SqlParameter("@iLocationId", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_PermanentAddress_City_TahsilID));
                        if (item.Student_PermanentAddress_City_TahsilOther != null)
                        {
                            cmdToExecute23.Parameters.Add(new SqlParameter("@nsLocationOther", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_PermanentAddress_City_TahsilOther));
                        }
                        else
                        {
                            cmdToExecute23.Parameters.Add(new SqlParameter("@nsLocationOther", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                        }
                        if (item.Student_PermanentAddress_NearPoliceStation != null)
                        {
                            cmdToExecute23.Parameters.Add(new SqlParameter("@nsNearPoliceStation", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_PermanentAddress_NearPoliceStation));
                        }
                        else
                        {
                            cmdToExecute23.Parameters.Add(new SqlParameter("@nsNearPoliceStation", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                        }
                        if (item.Student_PermanentAddress_Tahsil != null)
                        {
                            cmdToExecute23.Parameters.Add(new SqlParameter("@nsTahsil", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_PermanentAddress_Tahsil));
                        }
                        else
                        {
                            cmdToExecute23.Parameters.Add(new SqlParameter("@nsTahsil", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                        }
                        if (item.Student_PermanentAddress_ZipCode != null)
                        {
                            cmdToExecute23.Parameters.Add(new SqlParameter("@nsZipCode", SqlDbType.NVarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_PermanentAddress_ZipCode));
                        }
                        else
                        {
                            cmdToExecute23.Parameters.Add(new SqlParameter("@nsZipCode", SqlDbType.NVarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                        }
                        if (item.Student_PermanentAddress_City_Tahsil_Pattern != null)
                        {
                            cmdToExecute23.Parameters.Add(new SqlParameter("@nsCityTahsilPattern", SqlDbType.NVarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_PermanentAddress_City_Tahsil_Pattern));
                        }
                        else
                        {
                            cmdToExecute23.Parameters.Add(new SqlParameter("@nsCityTahsilPattern", SqlDbType.NVarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                        }

                        cmdToExecute23.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                        cmdToExecute23.Parameters.Add(new SqlParameter("@iModifiedBy", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.ModifiedBy));

                        cmdToExecute23.Transaction = transaction;
                        _rowsAffected = cmdToExecute23.ExecuteNonQuery();
                    }

                    else
                    {
                        cmdToExecute23.CommandText = "dbo.USP_stuRegistrationAddressDetails_Update ";
                        cmdToExecute23.CommandType = CommandType.StoredProcedure;
                        //  cmdToExecute23.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 10, ParameterDirection.Output, false, 0, 0, "", DataRowVersion.Proposed, item.Student_QualificationTransactionID));
                        cmdToExecute23.Parameters.Add(new SqlParameter("@iStudentRegistrationID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.ID));
                        cmdToExecute23.Parameters.Add(new SqlParameter("@cAddressType", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, "C"));
                        if (item.Student_CorrespondenceAddress_Address1 != null)
                        {
                            cmdToExecute23.Parameters.Add(new SqlParameter("@nsAddressLine1", SqlDbType.NVarChar, 150, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_CorrespondenceAddress_Address1));
                        }
                        else
                        {
                            cmdToExecute23.Parameters.Add(new SqlParameter("@nsAddressLine1", SqlDbType.NVarChar, 150, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                        }
                        if (item.Student_CorrespondenceAddress_Address2 != null)
                        {
                            cmdToExecute23.Parameters.Add(new SqlParameter("@nsAddressLine2", SqlDbType.NVarChar, 150, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_CorrespondenceAddress_Address2));
                        }
                        else
                        {
                            cmdToExecute23.Parameters.Add(new SqlParameter("@nsAddressLine2", SqlDbType.NVarChar, 150, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                        }
                        if (item.Student_CorrespondenceAddress_PloteNo != null)
                        {
                            cmdToExecute23.Parameters.Add(new SqlParameter("@nsPlotNumber", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_CorrespondenceAddress_PloteNo));
                        }
                        else
                        {
                            cmdToExecute23.Parameters.Add(new SqlParameter("@nsPlotNumber", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                        }
                        if (item.Student_CorrespondenceAddress_StreeNo != null)
                        {
                            cmdToExecute23.Parameters.Add(new SqlParameter("@nsStreet", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_CorrespondenceAddress_StreeNo));
                        }
                        else
                        {
                            cmdToExecute23.Parameters.Add(new SqlParameter("@nsStreet", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                        }
                        cmdToExecute23.Parameters.Add(new SqlParameter("@iCountryId", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_CorrespondenceAddress_CountryId));
                        cmdToExecute23.Parameters.Add(new SqlParameter("@iRegionId", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_CorrespondenceAddress_State));
                        if (item.Student_CorrespondenceAddress_StateOther != null)
                        {
                            cmdToExecute23.Parameters.Add(new SqlParameter("@nsRegionOther", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_CorrespondenceAddress_StateOther));
                        }
                        else
                        {
                            cmdToExecute23.Parameters.Add(new SqlParameter("@nsRegionOther", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                        }
                        cmdToExecute23.Parameters.Add(new SqlParameter("@iCityId", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_CorrespondenceAddress_DistrictID));
                        if (item.Student_CorrespondenceAddress_DistrictOther != null)
                        {
                            cmdToExecute23.Parameters.Add(new SqlParameter("@nsCityOther", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_CorrespondenceAddress_DistrictOther));
                        }
                        else
                        {
                            cmdToExecute23.Parameters.Add(new SqlParameter("@nsCityOther", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                        }
                        cmdToExecute23.Parameters.Add(new SqlParameter("@iLocationId", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_CorrespondenceAddress_City_TahsilID));
                        if (item.Student_CorrespondenceAddress_City_TahsilOther != null)
                        {
                            cmdToExecute23.Parameters.Add(new SqlParameter("@nsLocationOther", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_CorrespondenceAddress_City_TahsilOther));
                        }
                        else
                        {
                            cmdToExecute23.Parameters.Add(new SqlParameter("@nsLocationOther", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                        }
                        if (item.Student_CorrespondenceAddress_NearPoliceStation != null)
                        {
                            cmdToExecute23.Parameters.Add(new SqlParameter("@nsNearPoliceStation", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_CorrespondenceAddress_NearPoliceStation));
                        }
                        else
                        {
                            cmdToExecute23.Parameters.Add(new SqlParameter("@nsNearPoliceStation", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                        }
                        if (item.Student_CorrespondenceAddress_Tahsil != null)
                        {
                            cmdToExecute23.Parameters.Add(new SqlParameter("@nsTahsil", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_CorrespondenceAddress_Tahsil));
                        }
                        else
                        {
                            cmdToExecute23.Parameters.Add(new SqlParameter("@nsTahsil", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                        }
                        if (item.Student_CorrespondenceAddress_ZipCode != null)
                        {
                            cmdToExecute23.Parameters.Add(new SqlParameter("@nsZipCode", SqlDbType.NVarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_CorrespondenceAddress_ZipCode));
                        }
                        else
                        {
                            cmdToExecute23.Parameters.Add(new SqlParameter("@nsZipCode", SqlDbType.NVarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                        }
                        if (item.Student_PermanentAddress_City_Tahsil_Pattern != null)
                        {
                            cmdToExecute23.Parameters.Add(new SqlParameter("@nsCityTahsilPattern", SqlDbType.NVarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_PermanentAddress_City_Tahsil_Pattern));
                        }
                        else
                        {
                            cmdToExecute23.Parameters.Add(new SqlParameter("@nsCityTahsilPattern", SqlDbType.NVarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                        }

                        cmdToExecute23.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                        cmdToExecute23.Parameters.Add(new SqlParameter("@iModifiedBy", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.ModifiedBy));

                        cmdToExecute23.Transaction = transaction;
                        _rowsAffected = cmdToExecute23.ExecuteNonQuery();


                    }
                    #endregion USP_stuRegistrationAddressDetails_Update

                    #region USP_StuRegistrationPreviousWorkExperience_UpdateXML

                    cmdToExecute26.CommandText = "dbo.USP_StuRegistrationPreviousWorkExperience_UpdateXML ";
                    cmdToExecute26.CommandType = CommandType.StoredProcedure;

                    cmdToExecute26.Parameters.Add(new SqlParameter("@iStudentRegistrationID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.ID));
                    if (!string.IsNullOrEmpty(item.WorkExperienceXML))
                    {
                        cmdToExecute26.Parameters.Add(new SqlParameter("@xWorkExperienceXML", SqlDbType.Xml, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.WorkExperienceXML));
                    }
                    else
                    {
                        cmdToExecute26.Parameters.Add(new SqlParameter("@xWorkExperienceXML", SqlDbType.Xml, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    cmdToExecute26.Parameters.Add(new SqlParameter("@nsDeletedPreviousExperienceIDs", SqlDbType.NVarChar, 1000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.DeletedPreviousExperienceIDs));
                    cmdToExecute26.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute26.Parameters.Add(new SqlParameter("@iModifiedBy", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.StudentSelfRegistrationID));

                    cmdToExecute26.Transaction = transaction;
                    _rowsAffected = cmdToExecute26.ExecuteNonQuery();

                    #endregion USP_StuRegistrationPreviousWorkExperience_UpdateXML

                    #region USP_GeneralTaskApproverNotification_Insert
                    if (item.IsTaskGeneratedForApproval == true)
                    {

                        cmdToExecute24.CommandText = "dbo.USP_GeneralTaskApproverNotification_Insert";
                        cmdToExecute24.CommandType = CommandType.StoredProcedure;
                        cmdToExecute24.Parameters.Add(new SqlParameter("@nsMenuCode", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, "Stu_StudentRegistrationApplication"));
                        cmdToExecute24.Parameters.Add(new SqlParameter("@nsCentreCode", SqlDbType.NVarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.CenterCode));
                        cmdToExecute24.Parameters.Add(new SqlParameter("@sTaskApprovalBasedTable", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, "StuRegistrationStudentMaster"));
                        cmdToExecute24.Parameters.Add(new SqlParameter("@sTaskApprovalParamPrimaryKey", SqlDbType.VarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, "ID"));
                        cmdToExecute24.Parameters.Add(new SqlParameter("@iTaskApprovalKeyValue", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                        cmdToExecute24.Parameters.Add(new SqlParameter("@iStageSequenceNumber", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, 1));
                        cmdToExecute24.Parameters.Add(new SqlParameter("@sEntitytableName", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, "StuRegistrationStudentMaster"));
                        cmdToExecute24.Parameters.Add(new SqlParameter("@sEntityPKName", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, "ID"));
                        cmdToExecute24.Parameters.Add(new SqlParameter("@iEntityPKValue", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.ID));
                        cmdToExecute24.Parameters.Add(new SqlParameter("@iPersonID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.ID));
                        cmdToExecute24.Parameters.Add(new SqlParameter("@cPersonType", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, 'R'));
                        cmdToExecute24.Parameters.Add(new SqlParameter("@iApprovalStatus", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, 1));
                        cmdToExecute24.Parameters.Add(new SqlParameter("@iCreatedBy", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.ID));
                        cmdToExecute24.Parameters.Add(new SqlParameter("@iTaskNotificationMasterID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, 0));
                        cmdToExecute24.Parameters.Add(new SqlParameter("@iTaskNotificationDetailsID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, 0));
                        cmdToExecute24.Parameters.Add(new SqlParameter("@bIsLast", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, 0));
                        cmdToExecute24.Parameters.Add(new SqlParameter("@dRangeValue", SqlDbType.Decimal, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                        cmdToExecute24.Parameters.Add(new SqlParameter("@iStatus", SqlDbType.Int, 10, ParameterDirection.Output, false, 0, 0, "", DataRowVersion.Proposed, item.Status));
                        cmdToExecute24.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));


                        cmdToExecute24.Transaction = transaction;
                        _rowsAffected = cmdToExecute24.ExecuteNonQuery();

                        cmdToExecute25.CommandText = "dbo.USP_StuRegistration_Update";
                        cmdToExecute25.CommandType = CommandType.StoredProcedure;
                        cmdToExecute25.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.StudentSelfRegistrationID));
                        cmdToExecute25.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                        cmdToExecute25.Transaction = transaction;
                        _rowsAffected = cmdToExecute25.ExecuteNonQuery();
                    }
                    #endregion USP_GeneralTaskApproverNotification_Update

                    transaction.Commit();

                }
            }
            catch (SqlException ex)
            {
                transaction.Rollback();
                //transaction1.Rollback();
                response.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                _logException.Error(ex.Message);
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                response.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                _logException.Error(ex.Message);
            }
            finally
            {
                if (_mainConnectionIsCreatedLocal)
                {
                    // Close connection.
                    _mainConnection.Close();
                }
                response.Entity = item;
                cmdToExecute.Dispose();
                cmdToExecute1.Dispose();
                cmdToExecute2.Dispose();
                cmdToExecute3.Dispose();
                cmdToExecute4.Dispose();
                cmdToExecute5.Dispose();
                cmdToExecute6.Dispose();
                cmdToExecute7.Dispose();
                cmdToExecute8.Dispose();
                cmdToExecute9.Dispose();
                cmdToExecute10.Dispose();
                cmdToExecute11.Dispose();
                cmdToExecute12.Dispose();
                cmdToExecute13.Dispose();
                cmdToExecute14.Dispose();
                cmdToExecute15.Dispose();
                cmdToExecute16.Dispose();
                cmdToExecute17.Dispose();
                cmdToExecute18.Dispose();
                cmdToExecute19.Dispose();
                cmdToExecute20.Dispose();
                cmdToExecute21.Dispose();
                cmdToExecute22.Dispose();
                cmdToExecute23.Dispose();
                cmdToExecute24.Dispose();
                cmdToExecute25.Dispose();
                cmdToExecute26.Dispose();
            }
            return response;
        }
        /// <summary>
        /// Select all record from StudentRegistrationForm table with search parameters
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<StudentRegistrationForm> GetStudentRegistrationFormFieldBySearchList(StudentRegistrationFormSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<StudentRegistrationForm> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<StudentRegistrationForm>();
            SqlCommand cmdToExecute = new SqlCommand();
            SqlDataReader sqlDataReader = null;
            try
            {
                if (string.IsNullOrEmpty(searchRequest.ConnectionString))
                {
                    baseEntityCollection.Message.Add(new MessageDTO()
                    {
                        ErrorMessage = "Connection string is empty.",
                        MessageType = MessageTypeEnum.Error
                    });
                }
                else
                {
                    // Use base class' connection object
                    _mainConnection.ConnectionString = searchRequest.ConnectionString;
                    cmdToExecute.Connection = _mainConnection;
                    cmdToExecute.CommandText = "dbo.USP_ToolRegistrationFieldDetails_SelectAll";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iUniversityID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.UniversityID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iBranchDetailsID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.BranchDetailsID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iStandardNumber", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.StandardNumber));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsCentreCode", SqlDbType.NVarChar, 30, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.CenterCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    if (_mainConnectionIsCreatedLocal)
                    {
                        // Open connection.
                        _mainConnection.Open();
                    }
                    else
                    {
                        if (_mainConnectionProvider.IsTransactionPending)
                        {
                            cmdToExecute.Transaction = _mainConnectionProvider.CurrentTransaction;
                        }
                    }
                    sqlDataReader = cmdToExecute.ExecuteReader();
                    baseEntityCollection.CollectionResponse = new List<StudentRegistrationForm>();
                    while (sqlDataReader.Read())
                    {
                        StudentRegistrationForm item = new StudentRegistrationForm();
                        item.ToolRegistrationTemplateMstID = Convert.ToInt32(sqlDataReader["ToolRegistrationTemplateMstID"]);
                        item.ToolRegistrationFieldDetailsID = Convert.ToInt32(sqlDataReader["ID"]);
                        item.SubstitudeTitleName = sqlDataReader["SubstitudeTitleName"].ToString();
                        item.EnableDisableStatus = Convert.ToBoolean(sqlDataReader["EnableDisableStatus"]);
                        item.TemplateName = sqlDataReader["TemplateName"].ToString();

                        //item.Title = sqlDataReader["Title"].ToString();
                        //item.FirstName = sqlDataReader["FirstName"].ToString();
                        //item.MiddleName = sqlDataReader["MiddleName"].ToString();
                        //item.LastName = sqlDataReader["LastName"].ToString();
                        //item.ContactNumber = sqlDataReader["ContactNumber"].ToString();
                        //item.Gender = sqlDataReader["Gender"].ToString();
                        //item.DateOfBirth = sqlDataReader["DateOfBirth"].ToString();
                        //item.CenterCode = sqlDataReader["CenterCode"].ToString();
                        //item.IsActive = Convert.ToBoolean(sqlDataReader["IsActive"]);
                        //item.WebRegistrationStatus = sqlDataReader["WebRegistrationStatus"].ToString();
                        //item.WebAdminComments = sqlDataReader["WebAdminComments"].ToString();
                        //item.ApprovalDate = Convert.ToDateTime(sqlDataReader["ApprovalDate"]);
                        //item.AdminApprovedBy = Convert.ToInt32(sqlDataReader["AdminApprovedBy"]);
                        //item.StudentID = Convert.ToInt32(sqlDataReader["StudentID"]);
                        //item.StudentCode = sqlDataReader["StudentCode"].ToString();
                        //item.ApprovStudSecEmployeeID = Convert.ToInt32(sqlDataReader["ApprovStudSecEmployeeID"]);
                        //item.ApprovAcctSecEmployeeID = Convert.ToInt32(sqlDataReader["ApprovAcctSecEmployeeID"]);

                        baseEntityCollection.CollectionResponse.Add(item);
                        //baseEntityCollection.TotalRecords = Convert.ToInt32(sqlDataReader["TotalRecords"]);
                    }
                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_ToolRegistrationFieldDetails_SelectAll' reported the ErrorCode: " + _errorCode);
                    }
                }
            }
            catch (Exception ex)
            {
                baseEntityCollection.Message.Add(new MessageDTO()
                {
                    ErrorMessage = ex.InnerException.Message,
                    MessageType = MessageTypeEnum.Error
                });
                // _logException.Error(ex.Message);
            }
            finally
            {
                if (_mainConnectionIsCreatedLocal)
                {
                    // Close connection.
                    _mainConnection.Close();
                }
                cmdToExecute.Dispose();
            }
            return baseEntityCollection;
        }
        /// <summary>
        /// Update a specific record of StudentRegistrationForm
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>

        public IBaseEntityResponse<StudentRegistrationForm> SelectByEmailIDAndPassword(StudentRegistrationForm item)
        {
            IBaseEntityResponse<StudentRegistrationForm> response = new BaseEntityResponse<StudentRegistrationForm>();
            SqlCommand cmdToExecute = new SqlCommand();
            SqlDataReader sqlDataReader = null;
            try
            {
                if (string.IsNullOrEmpty(item.ConnectionString))
                {
                    response.Message.Add(new MessageDTO()
                    {
                        ErrorMessage = "Connection string is empty.",
                        MessageType = MessageTypeEnum.Error
                    });
                }
                else
                {
                    // Use base class' connection object
                    _mainConnection.ConnectionString = item.ConnectionString;
                    cmdToExecute.Connection = _mainConnection;
                    cmdToExecute.CommandText = "dbo.USP_StuRegistration_SelectByEmailAndPassword";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsEmail", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.StudentEmailID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsPassword", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.Password));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    if (_mainConnectionIsCreatedLocal)
                    {
                        // Open connection.
                        _mainConnection.Open();
                    }
                    else
                    {
                        if (_mainConnectionProvider.IsTransactionPending)
                        {
                            cmdToExecute.Transaction = _mainConnectionProvider.CurrentTransaction;
                        }
                    }
                    sqlDataReader = cmdToExecute.ExecuteReader();
                    //DataTable dt = new DataTable();
                    //dt.Load(sqlDataReader);
                    while (sqlDataReader.Read())
                    {
                        StudentRegistrationForm _item = new StudentRegistrationForm();
                        _item.StudentSelfRegistrationID = Convert.ToInt32(sqlDataReader["ID"]);
                        _item.StudentTitle = sqlDataReader["Title"].ToString();
                        _item.StudentEmailID = sqlDataReader["EmailID"].ToString();
                        _item.StudentFirstName = sqlDataReader["FirstName"].ToString();
                        _item.StudentMiddleName = sqlDataReader["MiddleName"].ToString();
                        _item.StudentLastName = sqlDataReader["LastName"].ToString();
                        _item.StudentMobileNumber = sqlDataReader["ContactNumber"].ToString();
                        _item.StudentGender = sqlDataReader["Gender"].ToString();
                        _item.StudentDateofBirth = sqlDataReader["DateOfBirth"].ToString();
                        _item.StandardNumber = Convert.ToInt32(sqlDataReader["StandardNumber"].ToString());
                        _item.BranchDetailID = Convert.ToInt32(sqlDataReader["BranchDetailID"].ToString());
                        _item.CenterCode = sqlDataReader["CenterCode"].ToString();
                        _item.UniversityID = Convert.ToInt32(sqlDataReader["UniversityID"].ToString());
                        _item.Student_QualifyingExamId = Convert.ToInt32(sqlDataReader["QualifingExamNameId"]);
                        _item.AdmissionPattern = Convert.ToInt32(sqlDataReader["AdmissionPattern"].ToString());
                        _item.Student_QualifyingExamName = sqlDataReader["QualifingExamName"].ToString();
                        // _item.Student_SelfRegistrationCode = sqlDataReader["SelfRegistrationCode"].ToString();
                        response.Entity = _item;
                    }
                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'Select Procedure' reported the ErrorCode: " + _errorCode);
                    }
                }
            }
            catch (Exception ex)
            {
                response.Message.Add(new MessageDTO()
                {
                    ErrorMessage = ex.InnerException.Message,
                    MessageType = MessageTypeEnum.Error
                });
                // _logException.Error(ex.Message);
            }
            finally
            {
                if (_mainConnectionIsCreatedLocal)
                {
                    // Close connection.
                    _mainConnection.Close();
                }
                cmdToExecute.Dispose();
            }
            return response;
        }

        public IBaseEntityCollectionResponse<StudentRegistrationForm> GetListQualifyingExamSelectList(StudentRegistrationFormSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<StudentRegistrationForm> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<StudentRegistrationForm>();
            SqlCommand cmdToExecute = new SqlCommand();
            SqlDataReader sqlDataReader = null;
            try
            {
                if (string.IsNullOrEmpty(searchRequest.ConnectionString))
                {
                    baseEntityCollection.Message.Add(new MessageDTO()
                    {
                        ErrorMessage = "Connection string is empty.",
                        MessageType = MessageTypeEnum.Error
                    });
                }
                else
                {
                    // Use base class' connection object
                    _mainConnection.ConnectionString = searchRequest.ConnectionString;
                    cmdToExecute.Connection = _mainConnection;
                    cmdToExecute.CommandText = "dbo.USP_StudentQualifyingExam_SelectList";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iBranchDetailsID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.BranchDetailsID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iStandardNumber", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.StandardNumber));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    if (_mainConnectionIsCreatedLocal)
                    {
                        // Open connection.
                        _mainConnection.Open();
                    }
                    else
                    {
                        if (_mainConnectionProvider.IsTransactionPending)
                        {
                            cmdToExecute.Transaction = _mainConnectionProvider.CurrentTransaction;
                        }
                    }
                    sqlDataReader = cmdToExecute.ExecuteReader();
                    baseEntityCollection.CollectionResponse = new List<StudentRegistrationForm>();
                    while (sqlDataReader.Read())
                    {
                        StudentRegistrationForm item = new StudentRegistrationForm();
                        item.Student_QualifyingExamId = Convert.ToInt32(sqlDataReader["QualifingExamNameId"]);
                        item.Student_QualifyingExamName = sqlDataReader["QualifingExamName"].ToString();
                        baseEntityCollection.CollectionResponse.Add(item);
                    }
                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_StudentQualifyingExam_SelectList' reported the ErrorCode: " + _errorCode);
                    }
                }
            }
            catch (Exception ex)
            {
                baseEntityCollection.Message.Add(new MessageDTO()
                {
                    ErrorMessage = ex.InnerException.Message,
                    MessageType = MessageTypeEnum.Error
                });
                // _logException.Error(ex.Message);
            }
            finally
            {
                if (_mainConnectionIsCreatedLocal)
                {
                    // Close connection.
                    _mainConnection.Close();
                }
                cmdToExecute.Dispose();
            }
            return baseEntityCollection;
        }

        public IBaseEntityCollectionResponse<PreviousWorkExperience> GetPreviousWorkExperience(PreviousWorkExperienceSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<PreviousWorkExperience> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<PreviousWorkExperience>();
            SqlCommand cmdToExecute = new SqlCommand();
            SqlDataReader sqlDataReader = null;
            try
            {
                if (string.IsNullOrEmpty(searchRequest.ConnectionString))
                {
                    baseEntityCollection.Message.Add(new MessageDTO()
                    {
                        ErrorMessage = "Connection string is empty.",
                        MessageType = MessageTypeEnum.Error
                    });
                }
                else
                {
                    // Use base class' connection object
                    _mainConnection.ConnectionString = searchRequest.ConnectionString;
                    cmdToExecute.Connection = _mainConnection;
                    cmdToExecute.CommandText = "dbo.USP_StudentPreviousWorkExperience_SelectAll";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iRegistrationID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.RegistrationID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    if (_mainConnectionIsCreatedLocal)
                    {
                        // Open connection.
                        _mainConnection.Open();
                    }
                    else
                    {
                        if (_mainConnectionProvider.IsTransactionPending)
                        {
                            cmdToExecute.Transaction = _mainConnectionProvider.CurrentTransaction;
                        }
                    }
                    sqlDataReader = cmdToExecute.ExecuteReader();
                    baseEntityCollection.CollectionResponse = new List<PreviousWorkExperience>();
                    while (sqlDataReader.Read())
                    {
                        PreviousWorkExperience item = new PreviousWorkExperience();
                        item.StudentPreviousExperienceID = sqlDataReader["ID"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["ID"]);
                        item.Position = sqlDataReader["Position"]  is DBNull ? string.Empty : Convert.ToString(sqlDataReader["Position"]);
                        item.NameOfOrganization = sqlDataReader["NameOfOrganization"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["NameOfOrganization"]);
                        item.FullPartTimeFlag = sqlDataReader["FullTimePartTimeFlag"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["FullTimePartTimeFlag"]);
                        item.FromDate = sqlDataReader["FromDate"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["FromDate"]);
                        item.UptoDate = sqlDataReader["UptoDate"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["UptoDate"]);
                        baseEntityCollection.CollectionResponse.Add(item);
                    }
                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_StudentQualifyingExam_SelectList' reported the ErrorCode: " + _errorCode);
                    }
                }
            }
            catch (Exception ex)
            {
                baseEntityCollection.Message.Add(new MessageDTO()
                {
                    ErrorMessage = ex.InnerException.Message,
                    MessageType = MessageTypeEnum.Error
                });
                // _logException.Error(ex.Message);
            }
            finally
            {
                if (_mainConnectionIsCreatedLocal)
                {
                    // Close connection.
                    _mainConnection.Close();
                }
                cmdToExecute.Dispose();
            }
            return baseEntityCollection;
        }
        

        /// <summary>
        /// Select a specific record of StudentRegistrationForm by ID
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>

        public IBaseEntityResponse<StudentRegistrationForm> SelectByID(StudentRegistrationForm item)
        {
            IBaseEntityResponse<StudentRegistrationForm> response = new BaseEntityResponse<StudentRegistrationForm>();
            SqlCommand cmdToExecute = new SqlCommand();
            SqlDataReader sqlDataReader = null;
            try
            {
                if (string.IsNullOrEmpty(item.ConnectionString))
                {
                    response.Message.Add(new MessageDTO()
                    {
                        ErrorMessage = "Connection string is empty.",
                        MessageType = MessageTypeEnum.Error
                    });
                }
                else
                {
                    // Use base class' connection object
                    _mainConnection.ConnectionString = item.ConnectionString;
                    cmdToExecute.Connection = _mainConnection;
                    cmdToExecute.CommandText = "dbo.USP_StudentRegistrationAcademicApproval_SelectOne";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iRegistrationID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.ID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    if (_mainConnectionIsCreatedLocal)
                    {
                        // Open connection.
                        _mainConnection.Open();
                    }
                    else
                    {
                        if (_mainConnectionProvider.IsTransactionPending)
                        {
                            cmdToExecute.Transaction = _mainConnectionProvider.CurrentTransaction;
                        }
                    }
                    sqlDataReader = cmdToExecute.ExecuteReader();
                    //DataTable dt = new DataTable();
                    //dt.Load(sqlDataReader);
                    while (sqlDataReader.Read())
                    {
                        StudentRegistrationForm _item = new StudentRegistrationForm();

                        _item.ID = Convert.ToInt32(sqlDataReader["StuRegistrationStudentMasterID"]);
                        _item.Student_DateofRegistration = sqlDataReader["DateOfRegistration"].ToString();
                        _item.StudentTitle = sqlDataReader["Title"].ToString();
                        _item.StudentFirstName = sqlDataReader["FirstName"].ToString();
                        _item.StudentMiddleName = sqlDataReader["MiddleName"].ToString();
                        _item.StudentLastName = sqlDataReader["LastName"].ToString();
                        _item.MotherFirstName = sqlDataReader["MotherName"].ToString();
                        _item.StudentMobileNumber = sqlDataReader["StudentMobileNumber"].ToString();
                        _item.FatherMobileNumber = sqlDataReader["ParentMobileNumber"].ToString();
                        _item.GuardianMobileNumber = sqlDataReader["GuardianMobileNumber"].ToString();
                        _item.FatherLandLineNumber = sqlDataReader["ParentLandlineNumber"].ToString();
                        _item.FatherEmailId = sqlDataReader["ParentEmailID"].ToString();
                        _item.GuardianEmailId = sqlDataReader["GuardianEmailID"].ToString();
                        _item.FatherEmailId = sqlDataReader["FatherEmailID"].ToString();
                        _item.MotherEmailId = sqlDataReader["MotherEmailID"].ToString();
                        _item.StudentEmailID = sqlDataReader["StudentEmailID"].ToString();

                        _item.StudentNameAsPerMarkSheet = sqlDataReader["NameAsPerLeaving"].ToString();
                        _item.StudentLastSchool_College = sqlDataReader["LastSchoolCollegeAttend"].ToString();
                        _item.StudentPreviousLC_TCNo = sqlDataReader["PreviousLeavingNumber"].ToString();
                        _item.StudentCasteAsPerTC_LC = sqlDataReader["CastAsPerLeaving"].ToString();
                        _item.StudentEnrollmentNo = sqlDataReader["CurrentEnrollmentNumber"].ToString();
                        _item.StudentRegionID = Convert.ToInt32(sqlDataReader["DomicileStateID"].ToString());
                        _item.Student_Domesile_CountryId = Convert.ToInt32(sqlDataReader["DomicileCountryID"].ToString());
                        _item.StudentRegionOther = sqlDataReader["DomicileStateOther"].ToString();
                        _item.StudentMigrationNumber = sqlDataReader["MigrationNumber"].ToString();
                        if (DBNull.Value.Equals(sqlDataReader["MigrationDatetime"].ToString()) == false)
                        {

                            _item.StudentMigrationDate = Convert.ToString(sqlDataReader["MigrationDatetime"].ToString());
                        }

                        _item.Student_DTE_AdmissionCategoryId = Convert.ToInt32(sqlDataReader["AdmissionCategoryID"].ToString());
                        _item.Student_DTE_AdmissionTypeId = Convert.ToInt32(sqlDataReader["AdmissionTypeID"].ToString());
                        // ,[IsHostelResidency]
                        _item.BranchDetailID = Convert.ToInt32(sqlDataReader["BranchDetailID"].ToString());
                        _item.StandardNumber = Convert.ToInt32(sqlDataReader["StandardNumber"].ToString());
                        _item.AdmissionPattern = Convert.ToInt32(sqlDataReader["AdmissionPatternID"].ToString());
                        // ,[StudentActiveFlag]
                        //,[AcademicYearID]
                        _item.CenterCode = sqlDataReader["CentreCode"].ToString();
                        _item.UniversityID = Convert.ToInt32(sqlDataReader["UniversityID"].ToString());
                        _item.StudentNRI_POI = sqlDataReader["NriPoi"].ToString();

                        _item.NameOfApplicant = sqlDataReader["NameOfApplicant"] is DBNull ? string.Empty: Convert.ToString(sqlDataReader["NameOfApplicant"]);
                        _item.TitleOfProject = sqlDataReader["TitleOfProject"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["TitleOfProject"]);
                        _item.ProjectSummary = sqlDataReader["ProjectSummary"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["ProjectSummary"]);
                        _item.FeesPaidBy = sqlDataReader["FeesPaidBy"] is DBNull ? new short() : Convert.ToInt16(sqlDataReader["FeesPaidBy"]);

                        //,[AllotAdmThrough]
                        //,[BankAccountNumber]
                        //,[BankBranchName]
                        //,[BankIFSCCode]
                        //,[BankMICRCode]
                        _item.Student_Scholarship_AadhaarCardNo = sqlDataReader["UniqueIdentificatinNumber"].ToString();

                        //,[IdentificationType]
                        if (DBNull.Value.Equals(sqlDataReader["StudentPhoto"]) == false)
                        {
                            _item.StudentPhoto = (byte[])(sqlDataReader["StudentPhoto"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["StudentSignature"]) == false)
                        {
                            _item.StudentSignature = (byte[])(sqlDataReader["StudentSignature"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["StudentThumb"]) == false)
                        {
                            _item.StudentThumb = (byte[])(sqlDataReader["StudentThumb"]);
                        }


                        if (DBNull.Value.Equals(sqlDataReader["StudentPhotoFileSize"]) == false)
                        {
                            _item.StudentPhotoFileSize = sqlDataReader["StudentPhotoFileSize"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["StudentSignatureFileSize"]) == false)
                        {
                            _item.StudentSignatureFileSize = sqlDataReader["StudentSignatureFileSize"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["StudentThumbFileSize"]) == false)
                        {
                            _item.StudentThumbFileSize = sqlDataReader["StudentThumbFileSize"].ToString();
                        }




                        _item.StudentPhotoType = sqlDataReader["StudentPhotoType"].ToString();
                        _item.StudentPhotoFilename = sqlDataReader["StudentPhotoFilename"].ToString();
                        _item.StudentPhotoFileWidth = sqlDataReader["StudentPhotoFileWidth"].ToString();
                        _item.StudentPhotoFileHeight = sqlDataReader["StudentPhotoFileHeight"].ToString();

                        _item.StudentSignatureType = sqlDataReader["StudentSignatureType"].ToString();
                        _item.StudentSignatureFilename = sqlDataReader["StudentSignatureFilename"].ToString();
                        _item.StudentSignatureFileWidth = sqlDataReader["StudentSignatureFileWidth"].ToString();
                        _item.StudentSignatureFileHeight = sqlDataReader["StudentSignatureFileHeight"].ToString();

                        _item.StudentThumbType = sqlDataReader["StudentThumbType"].ToString();
                        _item.StudentThumbFilename = sqlDataReader["StudentThumbFilename"].ToString();
                        _item.StudentThumbFileWidth = sqlDataReader["StudentThumbFileWidth"].ToString();
                        _item.StudentThumbFileHeight = sqlDataReader["StudentThumbFileHeight"].ToString();

                        _item.StudentDateofBirth = sqlDataReader["DateOfBirth"].ToString();
                        _item.StudentBirthPlace = sqlDataReader["BirthPlace"].ToString();
                        _item.StudentGender = sqlDataReader["Gender"].ToString();
                        _item.StudentMaritalStatus = sqlDataReader["MaritalStatus"].ToString();
                        _item.StudentNationalityID = Convert.ToInt32(sqlDataReader["NationalityId"].ToString());
                        _item.StudentReligionID = Convert.ToInt32(sqlDataReader["ReligionId"].ToString());
                        _item.StudentMotherTongueID = Convert.ToInt32(sqlDataReader["LanguageId"].ToString());
                        _item.StudentCategoryID = Convert.ToInt32(sqlDataReader["CategoryId"].ToString());
                        _item.StudentCasteID = Convert.ToInt32(sqlDataReader["CasteId"].ToString());

                        //,C.SubCasteId
                        _item.StudentBloodGroup = sqlDataReader["Bloodgroup"].ToString();
                        _item.StudentLandLineNumber = sqlDataReader["LandLineNumber"].ToString();
                        _item.StudentIdentificationMark = sqlDataReader["IdentificationMark"].ToString();
                        _item.StudentEmploymentSector = sqlDataReader["EmploymentSector"].ToString();
                        _item.StudentOccupation = sqlDataReader["Occupation"].ToString();
                        _item.StudentDesignation = sqlDataReader["Designation"].ToString();
                        _item.StudentOrganizationName = sqlDataReader["OrganizationName"].ToString();
                        _item.StudentOfficeContactNo = sqlDataReader["OfficeContactNumber"].ToString();
                        _item.StudentAnnualIncome = Convert.ToDouble(sqlDataReader["AnnualIncome"].ToString());
                        _item.PhysicallyHandicapped = sqlDataReader["IsHandicapped"].ToString();
                        _item.StudentOrgandonor = sqlDataReader["IsOrganDoner"].ToString();
                        _item.StudentPrevNameofStudent = sqlDataReader["PreviousNameOfStudentIfChange"].ToString();
                        _item.StudentReasonforNamechange = sqlDataReader["ReasonNameChange"].ToString();
                        _item.StudentEmploymentStatus = sqlDataReader["EmploymentStatus"].ToString();


                        _item.FatherHusbondType = sqlDataReader["F_EntityType"].ToString();
                        _item.FatherTitle = sqlDataReader["F_Title"].ToString();
                        _item.FatherFirstName = sqlDataReader["F_FirstName"].ToString();
                        _item.FatherMiddleName = sqlDataReader["F_MiddleName"].ToString();
                        _item.FatherLastName = sqlDataReader["F_LastName"].ToString();
                        _item.FatherEmailId = sqlDataReader["F_EmailID"].ToString();
                        _item.FatherMobileNumber = sqlDataReader["F_MobileNumber"].ToString();
                        _item.StudentDomicileStateofFather = sqlDataReader["F_DomicileState"].ToString();
                        _item.FatherLandLineNumber = sqlDataReader["F_LandlineNumber"].ToString();
                        _item.FatherEmploymentSector = sqlDataReader["F_EmploymentSector"].ToString();
                        _item.FatherOccupation = sqlDataReader["F_Occupation"].ToString();
                        _item.FatherDesignation = sqlDataReader["F_Designation"].ToString();
                        _item.FatherOrganizationName = sqlDataReader["F_OrganizationName"].ToString();
                        _item.FatherOfficeContactNo = sqlDataReader["F_OfficeContactNumber"].ToString();
                        _item.FatherAnnualIncome = Convert.ToDouble(sqlDataReader["F_AnnualIncome"].ToString());

                        // _item.FatherHusbondType = sqlDataReader["M_EntityType"].ToString();
                        _item.MotherTitle = sqlDataReader["M_Title"].ToString();
                        _item.MotherFirstName = sqlDataReader["M_FirstName"].ToString();
                        _item.MotherMiddleName = sqlDataReader["M_MiddleName"].ToString();
                        _item.MotherLastName = sqlDataReader["M_LastName"].ToString();
                        _item.MotherEmailId = sqlDataReader["M_EmailID"].ToString();
                        _item.MotherMobileNumber = sqlDataReader["M_MobileNumber"].ToString();
                        _item.StudentDomicileStateofMother = sqlDataReader["M_DomicileState"].ToString();
                        _item.MotherLandLineNumber = sqlDataReader["M_LandlineNumber"].ToString();
                        _item.MotherEmploymentSector = sqlDataReader["M_EmploymentSector"].ToString();
                        _item.MotherOccupation = sqlDataReader["M_Occupation"].ToString();
                        _item.MotherDesignation = sqlDataReader["M_Designation"].ToString();
                        _item.MotherOrganizationName = sqlDataReader["M_OrganizationName"].ToString();
                        _item.MotherOfficeContactNo = sqlDataReader["M_OfficeContactNumber"].ToString();
                        _item.MotherAnnualIncome = Convert.ToDouble(sqlDataReader["M_AnnualIncome"].ToString());

                        _item.GuardianTitle = sqlDataReader["G_Title"].ToString();
                        _item.GuardianFirstName = sqlDataReader["G_FirstName"].ToString();
                        _item.GuardianMiddleName = sqlDataReader["G_MiddleName"].ToString();
                        _item.GuardianLastName = sqlDataReader["G_LastName"].ToString();
                        _item.GuardianEmailId = sqlDataReader["G_EmailID"].ToString();
                        _item.GuardianMobileNumber = sqlDataReader["G_MobileNumber"].ToString();
                        //  _item.StudentDomicileStateofGuardian = sqlDataReader["G_DomicileState"].ToString();
                        _item.GuardianLandLineNumber = sqlDataReader["G_LandlineNumber"].ToString();
                        _item.GuardianEmploymentSector = sqlDataReader["G_EmploymentSector"].ToString();
                        _item.GuardianOccupation = sqlDataReader["G_Occupation"].ToString();
                        _item.GuardianDesignation = sqlDataReader["G_Designation"].ToString();
                        _item.GuardianOrganizationName = sqlDataReader["G_OrganizationName"].ToString();
                        _item.GuardianOfficeContactNo = sqlDataReader["G_OfficeContactNumber"].ToString();
                        _item.GuardianAnnualIncome = Convert.ToDouble(sqlDataReader["G_AnnualIncome"].ToString());

                        _item.Student_Ex_Serviceman_Ward_of_Ex_Serviceman = Convert.ToBoolean(sqlDataReader["SocialReservation1"].ToString());
                        _item.Student_Active_Serviceman_Ward_of_Active_Serviceman = Convert.ToBoolean(sqlDataReader["SocialReservation2"].ToString());
                        _item.Student_FreedomFighterWardOfFreedomFighter = Convert.ToBoolean(sqlDataReader["SocialReservation3"].ToString());
                        _item.Student_WardofPrimaryTeacher = Convert.ToBoolean(sqlDataReader["SocialReservation4"].ToString());
                        _item.Student_WardofSecondaryTeacher = Convert.ToBoolean(sqlDataReader["SocialReservation5"].ToString());
                        _item.Student_Deserted_Divorced_Widowed_Women = Convert.ToBoolean(sqlDataReader["SocialReservation6"].ToString());
                        _item.Student_MemberofProjectAffectedFamily = Convert.ToBoolean(sqlDataReader["SocialReservation7"].ToString());
                        _item.Student_MemberofEarthquakeAffectedFamily = Convert.ToBoolean(sqlDataReader["SocialReservation8"].ToString());
                        _item.Student_MemberofFloodFamineAffectedFamily = Convert.ToBoolean(sqlDataReader["SocialReservation9"].ToString());
                        _item.Student_ResidentofTribalArea = Convert.ToBoolean(sqlDataReader["SocialReservation10"].ToString());
                        _item.Student_KashmirMigrant = Convert.ToBoolean(sqlDataReader["SocialReservation11"].ToString());

                        _item.StudentIndicatetypeofCandidature = sqlDataReader["IndicateTypeOfCandidature"].ToString();
                        _item.StudentSchoolFromHSCExaminationpassed = sqlDataReader["WhereTheSchoolFromWhichSSC"].ToString();
                        _item.StudentEconomicallyBackwardClass = sqlDataReader["IsEconomicallyBackwordClass"].ToString();
                        _item.StudentsNameOfDistrictWhereParentDomiciled = sqlDataReader["NameOfTheDistrictWhereParent"].ToString();
                        _item.StudentsMKBCandidate = sqlDataReader["MKBCandidate"].ToString();

                        _item.Student_PermanentAddress_Address1 = sqlDataReader["PA_AddressLine1"].ToString();
                        _item.Student_PermanentAddress_Address2 = sqlDataReader["PA_AddressLine2"].ToString();
                        _item.Student_PermanentAddress_PloteNo = sqlDataReader["PA_PlotNumber"].ToString();
                        _item.Student_PermanentAddress_StreeNo = sqlDataReader["PA_Street"].ToString();

                        _item.Student_PermanentAddress_City_TahsilID = Convert.ToInt32(sqlDataReader["PA_LocationId"].ToString());
                        _item.Student_PermanentAddress_City_TahsilName = Convert.ToString(sqlDataReader["PA_LocationAddress"]);
                        _item.Student_PermanentAddress_City_TahsilOther = sqlDataReader["PA_LocationOther"].ToString();
                        _item.Student_PermanentAddress_DistrictID = Convert.ToInt32(sqlDataReader["PA_CityId"].ToString());
                        _item.Student_PermanentAddress_DistrictOther = sqlDataReader["PA_CityOther"].ToString();
                        _item.Student_PermanentAddress_State = Convert.ToInt32(sqlDataReader["PA_RegionId"].ToString());
                        _item.Student_PermanentAddress_StateOther = sqlDataReader["PA_RegionOther"].ToString();
                        _item.Student_PermanentAddress_CountryId = Convert.ToInt32(sqlDataReader["PA_CountryId"].ToString());
                        _item.Student_PermanentAddress_NearPoliceStation = sqlDataReader["PA_NearPoliceStation"].ToString();
                        _item.Student_PermanentAddress_Tahsil = sqlDataReader["PA_Tahsil"].ToString();
                        _item.Student_PermanentAddress_ZipCode = sqlDataReader["PA_ZipCode"].ToString();
                        _item.Student_PermanentAddress_City_Tahsil_Pattern = sqlDataReader["PA_CityTahsilPattern"].ToString();


                        _item.Student_CorrespondenceAddress_Address1 = sqlDataReader["CA_AddressLine1"].ToString();
                        _item.Student_CorrespondenceAddress_Address2 = sqlDataReader["CA_AddressLine2"].ToString();
                        _item.Student_CorrespondenceAddress_PloteNo = sqlDataReader["CA_PlotNumber"].ToString();
                        _item.Student_CorrespondenceAddress_StreeNo = sqlDataReader["CA_Street"].ToString();
                        _item.Student_CorrespondenceAddress_City_TahsilID = Convert.ToInt32(sqlDataReader["CA_LocationId"].ToString());
                        _item.Student_CorrespondenceAddress_City_TahsilName = Convert.ToString(sqlDataReader["CA_LocationAddress"]);
                        _item.Student_CorrespondenceAddress_City_TahsilOther = sqlDataReader["CA_LocationOther"].ToString();
                        _item.Student_CorrespondenceAddress_DistrictID = Convert.ToInt32(sqlDataReader["CA_CityId"].ToString());
                        _item.Student_CorrespondenceAddress_DistrictOther = sqlDataReader["CA_CityOther"].ToString();
                        _item.Student_CorrespondenceAddress_State = Convert.ToInt32(sqlDataReader["CA_RegionId"].ToString());
                        _item.Student_CorrespondenceAddress_StateOther = sqlDataReader["CA_RegionOther"].ToString();
                        _item.Student_CorrespondenceAddress_CountryId = Convert.ToInt32(sqlDataReader["CA_CountryId"].ToString());
                        _item.Student_CorrespondenceAddress_NearPoliceStation = sqlDataReader["CA_NearPoliceStation"].ToString();
                        _item.Student_CorrespondenceAddress_Tahsil = sqlDataReader["CA_Tahsil"].ToString();
                        _item.Student_CorrespondenceAddress_ZipCode = sqlDataReader["CA_ZipCode"].ToString();
                        _item.Student_CorrespondenceAddress_City_Tahsil_Pattern = sqlDataReader["CA_CityTahsilPattern"].ToString();
                        _item.Student_QualifyingExamId = Convert.ToInt32(sqlDataReader["QualifyingExamMasterId"].ToString());
                        _item.Student_QualifyingRollNo = sqlDataReader["RollNumber"].ToString();
                        _item.Student_QualifyingExamTotalMarksPointsObtained = Convert.ToInt32(sqlDataReader["Q_MarksObtained"].ToString());
                        _item.Student_QualifyingExamOutOffMark = Convert.ToInt32(sqlDataReader["Q_MarksOutOf"].ToString());
                        _item.Student_QualifyingExamRank = sqlDataReader["Rank"].ToString();

                        _item.Student_Qualification_General_MediumOfInstitution = Convert.ToInt32(sqlDataReader["G_MediumId"].ToString());
                        _item.Student_Qualification_General_MonthOfPassing = Convert.ToInt32(sqlDataReader["G_MonthPassing"].ToString());
                        _item.Student_Qualification_General_YearOfPassing = Convert.ToInt32(sqlDataReader["G_YearPassing"].ToString());
                        _item.Student_Qualification_General_SingleAttempt = sqlDataReader["G_IsSingleAttempt"].ToString();
                        _item.Student_Qualification_General_ObtainedMark = Convert.ToInt32(sqlDataReader["G_MarksObtained"].ToString());
                        _item.Student_Qualification_General_OutOfMark = Convert.ToInt32(sqlDataReader["G_MarksOutOf"].ToString());
                        _item.Student_Qualification_General_Percent = Convert.ToInt32(sqlDataReader["G_MarksObtainedPercentage"].ToString());
                        _item.Student_Qualification_General_NameofInstitution = sqlDataReader["G_InstitutionName"].ToString();
                        _item.Student_Qualification_General_Region_Division_Board = sqlDataReader["G_RegionDivisionBoard"].ToString();

                        _item.Student_Qualification_SSC_MediumOfInstitution = Convert.ToInt32(sqlDataReader["S_MediumId"].ToString());
                        _item.Student_Qualification_SSC_MonthOfPassing = Convert.ToInt32(sqlDataReader["S_MonthPassing"].ToString());
                        _item.Student_Qualification_SSC_YearOfPassing = Convert.ToInt32(sqlDataReader["S_YearPassing"].ToString());
                        _item.Student_Qualification_SSC_SingleAttempt = sqlDataReader["S_IsSingleAttempt"].ToString();
                        _item.Student_Qualification_SSC_ObtainedMark = Convert.ToInt32(sqlDataReader["S_MarksObtained"].ToString());
                        _item.Student_Qualification_SSC_OutOfMark = Convert.ToInt32(sqlDataReader["S_MarksOutOf"].ToString());

                        if (DBNull.Value.Equals(sqlDataReader["S_MarksObtainedPercentage"]) == false)
                        {
                            _item.Student_Qualification_SSC_Percent = Convert.ToInt32(sqlDataReader["S_MarksObtainedPercentage"].ToString());
                        }
                        _item.Student_Qualification_SSC_NameofInstitution = sqlDataReader["S_InstitutionName"].ToString();
                        _item.Student_Qualification_SSC_Region_Division_Board = sqlDataReader["S_RegionDivisionBoard"].ToString();

                        _item.Student_Qualification_HSC_MediumOfInstitution = Convert.ToInt32(sqlDataReader["H_MediumId"].ToString());
                        _item.Student_Qualification_HSC_MonthOfPassing = Convert.ToInt32(sqlDataReader["H_MonthPassing"].ToString());
                        _item.Student_Qualification_HSC_YearOfPassing = Convert.ToInt32(sqlDataReader["H_YearPassing"].ToString());
                        _item.Student_Qualification_HSC_SingleAttempt = sqlDataReader["H_IsSingleAttempt"].ToString();
                        _item.Student_Qualification_HSC_ObtainedMark = Convert.ToInt32(sqlDataReader["H_MarksObtained"].ToString());
                        _item.Student_Qualification_HSC_OutOfMark = Convert.ToInt32(sqlDataReader["H_MarksOutOf"].ToString());

                        if (DBNull.Value.Equals(sqlDataReader["H_MarksObtainedPercentage"]) == false)
                        {
                            _item.Student_Qualification_HSC_Percent = Convert.ToInt32(sqlDataReader["H_MarksObtainedPercentage"].ToString());
                        }
                        _item.Student_Qualification_HSC_NameofInstitution = sqlDataReader["H_InstitutionName"].ToString();
                        _item.Student_Qualification_HSC_Region_Division_Board = sqlDataReader["H_RegionDivisionBoard"].ToString();
                        _item.Student_Qualification_HSC_StreamID = Convert.ToInt32(sqlDataReader["H_StreamId"].ToString());
                        _item.Student_Qualification_HSC_StreamOther = sqlDataReader["H_OtherStream"].ToString();
                        _item.Student_Qualification_HSC_Class = sqlDataReader["H_Grade"].ToString();

                        _item.Student_Qualification_HSC_PCM_PVM_ObtainedMark = Convert.ToInt32(sqlDataReader["H_GroupAObtainedMarks"].ToString());
                        _item.Student_Qualification_HSC_PCM_PVM_OutOfMark = Convert.ToInt32(sqlDataReader["H_GroupAOutOfMarks"].ToString());
                        _item.Student_Qualification_HSC_PCB_ObtainedMark = Convert.ToInt32(sqlDataReader["H_GroupBObtainedMarks"].ToString());
                        _item.Student_Qualification_HSC_PCB_OutOfMark = Convert.ToInt32(sqlDataReader["H_GroupBOutOfMarks"].ToString());

                        _item.Student_Qualification_Diploma_ITI_Details_MediumOfInstitution = Convert.ToInt32(sqlDataReader["DP_MediumId"].ToString());
                        _item.Student_Qualification_Diploma_ITI_Details_BranchName = sqlDataReader["DP_BranchName"].ToString();
                        _item.Student_Qualification_Diploma_ITI_Details_ExamPattern = sqlDataReader["DP_ExamPattern"].ToString();
                        _item.Student_Qualification_Diploma_ITI_Details_MonthOfPassing = Convert.ToInt32(sqlDataReader["DP_MonthPassing"].ToString());
                        _item.Student_Qualification_Diploma_ITI_Details_YearOfPassing = Convert.ToInt32(sqlDataReader["DP_YearPassing"].ToString());
                        _item.Student_Qualification_Diploma_ITI_Details_SingleAttempt = sqlDataReader["DP_IsSingleAttempt"].ToString();
                        _item.Student_Qualification_Diploma_ITI_Details_ObtainedMark = Convert.ToInt32(sqlDataReader["DP_MarksObtained"].ToString());
                        _item.Student_Qualification_Diploma_ITI_Details_OutOfMark = Convert.ToInt32(sqlDataReader["DP_MarksOutOf"].ToString());

                        if (DBNull.Value.Equals(sqlDataReader["DP_MarksObtainedPercentage"]) == false)
                        {
                            _item.Student_Qualification_Diploma_ITI_Details_Percent = Convert.ToInt32(sqlDataReader["DP_MarksObtainedPercentage"].ToString());
                        }
                        _item.Student_Qualification_Diploma_ITI_Details_NameofInstitution = sqlDataReader["DP_InstitutionName"].ToString();
                        _item.Student_Qualification_Diploma_ITI_Details_Board = sqlDataReader["DP_RegionDivisionBoard"].ToString();
                        _item.Student_Qualification_Diploma_ITI_Details_State = Convert.ToInt32(sqlDataReader["DP_RegionID"].ToString());
                        _item.Student_Qualification_Diploma_ITI_Details_CountryId = Convert.ToInt32(sqlDataReader["DP_CountryID"].ToString());
                        _item.Student_Qualification_Diploma_ITI_Details_StateOther = sqlDataReader["DP_OtherRegion"].ToString();
                        _item.Student_Qualification_Diploma_ITI_Details_BoardEnrollmentNumber = sqlDataReader["DP_EnrollmentNo"].ToString();
                        _item.Student_Qualification_Diploma_ITI_Details_Class = sqlDataReader["DP_Grade"].ToString();

                        _item.Student_Qualification_DegreeDetails_MediumOfInstitution = Convert.ToInt32(sqlDataReader["UG_MediumId"].ToString());
                        _item.Student_Qualification_DegreeDetails_BranchName = sqlDataReader["UG_BranchName"].ToString();
                        _item.Student_Qualification_DegreeDetails_ExamPattern = sqlDataReader["UG_ExamPattern"].ToString();
                        _item.Student_Qualification_DegreeDetails_MonthOfPassing = Convert.ToInt32(sqlDataReader["UG_MonthPassing"].ToString());
                        _item.Student_Qualification_DegreeDetails_YearOfPassing = Convert.ToInt32(sqlDataReader["UG_YearPassing"].ToString());
                        _item.Student_Qualification_DegreeDetails_SingleAttempt = sqlDataReader["UG_IsSingleAttempt"].ToString();
                        _item.Student_Qualification_DegreeDetails_ObtainedMark = Convert.ToInt32(sqlDataReader["UG_MarksObtained"].ToString());
                        _item.Student_Qualification_DegreeDetails_OutOfMark = Convert.ToInt32(sqlDataReader["UG_MarksOutOf"].ToString());
                        if (DBNull.Value.Equals(sqlDataReader["UG_MarksObtainedPercentage"]) == false)
                        {
                            _item.Student_Qualification_DegreeDetails_Percent = Convert.ToInt32(sqlDataReader["UG_MarksObtainedPercentage"].ToString());
                        }
                        _item.Student_Qualification_DegreeDetails_NameofInstitution = sqlDataReader["UG_InstitutionName"].ToString();
                        _item.Student_Qualification_DegreeDetails_UniversityName = sqlDataReader["UG_RegionDivisionBoard"].ToString();
                        _item.Student_Qualification_DegreeDetails_State = Convert.ToInt32(sqlDataReader["UG_RegionID"].ToString());
                        _item.Student_Qualification_DegreeDetails_CountryId = Convert.ToInt32(sqlDataReader["UG_CountryID"].ToString());
                        _item.Student_Qualification_DegreeDetails_StateOther = sqlDataReader["UG_OtherRegion"].ToString();
                        _item.Student_Qualification_DegreeDetails_Degree = sqlDataReader["UG_DegreeName"].ToString();
                        _item.Student_Qualification_DegreeDetails_BoardEnrollmentNumber = sqlDataReader["UG_EnrollmentNo"].ToString();
                        _item.Student_Qualification_DegreeDetails_Class = sqlDataReader["UG_Grade"].ToString();

                        _item.Student_Qualification_PostGraduationDetails_MediumOfInstitution = Convert.ToInt32(sqlDataReader["PG_MediumId"].ToString());
                        _item.Student_Qualification_PostGraduationDetails_BranchName = sqlDataReader["PG_BranchName"].ToString();
                        _item.Student_Qualification_PostGraduationDetails_ExamPattern = sqlDataReader["PG_ExamPattern"].ToString();
                        _item.Student_Qualification_PostGraduationDetails_MonthOfPassing = Convert.ToInt32(sqlDataReader["PG_MonthPassing"].ToString());
                        _item.Student_Qualification_PostGraduationDetails_YearOfPassing = Convert.ToInt32(sqlDataReader["PG_YearPassing"].ToString());
                        _item.Student_Qualification_PostGraduationDetails_SingleAttempt = sqlDataReader["PG_IsSingleAttempt"].ToString();
                        _item.Student_Qualification_PostGraduationDetails_ObtainedMark = Convert.ToInt32(sqlDataReader["PG_MarksObtained"].ToString());
                        _item.Student_Qualification_PostGraduationDetails_OutOfMark = Convert.ToInt32(sqlDataReader["PG_MarksOutOf"].ToString());
                        if (DBNull.Value.Equals(sqlDataReader["PG_MarksObtainedPercentage"]) == false)
                        {
                            _item.Student_Qualification_PostGraduationDetails_Percent = Convert.ToInt32(sqlDataReader["PG_MarksObtainedPercentage"].ToString());
                        }
                        _item.Student_Qualification_PostGraduationDetails_NameofInstitution = sqlDataReader["PG_InstitutionName"].ToString();
                        _item.Student_Qualification_PostGraduationDetails_UniversityName = sqlDataReader["PG_RegionDivisionBoard"].ToString();
                        _item.Student_Qualification_PostGraduationDetails_State = Convert.ToInt32(sqlDataReader["PG_RegionID"].ToString());
                        _item.Student_Qualification_PostGraduationDetails_CountryId = Convert.ToInt32(sqlDataReader["PG_CountryID"].ToString());
                        _item.Student_Qualification_PostGraduationDetails_StateOther = sqlDataReader["PG_OtherRegion"].ToString();
                        _item.Student_Qualification_PostGraduationDetails_PostGraduation = sqlDataReader["PG_DegreeName"].ToString();
                        _item.Student_Qualification_PostGraduationDetails_BoardEnrollmentNumber = sqlDataReader["PG_EnrollmentNo"].ToString();
                        _item.Student_Qualification_PostGraduationDetails_Class = sqlDataReader["PG_Grade"].ToString();
                        _item.Student_DTE_DTEUserID = sqlDataReader["UserId"].ToString();
                        _item.Student_DTE_DTEPassword = sqlDataReader["UserPassword"].ToString();
                        _item.Student_DTE_DTESrNo = sqlDataReader["SerialNumber"].ToString();
                        _item.Student_DTE_DTEMeritNo = sqlDataReader["MeritNumber"].ToString();
                        _item.Student_DTE_AdmissionTypeId = Convert.ToInt32(sqlDataReader["AdmissionType"].ToString());
                        _item.Student_DTE_AdmissionRound = Convert.ToInt32(sqlDataReader["AdmissionRound"].ToString());
                        _item.Student_DTE_AdmissionCategoryId = Convert.ToInt32(sqlDataReader["AdmissionCategoryID"].ToString());
                        _item.Student_DTE_DTESeatNo = sqlDataReader["SeatType"].ToString();
                        _item.Student_DTE_QualifyingExamName = sqlDataReader["QualifyingExaminationName"].ToString();
                        _item.Student_DTE_QualifyingExamMarks = Convert.ToInt32(sqlDataReader["QualifyingExamMarksObtained"].ToString());

                        //For Document
                        _item.Student_AdmissionDocuments_JETMarkSheet = Convert.ToBoolean(sqlDataReader["SubmitedDocument1"].ToString());
                        _item.Student_AdmissionDocuments_AllotmentLetter = Convert.ToBoolean(sqlDataReader["SubmitedDocument2"].ToString());
                        _item.Student_AdmissionDocuments_TenthMarkSheet = Convert.ToBoolean(sqlDataReader["SubmitedDocument3"].ToString());
                        _item.Student_AdmissionDocuments_TwelvethMarkSheet = Convert.ToBoolean(sqlDataReader["SubmitedDocument4"].ToString());
                        _item.Student_AdmissionDocuments_AllDiplomaMarksheet = Convert.ToBoolean(sqlDataReader["SubmitedDocument5"].ToString());
                        _item.Student_AdmissionDocuments_LeavingCertificate = Convert.ToBoolean(sqlDataReader["SubmitedDocument6"].ToString());
                        _item.Student_AdmissionDocuments_Domicile_BirthCertificate = Convert.ToBoolean(sqlDataReader["SubmitedDocument7"].ToString());
                        _item.Student_AdmissionDocuments_NationalityCertificate = Convert.ToBoolean(sqlDataReader["SubmitedDocument8"].ToString());
                        _item.Student_AdmissionDocuments_CasteCertificate = Convert.ToBoolean(sqlDataReader["SubmitedDocument9"].ToString());
                        _item.Student_AdmissionDocuments_CasteValidityCertificate = Convert.ToBoolean(sqlDataReader["SubmitedDocument10"].ToString());
                        _item.Student_AdmissionDocuments_NonCreamylayerCertificate = Convert.ToBoolean(sqlDataReader["SubmitedDocument11"].ToString());
                        _item.Student_AdmissionDocuments_EquivalenceCertificate = Convert.ToBoolean(sqlDataReader["SubmitedDocument12"].ToString());
                        _item.Student_AdmissionDocuments_MigrationCertificate = Convert.ToBoolean(sqlDataReader["SubmitedDocument13"].ToString());
                        _item.Student_AdmissionDocuments_GapCertificate = Convert.ToBoolean(sqlDataReader["SubmitedDocument14"].ToString());
                        _item.Student_AdmissionDocuments_AntiRaggingAffidavit = Convert.ToBoolean(sqlDataReader["SubmitedDocument15"].ToString());
                        _item.Student_AdmissionDocuments_Proforma_Fand_F1_On_DoctorsLetter_Head = Convert.ToBoolean(sqlDataReader["SubmitedDocument16"].ToString());
                        _item.Student_AdmissionDocuments_Proforma_I = Convert.ToBoolean(sqlDataReader["SubmitedDocument17"].ToString());
                        _item.Student_AdmissionDocuments_ProformaG1 = Convert.ToBoolean(sqlDataReader["SubmitedDocument18"].ToString());
                        _item.Student_AdmissionDocuments_ProformaG2 = Convert.ToBoolean(sqlDataReader["SubmitedDocument19"].ToString());
                        _item.Student_AdmissionDocuments_Proforma_C_D_E = Convert.ToBoolean(sqlDataReader["SubmitedDocument20"].ToString());
                        _item.Student_AdmissionDocuments_FathersIncomeCertificate = Convert.ToBoolean(sqlDataReader["SubmitedDocument21"].ToString());
                        _item.Student_AdmissionDocuments_AadharCardXerox = Convert.ToBoolean(sqlDataReader["SubmitedDocument22"].ToString());
                        _item.Student_AdmissionDocuments_B_WPhoto_I_card_size = Convert.ToBoolean(sqlDataReader["SubmitedDocument23"].ToString());
                        _item.Student_AdmissionDocuments_Colour_photo = Convert.ToBoolean(sqlDataReader["SubmitedDocument24"].ToString());


                        //For PG Students
                        _item.Student_AdmissionDocuments_PGStudents_DegreeMarksheet = Convert.ToBoolean(sqlDataReader["SubmitedDocument25"].ToString());
                        _item.Student_AdmissionDocuments_PGStudents_DegreeCertificate = Convert.ToBoolean(sqlDataReader["SubmitedDocument26"].ToString());
                        _item.Student_AdmissionDocuments_PGStudents_GateScoreCard = Convert.ToBoolean(sqlDataReader["SubmitedDocument27"].ToString());
                        _item.Student_AdmissionDocuments_PGStudents_SponsorshipLetterforSponsoredCandidate = Convert.ToBoolean(sqlDataReader["SubmitedDocument28"].ToString());

                        _item.SectionDetailsID = Convert.ToInt32(sqlDataReader["BranchDetailIDOFBranchID"].ToString());
                        if (DBNull.Value.Equals(sqlDataReader["AuthorisationComments"]) == false)
                        {
                            _item.ReasonIfRejected = sqlDataReader["AuthorisationComments"].ToString();
                        }
                        _item.StudentSelfRegistrationID = Convert.ToInt32(sqlDataReader["StudentSelfRegistrationID"]);
                        response.Entity = _item;
                    }
                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'Select Procedure' reported the ErrorCode: " + _errorCode);
                    }
                }
            }
            catch (Exception ex)
            {
                response.Message.Add(new MessageDTO()
                {
                    ErrorMessage = ex.InnerException.Message,
                    MessageType = MessageTypeEnum.Error
                });
                // _logException.Error(ex.Message);
            }
            finally
            {
                if (_mainConnectionIsCreatedLocal)
                {
                    // Close connection.
                    _mainConnection.Close();
                }
                cmdToExecute.Dispose();
            }
            return response;
        }
        #endregion
    }
}
