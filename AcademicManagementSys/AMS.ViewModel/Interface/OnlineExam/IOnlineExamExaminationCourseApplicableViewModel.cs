using AMS.DTO;
using System;
using System.Collections.Generic;

namespace AMS.ViewModel
{
    public interface IOnlineExamExaminationCourseApplicableViewModel
    {
        OnlineExamExaminationCourseApplicable OnlineExamExaminationCourseApplicableDTO
        {
            get;
            set;
        }

        Int32 ID
        {
            get;
            set;
        }
        //Int32 OnlineExamExaminationMasterID
        //{
        //    get;
        //    set;
        //}

        Int32 CourseYearID
        {
            get;
            set;
        }
        //Int32 SemesterTypeId
        //{
        //    get;
        //    set;
        //}
        Int32 DepartmentID
        {
            get;
            set;
        }
        //bool ExaminationStatus
        //{
        //    get;
        //    set;
        //}
        bool IsDeleted
        {
            get;
            set;
        }
        string ExaminationStartDate
        {
            get;
            set;
        }
        string ExaminationEndDate
        {
            get;
            set;
        }
        string ResultAnnounceDate
        {
            get;
            set;
        }
        string Semester
        {
            get;
            set;
        }
        //bool IsResultAnnounce
        //{
        //    get;
        //    set;
        //}
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
        //List<OrganisationSemesterMaster> ListOrganisationSemesterMaster { get; set; }
        //List<GeneralSessionMaster> GetSessionNameList 
        //{ 
        //     get; 
        //     set; 
        //}
    }

}
