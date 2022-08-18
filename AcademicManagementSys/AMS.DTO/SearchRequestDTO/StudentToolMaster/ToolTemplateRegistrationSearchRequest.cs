using AMS.Base.DTO;
using System;
namespace AMS.DTO
{
    public class ToolTemplateRegistrationSearchRequest : Request
    {
        public int ID
        {
            get;
            set;
        }
        public string Title
        {
            get;
            set;
        }
        public int ParentID
        {
            get;
            set;
        }
        public int NumberOfColumn
        {
            get;
            set;
        }
        public int SequenceNo
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
