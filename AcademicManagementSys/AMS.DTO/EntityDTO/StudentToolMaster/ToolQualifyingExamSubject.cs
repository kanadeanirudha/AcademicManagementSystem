using AMS.Base.DTO;
using System;
namespace AMS.DTO
{
    public class ToolQualifyingExamSubject : BaseDTO
    {
        public int ID
        {
            get;
            set;
        }
        public int QualifyingExamMstID
        {
            get;
            set;
        }
        public string SubjectName
        {
            get;
            set;
        }
        public int MarkOutOf
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
        public string ExamName
        {
            get;
            set;
        }
        public bool StatusFlag
        {
            get;
            set;
        }
        public string SelectedIDs
        {
            get;
            set;
        }
        public string errorMessage { get; set; }
    }
}
