using AMS.Base.DTO;
using System;
namespace AMS.DTO
{
	public class FeeRefundMaster : BaseDTO
	{
		public int ID
		{
			get;
			set;
		}
		public Int16 AccSessionID
		{
			get;
			set;
		}
		public string CentreCode
		{
			get;
			set;
		}
        public string CentreName
        {
            get;
            set;
        }
		public int AcademicYearID
		{
			get;
			set;
		}
		public string PersonType
		{
			get;
			set;
		}
		public int PersonID
		{
			get;
			set;
		}
		public bool IsRefundByCashOrBank
		{
			get;
			set;
		}
		public string Remark
		{
			get;
			set;
		}
		public decimal RefundAmount
		{
			get;
			set;
		}
		public string RefundDate
		{
			get;
			set;
		}
		public string ChequeNumber
		{
			get;
			set;
		}
		public string ChequeDate
		{
			get;
			set;
		}
        public bool IsRefundGiven
		{
			get;
			set;
		}
        public string EntityLevel
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
        public string errorMessage { get; set; }
        public string SelectedXml { get; set; }
        public int StudentID{ get; set; }
        public string StudentName{ get; set; }
        public string BranchDescription{ get; set; }
        public string SessionName { get; set; }
        public string BranchShortCode { get; set; }
        public string AccountName{ get; set; }
        public int AccountID { get; set; }
        public string AcademicYear { get; set; }
        public string EmailID { get; set; }
        public string Course { get; set; }
        public string Section { get; set; }
        public string AdmissionPattern { get; set; }
        public string EnrollmentNumber { get; set; }
        public string StandardNumber { get; set; }
        public string AdmitAcademicYear { get; set; }
        public string Gender { get; set; }
        public byte[] StudentPhoto { get; set; }
        public string StudentPhotoFileHeight { get; set; }
        public string StudentPhotoFilename { get; set; }
        public string StudentPhotoFileSize { get; set; }
        public string StudentPhotoFileWidth { get; set; }
        public string StudentPhotoType { get; set; }
        public string AccountType{ get; set; }
        public string SectionDetailsDesc { get; set; }
        public int AccountIDForStudentOutStanding { get; set; }
        public string XmlString { get; set; }
        public Int16 AccBalsheetID
		{
			get;
			set;
		}
	}
}
