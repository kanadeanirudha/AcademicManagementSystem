using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AMS.Base.DTO;
using System;
namespace AMS.DTO
{
    public class OnlineExamExaminationCourseApplicable : BaseDTO
    {
        public int ID
        {
            get;
            set;
        }
        public Int32 OnlineExamExaminationMasterId
        {
            get;
            set;
        }
        public Int32 OnlineExamExaminationMasterID
        {
            get;
            set;
        }
        public Int32 CourseYearID
        {
            get;
            set;
        }
        public String Description
        {
            get;
            set;
        }
        public Int32 SemesterMstID
        {
            get;
            set;
        }
        public Int32 DepartmentID
        {
            get;
            set;
        }
        public String DepartmentName
        {
            get;
            set;
        }
        public String Semester
        {
            get;
            set;
        }
        public byte ExaminationStatus
        {
            get;
            set;
        }

        public String ExaminationStartDate
        {
            get;
            set;
        }
        public String ExaminationEndDate
        {
            get;
            set;
        }
        public String ResultAnnounceDate
        {
            get;
            set;
        }
        public bool IsResultAnnounce
        {
            get;
            set;
        }
        //for OnlineExamExamination Master
        public string ExaminationName
        {
            get;
            set;
        }
        public String Purpose
        {
            get;
            set;
        }
        public Int32 AcadSessionId
        {
            get;
            set;
        }
        public String ExaminationFor
        {
            get;
            set;
        }
        //public Int32 SemesterMstID
        //{ get; 
        //  set; }
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
        // public string MenuCode { get; set; }
    }
}
