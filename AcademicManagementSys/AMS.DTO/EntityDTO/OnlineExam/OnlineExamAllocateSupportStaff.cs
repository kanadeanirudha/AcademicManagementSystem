
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AMS.Base.DTO;
using System;
namespace AMS.DTO
{
    public class OnlineExamAllocateSupportStaff : BaseDTO
    {
        public int ID
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
        public int OnlineExamExaminationMasterID
        {
            get;
            set;
        }

        //**********Fields From OnlineExamAllocateJobSupportStaff Form
        public int OnlineExamAllocateJobSupportStaffID
        {
            get; 
            set; 
        }
        //public OnlineExamAllocateSupportStaff OnlineExamAllocateSupportStaffDTO
        //{
        //    get;
        //    set;
        //}
        
        public string AllotedJobName
        {
            get;
            set;
        }
        public string ExaminationName
        {
            get;
            set;
        }
        public string EmployeeFullName
        {
            get;
            set;
        }
        public string AllotedJobCode
        {
            get;
            set;
        }
        public string SubjectName
        {
            get;
            set;
        }
        public string SubjectCode
        {
            get;
            set;
        }

        public string CentreCode
        {
            get;
            set;
        }
        public string CentreName
        {
            get;
            set;
        }
        public string JobAllotedForCentreCode
        {
            get;
            set;
        }
        public string JobStartDate
        {
            get;
            set;
        }
        public string JobEndDate
        {
            get;
            set;
        }
        public byte JobTargetInNumber
        {
            get;
            set;
        }
        public int OnlineExamAllocateSupportStaffID
        {
            get;
            set;
        }
        public bool IsJobCompleted
        {
            get;
            set;
        }
        public bool JobStatusFlag
        {
            get;
            set;
        }
        public string ComplitionDate
        {
            get;
            set;
        }
        public bool IsNotificationNeedToSentCompulsory
        {
            get;
            set;
        }
        public byte JobCompleteInNumber
        {
            get;
            set;
        }
        public int SubjectGroupId
        {
            get;
            set;
        }
        public int AcademicSessionID
        {
            get;
            set;
        }
        public int SessionID
        {
            get;
            set;
        }
        public string Session
        {
            get;
            set;
        }
       
        public bool IsDeleted
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
        public string SelectedCentreCode
        {
            get;
            set;
        }
        public string SelectedExam
        {
            get;
            set;
        }
        // public string MenuCode { get; set; }
    }
}
