using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using System.Threading.Tasks;
using AMS.DTO;

namespace AMS.ViewModel
{
   public class StudentReadmissionViewModel : IStudentReadmissionViewModel
    {
       public StudentReadmissionViewModel()
       {
           StudentReadmissionDTO = new StudentReadmission();
           ListOrganisationStudyCentreMaster = new List<OrganisationStudyCentreMaster>();
       }
       public List<OrganisationStudyCentreMaster> ListOrganisationStudyCentreMaster
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
       public IEnumerable<SelectListItem> StudyCentreListMasterItems
       {
           get
           {
               return new SelectList(ListOrganisationStudyCentreMaster, "CentreCode", "CentreName");
           }
       }
       public StudentReadmission StudentReadmissionDTO { get; set; }
       public int ID
       {
           get
           {
               return (StudentReadmissionDTO != null && StudentReadmissionDTO.ID > 0) ? StudentReadmissionDTO.ID : new int();
           }
           set
           {
               StudentReadmissionDTO.ID = value;
           }
       }
       public int StudentId
       {
           get
           {
               return (StudentReadmissionDTO != null && StudentReadmissionDTO.StudentId > 0) ? StudentReadmissionDTO.StudentId : new int();
           }
           set
           {
               StudentReadmissionDTO.StudentId = value;
           }
       }

       [Display(Name = "DisplayName_StudentName", ResourceType = typeof(AMS.Common.Resources))]
       public string StudentName
       {
           get
           {
               return (StudentReadmissionDTO != null) ? StudentReadmissionDTO.StudentName : string.Empty;
           }
           set
           {
               StudentReadmissionDTO.StudentName = value;
           }
       }
       public string FormNumber
       {
           get
           {
               return (StudentReadmissionDTO != null) ? StudentReadmissionDTO.FormNumber : string.Empty;
           }
           set
           {
               StudentReadmissionDTO.FormNumber = value;
           }
       }
       public string FormDate
       {
           get
           {
               return (StudentReadmissionDTO != null) ? StudentReadmissionDTO.FormDate : string.Empty;
           }
           set
           {
               StudentReadmissionDTO.FormDate = value;
           }
       }
       [Display(Name = "DisplayName_SectionDetailID", ResourceType = typeof(AMS.Common.Resources))]
       [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_SectionDetailIDRequired")]
       public int SectionDetailID
       {
           get
           {
               return (StudentReadmissionDTO != null && StudentReadmissionDTO.SectionDetailID > 0) ? StudentReadmissionDTO.SectionDetailID : new int();
           }
           set
           {
               StudentReadmissionDTO.SectionDetailID = value;
           }
       }

       [Display(Name = "DisplayName_AdmissionDate", ResourceType = typeof(AMS.Common.Resources))]
       [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_AdmissionDateRequired")]
       public string AdmissionDate
       {
           get
           {
               return (StudentReadmissionDTO != null) ? StudentReadmissionDTO.AdmissionDate : string.Empty;
           }
           set
           {
               StudentReadmissionDTO.AdmissionDate = value;
           }
       }
       public bool AdmissionActiveFlag
       {
           get
           {
               return (StudentReadmissionDTO != null) ? StudentReadmissionDTO.AdmissionActiveFlag : false;
           }
           set
           {
               StudentReadmissionDTO.AdmissionActiveFlag = value;
           }
       }

       [Display(Name = "DisplayName_AcademicYear", ResourceType = typeof(AMS.Common.Resources))]
       public string AcademicYear
       {
           get
           {
               return (StudentReadmissionDTO != null) ? StudentReadmissionDTO.AcademicYear : string.Empty;
           }
           set
           {
               StudentReadmissionDTO.AcademicYear = value;
           }
       }
       public string YearlyRollNumber
       {
           get
           {
               return (StudentReadmissionDTO != null) ? StudentReadmissionDTO.YearlyRollNumber : string.Empty;
           }
           set
           {
               StudentReadmissionDTO.YearlyRollNumber = value;
           }
       }
       public string RollNoSortOrder
       {
           get
           {
               return (StudentReadmissionDTO != null) ? StudentReadmissionDTO.RollNoSortOrder : string.Empty;
           }
           set
           {
               StudentReadmissionDTO.RollNoSortOrder = value;
           }
       }
       public string SortOrderStatus
       {
           get
           {
               return (StudentReadmissionDTO != null) ? StudentReadmissionDTO.SortOrderStatus : string.Empty;
           }
           set
           {
               StudentReadmissionDTO.SortOrderStatus = value;
           }
       }
       public string FromSession
       {
           get
           {
               return (StudentReadmissionDTO != null) ? StudentReadmissionDTO.FromSession : string.Empty;
           }
           set
           {
               StudentReadmissionDTO.FromSession = value;
           }
       }
       public string UptoSession
       {
           get
           {
               return (StudentReadmissionDTO != null) ? StudentReadmissionDTO.UptoSession : string.Empty;
           }
           set
           {
               StudentReadmissionDTO.UptoSession = value;
           }
       }
       public string ResultStatus
       {
           get
           {
               return (StudentReadmissionDTO != null) ? StudentReadmissionDTO.ResultStatus : string.Empty;
           }
           set
           {
               StudentReadmissionDTO.ResultStatus = value;
           }
       }
       public string AdmissionCancelStatus
       {
           get
           {
               return (StudentReadmissionDTO != null) ? StudentReadmissionDTO.AdmissionCancelStatus : string.Empty;
           }
           set
           {
               StudentReadmissionDTO.AdmissionCancelStatus = value;
           }
       }
       public string AdmissionStatus
       {
           get
           {
               return (StudentReadmissionDTO != null) ? StudentReadmissionDTO.AdmissionStatus : string.Empty;
           }
           set
           {
               StudentReadmissionDTO.AdmissionStatus = value;
           }
       }
       public string AdmissionCancelDate
       {
           get
           {
               return (StudentReadmissionDTO != null) ? StudentReadmissionDTO.AdmissionCancelDate : string.Empty;
           }
           set
           {
               StudentReadmissionDTO.AdmissionCancelDate = value;
           }
       }
       public int BranchId
       {
           get
           {
               return (StudentReadmissionDTO != null && StudentReadmissionDTO.BranchId > 0) ? StudentReadmissionDTO.BranchId : new int();
           }
           set
           {
               StudentReadmissionDTO.BranchId = value;
           }
       }
       public string PromotedToNextBranch
       {
           get
           {
               return (StudentReadmissionDTO != null) ? StudentReadmissionDTO.PromotedToNextBranch : string.Empty;
           }
           set
           {
               StudentReadmissionDTO.PromotedToNextBranch = value;
           }
       }
       public string StatusCode
       {
           get
           {
               return (StudentReadmissionDTO != null) ? StudentReadmissionDTO.StatusCode : string.Empty;
           }
           set
           {
               StudentReadmissionDTO.StatusCode = value;
           }
       }
       public string AdmissionConfirmDate
       {
           get
           {
               return (StudentReadmissionDTO != null) ? StudentReadmissionDTO.AdmissionConfirmDate : string.Empty;
           }
           set
           {
               StudentReadmissionDTO.AdmissionConfirmDate = value;
           }
       }
       public string AdmissionPromoteDate
       {
           get
           {
               return (StudentReadmissionDTO != null) ? StudentReadmissionDTO.AdmissionPromoteDate : string.Empty;
           }
           set
           {
               StudentReadmissionDTO.AdmissionPromoteDate = value;
           }
       }
       public string CentreCode
       {
           get
           {
               return (StudentReadmissionDTO != null) ? StudentReadmissionDTO.CentreCode : string.Empty;
           }
           set
           {
               StudentReadmissionDTO.CentreCode = value;
           }
       }
       public string Remark
       {
           get
           {
               return (StudentReadmissionDTO != null) ? StudentReadmissionDTO.Remark : string.Empty;
           }
           set
           {
               StudentReadmissionDTO.Remark = value;
           }
       }

       [Display(Name = "DisplayName_AdmissionNumber", ResourceType = typeof(AMS.Common.Resources))]
       public string AdmissionNumber
       {
           get
           {
               return (StudentReadmissionDTO != null) ? StudentReadmissionDTO.AdmissionNumber : string.Empty;
           }
           set
           {
               StudentReadmissionDTO.AdmissionNumber = value;
           }
       }
       public string PrevExamSeatNo
       {
           get
           {
               return (StudentReadmissionDTO != null) ? StudentReadmissionDTO.PrevExamSeatNo : string.Empty;
           }
           set
           {
               StudentReadmissionDTO.PrevExamSeatNo = value;
           }
       }
       public string EligibForCuryrAdmsn
       {
           get
           {
               return (StudentReadmissionDTO != null) ? StudentReadmissionDTO.EligibForCuryrAdmsn : string.Empty;
           }
           set
           {
               StudentReadmissionDTO.EligibForCuryrAdmsn = value;
           }
       }
       public string ResultCurYear
       {
           get
           {
               return (StudentReadmissionDTO != null) ? StudentReadmissionDTO.ResultCurYear : string.Empty;
           }
           set
           {
               StudentReadmissionDTO.ResultCurYear = value;
           }
       }
       public string DtndForSemester
       {
           get
           {
               return (StudentReadmissionDTO != null) ? StudentReadmissionDTO.DtndForSemester : string.Empty;
           }
           set
           {
               StudentReadmissionDTO.DtndForSemester = value;
           }
       }
       public string SemesterSpecificAdmsn
       {
           get
           {
               return (StudentReadmissionDTO != null) ? StudentReadmissionDTO.SemesterSpecificAdmsn : string.Empty;
           }
           set
           {
               StudentReadmissionDTO.SemesterSpecificAdmsn = value;
           }
       }
       public int StuRevalAppliId
       {
           get
           {
               return (StudentReadmissionDTO != null && StudentReadmissionDTO.StuRevalAppliId > 0) ? StudentReadmissionDTO.StuRevalAppliId : new int();
           }
           set
           {
               StudentReadmissionDTO.StuRevalAppliId = value;
           }
       }
       public string ProvisionalType
       {
           get
           {
               return (StudentReadmissionDTO != null) ? StudentReadmissionDTO.ProvisionalType : string.Empty;
           }
           set
           {
               StudentReadmissionDTO.ProvisionalType = value;
           }
       }
       public string AdmissionFinalStatus
       {
           get
           {
               return (StudentReadmissionDTO != null) ? StudentReadmissionDTO.AdmissionFinalStatus : string.Empty;
           }
           set
           {
               StudentReadmissionDTO.AdmissionFinalStatus = value;
           }
       }
       public bool IsActive
       {
           get
           {
               return (StudentReadmissionDTO != null) ? StudentReadmissionDTO.IsActive : false;
           }
           set
           {
               StudentReadmissionDTO.IsActive = value;
           }
       }
       public bool IsDeleted
       {
           get
           {
               return (StudentReadmissionDTO != null) ? StudentReadmissionDTO.IsDeleted : false;
           }
           set
           {
               StudentReadmissionDTO.IsDeleted = value;
           }
       }
       public int CreatedBy
       {
           get
           {
               return (StudentReadmissionDTO != null && StudentReadmissionDTO.CreatedBy > 0) ? StudentReadmissionDTO.CreatedBy : new int();
           }
           set
           {
               StudentReadmissionDTO.CreatedBy = value;
           }
       }
       public DateTime CreatedDate
       {
           get
           {
               return (StudentReadmissionDTO != null) ? StudentReadmissionDTO.CreatedDate : DateTime.Now;
           }
           set
           {
               StudentReadmissionDTO.CreatedDate = value;
           }
       }
       public int? ModifiedBy
       {
           get
           {
               return (StudentReadmissionDTO != null && StudentReadmissionDTO.ModifiedBy > 0) ? StudentReadmissionDTO.ModifiedBy : new int();
           }
           set
           {
               StudentReadmissionDTO.ModifiedBy = value;
           }
       }
       public DateTime? ModifiedDate
       {
           get
           {
               return (StudentReadmissionDTO != null) ? StudentReadmissionDTO.ModifiedDate : DateTime.Now;
           }
           set
           {
               StudentReadmissionDTO.ModifiedDate = value;
           }
       }
       public int? DeletedBy
       {
           get
           {
               return (StudentReadmissionDTO != null && StudentReadmissionDTO.DeletedBy > 0) ? StudentReadmissionDTO.DeletedBy : new int();
           }
           set
           {
               StudentReadmissionDTO.DeletedBy = value;
           }
       }
       public DateTime? DeletedDate
       {
           get
           {
               return (StudentReadmissionDTO != null) ? StudentReadmissionDTO.DeletedDate : DateTime.Now;
           }
           set
           {
               StudentReadmissionDTO.DeletedDate = value;
           }
       }

   [Display(Name = "DisplayName_BranchDescription", ResourceType = typeof(AMS.Common.Resources))]
       public string BranchDescription
       {
           get
           {
               return (StudentReadmissionDTO != null) ? StudentReadmissionDTO.BranchDescription : string.Empty;
           }
           set
           {
               StudentReadmissionDTO.BranchDescription = value;
           }
       }

        [Display(Name = "DisplayName_CourseYearDesc", ResourceType = typeof(AMS.Common.Resources))]
       public string CourseYearDesc
       {
           get
           {
               return (StudentReadmissionDTO != null) ? StudentReadmissionDTO.CourseYearDesc : string.Empty;
           }
           set
           {
               StudentReadmissionDTO.CourseYearDesc = value;
           }
       }

       [Display(Name = "DisplayName_SectionDesc", ResourceType = typeof(AMS.Common.Resources))]
       public string SectionDesc
       {
           get
           {
               return (StudentReadmissionDTO != null) ? StudentReadmissionDTO.SectionDesc : string.Empty;
           }
           set
           {
               StudentReadmissionDTO.SectionDesc = value;
           }
       }

       [Display(Name = "DisplayName_SessionName", ResourceType = typeof(AMS.Common.Resources))]
       public string SessionName
       {
           get
           {
               return (StudentReadmissionDTO != null) ? StudentReadmissionDTO.SessionName : string.Empty;
           }
           set
           {
               StudentReadmissionDTO.SessionName = value;
           }
       }
       public int SessionID
       {
           get
           {
               return (StudentReadmissionDTO != null && StudentReadmissionDTO.SessionID > 0) ? StudentReadmissionDTO.SessionID : new int();
           }
           set
           {
               StudentReadmissionDTO.SessionID = value;
           }
       }

       [Display(Name = "DisplayName_CentreName", ResourceType = typeof(AMS.Common.Resources))]
       public string CentreName
       {
           get
           {
               return (StudentReadmissionDTO != null) ? StudentReadmissionDTO.CentreName : string.Empty;
           }
           set
           {
               StudentReadmissionDTO.CentreName = value;
           }
       }
       public string errorMessage { get; set; }
       public int CourseYearId
       {
           get
           {
               return (StudentReadmissionDTO != null && StudentReadmissionDTO.CourseYearId > 0) ? StudentReadmissionDTO.CourseYearId : new int();
           }
           set
           {
               StudentReadmissionDTO.CourseYearId = value;
           }
       }
       public string StudentCode
       {
           get
           {
               return (StudentReadmissionDTO != null) ? StudentReadmissionDTO.StudentCode : string.Empty;
           }
           set
           {
               StudentReadmissionDTO.StudentCode = value;
           }
       }
       public int StuAdmissionDetailID
       {
           get
           {
               return (StudentReadmissionDTO != null && StudentReadmissionDTO.StuAdmissionDetailID > 0) ? StudentReadmissionDTO.StuAdmissionDetailID : new int();
           }
           set
           {
               StudentReadmissionDTO.StuAdmissionDetailID = value;
           }
       }

       public int OldSectionDetailID
       {
           get
           {
               return (StudentReadmissionDTO != null && StudentReadmissionDTO.OldSectionDetailID > 0) ? StudentReadmissionDTO.OldSectionDetailID : new int();
           }
           set
           {
               StudentReadmissionDTO.OldSectionDetailID = value;
           }
       }
       public int CourseYearOldId
       {
           get
           {
               return (StudentReadmissionDTO != null && StudentReadmissionDTO.CourseYearOldId > 0) ? StudentReadmissionDTO.CourseYearOldId : new int();
           }
           set
           {
               StudentReadmissionDTO.CourseYearOldId = value;
           }
       }
       
   [Display(Name = "DisplayName_IsCurrentYearStudent", ResourceType = typeof(AMS.Common.Resources))]
       public string IsCurrentYearStudent
       {
           get
           {
               return (StudentReadmissionDTO != null) ? StudentReadmissionDTO.IsCurrentYearStudent : string.Empty;
           }
           set
           {
               StudentReadmissionDTO.IsCurrentYearStudent = value;
           }
       }

       public string ActiveSessionFlag
       {
           get
           {
               return (StudentReadmissionDTO != null) ? StudentReadmissionDTO.ActiveSessionFlag : string.Empty;
           }
           set
           {
               StudentReadmissionDTO.ActiveSessionFlag = value;
           }
       }
    }
}
