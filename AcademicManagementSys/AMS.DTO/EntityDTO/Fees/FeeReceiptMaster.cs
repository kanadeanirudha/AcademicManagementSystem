using AMS.Base.DTO;
using System;
namespace AMS.DTO
{
	public class FeeReceiptMaster : BaseDTO
	{
        //--------------------------------------Properties of FeeStructureSessionMaster table---------------------------------
        public int ID
		{
			get;
			set;
		}
		public int FeeStructureMasterID { get; set; }
        public string ApplicableFromDate { get; set; }
        public string ApplicableToDate { get; set; }
		public string CentreCode { get; set; }
        public string AccountName { get; set; }
		public bool IsActive { get; set; }
		public bool IsDeleted { get; set; }
		public int CreatedBy { get; set; }
		public DateTime CreatedDate { get; set; }
		public int? ModifiedBy { get; set; }
		public DateTime? ModifiedDate { get; set; }
		public int? DeletedBy { get; set; }
		public DateTime? DeletedDate { get; set; }

        //--------------------------------------Properties of FeeStructureSessionInstallmentDetails table---------------------------------
        public int FeeStructureSessionInstallmentDetailsID { get; set; }
		public int FeeStructureSessionMasterID { get; set; }
		public int FeeStructureInstallmentMasterID { get; set; }
		public string InstallmentFromDate { get; set; }
		public string InstallmentToDate { get; set; }

        //--------------------------------------Properties of FeeReceiptMasterDetails table---------------------------------
        public int FeeReceiptMasterDetailsID { get; set; }
		public string EntityType { get; set; }
		public int EntityID { get; set; }

        //----------------------------------------FeeReceiptMasterHistory Table---------------------------------
        public int FeeReceiptMasterHistoryID { get; set; }
        public int AccountSessionID { get; set; }
        public int AdmissionDetailID { get; set; }
        public int FeeStructureDetailsID { get; set; }
        public int FeeSubTypeID { get; set; }
        public decimal FeeSubTypeAmount { get; set; }
        public string FeeSubTypeDesc { get; set; }
        public int StudentID { get; set; }
        public string SectionDescription { get; set; }
        public string AdmissionPattern { get; set; }
        public byte[] StudentPhoto { get; set; }
        public string StudentPhotoFileHeight { get; set; }
        public string StudentPhotoFilename { get; set; }
        public string StudentPhotoFileSize { get; set; }
        public string StudentPhotoFileWidth { get; set; }
        public string StudentPhotoType { get; set; }

        //--------------------------------------Extra properties-------------------------------------------------------
        public string errorMessage { get; set; }
        public string AccBalanceSheetName { get; set; }
        public string CentreName { get; set; }
        public decimal TotalFeeAmount { get; set; }
        public bool IsInstallmentApplicable { get; set; }
        public bool StatusFlag { get; set; }
        public string FeeCriteriaValueCombinationDescription { get; set; }
        public string Category { get; set; }
        public string AdmitAcademicYear { get; set; }
        public string BranchName { get; set; }
        public string SectionName { get; set; }
        public string DomicileState { get; set; }
        public string StudentName { get; set; }
        public string StudentCode { get; set; }
        public int StartRow { get; set; }
        public int EndRow { get; set; }
        public string FeeReceiptMasterFromDate { get; set; }
        public int AccBalsheetID { get; set; }
        public string XMLstring { get; set; }

        
        public string Address { get; set; }
        public string AddmissionYear { get; set; }
        public string AdmissionType { get; set; }
        public int PersonID { get; set; }
        public int TaskNotificationDetailsID { get; set; }
        public int TaskNotificationMasterID { get; set; }
        public int GeneralTaskReportingDetailsID { get; set; }
        public string TaskCode { get; set; }
        public int StageSequenceNumber { get; set; }
        public bool IsLastRecord { get; set; }
        public int AccBalanceSheetID { get; set; }
        public decimal ToalFeeAmount { get; set; }

        public int AccountID { get; set; }
        public int FeeReceivableVoucherStructureID { get; set; }
        public string AccountType { get; set; }
        public decimal Amount { get; set; }
        public bool CrDrStatus { get; set; }
        public string FeeSubShortDesc { get; set; }
        public Int16 Source { get; set; }
        public int SubTypeMasterID { get; set; }
        public string FeeApprovalXmlstring { get; set; }

        public int Student_CourseYearId { get;set;}
        public int StandardNumber {get; set; }
        public string CourseYearDesc { get; set; }
        public string StandardDescription { get; set; }

       
        public string PersonType { get; set; } 
        public string ReceiptNumber { get; set; } 
        public string SystemGeneratedReceiptNo { get; set; } 
        public string ReceiptDate { get; set; } 
        public decimal ReceiptAmount { get; set; } 
        public int ReceiptType { get; set; } 
        public string FeeChequeOrDDNumber { get; set; } 
        public string FeeChequeOrDDDate { get; set; } 
        public string FeeBankName { get; set; } 
        public string FeeBranchName { get; set; } 
        public string BranchCity { get; set; } 
        public bool IschequeORDD { get; set; } 
        public int FinancialYearID { get; set; }
        public string LateFeeAmount { get; set; }

        public string Gender { get; set; }
        public string EnrollmentNumber { get; set; }
        public string StudentEmailID { get; set; }
        public string BranchDescription { get; set; }
        public string BranchShortCode { get; set; }
        public string CourseYearCode { get; set; }       
        public string SessionName { get; set; }
        public string SectionDetailsDesc { get; set; }



        public int FeeCriteriaValueCombinationMasterID { get; set; }
        public int FeeStructureDetailsIDORFeeStructureInstallmentMasterID { get; set; }
        public decimal InstallmentAmount { get; set; }
        public int FeeReceivableDueListMasterID { get; set; }
        public int FeeReceivableDueListDetailsID{ get; set; }
        public int FeeReceivableDueListFeeTypeDetailsID { get; set; }
        public int NextFeeReceivableDueListDetailsID { get; set; }    
        public int AccSessionId { get; set; }
        public short FeeReceivableStatus { get; set; }
        public decimal FeeReceivedDueAmount { get; set; }
        public int InstallmentNumber { get; set; }
        public bool IsLumpsum { get; set; }
        public decimal ReceivedAmount { get; set; }
        public int ScholarShipAllocationID { get; set; }
        public int ScholarShipMasterID { get; set; }
        public string TransDate { get; set; }
        public string ScholarSheepDocumentNumber { get; set; }
        public bool IsApproved { get; set; }
        public string ApporvedBy { get; set; }
        public string ApproveStatus { get; set; }
        public int LastSectionDetailID { get; set; }
        public int ScholarShipTransactionDetailsID { get; set; }
        public int StudentAmissionDetailID { get; set; }
        public int SectionDetailId { get; set; }
        public int AcadCenterwiseSessionId { get; set; }
        public string StandarNumber { get; set; }
        public string ScholarShipDescription { get; set; }
        public bool IsScholarShipApplicable { get; set; }
        public decimal ScholarShipOrDiscountAmount { get; set; }

	}
}
