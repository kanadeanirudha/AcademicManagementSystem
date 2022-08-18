using System;
using System.Collections.Generic;

using AMS.Base.DTO;

namespace AMS.DTO
{
    public class OnlineExamStudentQuePaperCheckDetailsSearchRequest : Request
    {
        public int ID
        {
            get;
            set;
        }
        public int OnlineExamAllocateJobSupportStaffID
        {
            get;
            set;
        }
        public int SubjectGroupID
        {
            get;
            set;
        }
        public int OnlineExamSubjectGroupScheduleID
        {
            get;
            set;
        }
        public int OnlineExamQuestionPaperCheckerID
        {
            get;
            set;
        }
        public int OnlineExamIndStudentExamInfoID
        {
            get;
            set;
        }
        public int SubjectID
        {
            get;
            set;
        }
        public int OnlineExamQuestionBankMasterID
        {
            get;
            set;
        }
        public int PersonID
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
