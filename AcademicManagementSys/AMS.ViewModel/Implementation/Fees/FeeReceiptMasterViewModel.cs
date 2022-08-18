using AMS.Common;
using AMS.DTO;
using System;
using System.Web.Mvc;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AMS.ViewModel
{
    public class FeeReceiptMasterViewModel : IFeeReceiptMasterViewModel
    {
        public FeeReceiptMasterViewModel()
        {
            FeeReceiptMasterDTO = new FeeReceiptMaster();
            StructureApplicableStudentList = new List<FeeReceiptMaster>();
            StudentPaymentDetails = new List<FeeReceiptMaster>();
            AccountList = new List<FeeReceiptMaster>();
        }

        public List<FeeReceiptMaster> StructureApplicableStudentList
        {
            get;
            set;
        }
        public List<FeeReceiptMaster> AccountList
        {
            get;
            set;
        }
        public List<FeeReceiptMaster> StudentPaymentDetails { get; set; }
        public IEnumerable<SelectListItem> AccountListItems
        {
            get { return new SelectList(AccountList, "AccountID", "AccountName"); }
        }
        public string SelectedFeeCriteriaMasterID { get; set; }
        public FeeReceiptMaster FeeReceiptMasterDTO { get; set; }

        //--------------------------------------Properties of FeeStructureSessionMaster table---------------------------------
        public int ID
        {
            get
            {
                return (FeeReceiptMasterDTO != null && FeeReceiptMasterDTO.ID > 0) ? FeeReceiptMasterDTO.ID : new int();
            }
            set
            {
                FeeReceiptMasterDTO.ID = value;
            }
        }
        public int FeeStructureMasterID
        {
            get
            {
                return (FeeReceiptMasterDTO != null && FeeReceiptMasterDTO.FeeStructureMasterID > 0) ? FeeReceiptMasterDTO.FeeStructureMasterID : new int();
            }
            set
            {
                FeeReceiptMasterDTO.FeeStructureMasterID = value;
            }
        }
        [Display(Name = "Applicable From :")]
        [Required(ErrorMessage = "Applicable From  required")]
        public string ApplicableFromDate
        {
            get
            {
                return (FeeReceiptMasterDTO != null) ? FeeReceiptMasterDTO.ApplicableFromDate : string.Empty;
            }
            set
            {
                FeeReceiptMasterDTO.ApplicableFromDate = value;
            }
        }
        public string ApplicableToDate
        {
            get
            {
                return (FeeReceiptMasterDTO != null) ? FeeReceiptMasterDTO.ApplicableToDate : string.Empty;
            }
            set
            {
                FeeReceiptMasterDTO.ApplicableToDate = value;
            }
        }
        [Display(Name = "DisplayName_CentreCode", ResourceType = typeof(Resources))]
        //[Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "ValidationMessage_CentreCode")]
        public string CentreCode
        {
            get
            {
                return (FeeReceiptMasterDTO != null) ? FeeReceiptMasterDTO.CentreCode : string.Empty;
            }
            set
            {
                FeeReceiptMasterDTO.CentreCode = value;
            }
        }
        public bool IsActive
        {
            get
            {
                return (FeeReceiptMasterDTO != null) ? FeeReceiptMasterDTO.IsActive : false;
            }
            set
            {
                FeeReceiptMasterDTO.IsActive = value;
            }
        }
        public int CreatedBy
        {
            get
            {
                return (FeeReceiptMasterDTO != null && FeeReceiptMasterDTO.CreatedBy > 0) ? FeeReceiptMasterDTO.CreatedBy : new int();
            }
            set
            {
                FeeReceiptMasterDTO.CreatedBy = value;
            }
        }
        public DateTime CreatedDate
        {
            get
            {
                return (FeeReceiptMasterDTO != null) ? FeeReceiptMasterDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                FeeReceiptMasterDTO.CreatedDate = value;
            }
        }
        public int? ModifiedBy
        {
            get
            {
                return (FeeReceiptMasterDTO != null && FeeReceiptMasterDTO.ModifiedBy > 0) ? FeeReceiptMasterDTO.ModifiedBy : new int();
            }
            set
            {
                FeeReceiptMasterDTO.ModifiedBy = value;
            }
        }
        public DateTime? ModifiedDate
        {
            get
            {
                return (FeeReceiptMasterDTO != null) ? FeeReceiptMasterDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                FeeReceiptMasterDTO.ModifiedDate = value;
            }
        }
        public int? DeletedBy
        {
            get
            {
                return (FeeReceiptMasterDTO != null && FeeReceiptMasterDTO.DeletedBy > 0) ? FeeReceiptMasterDTO.DeletedBy : new int();
            }
            set
            {
                FeeReceiptMasterDTO.DeletedBy = value;
            }
        }
        public DateTime? DeletedDate
        {
            get
            {
                return (FeeReceiptMasterDTO != null) ? FeeReceiptMasterDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                FeeReceiptMasterDTO.DeletedDate = value;
            }
        }
        public bool IsDeleted
        {
            get
            {
                return (FeeReceiptMasterDTO != null) ? FeeReceiptMasterDTO.IsDeleted : false;
            }
            set
            {
                FeeReceiptMasterDTO.IsDeleted = value;
            }
        }

        //--------------------------------------Properties of FeeStructureSessionInstallmentDetails table---------------------------------
        public int FeeStructureSessionInstallmentDetailsID
        {
            get
            {
                return (FeeReceiptMasterDTO != null && FeeReceiptMasterDTO.FeeStructureSessionInstallmentDetailsID > 0) ? FeeReceiptMasterDTO.FeeStructureSessionInstallmentDetailsID : new int();
            }
            set
            {
                FeeReceiptMasterDTO.FeeStructureSessionInstallmentDetailsID = value;
            }
        }
        public int FeeStructureSessionMasterID
        {
            get
            {
                return (FeeReceiptMasterDTO != null && FeeReceiptMasterDTO.FeeStructureSessionMasterID > 0) ? FeeReceiptMasterDTO.FeeStructureSessionMasterID : new int();
            }
            set
            {
                FeeReceiptMasterDTO.FeeStructureSessionMasterID = value;
            }
        }
        public int FeeStructureInstallmentMasterID
        {
            get
            {
                return (FeeReceiptMasterDTO != null && FeeReceiptMasterDTO.FeeStructureInstallmentMasterID > 0) ? FeeReceiptMasterDTO.FeeStructureInstallmentMasterID : new int();
            }
            set
            {
                FeeReceiptMasterDTO.FeeStructureInstallmentMasterID = value;
            }
        }
        public string InstallmentFromDate
        {
            get
            {
                return (FeeReceiptMasterDTO != null) ? FeeReceiptMasterDTO.InstallmentFromDate : string.Empty;
            }
            set
            {
                FeeReceiptMasterDTO.InstallmentFromDate = value;
            }
        }
        public string InstallmentToDate
        {
            get
            {
                return (FeeReceiptMasterDTO != null) ? FeeReceiptMasterDTO.InstallmentToDate : string.Empty;
            }
            set
            {
                FeeReceiptMasterDTO.InstallmentToDate = value;
            }
        }

        //--------------------------------------Properties of FeeReceiptMasterDetails table---------------------------------
        public int FeeReceiptMasterDetailsID
        {
            get
            {
                return (FeeReceiptMasterDTO != null && FeeReceiptMasterDTO.FeeReceiptMasterDetailsID > 0) ? FeeReceiptMasterDTO.FeeReceiptMasterDetailsID : new int();
            }
            set
            {
                FeeReceiptMasterDTO.FeeReceiptMasterDetailsID = value;
            }
        }
        public string EntityType
        {
            get
            {
                return (FeeReceiptMasterDTO != null) ? FeeReceiptMasterDTO.EntityType : string.Empty;
            }
            set
            {
                FeeReceiptMasterDTO.EntityType = value;
            }
        }
        public int EntityID
        {
            get
            {
                return (FeeReceiptMasterDTO != null && FeeReceiptMasterDTO.EntityID > 0) ? FeeReceiptMasterDTO.EntityID : new int();
            }
            set
            {
                FeeReceiptMasterDTO.EntityID = value;
            }
        }

        //--------------------------------------Extra properties-------------------------------------------------------
        public string errorMessage
        {
            get
            {
                return (FeeReceiptMasterDTO != null) ? FeeReceiptMasterDTO.errorMessage : string.Empty;
            }
            set
            {
                FeeReceiptMasterDTO.errorMessage = value;
            }
        }
        public string AccBalanceSheetName
        {
            get
            {
                return (FeeReceiptMasterDTO != null) ? FeeReceiptMasterDTO.AccBalanceSheetName : string.Empty;
            }
            set
            {
                FeeReceiptMasterDTO.AccBalanceSheetName = value;
            }
        }
        public string CentreName
        {
            get
            {
                return (FeeReceiptMasterDTO != null) ? FeeReceiptMasterDTO.CentreName : string.Empty;
            }
            set
            {
                FeeReceiptMasterDTO.CentreName = value;
            }
        }
        public decimal TotalFeeAmount
        {
            get
            {
                return (FeeReceiptMasterDTO != null && FeeReceiptMasterDTO.TotalFeeAmount > 0) ? FeeReceiptMasterDTO.TotalFeeAmount : new decimal();
            }
            set
            {
                FeeReceiptMasterDTO.TotalFeeAmount = value;
            }
        }
        public bool IsInstallmentApplicable
        {
            get
            {
                return (FeeReceiptMasterDTO != null) ? FeeReceiptMasterDTO.IsInstallmentApplicable : false;
            }
            set
            {
                FeeReceiptMasterDTO.IsInstallmentApplicable = value;
            }
        }
        public bool StatusFlag
        {
            get
            {
                return (FeeReceiptMasterDTO != null) ? FeeReceiptMasterDTO.StatusFlag : false;
            }
            set
            {
                FeeReceiptMasterDTO.StatusFlag = value;
            }
        }
        [Display(Name = "Fee Structure :")]
        public string FeeCriteriaValueCombinationDescription
        {
            get
            {
                return (FeeReceiptMasterDTO != null) ? FeeReceiptMasterDTO.FeeCriteriaValueCombinationDescription : string.Empty;
            }
            set
            {
                FeeReceiptMasterDTO.FeeCriteriaValueCombinationDescription = value;
            }
        }


        public string Category
        {
            get
            {
                return (FeeReceiptMasterDTO != null) ? FeeReceiptMasterDTO.Category : string.Empty;
            }
            set
            {
                FeeReceiptMasterDTO.Category = value;
            }
        }
        public string AdmitAcademicYear
        {
            get
            {
                return (FeeReceiptMasterDTO != null) ? FeeReceiptMasterDTO.AdmitAcademicYear : string.Empty;
            }
            set
            {
                FeeReceiptMasterDTO.AdmitAcademicYear = value;
            }
        }
        public string BranchName
        {
            get
            {
                return (FeeReceiptMasterDTO != null) ? FeeReceiptMasterDTO.BranchName : string.Empty;
            }
            set
            {
                FeeReceiptMasterDTO.BranchName = value;
            }
        }
        public string SectionName
        {
            get
            {
                return (FeeReceiptMasterDTO != null) ? FeeReceiptMasterDTO.SectionName : string.Empty;
            }
            set
            {
                FeeReceiptMasterDTO.SectionName = value;
            }
        }
        public string DomicileState
        {
            get
            {
                return (FeeReceiptMasterDTO != null) ? FeeReceiptMasterDTO.DomicileState : string.Empty;
            }
            set
            {
                FeeReceiptMasterDTO.DomicileState = value;
            }
        }
        [Display(Name="Student")]
        [Required(ErrorMessage="Student must be selected")]
        public string StudentName
        {
            get
            {
                return (FeeReceiptMasterDTO != null) ? FeeReceiptMasterDTO.StudentName : string.Empty;
            }
            set
            {
                FeeReceiptMasterDTO.StudentName = value;
            }
        }
        public string FeeReceiptMasterFromDate
        {
            get
            {
                return (FeeReceiptMasterDTO != null) ? FeeReceiptMasterDTO.FeeReceiptMasterFromDate : string.Empty;
            }
            set
            {
                FeeReceiptMasterDTO.FeeReceiptMasterFromDate = value;
            }
        }
        public int AccBalsheetID
        {
            get
            {
                return (FeeReceiptMasterDTO != null) ? FeeReceiptMasterDTO.AccBalsheetID : new int();
            }
            set
            {
                FeeReceiptMasterDTO.AccBalsheetID = value;
            }
        }
        public string XMLstring
        {
            get
            {
                return (FeeReceiptMasterDTO != null) ? FeeReceiptMasterDTO.XMLstring : string.Empty;
            }
            set
            {
                FeeReceiptMasterDTO.XMLstring = value;
            }
        }

        public string Address
        {
            get
            {
                return (FeeReceiptMasterDTO != null && FeeReceiptMasterDTO.Address != "") ? FeeReceiptMasterDTO.Address : string.Empty;
            }
            set
            {
                FeeReceiptMasterDTO.Address = value;
            }
        }

        public string AddmissionYear
        {
            get
            {
                return (FeeReceiptMasterDTO != null && FeeReceiptMasterDTO.AddmissionYear != "") ? FeeReceiptMasterDTO.AddmissionYear : string.Empty;
            }
            set
            {
                FeeReceiptMasterDTO.AddmissionYear = value;
            }
        }

        public string AdmissionType
        {
            get
            {
                return (FeeReceiptMasterDTO != null && FeeReceiptMasterDTO.AdmissionType != "") ? FeeReceiptMasterDTO.AdmissionType : string.Empty;
            }
            set
            {
                FeeReceiptMasterDTO.AdmissionType = value;
            }
        }

        public int PersonID
        {
            get
            {
                return (FeeReceiptMasterDTO != null && FeeReceiptMasterDTO.PersonID > 0) ? FeeReceiptMasterDTO.PersonID : new int();
            }
            set
            {
                FeeReceiptMasterDTO.PersonID = value;
            }
        }
        public int TaskNotificationDetailsID
        {
            get
            {
                return (FeeReceiptMasterDTO != null && FeeReceiptMasterDTO.TaskNotificationDetailsID > 0) ? FeeReceiptMasterDTO.TaskNotificationDetailsID : new int();
            }
            set
            {
                FeeReceiptMasterDTO.TaskNotificationDetailsID = value;
            }
        }

        public int TaskNotificationMasterID
        {
            get
            {
                return (FeeReceiptMasterDTO != null && FeeReceiptMasterDTO.TaskNotificationMasterID > 0) ? FeeReceiptMasterDTO.TaskNotificationMasterID : new int();
            }
            set
            {
                FeeReceiptMasterDTO.TaskNotificationMasterID = value;
            }
        }

        public int GeneralTaskReportingDetailsID
        {
            get
            {
                return (FeeReceiptMasterDTO != null && FeeReceiptMasterDTO.GeneralTaskReportingDetailsID > 0) ? FeeReceiptMasterDTO.GeneralTaskReportingDetailsID : new int();
            }
            set
            {
                FeeReceiptMasterDTO.GeneralTaskReportingDetailsID = value;
            }
        }
        public string TaskCode
        {
            get
            {
                return (FeeReceiptMasterDTO != null && FeeReceiptMasterDTO.TaskCode != "") ? FeeReceiptMasterDTO.TaskCode : string.Empty;
            }
            set
            {
                FeeReceiptMasterDTO.TaskCode = value;
            }
        }
        public int StageSequenceNumber
        {
            get
            {
                return (FeeReceiptMasterDTO != null && FeeReceiptMasterDTO.StageSequenceNumber > 0) ? FeeReceiptMasterDTO.StageSequenceNumber : new int();
            }
            set
            {
                FeeReceiptMasterDTO.StageSequenceNumber = value;
            }
        }
        public bool IsLastRecord
        {
            get
            {
                return (FeeReceiptMasterDTO != null) ? FeeReceiptMasterDTO.IsLastRecord : new bool();
            }
            set
            {
                FeeReceiptMasterDTO.IsLastRecord = value;
            }
        }
        public int AccBalanceSheetID
        {
            get
            {
                return (FeeReceiptMasterDTO != null && FeeReceiptMasterDTO.AccBalanceSheetID > 0) ? FeeReceiptMasterDTO.AccBalanceSheetID : new int();
            }
            set
            {
                FeeReceiptMasterDTO.AccBalanceSheetID = value;
            }
        }
        public int FeeReceiptMasterHistoryID
        {
            get
            {
                return (FeeReceiptMasterDTO != null && FeeReceiptMasterDTO.FeeReceiptMasterHistoryID > 0) ? FeeReceiptMasterDTO.FeeReceiptMasterHistoryID : new int();
            }
            set
            {
                FeeReceiptMasterDTO.FeeReceiptMasterHistoryID = value;
            }
        }
        public int AccountSessionID
        {
            get
            {
                return (FeeReceiptMasterDTO != null && FeeReceiptMasterDTO.AccountSessionID > 0) ? FeeReceiptMasterDTO.AccountSessionID : new int();
            }
            set
            {
                FeeReceiptMasterDTO.AccountSessionID = value;
            }
        }
        public int AdmissionDetailID
        {
            get
            {
                return (FeeReceiptMasterDTO != null && FeeReceiptMasterDTO.AdmissionDetailID > 0) ? FeeReceiptMasterDTO.AdmissionDetailID : new int();
            }
            set
            {
                FeeReceiptMasterDTO.AdmissionDetailID = value;
            }
        }
        public int FeeStructureDetailsID
        {
            get
            {
                return (FeeReceiptMasterDTO != null && FeeReceiptMasterDTO.FeeStructureDetailsID > 0) ? FeeReceiptMasterDTO.FeeStructureDetailsID : new int();
            }
            set
            {
                FeeReceiptMasterDTO.FeeStructureDetailsID = value;
            }
        }
        public int FeeSubTypeID
        {
            get
            {
                return (FeeReceiptMasterDTO != null && FeeReceiptMasterDTO.FeeSubTypeID > 0) ? FeeReceiptMasterDTO.FeeSubTypeID : new int();
            }
            set
            {
                FeeReceiptMasterDTO.FeeSubTypeID = value;
            }
        }
        public decimal FeeSubTypeAmount
        {
            get
            {
                return (FeeReceiptMasterDTO != null && FeeReceiptMasterDTO.FeeSubTypeAmount > 0) ? FeeReceiptMasterDTO.FeeSubTypeAmount : new decimal();
            }
            set
            {
                FeeReceiptMasterDTO.FeeSubTypeAmount = value;
            }
        }
        public string FeeSubTypeDesc
        {
            get
            {
                return (FeeReceiptMasterDTO != null && FeeReceiptMasterDTO.FeeSubTypeDesc != "") ? FeeReceiptMasterDTO.FeeSubTypeDesc : string.Empty;
            }
            set
            {
                FeeReceiptMasterDTO.FeeSubTypeDesc = value;
            }
        }
        public int StudentID
        {
            get
            {
                return (FeeReceiptMasterDTO != null && FeeReceiptMasterDTO.StudentID > 0) ? FeeReceiptMasterDTO.StudentID : new int();
            }
            set
            {
                FeeReceiptMasterDTO.StudentID = value;
            }
        }
        public string SectionDescription
        {
            get
            {
                return (FeeReceiptMasterDTO != null && FeeReceiptMasterDTO.SectionDescription != "") ? FeeReceiptMasterDTO.SectionDescription : string.Empty;
            }
            set
            {
                FeeReceiptMasterDTO.SectionDescription = value;
            }
        }
        public string AdmissionPattern
        {
            get
            {
                return (FeeReceiptMasterDTO != null && FeeReceiptMasterDTO.AdmissionPattern != "") ? FeeReceiptMasterDTO.AdmissionPattern : string.Empty;
            }
            set
            {
                FeeReceiptMasterDTO.AdmissionPattern = value;
            }
        }

        public byte[] StudentPhoto
        {
            get
            {
                return (FeeReceiptMasterDTO != null) ? FeeReceiptMasterDTO.StudentPhoto : new byte[1];         //review this       
            }
            set
            {
                FeeReceiptMasterDTO.StudentPhoto = value;
            }
        }

        public string StudentPhotoFileHeight
        {
            get
            {
                return (FeeReceiptMasterDTO != null && FeeReceiptMasterDTO.StudentPhotoFileHeight != "") ? FeeReceiptMasterDTO.StudentPhotoFileHeight : string.Empty;
            }
            set
            {
                FeeReceiptMasterDTO.StudentPhotoFileHeight = value;
            }
        }
        public string StudentPhotoFilename
        {
            get
            {
                return (FeeReceiptMasterDTO != null && FeeReceiptMasterDTO.StudentPhotoFilename != "") ? FeeReceiptMasterDTO.StudentPhotoFilename : string.Empty;
            }
            set
            {
                FeeReceiptMasterDTO.StudentPhotoFilename = value;
            }
        }
        public string StudentPhotoFileSize
        {
            get
            {
                return (FeeReceiptMasterDTO != null && FeeReceiptMasterDTO.StudentPhotoFileSize != "") ? FeeReceiptMasterDTO.StudentPhotoFileSize : string.Empty;
            }
            set
            {
                FeeReceiptMasterDTO.StudentPhotoFileSize = value;
            }
        }
        public string StudentPhotoFileWidth
        {
            get
            {
                return (FeeReceiptMasterDTO != null && FeeReceiptMasterDTO.StudentPhotoFileWidth != "") ? FeeReceiptMasterDTO.StudentPhotoFileWidth : string.Empty;
            }
            set
            {
                FeeReceiptMasterDTO.StudentPhotoFileWidth = value;
            }
        }
        public string StudentPhotoType
        {
            get
            {
                return (FeeReceiptMasterDTO != null && FeeReceiptMasterDTO.StudentPhotoType != "") ? FeeReceiptMasterDTO.StudentPhotoType : string.Empty;
            }
            set
            {
                FeeReceiptMasterDTO.StudentPhotoType = value;
            }
        }

        public decimal ToalFeeAmount
        {
            get
            {
                return (FeeReceiptMasterDTO != null && FeeReceiptMasterDTO.ToalFeeAmount > 0) ? FeeReceiptMasterDTO.ToalFeeAmount : new decimal();
            }
            set
            {
                FeeReceiptMasterDTO.ToalFeeAmount = value;
            }
        }
        [Required(ErrorMessage = "Deposite Account must be selected")]
        public int AccountID
        {
            get
            {
                return (FeeReceiptMasterDTO != null && FeeReceiptMasterDTO.AccountID > 0) ? FeeReceiptMasterDTO.AccountID : new int();
            }
            set
            {
                FeeReceiptMasterDTO.AccountID = value;
            }
        }
        public int FeeReceivableVoucherStructureID
        {
            get
            {
                return (FeeReceiptMasterDTO != null && FeeReceiptMasterDTO.FeeReceivableVoucherStructureID > 0) ? FeeReceiptMasterDTO.FeeReceivableVoucherStructureID : new int();
            }
            set
            {
                FeeReceiptMasterDTO.FeeReceivableVoucherStructureID = value;
            }
        }
        public string AccountType
        {
            get
            {
                return (FeeReceiptMasterDTO != null && FeeReceiptMasterDTO.AccountType != "") ? FeeReceiptMasterDTO.AccountType : string.Empty;
            }
            set
            {
                FeeReceiptMasterDTO.AccountType = value;
            }
        }
        public decimal Amount
        {
            get
            {
                return (FeeReceiptMasterDTO != null && FeeReceiptMasterDTO.Amount > 0) ? FeeReceiptMasterDTO.Amount : new decimal();
            }
            set
            {
                FeeReceiptMasterDTO.Amount = value;
            }
        }
        public bool CrDrStatus
        {
            get
            {
                return (FeeReceiptMasterDTO != null) ? FeeReceiptMasterDTO.CrDrStatus : new bool();
            }
            set
            {
                FeeReceiptMasterDTO.CrDrStatus = value;
            }
        }
        public string FeeSubShortDesc
        {
            get
            {
                return (FeeReceiptMasterDTO != null && FeeReceiptMasterDTO.FeeSubShortDesc != "") ? FeeReceiptMasterDTO.FeeSubShortDesc : string.Empty;
            }
            set
            {
                FeeReceiptMasterDTO.FeeSubShortDesc = value;
            }
        }
        public Int16 Source
        {
            get
            {
                return (FeeReceiptMasterDTO != null && FeeReceiptMasterDTO.Source > 0) ? FeeReceiptMasterDTO.Source : new Int16();
            }
            set
            {
                FeeReceiptMasterDTO.Source = value;
            }
        }
        public int SubTypeMasterID
        {
            get
            {
                return (FeeReceiptMasterDTO != null && FeeReceiptMasterDTO.SubTypeMasterID > 0) ? FeeReceiptMasterDTO.SubTypeMasterID : new int();
            }
            set
            {
                FeeReceiptMasterDTO.SubTypeMasterID = value;
            }
        }
        public string FeeApprovalXmlstring
        {
            get
            {
                return (FeeReceiptMasterDTO != null) ? FeeReceiptMasterDTO.FeeApprovalXmlstring : string.Empty;
            }
            set
            {
                FeeReceiptMasterDTO.FeeApprovalXmlstring = value;
            }
        }

        public int StandardNumber
        {
            get
            {
                return (FeeReceiptMasterDTO != null && FeeReceiptMasterDTO.StandardNumber > 0) ? FeeReceiptMasterDTO.StandardNumber : new int();
            }
            set
            {
                FeeReceiptMasterDTO.StandardNumber = value;
            }
        }
        public int Student_CourseYearId
        {
            get
            {
                return (FeeReceiptMasterDTO != null && FeeReceiptMasterDTO.Student_CourseYearId > 0) ? FeeReceiptMasterDTO.Student_CourseYearId : new int();
            }
            set
            {
                FeeReceiptMasterDTO.Student_CourseYearId = value;
            }
        }
        public string CourseYearDesc
        {
            get
            {
                return (FeeReceiptMasterDTO != null && FeeReceiptMasterDTO.CourseYearDesc != "") ? FeeReceiptMasterDTO.CourseYearDesc : string.Empty;
            }
            set
            {
                FeeReceiptMasterDTO.CourseYearDesc = value;
            }
        }
        public string StandardDescription
        {
            get
            {
                return (FeeReceiptMasterDTO != null && FeeReceiptMasterDTO.StandardDescription != "") ? FeeReceiptMasterDTO.StandardDescription : string.Empty;
            }
            set
            {
                FeeReceiptMasterDTO.StandardDescription = value;
            }
        }


        public string PersonType
        {
            get
            {
                return (FeeReceiptMasterDTO != null && FeeReceiptMasterDTO.PersonType != string.Empty) ? FeeReceiptMasterDTO.PersonType : string.Empty;
            }
            set
            {
                FeeReceiptMasterDTO.PersonType = value;
            }
        }
        public string ReceiptNumber
        {
            get
            {
                return (FeeReceiptMasterDTO != null && FeeReceiptMasterDTO.ReceiptNumber != string.Empty) ? FeeReceiptMasterDTO.ReceiptNumber : string.Empty;
            }
            set
            {
                FeeReceiptMasterDTO.ReceiptNumber = value;
            }
        }
        public string SystemGeneratedReceiptNo
        {
            get
            {
                return (FeeReceiptMasterDTO != null && FeeReceiptMasterDTO.SystemGeneratedReceiptNo != string.Empty) ? FeeReceiptMasterDTO.SystemGeneratedReceiptNo : string.Empty;
            }
            set
            {
                FeeReceiptMasterDTO.SystemGeneratedReceiptNo = value;
            }
        }
        [Display(Name = "Receipt Date")]
        public string ReceiptDate
        {
            get
            {
                return (FeeReceiptMasterDTO != null && FeeReceiptMasterDTO.ReceiptDate != string.Empty) ? FeeReceiptMasterDTO.ReceiptDate : string.Empty;
            }
            set
            {
                FeeReceiptMasterDTO.ReceiptDate = value;
            }
        }
        [Display(Name = "Amount Received")]
        [Required(ErrorMessage = "Amount Received should not be blank")]
        public decimal ReceiptAmount
        {
            get
            {
                return (FeeReceiptMasterDTO != null ) ? FeeReceiptMasterDTO.ReceiptAmount : new decimal();
            }
            set
            {
                FeeReceiptMasterDTO.ReceiptAmount = value;
            }
        }
        public int ReceiptType
        {
            get
            {
                return (FeeReceiptMasterDTO != null && FeeReceiptMasterDTO.ReceiptType > 0) ? FeeReceiptMasterDTO.ReceiptType : new int();
            }
            set
            {
                FeeReceiptMasterDTO.ReceiptType = value;
            }
        }
        [Display(Name = "Cheque Number Or DD Number")]
        public string FeeChequeOrDDNumber
        {
            get
            {
                return (FeeReceiptMasterDTO != null && FeeReceiptMasterDTO.FeeChequeOrDDNumber != string.Empty) ? FeeReceiptMasterDTO.FeeChequeOrDDNumber : string.Empty;
            }
            set
            {
                FeeReceiptMasterDTO.FeeChequeOrDDNumber = value;
            }
        }
        [Display(Name = "Cheque Date Or DD Date")]
        public string FeeChequeOrDDDate
        {
            get
            {
                return (FeeReceiptMasterDTO != null && FeeReceiptMasterDTO.FeeChequeOrDDDate != string.Empty) ? FeeReceiptMasterDTO.FeeChequeOrDDDate : string.Empty;
            }
            set
            {
                FeeReceiptMasterDTO.FeeChequeOrDDDate = value;
            }
        }
        [Display(Name = "Bank Name")]
        public string FeeBankName
        {
            get
            {
                return (FeeReceiptMasterDTO != null && FeeReceiptMasterDTO.FeeBankName != string.Empty) ? FeeReceiptMasterDTO.FeeBankName : string.Empty;
            }
            set
            {
                FeeReceiptMasterDTO.FeeBankName = value;
            }
        }
        [Display(Name = "Branch Name")]
        public string FeeBranchName
        {
            get
            {
                return (FeeReceiptMasterDTO != null && FeeReceiptMasterDTO.FeeBranchName != string.Empty) ? FeeReceiptMasterDTO.FeeBranchName : string.Empty;
            }
            set
            {
                FeeReceiptMasterDTO.FeeBranchName = value;
            }
        }
        [Display(Name = "City")]
        public string BranchCity
        {
            get
            {
                return (FeeReceiptMasterDTO != null && FeeReceiptMasterDTO.BranchCity != string.Empty) ? FeeReceiptMasterDTO.BranchCity : string.Empty;
            }
            set
            {
                FeeReceiptMasterDTO.BranchCity = value;
            }
        }
        [Display(Name = "Is payment by cheque ?")]
        public bool IschequeORDD
        {
            get
            {
                return (FeeReceiptMasterDTO != null) ? FeeReceiptMasterDTO.IschequeORDD : new bool();
            }
            set
            {
                FeeReceiptMasterDTO.IschequeORDD = value;
            }
        }
        public int FinancialYearID
        {
            get
            {
                return (FeeReceiptMasterDTO != null && FeeReceiptMasterDTO.FinancialYearID > 0) ? FeeReceiptMasterDTO.FinancialYearID : new int();
            }
            set
            {
                FeeReceiptMasterDTO.FinancialYearID = value;
            }
        }
        [Display(Name = "Late Fee")]
        public string LateFeeAmount
        {
            get
            {
                return (FeeReceiptMasterDTO != null ) ? FeeReceiptMasterDTO.LateFeeAmount : string.Empty;
            }
            set
            {
                FeeReceiptMasterDTO.LateFeeAmount = value;
            }
        }


        public int FeeCriteriaValueCombinationMasterID
        {
            get
            {
                return (FeeReceiptMasterDTO != null && FeeReceiptMasterDTO.FeeCriteriaValueCombinationMasterID > 0) ? FeeReceiptMasterDTO.FeeCriteriaValueCombinationMasterID : new int();
            }
            set
            {
                FeeReceiptMasterDTO.FeeCriteriaValueCombinationMasterID = value;
            }
        }

        public int FeeStructureDetailsIDORFeeStructureInstallmentMasterID
        {
            get
            {
                return (FeeReceiptMasterDTO != null && FeeReceiptMasterDTO.FeeStructureDetailsIDORFeeStructureInstallmentMasterID > 0) ? FeeReceiptMasterDTO.FeeStructureDetailsIDORFeeStructureInstallmentMasterID : new int();
            }
            set
            {
                FeeReceiptMasterDTO.FeeStructureDetailsIDORFeeStructureInstallmentMasterID = value;
            }
        }

        public decimal InstallmentAmount
        {
            get
            {
                return (FeeReceiptMasterDTO != null && FeeReceiptMasterDTO.InstallmentAmount > 0) ? FeeReceiptMasterDTO.InstallmentAmount : new decimal();
            }
            set
            {
                FeeReceiptMasterDTO.InstallmentAmount = value;
            }
        }

        public int FeeReceivableDueListMasterID
        {
            get
            {
                return (FeeReceiptMasterDTO != null && FeeReceiptMasterDTO.FeeReceivableDueListMasterID > 0) ? FeeReceiptMasterDTO.FeeReceivableDueListMasterID : new int();
            }
            set
            {
                FeeReceiptMasterDTO.FeeReceivableDueListMasterID = value;
            }
        }

         public int AccSessionId
        {
            get
            {
                return (FeeReceiptMasterDTO != null && FeeReceiptMasterDTO.AccSessionId > 0) ? FeeReceiptMasterDTO.AccSessionId : new int();
            }
            set
            {
                FeeReceiptMasterDTO.AccSessionId = value;
            }
        }

        public short FeeReceivableStatus
        {
            get
            {
                return (FeeReceiptMasterDTO != null && FeeReceiptMasterDTO.FeeReceivableStatus != 0) ? FeeReceiptMasterDTO.FeeReceivableStatus : new short();
            }
            set
            {
                FeeReceiptMasterDTO.FeeReceivableStatus = value;
            }
        }

        public decimal FeeReceivedDueAmount
        {
            get
            {
                return (FeeReceiptMasterDTO != null && FeeReceiptMasterDTO.FeeReceivedDueAmount > 0) ? FeeReceiptMasterDTO.FeeReceivedDueAmount : new decimal();
            }
            set
            {
                FeeReceiptMasterDTO.FeeReceivedDueAmount = value;
            }
        }

        public int InstallmentNumber
        {
            get
            {
                return (FeeReceiptMasterDTO != null && FeeReceiptMasterDTO.InstallmentNumber != 0) ? FeeReceiptMasterDTO.InstallmentNumber : new int();
            }
            set
            {
                FeeReceiptMasterDTO.InstallmentNumber = value;
            }
        }

        public bool IsLumpsum
        {
            get
            {
                    return (FeeReceiptMasterDTO!= null  ? FeeReceiptMasterDTO.IsLumpsum : new bool());
            }
            set
            {
                FeeReceiptMasterDTO.IsLumpsum = value;
            }
        }

        public decimal ReceivedAmount
        {
            get
            {
                return (FeeReceiptMasterDTO != null && FeeReceiptMasterDTO.ReceivedAmount > 0) ? FeeReceiptMasterDTO.ReceivedAmount : new decimal();
            }
            set
            {
                FeeReceiptMasterDTO.ReceivedAmount = value;
            }
        }

        public int ScholarShipAllocationID
        {
            get
            {
                return (FeeReceiptMasterDTO != null && FeeReceiptMasterDTO.ScholarShipAllocationID > 0) ? FeeReceiptMasterDTO.ScholarShipAllocationID : new int();
            }
            set
            {
                FeeReceiptMasterDTO.ScholarShipAllocationID = value;
            }
        }


        public int ScholarShipMasterID
        {
            get
            {
                return (FeeReceiptMasterDTO != null && FeeReceiptMasterDTO.ScholarShipMasterID > 0) ? FeeReceiptMasterDTO.ScholarShipMasterID : new int();
            }
            set
            {
                FeeReceiptMasterDTO.ScholarShipMasterID = value;
            }
        }

        public string TransDate
        {
            get
            {
                return (FeeReceiptMasterDTO != null && FeeReceiptMasterDTO.TransDate != string.Empty) ? FeeReceiptMasterDTO.TransDate : string.Empty;
            }
            set
            {
                FeeReceiptMasterDTO.TransDate = value;
            }
        }

        public string ScholarSheepDocumentNumber
        {
            get
            {
                return (FeeReceiptMasterDTO != null && FeeReceiptMasterDTO.ScholarSheepDocumentNumber != string.Empty) ? FeeReceiptMasterDTO.ScholarSheepDocumentNumber : string.Empty;
            }
            set
            {
                FeeReceiptMasterDTO.ScholarSheepDocumentNumber = value;
            }
        }

        public bool IsApproved
        {
            get
            {
                    return (FeeReceiptMasterDTO!= null  ? FeeReceiptMasterDTO.IsApproved : new bool());
            }
            set
            {
                FeeReceiptMasterDTO.IsApproved = value;
            }
        }

        public string ApporvedBy
        {
            get
            {
                return (FeeReceiptMasterDTO != null && FeeReceiptMasterDTO.ApporvedBy != string.Empty) ? FeeReceiptMasterDTO.ApporvedBy : string.Empty;
            }
            set
            {
                FeeReceiptMasterDTO.ApporvedBy = value;
            }
        }

        public string ApproveStatus
        {
            get
            {
                return (FeeReceiptMasterDTO != null && FeeReceiptMasterDTO.ApproveStatus != string.Empty) ? FeeReceiptMasterDTO.ApproveStatus : string.Empty;
            }
            set
            {
                FeeReceiptMasterDTO.ApproveStatus = value;
            }
        }

        public int LastSectionDetailID
        {
            get
            {
                return (FeeReceiptMasterDTO != null && FeeReceiptMasterDTO.LastSectionDetailID > 0) ? FeeReceiptMasterDTO.LastSectionDetailID : new int();
            }
            set
            {
                FeeReceiptMasterDTO.LastSectionDetailID = value;
            }
        }

        public int ScholarShipTransactionDetailsID
        {
            get
            {
                return (FeeReceiptMasterDTO != null && FeeReceiptMasterDTO.ScholarShipTransactionDetailsID > 0) ? FeeReceiptMasterDTO.ScholarShipTransactionDetailsID : new int();
            }
            set
            {
                FeeReceiptMasterDTO.ScholarShipTransactionDetailsID = value;
            }
        }

        public int StudentAmissionDetailID
        {
            get
            {
                return (FeeReceiptMasterDTO != null && FeeReceiptMasterDTO.StudentAmissionDetailID > 0) ? FeeReceiptMasterDTO.StudentAmissionDetailID : new int();
            }
            set
            {
                FeeReceiptMasterDTO.StudentAmissionDetailID = value;
            }
        }

        public int SectionDetailId
        {
            get
            {
                return (FeeReceiptMasterDTO != null && FeeReceiptMasterDTO.SectionDetailId > 0) ? FeeReceiptMasterDTO.SectionDetailId : new int();
            }
            set
            {
                FeeReceiptMasterDTO.SectionDetailId = value;
            }
        }

        public int AcadCenterwiseSessionId
        {
            get
            {
                return (FeeReceiptMasterDTO != null && FeeReceiptMasterDTO.AcadCenterwiseSessionId > 0) ? FeeReceiptMasterDTO.AcadCenterwiseSessionId : new int();
            }
            set
            {
                FeeReceiptMasterDTO.AcadCenterwiseSessionId = value;
            }
        }

        public string StandarNumber
        {
            get
            {
                return (FeeReceiptMasterDTO != null && FeeReceiptMasterDTO.StandarNumber != string.Empty) ? FeeReceiptMasterDTO.StandarNumber : string.Empty;
            }
            set
            {
                FeeReceiptMasterDTO.StandarNumber = value;
            }
        }

        public string ScholarShipDescription
        {
            get
            {
                return (FeeReceiptMasterDTO != null && FeeReceiptMasterDTO.ScholarShipDescription != string.Empty) ? FeeReceiptMasterDTO.ScholarShipDescription : string.Empty;
            }
            set
            {
                FeeReceiptMasterDTO.ScholarShipDescription = value;
            }
        }

        public bool IsScholarShipApplicable
        {
            get
            {
                  return (FeeReceiptMasterDTO!= null  ? FeeReceiptMasterDTO.IsScholarShipApplicable : new bool());
            }
            set
            {
                FeeReceiptMasterDTO.IsScholarShipApplicable = value;
            }
        }


        public decimal ScholarShipOrDiscountAmount
        {
            get
            {
                return (FeeReceiptMasterDTO != null && FeeReceiptMasterDTO.ScholarShipOrDiscountAmount > 0) ? FeeReceiptMasterDTO.ScholarShipOrDiscountAmount : new decimal();
            }
            set
            {
                FeeReceiptMasterDTO.ScholarShipOrDiscountAmount = value;
            }
        }
        public int FeeReceivableDueListDetailsID
        {
            get
            {
                return (FeeReceiptMasterDTO != null && FeeReceiptMasterDTO.FeeReceivableDueListDetailsID > 0) ? FeeReceiptMasterDTO.FeeReceivableDueListDetailsID : new int();
            }
            set
            {
                FeeReceiptMasterDTO.FeeReceivableDueListDetailsID = value;
            }
        }
        public int FeeReceivableDueListFeeTypeDetailsID
        {
            get
            {
                return (FeeReceiptMasterDTO != null && FeeReceiptMasterDTO.FeeReceivableDueListFeeTypeDetailsID > 0) ? FeeReceiptMasterDTO.FeeReceivableDueListFeeTypeDetailsID : new int();
            }
            set
            {
                FeeReceiptMasterDTO.FeeReceivableDueListFeeTypeDetailsID = value;
            }
        }
        public int NextFeeReceivableDueListDetailsID
        {
            get
            {
                return (FeeReceiptMasterDTO != null && FeeReceiptMasterDTO.NextFeeReceivableDueListDetailsID > 0) ? FeeReceiptMasterDTO.NextFeeReceivableDueListDetailsID : new int();
            }
            set
            {
                FeeReceiptMasterDTO.NextFeeReceivableDueListDetailsID = value;
            }
        }        
    }
}
