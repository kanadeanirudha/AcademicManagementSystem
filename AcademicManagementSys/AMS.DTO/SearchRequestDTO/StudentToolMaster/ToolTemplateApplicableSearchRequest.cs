using AMS.Base.DTO;
using System;
namespace AMS.DTO
{
    public class ToolTemplateApplicableSearchRequest : Request
    {
        public int ID
        {
            get;
            set;
        }
        public string ExamName
        {
            get;
            set;
        }
        public string SortOrder
        {
            get;
            set;
        }
        public string SortBy
        {
            get;
            set;
        }
        public int StartRow
        {
            get;
            set;
        }
        public int RowLength
        {
            get;
            set;
        }
        public int EndRow
        {
            get;
            set;
        }
        public string SearchType
        {
            get;
            set;
        }

        public bool IsDeleted
        {
            get;
            set;
        }
        public string CentreCode
        {
            get;
            set;
        }
        public int UniversityID
        {
            get;
            set;
        }
        public string ScopeIdentity
        {
            get;
            set;
        }
        public int AdminRoleMasterID
        {
            get;
            set;
        }
        public string SortDirection { get; set; }
        public string SearchBy { get; set; }
    }
}
