using AMS.Base.DTO;
using System;
namespace AMS.DTO
{
    public class ScholarShipAllocation : BaseDTO
    {
        //-------------------Properties of table ScholarShipAllocation -----------------------------------
        public int ID
        {
            get;
            set;
        }
        public int StudentID
        {
            get;
            set;
        }
        public int ScholarShipMasterID
        {
            get;
            set;
        }
        public string TransDate
        {
            get;
            set;
        }
        public string ScholarSheepDocumentNumber
        {
            get;
            set;
        }
        public int BranchID
        {
            get;
            set;
        }
        public string BranchDesc
        {
            get;
            set;
        }
        public bool IsApproved
        {
            get;
            set;
        }
        public int ApporvedBy
        {
            get;
            set;
        }
        public string ApproveStatus
        {
            get;
            set;
        }
        public int LastSectionDetailID
        {
            get;
            set;
        }
        public bool IsActive
        {
            get;
            set;
        }
        public bool IsDeleted
        {
            get;
            set;
        }
        public int CreatedBy
        {
            get;
            set;
        }
        public DateTime CreatedDate
        {
            get;
            set;
        }
        public int? ModifiedBy
        {
            get;
            set;
        }
        public DateTime? ModifiedDate
        {
            get;
            set;
        }
        public int? DeletedBy
        {
            get;
            set;
        }
        public DateTime? DeletedDate
        {
            get;
            set;
        }

        //-------------------Properties of table ScholarShipTransactionDetails  -----------------------------------
        public int StudentAmissionDetailID
        {
            get;
            set;
        }
        public int ScholarShipAllocationID
        {
            get;
            set;
        }
        public int SectionDetailId
        {
            get;
            set;
        }        
        public decimal Amount
        {
            get;
            set;
        }
        public int AcadCenterwiseSessionId
        {
            get;
            set;
        }
        public string StandarNumber
        {
            get;
            set;
        }

        //--------------------------------------Extra properties-------------------------------------------------------
        public string StudentName
        {
            get;
            set;
        }
        public string SectionDetailDescription
        {
            get;
            set;
        }
        public string errorMessage { get; set; }
        public string SelectedBalanceSheet { get; set; }
        public int SelectedBalanceSheetID { get; set; }
        public int TaskNotificationDetailsID { get; set; }
        public int TaskNotificationMasterID { get; set; }
        public int GeneralTaskReportingDetailsID { get; set; }
        public string TaskCode { get; set; }
        public int StageSequenceNumber { get; set; }
        public bool IsLastRecord { get; set; }
        public string CentreName { get; set; }
        public string CentreCode { get; set; }
        public string XMLstring { get; set; }
        public string EntityLevel { get; set; }


        public int AcademicYearID { get; set; }
        public int AdmissionPatternID { get; set; }
        public int CourseYearId { get; set; }
        public string Gender { get; set; }
        public string EnrollmentNumber { get; set; }
        public string StandardNumber { get; set; }
        public int SectionDetailID { get; set; }
        public int OldSectionDetailID { get; set; }
        public string AdmitAcademicYear { get; set; }
        public string StudentEmailID { get; set; }
        public byte[] StudentPhoto { get; set; }
        public int StudentPhotoFileSize { get; set; }
        public string StudentPhotoFileHeight { get; set; }
        public string StudentPhotoFilename { get; set; }
        public string StudentSignatureFileSize { get; set; }
        public string StudentPhotoFileWidth { get; set; }
        public string StudentPhotoType { get; set; }
        public string BranchDescription { get; set; }
        public string BranchShortCode { get; set; }
        public string AdmissionPattern { get; set; }
        public string CourseYearDesc { get; set; }
        public string CourseYearCode { get; set; }
        public string SectionDetailsDesc { get; set; } 
        public string SessionName{ get; set; }
        public string ScholarShipDescription{ get; set; }
        public int PersonID { get; set; }
        public string FeeAccountSubTypeDesc{ get; set; }
        public int    AccountID { get; set; }
           public Int16 FeeAccountTypeCode { get; set; }
           public string CrDrStatusFlag { get; set; }
           public bool RequestApprovedStatus { get; set; }
    }
}