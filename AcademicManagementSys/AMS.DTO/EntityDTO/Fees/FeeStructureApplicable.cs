using AMS.Base.DTO;
using System;
namespace AMS.DTO
{
	public class FeeStructureApplicable : BaseDTO
	{
        //--------------------------------------Properties of FeeStructureSessionMaster table---------------------------------
        public int ID
		{
			get;
			set;
		}
		public int FeeStructureMasterID { get; set; }
        public bool RequestApprovalStatus { get; set; }
        public string ApplicableFromDate { get; set; }
        public string ApplicableToDate { get; set; }
		public string CentreCode { get; set; }
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

        //--------------------------------------Properties of FeeStructureApplicableDetails table---------------------------------
        public int FeeStructureApplicableDetailsID { get; set; }
		public string EntityType { get; set; }
		public int EntityID { get; set; }

        //----------------------------------------FeeStructureApplicableHistory Table---------------------------------
        public int FeeStructureApplicableHistoryID { get; set; }
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
        public string FeeStructureApplicableFromDate { get; set; }
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
        
	}
}
