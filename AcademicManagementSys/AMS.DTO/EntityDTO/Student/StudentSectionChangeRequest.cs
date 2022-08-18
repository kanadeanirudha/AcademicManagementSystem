using AMS.Base.DTO;
using System;
namespace AMS.DTO
{
	public class StudentSectionChangeRequest : BaseDTO
	{
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
		public int RequestSectionDetailId
		{
			get;
			set;
		}
		public int SessionID
		{
			get;
			set;
		}
		public string CentreCode
		{
			get;
			set;
		}
		public int OldSectionDetailID
		{
			get;
			set;
		}
		public string StatusOfRequest
		{
			get;
			set;
		}
		public int ApprovedEmployeeId
		{
			get;
			set;
		}
		public string ApprovedDate
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

        public string CentreName { get; set; }
        public string SessionName { get; set; }
        public string errorMessage { get; set; }

        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public int BranchId { get; set; }
        public int SectionDetailID { get; set; }
        public string BranchDescription { get; set; }
        public string SectionDesc { get; set; }
        public string CourseYearDesc { get; set; }
        public string AcademicYear { get; set; }
        public string AdmissionNumber { get; set; }
        public int CourseYearId { get; set; }
        public int SectionID { get; set; }
        public string SectionDetailCode { get; set; }
	}
}

