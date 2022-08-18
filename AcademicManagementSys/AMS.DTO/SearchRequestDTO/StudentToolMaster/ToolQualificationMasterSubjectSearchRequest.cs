using AMS.Base.DTO;
using System;
namespace AMS.DTO
{
    public class ToolQualificationMasterSubjectSearchRequest : Request
    {
        public int ID
        {
            get;
            set;
        }
        public int QualificationMstID
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
        public int BranchDetailID
        {
            get;
            set;
        }
        public int StandardNumber
        {
            get;
            set;
        }
        public string EducationType
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
        public string SearchBy { get; set; }
        public string SortDirection { get; set; }
    }
}
