﻿using AMS.Base.DTO;

namespace AMS.DTO
{
    public class CRMCallTypeSearchRequest : Request
    {
        public int ID
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
