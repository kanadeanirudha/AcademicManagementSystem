﻿using AMS.Base.DTO;
using System;
namespace AMS.DTO
{
    public class EmployeeDocumentRequiredSearchRequest : Request
    {
        public int ID
        {
            get;
            set;
        }
        public int DocumentID
        {
            get;
            set;
        }
        public int LeaveRuleMasterID
        {
            get;
            set;
        }
        public bool DocumentCompulsaryFlag
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
        public string CentreCode { get; set; }
        public string EntityLevel { get; set; }
        public int AdminRoleMasterID { get; set; }
    }
}
