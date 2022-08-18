
using AMS.DTO;
using System;
using System.Collections.Generic;

namespace AMS.ViewModel
{
    public interface IOnlineExamAssignPaperCheckerViewModel
    {
        OnlineExamAssignPaperChecker OnlineExamAssignPaperCheckerDTO
        {
            get;
            set;
        }

        Byte ID
        {
            get;
            set;
        }
        string PaperSet
        {
            get;
            set;
        }
        int OnlineExamExaminationMasterID
        {
            get;
            set;
        }

        int OnlineExamSubjectGroupScheduleID
        {
            get;
            set;
        }

        int OnlineExamAllocateJobSupportStaffID
        {
            get;
            set;
        }

        bool IsDeleted
        {
            get;
            set;
        }
        int CreatedBy
        {
            get;
            set;
        }
        DateTime CreatedDate
        {
            get;
            set;
        }
        int ModifiedBy
        {
            get;
            set;
        }
        DateTime ModifiedDate
        {
            get;
            set;
        }
        int DeletedBy
        {
            get;
            set;
        }
        DateTime DeletedDate
        {
            get;
            set;
        }
        string errorMessage { get; set; }
    }
}
