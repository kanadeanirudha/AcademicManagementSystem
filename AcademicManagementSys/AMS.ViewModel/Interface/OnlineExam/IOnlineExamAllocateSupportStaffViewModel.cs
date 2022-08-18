using AMS.DTO;
using System;
using System.Collections.Generic;

namespace AMS.ViewModel
{
    public interface IOnlineExamAllocateSupportStaffViewModel
    {
        OnlineExamAllocateSupportStaff OnlineExamAllocateSupportStaffDTO
        {
            get;
            set;
        }

        Int32 ID
        {
            get;
            set;
        }
        Int32 EmployeeID
        {
            get;
            set;
        }
        //Int32 RoleDetailID
        //{
        //    get;
        //    set;
        //}
       
        Int32 OnlineExamExaminationMasterID
        {
            get;
            set;
        }
        //************for the form OnlineExamAllocateJobSupportStaff**********
        string AllotedJobName
        {
            get;
            set;
        }
        String AllotedJobCode
        {
            get;
            set;
        }

        String JobAllotedForCentreCode
        {
            get;
            set;
        }
        String JobStartDate
        {
            get;
            set;
        }
        String JobEndDate
        {
            get;
            set;
        }
        //Byte JobTargetInNumber
        //{
        //    get;
        //    set;
        //}
        //Int32 OnlineExamAllocateSupportSfaffID
        //{
        //    get;
        //    set;
        //}
        //bool IsJobCompleted
        //{
        //    get;
        //    set;
        //}
        //String ComplitionDate
        //{
        //    get;
        //    set;
        //}
        bool IsNotificationNeedToSentCompulsory
        {
            get;
            set;
        }
        //Byte JobCompleteInNumber
        //{
        //    get;
        //    set;
        //}
        Int32 SubjectGroupId
        {
            get;
            set;
        }
        
        Int32 AcademicSessionID
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
        //List<GeneralSessionMaster> GetSessionNameList 
        //{ 
        //     get; 
        //     set; 
        //}
    }

}
