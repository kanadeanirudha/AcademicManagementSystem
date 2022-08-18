using System;
using System.Collections.Generic;

using AMS.Base.DTO;

namespace AMS.DTO
{
    public class OnlineExamStudentApplicableSearchRequest : Request
    {
        public int ID
        {
            get;
            set;
        }
        public int OnlineExaminationMasterID
        {
            get;
            set;
        }
        public int CourseYearID
        {
            get;
            set;
        }
        public string CentreCode
        {
            get;
            set;
        }
        public int SemesterMstID
        {
            get;
            set;
        }
        public int SectionDetailID
        {
            get;
            set;
        }
        public int SubjectID
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
