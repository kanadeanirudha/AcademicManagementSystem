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
    public class StudentRegistrationAcademicApprovalDataProvider : DBInteractionBase, IStudentRegistrationAcademicApprovalDataProvider
    {
        #region Variable Declaration
        private readonly string _connectionString;
        private readonly ILogger _logException;
        #endregion
        #region Constructor
        /// <summary>
        /// Constructor to initialized data member and member functions
        /// </summary>
        public StudentRegistrationAcademicApprovalDataProvider()
        {
        }
        /// <summary>
        /// Constructor to initialized data member and member functions
        /// </summary>
        /// <param name="logException"></param>
        public StudentRegistrationAcademicApprovalDataProvider(ILogger logException)
        {
            _connectionString = ""; //ConfigurationManager.ConnectionStrings["AMSEntities"].ToString();
            _logException = logException; // This should fix later
        }
        #endregion
        #region Method Implementation
        /// <summary>
        /// Select all record from StudentRegistrationAcademicApproval table with search parameters
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<StudentRegistrationAcademicApproval> GetStudentRegistrationAcademicApprovalBySearch(StudentRegistrationAcademicApprovalSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<StudentRegistrationAcademicApproval> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<StudentRegistrationAcademicApproval>();
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
                    cmdToExecute.CommandText = "dbo.USP_TaskNotificationDetailsForAcademicApproval_SelectByPersonID";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iPersonID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.PersonID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sTaskCode", SqlDbType.VarChar, 20, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.TaskCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sSortBy", SqlDbType.VarChar, 200, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.SortBy));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iStartRow", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.StartRow));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iEndRow", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.EndRow));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsSearchBy", SqlDbType.NVarChar, 200, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.SearchBy));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sSortDirection", SqlDbType.VarChar, 10, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.SortDirection));
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
                    baseEntityCollection.CollectionResponse = new List<StudentRegistrationAcademicApproval>();
                    while (sqlDataReader.Read())
                    {
                        StudentRegistrationAcademicApproval item = new StudentRegistrationAcademicApproval();
                        //item.ID = Convert.ToInt32(sqlDataReader["ID"]);
                        //item.RegistrationID = Convert.ToInt32(sqlDataReader["RegistrationID"]);
                        //item.StudentTitle = sqlDataReader["Title"].ToString();
                        //item.StudentFirstName = sqlDataReader["FirstName"].ToString();
                        //item.StudentMiddleName = sqlDataReader["MiddleName"].ToString();
                        //item.StudentLastName = sqlDataReader["LastName"].ToString();
                        //item.StudentDateofRegistration = Convert.ToString(sqlDataReader["DateOfRegistration"]);
                        //item.StudentStatus = Convert.ToString(sqlDataReader["ApproveRejectStatus"]);

                        if (DBNull.Value.Equals(sqlDataReader["Description"]) == false)
                        {
                            item.StudentFirstName = sqlDataReader["Description"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["MenuCodeLink"]) == false)
                        {
                            item.MenuCodeLink = sqlDataReader["MenuCodeLink"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ApprovalStatus"]) == false)
                        {
                            item.ApprovalStatus = Convert.ToInt32(sqlDataReader["ApprovalStatus"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["TaskNotificationDetailsID"]) == false)
                        {
                            item.TaskNotificationDetailsID = Convert.ToInt32(sqlDataReader["TaskNotificationDetailsID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["TaskNotificationMasterID"]) == false)
                        {
                            item.TaskNotificationMasterID = Convert.ToInt32(sqlDataReader["TaskNotificationMasterID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["GeneralTaskReportingDetailsID"]) == false)
                        {
                            item.GeneralTaskReportingDetailsID = Convert.ToInt32(sqlDataReader["GeneralTaskReportingDetailsID"]);
                        }
                        //if (DBNull.Value.Equals(sqlDataReader["EntitytableName"]) == false)
                        //{
                        //    item.EntitytableName = sqlDataReader["EntitytableName"].ToString();
                        //}
                        //if (DBNull.Value.Equals(sqlDataReader["EntityPKName"]) == false)
                        //{
                        //    item.EntityPKName = sqlDataReader["EntityPKName"].ToString();
                        //}
                        //if (DBNull.Value.Equals(sqlDataReader["EntityPKValue"]) == false)
                        //{
                        //    item.EntityPKValue = Convert.ToInt32(sqlDataReader["EntityPKValue"]);
                        //}
                        if (DBNull.Value.Equals(sqlDataReader["StageSequenceNumber"]) == false)
                        {
                            item.StageSequenceNumber = Convert.ToInt32(sqlDataReader["StageSequenceNumber"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["IsLastStage"]) == false)
                        {
                            item.IsLastRecordFlag = Convert.ToBoolean(sqlDataReader["IsLastStage"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ApplicationDate"]) == false)
                        {
                            item.ApplicationDate = sqlDataReader["ApplicationDate"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["IsEngaged"]) == false)
                        {
                            item.IsEngaged = Convert.ToBoolean(sqlDataReader["IsEngaged"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["EnagedByUserID"]) == false)
                        {
                            item.EngagedByUserID = Convert.ToInt32(sqlDataReader["EnagedByUserID"]);
                        }
                        //if (DBNull.Value.Equals(sqlDataReader["CentreCode"]) == false)
                        //{
                        //    item.CentreCode = Convert.ToString(sqlDataReader["CentreCode"]);
                        //}

                        baseEntityCollection.CollectionResponse.Add(item);
                        baseEntityCollection.TotalRecords = Convert.ToInt32(sqlDataReader["TotalRecords"]);
                    }
                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_StuRegistrationAcademicApproval_SelectAll' reported the ErrorCode: " + _errorCode);
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
        /// Select a record from table by ID
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<StudentRegistrationAcademicApproval> GetStudentRegistrationAcademicApprovalByID(StudentRegistrationAcademicApproval item)
        {
            IBaseEntityResponse<StudentRegistrationAcademicApproval> response = new BaseEntityResponse<StudentRegistrationAcademicApproval>();
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
                    cmdToExecute.Parameters.Add(new SqlParameter("@iRegistrationID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.RegistrationID));
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
                    while (sqlDataReader.Read())
                    {
                        StudentRegistrationAcademicApproval _item = new StudentRegistrationAcademicApproval();
                        _item.RegistrationID = Convert.ToInt32(sqlDataReader["StuRegistrationStudentMasterID"]);
                        _item.StudentDateofRegistration = sqlDataReader["DateOfRegistration"].ToString();
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
                        // ,[AdmissionPatternID]
                        // ,[StudentActiveFlag]
                        //,[AcademicYearID]
                        _item.CenterCode = sqlDataReader["CentreCode"].ToString();
                        _item.UniversityID = Convert.ToInt32(sqlDataReader["UniversityID"].ToString());
                        _item.StudentNRI_POI = sqlDataReader["NriPoi"].ToString();

                        _item.NameOfApplicant = sqlDataReader["NameOfApplicant"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["NameOfApplicant"]);
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

                        _item.Student_BranchDetailIDOFBranchID = Convert.ToInt32(sqlDataReader["BranchDetailIDOFBranchID"].ToString());

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
        /// <summary>
        /// Create new record of the table
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<StudentRegistrationAcademicApproval> InsertStudentRegistrationAcademicApproval(StudentRegistrationAcademicApproval item)
        {
            IBaseEntityResponse<StudentRegistrationAcademicApproval> response = new BaseEntityResponse<StudentRegistrationAcademicApproval>();
            SqlCommand cmdToExecute = new SqlCommand();
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

                    #region for specific Info
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
                    transaction = _mainConnection.BeginTransaction("SampleTransaction");

                    //if (item.Student_Domesile_CountryId != 0 && item.StudentRegionOther != null && item.StudentRegionOther != "")
                    //{
                    //    cmdToExecute.CommandText = "dbo.USP_StudentRegistrationSpecificInformationForOther_Insert_Update";
                    //    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    //    cmdToExecute.Parameters.Add(new SqlParameter("@iRegistrationID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.RegistrationID));
                    //    cmdToExecute.Parameters.Add(new SqlParameter("@iCountryID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_Domesile_CountryId));
                    //    cmdToExecute.Parameters.Add(new SqlParameter("@nsRegionName", SqlDbType.NVarChar, 0, ParameterDirection.Input, false, 50, 0, "", DataRowVersion.Proposed, item.StudentRegionOther));
                    //    cmdToExecute.Parameters.Add(new SqlParameter("@iCreatedBy", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.CreatedBy));
                    //    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    //    cmdToExecute.Transaction = transaction;
                    //    _rowsAffected = cmdToExecute.ExecuteNonQuery();
                    //}

                    #endregion for specific Info

                    //#region for PermanentAddress USP_StudentRegistrationPermanentAddressForOtherState_Insert_Update

                    //if (item.Student_PermanentAddress_CountryId != null && item.Student_PermanentAddress_CountryId != 0)
                    //{
                    //    cmdToExecute.Parameters.Clear();
                    //    cmdToExecute.CommandText = "dbo.USP_StudentRegistrationPermanentAddressForOtherState_Insert_Update";
                    //    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    //    cmdToExecute.Parameters.Add(new SqlParameter("@iRegistrationID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.RegistrationID));
                    //    cmdToExecute.Parameters.Add(new SqlParameter("@iCountryID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_PermanentAddress_CountryId));
                    //    cmdToExecute.Parameters.Add(new SqlParameter("@cAddressType", SqlDbType.Char, 0, ParameterDirection.Input, false, 50, 0, "", DataRowVersion.Proposed, "P"));
                    //    if (item.Student_PermanentAddress_State != null && item.Student_PermanentAddress_State != 0)
                    //    {
                    //        cmdToExecute.Parameters.Add(new SqlParameter("@iRegionID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_PermanentAddress_State));
                    //        cmdToExecute.Parameters.Add(new SqlParameter("@nsRegionName", SqlDbType.NVarChar, 0, ParameterDirection.Input, false, 50, 0, "", DataRowVersion.Proposed, ""));
                    //    }
                    //    else
                    //    {
                    //        cmdToExecute.Parameters.Add(new SqlParameter("@iRegionID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, 0));
                    //        cmdToExecute.Parameters.Add(new SqlParameter("@nsRegionName", SqlDbType.NVarChar, 0, ParameterDirection.Input, false, 50, 0, "", DataRowVersion.Proposed, (item.Student_PermanentAddress_StateOther != null) ? item.Student_PermanentAddress_StateOther : string.Empty));

                    //    }
                    //    if (item.Student_PermanentAddress_DistrictID != null && item.Student_PermanentAddress_DistrictID != 0)
                    //    {
                    //        cmdToExecute.Parameters.Add(new SqlParameter("@iDistictID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_PermanentAddress_DistrictID));
                    //        cmdToExecute.Parameters.Add(new SqlParameter("@nsDistrict", SqlDbType.NVarChar, 0, ParameterDirection.Input, false, 50, 0, "", DataRowVersion.Proposed, ""));
                    //    }
                    //    else
                    //    {
                    //        cmdToExecute.Parameters.Add(new SqlParameter("@iDistictID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, 0));
                    //        cmdToExecute.Parameters.Add(new SqlParameter("@nsDistrict", SqlDbType.NVarChar, 0, ParameterDirection.Input, false, 50, 0, "", DataRowVersion.Proposed, (item.Student_PermanentAddress_DistrictOther != null) ? item.Student_PermanentAddress_DistrictOther : string.Empty));
                    //    }
                    //    if (item.Student_PermanentAddress_City_TahsilID != null && item.Student_PermanentAddress_City_TahsilID != 0)
                    //    {
                    //        cmdToExecute.Parameters.Add(new SqlParameter("@iCityID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_PermanentAddress_City_TahsilID));
                    //        cmdToExecute.Parameters.Add(new SqlParameter("@nsCity", SqlDbType.NVarChar, 0, ParameterDirection.Input, false, 50, 0, "", DataRowVersion.Proposed, ""));
                    //    }
                    //    else
                    //    {
                    //        cmdToExecute.Parameters.Add(new SqlParameter("@iCityID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, 0));
                    //        cmdToExecute.Parameters.Add(new SqlParameter("@nsCity", SqlDbType.NVarChar, 0, ParameterDirection.Input, false, 50, 0, "", DataRowVersion.Proposed, (item.Student_PermanentAddress_City_TahsilOther != null) ? item.Student_PermanentAddress_City_TahsilOther : string.Empty));                               
                    //    }
                    //    cmdToExecute.Parameters.Add(new SqlParameter("@iCreatedBy", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.CreatedBy));
                    //    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));


                    //    cmdToExecute.Transaction = transaction;
                    //    _rowsAffected = cmdToExecute.ExecuteNonQuery();

                    //}
                    //#endregion for PermanentAddress USP_StudentRegistrationPermanentAddressForOtherState_Insert_Update


                    //#region for CorrespondanceAddress USP_StudentRegistrationPermanentAddressForOtherState_Insert_Update

                    ////if (item.Student_CorrespondenceAddress_CountryId != null && item.Student_PermanentAddress_CountryId != 0)
                    ////{
                    ////    cmdToExecute.Parameters.Clear();
                    ////    cmdToExecute.CommandText = "dbo.USP_StudentRegistrationPermanentAddressForOtherState_Insert_Update";
                    ////    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    ////    cmdToExecute.Parameters.Add(new SqlParameter("@iRegistrationID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.RegistrationID));
                    ////    cmdToExecute.Parameters.Add(new SqlParameter("@iCountryID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_CorrespondenceAddress_CountryId));
                    ////    cmdToExecute.Parameters.Add(new SqlParameter("@cAddressType", SqlDbType.Char, 0, ParameterDirection.Input, false, 50, 0, "", DataRowVersion.Proposed, "C"));
                    ////    if (item.Student_CorrespondenceAddress_State != null && item.Student_CorrespondenceAddress_State != 0)
                    ////    {
                    ////        cmdToExecute.Parameters.Add(new SqlParameter("@iRegionID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_CorrespondenceAddress_State));
                    ////        cmdToExecute.Parameters.Add(new SqlParameter("@nsRegionName", SqlDbType.NVarChar, 0, ParameterDirection.Input, false, 50, 0, "", DataRowVersion.Proposed, ""));
                    ////    }
                    ////    else
                    ////    {
                    ////        cmdToExecute.Parameters.Add(new SqlParameter("@iRegionID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, 0));
                    ////        cmdToExecute.Parameters.Add(new SqlParameter("@nsRegionName", SqlDbType.NVarChar, 0, ParameterDirection.Input, false, 50, 0, "", DataRowVersion.Proposed, (item.Student_CorrespondenceAddress_StateOther != null) ? item.Student_CorrespondenceAddress_StateOther : string.Empty));
                    ////    }
                    ////    if (item.Student_CorrespondenceAddress_DistrictID != null && item.Student_CorrespondenceAddress_DistrictID != 0)
                    ////    {
                    ////        cmdToExecute.Parameters.Add(new SqlParameter("@iDistictID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_CorrespondenceAddress_DistrictID));
                    ////        cmdToExecute.Parameters.Add(new SqlParameter("@nsDistrict", SqlDbType.NVarChar, 0, ParameterDirection.Input, false, 50, 0, "", DataRowVersion.Proposed, ""));
                    ////    }
                    ////    else
                    ////    {
                    ////        cmdToExecute.Parameters.Add(new SqlParameter("@iDistictID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, 0));
                    ////        cmdToExecute.Parameters.Add(new SqlParameter("@nsDistrict", SqlDbType.NVarChar, 0, ParameterDirection.Input, false, 50, 0, "", DataRowVersion.Proposed, (item.Student_CorrespondenceAddress_DistrictOther != null) ? item.Student_CorrespondenceAddress_DistrictOther : string.Empty));
                    ////    }
                    ////    if (item.Student_CorrespondenceAddress_City_TahsilID != null && item.Student_CorrespondenceAddress_City_TahsilID != 0)
                    ////    {
                    ////        cmdToExecute.Parameters.Add(new SqlParameter("@iCityID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_CorrespondenceAddress_City_TahsilID));
                    ////        cmdToExecute.Parameters.Add(new SqlParameter("@nsCity", SqlDbType.NVarChar, 0, ParameterDirection.Input, false, 50, 0, "", DataRowVersion.Proposed, ""));
                    ////    }
                    ////    else
                    ////    {
                    ////        cmdToExecute.Parameters.Add(new SqlParameter("@iCityID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, 0));
                    ////        cmdToExecute.Parameters.Add(new SqlParameter("@nsCity", SqlDbType.NVarChar, 0, ParameterDirection.Input, false, 50, 0, "", DataRowVersion.Proposed, (item.Student_CorrespondenceAddress_City_TahsilOther != null) ? item.Student_CorrespondenceAddress_City_TahsilOther : string.Empty));
                    ////    }
                    ////    cmdToExecute.Parameters.Add(new SqlParameter("@iCreatedBy", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.CreatedBy));
                    ////    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    ////    cmdToExecute.Transaction = transaction;
                    ////    _rowsAffected = cmdToExecute.ExecuteNonQuery();
                    ////}

                    //#endregion for CorrespondanceAddress USP_StudentRegistrationCorrespondenceAddressForOtherState_Insert_Update


                    //#region for Diploma / ITI Details


                    //if (item.Student_Qualification_Diploma_ITI_Details_CountryId != null && item.Student_Qualification_Diploma_ITI_Details_CountryId != 0 && item.Student_Qualification_Diploma_ITI_Details_StateOther != null && item.Student_Qualification_Diploma_ITI_Details_StateOther != "")
                    //{
                    //    cmdToExecute.Parameters.Clear();
                    //    cmdToExecute.CommandText = "dbo.USP_StudentRegistrationQualificationDetailsForOther_Insert_Update";
                    //    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    //    cmdToExecute.Parameters.Add(new SqlParameter("@iRegistrationID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.RegistrationID));
                    //    cmdToExecute.Parameters.Add(new SqlParameter("@iCountryID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_Qualification_Diploma_ITI_Details_CountryId));
                    //    cmdToExecute.Parameters.Add(new SqlParameter("@nsEducationType", SqlDbType.NVarChar, 0, ParameterDirection.Input, false, 15, 0, "", DataRowVersion.Proposed, "DIPLOMA"));
                    //    cmdToExecute.Parameters.Add(new SqlParameter("@nsRegionName", SqlDbType.NVarChar, 0, ParameterDirection.Input, false, 50, 0, "", DataRowVersion.Proposed, item.Student_Qualification_Diploma_ITI_Details_StateOther));
                    //    cmdToExecute.Parameters.Add(new SqlParameter("@iCreatedBy", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.CreatedBy));
                    //    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    //    cmdToExecute.Transaction = transaction;
                    //    _rowsAffected = cmdToExecute.ExecuteNonQuery();
                    //}

                    //#endregion for Diploma / ITI Details

                    //#region for Degree Details Details


                    //if (item.Student_Qualification_DegreeDetails_CountryId != null && item.Student_Qualification_DegreeDetails_CountryId != 0 && item.Student_Qualification_DegreeDetails_StateOther != null && item.Student_Qualification_DegreeDetails_StateOther != "")
                    //{
                    //    cmdToExecute.Parameters.Clear();
                    //    cmdToExecute.CommandText = "dbo.USP_StudentRegistrationQualificationDetailsForOther_Insert_Update";
                    //    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    //    cmdToExecute.Parameters.Add(new SqlParameter("@iRegistrationID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.RegistrationID));
                    //    cmdToExecute.Parameters.Add(new SqlParameter("@iCountryID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_Qualification_DegreeDetails_CountryId));
                    //    cmdToExecute.Parameters.Add(new SqlParameter("@nsEducationType", SqlDbType.NVarChar, 0, ParameterDirection.Input, false, 15, 0, "", DataRowVersion.Proposed, "UG"));
                    //    cmdToExecute.Parameters.Add(new SqlParameter("@nsRegionName", SqlDbType.NVarChar, 0, ParameterDirection.Input, false, 50, 0, "", DataRowVersion.Proposed, item.Student_Qualification_DegreeDetails_StateOther));
                    //    cmdToExecute.Parameters.Add(new SqlParameter("@iCreatedBy", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.CreatedBy));
                    //    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    //    cmdToExecute.Transaction = transaction;
                    //    _rowsAffected = cmdToExecute.ExecuteNonQuery();
                    //}

                    //#endregion for Degree Details Details

                    //#region for  Post Graduation


                    //if (item.Student_Qualification_PostGraduationDetails_CountryId != null && item.Student_Qualification_PostGraduationDetails_CountryId != 0 && item.Student_Qualification_PostGraduationDetails_StateOther != null && item.Student_Qualification_PostGraduationDetails_StateOther != "")
                    //{
                    //    cmdToExecute.Parameters.Clear();
                    //    cmdToExecute.CommandText = "dbo.USP_StudentRegistrationQualificationDetailsForOther_Insert_Update";
                    //    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    //    cmdToExecute.Parameters.Add(new SqlParameter("@iRegistrationID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.RegistrationID));
                    //    cmdToExecute.Parameters.Add(new SqlParameter("@iCountryID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Student_Qualification_PostGraduationDetails_CountryId));
                    //    cmdToExecute.Parameters.Add(new SqlParameter("@nsEducationType", SqlDbType.NVarChar, 0, ParameterDirection.Input, false, 15, 0, "", DataRowVersion.Proposed, "PG"));
                    //    cmdToExecute.Parameters.Add(new SqlParameter("@nsRegionName", SqlDbType.NVarChar, 0, ParameterDirection.Input, false, 50, 0, "", DataRowVersion.Proposed, item.Student_Qualification_PostGraduationDetails_StateOther));
                    //    cmdToExecute.Parameters.Add(new SqlParameter("@iCreatedBy", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.CreatedBy));
                    //    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    //    cmdToExecute.Transaction = transaction;
                    //    _rowsAffected = cmdToExecute.ExecuteNonQuery();
                    //}

                    //#endregion for Post Graduation


                    cmdToExecute.Parameters.Clear();
                    cmdToExecute.CommandText = "dbo.USP_StudentRegistrationAcademicApproval_Insert";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.ID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iRegistrationID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.RegistrationID));
                    // cmdToExecute.Parameters.Add(new SqlParameter("@sAuthorisationType", SqlDbType.VarChar, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.AuthorisationType));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iRoleID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.RoleID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsReasonIfRejected", SqlDbType.NVarChar, 200, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, (item.ReasonIfRejected != string.Empty && item.ReasonIfRejected != null) ? item.ReasonIfRejected : DBNull.Value.ToString()));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bApprovalStatus", SqlDbType.Bit, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.ApprovalStatus));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iSectionDetailID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.SelectedSectionDetailID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bIslastStatus", SqlDbType.Bit, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.IslastStatus));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bStuRegistrationStudentPhotoSignThumb", SqlDbType.Bit, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.StuRegistrationStudentPhotoSignThumb));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bStuRegistrationStudentSocialReservationInformation", SqlDbType.Bit, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.StuRegistrationStudentSocialReservationInformation));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bStuRegistrationOtherInfoOfStudent", SqlDbType.Bit, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.StuRegistrationOtherInfoOfStudent));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bstuRegistrationAddressDetails", SqlDbType.Bit, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.stuRegistrationAddressDetails));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bStuRegistrationQualifyingSelectionInfo", SqlDbType.Bit, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.StuRegistrationQualifyingSelectionInfo));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bStuRegistrationDocumentSubmitted", SqlDbType.Bit, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.StuRegistrationDocumentSubmitted));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bStuRegistrationPreEntranceExaminationTransaction", SqlDbType.Bit, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.StuRegistrationPreEntranceExaminationTransaction));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bStuRegistrationPreEntranceExaminationSubjectDetail", SqlDbType.Bit, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.StuRegistrationPreEntranceExaminationSubjectDetail));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bStuRegistrationPreQualificationSchoolTransaction", SqlDbType.Bit, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.StuRegistrationPreQualificationSchoolTransaction));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bStuRegistrationPreQualificationCollegeTransactions", SqlDbType.Bit, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.StuRegistrationPreQualificationCollegeTransaction));

                    cmdToExecute.Parameters.Add(new SqlParameter("@iStageSequenceNumber", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.StageSequenceNumber));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bIsLast", SqlDbType.Bit, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.IsLastRecord));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iTaskNotificationMasterID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.TaskNotificationMasterID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iTaskNotificationDetailsID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.TaskNotificationDetailsID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iGeneralTaskReportingDetailsID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.GeneralTaskReportingDetailsID));

                    cmdToExecute.Parameters.Add(new SqlParameter("@iCreatedBy", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.CreatedBy));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));

                    // Execute query.

                    cmdToExecute.Transaction = transaction;
                   _rowsAffected = cmdToExecute.ExecuteNonQuery();
                    item.ID = (Int32)cmdToExecute.Parameters["@iID"].Value;
                    transaction.Commit();
                    _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'dbo.USP_StudentRegistrationAcademicApproval_INSERT' reported the ErrorCode: " +
                                        _errorCode);
                    }
                    if (_rowsAffected > 0)
                    {
                        response.Entity = item;
                    }
                    else
                    {
                        response.Message.Add(new MessageDTO
                        {
                            ErrorMessage = "Create failed"
                        });
                    }
                }
            }
            catch (SqlException ex)
            {
                transaction.Rollback();
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
                cmdToExecute.Dispose();
                //cmdToExecute.Dispose();
                //cmdToExecute.Dispose();
                //cmdToExecute.Dispose();
                //cmdToExecute.Dispose();
                //cmdToExecute.Dispose();
            }
            return response;
        }
        /// <summary>
        /// Update a specific record of StudentRegistrationAcademicApproval
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<StudentRegistrationAcademicApproval> UpdateStudentRegistrationAcademicApproval(StudentRegistrationAcademicApproval item)
        {
            IBaseEntityResponse<StudentRegistrationAcademicApproval> response = new BaseEntityResponse<StudentRegistrationAcademicApproval>();
            SqlCommand cmdToExecute = new SqlCommand();
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
                    cmdToExecute.CommandText = "dbo.USP_StudentRegistrationAcademicApproval_Update";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 10,
                                        ParameterDirection.Input, false, 0, 0, "",
                                        DataRowVersion.Proposed, item.ID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iRegistrationID", SqlDbType.Int, 10,
                                        ParameterDirection.Input, false, 0, 0, "",
                                        DataRowVersion.Proposed, item.RegistrationID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sAuthorisationType", SqlDbType.VarChar, 0,
                                        ParameterDirection.Input, false, 10, 0, "",
                                        DataRowVersion.Proposed, item.AuthorisationType));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iRoleID", SqlDbType.Int, 10,
                                        ParameterDirection.Input, false, 0, 0, "",
                                        DataRowVersion.Proposed, item.RoleID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bStatus", SqlDbType.Bit, 0,
                                        ParameterDirection.Input, false, 0, 0, "",
                                        DataRowVersion.Proposed, item.Status));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sReasonIfRejected", SqlDbType.VarChar, 0,
                                        ParameterDirection.Input, false, 10, 0, "",
                                        DataRowVersion.Proposed, item.ReasonIfRejected));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bIslastStatus", SqlDbType.Bit, 0,
                                        ParameterDirection.Input, false, 0, 0, "",
                                        DataRowVersion.Proposed, item.IslastStatus));

                    cmdToExecute.Parameters.Add(new SqlParameter("@iModifiedBy", SqlDbType.Int, 4,
                                        ParameterDirection.Input, true, 10, 0, "",
                                        DataRowVersion.Proposed, item.ModifiedBy));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4,
                                            ParameterDirection.Output, true, 10, 0, "",
                                            DataRowVersion.Proposed, _errorCode));
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
                    _rowsAffected = cmdToExecute.ExecuteNonQuery();
                    item.ID = (Int32)cmdToExecute.Parameters["@iID"].Value;
                    _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'dbo.USP_StudentRegistrationAcademicApproval_Delete' reported the ErrorCode: " +
                                        _errorCode);
                    }
                    if (_rowsAffected > 0)
                    {
                        response.Entity = item;
                    }
                    else
                    {
                        response.Message.Add(new MessageDTO
                        {
                            ErrorMessage = "Create failed"
                        });
                    }
                }
            }
            catch (SqlException ex)
            {
                response.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                _logException.Error(ex.Message);
            }
            catch (Exception ex)
            {
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
                cmdToExecute.Dispose();
            }
            return response;
        }
        /// <summary>
        /// Delete a specific record of StudentRegistrationAcademicApproval
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<StudentRegistrationAcademicApproval> DeleteStudentRegistrationAcademicApproval(StudentRegistrationAcademicApproval item)
        {
            IBaseEntityResponse<StudentRegistrationAcademicApproval> response = new BaseEntityResponse<StudentRegistrationAcademicApproval>();
            SqlCommand cmdToExecute = new SqlCommand();
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
                    cmdToExecute.CommandText = "dbo.USP_StudentRegistrationAcademicApproval_Delete";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 4,
                                            ParameterDirection.Input, true, 10, 0, "",
                                            DataRowVersion.Proposed, item.ID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bIsDeletedType", SqlDbType.Bit, 1,
                                            ParameterDirection.Input, false, 0, 0, "",
                                            DataRowVersion.Proposed, 0));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bDeletedStatus", SqlDbType.Bit, 1,
                                            ParameterDirection.Input, false, 0, 0, "",
                                            DataRowVersion.Proposed, 1));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iDeletedBy", SqlDbType.Int, 4,
                                            ParameterDirection.Input, true, 10, 0, "",
                                            DataRowVersion.Proposed, 1));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4,
                                            ParameterDirection.Output, true, 10, 0, "",
                                            DataRowVersion.Proposed, _errorCode));
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
                    _rowsAffected = cmdToExecute.ExecuteNonQuery();
                    item.ID = (Int32)cmdToExecute.Parameters["@iID"].Value;
                    _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'dbo.USP_StudentRegistrationAcademicApproval_Delete' reported the ErrorCode: " +
                                        _errorCode);
                    }
                    if (_rowsAffected > 0)
                    {
                        response.Entity = item;
                    }
                    else
                    {
                        response.Message.Add(new MessageDTO
                        {
                            ErrorMessage = "Create failed"
                        });
                    }
                }
            }
            catch (SqlException ex)
            {
                response.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                _logException.Error(ex.Message);
            }
            catch (Exception ex)
            {
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
                cmdToExecute.Dispose();
            }
            return response;
        }

        public IBaseEntityCollectionResponse<PreviousWorkExperienceAcademicApproval> GetPreviousWorkExperienceAcademicApproval(PreviousWorkExperienceAcademicApprovalSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<PreviousWorkExperienceAcademicApproval> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<PreviousWorkExperienceAcademicApproval>();
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
                    baseEntityCollection.CollectionResponse = new List<PreviousWorkExperienceAcademicApproval>();
                    while (sqlDataReader.Read())
                    {
                        PreviousWorkExperienceAcademicApproval item = new PreviousWorkExperienceAcademicApproval();
                        item.StudentPreviousExperienceID = sqlDataReader["ID"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["ID"]);
                        item.Position = sqlDataReader["Position"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["Position"]);
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
        
        public IBaseEntityCollectionResponse<StudentRegistrationAcademicApproval> GetByQualifyingExamSubjectList(StudentRegistrationAcademicApprovalSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<StudentRegistrationAcademicApproval> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<StudentRegistrationAcademicApproval>();
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
                    cmdToExecute.CommandText = "dbo.USP_StuRegistrationPreEntranceExaminationSubjectDetail_ByStudentRegistrationID";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iStudentRegistrationID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.RegistrationID));

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
                    baseEntityCollection.CollectionResponse = new List<StudentRegistrationAcademicApproval>();
                    while (sqlDataReader.Read())
                    {
                        StudentRegistrationAcademicApproval item = new StudentRegistrationAcademicApproval();
                        if (DBNull.Value.Equals(sqlDataReader["QualifyingSubjectID"]) == false)
                        {
                            item.QualifyingSubjectID = Convert.ToInt32(sqlDataReader["QualifyingSubjectID"]);
                        }

                        item.QualifyingSubjectName = sqlDataReader["SubjectName"].ToString();
                        if (DBNull.Value.Equals(sqlDataReader["MarksOutOf"]) == false)
                        {
                            item.QualifyingMarksOutOf = Convert.ToInt32(sqlDataReader["MarksOutOf"]);
                        }

                        if (DBNull.Value.Equals(sqlDataReader["MarksObtained"]) == false)
                        {
                            item.QualifyingMarksObtained = Convert.ToInt32(sqlDataReader["MarksObtained"]);
                        }

                        baseEntityCollection.CollectionResponse.Add(item);

                    }
                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_StudentRegistrationAcademicApproval_SelectByQualifyingExamMstID' reported the ErrorCode: " + _errorCode);
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

        public IBaseEntityCollectionResponse<StudentRegistrationAcademicApproval> GetByQualificationSubjectListByStudentRegistrationIDAndEducationType(StudentRegistrationAcademicApprovalSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<StudentRegistrationAcademicApproval> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<StudentRegistrationAcademicApproval>();
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
                    cmdToExecute.CommandText = "dbo.USP_StuRegistrationPreQualificationSchoolSubjectDetail_ByStudentRegistrationID";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iStudentRegistrationID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.RegistrationID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@cEducationType", SqlDbType.Char, 1, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.EducationType));
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
                    baseEntityCollection.CollectionResponse = new List<StudentRegistrationAcademicApproval>();
                    while (sqlDataReader.Read())
                    {
                        StudentRegistrationAcademicApproval item = new StudentRegistrationAcademicApproval();
                        if (DBNull.Value.Equals(sqlDataReader["QualificationSubjectID"]) == false)
                        {
                            item.QualificationSubjectID = Convert.ToInt32(sqlDataReader["QualificationSubjectID"]);
                        }

                        item.QualificationSubjectName = sqlDataReader["SubjectName"].ToString();
                        if (DBNull.Value.Equals(sqlDataReader["MarksOutOf"]) == false)
                        {
                            item.QualificationMarksOutOf = Convert.ToInt32(sqlDataReader["MarksOutOf"]);
                        }

                        if (DBNull.Value.Equals(sqlDataReader["MarksObtained"]) == false)
                        {
                            item.QualificationMarksObtained = Convert.ToInt32(sqlDataReader["MarksObtained"]);
                        }

                        baseEntityCollection.CollectionResponse.Add(item);

                    }
                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_StudentRegistrationAcademicApproval_SelectByQualifyingExamMstID' reported the ErrorCode: " + _errorCode);
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
        #endregion
    }
}
