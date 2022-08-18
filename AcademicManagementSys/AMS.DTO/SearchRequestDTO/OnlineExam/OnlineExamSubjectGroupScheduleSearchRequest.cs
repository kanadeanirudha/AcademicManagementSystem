using System;
using System.Collections.Generic;

using AMS.Base.DTO;

namespace AMS.DTO
{
    public class OnlineExamSubjectGroupScheduleSearchRequest : Request
    {
        public int ID
        {
            get;
            set;
        }
        public String PaperSetCode
        {
            get;
            set;
        }

        public bool IsDeleted
        {
            get;
            set;
        }

        public string SortOrder
        {
            get;
            set;
        }
        public string CentreCode
        {
            get;
            set;
        }
     
        public int OnlineExamExaminationMasterID
        {
            get;
            set;
        }
        public int GenSessionMaster
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

        public int EndRow
        {
            get;
            set;
        }

        public int RowLength
        {
            get;
            set;
        }
        public string SearchBy
        {
            get;
            set;
        }
        public string SortDirection
        {
            get;
            set;
        }
    }
}
