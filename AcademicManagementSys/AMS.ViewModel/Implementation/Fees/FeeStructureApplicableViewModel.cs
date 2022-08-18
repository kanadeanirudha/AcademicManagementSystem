using AMS.Common;
using AMS.DTO;
using System;
using System.Web.Mvc;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AMS.ViewModel
{
    public class FeeStructureApplicableViewModel : IFeeStructureApplicableViewModel
    {
        public FeeStructureApplicableViewModel()
        {
            FeeStructureApplicableDTO = new FeeStructureApplicable();
            ListGetFeeCriteria = new List<FeeCriteriaMasterAndDetails>();
            FeeStructureMasterList = new List<FeeStructureMasterAndDetails>();
            FeeStructureInstallmentList = new List<FeeStructureMasterAndDetails>();
            StructureApplicableStudentList = new List<FeeStructureApplicable>();
            FeeStructureCriteriaApprovalList = new List<FeeStructureApplicable>();
        }
        public List<FeeCriteriaMasterAndDetails> ListGetFeeCriteria
        {
            get;
            set;
        }
        public List<FeeStructureMasterAndDetails> FeeStructureMasterList
        {
            get;
            set;
        }
        public List<FeeStructureMasterAndDetails> FeeStructureInstallmentList
        {
            get;
            set;
        }
        public List<FeeStructureApplicable> StructureApplicableStudentList
        {
            get;
            set;
        }
        public List<FeeStructureApplicable> FeeStructureCriteriaApprovalList { get; set; }

        public string SelectedFeeCriteriaMasterID { get; set; }
        public IEnumerable<SelectListItem> ListGetFeeCriteriaItems
        {
            get
            {
                return new SelectList(ListGetFeeCriteria, "ID", "FeeCriteriaDescription");
            }
        }
        public FeeStructureApplicable FeeStructureApplicableDTO { get; set; }

        //--------------------------------------Properties of FeeStructureSessionMaster table---------------------------------
        public int ID
        {
            get
            {
                return (FeeStructureApplicableDTO != null && FeeStructureApplicableDTO.ID > 0) ? FeeStructureApplicableDTO.ID : new int();
            }
            set
            {
                FeeStructureApplicableDTO.ID = value;
            }
        }
        public int FeeStructureMasterID
        {
            get
            {
                return (FeeStructureApplicableDTO != null && FeeStructureApplicableDTO.FeeStructureMasterID > 0) ? FeeStructureApplicableDTO.FeeStructureMasterID : new int();
            }
            set
            {
                FeeStructureApplicableDTO.FeeStructureMasterID = value;
            }
        }
        [Display(Name = "Applicable From :")]
        [Required(ErrorMessage = "Applicable From  required")]
        public string ApplicableFromDate
        {
            get
            {
                return (FeeStructureApplicableDTO != null) ? FeeStructureApplicableDTO.ApplicableFromDate : string.Empty;
            }
            set
            {
                FeeStructureApplicableDTO.ApplicableFromDate = value;
            }
        }
        public string ApplicableToDate
        {
            get
            {
                return (FeeStructureApplicableDTO != null) ? FeeStructureApplicableDTO.ApplicableToDate : string.Empty;
            }
            set
            {
                FeeStructureApplicableDTO.ApplicableToDate = value;
            }
        }
        [Display(Name = "DisplayName_CentreCode", ResourceType = typeof(Resources))]
        //[Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "ValidationMessage_CentreCode")]
        public string CentreCode
        {
            get
            {
                return (FeeStructureApplicableDTO != null) ? FeeStructureApplicableDTO.CentreCode : string.Empty;
            }
            set
            {
                FeeStructureApplicableDTO.CentreCode = value;
            }
        }
        public bool IsActive
        {
            get
            {
                return (FeeStructureApplicableDTO != null) ? FeeStructureApplicableDTO.IsActive : false;
            }
            set
            {
                FeeStructureApplicableDTO.IsActive = value;
            }
        }
        public bool RequestApprovalStatus
        {
            get
            {
                return (FeeStructureApplicableDTO != null) ? FeeStructureApplicableDTO.RequestApprovalStatus : false;
            }
            set
            {
                FeeStructureApplicableDTO.RequestApprovalStatus = value;
            }
        }
        public int CreatedBy
        {
            get
            {
                return (FeeStructureApplicableDTO != null && FeeStructureApplicableDTO.CreatedBy > 0) ? FeeStructureApplicableDTO.CreatedBy : new int();
            }
            set
            {
                FeeStructureApplicableDTO.CreatedBy = value;
            }
        }
        public DateTime CreatedDate
        {
            get
            {
                return (FeeStructureApplicableDTO != null) ? FeeStructureApplicableDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                FeeStructureApplicableDTO.CreatedDate = value;
            }
        }
        public int? ModifiedBy
        {
            get
            {
                return (FeeStructureApplicableDTO != null && FeeStructureApplicableDTO.ModifiedBy > 0) ? FeeStructureApplicableDTO.ModifiedBy : new int();
            }
            set
            {
                FeeStructureApplicableDTO.ModifiedBy = value;
            }
        }
        public DateTime? ModifiedDate
        {
            get
            {
                return (FeeStructureApplicableDTO != null) ? FeeStructureApplicableDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                FeeStructureApplicableDTO.ModifiedDate = value;
            }
        }
        public int? DeletedBy
        {
            get
            {
                return (FeeStructureApplicableDTO != null && FeeStructureApplicableDTO.DeletedBy > 0) ? FeeStructureApplicableDTO.DeletedBy : new int();
            }
            set
            {
                FeeStructureApplicableDTO.DeletedBy = value;
            }
        }
        public DateTime? DeletedDate
        {
            get
            {
                return (FeeStructureApplicableDTO != null) ? FeeStructureApplicableDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                FeeStructureApplicableDTO.DeletedDate = value;
            }
        }
        public bool IsDeleted
        {
            get
            {
                return (FeeStructureApplicableDTO != null) ? FeeStructureApplicableDTO.IsDeleted : false;
            }
            set
            {
                FeeStructureApplicableDTO.IsDeleted = value;
            }
        }

        //--------------------------------------Properties of FeeStructureSessionInstallmentDetails table---------------------------------
        public int FeeStructureSessionInstallmentDetailsID
        {
            get
            {
                return (FeeStructureApplicableDTO != null && FeeStructureApplicableDTO.FeeStructureSessionInstallmentDetailsID > 0) ? FeeStructureApplicableDTO.FeeStructureSessionInstallmentDetailsID : new int();
            }
            set
            {
                FeeStructureApplicableDTO.FeeStructureSessionInstallmentDetailsID = value;
            }
        }
        public int FeeStructureSessionMasterID
        {
            get
            {
                return (FeeStructureApplicableDTO != null && FeeStructureApplicableDTO.FeeStructureSessionMasterID > 0) ? FeeStructureApplicableDTO.FeeStructureSessionMasterID : new int();
            }
            set
            {
                FeeStructureApplicableDTO.FeeStructureSessionMasterID = value;
            }
        }
        public int FeeStructureInstallmentMasterID
        {
            get
            {
                return (FeeStructureApplicableDTO != null && FeeStructureApplicableDTO.FeeStructureInstallmentMasterID > 0) ? FeeStructureApplicableDTO.FeeStructureInstallmentMasterID : new int();
            }
            set
            {
                FeeStructureApplicableDTO.FeeStructureInstallmentMasterID = value;
            }
        }
        public string InstallmentFromDate
        {
            get
            {
                return (FeeStructureApplicableDTO != null) ? FeeStructureApplicableDTO.InstallmentFromDate : string.Empty;
            }
            set
            {
                FeeStructureApplicableDTO.InstallmentFromDate = value;
            }
        }
        public string InstallmentToDate
        {
            get
            {
                return (FeeStructureApplicableDTO != null) ? FeeStructureApplicableDTO.InstallmentToDate : string.Empty;
            }
            set
            {
                FeeStructureApplicableDTO.InstallmentToDate = value;
            }
        }

        //--------------------------------------Properties of FeeStructureApplicableDetails table---------------------------------
        public int FeeStructureApplicableDetailsID
        {
            get
            {
                return (FeeStructureApplicableDTO != null && FeeStructureApplicableDTO.FeeStructureApplicableDetailsID > 0) ? FeeStructureApplicableDTO.FeeStructureApplicableDetailsID : new int();
            }
            set
            {
                FeeStructureApplicableDTO.FeeStructureApplicableDetailsID = value;
            }
        }
        public string EntityType
        {
            get
            {
                return (FeeStructureApplicableDTO != null) ? FeeStructureApplicableDTO.EntityType : string.Empty;
            }
            set
            {
                FeeStructureApplicableDTO.EntityType = value;
            }
        }
        public int EntityID
        {
            get
            {
                return (FeeStructureApplicableDTO != null && FeeStructureApplicableDTO.EntityID > 0) ? FeeStructureApplicableDTO.EntityID : new int();
            }
            set
            {
                FeeStructureApplicableDTO.EntityID = value;
            }
        }

        //--------------------------------------Extra properties-------------------------------------------------------
        public string errorMessage
        {
            get
            {
                return (FeeStructureApplicableDTO != null) ? FeeStructureApplicableDTO.errorMessage : string.Empty;
            }
            set
            {
                FeeStructureApplicableDTO.errorMessage = value;
            }
        }
        public string AccBalanceSheetName
        {
            get
            {
                return (FeeStructureApplicableDTO != null) ? FeeStructureApplicableDTO.AccBalanceSheetName : string.Empty;
            }
            set
            {
                FeeStructureApplicableDTO.AccBalanceSheetName = value;
            }
        }
        public string CentreName
        {
            get
            {
                return (FeeStructureApplicableDTO != null) ? FeeStructureApplicableDTO.CentreName : string.Empty;
            }
            set
            {
                FeeStructureApplicableDTO.CentreName = value;
            }
        }
        public decimal TotalFeeAmount
        {
            get
            {
                return (FeeStructureApplicableDTO != null && FeeStructureApplicableDTO.TotalFeeAmount > 0) ? FeeStructureApplicableDTO.TotalFeeAmount : new decimal();
            }
            set
            {
                FeeStructureApplicableDTO.TotalFeeAmount = value;
            }
        }
        public bool IsInstallmentApplicable
        {
            get
            {
                return (FeeStructureApplicableDTO != null) ? FeeStructureApplicableDTO.IsInstallmentApplicable : false;
            }
            set
            {
                FeeStructureApplicableDTO.IsInstallmentApplicable = value;
            }
        }
        public bool StatusFlag
        {
            get
            {
                return (FeeStructureApplicableDTO != null) ? FeeStructureApplicableDTO.StatusFlag : false;
            }
            set
            {
                FeeStructureApplicableDTO.StatusFlag = value;
            }
        }
        [Display(Name = "Fee Structure :")]
        public string FeeCriteriaValueCombinationDescription
        {
            get
            {
                return (FeeStructureApplicableDTO != null) ? FeeStructureApplicableDTO.FeeCriteriaValueCombinationDescription : string.Empty;
            }
            set
            {
                FeeStructureApplicableDTO.FeeCriteriaValueCombinationDescription = value;
            }
        }


        public string Category
        {
            get
            {
                return (FeeStructureApplicableDTO != null) ? FeeStructureApplicableDTO.Category : string.Empty;
            }
            set
            {
                FeeStructureApplicableDTO.Category = value;
            }
        }
        public string AdmitAcademicYear
        {
            get
            {
                return (FeeStructureApplicableDTO != null) ? FeeStructureApplicableDTO.AdmitAcademicYear : string.Empty;
            }
            set
            {
                FeeStructureApplicableDTO.AdmitAcademicYear = value;
            }
        }
        public string BranchName
        {
            get
            {
                return (FeeStructureApplicableDTO != null) ? FeeStructureApplicableDTO.BranchName : string.Empty;
            }
            set
            {
                FeeStructureApplicableDTO.BranchName = value;
            }
        }
        public string SectionName
        {
            get
            {
                return (FeeStructureApplicableDTO != null) ? FeeStructureApplicableDTO.SectionName : string.Empty;
            }
            set
            {
                FeeStructureApplicableDTO.SectionName = value;
            }
        }
        public string DomicileState
        {
            get
            {
                return (FeeStructureApplicableDTO != null) ? FeeStructureApplicableDTO.DomicileState : string.Empty;
            }
            set
            {
                FeeStructureApplicableDTO.DomicileState = value;
            }
        }
        public string StudentName
        {
            get
            {
                return (FeeStructureApplicableDTO != null) ? FeeStructureApplicableDTO.StudentName : string.Empty;
            }
            set
            {
                FeeStructureApplicableDTO.StudentName = value;
            }
        }
        public string FeeStructureApplicableFromDate
        {
            get
            {
                return (FeeStructureApplicableDTO != null) ? FeeStructureApplicableDTO.FeeStructureApplicableFromDate : string.Empty;
            }
            set
            {
                FeeStructureApplicableDTO.FeeStructureApplicableFromDate = value;
            }
        }
        public int AccBalsheetID
        {
            get
            {
                return (FeeStructureApplicableDTO != null) ? FeeStructureApplicableDTO.AccBalsheetID : new int();
            }
            set
            {
                FeeStructureApplicableDTO.AccBalsheetID = value;
            }
        }
        public string XMLstring
        {
            get
            {
                return (FeeStructureApplicableDTO != null) ? FeeStructureApplicableDTO.XMLstring : string.Empty;
            }
            set
            {
                FeeStructureApplicableDTO.XMLstring = value;
            }
        }

        public string Address
        {
            get
            {
                return (FeeStructureApplicableDTO != null && FeeStructureApplicableDTO.Address != "") ? FeeStructureApplicableDTO.Address : string.Empty;
            }
            set
            {
                FeeStructureApplicableDTO.Address = value;
            }
        }

        public string AddmissionYear
        {
            get
            {
                return (FeeStructureApplicableDTO != null && FeeStructureApplicableDTO.AddmissionYear != "") ? FeeStructureApplicableDTO.AddmissionYear : string.Empty;
            }
            set
            {
                FeeStructureApplicableDTO.AddmissionYear = value;
            }
        }

        public string AdmissionType
        {
            get
            {
                return (FeeStructureApplicableDTO != null && FeeStructureApplicableDTO.AdmissionType != "") ? FeeStructureApplicableDTO.AdmissionType : string.Empty;
            }
            set
            {
                FeeStructureApplicableDTO.AdmissionType = value;
            }
        }

        public int PersonID {
            get
            { 
                return (FeeStructureApplicableDTO != null && FeeStructureApplicableDTO.PersonID > 0) ? FeeStructureApplicableDTO.PersonID : new int(); 
            }
            set
            {
                FeeStructureApplicableDTO.PersonID = value;
            }
        }
        public int TaskNotificationDetailsID
        {
            get
            {
                return (FeeStructureApplicableDTO != null && FeeStructureApplicableDTO.TaskNotificationDetailsID > 0) ? FeeStructureApplicableDTO.TaskNotificationDetailsID : new int();
            }
            set
            {
                FeeStructureApplicableDTO.TaskNotificationDetailsID = value;
            }
        }

        public int TaskNotificationMasterID
        {
            get
            {
                return (FeeStructureApplicableDTO != null && FeeStructureApplicableDTO.TaskNotificationMasterID > 0) ? FeeStructureApplicableDTO.TaskNotificationMasterID : new int();
            }
            set
            {
                FeeStructureApplicableDTO.TaskNotificationMasterID = value;
            }
        }

        public int GeneralTaskReportingDetailsID 
        {
            get
            {
                return (FeeStructureApplicableDTO != null && FeeStructureApplicableDTO.GeneralTaskReportingDetailsID > 0) ? FeeStructureApplicableDTO.GeneralTaskReportingDetailsID : new int();
            }
            set
            {
                FeeStructureApplicableDTO.GeneralTaskReportingDetailsID = value;
            }
        }
        public string TaskCode 
        {
            get
            {
                return (FeeStructureApplicableDTO != null && FeeStructureApplicableDTO.TaskCode != "") ? FeeStructureApplicableDTO.TaskCode : string.Empty;
            }
            set
            {
                FeeStructureApplicableDTO.TaskCode = value;
            }
        }
        public int StageSequenceNumber {
            get
            {
                return (FeeStructureApplicableDTO != null && FeeStructureApplicableDTO.StageSequenceNumber > 0) ? FeeStructureApplicableDTO.StageSequenceNumber : new int();
            }
            set
            {
                FeeStructureApplicableDTO.StageSequenceNumber = value;
            }
        }
        public bool IsLastRecord {
            get
            {
                return (FeeStructureApplicableDTO != null) ? FeeStructureApplicableDTO.IsLastRecord : new bool();
            }
            set
            {
                FeeStructureApplicableDTO.IsLastRecord = value;
            }
        }
        public int AccBalanceSheetID
        {
            get
            {
                return (FeeStructureApplicableDTO != null && FeeStructureApplicableDTO.AccBalanceSheetID > 0) ? FeeStructureApplicableDTO.AccBalanceSheetID : new int();
            }
            set
            {
                FeeStructureApplicableDTO.AccBalanceSheetID = value;
            }
        }
        public int FeeStructureApplicableHistoryID
        {
            get
            {
                return (FeeStructureApplicableDTO != null && FeeStructureApplicableDTO.FeeStructureApplicableHistoryID > 0) ? FeeStructureApplicableDTO.FeeStructureApplicableHistoryID : new int();
            }
            set
            {
                FeeStructureApplicableDTO.FeeStructureApplicableHistoryID = value;
            }
        }
        public int AccountSessionID
        {
            get
            {
                return (FeeStructureApplicableDTO != null && FeeStructureApplicableDTO.AccountSessionID > 0) ? FeeStructureApplicableDTO.AccountSessionID : new int();
            }
            set
            {
                FeeStructureApplicableDTO.AccountSessionID = value;
            }
        }
        public int AdmissionDetailID
        {
            get
            {
                return (FeeStructureApplicableDTO != null && FeeStructureApplicableDTO.AdmissionDetailID > 0) ? FeeStructureApplicableDTO.AdmissionDetailID : new int();
            }
            set
            {
                FeeStructureApplicableDTO.AdmissionDetailID = value;
            }
        }
        public int FeeStructureDetailsID
        {
            get
            {
                return (FeeStructureApplicableDTO != null && FeeStructureApplicableDTO.FeeStructureDetailsID > 0) ? FeeStructureApplicableDTO.FeeStructureDetailsID : new int();
            }
            set
            {
                FeeStructureApplicableDTO.FeeStructureDetailsID = value;
            }
        }
        public int FeeSubTypeID
        {
            get
            {
                return (FeeStructureApplicableDTO != null && FeeStructureApplicableDTO.FeeSubTypeID > 0) ? FeeStructureApplicableDTO.FeeSubTypeID : new int();
            }
            set
            {
                FeeStructureApplicableDTO.FeeSubTypeID = value;
            }
        }
        public decimal FeeSubTypeAmount
        {
            get
            {
                return (FeeStructureApplicableDTO != null && FeeStructureApplicableDTO.FeeSubTypeAmount > 0) ? FeeStructureApplicableDTO.FeeSubTypeAmount : new decimal();
            }
            set
            {
                FeeStructureApplicableDTO.FeeSubTypeAmount = value;
            }
        }
        public string FeeSubTypeDesc
        {
            get
            {
                return (FeeStructureApplicableDTO != null && FeeStructureApplicableDTO.FeeSubTypeDesc != "") ? FeeStructureApplicableDTO.FeeSubTypeDesc : string.Empty;
            }
            set
            {
                FeeStructureApplicableDTO.FeeSubTypeDesc = value;
            }
        }
        public int StudentID
        {
            get
            {
                return (FeeStructureApplicableDTO != null && FeeStructureApplicableDTO.StudentID > 0) ? FeeStructureApplicableDTO.StudentID : new int();
            }
            set
            {
                FeeStructureApplicableDTO.StudentID = value;
            }
        }
        public string SectionDescription
        {
            get
            {
                return (FeeStructureApplicableDTO != null && FeeStructureApplicableDTO.SectionDescription != "") ? FeeStructureApplicableDTO.SectionDescription : string.Empty;
            }
            set
            {
                FeeStructureApplicableDTO.SectionDescription = value;
            }
        }
        public string AdmissionPattern
        {
            get
            {
                return (FeeStructureApplicableDTO != null && FeeStructureApplicableDTO.AdmissionPattern != "") ? FeeStructureApplicableDTO.AdmissionPattern : string.Empty;
            }
            set
            {
                FeeStructureApplicableDTO.AdmissionPattern = value;
            }
        }

        public byte[] StudentPhoto
        {
            get
            {
                return (FeeStructureApplicableDTO != null) ? FeeStructureApplicableDTO.StudentPhoto : new byte[1];         //review this       
            }
            set
            {
                FeeStructureApplicableDTO.StudentPhoto = value;
            }
        }

        public string StudentPhotoFileHeight
        {
            get
            {
                return (FeeStructureApplicableDTO != null && FeeStructureApplicableDTO.StudentPhotoFileHeight != "") ? FeeStructureApplicableDTO.StudentPhotoFileHeight : string.Empty;
            }
            set
            {
                FeeStructureApplicableDTO.StudentPhotoFileHeight = value;
            }
        }
        public string StudentPhotoFilename
        {
            get
            {
                return (FeeStructureApplicableDTO != null && FeeStructureApplicableDTO.StudentPhotoFilename != "") ? FeeStructureApplicableDTO.StudentPhotoFilename : string.Empty;
            }
            set
            {
                FeeStructureApplicableDTO.StudentPhotoFilename = value;
            }
        }
        public string StudentPhotoFileSize
        {
            get
            {
                return (FeeStructureApplicableDTO != null && FeeStructureApplicableDTO.StudentPhotoFileSize != "") ? FeeStructureApplicableDTO.StudentPhotoFileSize : string.Empty;
            }
            set
            {
                FeeStructureApplicableDTO.StudentPhotoFileSize = value;
            }
        }
        public string StudentPhotoFileWidth
        {
            get
            {
                return (FeeStructureApplicableDTO != null && FeeStructureApplicableDTO.StudentPhotoFileWidth != "") ? FeeStructureApplicableDTO.StudentPhotoFileWidth : string.Empty;
            }
            set
            {
                FeeStructureApplicableDTO.StudentPhotoFileWidth = value;
            }
        }
        public string StudentPhotoType
        {
            get
            {
                return (FeeStructureApplicableDTO != null && FeeStructureApplicableDTO.StudentPhotoType != "") ? FeeStructureApplicableDTO.StudentPhotoType : string.Empty;
            }
            set
            {
                FeeStructureApplicableDTO.StudentPhotoType = value;
            }
        }

        public decimal ToalFeeAmount
        {
            get
            {
                return (FeeStructureApplicableDTO != null && FeeStructureApplicableDTO.ToalFeeAmount > 0) ? FeeStructureApplicableDTO.ToalFeeAmount : new decimal();
            }
            set
            {
                FeeStructureApplicableDTO.ToalFeeAmount = value;
            }
        }

        public int AccountID
        {
            get
            {
                return (FeeStructureApplicableDTO != null && FeeStructureApplicableDTO.AccountID > 0) ? FeeStructureApplicableDTO.AccountID : new int();
            }
            set
            {
                FeeStructureApplicableDTO.AccountID = value;
            }
        }
        public int FeeReceivableVoucherStructureID
        {
            get
            {
                return (FeeStructureApplicableDTO != null && FeeStructureApplicableDTO.FeeReceivableVoucherStructureID > 0) ? FeeStructureApplicableDTO.FeeReceivableVoucherStructureID : new int();
            }
            set
            {
                FeeStructureApplicableDTO.FeeReceivableVoucherStructureID = value;
            }
        }
        public string AccountType
        {
            get
            {
                return (FeeStructureApplicableDTO != null && FeeStructureApplicableDTO.AccountType != "") ? FeeStructureApplicableDTO.AccountType : string.Empty;
            }
            set
            {
                FeeStructureApplicableDTO.AccountType = value;
            }
        }
        public decimal Amount
        {
            get
            {
                return (FeeStructureApplicableDTO != null && FeeStructureApplicableDTO.Amount > 0) ? FeeStructureApplicableDTO.Amount : new decimal();
            }
            set
            {
                FeeStructureApplicableDTO.Amount = value;
            }
        }
        public bool CrDrStatus
        {
            get
            {
                return (FeeStructureApplicableDTO != null) ? FeeStructureApplicableDTO.CrDrStatus : new bool();
            }
            set
            {
                FeeStructureApplicableDTO.CrDrStatus = value;
            }
        }
        public string FeeSubShortDesc
        {
            get
            {
                return (FeeStructureApplicableDTO != null && FeeStructureApplicableDTO.FeeSubShortDesc != "") ? FeeStructureApplicableDTO.FeeSubShortDesc : string.Empty;
            }
            set
            {
                FeeStructureApplicableDTO.FeeSubShortDesc = value;
            }
        }
        public Int16 Source
        {
            get
            {
                return (FeeStructureApplicableDTO != null && FeeStructureApplicableDTO.Source > 0) ? FeeStructureApplicableDTO.Source : new Int16();
            }
            set
            {
                FeeStructureApplicableDTO.Source = value;
            }
        }
        public int SubTypeMasterID
        {
            get
            {
                return (FeeStructureApplicableDTO != null && FeeStructureApplicableDTO.SubTypeMasterID > 0) ? FeeStructureApplicableDTO.SubTypeMasterID : new int();
            }
            set
            {
                FeeStructureApplicableDTO.SubTypeMasterID = value;
            }
        }
        public string FeeApprovalXmlstring
        {
            get
            {
                return (FeeStructureApplicableDTO != null) ? FeeStructureApplicableDTO.FeeApprovalXmlstring : string.Empty;
            }
            set
            {
                FeeStructureApplicableDTO.FeeApprovalXmlstring = value;
            }
        }

        public int StandardNumber
        {
            get
            {
                return (FeeStructureApplicableDTO != null && FeeStructureApplicableDTO.StandardNumber > 0) ? FeeStructureApplicableDTO.StandardNumber : new int();
            }
            set
            {
                FeeStructureApplicableDTO.StandardNumber = value;
            }
        }
        public int Student_CourseYearId
        {
            get
            {
                return (FeeStructureApplicableDTO != null && FeeStructureApplicableDTO.Student_CourseYearId > 0) ? FeeStructureApplicableDTO.Student_CourseYearId : new int();
            }
            set
            {
                FeeStructureApplicableDTO.Student_CourseYearId = value;
            }
        }
        public string CourseYearDesc
        {
            get
            {
                return (FeeStructureApplicableDTO != null && FeeStructureApplicableDTO.CourseYearDesc != "") ? FeeStructureApplicableDTO.CourseYearDesc : string.Empty;
            }
            set
            {
                FeeStructureApplicableDTO.CourseYearDesc = value;
            }
        }
        public string StandardDescription
        {
            get
            {
                return (FeeStructureApplicableDTO != null && FeeStructureApplicableDTO.StandardDescription != "") ? FeeStructureApplicableDTO.StandardDescription : string.Empty;
            }
            set
            {
                FeeStructureApplicableDTO.StandardDescription = value;
            }
        }
    }
}
