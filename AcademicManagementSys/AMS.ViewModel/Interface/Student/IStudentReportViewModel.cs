using AMS.DTO;
using System;

namespace AMS.ViewModel
{
    public interface IStudentReportViewModel
    {
        StudentReport StudentReportDTO { get; set; }
        int ID
        {
            get;
            set;
        }
        int StudentId
        {
            get;
            set;
        }
   
        string StudentFirstName
        {
            get;
            set;
        }
        string StudentMiddleName
        {
            get;
            set;
        }
        string StudentLastName
        {
            get;
            set;
        }
      
        string StudentCode
        {
            get;
            set;
        }
    
        string RollNumber
        {
            get;
            set;
        }
        int BranchID
        {
            get;
            set;
        }
        int UniversityID
        {
            get;
            set;
        }
        int SectionDetailID
        {
            get;
            set;
        }

         bool IsShowDiv
        {
            get;
            set;
        }
        string AcademicYear
        {
            get;
            set;
        }
        string CentreCode
        {
            get;
            set;
        }
        string AdmissionStatus
        {
            get;
            set;
        }
         string SortOrder
        {
            get;
            set;
        }
          bool ReportType
         {
             get;
             set;
         }
          string Course_Section
        {
            get;
            set;
        }
        int CourseYearId
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
        int? ModifiedBy
        {
            get;
            set;
        }
        DateTime? ModifiedDate
        {
            get;
            set;
        }
        int? DeletedBy
        {
            get;
            set;
        }
        DateTime? DeletedDate
        {
            get;
            set;
        }


        
    }
}

