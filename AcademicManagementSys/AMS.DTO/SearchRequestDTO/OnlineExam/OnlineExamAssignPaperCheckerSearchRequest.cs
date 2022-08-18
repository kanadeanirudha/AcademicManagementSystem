using System;
using System.Collections.Generic;

using AMS.Base.DTO;

namespace AMS.DTO
{
    public class OnlineExamAssignPaperCheckerSearchRequest : Request
    {
        public int ID
        {
            get;
            set;
        }
        public char PaperSet
        {
            get;
            set;
        }
        public int OnlineExamExaminationMasterID
        {
            get;
            set;
        }
        public int SubjectGroupId
        {
            get;
            set;
        }
        public int GlobalSessionID
        {
            get;
            set;
        }
        public string SearchWord
        {
            get;
            set;
        }
        public int OnlineExamSubjectGroupScheduleID
        {
            get;
            set;
        }
        public int SectionDetailID
        {
            get;
            set;
        }
        public int OnlineExamAllocateJobSupportStaffID
        {
            get;
            set;
        }
        public int GenSessionMaster
        {
            get;
            set;
        }
        public int CourseYearID
        {
            get;
            set;
        }
        public int SemesterMstID
        {
            get;
            set;
        }
        public string CentreCode
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
