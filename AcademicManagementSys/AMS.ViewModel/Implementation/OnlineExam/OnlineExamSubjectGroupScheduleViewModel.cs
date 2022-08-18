using AMS.Common;
using AMS.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AMS.ViewModel
{
    public class OnlineExamSubjectGroupScheduleViewModel : IOnlineExamSubjectGroupScheduleViewModel
    {

        public OnlineExamSubjectGroupScheduleViewModel()
        {
            OnlineExamSubjectGroupScheduleDTO = new OnlineExamSubjectGroupSchedule();
            SessionNameList = new List<GeneralSessionMaster>();
            EmployeenameList = new List<EmpEmployeeMaster>();
        }
        public List<GeneralSessionMaster> SessionNameList { get; set; }
        public IEnumerable<SelectListItem> SessionNameListItems { get { return new SelectList(SessionNameList, "SessionID", "SessionName"); } }

        public List<EmpEmployeeMaster> EmployeenameList { get; set; }
        public IEnumerable<SelectListItem> EmployeenameListItem { get { return new SelectList(EmployeenameListItem, "EmployeeID", "Employeename"); } }
        public OnlineExamSubjectGroupSchedule OnlineExamSubjectGroupScheduleDTO
        {
            get;
            set;
        }

        public int ID
        {
            get
            {
                return (OnlineExamSubjectGroupScheduleDTO != null && OnlineExamSubjectGroupScheduleDTO.ID > 0) ? OnlineExamSubjectGroupScheduleDTO.ID : new int();
            }
            set
            {
                OnlineExamSubjectGroupScheduleDTO.ID = value;
            }
        }
        public int OnlineExamSectionScheduleID
        {
            get
            {
                return (OnlineExamSubjectGroupScheduleDTO != null && OnlineExamSubjectGroupScheduleDTO.OnlineExamSectionScheduleID > 0) ? OnlineExamSubjectGroupScheduleDTO.OnlineExamSectionScheduleID : new int();
            }
            set
            {
                OnlineExamSubjectGroupScheduleDTO.OnlineExamSectionScheduleID = value;
            }
        }

        public int OnlineExamSubjectGroupScheduleID
        {
            get
            {
                return (OnlineExamSubjectGroupScheduleDTO != null && OnlineExamSubjectGroupScheduleDTO.OnlineExamSubjectGroupScheduleID > 0) ? OnlineExamSubjectGroupScheduleDTO.OnlineExamSubjectGroupScheduleID : new int();
            }
            set
            {
                OnlineExamSubjectGroupScheduleDTO.OnlineExamSubjectGroupScheduleID = value;
            }
        }


        public int SectionDetailID
        {
            get
            {
                return (OnlineExamSubjectGroupScheduleDTO != null && OnlineExamSubjectGroupScheduleDTO.SectionDetailID > 0) ? OnlineExamSubjectGroupScheduleDTO.SectionDetailID : new int();
            }
            set
            {
                OnlineExamSubjectGroupScheduleDTO.SectionDetailID = value;
            }
        }
        public int OnlineExamExaminationCourseApplicableID
        {
            get
            {
                return (OnlineExamSubjectGroupScheduleDTO != null && OnlineExamSubjectGroupScheduleDTO.OnlineExamExaminationCourseApplicableID > 0) ? OnlineExamSubjectGroupScheduleDTO.OnlineExamExaminationCourseApplicableID : new int();
            }
            set
            {
                OnlineExamSubjectGroupScheduleDTO.OnlineExamExaminationCourseApplicableID = value;
            }
        }

        public int OnlineExamExaminationMasterID
        {
            get
            {
                return (OnlineExamSubjectGroupScheduleDTO != null && OnlineExamSubjectGroupScheduleDTO.OnlineExamExaminationMasterID > 0) ? OnlineExamSubjectGroupScheduleDTO.OnlineExamExaminationMasterID : new int();
            }
            set
            {
                OnlineExamSubjectGroupScheduleDTO.OnlineExamExaminationMasterID = value;
            }
        }
        public int OnlineExamQuestionBankMasterID
        {
            get
            {
                return (OnlineExamSubjectGroupScheduleDTO != null && OnlineExamSubjectGroupScheduleDTO.OnlineExamQuestionBankMasterID > 0) ? OnlineExamSubjectGroupScheduleDTO.OnlineExamQuestionBankMasterID : new int();
            }
            set
            {
                OnlineExamSubjectGroupScheduleDTO.OnlineExamQuestionBankMasterID = value;
            }
        }
        [Display(Name = "Select Exam")]
        public string SelectedExam
        {
            get
            {
                return (OnlineExamSubjectGroupScheduleDTO != null) ? OnlineExamSubjectGroupScheduleDTO.SelectedExam : string.Empty;
            }
            set
            {
                OnlineExamSubjectGroupScheduleDTO.SelectedExam = value;
            }
        }
        [Display(Name = "Centre Name")]
        public string SelectedCentreCode
        {
            get
            {
                return (OnlineExamSubjectGroupScheduleDTO != null) ? OnlineExamSubjectGroupScheduleDTO.SelectedCentreCode : string.Empty;
            }
            set
            {
                OnlineExamSubjectGroupScheduleDTO.SelectedCentreCode = value;
            }
        }
        public string CourseYearName
        {
            get
            {
                return (OnlineExamSubjectGroupScheduleDTO != null) ? OnlineExamSubjectGroupScheduleDTO.CourseYearName : string.Empty;
            }
            set
            {
                OnlineExamSubjectGroupScheduleDTO.CourseYearName = value;
            }
        }
        public string CourseYearCode
        {
            get
            {
                return (OnlineExamSubjectGroupScheduleDTO != null) ? OnlineExamSubjectGroupScheduleDTO.CourseYearCode : string.Empty;
            }
            set
            {
                OnlineExamSubjectGroupScheduleDTO.CourseYearCode = value;
            }
        }

        public string SectionScheduleList
        {
            get
            {
                return (OnlineExamSubjectGroupScheduleDTO != null) ? OnlineExamSubjectGroupScheduleDTO.SectionScheduleList : string.Empty;
            }
            set
            {
                OnlineExamSubjectGroupScheduleDTO.SectionScheduleList = value;
            }
        }
        public string OrgSemesterName
        {
            get
            {
                return (OnlineExamSubjectGroupScheduleDTO != null) ? OnlineExamSubjectGroupScheduleDTO.OrgSemesterName : string.Empty;
            }
            set
            {
                OnlineExamSubjectGroupScheduleDTO.OrgSemesterName = value;
            }
        }
        public int SubjectID
        {
            get
            {
                return (OnlineExamSubjectGroupScheduleDTO != null && OnlineExamSubjectGroupScheduleDTO.SubjectID > 0) ? OnlineExamSubjectGroupScheduleDTO.SubjectID : new int();
            }
            set
            {
                OnlineExamSubjectGroupScheduleDTO.SubjectID = value;
            }
        }
        public int SubjectGroupID
        {
            get
            {
                return (OnlineExamSubjectGroupScheduleDTO != null && OnlineExamSubjectGroupScheduleDTO.SubjectGroupID > 0) ? OnlineExamSubjectGroupScheduleDTO.SubjectGroupID : new int();
            }
            set
            {
                OnlineExamSubjectGroupScheduleDTO.SubjectGroupID = value;
            }
        }
        public int SessionID
        {
            get
            {
                return (OnlineExamSubjectGroupScheduleDTO != null && OnlineExamSubjectGroupScheduleDTO.SessionID > 0) ? OnlineExamSubjectGroupScheduleDTO.SessionID : new int();
            }
            set
            {
                OnlineExamSubjectGroupScheduleDTO.SessionID = value;
            }
        }
        [Required(ErrorMessage = "Please Enter Examination Start Date.")]
        [Display(Name = " Examination Start Date")]
        public string ExaminationStartDate
        {
            get
            {
                return (OnlineExamSubjectGroupScheduleDTO != null) ? OnlineExamSubjectGroupScheduleDTO.ExaminationStartDate : string.Empty;
            }
            set
            {
                OnlineExamSubjectGroupScheduleDTO.ExaminationStartDate = value;
            }
        }
         [Required(ErrorMessage = "Please Enter Examination End Date.")]
         [Display(Name = "Examination End Date")]
        public string ExaminationEndDate
        {
            get
            {
                return (OnlineExamSubjectGroupScheduleDTO != null) ? OnlineExamSubjectGroupScheduleDTO.ExaminationEndDate : string.Empty;
            }
            set
            {
                OnlineExamSubjectGroupScheduleDTO.ExaminationEndDate = value;
            }
        }
        [Required(ErrorMessage = "Please Enter Examination Start Time.")]
        [Display(Name = "Examination Start Time")]
         public string ExaminationStartTime
        {
            get
            {
                return (OnlineExamSubjectGroupScheduleDTO != null) ? OnlineExamSubjectGroupScheduleDTO.ExaminationStartTime : string.Empty;
            }
            set
            {
                OnlineExamSubjectGroupScheduleDTO.ExaminationStartTime = value;
            }
        }
        [Required(ErrorMessage = "Please Enter Examination End Time.")]
        [Display(Name = "Examination End Time")]
        public string ExaminationEndTime
        {
            get
            {
                return (OnlineExamSubjectGroupScheduleDTO != null) ? OnlineExamSubjectGroupScheduleDTO.ExaminationEndTime : string.Empty;
            }
            set
            {
                OnlineExamSubjectGroupScheduleDTO.ExaminationEndTime = value;
            }
        }
        [Required(ErrorMessage = "Please Enter Total Questions.")]
        [Display(Name = "Total Questions")]
        public byte TotalQuestions
        {
            get
            {
                return (OnlineExamSubjectGroupScheduleDTO != null) ? OnlineExamSubjectGroupScheduleDTO.TotalQuestions : new byte();
            }
            set
            {
                OnlineExamSubjectGroupScheduleDTO.TotalQuestions = value;
            }
        }
        [Required(ErrorMessage = "Please Enter Total Marks.")]
        [Display(Name = "Total Marks")]
        public byte TotalMarks
        {
            get
            {
                return (OnlineExamSubjectGroupScheduleDTO != null) ? OnlineExamSubjectGroupScheduleDTO.TotalMarks : new byte();
            }
            set
            {
                OnlineExamSubjectGroupScheduleDTO.TotalMarks = value;
            }
        }
        [Display(Name = "Exam Name")]
        public string ExamName
        {
            get
            {
                return (OnlineExamSubjectGroupScheduleDTO != null) ? OnlineExamSubjectGroupScheduleDTO.ExamName : string.Empty;
            }
            set
            {
                OnlineExamSubjectGroupScheduleDTO.ExamName = value;
            }
        }
        public string ParameterXml
        {
            get
            {
                return (OnlineExamSubjectGroupScheduleDTO != null) ? OnlineExamSubjectGroupScheduleDTO.ParameterXml : string.Empty;
            }
            set
            {
                OnlineExamSubjectGroupScheduleDTO.ParameterXml = value;
            }
        }
        [Display(Name = "Total Paper Set")]
        public byte TotalPaperSet
        {
            get
            {
                return (OnlineExamSubjectGroupScheduleDTO != null) ? OnlineExamSubjectGroupScheduleDTO.TotalPaperSet : new byte();
            }
            set
            {
                OnlineExamSubjectGroupScheduleDTO.TotalPaperSet = value;
            }
        }
        //[Display(Name = "Examination Start Time")]
        public int SectionDetailsID
        {
            get
            {
                return (OnlineExamSubjectGroupScheduleDTO != null && OnlineExamSubjectGroupScheduleDTO.SectionDetailsID > 0) ? OnlineExamSubjectGroupScheduleDTO.SectionDetailsID : new int();
            }
            set
            {
                OnlineExamSubjectGroupScheduleDTO.SectionDetailsID = value;
            }
        }
        [Required(ErrorMessage = "Please Enter Passing Marks.")]
        [Display(Name = "Passing Marks")]
        public byte PassingMarks
        {
            get
            {
                return (OnlineExamSubjectGroupScheduleDTO != null) ? OnlineExamSubjectGroupScheduleDTO.PassingMarks : new byte();
            }
            set
            {
                OnlineExamSubjectGroupScheduleDTO.PassingMarks = value;
            }
        }
        [Required(ErrorMessage = "Please Enter Marks For Each Question.")]
        [Display(Name = "Marks For Each Ques")]
        public byte MarksForEachQues
        {
            get
            {
                return (OnlineExamSubjectGroupScheduleDTO != null) ? OnlineExamSubjectGroupScheduleDTO.MarksForEachQues : new byte();
            }
            set
            {
                OnlineExamSubjectGroupScheduleDTO.MarksForEachQues = value;
            }
        }
        [Display(Name = "Is Negavtie Marking")]
        public bool IsNegavieMarking
        {
            get
            {
                return (OnlineExamSubjectGroupScheduleDTO != null) ? OnlineExamSubjectGroupScheduleDTO.IsNegavieMarking : false;
            }
            set
            {
                OnlineExamSubjectGroupScheduleDTO.IsNegavieMarking = value;
            }
        }
         [Required(ErrorMessage = "Please Enter Marks To Be Deducted.")]
         [Display(Name = "Marks To Be Deducted")]
        public decimal MarksToBeDeducted
        {
            get
            {
                return (OnlineExamSubjectGroupScheduleDTO != null && OnlineExamSubjectGroupScheduleDTO.MarksToBeDeducted > 0) ? OnlineExamSubjectGroupScheduleDTO.MarksToBeDeducted : new decimal();
            }
            set
            {
                OnlineExamSubjectGroupScheduleDTO.MarksToBeDeducted = value;
            }
        }
        [Display(Name = "Level 1 Marks")]
        public byte Level1Marks
        {
            get
            {
                return (OnlineExamSubjectGroupScheduleDTO != null) ? OnlineExamSubjectGroupScheduleDTO.Level1Marks : new byte();
            }
            set
            {
                OnlineExamSubjectGroupScheduleDTO.Level1Marks = value;
            }
        }
        [Display(Name = "Level 2 Marks")]
        public byte Level2Marks
        {
            get
            {
                return (OnlineExamSubjectGroupScheduleDTO != null) ? OnlineExamSubjectGroupScheduleDTO.Level2Marks : new byte();
            }
            set
            {
                OnlineExamSubjectGroupScheduleDTO.Level2Marks = value;
            }
        }
        [Display(Name = "Level 3 Marks")]
        public byte Level3Marks
        {
            get
            {
                return (OnlineExamSubjectGroupScheduleDTO != null) ? OnlineExamSubjectGroupScheduleDTO.Level3Marks : new byte();
            }
            set
            {
                OnlineExamSubjectGroupScheduleDTO.Level3Marks = value;
            }
        }
        [Display(Name = "Level 1 Time In Minutes")]
        public byte Level1TimeInMinutes
        {
            get
            {
                return (OnlineExamSubjectGroupScheduleDTO != null) ? OnlineExamSubjectGroupScheduleDTO.Level1TimeInMinutes : new byte();
            }
            set
            {
                OnlineExamSubjectGroupScheduleDTO.Level1TimeInMinutes = value;
            }
        }
        [Display(Name = "Level 2 Time In Minutes")]
        public byte Level2TimeInMinutes
        {
            get
            {
                return (OnlineExamSubjectGroupScheduleDTO != null) ? OnlineExamSubjectGroupScheduleDTO.Level2TimeInMinutes : new byte();
            }
            set
            {
                OnlineExamSubjectGroupScheduleDTO.Level2TimeInMinutes = value;
            }
        }
        [Display(Name = "Level 3 Time In Minutes")]
        public byte Level3TimeInMinutes
        {
            get
            {
                return (OnlineExamSubjectGroupScheduleDTO != null) ? OnlineExamSubjectGroupScheduleDTO.Level3TimeInMinutes : new byte();
            }
            set
            {
                OnlineExamSubjectGroupScheduleDTO.Level3TimeInMinutes = value;
            }
        }
        [Display(Name = "Level 4 Time In Minutes")]
        public byte Level4TimeInMinutes
        {
            get
            {
                return (OnlineExamSubjectGroupScheduleDTO != null) ? OnlineExamSubjectGroupScheduleDTO.Level4TimeInMinutes : new byte();
            }
            set
            {
                OnlineExamSubjectGroupScheduleDTO.Level4TimeInMinutes = value;
            }
        }
        [Display(Name = "Fixed Flexible Time")]
        public byte FixedFlexibleTime
        {
            get
            {
                return (OnlineExamSubjectGroupScheduleDTO != null) ? OnlineExamSubjectGroupScheduleDTO.FixedFlexibleTime : new byte();
            }
            set
            {
                OnlineExamSubjectGroupScheduleDTO.FixedFlexibleTime = value;
            }
        }
         [Display(Name = "Exam Duration")]
        public byte ExamDuration
        {
            get
            {
                return (OnlineExamSubjectGroupScheduleDTO != null) ? OnlineExamSubjectGroupScheduleDTO.ExamDuration : new byte();
            }
            set
            {
                OnlineExamSubjectGroupScheduleDTO.ExamDuration = value;
            }
        }
         [Display(Name = "Day Open Time")]
        public byte DayOpenTime
        {
            get
            {
                return (OnlineExamSubjectGroupScheduleDTO != null) ? OnlineExamSubjectGroupScheduleDTO.DayOpenTime : new byte();
            }
            set
            {
                OnlineExamSubjectGroupScheduleDTO.DayOpenTime = value;
            }
        }
        [Display(Name = "Day Close Time")]
        public byte DayCloseTime
        {
            get
            {
                return (OnlineExamSubjectGroupScheduleDTO != null) ? OnlineExamSubjectGroupScheduleDTO.DayCloseTime : new byte();
            }
            set
            {
                OnlineExamSubjectGroupScheduleDTO.DayCloseTime = value;
            }
        }

        [Display(Name = "Examination Statuse")]
        public byte ExaminationStatus
        {
            get
            {
                return (OnlineExamSubjectGroupScheduleDTO != null) ? OnlineExamSubjectGroupScheduleDTO.ExaminationStatus : new byte();
            }
            set
            {
                OnlineExamSubjectGroupScheduleDTO.ExaminationStatus = value;
            }
        }
         [Display(Name = "Is Schedule For All Sections")]
        public bool IsScheduleForAllSections
        {
            get
            {
                return (OnlineExamSubjectGroupScheduleDTO != null) ? OnlineExamSubjectGroupScheduleDTO.IsScheduleForAllSections : false;
            }
            set
            {
                OnlineExamSubjectGroupScheduleDTO.IsScheduleForAllSections = value;
            }
        }
        public bool IsActive
        {
            get
            {
                return (OnlineExamSubjectGroupScheduleDTO != null) ? OnlineExamSubjectGroupScheduleDTO.IsActive : false;
            }
            set
            {
                OnlineExamSubjectGroupScheduleDTO.IsActive = value;
            }
        }
        public int AcadSessionID
        {
            get
            {
                return (OnlineExamSubjectGroupScheduleDTO != null && OnlineExamSubjectGroupScheduleDTO.AcadSessionID > 0) ? OnlineExamSubjectGroupScheduleDTO.AcadSessionID : new int();
            }
            set
            {
                OnlineExamSubjectGroupScheduleDTO.AcadSessionID = value;
            }
        }
        public string ExaminationName
        {
            get
            {
                return (OnlineExamSubjectGroupScheduleDTO != null) ? OnlineExamSubjectGroupScheduleDTO.ExaminationName : string.Empty;
            }
            set
            {
                OnlineExamSubjectGroupScheduleDTO.ExaminationName = value;
            }
        }
        public string Purpose
        {
            get
            {
                return (OnlineExamSubjectGroupScheduleDTO != null) ? OnlineExamSubjectGroupScheduleDTO.Purpose : string.Empty;
            }
            set
            {
                OnlineExamSubjectGroupScheduleDTO.Purpose = value;
            }
        }
        public string ExaminationFor
        {
            get
            {
                return (OnlineExamSubjectGroupScheduleDTO != null) ? OnlineExamSubjectGroupScheduleDTO.ExaminationFor : string.Empty;
            }
            set
            {
                OnlineExamSubjectGroupScheduleDTO.ExaminationFor = value;
            }
        }
        public string CentreCode
        {
            get
            {
                return (OnlineExamSubjectGroupScheduleDTO != null) ? OnlineExamSubjectGroupScheduleDTO.CentreCode : string.Empty;
            }
            set
            {
                OnlineExamSubjectGroupScheduleDTO.CentreCode = value;
            }
        }
        public int CourseYearID
        {
            get
            {
                return (OnlineExamSubjectGroupScheduleDTO != null && OnlineExamSubjectGroupScheduleDTO.CourseYearID > 0) ? OnlineExamSubjectGroupScheduleDTO.CourseYearID : new int();
            }
            set
            {
                OnlineExamSubjectGroupScheduleDTO.CourseYearID = value;
            }
        }
        public int BranchID
        {
            get
            {
                return (OnlineExamSubjectGroupScheduleDTO != null && OnlineExamSubjectGroupScheduleDTO.BranchID > 0) ? OnlineExamSubjectGroupScheduleDTO.BranchID : new int();
            }
            set
            {
                OnlineExamSubjectGroupScheduleDTO.BranchID = value;
            }
        }
        public int SemesterMstID
        {
            get
            {
                return (OnlineExamSubjectGroupScheduleDTO != null && OnlineExamSubjectGroupScheduleDTO.SemesterMstID > 0) ? OnlineExamSubjectGroupScheduleDTO.SemesterMstID : new int();
            }
            set
            {
                OnlineExamSubjectGroupScheduleDTO.SemesterMstID = value;
            }
        }
        public string SubjectGroupDescription
        {
            get
            {
                return (OnlineExamSubjectGroupScheduleDTO != null) ? OnlineExamSubjectGroupScheduleDTO.SubjectGroupDescription : string.Empty;
            }
            set
            {
                OnlineExamSubjectGroupScheduleDTO.SubjectGroupDescription = value;
            }
        }
        public string CombinationCode
        {
            get
            {
                return (OnlineExamSubjectGroupScheduleDTO != null) ? OnlineExamSubjectGroupScheduleDTO.CombinationCode : string.Empty;
            }
            set
            {
                OnlineExamSubjectGroupScheduleDTO.CombinationCode = value;
            }
        }
        public string SubjectShortDescription
        {
            get
            {
                return (OnlineExamSubjectGroupScheduleDTO != null) ? OnlineExamSubjectGroupScheduleDTO.SubjectShortDescription : string.Empty;
            }
            set
            {
                OnlineExamSubjectGroupScheduleDTO.SubjectShortDescription = value;
            }
        }
        public bool ViewFlag
        {
            get
            {
                return (OnlineExamSubjectGroupScheduleDTO != null) ? OnlineExamSubjectGroupScheduleDTO.ViewFlag : false;
            }
            set
            {
                OnlineExamSubjectGroupScheduleDTO.ViewFlag = value;
            }
        }
        [Display(Name = "Is Time Flexible")]
        public bool IsTimeFlexible
        {
            get
            {
                return (OnlineExamSubjectGroupScheduleDTO != null) ? OnlineExamSubjectGroupScheduleDTO.IsTimeFlexible : false;
            }
            set
            {
                OnlineExamSubjectGroupScheduleDTO.IsTimeFlexible = value;
            }
        }
        //common fields
        [Display(Name = "IsDeleted")]
        public bool IsDeleted
        {
            get
            {
                return (OnlineExamSubjectGroupScheduleDTO != null) ? OnlineExamSubjectGroupScheduleDTO.IsDeleted : false;
            }
            set
            {
                OnlineExamSubjectGroupScheduleDTO.IsDeleted = value;
            }
        }

        [Display(Name = "CreatedBy")]
        public int CreatedBy
        {
            get
            {
                return (OnlineExamSubjectGroupScheduleDTO != null && OnlineExamSubjectGroupScheduleDTO.CreatedBy > 0) ? OnlineExamSubjectGroupScheduleDTO.CreatedBy : new int();
            }
            set
            {
                OnlineExamSubjectGroupScheduleDTO.CreatedBy = value;
            }
        }

        [Display(Name = "CreatedDate")]
        public DateTime CreatedDate
        {
            get
            {
                return (OnlineExamSubjectGroupScheduleDTO != null) ? OnlineExamSubjectGroupScheduleDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                OnlineExamSubjectGroupScheduleDTO.CreatedDate = value;
            }
        }

        [Display(Name = "ModifiedBy")]
        public int ModifiedBy
        {
            get
            {
                return (OnlineExamSubjectGroupScheduleDTO != null) ? OnlineExamSubjectGroupScheduleDTO.ModifiedBy : new int();
            }
            set
            {
                OnlineExamSubjectGroupScheduleDTO.ModifiedBy = value;
            }
        }

        [Display(Name = "ModifiedDate")]
        public DateTime ModifiedDate
        {
            get
            {
                return (OnlineExamSubjectGroupScheduleDTO != null) ? OnlineExamSubjectGroupScheduleDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                OnlineExamSubjectGroupScheduleDTO.ModifiedDate = value;
            }
        }

        [Display(Name = "DeletedBy")]
        public int DeletedBy
        {
            get
            {
                return (OnlineExamSubjectGroupScheduleDTO != null) ? OnlineExamSubjectGroupScheduleDTO.DeletedBy : new int();
            }
            set
            {
                OnlineExamSubjectGroupScheduleDTO.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime DeletedDate
        {
            get
            {
                return (OnlineExamSubjectGroupScheduleDTO != null) ? OnlineExamSubjectGroupScheduleDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                OnlineExamSubjectGroupScheduleDTO.DeletedDate = value;
            }
        }


        public string errorMessage { get; set; }






    }
}

