using System;
using System.Collections.Generic;
using AMS.Base.DTO;
namespace AMS.DTO
{
    public class OnlineExamSubjectGroupSchedule : BaseDTO
    {
        public int ID
        {
            get;
            set;
        }
        public int OnlineExamSectionScheduleID
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
        public int OnlineExamExaminationCourseApplicableID
        {
            get;
            set;
        }
        public int OnlineExamExaminationMasterID
        {
            get;
            set;
        }
        public int OnlineExamQuestionBankMasterID
        {
            get;
            set;
        }
        public int SubjectID
        {
            get;
            set;
        }
        public string SelectedCentreCode
        {
            get;
            set;
        }
        public string CourseYearName
        {
            get;
            set;
        }
        public string CourseYearCode
        {
            get;
            set;
        }
        public string OrgSemesterName
        {
            get;
            set;
        }
        public string SelectedExam
        {
            get;
            set;
        }
        public int SubjectGroupID
        {
            get;
            set;
        }
        public int SessionID
        {
            get;
            set;
        }
        public string ExaminationStartDate
        {
            get;
            set;
        }
        public string ExaminationEndDate
        {
            get;
            set;
        }
        public string ExamName
        { 
          get; 
          set; 
        }
        public string ExaminationStartTime
        {
            get;
            set;
        }
        public string ExaminationEndTime
        {
            get;
            set;
        }
        public byte TotalQuestions
        {
            get;
            set;
        }
        public byte TotalMarks
        {
            get;
            set;
        }
        public int SectionDetailsID 
        {
            get;
            set;
        }
        public byte TotalPaperSet
        {
            get;
            set;
        }
        public byte PassingMarks
        {
            get;
            set;
        }
        public byte MarksForEachQues
        {
            get;
            set;
        }
        public bool IsNegavieMarking
        {
            get;
            set;
        }
        public decimal MarksToBeDeducted
        {
            get;
            set;
        }

        public byte Level1Marks
        {
            get;
            set;
        }
        public byte Level2Marks
        {
            get;
            set;
        }
        public byte Level3Marks
        {
            get;
            set;
        }
        public byte Level1TimeInMinutes
        {
            get;
            set;
        }
        public byte Level2TimeInMinutes
        {
            get;
            set;
        }
        public byte Level3TimeInMinutes
        {
            get;
            set;
        }
        public byte Level4TimeInMinutes
        {
            get;
            set;
        }
        public byte FixedFlexibleTime
        {
            get;
            set;
        }
        public byte ExamDuration
        {
            get;
            set;
        }
        public byte DayOpenTime
        {
            get;
            set;
        }
        public byte DayCloseTime
        {
            get;
            set;
        }
        public byte ExaminationStatus
        {
            get;
            set;
        }

        public bool IsScheduleForAllSections
        {
            get;
            set;
        }
        public string SectionScheduleList
        {
            get;
            set;
        }
        public bool IsActive
        {
            get;
            set;
        }
        public string ExaminationName
        {
            get;
            set;
        }
        public string Purpose
        {
            get;
            set;
        }
        public string ParameterXml
        {
            get;
            set;
        }
        public int AcadSessionID
        {
            get;
            set;
        }
        public string ExaminationFor
        {
            get;
            set;
        }
        public int CourseYearID
        {
            get;
            set;
        }
        public string CentreCode
        {
            get;
            set;
        }
        public int BranchID
        {
            get;
            set;
        }
        public int SemesterMstID
        {
            get;
            set;
        }
        public string SubjectGroupDescription
        {
            get;
            set;
        }
        public string CombinationCode
        {
            get;
            set;
        }
        public string SubjectShortDescription
        {
            get;
            set;
        }
        public bool ViewFlag
        {
            get;
            set;
        }
        public bool IsTimeFlexible
        {
            get;
            set;
        }
        //Common fields
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
    }
}
