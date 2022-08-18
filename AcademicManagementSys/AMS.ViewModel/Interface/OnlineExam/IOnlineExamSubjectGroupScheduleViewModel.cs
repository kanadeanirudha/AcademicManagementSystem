using AMS.DTO;
using System;
using System.Collections.Generic;

namespace AMS.ViewModel
{
    public interface IOnlineExamSubjectGroupScheduleViewModel
    {
        OnlineExamSubjectGroupSchedule OnlineExamSubjectGroupScheduleDTO
        {
            get;
            set;
        }

        Int32 ID
        {
            get;
            set;
        }
        string CentreCode
        {
            get;
            set;
        }
        int OnlineExamExaminationCourseApplicableID
        {
            get;
            set;
        }
        int OnlineExamExaminationMasterID
        {
            get;
            set;
        }
        int OnlineExamQuestionBankMasterID
        {
            get;
            set;
        }
        int SubjectID
        {
            get;
            set;
        }
        int SubjectGroupID
        {
            get;
            set;
        }
        int CourseYearID
        {
            get;
            set;
        }
        int SemesterMstID
        {
            get;
            set;
        }
        string CombinationCode
        {
            get;
            set;
        }
     
        //************for the form OnlineExamAllocateJobSupportStaff**********
       
        
      
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
        //List<GeneralSessionMaster> GetSessionNameList 
        //{ 
        //     get; 
        //     set; 
        //}
    }

}
