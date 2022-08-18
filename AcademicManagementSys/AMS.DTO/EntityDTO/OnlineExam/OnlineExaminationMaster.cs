using AMS.Base.DTO;
using System;
namespace AMS.DTO
{
	public class OnlineExaminationMaster : BaseDTO
	{
        //----------------------------------Properties of OnlineExamExaminationMaster table--------------------------------
		public int ID
		{
			get;
			set;
		}
		public string ExaminationName
		{
			get;
			set;
		}
		public string Purpose
		{
			get;
			set;
		}
		public int AcadSessionId
		{
			get;
			set;
		}
        public Int16 TotalTime
		{
			get;
			set;
		}
		public Int16 TotalQuestion
		{
			get;
			set;
		}
		public decimal TotalMarks
		{
			get;
			set;
		}
		public decimal MarksInEachQuestion
		{
			get;
			set;
		}
		public Boolean IsNegativeMarkingApplicable
		{
			get;
			set;
		}
		public decimal NegativeMarksInEachQuestion
		{
			get;
			set;
		}
		public Int16 TotalPaperSet
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

        //----------------------------------Properties of OnlineExamExaminationSubjectApplicable  table--------------------------------
        public int OnlineExaminationSubjectApplicableID
        {
            get;
            set;
        }
        public int OnlineExamExaminationMasterID
        {
            get;
            set;
        }
        public Int16 TotalQuestionQueTypeWise
        {
            get;
            set;
        }
        public int SubjectID
        {
            get;
            set;
        }
        public string QuestionType
        {
            get;
            set;
        }
        public string errorMessage
        {
            get;
            set;
        }
        public int QuestionTypeID
        {
            get;
            set;
        }
        public string SubjectName
        {
            get;
            set;
        }
        public string XMLString
        {
            get;
            set;
        }
    }
}
