using AMS.Base.DTO;
using System;
namespace AMS.DTO
{
	public class OnlineExaminationQuestionPaperSetMaster : BaseDTO
	{
        //----------------------------------Properties of OnlineExaminationQuestionPaper table--------------------------------
		public int ID
		{
			get;
			set;
		}
		public string PaperSet
		{
			get;
			set;
		}
		public int OnlineExamExaminationMasterID
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

        //----------------------------------Properties of OnlineExaminationQuestionPaperDetails table--------------------------------
        public int OnlineExaminationQuestionPaperDetailsID
		{
			get;
			set;
		}
		public int OnlineExamExaminationQuestionPaperID
		{
			get;
			set;
		}
		public int OnlineExamQuestionBankDetailsID
		{
			get;
			set;
		}
		public Int16 OriginalOrder
		{
			get;
			set;
		}
        public string XMLString
        {
            get;
            set;
        }
        public string errorMessage
        {
            get;
            set;
        }
        public string PaperSetCode
        {
            get;
            set;
        }
        public string ExaminationName
        {
            get;
            set;
        }
        public string SubjectName
        {
            get;
            set;
        }    
        public int TotalQuestionSubjectWise
        {
            get;
            set;
        }        
		public int TotalQuestion
        {
            get;
            set;
        }        	
		public int OnlineExamQuestionBankMasterID
        {
            get;
            set;
        }        		
		public bool IsQuestionInImage
        {
            get;
            set;
        }  	
		public string QuestionLableText
        {
            get;
            set;
        }
        public string ImageName
        {
            get;
            set;
        }
        public bool SubjectWiseStatus
        {
            get;
            set;
        }  	
        public int SubjectWiseCount
        {
            get;
            set;
        }        		
        public int SubjectWiseTotalQuestion
        {
            get;
            set;
        }
        public int TotalRecords
        {
            get;
            set;
        }
        public bool IsViewOnly { get; set; }
	}
}