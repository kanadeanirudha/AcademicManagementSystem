using AMS.Common;
using AMS.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using System.Web;
namespace AMS.ViewModel
{
    public class ScholarShipAllocationViewModel : IScholarShipAllocationViewModel
    {
        public ScholarShipAllocationViewModel()
        {
            ScholarShipAllocationDTO = new ScholarShipAllocation();
            CourseList = new List<ScholarShipAllocation>();
            ScholarShipList = new List<ScholarShipAllocation>();
            ListGetAdminRoleApplicableCentre = new List<AdminRoleApplicableDetails>();
            ScholarShipAllocationApprovalList = new List<ScholarShipAllocation>();
        }
        public List<ScholarShipAllocation> CourseList { get; set; }
        public List<ScholarShipAllocation> ScholarShipList { get; set; }
        public List<ScholarShipAllocation> ScholarShipAllocationApprovalList { get; set; }
        public string SelectedCourseID { get; set; }
        public string SelectedCentreCode { get; set; }
        public List<AdminRoleApplicableDetails> ListGetAdminRoleApplicableCentre
        {
            get;
            set;
        }
        public IEnumerable<SelectListItem> CourseListItems
        {
            get
            {
                return new SelectList(CourseList, "BranchID", "BranchDesc");
            }
        }
        public IEnumerable<SelectListItem> ListGetAdminRoleApplicableCentreItems
        {
            get
            {
                return new SelectList(ListGetAdminRoleApplicableCentre, "CentreCode", "CentreName");
            }
        }
        public IEnumerable<SelectListItem> ScholarShipListItems
        {
            get
            {
                return new SelectList(ScholarShipList, "ScholarShipMasterID", "ScholarShipDescription");
            }
        }
        public ScholarShipAllocation ScholarShipAllocationDTO { get; set; }
        //-------------------Properties of table ScholarShipAllocation -----------------------------------
        public int ID
        {
            get
            {
                return (ScholarShipAllocationDTO != null && ScholarShipAllocationDTO.ID > 0) ? ScholarShipAllocationDTO.ID : new int();
            }
            set
            {
                ScholarShipAllocationDTO.ID = value;
            }
        }
        public int StudentID
        {
            get
            {
                return (ScholarShipAllocationDTO != null && ScholarShipAllocationDTO.StudentID > 0) ? ScholarShipAllocationDTO.StudentID : new int();
            }
            set
            {
                ScholarShipAllocationDTO.StudentID = value;
            }
        }
        [Display(Name="ScholarShip")]
        [Required(ErrorMessage="ScholarShip must be selected")]
        public int ScholarShipMasterID
        {
            get
            {
                return (ScholarShipAllocationDTO != null && ScholarShipAllocationDTO.ScholarShipMasterID > 0) ? ScholarShipAllocationDTO.ScholarShipMasterID : new int();
            }
            set
            {
                ScholarShipAllocationDTO.ScholarShipMasterID = value;
            }
        }
        public string TransDate
        {
            get
            {
                return (ScholarShipAllocationDTO != null) ? ScholarShipAllocationDTO.TransDate : string.Empty;
            }
            set
            {
                ScholarShipAllocationDTO.TransDate = value;
            }
        }
        [Display(Name = "ScholarShip Reference No.")]
        [Required(ErrorMessage = "ScholarShip Reference No. should not be blank")]
        public string ScholarSheepDocumentNumber
        {
            get
            {
                return (ScholarShipAllocationDTO != null) ? ScholarShipAllocationDTO.ScholarSheepDocumentNumber : string.Empty;
            }
            set
            {
                ScholarShipAllocationDTO.ScholarSheepDocumentNumber = value;
            }
        }
         [Display(Name = "Course")]
         [Required(ErrorMessage = "Course must be selected")]
        public int BranchID
        {
            get
            {
                return (ScholarShipAllocationDTO != null && ScholarShipAllocationDTO.BranchID > 0) ? ScholarShipAllocationDTO.BranchID : new int();
            }
            set
            {
                ScholarShipAllocationDTO.BranchID = value;
            }
        }
        [Display(Name = "Course")]
        public string BranchDesc
        {
            get
            {
                return (ScholarShipAllocationDTO != null) ? ScholarShipAllocationDTO.BranchDesc : string.Empty;
            }
            set
            {
                ScholarShipAllocationDTO.BranchDesc = value;
            }
        }
        public bool IsApproved
        {
            get
            {
                return (ScholarShipAllocationDTO != null) ? ScholarShipAllocationDTO.IsApproved : false;
            }
            set
            {
                ScholarShipAllocationDTO.IsApproved = value;
            }
        }
        public int ApporvedBy
        {
            get
            {
                return (ScholarShipAllocationDTO != null && ScholarShipAllocationDTO.ApporvedBy > 0) ? ScholarShipAllocationDTO.ApporvedBy : new int();
            }
            set
            {
                ScholarShipAllocationDTO.ApporvedBy = value;
            }
        }
        public string ApproveStatus
        {
            get
            {
                return (ScholarShipAllocationDTO != null) ? ScholarShipAllocationDTO.ApproveStatus : string.Empty;
            }
            set
            {
                ScholarShipAllocationDTO.ApproveStatus = value;
            }
        }
        public int LastSectionDetailID
        {
            get
            {
                return (ScholarShipAllocationDTO != null && ScholarShipAllocationDTO.LastSectionDetailID > 0) ? ScholarShipAllocationDTO.LastSectionDetailID : new int();
            }
            set
            {
                ScholarShipAllocationDTO.LastSectionDetailID = value;
            }
        }
        public bool IsActive
        {
            get
            {
                return (ScholarShipAllocationDTO != null) ? ScholarShipAllocationDTO.IsActive : false;
            }
            set
            {
                ScholarShipAllocationDTO.IsActive = value;
            }
        }
        public bool IsDeleted
        {
            get
            {
                return (ScholarShipAllocationDTO != null) ? ScholarShipAllocationDTO.IsDeleted : false;
            }
            set
            {
                ScholarShipAllocationDTO.IsDeleted = value;
            }
        }
        public int CreatedBy
        {
            get
            {
                return (ScholarShipAllocationDTO != null && ScholarShipAllocationDTO.CreatedBy > 0) ? ScholarShipAllocationDTO.CreatedBy : new int();
            }
            set
            {
                ScholarShipAllocationDTO.CreatedBy = value;
            }
        }
        public DateTime CreatedDate
        {
            get
            {
                return (ScholarShipAllocationDTO != null) ? ScholarShipAllocationDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                ScholarShipAllocationDTO.CreatedDate = value;
            }
        }
        public int? ModifiedBy
        {
            get
            {
                return (ScholarShipAllocationDTO != null && ScholarShipAllocationDTO.ModifiedBy > 0) ? ScholarShipAllocationDTO.ModifiedBy : new int();
            }
            set
            {
                ScholarShipAllocationDTO.ModifiedBy = value;
            }
        }
        public DateTime? ModifiedDate
        {
            get
            {
                return (ScholarShipAllocationDTO != null) ? ScholarShipAllocationDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                ScholarShipAllocationDTO.ModifiedDate = value;
            }
        }

        //-------------------Properties of table ScholarShipTransactionDetails  -----------------------------------
        public int StudentAmissionDetailID
        {
            get
            {
                return (ScholarShipAllocationDTO != null && ScholarShipAllocationDTO.StudentAmissionDetailID > 0) ? ScholarShipAllocationDTO.StudentAmissionDetailID : new int();
            }
            set
            {
                ScholarShipAllocationDTO.StudentAmissionDetailID = value;
            }
        }
        public int ScholarShipAllocationID
        {
            get
            {
                return (ScholarShipAllocationDTO != null && ScholarShipAllocationDTO.ScholarShipAllocationID > 0) ? ScholarShipAllocationDTO.ScholarShipAllocationID : new int();
            }
            set
            {
                ScholarShipAllocationDTO.ScholarShipAllocationID = value;
            }
        }
        public int SectionDetailId
        {
            get
            {
                return (ScholarShipAllocationDTO != null && ScholarShipAllocationDTO.SectionDetailId > 0) ? ScholarShipAllocationDTO.SectionDetailId : new int();
            }
            set
            {
                ScholarShipAllocationDTO.SectionDetailId = value;
            }
        }
        public decimal Amount
        {
            get
            {
                return (ScholarShipAllocationDTO != null && ScholarShipAllocationDTO.Amount > 0) ? ScholarShipAllocationDTO.Amount : new decimal();
            }
            set
            {
                ScholarShipAllocationDTO.Amount = value;
            }
        }
        public int AcadCenterwiseSessionId
        {
            get
            {
                return (ScholarShipAllocationDTO != null && ScholarShipAllocationDTO.AcadCenterwiseSessionId > 0) ? ScholarShipAllocationDTO.AcadCenterwiseSessionId : new int();
            }
            set
            {
                ScholarShipAllocationDTO.AcadCenterwiseSessionId = value;
            }
        }
        public string StandarNumber
        {
            get
            {
                return (ScholarShipAllocationDTO != null) ? ScholarShipAllocationDTO.StandarNumber : string.Empty;
            }
            set
            {
                ScholarShipAllocationDTO.StandarNumber = value;
            }
        }

        //--------------------------------------Extra properties-------------------------------------------------------
        [Display(Name="Student")]
        [Required(ErrorMessage = "Student should not be blank")]
        public string StudentName
        {
            get
            {
                return (ScholarShipAllocationDTO != null) ? ScholarShipAllocationDTO.StudentName : string.Empty;
            }
            set
            {
                ScholarShipAllocationDTO.StudentName = value;
            }
        }
        public string SectionDetailDescription
        {
            get
            {
                return (ScholarShipAllocationDTO != null) ? ScholarShipAllocationDTO.SectionDetailDescription : string.Empty;
            }
            set
            {
                ScholarShipAllocationDTO.SectionDetailDescription = value;
            }
        }
        public string errorMessage
        {
            get
            {
                return (ScholarShipAllocationDTO != null) ? ScholarShipAllocationDTO.errorMessage : string.Empty;
            }
            set
            {
                ScholarShipAllocationDTO.errorMessage = value;
            }
        }
        public string SelectedBalanceSheet
        {
            get
            {
                return (ScholarShipAllocationDTO != null) ? ScholarShipAllocationDTO.SelectedBalanceSheet : string.Empty;
            }
            set
            {
                ScholarShipAllocationDTO.SelectedBalanceSheet = value;
            }
        }
        public int SelectedBalanceSheetID
        {
            get
            {
                return (ScholarShipAllocationDTO != null && ScholarShipAllocationDTO.SelectedBalanceSheetID > 0) ? ScholarShipAllocationDTO.SelectedBalanceSheetID : new int();
            }
            set
            {
                ScholarShipAllocationDTO.SelectedBalanceSheetID = value;
            }
        }
        public int TaskNotificationDetailsID
        {
            get
            {
                return (ScholarShipAllocationDTO != null && ScholarShipAllocationDTO.TaskNotificationDetailsID > 0) ? ScholarShipAllocationDTO.TaskNotificationDetailsID : new int();
            }
            set
            {
                ScholarShipAllocationDTO.TaskNotificationDetailsID = value;
            }
        }
        public int TaskNotificationMasterID
        {
            get
            {
                return (ScholarShipAllocationDTO != null && ScholarShipAllocationDTO.TaskNotificationMasterID > 0) ? ScholarShipAllocationDTO.TaskNotificationMasterID : new int();
            }
            set
            {
                ScholarShipAllocationDTO.TaskNotificationMasterID = value;
            }
        }
        public int GeneralTaskReportingDetailsID
        {
            get
            {
                return (ScholarShipAllocationDTO != null && ScholarShipAllocationDTO.GeneralTaskReportingDetailsID > 0) ? ScholarShipAllocationDTO.GeneralTaskReportingDetailsID : new int();
            }
            set
            {
                ScholarShipAllocationDTO.GeneralTaskReportingDetailsID = value;
            }
        }
        public string TaskCode
        {
            get
            {
                return (ScholarShipAllocationDTO != null) ? ScholarShipAllocationDTO.TaskCode : string.Empty;
            }
            set
            {
                ScholarShipAllocationDTO.TaskCode = value;
            }
        }
        public int StageSequenceNumber
        {
            get
            {
                return (ScholarShipAllocationDTO != null && ScholarShipAllocationDTO.StageSequenceNumber > 0) ? ScholarShipAllocationDTO.StageSequenceNumber : new int();
            }
            set
            {
                ScholarShipAllocationDTO.StageSequenceNumber = value;
            }
        }
        public bool IsLastRecord
        {
            get
            {
                return (ScholarShipAllocationDTO != null) ? ScholarShipAllocationDTO.IsLastRecord : false;
            }
            set
            {
                ScholarShipAllocationDTO.IsLastRecord = value;
            }
        }
        public string CentreName
        {
            get
            {
                return (ScholarShipAllocationDTO != null) ? ScholarShipAllocationDTO.CentreName : string.Empty;
            }
            set
            {
                ScholarShipAllocationDTO.CentreName = value;
            }
        }
        public string CentreCode
        {
            get
            {
                return (ScholarShipAllocationDTO != null) ? ScholarShipAllocationDTO.CentreCode : string.Empty;
            }
            set
            {
                ScholarShipAllocationDTO.CentreCode = value;
            }
        }
        public string XMLstring
        {
            get
            {
                return (ScholarShipAllocationDTO != null) ? ScholarShipAllocationDTO.XMLstring : string.Empty;
            }
            set
            {
                ScholarShipAllocationDTO.XMLstring = value;
            }
        }
        public string EntityLevel
        {
            get
            {
                return (ScholarShipAllocationDTO != null) ? ScholarShipAllocationDTO.EntityLevel : string.Empty;
            }
            set
            {
                ScholarShipAllocationDTO.EntityLevel = value;
            }
        }
        public int PersonID
        {
            get
            {
                return (ScholarShipAllocationDTO != null && ScholarShipAllocationDTO.PersonID > 0) ? ScholarShipAllocationDTO.PersonID : new int();
            }
            set
            {
                ScholarShipAllocationDTO.PersonID = value;
            }
        }
        public string SessionName
        {
            get
            {
                return (ScholarShipAllocationDTO != null) ? ScholarShipAllocationDTO.SessionName : string.Empty;
            }
            set
            {
                ScholarShipAllocationDTO.SessionName = value;
            }
        }
        public string ScholarShipDescription
        {
            get
            {
                return (ScholarShipAllocationDTO != null) ? ScholarShipAllocationDTO.ScholarShipDescription : string.Empty;
            }
            set
            {
                ScholarShipAllocationDTO.ScholarShipDescription = value;
            }
        }
        public bool RequestApprovedStatus
        {
            get
            {
                return (ScholarShipAllocationDTO != null) ? ScholarShipAllocationDTO.RequestApprovedStatus : false;
            }
            set
            {
                ScholarShipAllocationDTO.RequestApprovedStatus = value;
            }
        }
        
    }
}
