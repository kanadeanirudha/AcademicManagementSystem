using System;
using System.Collections.Generic;
using AMS.Base.DTO;
namespace AMS.DTO
{
    public class OnlineExamAssignPaperChecker : BaseDTO
    {
        public byte ID
        {
            get;
            set;
        }
        public string PaperSet
        {
            get;
            set;
        }
        public int OnlineExamExaminationMasterID
        {
            get;
            set;
        }
        public int OnlineExamSubjectGroupScheduleID
        {
            get;
            set;
        }
        public int OnlineExamAllocateJobSupportStaffID
        {
            get;
            set;
        }
      
        public string PaperSetCode
        {
            get;
            set;
        }
        public int GeneralPaperSetMasterID
        {
            get;
            set;
        }
        public string CentreCode
        {
            get;
            set;
        }
        public int CourseYearID
        {
            get;
            set;
        }
        public int SectionDetailID
        {
            get;
            set;
        }
        public int OnlineExamExaminationCourseApplicableID
        {
            get;
            set;
        }
        public string ExaminationFor
        {
            get;
            set;
        }
        public string ExaminationName
        {
            get;
            set;
        }
        public int SemesterMstID
        {
            get;
            set;
        }
        public int SubjectGroupID
        {
            get;
            set;
        }
        public int GlobalSessionID
        {
            get;
            set;
        }
        public string SubjectGroupDescription
        {
            get;
            set;
        }
        public string SubjectShortDescription
        {
            get;
            set;
        }
        public int SubjectID
        {
            get;
            set;
        }
        public int OnlineExamQuestionPaperCheckerID
        {
            get;
            set;
        }
        public string OnlineExamAllocateJobSupportStaff
        {
            get;
            set;
        }
        public bool IsAllChecked
        {
            get;
            set;
        }
        public bool IsDeleted
        {
            get;
            set;
        }
        public string SelectedCentreCode
        {
            get;
            set;
        }
        public int SessionID
        {
            get;
            set;
        }
        public string SelectedExam
        {
            get;
            set;
        }
        public string AllotedJobName
        {
            get;
            set;
        }
        public string AllotedJobCode
        {
            get;
            set;
        }
        public string JobAllotedForCentreCode
        {
            get;
            set;
        }
        public int OnlineExamAllocateSupportStaffID
        {
            get;
            set;
        }
        public int SubjectGroupId
        {
            get;
            set;
        }
        public int EmployeeID
        {
            get;
            set;
        }
        public int RoleMasterID
        {
            get;
            set;
        }
        public string EmployeeFirstName
        {
            get;
            set;
        }
        public string EmployeeLastName
        {
            get;
            set;
        }
        public string EmployeeMiddleName
        {
            get;
            set;
        }
        public string FullName
        {
            get;
            set;
        }
        public int CreatedBy
        {
            get;
            set;
        }
        public DateTime CreatedDate
        {
            get;
            set;
        }
        public int ModifiedBy
        {
            get;
            set;
        }
        public DateTime ModifiedDate
        {
            get;
            set;
        }
        public int DeletedBy
        {
            get;
            set;
        }
        public DateTime DeletedDate
        {
            get;
            set;
        }
        public string errorMessage { get; set; }
    }
}
