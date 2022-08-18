
using AMS.Common;
using AMS.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AMS.ViewModel
{
    public class OnlineExamAssignPaperCheckerViewModel : IOnlineExamAssignPaperCheckerViewModel
    {

        public OnlineExamAssignPaperCheckerViewModel()
        {
            OnlineExamAssignPaperCheckerDTO = new OnlineExamAssignPaperChecker();

        }



        public OnlineExamAssignPaperChecker OnlineExamAssignPaperCheckerDTO
        {
            get;
            set;
        }

        public Byte ID
        {
            get
            {
                return (OnlineExamAssignPaperCheckerDTO != null && OnlineExamAssignPaperCheckerDTO.ID > 0) ? OnlineExamAssignPaperCheckerDTO.ID : new byte();
            }
            set
            {
                OnlineExamAssignPaperCheckerDTO.ID = value;
            }
        }

        [Display(Name = "Paper Set")]
        public string PaperSet
        {
            get
            {
                return (OnlineExamAssignPaperCheckerDTO != null) ? OnlineExamAssignPaperCheckerDTO.PaperSet : string.Empty;
            }
            set
            {
                OnlineExamAssignPaperCheckerDTO.PaperSet = value;
            }
        }
        public string PaperSetCode
        {
            get
            {
                return (OnlineExamAssignPaperCheckerDTO != null) ? OnlineExamAssignPaperCheckerDTO.PaperSetCode : string.Empty;
            }
            set
            {
                OnlineExamAssignPaperCheckerDTO.PaperSetCode = value;
            }
        }

        public int GeneralPaperSetMasterID
        {
            get
            {
                return (OnlineExamAssignPaperCheckerDTO != null && OnlineExamAssignPaperCheckerDTO.GeneralPaperSetMasterID > 0) ? OnlineExamAssignPaperCheckerDTO.GeneralPaperSetMasterID : new int();
            }
            set
            {
                OnlineExamAssignPaperCheckerDTO.GeneralPaperSetMasterID = value;
            }
        }
        public int OnlineExamExaminationMasterID
        {
            get
            {
                return (OnlineExamAssignPaperCheckerDTO != null && OnlineExamAssignPaperCheckerDTO.OnlineExamExaminationMasterID > 0) ? OnlineExamAssignPaperCheckerDTO.OnlineExamExaminationMasterID : new int();
            }
            set
            {
                OnlineExamAssignPaperCheckerDTO.OnlineExamExaminationMasterID = value;
            }
        }
        public int OnlineExamSubjectGroupScheduleID
        {
            get
            {
                return (OnlineExamAssignPaperCheckerDTO != null && OnlineExamAssignPaperCheckerDTO.OnlineExamSubjectGroupScheduleID > 0) ? OnlineExamAssignPaperCheckerDTO.OnlineExamSubjectGroupScheduleID : new int();
            }
            set
            {
                OnlineExamAssignPaperCheckerDTO.OnlineExamSubjectGroupScheduleID = value;
            }
        }
        public int OnlineExamAllocateSupportStaffID
        {
            get
            {
                return (OnlineExamAssignPaperCheckerDTO != null && OnlineExamAssignPaperCheckerDTO.OnlineExamAllocateSupportStaffID > 0) ? OnlineExamAssignPaperCheckerDTO.OnlineExamAllocateSupportStaffID : new int();
            }
            set
            {
                OnlineExamAssignPaperCheckerDTO.OnlineExamAllocateSupportStaffID = value;
            }
        }
        public string CentreCode
        {
            get
            {
                return (OnlineExamAssignPaperCheckerDTO != null) ? OnlineExamAssignPaperCheckerDTO.CentreCode : string.Empty;
            }
            set
            {
                OnlineExamAssignPaperCheckerDTO.CentreCode = value;
            }
        }
        [Display(Name = "Centre Name")]
        public string SelectedCentreCode
        {
            get
            {
                return (OnlineExamAssignPaperCheckerDTO != null) ? OnlineExamAssignPaperCheckerDTO.SelectedCentreCode : string.Empty;
            }
            set
            {
                OnlineExamAssignPaperCheckerDTO.SelectedCentreCode = value;
            }
        }
        public int SessionID
        {
            get
            {
                return (OnlineExamAssignPaperCheckerDTO != null && OnlineExamAssignPaperCheckerDTO.SessionID > 0) ? OnlineExamAssignPaperCheckerDTO.SessionID : new int();
            }
            set
            {
                OnlineExamAssignPaperCheckerDTO.SessionID = value;
            }
        }
        [Display(Name = " Select Exam")]
        public string SelectedExam
        {
            get
            {
                return (OnlineExamAssignPaperCheckerDTO != null) ? OnlineExamAssignPaperCheckerDTO.SelectedExam : string.Empty;
            }
            set
            {
                OnlineExamAssignPaperCheckerDTO.SelectedExam = value;
            }
        }


        public int OnlineExamAllocateJobSupportStaffID
        {
            get
            {
                return (OnlineExamAssignPaperCheckerDTO != null && OnlineExamAssignPaperCheckerDTO.OnlineExamAllocateJobSupportStaffID > 0) ? OnlineExamAssignPaperCheckerDTO.OnlineExamAllocateJobSupportStaffID : new int();
            }
            set
            {
                OnlineExamAssignPaperCheckerDTO.OnlineExamAllocateJobSupportStaffID = value;
            }
        }

        public int CourseYearID
        {
            get
            {
                return (OnlineExamAssignPaperCheckerDTO != null) ? OnlineExamAssignPaperCheckerDTO.CourseYearID : new int();
            }
            set
            {
                OnlineExamAssignPaperCheckerDTO.CourseYearID = value;
            }
        }

        public int SectionDetailID
        {
            get
            {
                return (OnlineExamAssignPaperCheckerDTO != null && OnlineExamAssignPaperCheckerDTO.SectionDetailID > 0) ? OnlineExamAssignPaperCheckerDTO.SectionDetailID : new int();
            }
            set
            {
                OnlineExamAssignPaperCheckerDTO.SectionDetailID = value;
            }
        }
        public int OnlineExamExaminationCourseApplicableID
        {
            get
            {
                return (OnlineExamAssignPaperCheckerDTO != null && OnlineExamAssignPaperCheckerDTO.OnlineExamExaminationCourseApplicableID > 0) ? OnlineExamAssignPaperCheckerDTO.OnlineExamExaminationCourseApplicableID : new int();
            }
            set
            {
                OnlineExamAssignPaperCheckerDTO.OnlineExamExaminationCourseApplicableID = value;
            }
        }
        public int SemesterMstID
        {
            get
            {
                return (OnlineExamAssignPaperCheckerDTO != null && OnlineExamAssignPaperCheckerDTO.SemesterMstID > 0) ? OnlineExamAssignPaperCheckerDTO.SemesterMstID : new int();
            }
            set
            {
                OnlineExamAssignPaperCheckerDTO.SemesterMstID = value;
            }
        }
        public int SubjectGroupID
        {
            get
            {
                return (OnlineExamAssignPaperCheckerDTO != null && OnlineExamAssignPaperCheckerDTO.SubjectGroupID > 0) ? OnlineExamAssignPaperCheckerDTO.SubjectGroupID : new int();
            }
            set
            {
                OnlineExamAssignPaperCheckerDTO.SubjectGroupID = value;
            }
        }
        public int GlobalSessionID
        {
            get
            {
                return (OnlineExamAssignPaperCheckerDTO != null && OnlineExamAssignPaperCheckerDTO.GlobalSessionID > 0) ? OnlineExamAssignPaperCheckerDTO.GlobalSessionID : new int();
            }
            set
            {
                OnlineExamAssignPaperCheckerDTO.GlobalSessionID = value;
            }
        }
        public int SubjectID
        {
            get
            {
                return (OnlineExamAssignPaperCheckerDTO != null && OnlineExamAssignPaperCheckerDTO.SubjectID > 0) ? OnlineExamAssignPaperCheckerDTO.SubjectID : new int();
            }
            set
            {
                OnlineExamAssignPaperCheckerDTO.SubjectID = value;
            }
        }
        public int OnlineExamQuestionPaperCheckerID
        {
            get
            {
                return (OnlineExamAssignPaperCheckerDTO != null && OnlineExamAssignPaperCheckerDTO.OnlineExamQuestionPaperCheckerID > 0) ? OnlineExamAssignPaperCheckerDTO.OnlineExamQuestionPaperCheckerID : new int();
            }
            set
            {
                OnlineExamAssignPaperCheckerDTO.OnlineExamQuestionPaperCheckerID = value;
            }
        }

        public string ExaminationName
        {
            get
            {
                return (OnlineExamAssignPaperCheckerDTO != null) ? OnlineExamAssignPaperCheckerDTO.ExaminationName : string.Empty;
            }
            set
            {
                OnlineExamAssignPaperCheckerDTO.ExaminationName = value;
            }
        }
        public string ExaminationFor
        {
            get
            {
                return (OnlineExamAssignPaperCheckerDTO != null) ? OnlineExamAssignPaperCheckerDTO.ExaminationFor : string.Empty;
            }
            set
            {
                OnlineExamAssignPaperCheckerDTO.ExaminationFor = value;
            }
        }
        [Display(Name = "Allocate Support Staff")]
        [Required(ErrorMessage = "Allocate Support Staff should not be blank.")]
        public string OnlineExamAllocateJobSupportStaff
        {
            get
            {
                return (OnlineExamAssignPaperCheckerDTO != null) ? OnlineExamAssignPaperCheckerDTO.OnlineExamAllocateJobSupportStaff : string.Empty;
            }
            set
            {
                OnlineExamAssignPaperCheckerDTO.OnlineExamAllocateJobSupportStaff = value;
            }
        }
        public string SubjectGroupDescription
        {
            get
            {
                return (OnlineExamAssignPaperCheckerDTO != null) ? OnlineExamAssignPaperCheckerDTO.SubjectGroupDescription : string.Empty;
            }
            set
            {
                OnlineExamAssignPaperCheckerDTO.SubjectGroupDescription = value;
            }
        }
        public string SubjectShortDescription
        {
            get
            {
                return (OnlineExamAssignPaperCheckerDTO != null) ? OnlineExamAssignPaperCheckerDTO.SubjectShortDescription : string.Empty;
            }
            set
            {
                OnlineExamAssignPaperCheckerDTO.SubjectShortDescription = value;
            }
        }
        public bool IsAllChecked
        {
            get
            {
                return (OnlineExamAssignPaperCheckerDTO != null) ? OnlineExamAssignPaperCheckerDTO.IsAllChecked : false;
            }
            set
            {
                OnlineExamAssignPaperCheckerDTO.IsAllChecked = value;
            }
        }

        [Display(Name = "IsDeleted")]
        public bool IsDeleted
        {
            get
            {
                return (OnlineExamAssignPaperCheckerDTO != null) ? OnlineExamAssignPaperCheckerDTO.IsDeleted : false;
            }
            set
            {
                OnlineExamAssignPaperCheckerDTO.IsDeleted = value;
            }
        }

        [Display(Name = "CreatedBy")]
        public int CreatedBy
        {
            get
            {
                return (OnlineExamAssignPaperCheckerDTO != null && OnlineExamAssignPaperCheckerDTO.CreatedBy > 0) ? OnlineExamAssignPaperCheckerDTO.CreatedBy : new int();
            }
            set
            {
                OnlineExamAssignPaperCheckerDTO.CreatedBy = value;
            }
        }

        [Display(Name = "CreatedDate")]
        public DateTime CreatedDate
        {
            get
            {
                return (OnlineExamAssignPaperCheckerDTO != null) ? OnlineExamAssignPaperCheckerDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                OnlineExamAssignPaperCheckerDTO.CreatedDate = value;
            }
        }

        [Display(Name = "ModifiedBy")]
        public int ModifiedBy
        {
            get
            {
                return (OnlineExamAssignPaperCheckerDTO != null) ? OnlineExamAssignPaperCheckerDTO.ModifiedBy : new int();
            }
            set
            {
                OnlineExamAssignPaperCheckerDTO.ModifiedBy = value;
            }
        }

        [Display(Name = "ModifiedDate")]
        public DateTime ModifiedDate
        {
            get
            {
                return (OnlineExamAssignPaperCheckerDTO != null) ? OnlineExamAssignPaperCheckerDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                OnlineExamAssignPaperCheckerDTO.ModifiedDate = value;
            }
        }

        [Display(Name = "DeletedBy")]
        public int DeletedBy
        {
            get
            {
                return (OnlineExamAssignPaperCheckerDTO != null) ? OnlineExamAssignPaperCheckerDTO.DeletedBy : new int();
            }
            set
            {
                OnlineExamAssignPaperCheckerDTO.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime DeletedDate
        {
            get
            {
                return (OnlineExamAssignPaperCheckerDTO != null) ? OnlineExamAssignPaperCheckerDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                OnlineExamAssignPaperCheckerDTO.DeletedDate = value;
            }
        }


        public string errorMessage { get; set; }






    }
}

