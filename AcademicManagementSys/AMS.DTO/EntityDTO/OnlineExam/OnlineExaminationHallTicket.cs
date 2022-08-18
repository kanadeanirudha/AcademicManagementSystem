using AMS.Base.DTO;
using System;
namespace AMS.DTO
{
	public class OnlineExaminationHallTicket : BaseDTO
	{
        //----------------------------------Properties of OnlineExaminationHallTicket table--------------------------------
		public int ID
		{
			get;
			set;
		}
        public int StudentRegistrationID
        {
            get;
            set;
        }
        public string RegistrationNumber
        {
            get;
            set;
        }
		
        public int RollNumber
        {
            get;
            set;
        }
        public string StudentFullName
        {
            get;
            set;
        }
        public string ExaminationName
        {
            get;
            set;
        }
        
        
        public string Gender
        {
            get;
            set;
        }
        public string CasteAsPerLeaving
        {
            get;
            set;
        }
        public string ExamDate
        {
            get;
            set;
        }
        public string ExamTime
        {
            get;
            set;
        }
        public string Venue
        {
            get;
            set;
        }
        public string Venue1
        {
            get;
            set;
        }
        public byte[] StudentSignature
        {
            get;
            set;
        }
        public byte[] StudentPhoto
        {
            get;
            set;
        }
        public string StudentSignatureFilename
        {
            get;
            set;
        }
        public string StudentPhotoFilename
        {
            get;
            set;
        }
        public string StudentPhotoFileSize
        {
            get;
            set;
        }
        public string StudentSignatureFileSize
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
		public int ModifiedBy
		{
			get;
			set;
		}
		public DateTime ModifiedDate
		{
			get;
			set;
		}
		public int DeletedBy
		{
			get;
			set;
		}
		public DateTime DeletedDate
		{
			get;
			set;
		}

    }
}
