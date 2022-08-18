using AMS.Common;
using AMS.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AMS.ViewModel
{
    public class BranchPromotionViewModel : IBranchPromotionViewModel
    {
        public BranchPromotionViewModel()
        {
            ListOrganisationDepartmentMaster = new List<OrganisationDepartmentMaster>();
            ListOrganisationStudyCentreMaster = new List<OrganisationStudyCentreMaster>();
            ListBranchRoleWise = new List<OrganisationBranchMaster>();
            ListOrganisationUniversityMaster = new List<OrganisationUniversityMaster>();
            ListNextCourseYearDetails = new List<OrganisationCourseYearDetails>();
            ListOrganisationSectionDetailsRoleWise = new List<OrganisationSectionDetails>();
            ListNextSectionPromotionList = new List<OrganisationSectionDetails>();
            ListOrganisationCentrewiseSession = new List<OrganisationCentrewiseSession>();
            BranchPromotionDTO = new BranchPromotion();
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


        public BranchPromotion BranchPromotionDTO
        {
            get;
            set;
        }

        public int ID
        {
            get
            {
                return (BranchPromotionDTO != null && BranchPromotionDTO.ID > 0) ? BranchPromotionDTO.ID : new int();
            }
            set
            {
                BranchPromotionDTO.ID = value;
            }
        }
        public int StudentId
        {
            get
            {
                return (BranchPromotionDTO != null && BranchPromotionDTO.StudentId > 0) ? BranchPromotionDTO.StudentId : new int();
            }
            set
            {
                BranchPromotionDTO.StudentId = value;
            }
        }

        [Display(Name = "DisplayName_StudentName", ResourceType = typeof(AMS.Common.Resources))]
        public string StudentName
        {
            get
            {
                return (BranchPromotionDTO != null) ? BranchPromotionDTO.StudentName : string.Empty;
            }
            set
            {
                BranchPromotionDTO.StudentName = value;
            }
        }
        public string FormNumber
        {
            get
            {
                return (BranchPromotionDTO != null) ? BranchPromotionDTO.FormNumber : string.Empty;
            }
            set
            {
                BranchPromotionDTO.FormNumber = value;
            }
        }
        public string FormDate
        {
            get
            {
                return (BranchPromotionDTO != null) ? BranchPromotionDTO.FormDate : string.Empty;
            }
            set
            {
                BranchPromotionDTO.FormDate = value;
            }
        }
        [Display(Name = "DisplayName_SectionDetailID", ResourceType = typeof(AMS.Common.Resources))]
        public int SectionDetailID
        {
            get
            {
                return (BranchPromotionDTO != null && BranchPromotionDTO.SectionDetailID > 0) ? BranchPromotionDTO.SectionDetailID : new int();
            }
            set
            {
                BranchPromotionDTO.SectionDetailID = value;
            }
        }

        [Display(Name = "DisplayName_SectionDetails", ResourceType = typeof(AMS.Common.Resources))]
        public string SectionDetails
        {
            get
            {
                return (BranchPromotionDTO != null) ? BranchPromotionDTO.SectionDetails : string.Empty;
            }
            set
            {
                BranchPromotionDTO.SectionDetails = value;
            }
        }

          [Display(Name = "DisplayName_PromotedToNextSection", ResourceType = typeof(AMS.Common.Resources))]
        public string PromotedToNextSection
        {
            get
            {
                return (BranchPromotionDTO != null) ? BranchPromotionDTO.PromotedToNextSection : string.Empty;
            }
            set
            {
                BranchPromotionDTO.PromotedToNextSection = value;
            }
        }

        public string NextSectionDescription
        {
            get
            {
                return (BranchPromotionDTO != null) ? BranchPromotionDTO.NextSectionDescription : string.Empty;
            }
            set
            {
                BranchPromotionDTO.NextSectionDescription = value;
            }
        }
        [Display(Name = "DisplayName_AdmissionDate", ResourceType = typeof(AMS.Common.Resources))]
        public string AdmissionDate
        {
            get
            {
                return (BranchPromotionDTO != null) ? BranchPromotionDTO.AdmissionDate : string.Empty;
            }
            set
            {
                BranchPromotionDTO.AdmissionDate = value;
            }
        }
        public bool AdmissionActiveFlag
        {
            get
            {
                return (BranchPromotionDTO != null) ? BranchPromotionDTO.AdmissionActiveFlag : false;
            }
            set
            {
                BranchPromotionDTO.AdmissionActiveFlag = value;
            }
        }

        [Display(Name = "DisplayName_AcademicYear", ResourceType = typeof(AMS.Common.Resources))]
        public string AcademicYear
        {
            get
            {
                return (BranchPromotionDTO != null) ? BranchPromotionDTO.AcademicYear : string.Empty;
            }
            set
            {
                BranchPromotionDTO.AcademicYear = value;
            }
        }
        public string YearlyRollNumber
        {
            get
            {
                return (BranchPromotionDTO != null) ? BranchPromotionDTO.YearlyRollNumber : string.Empty;
            }
            set
            {
                BranchPromotionDTO.YearlyRollNumber = value;
            }
        }
        public string RollNoSortOrder
        {
            get
            {
                return (BranchPromotionDTO != null) ? BranchPromotionDTO.RollNoSortOrder : string.Empty;
            }
            set
            {
                BranchPromotionDTO.RollNoSortOrder = value;
            }
        }
        public string SortOrderStatus
        {
            get
            {
                return (BranchPromotionDTO != null) ? BranchPromotionDTO.SortOrderStatus : string.Empty;
            }
            set
            {
                BranchPromotionDTO.SortOrderStatus = value;
            }
        }
        public string FromSession
        {
            get
            {
                return (BranchPromotionDTO != null) ? BranchPromotionDTO.FromSession : string.Empty;
            }
            set
            {
                BranchPromotionDTO.FromSession = value;
            }
        }
        public string UptoSession
        {
            get
            {
                return (BranchPromotionDTO != null) ? BranchPromotionDTO.UptoSession : string.Empty;
            }
            set
            {
                BranchPromotionDTO.UptoSession = value;
            }
        }
        public string ResultStatus
        {
            get
            {
                return (BranchPromotionDTO != null) ? BranchPromotionDTO.ResultStatus : string.Empty;
            }
            set
            {
                BranchPromotionDTO.ResultStatus = value;
            }
        }
        public bool AdmissionCancelStatus
        {
            get
            {
                return (BranchPromotionDTO != null) ? BranchPromotionDTO.AdmissionCancelStatus : false;
            }
            set
            {
                BranchPromotionDTO.AdmissionCancelStatus = value;
            }
        }
        public string AdmissionStatus
        {
            get
            {
                return (BranchPromotionDTO != null) ? BranchPromotionDTO.AdmissionStatus : string.Empty;
            }
            set
            {
                BranchPromotionDTO.AdmissionStatus = value;
            }
        }
        public string AdmissionCancelDate
        {
            get
            {
                return (BranchPromotionDTO != null) ? BranchPromotionDTO.AdmissionCancelDate : string.Empty;
            }
            set
            {
                BranchPromotionDTO.AdmissionCancelDate = value;
            }
        }
        public int BranchId
        {
            get
            {
                return (BranchPromotionDTO != null && BranchPromotionDTO.BranchId > 0) ? BranchPromotionDTO.BranchId : new int();
            }
            set
            {
                BranchPromotionDTO.BranchId = value;
            }
        }
        public string PromotedToNextBranch
        {
            get
            {
                return (BranchPromotionDTO != null) ? BranchPromotionDTO.PromotedToNextBranch : string.Empty;
            }
            set
            {
                BranchPromotionDTO.PromotedToNextBranch = value;
            }
        }
        public string StatusCode
        {
            get
            {
                return (BranchPromotionDTO != null) ? BranchPromotionDTO.StatusCode : string.Empty;
            }
            set
            {
                BranchPromotionDTO.StatusCode = value;
            }
        }
        public string AdmissionConfirmDate
        {
            get
            {
                return (BranchPromotionDTO != null) ? BranchPromotionDTO.AdmissionConfirmDate : string.Empty;
            }
            set
            {
                BranchPromotionDTO.AdmissionConfirmDate = value;
            }
        }
        public string AdmissionPromoteDate
        {
            get
            {
                return (BranchPromotionDTO != null) ? BranchPromotionDTO.AdmissionPromoteDate : string.Empty;
            }
            set
            {
                BranchPromotionDTO.AdmissionPromoteDate = value;
            }
        }
        public string CentreCode
        {
            get
            {
                return (BranchPromotionDTO != null) ? BranchPromotionDTO.CentreCode : string.Empty;
            }
            set
            {
                BranchPromotionDTO.CentreCode = value;
            }
        }
        public string Remark
        {
            get
            {
                return (BranchPromotionDTO != null) ? BranchPromotionDTO.Remark : string.Empty;
            }
            set
            {
                BranchPromotionDTO.Remark = value;
            }
        }

        [Display(Name = "DisplayName_AdmissionNumber", ResourceType = typeof(AMS.Common.Resources))]
        public string AdmissionNumber
        {
            get
            {
                return (BranchPromotionDTO != null) ? BranchPromotionDTO.AdmissionNumber : string.Empty;
            }
            set
            {
                BranchPromotionDTO.AdmissionNumber = value;
            }
        }
        public string PrevExamSeatNo
        {
            get
            {
                return (BranchPromotionDTO != null) ? BranchPromotionDTO.PrevExamSeatNo : string.Empty;
            }
            set
            {
                BranchPromotionDTO.PrevExamSeatNo = value;
            }
        }
        public string EligibForCuryrAdmsn
        {
            get
            {
                return (BranchPromotionDTO != null) ? BranchPromotionDTO.EligibForCuryrAdmsn : string.Empty;
            }
            set
            {
                BranchPromotionDTO.EligibForCuryrAdmsn = value;
            }
        }
        public string ResultCurYear
        {
            get
            {
                return (BranchPromotionDTO != null) ? BranchPromotionDTO.ResultCurYear : string.Empty;
            }
            set
            {
                BranchPromotionDTO.ResultCurYear = value;
            }
        }
        public string DtndForSemester
        {
            get
            {
                return (BranchPromotionDTO != null) ? BranchPromotionDTO.DtndForSemester : string.Empty;
            }
            set
            {
                BranchPromotionDTO.DtndForSemester = value;
            }
        }
        public string SemesterSpecificAdmsn
        {
            get
            {
                return (BranchPromotionDTO != null) ? BranchPromotionDTO.SemesterSpecificAdmsn : string.Empty;
            }
            set
            {
                BranchPromotionDTO.SemesterSpecificAdmsn = value;
            }
        }
        public int StuRevalAppliId
        {
            get
            {
                return (BranchPromotionDTO != null && BranchPromotionDTO.StuRevalAppliId > 0) ? BranchPromotionDTO.StuRevalAppliId : new int();
            }
            set
            {
                BranchPromotionDTO.StuRevalAppliId = value;
            }
        }
        public string ProvisionalType
        {
            get
            {
                return (BranchPromotionDTO != null) ? BranchPromotionDTO.ProvisionalType : string.Empty;
            }
            set
            {
                BranchPromotionDTO.ProvisionalType = value;
            }
        }
        public string AdmissionFinalStatus
        {
            get
            {
                return (BranchPromotionDTO != null) ? BranchPromotionDTO.AdmissionFinalStatus : string.Empty;
            }
            set
            {
                BranchPromotionDTO.AdmissionFinalStatus = value;
            }
        }
        public bool IsActive
        {
            get
            {
                return (BranchPromotionDTO != null) ? BranchPromotionDTO.IsActive : false;
            }
            set
            {
                BranchPromotionDTO.IsActive = value;
            }
        }
        public bool IsDeleted
        {
            get
            {
                return (BranchPromotionDTO != null) ? BranchPromotionDTO.IsDeleted : false;
            }
            set
            {
                BranchPromotionDTO.IsDeleted = value;
            }
        }
        public int CreatedBy
        {
            get
            {
                return (BranchPromotionDTO != null && BranchPromotionDTO.CreatedBy > 0) ? BranchPromotionDTO.CreatedBy : new int();
            }
            set
            {
                BranchPromotionDTO.CreatedBy = value;
            }
        }
        public DateTime CreatedDate
        {
            get
            {
                return (BranchPromotionDTO != null) ? BranchPromotionDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                BranchPromotionDTO.CreatedDate = value;
            }
        }
        public int? ModifiedBy
        {
            get
            {
                return (BranchPromotionDTO != null && BranchPromotionDTO.ModifiedBy > 0) ? BranchPromotionDTO.ModifiedBy : new int();
            }
            set
            {
                BranchPromotionDTO.ModifiedBy = value;
            }
        }
        public DateTime? ModifiedDate
        {
            get
            {
                return (BranchPromotionDTO != null) ? BranchPromotionDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                BranchPromotionDTO.ModifiedDate = value;
            }
        }
        public int? DeletedBy
        {
            get
            {
                return (BranchPromotionDTO != null && BranchPromotionDTO.DeletedBy > 0) ? BranchPromotionDTO.DeletedBy : new int();
            }
            set
            {
                BranchPromotionDTO.DeletedBy = value;
            }
        }
        public DateTime? DeletedDate
        {
            get
            {
                return (BranchPromotionDTO != null) ? BranchPromotionDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                BranchPromotionDTO.DeletedDate = value;
            }
        }

        [Display(Name = "DisplayName_BranchDescription", ResourceType = typeof(AMS.Common.Resources))]
        public string BranchDescription
        {
            get
            {
                return (BranchPromotionDTO != null) ? BranchPromotionDTO.BranchDescription : string.Empty;
            }
            set
            {
                BranchPromotionDTO.BranchDescription = value;
            }
        }

        [Display(Name = "DisplayName_CourseYearDesc", ResourceType = typeof(AMS.Common.Resources))]
        public string CourseYearDesc
        {
            get
            {
                return (BranchPromotionDTO != null) ? BranchPromotionDTO.CourseYearDesc : string.Empty;
            }
            set
            {
                BranchPromotionDTO.CourseYearDesc = value;
            }
        }

        [Display(Name = "DisplayName_SectionDesc", ResourceType = typeof(AMS.Common.Resources))]
        public string SectionDesc
        {
            get
            {
                return (BranchPromotionDTO != null) ? BranchPromotionDTO.SectionDesc : string.Empty;
            }
            set
            {
                BranchPromotionDTO.SectionDesc = value;
            }
        }

        [Display(Name = "DisplayName_SessionName", ResourceType = typeof(AMS.Common.Resources))]
        public string SessionName
        {
            get
            {
                return (BranchPromotionDTO != null) ? BranchPromotionDTO.SessionName : string.Empty;
            }
            set
            {
                BranchPromotionDTO.SessionName = value;
            }
        }
        public int SessionID
        {
            get
            {
                return (BranchPromotionDTO != null && BranchPromotionDTO.SessionID > 0) ? BranchPromotionDTO.SessionID : new int();
            }
            set
            {
                BranchPromotionDTO.SessionID = value;
            }
        }

        [Display(Name = "DisplayName_CentreName", ResourceType = typeof(AMS.Common.Resources))]
        public string CentreName
        {
            get
            {
                return (BranchPromotionDTO != null) ? BranchPromotionDTO.CentreName : string.Empty;
            }
            set
            {
                BranchPromotionDTO.CentreName = value;
            }
        }
        public string errorMessage { get; set; }

        public string PromotedStudentList
        {
            get
            {
                return (BranchPromotionDTO != null) ? BranchPromotionDTO.PromotedStudentList : string.Empty;
            }
            set
            {
                BranchPromotionDTO.PromotedStudentList = value;
            }
        }





        //--------------------------Properties of StuStudentMaster--------------------------------------//
        public string StudentCode
        {
            get
            {
                return (BranchPromotionDTO != null) ? BranchPromotionDTO.StudentCode : string.Empty;
            }
            set
            {
                BranchPromotionDTO.StudentCode = value;
            }
        }
        public string Title
        {
            get
            {
                return (BranchPromotionDTO != null) ? BranchPromotionDTO.Title : string.Empty;
            }
            set
            {
                BranchPromotionDTO.Title = value;
            }
        }
        public string NickName
        {
            get
            {
                return (BranchPromotionDTO != null) ? BranchPromotionDTO.NickName : string.Empty;
            }
            set
            {
                BranchPromotionDTO.NickName = value;
            }
        }
        public string FirstName
        {
            get
            {
                return (BranchPromotionDTO != null) ? BranchPromotionDTO.FirstName : string.Empty;
            }
            set
            {
                BranchPromotionDTO.FirstName = value;
            }
        }
        public string MiddleName
        {
            get
            {
                return (BranchPromotionDTO != null) ? BranchPromotionDTO.MiddleName : string.Empty;
            }
            set
            {
                BranchPromotionDTO.MiddleName = value;
            }
        }
        public string LastName
        {
            get
            {
                return (BranchPromotionDTO != null) ? BranchPromotionDTO.LastName : string.Empty;
            }
            set
            {
                BranchPromotionDTO.LastName = value;
            }
        }
        public string MotherName
        {
            get
            {
                return (BranchPromotionDTO != null) ? BranchPromotionDTO.MotherName : string.Empty;
            }
            set
            {
                BranchPromotionDTO.MotherName = value;
            }
        }
        public string StudentOccupation
        {
            get
            {
                return (BranchPromotionDTO != null) ? BranchPromotionDTO.StudentOccupation : string.Empty;
            }
            set
            {
                BranchPromotionDTO.StudentOccupation = value;
            }
        }
        public int StudentMobileNumber
        {
            get
            {
                return (BranchPromotionDTO != null && BranchPromotionDTO.StudentMobileNumber > 0) ? BranchPromotionDTO.StudentMobileNumber : new int();
            }
            set
            {
                BranchPromotionDTO.StudentMobileNumber = value;
            }
        }
        public int ParentMobileNumber
        {
            get
            {
                return (BranchPromotionDTO != null && BranchPromotionDTO.ParentMobileNumber > 0) ? BranchPromotionDTO.ParentMobileNumber : new int();
            }
            set
            {
                BranchPromotionDTO.ParentMobileNumber = value;
            }
        }
        public int GuardianMobileNumber
        {
            get
            {
                return (BranchPromotionDTO != null && BranchPromotionDTO.GuardianMobileNumber > 0) ? BranchPromotionDTO.GuardianMobileNumber : new int();
            }
            set
            {
                BranchPromotionDTO.GuardianMobileNumber = value;
            }
        }
        public int ParentLandlineNumber
        {
            get
            {
                return (BranchPromotionDTO != null && BranchPromotionDTO.ParentLandlineNumber > 0) ? BranchPromotionDTO.ParentLandlineNumber : new int();
            }
            set
            {
                BranchPromotionDTO.ParentLandlineNumber = value;
            }
        }
        public string ParentEmailID
        {
            get
            {
                return (BranchPromotionDTO != null) ? BranchPromotionDTO.ParentEmailID : string.Empty;
            }
            set
            {
                BranchPromotionDTO.ParentEmailID = value;
            }
        }
        public string GuardianEmailID
        {
            get
            {
                return (BranchPromotionDTO != null) ? BranchPromotionDTO.GuardianEmailID : string.Empty;
            }
            set
            {
                BranchPromotionDTO.GuardianEmailID = value;
            }
        }
        public string FatherEmailID
        {
            get
            {
                return (BranchPromotionDTO != null) ? BranchPromotionDTO.FatherEmailID : string.Empty;
            }
            set
            {
                BranchPromotionDTO.FatherEmailID = value;
            }
        }
        public string MotherEmailID
        {
            get
            {
                return (BranchPromotionDTO != null) ? BranchPromotionDTO.MotherEmailID : string.Empty;
            }
            set
            {
                BranchPromotionDTO.MotherEmailID = value;
            }
        }
        public string StudentEmailID
        {
            get
            {
                return (BranchPromotionDTO != null) ? BranchPromotionDTO.StudentEmailID : string.Empty;
            }
            set
            {
                BranchPromotionDTO.StudentEmailID = value;
            }
        }
        public string NameAsPerLeaving
        {
            get
            {
                return (BranchPromotionDTO != null) ? BranchPromotionDTO.NameAsPerLeaving : string.Empty;
            }
            set
            {
                BranchPromotionDTO.NameAsPerLeaving = value;
            }
        }
        public string LastSchoolCollegeAttend
        {
            get
            {
                return (BranchPromotionDTO != null) ? BranchPromotionDTO.LastSchoolCollegeAttend : string.Empty;
            }
            set
            {
                BranchPromotionDTO.LastSchoolCollegeAttend = value;
            }
        }
        public int PreviousLeavingNumber
        {
            get
            {
                return (BranchPromotionDTO != null && BranchPromotionDTO.PreviousLeavingNumber > 0) ? BranchPromotionDTO.PreviousLeavingNumber : new int();
            }
            set
            {
                BranchPromotionDTO.PreviousLeavingNumber = value;
            }
        }
        public string CastAsPerLeaving
        {
            get
            {
                return (BranchPromotionDTO != null) ? BranchPromotionDTO.CastAsPerLeaving : string.Empty;
            }
            set
            {
                BranchPromotionDTO.CastAsPerLeaving = value;
            }
        }
        public string LeavingDatetime
        {
            get
            {
                return (BranchPromotionDTO != null) ? BranchPromotionDTO.LeavingDatetime : string.Empty;
            }
            set
            {
                BranchPromotionDTO.LeavingDatetime = value;
            }
        }
        public int EnrollmentNumber
        {
            get
            {
                return (BranchPromotionDTO != null && BranchPromotionDTO.EnrollmentNumber > 0) ? BranchPromotionDTO.EnrollmentNumber : new int();
            }
            set
            {
                BranchPromotionDTO.EnrollmentNumber = value;
            }
        }
        public Int16 DomicileStateID
        {
            get
            {
                return (BranchPromotionDTO != null && BranchPromotionDTO.DomicileStateID > 0) ? BranchPromotionDTO.DomicileStateID : new Int16();
            }
            set
            {
                BranchPromotionDTO.DomicileStateID = value;
            }
        }
        public Int16 DomicileCountryID
        {
            get
            {
                return (BranchPromotionDTO != null && BranchPromotionDTO.DomicileCountryID > 0) ? BranchPromotionDTO.DomicileCountryID : new Int16();
            }
            set
            {
                BranchPromotionDTO.DomicileCountryID = value;
            }
        }
        public int MigrationNumber
        {
            get
            {
                return (BranchPromotionDTO != null && BranchPromotionDTO.MigrationNumber > 0) ? BranchPromotionDTO.MigrationNumber : new int();
            }
            set
            {
                BranchPromotionDTO.MigrationNumber = value;
            }
        }
        public string MigrationDatetime
        {
            get
            {
                return (BranchPromotionDTO != null) ? BranchPromotionDTO.MigrationDatetime : string.Empty;
            }
            set
            {
                BranchPromotionDTO.MigrationDatetime = value;
            }
        }
        //public string AdmissionNumber
        //{
        //    get
        //    {
        //        return (BranchPromotionDTO != null) ? BranchPromotionDTO.AdmissionNumber : string.Empty;
        //    }
        //    set
        //    {
        //        BranchPromotionDTO.AdmissionNumber = value;
        //    }
        //}
        public int AdmissionCategoryID
        {
            get
            {
                return (BranchPromotionDTO != null && BranchPromotionDTO.AdmissionCategoryID > 0) ? BranchPromotionDTO.AdmissionCategoryID : new int();
            }
            set
            {
                BranchPromotionDTO.AdmissionCategoryID = value;
            }
        }
        public int AdmissionTypeID
        {
            get
            {
                return (BranchPromotionDTO != null && BranchPromotionDTO.AdmissionTypeID > 0) ? BranchPromotionDTO.AdmissionTypeID : new int();
            }
            set
            {
                BranchPromotionDTO.AdmissionTypeID = value;
            }
        }
        public int QuotaMstID
        {
            get
            {
                return (BranchPromotionDTO != null && BranchPromotionDTO.QuotaMstID > 0) ? BranchPromotionDTO.QuotaMstID : new int();
            }
            set
            {
                BranchPromotionDTO.QuotaMstID = value;
            }
        }
        public int SeatMstID
        {
            get
            {
                return (BranchPromotionDTO != null && BranchPromotionDTO.SeatMstID > 0) ? BranchPromotionDTO.SeatMstID : new int();
            }
            set
            {
                BranchPromotionDTO.SeatMstID = value;
            }
        }
        public bool IsHostelResidency
        {
            get
            {
                return (BranchPromotionDTO != null) ? BranchPromotionDTO.IsHostelResidency : false;
            }
            set
            {
                BranchPromotionDTO.IsHostelResidency = value;
            }
        }
        public int RfidTagIDNo
        {
            get
            {
                return (BranchPromotionDTO != null && BranchPromotionDTO.RfidTagIDNo > 0) ? BranchPromotionDTO.RfidTagIDNo : new int();
            }
            set
            {
                BranchPromotionDTO.RfidTagIDNo = value;
            }
        }
        public int BranchID
        {
            get
            {
                return (BranchPromotionDTO != null && BranchPromotionDTO.BranchID > 0) ? BranchPromotionDTO.BranchID : new int();
            }
            set
            {
                BranchPromotionDTO.BranchID = value;
            }
        }
        public int FeeStructureID
        {
            get
            {
                return (BranchPromotionDTO != null && BranchPromotionDTO.FeeStructureID > 0) ? BranchPromotionDTO.FeeStructureID : new int();
            }
            set
            {
                BranchPromotionDTO.FeeStructureID = value;
            }
        }
        //public int SectionDetailID
        //{
        //    get
        //    {
        //        return (BranchPromotionDTO != null && BranchPromotionDTO.SectionDetailID > 0) ? BranchPromotionDTO.SectionDetailID : new int();
        //    }
        //    set
        //    {
        //        BranchPromotionDTO.SectionDetailID = value;
        //    }
        //}
        public int OldSectionDetailID
        {
            get
            {
                return (BranchPromotionDTO != null && BranchPromotionDTO.OldSectionDetailID > 0) ? BranchPromotionDTO.OldSectionDetailID : new int();
            }
            set
            {
                BranchPromotionDTO.OldSectionDetailID = value;
            }
        }
        public int CourseYearId
        {
            get
            {
                return (BranchPromotionDTO != null && BranchPromotionDTO.CourseYearId > 0) ? BranchPromotionDTO.CourseYearId : new int();
            }
            set
            {
                BranchPromotionDTO.CourseYearId = value;
            }
        }
        public int CourseYearOldId
        {
            get
            {
                return (BranchPromotionDTO != null && BranchPromotionDTO.CourseYearOldId > 0) ? BranchPromotionDTO.CourseYearOldId : new int();
            }
            set
            {
                BranchPromotionDTO.CourseYearOldId = value;
            }
        }
        public bool StudentActiveFlag
        {
            get
            {
                return (BranchPromotionDTO != null) ? BranchPromotionDTO.StudentActiveFlag : false;
            }
            set
            {
                BranchPromotionDTO.StudentActiveFlag = value;
            }
        }
        public string StudentStatus
        {
            get
            {
                return (BranchPromotionDTO != null) ? BranchPromotionDTO.StudentStatus : string.Empty;
            }
            set
            {
                BranchPromotionDTO.StudentStatus = value;
            }
        }
        //public string StatusCode
        //{
        //    get
        //    {
        //        return (BranchPromotionDTO != null) ? BranchPromotionDTO.StatusCode : string.Empty;
        //    }
        //    set
        //    {
        //        BranchPromotionDTO.StatusCode = value;
        //    }
        //}
        public string StuAdmissionCode
        {
            get
            {
                return (BranchPromotionDTO != null) ? BranchPromotionDTO.StuAdmissionCode : string.Empty;
            }
            set
            {
                BranchPromotionDTO.StuAdmissionCode = value;
            }
        }
        //public string AcademicYear
        //{
        //    get
        //    {
        //        return (BranchPromotionDTO != null) ? BranchPromotionDTO.AcademicYear : string.Empty;
        //    }
        //    set
        //    {
        //        BranchPromotionDTO.AcademicYear = value;
        //    }
        //}
        public string AdmitAcademicYear
        {
            get
            {
                return (BranchPromotionDTO != null) ? BranchPromotionDTO.AdmitAcademicYear : string.Empty;
            }
            set
            {
                BranchPromotionDTO.AdmitAcademicYear = value;
            }
        }
        public string StuAdmissionType
        {
            get
            {
                return (BranchPromotionDTO != null) ? BranchPromotionDTO.StuAdmissionType : string.Empty;
            }
            set
            {
                BranchPromotionDTO.StuAdmissionType = value;
            }
        }
        public string QulifyingExamType
        {
            get
            {
                return (BranchPromotionDTO != null) ? BranchPromotionDTO.QulifyingExamType : string.Empty;
            }
            set
            {
                BranchPromotionDTO.QulifyingExamType = value;
            }
        }
        public string FirstAdmissionDatetime
        {
            get
            {
                return (BranchPromotionDTO != null) ? BranchPromotionDTO.FirstAdmissionDatetime : string.Empty;
            }
            set
            {
                BranchPromotionDTO.FirstAdmissionDatetime = value;
            }
        }
        //public string CentreCode
        //{
        //    get
        //    {
        //        return (BranchPromotionDTO != null) ? BranchPromotionDTO.CentreCode : string.Empty;
        //    }
        //    set
        //    {
        //        BranchPromotionDTO.CentreCode = value;
        //    }
        //}
        public string AdmissionPattern
        {
            get
            {
                return (BranchPromotionDTO != null) ? BranchPromotionDTO.AdmissionPattern : string.Empty;
            }
            set
            {
                BranchPromotionDTO.AdmissionPattern = value;
            }
        }
        public int TransferSectionID
        {
            get
            {
                return (BranchPromotionDTO != null && BranchPromotionDTO.TransferSectionID > 0) ? BranchPromotionDTO.TransferSectionID : new int();
            }
            set
            {
                BranchPromotionDTO.TransferSectionID = value;
            }
        }
        public int RegistrationID
        {
            get
            {
                return (BranchPromotionDTO != null && BranchPromotionDTO.RegistrationID > 0) ? BranchPromotionDTO.RegistrationID : new int();
            }
            set
            {
                BranchPromotionDTO.RegistrationID = value;
            }
        }
        public bool IsDomicleFromLast3Year
        {
            get
            {
                return (BranchPromotionDTO != null) ? BranchPromotionDTO.IsDomicleFromLast3Year : false;
            }
            set
            {
                BranchPromotionDTO.IsDomicleFromLast3Year = value;
            }
        }
        public bool IsNriPoi
        {
            get
            {
                return (BranchPromotionDTO != null) ? BranchPromotionDTO.IsNriPoi : false;
            }
            set
            {
                BranchPromotionDTO.IsNriPoi = value;
            }
        }
        public int TransferCoursesYearId
        {
            get
            {
                return (BranchPromotionDTO != null && BranchPromotionDTO.TransferCoursesYearId > 0) ? BranchPromotionDTO.TransferCoursesYearId : new int();
            }
            set
            {
                BranchPromotionDTO.TransferCoursesYearId = value;
            }
        }
        public string DirectSecYrAdmissionMode
        {
            get
            {
                return (BranchPromotionDTO != null) ? BranchPromotionDTO.DirectSecYrAdmissionMode : string.Empty;
            }
            set
            {
                BranchPromotionDTO.DirectSecYrAdmissionMode = value;
            }
        }
        public string AdmittedInShift
        {
            get
            {
                return (BranchPromotionDTO != null) ? BranchPromotionDTO.AdmittedInShift : string.Empty;
            }
            set
            {
                BranchPromotionDTO.AdmittedInShift = value;
            }
        }
        public string AllotAdmThrough
        {
            get
            {
                return (BranchPromotionDTO != null) ? BranchPromotionDTO.AllotAdmThrough : string.Empty;
            }
            set
            {
                BranchPromotionDTO.AllotAdmThrough = value;
            }
        }
        public int BankAccountNumber
        {
            get
            {
                return (BranchPromotionDTO != null && BranchPromotionDTO.BankAccountNumber > 0) ? BranchPromotionDTO.BankAccountNumber : new int();
            }
            set
            {
                BranchPromotionDTO.BankAccountNumber = value;
            }
        }
        public string BankBranchName
        {
            get
            {
                return (BranchPromotionDTO != null) ? BranchPromotionDTO.BankBranchName : string.Empty;
            }
            set
            {
                BranchPromotionDTO.BankBranchName = value;
            }
        }
        public string BankBranchCity
        {
            get
            {
                return (BranchPromotionDTO != null) ? BranchPromotionDTO.BankBranchCity : string.Empty;
            }
            set
            {
                BranchPromotionDTO.BankBranchCity = value;
            }
        }
        public int UniqueIdentificatinNumber
        {
            get
            {
                return (BranchPromotionDTO != null && BranchPromotionDTO.UniqueIdentificatinNumber > 0) ? BranchPromotionDTO.UniqueIdentificatinNumber : new int();
            }
            set
            {
                BranchPromotionDTO.UniqueIdentificatinNumber = value;
            }
        }
        public string IdentificationType
        {
            get
            {
                return (BranchPromotionDTO != null) ? BranchPromotionDTO.IdentificationType : string.Empty;
            }
            set
            {
                BranchPromotionDTO.IdentificationType = value;
            }
        }
        [Display(Name = "DisplayName_IsFirstYearPromotion", ResourceType = typeof(AMS.Common.Resources))]
        public bool IsFirstYearPromotion
        {
            get
            {
                return (BranchPromotionDTO != null) ? BranchPromotionDTO.IsFirstYearPromotion : false;
            }
            set
            {
                BranchPromotionDTO.IsFirstYearPromotion = value;
            }
        }
        public string ScopeIdentity
                {
                    get
                    {
                        return (BranchPromotionDTO != null) ? BranchPromotionDTO.ScopeIdentity : string.Empty;
                    }
                    set
                    {
                        BranchPromotionDTO.ScopeIdentity = value;
                    }
                }
        public int StudentAdmissionDetailId
        {
            get
            {
                return (BranchPromotionDTO != null && BranchPromotionDTO.StudentAdmissionDetailId > 0) ? BranchPromotionDTO.StudentAdmissionDetailId : new int();
            }
            set
            {
                BranchPromotionDTO.StudentAdmissionDetailId = value;
            }
        }
        public int NextSectionDetailID
        {
            get
            {
                return (BranchPromotionDTO != null && BranchPromotionDTO.NextSectionDetailID > 0) ? BranchPromotionDTO.NextSectionDetailID : new int();
            }
            set
            {
                BranchPromotionDTO.NextSectionDetailID = value;
            }
        }
    }
}
