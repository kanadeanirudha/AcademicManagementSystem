using AMS.Common;
using AMS.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web;
using System.Web.Mvc;

namespace AMS.ViewModel
{
    public class OnlineExaminationMasterAndCourseApplicableViewModel : IOnlineExaminationMasterAndCourseApplicableViewModel
    {
        public OnlineExaminationMasterAndCourseApplicableViewModel()
        {
            OnlineExaminationMasterAndCourseApplicableDTO = new OnlineExaminationMasterAndCourseApplicable();
        }

        public OnlineExaminationMasterAndCourseApplicable OnlineExaminationMasterAndCourseApplicableDTO { get; set; }

        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~OnlineExamExaminationMaster Table Property~~~~~~~~~~~~~~~~~~~~~~~~~~~
        public int OnlineExamExaminationMasterID 
        {
            get
            {
                return (OnlineExaminationMasterAndCourseApplicableDTO != null && OnlineExaminationMasterAndCourseApplicableDTO.OnlineExamExaminationMasterID > 0) ? OnlineExaminationMasterAndCourseApplicableDTO.OnlineExamExaminationMasterID : new int();
            }
            set
            {
                OnlineExaminationMasterAndCourseApplicableDTO.OnlineExamExaminationMasterID = value;
            }
        }
        public string ExaminationName
        {
            get
            {
                return (OnlineExaminationMasterAndCourseApplicableDTO != null && OnlineExaminationMasterAndCourseApplicableDTO.ExaminationName != "") ? OnlineExaminationMasterAndCourseApplicableDTO.ExaminationName : string.Empty;
            }
            set
            {
                OnlineExaminationMasterAndCourseApplicableDTO.ExaminationName = value;
            }
        }
        public string Purpose
        {
            get
            {
                return (OnlineExaminationMasterAndCourseApplicableDTO != null && OnlineExaminationMasterAndCourseApplicableDTO.Purpose != "") ? OnlineExaminationMasterAndCourseApplicableDTO.Purpose : string.Empty;
            }
            set
            {
                OnlineExaminationMasterAndCourseApplicableDTO.Purpose = value;
            }
        }
        public int AcadSessionID
        {
            get
            {
                return (OnlineExaminationMasterAndCourseApplicableDTO != null && OnlineExaminationMasterAndCourseApplicableDTO.AcadSessionID > 0) ? OnlineExaminationMasterAndCourseApplicableDTO.AcadSessionID : new int();
            }
            set
            {
                OnlineExaminationMasterAndCourseApplicableDTO.AcadSessionID = value;
            }
        }
        public string ExaminationFor
        {
            get
            {
                return (OnlineExaminationMasterAndCourseApplicableDTO != null && OnlineExaminationMasterAndCourseApplicableDTO.ExaminationFor != "") ? OnlineExaminationMasterAndCourseApplicableDTO.ExaminationFor : string.Empty;
            }
            set
            {
                OnlineExaminationMasterAndCourseApplicableDTO.ExaminationFor = value;
            }
        }

        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~OnlineExamExaminationCourseApplicable Table Property~~~~~~~~~~~~~~~~~~~~~~~~~~

        public int OnlineExamExaminationCourseApplicableID
        {
            get
            {
                return (OnlineExaminationMasterAndCourseApplicableDTO != null && OnlineExaminationMasterAndCourseApplicableDTO.OnlineExamExaminationCourseApplicableID > 0) ? OnlineExaminationMasterAndCourseApplicableDTO.OnlineExamExaminationCourseApplicableID : new int();
            }
            set
            {
                OnlineExaminationMasterAndCourseApplicableDTO.OnlineExamExaminationCourseApplicableID = value;
            }
        }
        public int CourseYearID
        {
            get
            {
                return (OnlineExaminationMasterAndCourseApplicableDTO != null && OnlineExaminationMasterAndCourseApplicableDTO.CourseYearID > 0) ? OnlineExaminationMasterAndCourseApplicableDTO.CourseYearID : new int();
            }
            set
            {
                OnlineExaminationMasterAndCourseApplicableDTO.CourseYearID = value;
            }
        }
        public int SemesterMasterID
        {
            get
            {
                return (OnlineExaminationMasterAndCourseApplicableDTO != null && OnlineExaminationMasterAndCourseApplicableDTO.SemesterMasterID > 0) ? OnlineExaminationMasterAndCourseApplicableDTO.SemesterMasterID : new int();
            }
            set
            {
                OnlineExaminationMasterAndCourseApplicableDTO.SemesterMasterID = value;
            }
        }
        public int DepartmentID
        {
            get
            {
                return (OnlineExaminationMasterAndCourseApplicableDTO != null && OnlineExaminationMasterAndCourseApplicableDTO.DepartmentID > 0) ? OnlineExaminationMasterAndCourseApplicableDTO.DepartmentID : new int();
            }
            set
            {
                OnlineExaminationMasterAndCourseApplicableDTO.DepartmentID = value;
            }
        }
        public Int16 ExaminationStatus
        {
            get
            {
                return (OnlineExaminationMasterAndCourseApplicableDTO != null && OnlineExaminationMasterAndCourseApplicableDTO.ExaminationStatus > 0) ? OnlineExaminationMasterAndCourseApplicableDTO.ExaminationStatus : new Int16();
            }
            set
            {
                OnlineExaminationMasterAndCourseApplicableDTO.ExaminationStatus = value;
            }
        }
        public string ExaminationStartDate
        {
            get
            {
                return (OnlineExaminationMasterAndCourseApplicableDTO != null && OnlineExaminationMasterAndCourseApplicableDTO.ExaminationStartDate != "") ? OnlineExaminationMasterAndCourseApplicableDTO.ExaminationStartDate : string.Empty;
            }
            set
            {
                OnlineExaminationMasterAndCourseApplicableDTO.ExaminationStartDate = value;
            }
        }
        public string ExaminationEndDate
        {
            get
            {
                return (OnlineExaminationMasterAndCourseApplicableDTO != null && OnlineExaminationMasterAndCourseApplicableDTO.ExaminationEndDate != "") ? OnlineExaminationMasterAndCourseApplicableDTO.ExaminationEndDate : string.Empty;
            }
            set
            {
                OnlineExaminationMasterAndCourseApplicableDTO.ExaminationEndDate = value;
            }
        }
        public string ResultAnnounceDate
        {
            get
            {
                return (OnlineExaminationMasterAndCourseApplicableDTO != null && OnlineExaminationMasterAndCourseApplicableDTO.ResultAnnounceDate != "") ? OnlineExaminationMasterAndCourseApplicableDTO.ResultAnnounceDate : string.Empty;
            }
            set
            {
                OnlineExaminationMasterAndCourseApplicableDTO.ResultAnnounceDate = value;
            }
        }
        public bool IsResultAnnounce
        {
            get
            {
                return (OnlineExaminationMasterAndCourseApplicableDTO.IsResultAnnounce != false) ? OnlineExaminationMasterAndCourseApplicableDTO.IsResultAnnounce : new Boolean();
            }
            set
            {
                OnlineExaminationMasterAndCourseApplicableDTO.IsResultAnnounce = value;
            }
        }


        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~Comman Feilds~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        [Display(Name = "CreatedBy")]
        public int CreatedBy
        {
            get
            {
                return (OnlineExaminationMasterAndCourseApplicableDTO.CreatedBy > 0) ? OnlineExaminationMasterAndCourseApplicableDTO.CreatedBy : new int();
            }
            set
            {
                OnlineExaminationMasterAndCourseApplicableDTO.CreatedBy = value;
            }
        }

        [Display(Name = "CreatedDate")]
        public DateTime CreatedDate
        {
            get
            {
                return (OnlineExaminationMasterAndCourseApplicableDTO != null) ? OnlineExaminationMasterAndCourseApplicableDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                OnlineExaminationMasterAndCourseApplicableDTO.CreatedDate = value;
            }
        }

        [Display(Name = "ModifiedBy")]
        public int ModifiedBy
        {
            get
            {
                return (OnlineExaminationMasterAndCourseApplicableDTO != null && OnlineExaminationMasterAndCourseApplicableDTO.ModifiedBy > 0) ? OnlineExaminationMasterAndCourseApplicableDTO.ModifiedBy : new int();
            }
            set
            {
                OnlineExaminationMasterAndCourseApplicableDTO.ModifiedBy = value;
            }
        }

        [Display(Name = "ModifiedDate")]
        public DateTime ModifiedDate
        {
            get
            {
                return (OnlineExaminationMasterAndCourseApplicableDTO != null) ? OnlineExaminationMasterAndCourseApplicableDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                OnlineExaminationMasterAndCourseApplicableDTO.ModifiedDate = value;
            }
        }

        [Display(Name = "DeletedBy")]
        public int DeletedBy
        {
            get
            {
                return (OnlineExaminationMasterAndCourseApplicableDTO != null) ? OnlineExaminationMasterAndCourseApplicableDTO.DeletedBy : new int();
            }
            set
            {
                OnlineExaminationMasterAndCourseApplicableDTO.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime DeletedDate
        {
            get
            {
                return (OnlineExaminationMasterAndCourseApplicableDTO != null) ? OnlineExaminationMasterAndCourseApplicableDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                OnlineExaminationMasterAndCourseApplicableDTO.DeletedDate = value;
            }
        }
        public bool IsDeleted
        {
            get
            {
                return (OnlineExaminationMasterAndCourseApplicableDTO.IsDeleted != false) ? OnlineExaminationMasterAndCourseApplicableDTO.IsDeleted : new bool();
            }
            set
            {
                OnlineExaminationMasterAndCourseApplicableDTO.IsDeleted = value;
            }
        }
        public string errorMessage
        {
            get
            {
                return (OnlineExaminationMasterAndCourseApplicableDTO.errorMessage != null && OnlineExaminationMasterAndCourseApplicableDTO.errorMessage != "") ? OnlineExaminationMasterAndCourseApplicableDTO.errorMessage : string.Empty;
            }
            set
            {
                OnlineExaminationMasterAndCourseApplicableDTO.errorMessage = value;
            }
        }

    }
}
