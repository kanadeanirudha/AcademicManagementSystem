using AMS.Common;
using AMS.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AMS.ViewModel
{
    public class GenerateStudentRollNumberViewModel : IGenerateStudentRollNumberViewModel
    {
        public GenerateStudentRollNumberViewModel()
        {
            ListOrganisationDepartmentMaster = new List<OrganisationDepartmentMaster>();
            ListOrganisationStudyCentreMaster = new List<OrganisationStudyCentreMaster>();
            ListBranchRoleWise = new List<OrganisationBranchMaster>();
            ListOrganisationUniversityMaster = new List<OrganisationUniversityMaster>();
            ListNextCourseYearDetails = new List<OrganisationCourseYearDetails>();
            ListOrganisationSectionDetailsRoleWise = new List<OrganisationSectionDetails>();
            ListNextSectionPromotionList = new List<OrganisationSectionDetails>();
            ListOrganisationCentrewiseSession = new List<OrganisationCentrewiseSession>();
            GenerateStudentRollNumberDTO = new GenerateStudentRollNumber();
        }


        public List<OrganisationDepartmentMaster> ListOrganisationDepartmentMaster
        {
            get;
            set;
        }
        public List<OrganisationStudyCentreMaster> ListOrganisationStudyCentreMaster
        {
            get;
            set;
        }
        public List<OrganisationBranchMaster> ListBranchRoleWise
        {
            get;
            set;
        }
        public List<OrganisationUniversityMaster> ListOrganisationUniversityMaster
        {
            get;
            set;
        }
        public List<OrganisationCourseYearDetails> ListNextCourseYearDetails
        {
            get;
            set;
        }
        public List<OrganisationSectionDetails> ListOrganisationSectionDetailsRoleWise
        {
            get;
            set;
        } 
        public List<OrganisationSectionDetails> ListNextSectionPromotionList
        {
            get;
            set;
        }
        public List<OrganisationCentrewiseSession> ListOrganisationCentrewiseSession
        {
            get;
            set;
        }

        [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_SelectedCentreCode")]
        public string SelectedCentreCode
        {
            get;
            set;
        }
        public string SelectedCentreName
        {
            get;
            set;
        }

          [Display(Name = "DisplayName_SelectedUniversityID", ResourceType = typeof(AMS.Common.Resources))]
          [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_SelectedUniversityID")]
        public string SelectedUniversityID
        {
            get;
            set;
        }
        public string SelectedDepartmentID
        {
            get;
            set;
        }
         [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_SelectedSessionID")]
        public string SelectedSessionID
        {
            get;
            set;
        }
        [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_SelectedBranchID")]    
        public string SelectedBranchID
        {
            get;
            set;
        }
        public string SelectedNextCourseYearID
        {
            get;
            set;
        }
        [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_SelectedSectionDetRoleWiseID")]
        public string SelectedSectionDetRoleWiseID
        {
            get;
            set;
        }
        public string SelectedNextSecPromoID
        {
            get;
            set;
        }

        public IEnumerable<SelectListItem> StudyCentreListMasterItems
        {
            get
            {
                return new SelectList(ListOrganisationStudyCentreMaster, "CentreCode" , "CentreName");
            }
        }
        public IEnumerable<SelectListItem> ListOrganisationUnivesitytMasterItems
        {
            get
            {

                return new SelectList(ListOrganisationUniversityMaster, "ID", "UniversityName");
            }

        }
        public IEnumerable<SelectListItem> DepartmentListMasterItems
        {
            get
            {

                return new SelectList(ListOrganisationDepartmentMaster, "ID", "Description");
            }

        }
        public IEnumerable<SelectListItem> BranchListRoleWiseMasterItems
        {
            get
            {
                return new SelectList(ListBranchRoleWise, "ID", "BranchDescription");
            }
        }
        public IEnumerable<SelectListItem> NextCourseYearListMasterItems
        {
            get
            {
                return new SelectList(ListNextCourseYearDetails, "ID", "CourseYear");
            }
        }
        public IEnumerable<SelectListItem> SessionListMasterItems
        {
            get
            {
                return new SelectList(ListOrganisationCentrewiseSession, "SessionID", "SessionName");
            }
        }
        public IEnumerable<SelectListItem> SectionDetListRoleWiseMasterItems
        {
            get
            {
                return new SelectList(ListOrganisationSectionDetailsRoleWise, "ID", "Descriptions");
            }
        }
        public IEnumerable<SelectListItem> NextSectionPromotionListMasterItems
        {
            get
            {
                return new SelectList(ListNextSectionPromotionList, "ID", "SectionDescription");
            }
        }
        

        //--------------------------Properties of StuAdmissioDetails Table--------------------------------------//


        public GenerateStudentRollNumber GenerateStudentRollNumberDTO
        {
            get;
            set;
        }

        public int ID
        {
            get
            {
                return (GenerateStudentRollNumberDTO != null && GenerateStudentRollNumberDTO.ID > 0) ? GenerateStudentRollNumberDTO.ID : new int();
            }
            set
            {
                GenerateStudentRollNumberDTO.ID = value;
            }
        }
        public int StudentId
        {
            get
            {
                return (GenerateStudentRollNumberDTO != null && GenerateStudentRollNumberDTO.StudentId > 0) ? GenerateStudentRollNumberDTO.StudentId : new int();
            }
            set
            {
                GenerateStudentRollNumberDTO.StudentId = value;
            }
        }

        [Display(Name = "DisplayName_StudentName", ResourceType = typeof(AMS.Common.Resources))]
        public string StudentName
        {
            get
            {
                return (GenerateStudentRollNumberDTO != null) ? GenerateStudentRollNumberDTO.StudentName : string.Empty;
            }
            set
            {
                GenerateStudentRollNumberDTO.StudentName = value;
            }
        }
        public string FormNumber
        {
            get
            {
                return (GenerateStudentRollNumberDTO != null) ? GenerateStudentRollNumberDTO.FormNumber : string.Empty;
            }
            set
            {
                GenerateStudentRollNumberDTO.FormNumber = value;
            }
        }
        public string FormDate
        {
            get
            {
                return (GenerateStudentRollNumberDTO != null) ? GenerateStudentRollNumberDTO.FormDate : string.Empty;
            }
            set
            {
                GenerateStudentRollNumberDTO.FormDate = value;
            }
        }
        [Display(Name = "DisplayName_SectionDetailID", ResourceType = typeof(AMS.Common.Resources))]
        public int SectionDetailID
        {
            get
            {
                return (GenerateStudentRollNumberDTO != null && GenerateStudentRollNumberDTO.SectionDetailID > 0) ? GenerateStudentRollNumberDTO.SectionDetailID : new int();
            }
            set
            {
                GenerateStudentRollNumberDTO.SectionDetailID = value;
            }
        }

        [Display(Name = "DisplayName_SectionDetails", ResourceType = typeof(AMS.Common.Resources))]
        public string SectionDetails
        {
            get
            {
                return (GenerateStudentRollNumberDTO != null) ? GenerateStudentRollNumberDTO.SectionDetails : string.Empty;
            }
            set
            {
                GenerateStudentRollNumberDTO.SectionDetails = value;
            }
        }

          [Display(Name = "DisplayName_PromotedToNextSection", ResourceType = typeof(AMS.Common.Resources))]
        public string PromotedToNextSection
        {
            get
            {
                return (GenerateStudentRollNumberDTO != null) ? GenerateStudentRollNumberDTO.PromotedToNextSection : string.Empty;
            }
            set
            {
                GenerateStudentRollNumberDTO.PromotedToNextSection = value;
            }
        }

        public string NextSectionDescription
        {
            get
            {
                return (GenerateStudentRollNumberDTO != null) ? GenerateStudentRollNumberDTO.NextSectionDescription : string.Empty;
            }
            set
            {
                GenerateStudentRollNumberDTO.NextSectionDescription = value;
            }
        }
        [Display(Name = "DisplayName_AdmissionDate", ResourceType = typeof(AMS.Common.Resources))]
        public string AdmissionDate
        {
            get
            {
                return (GenerateStudentRollNumberDTO != null) ? GenerateStudentRollNumberDTO.AdmissionDate : string.Empty;
            }
            set
            {
                GenerateStudentRollNumberDTO.AdmissionDate = value;
            }
        }
        public bool AdmissionActiveFlag
        {
            get
            {
                return (GenerateStudentRollNumberDTO != null) ? GenerateStudentRollNumberDTO.AdmissionActiveFlag : false;
            }
            set
            {
                GenerateStudentRollNumberDTO.AdmissionActiveFlag = value;
            }
        }

        [Display(Name = "DisplayName_AcademicYear", ResourceType = typeof(AMS.Common.Resources))]
        public string AcademicYear
        {
            get
            {
                return (GenerateStudentRollNumberDTO != null) ? GenerateStudentRollNumberDTO.AcademicYear : string.Empty;
            }
            set
            {
                GenerateStudentRollNumberDTO.AcademicYear = value;
            }
        }
        public string YearlyRollNumber
        {
            get
            {
                return (GenerateStudentRollNumberDTO != null) ? GenerateStudentRollNumberDTO.YearlyRollNumber : string.Empty;
            }
            set
            {
                GenerateStudentRollNumberDTO.YearlyRollNumber = value;
            }
        }
        public string RollNoSortOrder
        {
            get
            {
                return (GenerateStudentRollNumberDTO != null) ? GenerateStudentRollNumberDTO.RollNoSortOrder : string.Empty;
            }
            set
            {
                GenerateStudentRollNumberDTO.RollNoSortOrder = value;
            }
        }
        public string SortOrderStatus
        {
            get
            {
                return (GenerateStudentRollNumberDTO != null) ? GenerateStudentRollNumberDTO.SortOrderStatus : string.Empty;
            }
            set
            {
                GenerateStudentRollNumberDTO.SortOrderStatus = value;
            }
        }
        public string FromSession
        {
            get
            {
                return (GenerateStudentRollNumberDTO != null) ? GenerateStudentRollNumberDTO.FromSession : string.Empty;
            }
            set
            {
                GenerateStudentRollNumberDTO.FromSession = value;
            }
        }
        public string UptoSession
        {
            get
            {
                return (GenerateStudentRollNumberDTO != null) ? GenerateStudentRollNumberDTO.UptoSession : string.Empty;
            }
            set
            {
                GenerateStudentRollNumberDTO.UptoSession = value;
            }
        }
        public string ResultStatus
        {
            get
            {
                return (GenerateStudentRollNumberDTO != null) ? GenerateStudentRollNumberDTO.ResultStatus : string.Empty;
            }
            set
            {
                GenerateStudentRollNumberDTO.ResultStatus = value;
            }
        }
        public bool AdmissionCancelStatus
        {
            get
            {
                return (GenerateStudentRollNumberDTO != null) ? GenerateStudentRollNumberDTO.AdmissionCancelStatus : false;
            }
            set
            {
                GenerateStudentRollNumberDTO.AdmissionCancelStatus = value;
            }
        }
        public string AdmissionStatus
        {
            get
            {
                return (GenerateStudentRollNumberDTO != null) ? GenerateStudentRollNumberDTO.AdmissionStatus : string.Empty;
            }
            set
            {
                GenerateStudentRollNumberDTO.AdmissionStatus = value;
            }
        }
        public string AdmissionCancelDate
        {
            get
            {
                return (GenerateStudentRollNumberDTO != null) ? GenerateStudentRollNumberDTO.AdmissionCancelDate : string.Empty;
            }
            set
            {
                GenerateStudentRollNumberDTO.AdmissionCancelDate = value;
            }
        }
        public int BranchId
        {
            get
            {
                return (GenerateStudentRollNumberDTO != null && GenerateStudentRollNumberDTO.BranchId > 0) ? GenerateStudentRollNumberDTO.BranchId : new int();
            }
            set
            {
                GenerateStudentRollNumberDTO.BranchId = value;
            }
        }
        public string PromotedToNextBranch
        {
            get
            {
                return (GenerateStudentRollNumberDTO != null) ? GenerateStudentRollNumberDTO.PromotedToNextBranch : string.Empty;
            }
            set
            {
                GenerateStudentRollNumberDTO.PromotedToNextBranch = value;
            }
        }
        public string StatusCode
        {
            get
            {
                return (GenerateStudentRollNumberDTO != null) ? GenerateStudentRollNumberDTO.StatusCode : string.Empty;
            }
            set
            {
                GenerateStudentRollNumberDTO.StatusCode = value;
            }
        }
        public string AdmissionConfirmDate
        {
            get
            {
                return (GenerateStudentRollNumberDTO != null) ? GenerateStudentRollNumberDTO.AdmissionConfirmDate : string.Empty;
            }
            set
            {
                GenerateStudentRollNumberDTO.AdmissionConfirmDate = value;
            }
        }
        public string AdmissionPromoteDate
        {
            get
            {
                return (GenerateStudentRollNumberDTO != null) ? GenerateStudentRollNumberDTO.AdmissionPromoteDate : string.Empty;
            }
            set
            {
                GenerateStudentRollNumberDTO.AdmissionPromoteDate = value;
            }
        }
        public string CentreCode
        {
            get
            {
                return (GenerateStudentRollNumberDTO != null) ? GenerateStudentRollNumberDTO.CentreCode : string.Empty;
            }
            set
            {
                GenerateStudentRollNumberDTO.CentreCode = value;
            }
        }
        public string Remark
        {
            get
            {
                return (GenerateStudentRollNumberDTO != null) ? GenerateStudentRollNumberDTO.Remark : string.Empty;
            }
            set
            {
                GenerateStudentRollNumberDTO.Remark = value;
            }
        }

        [Display(Name = "DisplayName_AdmissionNumber", ResourceType = typeof(AMS.Common.Resources))]
        public string AdmissionNumber
        {
            get
            {
                return (GenerateStudentRollNumberDTO != null) ? GenerateStudentRollNumberDTO.AdmissionNumber : string.Empty;
            }
            set
            {
                GenerateStudentRollNumberDTO.AdmissionNumber = value;
            }
        }
        public string PrevExamSeatNo
        {
            get
            {
                return (GenerateStudentRollNumberDTO != null) ? GenerateStudentRollNumberDTO.PrevExamSeatNo : string.Empty;
            }
            set
            {
                GenerateStudentRollNumberDTO.PrevExamSeatNo = value;
            }
        }
        public string EligibForCuryrAdmsn
        {
            get
            {
                return (GenerateStudentRollNumberDTO != null) ? GenerateStudentRollNumberDTO.EligibForCuryrAdmsn : string.Empty;
            }
            set
            {
                GenerateStudentRollNumberDTO.EligibForCuryrAdmsn = value;
            }
        }
        public string ResultCurYear
        {
            get
            {
                return (GenerateStudentRollNumberDTO != null) ? GenerateStudentRollNumberDTO.ResultCurYear : string.Empty;
            }
            set
            {
                GenerateStudentRollNumberDTO.ResultCurYear = value;
            }
        }
        public string DtndForSemester
        {
            get
            {
                return (GenerateStudentRollNumberDTO != null) ? GenerateStudentRollNumberDTO.DtndForSemester : string.Empty;
            }
            set
            {
                GenerateStudentRollNumberDTO.DtndForSemester = value;
            }
        }
        public string SemesterSpecificAdmsn
        {
            get
            {
                return (GenerateStudentRollNumberDTO != null) ? GenerateStudentRollNumberDTO.SemesterSpecificAdmsn : string.Empty;
            }
            set
            {
                GenerateStudentRollNumberDTO.SemesterSpecificAdmsn = value;
            }
        }
        public int StuRevalAppliId
        {
            get
            {
                return (GenerateStudentRollNumberDTO != null && GenerateStudentRollNumberDTO.StuRevalAppliId > 0) ? GenerateStudentRollNumberDTO.StuRevalAppliId : new int();
            }
            set
            {
                GenerateStudentRollNumberDTO.StuRevalAppliId = value;
            }
        }
        public string ProvisionalType
        {
            get
            {
                return (GenerateStudentRollNumberDTO != null) ? GenerateStudentRollNumberDTO.ProvisionalType : string.Empty;
            }
            set
            {
                GenerateStudentRollNumberDTO.ProvisionalType = value;
            }
        }
        public string AdmissionFinalStatus
        {
            get
            {
                return (GenerateStudentRollNumberDTO != null) ? GenerateStudentRollNumberDTO.AdmissionFinalStatus : string.Empty;
            }
            set
            {
                GenerateStudentRollNumberDTO.AdmissionFinalStatus = value;
            }
        }
        public bool IsActive
        {
            get
            {
                return (GenerateStudentRollNumberDTO != null) ? GenerateStudentRollNumberDTO.IsActive : false;
            }
            set
            {
                GenerateStudentRollNumberDTO.IsActive = value;
            }
        }
        public bool IsDeleted
        {
            get
            {
                return (GenerateStudentRollNumberDTO != null) ? GenerateStudentRollNumberDTO.IsDeleted : false;
            }
            set
            {
                GenerateStudentRollNumberDTO.IsDeleted = value;
            }
        }
        public int CreatedBy
        {
            get
            {
                return (GenerateStudentRollNumberDTO != null && GenerateStudentRollNumberDTO.CreatedBy > 0) ? GenerateStudentRollNumberDTO.CreatedBy : new int();
            }
            set
            {
                GenerateStudentRollNumberDTO.CreatedBy = value;
            }
        }
        public DateTime CreatedDate
        {
            get
            {
                return (GenerateStudentRollNumberDTO != null) ? GenerateStudentRollNumberDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                GenerateStudentRollNumberDTO.CreatedDate = value;
            }
        }
        public int? ModifiedBy
        {
            get
            {
                return (GenerateStudentRollNumberDTO != null && GenerateStudentRollNumberDTO.ModifiedBy > 0) ? GenerateStudentRollNumberDTO.ModifiedBy : new int();
            }
            set
            {
                GenerateStudentRollNumberDTO.ModifiedBy = value;
            }
        }
        public DateTime? ModifiedDate
        {
            get
            {
                return (GenerateStudentRollNumberDTO != null) ? GenerateStudentRollNumberDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                GenerateStudentRollNumberDTO.ModifiedDate = value;
            }
        }
        public int? DeletedBy
        {
            get
            {
                return (GenerateStudentRollNumberDTO != null && GenerateStudentRollNumberDTO.DeletedBy > 0) ? GenerateStudentRollNumberDTO.DeletedBy : new int();
            }
            set
            {
                GenerateStudentRollNumberDTO.DeletedBy = value;
            }
        }
        public DateTime? DeletedDate
        {
            get
            {
                return (GenerateStudentRollNumberDTO != null) ? GenerateStudentRollNumberDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                GenerateStudentRollNumberDTO.DeletedDate = value;
            }
        }

        [Display(Name = "DisplayName_BranchDescription", ResourceType = typeof(AMS.Common.Resources))]
        public string BranchDescription
        {
            get
            {
                return (GenerateStudentRollNumberDTO != null) ? GenerateStudentRollNumberDTO.BranchDescription : string.Empty;
            }
            set
            {
                GenerateStudentRollNumberDTO.BranchDescription = value;
            }
        }

        [Display(Name = "DisplayName_CourseYearDesc", ResourceType = typeof(AMS.Common.Resources))]
        public string CourseYearDesc
        {
            get
            {
                return (GenerateStudentRollNumberDTO != null) ? GenerateStudentRollNumberDTO.CourseYearDesc : string.Empty;
            }
            set
            {
                GenerateStudentRollNumberDTO.CourseYearDesc = value;
            }
        }

        [Display(Name = "DisplayName_SectionDesc", ResourceType = typeof(AMS.Common.Resources))]
        public string SectionDesc
        {
            get
            {
                return (GenerateStudentRollNumberDTO != null) ? GenerateStudentRollNumberDTO.SectionDesc : string.Empty;
            }
            set
            {
                GenerateStudentRollNumberDTO.SectionDesc = value;
            }
        }

        [Display(Name = "DisplayName_SessionName", ResourceType = typeof(AMS.Common.Resources))]
        public string SessionName
        {
            get
            {
                return (GenerateStudentRollNumberDTO != null) ? GenerateStudentRollNumberDTO.SessionName : string.Empty;
            }
            set
            {
                GenerateStudentRollNumberDTO.SessionName = value;
            }
        }
        public int SessionID
        {
            get
            {
                return (GenerateStudentRollNumberDTO != null && GenerateStudentRollNumberDTO.SessionID > 0) ? GenerateStudentRollNumberDTO.SessionID : new int();
            }
            set
            {
                GenerateStudentRollNumberDTO.SessionID = value;
            }
        }

        [Display(Name = "DisplayName_CentreName", ResourceType = typeof(AMS.Common.Resources))]
        public string CentreName
        {
            get
            {
                return (GenerateStudentRollNumberDTO != null) ? GenerateStudentRollNumberDTO.CentreName : string.Empty;
            }
            set
            {
                GenerateStudentRollNumberDTO.CentreName = value;
            }
        }
        public string errorMessage { get; set; }

        public string PromotedStudentList
        {
            get
            {
                return (GenerateStudentRollNumberDTO != null) ? GenerateStudentRollNumberDTO.PromotedStudentList : string.Empty;
            }
            set
            {
                GenerateStudentRollNumberDTO.PromotedStudentList = value;
            }
        }





        //--------------------------Properties of StuStudentMaster--------------------------------------//
        public string StudentCode
        {
            get
            {
                return (GenerateStudentRollNumberDTO != null) ? GenerateStudentRollNumberDTO.StudentCode : string.Empty;
            }
            set
            {
                GenerateStudentRollNumberDTO.StudentCode = value;
            }
        }
        public string Title
        {
            get
            {
                return (GenerateStudentRollNumberDTO != null) ? GenerateStudentRollNumberDTO.Title : string.Empty;
            }
            set
            {
                GenerateStudentRollNumberDTO.Title = value;
            }
        }
        public string NickName
        {
            get
            {
                return (GenerateStudentRollNumberDTO != null) ? GenerateStudentRollNumberDTO.NickName : string.Empty;
            }
            set
            {
                GenerateStudentRollNumberDTO.NickName = value;
            }
        }
        public string FirstName
        {
            get
            {
                return (GenerateStudentRollNumberDTO != null) ? GenerateStudentRollNumberDTO.FirstName : string.Empty;
            }
            set
            {
                GenerateStudentRollNumberDTO.FirstName = value;
            }
        }
        public string MiddleName
        {
            get
            {
                return (GenerateStudentRollNumberDTO != null) ? GenerateStudentRollNumberDTO.MiddleName : string.Empty;
            }
            set
            {
                GenerateStudentRollNumberDTO.MiddleName = value;
            }
        }
        public string LastName
        {
            get
            {
                return (GenerateStudentRollNumberDTO != null) ? GenerateStudentRollNumberDTO.LastName : string.Empty;
            }
            set
            {
                GenerateStudentRollNumberDTO.LastName = value;
            }
        }
        public string MotherName
        {
            get
            {
                return (GenerateStudentRollNumberDTO != null) ? GenerateStudentRollNumberDTO.MotherName : string.Empty;
            }
            set
            {
                GenerateStudentRollNumberDTO.MotherName = value;
            }
        }
        public string StudentOccupation
        {
            get
            {
                return (GenerateStudentRollNumberDTO != null) ? GenerateStudentRollNumberDTO.StudentOccupation : string.Empty;
            }
            set
            {
                GenerateStudentRollNumberDTO.StudentOccupation = value;
            }
        }
        public int StudentMobileNumber
        {
            get
            {
                return (GenerateStudentRollNumberDTO != null && GenerateStudentRollNumberDTO.StudentMobileNumber > 0) ? GenerateStudentRollNumberDTO.StudentMobileNumber : new int();
            }
            set
            {
                GenerateStudentRollNumberDTO.StudentMobileNumber = value;
            }
        }
        public int ParentMobileNumber
        {
            get
            {
                return (GenerateStudentRollNumberDTO != null && GenerateStudentRollNumberDTO.ParentMobileNumber > 0) ? GenerateStudentRollNumberDTO.ParentMobileNumber : new int();
            }
            set
            {
                GenerateStudentRollNumberDTO.ParentMobileNumber = value;
            }
        }
        public int GuardianMobileNumber
        {
            get
            {
                return (GenerateStudentRollNumberDTO != null && GenerateStudentRollNumberDTO.GuardianMobileNumber > 0) ? GenerateStudentRollNumberDTO.GuardianMobileNumber : new int();
            }
            set
            {
                GenerateStudentRollNumberDTO.GuardianMobileNumber = value;
            }
        }
        public int ParentLandlineNumber
        {
            get
            {
                return (GenerateStudentRollNumberDTO != null && GenerateStudentRollNumberDTO.ParentLandlineNumber > 0) ? GenerateStudentRollNumberDTO.ParentLandlineNumber : new int();
            }
            set
            {
                GenerateStudentRollNumberDTO.ParentLandlineNumber = value;
            }
        }
        public string ParentEmailID
        {
            get
            {
                return (GenerateStudentRollNumberDTO != null) ? GenerateStudentRollNumberDTO.ParentEmailID : string.Empty;
            }
            set
            {
                GenerateStudentRollNumberDTO.ParentEmailID = value;
            }
        }
        public string GuardianEmailID
        {
            get
            {
                return (GenerateStudentRollNumberDTO != null) ? GenerateStudentRollNumberDTO.GuardianEmailID : string.Empty;
            }
            set
            {
                GenerateStudentRollNumberDTO.GuardianEmailID = value;
            }
        }
        public string FatherEmailID
        {
            get
            {
                return (GenerateStudentRollNumberDTO != null) ? GenerateStudentRollNumberDTO.FatherEmailID : string.Empty;
            }
            set
            {
                GenerateStudentRollNumberDTO.FatherEmailID = value;
            }
        }
        public string MotherEmailID
        {
            get
            {
                return (GenerateStudentRollNumberDTO != null) ? GenerateStudentRollNumberDTO.MotherEmailID : string.Empty;
            }
            set
            {
                GenerateStudentRollNumberDTO.MotherEmailID = value;
            }
        }
        public string StudentEmailID
        {
            get
            {
                return (GenerateStudentRollNumberDTO != null) ? GenerateStudentRollNumberDTO.StudentEmailID : string.Empty;
            }
            set
            {
                GenerateStudentRollNumberDTO.StudentEmailID = value;
            }
        }
        public string NameAsPerLeaving
        {
            get
            {
                return (GenerateStudentRollNumberDTO != null) ? GenerateStudentRollNumberDTO.NameAsPerLeaving : string.Empty;
            }
            set
            {
                GenerateStudentRollNumberDTO.NameAsPerLeaving = value;
            }
        }
        public string LastSchoolCollegeAttend
        {
            get
            {
                return (GenerateStudentRollNumberDTO != null) ? GenerateStudentRollNumberDTO.LastSchoolCollegeAttend : string.Empty;
            }
            set
            {
                GenerateStudentRollNumberDTO.LastSchoolCollegeAttend = value;
            }
        }
        public int PreviousLeavingNumber
        {
            get
            {
                return (GenerateStudentRollNumberDTO != null && GenerateStudentRollNumberDTO.PreviousLeavingNumber > 0) ? GenerateStudentRollNumberDTO.PreviousLeavingNumber : new int();
            }
            set
            {
                GenerateStudentRollNumberDTO.PreviousLeavingNumber = value;
            }
        }
        public string CastAsPerLeaving
        {
            get
            {
                return (GenerateStudentRollNumberDTO != null) ? GenerateStudentRollNumberDTO.CastAsPerLeaving : string.Empty;
            }
            set
            {
                GenerateStudentRollNumberDTO.CastAsPerLeaving = value;
            }
        }
        public string LeavingDatetime
        {
            get
            {
                return (GenerateStudentRollNumberDTO != null) ? GenerateStudentRollNumberDTO.LeavingDatetime : string.Empty;
            }
            set
            {
                GenerateStudentRollNumberDTO.LeavingDatetime = value;
            }
        }
        public int EnrollmentNumber
        {
            get
            {
                return (GenerateStudentRollNumberDTO != null && GenerateStudentRollNumberDTO.EnrollmentNumber > 0) ? GenerateStudentRollNumberDTO.EnrollmentNumber : new int();
            }
            set
            {
                GenerateStudentRollNumberDTO.EnrollmentNumber = value;
            }
        }
        public Int16 DomicileStateID
        {
            get
            {
                return (GenerateStudentRollNumberDTO != null && GenerateStudentRollNumberDTO.DomicileStateID > 0) ? GenerateStudentRollNumberDTO.DomicileStateID : new Int16();
            }
            set
            {
                GenerateStudentRollNumberDTO.DomicileStateID = value;
            }
        }
        public Int16 DomicileCountryID
        {
            get
            {
                return (GenerateStudentRollNumberDTO != null && GenerateStudentRollNumberDTO.DomicileCountryID > 0) ? GenerateStudentRollNumberDTO.DomicileCountryID : new Int16();
            }
            set
            {
                GenerateStudentRollNumberDTO.DomicileCountryID = value;
            }
        }
        public int MigrationNumber
        {
            get
            {
                return (GenerateStudentRollNumberDTO != null && GenerateStudentRollNumberDTO.MigrationNumber > 0) ? GenerateStudentRollNumberDTO.MigrationNumber : new int();
            }
            set
            {
                GenerateStudentRollNumberDTO.MigrationNumber = value;
            }
        }
        public string MigrationDatetime
        {
            get
            {
                return (GenerateStudentRollNumberDTO != null) ? GenerateStudentRollNumberDTO.MigrationDatetime : string.Empty;
            }
            set
            {
                GenerateStudentRollNumberDTO.MigrationDatetime = value;
            }
        }
        //public string AdmissionNumber
        //{
        //    get
        //    {
        //        return (GenerateStudentRollNumberDTO != null) ? GenerateStudentRollNumberDTO.AdmissionNumber : string.Empty;
        //    }
        //    set
        //    {
        //        GenerateStudentRollNumberDTO.AdmissionNumber = value;
        //    }
        //}
        public int AdmissionCategoryID
        {
            get
            {
                return (GenerateStudentRollNumberDTO != null && GenerateStudentRollNumberDTO.AdmissionCategoryID > 0) ? GenerateStudentRollNumberDTO.AdmissionCategoryID : new int();
            }
            set
            {
                GenerateStudentRollNumberDTO.AdmissionCategoryID = value;
            }
        }
        public int AdmissionTypeID
        {
            get
            {
                return (GenerateStudentRollNumberDTO != null && GenerateStudentRollNumberDTO.AdmissionTypeID > 0) ? GenerateStudentRollNumberDTO.AdmissionTypeID : new int();
            }
            set
            {
                GenerateStudentRollNumberDTO.AdmissionTypeID = value;
            }
        }
        public int QuotaMstID
        {
            get
            {
                return (GenerateStudentRollNumberDTO != null && GenerateStudentRollNumberDTO.QuotaMstID > 0) ? GenerateStudentRollNumberDTO.QuotaMstID : new int();
            }
            set
            {
                GenerateStudentRollNumberDTO.QuotaMstID = value;
            }
        }
        public int SeatMstID
        {
            get
            {
                return (GenerateStudentRollNumberDTO != null && GenerateStudentRollNumberDTO.SeatMstID > 0) ? GenerateStudentRollNumberDTO.SeatMstID : new int();
            }
            set
            {
                GenerateStudentRollNumberDTO.SeatMstID = value;
            }
        }
        public bool IsHostelResidency
        {
            get
            {
                return (GenerateStudentRollNumberDTO != null) ? GenerateStudentRollNumberDTO.IsHostelResidency : false;
            }
            set
            {
                GenerateStudentRollNumberDTO.IsHostelResidency = value;
            }
        }
        public int RfidTagIDNo
        {
            get
            {
                return (GenerateStudentRollNumberDTO != null && GenerateStudentRollNumberDTO.RfidTagIDNo > 0) ? GenerateStudentRollNumberDTO.RfidTagIDNo : new int();
            }
            set
            {
                GenerateStudentRollNumberDTO.RfidTagIDNo = value;
            }
        }
        public int BranchID
        {
            get
            {
                return (GenerateStudentRollNumberDTO != null && GenerateStudentRollNumberDTO.BranchID > 0) ? GenerateStudentRollNumberDTO.BranchID : new int();
            }
            set
            {
                GenerateStudentRollNumberDTO.BranchID = value;
            }
        }
        public int FeeStructureID
        {
            get
            {
                return (GenerateStudentRollNumberDTO != null && GenerateStudentRollNumberDTO.FeeStructureID > 0) ? GenerateStudentRollNumberDTO.FeeStructureID : new int();
            }
            set
            {
                GenerateStudentRollNumberDTO.FeeStructureID = value;
            }
        }
        //public int SectionDetailID
        //{
        //    get
        //    {
        //        return (GenerateStudentRollNumberDTO != null && GenerateStudentRollNumberDTO.SectionDetailID > 0) ? GenerateStudentRollNumberDTO.SectionDetailID : new int();
        //    }
        //    set
        //    {
        //        GenerateStudentRollNumberDTO.SectionDetailID = value;
        //    }
        //}
        public int OldSectionDetailID
        {
            get
            {
                return (GenerateStudentRollNumberDTO != null && GenerateStudentRollNumberDTO.OldSectionDetailID > 0) ? GenerateStudentRollNumberDTO.OldSectionDetailID : new int();
            }
            set
            {
                GenerateStudentRollNumberDTO.OldSectionDetailID = value;
            }
        }
        public int CourseYearId
        {
            get
            {
                return (GenerateStudentRollNumberDTO != null && GenerateStudentRollNumberDTO.CourseYearId > 0) ? GenerateStudentRollNumberDTO.CourseYearId : new int();
            }
            set
            {
                GenerateStudentRollNumberDTO.CourseYearId = value;
            }
        }
        public int CourseYearOldId
        {
            get
            {
                return (GenerateStudentRollNumberDTO != null && GenerateStudentRollNumberDTO.CourseYearOldId > 0) ? GenerateStudentRollNumberDTO.CourseYearOldId : new int();
            }
            set
            {
                GenerateStudentRollNumberDTO.CourseYearOldId = value;
            }
        }
        public bool StudentActiveFlag
        {
            get
            {
                return (GenerateStudentRollNumberDTO != null) ? GenerateStudentRollNumberDTO.StudentActiveFlag : false;
            }
            set
            {
                GenerateStudentRollNumberDTO.StudentActiveFlag = value;
            }
        }
        public string StudentStatus
        {
            get
            {
                return (GenerateStudentRollNumberDTO != null) ? GenerateStudentRollNumberDTO.StudentStatus : string.Empty;
            }
            set
            {
                GenerateStudentRollNumberDTO.StudentStatus = value;
            }
        }
        //public string StatusCode
        //{
        //    get
        //    {
        //        return (GenerateStudentRollNumberDTO != null) ? GenerateStudentRollNumberDTO.StatusCode : string.Empty;
        //    }
        //    set
        //    {
        //        GenerateStudentRollNumberDTO.StatusCode = value;
        //    }
        //}
        public string StuAdmissionCode
        {
            get
            {
                return (GenerateStudentRollNumberDTO != null) ? GenerateStudentRollNumberDTO.StuAdmissionCode : string.Empty;
            }
            set
            {
                GenerateStudentRollNumberDTO.StuAdmissionCode = value;
            }
        }
        //public string AcademicYear
        //{
        //    get
        //    {
        //        return (GenerateStudentRollNumberDTO != null) ? GenerateStudentRollNumberDTO.AcademicYear : string.Empty;
        //    }
        //    set
        //    {
        //        GenerateStudentRollNumberDTO.AcademicYear = value;
        //    }
        //}
        public string AdmitAcademicYear
        {
            get
            {
                return (GenerateStudentRollNumberDTO != null) ? GenerateStudentRollNumberDTO.AdmitAcademicYear : string.Empty;
            }
            set
            {
                GenerateStudentRollNumberDTO.AdmitAcademicYear = value;
            }
        }
        public string StuAdmissionType
        {
            get
            {
                return (GenerateStudentRollNumberDTO != null) ? GenerateStudentRollNumberDTO.StuAdmissionType : string.Empty;
            }
            set
            {
                GenerateStudentRollNumberDTO.StuAdmissionType = value;
            }
        }
        public string QulifyingExamType
        {
            get
            {
                return (GenerateStudentRollNumberDTO != null) ? GenerateStudentRollNumberDTO.QulifyingExamType : string.Empty;
            }
            set
            {
                GenerateStudentRollNumberDTO.QulifyingExamType = value;
            }
        }
        public string FirstAdmissionDatetime
        {
            get
            {
                return (GenerateStudentRollNumberDTO != null) ? GenerateStudentRollNumberDTO.FirstAdmissionDatetime : string.Empty;
            }
            set
            {
                GenerateStudentRollNumberDTO.FirstAdmissionDatetime = value;
            }
        }
        //public string CentreCode
        //{
        //    get
        //    {
        //        return (GenerateStudentRollNumberDTO != null) ? GenerateStudentRollNumberDTO.CentreCode : string.Empty;
        //    }
        //    set
        //    {
        //        GenerateStudentRollNumberDTO.CentreCode = value;
        //    }
        //}
        public string AdmissionPattern
        {
            get
            {
                return (GenerateStudentRollNumberDTO != null) ? GenerateStudentRollNumberDTO.AdmissionPattern : string.Empty;
            }
            set
            {
                GenerateStudentRollNumberDTO.AdmissionPattern = value;
            }
        }
        public int TransferSectionID
        {
            get
            {
                return (GenerateStudentRollNumberDTO != null && GenerateStudentRollNumberDTO.TransferSectionID > 0) ? GenerateStudentRollNumberDTO.TransferSectionID : new int();
            }
            set
            {
                GenerateStudentRollNumberDTO.TransferSectionID = value;
            }
        }
        public int RegistrationID
        {
            get
            {
                return (GenerateStudentRollNumberDTO != null && GenerateStudentRollNumberDTO.RegistrationID > 0) ? GenerateStudentRollNumberDTO.RegistrationID : new int();
            }
            set
            {
                GenerateStudentRollNumberDTO.RegistrationID = value;
            }
        }
        public bool IsDomicleFromLast3Year
        {
            get
            {
                return (GenerateStudentRollNumberDTO != null) ? GenerateStudentRollNumberDTO.IsDomicleFromLast3Year : false;
            }
            set
            {
                GenerateStudentRollNumberDTO.IsDomicleFromLast3Year = value;
            }
        }
        public bool IsNriPoi
        {
            get
            {
                return (GenerateStudentRollNumberDTO != null) ? GenerateStudentRollNumberDTO.IsNriPoi : false;
            }
            set
            {
                GenerateStudentRollNumberDTO.IsNriPoi = value;
            }
        }
        public int TransferCoursesYearId
        {
            get
            {
                return (GenerateStudentRollNumberDTO != null && GenerateStudentRollNumberDTO.TransferCoursesYearId > 0) ? GenerateStudentRollNumberDTO.TransferCoursesYearId : new int();
            }
            set
            {
                GenerateStudentRollNumberDTO.TransferCoursesYearId = value;
            }
        }
        public string DirectSecYrAdmissionMode
        {
            get
            {
                return (GenerateStudentRollNumberDTO != null) ? GenerateStudentRollNumberDTO.DirectSecYrAdmissionMode : string.Empty;
            }
            set
            {
                GenerateStudentRollNumberDTO.DirectSecYrAdmissionMode = value;
            }
        }
        public string AdmittedInShift
        {
            get
            {
                return (GenerateStudentRollNumberDTO != null) ? GenerateStudentRollNumberDTO.AdmittedInShift : string.Empty;
            }
            set
            {
                GenerateStudentRollNumberDTO.AdmittedInShift = value;
            }
        }
        public string AllotAdmThrough
        {
            get
            {
                return (GenerateStudentRollNumberDTO != null) ? GenerateStudentRollNumberDTO.AllotAdmThrough : string.Empty;
            }
            set
            {
                GenerateStudentRollNumberDTO.AllotAdmThrough = value;
            }
        }
        public int BankAccountNumber
        {
            get
            {
                return (GenerateStudentRollNumberDTO != null && GenerateStudentRollNumberDTO.BankAccountNumber > 0) ? GenerateStudentRollNumberDTO.BankAccountNumber : new int();
            }
            set
            {
                GenerateStudentRollNumberDTO.BankAccountNumber = value;
            }
        }
        public string BankBranchName
        {
            get
            {
                return (GenerateStudentRollNumberDTO != null) ? GenerateStudentRollNumberDTO.BankBranchName : string.Empty;
            }
            set
            {
                GenerateStudentRollNumberDTO.BankBranchName = value;
            }
        }
        public string BankBranchCity
        {
            get
            {
                return (GenerateStudentRollNumberDTO != null) ? GenerateStudentRollNumberDTO.BankBranchCity : string.Empty;
            }
            set
            {
                GenerateStudentRollNumberDTO.BankBranchCity = value;
            }
        }
        public int UniqueIdentificatinNumber
        {
            get
            {
                return (GenerateStudentRollNumberDTO != null && GenerateStudentRollNumberDTO.UniqueIdentificatinNumber > 0) ? GenerateStudentRollNumberDTO.UniqueIdentificatinNumber : new int();
            }
            set
            {
                GenerateStudentRollNumberDTO.UniqueIdentificatinNumber = value;
            }
        }
        public string IdentificationType
        {
            get
            {
                return (GenerateStudentRollNumberDTO != null) ? GenerateStudentRollNumberDTO.IdentificationType : string.Empty;
            }
            set
            {
                GenerateStudentRollNumberDTO.IdentificationType = value;
            }
        }
        [Display(Name = "DisplayName_IsFirstYearPromotion", ResourceType = typeof(AMS.Common.Resources))]
        public bool IsFirstYearPromotion
        {
            get
            {
                return (GenerateStudentRollNumberDTO != null) ? GenerateStudentRollNumberDTO.IsFirstYearPromotion : false;
            }
            set
            {
                GenerateStudentRollNumberDTO.IsFirstYearPromotion = value;
            }
        }
        public string ScopeIdentity
                {
                    get
                    {
                        return (GenerateStudentRollNumberDTO != null) ? GenerateStudentRollNumberDTO.ScopeIdentity : string.Empty;
                    }
                    set
                    {
                        GenerateStudentRollNumberDTO.ScopeIdentity = value;
                    }
                }
        public int StudentAdmissionDetailId
        {
            get
            {
                return (GenerateStudentRollNumberDTO != null && GenerateStudentRollNumberDTO.StudentAdmissionDetailId > 0) ? GenerateStudentRollNumberDTO.StudentAdmissionDetailId : new int();
            }
            set
            {
                GenerateStudentRollNumberDTO.StudentAdmissionDetailId = value;
            }
        }
        public int NextSectionDetailID
        {
            get
            {
                return (GenerateStudentRollNumberDTO != null && GenerateStudentRollNumberDTO.NextSectionDetailID > 0) ? GenerateStudentRollNumberDTO.NextSectionDetailID : new int();
            }
            set
            {
                GenerateStudentRollNumberDTO.NextSectionDetailID = value;
            }
        }
    }
}
