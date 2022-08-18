
using AMS.Common;
using AMS.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AMS.ViewModel
{
    public class OnlineExamAssignpapersetterViewModel : IOnlineExamAssignpapersetterViewModel
    {

        public OnlineExamAssignpapersetterViewModel()
        {
            OnlineExamAssignpapersetterDTO = new OnlineExamAssignpapersetter();

        }



        public OnlineExamAssignpapersetter OnlineExamAssignpapersetterDTO
        {
            get;
            set;
        }

        public Byte ID
        {
            get
            {
                return (OnlineExamAssignpapersetterDTO != null && OnlineExamAssignpapersetterDTO.ID > 0) ? OnlineExamAssignpapersetterDTO.ID : new byte();
            }
            set
            {
                OnlineExamAssignpapersetterDTO.ID = value;
            }
        }


     
        [Display(Name = "Paper Set")]
        [Required(ErrorMessage = "Paper Set should not be blank.")]
        public string PaperSet
        {
            get
            {
                return (OnlineExamAssignpapersetterDTO != null) ? OnlineExamAssignpapersetterDTO.PaperSet : string.Empty;
            }
            set
            {
                OnlineExamAssignpapersetterDTO.PaperSet = value;
            }
        }
        public string PaperSetCode
        {
            get
            {
                return (OnlineExamAssignpapersetterDTO != null) ? OnlineExamAssignpapersetterDTO.PaperSetCode : string.Empty;
            }
            set
            {
                OnlineExamAssignpapersetterDTO.PaperSetCode = value;
            }
        }
        public int GeneralPaperSetMasterID
        {
            get
            {
                return (OnlineExamAssignpapersetterDTO != null && OnlineExamAssignpapersetterDTO.GeneralPaperSetMasterID > 0) ? OnlineExamAssignpapersetterDTO.GeneralPaperSetMasterID : new int();
            }
            set
            {
                OnlineExamAssignpapersetterDTO.GeneralPaperSetMasterID = value;
            }
        }
        public int OnlineExamExaminationMasterID
        {
            get
            {
                return (OnlineExamAssignpapersetterDTO != null && OnlineExamAssignpapersetterDTO.OnlineExamExaminationMasterID > 0) ? OnlineExamAssignpapersetterDTO.OnlineExamExaminationMasterID : new int();
            }
            set
            {
                OnlineExamAssignpapersetterDTO.OnlineExamExaminationMasterID = value;
            }
        }
        public int OnlineExamSubjectGroupScheduleID
        {
            get
            {
                return (OnlineExamAssignpapersetterDTO != null && OnlineExamAssignpapersetterDTO.OnlineExamSubjectGroupScheduleID > 0) ? OnlineExamAssignpapersetterDTO.OnlineExamSubjectGroupScheduleID : new int();
            }
            set
            {
                OnlineExamAssignpapersetterDTO.OnlineExamSubjectGroupScheduleID = value;
            }
        }
        public int OnlineExamAllocateSupportStaffID
        {
            get
            {
                return (OnlineExamAssignpapersetterDTO != null && OnlineExamAssignpapersetterDTO.OnlineExamAllocateSupportStaffID > 0) ? OnlineExamAssignpapersetterDTO.OnlineExamAllocateSupportStaffID : new int();
            }
            set
            {
                OnlineExamAssignpapersetterDTO.OnlineExamAllocateSupportStaffID = value;
            }
        }
        public string CentreCode
        {
            get
            {
                return (OnlineExamAssignpapersetterDTO != null) ? OnlineExamAssignpapersetterDTO.CentreCode : string.Empty;
            }
            set
            {
                OnlineExamAssignpapersetterDTO.CentreCode = value;
            }
        }
        [Display(Name = "Centre Name")]
        public string SelectedCentreCode
        {
            get
            {
                return (OnlineExamAssignpapersetterDTO != null) ? OnlineExamAssignpapersetterDTO.SelectedCentreCode : string.Empty;
            }
            set
            {
                OnlineExamAssignpapersetterDTO.SelectedCentreCode = value;
            }
        }
        public int SessionID
        {
            get
            {
                return (OnlineExamAssignpapersetterDTO != null && OnlineExamAssignpapersetterDTO.SessionID > 0) ? OnlineExamAssignpapersetterDTO.SessionID : new int();
            }
            set
            {
                OnlineExamAssignpapersetterDTO.SessionID = value;
            }
        }
         [Display(Name = " Select Exam")]
        public string SelectedExam
        {
            get
            {
                return (OnlineExamAssignpapersetterDTO != null) ? OnlineExamAssignpapersetterDTO.SelectedExam : string.Empty;
            }
            set
            {
                OnlineExamAssignpapersetterDTO.SelectedExam = value;
            }
        }
      
       
        public int OnlineExamAllocateJobSupportStaffID
        {
            get
            {
                return (OnlineExamAssignpapersetterDTO != null && OnlineExamAssignpapersetterDTO.OnlineExamAllocateJobSupportStaffID > 0) ? OnlineExamAssignpapersetterDTO.OnlineExamAllocateJobSupportStaffID : new int();
            }
            set
            {
                OnlineExamAssignpapersetterDTO.OnlineExamAllocateJobSupportStaffID = value;
            }
        }

        public int CourseYearID
        {
            get
            {
                return (OnlineExamAssignpapersetterDTO != null && OnlineExamAssignpapersetterDTO.CourseYearID > 0) ? OnlineExamAssignpapersetterDTO.CourseYearID : new int();
            }
            set
            {
                OnlineExamAssignpapersetterDTO.CourseYearID = value;
            }
        }
        public int OnlineExamExaminationCourseApplicableID
        {
            get
            {
                return (OnlineExamAssignpapersetterDTO != null && OnlineExamAssignpapersetterDTO.OnlineExamExaminationCourseApplicableID > 0) ? OnlineExamAssignpapersetterDTO.OnlineExamExaminationCourseApplicableID : new int();
            }
            set
            {
                OnlineExamAssignpapersetterDTO.OnlineExamExaminationCourseApplicableID = value;
            }
        }
        public int SemesterMstID
        {
            get
            {
                return (OnlineExamAssignpapersetterDTO != null && OnlineExamAssignpapersetterDTO.SemesterMstID > 0) ? OnlineExamAssignpapersetterDTO.SemesterMstID : new int();
            }
            set
            {
                OnlineExamAssignpapersetterDTO.SemesterMstID = value;
            }
        }
        public int SubjectGroupID
        {
            get
            {
                return (OnlineExamAssignpapersetterDTO != null && OnlineExamAssignpapersetterDTO.SubjectGroupID > 0) ? OnlineExamAssignpapersetterDTO.SubjectGroupID : new int();
            }
            set
            {
                OnlineExamAssignpapersetterDTO.SubjectGroupID = value;
            }
        }
        public int GlobalSessionID
        {
            get
            {
                return (OnlineExamAssignpapersetterDTO != null && OnlineExamAssignpapersetterDTO.GlobalSessionID > 0) ? OnlineExamAssignpapersetterDTO.GlobalSessionID : new int();
            }
            set
            {
                OnlineExamAssignpapersetterDTO.GlobalSessionID = value;
            }
        }
        public int SubjectID
        {
            get
            {
                return (OnlineExamAssignpapersetterDTO != null && OnlineExamAssignpapersetterDTO.SubjectID > 0) ? OnlineExamAssignpapersetterDTO.SubjectID : new int();
            }
            set
            {
                OnlineExamAssignpapersetterDTO.SubjectID = value;
            }
        }
        public int OnlineExamExaminationQuestionPaperID
        {
            get
            {
                return (OnlineExamAssignpapersetterDTO != null && OnlineExamAssignpapersetterDTO.OnlineExamExaminationQuestionPaperID > 0) ? OnlineExamAssignpapersetterDTO.OnlineExamExaminationQuestionPaperID : new int();
            }
            set
            {
                OnlineExamAssignpapersetterDTO.OnlineExamExaminationQuestionPaperID = value;
            }
        }

        public string ExaminationName
        {
            get
            {
                return (OnlineExamAssignpapersetterDTO != null) ? OnlineExamAssignpapersetterDTO.ExaminationName : string.Empty;
            }
            set
            {
                OnlineExamAssignpapersetterDTO.ExaminationName = value;
            }
        }
        public string ExaminationFor
        {
            get
            {
                return (OnlineExamAssignpapersetterDTO != null) ? OnlineExamAssignpapersetterDTO.ExaminationFor : string.Empty;
            }
            set
            {
                OnlineExamAssignpapersetterDTO.ExaminationFor = value;
            }
        }
        [Display(Name = "Allocate Support Staff")]
        [Required(ErrorMessage = "Allocate Support Staff should not be blank.")]
        public string OnlineExamAllocateJobSupportStaff
        {
            get
            {
                return (OnlineExamAssignpapersetterDTO != null) ? OnlineExamAssignpapersetterDTO.OnlineExamAllocateJobSupportStaff : string.Empty;
            }
            set
            {
                OnlineExamAssignpapersetterDTO.OnlineExamAllocateJobSupportStaff = value;
            }
        }
        public string SubjectGroupDescription
        {
            get
            {
                return (OnlineExamAssignpapersetterDTO != null) ? OnlineExamAssignpapersetterDTO.SubjectGroupDescription : string.Empty;
            }
            set
            {
                OnlineExamAssignpapersetterDTO.SubjectGroupDescription = value;
            }
        }
        public string SubjectShortDescription
        {
            get
            {
                return (OnlineExamAssignpapersetterDTO != null) ? OnlineExamAssignpapersetterDTO.SubjectShortDescription : string.Empty;
            }
            set
            {
                OnlineExamAssignpapersetterDTO.SubjectShortDescription = value;
            }
        }
        public bool IsFinal
        {
            get
            {
                return (OnlineExamAssignpapersetterDTO != null) ? OnlineExamAssignpapersetterDTO.IsFinal : false;
            }
            set
            {
                OnlineExamAssignpapersetterDTO.IsFinal = value;
            }
        }
        public bool IsSelected
        {
            get
            {
                return (OnlineExamAssignpapersetterDTO != null) ? OnlineExamAssignpapersetterDTO.IsSelected : false;
            }
            set
            {
                OnlineExamAssignpapersetterDTO.IsSelected = value;
            }
        }
        
        [Display(Name = "IsDeleted")]
        public bool IsDeleted
        {
            get
            {
                return (OnlineExamAssignpapersetterDTO != null) ? OnlineExamAssignpapersetterDTO.IsDeleted : false;
            }
            set
            {
                OnlineExamAssignpapersetterDTO.IsDeleted = value;
            }
        }

        [Display(Name = "CreatedBy")]
        public int CreatedBy
        {
            get
            {
                return (OnlineExamAssignpapersetterDTO != null && OnlineExamAssignpapersetterDTO.CreatedBy > 0) ? OnlineExamAssignpapersetterDTO.CreatedBy : new int();
            }
            set
            {
                OnlineExamAssignpapersetterDTO.CreatedBy = value;
            }
        }

        [Display(Name = "CreatedDate")]
        public DateTime CreatedDate
        {
            get
            {
                return (OnlineExamAssignpapersetterDTO != null) ? OnlineExamAssignpapersetterDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                OnlineExamAssignpapersetterDTO.CreatedDate = value;
            }
        }

        [Display(Name = "ModifiedBy")]
        public int ModifiedBy
        {
            get
            {
                return (OnlineExamAssignpapersetterDTO != null) ? OnlineExamAssignpapersetterDTO.ModifiedBy : new int();
            }
            set
            {
                OnlineExamAssignpapersetterDTO.ModifiedBy = value;
            }
        }

        [Display(Name = "ModifiedDate")]
        public DateTime ModifiedDate
        {
            get
            {
                return (OnlineExamAssignpapersetterDTO != null) ? OnlineExamAssignpapersetterDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                OnlineExamAssignpapersetterDTO.ModifiedDate = value;
            }
        }

        [Display(Name = "DeletedBy")]
        public int DeletedBy
        {
            get
            {
                return (OnlineExamAssignpapersetterDTO != null) ? OnlineExamAssignpapersetterDTO.DeletedBy : new int();
            }
            set
            {
                OnlineExamAssignpapersetterDTO.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime DeletedDate
        {
            get
            {
                return (OnlineExamAssignpapersetterDTO != null) ? OnlineExamAssignpapersetterDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                OnlineExamAssignpapersetterDTO.DeletedDate = value;
            }
        }


        public string errorMessage { get; set; }






    }
}

