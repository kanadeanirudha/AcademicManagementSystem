using AMS.Base.DTO;
using System;
namespace AMS.DTO
{
    public class ToolTemplateApplicable : BaseDTO
    {
        public int ID
        {
            get;
            set;
        }
        public int TemplateID
        {
            get;
            set;
        }
        public string TemplateName
        {
            get;
            set;
        }
        public int BranchDetailID
        {
            get;
            set;
        }
        public string BranchDescription
        {
            get;
            set;
        }
        public string DivisionDescription
        {
            get;
            set;
        }
        public int StandardNumber
        {
            get;
            set;
        }
        public int CentreWiseSessionID
        {
            get;
            set;
        }
        public bool IsApplicableForEntranceExam
        {
            get;
            set;
        }
        public string FromDate
        {
            get;
            set;
        }
        public string ToDate
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
        public bool StatusFlag
        {
            get;
            set;
        }
        public string CenterName
        {
            get;
            set;
        }
        public string UniversityName
        {
            get;
            set;
        }
    }
}
